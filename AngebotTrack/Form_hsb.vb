Imports DevExpress.XtraGrid.Views.Base

Public Class Form_hsb
  Dim drHSBResult() As DataRow = Nothing
  Dim colGO As Color = Color.PaleGreen
  Dim colGOBUT As Color = Color.Gold
  Dim colNOGO As Color = Color.Salmon
  Dim colEmpty As Color = Color.WhiteSmoke
  Dim lstParts As New List(Of Int64)
  Dim strAngebNr As String
  Dim strZNr As String
  Dim strInd As String
  Dim lngFLG As Int64
  Dim strOrg As String
  Dim strDiv As String
  Dim strPla As String
  Dim strFilter As String

#Region "form"
  Private Sub all_Keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress,
                                                                                            PanelControl_ae.KeyPress,
                                                                                            GridControl_ae.KeyPress,
                                                                                            PanelControl_prod.KeyPress,
                                                                                            GridView_prod.KeyPress,
                                                                                            PanelControl_qs.KeyPress,
                                                                                            GridView_qs.KeyPress,
                                                                                            PanelControl_footer.KeyPress
    int_counter_user_action = 0
  End Sub

  Private Sub all_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove,
                                                                                          PanelControl_ae.MouseMove,
                                                                                          GridControl_ae.MouseMove,
                                                                                          PanelControl_prod.MouseMove,
                                                                                          GridControl_prod.MouseMove,
                                                                                          PanelControl_qs.MouseMove,
                                                                                          GridView_qs.MouseMove,
                                                                                          PanelControl_footer.MouseMove

    int_counter_user_action = 0
  End Sub

  Private Sub Form_hsb_Load(sender As Object, e As EventArgs) Handles Me.Load
  End Sub

  Private Sub Form_hsb_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    Dim drAR() As DataRow = Form1.DataSet_tracking.Tables("DataTable_AngebotReg").Select("id = " & strIDAngebotReg & "")
    Dim drEqual() As DataRow

    lstParts.Clear()

    If Not IsDBNull(drAR(0)("angebot_nr")) Then
      If drAR(0)("angebot_nr") <> "?" Then
        strAngebNr = drAR(0)("angebot_nr")
      Else
        strAngebNr = Convert.ToInt64(drAR(0)("angebot_nr_neu")).ToString("000-000") & "_" & Convert.ToInt64(drAR(0)("angebot_nr_ind")).ToString("00")
      End If
    End If

    lbl_angebot_nr.Text = strAngebNr

    If Not IsDBNull(drAR(0)("znr")) Then
      strZNr = drAR(0)("znr")
      lbl_znr_wert.Text = strZNr
    End If
    If Not IsDBNull(drAR(0)("ind")) Then
      If String.IsNullOrEmpty(drAR(0)("ind")) Then
        strInd = "NULL"
        lbl_ind_wert.Text = ""
      Else
        strInd = drAR(0)("ind")
        lbl_ind_wert.Text = strInd
      End If
    Else
      strInd = "NULL"
      lbl_ind_wert.Text = ""
    End If
    If Not IsDBNull(drAR(0)("losgroesse")) Then
      lngFLG = drAR(0)("losgroesse")
      tbx_flg.EditValue = lngFLG
    End If
    strOrg = drAR(0)("org_company")
    strDiv = drAR(0)("org_division")
    strPla = drAR(0)("org_plant")

    Dim strFilterNamenAE As String = ""
    Dim strFilterNamenPROD As String = ""
    Dim strFilterNamenQS As String = ""

    'Liste mit id's der Teile mit gleicher Zeichnung-Nr. und Index, aber unterschiedlicher FLG füllen (sofern gleiche Teile existieren)
    If drAR(0)("angebot_nr") = "?" Then

      If strInd = "NULL" Then
        strFilter = "angebot_nr_neu = '" & drAR(0)("angebot_nr_neu").ToString & "' 
                     AND angebot_nr_ind = '" & drAR(0)("angebot_nr_ind").ToString & "' 
                     AND znr = '" & strZNr & "' 
                     AND losgroesse <> " & lngFLG & " 
                     AND org_company = '" & strOrg & "' 
                     AND org_division = '" & strDiv & "' 
                     AND org_plant = '" & strPla & "'"
      Else
        strFilter = "angebot_nr_neu = '" & drAR(0)("angebot_nr_neu").ToString & "' 
                     AND angebot_nr_ind = '" & drAR(0)("angebot_nr_ind").ToString & "' 
                     AND znr = '" & strZNr & "' 
                     AND ind = '" & strInd & "' 
                     AND losgroesse <> " & lngFLG & " 
                     AND org_company = '" & strOrg & "' 
                     AND org_division = '" & strDiv & "' 
                     AND org_plant = '" & strPla & "'"
      End If
    Else
      strFilter = "angebot_nr = '" & strAngebNr & "' 
                   AND znr = '" & strZNr & "' 
                   AND ind = '" & strInd & "' 
                   AND losgroesse <> " & lngFLG & " 
                   AND org_company = '" & strOrg & "' 
                   AND org_division = '" & strDiv & "' 
                   AND org_plant = '" & strPla & "'"
    End If

    drEqual = Form1.DataSet_tracking.Tables("DataTable_AngebotReg").Select(strFilter)

    If drEqual.Count > 0 Then
      For i As Integer = 0 To drEqual.Count - 1
        lstParts.Add(drEqual(i)("id"))
      Next
    End If

    table_check()

    Try
      If Not IsDBNull(drAR(0)("pb")) Then lbl_pb_wert.Text = drAR(0)("pb")
      If Not IsDBNull(drAR(0)("kunde")) Then lbl_kunde_wert.Text = drAR(0)("kunde")

      'ComboBoxen für Namen füllen
      Select Case True
        Case LCase(drAR(0)("org_company")) = "bra" AndAlso LCase(drAR(0)("org_division")) = "as" AndAlso LCase(drAR(0)("org_plant")) = "a"
          strFilterNamenAE = "merkmal = 'werteliste_ae_name_as'"
          strFilterNamenPROD = "merkmal = 'werteliste_prod_name_as' OR merkmal = 'werteliste_prodqs_name_as'"
          strFilterNamenQS = "merkmal = 'werteliste_qs_name_as' OR merkmal = 'werteliste_prodqs_name_as'"
        Case LCase(drAR(0)("org_company")) = "bra" AndAlso LCase(drAR(0)("org_division")) = "if" AndAlso LCase(drAR(0)("org_plant")) = "a"
          strFilterNamenAE = "merkmal = 'werteliste_ae_name_ifa'"
          strFilterNamenPROD = "merkmal = 'werteliste_prod_name_ifa'"
          strFilterNamenQS = "merkmal = 'werteliste_qs_name_ifa'"
        Case LCase(drAR(0)("org_company")) = "mfw" AndAlso LCase(drAR(0)("org_division")) = "if" AndAlso LCase(drAR(0)("org_plant")) = "l"
          strFilterNamenAE = "merkmal = 'werteliste_ae_name_ifl'"
          strFilterNamenPROD = "merkmal = 'werteliste_prod_name_ifl'"
          strFilterNamenQS = "merkmal = 'werteliste_qs_name_ifl'"
      End Select

      fill_box_from_datatable(cbx_ae_name, "DataTable_setup", strFilterNamenAE, "wert", "wert", True, "Form_hsb_Shown")
      fill_box_from_datatable(cbx_prod_name, "DataTable_setup", strFilterNamenPROD, "wert", "wert", True, "Form_hsb_Shown")
      fill_box_from_datatable(cbx_qs_name, "DataTable_setup", strFilterNamenQS, "wert", "wert", True, "Form_hsb_Shown")


            Select Case LCase(strBerechtigung)
        Case "admin"
          PanelControl_ae.BackColor = Color.LightSteelBlue
          PanelControl_prod.BackColor = Color.LightSteelBlue
          PanelControl_qs.BackColor = Color.LightSteelBlue
          GridView_ae.OptionsBehavior.ReadOnly = False
          GridView_prod.OptionsBehavior.ReadOnly = False
          GridView_qs.OptionsBehavior.ReadOnly = False
          cbx_ae_name.ReadOnly = False
          DateEdit_ae.ReadOnly = False
          cbx_prod_name.ReadOnly = False
          DateEdit_prod.ReadOnly = False
          cbx_qs_name.ReadOnly = False
          DateEdit_qs.ReadOnly = False
          DateEdit_all.ReadOnly = False
        Case "ae"
          PanelControl_ae.BackColor = Color.LightSteelBlue
          GridView_ae.OptionsBehavior.ReadOnly = False
          cbx_ae_name.ReadOnly = False
          DateEdit_ae.ReadOnly = False
        Case "prod"
          PanelControl_prod.BackColor = Color.LightSteelBlue
          GridView_prod.OptionsBehavior.ReadOnly = False
          cbx_prod_name.ReadOnly = False
          DateEdit_prod.ReadOnly = False
        Case "qs"
          PanelControl_qs.BackColor = Color.LightSteelBlue
          GridView_qs.OptionsBehavior.ReadOnly = False
          cbx_qs_name.ReadOnly = False
          DateEdit_qs.ReadOnly = False
        Case "prodqs"
          PanelControl_prod.BackColor = Color.LightSteelBlue
          GridView_prod.OptionsBehavior.ReadOnly = False
          cbx_prod_name.ReadOnly = False
          DateEdit_prod.ReadOnly = False
          PanelControl_qs.BackColor = Color.LightSteelBlue
          GridView_qs.OptionsBehavior.ReadOnly = False
          cbx_qs_name.ReadOnly = False
          DateEdit_qs.ReadOnly = False
        Case "aeprod"
          PanelControl_ae.BackColor = Color.LightSteelBlue
          GridView_ae.OptionsBehavior.ReadOnly = False
          cbx_ae_name.ReadOnly = False
          DateEdit_ae.ReadOnly = False
          PanelControl_prod.BackColor = Color.LightSteelBlue
          GridView_prod.OptionsBehavior.ReadOnly = False
          cbx_prod_name.ReadOnly = False
          DateEdit_prod.ReadOnly = False
      End Select

      GridControl_ae.DataSource = DataSet_hsb.Tables("DataTable_hsb").Select("area = 'ae' AND attribute <> 'result'", "order_no")
      GridControl_prod.DataSource = DataSet_hsb.Tables("DataTable_hsb").Select("area = 'prod' AND attribute <> 'result'", "order_no")
      GridControl_qs.DataSource = DataSet_hsb.Tables("DataTable_hsb").Select("area = 'qs' AND attribute <> 'result'", "order_no")
      drHSBResult = DataSet_hsb.Tables("DataTable_hsb_result").Select

      If blReadOnlyHSB = True Then
        Text = "Interne Herstellbarkeitsbewertung - abgeschlossen"
        GridView_ae.OptionsBehavior.ReadOnly = True
        GridView_prod.OptionsBehavior.ReadOnly = True
        GridView_qs.OptionsBehavior.ReadOnly = True
        cbx_ae_name.ReadOnly = True
        DateEdit_ae.ReadOnly = True
        cbx_prod_name.ReadOnly = True
        DateEdit_prod.ReadOnly = True
        cbx_qs_name.ReadOnly = True
        DateEdit_qs.ReadOnly = True
        DateEdit_all.ReadOnly = True
        btn_freigeben.Enabled = False
      End If

      DataSet_hsb.Tables("DataTable_hsb_result").AcceptChanges()
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in Sub Form_hsb.Shown")
    End Try
  End Sub

  Private Sub Form_close()
    Dim strResult As String = ""
    Dim icMsgBox As MessageBoxIcon = Nothing

    'das Speichern soll nur mit entsprechender Berechtigung möglich sein
    Select Case strBerechtigung
      Case "vm", "info"
        Close()
    End Select

    If blReadOnlyHSB = False Then
      If check_changes(DataSet_hsb) = True Then
        icMsgBox = MessageBoxIcon.Question
        Select Case strSprache
          Case "de-DE"
            strTextMsg = "Änderungen speichern?"
            strTitelMsg = "Herstellbarkeitsbewertung"
          Case Else
            strTextMsg = "save changes?"
            strTitelMsg = "feasibility evaluation"
        End Select

        If MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.YesNo, icMsgBox) = vbYes Then
          strResult = save_hsb(strIDAngebotReg)
          If strResult.Contains("error") Then
            icMsgBox = MessageBoxIcon.Error
            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Es ist ein Fehler aufgetreten" & vbCrLf & "Die Änderungen wurden nicht gespeichert"
              Case Else
                strTextMsg = "an error occured" & vbCrLf & "changes have not been saved"
            End Select
          Else
            icMsgBox = MessageBoxIcon.Information
            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Die Änderungen wurden gespeichert"
              Case Else
                strTextMsg = "changes saved"
            End Select
          End If
          MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, icMsgBox)
          notice_to_ae()
          Close()
        Else
          Close()
        End If
      Else
        Close()
      End If
    Else
      Close()
    End If
  End Sub

