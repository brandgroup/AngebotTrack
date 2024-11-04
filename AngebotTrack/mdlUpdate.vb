Imports System.IO
Imports System.Threading
Module mdlUpdate
  Dim blMissing As Boolean = False
  Dim blNewer As Boolean = False

  Dim strAppName As String

  Dim lstMissing As New List(Of String)
  Dim lstNewer As New List(Of String)

#Region "functions"

  Public Function check_for_update(ByVal strPath As String) As Boolean
    Dim diSource As DirectoryInfo = New DirectoryInfo(strPath)
    Dim intAktuelleVersion As Int16 = Convert.ToInt16(Replace(Application.ProductVersion, ".", ""))

    If get_latest_version(strPath) > intAktuelleVersion Then Return True

    Return False
  End Function

  Public Function file_and_updatecheck(strPathSource As String, strPathApp As String) As List(Of String)
    Dim strUDPara As String = ""
    Dim strMissing As String = ""
    Dim blRunUD As Boolean = False

    Dim lstAll As New List(Of String)

    Dim lstM As New List(Of String)
    Dim lstN As New List(Of String)

    'prüfen auf fehlende Dateien + fehlende SubDirs
    If Directory.Exists(strPathSource) Then
      lstM = get_missing_files_and_dirs(strPathSource, strPathApp)
      If lstM.Count > 0 Then
        lstAll.AddRange(lstM)
      End If
    Else
      lstAll.Add("directory not found: " & strPfadOrganisation_company & strNeuVersionFiles)
    End If

    'prüfen auf neuere Dateien
    strMissing = ""
    If Directory.Exists(strPathSource) Then
      lstN = get_newer_files(strPathSource, strPathApp)
      If lstN.Count > 0 Then
        lstAll.AddRange(lstN)
      End If
    Else
      lstAll.Add("directory not found: " & strPfadOrganisation_company & strNeuVersionFiles)
    End If

    'prüfen auf neuere Version der Anwendung
    If Directory.Exists(strPfadOrganisation_company & strNeueVersionPath) Then
      If check_for_update(strPfadOrganisation_company & strNeueVersionPath) = True Then
        lstAll.Add("update:" & get_latest_version(strPfadOrganisation_company & strNeueVersionPath).ToString("0.0.0.0"))
      End If
    Else
      lstAll.Add("directory not found: " & strPfadOrganisation_company & strNeueVersionPath)
    End If

    Return lstAll
  End Function

  Public Function get_latest_version(ByVal strPath As String) As Int16
    Dim intLatestVersion As Int16 = Nothing
    Dim diSource As DirectoryInfo = New DirectoryInfo(strPath)
    Dim intAktuelleVersion As Int16 = Convert.ToInt16(Replace(Application.ProductVersion, ".", ""))
    Dim lstVersion As New List(Of Int16)

    For Each SourceFile As FileInfo In diSource.GetFiles
      If SourceFile.Name.Substring(0, Application.ProductName.Length) = Application.ProductName Then
        lstVersion.Add(Convert.ToInt16(Replace(SourceFile.Name.Substring(Application.ProductName.Length), ".", "")))
      End If
    Next

    lstVersion.Sort()
    lstVersion.Reverse()

    intLatestVersion = lstVersion(0) 'lstVersion.Max

    Return intLatestVersion
  End Function

  Public Function get_missing_files_and_dirs(ByVal strPathSource As String, ByVal strPathApp As String) As List(Of String)
    'die zurückzugebende Liste enthält die Namen aller Files + Dirs, die in strPathSource vorhanden sind, aber in strPathApp fehlen
    'zur Unterscheidung erhalten die Namen der fehlenden Files im Stammverzeichninsden Prefix "F:",
    'im Unterverzeichnis den Prefix "SD:",
    'alle fehlenden Dirs den Prfix "D:"

    Dim diSource As DirectoryInfo = New DirectoryInfo(strPathSource)
    Dim diApp As DirectoryInfo = New DirectoryInfo(strPathApp)
    Dim nextTargetSubDir As DirectoryInfo = Nothing

