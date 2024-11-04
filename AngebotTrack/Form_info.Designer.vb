<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_info
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
    Me.lbl_programm = New System.Windows.Forms.Label()
    Me.lbl_jahr = New System.Windows.Forms.Label()
    Me.lbl_Programmierer = New System.Windows.Forms.Label()
    Me.lbl_programmiert_von = New System.Windows.Forms.Label()
    Me.lbl_version_installiert = New System.Windows.Forms.Label()
    Me.lbl_Version = New System.Windows.Forms.Label()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lbl_programm
    '
    Me.lbl_programm.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbl_programm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.lbl_programm.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.lbl_programm.Location = New System.Drawing.Point(6, 68)
    Me.lbl_programm.Name = "lbl_programm"
    Me.lbl_programm.Size = New System.Drawing.Size(218, 24)
    Me.lbl_programm.TabIndex = 14
    Me.lbl_programm.Text = "Angebots-Tracking"
    Me.lbl_programm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lbl_jahr
    '
    Me.lbl_jahr.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.lbl_jahr.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.lbl_jahr.Location = New System.Drawing.Point(6, 146)
    Me.lbl_jahr.Name = "lbl_jahr"
    Me.lbl_jahr.Size = New System.Drawing.Size(40, 18)
    Me.lbl_jahr.TabIndex = 13
    Me.lbl_jahr.Text = "2017"
    Me.lbl_jahr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lbl_Programmierer
    '
    Me.lbl_Programmierer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.lbl_Programmierer.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.lbl_Programmierer.Location = New System.Drawing.Point(114, 122)
    Me.lbl_Programmierer.Name = "lbl_Programmierer"
    Me.lbl_Programmierer.Size = New System.Drawing.Size(100, 18)
    Me.lbl_Programmierer.TabIndex = 12
    Me.lbl_Programmierer.Text = "Michael Heyder"
    Me.lbl_Programmierer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lbl_programmiert_von
    '
    Me.lbl_programmiert_von.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.lbl_programmiert_von.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.lbl_programmiert_von.Location = New System.Drawing.Point(6, 122)
    Me.lbl_programmiert_von.Name = "lbl_programmiert_von"
    Me.lbl_programmiert_von.Size = New System.Drawing.Size(104, 18)
    Me.lbl_programmiert_von.TabIndex = 11
    Me.lbl_programmiert_von.Text = "Entwickler"
    Me.lbl_programmiert_von.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lbl_version_installiert
    '
    Me.lbl_version_installiert.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.lbl_version_installiert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.lbl_version_installiert.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.lbl_version_installiert.Location = New System.Drawing.Point(114, 98)
    Me.lbl_version_installiert.Name = "lbl_version_installiert"
    Me.lbl_version_installiert.Size = New System.Drawing.Size(100, 18)
    Me.lbl_version_installiert.TabIndex = 10
    Me.lbl_version_installiert.Text = "AngebotTrack x.y.z"
    Me.lbl_version_installiert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lbl_Version
    '
    Me.lbl_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
    Me.lbl_Version.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.lbl_Version.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.lbl_Version.Location = New System.Drawing.Point(6, 98)
    Me.lbl_Version.Name = "lbl_Version"
    Me.lbl_Version.Size = New System.Drawing.Size(104, 18)
    Me.lbl_Version.TabIndex = 9
    Me.lbl_Version.Text = "installierte Version :"
    Me.lbl_Version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'PictureBox1
    '
    Me.PictureBox1.BackgroundImage = Global.AngebotTrack.My.Resources.Resources.bg_logo_rgb1
    Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(218, 56)
    Me.PictureBox1.TabIndex = 15
    Me.PictureBox1.TabStop = False
    '
    'Form_info
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(232, 175)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.lbl_programm)
    Me.Controls.Add(Me.lbl_jahr)
    Me.Controls.Add(Me.lbl_Programmierer)
    Me.Controls.Add(Me.lbl_programmiert_von)
    Me.Controls.Add(Me.lbl_version_installiert)
    Me.Controls.Add(Me.lbl_Version)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form_info"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Programm-Version"
    Me.TopMost = True
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents lbl_programm As System.Windows.Forms.Label
  Friend WithEvents lbl_jahr As System.Windows.Forms.Label
  Friend WithEvents lbl_Programmierer As System.Windows.Forms.Label
  Friend WithEvents lbl_programmiert_von As System.Windows.Forms.Label
  Friend WithEvents lbl_version_installiert As System.Windows.Forms.Label
  Friend WithEvents lbl_Version As System.Windows.Forms.Label
  Friend WithEvents PictureBox1 As PictureBox
End Class