#End Region

#Region "subs"
  Private Sub create_hsb(ByVal strIDAR As String)
    'legt DS für die HSB im internen DataSet an
    Dim strSQL As String = ""
    Dim newRow As DataRow = Nothing
    Dim drMerkmale() As DataRow = Nothing

        DataSet_hsb.Tables("DataTable_hsb").Rows.Clear()
        DataSet_hsb.Tables("DataTable_hsb_result").Rows.Clear()

    'rows ae anlegen
    drMerkmale = Form1.DataSet_tracking.Tables("DataTable_setup").Select("merkmal = 'werteliste_hsb_ae'", "order_no")
    If drMerkmale.Count > 0 Then
      For i As Integer = 0 To drMerkmale.Count - 1
        newRow = DataSet_hsb.Tables("DataTable_hsb").NewRow
        newRow("id_angebot_reg") = strIDAR
        newRow("area") = "ae"
        newRow("attribute") = drMerkmale(i)("wert")
        newRow("order_no") = drMerkmale(i)("order_no")
        newRow("date_time_result") = Date.Now.ToString(strDatFmt)
        DataSet_hsb.Tables("DataTable_hsb").Rows.Add(newRow)
        newRow = Nothing
      Next
    End If

    'rows prod anlegen
    drMerkmale = Form1.DataSet_tracking.Tables("DataTable_setup").Select("merkmal = 'werteliste_hsb_prod'", "order_no")
    If drMerkmale.Count > 0 Then
      For i As Integer = 0 To drMerkmale.Count - 1
        newRow = DataSet_hsb.Tables("DataTable_hsb").NewRow()
        newRow("id_angebot_reg") = strIDAR
        newRow("area") = "prod"
        newRow("attribute") = drMerkmale(i)("wert")
        newRow("order_no") = drMerkmale(i)("order_no")
        newRow("date_time_result") = Date.Now.ToString(strDatFmt)
        DataSet_hsb.Tables("DataTable_hsb").Rows.Add(newRow)
        newRow = Nothing
      Next
    End If

    'rows qs anlegen
    drMerkmale = Form1.DataSet_tracking.Tables("DataTable_setup").Select("merkmal = 'werteliste_hsb_qs'", "order_no")
    If drMerkmale.Count > 0 Then
      For i As Integer = 0 To drMerkmale.Count - 1
        newRow = DataSet_hsb.Tables("DataTable_hsb").NewRow()
        newRow("id_angebot_reg") = strIDAR
        newRow("area") = "qs"
        newRow("attribute") = drMerkmale(i)("wert")
        newRow("order_no") = drMerkmale(i)("order_no")
        newRow("date_time_result") = Date.Now.ToString(strDatFmt)
        DataSet_hsb.Tables("DataTable_hsb").Rows.Add(newRow)
        newRow = Nothing
      Next
    End If

    'row für Gesamt-Resultat der HSB anlegen
    newRow = DataSet_hsb.Tables("DataTable_hsb").NewRow()
    newRow("id_angebot_reg") = strIDAR
    newRow("area") = "result"
    newRow("attribute") = "result_all"
    newRow("order_no") = "0"
    newRow("date_time_result") = Date.Now.ToString(strDatFmt)
    DataSet_hsb.Tables("DataTable_hsb").Rows.Add(newRow)
    newRow = Nothing

    'row in Tabelle "DataTable_hsb_result" anlegen
    newRow = DataSet_hsb.Tables("DataTable_hsb_result").NewRow()
    newRow("result_ae") = "-"
    newRow("result_prod") = "-"
    newRow("result_qs") = "-"
    newRow("result_all") = "-"
        newRow("name_ae") = "-"
        newRow("name_prod") = "-"
        newRow("name_qs") = "-"
        newRow("name_all") = "-"
        newRow("cbx_ae_aws") = "abcd"
        newRow("date_time_result_ae") = Date.Now.ToString(strDatFmt)
    newRow("date_time_result_prod") = Date.Now.ToString(strDatFmt)
    newRow("date_time_result_qs") = Date.Now.ToString(strDatFmt)
    newRow("date_time_result_all") = Date.Now.ToString(strDatFmt)
    DataSet_hsb.Tables("DataTable_hsb_result").Rows.Add(newRow)
    newRow = Nothing
  End Sub

  Private Sub equal_hsb(ByVal strZNr As String,
                         ByVal strInd As String,
                         ByVal lngLosgroesse As String,
                         ByVal strIdAR As String)
    'in der Angebot-Reg: Teile mit gleicher Zeichnung-Nr. und gleichem Index, aber unterschiedlicher Fertigungslosgrösse erhalten gleiche HSB-Daten

    Dim strHSBResultAll As String = drHSBResult(0)("result_all")
    Dim strHSBResultAE As String = drHSBResult(0)("result_ae")
    Dim strHSBResultPROD As String = drHSBResult(0)("result_prod")
    Dim strHSBResultQS As String = drHSBResult(0)("result_qs")

    Try
      For i As Integer = 0 To Form1.GridView_AngebotReg.RowCount - 1
        For j As Integer = 0 To lstParts.Count - 1
          With Form1.GridView_AngebotReg
            If .GetRowCellValue(i, "id") = lstParts(j) Then
              .SetRowCellValue(i, "machbarkeit_ae", strHSBResultAE)
              If strHSBResultAE.Contains("go") Then
                .SetRowCellValue(i, "zeit_datum_hsb_erstellt_ae", drHSBResult(0)("date_time_result_ae"))
              Else
                .SetRowCellValue(i, "zeit_datum_hsb_erstellt_ae", DBNull.Value)
              End If
              .SetRowCellValue(i, "machbarkeit_prod", strHSBResultPROD)
              If strHSBResultPROD.Contains("go") Then
                .SetRowCellValue(i, "zeit_datum_hsb_erstellt_prod", drHSBResult(0)("date_time_result_prod"))
              Else
                .SetRowCellValue(i, "zeit_datum_hsb_erstellt_prod", DBNull.Value)
              End If
              .SetRowCellValue(i, "machbarkeit_qm", strHSBResultQS)
              If strHSBResultQS.Contains("go") Then
                .SetRowCellValue(i, "zeit_datum_hsb_erstellt_qm", drHSBResult(0)("date_time_result_qs"))
              Else
                .SetRowCellValue(i, "zeit_datum_hsb_erstellt_qm", DBNull.Value)
              End If
              .SetRowCellValue(i, "machbarkeit", strHSBResultAll)
              If strHSBResultAll.Contains("go") Then
                .SetRowCellValue(i, "zeit_datum_hsb_freigegeben", drHSBResult(0)("date_time_result_all"))
              Else
                .SetRowCellValue(i, "zeit_datum_hsb_freigegeben", DBNull.Value)
              End If
            End If
          End With
        Next
      Next
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in Sub equal_hsb")
    End Try
  End Sub

  Private Sub lbl_ae_result_all_wert_TextChanged(sender As Object, e As EventArgs) Handles lbl_ae_result_all_wert.TextChanged
    With lbl_ae_result_all_wert
      Select Case True
        Case .Text = "go"
          .BackColor = colGO
        Case .Text = "go but"
          .BackColor = colGOBUT
        Case .Text = "no go"
          .BackColor = colNOGO
        Case Else
          .BackColor = colEmpty
      End Select
    End With
  End Sub

  Private Sub lbl_prod_result_all_wert_TextChanged(sender As Object, e As EventArgs) Handles lbl_prod_result_all_wert.TextChanged
    With lbl_prod_result_all_wert
      Select Case True
        Case .Text = "go"
          .BackColor = colGO
        Case .Text = "go but"
          .BackColor = colGOBUT
        Case .Text = "no go"
          .BackColor = colNOGO
        Case Else
          .BackColor = colEmpty
      End Select
    End With
  End Sub

  Private Sub lbl_qs_result_all_wert_TextChanged(sender As Object, e As EventArgs) Handles lbl_qs_result_all_wert.TextChanged
    With lbl_qs_result_all_wert
      Select Case True
        Case .Text = "go"
          .BackColor = colGO
        Case .Text = "go but"
          .BackColor = colGOBUT
        Case .Text = "no go"
          .BackColor = colNOGO
        Case Else
          .BackColor = colEmpty
      End Select
    End With
  End Sub

  Private Sub lbl_result_hsb_all_TextChanged(sender As Object, e As EventArgs) Handles lbl_result_hsb_all.TextChanged
    With lbl_result_hsb_all
      Select Case True
        Case .Text = "go"
          .BackColor = colGO
        Case .Text = "go but"
          .BackColor = colGOBUT
        Case .Text = "no go"
          .BackColor = colNOGO
        Case Else
          .BackColor = colEmpty
      End Select
    End With
  End Sub

  Private Sub notice_to_ae()
    Dim strAEName As String = cbx_ae_name.EditValue
    Dim drEMAdr() As DataRow = Form1.DataSet_tracking.Tables("DataTable_SetUp").Select("merkmal like 'werteliste_ae_name*' AND wert = '" & strAEName & "'")
    Dim drCountHSBGruende() As DataRow = Nothing
    Dim dtHSBGruende As New DataTable
    Dim newRow As DataRow = Nothing
    Dim drHSBGruende() As DataRow = Nothing
    Dim strEMAdr As String = ""
    Dim strBodyText As String = ""

    drCountHSBGruende = DataSet_hsb.Tables("DataTable_hsb").Select("result_attribute = 'go but' OR result_attribute = 'no go'")

    If drCountHSBGruende.Count = 0 Then Exit Sub

    If strAEName = "-" Then Exit Sub
    If get_result_hsb_all() = "-" Then Exit Sub

    If drEMAdr.Count = 0 Then
      Select Case strSprache
        Case "de-DE"
          strTextMsg = "Email-Adresse des AE konnte nicht ermittelt werden"
          strTitelMsg = "Benachrichtigung an AE"
        Case Else
          strTextMsg = "email adress of AE not found"
          strTitelMsg = "notic to AE"
      End Select

      MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, MessageBoxIcon.Hand)
      Exit Sub
    End If

    strEMAdr = drEMAdr(0)("wert_1")
    strBodyText = "Angebot-Nr. " & lbl_angebot_nr.Text & "%0d%0A" & "Die HSB für die Zeichnung-Nr. " & lbl_znr_wert.Text & " ist vollständig"

    drHSBGruende = DataSet_hsb.Tables("DataTable_hsb").Select("result_attribute = 'go but' OR result_attribute = 'no go'")

    If drHSBGruende.Count = 0 Then Exit Sub

    With dtHSBGruende.Columns
      .Add("id_angebot_reg", GetType(Int64))
      .Add("area", GetType(String))
      .Add("attribute", GetType(String))
      .Add("match_int", GetType(Int64))
      .Add("match_ext", GetType(Int64))
      .Add("tool_exist", GetType(Int64))
      .Add("result_attribute", GetType(String))
      .Add("rem_int", GetType(String))
      .Add("rem_cust", GetType(String))
      .Add("name", GetType(String))
      .Add("date_time_result", GetType(Date))
      .Add("order_no", GetType(Int64))
    End With

    For i As Integer = 0 To drHSBGruende.Count - 1
      newRow = dtHSBGruende.NewRow

      newRow("id_angebot_reg") = drHSBGruende(i)("id_angebot_reg")
      newRow("area") = drHSBGruende(i)("area")
      newRow("attribute") = drHSBGruende(i)("attribute")
      newRow("match_int") = drHSBGruende(i)("match_int")
      newRow("match_ext") = drHSBGruende(i)("match_ext")
      newRow("tool_exist") = drHSBGruende(i)("tool_exist")
      newRow("result_attribute") = drHSBGruende(i)("result_attribute")
      newRow("rem_int") = drHSBGruende(i)("rem_int")
      newRow("rem_cust") = drHSBGruende(i)("rem_cust")
      newRow("name") = drHSBGruende(i)("name")
      newRow("date_time_result") = drHSBGruende(i)("date_time_result")
      newRow("order_no") = drHSBGruende(i)("order_no")

      dtHSBGruende.Rows.Add(newRow)
      newRow = Nothing
    Next

    drHSBGruende = Nothing

    'dtHSBGruende = DataSet_hsb.Tables("DataTable_hsb").Select("result_attribute = 'go but' OR result_attribute = 'no go'").CopyToDataTable

