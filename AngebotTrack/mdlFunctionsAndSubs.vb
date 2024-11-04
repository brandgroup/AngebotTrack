Imports System.IO
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraGrid.Views.Base

Module mdlFunctionsAndSubs
#Region "functions"
  Public Function check_changes(ByVal DS As DataSet) As Boolean
    Dim xTable As DataTable
    Dim lstxTables As New List(Of String)
    Dim dt As DataTable

    'Editmodus beenden
    For i As Integer = 0 To DS.Tables.Count - 1
      dt = DS.Tables(i)
      For j As Integer = 0 To dt.Rows.Count - 1
        dt(j).EndEdit()
      Next
    Next

    For i As Integer = 0 To DS.Tables.Count - 1
      xTable = DS.Tables(i).GetChanges
      If Not IsNothing(xTable) Then
        lstxTables.Add(xTable.ToString)
      End If
    Next

    If lstxTables.Count > 0 Then
      'For i As Integer = 0 To lstxTables.Count - 1
      '  Debug.Print("geändert: " & lstxTables(i))
      'Next
      Return True
    Else
      Return False
    End If
  End Function

  Public Function check_db_connection(ByVal strConString As String) As Boolean
    'prüft, ob die im Connectionstring angegebene Datenbankverbindung verfügbar ist
    Dim strServer As String = strConString.Substring(7, InStr(strConString, ";") - 8)
    Dim con As MySqlConnection

    If My.Computer.Network.Ping(strServer) = True Then
      Try
        con = New MySqlConnection(strConString)

        con.Open()

        con.Close()

        check_db_connection = True

      Catch ex As Exception
        WriteToErrorLog("Datenbankverbindung konnte nicht hergestellt werden", "Connectionstring: " & strConString, "sub check_db_needed")
        check_db_connection = False
      End Try
    Else
      WriteToErrorLog("Datenbankverbindung konnte nicht hergestellt werden", "Connectionstring: " & strConString, "sub check_db_needed")
      check_db_connection = False
    End If

  End Function

  Public Function check_db_needed() As String
    If check_db_connection(connectionstringCI) = False Then
      blconnectedDBCI = False
      strMissingDB = "- Common Interfaces"
    Else
      blconnectedDBCI = True
    End If

    If check_db_connection(connectionstringKalk) = False Then
      blconnectedDBKalk = False
      strMissingDB = strMissingDB & vbCrLf & "- Kalkulation"
    Else
      blconnectedDBKalk = True
    End If

    If blconnectedDBCI = False Or blconnectedDBKalk = False Then
      WriteToErrorLog("IP Server: " & strIPServer & vbCrLf & "ConnectionStringCI: " & connectionstringCI,
                      "Pfad OC: " & strPfadOrganisation_company & vbCrLf & "ConnectionStringKALK: " & connectionstringKalk,
                      "beim Start: ")

      Return "missing_db" & "|" & strMissingDB
    Else
      Return "ok"
    End If
  End Function

  Public Function ConvertToRecordset(inTable As DataTable) As ADODB.Recordset
    Dim result As New ADODB.Recordset()
    Dim columnIndex As Integer
    Dim dr As DataRow = Nothing

    result.CursorLocation = ADODB.CursorLocationEnum.adUseClient

    Dim resultFields As ADODB.Fields = result.Fields
    Dim inColumns As DataColumnCollection = inTable.Columns

    For Each inColumn As DataColumn In inColumns
      resultFields.Append(inColumn.ColumnName, TranslateType(inColumn.DataType), inColumn.MaxLength, If(inColumn.AllowDBNull, ADODB.FieldAttributeEnum.adFldIsNullable, ADODB.FieldAttributeEnum.adFldUnspecified), Nothing)
    Next

    result.Open(Reflection.Missing.Value, Reflection.Missing.Value, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0)

    Try
      For Each dr In inTable.Rows
        result.AddNew(Reflection.Missing.Value, Reflection.Missing.Value)

        For columnIndex = 0 To inColumns.Count - 1
          resultFields(columnIndex).Value = dr(columnIndex)
        Next
      Next
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in Function ConvertToRecordset" & vbCrLf &
                        "Wert:" & dr(columnIndex).ToString & vbCrLf &
                        "Column-Index: " & columnIndex & vbCrLf &
                        "Column-Name: " & resultFields(columnIndex).Name.ToString)

      Select Case strSprache
        Case "de-DE"
          strTextMsg = "Bei der Auswertung sind Fehler aufgetreten:" & vbCrLf & vbCrLf &
                       "Name des Feldes: " & resultFields(columnIndex).Name.ToString & vbCrLf &
                       "Wert des Feldes: " & dr(columnIndex).ToString
          strTitelMsg = "Auswertung Excel"
        Case Else
          strTextMsg = "error while collecting data:" & vbCrLf & vbCrLf &
                       "field: " & resultFields(columnIndex).Name.ToString & vbCrLf &
                       "value: " & dr(columnIndex).ToString
          strTitelMsg = "excel report"
      End Select

      MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

    Return result
  End Function
  Public Function copy_dir_and_files(ByVal sourceDirectory As String, ByVal targetDirectory As String) As List(Of String)
    Dim diSource As DirectoryInfo = New DirectoryInfo(sourceDirectory)
    Dim diTarget As DirectoryInfo = New DirectoryInfo(targetDirectory)
    Dim lstAntwort As New List(Of String)

    'prüfen, ob sourceDirectory existiert, sonst Abbruch
    Dim di As DirectoryInfo = New DirectoryInfo(sourceDirectory)

    If Not di.Exists Then
      lstAntwort.Add("- source directory missing")
    Else
      lstAntwort = CopyAll(diSource, diTarget)
    End If

    Return lstAntwort
  End Function

  Public Function count_max(ByVal sqlstring) As String
    Dim con As MySqlConnection
    Dim cmd As MySqlCommand
    Dim dt As New DataTable

    Dim myAdapter As New MySqlDataAdapter
    Dim myData As New DataTable

    Dim custRow As DataRow

    Dim x As String

    con = New MySqlConnection(connectionstring)

    con.Open()

    cmd = New MySqlCommand

    cmd.Connection = con

    cmd.CommandText() = sqlstring

    myAdapter.SelectCommand = cmd
    myAdapter.Fill(myData)

    con.Close()

    x = "0"

    For Each custRow In myData.Rows
      x = custRow.Item(0).ToString
    Next

    Return x

  End Function

  Public Function FileToArray(ByVal filePath As String) As String()
    Dim sr As StreamReader = Nothing

    Try
      sr = New StreamReader(filePath, Text.Encoding.Default)
      Return Text.RegularExpressions.Regex.Split(sr.ReadToEnd, "\r\n")
    Finally
      If Not sr Is Nothing Then sr.Close()
    End Try

  End Function

  Public Function fill_arraylist(ByVal sqlstring As String, ByVal trennzeichen As String, ByVal spalte As String)
    Dim datenArray As New ArrayList()
    Dim element, ds, tempds As String

    Dim con As MySqlConnection
    Dim cmd As MySqlCommand

    Dim myAdapter As New MySqlDataAdapter
    Dim myData As New DataTable

    Dim custRow As DataRow
    Dim a() As String

    con = New MySqlConnection(connectionstring)

    con.Open()

    Try
      cmd = New MySqlCommand

      cmd.Connection = con

      cmd.CommandText() = sqlstring

      myAdapter.SelectCommand = cmd
      myAdapter.Fill(myData)

      con.Close()

      For Each custRow In myData.Rows
        a = Split(spalte, ";")
        ds = ""
        For Each element In a
          If IsDBNull(custRow.Item(element)) Then
            tempds = ""
          Else
            tempds = custRow.Item(element)
          End If

          tempds = Replace(tempds, trennzeichen, " ")
          ds = ds & tempds & trennzeichen
        Next
        ds = ds.Substring(0, ds.Length - trennzeichen.Length)
        datenArray.Add(ds)
      Next

      Return datenArray
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function fill_arraylist" & vbCrLf & "SQL: " & sqlstring & vbCrLf & "Spalten: " & spalte)
      Return ""
    End Try

  End Function

  Public Function load_hsb(ByVal strID As String) As String
    Dim con As MySqlConnection = Nothing
    Dim cmd As MySqlCommand
    Dim myAdapter As New MySqlDataAdapter

    Dim strSQL As String = ""
    Dim strResult As String = ""

    Dim strRAE As String = ""
    Dim strNAE As String = ""
    Dim datAE As Date = Nothing

    Dim strRPROD As String = ""
    Dim strNPROD As String = ""
    Dim datPROD As Date = Nothing

    Dim strRQS As String = ""
    Dim strNQS As String = ""
    Dim datQS As Date = Nothing

    Dim strRALL As String = ""
    Dim strNALL As String = ""
    Dim datALL As Date = Nothing

    Dim nR As DataRow = Nothing

    con = New MySqlConnection(connectionstringKalk)

    Try
      con.Open()
      cmd = New MySqlCommand
      cmd.Connection = con
      myAdapter.SelectCommand = cmd

      strSQL = "SELECT " &
               "* " &
               "FROM " &
               "t_hsb " &
               "WHERE " &
               "id_angebot_reg = " & strIDAngebotReg & ""

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form_hsb.DataSet_hsb.Tables("Datatable_hsb"))

      strSQL = "SELECT " &
               "area," &
               "result_attribute," &
               "name," &
               "date_time_result " &
               "FROM " &
               "t_hsb " &
               "WHERE " &
               "id_angebot_reg = " & strIDAngebotReg & " " &
               "AND " &
               "area = 'ae'" &
               "AND " &
               "attribute = 'result' "

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results"))

      strSQL = "SELECT " &
               "area," &
               "result_attribute," &
               "name," &
               "date_time_result " &
               "FROM " &
               "t_hsb " &
               "WHERE " &
               "id_angebot_reg = " & strIDAngebotReg & " " &
               "AND " &
               "area = 'prod'" &
               "AND " &
               "attribute = 'result' "

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results"))

      strSQL = "SELECT " &
               "area," &
               "result_attribute," &
               "name," &
               "date_time_result " &
               "FROM " &
               "t_hsb " &
               "WHERE " &
               "id_angebot_reg = " & strIDAngebotReg & " " &
               "AND " &
               "area = 'qs'" &
               "AND " &
               "attribute = 'result' "

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results"))

      strSQL = "SELECT " &
               "area," &
               "result_attribute," &
               "name," &
               "date_time_result " &
               "FROM " &
               "t_hsb " &
               "WHERE " &
               "id_angebot_reg = " & strIDAngebotReg & " " &
               "AND " &
               "area = 'result'" &
               "AND " &
               "attribute = 'result_all' "

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results"))

      'For i As Integer = 0 To Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results").Rows.Count - 1
      '  Debug.Print("area: " & Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("area"))
      '  Debug.Print("result_attribute: " & Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("result_attribute"))
      '  Debug.Print("name: " & Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("name"))
      '  Debug.Print("date_time_result: " & Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result"))
      '  Debug.Print("---")
      'Next

      For i As Integer = 0 To Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results").Rows.Count - 1
        'Debug.Print("id: " & Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("id"))
        'Debug.Print("area: " & Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("area"))
        'Debug.Print("result_attribute: " & Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("result_attribute"))
        With Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("area")
          Select Case True
            Case .contains("ae")
              strRAE = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("result_attribute")
              strNAE = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("name")
              If IsDBNull(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")) Then
                datAE = ""
              Else
                datAE = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")
              End If
            Case .contains("prod")
              strRPROD = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("result_attribute")
              strNPROD = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("name")
              If IsDBNull(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")) Then
                datPROD = ""
              Else
                datPROD = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")
              End If
            Case .contains("qs")
              strRQS = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("result_attribute")
              strNQS = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("name")
              If IsDBNull(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")) Then
                datQS = ""
              Else
                datQS = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")
              End If
            Case .contains("result")
              strRALL = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("result_attribute")
              strNALL = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("name")
              If IsDBNull(Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")) Then
                datALL = ""
              Else
                datALL = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_all_results")(i)("date_time_result")
              End If
          End Select
        End With
      Next

      nR = Form_hsb.DataSet_hsb.Tables("DataTable_hsb_result").NewRow()
      nR("result_ae") = strRAE
      nR("result_prod") = strRPROD
      nR("result_qs") = strRQS
      nR("result_all") = strRALL
      nR("name_ae") = strNAE
      nR("name_prod") = strNPROD
      nR("name_qs") = strNQS
      nR("name_all") = strNALL
      nR("date_time_result_ae") = datAE
      nR("date_time_result_prod") = datPROD
      nR("date_time_result_qs") = datQS
      nR("date_time_result_all") = datALL
      Form_hsb.DataSet_hsb.Tables("DataTable_hsb_result").Rows.Add(nR)

      strResult = "ok"
    Catch ex As Exception
      strResult = "error"
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function load_hsb" & vbCrLf & "ID: " & strID)
    End Try

    con.Close()

    Return strResult
  End Function

  Public Function fill_intenal_tables() As String
    Dim con As MySqlConnection = Nothing
    Dim cmd As MySqlCommand
    Dim myAdapter As New MySqlDataAdapter

    Dim strSQL As String = ""
    Dim intMaxID As Integer = 0


    Dim strOrderBy As String = ""

    Dim strOrg As String = ""
    Dim strDiv As String = ""
    Dim strPla As String = ""

    Try

#Region "fill_angebot_track"
      con = New MySqlConnection(connectionstringKalk)

      con.Open()
      cmd = New MySqlCommand
      cmd.Connection = con
      myAdapter.SelectCommand = cmd

      'die Tabelle t_angebot_tracking soll nur die Vertriebsbereiche enthalten, für die der User freigeschaltet ist
      'die Liste der entsprechenden Vertriebsbereiche findet sich in lstVertriebsbereich
      For i As Integer = 0 To lstVertriebsbereich.Count - 1
        lstODP = lstVertriebsbereich(i).Split("-").ToList
        strOrg = strOrg & "'" & lstODP(0) & "',"
        strDiv = strDiv & "'" & lstODP(1) & "',"
        strPla = strPla & "'" & lstODP(2) & "',"
      Next

      strOrg = strOrg.Substring(0, strOrg.Length - 1)
      strDiv = strDiv.Substring(0, strDiv.Length - 1)
      strPla = strPla.Substring(0, strPla.Length - 1)

      strWhereVB = "org_company IN (" & strOrg & ") AND org_division IN (" & strDiv & ") AND org_plant IN (" & strPla & ") "

      'Sortierung nach: Jahr / Monat / Angebot-Nr.
      'strOrderBy = "ORDER BY " &
      '             "CAST((substring_index(angebot_nr, ""/"", - 1)) AS DECIMAL) DESC, " &
      '             "CAST((substring_index(angebot_nr, ""/"", 1)) AS DECIMAL) DESC, " &
      '             "CAST((substr(angebot_nr, instr(angebot_nr, ""/"") + 1, instr(substr(angebot_nr, instr(angebot_nr, ""/"") + 1), ""/"") - 1)) AS DECIMAL) DESC"

      strOrderBy = "ORDER BY 
                    org_company,
                    org_division,
                    id_tracking DESC"

      'Tracking
      strSQL = "SELECT 
                * 
                FROM 
                t_angebot_tracking 
                WHERE 
                isnull(time_delete) 
                AND " &
                strWhereVB &
                strOrderBy

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form1.DataSet_tracking.Tables("DataTable_tracking"))

      'Angebot-Registrierung
      strSQL = "SELECT " &
               "id," &
               "id_tracking," &
               "angebot_nr," &
               "angebot_nr_neu," &
               "angebot_nr_ind," &
               "zeit_datum_angebot_bis," &
               "kunde," &
               "federtyp," &
               "znr," &
               "ind," &
               "jahresbedarf," &
               "losgroesse," &
               "machbarkeit," &
               "pb," &
               "mit_zukaufteilen," &
               "mit_ext_ag," &
               "zeit_datum_berechnung_erstellt," &
               "zeit_datum_hsb_erstellt_ae," &
               "zeit_datum_hsb_erstellt_prod," &
               "zeit_datum_hsb_erstellt_qm," &
               "zeit_datum_hsb_freigegeben," &
               "zeit_datum_zukaufteile_angefragt," &
               "zeit_datum_ext_bearbeitung_angefragt," &
               "zeit_datum_zukaufteile_angebot_erhalten," &
               "zeit_datum_ext_bearbeitung_angebot_erhalten," &
               "zeit_datum_kalkulation_erstellt," &
               "status_angebot," &
               "bem_angeb_reg," &
               "machbarkeit_ae," &
               "machbarkeit_prod," &
               "machbarkeit_qm," &
               "org_company, " &
               "org_division, " &
               "org_plant " &
               "FROM " &
               "t_angebot_reg " &
               "WHERE " &
               strWhereVB &
               "AND " &
               "NOT ISNULL(id_tracking) " &
               "AND " &
               "ISNULL(time_delete) " &
               strOrderBy

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form1.DataSet_tracking.Tables("DataTable_AngebotReg"))

      'Tabelle Setup
      strSQL = "SELECT " &
               "* " &
               "FROM " &
               "t_setup"

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form1.DataSet_tracking.Tables("DataTable_SetUp"))

      con.Close()
#End Region

#Region "fill_internal_ci"
      'WriteToErrorLog("", "", "fill_angebot_reg" & vbCrLf &
      '                "connectionstringCI,: " & connectionstringCI)
      con = New MySqlConnection(connectionstringCI)
      con.Open()
      cmd = New MySqlCommand
      cmd.Connection = con
      myAdapter.SelectCommand = cmd

      'Viele Werteliste werden immer aus der Tabelle "items_mdata" gefüllt!
      'feststehende Begriffe
      strSQL = "SELECT " &
               "* " &
               "FROM " &
               "items_mdata"

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form1.DataSet_tracking.Tables("DataTable_items_mdata"))

      'myDataCI_Organisation_mdata
      strSQL = "SELECT " &
               "* " &
               "FROM " &
               "organisation_mdata"

      cmd.CommandText() = strSQL
      myAdapter.Fill(Form1.DataSet_tracking.Tables("DataTable_organisation_mdata"))

      con.Close()

