Public Class Form_info

  Private Sub Form_info_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Try
      Me.lbl_version_installiert.Text = Application.ProductVersion.ToString
    Catch ex As Exception
      Me.lbl_version_installiert.Text = "nicht verfügbar"
    End Try
  End Sub
End Class