Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraSplashScreen
Public Class clCustomOverlayPainter
  Inherits OverlayWindowPainterBase

  Private stopwatch As Stopwatch
  Private gifHelper As New clAnimatedGifImageHelper(Application.StartupPath & "\spin_lines.gif")
  Private imgToDraw As Image = Nothing
  Private ReadOnly interval As Integer = 100
  Private ReadOnly strTextToShow As String = ""

  Private ReadOnly options As OverlayWindowOptions

  Public Sub New(ByVal _interval As Integer, ByVal _strTextToShow As String)
    interval = _interval
    strTextToShow = _strTextToShow
    imgToDraw = gifHelper.GetFrame(0)
    stopwatch = New Stopwatch()
  End Sub

  Public Sub StopTimer()
    stopwatch.Reset()
  End Sub
  Private Shared ReadOnly drawFont As Font
  Shared Sub New()
    drawFont = New Font("Tahoma", 18)
  End Sub

  Protected Overrides Sub Draw(ByVal context As OverlayWindowCustomDrawContext)
    If Not stopwatch.IsRunning Then
      stopwatch.Start()
    End If

    If stopwatch.ElapsedMilliseconds > interval Then
      imgToDraw = gifHelper.GetNextFrame()
      stopwatch.Reset()
    End If

    context.Handled = True

    Dim cache As GraphicsCache = context.DrawArgs.Cache
    cache.TextRenderingHint = Text.TextRenderingHint.AntiAlias

    Dim bounds As Rectangle = context.DrawArgs.Bounds

    context.DrawBackground()

    If imgToDraw IsNot Nothing Then
      Dim drawPoint As New PointF(bounds.Left + bounds.Width \ 2 - imgToDraw.Width \ 2, bounds.Top + bounds.Height \ 3 - imgToDraw.Height \ 2)
      cache.Graphics.DrawImage(imgToDraw, drawPoint)
    End If

    Dim drawString As String = strTextToShow  '"Preislisten werden importiert ..."
    Dim drawBrush As Brush = Brushes.Black
    Dim textSize As SizeF = cache.CalcTextSize(drawString, drawFont)
    Dim textPoint As New PointF(bounds.Left + bounds.Width \ 2 - textSize.Width \ 2, bounds.Top + bounds.Height \ 2 - textSize.Height \ 2 + 50)

    cache.Graphics.DrawString(drawString, drawFont, drawBrush, textPoint)
  End Sub
End Class
