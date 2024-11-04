<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_hsb
  Inherits System.Windows.Forms.Form

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
  <System.Diagnostics.DebuggerNonUserCode()> _
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
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_hsb))
        Me.RepositoryItemCheckEdit_zutreffend = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemComboBox_ergebnis = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.PanelControl_header = New DevExpress.XtraEditors.PanelControl()
        Me.lbl_flg = New DevExpress.XtraEditors.LabelControl()
        Me.tbx_flg = New DevExpress.XtraEditors.TextEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonItem_schliessen = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.lbl_angebot_nr = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_pb_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_pb = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_znr_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_ind_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_kunde_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_znr_ind = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_kunde = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl_ae = New DevExpress.XtraEditors.PanelControl()
        Me.lbl_vkwg = New DevExpress.XtraEditors.LabelControl()
        Me.cbx_vkwg_produkt = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DataSet_hsb = New AngebotTrack.DataSet_tracking()
        Me.cbx_vkwg_anwendung = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbx_vkwg_anwendungssegment = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbx_vkwg_branche = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbl_ae_name = New DevExpress.XtraEditors.LabelControl()
        Me.cbx_ae_name = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DateEdit_ae = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_ae_result_all_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_ae_result_all = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl_ae = New DevExpress.XtraGrid.GridControl()
        Me.GridView_ae = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.col_ae_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_id_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_area = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_attribute = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_match_ext = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_match_int = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit_ae = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.col_ae_result_attribute = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox_result_ae = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.col_ae_tool = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_rem_int = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit_ae = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.col_ae_rem_cust = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_date_time_result = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_result_all = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_ae_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lbl_ae = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl_prod = New DevExpress.XtraEditors.PanelControl()
        Me.lbl_prod_name = New DevExpress.XtraEditors.LabelControl()
        Me.cbx_prod_name = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DateEdit_prod = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_prod_result_all_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_prod_result_all = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl_prod = New DevExpress.XtraGrid.GridControl()
        Me.GridView_prod = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.col_prod_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_id_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_area = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_attribute = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_match_ext = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit_prod = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.col_prod_match_int = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_result_attribute = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox_result_prod = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.col_prod_tool = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_rem_int = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit_prod = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.col_prod_rem_cust = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_date_time_result = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_produ_result_all = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_prod_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lbl_prod = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl_qs = New DevExpress.XtraEditors.PanelControl()
        Me.lbl_qs_name = New DevExpress.XtraEditors.LabelControl()
        Me.cbx_qs_name = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DateEdit_qs = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_qs_result_all_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_qs_result_all = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl_qs = New DevExpress.XtraGrid.GridControl()
        Me.GridView_qs = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.col_qs_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_id_ar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_area = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_attribute = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_match_ext = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_match_int = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit_qs = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.col_qs_result_attribute = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox_result_qs = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.col_qs_tool = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_rem_int = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoExEdit_qs = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.col_qs_rem_cust = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_date_time_result = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_result_all = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.col_qs_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lbl_qs = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl_footer = New DevExpress.XtraEditors.PanelControl()
        Me.btn_freigeben = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_name_ae_hsb_all_wert = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_name_ae_hsb_all = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit_all = New DevExpress.XtraEditors.DateEdit()
        Me.lbl_result_hsb_all = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_result_all = New DevExpress.XtraEditors.LabelControl()
        Me.DataTablehsbBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.RepositoryItemCheckEdit_zutreffend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox_ergebnis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl_header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl_header.SuspendLayout()
        CType(Me.tbx_flg.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl_ae, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl_ae.SuspendLayout()
        CType(Me.cbx_vkwg_produkt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_hsb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbx_vkwg_anwendung.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbx_vkwg_anwendungssegment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbx_vkwg_branche.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbx_ae_name.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit_ae.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit_ae.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl_ae, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_ae, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit_ae, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox_result_ae, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit_ae, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl_prod.SuspendLayout()
        CType(Me.cbx_prod_name.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit_prod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit_prod.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox_result_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit_prod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl_qs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl_qs.SuspendLayout()
        CType(Me.cbx_qs_name.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit_qs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit_qs.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl_qs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_qs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit_qs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox_result_qs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit_qs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl_footer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl_footer.SuspendLayout()
        CType(Me.DateEdit_all.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit_all.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTablehsbBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemCheckEdit_zutreffend
        '
        Me.RepositoryItemCheckEdit_zutreffend.AutoHeight = False
        Me.RepositoryItemCheckEdit_zutreffend.Name = "RepositoryItemCheckEdit_zutreffend"
        Me.RepositoryItemCheckEdit_zutreffend.ValueChecked = CType(1, Short)
        Me.RepositoryItemCheckEdit_zutreffend.ValueUnchecked = CType(0, Short)
        '
        'RepositoryItemComboBox_ergebnis
        '
        Me.RepositoryItemComboBox_ergebnis.AutoHeight = False
        Me.RepositoryItemComboBox_ergebnis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox_ergebnis.Items.AddRange(New Object() {"-", "go", "go but", "no go"})
        Me.RepositoryItemComboBox_ergebnis.Name = "RepositoryItemComboBox_ergebnis"
        Me.RepositoryItemComboBox_ergebnis.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'PanelControl_header
        '
        Me.PanelControl_header.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PanelControl_header.Controls.Add(Me.lbl_flg)
        Me.PanelControl_header.Controls.Add(Me.tbx_flg)
        Me.PanelControl_header.Controls.Add(Me.lbl_angebot_nr)
        Me.PanelControl_header.Controls.Add(Me.lbl_pb_wert)
        Me.PanelControl_header.Controls.Add(Me.lbl_pb)
        Me.PanelControl_header.Controls.Add(Me.lbl_znr_wert)
        Me.PanelControl_header.Controls.Add(Me.lbl_ind_wert)
        Me.PanelControl_header.Controls.Add(Me.lbl_kunde_wert)
        Me.PanelControl_header.Controls.Add(Me.lbl_znr_ind)
        Me.PanelControl_header.Controls.Add(Me.lbl_kunde)
        Me.PanelControl_header.Location = New System.Drawing.Point(6, 26)
        Me.PanelControl_header.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl_header.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl_header.Name = "PanelControl_header"
        Me.PanelControl_header.Size = New System.Drawing.Size(958, 80)
        Me.PanelControl_header.TabIndex = 0
        '
        'lbl_flg
        '
        Me.lbl_flg.Appearance.Options.UseTextOptions = True
        Me.lbl_flg.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_flg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_flg.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_flg.Location = New System.Drawing.Point(726, 52)
        Me.lbl_flg.Name = "lbl_flg"
        Me.lbl_flg.Size = New System.Drawing.Size(120, 21)
        Me.lbl_flg.TabIndex = 12
        Me.lbl_flg.Text = "Fertigungslosgrösse"
        '
        'tbx_flg
        '
        Me.tbx_flg.Location = New System.Drawing.Point(852, 52)
        Me.tbx_flg.MenuManager = Me.BarManager1
        Me.tbx_flg.Name = "tbx_flg"
        Me.tbx_flg.Properties.Appearance.Options.UseTextOptions = True
        Me.tbx_flg.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.tbx_flg.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.tbx_flg.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.tbx_flg.Properties.AutoHeight = False
        Me.tbx_flg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tbx_flg.Properties.Mask.EditMask = "n0"
        Me.tbx_flg.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tbx_flg.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tbx_flg.Properties.ReadOnly = True
        Me.tbx_flg.Size = New System.Drawing.Size(100, 21)
        Me.tbx_flg.TabIndex = 11
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem_schliessen, Me.BarStaticItem1})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 3
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Hauptmenü"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem_schliessen)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawBorder = False
        Me.Bar2.Text = "Hauptmenü"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Id = 2
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.Size = New System.Drawing.Size(870, 0)
        Me.BarStaticItem1.Width = 870
        '
        'BarButtonItem_schliessen
        '
        Me.BarButtonItem_schliessen.Caption = "Schliessen"
        Me.BarButtonItem_schliessen.Id = 0
        Me.BarButtonItem_schliessen.Name = "BarButtonItem_schliessen"
        Me.BarButtonItem_schliessen.Size = New System.Drawing.Size(80, 0)
        '
        'Bar3
        '
        Me.Bar3.BarName = "Statusleiste"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Statusleiste"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(967, 20)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 965)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(967, 20)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 20)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 945)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(967, 20)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 945)
        '
        'lbl_angebot_nr
        '
        Me.lbl_angebot_nr.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_angebot_nr.Appearance.Options.UseFont = True
        Me.lbl_angebot_nr.Appearance.Options.UseTextOptions = True
        Me.lbl_angebot_nr.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbl_angebot_nr.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_angebot_nr.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_angebot_nr.Location = New System.Drawing.Point(832, 6)
        Me.lbl_angebot_nr.Name = "lbl_angebot_nr"
        Me.lbl_angebot_nr.Size = New System.Drawing.Size(120, 21)
        Me.lbl_angebot_nr.TabIndex = 10
        Me.lbl_angebot_nr.Text = "-"
        '
        'lbl_pb_wert
        '
        Me.lbl_pb_wert.Appearance.BackColor = System.Drawing.Color.White
        Me.lbl_pb_wert.Appearance.Options.UseBackColor = True
        Me.lbl_pb_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_pb_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_pb_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_pb_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_pb_wert.Location = New System.Drawing.Point(130, 6)
        Me.lbl_pb_wert.Name = "lbl_pb_wert"
        Me.lbl_pb_wert.Size = New System.Drawing.Size(200, 21)
        Me.lbl_pb_wert.TabIndex = 9
        Me.lbl_pb_wert.Text = "-"
        '
        'lbl_pb
        '
        Me.lbl_pb.Appearance.Options.UseTextOptions = True
        Me.lbl_pb.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_pb.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_pb.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_pb.Location = New System.Drawing.Point(6, 6)
        Me.lbl_pb.Name = "lbl_pb"
        Me.lbl_pb.Size = New System.Drawing.Size(120, 21)
        Me.lbl_pb.TabIndex = 8
        Me.lbl_pb.Text = "Produktionsstandort"
        '
        'lbl_znr_wert
        '
        Me.lbl_znr_wert.Appearance.BackColor = System.Drawing.Color.White
        Me.lbl_znr_wert.Appearance.Options.UseBackColor = True
        Me.lbl_znr_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_znr_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_znr_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_znr_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_znr_wert.Location = New System.Drawing.Point(130, 52)
        Me.lbl_znr_wert.Name = "lbl_znr_wert"
        Me.lbl_znr_wert.Size = New System.Drawing.Size(200, 21)
        Me.lbl_znr_wert.TabIndex = 7
        Me.lbl_znr_wert.Text = "-"
        '
        'lbl_ind_wert
        '
        Me.lbl_ind_wert.Appearance.BackColor = System.Drawing.Color.White
        Me.lbl_ind_wert.Appearance.Options.UseBackColor = True
        Me.lbl_ind_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_ind_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_ind_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_ind_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_ind_wert.Location = New System.Drawing.Point(332, 52)
        Me.lbl_ind_wert.Name = "lbl_ind_wert"
        Me.lbl_ind_wert.Size = New System.Drawing.Size(40, 21)
        Me.lbl_ind_wert.TabIndex = 6
        Me.lbl_ind_wert.Text = "-"
        '
        'lbl_kunde_wert
        '
        Me.lbl_kunde_wert.Appearance.BackColor = System.Drawing.Color.White
        Me.lbl_kunde_wert.Appearance.Options.UseBackColor = True
        Me.lbl_kunde_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_kunde_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_kunde_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_kunde_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_kunde_wert.Location = New System.Drawing.Point(130, 29)
        Me.lbl_kunde_wert.Name = "lbl_kunde_wert"
        Me.lbl_kunde_wert.Size = New System.Drawing.Size(500, 21)
        Me.lbl_kunde_wert.TabIndex = 5
        Me.lbl_kunde_wert.Text = "-"
        '
        'lbl_znr_ind
        '
        Me.lbl_znr_ind.Appearance.Options.UseTextOptions = True
        Me.lbl_znr_ind.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_znr_ind.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_znr_ind.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_znr_ind.Location = New System.Drawing.Point(6, 52)
        Me.lbl_znr_ind.Name = "lbl_znr_ind"
        Me.lbl_znr_ind.Size = New System.Drawing.Size(120, 21)
        Me.lbl_znr_ind.TabIndex = 2
        Me.lbl_znr_ind.Text = "Zeichnung-Nr. / Index"
        '
        'lbl_kunde
        '
        Me.lbl_kunde.Appearance.Options.UseTextOptions = True
        Me.lbl_kunde.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_kunde.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_kunde.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_kunde.Location = New System.Drawing.Point(6, 29)
        Me.lbl_kunde.Name = "lbl_kunde"
        Me.lbl_kunde.Size = New System.Drawing.Size(120, 21)
        Me.lbl_kunde.TabIndex = 0
        Me.lbl_kunde.Text = "Kunde"
        '
        'PanelControl_ae
        '
        Me.PanelControl_ae.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.PanelControl_ae.Appearance.Options.UseBackColor = True
        Me.PanelControl_ae.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PanelControl_ae.Controls.Add(Me.lbl_vkwg)
        Me.PanelControl_ae.Controls.Add(Me.cbx_vkwg_produkt)
        Me.PanelControl_ae.Controls.Add(Me.cbx_vkwg_anwendung)
        Me.PanelControl_ae.Controls.Add(Me.cbx_vkwg_anwendungssegment)
        Me.PanelControl_ae.Controls.Add(Me.cbx_vkwg_branche)
        Me.PanelControl_ae.Controls.Add(Me.lbl_ae_name)
        Me.PanelControl_ae.Controls.Add(Me.cbx_ae_name)
        Me.PanelControl_ae.Controls.Add(Me.DateEdit_ae)
        Me.PanelControl_ae.Controls.Add(Me.lbl_ae_result_all_wert)
        Me.PanelControl_ae.Controls.Add(Me.lbl_ae_result_all)
        Me.PanelControl_ae.Controls.Add(Me.GridControl_ae)
        Me.PanelControl_ae.Controls.Add(Me.lbl_ae)
        Me.PanelControl_ae.Location = New System.Drawing.Point(6, 112)
        Me.PanelControl_ae.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl_ae.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl_ae.Name = "PanelControl_ae"
        Me.PanelControl_ae.Size = New System.Drawing.Size(958, 268)
        Me.PanelControl_ae.TabIndex = 1
        '
        'lbl_vkwg
        '
        Me.lbl_vkwg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_vkwg.Appearance.Options.UseTextOptions = True
        Me.lbl_vkwg.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_vkwg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_vkwg.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_vkwg.Location = New System.Drawing.Point(14, 239)
        Me.lbl_vkwg.Name = "lbl_vkwg"
        Me.lbl_vkwg.Size = New System.Drawing.Size(50, 21)
        Me.lbl_vkwg.TabIndex = 19
        Me.lbl_vkwg.Text = "VKWG"
        '
        'cbx_vkwg_produkt
        '
        Me.cbx_vkwg_produkt.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_AngebotReg.produkt", True))
        Me.cbx_vkwg_produkt.EditValue = "Produkt"
        Me.cbx_vkwg_produkt.Location = New System.Drawing.Point(727, 240)
        Me.cbx_vkwg_produkt.Name = "cbx_vkwg_produkt"
        Me.cbx_vkwg_produkt.Properties.AutoHeight = False
        Me.cbx_vkwg_produkt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbx_vkwg_produkt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbx_vkwg_produkt.Properties.ReadOnly = True
        Me.cbx_vkwg_produkt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbx_vkwg_produkt.Size = New System.Drawing.Size(200, 21)
        Me.cbx_vkwg_produkt.TabIndex = 18
        '
        'DataSet_hsb
        '
        Me.DataSet_hsb.DataSetName = "DataSet_tracking"
        Me.DataSet_hsb.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbx_vkwg_anwendung
        '
        Me.cbx_vkwg_anwendung.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_AngebotReg.anwendung", True))
        Me.cbx_vkwg_anwendung.EditValue = "Anwendung"
        Me.cbx_vkwg_anwendung.Location = New System.Drawing.Point(513, 240)
        Me.cbx_vkwg_anwendung.Name = "cbx_vkwg_anwendung"
        Me.cbx_vkwg_anwendung.Properties.AutoHeight = False
        Me.cbx_vkwg_anwendung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbx_vkwg_anwendung.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbx_vkwg_anwendung.Properties.ReadOnly = True
        Me.cbx_vkwg_anwendung.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbx_vkwg_anwendung.Size = New System.Drawing.Size(200, 21)
        Me.cbx_vkwg_anwendung.TabIndex = 17
        '
        'cbx_vkwg_anwendungssegment
        '
        Me.cbx_vkwg_anwendungssegment.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_AngebotReg.anwendungssegment", True))
        Me.cbx_vkwg_anwendungssegment.EditValue = "Anwendungssegment"
        Me.cbx_vkwg_anwendungssegment.Location = New System.Drawing.Point(295, 240)
        Me.cbx_vkwg_anwendungssegment.Name = "cbx_vkwg_anwendungssegment"
        Me.cbx_vkwg_anwendungssegment.Properties.AutoHeight = False
        Me.cbx_vkwg_anwendungssegment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbx_vkwg_anwendungssegment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbx_vkwg_anwendungssegment.Properties.ReadOnly = True
        Me.cbx_vkwg_anwendungssegment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbx_vkwg_anwendungssegment.Size = New System.Drawing.Size(200, 21)
        Me.cbx_vkwg_anwendungssegment.TabIndex = 16
        '
        'cbx_vkwg_branche
        '
        Me.cbx_vkwg_branche.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_AngebotReg.branche", True))
        Me.cbx_vkwg_branche.EditValue = "Branche"
        Me.cbx_vkwg_branche.Location = New System.Drawing.Point(76, 240)
        Me.cbx_vkwg_branche.Name = "cbx_vkwg_branche"
        Me.cbx_vkwg_branche.Properties.AutoHeight = False
        Me.cbx_vkwg_branche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbx_vkwg_branche.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbx_vkwg_branche.Properties.ReadOnly = True
        Me.cbx_vkwg_branche.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbx_vkwg_branche.Size = New System.Drawing.Size(200, 21)
        Me.cbx_vkwg_branche.TabIndex = 14
        '
        'lbl_ae_name
        '
        Me.lbl_ae_name.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_ae_name.Appearance.Options.UseTextOptions = True
        Me.lbl_ae_name.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_ae_name.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_ae_name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_ae_name.Location = New System.Drawing.Point(382, 216)
        Me.lbl_ae_name.Name = "lbl_ae_name"
        Me.lbl_ae_name.Size = New System.Drawing.Size(70, 21)
        Me.lbl_ae_name.TabIndex = 13
        Me.lbl_ae_name.Text = "freigegeben"
        '
        'cbx_ae_name
        '
        Me.cbx_ae_name.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_hsb_result.name_ae", True))
        Me.cbx_ae_name.Location = New System.Drawing.Point(454, 216)
        Me.cbx_ae_name.Name = "cbx_ae_name"
        Me.cbx_ae_name.Properties.AutoHeight = False
        Me.cbx_ae_name.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbx_ae_name.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbx_ae_name.Properties.ReadOnly = True
        Me.cbx_ae_name.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbx_ae_name.Size = New System.Drawing.Size(200, 21)
        Me.cbx_ae_name.TabIndex = 12
        '
        'DateEdit_ae
        '
        Me.DateEdit_ae.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_hsb_result.date_time_result_ae", True))
        Me.DateEdit_ae.EditValue = Nothing
        Me.DateEdit_ae.Location = New System.Drawing.Point(694, 216)
        Me.DateEdit_ae.Name = "DateEdit_ae"
        Me.DateEdit_ae.Properties.AutoHeight = False
        Me.DateEdit_ae.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.DateEdit_ae.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_ae.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEdit_ae.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_ae.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.DateEdit_ae.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit_ae.Properties.NullDate = """"""
        Me.DateEdit_ae.Properties.NullText = "kein Datum"
        Me.DateEdit_ae.Properties.ReadOnly = True
        Me.DateEdit_ae.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit_ae.Size = New System.Drawing.Size(100, 21)
        Me.DateEdit_ae.TabIndex = 11
        '
        'lbl_ae_result_all_wert
        '
        Me.lbl_ae_result_all_wert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_ae_result_all_wert.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_ae_result_all_wert.Appearance.Options.UseBackColor = True
        Me.lbl_ae_result_all_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_ae_result_all_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbl_ae_result_all_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_ae_result_all_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_ae_result_all_wert.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DataSet_hsb, "DataTable_hsb_result.result_ae", True))
        Me.lbl_ae_result_all_wert.Location = New System.Drawing.Point(892, 216)
        Me.lbl_ae_result_all_wert.Name = "lbl_ae_result_all_wert"
        Me.lbl_ae_result_all_wert.Size = New System.Drawing.Size(60, 21)
        Me.lbl_ae_result_all_wert.TabIndex = 10
        Me.lbl_ae_result_all_wert.Text = "-"
        '
        'lbl_ae_result_all
        '
        Me.lbl_ae_result_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_ae_result_all.Appearance.Options.UseTextOptions = True
        Me.lbl_ae_result_all.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_ae_result_all.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_ae_result_all.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_ae_result_all.Location = New System.Drawing.Point(820, 216)
        Me.lbl_ae_result_all.Name = "lbl_ae_result_all"
        Me.lbl_ae_result_all.Size = New System.Drawing.Size(70, 21)
        Me.lbl_ae_result_all.TabIndex = 9
        Me.lbl_ae_result_all.Text = "Entscheidung"
        '
        'GridControl_ae
        '
        Me.GridControl_ae.Location = New System.Drawing.Point(6, 34)
        Me.GridControl_ae.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl_ae.MainView = Me.GridView_ae
        Me.GridControl_ae.Name = "GridControl_ae"
        Me.GridControl_ae.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoExEdit_ae, Me.RepositoryItemComboBox_result_ae, Me.RepositoryItemCheckEdit_ae})
        Me.GridControl_ae.Size = New System.Drawing.Size(946, 175)
        Me.GridControl_ae.TabIndex = 2
        Me.GridControl_ae.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_ae})
        '
        'GridView_ae
        '
        Me.GridView_ae.Appearance.EvenRow.BackColor = System.Drawing.Color.Lavender
        Me.GridView_ae.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView_ae.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.GridView_ae.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView_ae.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.col_ae_id, Me.col_ae_id_ar, Me.col_ae_area, Me.col_ae_attribute, Me.col_ae_match_ext, Me.col_ae_match_int, Me.col_ae_result_attribute, Me.col_ae_tool, Me.col_ae_rem_int, Me.col_ae_rem_cust, Me.col_ae_name, Me.col_ae_date_time_result, Me.col_ae_result_all, Me.col_ae_order})
        Me.GridView_ae.GridControl = Me.GridControl_ae
        Me.GridView_ae.Name = "GridView_ae"
        Me.GridView_ae.OptionsBehavior.ReadOnly = True
        Me.GridView_ae.OptionsView.AllowHtmlDrawHeaders = True
        Me.GridView_ae.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView_ae.OptionsView.EnableAppearanceOddRow = True
        Me.GridView_ae.OptionsView.ShowGroupPanel = False
        '
        'col_ae_id
        '
        Me.col_ae_id.Caption = "id"
        Me.col_ae_id.FieldName = "id"
        Me.col_ae_id.Name = "col_ae_id"
        '
        'col_ae_id_ar
        '
        Me.col_ae_id_ar.Caption = "id AR"
        Me.col_ae_id_ar.FieldName = "id_angebot_reg"
        Me.col_ae_id_ar.Name = "col_ae_id_ar"
        '
        'col_ae_area
        '
        Me.col_ae_area.Caption = "Bereich"
        Me.col_ae_area.FieldName = "area"
        Me.col_ae_area.Name = "col_ae_area"
        '
        'col_ae_attribute
        '
        Me.col_ae_attribute.Caption = "Merkmal"
        Me.col_ae_attribute.FieldName = "attribute"
        Me.col_ae_attribute.MaxWidth = 180
        Me.col_ae_attribute.MinWidth = 180
        Me.col_ae_attribute.Name = "col_ae_attribute"
        Me.col_ae_attribute.Visible = True
        Me.col_ae_attribute.VisibleIndex = 0
        Me.col_ae_attribute.Width = 180
        '
        'col_ae_match_ext
        '
        Me.col_ae_match_ext.MaxWidth = 60
        Me.col_ae_match_ext.MinWidth = 60
        Me.col_ae_match_ext.Name = "col_ae_match_ext"
        Me.col_ae_match_ext.Visible = True
        Me.col_ae_match_ext.VisibleIndex = 1
        Me.col_ae_match_ext.Width = 60
        '
        'col_ae_match_int
        '
        Me.col_ae_match_int.Caption = "zutreffend"
        Me.col_ae_match_int.ColumnEdit = Me.RepositoryItemCheckEdit_ae
        Me.col_ae_match_int.FieldName = "match_int"
        Me.col_ae_match_int.MaxWidth = 60
        Me.col_ae_match_int.MinWidth = 60
        Me.col_ae_match_int.Name = "col_ae_match_int"
        Me.col_ae_match_int.Visible = True
        Me.col_ae_match_int.VisibleIndex = 2
        Me.col_ae_match_int.Width = 60
        '
        'RepositoryItemCheckEdit_ae
        '
        Me.RepositoryItemCheckEdit_ae.AutoHeight = False
        Me.RepositoryItemCheckEdit_ae.Name = "RepositoryItemCheckEdit_ae"
        Me.RepositoryItemCheckEdit_ae.ValueChecked = CType(1, Short)
        Me.RepositoryItemCheckEdit_ae.ValueUnchecked = CType(0, Short)
        '
        'col_ae_result_attribute
        '
        Me.col_ae_result_attribute.Caption = "Ergebnis"
        Me.col_ae_result_attribute.ColumnEdit = Me.RepositoryItemComboBox_result_ae
        Me.col_ae_result_attribute.FieldName = "result_attribute"
        Me.col_ae_result_attribute.MaxWidth = 60
        Me.col_ae_result_attribute.MinWidth = 60
        Me.col_ae_result_attribute.Name = "col_ae_result_attribute"
        Me.col_ae_result_attribute.Visible = True
        Me.col_ae_result_attribute.VisibleIndex = 3
        Me.col_ae_result_attribute.Width = 60
        '
        'RepositoryItemComboBox_result_ae
        '
        Me.RepositoryItemComboBox_result_ae.AutoHeight = False
        Me.RepositoryItemComboBox_result_ae.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox_result_ae.Items.AddRange(New Object() {"-", "go", "go but", "no go"})
        Me.RepositoryItemComboBox_result_ae.Name = "RepositoryItemComboBox_result_ae"
        '
        'col_ae_tool
        '
        Me.col_ae_tool.MaxWidth = 70
        Me.col_ae_tool.MinWidth = 70
        Me.col_ae_tool.Name = "col_ae_tool"
        Me.col_ae_tool.Visible = True
        Me.col_ae_tool.VisibleIndex = 4
        Me.col_ae_tool.Width = 70
        '
        'col_ae_rem_int
        '
        Me.col_ae_rem_int.Caption = "Bemerkungen, intern"
        Me.col_ae_rem_int.ColumnEdit = Me.RepositoryItemMemoExEdit_ae
        Me.col_ae_rem_int.FieldName = "rem_int"
        Me.col_ae_rem_int.MaxWidth = 240
        Me.col_ae_rem_int.MinWidth = 240
        Me.col_ae_rem_int.Name = "col_ae_rem_int"
        Me.col_ae_rem_int.Visible = True
        Me.col_ae_rem_int.VisibleIndex = 5
        Me.col_ae_rem_int.Width = 240
        '
        'RepositoryItemMemoExEdit_ae
        '
        Me.RepositoryItemMemoExEdit_ae.AutoHeight = False
        Me.RepositoryItemMemoExEdit_ae.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit_ae.Name = "RepositoryItemMemoExEdit_ae"
        Me.RepositoryItemMemoExEdit_ae.ShowIcon = False
        '
        'col_ae_rem_cust
        '
        Me.col_ae_rem_cust.Caption = "Bemerkungen für Kunden"
        Me.col_ae_rem_cust.ColumnEdit = Me.RepositoryItemMemoExEdit_ae
        Me.col_ae_rem_cust.FieldName = "rem_cust"
        Me.col_ae_rem_cust.MaxWidth = 240
        Me.col_ae_rem_cust.MinWidth = 240
        Me.col_ae_rem_cust.Name = "col_ae_rem_cust"
        Me.col_ae_rem_cust.Visible = True
        Me.col_ae_rem_cust.VisibleIndex = 6
        Me.col_ae_rem_cust.Width = 240
        '
        'col_ae_name
        '
        Me.col_ae_name.Caption = "Name"
        Me.col_ae_name.FieldName = "name"
        Me.col_ae_name.Name = "col_ae_name"
        '
        'col_ae_date_time_result
        '
        Me.col_ae_date_time_result.Caption = "Datum"
        Me.col_ae_date_time_result.FieldName = "date_time_result"
        Me.col_ae_date_time_result.Name = "col_ae_date_time_result"
        '
        'col_ae_result_all
        '
        Me.col_ae_result_all.Caption = "Ergebnis in Summe"
        Me.col_ae_result_all.FieldName = "result_all"
        Me.col_ae_result_all.Name = "col_ae_result_all"
        '
        'col_ae_order
        '
        Me.col_ae_order.Caption = "Reihenfolge"
        Me.col_ae_order.FieldName = "order"
        Me.col_ae_order.Name = "col_ae_order"
        '
        'lbl_ae
        '
        Me.lbl_ae.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ae.Appearance.Options.UseFont = True
        Me.lbl_ae.Appearance.Options.UseTextOptions = True
        Me.lbl_ae.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_ae.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_ae.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_ae.Location = New System.Drawing.Point(6, 6)
        Me.lbl_ae.Name = "lbl_ae"
        Me.lbl_ae.Size = New System.Drawing.Size(150, 21)
        Me.lbl_ae.TabIndex = 1
        Me.lbl_ae.Text = "Anwendungsentwicklung"
        '
        'PanelControl_prod
        '
        Me.PanelControl_prod.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PanelControl_prod.Controls.Add(Me.lbl_prod_name)
        Me.PanelControl_prod.Controls.Add(Me.cbx_prod_name)
        Me.PanelControl_prod.Controls.Add(Me.DateEdit_prod)
        Me.PanelControl_prod.Controls.Add(Me.lbl_prod_result_all_wert)
        Me.PanelControl_prod.Controls.Add(Me.lbl_prod_result_all)
        Me.PanelControl_prod.Controls.Add(Me.GridControl_prod)
        Me.PanelControl_prod.Controls.Add(Me.lbl_prod)
        Me.PanelControl_prod.Location = New System.Drawing.Point(6, 386)
        Me.PanelControl_prod.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl_prod.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl_prod.Name = "PanelControl_prod"
        Me.PanelControl_prod.Size = New System.Drawing.Size(958, 346)
        Me.PanelControl_prod.TabIndex = 2
        '
        'lbl_prod_name
        '
        Me.lbl_prod_name.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_prod_name.Appearance.Options.UseTextOptions = True
        Me.lbl_prod_name.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_prod_name.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_prod_name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_prod_name.Location = New System.Drawing.Point(382, 319)
        Me.lbl_prod_name.Name = "lbl_prod_name"
        Me.lbl_prod_name.Size = New System.Drawing.Size(70, 21)
        Me.lbl_prod_name.TabIndex = 16
        Me.lbl_prod_name.Text = "freigegeben"
        '
        'cbx_prod_name
        '
        Me.cbx_prod_name.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_hsb_result.name_prod", True))
        Me.cbx_prod_name.Location = New System.Drawing.Point(454, 319)
        Me.cbx_prod_name.Name = "cbx_prod_name"
        Me.cbx_prod_name.Properties.AutoHeight = False
        Me.cbx_prod_name.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbx_prod_name.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbx_prod_name.Properties.ReadOnly = True
        Me.cbx_prod_name.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbx_prod_name.Size = New System.Drawing.Size(200, 21)
        Me.cbx_prod_name.TabIndex = 15
        '
        'DateEdit_prod
        '
        Me.DateEdit_prod.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_hsb_result.date_time_result_prod", True))
        Me.DateEdit_prod.EditValue = Nothing
        Me.DateEdit_prod.Location = New System.Drawing.Point(694, 319)
        Me.DateEdit_prod.Name = "DateEdit_prod"
        Me.DateEdit_prod.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEdit_prod.Properties.AutoHeight = False
        Me.DateEdit_prod.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.DateEdit_prod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_prod.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_prod.Properties.ReadOnly = True
        Me.DateEdit_prod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit_prod.Size = New System.Drawing.Size(100, 21)
        Me.DateEdit_prod.TabIndex = 14
        '
        'lbl_prod_result_all_wert
        '
        Me.lbl_prod_result_all_wert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_prod_result_all_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_prod_result_all_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbl_prod_result_all_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_prod_result_all_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_prod_result_all_wert.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DataSet_hsb, "DataTable_hsb_result.result_prod", True))
        Me.lbl_prod_result_all_wert.Location = New System.Drawing.Point(892, 319)
        Me.lbl_prod_result_all_wert.Name = "lbl_prod_result_all_wert"
        Me.lbl_prod_result_all_wert.Size = New System.Drawing.Size(60, 21)
        Me.lbl_prod_result_all_wert.TabIndex = 12
        Me.lbl_prod_result_all_wert.Text = "-"
        '
        'lbl_prod_result_all
        '
        Me.lbl_prod_result_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_prod_result_all.Appearance.Options.UseTextOptions = True
        Me.lbl_prod_result_all.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_prod_result_all.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_prod_result_all.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_prod_result_all.Location = New System.Drawing.Point(820, 319)
        Me.lbl_prod_result_all.Name = "lbl_prod_result_all"
        Me.lbl_prod_result_all.Size = New System.Drawing.Size(70, 21)
        Me.lbl_prod_result_all.TabIndex = 11
        Me.lbl_prod_result_all.Text = "Entscheidung"
        '
        'GridControl_prod
        '
        Me.GridControl_prod.Location = New System.Drawing.Point(6, 33)
        Me.GridControl_prod.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl_prod.MainView = Me.GridView_prod
        Me.GridControl_prod.Name = "GridControl_prod"
        Me.GridControl_prod.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox_result_prod, Me.RepositoryItemMemoExEdit_prod, Me.RepositoryItemCheckEdit_prod})
        Me.GridControl_prod.Size = New System.Drawing.Size(946, 278)
        Me.GridControl_prod.TabIndex = 3
        Me.GridControl_prod.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_prod})
        '
        'GridView_prod
        '
        Me.GridView_prod.Appearance.EvenRow.BackColor = System.Drawing.Color.Lavender
        Me.GridView_prod.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView_prod.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.GridView_prod.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView_prod.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.col_prod_id, Me.col_prod_id_ar, Me.col_prod_area, Me.col_prod_attribute, Me.col_prod_match_ext, Me.col_prod_match_int, Me.col_prod_result_attribute, Me.col_prod_tool, Me.col_prod_rem_int, Me.col_prod_rem_cust, Me.col_prod_name, Me.col_prod_date_time_result, Me.col_produ_result_all, Me.col_prod_order})
        Me.GridView_prod.GridControl = Me.GridControl_prod
        Me.GridView_prod.Name = "GridView_prod"
        Me.GridView_prod.OptionsBehavior.ReadOnly = True
        Me.GridView_prod.OptionsView.AllowHtmlDrawHeaders = True
        Me.GridView_prod.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView_prod.OptionsView.EnableAppearanceOddRow = True
        Me.GridView_prod.OptionsView.ShowGroupPanel = False
        '
        'col_prod_id
        '
        Me.col_prod_id.Caption = "id"
        Me.col_prod_id.FieldName = "id"
        Me.col_prod_id.Name = "col_prod_id"
        '
        'col_prod_id_ar
        '
        Me.col_prod_id_ar.Caption = "id AR"
        Me.col_prod_id_ar.FieldName = "id_angebot_reg"
        Me.col_prod_id_ar.Name = "col_prod_id_ar"
        '
        'col_prod_area
        '
        Me.col_prod_area.Caption = "Bereich"
        Me.col_prod_area.FieldName = "area"
        Me.col_prod_area.Name = "col_prod_area"
        '
        'col_prod_attribute
        '
        Me.col_prod_attribute.Caption = "Merkmal"
        Me.col_prod_attribute.FieldName = "attribute"
        Me.col_prod_attribute.MaxWidth = 180
        Me.col_prod_attribute.MinWidth = 180
        Me.col_prod_attribute.Name = "col_prod_attribute"
        Me.col_prod_attribute.Visible = True
        Me.col_prod_attribute.VisibleIndex = 0
        Me.col_prod_attribute.Width = 180
        '
        'col_prod_match_ext
        '
        Me.col_prod_match_ext.AppearanceHeader.Options.UseTextOptions = True
        Me.col_prod_match_ext.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.col_prod_match_ext.Caption = "zutreffend<br>extern"
        Me.col_prod_match_ext.ColumnEdit = Me.RepositoryItemCheckEdit_prod
        Me.col_prod_match_ext.FieldName = "match_ext"
        Me.col_prod_match_ext.MaxWidth = 60
        Me.col_prod_match_ext.MinWidth = 60
        Me.col_prod_match_ext.Name = "col_prod_match_ext"
        Me.col_prod_match_ext.Visible = True
        Me.col_prod_match_ext.VisibleIndex = 1
        Me.col_prod_match_ext.Width = 60
        '
        'RepositoryItemCheckEdit_prod
        '
        Me.RepositoryItemCheckEdit_prod.AutoHeight = False
        Me.RepositoryItemCheckEdit_prod.Name = "RepositoryItemCheckEdit_prod"
        Me.RepositoryItemCheckEdit_prod.ValueChecked = CType(1, Short)
        Me.RepositoryItemCheckEdit_prod.ValueUnchecked = CType(0, Short)
        '
        'col_prod_match_int
        '
        Me.col_prod_match_int.AppearanceHeader.Options.UseTextOptions = True
        Me.col_prod_match_int.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.col_prod_match_int.Caption = "zutreffend<br>intern"
        Me.col_prod_match_int.ColumnEdit = Me.RepositoryItemCheckEdit_prod
        Me.col_prod_match_int.FieldName = "match_int"
        Me.col_prod_match_int.MaxWidth = 60
        Me.col_prod_match_int.MinWidth = 60
        Me.col_prod_match_int.Name = "col_prod_match_int"
        Me.col_prod_match_int.Visible = True
        Me.col_prod_match_int.VisibleIndex = 2
        Me.col_prod_match_int.Width = 60
        '
        'col_prod_result_attribute
        '
        Me.col_prod_result_attribute.Caption = "Ergebnis"
        Me.col_prod_result_attribute.ColumnEdit = Me.RepositoryItemComboBox_result_prod
        Me.col_prod_result_attribute.FieldName = "result_attribute"
        Me.col_prod_result_attribute.MaxWidth = 60
        Me.col_prod_result_attribute.MinWidth = 60
        Me.col_prod_result_attribute.Name = "col_prod_result_attribute"
        Me.col_prod_result_attribute.Visible = True
        Me.col_prod_result_attribute.VisibleIndex = 3
        Me.col_prod_result_attribute.Width = 60
        '
        'RepositoryItemComboBox_result_prod
        '
        Me.RepositoryItemComboBox_result_prod.AutoHeight = False
        Me.RepositoryItemComboBox_result_prod.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox_result_prod.Items.AddRange(New Object() {"-", "go", "go but", "no go"})
        Me.RepositoryItemComboBox_result_prod.Name = "RepositoryItemComboBox_result_prod"
        Me.RepositoryItemComboBox_result_prod.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'col_prod_tool
        '
        Me.col_prod_tool.AppearanceHeader.Options.UseTextOptions = True
        Me.col_prod_tool.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.col_prod_tool.Caption = "Werkzeuge<br>vorhanden"
        Me.col_prod_tool.ColumnEdit = Me.RepositoryItemCheckEdit_prod
        Me.col_prod_tool.FieldName = "tool_exist"
        Me.col_prod_tool.MaxWidth = 70
        Me.col_prod_tool.MinWidth = 70
        Me.col_prod_tool.Name = "col_prod_tool"
        Me.col_prod_tool.Visible = True
        Me.col_prod_tool.VisibleIndex = 4
        Me.col_prod_tool.Width = 70
        '
        'col_prod_rem_int
        '
        Me.col_prod_rem_int.Caption = "Bemerkungen, intern"
        Me.col_prod_rem_int.ColumnEdit = Me.RepositoryItemMemoExEdit_prod
        Me.col_prod_rem_int.FieldName = "rem_int"
        Me.col_prod_rem_int.MaxWidth = 240
        Me.col_prod_rem_int.MinWidth = 130
        Me.col_prod_rem_int.Name = "col_prod_rem_int"
        Me.col_prod_rem_int.Visible = True
        Me.col_prod_rem_int.VisibleIndex = 5
        Me.col_prod_rem_int.Width = 130
        '
        'RepositoryItemMemoExEdit_prod
        '
        Me.RepositoryItemMemoExEdit_prod.AutoHeight = False
        Me.RepositoryItemMemoExEdit_prod.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit_prod.Name = "RepositoryItemMemoExEdit_prod"
        Me.RepositoryItemMemoExEdit_prod.ShowIcon = False
        '
        'col_prod_rem_cust
        '
        Me.col_prod_rem_cust.Caption = "Bemerkungen für Kunden"
        Me.col_prod_rem_cust.ColumnEdit = Me.RepositoryItemMemoExEdit_prod
        Me.col_prod_rem_cust.FieldName = "rem_cust"
        Me.col_prod_rem_cust.MaxWidth = 240
        Me.col_prod_rem_cust.MinWidth = 240
        Me.col_prod_rem_cust.Name = "col_prod_rem_cust"
        Me.col_prod_rem_cust.Visible = True
        Me.col_prod_rem_cust.VisibleIndex = 6
        Me.col_prod_rem_cust.Width = 240
        '
        'col_prod_name
        '
        Me.col_prod_name.Caption = "Name"
        Me.col_prod_name.FieldName = "name"
        Me.col_prod_name.Name = "col_prod_name"
        '
        'col_prod_date_time_result
        '
        Me.col_prod_date_time_result.Caption = "Datum"
        Me.col_prod_date_time_result.FieldName = "date_time_result"
        Me.col_prod_date_time_result.Name = "col_prod_date_time_result"
        '
        'col_produ_result_all
        '
        Me.col_produ_result_all.Caption = "Ergebnis in Summe"
        Me.col_produ_result_all.FieldName = "result_all"
        Me.col_produ_result_all.Name = "col_produ_result_all"
        '
        'col_prod_order
        '
        Me.col_prod_order.Caption = "Reihenfolge"
        Me.col_prod_order.FieldName = "order"
        Me.col_prod_order.Name = "col_prod_order"
        '
        'lbl_prod
        '
        Me.lbl_prod.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prod.Appearance.Options.UseFont = True
        Me.lbl_prod.Appearance.Options.UseTextOptions = True
        Me.lbl_prod.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_prod.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_prod.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_prod.Location = New System.Drawing.Point(6, 6)
        Me.lbl_prod.Name = "lbl_prod"
        Me.lbl_prod.Size = New System.Drawing.Size(150, 21)
        Me.lbl_prod.TabIndex = 2
        Me.lbl_prod.Text = "Produktion"
        '
        'PanelControl_qs
        '
        Me.PanelControl_qs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PanelControl_qs.Controls.Add(Me.lbl_qs_name)
        Me.PanelControl_qs.Controls.Add(Me.cbx_qs_name)
        Me.PanelControl_qs.Controls.Add(Me.DateEdit_qs)
        Me.PanelControl_qs.Controls.Add(Me.lbl_qs_result_all_wert)
        Me.PanelControl_qs.Controls.Add(Me.lbl_qs_result_all)
        Me.PanelControl_qs.Controls.Add(Me.GridControl_qs)
        Me.PanelControl_qs.Controls.Add(Me.lbl_qs)
        Me.PanelControl_qs.Location = New System.Drawing.Point(6, 738)
        Me.PanelControl_qs.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl_qs.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl_qs.Name = "PanelControl_qs"
        Me.PanelControl_qs.Size = New System.Drawing.Size(958, 184)
        Me.PanelControl_qs.TabIndex = 3
        '
        'lbl_qs_name
        '
        Me.lbl_qs_name.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_qs_name.Appearance.Options.UseTextOptions = True
        Me.lbl_qs_name.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_qs_name.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_qs_name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_qs_name.Location = New System.Drawing.Point(382, 157)
        Me.lbl_qs_name.Name = "lbl_qs_name"
        Me.lbl_qs_name.Size = New System.Drawing.Size(70, 21)
        Me.lbl_qs_name.TabIndex = 19
        Me.lbl_qs_name.Text = "freigegeben"
        '
        'cbx_qs_name
        '
        Me.cbx_qs_name.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_hsb_result.name_qs", True))
        Me.cbx_qs_name.Location = New System.Drawing.Point(454, 157)
        Me.cbx_qs_name.Name = "cbx_qs_name"
        Me.cbx_qs_name.Properties.AutoHeight = False
        Me.cbx_qs_name.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbx_qs_name.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbx_qs_name.Properties.ReadOnly = True
        Me.cbx_qs_name.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbx_qs_name.Size = New System.Drawing.Size(200, 21)
        Me.cbx_qs_name.TabIndex = 18
        '
        'DateEdit_qs
        '
        Me.DateEdit_qs.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_hsb_result.date_time_result_qs", True))
        Me.DateEdit_qs.EditValue = Nothing
        Me.DateEdit_qs.Location = New System.Drawing.Point(694, 157)
        Me.DateEdit_qs.Name = "DateEdit_qs"
        Me.DateEdit_qs.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEdit_qs.Properties.AutoHeight = False
        Me.DateEdit_qs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.DateEdit_qs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_qs.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_qs.Properties.ReadOnly = True
        Me.DateEdit_qs.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit_qs.Size = New System.Drawing.Size(100, 21)
        Me.DateEdit_qs.TabIndex = 17
        '
        'lbl_qs_result_all_wert
        '
        Me.lbl_qs_result_all_wert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_qs_result_all_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_qs_result_all_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbl_qs_result_all_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_qs_result_all_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_qs_result_all_wert.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DataSet_hsb, "DataTable_hsb_result.result_qs", True))
        Me.lbl_qs_result_all_wert.Location = New System.Drawing.Point(892, 157)
        Me.lbl_qs_result_all_wert.Name = "lbl_qs_result_all_wert"
        Me.lbl_qs_result_all_wert.Size = New System.Drawing.Size(60, 21)
        Me.lbl_qs_result_all_wert.TabIndex = 12
        Me.lbl_qs_result_all_wert.Text = "-"
        '
        'lbl_qs_result_all
        '
        Me.lbl_qs_result_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_qs_result_all.Appearance.Options.UseTextOptions = True
        Me.lbl_qs_result_all.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_qs_result_all.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_qs_result_all.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_qs_result_all.Location = New System.Drawing.Point(820, 157)
        Me.lbl_qs_result_all.Name = "lbl_qs_result_all"
        Me.lbl_qs_result_all.Size = New System.Drawing.Size(70, 21)
        Me.lbl_qs_result_all.TabIndex = 11
        Me.lbl_qs_result_all.Text = "Entscheidung"
        '
        'GridControl_qs
        '
        Me.GridControl_qs.Location = New System.Drawing.Point(6, 34)
        Me.GridControl_qs.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl_qs.MainView = Me.GridView_qs
        Me.GridControl_qs.Name = "GridControl_qs"
        Me.GridControl_qs.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox_result_qs, Me.RepositoryItemMemoExEdit_qs, Me.RepositoryItemCheckEdit_qs})
        Me.GridControl_qs.Size = New System.Drawing.Size(946, 116)
        Me.GridControl_qs.TabIndex = 4
        Me.GridControl_qs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_qs})
        '
        'GridView_qs
        '
        Me.GridView_qs.Appearance.EvenRow.BackColor = System.Drawing.Color.Lavender
        Me.GridView_qs.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView_qs.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.GridView_qs.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView_qs.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.col_qs_id, Me.col_qs_id_ar, Me.col_qs_area, Me.col_qs_attribute, Me.col_qs_match_ext, Me.col_qs_match_int, Me.col_qs_result_attribute, Me.col_qs_tool, Me.col_qs_rem_int, Me.col_qs_rem_cust, Me.col_qs_name, Me.col_qs_date_time_result, Me.col_qs_result_all, Me.col_qs_order})
        Me.GridView_qs.GridControl = Me.GridControl_qs
        Me.GridView_qs.Name = "GridView_qs"
        Me.GridView_qs.OptionsBehavior.ReadOnly = True
        Me.GridView_qs.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView_qs.OptionsView.EnableAppearanceOddRow = True
        Me.GridView_qs.OptionsView.ShowGroupPanel = False
        '
        'col_qs_id
        '
        Me.col_qs_id.Caption = "id"
        Me.col_qs_id.FieldName = "id"
        Me.col_qs_id.Name = "col_qs_id"
        '
        'col_qs_id_ar
        '
        Me.col_qs_id_ar.Caption = "id AR"
        Me.col_qs_id_ar.FieldName = "id_angebot_reg"
        Me.col_qs_id_ar.Name = "col_qs_id_ar"
        '
        'col_qs_area
        '
        Me.col_qs_area.Caption = "Bereich"
        Me.col_qs_area.FieldName = "area"
        Me.col_qs_area.Name = "col_qs_area"
        '
        'col_qs_attribute
        '
        Me.col_qs_attribute.Caption = "Merkmal"
        Me.col_qs_attribute.FieldName = "attribute"
        Me.col_qs_attribute.MaxWidth = 180
        Me.col_qs_attribute.MinWidth = 180
        Me.col_qs_attribute.Name = "col_qs_attribute"
        Me.col_qs_attribute.Visible = True
        Me.col_qs_attribute.VisibleIndex = 0
        Me.col_qs_attribute.Width = 180
        '
        'col_qs_match_ext
        '
        Me.col_qs_match_ext.MaxWidth = 60
        Me.col_qs_match_ext.MinWidth = 60
        Me.col_qs_match_ext.Name = "col_qs_match_ext"
        Me.col_qs_match_ext.Visible = True
        Me.col_qs_match_ext.VisibleIndex = 1
        Me.col_qs_match_ext.Width = 60
        '
        'col_qs_match_int
        '
        Me.col_qs_match_int.Caption = "zutreffend"
        Me.col_qs_match_int.ColumnEdit = Me.RepositoryItemCheckEdit_qs
        Me.col_qs_match_int.FieldName = "match_int"
        Me.col_qs_match_int.MaxWidth = 60
        Me.col_qs_match_int.MinWidth = 60
        Me.col_qs_match_int.Name = "col_qs_match_int"
        Me.col_qs_match_int.Visible = True
        Me.col_qs_match_int.VisibleIndex = 2
        Me.col_qs_match_int.Width = 60
        '
        'RepositoryItemCheckEdit_qs
        '
        Me.RepositoryItemCheckEdit_qs.AutoHeight = False
        Me.RepositoryItemCheckEdit_qs.Name = "RepositoryItemCheckEdit_qs"
        Me.RepositoryItemCheckEdit_qs.ValueChecked = CType(1, Short)
        Me.RepositoryItemCheckEdit_qs.ValueUnchecked = CType(0, Short)
        '
        'col_qs_result_attribute
        '
        Me.col_qs_result_attribute.Caption = "Ergebnis"
        Me.col_qs_result_attribute.ColumnEdit = Me.RepositoryItemComboBox_result_qs
        Me.col_qs_result_attribute.FieldName = "result_attribute"
        Me.col_qs_result_attribute.MaxWidth = 60
        Me.col_qs_result_attribute.MinWidth = 60
        Me.col_qs_result_attribute.Name = "col_qs_result_attribute"
        Me.col_qs_result_attribute.Visible = True
        Me.col_qs_result_attribute.VisibleIndex = 3
        Me.col_qs_result_attribute.Width = 60
        '
        'RepositoryItemComboBox_result_qs
        '
        Me.RepositoryItemComboBox_result_qs.AutoHeight = False
        Me.RepositoryItemComboBox_result_qs.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox_result_qs.Items.AddRange(New Object() {"-", "go", "go but", "no go"})
        Me.RepositoryItemComboBox_result_qs.Name = "RepositoryItemComboBox_result_qs"
        Me.RepositoryItemComboBox_result_qs.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'col_qs_tool
        '
        Me.col_qs_tool.MaxWidth = 70
        Me.col_qs_tool.MinWidth = 70
        Me.col_qs_tool.Name = "col_qs_tool"
        Me.col_qs_tool.Visible = True
        Me.col_qs_tool.VisibleIndex = 4
        Me.col_qs_tool.Width = 70
        '
        'col_qs_rem_int
        '
        Me.col_qs_rem_int.Caption = "Bemerkungen, intern"
        Me.col_qs_rem_int.ColumnEdit = Me.RepositoryItemMemoExEdit_qs
        Me.col_qs_rem_int.FieldName = "rem_int"
        Me.col_qs_rem_int.MaxWidth = 240
        Me.col_qs_rem_int.MinWidth = 240
        Me.col_qs_rem_int.Name = "col_qs_rem_int"
        Me.col_qs_rem_int.Visible = True
        Me.col_qs_rem_int.VisibleIndex = 5
        Me.col_qs_rem_int.Width = 240
        '
        'RepositoryItemMemoExEdit_qs
        '
        Me.RepositoryItemMemoExEdit_qs.AutoHeight = False
        Me.RepositoryItemMemoExEdit_qs.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit_qs.Name = "RepositoryItemMemoExEdit_qs"
        Me.RepositoryItemMemoExEdit_qs.ShowIcon = False
        '
        'col_qs_rem_cust
        '
        Me.col_qs_rem_cust.Caption = "Bemerkungen für Kunden"
        Me.col_qs_rem_cust.ColumnEdit = Me.RepositoryItemMemoExEdit_qs
        Me.col_qs_rem_cust.FieldName = "rem_cust"
        Me.col_qs_rem_cust.MaxWidth = 240
        Me.col_qs_rem_cust.MinWidth = 240
        Me.col_qs_rem_cust.Name = "col_qs_rem_cust"
        Me.col_qs_rem_cust.Visible = True
        Me.col_qs_rem_cust.VisibleIndex = 6
        Me.col_qs_rem_cust.Width = 240
        '
        'col_qs_name
        '
        Me.col_qs_name.Caption = "Name"
        Me.col_qs_name.FieldName = "name"
        Me.col_qs_name.Name = "col_qs_name"
        '
        'col_qs_date_time_result
        '
        Me.col_qs_date_time_result.Caption = "Datum"
        Me.col_qs_date_time_result.FieldName = "date_time_result"
        Me.col_qs_date_time_result.Name = "col_qs_date_time_result"
        '
        'col_qs_result_all
        '
        Me.col_qs_result_all.Caption = "Ergebnis in Summe"
        Me.col_qs_result_all.FieldName = "result_all"
        Me.col_qs_result_all.Name = "col_qs_result_all"
        '
        'col_qs_order
        '
        Me.col_qs_order.Caption = "Reihenfolge"
        Me.col_qs_order.FieldName = "order"
        Me.col_qs_order.Name = "col_qs_order"
        '
        'lbl_qs
        '
        Me.lbl_qs.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_qs.Appearance.Options.UseFont = True
        Me.lbl_qs.Appearance.Options.UseTextOptions = True
        Me.lbl_qs.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_qs.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_qs.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_qs.Location = New System.Drawing.Point(6, 6)
        Me.lbl_qs.Name = "lbl_qs"
        Me.lbl_qs.Size = New System.Drawing.Size(150, 21)
        Me.lbl_qs.TabIndex = 3
        Me.lbl_qs.Text = "Qualität"
        '
        'PanelControl_footer
        '
        Me.PanelControl_footer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.PanelControl_footer.Controls.Add(Me.btn_freigeben)
        Me.PanelControl_footer.Controls.Add(Me.lbl_name_ae_hsb_all_wert)
        Me.PanelControl_footer.Controls.Add(Me.lbl_name_ae_hsb_all)
        Me.PanelControl_footer.Controls.Add(Me.DateEdit_all)
        Me.PanelControl_footer.Controls.Add(Me.lbl_result_hsb_all)
        Me.PanelControl_footer.Controls.Add(Me.LabelControl2)
        Me.PanelControl_footer.Controls.Add(Me.lbl_result_all)
        Me.PanelControl_footer.Location = New System.Drawing.Point(6, 928)
        Me.PanelControl_footer.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PanelControl_footer.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl_footer.Name = "PanelControl_footer"
        Me.PanelControl_footer.Size = New System.Drawing.Size(958, 37)
        Me.PanelControl_footer.TabIndex = 4
        '
        'btn_freigeben
        '
        Me.btn_freigeben.AppearanceHovered.BackColor = System.Drawing.Color.DimGray
        Me.btn_freigeben.AppearanceHovered.Options.UseBackColor = True
        Me.btn_freigeben.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btn_freigeben.Location = New System.Drawing.Point(180, 8)
        Me.btn_freigeben.Name = "btn_freigeben"
        Me.btn_freigeben.Size = New System.Drawing.Size(80, 21)
        Me.btn_freigeben.TabIndex = 22
        Me.btn_freigeben.Text = "HSB freigeben"
        '
        'lbl_name_ae_hsb_all_wert
        '
        Me.lbl_name_ae_hsb_all_wert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_name_ae_hsb_all_wert.Appearance.Options.UseTextOptions = True
        Me.lbl_name_ae_hsb_all_wert.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_name_ae_hsb_all_wert.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_name_ae_hsb_all_wert.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_name_ae_hsb_all_wert.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DataSet_hsb, "DataTable_hsb_result.name_all", True))
        Me.lbl_name_ae_hsb_all_wert.Location = New System.Drawing.Point(454, 8)
        Me.lbl_name_ae_hsb_all_wert.Name = "lbl_name_ae_hsb_all_wert"
        Me.lbl_name_ae_hsb_all_wert.Size = New System.Drawing.Size(200, 21)
        Me.lbl_name_ae_hsb_all_wert.TabIndex = 21
        Me.lbl_name_ae_hsb_all_wert.Text = "Name"
        '
        'lbl_name_ae_hsb_all
        '
        Me.lbl_name_ae_hsb_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_name_ae_hsb_all.Appearance.Options.UseTextOptions = True
        Me.lbl_name_ae_hsb_all.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_name_ae_hsb_all.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_name_ae_hsb_all.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_name_ae_hsb_all.Location = New System.Drawing.Point(382, 8)
        Me.lbl_name_ae_hsb_all.Name = "lbl_name_ae_hsb_all"
        Me.lbl_name_ae_hsb_all.Size = New System.Drawing.Size(70, 21)
        Me.lbl_name_ae_hsb_all.TabIndex = 20
        Me.lbl_name_ae_hsb_all.Text = "freigegeben"
        '
        'DateEdit_all
        '
        Me.DateEdit_all.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DataSet_hsb, "DataTable_hsb_result.date_time_result_all", True))
        Me.DateEdit_all.EditValue = Nothing
        Me.DateEdit_all.Location = New System.Drawing.Point(694, 8)
        Me.DateEdit_all.Name = "DateEdit_all"
        Me.DateEdit_all.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEdit_all.Properties.AutoHeight = False
        Me.DateEdit_all.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.DateEdit_all.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_all.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit_all.Properties.ReadOnly = True
        Me.DateEdit_all.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.DateEdit_all.Size = New System.Drawing.Size(100, 21)
        Me.DateEdit_all.TabIndex = 18
        '
        'lbl_result_hsb_all
        '
        Me.lbl_result_hsb_all.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_result_hsb_all.Appearance.Options.UseTextOptions = True
        Me.lbl_result_hsb_all.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbl_result_hsb_all.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_result_hsb_all.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_result_hsb_all.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DataSet_hsb, "DataTable_hsb_result.result_all", True))
        Me.lbl_result_hsb_all.Location = New System.Drawing.Point(892, 8)
        Me.lbl_result_hsb_all.Name = "lbl_result_hsb_all"
        Me.lbl_result_hsb_all.Size = New System.Drawing.Size(60, 21)
        Me.lbl_result_hsb_all.TabIndex = 14
        Me.lbl_result_hsb_all.Text = "-"
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.Appearance.Options.UseTextOptions = True
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LabelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(820, 8)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(70, 21)
        Me.LabelControl2.TabIndex = 13
        Me.LabelControl2.Text = "Entscheidung"
        '
        'lbl_result_all
        '
        Me.lbl_result_all.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_result_all.Appearance.Options.UseFont = True
        Me.lbl_result_all.Appearance.Options.UseTextOptions = True
        Me.lbl_result_all.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbl_result_all.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbl_result_all.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbl_result_all.Location = New System.Drawing.Point(6, 6)
        Me.lbl_result_all.Name = "lbl_result_all"
        Me.lbl_result_all.Size = New System.Drawing.Size(140, 21)
        Me.lbl_result_all.TabIndex = 4
        Me.lbl_result_all.Text = "Gesamtergebnis"
        '
        'DataTablehsbBindingSource
        '
        Me.DataTablehsbBindingSource.DataMember = "DataTable_hsb"
        Me.DataTablehsbBindingSource.DataSource = Me.DataSet_hsb
        '
        'Form_hsb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(984, 977)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelControl_footer)
        Me.Controls.Add(Me.PanelControl_qs)
        Me.Controls.Add(Me.PanelControl_prod)
        Me.Controls.Add(Me.PanelControl_ae)
        Me.Controls.Add(Me.PanelControl_header)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(1000, 1016)
        Me.MinimumSize = New System.Drawing.Size(16, 720)
        Me.Name = "Form_hsb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Interne Herstellbarkeitsbewertung"
        CType(Me.RepositoryItemCheckEdit_zutreffend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox_ergebnis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl_header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl_header.ResumeLayout(False)
        CType(Me.tbx_flg.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl_ae, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl_ae.ResumeLayout(False)
        CType(Me.cbx_vkwg_produkt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_hsb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbx_vkwg_anwendung.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbx_vkwg_anwendungssegment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbx_vkwg_branche.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbx_ae_name.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit_ae.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit_ae.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl_ae, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_ae, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit_ae, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox_result_ae, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit_ae, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl_prod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl_prod.ResumeLayout(False)
        CType(Me.cbx_prod_name.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit_prod.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit_prod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl_prod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_prod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit_prod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox_result_prod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit_prod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl_qs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl_qs.ResumeLayout(False)
        CType(Me.cbx_qs_name.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit_qs.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit_qs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl_qs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_qs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit_qs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox_result_qs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit_qs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl_footer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl_footer.ResumeLayout(False)
        CType(Me.DateEdit_all.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit_all.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTablehsbBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl_header As DevExpress.XtraEditors.PanelControl
  Friend WithEvents PanelControl_ae As DevExpress.XtraEditors.PanelControl
  Friend WithEvents PanelControl_prod As DevExpress.XtraEditors.PanelControl
  Friend WithEvents PanelControl_qs As DevExpress.XtraEditors.PanelControl
  Friend WithEvents PanelControl_footer As DevExpress.XtraEditors.PanelControl
  Friend WithEvents lbl_kunde As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_znr_ind As DevExpress.XtraEditors.LabelControl
  Friend WithEvents GridControl_ae As DevExpress.XtraGrid.GridControl
  Friend WithEvents GridView_ae As DevExpress.XtraGrid.Views.Grid.GridView
  Friend WithEvents lbl_ae As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_prod As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_qs As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_result_all As DevExpress.XtraEditors.LabelControl
  Friend WithEvents DataSet_hsb As DataSet_tracking
  Friend WithEvents col_ae_id As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_id_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_area As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_attribute As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_match_int As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_result_attribute As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_rem_int As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_rem_cust As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_name As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_date_time_result As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_result_all As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_order As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents lbl_znr_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_ind_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_kunde_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_pb_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_pb As DevExpress.XtraEditors.LabelControl
  Friend WithEvents GridControl_prod As DevExpress.XtraGrid.GridControl
  Friend WithEvents GridView_prod As DevExpress.XtraGrid.Views.Grid.GridView
  Friend WithEvents col_prod_id As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_id_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_area As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_attribute As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_match_int As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_match_ext As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_tool As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_result_attribute As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_rem_int As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_rem_cust As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_name As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_date_time_result As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_produ_result_all As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_prod_order As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents GridControl_qs As DevExpress.XtraGrid.GridControl
  Friend WithEvents GridView_qs As DevExpress.XtraGrid.Views.Grid.GridView
  Friend WithEvents col_qs_id As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_id_ar As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_area As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_attribute As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_match_int As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_match_ext As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_tool As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_result_attribute As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_rem_int As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_rem_cust As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_name As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_date_time_result As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_result_all As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_qs_order As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_match_ext As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents col_ae_tool As DevExpress.XtraGrid.Columns.GridColumn
  Friend WithEvents RepositoryItemComboBox_result_prod As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
  Friend WithEvents RepositoryItemComboBox_result_qs As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
  Friend WithEvents lbl_ae_result_all_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_ae_result_all As DevExpress.XtraEditors.LabelControl
  Friend WithEvents RepositoryItemCheckEdit_zutreffend As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
  Friend WithEvents RepositoryItemComboBox_ergebnis As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
  Friend WithEvents lbl_prod_result_all_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_prod_result_all As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_qs_result_all_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_qs_result_all As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_ae_name As DevExpress.XtraEditors.LabelControl
  Friend WithEvents cbx_ae_name As DevExpress.XtraEditors.ComboBoxEdit
  Friend WithEvents DateEdit_ae As DevExpress.XtraEditors.DateEdit
  Friend WithEvents lbl_prod_name As DevExpress.XtraEditors.LabelControl
  Friend WithEvents cbx_prod_name As DevExpress.XtraEditors.ComboBoxEdit
  Friend WithEvents DateEdit_prod As DevExpress.XtraEditors.DateEdit
  Friend WithEvents lbl_qs_name As DevExpress.XtraEditors.LabelControl
  Friend WithEvents cbx_qs_name As DevExpress.XtraEditors.ComboBoxEdit
  Friend WithEvents DateEdit_qs As DevExpress.XtraEditors.DateEdit
  Friend WithEvents lbl_result_hsb_all As DevExpress.XtraEditors.LabelControl
  Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_angebot_nr As DevExpress.XtraEditors.LabelControl
  Friend WithEvents DataTablehsbBindingSource As BindingSource
  Friend WithEvents DateEdit_all As DevExpress.XtraEditors.DateEdit
  Friend WithEvents RepositoryItemMemoExEdit_ae As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
  Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
  Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
  Friend WithEvents BarButtonItem_schliessen As DevExpress.XtraBars.BarButtonItem
  Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
  Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
  Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
  Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
  Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
  Friend WithEvents RepositoryItemMemoExEdit_prod As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
  Friend WithEvents RepositoryItemMemoExEdit_qs As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
  Friend WithEvents RepositoryItemComboBox_result_ae As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
  Friend WithEvents RepositoryItemCheckEdit_ae As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
  Friend WithEvents RepositoryItemCheckEdit_prod As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
  Friend WithEvents RepositoryItemCheckEdit_qs As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
  Friend WithEvents lbl_name_ae_hsb_all_wert As DevExpress.XtraEditors.LabelControl
  Friend WithEvents lbl_name_ae_hsb_all As DevExpress.XtraEditors.LabelControl
  Friend WithEvents btn_freigeben As DevExpress.XtraEditors.SimpleButton
  Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
  Friend WithEvents lbl_flg As DevExpress.XtraEditors.LabelControl
  Friend WithEvents tbx_flg As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbx_vkwg_branche As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbx_vkwg_anwendung As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbx_vkwg_anwendungssegment As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lbl_vkwg As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbx_vkwg_produkt As DevExpress.XtraEditors.ComboBoxEdit
End Class