#Region "AE"
    drHSBGruende = dtHSBGruende.Select("area = 'ae' AND attribute <> 'result' AND match_int = 1")
    strBodyText = strBodyText & "%0d%0A" & "%0d%0A" & "HSB, AE:" & "%0d%0A"
    For i As Integer = 0 To drHSBGruende.Count - 1
      strBodyText = strBodyText & "%0d%0A" &
                    drHSBGruende(i)("attribute") & " - " &
                    drHSBGruende(i)("result_attribute") & " - " &
                    Replace(drHSBGruende(i)("rem_cust"), "&", "")
    Next
#End Region

#Region "PROD"
    drHSBGruende = dtHSBGruende.Select("area = 'prod' AND attribute <> 'result' AND match_int = 1")
    strBodyText = strBodyText & "%0d%0A" & "%0d%0A" & "HSB, Produktion:" & "%0d%0A"
    For i As Integer = 0 To drHSBGruende.Count - 1
      strBodyText = strBodyText & "%0d%0A" &
                    drHSBGruende(i)("attribute") & " - " &
                    drHSBGruende(i)("result_attribute") & " - " &
                    Replace(drHSBGruende(i)("rem_cust"), "&", "")
    Next
#End Region

#Region "QS"
    drHSBGruende = dtHSBGruende.Select("area = 'qs' AND attribute <> 'result' AND match_int = 1")
    strBodyText = strBodyText & "%0d%0A" & "%0d%0A" & "HSB, QS:" & "%0d%0A"
    For i As Integer = 0 To drHSBGruende.Count - 1
      strBodyText = strBodyText & "%0d%0A" &
                    drHSBGruende(i)("attribute") & " - " &
                    drHSBGruende(i)("result_attribute") & " - " &
                    Replace(drHSBGruende(i)("rem_cust"), "&", "")
    Next
