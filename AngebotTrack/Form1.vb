Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Drawing.Drawing2D

Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.Utils.Win
Imports DevExpress.XtraSplashScreen

Imports Excel = Microsoft.Office.Interop.Excel

Public Class Form1
  Dim painter As clCustomOverlayPainter = Nothing
  Private _handle As IOverlaySplashScreenHandle = Nothing

  Dim args As New XtraMessageBoxArgs()

#Region "progresspanel"
  Private Function ShowProgressPanel(ByVal painter As clCustomOverlayPainter) As IOverlaySplashScreenHandle
    Return SplashScreenManager.ShowOverlayForm(Me, opacity:=140, backColor:=Color.Azure, customPainter:=painter)
  End Function

  Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle, ByVal painter As clCustomOverlayPainter)
    If handle IsNot Nothing Then
      SplashScreenManager.CloseOverlayForm(handle)
    End If
  End Sub

  Public Sub show_overlay_form(ByVal strTextToShow As String)
    Try
      painter = New clCustomOverlayPainter(50, strTextToShow)
      _handle = ShowProgressPanel(painter)
    Catch ex As Exception
    End Try
  End Sub

#End Region

  Sub New
      InitializeComponent()

#Region "messagebox"
    Select Case strSprache
      Case "de-DE"
        args.Caption = "Excel-Export"
        args.Text = "bitte eine Variante auswählen"
        args.Buttons = New DialogResult() {DialogResult.Yes, DialogResult.No, DialogResult.Cancel}
      Case Else
        args.Caption = "excel export"
        args.Text = "please select variant"
        args.Buttons = New DialogResult() {DialogResult.Yes, DialogResult.No, DialogResult.Cancel}
    End Select

    AddHandler args.Showing, AddressOf Args_showing

#End Region
  End Sub

#Region "form1"
  'Protected Overrides ReadOnly Property CreateParams() As CreateParams
  '  Get
  '    Dim cp As CreateParams = MyBase.CreateParams
  '    Const CS_NOCLOSE As Integer = &H200
  '    cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
  '    Return cp
  '  End Get
  'End Property

  Private Sub all_Keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
    int_counter_user_action = 0
  End Sub

  Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    Select Case e.KeyData
      Case Keys.NumLock
        If My.Computer.Keyboard.NumLock Then
          BarStaticItem_numlock.Caption = "NUM"
        Else
          BarStaticItem_numlock.Caption = ""
        End If
      Case Keys.CapsLock
        If My.Computer.Keyboard.CapsLock Then
          BarStaticItem_capslock.Caption = "CAP"
        Else
          BarStaticItem_capslock.Caption = ""
        End If
    End Select
  End Sub

  Private Sub all_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
    int_counter_user_action = 0
  End Sub

  Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    write_user_settings()
    speichern()
  End Sub

  Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    Datensatz_entsperren(suser)
  End Sub

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Form1Load()
  End Sub

  Private Sub Form1Load()
    Dim con As Control

    For Each con In Me.Controls
      AddHandler con.MouseMove, AddressOf all_MouseMove
      AddHandler con.KeyPress, AddressOf all_Keypress
    Next

    GridControl_tracking.DataSource = DataSet_tracking.Tables("DataTable_tracking")

    berechtigung()

    blGeaendert = False

    SwitchLanguage(strSprache)

    'If LCase(strBerechtigung) <> "admin" Then Switch_vertriebsbereich(strVertriebsbereich)

    fill_cboxes_in_form1()

    connectionstring = connectionstringKalk

    show_vertriebsbereich(strOrganisation_company, strOrganisation_division, strOrganisation_plant)

    connection_label()
    CheckLockKeys()
    BarStaticItem_berechtigung.Caption = UCase(strBerechtigung)
    BarStaticItem_date.Caption = Today.ToShortDateString

    read_user_settings()

    BandedGridView_tracking.FocusedRowHandle = 0
  End Sub

  Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    SplashScreen.Close()
  End Sub
#End Region

#Region "gridcontrols"
  Public Sub speichern()
    If blGeaendert = False Then Exit Sub
    'id's der aktuell gewählten rows an variablen übergeben
    intRowHandle_AT = BandedGridView_tracking.GetRowCellValue(BandedGridView_tracking.FocusedRowHandle, "id_tracking")
    'intRowHandle_AR = GridView_AngebotReg.GetRowCellValue(GridView_AngebotReg.FocusedRowHandle, "id")
    'Speichern
    speichern_tracking()
    speichern_teile()

    Thread.Sleep(50)

    blGeaendert = False

    aktualisieren_daten()

    Thread.Sleep(50)

    'Debug.Print("intRowHandle_AT: " & intRowHandle_AT)
    'Debug.Print("intRowHandle_AR: " & intRowHandle_AR)

    'BandedGridView_tracking.FocusedRowHandle = intRowHandle_AT
    'GridView_AngebotReg.FocusedRowHandle = intRowHandle_AR
  End Sub