#Region "root"
    For Each SourceFile As FileInfo In diSource.GetFiles
      If Not SourceFile.Name = strAppName & ".exe" Then
        If Not File.Exists(strPathApp & "\" & SourceFile.Name) Then
          lstMissing.Add("mF:" & SourceFile.FullName)
        End If
      End If
    Next
#End Region

#Region "subdir"
    For Each diSourceSubDir As DirectoryInfo In diSource.GetDirectories()
      If Directory.Exists(Path.Combine(strPathApp, diSourceSubDir.Name)) = True Then
        'fehlende Dateien in vorhandenem SubDir
        get_missing_files_and_dirs(diSourceSubDir.FullName, Path.Combine(strPathApp, diSourceSubDir.Name))
      Else
        'SubDir nicht vorhanden
        lstMissing.Add("mSD:" & diSourceSubDir.Name)
        For Each SourceFile As FileInfo In diSourceSubDir.GetFiles
          lstMissing.Add("mF:" & SourceFile.FullName)
        Next
      End If
    Next
#End Region

    Return lstMissing
  End Function

  Public Function get_newer_files(strPathSource As String, strPathApp As String, Optional strSD As String = "") As List(Of String)


    Dim diSource As DirectoryInfo = New DirectoryInfo(strPathSource)
    Dim diApp As DirectoryInfo = New DirectoryInfo(strPathApp)

    Dim dateSourceFile As New Date
    Dim dateTargetFile As New Date

    Dim fviSource As FileVersionInfo = Nothing
    Dim fviTarget As FileVersionInfo = Nothing
    Dim intCompareResult As Int64 = 0

    Dim strPreFix As String = ""

    If strSD = "" Then
      strPreFix = "nF:"
    Else
      strPreFix = "nSD:" & strSD & "%"
    End If

    Try
      For Each SourceFile As FileInfo In diSource.GetFiles
        fviSource = FileVersionInfo.GetVersionInfo(Path.Combine(strPathSource, SourceFile.Name))
        For Each TargetFile As FileInfo In diApp.GetFiles
          fviTarget = FileVersionInfo.GetVersionInfo(Path.Combine(strPathApp, TargetFile.Name))
          If TargetFile.Name = SourceFile.Name Then
            Select Case SourceFile.Extension
              Case ".dll"
                If fviSource.InternalName.StartsWith("DevExpress") Then
                  If IsNumeric(Replace(fviTarget.FileVersion, ".", "")) Then
                    If Convert.ToInt64(Replace(fviTarget.FileVersion, ".", "")) < Convert.ToInt64(Replace(fviSource.FileVersion, ".", "")) Then
                      Try
                        lstNewer.Add(strPreFix & SourceFile.FullName)
                      Catch ex As Exception

                      End Try
                    End If
                  End If
                Else
                  If fviTarget.ProductVersion <> fviSource.ProductVersion Then
                    Try
                      lstNewer.Add(strPreFix & SourceFile.FullName)
                    Catch ex As Exception

                    End Try
                  End If
                End If
              Case Else
                If Not SourceFile.Name = strAppName AndAlso Not SourceFile.Name = Application.ProductName Then
                  dateTargetFile = get_file_lwt(TargetFile)
                  dateSourceFile = get_file_lwt(SourceFile)
                  intCompareResult = DateTime.Compare(dateTargetFile, dateSourceFile)
                  If intCompareResult < 0 Then
                    Try
                      lstNewer.Add(strPreFix & SourceFile.FullName)
                    Catch ex As Exception

                    End Try
                  End If
                End If
            End Select
          End If
        Next
      Next

      For Each diSourceSubDir As DirectoryInfo In diSource.GetDirectories()
        If Directory.Exists(strPathApp & "\" & diSourceSubDir.Name) Then
          get_newer_files(diSourceSubDir.FullName, strPathApp & "\" & diSourceSubDir.Name, diSourceSubDir.Name)
        End If
      Next
    Catch ex As Exception
      WriteToErrorLog(ex.Message,
                      ex.StackTrace,
                      "error in function get_newer_files" & vbCrLf &
                      "strPathSource: " & strPathSource & vbCrLf &
                      "strPathApp: " & strPathApp & vbCrLf &
                      "strSD: " & strSD)
    End Try

    Return lstNewer
  End Function

#End Region

#Region "Subs"
  Public Sub copy_ud()
    'Updater vom FileServer auf Client kopieren
    File.Copy(strPfadOrganisation_company & strNeuVersionFiles & "\" & "ud.exe", Application.StartupPath & "\" & "ud.exe", True)
  End Sub

  Public Sub run_ud(ByVal strPara As String)
    Dim tCopyUd As New Thread(AddressOf copy_ud)
    Dim prUd As New Process

    'WriteToErrorLog("UDT, sub run_ud",
    '                "_",
    '                "-",
    '                "strPara: " & strPara)

    'eventuell vorhandenen Updater auf Client löschen
    If File.Exists(Application.StartupPath & "\" & "UD.exe") Then File.Delete(Application.StartupPath & "\" & "UD.exe")

    'aktuelle Version der Updaters auf Client kopieren
    If File.Exists(strPfadOrganisation_company & strNeuVersionFiles & "\" & "UD.exe") Then
      tCopyUd.SetApartmentState(ApartmentState.STA)
      tCopyUd.Start()
      tCopyUd.Join()

      With prUd.StartInfo
        .WindowStyle = ProcessWindowStyle.Normal
        .FileName = "ud.exe"
        .Arguments = strPara
      End With

      'Updater starten
      prUd.Start()
      Application.Exit()
    Else
      WriteToErrorLog("-",
                      "-",
                      "can't run ud.exe, ud.exe missing in app directory on file server" & vbCrLf &
                      "error while starting ud.exe")
    End If
  End Sub

  Public Sub WriteUpdateInfo(lstAll As List(Of String))
    Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\updateinfo.txt", FileMode.Append, FileAccess.Write)
    Dim s1 As StreamWriter = New StreamWriter(fs1)
    For Each str As String In lstAll
      s1.Write(str & vbCrLf)
    Next
    s1.Close()
    fs1.Close()
  End Sub

#End Region

End Module