#End Region

    'Debug.Print(strBodyText)

    send_email(strEMAdr, strBodyText)

  End Sub

  Private Sub set_result_hsb_all()
    Dim strResultText As String = "-"

    Try
      strResultText = get_result_hsb_all()

      drHSBResult(0).BeginEdit()
      drHSBResult(0)("result_all") = strResultText
      drHSBResult(0).EndEdit()

      lbl_result_hsb_all.DataBindings.Item(0).WriteValue()
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub set_result_hsb_all")
    End Try
  End Sub

  Private Sub table_check()
    'prüft, ob schon Daten für die HSB des Teils existieren
    'bei Bedarf werden resultierend daraus zunächst Daten im lokalen DataSet erzeugt
    Dim strSQL As String = ""
    Dim strResult As String = ""

    If String.IsNullOrEmpty(strIDAngebotReg) Then Exit Sub

    Try
      strSQL = "SELECT " &
               "id " &
               "FROM " &
               "t_hsb " &
               "WHERE " &
               "id_angebot_reg = " & strIDAngebotReg & ""

      strResult = count_max(strSQL)

      If strResult.Contains("error") Then strResult = "error"

      Select Case strResult
        Case "error"

        Case "0"
          create_hsb(strIDAngebotReg)
        Case Else
          strResult = load_hsb(strIDAngebotReg)
      End Select

    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub table_check")
    End Try
  End Sub

#End Region

#Region "functions"

  Private Function get_result_hsb_all() As String
    Dim lstResultHSB As New List(Of String)
    Dim strResultText As String = "-"

    With lstResultHSB
      .Add(lbl_ae_result_all_wert.Text)
      .Add(lbl_prod_result_all_wert.Text)
      .Add(lbl_qs_result_all_wert.Text)
    End With

    With lstResultHSB
      Select Case True
        Case .Contains("-")
          strResultText = "-"
        Case .Contains("no go")
          strResultText = "no go"
        Case .Contains("go but")
          strResultText = "go but"
        Case .Contains("go")
          strResultText = "go"
        Case Else
          strResultText = "-"
      End Select
    End With

    Return strResultText
  End Function

  Private Function get_result_hsb_area(ByVal strArea As String) As String
    Dim strResult As String = ""
#Region "int"
    Dim drGO_int() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                            match_int = 1 AND 
                                                                            result_attribute = 'go' AND 
                                                                            name <> '-'")

    Dim drGOBUT_int() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                               match_int = 1 AND 
                                                                               result_attribute = 'go but' AND 
                                                                               name <> '-'")

    Dim drNOGO_int() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                              match_int = 1 AND 
                                                                              result_attribute = 'no go' AND 
                                                                              name <> '-'")
#End Region

#Region "ext"
    Dim drGO_ext() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                            match_ext = 1 AND 
                                                                            result_attribute = 'go' AND 
                                                                            name <> '-'")

    Dim drGOBUT_ext() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                               match_ext = 1 AND 
                                                                               result_attribute = 'go but' AND 
                                                                               name <> '-'")

    Dim drNOGO_ext() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                              match_ext = 1 AND 
                                                                              result_attribute = 'no go' AND 
                                                                              name <> '-'")
#End Region