#Region "tracking"

  Sub OnShownEditorGriedView_tracking(ByVal sender As Object, ByVal e As EventArgs) Handles BandedGridView_tracking.ShownEditor
    AddHandler CType(sender, ColumnView).ActiveEditor.EditValueChanged, AddressOf OnEditValueChangedGridView_tracking
  End Sub

  Sub OnEditValueChangedGridView_tracking(ByVal sender As Object, ByVal e As EventArgs)
    'beachte: nachfolgend ist ausschließlich für MemoExEdit ausgelegt, sobald weitere columns im Grid-Tracking editierbar sind, läuft die Routine auf einen Fehler!
    Dim editor As MemoExEdit = CType(sender, MemoExEdit)
    'GridView_tracking.PostEditor()
    BandedGridView_tracking.SetFocusedValue(editor.EditValue)
  End Sub

  Public Sub prio_automatik()
    For i As Integer = 0 To DataSet_tracking.Tables("DataTable_tracking").Rows.Count - 1
      If DataSet_tracking.Tables("DataTable_tracking").Rows(i)("status_bearbeitung") = "offen" Then
        DataSet_tracking.Tables("DataTable_tracking").Rows(i)("prio_automatisch") =
          get_prio_punkte_tracking(DataSet_tracking.Tables("DataTable_tracking").Rows(i)("id_tracking"))
      Else
        DataSet_tracking.Tables("DataTable_tracking").Rows(i)("prio_automatisch") = "-"
      End If
    Next
  End Sub

  'Private Function GetLastVisibleRowHandle(ByVal view As GridView) As Integer
  '  Dim viewInfo As DevExpress.B GridViewInfo = TryCast(view.GetViewInfo(), GridViewInfo)
  '  Return viewInfo.RowsInfo.Last().RowHandle
  'End Function

  Private Function get_bemerkungen(ByVal lngIDTr As Long) As String
    Dim drBemerkungen() As DataRow = DataSet_tracking.DataTable_tracking.Select("id_tracking = " & lngIDTr & "")

    If drBemerkungen.Count > 0 Then
      If Not IsDBNull(drBemerkungen(0)("bemerkungen_tracking")) Then
        Return "'" & hk(string_truncate(drBemerkungen(0)("bemerkungen_tracking"), 1024)) & "'"
      Else
        Return "NULL"
      End If
    Else
        Return "NULL"
    End If
  End Function

  Private Function speichern_tracking() As String
    Dim strSQL As String
    Dim strAntwort As String = "ok"

    strAngebotBis = max_datum_aus_devgrid("zeit_datum_angebot_bis")

    strMitZKT = mit_zkt_extbearb_aus_devgrid("mit_zukaufteilen")
    strMitExtBearb = mit_zkt_extbearb_aus_devgrid("mit_ext_ag")

    strBerechnungErstellt = max_datum_aus_devgrid("zeit_datum_berechnung_erstellt")
    strHSBErstelltAE = max_datum_aus_devgrid("zeit_datum_hsb_erstellt_ae")
    strHSBErstelltPROD = max_datum_aus_devgrid("zeit_datum_hsb_erstellt_prod")
    strHSBErstelltQS = max_datum_aus_devgrid("zeit_datum_hsb_erstellt_qm")
    strHSBFreigegeben = max_datum_aus_devgrid("zeit_datum_hsb_freigegeben")
    strZKTAngefragt = max_datum_aus_devgrid("zeit_datum_zukaufteile_angefragt")
    strExtBearbAngefragt = max_datum_aus_devgrid("zeit_datum_ext_bearbeitung_angefragt")
    strZKTAngebotErhalten = max_datum_aus_devgrid("zeit_datum_zukaufteile_angebot_erhalten")
    strExtBearbAngebotErhalten = max_datum_aus_devgrid("zeit_datum_ext_bearbeitung_angebot_erhalten")
    strKalkErstellt = max_datum_aus_devgrid("zeit_datum_kalkulation_erstellt")

    strStatusBerechnung = status_bearbeitung("zeit_datum_berechnung_erstellt")
    strStatusHSBAE = status_bearbeitung("machbarkeit_ae")
    strStatusHSBPROD = status_bearbeitung("machbarkeit_prod")
    strStatusHSBQS = status_bearbeitung("machbarkeit_qm")
    strStatusKalk = status_bearbeitung("zeit_datum_kalkulation_erstellt")

    'If IsDBNull(BandedGridView_tracking.GetRowCellValue(lngLastRowHandleTracking, "bemerkungen_tracking")) Then
    '  strBemerkungenTracking = "NULL"
    'Else
    '  strBemerkungenTracking = hk(BandedGridView_tracking.GetRowCellValue(lngLastRowHandleTracking, "bemerkungen_tracking"))
    '  strBemerkungenTracking = "'" & strBemerkungenTracking & "'"
    'End If

    strBemerkungenTracking = get_bemerkungen(lngIDTracking)

    strSQL = "UPDATE " &
             "t_angebot_tracking " &
             "SET " &
             "zeit_datum_angebot_bis = " & strAngebotBis & ", " &
             "zukaufteile_erforderlich = " & strMitZKT & ", " &
             "ext_bearbeitung_erforderlich = " & strMitExtBearb & ", " &
             "zeit_datum_berechnung_vorhanden = " & strBerechnungErstellt & ", " &
             "zeit_datum_zukaufteile_angefragt = " & strZKTAngefragt & ", " &
             "zeit_datum_ext_bearbeitung_angefragt = " & strExtBearbAngefragt & ", " &
             "zeit_datum_zukaufteile_angebot_vorhanden = " & strZKTAngebotErhalten & ", " &
             "zeit_datum_ext_bearbeitung_angebot_vorhanden = " & strExtBearbAngebotErhalten & ", " &
             "zeit_datum_hsb_vorhanden_ae = " & strHSBErstelltAE & ", " &
             "zeit_datum_hsb_vorhanden_prod = " & strHSBErstelltPROD & ", " &
             "zeit_datum_hsb_vorhanden_qm = " & strHSBErstelltQS & ", " &
             "zeit_datum_hsb_freigegeben = " & strHSBFreigegeben & ", " &
             "zeit_datum_kalk_erstellt =  " & strKalkErstellt & ", " &
             "bemerkungen_tracking = " & strBemerkungenTracking & "," &
             "status_berechnung = '" & strStatusBerechnung & "'," &
             "status_hsb_ae = '" & strStatusHSBAE & "'," &
             "status_hsb_prod = '" & strStatusHSBPROD & "'," &
             "status_hsb_qm = '" & strStatusHSBQS & "'," &
             "status_kalk = '" & strStatusKalk & "' " &
             "WHERE " &
             "id_tracking = " & lngIDTracking & ""

    Try
      strAntwort = update_insert_delete(strSQL,,, "function speichern_tracking")

      If strAntwort.Contains("error") Then
        Return "error_speichern_tracking"
      Else
        'zugehörige Zeile im internen DataTable aktualisieren
        Dim drTracking() As DataRow = DataSet_tracking.Tables("DataTable_tracking").Select("id_tracking = " & lngIDTracking & "")

        If IsDate(Replace(strAngebotBis, "'", "")) Then
          drTracking(0)("zeit_datum_angebot_bis") = Convert.ToDateTime(Replace(strAngebotBis, "'", ""))
        Else
          drTracking(0)("zeit_datum_angebot_bis") = DBNull.Value
        End If

        drTracking(0)("zukaufteile_erforderlich") = Convert.ToBoolean(Convert.ToByte(strMitZKT))
        drTracking(0)("ext_bearbeitung_erforderlich") = Convert.ToBoolean(Convert.ToByte(strMitExtBearb))

        If IsDate(Replace(strBerechnungErstellt, "'", "")) Then
          drTracking(0)("zeit_datum_berechnung_vorhanden") = Convert.ToDateTime(Replace(strBerechnungErstellt, "'", ""))
        Else
          drTracking(0)("zeit_datum_berechnung_vorhanden") = DBNull.Value
        End If

        If IsDate(Replace(strHSBErstelltAE, "'", "")) Then
          drTracking(0)("zeit_datum_hsb_vorhanden_ae") = Convert.ToDateTime(Replace(strHSBErstelltAE, "'", ""))
        Else
          drTracking(0)("zeit_datum_hsb_vorhanden_ae") = DBNull.Value
        End If

        If IsDate(Replace(strHSBErstelltPROD, "'", "")) Then
          drTracking(0)("zeit_datum_hsb_vorhanden_prod") = Convert.ToDateTime(Replace(strHSBErstelltPROD, "'", ""))
        Else
          drTracking(0)("zeit_datum_hsb_vorhanden_prod") = DBNull.Value
        End If

        If IsDate(Replace(strHSBErstelltQS, "'", "")) Then
          drTracking(0)("zeit_datum_hsb_vorhanden_qm") = Convert.ToDateTime(Replace(strHSBErstelltQS, "'", ""))
        Else
          drTracking(0)("zeit_datum_hsb_vorhanden_qm") = DBNull.Value
        End If

        If IsDate(Replace(strZKTAngefragt, "'", "")) Then
          drTracking(0)("zeit_datum_zukaufteile_angefragt") = Convert.ToDateTime(Replace(strZKTAngefragt, "'", ""))
        Else
          drTracking(0)("zeit_datum_zukaufteile_angefragt") = DBNull.Value
        End If

        If IsDate(Replace(strExtBearbAngefragt, "'", "")) Then
          drTracking(0)("zeit_datum_ext_bearbeitung_angefragt") = Convert.ToDateTime(Replace(strExtBearbAngefragt, "'", ""))
        Else
          drTracking(0)("zeit_datum_ext_bearbeitung_angefragt") = DBNull.Value
        End If

        If IsDate(Replace(strZKTAngebotErhalten, "'", "")) Then
          drTracking(0)("zeit_datum_zukaufteile_angebot_vorhanden") = Convert.ToDateTime(Replace(strZKTAngebotErhalten, "'", ""))
        Else
          drTracking(0)("zeit_datum_zukaufteile_angebot_vorhanden") = DBNull.Value
        End If

        If IsDate(Replace(strExtBearbAngebotErhalten, "'", "")) Then
          drTracking(0)("zeit_datum_ext_bearbeitung_angebot_vorhanden") = Convert.ToDateTime(Replace(strExtBearbAngebotErhalten, "'", ""))
        Else
          drTracking(0)("zeit_datum_ext_bearbeitung_angebot_vorhanden") = DBNull.Value
        End If

        If IsDate(Replace(strKalkErstellt, "'", "")) Then
          drTracking(0)("zeit_datum_kalk_erstellt") = Convert.ToDateTime(Replace(strKalkErstellt, "'", ""))
        Else
          drTracking(0)("zeit_datum_kalk_erstellt") = DBNull.Value
        End If

        Return "ok"
      End If
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function speichern_tracking" & vbCrLf &
                      "lngIDTracking: " & lngIDTracking)
      Return "error_speichern_tracking"
    End Try
  End Function

  Public Sub tracking_abgabe_termin()
    For i As Integer = 0 To DataSet_tracking.Tables("DataTable_tracking").Rows.Count - 1
      If Not IsDBNull(DataSet_tracking.Tables("DataTable_tracking").Rows(i)("status_bearbeitung")) Then
        If DataSet_tracking.Tables("DataTable_tracking").Rows(i)("status_bearbeitung") = "erledigt" Then
          DataSet_tracking.Tables("DataTable_tracking").Rows(i)("tracking_abgabe_termin") = "X"
        Else
          If Not IsDBNull(DataSet_tracking.Tables("DataTable_tracking").Rows(i)("zeit_datum_angefragt_am")) Then
            If Not IsDBNull(DataSet_tracking.Tables("DataTable_tracking").Rows(i)("zeit_datum_angebot_bis")) Then
              DataSet_tracking.Tables("DataTable_tracking").Rows(i)("tracking_abgabe_termin") =
                DateDiff(DateInterval.Day, DataSet_tracking.Tables("DataTable_tracking").Rows(i)("zeit_datum_angebot_bis"), Now())
            Else
              DataSet_tracking.Tables("DataTable_tracking").Rows(i)("tracking_abgabe_termin") = "?"
            End If
          End If
        End If
      Else
        DataSet_tracking.Tables("DataTable_tracking").Rows(i)("tracking_abgabe_termin") = "?"
      End If
    Next
  End Sub

  Private Sub BandedGridView_tracking_RowClick(sender As Object, e As RowClickEventArgs) Handles BandedGridView_tracking.RowClick
    strIDTracking = BandedGridView_tracking.GetRowCellValue(BandedGridView_tracking.FocusedRowHandle, colid_tracking)
    strIDAngebotReg = ""
  End Sub

  Private Sub GridView_tracking_BeforeLeaveRow(sender As Object, e As RowAllowEventArgs) Handles BandedGridView_tracking.BeforeLeaveRow
    If blGeaendert = True Then
      speichern()
    End If
    Datensatz_entsperren(strLastIDTracking)
  End Sub

  Private Sub GridView_tracking_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles BandedGridView_tracking.CellValueChanging
    If Not e.Column.Name = "colbemerkungen" Then Exit Sub
    blGeaendert = True
  End Sub

  Private Sub GridView_tracking_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles BandedGridView_tracking.CellValueChanged
    If Not e.Column.Name = "colbemerkungen" Then Exit Sub
    blGeaendert = True
  End Sub

  Private Sub GridView_tracking_CustomColumnSort(sender As Object, e As CustomColumnSortEventArgs) Handles BandedGridView_tracking.CustomColumnSort
    Dim ints1 As Integer
    Dim ints2 As Integer

    Select Case e.Column.FieldName
      Case "tracking_abgabe_termin", "prio", "prio_automatisch"
        If Not IsNumeric(e.Value1) Then
          ints1 = 0
        Else
          ints1 = Convert.ToInt16(e.Value1)
        End If

        If Not IsNumeric(e.Value2) Then
          ints2 = 0
        Else
          ints2 = Convert.ToInt16(e.Value2)
        End If

        e.Result = ints1.CompareTo(ints2)
        e.Handled = True
    End Select
  End Sub

  Private Sub GridView_tracking_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles BandedGridView_tracking.CustomDrawCell
    Dim View As GridView = TryCast(sender, GridView)
    Dim blVorhandenZKT As Boolean = False
    Dim blVorhandenExtBearb As Boolean = False

    If View.RowCount > 0 Then
      If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("flg"))) Then
        If LCase(View.GetRowCellValue(e.RowHandle, View.Columns("flg"))).contains("p") Then
          Return
        End If
      End If
    End If

    Try
      Select Case e.Column.FieldName
        Case "tracking_abgabe_termin"
          With e
            If Not IsDBNull(.CellValue) Then
              If IsNumeric(.CellValue) Then
                Select Case .CellValue
                  Case < 11
                    .Appearance.BackColor = Color.PaleGreen
                  Case 11 To 20
                    .Appearance.BackColor = Color.Gold
                  Case 21 To 30
                    .Appearance.BackColor = Color.DarkOrange
                  Case 31 To 40
                    .Appearance.BackColor = Color.LightPink
                  Case > 40
                    .Appearance.BackColor = Color.Salmon
                End Select
              End If
            End If
          End With
        Case "prio"
          With e
            If Not IsDBNull(.CellValue) Then
              If IsNumeric(.CellValue) Then
                Select Case .CellValue
                  Case 1
                    .Appearance.BackColor = Color.Salmon
                  Case 2
                    .Appearance.BackColor = Color.Gold
                  Case 3
                    .Appearance.BackColor = Color.PaleGreen
                    'Case 4
                    '  .Appearance.BackColor = Color.Gold
                    'Case 5
                    '  .Appearance.BackColor = Color.PaleGreen
                End Select
              End If
            End If
          End With
        Case "prio_automatisch"
          With e
            If Not IsDBNull(.CellValue) Then
              If IsNumeric(.CellValue) Then
                Select Case .CellValue
                  Case 1
                    .Appearance.BackColor = Color.Salmon
                  Case 2
                    .Appearance.BackColor = Color.Gold
                  Case 3
                    .Appearance.BackColor = Color.PaleGreen
                    'Case 4
                    '  .Appearance.BackColor = Color.Gold
                    'Case 5
                    '  .Appearance.BackColor = Color.PaleGreen
                End Select
              End If
            End If
          End With
        Case "zeit_datum_berechnung_vorhanden"
          With e
            Select Case BandedGridView_tracking.GetRowCellValue(e.RowHandle, "status_berechnung")
              Case "wartet"

              Case "in Arbeit"
                .Appearance.BackColor = Color.Gold
              Case "fertig"
                .Appearance.BackColor = Color.SkyBlue
            End Select
            'If Not IsDBNull(.CellValue) Then
            '  .Appearance.BackColor = Color.SkyBlue
            'End If
          End With
        Case "zeit_datum_hsb_vorhanden_ae"
          With e
            Select Case BandedGridView_tracking.GetRowCellValue(e.RowHandle, "status_hsb_ae")
              Case "wartet"

              Case "in Arbeit"
                .Appearance.BackColor = Color.Gold
              Case "fertig"
                .Appearance.BackColor = Color.SkyBlue
            End Select
            'If Not IsDBNull(.CellValue) Then
            '  .Appearance.BackColor = Color.SkyBlue
            'End If
          End With
        Case "zeit_datum_hsb_vorhanden_prod"
          With e
            Select Case BandedGridView_tracking.GetRowCellValue(e.RowHandle, "status_hsb_prod")
              Case "wartet"

              Case "in Arbeit"
                .Appearance.BackColor = Color.Gold
              Case "fertig"
                .Appearance.BackColor = Color.SkyBlue
            End Select
            'If Not IsDBNull(.CellValue) Then
            '  .Appearance.BackColor = Color.SkyBlue
            'End If
          End With
        Case "zeit_datum_hsb_vorhanden_qm"
          With e
            Select Case BandedGridView_tracking.GetRowCellValue(e.RowHandle, "status_hsb_qm")
              Case "wartet"

              Case "in Arbeit"
                .Appearance.BackColor = Color.Gold
              Case "fertig"
                .Appearance.BackColor = Color.SkyBlue
            End Select
            'If Not IsDBNull(.CellValue) Then
            '  .Appearance.BackColor = Color.SkyBlue
            'End If
          End With
        Case "zeit_datum_hsb_freigegeben"
          With e
            If Not IsDBNull(.CellValue) Then
              .Appearance.BackColor = Color.SkyBlue
            End If
          End With
        Case "zeit_datum_zukaufteile_angefragt",
             "zeit_datum_zukaufteile_angebot_vorhanden"
          With e
            blVorhandenZKT = View.GetRowCellValue(e.RowHandle, View.Columns("zukaufteile_erforderlich"))
            If blVorhandenZKT = False Then
              Using hb As New HatchBrush(HatchStyle.LightUpwardDiagonal, Color.LightGray, Color.SkyBlue)
                e.Graphics.FillRectangle(hb, e.Bounds)
              End Using
            Else
              If Not IsDBNull(.CellValue) Then
                .Appearance.BackColor = Color.SkyBlue
              End If
            End If
          End With
        Case "zeit_datum_ext_bearbeitung_angefragt",
             "zeit_datum_ext_bearbeitung_angebot_vorhanden"
          With e
            blVorhandenZKT = View.GetRowCellValue(e.RowHandle, View.Columns("ext_bearbeitung_erforderlich"))
            If blVorhandenZKT = False Then
              Using hb As New HatchBrush(HatchStyle.LightUpwardDiagonal, Color.LightGray, Color.SkyBlue)
                e.Graphics.FillRectangle(hb, e.Bounds)
              End Using
            Else
              If Not IsDBNull(.CellValue) Then
                .Appearance.BackColor = Color.SkyBlue
              End If
            End If
          End With
        Case "zeit_datum_kalk_erstellt"
          With e
            Select Case BandedGridView_tracking.GetRowCellValue(e.RowHandle, "status_kalk")
              Case "wartet"

              Case "in Arbeit"
                .Appearance.BackColor = Color.Gold
              Case "fertig"
                .Appearance.BackColor = Color.SkyBlue
            End Select
            'If Not IsDBNull(.CellValue) Then
            '  .Appearance.BackColor = Color.SkyBlue
            'End If
          End With
        Case "zeit_datum_angebot_abgegeben"
          With e
            If Not IsDBNull(.CellValue) Then
              .Appearance.BackColor = Color.SkyBlue
            End If
          End With
        Case "status_bearbeitung"
          With e
            If Not IsDBNull(.CellValue) Then
              Select Case .CellValue
                Case "offen"
                  .Appearance.BackColor = Color.Gold
                Case "erledigt"
                  .Appearance.BackColor = Color.SkyBlue
                Case "erledigt / abgelehnt"
                  .Appearance.BackColor = Color.LightPink
                Case "abgelehnt"
                  .Appearance.BackColor = Color.Salmon
              End Select
            End If
          End With
      End Select
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub GridView_tracking_CustomDrawCell")
    End Try
  End Sub

  Private Sub BandedGridView_tracking_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles BandedGridView_tracking.FocusedRowChanged
    TrackingFocusedRowChanged()
  End Sub

  Private Sub BandedGridView_tracking_ColumnFilterChanged(sender As Object, e As EventArgs) Handles BandedGridView_tracking.ColumnFilterChanged
    fill_znr_suchen()
    TrackingFocusedRowChanged()
  End Sub

  Private Sub TrackingFocusedRowChanged()
    DataTableAngebotRegBindingSource.Filter = "id_tracking = -1"

    strIDTracking = BandedGridView_tracking.GetRowCellValue(BandedGridView_tracking.FocusedRowHandle, colid_tracking)
    lngIDTracking = Convert.ToInt64(strIDTracking)

    If Not String.IsNullOrEmpty(strIDTracking) Then
      GridControl_AngebotReg.DataSource = DataTableAngebotRegBindingSource
      DataTableAngebotRegBindingSource.Filter = "id_tracking = " & lngIDTracking & ""
      BarStaticItem_anzahl_ds.Caption = DataTableAngebotRegBindingSource.Count
    End If

    If String.IsNullOrEmpty(strIDTracking) Then Exit Sub

    Select Case pruefen_satzsperre(strIDTracking, "t_angebot_tracking")
      Case "frei"
        hide_satzsperre()
        Datensatz_sperren("t_angebot_tracking", strIDTracking)
        BandedGridView_tracking.Appearance.FocusedRow.BackColor = Color.PaleGreen
        If Not pruefen_satzsperre_ar(strIDTracking).Contains("frei") Then
          GridControl_AngebotReg.Enabled = False
          BandedGridView_tracking.Appearance.FocusedRow.BackColor = Color.Salmon
          show_satzsperre(pruefen_satzsperre_ar(strIDTracking))
          Timer_user_action.Enabled = False
          BarStaticItem_timer_user_action.Caption = ""
        Else
          GridControl_AngebotReg.Enabled = True
          Datensatz_sperren("t_angebot_reg", strIDTracking)
          Timer_user_action.Enabled = True
        End If
      Case Else
        BandedGridView_tracking.SetRowCellValue(BandedGridView_tracking.FocusedRowHandle, col_satzsperre_ar, "gesperrt")
        BandedGridView_tracking.Appearance.FocusedRow.BackColor = Color.Salmon
        show_satzsperre(pruefen_satzsperre(strIDTracking, "t_angebot_tracking"))
        GridControl_AngebotReg.Enabled = False
    End Select
  End Sub

