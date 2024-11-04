<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
    Me.BackgroundWorker_splashscreen = New System.ComponentModel.BackgroundWorker()
    Me.lbl_tool_name = New DevExpress.XtraEditors.LabelControl()
    Me.PictureBox_logo = New System.Windows.Forms.PictureBox()
    Me.ProgressBar_ss = New System.Windows.Forms.ProgressBar()
    Me.LBoxSplashScreen = New System.Windows.Forms.ListBox()
    CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BackgroundWorker_splashscreen
    '
    Me.BackgroundWorker_splashscreen.WorkerReportsProgress = True
    Me.BackgroundWorker_splashscreen.WorkerSupportsCancellation = True
    '
    'lbl_tool_name
    '
    Me.lbl_tool_name.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbl_tool_name.Appearance.Options.UseFont = True
    Me.lbl_tool_name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
    Me.lbl_tool_name.Location = New System.Drawing.Point(12, 74)
    Me.lbl_tool_name.Name = "lbl_tool_name"
    Me.lbl_tool_name.Size = New System.Drawing.Size(218, 40)
    Me.lbl_tool_name.TabIndex = 1
    Me.lbl_tool_name.Text = "Angebot-Tracking"
    '
    'PictureBox_logo
    '
    Me.PictureBox_logo.BackgroundImage = Global.AngebotTrack.My.Resources.Resources.bg_logo_rgb
    Me.PictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.PictureBox_logo.Location = New System.Drawing.Point(12, 12)
    Me.PictureBox_logo.Name = "PictureBox_logo"
    Me.PictureBox_logo.Size = New System.Drawing.Size(218, 56)
    Me.PictureBox_logo.TabIndex = 0
    Me.PictureBox_logo.TabStop = False
    '
    'ProgressBar_ss
    '
    Me.ProgressBar_ss.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.ProgressBar_ss.Location = New System.Drawing.Point(0, 236)
    Me.ProgressBar_ss.MarqueeAnimationSpeed = 0
    Me.ProgressBar_ss.Maximum = 15
    Me.ProgressBar_ss.Name = "ProgressBar_ss"
    Me.ProgressBar_ss.Size = New System.Drawing.Size(284, 10)
    Me.ProgressBar_ss.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.ProgressBar_ss.TabIndex = 10
    Me.ProgressBar_ss.Visible = False
    '
    'LBoxSplashScreen
    '
    Me.LBoxSplashScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LBoxSplashScreen.FormattingEnabled = True
    Me.LBoxSplashScreen.Location = New System.Drawing.Point(12, 120)
    Me.LBoxSplashScreen.Name = "LBoxSplashScreen"
    Me.LBoxSplashScreen.Size = New System.Drawing.Size(260, 106)
    Me.LBoxSplashScreen.TabIndex = 11
    '
    'SplashScreen
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.ClientSize = New System.Drawing.Size(284, 246)
    Me.Controls.Add(Me.LBoxSplashScreen)
    Me.Controls.Add(Me.ProgressBar_ss)
    Me.Controls.Add(Me.lbl_tool_name)
    Me.Controls.Add(Me.PictureBox_logo)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Name = "SplashScreen"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "splashscreen"
    Me.TopMost = True
    CType(Me.PictureBox_logo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents BackgroundWorker_splashscreen As System.ComponentModel.BackgroundWorker
  Friend WithEvents PictureBox_logo As PictureBox
  Friend WithEvents lbl_tool_name As DevExpress.XtraEditors.LabelControl
  Friend WithEvents ProgressBar_ss As ProgressBar
  Friend WithEvents LBoxSplashScreen As ListBox
End Class
