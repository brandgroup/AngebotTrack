Imports System.IO
Imports System.Threading

Public Class SplashScreen
  Dim strResultStartCheck As String

  Private Delegate Sub setListBoxText(ByVal strText As String, ByVal blAdd As Boolean)

  Private Sub setLboxText(ByVal strText As String, ByVal blAdd As Boolean)
    If blAdd = True Then
      If ProgressBar_ss.Value = ProgressBar_ss.Maximum Then ProgressBar_ss.Maximum += 1
      ProgressBar_ss.Value += 1
    End If
    LBoxSplashScreen.Items.Add(strText)
    LBoxSplashScreen.SelectedIndex = LBoxSplashScreen.Items.Count - 1
    LBoxSplashScreen.SelectedIndex = -1
  End Sub

  Public Sub add_listbox_text(ByVal strText As String, ByVal blAdd As Boolean)
    If LBoxSplashScreen.InvokeRequired Then
      Invoke(New setListBoxText(AddressOf setLboxText), New Object() {strText, blAdd})
      Application.DoEvents()
    Else
      LBoxSplashScreen.Items.Add(strText)
      Application.DoEvents()
    End If
  End Sub

  Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ProgressBar_ss.Visible = True
    BackgroundWorker_splashscreen.RunWorkerAsync()
  End Sub

  Private Sub BackgroundWorker_splashscreen_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_splashscreen.DoWork
    BackgroundWorker_splashscreen.ReportProgress(0, "Startcheck runing")

    strResultStartCheck = StartCheck()

    If BackgroundWorker_splashscreen.CancellationPending Then
      e.Cancel = True
      BackgroundWorker_splashscreen.ReportProgress(100, "Startcheck canceled")
    End If
  End Sub

  Private Sub BackgroundWorker_splashscreen_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_splashscreen.RunWorkerCompleted
    Application.DoEvents()

    If e.Error IsNot Nothing Then
      MessageBox.Show(e.Error.Message)
      Application.Exit()
    ElseIf e.Cancelled Then
      MessageBox.Show("Startcheck canceled")
      Application.Exit()
    Else
      With strResultStartCheck
        Select Case True
          Case .StartsWith("run_ud")
            run_ud(strResultStartCheck.Substring(InStr(strResultStartCheck, "|")))
            Application.Exit()
          Case .Contains("ok")
            fill_intenal_tables()
            Form1.tracking_abgabe_termin()
            Form1.prio_automatik()
            Application.DoEvents()
            My.Application.ChangeMainForm(Form1)
            Form1.Show()
          Case .Contains("no_user_ini")
            strTextMsg = "Sie haben keine Berechtigung zur Nutzung dieser Software" & vbCrLf &
                         "No permission to use this software"
            strTitelMsg = "Angebots-Tracking / deal registration"
          Case .Contains("no_install_directory")
            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Das Quellvezeichnis auf dem Server konnte nicht gefunden werden"
                strTitelMsg = "Prüfen auf neue Programmdateien fehlgeschlagen"
              Case "en-GB"
                strTextMsg = "Source directory on server not found"
                strTitelMsg = "check for new files canceled"
            End Select
            .Contains("no_db_connection")
            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Die gewählte Verbinung ist nicht erreichbar"
                strTitelMsg = "Datenbankverbindung"
              Case "en-GB"
                strTextMsg = "Selected connection is not present"
                strTitelMsg = "database connection"
            End Select
          Case .Contains("missing_db")
            WriteToErrorLog("IP Server: " & strIPServer & vbCrLf,
                            "Pfad OC: " & strPfadOrganisation_company & vbCrLf,
                            "beim Start: ")

            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Folgende Datenbankverbindungen sind nicht verfügbar :" & vbCrLf & vbCrLf &
                              strResultStartCheck.Substring(InStr(strResultStartCheck, "|") + 1) & vbCrLf & vbCrLf &
                             "Die Anwendung kann nicht genutzt werden"
                strTitelMsg = "Angebots-Tracking"
              Case "en-GB"
                strTextMsg = "Following database connections are not available :" & vbCrLf & vbCrLf &
                              strResultStartCheck.Substring(InStr(strResultStartCheck, "|") + 1) & vbCrLf & vbCrLf &
                             "Application can not be used"
                strTitelMsg = "deal registration"
            End Select
          Case .Contains("not_in_usergroup")
            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Unbekannte User-Gruppe" & vbCrLf &
                             "Die Anwendung kann nicht genutzt werden"
                strTitelMsg = "Angebots-Tracking"
              Case "en-GB"
                strTextMsg = "unknown usergroup" & vbCrLf &
                             "Application can not be used"
                strTitelMsg = "deal registration"
            End Select
          Case .Contains("unknown_sales_segment")
            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Es wurde ein nicht berücksichtigter Vertriebsbereich gewählt" & vbCrLf &
                             "Die Anwendung wird beendet"
                strTitelMsg = "Angebots-Tracking"
              Case Else
                strTextMsg = "unknown sales segment selected" & vbCrLf &
                             "application closes"
                strTitelMsg = "offer tracking"
            End Select
          Case .Contains("error")
            Select Case strSprache
              Case "de-DE"
                strTextMsg = "Die Anwendung kann nicht gestartet werden"
                strTitelMsg = "Angbeots-Registrierung"
              Case "en-GB"
                strTextMsg = "Application can not be started"
                strTitelMsg = "deal registration"
            End Select
        End Select
      End With

      If Not strResultStartCheck = "ok" Then
        WriteToErrorLog("Fehler bei RunWorkerCompleted", "", "Fehlermeldung: " & strResultStartCheck)
        MessageBox.Show(strTextMsg, strTitelMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Application.Exit()
      End If
    End If
  End Sub

  Public Function StartCheck() As String
    Dim strAktuelleVersion As String
    Dim lstMissing As New List(Of String)
    Dim strSQL As String = ""

    Dim tIniLaden As New Thread(AddressOf ini_laden)

    Dim lstAntwort As New List(Of String)
    Dim strAntwort As String = ""

    Try
      blUpdate = False

      '01 - Username
      suser = Environment.UserName
      add_listbox_text("- current user: " & suser, True)

      '02 - Organisation bestimmen, IP, Pfade dazu einstellen
      add_listbox_text("- run localisation", True)

      'es wird zunächst im Netz nach der User.ini gesucht, ist dort keine vorhanden bzw. arbeitet der User lokal, wird im Programmverzeichnis gesucht
      'ist keine user.ini vorhanden, hat der Benutzer keine Berechtigung zur Nutzung des Programms

      '03 - User-ini
      strUserIni = suser & ".ini"
      add_listbox_text("- determin user.ini: " & strUserIni, True)

      blberechtigt = True
      strIniPath = strPfadOrganisation_company & strPfadVerwaltung & strUserIni

      '04 - es wird zunächst im Netz nach der User.ini gesucht, ist dort keine vorhanden bzw. arbeitet der User lokal, wird im Programmverzeichnis gesucht
      'ist keine user.ini vorhanden, hat der Benutzer keine Berechtigung zur Nutzung des Programms
      If File.Exists(strIniPath) Then
        blFileServerPresent = True
        File.Copy(strPfadOrganisation_company & strPfadVerwaltung & "\" & strUserIni, strUserIni, True)
        add_listbox_text("- ini-file copied to app path", True)
        blberechtigt = True
      Else
        add_listbox_text("- ini file not found on server", True)
        strIniPath = Application.StartupPath & "\" & strUserIni
        add_listbox_text("- ini path changed to: " & strIniPath, True)
        If File.Exists(strIniPath) Then
          blberechtigt = True
        Else
          blberechtigt = False
        End If
      End If

      '06 - Berechtigung(Rechte) + Einstellungen aus user.ini lesen
      'ist keine user.ini vorhanden, hat der Benutzer keine Berechtigung zur Nutzung des Programms
      If blberechtigt = False Then
        add_listbox_text("- no user.ini " & suser, True)
        Return "no_user_ini"
      Else
        add_listbox_text("- user.ini found for user " & suser, True)
      End If

      add_listbox_text("- loading information from ini", True)

      '07 - ini_laden()
      tIniLaden.SetApartmentState(ApartmentState.STA)
      tIniLaden.Start()
      tIniLaden.Join()

      'Pfad für Error-Log einstellen, wenn die Anwendung mit connectiontype = local gestartet wurde, soll Errors lokal gespeichert werden
      If strConnectionType = "local" Then
        If Not Directory.Exists(Application.StartupPath & "\Errors\") Then
          Directory.CreateDirectory(Application.StartupPath & "\Errors\")
        End If
        strPfadError = Application.StartupPath & "\Errors\"
      Else
        If Not Directory.Exists(strErrorPath) Then
          Directory.CreateDirectory(strErrorPath)
        End If
        strPfadError = strErrorPath & "\"
      End If

      '08 - aktuelle Version
      strAktuelleVersion = Application.ProductName & " " & Application.ProductVersion.ToString
      add_listbox_text("- current app version: " & Application.ProductVersion, True)

      'auf Updates nur prüfen, wenn Verbindung zum Server besteht und nicht Einstellung LOCAL!
      If File.Exists(Application.StartupPath & "\" & "updateinfo.txt") Then File.Delete(Application.StartupPath & "\" & "updateinfo.txt")

      If LCase(strConnectionType) <> "local" Then
        lstAntwort = file_and_updatecheck(strPfadOrganisation_company & strNeuVersionFiles, Application.StartupPath)

        If lstAntwort.Count > 0 Then
          If lstAntwort.Contains("directory not found") Then
            add_listbox_text("- automatic update impossible, directory not found", True)
          Else
            WriteUpdateInfo(lstAntwort)
            Return "run_ud|" &
                    Chr(34) &
                    strPfadOrganisation_company & "%" &
                    strNeuVersionFiles & "%" &
                    strNeueVersionPath & "%" &
                    strPfadVerwaltung & "%" &
                    Application.StartupPath & "%" &
                    suser & "%" &
                    Application.ProductName &
                    Chr(34)
          End If
        End If
      Else
        add_listbox_text("- skipping check for newer and missing files", True)
        add_listbox_text("- skipping check for update", True)
      End If

      setConnection("MySQL-A")
      strServerConnected = "MySQL-A"

      'ist in der User-Ini "local" eingetragen, die Verbindung zum MySQL-Server entsprechend ändern
      If strConnectionType = "local" Then
        setConnection("MySQL-Local")
        strServerConnected = "MySQL-Local"
      ElseIf strConnectionType = "test" Then
        setConnection("MySQL-Test")
        strServerConnected = "MySQL-Test"
      End If

      'prüfen, ob die benötigten Datenbanken erreichbar sind
      If check_db_needed() <> "ok" Then
        Return "missing_db" & "|" & strMissingDB
      End If

      'prüfen, ob die Berechtigung aus der user.ini in der DB bei den usergroups existiert
      add_listbox_text("- checking permission for user " & suser, True)
      connectionstring = connectionstringKalk

      strSQL = "SELECT " &
               "wert " &
               "FROM " &
               "t_setup " &
               "WHERE " &
               "merkmal = 'werteliste_usergroups_angebot_reg'"

      ArrayUserGroup = fill_arraylist(strSQL, ";", "wert")

      'prüfen auf gültige Berechtigung(UserGroup) für diese Anwendung
      blberechtigt = False

      For i As Integer = 0 To ArrayUserGroup.Count - 1
        If strBerechtigung = ArrayUserGroup(i) Then
          blberechtigt = True
          Exit For
        End If
      Next

      If blberechtigt = False Then
        add_listbox_text("- no permission for user " & suser, True)
        Return "not_in_usergroup"
      Else
        add_listbox_text("- permission granted for user " & suser, True)
      End If

      Return "ok"
    Catch ex As Exception
      WriteToErrorLog(ex.Message, ex.StackTrace, "Fehler in sub StartCheck")
      Return "error"
    End Try

  End Function

End Class