#End Region

#Region "angebot_reg"

  Sub OnShownEditorGriedView_AngebotReg(ByVal sender As Object, ByVal e As EventArgs) Handles GridView_AngebotReg.ShownEditor
    AddHandler CType(sender, ColumnView).ActiveEditor.EditValueChanged, AddressOf OnEditValueChangedGridView_AngebotReg
  End Sub

  Sub OnEditValueChangedGridView_AngebotReg(ByVal sender As Object, ByVal e As EventArgs)
    GridView_AngebotReg.PostEditor()
  End Sub

  Private Sub Edit_Popup(ByVal sender As Object, ByVal e As EventArgs)
    Dim control As IPopupControl = TryCast(sender, IPopupControl)
    RemoveHandler control.PopupWindow.KeyPress, AddressOf Edit_KeyPress
    AddHandler control.PopupWindow.KeyPress, AddressOf Edit_KeyPress

    RemoveHandler control.PopupWindow.MouseMove, AddressOf Edit_MouseMove
    AddHandler control.PopupWindow.MouseMove, AddressOf Edit_MouseMove
  End Sub

  Private Sub Edit_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
    int_counter_user_action = 0
  End Sub

  Private Sub Edit_MouseMove(ByVal sender As Object, e As MouseEventArgs)
    int_counter_user_action = 0
  End Sub

  Private Sub GridView_AngebotReg_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView_AngebotReg.RowClick
    'intRowHandle_AR = e.RowHandle
  End Sub

  Private Sub GridView_AngebotReg_ShowingEditor(sender As Object, e As CancelEventArgs) Handles GridView_AngebotReg.ShowingEditor
    Dim view As GridView = sender
    If (view.GetRowCellValue(view.FocusedRowHandle, colstatus_angebot_ar).Contains("angeboten")) Then
      e.Cancel = True
    End If
    If GridView_AngebotReg.FocusedColumn.Tag = "hsb" Then
      e.Cancel = True
    End If
  End Sub

  Private Sub GridView_AngebotReg_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView_AngebotReg.RowCellStyle
    Dim view As GridView = TryCast(sender, GridView)
    Dim strStatus As String = GridView_AngebotReg.GetRowCellValue(e.RowHandle, colstatus_angebot_ar)
    Dim col As New Color

    Select Case strStatus
      Case "angeboten"
        col = Color.Gray
      Case Else
        col = Color.PaleGreen
    End Select

    If view.FocusedRowHandle = e.RowHandle AndAlso Not view.FocusedColumn.Equals(e.Column) Then
      e.Appearance.BackColor = col
    End If
  End Sub

  Private Sub GridView_AngebotReg_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView_AngebotReg.RowCellClick
    intRowHandle_AR = e.RowHandle
    If e.Clicks = 2 Then
      If GridView_AngebotReg.FocusedColumn.Tag = "hsb" Then
        If GridView_AngebotReg.GetRowCellValue(e.RowHandle, colstatus_angebot_ar) = "angeboten" Then
          blReadOnlyHSB = True
        Else
          blReadOnlyHSB = False
        End If
        strIDAngebotReg = GridView_AngebotReg.GetRowCellValue(e.RowHandle, colid_ar)
        'Debug.Print("strIDAngebotReg: " & strIDAngebotReg)
        Form_hsb.Show()
      End If
    End If
  End Sub

  Private Function speichern_teile() As String
    Dim strSQL As String = ""
    Dim strSQLUID As String = ""
    Dim strAntwort As String = "ok"

    Dim strAngebotBis As String = "NULL"

    Dim strMitZukaufteilen As String = "NULL"
    Dim strMitExtBearbeitung As String = "NULL"

    Dim strBerechnungErstellt As String = "NULL"
    Dim strHSBErstelltAE As String = "NULL"
    Dim strHSBErstelltPROD As String = "NULL"
    Dim strHSBErstelltQS As String = "NULL"
    Dim strHSBFreigegeben As String = "NULL"

    Dim strZukaufteileAngefragt As String = "NULL"
    Dim strExtBearbeitungAngefragt As String = "NULL"
    Dim strZukaufteileAngebotErhalten As String = "NULL"
    Dim strExtBearbeitungAngebotErhalten As String = "NULL"
    Dim strKalkErstellt As String = "NULL"

    Dim strHSB_AE As String = "NULL"
    Dim strHSB_PROD As String = "NULL"
    Dim strHSB_QM As String = "NULL"
    Dim strHSB_KALK As String = "NULL"

    Dim lngIDAr As Long = Nothing

    If GridView_AngebotReg.DataRowCount < 1 Then Return "no_data_rows"

    Try
      For i As Integer = 0 To GridView_AngebotReg.DataRowCount - 1
        lngIDAr = GridView_AngebotReg.GetRowCellValue(i, "id")

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_angebot_bis")) Then
          strAngebotBis = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_angebot_bis"))
        Else
          strAngebotBis = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "mit_zukaufteilen")) Then
          If GridView_AngebotReg.GetRowCellValue(i, "mit_zukaufteilen") = True Then
            strMitZukaufteilen = 1
          Else
            strMitZukaufteilen = 0
          End If
        Else
          strMitZukaufteilen = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "mit_ext_ag")) Then
          If GridView_AngebotReg.GetRowCellValue(i, "mit_ext_ag") = True Then
            strMitExtBearbeitung = 1
          Else
            strMitExtBearbeitung = 0
          End If
        Else
          strMitExtBearbeitung = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_berechnung_erstellt")) Then
          strBerechnungErstellt = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_berechnung_erstellt"))
        Else
          strBerechnungErstellt = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_erstellt_ae")) Then
          strHSBErstelltAE = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_erstellt_ae"))
        Else
          strHSBErstelltAE = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_erstellt_prod")) Then
          strHSBErstelltPROD = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_erstellt_prod"))
        Else
          strHSBErstelltPROD = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_erstellt_qm")) Then
          strHSBErstelltQS = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_erstellt_qm"))
        Else
          strHSBErstelltQS = "NULL"
        End If

        If Not IsDBNull((GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_freigegeben"))) Then
          strHSBFreigegeben = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_hsb_freigegeben"))
        Else
          strHSBFreigegeben = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_zukaufteile_angefragt")) Then
          strZukaufteileAngefragt = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_zukaufteile_angefragt"))
        Else
          strZukaufteileAngefragt = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_ext_bearbeitung_angefragt")) Then
          strExtBearbeitungAngefragt = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_ext_bearbeitung_angefragt"))
        Else
          strExtBearbeitungAngefragt = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_zukaufteile_angebot_erhalten")) Then
          strZukaufteileAngebotErhalten = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_zukaufteile_angebot_erhalten"))
        Else
          strZukaufteileAngebotErhalten = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_ext_bearbeitung_angebot_erhalten")) Then
          strExtBearbeitungAngebotErhalten = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_ext_bearbeitung_angebot_erhalten"))
        Else
          strExtBearbeitungAngebotErhalten = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_kalkulation_erstellt")) Then
          strKalkErstellt = formatiere_datum_fuer_db(GridView_AngebotReg.GetRowCellValue(i, "zeit_datum_kalkulation_erstellt"))
        Else
          strKalkErstellt = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "machbarkeit_ae")) Then
          strHSB_AE = "'" & GridView_AngebotReg.GetRowCellValue(i, "machbarkeit_ae") & "'"
        Else
          strHSB_AE = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "machbarkeit_prod")) Then
          strHSB_PROD = "'" & GridView_AngebotReg.GetRowCellValue(i, "machbarkeit_prod") & "'"
        Else
          strHSB_PROD = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "machbarkeit_qm")) Then
          strHSB_QM = "'" & GridView_AngebotReg.GetRowCellValue(i, "machbarkeit_qm") & "'"
        Else
          strHSB_QM = "NULL"
        End If

        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "machbarkeit")) Then
          strHSB_KALK = "'" & GridView_AngebotReg.GetRowCellValue(i, "machbarkeit") & "'"
        Else
          strHSB_KALK = "NULL"
        End If

        strSQL = "UPDATE " &
                 "t_angebot_reg " &
                 "SET " &
                 "zeit_datum_angebot_bis = " & strAngebotBis & ", " &
                 "mit_zukaufteilen = " & strMitZukaufteilen & ", " &
                 "mit_ext_ag = " & strMitExtBearbeitung & ", " &
                 "zeit_datum_berechnung_erstellt = " & strBerechnungErstellt & ", " &
                 "zeit_datum_hsb_erstellt_ae = " & strHSBErstelltAE & ", " &
                 "zeit_datum_hsb_erstellt_prod = " & strHSBErstelltPROD & ", " &
                 "zeit_datum_hsb_erstellt_qm = " & strHSBErstelltQS & ", " &
                 "zeit_datum_hsb_freigegeben = " & strHSBFreigegeben & ", " &
                 "zeit_datum_zukaufteile_angefragt = " & strZukaufteileAngefragt & ", " &
                 "zeit_datum_ext_bearbeitung_angefragt = " & strExtBearbeitungAngefragt & ", " &
                 "zeit_datum_zukaufteile_angebot_erhalten = " & strZukaufteileAngebotErhalten & ", " &
                 "zeit_datum_ext_bearbeitung_angebot_erhalten = " & strExtBearbeitungAngebotErhalten & ", " &
                 "zeit_datum_kalkulation_erstellt = " & strKalkErstellt & ", " &
                 "machbarkeit_ae = " & strHSB_AE & ", " &
                 "machbarkeit_prod = " & strHSB_PROD & ", " &
                 "machbarkeit_qm = " & strHSB_QM & ", " &
                 "machbarkeit = " & strHSB_KALK & " " &
                 "WHERE " &
                 "id = " & lngIDAr & " " &
                 "AND " &
                 "id_tracking = " & lngIDTracking & "; "

        strSQLUID = strSQLUID & strSQL
      Next

      If Not String.IsNullOrEmpty(strSQLUID) Then
        strAntwort = update_insert_delete(strSQLUID, False,, "function speichern_teile")
      Else
        strAntwort = "nothing_to_do"
      End If

      If strAntwort.Contains("error") Then
        strAntwort = "error_speichern_teile"
      Else
        strAntwort = "ok"
      End If

    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function speichern_teile" & vbCrLf &
                      "lngIDtracking: " & lngIDTracking)
      strAntwort = "error_speichern_teile"
    End Try

    Return strAntwort
  End Function

  Private Sub hide_satzsperre()
    Select Case strSprache
      Case "de-DE"
        Text = "Angebots-Tacking " & " " & Application.ProductVersion.ToString
      Case "en-GB"
        Text = "offer tacking " & " " & Application.ProductVersion.ToString
      Case Else
        Text = "offer tacking " & " " & Application.ProductVersion.ToString
    End Select
  End Sub

  Private Sub show_satzsperre(ByVal strTextSatzSperre As String)
    Select Case strSprache
      Case "de-DE"
        Text = "Angebots-Tacking " & " " & Application.ProductVersion.ToString & " - " & strTextSatzSperre
      Case "en-GB"
        Text = "offer tacking " & " " & Application.ProductVersion.ToString & " - " & strTextSatzSperre
      Case Else
        Text = "offer tacking " & " " & Application.ProductVersion.ToString & " - " & strTextSatzSperre
    End Select
  End Sub

  Private Sub GridView_AngebotReg_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView_AngebotReg.CustomDrawCell
    Try
      Select Case e.Column.FieldName
        Case "status_angebot"
          With e
            If Not IsDBNull(.CellValue) Then
              Select Case .CellValue
                Case "offen"
                  .Appearance.BackColor = Color.Gold
                Case "abgelehnt"
                  .Appearance.BackColor = Color.Salmon
                Case "angeboten"
                  .Appearance.BackColor = Color.PaleGreen
                Case Else
                  .Appearance.BackColor = Color.Wheat
              End Select
            End If
          End With
        Case "machbarkeit_ae", "machbarkeit_prod", "machbarkeit_qm", "machbarkeit"
          With e
            If Not IsDBNull(.CellValue) Then
              Select Case .CellValue
                Case "go"
                  .Appearance.BackColor = Color.PaleGreen
                Case "go but"
                  .Appearance.BackColor = Color.Gold
                Case "no go"
                  .Appearance.BackColor = Color.Salmon
                Case Else
                  .Appearance.BackColor = Color.Wheat
              End Select
            End If
          End With
      End Select

    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub GridView_AngebotReg_CustomDrawCell")
    End Try
  End Sub

  Private Sub GridView_AngebotReg_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView_AngebotReg.CellValueChanging
    blGeaendert = True
  End Sub

  Private Sub GridView_AngebotReg_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView_AngebotReg.CellValueChanged
    Select Case e.Column.FieldName
      Case "machbarkeit_ae", "machbarkeit_prod", "machbarkeit_qm"
        set_hsb_kalk(e.RowHandle)
    End Select
    speichern()
  End Sub

  Private Sub set_hsb_kalk(ByVal intRowHandle As Integer)
    If String.IsNullOrEmpty(intRowHandle) Then Exit Sub

    Dim lstHSB As New List(Of String)
    Dim strHSB_KALK As String = ""

    If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(intRowHandle, colmachbarkeit_ae)) Then
      lstHSB.Add(GridView_AngebotReg.GetRowCellValue(intRowHandle, colmachbarkeit_ae))
    End If

    If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(intRowHandle, colmachbarkeit_prod)) Then
      lstHSB.Add(GridView_AngebotReg.GetRowCellValue(intRowHandle, colmachbarkeit_prod))
    End If

    If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(intRowHandle, colmachbarkeit_qm)) Then
      lstHSB.Add(GridView_AngebotReg.GetRowCellValue(intRowHandle, colmachbarkeit_qm))
    End If

    If lstHSB.Count = 3 Then
      If lstHSB(0) = lstHSB(1) And lstHSB(1) = lstHSB(2) Then
        strHSB_KALK = lstHSB(0)
      Else
        If lstHSB.Contains("no go") Then
          strHSB_KALK = "no go"
        ElseIf lstHSB.Contains("go but") Then
          strHSB_KALK = "go but"
        End If
      End If
    End If

    GridView_AngebotReg.SetRowCellValue(intRowHandle, colmachbarkeit_kalk, strHSB_KALK)

  End Sub

