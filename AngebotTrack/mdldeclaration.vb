Namespace My
  Friend Class MyApplication
    Sub ChangeMainForm(NewMainForm As Form)
      Me.MainForm = NewMainForm
    End Sub
  End Class
End Namespace

Module mdldeclaration
#Region "IP"
  Public Const strIPServerBrand As String = "172.30.1.38"
  Public Const strIPServerBKLCN As String = "10.150.3.31"
  Public Const strIPServerBKLMX As String = "0.0.0.0"
  Public Const strIPServerBOS As String = "0.0.0.0"
  Public Const strIPServerBSP As String = "0.0.0.0"
  Public Const strIPServerMFW As String = "172.25.10.4"
  Public Const strIPServerLocal As String = "127.0.0.1"

  Public strIPServer As String
#End Region

#Region "Pfade"
  Public Const strPOCBrand As String = "\\srvfbfs01\data\nagsic\tools\"
  Public Const strPOCBKLCN As String = "\\srvfbfs01\data\nagsic\tools\"
  Public Const strPOCBKLMX As String = "\\srvfbfs01\data\nagsic\tools\"
  Public Const strPOCBSP As String = "\\srvfbfs01\data\nagsic\tools\"
  Public Const strPOCMFW As String = "\\fb.brand-group.com\mfw\daten\daten\920_bg_tools\"

  Public Const strPfadOrganisation_company As String = "\\srvfbapp\brand_tools$\"

  Public Const strPfadVerwaltung As String = "angebtrack\verwaltung\"
  Public Const strNeueVersionPath As String = "angebtrack\update"
  Public Const strNeuVersionFiles As String = "angebtrack\setup"

  Public Const strErrorPath As String = "\\srvfbapp\brand_userdata$\angebtrack\errors"

  Public strPfadError As String

#End Region

#Region "Connection"
  Public connectionstringKalk As String
  Public connectionstringFed As String
  Public connectionstringFoss As String
  Public connectionstringCI As String

  Public connectionstring As String

  Public strConnectionType As String

  Public strMissingDB As String

  Public strServerConnected As String

  Public strServerNamen() As String = {"MySQL-A", "MySQL-MFW", "MySQL-Local"}

#End Region

#Region "filter vertriebsbereich"
  Public lstODP As New List(Of String)
  Public strWhereVB As String = ""


#End Region

#Region "constants"


#End Region

#Region "variablen"
#Region "bool"
  Public blFileServerPresent As Boolean
  Public blRemoteDBServerPresent As Boolean
  Public blLocalDBServerPresent As Boolean

  Public blconnectedDBKalk As Boolean
  Public blconnectedDBFed As Boolean
  Public blconnectedDBCI As Boolean

  Public blberechtigt As Boolean

  Public blUpdate As Boolean
  Public blUpdateFiles As Boolean

  Public blGeaendert As Boolean
  Public blReadOnlyHSB As Boolean

#End Region

#Region "string"

  Public strOrganisation_company As String
  Public strOrganisation_company_local As String = "BRA"
  Public strOrganisation_division As String
  Public strOrganisation_country As String
  Public strOrganisation_plant As String
  Public strOrganisation_plant_local As String
  Public strOrganisation_segment As String
  Public strOrganisation_town As String

  Public strVertriebsbereich As String
  Public lstVertriebsbereich As List(Of String)

  Public strIDTracking As String
  Public strLastIDTracking As String
  Public lngIDTracking As Long
  Public strIDAngebotReg As String
  Public strIDSatzSperre As String

  Public strMitZKT As String
  Public strMitExtBearb As String
  Public strAngebotBis As String
  Public strBerechnungErstellt As String
  Public strStatusBerechnung As String
  Public strHSBErstelltAE As String
  Public strStatusHSBAE As String
  Public strHSBErstelltPROD As String
  Public strStatusHSBPROD As String
  Public strHSBErstelltQS As String
  Public strHSBFreigegeben As String
  Public strStatusHSBQS As String
  Public strStatusKalk As String
  Public strZKTAngefragt As String
  Public strExtBearbAngefragt As String
  Public strZKTAngebotErhalten As String
  Public strExtBearbAngebotErhalten As String
  Public strKalkErstellt As String
  Public strBemerkungenTracking As String

  Public strFileWithPathExcelExport As String = Application.StartupPath & "\tracking.xlsx"

  Public Const strUserSettingsAT As String = "\usersettingsat.xml"
  Public Const strUserSettingsAR As String = "\usersettingsar.xml"

  Public strDatFmt As String = "yyyy-MM-dd"

#End Region

#Region "int"
  Public int_counter_user_action As Int16     'benötigt in Zusammenhang mit Satzsperre und automatisch Verlassen des vom User gesperrten DS
#End Region

#Region "lists"
  Public lstVM As New List(Of String)
#End Region

#End Region

#Region "Check"
  Public str_version_framework As String
  Public str_load_data_result As String
  Public str_save_result As String

  '*** Variablen bei Überprüfung der zur Kalkulation benötigten Daten
  Public datencheck_array As New ArrayList() 'Array für Bezeichnung der fehlenden Werte

  Public strIniPath As String

  Public int_wahrscheinlich As Integer        'benötigt für t_deckblatt, weil dort Integer

  Public arDaten As New ArrayList
  Public arFehlend As New ArrayList           'nimmt bei fehlenden Werten im Datencheck entsprechende Texte auf
  'Public arBaugruppe As New ArrayList         'nimmt alle zu einer Baugruppen gehörenden id's auf    

  Public alFilesToUpdate As ArrayList

  Public strSprache As String

  Public strTitelMsg As String
  Public strTextMsg As String

  Public str_uid_tmp As String                'nimmt mehrere SQL-Strings auf, die dann gemeinsam der Funktion "update_insert_delete" übergeben werden

  Public strVarianteKopie As String           'Variante beim Kopieren (Staffelmenge oder Kopie)
  Public strAntwortSpeichern As String        'Resultat aus der Funktion speichern_daten
#End Region

#Region "Format"
  Public strDatFmtStd As String = "yyyy-MM-dd"
  Public strDatFmtdeDE As String = "dd.MM.yyyy"
  Public strDatFmtenGB As String = "MMMM d,yyyy"
#End Region

#Region "filter"
  Public strFilterCDP As String                 'enthält den Grundausdruck, der die anzuzeigenden Daten filtert (auf Basis Organisation / Division / Plant)

  Public str_filter_last As String

  Public lst_filter As New ArrayList
  Public lst_filter_info As New ArrayList
  Public lst_filter_ctl As New ArrayList
#End Region

#Region "Satzsperre"
  Public lstSperrTabelle As New List(Of String)
  Public strTimeStamp As String
  Public strDatFmtSperre As String = "yyyy-MM-dd HH:mm:ss"

  Public intRowHandle_AT As Int64
  Public intRowHandle_AR As Int64
#End Region

#Region "user"
  Public suser As String
  Public strUserIni As String
  Public strBerechtigung As String              'gültige Werte: info, vm, km(Kunden-Manager), admin
  Public strUserVollstaendig As String          'vollständiger Name des Users
  Public ArrayUserGroup As New ArrayList        'nimmt die Bezeichnungen aller User-Gruppen(=Berechtigung) auf
#End Region

End Module