#Region "pending"
    Dim drPending_int() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                                match_int = 1 AND
                                                                                result_attribute = '-' AND
                                                                                name <> '-'")

    Dim drPending_ext() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("area = '" & strArea & "' AND 
                                                                                match_ext = 1 AND
                                                                                result_attribute = '-' AND
                                                                                name <> '-'")
#End Region

    If drNOGO_ext.Count > 0 Or drNOGO_int.Count > 0 Then
      strResult = "no go"
    ElseIf drGOBUT_ext.Count > 0 Or drGOBUT_int.Count > 0 Then
      strResult = "go but"
    ElseIf drGO_ext.Count > 0 Or drGO_int.Count > 0 Then
      strResult = "go"
    Else
      strResult = "-"
    End If

    If drPending_int.Count > 0 Or drPending_ext.Count > 0 Then strResult = "-"

    Return strResult
  End Function

  Private Function save_hsb(ByVal strIDAR) As String
    'es können Teile mit gleicher Zeichnung-Nr. und gleichem Index, aber unterschiedlicher Fertigungslosgröße verhanden sein
    'ist dies der Fall, enthält die Liste "lstParts" die entsprechenden ID's aus der Angebots-Reg dieser Teile
    'diese Teile sollen alle die gleichen Daten bezgl. der HSB erhalten
    'es muss nur eines der Teile bearbeitet werden, alle sollen den gleichen Stand bezgl. der HSB aufweisen
    Dim drHSB() As DataRow = DataSet_hsb.Tables("DataTable_hsb").Select("id_angebot_reg = " & strIDAR & "")
    Dim strSQL As String = ""
    Dim strResult As String = "0"

    If drHSB.Count = 0 Then
      Return "error - kein Eintrag in Angebots-Registierung gefunden"
    End If

    'Try
    'prüfen, ob schon Daten auf dem Server vorhanden sind
    strSQL = "SELECT 
              COUNT(id_angebot_reg)  
              FROM 
              t_hsb 
              WHERE 
              id_angebot_reg = " & strIDAR & ""

    strResult = count_max(strSQL)

    strSQL = ""

    If strResult.Contains("error") Then
      Return "error"
    End If

    'wenn bereits Daten existieren, sollte strResult eine numerische Zeichenfolge enthalten
    If IsNumeric(strResult) Then
      If Convert.ToInt64(strResult) > 0 Then 'Daten auf Server vorhanden
        'Update für aktuelles Teil
        For i As Integer = 0 To drHSB.Count - 1
          strSQL = strSQL &
                   "UPDATE 
                    t_hsb 
                    SET 
                    match_int = " & drHSB(i)("match_int") & ",
                    match_ext = " & drHSB(i)("match_ext") & ",
                    tool_exist = " & drHSB(i)("tool_exist") & ",
                    result_attribute = '" & drHSB(i)("result_attribute") & "',
                    rem_int = '" & hk(string_truncate(drHSB(i)("rem_int"), 2048)) & "',
                    rem_cust = '" & hk(string_truncate(drHSB(i)("rem_cust"), 2048)) & "',
                    name = '" & drHSB(i)("name") & "',
                    date_time_result = " & formatiere_datum_fuer_db(drHSB(i)("date_time_result")) & ",
                    time_update = '" & Date.Now.ToString(strDatFmt) & "' 
                    WHERE 
                    id = " & drHSB(i)("id") & ";"
        Next

        'sofern weitere Teile mit gleicher Zeichnung-Nr., gleichem Index, aber unterschiedlicher Fertigungslosgröße existieren:
        If lstParts.Count > 0 Then
          For j As Integer = 0 To lstParts.Count - 1
            For k As Integer = 0 To drHSB.Count - 1
              strSQL = strSQL &
                       "UPDATE 
                        t_hsb 
                        SET 
                        match_int = " & drHSB(k)("match_int") & ",
                        match_ext = " & drHSB(k)("match_ext") & ",
                        tool_exist = " & drHSB(k)("tool_exist") & ",
                        result_attribute = '" & drHSB(k)("result_attribute") & "',
                        rem_int = '" & hk(string_truncate(drHSB(k)("rem_int"), 2048)) & "',
                        rem_cust = '" & hk(string_truncate(drHSB(k)("rem_cust"), 2048)) & "',
                        name = '" & drHSB(k)("name") & "',
                        date_time_result = " & formatiere_datum_fuer_db(drHSB(k)("date_time_result")) & ",
                        time_update = '" & Date.Now.ToString(strDatFmt) & "' 
                        WHERE 
                        id_angebot_reg = " & lstParts(j) & " 
                        AND 
                        area = '" & drHSB(k)("area") & "' 
                        AND 
                        attribute = '" & drHSB(k)("attribute") & "';"
            Next
          Next
        End If

        'Gesamtergebnisse
        'AE
        strSQL = strSQL &
                 "UPDATE 
                  t_hsb 
                  SET 
                  result_attribute = '" & drHSBResult(0)("result_ae") & "',
                  name = '" & drHSBResult(0)("name_ae") & "',
                  date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_ae")) & " 
                  WHERE 
                  id_angebot_reg = " & strIDAR & " 
                  AND 
                  area = 'ae' 
                  AND 
                  attribute = 'result';"

        'für alle weiteren gleichen Teile, sofern vorhanden(siehe oben)
        If lstParts.Count > 0 Then
          For j As Integer = 0 To lstParts.Count - 1
            strSQL = strSQL &
                     "UPDATE 
                      t_hsb 
                      SET 
                      result_attribute = '" & drHSBResult(0)("result_ae") & "',
                      name = '" & drHSBResult(0)("name_ae") & "',
                      date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_ae")) & " 
                      WHERE 
                      id_angebot_reg = " & lstParts(j) & " 
                      AND 
                      area = 'ae' 
                      AND 
                      attribute = 'result';"
          Next
        End If

        'Produktion
        strSQL = strSQL &
                 "UPDATE 
                  t_hsb 
                  SET 
                  result_attribute = '" & drHSBResult(0)("result_prod") & "',
                  name = '" & drHSBResult(0)("name_prod") & "',
                  date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_prod")) & " 
                  WHERE 
                  id_angebot_reg = " & strIDAR & " 
                  AND 
                  area = 'prod' 
                  AND 
                  attribute = 'result';"

        'für alle weiteren gleichen Teile, sofern vorhanden(siehe oben)
        If lstParts.Count > 0 Then
          For j As Integer = 0 To lstParts.Count - 1
            strSQL = strSQL &
                     "UPDATE 
                      t_hsb 
                      SET 
                      result_attribute = '" & drHSBResult(0)("result_prod") & "',
                      name = '" & drHSBResult(0)("name_prod") & "',
                      date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_prod")) & " 
                      WHERE 
                      id_angebot_reg = " & lstParts(j) & " 
                      AND 
                      area = 'prod' 
                      AND 
                      attribute = 'result';"
          Next
        End If

        'QS
        strSQL = strSQL &
                 "UPDATE 
                  t_hsb 
                  SET 
                  result_attribute = '" & drHSBResult(0)("result_qs") & "',
                  name = '" & drHSBResult(0)("name_qs") & "',
                  date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_qs")) & " 
                  WHERE 
                  id_angebot_reg = " & strIDAR & " 
                  AND 
                  area = 'qs' 
                  AND 
                  attribute = 'result';"

        'für alle weiteren gleichen Teile, sofern vorhanden(siehe oben)
        If lstParts.Count > 0 Then
          For j As Integer = 0 To lstParts.Count - 1
            strSQL = strSQL &
                     "UPDATE 
                      t_hsb 
                      SET 
                      result_attribute = '" & drHSBResult(0)("result_qs") & "',
                      name = '" & drHSBResult(0)("name_qs") & "',
                      date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_qs")) & " 
                      WHERE 
                      id_angebot_reg = " & lstParts(j) & " 
                      AND 
                      area = 'qs' 
                      AND 
                      attribute = 'result';"
          Next
        End If

        'Gesamt
        'Debug.Print("Gesamt, aktueller DS, result_all: " & drHSBResult(0)("result_all"))
        strSQL = strSQL &
                 "UPDATE 
                  t_hsb 
                  SET 
                  result_attribute = '" & drHSBResult(0)("result_all") & "',
                  name = '" & drHSBResult(0)("name_all") & "',
                  date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_all")) & " 
                  WHERE 
                  id_angebot_reg = " & strIDAR & " 
                  AND 
                  area = 'result' 
                  AND 
                  attribute = 'result_all';"

        'für alle weiteren gleichen Teile, sofern vorhanden(siehe oben)
        If lstParts.Count > 0 Then
          For j As Integer = 0 To lstParts.Count - 1
            'Debug.Print("Gesamt, weiterer DS, result_all: " & drHSBResult(0)("result_all"))
            strSQL = strSQL &
                     "UPDATE 
                      t_hsb 
                      SET 
                      result_attribute = '" & drHSBResult(0)("result_all") & "',
                      name = '" & drHSBResult(0)("name_all") & "',
                      date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_all")) & " 
                      WHERE 
                      id_angebot_reg = " & lstParts(j) & " 
                      AND 
                      area = 'result' 
                      AND 
                      attribute = 'result_all';"
          Next
        End If

        strResult = update_insert_delete(strSQL, False,, "Function save_hsb, Daten aktualisieren")

      Else 'noch keine Daten vorhanden
        Try


          strSQL = ""
          For i As Integer = 0 To drHSB.Count - 1
            strSQL = strSQL &
                    "INSERT INTO 
                     t_hsb 
                     SET 
                     id_angebot_reg = " & strIDAR & ",
                     area = '" & drHSB(i)("area") & "',
                     attribute = '" & drHSB(i)("attribute") & "',
                     match_int = " & drHSB(i)("match_int") & ",
                     match_ext = " & drHSB(i)("match_ext") & ",
                     tool_exist = " & drHSB(i)("tool_exist") & ",
                     result_attribute = '" & drHSB(i)("result_attribute") & "',
                     rem_int = '" & hk(string_truncate(drHSB(i)("rem_int"), 2048)) & "',
                     rem_cust = '" & hk(string_truncate(drHSB(i)("rem_cust"), 2048)) & "',
                     name = '" & drHSB(i)("name") & "',
                     date_time_result = " & formatiere_datum_fuer_db(drHSB(i)("date_time_result")) & ",
                     order_no = " & drHSB(i)("order_no") & ",
                     time_update = '" & Date.Now.ToString(strDatFmt) & "';"
          Next

          strResult = update_insert_delete(strSQL, False,, "Function save_hsb, Daten anlegen")

          Threading.Thread.Sleep(100)

          'für alle weiteren gleichen Teile, sofern vorhanden (siehe oben)
          If lstParts.Count > 0 Then
            For j As Integer = 0 To lstParts.Count - 1
              strSQL = ""
              For k As Integer = 0 To drHSB.Count - 1
                strSQL = strSQL &
                         "INSERT INTO 
                          t_hsb
                          SET 
                          id_angebot_reg = " & lstParts(j) & ",
                          area = '" & drHSB(k)("area") & "',
                          Attribute = '" & drHSB(k)("attribute") & "',
                          match_int = " & drHSB(k)("match_int") & ",
                          match_ext = " & drHSB(k)("match_ext") & ",
                          tool_exist = " & drHSB(k)("tool_exist") & ",
                          result_attribute = '" & drHSB(k)("result_attribute") & "',
                          rem_int = '" & hk(string_truncate(drHSB(k)("rem_int"), 2048)) & "',
                          rem_cust = '" & hk(string_truncate(drHSB(k)("rem_cust"), 2048)) & "',
                          Name = '" & drHSB(k)("name") & "',
                          date_time_result = " & formatiere_datum_fuer_db(drHSB(k)("date_time_result")) & ",
                          order_no = " & drHSB(k)("order_no") & ",
                          time_update = '" & Date.Now.ToString(strDatFmt) & "';"
              Next
            Next
            strResult = update_insert_delete(strSQL, False,, "Function save_hsb, Daten anlegen")
          End If

          'Gesamtergebnisse
          'AE
          strSQL = "UPDATE 
                    t_hsb 
                    SET 
                    result_attribute = '" & drHSBResult(0)("result_ae") & "',
                    name = '" & drHSBResult(0)("name_ae") & "',
                    date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_ae")) & "
                    WHERE 
                    id_angebot_reg = " & strIDAR & " 
                    AND 
                    area = 'ae' 
                    AND 
                    attribute = 'result';"

          'für alle weiteren gleichen Teile, sofern vorhanden (siehe oben)
          If lstParts.Count > 0 Then
            For j As Integer = 0 To lstParts.Count - 1
              strSQL = strSQL &
                       "UPDATE 
                        t_hsb 
                        SET 
                        result_attribute = '" & drHSBResult(0)("result_ae") & "',
                        name = '" & drHSBResult(0)("name_ae") & "',
                        date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_ae")) & " 
                        WHERE 
                        id_angebot_reg = " & lstParts(j) & " 
                        AND 
                        area = 'ae' 
                        AND 
                        attribute = 'result';"
            Next
          End If

          'Produktion
          strSQL = strSQL &
                   "UPDATE 
                    t_hsb 
                    SET 
                    result_attribute = '" & drHSBResult(0)("result_prod") & "',
                    name = '" & drHSBResult(0)("name_prod") & "',
                    date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_prod")) & " 
                    WHERE 
                    id_angebot_reg = " & strIDAR & " 
                    AND 
                    area = 'prod' 
                    AND 
                    attribute = 'result';"

          'für alle weiteren gleichen Teile, sofern vorhanden (siehe oben)
          If lstParts.Count > 0 Then
            For j As Integer = 0 To lstParts.Count - 1
              strSQL = strSQL &
                       "UPDATE 
                        t_hsb 
                        SET 
                        result_attribute = '" & drHSBResult(0)("result_prod") & "',
                        name = '" & drHSBResult(0)("name_prod") & "',
                        date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_prod")) & " 
                        WHERE 
                        id_angebot_reg = " & lstParts(j) & " 
                        AND 
                        area = 'prod' 
                        AND 
                        attribute = 'result';"
            Next
          End If

          'QS
          strSQL = strSQL &
                   "UPDATE 
                    t_hsb 
                    SET 
                    result_attribute = '" & drHSBResult(0)("result_qs") & "',
                    name = '" & drHSBResult(0)("name_qs") & "',
                    date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_qs")) & " 
                    WHERE 
                    id_angebot_reg = " & strIDAR & " 
                    AND 
                    area = 'qs' 
                    AND 
                    attribute = 'result';"

          'für alle weiteren gleichen Teile, sofern vorhanden (siehe oben)
          If lstParts.Count > 0 Then
            For j As Integer = 0 To lstParts.Count - 1
              strSQL = strSQL &
                       "UPDATE 
                        t_hsb 
                        SET 
                        result_attribute = '" & drHSBResult(0)("result_qs") & "',
                        name = '" & drHSBResult(0)("name_qs") & "',
                        date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_qs")) & " 
                        WHERE 
                        id_angebot_reg = " & lstParts(j) & " 
                        AND 
                        area = 'qs' 
                        AND 
                        attribute = 'result';"
            Next
          End If

          'Gesamt
          strSQL = strSQL &
                   "UPDATE 
                    t_hsb 
                    SET 
                    result_attribute = '" & drHSBResult(0)("result_all") & "',
                    name = '" & drHSBResult(0)("name_all") & "',
                    date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_all")) & " 
                    WHERE 
                    id_angebot_reg = " & strIDAR & " 
                    AND 
                    area = 'result' 
                    AND 
                    attribute = 'result_all';"
          'für alle weiteren gleichen Teile, sofern vorhanden (siehe oben)
          If lstParts.Count > 0 Then
            For j As Integer = 0 To lstParts.Count - 1
              strSQL = strSQL &
                       "UPDATE 
                        t_hsb 
                        SET 
                        result_attribute = '" & drHSBResult(0)("result_all") & "',
                        name = '" & drHSBResult(0)("name_all") & "',
                        date_time_result = " & formatiere_datum_fuer_db(drHSBResult(0)("date_time_result_all")) & " 
                        WHERE 
                        id_angebot_reg = " & lstParts(j) & " 
                        AND 
                        area = 'result' 
                        AND 
                        attribute = 'result_all';"
            Next
          End If

          strResult = update_insert_delete(strSQL, False,, "Function save_hsb, Daten aktualisieren")

        Catch ex As Exception
          WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function save_hsb" & vbCrLf &
                          "Zweig INSERT, id_angebot_reg: " & strIDAR & "")

          strResult = "error - INSERT nicht möglich, es sind bereits Daten vorhanden"
        End Try
      End If

      'Eintrag in der Angebots-Registrierung aktualisieren, Resultate immer, DateTime nur, wenn Resultat vorhanden
      With Form1.GridView_AngebotReg
        If drHSBResult(0)("result_ae").Contains("go") Then
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_erstellt_ae", drHSBResult(0)("date_time_result_ae"))
        Else
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_erstellt_ae", DBNull.Value)
        End If
        If drHSBResult(0)("result_prod").Contains("go") Then
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_erstellt_prod", drHSBResult(0)("date_time_result_prod"))
        Else
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_erstellt_prod", DBNull.Value)
        End If
        If drHSBResult(0)("result_qs").Contains("go") Then
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_erstellt_qm", drHSBResult(0)("date_time_result_qs"))
        Else
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_erstellt_qm", DBNull.Value)
        End If
        If drHSBResult(0)("result_all").Contains("go") Then
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_freigegeben", drHSBResult(0)("date_time_result_all"))
        Else
          .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "zeit_datum_hsb_freigegeben", DBNull.Value)
        End If

        .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "machbarkeit_ae", drHSBResult(0)("result_ae"))
        .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "machbarkeit_prod", drHSBResult(0)("result_prod"))
        .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "machbarkeit_qm", drHSBResult(0)("result_qs"))
        .SetRowCellValue(Form1.GridView_AngebotReg.FocusedRowHandle, "machbarkeit", drHSBResult(0)("result_all"))

        If lstParts.Count > 0 Then equal_hsb(strZNr, strInd, lngFLG, strIDAR)

      End With

      'Ergebnisse auch im Tracking speichern
      'dazu muss nur die globale Variable "blgeandert" auf true gesetzt werden
      blGeaendert = True
      Form1.speichern()
    End If
    'Catch ex As Exception
    '  strResult = "error"
    '  WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in Function save_hsb" & vbCrLf &
    '                  "Fehler: " & strResult & vbCrLf &
    '                  "SQL:" & strSQL)
    'End Try

    Return strResult
  End Function