#End Region

#End Region

#Region "buttons"
  Private Sub btn_filter_aufheben_Click(sender As Object, e As EventArgs) Handles btn_filter_aufheben.Click
    GridControl_AngebotReg.DataSource = Nothing
    DataTabletrackingBindingSource.Filter = ""
    DataTableAngebotRegBindingSource.Filter = ""
  End Sub

  Private Sub btn_daten_aktualisieren_Click(sender As Object, e As EventArgs) Handles btn_daten_aktualisieren.Click
    speichern()
    Thread.Sleep(100)
    aktualisieren_daten()
  End Sub

  Private Sub btn_schliessen_Click(sender As Object, e As EventArgs) Handles btn_schliessen.Click
    schliessen()
  End Sub

  Private Sub btn_test_Click(sender As Object, e As EventArgs) Handles btn_test.Click
    WriteToErrorLog("dies", "ist", "ein Test")
  End Sub

  Private Sub btn_excel_export_Click(sender As Object, e As EventArgs) Handles btn_excel_export.Click
    select_excel_export()
  End Sub

#End Region

#Region "functions"

  Private Function get_faktor_produktgruppe(ByVal strMerkmal As String, ByVal strAlias As String) As Double
    Dim drFaktor() As DataRow = DataSet_tracking.Tables("DataTable_SetUp").Select("merkmal = '" & strMerkmal & "' AND
                                                               alias = '" & strAlias & "'")

    If drFaktor.Count > 0 Then
      If IsNumeric(drFaktor(0)(2)) Then
        Return Convert.ToDouble(drFaktor(0)(2))
      Else
        Return 0
      End If
    Else
      Return 0
    End If
  End Function

  Private Function get_punkte_jahresbedarf(ByVal intJahresBedarf As Long) As Double
    Dim dtPunkteJB As New DataTable
    Dim drPunkteJB() As DataRow = DataSet_tracking.Tables("DataTable_SetUp").Select("merkmal = 'werteliste_prio_tracking_punkte_jahresbedarf'", "wert")
    Dim drResult() As DataRow = Nothing

    'Zwischentabelle anlegen, für Ermittlung der Punkte/Jahresbedarf
    With dtPunkteJB
      .Columns.Add("wert", GetType(Long))
      .Columns.Add("min", GetType(Long))
      .Columns.Add("max", GetType(Long))
    End With

    'Zwischentabelle füllen
    If drPunkteJB.Count > 0 Then
      For i As Integer = 0 To drPunkteJB.Count - 1
        dtPunkteJB.Rows.Add(drPunkteJB(i)(2), drPunkteJB(i)(3), Convert.ToInt64(drPunkteJB(i)(4)))
      Next

      drResult = dtPunkteJB.Select("min <= " & intJahresBedarf & " AND  " & intJahresBedarf & " <= max")

      If drResult.Count > 0 Then
        Return drResult(0)(0)
      Else
        Return 0
      End If
    Else
      Return 0
    End If
  End Function

  Private Function get_punkte_abgabe_termin(ByVal datAbgabeTermin As Date) As Double
    Dim lngDiff As Long = DateDiff(DateInterval.Day, datAbgabeTermin, Now)

    Dim dtPunkteAT As New DataTable
    Dim drPunkteAT() As DataRow = DataSet_tracking.Tables("DataTable_SetUp").Select("merkmal = 'werteliste_prio_tracking_punkte_abgabe_termin'", "wert")
    Dim drResult() As DataRow = Nothing

    'Zwischentabelle anlegen, für Ermittlung der Punkte/AbgabeTermin
    With dtPunkteAT
      .Columns.Add("wert", GetType(Long))
      .Columns.Add("min", GetType(Long))
      .Columns.Add("max", GetType(Long))
    End With

    'Zwischentabelle füllen
    If drPunkteAT.Count > 0 Then
      For i As Integer = 0 To drPunkteAT.Count - 1
        dtPunkteAT.Rows.Add(drPunkteAT(i)(2), drPunkteAT(i)(3), Convert.ToInt64(drPunkteAT(i)(4)))
      Next

      drResult = dtPunkteAT.Select("min <= " & lngDiff & " AND  " & lngDiff & " <= max")

      Return drResult(0)(0)
    Else
      Return 0
    End If

  End Function

  Private Function get_punkte_gesamt(ByVal dblFaktorProdukt As Double,
                                    ByVal dblPunkteJahresbedarf As Double,
                                    ByVal dblPunkteAbgabeTermin As Double) As Double

    Return dblPunkteJahresbedarf * dblFaktorProdukt + dblPunkteAbgabeTermin

  End Function

  Public Function get_prio_punkte_tracking(ByVal lngIDTracking As Long) As String
    'ermittelt die Prio auf Basis von Produktgruppe und Jahresbedarf
    Dim dblHoechstePunkte As Double = 0
    Dim dblPrioBerechnet As Double = 0

    Dim drPrio() As DataRow = DataSet_tracking.Tables("DataTable_AngebotReg").Select("id_tracking = " & lngIDTracking & "")
    Dim dtPrio As New DataTable

    Try
      If drPrio.Count > 0 Then
        'DataTable definieren
        With dtPrio
          .Columns.Add("produktgruppe", GetType(String))
          .Columns.Add("abgabe_termin", GetType(Date))
          .Columns.Add("jahresbedarf", GetType(Long))
          .Columns.Add("faktor_pg", GetType(Double))
          .Columns.Add("punkte_jb", GetType(Double))
          .Columns.Add("punkte_abgabe_termin", GetType(Double))
          .Columns.Add("punkte_gesamt", GetType(Double))
        End With

        'DataTable mit der Produktgruppe aus Angebot füllen und gleichzeitig mit Faktoren und Punkten aktualisieren
        For i As Integer = 0 To drPrio.Count - 1
          Try
            If Not IsDBNull(drPrio(i)("zeit_datum_angebot_bis")) Then
              dtPrio.Rows.Add(drPrio(i)("federtyp"),
                            drPrio(i)("zeit_datum_angebot_bis"),
                            drPrio(i)("jahresbedarf"),
                            get_faktor_produktgruppe("werteliste_prio_tracking_faktor_prod_grup", drPrio(i)("federtyp")),
                            get_punkte_jahresbedarf(drPrio(i)("jahresbedarf")),
                            get_punkte_abgabe_termin(drPrio(i)("zeit_datum_angebot_bis")),
                            get_punkte_gesamt(get_faktor_produktgruppe("werteliste_prio_tracking_faktor_prod_grup", drPrio(i)("federtyp")),
                                              get_punkte_jahresbedarf(drPrio(i)("jahresbedarf")),
                                              get_punkte_abgabe_termin(drPrio(i)("zeit_datum_angebot_bis"))))
            End If
          Catch ex As Exception
            WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub get_prio_punkte_tracking, Schleife dtPrio.Rows.Add" & vbCrLf &
                            "zeit_datum_angebot_bis: " & drPrio(i)("zeit_datum_angebot_bis") & vbCrLf &
                            "federtyp: " & drPrio(i)("federtyp") & vbCrLf &
                            "jahresbedarf: " & drPrio(i)("jahresbedarf"))
          End Try

        Next

        'höchste Punktzahl aus DataTable ermitteln
        dblHoechstePunkte = dtPrio.Compute("MAX(punkte_gesamt)", "")

        Select Case dblHoechstePunkte
          Case >= 100
            dblPrioBerechnet = 1
          Case 80 To 99
            dblPrioBerechnet = 2
          Case Else
            dblPrioBerechnet = 3
        End Select
      End If
    Catch ex As Exception
      dblPrioBerechnet = 0
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in function get_prio_punkte_tracking" & vbCrLf &
                      "lngIDTracking: " & lngIDTracking)
    End Try

    Return dblPrioBerechnet
  End Function

  Private Function max_datum_aus_devgrid(ByVal str_fieldname As String) As String
    'die Funktion soll nur einen Wert <> NULL zurückgeben, wenn:
    '- mindestens ein Angebot noch den Status "offen" hat
    '- bei allen Angeboten ein Wert für das entsprechende Datum vorhanden ist

    Dim strMaxDat As String = "NULL"
    Dim strForNull As String = ""

    Dim datMaxDatum As Date = Date.MinValue
    Dim datMinDatum As Date = Nothing
    Dim datSpalte As Date = Nothing

    Dim lstValues As New List(Of String)

    'prüfen, ob alle DS für Datum enthalten -> nicht bei Terminen für externe Bearbeitung und Zukaufteile
    'bei Zukaufteilen / externer Bearbeitung wird statt "NULL" "" eingefügt
    Select Case str_fieldname
      Case "zeit_datum_zukaufteile_angefragt",
           "zeit_datum_ext_bearbeitung_angefragt",
           "zeit_datum_zukaufteile_angebot_erhalten",
           "zeit_datum_ext_bearbeitung_angebot_erhalten"
        strForNull = ""
      Case Else
        strForNull = "NULL"
    End Select

    For i As Integer = 0 To GridView_AngebotReg.DataRowCount - 1
      If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, str_fieldname)) Then
        lstValues.Add(GridView_AngebotReg.GetRowCellValue(i, str_fieldname))
      Else
        lstValues.Add(strForNull)
      End If
    Next

    If Not lstValues.Contains("NULL") Then
      lstValues.Clear()
      'prüfen, ob mindestens ein DS noch den Status "offen" hat
      For i As Integer = 0 To GridView_AngebotReg.DataRowCount - 1
        If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "status_angebot")) Then
          lstValues.Add(GridView_AngebotReg.GetRowCellValue(i, "status_angebot"))
        Else
          lstValues.Add("NULL")
        End If
      Next

      If lstValues.Contains("offen") Then
        For i As Integer = 0 To GridView_AngebotReg.DataRowCount - 1
          If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, str_fieldname)) Then
            datSpalte = GridView_AngebotReg.GetRowCellValue(i, str_fieldname)
            If datMaxDatum < datSpalte Then
              datMaxDatum = datSpalte
            ElseIf datMinDatum > datSpalte Then
              datMinDatum = datSpalte
            End If
          End If
        Next
      End If

      If Not datMaxDatum = Date.MinValue Then
        strMaxDat = formatiere_datum_fuer_db(datMaxDatum)
      End If
    End If

    'For i As Integer = 0 To GridView_AngebotReg.DataRowCount - 1
    '  If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, "status_angebot")) Then
    '    If GridView_AngebotReg.GetRowCellValue(i, "status_angebot") = "offen" Then
    '      If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, str_fieldname)) Then
    '        datSpalte = GridView_AngebotReg.GetRowCellValue(i, str_fieldname)
    '        If datMaxDatum < datSpalte Then
    '          datMaxDatum = datSpalte
    '        ElseIf datMinDatum > datSpalte Then
    '          datMinDatum = datSpalte
    '        End If
    '      End If
    '    End If
    '  End If
    'Next

    Return strMaxDat

  End Function

  Private Function status_bearbeitung(ByVal strFieldName As String) As String
    Dim strStatus As String = "wartet"

    Dim intRowCountTotal As Integer = GridView_AngebotReg.RowCount
    Dim intRowCountNotNull As Integer = 0

    If strFieldName.StartsWith("zeit_datum_") Then
      With GridView_AngebotReg
        For i As Integer = 0 To intRowCountTotal - 1
          If .GetRowCellValue(i, strFieldName) IsNot DBNull.Value Then intRowCountNotNull += 1
        Next
      End With
    Else
      With GridView_AngebotReg
        For i As Integer = 0 To intRowCountTotal - 1
          If Not IsDBNull(.GetRowCellValue(i, strFieldName)) Then
            If .GetRowCellValue(i, strFieldName) <> "-" Then intRowCountNotNull += 1
          End If
        Next
      End With
    End If

    If intRowCountNotNull > 0 AndAlso intRowCountNotNull < intRowCountTotal Then strStatus = "in Arbeit"
    If intRowCountNotNull = intRowCountTotal Then strStatus = "fertig"

    Return strStatus
  End Function

  Private Function mit_zkt_extbearb_aus_devgrid(ByVal str_fieldname As String) As String
    Dim strVal As String = "0"
    Dim blVal As Boolean = False

    For i As Integer = 0 To GridView_AngebotReg.DataRowCount - 1
      If Not IsDBNull(GridView_AngebotReg.GetRowCellValue(i, str_fieldname)) Then
        blVal = GridView_AngebotReg.GetRowCellValue(i, str_fieldname)
        If blVal = True Then
          strVal = "1"
          Exit For
        End If
      End If
    Next

    Return strVal
  End Function