#End Region

    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub fill_internal_tables" & vbCrLf & "SQL: " & strSQL)
      con.Close()
      connectionstring = connectionstringKalk
      Return "error" & "|" & ex.Message
    End Try

    Return "ok"

  End Function

  Public Function formatiere_datum_fuer_db(ByVal strDatum As String) As String
    Try
      If String.IsNullOrEmpty(strDatum) Then
        Return "NULL"
        Exit Function
      End If

      If Not IsDate(strDatum) Then
        Return "NULL"
        Exit Function
      End If

      Dim strJahr As String
      Dim strMonat As String
      Dim strTag As String

      strTag = strDatum.Substring(0, 2)
      strMonat = strDatum.Substring(3, 2)
      strJahr = strDatum.Substring(6, 4)

      Return "'" & strJahr & "-" & strMonat & "-" & strTag & "'"
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function formatiere_datum_fuer_db" & vbCrLf & "übergebener Wert für Datum: " & strDatum)
      Return "NULL"
    End Try
  End Function

  Public Function get_file_lwt(ByVal fsi As FileSystemInfo) As Date
    'gibt Datum und Uhrzeit des letzten Schreibzugriffes des übergebenen Files zurück
    get_file_lwt = fsi.LastWriteTime
  End Function

  Public Function GetFilteredData(ByVal view As ColumnView) As DataView
    If view Is Nothing Then
      Return Nothing
    End If
    If view.ActiveFilter Is Nothing OrElse (Not view.ActiveFilterEnabled) OrElse view.ActiveFilter.Expression = "" Then
      Return TryCast(view.DataSource, DataView)
    End If

    'Dim obj As Object = view.DataSource.GetType()

    Dim table As DataTable = (CType(view.DataSource, DataView)).Table
    Dim filteredDataView As New DataView(table)
    Return filteredDataView
  End Function

  Public Function getOrganisation_company() As String
    'auf Basis der ermittelten IP-Adresse das Werk(plant) bestimmen
    Dim strOrgComp As String = "unbekannt"

    Dim lst_IP As New ArrayList

    For Each netinterface As Net.NetworkInformation.NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
      If netinterface.OperationalStatus = Net.NetworkInformation.OperationalStatus.Up AndAlso
            netinterface.NetworkInterfaceType <> Net.NetworkInformation.NetworkInterfaceType.Loopback Then
        For Each ipAddr As Net.NetworkInformation.UnicastIPAddressInformation In netinterface.GetIPProperties.UnicastAddresses
          lst_IP.Add(ipAddr.Address.ToString)
        Next
      End If
    Next

    If lst_IP.Count > 0 Then
      For i As Integer = 0 To lst_IP.Count - 1
        With lst_IP(i)
          Select Case True
            Case .Contains("172.30") 'Anröchte
              strOrgComp = "BRA"
            Case .Contains("172.20") 'Erwitte
              strOrgComp = "BRA"
            Case .Contains("172.25") 'Lüdenscheid
              strOrgComp = "MFW"
            Case .Contains("10.150") 'BKL-CN
              strOrgComp = "BKC"
            Case .Contains("10.160") 'BKL-MX
              strOrgComp = "BKM"
            Case .Contains("10.170") 'BSP
              strOrgComp = "BSP"
            Case .Contains("192.168.23") 'BOS
              strOrgComp = "BOS"
            Case .Contains("192.168.178") 'Heyder, lokal = A
              strOrgComp = "BRA"
          End Select
        End With
      Next
    End If

    Return strOrgComp
  End Function

  Public Function getPlant() As String
    'auf Basis der ermittelten IP-Adresse das Werk(plant) bestimmen
    Dim strPlant As String = "unbekannt"

    Dim lst_IP As New ArrayList

    For Each netinterface As Net.NetworkInformation.NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
      If netinterface.OperationalStatus = Net.NetworkInformation.OperationalStatus.Up AndAlso
            netinterface.NetworkInterfaceType <> Net.NetworkInformation.NetworkInterfaceType.Loopback Then
        For Each ipAddr As Net.NetworkInformation.UnicastIPAddressInformation In netinterface.GetIPProperties.UnicastAddresses
          lst_IP.Add(ipAddr.Address.ToString)
        Next
      End If
    Next

    If lst_IP.Count > 0 Then
      For i As Integer = 0 To lst_IP.Count - 1
        With lst_IP(i)
          Select Case True
            Case .Contains("172.30") 'Anröchte
              strPlant = "A"
            Case .Contains("172.20") 'Erwitte
              strPlant = "E"
            Case .Contains("172.25") 'Lüdenscheid
              strPlant = "L"
            Case .Contains("10.150") 'BKL-CN
              strPlant = "T"
            Case .Contains("10.160") 'BKL-MX
              strPlant = "Q"
            Case .Contains("10.170") 'BSP
              strPlant = "R"
            Case .Contains("192.168.23") 'BOS
              strPlant = "F"
            Case .Contains("192.168.178") 'Heyder, lokal = A
              strPlant = "A"
          End Select
        End With
      Next
    End If

    Return strPlant
  End Function

  Public Function hk(ByVal strHk As String) As String
    'gibt einen String zurück, der die Speicherung von Hochkommata in MySQL ermöglicht
    'vorformatierte Datum-Strings (nach dem Muster "'YYYY-MM-DD'") bleiben jedoch unverändert
    Dim strSuchString As String = Chr(39)

    If Len(strHk) > 1 Then
      If strHk.Substring(0, 2).IndexOf(strSuchString) < 0 Then
        hk = Replace(strHk, "'", "\'")
      Else
        hk = strHk
      End If
    Else
      hk = strHk
    End If

  End Function

  Public Function make_now_to_string() As String
    Return DateTime.Now.ToString("yyyy") & DateTime.Now.ToString("MM") & DateTime.Now.ToString("dd")
  End Function

  Public Function stringding(ByVal name As String, ByVal VerEnt As String) As String
    Dim c As Char
    Dim neu As String = ""
    Dim neu2 As String = ""
    Dim test As String = ""

    Dim i As Integer
    Dim j As Integer

    Dim zufall As New Random

    If VerEnt = "ver" Then
      For Each c In name
        neu = neu & Convert.ToInt32(c).ToString("x")
      Next

      j = 3

      For i = 0 To neu.Length - 1
        j += 1
        neu2 = neu2 & Chr(CInt("&H" & zufall.Next(4, 8) & neu.Substring(i, 1)))
        If j = 7 Then
          j = 3
        End If
      Next
      name = neu2
    Else
      For Each c In name
        neu = neu & Convert.ToInt32(c).ToString("x")
      Next
      name = neu
      neu = ""
      i = 0
      For Each c In name
        If i = 1 Then
          neu = neu & c
          i = 0
        Else
          i = 1
        End If
      Next

      For i = 0 To neu.Length - 2 Step 2
        neu2 = neu2 & Chr(CInt("&H" & neu.Substring(i, 2)))
      Next

      name = neu2

    End If

    Return name

  End Function

  Public Function string_truncate(ByVal strToTruncate As String, ByVal intLength As Integer) As String
    If strToTruncate.Length > intLength Then
      Return strToTruncate.Substring(0, intLength)
    Else
      Return strToTruncate
    End If
  End Function

  Private Function TranslateType(columnType As Type) As ADODB.DataTypeEnum
    Select Case columnType.UnderlyingSystemType.ToString()
      Case "System.Boolean"
        Return ADODB.DataTypeEnum.adBoolean

      Case "System.Byte"
        Return ADODB.DataTypeEnum.adUnsignedTinyInt

      Case "System.Char"
        Return ADODB.DataTypeEnum.adChar

      Case "System.DateTime"
        Return ADODB.DataTypeEnum.adDate

      Case "System.Decimal"
        Return ADODB.DataTypeEnum.adCurrency

      Case "System.Double"
        Return ADODB.DataTypeEnum.adDouble

      Case "System.Int16"
        Return ADODB.DataTypeEnum.adSmallInt

      Case "System.Int32"
        Return ADODB.DataTypeEnum.adInteger

      Case "System.Int64"
        Return ADODB.DataTypeEnum.adBigInt

      Case "System.SByte"
        Return ADODB.DataTypeEnum.adTinyInt

      Case "System.Single"
        Return ADODB.DataTypeEnum.adSingle

      Case "System.UInt16"
        Return ADODB.DataTypeEnum.adUnsignedSmallInt

      Case "System.UInt32"
        Return ADODB.DataTypeEnum.adUnsignedInt

      Case "System.UInt64"
        Return ADODB.DataTypeEnum.adUnsignedBigInt

      Case "System.String"
        Return ADODB.DataTypeEnum.adVarChar
      Case Else
        Return ADODB.DataTypeEnum.adVarChar
    End Select
  End Function

  Public Function update_insert_delete(ByVal strSQLstring As String, Optional blSemiKFiltern As Boolean = True, Optional strConString As String = "/",
                                       Optional strAufgerufen_von As String = "/") As String
    'Bei Bedarf kann der Funktion vorgegeben werden:
    '- dass das Semikolon ";" nicht ausgefiltert wird - Parameter blSemiKFiltern
    '- welcher strCon verwendet werden soll - Parameter strConstring

    Dim strCon As String = connectionstring

    If strConString = "/" Then
      strCon = strCon
    Else

      strCon = strConString
    End If

    Dim con As MySqlConnection = New MySqlConnection(strCon)
    Dim cmd As New MySqlCommand
    Dim id As String = ""

    Try
      con = New MySqlConnection(strCon)

      con.Open()

      cmd.Connection = con

      If blSemiKFiltern = True Then
        strSQLstring = Replace(strSQLstring, ";", " ")
      End If

      cmd.CommandText() = strSQLstring

      cmd.ExecuteNonQuery()

      id = cmd.LastInsertedId

      con.Close()

      Threading.Thread.Sleep(20)

      Return id
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler bei update_insert_delete" & vbCrLf &
                      "SQL: " & strSQLstring & vbCrLf &
                      "aufgerufen von: " & strAufgerufen_von)

      Return "error"
    End Try

  End Function

  Public Function WorkingDays(ByVal DateStart As Date, ByVal DateEnd As Date) As Integer
    ' Zeit-Differenz in Tagen
    Dim Days As Integer = DateEnd.Subtract(DateStart).Days + 1
    Dim DaysWeekend As Integer = 0

    ' Anzahl Wochenend-Tage ermitteln
    For i As Integer = 0 To Days - 1
      Select Case DateStart.AddDays(i).DayOfWeek
        Case DayOfWeek.Saturday, DayOfWeek.Sunday
          DaysWeekend += 1
      End Select
    Next

    ' Arbeitstage = Anzahl Tage - Wochenend-Tage
    Return Days - DaysWeekend
  End Function