#End Region

#Region "grid_ae"
  Private Sub DateEdit_ae_Modified(sender As Object, e As EventArgs) Handles DateEdit_ae.Modified
    DateEdit_ae.DataBindings.Item(0).WriteValue()
  End Sub

  Private Sub GridView_ae_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView_ae.CellValueChanged
    Select Case e.Column.Name
      Case "col_ae_match_int", "col_ae_result_attribute"
        set_result_hsb_ae()
    End Select
  End Sub

  Private Sub RepositoryItemCheckEdit_ae_EditValueChanged(Sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit_ae.EditValueChanged
    GridView_ae.PostEditor()
  End Sub

  Private Sub RepositoryItemComboBox_result_ae_EditValueChanged(Sender As Object, e As EventArgs) Handles RepositoryItemComboBox_result_ae.EditValueChanged
    GridView_ae.PostEditor()
  End Sub

  Private Sub RepositoryItemMemoExEdit_ae_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemMemoExEdit_ae.EditValueChanged
    GridView_ae.PostEditor()
  End Sub

  Private Sub set_result_hsb_ae()
    If get_result_hsb_area("ae") <> "-" Then
      drHSBResult(0).BeginEdit()
      drHSBResult(0)("result_ae") = get_result_hsb_area("ae")

      drHSBResult(0).EndEdit()
    Else
      drHSBResult(0).BeginEdit()
      drHSBResult(0)("result_ae") = "-"
      'drHSBResult(0)("date_time_result_ae") = Date.Now
      drHSBResult(0).EndEdit()
    End If

    lbl_ae_result_all_wert.DataBindings.Item(0).WriteValue()
  End Sub

  Private Sub GridView_ae_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView_ae.CustomDrawCell
    If GridView_ae.GetRowCellValue(e.RowHandle, col_ae_match_int) = 1 Then
      Select Case e.Column.FieldName
        Case "result_attribute"
          With e
            If Not IsDBNull(.CellValue) Then
              Select Case .CellValue
                Case "go"
                  .Appearance.BackColor = colGO
                Case "go but"
                  .Appearance.BackColor = colGOBUT
                Case "no go"
                  .Appearance.BackColor = colNOGO
                Case Else
                  .Appearance.BackColor = colEmpty
              End Select
            End If
          End With
      End Select
    End If
  End Sub

  Private Sub cbx_ae_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_ae_name.SelectedIndexChanged
    Dim strName As String = cbx_ae_name.EditValue

    drHSBResult(0).BeginEdit()
    drHSBResult(0)("name_ae") = strName
    drHSBResult(0)("date_time_result_ae") = Date.Now
    drHSBResult(0).EndEdit()

    cbx_ae_name.DataBindings.Item(0).WriteValue()
    DateEdit_ae.DataBindings.Item(0).WriteValue()

    For Each dr As DataRow In DataSet_hsb.Tables("DataTable_hsb").Rows
      If dr("area") = "ae" Then
        dr("name") = strName
      End If
    Next

    set_result_hsb_ae()
  End Sub

#End Region

#Region "grid_prod"
  Private Sub DateEdit_prod_Modified(sender As Object, e As EventArgs) Handles DateEdit_prod.Modified
    DateEdit_prod.DataBindings.Item(0).WriteValue()
  End Sub

  Private Sub GridView_prod_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView_prod.CellValueChanged
    Select Case e.Column.Name
      Case "col_prod_match_ext", "col_prod_match_int", "col_prod_result_attribute"
        set_result_hsb_prod()
    End Select
  End Sub

  Private Sub RepositoryItemCheckEdit_prod_EditValueChanged(Sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit_prod.EditValueChanged
    GridView_prod.PostEditor()
  End Sub

  Private Sub RepositoryItemComboBox_result_prod_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox_result_prod.EditValueChanged
    GridView_prod.PostEditor()
  End Sub

  Private Sub RepositoryItemMemoExEdit_prod_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemMemoExEdit_prod.EditValueChanged
    GridView_prod.PostEditor()
  End Sub

  Private Sub RepositoryItemExEdit_prod_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemMemoExEdit_prod.EditValueChanged
    GridView_prod.PostEditor()
  End Sub

  Private Sub set_result_hsb_prod()
    If get_result_hsb_area("prod") <> "-" Then
      drHSBResult(0).BeginEdit()
      drHSBResult(0)("result_prod") = get_result_hsb_area("prod")

      drHSBResult(0).EndEdit()
    Else
      drHSBResult(0).BeginEdit()
      drHSBResult(0)("result_prod") = "-"
      'drHSBResult(0)("date_time_result_prod") = Date.Now
      drHSBResult(0).EndEdit()
    End If

    lbl_prod_result_all_wert.DataBindings.Item(0).WriteValue()
  End Sub

  Private Sub GridView_prod_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView_prod.CustomDrawCell
    If GridView_prod.GetRowCellValue(e.RowHandle, col_prod_match_int) = 1 Or GridView_prod.GetRowCellValue(e.RowHandle, col_prod_match_ext) = 1 Then
      Select Case e.Column.FieldName
        Case "result_attribute"
          With e
            If Not IsDBNull(.CellValue) Then
              Select Case .CellValue
                Case "go"
                  .Appearance.BackColor = colGO
                Case "go but"
                  .Appearance.BackColor = colGOBUT
                Case "no go"
                  .Appearance.BackColor = colNOGO
                Case Else
                  .Appearance.BackColor = colEmpty
              End Select
            End If
          End With
      End Select
    End If


  End Sub

  Private Sub GridView_prod_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView_prod.CellValueChanging
    Select Case e.Column.Name
      Case "col_prod_match_ext"
        If e.Value = 1 Then
          GridView_prod.SetRowCellValue(GridView_prod.FocusedRowHandle, "match_int", 0)
        End If
      Case "col_prod_match_int"
        If e.Value = 1 Then
          GridView_prod.SetRowCellValue(GridView_prod.FocusedRowHandle, "match_ext", 0)
        End If
    End Select
  End Sub

  Private Sub cbx_prod_name_SeletedIndexChanged(sender As Object, e As EventArgs) Handles cbx_prod_name.SelectedIndexChanged
    Dim strName As String = cbx_prod_name.EditValue

        If drHSBResult.Count = 0 Then
            WriteToErrorLog("Name füllen Prod", "kein HSBResult vorhanden: " & strName, "datetimeresultprod = " & Date.Now)
            Exit Sub
        End If

        drHSBResult(0).BeginEdit()
        drHSBResult(0)("name_prod") = strName
        drHSBResult(0)("date_time_result_prod") = Date.Now
        drHSBResult(0).EndEdit()

        cbx_prod_name.DataBindings.Item(0).WriteValue()
    DateEdit_prod.DataBindings.Item(0).WriteValue()

    For Each dr As DataRow In DataSet_hsb.Tables("DataTable_hsb").Rows
      If dr("area") = "prod" Then
        dr("name") = strName
      End If
    Next

    set_result_hsb_prod()
  End Sub

#End Region

#Region "grid_qs"
  Private Sub DateEdit_qs_Modified(sender As Object, e As EventArgs) Handles DateEdit_qs.Modified
    DateEdit_qs.DataBindings.Item(0).WriteValue()
  End Sub

  Private Sub GridView_qs_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView_qs.CellValueChanged
    Select Case e.Column.Name
      Case "col_qs_match_int", "col_qs_result_attribute"
        set_result_hsb_qs()
    End Select
  End Sub

  Private Sub RepositoryItemCheckEdit_qs_EditValueChanged(Sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit_qs.EditValueChanged
    GridView_qs.PostEditor()
  End Sub

  Private Sub RepositoryItemComboBox_result_qs_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox_result_qs.EditValueChanged
    GridView_qs.PostEditor()
  End Sub

  Private Sub RepositoryItemExEdit_qs_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemMemoExEdit_qs.EditValueChanged
    GridView_qs.PostEditor()
  End Sub

  Private Sub set_result_hsb_qs()
    If get_result_hsb_area("qs") <> "-" Then
      drHSBResult(0).BeginEdit()
      drHSBResult(0)("result_qs") = get_result_hsb_area("qs")

      drHSBResult(0).EndEdit()
    Else
      drHSBResult(0).BeginEdit()
      drHSBResult(0)("result_qs") = "-"
      'drHSBResult(0)("date_time_result_qs") = Date.Now
      drHSBResult(0).EndEdit()
    End If

    lbl_qs_result_all_wert.DataBindings.Item(0).WriteValue()
  End Sub

  Private Sub GridView_qs_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView_qs.CustomDrawCell
    If GridView_qs.GetRowCellValue(e.RowHandle, col_qs_match_int) = 1 Or GridView_qs.GetRowCellValue(e.RowHandle, col_qs_match_ext) = 1 Then
      Select Case e.Column.FieldName
        Case "result_attribute"
          With e
            If Not IsDBNull(.CellValue) Then
              Select Case .CellValue
                Case "go"
                  .Appearance.BackColor = colGO
                Case "go but"
                  .Appearance.BackColor = colGOBUT
                Case "no go"
                  .Appearance.BackColor = colNOGO
                Case Else
                  .Appearance.BackColor = colEmpty
              End Select
            End If
          End With
      End Select
    End If


  End Sub

  Private Sub cbx_qs_name_SeletedIndexChanged(sender As Object, e As EventArgs) Handles cbx_qs_name.SelectedIndexChanged
    Dim strName As String = cbx_qs_name.EditValue

    drHSBResult(0).BeginEdit()
    drHSBResult(0)("name_qs") = strName
    drHSBResult(0)("date_time_result_qs") = Date.Now
    drHSBResult(0).EndEdit()

    cbx_qs_name.DataBindings.Item(0).WriteValue()
    DateEdit_qs.DataBindings.Item(0).WriteValue()

    For Each dr As DataRow In DataSet_hsb.Tables("DataTable_hsb").Rows
      If dr("area") = "qs" Then
        dr("name") = strName
      End If
    Next

    set_result_hsb_qs()
  End Sub

#End Region

#Region "result"
  Private Sub btn_freigeben_Click(sender As Object, e As EventArgs) Handles btn_freigeben.Click
    hsb_freigeben
  End Sub

  Private Sub DateEdit_all_Modified(sender As Object, e As EventArgs) Handles DateEdit_all.Modified
    'DateEdit_all.DataBindings.Item(0).WriteValue()
    'lbl_name_ae_hsb_all_wert.Text = cbx_ae_name.EditValue
    'lbl_name_ae_hsb_all_wert.DataBindings.Item(0).WriteValue()
    'set_result_hsb_all()
  End Sub

  Private Sub hsb_freigeben()
    'prüfen, ob alle 3 Teilergebnisse existieren
    If lbl_ae_result_all_wert.Text = "-" Or lbl_prod_result_all_wert.Text = "-" Or lbl_qs_result_all_wert.Text = "-" Then
      Select Case strSprache
        Case "de-DE"
          strTextMsg = "Es sind nicht alle HSB-Bereiche bewertet"
          strTitelMsg = "HSB Gesamtergebnis freigeben"
        Case Else
          strTextMsg = "not all feasibilty areas are set"
          strTitelMsg = "set total result feasibilty"
      End Select

      MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, MessageBoxIcon.Hand)
      Exit Sub
    End If

    If lbl_name_ae_hsb_all_wert.Text <> "-" Then
      Select Case strSprache
        Case "de-DE"
          strTextMsg = "Soll die Freigabe des Gesamtergebnisses aufgehoben werden?"
          strTitelMsg = "HSB Gesamtergebnis"
        Case Else
          strTextMsg = "cancel release?"
          strTitelMsg = "total result feasibilty"
      End Select

      If MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        lbl_name_ae_hsb_all_wert.Text = "-"
        lbl_name_ae_hsb_all_wert.DataBindings.Item(0).WriteValue()
        DateEdit_all.EditValue = Now
        DateEdit_all.DataBindings.Item(0).WriteValue()
        lbl_result_hsb_all.Text = "-"
        lbl_result_hsb_all.DataBindings.Item(0).WriteValue()
      End If
      Exit Sub
    End If

    lbl_name_ae_hsb_all_wert.Text = cbx_ae_name.EditValue
    lbl_name_ae_hsb_all_wert.DataBindings.Item(0).WriteValue()
    DateEdit_all.EditValue = Now
    DateEdit_all.DataBindings.Item(0).WriteValue()
    lbl_result_hsb_all.Text = get_result_hsb_all()
    lbl_result_hsb_all.DataBindings.Item(0).WriteValue()
  End Sub

#End Region

#Region "menu"
  Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem_schliessen.ItemClick
    Form_close()
  End Sub


#End Region

End Class