#End Region

#Region "menue"
  Sub CloseMainMenuItem(item As BarSubItem)
    Dim subItemLink As BarSubItemLink = TryCast(item.Links(0), BarSubItemLink)
    subItemLink.CloseMenu()
  End Sub

  Private Sub BarEditItem_sprache_EditValueChanged(Sender As Object, e As EventArgs) Handles BarEditItem_sprache.EditValueChanged
    aendern_sprache(BarEditItem_sprache.EditValue)
    CloseMainMenuItem(BarSubItem_angebots_tracking)
  End Sub

  Private Sub BarButtonItem_schliessen_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem_schliessen.ItemClick
    schliessen()
  End Sub

  Private Sub BarButtonItem_dokumentation_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem_dokumentation.ItemClick
    anzeigen_doku()
  End Sub

  Private Sub BarButtonItem_info_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem_info.ItemClick
    Form_info.Show()
  End Sub

  Private Sub BarButtonItem_daten_aktualisieren_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem_daten_aktualisieren.ItemClick
    speichern()
    Thread.Sleep(100)
    aktualisieren_daten()
    PopupMenu_tracking.HidePopup()
  End Sub

  Private Sub BandedGridView_tracking_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles BandedGridView_tracking.PopupMenuShowing
    If GridHitTest.RowCell Then
      PopupMenu_tracking.ShowPopup(GridControl_tracking.PointToScreen(e.Point))
    End If
  End Sub

  Private Sub RepositoryItemSearchLookUpEdit_znr_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit_znr.EditValueChanged
    PopupMenu_tracking.HidePopup()

    Dim sle As SearchLookUpEdit = TryCast(sender, SearchLookUpEdit)
    Dim drV As DataRowView = sle.Properties.GetRowByKeyValue(sle.EditValue)

    If IsNothing(drV) Then Exit Sub

    Dim strANr As String = drV.Row.ItemArray(1)
    Dim intRh As Integer = Nothing
    Dim grv As GridView = BandedGridView_tracking

    For i As Integer = 0 To grv.RowCount - 1
      Dim rh As Integer = grv.GetRowHandle(i)
      If Not grv.IsGroupRow(i) Then
        If grv.GetRowCellValue(i, colangebot_nr).ToString = strANr Then
          BandedGridView_tracking.SelectRow(i)
          BandedGridView_tracking.FocusedRowHandle = i
          Exit For
        End If
      End If
    Next
  End Sub

