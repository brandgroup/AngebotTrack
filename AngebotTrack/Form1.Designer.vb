<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
  Inherits System.Windows.Forms.Form

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Wird vom Windows Form-Designer benötigt.
  Private components As System.ComponentModel.IContainer

  'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
  'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
  'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip_form1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btn_filter_aufheben = New System.Windows.Forms.Button()
        Me.btn_daten_aktualisieren = New System.Windows.Forms.Button()
        Me.Timer_satzsperre = New System.Windows.Forms.Timer(Me.components)
        Me.GridControl_tracking = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView_tracking = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand_basics = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colid_tracking = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colorg_company = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colorg_division = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colorg_plant = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.coldatum_angelegt_am = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colangebot_nr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colkunde = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colpb = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colanzahl_teile = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colanzahl_jahresbedarfe = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colbearbeitet_von = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colname_kunden_manager = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_angefragt_am = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_angebot_bis = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.coltracking_abgabe_termin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colprio = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colprio_automatisch = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.col_status_kalk = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.col_satzsperre_ar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand_zkt_extb = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colflg = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzukaufteile_erforderlich = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colext_bearbeitung_erforderlich = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand_tracking = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colzeit_datum_hsb_freigegeben = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_berechnung_vorhanden = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.col_status_berechnung = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_hsb_vorhanden_ae = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.col_status_hsb_ae = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_hsb_vorhanden_prod = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.col_status_hsb_prod = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_hsb_vorhanden_qs = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.col_status_hsb_qm = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_zukaufteile_angefragt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_ext_bearbeitung_angefragt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_zukaufteile_angebot_vorhanden = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_kalk_erstellt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colzeit_datum_angebot_abgegeben = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colstatus_bearbeitung = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colfreigegeben_von = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand_bemerkungen = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colbemerkungen = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.BarManager_form1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarSubItem_angebots_tracking = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem_schliessen = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem_einstellungen = New DevExpress.XtraBars.BarSubItem()
        Me.BarEditItem_sprache = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemComboBox_sprache = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.BarSubItem_anzeigen = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem_dokumentation = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem_info = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem_connection = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem_berechtigung = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem_numlock = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem_capslock = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem_date = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem_anzahl_ds = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem_timer_user_action = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarStaticItem_org = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem_div = New DevExpress.XtraBars.BarStaticItem()
        Me.BarHeaderItem_anzahl_ds = New DevExpress.XtraBars.BarHeaderItem()
        Me.BarStaticItem_plant = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonItem_daten_aktualisieren = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticItem_info_satzsperre = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarEditItem_znr_suchen = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemSearchLookUpEdit_znr = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemComboBox_znr_suchen = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemComboBox_vertriebsbereich = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.RepositoryItemCheckedComboBoxEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DataTabletrackingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_tracking = New AngebotTrack.DataSet_tracking()
        Me.PanelControl_buttons = New DevExpress.XtraEditors.PanelControl()
        Me.btn_excel_export = New System.Windows.Forms.Button()
        Me.btn_test = New System.Windows.Forms.Button()
        Me.btn_schliessen = New System.Windows.Forms.Button()
        Me.GridControl_AngebotReg = New DevExpress.XtraGrid.GridControl()
        Me.DataTableAngebotRegBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView_AngebotReg = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colid_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colid_tracking_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_datum_angebot_bis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colznr_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colind_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coljahresbedarf_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.collosgroesse_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colpb_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmit_zukaufteilen_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colmit_ext_ag_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_berechnung_erstellt_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colzeit_datum_hsb_erstellt_ae_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_hsb_erstellt_prod_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_hsb_erstellt_qm_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_hsb_freigegeben_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_zukaufteile_angefragt_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colzeit_datum_kalk_erstellt_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colstatus_angebot_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmachbarkeit_ae = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmachbarkeit_prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmachbarkeit_qm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmachbarkeit_kalk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_bemerkungen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BackgroundWorker_speichern = New System.ComponentModel.BackgroundWorker()
        Me.Timer_user_action = New System.Windows.Forms.Timer(Me.components)
        Me.PopupMenu_tracking = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BackgroundWorker_excel_export = New System.ComponentModel.BackgroundWorker()
        CType(Me.GridControl_tracking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView_tracking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager_form1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox_sprache, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit_znr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox_znr_suchen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox_vertriebsbereich, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckedComboBoxEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTabletrackingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_tracking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl_buttons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl_buttons.SuspendLayout()
        CType(Me.GridControl_AngebotReg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTableAngebotRegBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_AngebotReg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu_tracking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_filter_aufheben
        '
        resources.ApplyResources(Me.btn_filter_aufheben, "btn_filter_aufheben")
        Me.btn_filter_aufheben.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_filter_aufheben.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_filter_aufheben.Image = Global.AngebotTrack.My.Resources.Resources.clear_filter
        Me.btn_filter_aufheben.Name = "btn_filter_aufheben"
        Me.ToolTip_form1.SetToolTip(Me.btn_filter_aufheben, resources.GetString("btn_filter_aufheben.ToolTip"))
        Me.btn_filter_aufheben.UseVisualStyleBackColor = True
        '
        'btn_daten_aktualisieren
        '
        resources.ApplyResources(Me.btn_daten_aktualisieren, "btn_daten_aktualisieren")
        Me.btn_daten_aktualisieren.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_daten_aktualisieren.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_daten_aktualisieren.Image = Global.AngebotTrack.My.Resources.Resources.refresh
        Me.btn_daten_aktualisieren.Name = "btn_daten_aktualisieren"
        Me.ToolTip_form1.SetToolTip(Me.btn_daten_aktualisieren, resources.GetString("btn_daten_aktualisieren.ToolTip"))
        Me.btn_daten_aktualisieren.UseVisualStyleBackColor = True
        '
        'Timer_satzsperre
        '
        Me.Timer_satzsperre.Interval = 20000
        '
        'GridControl_tracking
        '
        resources.ApplyResources(Me.GridControl_tracking, "GridControl_tracking")
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.GridControl_tracking.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl_tracking.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.GridControl_tracking.MainView = Me.BandedGridView_tracking
        Me.GridControl_tracking.MenuManager = Me.BarManager_form1
        Me.GridControl_tracking.Name = "GridControl_tracking"
        Me.GridControl_tracking.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2, Me.RepositoryItemMemoEdit1, Me.RepositoryItemCheckedComboBoxEdit1, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemMemoExEdit1})
        Me.GridControl_tracking.UseEmbeddedNavigator = True
        Me.GridControl_tracking.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView_tracking})
        '
        'BandedGridView_tracking
        '
        Me.BandedGridView_tracking.Appearance.EvenRow.BackColor = System.Drawing.Color.Lavender
        Me.BandedGridView_tracking.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView_tracking.Appearance.GroupPanel.BackColor = System.Drawing.SystemColors.Control
        Me.BandedGridView_tracking.Appearance.GroupPanel.GradientMode = CType(resources.GetObject("BandedGridView_tracking.Appearance.GroupPanel.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.BandedGridView_tracking.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView_tracking.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.BandedGridView_tracking.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView_tracking.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView_tracking.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView_tracking.Appearance.SelectedRow.BackColor = System.Drawing.Color.Honeydew
        Me.BandedGridView_tracking.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView_tracking.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand_basics, Me.gridBand_zkt_extb, Me.gridBand_tracking, Me.gridBand_bemerkungen})
        Me.BandedGridView_tracking.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colid_tracking, Me.colorg_company, Me.colorg_division, Me.colorg_plant, Me.coldatum_angelegt_am, Me.colangebot_nr, Me.colkunde, Me.colpb, Me.colanzahl_teile, Me.colanzahl_jahresbedarfe, Me.colbearbeitet_von, Me.colname_kunden_manager, Me.colzeit_datum_angefragt_am, Me.colzeit_datum_angebot_bis, Me.coltracking_abgabe_termin, Me.colzukaufteile_erforderlich, Me.colext_bearbeitung_erforderlich, Me.colprio, Me.colprio_automatisch, Me.colzeit_datum_berechnung_vorhanden, Me.colzeit_datum_hsb_vorhanden_ae, Me.colzeit_datum_hsb_vorhanden_prod, Me.colzeit_datum_hsb_vorhanden_qs, Me.colzeit_datum_hsb_freigegeben, Me.colzeit_datum_zukaufteile_angefragt, Me.colzeit_datum_ext_bearbeitung_angefragt, Me.colzeit_datum_zukaufteile_angebot_vorhanden, Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden, Me.colzeit_datum_kalk_erstellt, Me.colzeit_datum_angebot_abgegeben, Me.colstatus_bearbeitung, Me.colfreigegeben_von, Me.colbemerkungen, Me.col_status_berechnung, Me.col_status_hsb_ae, Me.col_status_hsb_prod, Me.col_status_hsb_qm, Me.col_status_kalk, Me.colflg, Me.col_satzsperre_ar})
        Me.BandedGridView_tracking.GridControl = Me.GridControl_tracking
        Me.BandedGridView_tracking.Name = "BandedGridView_tracking"
        Me.BandedGridView_tracking.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridView_tracking.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.BandedGridView_tracking.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.BandedGridView_tracking.OptionsView.AllowHtmlDrawHeaders = True
        Me.BandedGridView_tracking.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.BandedGridView_tracking.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView_tracking.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView_tracking.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colzeit_datum_hsb_freigegeben, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridBand_basics
        '
        resources.ApplyResources(Me.GridBand_basics, "GridBand_basics")
        Me.GridBand_basics.Columns.Add(Me.colid_tracking)
        Me.GridBand_basics.Columns.Add(Me.colorg_company)
        Me.GridBand_basics.Columns.Add(Me.colorg_division)
        Me.GridBand_basics.Columns.Add(Me.colorg_plant)
        Me.GridBand_basics.Columns.Add(Me.coldatum_angelegt_am)
        Me.GridBand_basics.Columns.Add(Me.colangebot_nr)
        Me.GridBand_basics.Columns.Add(Me.colkunde)
        Me.GridBand_basics.Columns.Add(Me.colpb)
        Me.GridBand_basics.Columns.Add(Me.colanzahl_teile)
        Me.GridBand_basics.Columns.Add(Me.colanzahl_jahresbedarfe)
        Me.GridBand_basics.Columns.Add(Me.colbearbeitet_von)
        Me.GridBand_basics.Columns.Add(Me.colname_kunden_manager)
        Me.GridBand_basics.Columns.Add(Me.colzeit_datum_angefragt_am)
        Me.GridBand_basics.Columns.Add(Me.colzeit_datum_angebot_bis)
        Me.GridBand_basics.Columns.Add(Me.coltracking_abgabe_termin)
        Me.GridBand_basics.Columns.Add(Me.colprio)
        Me.GridBand_basics.Columns.Add(Me.colprio_automatisch)
        Me.GridBand_basics.Columns.Add(Me.col_status_kalk)
        Me.GridBand_basics.Columns.Add(Me.col_satzsperre_ar)
        Me.GridBand_basics.VisibleIndex = 0
        '
        'colid_tracking
        '
        resources.ApplyResources(Me.colid_tracking, "colid_tracking")
        Me.colid_tracking.FieldName = "id_tracking"
        Me.colid_tracking.MinWidth = 10
        Me.colid_tracking.Name = "colid_tracking"
        Me.colid_tracking.OptionsColumn.AllowEdit = False
        Me.colid_tracking.OptionsColumn.AllowFocus = False
        Me.colid_tracking.OptionsColumn.AllowIncrementalSearch = False
        Me.colid_tracking.OptionsColumn.AllowMove = False
        Me.colid_tracking.OptionsColumn.AllowShowHide = False
        '
        'colorg_company
        '
        resources.ApplyResources(Me.colorg_company, "colorg_company")
        Me.colorg_company.FieldName = "org_company"
        Me.colorg_company.MinWidth = 60
        Me.colorg_company.Name = "colorg_company"
        Me.colorg_company.OptionsColumn.AllowEdit = False
        '
        'colorg_division
        '
        resources.ApplyResources(Me.colorg_division, "colorg_division")
        Me.colorg_division.FieldName = "org_division"
        Me.colorg_division.MinWidth = 60
        Me.colorg_division.Name = "colorg_division"
        Me.colorg_division.OptionsColumn.AllowEdit = False
        '
        'colorg_plant
        '
        resources.ApplyResources(Me.colorg_plant, "colorg_plant")
        Me.colorg_plant.FieldName = "org_plant"
        Me.colorg_plant.MinWidth = 60
        Me.colorg_plant.Name = "colorg_plant"
        Me.colorg_plant.OptionsColumn.AllowEdit = False
        '
        'coldatum_angelegt_am
        '
        resources.ApplyResources(Me.coldatum_angelegt_am, "coldatum_angelegt_am")
        Me.coldatum_angelegt_am.FieldName = "datum_angelegt_am"
        Me.coldatum_angelegt_am.MinWidth = 10
        Me.coldatum_angelegt_am.Name = "coldatum_angelegt_am"
        Me.coldatum_angelegt_am.OptionsColumn.AllowEdit = False
        '
        'colangebot_nr
        '
        resources.ApplyResources(Me.colangebot_nr, "colangebot_nr")
        Me.colangebot_nr.FieldName = "angebot_nr"
        Me.colangebot_nr.MinWidth = 10
        Me.colangebot_nr.Name = "colangebot_nr"
        Me.colangebot_nr.OptionsColumn.AllowEdit = False
        '
        'colkunde
        '
        resources.ApplyResources(Me.colkunde, "colkunde")
        Me.colkunde.FieldName = "kunde"
        Me.colkunde.MinWidth = 10
        Me.colkunde.Name = "colkunde"
        Me.colkunde.OptionsColumn.AllowEdit = False
        '
        'colpb
        '
        resources.ApplyResources(Me.colpb, "colpb")
        Me.colpb.FieldName = "pb"
        Me.colpb.MinWidth = 10
        Me.colpb.Name = "colpb"
        Me.colpb.OptionsColumn.AllowEdit = False
        '
        'colanzahl_teile
        '
        resources.ApplyResources(Me.colanzahl_teile, "colanzahl_teile")
        Me.colanzahl_teile.FieldName = "anzahl_teile"
        Me.colanzahl_teile.MinWidth = 10
        Me.colanzahl_teile.Name = "colanzahl_teile"
        Me.colanzahl_teile.OptionsColumn.AllowEdit = False
        '
        'colanzahl_jahresbedarfe
        '
        resources.ApplyResources(Me.colanzahl_jahresbedarfe, "colanzahl_jahresbedarfe")
        Me.colanzahl_jahresbedarfe.FieldName = "anzahl_jahresbedarfe"
        Me.colanzahl_jahresbedarfe.MinWidth = 10
        Me.colanzahl_jahresbedarfe.Name = "colanzahl_jahresbedarfe"
        Me.colanzahl_jahresbedarfe.OptionsColumn.AllowEdit = False
        '
        'colbearbeitet_von
        '
        resources.ApplyResources(Me.colbearbeitet_von, "colbearbeitet_von")
        Me.colbearbeitet_von.FieldName = "bearbeitet_von"
        Me.colbearbeitet_von.MinWidth = 10
        Me.colbearbeitet_von.Name = "colbearbeitet_von"
        Me.colbearbeitet_von.OptionsColumn.AllowEdit = False
        '
        'colname_kunden_manager
        '
        resources.ApplyResources(Me.colname_kunden_manager, "colname_kunden_manager")
        Me.colname_kunden_manager.FieldName = "name_kunden_manager"
        Me.colname_kunden_manager.MinWidth = 10
        Me.colname_kunden_manager.Name = "colname_kunden_manager"
        '
        'colzeit_datum_angefragt_am
        '
        resources.ApplyResources(Me.colzeit_datum_angefragt_am, "colzeit_datum_angefragt_am")
        Me.colzeit_datum_angefragt_am.FieldName = "zeit_datum_angefragt_am"
        Me.colzeit_datum_angefragt_am.MinWidth = 10
        Me.colzeit_datum_angefragt_am.Name = "colzeit_datum_angefragt_am"
        Me.colzeit_datum_angefragt_am.OptionsColumn.AllowEdit = False
        '
        'colzeit_datum_angebot_bis
        '
        resources.ApplyResources(Me.colzeit_datum_angebot_bis, "colzeit_datum_angebot_bis")
        Me.colzeit_datum_angebot_bis.FieldName = "zeit_datum_angebot_bis"
        Me.colzeit_datum_angebot_bis.MinWidth = 10
        Me.colzeit_datum_angebot_bis.Name = "colzeit_datum_angebot_bis"
        Me.colzeit_datum_angebot_bis.OptionsColumn.AllowEdit = False
        '
        'coltracking_abgabe_termin
        '
        Me.coltracking_abgabe_termin.AppearanceCell.Options.UseTextOptions = True
        Me.coltracking_abgabe_termin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        resources.ApplyResources(Me.coltracking_abgabe_termin, "coltracking_abgabe_termin")
        Me.coltracking_abgabe_termin.FieldName = "tracking_abgabe_termin"
        Me.coltracking_abgabe_termin.MinWidth = 10
        Me.coltracking_abgabe_termin.Name = "coltracking_abgabe_termin"
        Me.coltracking_abgabe_termin.OptionsColumn.AllowEdit = False
        Me.coltracking_abgabe_termin.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
        '
        'colprio
        '
        Me.colprio.AppearanceCell.Options.UseTextOptions = True
        Me.colprio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        resources.ApplyResources(Me.colprio, "colprio")
        Me.colprio.FieldName = "prio"
        Me.colprio.MinWidth = 10
        Me.colprio.Name = "colprio"
        Me.colprio.OptionsColumn.AllowEdit = False
        '
        'colprio_automatisch
        '
        Me.colprio_automatisch.AppearanceCell.Options.UseTextOptions = True
        Me.colprio_automatisch.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        resources.ApplyResources(Me.colprio_automatisch, "colprio_automatisch")
        Me.colprio_automatisch.FieldName = "prio_automatisch"
        Me.colprio_automatisch.MinWidth = 10
        Me.colprio_automatisch.Name = "colprio_automatisch"
        Me.colprio_automatisch.OptionsColumn.AllowEdit = False
        '
        'col_status_kalk
        '
        resources.ApplyResources(Me.col_status_kalk, "col_status_kalk")
        Me.col_status_kalk.FieldName = "status_kalk"
        Me.col_status_kalk.Name = "col_status_kalk"
        '
        'col_satzsperre_ar
        '
        resources.ApplyResources(Me.col_satzsperre_ar, "col_satzsperre_ar")
        Me.col_satzsperre_ar.FieldName = "satzsperre"
        Me.col_satzsperre_ar.MinWidth = 10
        Me.col_satzsperre_ar.Name = "col_satzsperre_ar"
        Me.col_satzsperre_ar.OptionsColumn.AllowEdit = False
        Me.col_satzsperre_ar.OptionsColumn.AllowFocus = False
        Me.col_satzsperre_ar.OptionsColumn.AllowShowHide = False
        '
        'gridBand_zkt_extb
        '
        resources.ApplyResources(Me.gridBand_zkt_extb, "gridBand_zkt_extb")
        Me.gridBand_zkt_extb.Columns.Add(Me.colflg)
        Me.gridBand_zkt_extb.Columns.Add(Me.colzukaufteile_erforderlich)
        Me.gridBand_zkt_extb.Columns.Add(Me.colext_bearbeitung_erforderlich)
        Me.gridBand_zkt_extb.VisibleIndex = 1
        '
        'colflg
        '
        resources.ApplyResources(Me.colflg, "colflg")
        Me.colflg.FieldName = "flg"
        Me.colflg.Name = "colflg"
        '
        'colzukaufteile_erforderlich
        '
        resources.ApplyResources(Me.colzukaufteile_erforderlich, "colzukaufteile_erforderlich")
        Me.colzukaufteile_erforderlich.FieldName = "zukaufteile_erforderlich"
        Me.colzukaufteile_erforderlich.MinWidth = 10
        Me.colzukaufteile_erforderlich.Name = "colzukaufteile_erforderlich"
        Me.colzukaufteile_erforderlich.OptionsColumn.AllowEdit = False
        '
        'colext_bearbeitung_erforderlich
        '
        resources.ApplyResources(Me.colext_bearbeitung_erforderlich, "colext_bearbeitung_erforderlich")
        Me.colext_bearbeitung_erforderlich.FieldName = "ext_bearbeitung_erforderlich"
        Me.colext_bearbeitung_erforderlich.MinWidth = 10
        Me.colext_bearbeitung_erforderlich.Name = "colext_bearbeitung_erforderlich"
        Me.colext_bearbeitung_erforderlich.OptionsColumn.AllowEdit = False
        '
        'gridBand_tracking
        '
        resources.ApplyResources(Me.gridBand_tracking, "gridBand_tracking")
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_hsb_freigegeben)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_berechnung_vorhanden)
        Me.gridBand_tracking.Columns.Add(Me.col_status_berechnung)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_hsb_vorhanden_ae)
        Me.gridBand_tracking.Columns.Add(Me.col_status_hsb_ae)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_hsb_vorhanden_prod)
        Me.gridBand_tracking.Columns.Add(Me.col_status_hsb_prod)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_hsb_vorhanden_qs)
        Me.gridBand_tracking.Columns.Add(Me.col_status_hsb_qm)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_zukaufteile_angefragt)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_ext_bearbeitung_angefragt)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_zukaufteile_angebot_vorhanden)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_kalk_erstellt)
        Me.gridBand_tracking.Columns.Add(Me.colzeit_datum_angebot_abgegeben)
        Me.gridBand_tracking.Columns.Add(Me.colstatus_bearbeitung)
        Me.gridBand_tracking.Columns.Add(Me.colfreigegeben_von)
        Me.gridBand_tracking.VisibleIndex = 2
        '
        'colzeit_datum_hsb_freigegeben
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_freigegeben, "colzeit_datum_hsb_freigegeben")
        Me.colzeit_datum_hsb_freigegeben.FieldName = "zeit_datum_hsb_freigegeben"
        Me.colzeit_datum_hsb_freigegeben.MinWidth = 10
        Me.colzeit_datum_hsb_freigegeben.Name = "colzeit_datum_hsb_freigegeben"
        '
        'colzeit_datum_berechnung_vorhanden
        '
        resources.ApplyResources(Me.colzeit_datum_berechnung_vorhanden, "colzeit_datum_berechnung_vorhanden")
        Me.colzeit_datum_berechnung_vorhanden.FieldName = "zeit_datum_berechnung_vorhanden"
        Me.colzeit_datum_berechnung_vorhanden.MinWidth = 10
        Me.colzeit_datum_berechnung_vorhanden.Name = "colzeit_datum_berechnung_vorhanden"
        Me.colzeit_datum_berechnung_vorhanden.OptionsColumn.AllowEdit = False
        '
        'col_status_berechnung
        '
        resources.ApplyResources(Me.col_status_berechnung, "col_status_berechnung")
        Me.col_status_berechnung.Name = "col_status_berechnung"
        Me.col_status_berechnung.OptionsColumn.AllowEdit = False
        Me.col_status_berechnung.OptionsColumn.AllowFocus = False
        Me.col_status_berechnung.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.col_status_berechnung.OptionsColumn.AllowIncrementalSearch = False
        Me.col_status_berechnung.OptionsColumn.AllowMove = False
        Me.col_status_berechnung.OptionsColumn.AllowShowHide = False
        Me.col_status_berechnung.OptionsColumn.AllowSize = False
        Me.col_status_berechnung.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.col_status_berechnung.OptionsColumn.ReadOnly = True
        Me.col_status_berechnung.OptionsColumn.TabStop = False
        '
        'colzeit_datum_hsb_vorhanden_ae
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_vorhanden_ae, "colzeit_datum_hsb_vorhanden_ae")
        Me.colzeit_datum_hsb_vorhanden_ae.FieldName = "zeit_datum_hsb_vorhanden_ae"
        Me.colzeit_datum_hsb_vorhanden_ae.MinWidth = 10
        Me.colzeit_datum_hsb_vorhanden_ae.Name = "colzeit_datum_hsb_vorhanden_ae"
        Me.colzeit_datum_hsb_vorhanden_ae.OptionsColumn.AllowEdit = False
        '
        'col_status_hsb_ae
        '
        resources.ApplyResources(Me.col_status_hsb_ae, "col_status_hsb_ae")
        Me.col_status_hsb_ae.FieldName = "status_hsb_ae"
        Me.col_status_hsb_ae.Name = "col_status_hsb_ae"
        Me.col_status_hsb_ae.OptionsColumn.AllowEdit = False
        Me.col_status_hsb_ae.OptionsColumn.AllowFocus = False
        Me.col_status_hsb_ae.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.col_status_hsb_ae.OptionsColumn.AllowIncrementalSearch = False
        Me.col_status_hsb_ae.OptionsColumn.AllowMove = False
        Me.col_status_hsb_ae.OptionsColumn.AllowShowHide = False
        Me.col_status_hsb_ae.OptionsColumn.AllowSize = False
        Me.col_status_hsb_ae.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colzeit_datum_hsb_vorhanden_prod
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_vorhanden_prod, "colzeit_datum_hsb_vorhanden_prod")
        Me.colzeit_datum_hsb_vorhanden_prod.FieldName = "zeit_datum_hsb_vorhanden_prod"
        Me.colzeit_datum_hsb_vorhanden_prod.MinWidth = 10
        Me.colzeit_datum_hsb_vorhanden_prod.Name = "colzeit_datum_hsb_vorhanden_prod"
        Me.colzeit_datum_hsb_vorhanden_prod.OptionsColumn.AllowEdit = False
        '
        'col_status_hsb_prod
        '
        resources.ApplyResources(Me.col_status_hsb_prod, "col_status_hsb_prod")
        Me.col_status_hsb_prod.FieldName = "status_hsb_prod"
        Me.col_status_hsb_prod.Name = "col_status_hsb_prod"
        Me.col_status_hsb_prod.OptionsColumn.AllowEdit = False
        Me.col_status_hsb_prod.OptionsColumn.AllowFocus = False
        Me.col_status_hsb_prod.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.col_status_hsb_prod.OptionsColumn.AllowIncrementalSearch = False
        Me.col_status_hsb_prod.OptionsColumn.AllowMove = False
        Me.col_status_hsb_prod.OptionsColumn.AllowShowHide = False
        Me.col_status_hsb_prod.OptionsColumn.AllowSize = False
        Me.col_status_hsb_prod.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colzeit_datum_hsb_vorhanden_qs
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_vorhanden_qs, "colzeit_datum_hsb_vorhanden_qs")
        Me.colzeit_datum_hsb_vorhanden_qs.FieldName = "zeit_datum_hsb_vorhanden_qm"
        Me.colzeit_datum_hsb_vorhanden_qs.MinWidth = 10
        Me.colzeit_datum_hsb_vorhanden_qs.Name = "colzeit_datum_hsb_vorhanden_qs"
        Me.colzeit_datum_hsb_vorhanden_qs.OptionsColumn.AllowEdit = False
        '
        'col_status_hsb_qm
        '
        resources.ApplyResources(Me.col_status_hsb_qm, "col_status_hsb_qm")
        Me.col_status_hsb_qm.FieldName = "status_hsb_qm"
        Me.col_status_hsb_qm.Name = "col_status_hsb_qm"
        Me.col_status_hsb_qm.OptionsColumn.AllowEdit = False
        Me.col_status_hsb_qm.OptionsColumn.AllowFocus = False
        Me.col_status_hsb_qm.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.col_status_hsb_qm.OptionsColumn.AllowIncrementalSearch = False
        Me.col_status_hsb_qm.OptionsColumn.AllowMove = False
        Me.col_status_hsb_qm.OptionsColumn.AllowShowHide = False
        Me.col_status_hsb_qm.OptionsColumn.AllowSize = False
        Me.col_status_hsb_qm.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colzeit_datum_zukaufteile_angefragt
        '
        resources.ApplyResources(Me.colzeit_datum_zukaufteile_angefragt, "colzeit_datum_zukaufteile_angefragt")
        Me.colzeit_datum_zukaufteile_angefragt.FieldName = "zeit_datum_zukaufteile_angefragt"
        Me.colzeit_datum_zukaufteile_angefragt.MinWidth = 10
        Me.colzeit_datum_zukaufteile_angefragt.Name = "colzeit_datum_zukaufteile_angefragt"
        Me.colzeit_datum_zukaufteile_angefragt.OptionsColumn.AllowEdit = False
        '
        'colzeit_datum_ext_bearbeitung_angefragt
        '
        resources.ApplyResources(Me.colzeit_datum_ext_bearbeitung_angefragt, "colzeit_datum_ext_bearbeitung_angefragt")
        Me.colzeit_datum_ext_bearbeitung_angefragt.FieldName = "zeit_datum_ext_bearbeitung_angefragt"
        Me.colzeit_datum_ext_bearbeitung_angefragt.MinWidth = 10
        Me.colzeit_datum_ext_bearbeitung_angefragt.Name = "colzeit_datum_ext_bearbeitung_angefragt"
        Me.colzeit_datum_ext_bearbeitung_angefragt.OptionsColumn.AllowEdit = False
        '
        'colzeit_datum_zukaufteile_angebot_vorhanden
        '
        resources.ApplyResources(Me.colzeit_datum_zukaufteile_angebot_vorhanden, "colzeit_datum_zukaufteile_angebot_vorhanden")
        Me.colzeit_datum_zukaufteile_angebot_vorhanden.FieldName = "zeit_datum_zukaufteile_angebot_vorhanden"
        Me.colzeit_datum_zukaufteile_angebot_vorhanden.MinWidth = 10
        Me.colzeit_datum_zukaufteile_angebot_vorhanden.Name = "colzeit_datum_zukaufteile_angebot_vorhanden"
        Me.colzeit_datum_zukaufteile_angebot_vorhanden.OptionsColumn.AllowEdit = False
        '
        'colzeit_datum_ext_bearbeitung_angebot_vorhanden
        '
        resources.ApplyResources(Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden, "colzeit_datum_ext_bearbeitung_angebot_vorhanden")
        Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden.FieldName = "zeit_datum_ext_bearbeitung_angebot_vorhanden"
        Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden.MinWidth = 10
        Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden.Name = "colzeit_datum_ext_bearbeitung_angebot_vorhanden"
        Me.colzeit_datum_ext_bearbeitung_angebot_vorhanden.OptionsColumn.AllowEdit = False
        '
        'colzeit_datum_kalk_erstellt
        '
        resources.ApplyResources(Me.colzeit_datum_kalk_erstellt, "colzeit_datum_kalk_erstellt")
        Me.colzeit_datum_kalk_erstellt.FieldName = "zeit_datum_kalk_erstellt"
        Me.colzeit_datum_kalk_erstellt.MinWidth = 10
        Me.colzeit_datum_kalk_erstellt.Name = "colzeit_datum_kalk_erstellt"
        Me.colzeit_datum_kalk_erstellt.OptionsColumn.AllowEdit = False
        '
        'colzeit_datum_angebot_abgegeben
        '
        resources.ApplyResources(Me.colzeit_datum_angebot_abgegeben, "colzeit_datum_angebot_abgegeben")
        Me.colzeit_datum_angebot_abgegeben.FieldName = "zeit_datum_angebot_abgegeben"
        Me.colzeit_datum_angebot_abgegeben.MinWidth = 10
        Me.colzeit_datum_angebot_abgegeben.Name = "colzeit_datum_angebot_abgegeben"
        Me.colzeit_datum_angebot_abgegeben.OptionsColumn.AllowEdit = False
        Me.colzeit_datum_angebot_abgegeben.OptionsColumn.ReadOnly = True
        '
        'colstatus_bearbeitung
        '
        resources.ApplyResources(Me.colstatus_bearbeitung, "colstatus_bearbeitung")
        Me.colstatus_bearbeitung.FieldName = "status_bearbeitung"
        Me.colstatus_bearbeitung.MinWidth = 10
        Me.colstatus_bearbeitung.Name = "colstatus_bearbeitung"
        Me.colstatus_bearbeitung.OptionsColumn.AllowEdit = False
        Me.colstatus_bearbeitung.OptionsColumn.ReadOnly = True
        '
        'colfreigegeben_von
        '
        resources.ApplyResources(Me.colfreigegeben_von, "colfreigegeben_von")
        Me.colfreigegeben_von.FieldName = "freigegeben_von"
        Me.colfreigegeben_von.MinWidth = 10
        Me.colfreigegeben_von.Name = "colfreigegeben_von"
        Me.colfreigegeben_von.OptionsColumn.AllowEdit = False
        Me.colfreigegeben_von.OptionsColumn.ReadOnly = True
        '
        'gridBand_bemerkungen
        '
        resources.ApplyResources(Me.gridBand_bemerkungen, "gridBand_bemerkungen")
        Me.gridBand_bemerkungen.Columns.Add(Me.colbemerkungen)
        Me.gridBand_bemerkungen.VisibleIndex = 3
        '
        'colbemerkungen
        '
        Me.colbemerkungen.AppearanceCell.Options.UseTextOptions = True
        Me.colbemerkungen.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.colbemerkungen, "colbemerkungen")
        Me.colbemerkungen.ColumnEdit = Me.RepositoryItemMemoExEdit1
        Me.colbemerkungen.FieldName = "bemerkungen_tracking"
        Me.colbemerkungen.MinWidth = 10
        Me.colbemerkungen.Name = "colbemerkungen"
        Me.colbemerkungen.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colbemerkungen.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        '
        'RepositoryItemMemoExEdit1
        '
        resources.ApplyResources(Me.RepositoryItemMemoExEdit1, "RepositoryItemMemoExEdit1")
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemMemoExEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        Me.RepositoryItemMemoExEdit1.ShowIcon = False
        '
        'BarManager_form1
        '
        Me.BarManager_form1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager_form1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager_form1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager_form1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager_form1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager_form1.Form = Me
        Me.BarManager_form1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem_angebots_tracking, Me.BarSubItem_einstellungen, Me.BarSubItem_anzeigen, Me.BarEditItem_sprache, Me.BarButtonItem_dokumentation, Me.BarButtonItem_info, Me.BarStaticItem_org, Me.BarStaticItem_div, Me.BarStaticItem_numlock, Me.BarStaticItem_capslock, Me.BarStaticItem_date, Me.BarHeaderItem_anzahl_ds, Me.BarStaticItem_timer_user_action, Me.BarStaticItem_connection, Me.BarStaticItem_berechtigung, Me.BarStaticItem_plant, Me.BarStaticItem_anzahl_ds, Me.BarButtonItem_schliessen, Me.BarButtonItem_daten_aktualisieren, Me.BarStaticItem_info_satzsperre, Me.BarStaticItem1, Me.BarEditItem_znr_suchen})
        Me.BarManager_form1.MainMenu = Me.Bar2
        Me.BarManager_form1.MaxItemId = 33
        Me.BarManager_form1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemComboBox_sprache, Me.RepositoryItemComboBox_znr_suchen, Me.RepositoryItemComboBox_vertriebsbereich, Me.RepositoryItemPictureEdit1, Me.RepositoryItemSearchLookUpEdit_znr, Me.RepositoryItemSearchLookUpEdit1})
        Me.BarManager_form1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Hauptmenü"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.FloatLocation = New System.Drawing.Point(97, 131)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem_angebots_tracking), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem_einstellungen), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem_anzeigen)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar2, "Bar2")
        '
        'BarSubItem_angebots_tracking
        '
        resources.ApplyResources(Me.BarSubItem_angebots_tracking, "BarSubItem_angebots_tracking")
        Me.BarSubItem_angebots_tracking.Id = 0
        Me.BarSubItem_angebots_tracking.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem_schliessen)})
        Me.BarSubItem_angebots_tracking.Name = "BarSubItem_angebots_tracking"
        '
        'BarButtonItem_schliessen
        '
        resources.ApplyResources(Me.BarButtonItem_schliessen, "BarButtonItem_schliessen")
        Me.BarButtonItem_schliessen.Id = 24
        Me.BarButtonItem_schliessen.Name = "BarButtonItem_schliessen"
        '
        'BarSubItem_einstellungen
        '
        resources.ApplyResources(Me.BarSubItem_einstellungen, "BarSubItem_einstellungen")
        Me.BarSubItem_einstellungen.Id = 1
        Me.BarSubItem_einstellungen.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarEditItem_sprache)})
        Me.BarSubItem_einstellungen.Name = "BarSubItem_einstellungen"
        '
        'BarEditItem_sprache
        '
        resources.ApplyResources(Me.BarEditItem_sprache, "BarEditItem_sprache")
        Me.BarEditItem_sprache.Edit = Me.RepositoryItemComboBox_sprache
        Me.BarEditItem_sprache.Id = 6
        Me.BarEditItem_sprache.Name = "BarEditItem_sprache"
        '
        'RepositoryItemComboBox_sprache
        '
        Me.RepositoryItemComboBox_sprache.AllowMouseWheel = False
        resources.ApplyResources(Me.RepositoryItemComboBox_sprache, "RepositoryItemComboBox_sprache")
        Me.RepositoryItemComboBox_sprache.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemComboBox_sprache.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemComboBox_sprache.Name = "RepositoryItemComboBox_sprache"
        '
        'BarSubItem_anzeigen
        '
        resources.ApplyResources(Me.BarSubItem_anzeigen, "BarSubItem_anzeigen")
        Me.BarSubItem_anzeigen.Id = 2
        Me.BarSubItem_anzeigen.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem_dokumentation), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem_info)})
        Me.BarSubItem_anzeigen.Name = "BarSubItem_anzeigen"
        '
        'BarButtonItem_dokumentation
        '
        resources.ApplyResources(Me.BarButtonItem_dokumentation, "BarButtonItem_dokumentation")
        Me.BarButtonItem_dokumentation.Id = 9
        Me.BarButtonItem_dokumentation.Name = "BarButtonItem_dokumentation"
        '
        'BarButtonItem_info
        '
        resources.ApplyResources(Me.BarButtonItem_info, "BarButtonItem_info")
        Me.BarButtonItem_info.Id = 10
        Me.BarButtonItem_info.Name = "BarButtonItem_info"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Statusleiste"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem_connection), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem_berechtigung), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem_numlock), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem_capslock), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem_date), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem_anzahl_ds), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem_timer_user_action)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar3, "Bar3")
        '
        'BarStaticItem_connection
        '
        resources.ApplyResources(Me.BarStaticItem_connection, "BarStaticItem_connection")
        Me.BarStaticItem_connection.Id = 20
        Me.BarStaticItem_connection.Name = "BarStaticItem_connection"
        '
        'BarStaticItem_berechtigung
        '
        resources.ApplyResources(Me.BarStaticItem_berechtigung, "BarStaticItem_berechtigung")
        Me.BarStaticItem_berechtigung.Id = 21
        Me.BarStaticItem_berechtigung.Name = "BarStaticItem_berechtigung"
        '
        'BarStaticItem_numlock
        '
        resources.ApplyResources(Me.BarStaticItem_numlock, "BarStaticItem_numlock")
        Me.BarStaticItem_numlock.Id = 15
        Me.BarStaticItem_numlock.Name = "BarStaticItem_numlock"
        '
        'BarStaticItem_capslock
        '
        resources.ApplyResources(Me.BarStaticItem_capslock, "BarStaticItem_capslock")
        Me.BarStaticItem_capslock.Id = 16
        Me.BarStaticItem_capslock.Name = "BarStaticItem_capslock"
        '
        'BarStaticItem_date
        '
        resources.ApplyResources(Me.BarStaticItem_date, "BarStaticItem_date")
        Me.BarStaticItem_date.Id = 17
        Me.BarStaticItem_date.Name = "BarStaticItem_date"
        '
        'BarStaticItem_anzahl_ds
        '
        resources.ApplyResources(Me.BarStaticItem_anzahl_ds, "BarStaticItem_anzahl_ds")
        Me.BarStaticItem_anzahl_ds.Id = 23
        Me.BarStaticItem_anzahl_ds.Name = "BarStaticItem_anzahl_ds"
        '
        'BarStaticItem_timer_user_action
        '
        resources.ApplyResources(Me.BarStaticItem_timer_user_action, "BarStaticItem_timer_user_action")
        Me.BarStaticItem_timer_user_action.Id = 19
        Me.BarStaticItem_timer_user_action.Name = "BarStaticItem_timer_user_action"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager_form1
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager_form1
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager_form1
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager_form1
        '
        'BarStaticItem_org
        '
        resources.ApplyResources(Me.BarStaticItem_org, "BarStaticItem_org")
        Me.BarStaticItem_org.Id = 12
        Me.BarStaticItem_org.Name = "BarStaticItem_org"
        '
        'BarStaticItem_div
        '
        resources.ApplyResources(Me.BarStaticItem_div, "BarStaticItem_div")
        Me.BarStaticItem_div.Id = 13
        Me.BarStaticItem_div.Name = "BarStaticItem_div"
        '
        'BarHeaderItem_anzahl_ds
        '
        resources.ApplyResources(Me.BarHeaderItem_anzahl_ds, "BarHeaderItem_anzahl_ds")
        Me.BarHeaderItem_anzahl_ds.Id = 18
        Me.BarHeaderItem_anzahl_ds.Name = "BarHeaderItem_anzahl_ds"
        '
        'BarStaticItem_plant
        '
        resources.ApplyResources(Me.BarStaticItem_plant, "BarStaticItem_plant")
        Me.BarStaticItem_plant.Id = 22
        Me.BarStaticItem_plant.Name = "BarStaticItem_plant"
        '
        'BarButtonItem_daten_aktualisieren
        '
        resources.ApplyResources(Me.BarButtonItem_daten_aktualisieren, "BarButtonItem_daten_aktualisieren")
        Me.BarButtonItem_daten_aktualisieren.Id = 28
        Me.BarButtonItem_daten_aktualisieren.Name = "BarButtonItem_daten_aktualisieren"
        '
        'BarStaticItem_info_satzsperre
        '
        Me.BarStaticItem_info_satzsperre.Id = 29
        Me.BarStaticItem_info_satzsperre.Name = "BarStaticItem_info_satzsperre"
        '
        'BarStaticItem1
        '
        resources.ApplyResources(Me.BarStaticItem1, "BarStaticItem1")
        Me.BarStaticItem1.Id = 30
        Me.BarStaticItem1.Name = "BarStaticItem1"
        '
        'BarEditItem_znr_suchen
        '
        resources.ApplyResources(Me.BarEditItem_znr_suchen, "BarEditItem_znr_suchen")
        Me.BarEditItem_znr_suchen.Edit = Me.RepositoryItemSearchLookUpEdit_znr
        Me.BarEditItem_znr_suchen.Id = 31
        Me.BarEditItem_znr_suchen.Name = "BarEditItem_znr_suchen"
        '
        'RepositoryItemSearchLookUpEdit_znr
        '
        resources.ApplyResources(Me.RepositoryItemSearchLookUpEdit_znr, "RepositoryItemSearchLookUpEdit_znr")
        Me.RepositoryItemSearchLookUpEdit_znr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemSearchLookUpEdit_znr.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemSearchLookUpEdit_znr.Name = "RepositoryItemSearchLookUpEdit_znr"
        Me.RepositoryItemSearchLookUpEdit_znr.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsCustomization.AllowColumnMoving = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsCustomization.AllowQuickHideColumns = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit1
        '
        resources.ApplyResources(Me.RepositoryItemTextEdit1, "RepositoryItemTextEdit1")
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemComboBox_znr_suchen
        '
        resources.ApplyResources(Me.RepositoryItemComboBox_znr_suchen, "RepositoryItemComboBox_znr_suchen")
        Me.RepositoryItemComboBox_znr_suchen.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemComboBox_znr_suchen.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemComboBox_znr_suchen.Name = "RepositoryItemComboBox_znr_suchen"
        '
        'RepositoryItemComboBox_vertriebsbereich
        '
        Me.RepositoryItemComboBox_vertriebsbereich.AllowMouseWheel = False
        resources.ApplyResources(Me.RepositoryItemComboBox_vertriebsbereich, "RepositoryItemComboBox_vertriebsbereich")
        Me.RepositoryItemComboBox_vertriebsbereich.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemComboBox_vertriebsbereich.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemComboBox_vertriebsbereich.Name = "RepositoryItemComboBox_vertriebsbereich"
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Appearance.Image = Global.AngebotTrack.My.Resources.Resources.brandgroup
        Me.RepositoryItemPictureEdit1.Appearance.Options.UseImage = True
        Me.RepositoryItemPictureEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RepositoryItemPictureEdit1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.ReadOnly = True
        Me.RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'RepositoryItemSearchLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemSearchLookUpEdit1, "RepositoryItemSearchLookUpEdit1")
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemSearchLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.PopupView = Me.GridView1
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemCheckEdit2
        '
        resources.ApplyResources(Me.RepositoryItemCheckEdit2, "RepositoryItemCheckEdit2")
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'RepositoryItemCheckedComboBoxEdit1
        '
        resources.ApplyResources(Me.RepositoryItemCheckedComboBoxEdit1, "RepositoryItemCheckedComboBoxEdit1")
        Me.RepositoryItemCheckedComboBoxEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemCheckedComboBoxEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemCheckedComboBoxEdit1.Name = "RepositoryItemCheckedComboBoxEdit1"
        '
        'RepositoryItemLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit1, "RepositoryItemLookUpEdit1")
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'DataTabletrackingBindingSource
        '
        Me.DataTabletrackingBindingSource.DataMember = "DataTable_tracking"
        Me.DataTabletrackingBindingSource.DataSource = Me.DataSet_tracking
        '
        'DataSet_tracking
        '
        Me.DataSet_tracking.DataSetName = "DataSet_tracking"
        Me.DataSet_tracking.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelControl_buttons
        '
        resources.ApplyResources(Me.PanelControl_buttons, "PanelControl_buttons")
        Me.PanelControl_buttons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.PanelControl_buttons.Controls.Add(Me.btn_excel_export)
        Me.PanelControl_buttons.Controls.Add(Me.btn_daten_aktualisieren)
        Me.PanelControl_buttons.Controls.Add(Me.btn_filter_aufheben)
        Me.PanelControl_buttons.Controls.Add(Me.btn_test)
        Me.PanelControl_buttons.Controls.Add(Me.btn_schliessen)
        Me.PanelControl_buttons.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl_buttons.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl_buttons.Name = "PanelControl_buttons"
        '
        'btn_excel_export
        '
        resources.ApplyResources(Me.btn_excel_export, "btn_excel_export")
        Me.btn_excel_export.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_excel_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_excel_export.Image = Global.AngebotTrack.My.Resources.Resources.excel_select
        Me.btn_excel_export.Name = "btn_excel_export"
        Me.btn_excel_export.UseVisualStyleBackColor = True
        '
        'btn_test
        '
        resources.ApplyResources(Me.btn_test, "btn_test")
        Me.btn_test.Name = "btn_test"
        Me.btn_test.UseVisualStyleBackColor = True
        '
        'btn_schliessen
        '
        resources.ApplyResources(Me.btn_schliessen, "btn_schliessen")
        Me.btn_schliessen.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_schliessen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_schliessen.Image = Global.AngebotTrack.My.Resources.Resources.exit_app
        Me.btn_schliessen.Name = "btn_schliessen"
        Me.btn_schliessen.UseVisualStyleBackColor = True
        '
        'GridControl_AngebotReg
        '
        resources.ApplyResources(Me.GridControl_AngebotReg, "GridControl_AngebotReg")
        Me.GridControl_AngebotReg.DataSource = Me.DataTableAngebotRegBindingSource
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.Append.Enabled = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.CancelEdit.Enabled = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.Edit.Enabled = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.EndEdit.Enabled = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.Remove.Enabled = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl_AngebotReg.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.GridControl_AngebotReg.MainView = Me.GridView_AngebotReg
        Me.GridControl_AngebotReg.Name = "GridControl_AngebotReg"
        Me.GridControl_AngebotReg.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemDateEdit1})
        Me.GridControl_AngebotReg.UseEmbeddedNavigator = True
        Me.GridControl_AngebotReg.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_AngebotReg})
        '
        'DataTableAngebotRegBindingSource
        '
        Me.DataTableAngebotRegBindingSource.DataMember = "DataTable_AngebotReg"
        Me.DataTableAngebotRegBindingSource.DataSource = Me.DataSet_tracking
        Me.DataTableAngebotRegBindingSource.Filter = "id_tracking = -1"
        '
        'GridView_AngebotReg
        '
        Me.GridView_AngebotReg.Appearance.EvenRow.BackColor = System.Drawing.Color.Lavender
        Me.GridView_AngebotReg.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView_AngebotReg.Appearance.GroupPanel.GradientMode = CType(resources.GetObject("GridView_AngebotReg.Appearance.GroupPanel.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.GridView_AngebotReg.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView_AngebotReg.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridView_AngebotReg.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.GridView_AngebotReg.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView_AngebotReg.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colid_ar, Me.colid_tracking_ar, Me.col_datum_angebot_bis, Me.colznr_ar, Me.colind_ar, Me.coljahresbedarf_ar, Me.collosgroesse_ar, Me.colpb_ar, Me.colmit_zukaufteilen_ar, Me.colmit_ext_ag_ar, Me.colzeit_datum_berechnung_erstellt_ar, Me.colzeit_datum_hsb_erstellt_ae_ar, Me.colzeit_datum_hsb_erstellt_prod_ar, Me.colzeit_datum_hsb_erstellt_qm_ar, Me.colzeit_datum_hsb_freigegeben_ar, Me.colzeit_datum_zukaufteile_angefragt_ar, Me.colzeit_datum_ext_bearbeitung_angefragt_ar, Me.colzeit_datum_zukaufteile_angebot_erhalten_ar, Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar, Me.colzeit_datum_kalk_erstellt_ar, Me.colstatus_angebot_ar, Me.colmachbarkeit_ae, Me.colmachbarkeit_prod, Me.colmachbarkeit_qm, Me.colmachbarkeit_kalk, Me.col_bemerkungen})
        Me.GridView_AngebotReg.GridControl = Me.GridControl_AngebotReg
        Me.GridView_AngebotReg.Name = "GridView_AngebotReg"
        Me.GridView_AngebotReg.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridView_AngebotReg.OptionsView.AllowHtmlDrawHeaders = True
        Me.GridView_AngebotReg.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView_AngebotReg.OptionsView.EnableAppearanceOddRow = True
        Me.GridView_AngebotReg.OptionsView.ShowGroupPanel = False
        '
        'colid_ar
        '
        resources.ApplyResources(Me.colid_ar, "colid_ar")
        Me.colid_ar.FieldName = "id"
        Me.colid_ar.MinWidth = 10
        Me.colid_ar.Name = "colid_ar"
        Me.colid_ar.OptionsColumn.AllowEdit = False
        Me.colid_ar.OptionsColumn.AllowMove = False
        Me.colid_ar.OptionsColumn.AllowShowHide = False
        Me.colid_ar.OptionsColumn.ReadOnly = True
        Me.colid_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colid_ar.OptionsEditForm.VisibleIndex = 97
        '
        'colid_tracking_ar
        '
        resources.ApplyResources(Me.colid_tracking_ar, "colid_tracking_ar")
        Me.colid_tracking_ar.FieldName = "id_tracking"
        Me.colid_tracking_ar.MinWidth = 10
        Me.colid_tracking_ar.Name = "colid_tracking_ar"
        Me.colid_tracking_ar.OptionsColumn.AllowMove = False
        Me.colid_tracking_ar.OptionsColumn.AllowShowHide = False
        Me.colid_tracking_ar.OptionsColumn.ReadOnly = True
        Me.colid_tracking_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colid_tracking_ar.OptionsEditForm.VisibleIndex = 98
        '
        'col_datum_angebot_bis
        '
        resources.ApplyResources(Me.col_datum_angebot_bis, "col_datum_angebot_bis")
        Me.col_datum_angebot_bis.FieldName = "zeit_datum_angebot_bis"
        Me.col_datum_angebot_bis.MaxWidth = 80
        Me.col_datum_angebot_bis.MinWidth = 10
        Me.col_datum_angebot_bis.Name = "col_datum_angebot_bis"
        Me.col_datum_angebot_bis.OptionsColumn.AllowMove = False
        Me.col_datum_angebot_bis.OptionsColumn.AllowShowHide = False
        Me.col_datum_angebot_bis.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.col_datum_angebot_bis.OptionsEditForm.VisibleIndex = 99
        '
        'colznr_ar
        '
        resources.ApplyResources(Me.colznr_ar, "colznr_ar")
        Me.colznr_ar.FieldName = "znr"
        Me.colznr_ar.MinWidth = 10
        Me.colznr_ar.Name = "colznr_ar"
        Me.colznr_ar.OptionsColumn.AllowMove = False
        Me.colznr_ar.OptionsColumn.AllowShowHide = False
        Me.colznr_ar.OptionsColumn.ReadOnly = True
        '
        'colind_ar
        '
        resources.ApplyResources(Me.colind_ar, "colind_ar")
        Me.colind_ar.FieldName = "ind"
        Me.colind_ar.MinWidth = 10
        Me.colind_ar.Name = "colind_ar"
        Me.colind_ar.OptionsColumn.AllowMove = False
        Me.colind_ar.OptionsColumn.AllowShowHide = False
        Me.colind_ar.OptionsColumn.ReadOnly = True
        Me.colind_ar.OptionsEditForm.VisibleIndex = 1
        '
        'coljahresbedarf_ar
        '
        resources.ApplyResources(Me.coljahresbedarf_ar, "coljahresbedarf_ar")
        Me.coljahresbedarf_ar.DisplayFormat.FormatString = "#,##0"
        Me.coljahresbedarf_ar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coljahresbedarf_ar.FieldName = "jahresbedarf"
        Me.coljahresbedarf_ar.MinWidth = 10
        Me.coljahresbedarf_ar.Name = "coljahresbedarf_ar"
        Me.coljahresbedarf_ar.OptionsColumn.AllowMove = False
        Me.coljahresbedarf_ar.OptionsColumn.AllowShowHide = False
        Me.coljahresbedarf_ar.OptionsColumn.ReadOnly = True
        Me.coljahresbedarf_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'collosgroesse_ar
        '
        resources.ApplyResources(Me.collosgroesse_ar, "collosgroesse_ar")
        Me.collosgroesse_ar.DisplayFormat.FormatString = "#,##0"
        Me.collosgroesse_ar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.collosgroesse_ar.FieldName = "losgroesse"
        Me.collosgroesse_ar.MinWidth = 10
        Me.collosgroesse_ar.Name = "collosgroesse_ar"
        Me.collosgroesse_ar.OptionsColumn.AllowMove = False
        Me.collosgroesse_ar.OptionsColumn.AllowShowHide = False
        Me.collosgroesse_ar.OptionsColumn.ReadOnly = True
        Me.collosgroesse_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colpb_ar
        '
        resources.ApplyResources(Me.colpb_ar, "colpb_ar")
        Me.colpb_ar.FieldName = "pb"
        Me.colpb_ar.MinWidth = 10
        Me.colpb_ar.Name = "colpb_ar"
        Me.colpb_ar.OptionsColumn.ReadOnly = True
        Me.colpb_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colmit_zukaufteilen_ar
        '
        resources.ApplyResources(Me.colmit_zukaufteilen_ar, "colmit_zukaufteilen_ar")
        Me.colmit_zukaufteilen_ar.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.colmit_zukaufteilen_ar.FieldName = "mit_zukaufteilen"
        Me.colmit_zukaufteilen_ar.MinWidth = 10
        Me.colmit_zukaufteilen_ar.Name = "colmit_zukaufteilen_ar"
        Me.colmit_zukaufteilen_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colmit_zukaufteilen_ar.OptionsEditForm.VisibleIndex = 96
        '
        'RepositoryItemCheckEdit1
        '
        resources.ApplyResources(Me.RepositoryItemCheckEdit1, "RepositoryItemCheckEdit1")
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'colmit_ext_ag_ar
        '
        resources.ApplyResources(Me.colmit_ext_ag_ar, "colmit_ext_ag_ar")
        Me.colmit_ext_ag_ar.FieldName = "mit_ext_ag"
        Me.colmit_ext_ag_ar.MinWidth = 10
        Me.colmit_ext_ag_ar.Name = "colmit_ext_ag_ar"
        Me.colmit_ext_ag_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colzeit_datum_berechnung_erstellt_ar
        '
        resources.ApplyResources(Me.colzeit_datum_berechnung_erstellt_ar, "colzeit_datum_berechnung_erstellt_ar")
        Me.colzeit_datum_berechnung_erstellt_ar.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colzeit_datum_berechnung_erstellt_ar.FieldName = "zeit_datum_berechnung_erstellt"
        Me.colzeit_datum_berechnung_erstellt_ar.MinWidth = 10
        Me.colzeit_datum_berechnung_erstellt_ar.Name = "colzeit_datum_berechnung_erstellt_ar"
        Me.colzeit_datum_berechnung_erstellt_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_berechnung_erstellt_ar.OptionsEditForm.StartNewRow = True
        Me.colzeit_datum_berechnung_erstellt_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colzeit_datum_berechnung_erstellt_ar.OptionsEditForm.VisibleIndex = 94
        '
        'RepositoryItemDateEdit1
        '
        resources.ApplyResources(Me.RepositoryItemDateEdit1, "RepositoryItemDateEdit1")
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemDateEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemDateEdit1.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemDateEdit1.MinValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colzeit_datum_hsb_erstellt_ae_ar
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_erstellt_ae_ar, "colzeit_datum_hsb_erstellt_ae_ar")
        Me.colzeit_datum_hsb_erstellt_ae_ar.FieldName = "zeit_datum_hsb_erstellt_ae"
        Me.colzeit_datum_hsb_erstellt_ae_ar.MinWidth = 10
        Me.colzeit_datum_hsb_erstellt_ae_ar.Name = "colzeit_datum_hsb_erstellt_ae_ar"
        Me.colzeit_datum_hsb_erstellt_ae_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_hsb_erstellt_ae_ar.OptionsColumn.ReadOnly = True
        Me.colzeit_datum_hsb_erstellt_ae_ar.OptionsEditForm.VisibleIndex = 3
        '
        'colzeit_datum_hsb_erstellt_prod_ar
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_erstellt_prod_ar, "colzeit_datum_hsb_erstellt_prod_ar")
        Me.colzeit_datum_hsb_erstellt_prod_ar.FieldName = "zeit_datum_hsb_erstellt_prod"
        Me.colzeit_datum_hsb_erstellt_prod_ar.MinWidth = 10
        Me.colzeit_datum_hsb_erstellt_prod_ar.Name = "colzeit_datum_hsb_erstellt_prod_ar"
        Me.colzeit_datum_hsb_erstellt_prod_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_hsb_erstellt_prod_ar.OptionsColumn.ReadOnly = True
        Me.colzeit_datum_hsb_erstellt_prod_ar.OptionsEditForm.VisibleIndex = 6
        '
        'colzeit_datum_hsb_erstellt_qm_ar
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_erstellt_qm_ar, "colzeit_datum_hsb_erstellt_qm_ar")
        Me.colzeit_datum_hsb_erstellt_qm_ar.FieldName = "zeit_datum_hsb_erstellt_qm"
        Me.colzeit_datum_hsb_erstellt_qm_ar.MinWidth = 10
        Me.colzeit_datum_hsb_erstellt_qm_ar.Name = "colzeit_datum_hsb_erstellt_qm_ar"
        Me.colzeit_datum_hsb_erstellt_qm_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_hsb_erstellt_qm_ar.OptionsColumn.ReadOnly = True
        Me.colzeit_datum_hsb_erstellt_qm_ar.OptionsEditForm.VisibleIndex = 9
        '
        'colzeit_datum_hsb_freigegeben_ar
        '
        resources.ApplyResources(Me.colzeit_datum_hsb_freigegeben_ar, "colzeit_datum_hsb_freigegeben_ar")
        Me.colzeit_datum_hsb_freigegeben_ar.FieldName = "zeit_datum_hsb_freigegeben"
        Me.colzeit_datum_hsb_freigegeben_ar.MinWidth = 10
        Me.colzeit_datum_hsb_freigegeben_ar.Name = "colzeit_datum_hsb_freigegeben_ar"
        Me.colzeit_datum_hsb_freigegeben_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_hsb_freigegeben_ar.OptionsColumn.ReadOnly = True
        '
        'colzeit_datum_zukaufteile_angefragt_ar
        '
        resources.ApplyResources(Me.colzeit_datum_zukaufteile_angefragt_ar, "colzeit_datum_zukaufteile_angefragt_ar")
        Me.colzeit_datum_zukaufteile_angefragt_ar.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colzeit_datum_zukaufteile_angefragt_ar.FieldName = "zeit_datum_zukaufteile_angefragt"
        Me.colzeit_datum_zukaufteile_angefragt_ar.MinWidth = 10
        Me.colzeit_datum_zukaufteile_angefragt_ar.Name = "colzeit_datum_zukaufteile_angefragt_ar"
        Me.colzeit_datum_zukaufteile_angefragt_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_zukaufteile_angefragt_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colzeit_datum_zukaufteile_angefragt_ar.OptionsEditForm.VisibleIndex = 92
        '
        'colzeit_datum_ext_bearbeitung_angefragt_ar
        '
        resources.ApplyResources(Me.colzeit_datum_ext_bearbeitung_angefragt_ar, "colzeit_datum_ext_bearbeitung_angefragt_ar")
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.FieldName = "zeit_datum_ext_bearbeitung_angefragt"
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.MaxWidth = 80
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.MinWidth = 10
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.Name = "colzeit_datum_ext_bearbeitung_angefragt_ar"
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colzeit_datum_ext_bearbeitung_angefragt_ar.OptionsEditForm.VisibleIndex = 91
        '
        'colzeit_datum_zukaufteile_angebot_erhalten_ar
        '
        resources.ApplyResources(Me.colzeit_datum_zukaufteile_angebot_erhalten_ar, "colzeit_datum_zukaufteile_angebot_erhalten_ar")
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.FieldName = "zeit_datum_zukaufteile_angebot_erhalten"
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.MaxWidth = 80
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.MinWidth = 10
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.Name = "colzeit_datum_zukaufteile_angebot_erhalten_ar"
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colzeit_datum_zukaufteile_angebot_erhalten_ar.OptionsEditForm.VisibleIndex = 91
        '
        'colzeit_datum_ext_bearbeitung_angebot_erhalten_ar
        '
        resources.ApplyResources(Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar, "colzeit_datum_ext_bearbeitung_angebot_erhalten_ar")
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.FieldName = "zeit_datum_ext_bearbeitung_angebot_erhalten"
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.MaxWidth = 80
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.MinWidth = 10
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.Name = "colzeit_datum_ext_bearbeitung_angebot_erhalten_ar"
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colzeit_datum_ext_bearbeitung_angebot_erhalten_ar.OptionsEditForm.VisibleIndex = 90
        '
        'colzeit_datum_kalk_erstellt_ar
        '
        resources.ApplyResources(Me.colzeit_datum_kalk_erstellt_ar, "colzeit_datum_kalk_erstellt_ar")
        Me.colzeit_datum_kalk_erstellt_ar.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.colzeit_datum_kalk_erstellt_ar.FieldName = "zeit_datum_kalkulation_erstellt"
        Me.colzeit_datum_kalk_erstellt_ar.MaxWidth = 80
        Me.colzeit_datum_kalk_erstellt_ar.MinWidth = 10
        Me.colzeit_datum_kalk_erstellt_ar.Name = "colzeit_datum_kalk_erstellt_ar"
        Me.colzeit_datum_kalk_erstellt_ar.OptionsColumn.AllowSize = False
        Me.colzeit_datum_kalk_erstellt_ar.OptionsEditForm.VisibleIndex = 12
        '
        'colstatus_angebot_ar
        '
        resources.ApplyResources(Me.colstatus_angebot_ar, "colstatus_angebot_ar")
        Me.colstatus_angebot_ar.FieldName = "status_angebot"
        Me.colstatus_angebot_ar.MaxWidth = 80
        Me.colstatus_angebot_ar.MinWidth = 10
        Me.colstatus_angebot_ar.Name = "colstatus_angebot_ar"
        Me.colstatus_angebot_ar.OptionsColumn.AllowEdit = False
        Me.colstatus_angebot_ar.OptionsColumn.AllowMove = False
        Me.colstatus_angebot_ar.OptionsColumn.AllowShowHide = False
        Me.colstatus_angebot_ar.OptionsColumn.AllowSize = False
        Me.colstatus_angebot_ar.OptionsColumn.ReadOnly = True
        Me.colstatus_angebot_ar.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colmachbarkeit_ae
        '
        resources.ApplyResources(Me.colmachbarkeit_ae, "colmachbarkeit_ae")
        Me.colmachbarkeit_ae.FieldName = "machbarkeit_ae"
        Me.colmachbarkeit_ae.MaxWidth = 50
        Me.colmachbarkeit_ae.MinWidth = 10
        Me.colmachbarkeit_ae.Name = "colmachbarkeit_ae"
        Me.colmachbarkeit_ae.OptionsColumn.ReadOnly = True
        Me.colmachbarkeit_ae.OptionsEditForm.StartNewRow = True
        Me.colmachbarkeit_ae.OptionsEditForm.VisibleIndex = 2
        Me.colmachbarkeit_ae.Tag = "hsb"
        '
        'colmachbarkeit_prod
        '
        resources.ApplyResources(Me.colmachbarkeit_prod, "colmachbarkeit_prod")
        Me.colmachbarkeit_prod.FieldName = "machbarkeit_prod"
        Me.colmachbarkeit_prod.MaxWidth = 50
        Me.colmachbarkeit_prod.MinWidth = 10
        Me.colmachbarkeit_prod.Name = "colmachbarkeit_prod"
        Me.colmachbarkeit_prod.OptionsColumn.ReadOnly = True
        Me.colmachbarkeit_prod.OptionsEditForm.StartNewRow = True
        Me.colmachbarkeit_prod.OptionsEditForm.VisibleIndex = 5
        Me.colmachbarkeit_prod.Tag = "hsb"
        '
        'colmachbarkeit_qm
        '
        resources.ApplyResources(Me.colmachbarkeit_qm, "colmachbarkeit_qm")
        Me.colmachbarkeit_qm.FieldName = "machbarkeit_qm"
        Me.colmachbarkeit_qm.MaxWidth = 50
        Me.colmachbarkeit_qm.MinWidth = 10
        Me.colmachbarkeit_qm.Name = "colmachbarkeit_qm"
        Me.colmachbarkeit_qm.OptionsColumn.ReadOnly = True
        Me.colmachbarkeit_qm.OptionsEditForm.StartNewRow = True
        Me.colmachbarkeit_qm.OptionsEditForm.VisibleIndex = 8
        Me.colmachbarkeit_qm.Tag = "hsb"
        '
        'colmachbarkeit_kalk
        '
        resources.ApplyResources(Me.colmachbarkeit_kalk, "colmachbarkeit_kalk")
        Me.colmachbarkeit_kalk.FieldName = "machbarkeit"
        Me.colmachbarkeit_kalk.MaxWidth = 50
        Me.colmachbarkeit_kalk.MinWidth = 10
        Me.colmachbarkeit_kalk.Name = "colmachbarkeit_kalk"
        Me.colmachbarkeit_kalk.OptionsColumn.AllowEdit = False
        Me.colmachbarkeit_kalk.OptionsColumn.ReadOnly = True
        Me.colmachbarkeit_kalk.OptionsEditForm.StartNewRow = True
        Me.colmachbarkeit_kalk.OptionsEditForm.VisibleIndex = 11
        Me.colmachbarkeit_kalk.Tag = "hsb"
        '
        'col_bemerkungen
        '
        resources.ApplyResources(Me.col_bemerkungen, "col_bemerkungen")
        Me.col_bemerkungen.FieldName = "bem_angeb_reg"
        Me.col_bemerkungen.MinWidth = 10
        Me.col_bemerkungen.Name = "col_bemerkungen"
        Me.col_bemerkungen.OptionsColumn.AllowEdit = False
        Me.col_bemerkungen.OptionsEditForm.ColumnSpan = 2
        Me.col_bemerkungen.OptionsEditForm.RowSpan = 2
        Me.col_bemerkungen.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.col_bemerkungen.OptionsEditForm.VisibleIndex = 14
        '
        'BackgroundWorker_speichern
        '
        Me.BackgroundWorker_speichern.WorkerReportsProgress = True
        Me.BackgroundWorker_speichern.WorkerSupportsCancellation = True
        '
        'Timer_user_action
        '
        Me.Timer_user_action.Interval = 1000
        '
        'PopupMenu_tracking
        '
        Me.PopupMenu_tracking.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarEditItem_znr_suchen), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem_daten_aktualisieren)})
        Me.PopupMenu_tracking.Manager = Me.BarManager_form1
        Me.PopupMenu_tracking.Name = "PopupMenu_tracking"
        '
        'BackgroundWorker_excel_export
        '
        Me.BackgroundWorker_excel_export.WorkerReportsProgress = True
        Me.BackgroundWorker_excel_export.WorkerSupportsCancellation = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControl_AngebotReg)
        Me.Controls.Add(Me.PanelControl_buttons)
        Me.Controls.Add(Me.GridControl_tracking)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.KeyPreview = True
        Me.Name = "Form1"
        CType(Me.GridControl_tracking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView_tracking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager_form1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox_sprache, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit_znr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox_znr_suchen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox_vertriebsbereich, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckedComboBoxEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTabletrackingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_tracking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl_buttons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl_buttons.ResumeLayout(False)
        CType(Me.GridControl_AngebotReg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTableAngebotRegBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_AngebotReg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu_tracking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip_form1 As ToolTip
  Friend WithEvents Timer_satzsperre As Timer
  Friend WithEvents GridControl_tracking As DevExpress.XtraGrid.GridControl
  Friend WithEvents PanelControl_buttons As DevExpress.XtraEditors.PanelControl
  Friend WithEvents btn_schliessen As Button
  Friend WithEvents DataSet_tracking As DataSet_tracking
  Friend WithEvents DataTabletrackingBindingSource As BindingSource
  Friend WithEvents GridControl_AngebotReg As DevExpress.XtraGrid.GridControl
  Friend WithEvents DataTableAngebotRegBindingSource As BindingSource
  Friend WithEvents GridView_AngebotReg As DevExpress.XtraGrid.Views.Grid.GridView
  Friend WithEvents colid_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colid_tracking_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colznr_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colind_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents coljahresbedarf_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents collosgroesse_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colpb_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colmit_zukaufteilen_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colmit_ext_ag_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_berechnung_erstellt_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_hsb_erstellt_ae_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_zukaufteile_angefragt_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_ext_bearbeitung_angefragt_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_zukaufteile_angebot_erhalten_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_ext_bearbeitung_angebot_erhalten_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_kalk_erstellt_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colstatus_angebot_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
  Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
  Friend WithEvents btn_test As Button
  Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
  Friend WithEvents RepositoryItemCheckedComboBoxEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit
  Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
  Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
  Friend WithEvents col_bemerkungen As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_datum_angebot_bis As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents BackgroundWorker_speichern As System.ComponentModel.BackgroundWorker
  Friend WithEvents btn_filter_aufheben As Button
  Friend WithEvents btn_daten_aktualisieren As Button
  Friend WithEvents btn_excel_export As Button
  Friend WithEvents colzeit_datum_hsb_erstellt_prod_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colzeit_datum_hsb_erstellt_qm_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
  Friend WithEvents colmachbarkeit_ae As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colmachbarkeit_prod As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colmachbarkeit_qm As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents colmachbarkeit_kalk As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents BandedGridView_tracking As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
  Friend WithEvents colid_tracking As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents coldatum_angelegt_am As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colangebot_nr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colkunde As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colpb As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colanzahl_teile As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colanzahl_jahresbedarfe As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colbearbeitet_von As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_angefragt_am As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_angebot_bis As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents coltracking_abgabe_termin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzukaufteile_erforderlich As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colext_bearbeitung_erforderlich As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colprio As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colprio_automatisch As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_berechnung_vorhanden As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_hsb_vorhanden_ae As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_hsb_vorhanden_prod As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_hsb_vorhanden_qs As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_zukaufteile_angefragt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_ext_bearbeitung_angefragt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_zukaufteile_angebot_vorhanden As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_ext_bearbeitung_angebot_vorhanden As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_kalk_erstellt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_angebot_abgegeben As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colstatus_bearbeitung As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colfreigegeben_von As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colbemerkungen As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colorg_company As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colorg_division As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colorg_plant As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents col_satzsperre_ar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents Timer_user_action As Timer
  Friend WithEvents BarManager_form1 As DevExpress.XtraBars.BarManager
  Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
  Friend WithEvents BarSubItem_angebots_tracking As DevExpress.XtraBars.BarSubItem
  Friend WithEvents RepositoryItemComboBox_vertriebsbereich As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
  Friend WithEvents RepositoryItemComboBox_znr_suchen As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
  Friend WithEvents BarSubItem_einstellungen As DevExpress.XtraBars.BarSubItem
  Friend WithEvents BarEditItem_sprache As DevExpress.XtraBars.BarEditItem
  Friend WithEvents RepositoryItemComboBox_sprache As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
  Friend WithEvents BarSubItem_anzeigen As DevExpress.XtraBars.BarSubItem
  Friend WithEvents BarButtonItem_dokumentation As DevExpress.XtraBars.BarButtonItem
  Friend WithEvents BarButtonItem_info As DevExpress.XtraBars.BarButtonItem
  Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
  Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
  Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
  Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
  Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
  Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
  Friend WithEvents BarStaticItem_connection As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_org As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_div As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_plant As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_berechtigung As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_numlock As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_capslock As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_date As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_anzahl_ds As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarStaticItem_timer_user_action As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents BarHeaderItem_anzahl_ds As DevExpress.XtraBars.BarHeaderItem
  Friend WithEvents BarButtonItem_schliessen As DevExpress.XtraBars.BarButtonItem
  Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
  Friend WithEvents BarButtonItem_daten_aktualisieren As DevExpress.XtraBars.BarButtonItem
  Friend WithEvents PopupMenu_tracking As DevExpress.XtraBars.PopupMenu
  Friend WithEvents BarStaticItem_info_satzsperre As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents col_status_hsb_ae As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents col_status_hsb_prod As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents col_status_hsb_qm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents col_status_berechnung As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colname_kunden_manager As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colflg As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents col_status_kalk As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_hsb_freigegeben As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
  Friend WithEvents colzeit_datum_hsb_freigegeben_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents GridBand_basics As DevExpress.XtraGrid.Views.BandedGrid.GridBand
  Friend WithEvents gridBand_zkt_extb As DevExpress.XtraGrid.Views.BandedGrid.GridBand
  Friend WithEvents gridBand_tracking As DevExpress.XtraGrid.Views.BandedGrid.GridBand
  Friend WithEvents gridBand_bemerkungen As DevExpress.XtraGrid.Views.BandedGrid.GridBand
  Friend WithEvents BarEditItem_znr_suchen As DevExpress.XtraBars.BarEditItem
  Friend WithEvents RepositoryItemSearchLookUpEdit_znr As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
  Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
  Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
  Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
  Friend WithEvents BackgroundWorker_excel_export As System.ComponentModel.BackgroundWorker
End Class