#End Region

#Region "subs"
  Public Sub aendern_sprache(ByVal strSpracheGewaehlt As String)
    If strSpracheGewaehlt = strSprache Then Exit Sub

    Dim strSetUpLanguage As String = "Sprache (language);" & strSpracheGewaehlt
    Dim lines() As String = File.ReadAllLines(Application.StartupPath & "\" & suser & ".ini")

    'Spracheinstellung immer in der zweiten Zeile der ini!
    lines(1) = strSetUpLanguage

    Dim strIniText = String.Join(vbCrLf, lines).TrimEnd(vbCrLf)

    'Änderung in lokale ini schreiben
    File.WriteAllText(Application.StartupPath & "\" & suser & ".ini", strIniText)

    'wenn eine Verbindung zum Server besteht, die Änderungen auch in der dort vorhandenen User.ini vornehmen
    If blFileServerPresent = True Then
      File.WriteAllText(strIniPath, strIniText)
    End If

    Application.Restart()
  End Sub

  Public Sub anzeigen_doku()
    Try
      Process.Start(Application.StartupPath & "\doku_angebot_track.pdf")
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub anzeigen_doku")
    End Try
  End Sub

  Public Sub connection_label()
    Dim colF As Color
    Dim colB As Color

    Form1.BarStaticItem_connection.Caption = strServerConnected

    Select Case LCase(strServerConnected)
      Case "mysql-a"
        colB = Color.LightGreen
        colF = Color.Black
      Case "mysql-e"
        colB = Color.LightGreen
        colF = Color.Black
      Case "mysql-bklcn"
        colB = Color.LightGreen
        colF = Color.Black
      Case "mysql-bklmx"
        colB = Color.LightGreen
        colF = Color.Black
      Case "mysql-bsp"
        colB = Color.LightGreen
        colF = Color.Black
      Case "mysql-local", "mysql-test"
        colB = Color.Yellow
        colF = Color.Black
      Case "mysql-mfw"
        colB = Color.Red
        colF = Color.White
      Case Else

    End Select

    Form1.BarStaticItem_connection.ItemAppearance.Normal.BackColor = colB
    Form1.BarStaticItem_connection.ItemAppearance.Normal.ForeColor = colF
  End Sub

  Public Function CopyAll(ByVal SourceDir As DirectoryInfo, ByVal DestDir As DirectoryInfo) As List(Of String)
    Dim intCompareResult As Integer = Nothing
    Dim fviSource As FileVersionInfo = Nothing
    Dim fviDest As FileVersionInfo = Nothing
    Dim lstFileNames As New List(Of String)

    'prüfen, ob das Zielverzeichnis existiert, bei Bedarf erstellen
    If Directory.Exists(DestDir.FullName) = False Then
      Directory.CreateDirectory(DestDir.FullName)
    End If

    For Each SourceFile As FileInfo In SourceDir.GetFiles
      Try
        If Not SourceFile.Name = Application.ProductName & ".exe" Then
          If File.Exists(Path.Combine(DestDir.ToString(), SourceFile.Name)) Then 'wenn File bereits vorhanden Vergleich auf neuere Version
            'Dim DestFile As New FileInfo(SourceFile.Name)
            If SourceFile.Extension = ".dll" Then
              fviSource = FileVersionInfo.GetVersionInfo(Path.Combine(SourceDir.ToString(), SourceFile.Name))
              For Each DestFile As FileInfo In DestDir.GetFiles
                fviDest = FileVersionInfo.GetVersionInfo(Path.Combine(DestDir.ToString(), DestFile.Name))
                If fviSource.InternalName = fviDest.InternalName Then
                  If fviDest.FileVersion < fviSource.FileVersion Then
                    SourceFile.CopyTo(Path.Combine(DestDir.ToString(), SourceFile.Name), True)
                    WriteToErrorLog("ältere dll wurde überschrieben: " & DestFile.FullName & vbCrLf &
                                    "Version, ältere: " & fviDest.FileVersion.ToString & vbCrLf &
                                    "Version, auf Server: " & fviSource.FileVersion.ToString, "", "Sub CopyAll")
                  End If
                End If
              Next
            Else
              fviSource = FileVersionInfo.GetVersionInfo(Path.Combine(SourceDir.ToString(), SourceFile.Name))
              For Each DestFile As FileInfo In DestDir.GetFiles
                If DestFile.Name = SourceFile.Name Then
                  intCompareResult = DateTime.Compare(get_file_lwt(DestFile), get_file_lwt(SourceFile))
                  If intCompareResult < 0 Then 'File in Dest ist älter als File in Source
                    SourceFile.CopyTo(Path.Combine(DestDir.ToString(), SourceFile.Name), True)
                    WriteToErrorLog("ältere Datei wurde überschrieben: " & DestFile.FullName & vbCrLf &
                                    "Datum, ältere: " & get_file_lwt(DestFile) & vbCrLf &
                                    "Datum, auf Server: " & get_file_lwt(SourceFile), "", "Sub CopyAll")
                  End If
                End If
              Next
            End If
          Else
            SourceFile.CopyTo(Path.Combine(DestDir.ToString(), SourceFile.Name), True)
            lstFileNames.Add("- file added: " & SourceFile.Name)
            WriteToErrorLog("nicht vorhandene Datei wurde ins Programmverzeichnis kopiert: " & SourceFile.Name, "", "Sub CopyAll")
          End If
        End If
      Catch ex As Exception
        lstFileNames.Add("error")
        WriteToErrorLog(ex.Message, ex.StackTrace,
                        "Sub CopyAll " & vbCrLf &
                        "Datei konnte nicht ins Programmverzeichnis kopiert werden: " & SourceFile.FullName)
      End Try
    Next

    ' Copy each subdirectory using recursion.
    For Each diSourceSubDir As DirectoryInfo In SourceDir.GetDirectories()
      Dim nextTargetSubDir As DirectoryInfo = DestDir.CreateSubdirectory(diSourceSubDir.Name)
      CopyAll(diSourceSubDir, nextTargetSubDir)
    Next

    If lstFileNames.Count = 0 Then lstFileNames.Add("- no newer or missing files")

    Return lstFileNames
  End Function

  Public Sub fill_box_from_datatable(ByVal box As Object,
                                        ByVal strDataTableName As String,
                                        ByVal strFilter As String,
                                        ByVal strColName As String,
                                        Optional ByVal strOrder As String = "",
                                        Optional ByVal blDistinct As Boolean = False,
                                        Optional ByVal strAufgerufenVon As String = "-")

    Dim result() As DataRow

    Try
      If blDistinct = True Then
        Dim distinctDT As DataTable

        If Not String.IsNullOrEmpty(strFilter) Then
          Dim view As DataView = New DataView(Form1.DataSet_tracking.Tables(strDataTableName))
          view.RowFilter = strFilter
          If Not String.IsNullOrEmpty(strOrder) Then
            view.Sort = strOrder
          End If

          distinctDT = view.ToTable(True, strColName)
          result = distinctDT.Select()
        Else
          distinctDT = Form1.DataSet_tracking.Tables(strDataTableName).DefaultView.ToTable(True, strColName)
          result = distinctDT.Select(strFilter, strOrder)
        End If

      Else
        result = Form1.DataSet_tracking.Tables(strDataTableName).Select(strFilter, strOrder)
      End If

      If TypeOf (box) Is DevExpress.XtraEditors.ComboBoxEdit Then
        box.Properties.Items.Clear()
      ElseIf TypeOf (box) Is DevExpress.XtraEditors.Repository.RepositoryItemComboBox Then
        box.Items.Clear()
      ElseIf TypeOf (box) Is ToolStripComboBox Then
        box.Items.Clear()
      End If

      If result.Count > 0 Then
        If TypeOf (box) Is DevExpress.XtraEditors.ComboBoxEdit Then
          For i As Integer = 0 To result.Count - 1
            If Not IsDBNull(result(i)(strColName)) Then
              box.Properties.Items.Add(result(i)(strColName))
            End If
          Next
        ElseIf TypeOf (box) Is DevExpress.XtraEditors.Repository.RepositoryItemComboBox Then
          For i As Integer = 0 To result.Count - 1
            If Not IsDBNull(result(i)(strColName)) Then
              box.Items.Add(result(i)(strColName))
            End If
          Next
        End If
      ElseIf TypeOf (box) Is ToolStripComboBox Then
        For i As Integer = 0 To result.Count - 1
          If Not IsDBNull(result(i)(strColName)) Then
            box.Items.Add(result(i)(strColName))
          End If
        Next
      End If
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Form1 sub fill_box_from_datatable aufgerufen von: " & strAufgerufenVon & vbCrLf &
                    "Box: " & box.ToString & vbCrLf &
                    "DataTable: " & strDataTableName & vbCrLf &
                    "Filter: " & strFilter & vbCrLf &
                    "strColName: " & strColName & vbCrLf &
                    "Order: " & strOrder & vbCrLf &
                    "Distinct: " & blDistinct)
    End Try

  End Sub

  Public Sub fill_table(ByVal dt As DataTable)
    Dim con As MySqlConnection = Nothing
    Dim cmd As MySqlCommand = Nothing
    Dim myAdapter As New MySqlDataAdapter

    Dim strSQL As String = ""

    Select Case dt.TableName
      Case "dtRD"
        strSQL = "SELECT 
                  org_company,
                  org_division,
                  datum_angelegt_am,
                  angebot_nr,
                  kunde,
                  anzahl_teile,
                  pb,
                  name_kunden_manager,
                  bearbeitet_von,
                  zeit_datum_angefragt_am,
                  zeit_datum_angebot_bis,
                  tracking_abgabe_termin,
                  prio,
                  zukaufteile_erforderlich,
                  ext_bearbeitung_erforderlich,
                  zeit_datum_berechnung_vorhanden,
                  zeit_datum_hsb_vorhanden_ae,
                  zeit_datum_hsb_vorhanden_prod,
                  zeit_datum_hsb_vorhanden_qm,
                  zeit_datum_hsb_freigegeben,
                  zeit_datum_zukaufteile_angefragt,
                  zeit_datum_ext_bearbeitung_angefragt,
                  zeit_datum_zukaufteile_angebot_vorhanden,
                  zeit_datum_ext_bearbeitung_angebot_vorhanden,
                  zeit_datum_kalk_erstellt,
                  status_bearbeitung,
                  bemerkungen_tracking 
                  FROM 
                  t_angebot_tracking 
                  WHERE 
                  ISNULL(time_delete) 
                  AND 
                  status_bearbeitung = 'offen'
                  "
    End Select

    con = New MySqlConnection(connectionstringKalk)

    con.Open()

    Try
      cmd = New MySqlCommand
      cmd.Connection = con
      myAdapter.SelectCommand = cmd

      cmd.CommandText() = strSQL
      myAdapter.Fill(dt)
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler n Sub fill_table")
    End Try

    con.Close()
  End Sub

  Public Sub fill_znr_suchen()
    Dim vFiltered As DataView = GetFilteredDataSource(Form1.BandedGridView_tracking)
    Dim dtAT As DataTable = vFiltered.ToTable
    Dim dtAR As DataTable = Form1.DataSet_tracking.Tables("DataTable_AngebotReg")
    Dim dtResult As DataTable = Nothing

    'Dim query = From at In dtAT.AsEnumerable
    '            Join ar In dtAR.AsEnumerable
    '               On ar("id_tracking") Equals at("id_tracking")
    '            Order By ar("znr")
    '            Select New With {
    '                              .ZNr = ar.Field(Of String)("znr"),
    '                              .ANr_alt = ar.Field(Of String)("angebot_nr"),
    '                              .ANr_neu = Convert.ToInt32(ar.Field(Of String)("angebot_nr_neu")).ToString("000-000") &
    '                              "_" &
    '                              Convert.ToInt32(ar.Field(Of String)("angebot_nr_ind")).ToString("00")
    '                            }

    Dim query = From at In dtAT.AsEnumerable
                Join ar In dtAR.AsEnumerable
                   On ar("id_tracking") Equals at("id_tracking")
                Order By ar("znr")
                Select New With {
                                  .ZNr = ar.Field(Of String)("znr"),
                                  .ANr = If(ar.Field(Of String)("angebot_nr").Contains("?"),
                                            Convert.ToInt32(ar.Field(Of String)("angebot_nr_neu")).ToString("000-000") &
                                            "_" &
                                            Convert.ToInt32(ar.Field(Of String)("angebot_nr_ind")).ToString("00"),
                                            ar.Field(Of String)("angebot_nr"))
                                }

    dtResult = query.CopyToDataTable

    dtResult.Columns(0).ColumnName = "Zeichnung-Nr."
    dtResult.Columns(1).ColumnName = "Angebots-Nr."

    Form1.RepositoryItemSearchLookUpEdit_znr.DataSource = dtResult

  End Sub

  Public Sub ini_laden()
    Try
      strBerechtigung = LCase(FileToArray(strIniPath)(0).Substring(InStr(FileToArray(strIniPath)(0), ";")))
      strSprache = FileToArray(strIniPath)(1).Substring(InStr(FileToArray(strIniPath)(1), ";"))
      strConnectionType = FileToArray(strIniPath)(2).Substring(InStr(FileToArray(strIniPath)(2), ";"))
      strVertriebsbereich = FileToArray(strIniPath)(3).Substring(InStr(FileToArray(strIniPath)(3), ";"))
      lstVertriebsbereich = strVertriebsbereich.Split(";").ToList
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub ini_laden")
    End Try
  End Sub

  Public Sub read_user_settings()
    Try
      If File.Exists(Application.StartupPath & strUserSettingsAT) Then
        Form1.GridControl_tracking.ForceInitialize()
        Form1.GridControl_tracking.MainView.RestoreLayoutFromXml(Application.StartupPath & strUserSettingsAT)
      End If
      If File.Exists(Application.StartupPath & strUserSettingsAR) Then
        Form1.GridControl_AngebotReg.ForceInitialize()
        Form1.GridControl_AngebotReg.MainView.RestoreLayoutFromXml(Application.StartupPath & strUserSettingsAR)
      End If
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function read_user_settings")
    End Try

  End Sub

  Public Sub send_email(ByVal strMailAdress As String, ByVal strBodyText As String)
    Dim strMailTo As String = "mailto:" & "mheyder@brand-group.com" & "?subject=" & "Auftrag abgeschlossen" & "&body=" & "Test für Text"

    Dim strSubject As String = "?subject=" & "HSB vollständig"
    Dim strBody As String = "&body=" & strBodyText
    Dim strSignature As String = "%0d%0A" & "Dies ist eine automatisch erstellte Email" & "%0d%0A" & "Bitte nicht auf diese Email antworten"

    strMailTo = "mailto:" & strMailAdress & strSubject & strBody & "%0d%0A" & strSignature

    Process.Start(strMailTo)
  End Sub

  Public Sub setConnection(ByVal strServerGewaehlt As String)
    Select Case strServerGewaehlt
      Case "MySQL-A"
        connectionstringKalk = "server=" & strIPServerBrand & ";user id=kalkulation; password='" & stringding("FkfqvlFkwuVlVAGdFiFoFn", "ent") & "'; database=kalkulation_kompo; pooling=false; UseCompression=True"
        connectionstringFed = "server=" & strIPServerBrand & ";user id=td; password='" & stringding("GdVD", "ent") & "'; database=federstammdaten; pooling=false; UseCompression=True"
        connectionstringFoss = "server=" & strIPServerBrand & ";user id=td; password='" & stringding("GdVD", "ent") & "'; database=foss; pooling = false; UseCompression=True"
        connectionstringCI = "server=" & strIPServerBrand & ";user id=root; password='" & stringding("WBvof_GTW@vbcbsicr", "ent") & "'; database=common_interfaces; pooling = false; UseCompression=True"
      Case "MySQL-E"

      Case "MySQL-BKLCN"
        'connectionstringKalk = "server=" & strIPServerBKLCN & ";user id=kalkulation; password=kalkulation; database=kalkulation_kompo; pooling=false; UseCompression=True"
        'connectionstringFed = "server=" & strIPServerBKLCN & ";user id=td; password=td; database=federstammdaten; pooling=false; UseCompression=True"
        'connectionstringFoss = "server=" & strIPServerBKLCN & ";user id=td; password=td; database=foss; pooling = false; UseCompression=True"
        'connectionstringCI = "server=" & strIPServerBKLCN & ";user id=root; password=rootpb292; database=common_interfaces; pooling = false; UseCompression=True"
      Case "MySQL-BKLMX"
        'connectionstringKalk = "server=" & strIPServerBKLMX & ";user id=kalkulation; password=kalkulation; database=kalkulation_kompo; pooling=false; UseCompression=True"
        'connectionstringFed = "server=" & strIPServerBKLMX & ";user id=td; password=td; database=federstammdaten; pooling=false; UseCompression=True"
        'connectionstringFoss = "server=" & strIPServerBKLMX & ";user id=td; password=td; database=foss; pooling = false; UseCompression=True"
        'connectionstringCI = "server=" & strIPServerBKLMX & ";user id=root; password=rootpb292; database=common_interfaces; pooling = false; UseCompression=True"
      Case "MySQL-BSP"
        'connectionstringKalk = "server=" & strIPServerBSP & ";user id=kalkulation; password=kalkulation; database=kalkulation_kompo; pooling=false; UseCompression=True"
        'connectionstringFed = "server=" & strIPServerBSP & ";user id=td; password=td; database=federstammdaten; pooling=false; UseCompression=True"
        'connectionstringFoss = "server=" & strIPServerBSP & ";user id=td; password=td; database=foss; pooling = false; UseCompression=True"
        'connectionstringCI = "server=" & strIPServerBSP & ";user id=root; password=rootpb292; database=common_interfaces; pooling = false; UseCompression=True"
      Case "MySQL-MFW"
        'connectionstringKalk = "server=" & strIPServerMFW & ";user id=kalkulation; password=kalkulation; database=kalkulation_kompo; pooling=false; UseCompression=True"
        'connectionstringFed = "server=" & strIPServerMFW & ";user id=td; password=td; database=federstammdaten; pooling=false; UseCompression=True"
        'connectionstringFoss = "server=" & strIPServerMFW & ";user id=td; password=td; database=foss; pooling = false; UseCompression=True"
        'connectionstringCI = "server=" & strIPServerMFW & ";user id=root; password=rootpb292; database=common_interfaces; pooling = false; UseCompression=True"
      Case "MySQL-Local"
        connectionstringKalk = "server=" & strIPServerLocal & ";user id=root; password=root; database=kalkulation_kompo; pooling=false; UseCompression=True"
        connectionstringFed = "server=" & strIPServerLocal & ";user id=root; password=root; database=federstammdaten; pooling=false; UseCompression=True"
        connectionstringFoss = "server=" & strIPServerLocal & ";user id=root; password=root; database=foss; pooling = false; UseCompression=True"
        connectionstringCI = "server=" & strIPServerLocal & ";user id=root; password=root; database=common_interfaces; pooling = false; UseCompression=True"
      Case "MySQL-Test"
        connectionstringKalk = "server=" & strIPServerBrand & ";user id=kalkulation; password=kalkulation; database=kalkulation_copy; pooling=false; UseCompression=True"
        connectionstringFed = "server=" & strIPServerBrand & ";user id=td; password=td; database=federstammdaten; pooling=false; UseCompression=True"
        connectionstringFoss = "server=" & strIPServerBrand & ";user id=td; password=td; database=foss; pooling = false; UseCompression=True"
        connectionstringCI = "server=" & strIPServerBrand & ";user id=root; password=rootpb292; database=common_interfaces; pooling = false; UseCompression=True"
    End Select

  End Sub

  Public Sub sprachanpassung()
    Select Case strSprache
      Case "de-DE"
        With Form1
          '.Text = "Angebots-Tracking - " '& Application.ProductVersion.ToString & "T E S T  -  V E R S I O N"

          With Form1
            .coldatum_angelegt_am.Caption = "Datum" & vbCrLf & "angelegt am"
            .colangebot_nr.Caption = "Angebot-Nr."
            .colkunde.Caption = "Kunde"
            .colpb.Caption = "Fertigungs-" & vbCrLf & "Standort"
            .colanzahl_teile.Caption = "Anzahl" & vbCrLf & "Teile"
            .colanzahl_jahresbedarfe.Caption = "Anzahl" & vbCrLf & "Kalkulationen"
            .colbearbeitet_von.Caption = "bearbeitet" & vbCrLf & "von"
            .colname_kunden_manager.Caption = "Kunden-" & vbCrLf & "Manager"
            .colzeit_datum_angefragt_am.Caption = "Datum" & vbCrLf & "angefragt am"
            .colzeit_datum_angebot_bis.Caption = "Datum" & vbCrLf & "Angebot bis"
            .coltracking_abgabe_termin.Caption = "Tracking" & vbCrLf & "Abgabetermin"
            .colzukaufteile_erforderlich.Caption = "Zukaufteile" & vbCrLf & "erforderlich"
            .colext_bearbeitung_erforderlich.Caption = "ext. Bearbeitung" & vbCrLf & "erforderlich"
            .colprio.Caption = "Prio"
            .colprio_automatisch.Caption = "Prio" & vbCrLf & "ber."
            .colzeit_datum_berechnung_vorhanden.Caption = "Datum" & vbCrLf & "Berechnung" & vbCrLf & "vorh."
            .colzeit_datum_hsb_vorhanden_ae.Caption = "Datum" & vbCrLf & "HSB" & vbCrLf & "vorh. AE"
            .colzeit_datum_hsb_vorhanden_prod.Caption = "Datum" & vbCrLf & "HSB" & vbCrLf & "vorh. Prod."
            .colzeit_datum_hsb_vorhanden_qs.Caption = "Datum" & vbCrLf & "HSB" & vbCrLf & "vorh. QM"
            .colzeit_datum_hsb_freigegeben.Caption = "Datum" & vbCrLf & "HSB" & vbCrLf & "freigegeben"
            .colzeit_datum_zukaufteile_angefragt.Caption = "Zukaufteile" & vbCrLf & "angefragt" & vbCrLf & "am"
            .colzeit_datum_ext_bearbeitung_angefragt.Caption = "ext. Bearb." & vbCrLf & "angefragt" & vbCrLf & "am"
            .colzeit_datum_zukaufteile_angebot_vorhanden.Caption = "Datum" & vbCrLf & "Zukaufteile" & vbCrLf & "Angebot"
            .colzeit_datum_ext_bearbeitung_angebot_vorhanden.Caption = "Datum" & vbCrLf & "ext. Bearb." & vbCrLf & "Angebot"
            .colzeit_datum_kalk_erstellt.Caption = "Datum" & vbCrLf & "Kalkulation" & vbCrLf & "erstellt"
            .colzeit_datum_angebot_abgegeben.Caption = "Datum" & vbCrLf & "Angebot" & vbCrLf & "abgegeben"
            .colstatus_bearbeitung.Caption = "Status" & vbCrLf & "Bearb."
            .colfreigegeben_von.Caption = "freigegeben" & vbCrLf & "von"

            .colznr_ar.Caption = "Zeichnung-Nr."
            .colind_ar.Caption = "Index"
            .coljahresbedarf_ar.Caption = "Jahres-" & vbCrLf & "bedarf"
            .collosgroesse_ar.Caption = "Fertigungs-" & vbCrLf & "Losgrösse"
            .colpb_ar.Caption = "Fertiguns-" & vbCrLf & "Standort"
            .colmit_zukaufteilen_ar.Caption = "Zukaufteile"
            .colmit_ext_ag_ar.Caption = "externe" & vbCrLf & "Bearbeitung"
            .colzeit_datum_berechnung_erstellt_ar.Caption = "Datum" & vbCrLf & "Berechnung" & vbCrLf & "erstellt"
            .colzeit_datum_hsb_erstellt_ae_ar.Caption = "Datum" & vbCrLf & "HSB" & vbCrLf & "erstellt AE"
            .colzeit_datum_hsb_erstellt_prod_ar.Caption = "Datum" & vbCrLf & "HSB" & vbCrLf & "erstellt Prod."
            .colzeit_datum_hsb_erstellt_qm_ar.Caption = "Datum" & vbCrLf & "HSB" & vbCrLf & "erstellt QM"
            .colzeit_datum_zukaufteile_angefragt_ar.Caption = "Datum" & vbCrLf & "Zukaufteile" & vbCrLf & "angefragt am"
            .colzeit_datum_ext_bearbeitung_angefragt_ar.Caption = "Datum" & vbCrLf & "externe" & vbCrLf & "Bearbeitung" & vbCrLf & "angefragt am"
            .colzeit_datum_zukaufteile_angebot_erhalten_ar.Caption = "Datum" & vbCrLf & "Zukaufteile" & vbCrLf & "Angebot" & vbCrLf & "vorhanden"
            .colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.Caption = "Datum" & vbCrLf & "externe" & vbCrLf & "Bearbeitung" & vbCrLf & "Angebot" & vbCrLf & "vorhanden"
            .colzeit_datum_kalk_erstellt_ar.Caption = "Datum" & vbCrLf & "Kalkulation" & vbCrLf & "erstellt am"
            .colstatus_angebot_ar.Caption = "Status" & vbCrLf & "Bearbeitung"
            .colmachbarkeit_ae.Caption = "HSB" & vbCrLf & "AE"
          End With

          .ToolTip_form1.SetToolTip(.btn_schliessen, "Anwendnung beenden?")
          .ToolTip_form1.SetToolTip(.btn_excel_export, "Daten nach Excel exportieren")
          .ToolTip_form1.SetToolTip(.btn_daten_aktualisieren, "Daten aktualisieren")
          .ToolTip_form1.SetToolTip(.btn_filter_aufheben, "alle Filter aufheben")
        End With
      Case "en-GB"
        With Form1
          .Text = "offer tracking - " & Application.ProductVersion.ToString

          .ToolTip_form1.SetToolTip(.btn_schliessen, "close application?")
        End With
    End Select
  End Sub

  Public Sub update_Programm(ByVal NeueVersionPath As String, ByVal aktuelleVersion As String, ByVal automatik As String)
    Dim neueVersion As String

    Try
      IO.File.Delete(".\update_programm.exe")
    Catch ex As Exception
    End Try

    'anpassung windows7
    Try
      IO.File.Delete(".\etadpu_programm.exe")
    Catch ex As Exception
    End Try

    'anpassung windows7
    Dim i As Integer
    i = 0

    While i < 10
      If IO.Directory.Exists(NeueVersionPath) Then
        Exit While
      End If

      Threading.Thread.Sleep(100)
      i = i + 1
    End While

    If IO.Directory.Exists(NeueVersionPath) Then

    Else
      Exit Sub
    End If

    Try
      neueVersion = "0"

      Dim dir As IO.DirectoryInfo
      Dim file As IO.FileInfo

      dir = New IO.DirectoryInfo(NeueVersionPath)

      For Each file In dir.GetFiles()
        'anpassung windows7
        If file.ToString Like "update*" Or file.ToString Like "etadpu*" Then
        Else
          neueVersion = file.ToString
        End If

      Next

      If aktuelleVersion < neueVersion Then

        Dim b() As String
        Dim aktuellerName As String

        blUpdate = True

        aktuellerName = "0"

        b = Split(System.Environment.GetCommandLineArgs(0), "\")

        For Each aktuellerName In b

        Next

        Try
          'anpassung windows7
          IO.File.Copy(NeueVersionPath & "\etadpu_programm.exe", ".\etadpu_programm.exe")

          Dim processid As Integer

          NeueVersionPath = Replace(NeueVersionPath, " ", "/\;/\")
          aktuelleVersion = Replace(aktuelleVersion, " ", "/\;/\")

          'anpassung windows7
          processid = Shell("./etadpu_programm.exe " + aktuellerName + " " + NeueVersionPath + " " + aktuelleVersion + " " + automatik, AppWinStyle.NormalFocus)

          SplashScreen.Close()
          End

        Catch ex As Exception

          Try

            Dim p As New Process()

            p.StartInfo.FileName = "./etadpu_maschinendaten.exe"
            p.StartInfo.Arguments = aktuellerName + " " + NeueVersionPath + " " + aktuelleVersion + " " + automatik
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            p.Start()

            i = p.Id

            SplashScreen.Close()
            End

          Catch ex2 As Exception

          End Try

        End Try

      End If

    Catch ex As Exception

    End Try

  End Sub

  Public Sub WriteToErrorLog(ByVal str_Msg As String, ByVal stkTrace As String, ByVal str_Title As String)
    Dim strPfadError As String

    If LCase(strConnectionType) = "local" Then
      If Not Directory.Exists(Application.StartupPath & "\Errors\") Then
        Directory.CreateDirectory(Application.StartupPath & "\Errors\")
      End If
      strPfadError = Application.StartupPath & "\Errors\"
    Else
      If blFileServerPresent = True Then
        If Not Directory.Exists(strErrorPath) Then
          Directory.CreateDirectory(strErrorPath)
        End If
        strPfadError = strErrorPath & "\"
      Else
        If Not Directory.Exists(Application.StartupPath & "\Errors\") Then
          Directory.CreateDirectory(Application.StartupPath & "\Errors\")
        End If
        strPfadError = Application.StartupPath & "\Errors\"
      End If
    End If

    Dim fs As FileStream = New FileStream(strPfadError & "errlog_" & suser & ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
    Dim s As StreamWriter = New StreamWriter(fs)

    s.Close()
    fs.Close()

    Dim fs1 As FileStream = New FileStream(strPfadError & "errlog_" & suser & ".txt", FileMode.Append, FileAccess.Write)
    Dim s1 As StreamWriter = New StreamWriter(fs1)
    s1.Write("Titel: " & str_Title & vbCrLf)
    s1.Write("Meldung: " & str_Msg & vbCrLf)
    s1.Write("StackTrace: " & stkTrace & vbCrLf)
    s1.Write("Datum/Uhrzeit: " & DateTime.Now.ToString() & vbCrLf)
    s1.Write(Application.ProductName & " " & Application.ProductVersion.ToString)
    s1.Write("===========================================================================================" & vbCrLf)
    s1.Write("" & vbCrLf)
    s1.Close()
    fs1.Close()

  End Sub

  Public Sub write_user_settings()
    Try
      Form1.GridControl_tracking.MainView.SaveLayoutToXml(Application.StartupPath & strUserSettingsAT)
      Form1.GridControl_AngebotReg.MainView.SaveLayoutToXml(Application.StartupPath & strUserSettingsAR)
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function write_user_settings")
    End Try

  End Sub

#End Region

#Region "satzsperre"
  Public Sub Datensatz_entsperren(ByVal strIDEntSperren As String)
    Dim strSQLEntsperren As String = ""

    If lstSperrTabelle.Count = 0 Then Exit Sub

    For i As Integer = 0 To lstSperrTabelle.Count - 1
      If IsNumeric(strIDEntSperren) Then
        strSQLEntsperren = strSQLEntsperren &
                           "UPDATE " &
                           "" & lstSperrTabelle(i) & " " &
                           "SET " &
                           "status = '' " &
                           "WHERE " &
                           "id_tracking = " & strIDEntSperren & "; "
        'Debug.Print("Datensatz entsperren: " & strSQLEntsperren)
      Else
        strSQLEntsperren = strSQLEntsperren &
                           "UPDATE " &
                           "" & lstSperrTabelle(i) & " " &
                           "SET " &
                           "status = '' " &
                           "WHERE " &
                           "user = '" & suser & "'; "
        'Debug.Print("Datensatz entsperren: " & strSQLEntsperren)
      End If
    Next

    strIDSatzSperre = ""

    update_insert_delete(strSQLEntsperren, False,, "Sub Datensatz_entsperren")

    lstSperrTabelle.Clear()

    Form1.Timer_satzsperre.Enabled = False

  End Sub

  Public Sub Datensatz_sperren(ByVal strTabellenName As String, ByVal strIDSperren As String)
    Dim strSQLSatzSperre As String = ""

    strTimeStamp = Date.Now.ToString(strDatFmtSperre)

    If lstSperrTabelle.Contains(strTabellenName) Then Exit Sub

    lstSperrTabelle.Add(strTabellenName)

    strIDSatzSperre = strIDSperren

    strSQLSatzSperre = "UPDATE " &
                       "" & strTabellenName & " " &
                       "SET " &
                       "status = 'in Bearbeitung', " &
                       "user = '" & suser & "', " &
                       "timestamp = '" & strTimeStamp & "' " &
                       "WHERE " &
                       "id_tracking = " & strIDSperren & ""

    update_insert_delete(strSQLSatzSperre,,, "sub Datensatz_sperren")

    'Debug.Print("Datensatz sperren: " & strSQLSatzSperre)

    Form1.Timer_satzsperre.Enabled = True

  End Sub

  Public Function pruefen_satzsperre_ar(ByVal strIDTracking As String) As String
    Dim con As MySqlConnection = Nothing
    Dim cmd As MySqlCommand
    Dim myAdapter As New MySqlDataAdapter

    Dim strUserName As String = ""
    Dim strReturn As String = "frei"

    Dim datAktuell As DateTime
    Dim datTimeStamp As DateTime
    Dim intDiff As Int64

    Dim aLUsers As New ArrayList
    Dim blDiffUser As Boolean = False

    If String.IsNullOrEmpty(strIDTracking) Then
      Return "ok"
      Exit Function
    End If

    Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Clear()

    Dim strSQL As String = "SELECT " &
                           "id, " &
                           "user, " &
                           "status, " &
                           "timestamp " &
                           "FROM " &
                           "t_angebot_reg " &
                           "WHERE " &
                           "id_tracking = " & strIDTracking & ""

    con = New MySqlConnection(connectionstringKalk)

    con.Open()
    cmd = New MySqlCommand
    cmd.Connection = con
    myAdapter.SelectCommand = cmd

    cmd.CommandText() = strSQL
    myAdapter.Fill(Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar"))

    con.Close()

    If Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows.Count = 0 Then
      Return strReturn
      Exit Function
    End If

    'Usernamen auslesen aus allen passenden DS in der Angebots-Registrierung
    For i As Integer = 0 To Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows.Count - 1
      If Not IsDBNull(Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows(i)(1)) Then
        aLUsers.Add(Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows(i)(1))
      End If
    Next

    'Prüfen, ob "fremde" Usernamen vorhanden sind
    For i As Integer = 0 To aLUsers.Count - 1
      If aLUsers(i) <> suser Then
        blDiffUser = True
      End If
    Next

    'wenn "fremder" User vorhanden
    If blDiffUser = True Then
      For i As Integer = 0 To Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows.Count - 1
        If Not IsDBNull(Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows(i)(3)) Then
          datTimeStamp = Convert.ToDateTime(Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows(i)(3))
          datAktuell = Now
          intDiff = Convert.ToInt64((datAktuell - datTimeStamp).TotalSeconds)

          If intDiff <= 30 Then
            strUserName = Form1.DataSet_tracking.Tables("DataTable_satzsperre_ar").Rows(i)(1)
            Exit For
          End If
        End If
      Next
    End If

    If Not strUserName = "" Then
      Select Case strSprache
        Case "de-DE"
          strReturn = "Angebots-Registirerung: Datensatz gesperrt durch User " & strUserName
        Case "en-GB"
          strReturn = "offer registration: record in use by user " & strUserName
        Case Else
          strReturn = "offer registration: record in use by user " & strUserName
      End Select
    End If

    Return strReturn

  End Function

  Public Function pruefen_satzsperre(ByVal strid As String, ByVal strTabelle As String) As String
    Dim strSQL As String

    Dim a(4) As String
    Dim strElement As String
    Dim arStatus As New ArrayList
    Dim strUser As String
    Dim strStatus As String
    Dim strTimeStamp As String

    Dim datAktuell As DateTime
    Dim datTimeStamp As DateTime
    Dim intDiff As Int64

    'prüfen, ob der Datensatz gesperrt ist
    strSQL = "SELECT " &
             "id_tracking, " &
             "user, " &
             "status, " &
             "timestamp " &
             "FROM " &
             "" & strTabelle & " " &
             "WHERE " &
             "id_tracking = '" & strid & "'"

    arStatus = fill_arraylist(strSQL, ";", "id_tracking;user;status;timestamp")

    For Each strElement In arStatus
      a = Split(strElement, ";")
    Next

    strid = a(0)
    strUser = a(1)
    strStatus = a(2)
    strTimeStamp = a(3)

    If strUser <> suser Then
      If strStatus <> String.Empty Then 'wenn Eintrag im Status vorhanden
        If strTimeStamp = String.Empty Then
          pruefen_satzsperre = "frei"
        Else
          datTimeStamp = Convert.ToDateTime(strTimeStamp)
          datAktuell = Now

          intDiff = Convert.ToInt64((datAktuell - datTimeStamp).TotalSeconds)

          If intDiff <= 30 Then
            Select Case strSprache
              Case "de-DE"
                pruefen_satzsperre = "Datensatz gesperrt durch User " & strUser
              Case "en-GB"
                pruefen_satzsperre = "record in use by user " & strUser
              Case Else
                pruefen_satzsperre = "record in use by user " & strUser
            End Select
          Else
            pruefen_satzsperre = "frei"
          End If
        End If
      Else
        pruefen_satzsperre = "frei"
      End If
    Else
      pruefen_satzsperre = "frei"
    End If

  End Function

#End Region
End Module