#End Region

#Region "subs"
  Private Sub aktualisieren_daten()
    blGeaendert = False

    'Tabellen leeren
    For Each dt As DataTable In DataSet_tracking.Tables
      dt.Clear()
    Next

    'Daten neu laden
    fill_intenal_tables()
    tracking_abgabe_termin()
    prio_automatik()

    GridControl_tracking.ForceInitialize()
    BandedGridView_tracking.RefreshData()

    GridView_AngebotReg.RefreshData()

    'nach dem Refresh soll keine DS gewählt sein, im GridView_AngebotReg sollen keine Daten erscheinen
    DataTableAngebotRegBindingSource.Filter = "angebot_nr = '0'"

    tracking_abgabe_termin()

    'vor dem Speichern gewählte Zeilen in den Grids wählen
    'rowhandles zur zu focusierenden Zeilen über deren beim Speichern in Variablen abgelegten id's ermitteln
    intRowHandle_AT = BandedGridView_tracking.LocateByValue("id_tracking", intRowHandle_AT)
    'intRowHandle_AR = GridView_AngebotReg.LocateByValue("id", intRowHandle_AR)

    If intRowHandle_AT = 0 Then BandedGridView_tracking.FocusedRowHandle = 1
    If intRowHandle_AT <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
      BandedGridView_tracking.FocusedRowHandle = intRowHandle_AT
    Else
      'MessageBox.Show("Fehler - AT : " & intRowHandle_AT)
    End If

    'If intRowHandle_AR <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
    '  GridView_AngebotReg.FocusedRowHandle = intRowHandle_AR
    'Else
    '  MessageBox.Show("Fehler - AR : " & intRowHandle_AR)
    'End If
  End Sub

  Private Sub ApplyRessourcesAllControls(ByVal control As Control, ByVal resManager As ComponentResourceManager, ByVal cInfo As CultureInfo)
    For Each ctl As Control In control.Controls
      If ctl.Controls.Count > 0 Then
        ApplyRessourcesAllControls(ctl, resManager, cInfo)
      End If
      resManager.ApplyResources(ctl, ctl.Name, cInfo)
      ' folgendes nur für .NET 2.0
      If TypeOf ctl Is ToolStrip Then
        ApplyRessourcesAllToolStrips(DirectCast(ctl, ToolStrip), resManager, cInfo)
      End If
    Next
    For Each cmp As Component In Me.components.Components
      ' z.B. ContextMenu
      If TypeOf cmp Is ToolStrip Then
        ApplyRessourcesAllToolStrips(DirectCast(cmp, ToolStrip), resManager, cInfo)
      End If
    Next
  End Sub

  Private Sub ApplyRessourcesAllToolStrips(ByVal ts As ToolStrip, ByVal resManager As ComponentResourceManager, ByVal cInfo As CultureInfo)
    For Each tsi As ToolStripItem In ts.Items
      Dim tdi As ToolStripDropDownItem = TryCast(tsi, ToolStripDropDownItem)
      If tdi IsNot Nothing Then
        ApplyAllToolStripItems(tdi, resManager, cInfo)
      End If
      Dim tdc As ToolStripComboBox = TryCast(tsi, ToolStripComboBox)
      If tdc IsNot Nothing Then
        ApplyAllToolStripItems(tdc, resManager, cInfo)
      End If
      resManager.ApplyResources(tsi, tsi.Name, cInfo)
    Next
    resManager.ApplyResources(ts, ts.Name, cInfo)
  End Sub

  Private Sub ApplyAllToolStripItems(ByVal tsi As ToolStripItem, ByVal resManager As ComponentResourceManager, ByVal cInfo As CultureInfo)
    Dim tdi As ToolStripDropDownItem = TryCast(tsi, ToolStripDropDownItem)
    If tdi IsNot Nothing Then
      For Each tsi2 As ToolStripItem In tdi.DropDownItems
        Dim tdi2 As ToolStripDropDownItem = TryCast(tsi2, ToolStripDropDownItem)
        If tdi2 IsNot Nothing AndAlso tdi2.DropDownItems.Count > 0 Then
          ApplyAllToolStripItems(tdi2, resManager, cInfo)
        End If
        resManager.ApplyResources(tsi2, tsi2.Name, cInfo)
      Next
    End If
    Dim tdc As ToolStripComboBox = TryCast(tsi, ToolStripComboBox)
    If tdc IsNot Nothing Then
      For i As Integer = 0 To tdc.Items.Count - 1
        tdc.Items(i) = resManager.GetString(tdc.Name & ".Items" & (If((i = 0), "", i.ToString())), cInfo)
      Next
    End If
    resManager.ApplyResources(tsi, tsi.Name, cInfo)
  End Sub

  Private Sub berechtigung()
    RepositoryItemDateEdit1.MinValue = Now

    Form_hsb.DateEdit_ae.Properties.MinValue = Now
    Form_hsb.DateEdit_prod.Properties.MinValue = Now
    Form_hsb.DateEdit_qs.Properties.MinValue = Now
    Form_hsb.DateEdit_all.Properties.MinValue = Now

    Select Case LCase(strBerechtigung)
      Case "admin"
        RepositoryItemDateEdit1.MinValue = #2000/01/01#

        Form_hsb.DateEdit_ae.Properties.MinValue = #2000/01/01#
        Form_hsb.DateEdit_prod.Properties.MinValue = #2000/01/01#
        Form_hsb.DateEdit_qs.Properties.MinValue = #2000/01/01#
        Form_hsb.DateEdit_all.Properties.MinValue = #2000/01/01#

      Case "gl"
        BandedGridView_tracking.OptionsBehavior.ReadOnly = True
        GridView_AngebotReg.OptionsBehavior.ReadOnly = True
      Case "vm"
        With GridView_AngebotReg
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            col.OptionsColumn.AllowEdit = False
          Next
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            Select Case col.Name
              Case "colmit_zukaufteilen_ar",
                   "colzeit_datum_zukaufteile_angefragt_ar",
                   "colzeit_datum_ext_bearbeitung_angefragt_ar",
                   "colmit_ext_ag_ar",
                   "colzeit_datum_zukaufteile_angebot_erhalten_ar",
                   "colzeit_datum_ext_bearbeitung_angebot_erhalten_ar"
                col.OptionsColumn.AllowEdit = True
            End Select
          Next
        End With
      Case "ae"
        With GridView_AngebotReg
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            col.OptionsColumn.AllowEdit = False
          Next
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            Select Case col.Name
              Case "colzeit_datum_berechnung_erstellt_ar",
                   "colmit_zukaufteilen_ar",
                   "colmit_ext_ag_ar"
                col.OptionsColumn.AllowEdit = True
            End Select
          Next
        End With
      Case "prod"
        With GridView_AngebotReg
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            col.OptionsColumn.AllowEdit = False
          Next
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            Select Case col.Name
              Case "colmachbarkeit_prod",
                col.OptionsColumn.AllowEdit = True
            End Select
          Next
        End With
      Case "qm"
        With GridView_AngebotReg
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            col.OptionsColumn.AllowEdit = False
          Next
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            Select Case col.Name
              Case "colgrund_machbarkeit_qm"
                col.OptionsColumn.AllowEdit = True
            End Select
          Next
        End With
      Case "ek"
        With GridView_AngebotReg
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            col.OptionsColumn.AllowEdit = False
          Next
          For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
            Select Case col.Name
              Case "colzeit_datum_zukaufteile_angefragt_ar",
                   "colzeit_datum_ext_bearbeitung_angefragt_ar",
                   "colzeit_datum_zukaufteile_angebot_erhalten_ar",
                   "colzeit_datum_ext_bearbeitung_angebot_erhalten_ar"
                col.OptionsColumn.AllowEdit = True
            End Select
          Next
        End With
      Case "info"
        BandedGridView_tracking.OptionsBehavior.ReadOnly = True
        GridView_AngebotReg.OptionsBehavior.ReadOnly = True
    End Select
  End Sub

  Private Sub CheckLockKeys()
    ' Wenn die Feststelltaste geändert wird, den Wert des capslock-Statusleistenbereichs ändern.
    If My.Computer.Keyboard.CapsLock Then
      BarStaticItem_capslock.Caption = "CAP"
    Else
      BarStaticItem_capslock.Caption = ""
    End If

    ' Wenn die Num-Taste geändert wird, den Wert des numlock-Statusleistenbereichs ändern.
    If My.Computer.Keyboard.NumLock Then
      BarStaticItem_numlock.Caption = "NUM"
    Else
      BarStaticItem_numlock.Caption = ""
    End If
  End Sub

  Private Sub fill_cboxes_in_form1()
    fill_box_from_datatable(RepositoryItemComboBox_sprache,
                            "DataTable_Setup",
                            "merkmal = 'werteliste_sprache'",
                            "wert",
                            "wert",
                            ,
                            "fill_cboxes_in_form1")

    fill_znr_suchen()
  End Sub

  Private Sub finden_angebot_mit_znr(ByVal strZNr As String)
    Dim dtAngeboteZurZNrDistinct As DataTable
    Dim lstAngebotNr As New List(Of String)
    Dim strFilter As String = ""

    Dim view As DataView = New DataView(DataSet_tracking.Tables("DataTable_AngebotReg"))

        view.RowFilter = "znr = '" & strZNr & "'"
        Debug.Print("View RowFilter: " & view.RowFilter)

        If view.Count = 0 Then Exit Sub

    dtAngeboteZurZNrDistinct = view.ToTable(True, "id_tracking")

    For i As Integer = 0 To dtAngeboteZurZNrDistinct.Rows.Count - 1
            lstAngebotNr.Add("'" & dtAngeboteZurZNrDistinct.Rows(i)(0).ToString & "'")
            Debug.Print("Angebot Nr: " & dtAngeboteZurZNrDistinct.Rows(i)(0).ToString)
        Next

        If dtAngeboteZurZNrDistinct.Rows.Count = 1 Then
            strFilter = "id_tracking = " & lstAngebotNr(0) & ""
        Else
            For i As Integer = 0 To lstAngebotNr.Count - 1
                strFilter = strFilter & lstAngebotNr(i) & ","
            Next
            strFilter = strFilter.Substring(0, strFilter.Length - 1)
            strFilter = "id_tracking IN(" & strFilter & ")"
        End If
        Debug.Print("Filter: " & strFilter)

        DataTabletrackingBindingSource.Filter = strFilter
    strIDTracking = BandedGridView_tracking.GetRowCellValue(0, colid_tracking)
    DataTableAngebotRegBindingSource.Filter = "id_tracking = " & strIDTracking & ""

        Debug.Print("ID Tracking: " & strIDTracking)
    End Sub

  Private Sub schliessen()
    Select Case strSprache
      Case "de-DE"
        strTextMsg = "Anwendung beenden?"
        strTitelMsg = "Angebots-Tracking"
      Case "en-GB"
        strTextMsg = "close application?"
        strTitelMsg = "offer tracking"
      Case Else
        strTextMsg = "close application?"
        strTitelMsg = "offer tracking"
    End Select

    If MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
      Application.Exit()
    End If

  End Sub

  Public Sub show_vertriebsbereich(ByVal strOrg As String, ByVal strDiv As String, ByVal strPla As String)
    Dim strVMText As String = "/"
    Dim colFore As Color
    Dim colBack As Color

    Select Case LCase(strOrg)
      Case "bra"
        colFore = Color.Black
        colBack = Color.LightBlue
      Case "mfw"
        colFore = Color.Black
        colBack = Color.Thistle
    End Select

    With BarStaticItem_org
      .ItemAppearance.Normal.ForeColor = colFore
      .ItemAppearance.Normal.BackColor = colBack
    End With

    Select Case LCase(strDiv)
      Case "as"
        colFore = Color.Black
        colBack = Color.LightBlue
      Case "if"
        colFore = Color.Black
        colBack = Color.Orange
      Case "ftt"
        colFore = Color.Black
        colBack = Color.LightGray
    End Select

    With BarStaticItem_div
      .ItemAppearance.Normal.ForeColor = colFore
      .ItemAppearance.Normal.BackColor = colBack
    End With

    BarStaticItem_org.Caption = UCase(strOrg)
    BarStaticItem_div.Caption = UCase(strDiv)
    BarStaticItem_plant.Caption = UCase(strPla)

  End Sub

  Private Sub SwitchLanguage(ByVal culture As String)
    Dim cInfo As New CultureInfo(culture)
    Dim resManager As New ComponentResourceManager(Me.[GetType]())
    Dim old_location As Point = Me.Location

    resManager.ApplyResources(Me, "$this", cInfo)
    Location = old_location
    'nur für .NET 1.1 nötig
    'Controls.Clear();  // <<=== Sauberer, aber ggf. mehr Flackern
    ApplyRessourcesAllControls(Me, resManager, cInfo)

    Thread.CurrentThread.CurrentCulture = New CultureInfo(culture)
    Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)

    'InitializeComponent(); // <<=== wenn "Controls.Clear" auskommentiert, dann hier auch.
    'Form1_Load(Me, EventArgs.Empty)

    sprachanpassung()

  End Sub

  Public Sub Switch_vertriebsbereich(ByVal strVertriebsbereich As String)
    'beachte:
    'sofern auf ein anderes Werk umgeschaltet wird, müssen auch die Tabellen mit "werksspezifischen" Daten aktualisiert werden!
    'z.B. Kundendaten

    Select Case LCase(strVertriebsbereich)
      Case "bra-as"
        strOrganisation_company = "BRA"
        strOrganisation_division = "AS"
        strOrganisation_plant = "A"
      Case "bra-if"
        strOrganisation_company = "BRA"
        strOrganisation_division = "IF"
        strOrganisation_plant = "A"
      Case "mfw-if"
        strOrganisation_company = "MFW"
        strOrganisation_division = "IF"
        strOrganisation_plant = "L"
    End Select

    strFilterCDP = "org_company = '" & strOrganisation_company & "' AND 
                    org_division = '" & strOrganisation_division & "' AND 
                    org_plant = '" & strOrganisation_plant & "'"

    If DataSet_tracking.Tables("DataTable_tracking").Select(strFilterCDP).Count > 0 Then
      DataTabletrackingBindingSource.Filter = strFilterCDP
      DataTableAngebotRegBindingSource.Filter = "id_tracking = -1 AND " & strFilterCDP

      fill_box_from_datatable(RepositoryItemComboBox_znr_suchen,
                              "DataTable_AngebotReg",
                              strFilterCDP,
                              "znr",
                              "znr",
                              True,
                              "fill_cboxes_in_form1")
    Else
      strFilterCDP = "org_company = '?' AND 
                      org_division = '?' AND 
                      org_plant = '?'"

      DataTabletrackingBindingSource.Filter = strFilterCDP
      DataTableAngebotRegBindingSource.Filter = "id_tracking = -1 AND " & strFilterCDP

      Select Case strSprache
        Case "de-DE"
          strTextMsg = "Für " & strVertriebsbereich & " sind keine Daten vorhanden"
          strTitelMsg = "Vertriebsbereich wechseln"
        Case "en-GB"
          strTextMsg = "no data for sales divison " & strVertriebsbereich
          strTitelMsg = "change sales division"
        Case Else

      End Select

      MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If

  End Sub

  Private Sub Timer_satzsperre_Tick(sender As Object, e As EventArgs) Handles Timer_satzsperre.Tick
    Dim strSQLSatzSperre As String = ""
    Dim strTimeStamp As String

    strTimeStamp = DateTime.Now.ToString(strDatFmtSperre)

    If lstSperrTabelle.Count > 0 Then
      For i As Integer = 0 To lstSperrTabelle.Count - 1
        strSQLSatzSperre = strSQLSatzSperre &
                           "UPDATE " &
                           "" & lstSperrTabelle(i) & " " &
                           "SET " &
                           "timestamp = '" & strTimeStamp & "' " &
                           "WHERE " &
                           "id_tracking = '" & strIDSatzSperre & "'; "
      Next
    End If

    update_insert_delete(strSQLSatzSperre, False,, "Sub Timer_satzsperre_Tick")

  End Sub

  Private Sub Timer_user_action_Tick(sender As Object, e As EventArgs) Handles Timer_user_action.Tick
    int_counter_user_action += 1
    BarStaticItem_timer_user_action.Caption = 300 - int_counter_user_action

    If int_counter_user_action = 300 Then
      BarStaticItem_timer_user_action.Caption = "-"

      int_counter_user_action = 0
      Timer_user_action.Enabled = False

      Form_hsb.Close()

      BandedGridView_tracking.UnselectRow(intRowHandle_AT)
      GridControl_AngebotReg.DataSource = Nothing
      Datensatz_entsperren(strLastIDTracking)
    End If
  End Sub

#End Region

#Region "excel"
  Private Sub Args_showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
    For Each control In e.Form.Controls
      Dim button As SimpleButton = TryCast(control, SimpleButton)
      If button IsNot Nothing Then
        Select Case strSprache
          Case "de-DE"
            Select Case LCase(button.DialogResult.ToString)
              Case "ok"
                button.Width = 140
                button.Text = "-"
              Case "yes"
                button.Width = 140
                button.Text = "aktuelle Daten"
              Case "no"
                button.Width = 140
                button.Text = "Auswertungen"
              Case "cancel"
                button.Width = 140
                button.Text = "Abbruch"
            End Select
          Case Else
            Select Case LCase(button.DialogResult.ToString)
              Case "ok"
                button.Width = 140
                button.Text = "-"
              Case "yes"
                button.Width = 140
                button.Text = "current data"
              Case "no"
                button.Width = 140
                button.Text = "show score"
              Case "cancel"
                button.Width = 140
                button.Text = "cancel"
            End Select
        End Select
      End If
    Next
  End Sub

  Private Sub BackgroundWorker_excel_export_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker_excel_export.DoWork
    Excel_Export()

    BackgroundWorker_excel_export.ReportProgress(0, "exportiere Daten ...")

    If BackgroundWorker_excel_export.CancellationPending Then
      e.Cancel = True
      BackgroundWorker_excel_export.ReportProgress(100, "Excel-Export abgebrochen")
    End If
  End Sub

  Private Sub BackgroundWorker_excel_export_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_excel_export.RunWorkerCompleted

    If e.Error IsNot Nothing Then
      'if BackgroundWorker terminated due to error
      MessageBox.Show(e.Error.Message)

    ElseIf e.Cancelled Then
      'otherwise if it was cancelled
      MessageBox.Show("Excel-Export abgebrochen")

    Else
      'otherwise it completed normally
      'MessageBox.Show("Excel-Export abgeschlossen")
    End If

    CloseProgressPanel(_handle, painter)

  End Sub

  Private Function ConvertToLetter(int_Col As Integer) As String
    Dim str_letter As String = ""
    Dim int_Alpha As Integer
    Dim int_Remainder As Integer

    int_Alpha = Int(int_Col / 27)
    int_Remainder = int_Col - (int_Alpha * 26)

    If int_Alpha > 0 Then
      str_letter = Chr(int_Alpha + 64)
    End If

    If int_Remainder > 0 Then
      str_letter = str_letter & Chr(int_Remainder + 64)
    Else
      str_letter = "??"
    End If

    Return str_letter
  End Function

  Public Sub Excel_Export()
    Dim oExcel As Excel.Application = CreateObject("Excel.Application")
    Dim wBook As Excel.Workbook = Nothing
    Dim wSheet As Excel.Worksheet = Nothing
    Dim wSheetRohDaten As Excel.Worksheet = Nothing

    Dim dtRD As New DataTable       'DataTable für Rohdaten
    Dim rsADO As ADODB.Recordset

    Dim strFileName As String = "score.xlsx"
    Dim strFileNameWithPath As String = ""

    Dim intLetzteZelle As Integer = 0

    strFileNameWithPath = Application.StartupPath & "\" & strFileName

    Try
      Dim fileTemp As FileStream = File.OpenWrite(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & make_now_to_string() & "_" & strFileName)

      fileTemp.Close()
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler bei Excel_Export")

      Select Case strSprache
        Case "de-DE"
          strTextMsg = "Es ist bereits eine Excel-Datei geöffnet" & vbCrLf &
                       "Bitte diese Datei schliessen"
          strTitelMsg = "Excel-Export"
        Case "en-GB"
          strTextMsg = "Excel sheet already opened" & vbCrLf &
                       "Please close sheet"
          strTitelMsg = "Excel-Export"
      End Select

      MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Exit Sub
    End Try

    Try
      'Tabelle Namen geben
      dtRD.TableName = "dtRD"

      'Tabelle mit Spalten versehen
      With dtRD.Columns
        .Add("org_company", GetType(String))
        .Add("org_division", GetType(String))
        .Add("datum_angelegt_am", GetType(DateTime))
        .Add("angebot_nr", GetType(String))
        .Add("kunde", GetType(String))
        .Add("anzahl_teile", GetType(Int16))
        .Add("pb", GetType(String))
        .Add("name_kunden_manager", GetType(String))
        .Add("bearbeitet_von", GetType(String))
        .Add("zeit_datum_angefragt_am", GetType(DateTime))
        .Add("zeit_datum_angebot_bis", GetType(DateTime))
        .Add("tracking_abgabe_termin", GetType(String))
        .Add("prio", GetType(String))
        .Add("zukaufteile_erforderlich", GetType(Int16))
        .Add("ext_bearbeitung_erforderlich", GetType(Int16))
        .Add("zeit_datum_berechnung_vorhanden", GetType(DateTime))
        .Add("zeit_datum_hsb_vorhanden_ae", GetType(DateTime))
        .Add("zeit_datum_hsb_vorhanden_prod", GetType(DateTime))
        .Add("zeit_datum_hsb_vorhanden_qm", GetType(DateTime))
        .Add("zeit_datum_hsb_freigegeben", GetType(DateTime))
        .Add("zeit_datum_zukaufteile_angefragt", GetType(DateTime))
        .Add("zeit_datum_ext_bearbeitung_angefragt", GetType(DateTime))
        .Add("zeit_datum_zukaufteile_angebot_vorhanden", GetType(DateTime))
        .Add("zeit_datum_ext_bearbeitung_angebot_vorhanden", GetType(DateTime))
        .Add("zeit_datum_kalk_erstellt", GetType(DateTime))
        .Add("status_bearbeitung", GetType(String))
        .Add("bemerkungen_tracking", GetType(String))
        .Add("bearb_zeit_kunde", GetType(Int16))
        .Add("ueberfaellig", GetType(Int16))
      End With

      'Tabelle füllen
      fill_table(dtRD)

      'Berechnung von Bearbeitungszeit, Kunde und überfällig
      For Each dr As DataRow In dtRD.Rows
        If Not dr("datum_angelegt_am").Equals(DBNull.Value) AndAlso Not dr("zeit_datum_angebot_bis").Equals(DBNull.Value) Then
          dr("bearb_zeit_kunde") = WorkingDays(Convert.ToDateTime(dr("datum_angelegt_am")), Convert.ToDateTime(dr("zeit_datum_angebot_bis")))
          If Convert.ToInt16(dr("bearb_zeit_kunde")) < 0 Then dr("bearb_zeit_kunde") = 0
        End If
        If Not dr("zeit_datum_angebot_bis").Equals(DBNull.Value) Then
          dr("ueberfaellig") = WorkingDays(Convert.ToDateTime(dr("zeit_datum_angebot_bis")), Now())
        End If
      Next

      rsADO = ConvertToRecordset(dtRD)

      'Excel-Datei kopieren
      File.Copy(Application.StartupPath & "\" & strFileName,
                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & make_now_to_string() & "_" & strFileName,
                True)

      wBook = oExcel.Workbooks.Open(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & make_now_to_string() & "_" & strFileName)
      wSheetRohDaten = wBook.Sheets("row data")

      intLetzteZelle = DataSet_tracking.Tables("DataTable_tracking").Columns.Count

      With wSheetRohDaten
        'Zeilen mit Werten füllen
        .Range("A2").CopyFromRecordset(rsADO)
        'Autofilter aktivieren
        '.Range("A1", ConvertToLetter(intLetzteZelle) & rsADO.RecordCount.ToString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)
        'Spaltenbreiten automatisch einstellen
        .Columns.AutoFit()
        'Zellenhöe einheitlich
        '.Rows.RowHeight = 15
      End With

      oExcel.ActiveWorkbook.RefreshAll()

      oExcel.Visible = True
    Catch ex As Exception
      oExcel.Quit()
      oExcel.DisplayAlerts = False

      WriteToErrorLog(ex.Message, ex.StackTrace, "Form1 excel_export")

      Select Case strSprache
        Case "de-DE"
          strTextMsg = "Fehler:  " & ex.Message
          strTitelMsg = "Datenexport abgebrochen"
        Case "en-GB"
          strTextMsg = "error: " & ex.Message
          strTitelMsg = "data export canceled"
      End Select
      MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

  End Sub

  Private Sub select_excel_export()
    Dim options As New DevExpress.XtraPrinting.XlsxExportOptions

    Select Case XtraMessageBox.Show(args)
      Case vbYes
        options.ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile
        options.SheetName = "data"
        strFileWithPathExcelExport = Application.StartupPath & "\current_tracking_data.xlsx"

        GridControl_tracking.ExportToXlsx(strFileWithPathExcelExport, options)
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
        startInfo.FileName = "EXCEL.EXE"
        startInfo.Arguments = """" & strFileWithPathExcelExport & """"
        Process.Start(startInfo)
      Case vbNo
        show_overlay_form("Daten werden nach Excel exportiert...")
        BackgroundWorker_excel_export.RunWorkerAsync()

      Case vbCancel

    End Select
  End Sub

#End Region
End Class

