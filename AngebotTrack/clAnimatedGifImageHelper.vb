Imports System.Drawing.Imaging
Public Class clAnimatedGifImageHelper
  Private gif As Image
  Private ReadOnly frameDimension As FrameDimension
  Private ReadOnly frameCount As Integer
  Private currentFrame As Integer = -1

  Public Sub New(ByVal path As String)
    gif = Image.FromFile(path)
    frameDimension = New FrameDimension(gif.FrameDimensionsList(0))
    frameCount = gif.GetFrameCount(frameDimension)
  End Sub

  Public Function GetFrame(ByVal index As Integer) As Image
    gif.SelectActiveFrame(frameDimension, index)
    Return TryCast(gif.Clone(), Image)
  End Function

  Public Function GetNextFrame() As Image
    currentFrame += 1
    If currentFrame >= frameCount OrElse currentFrame < 1 Then
      currentFrame = 0
    End If

    Return GetFrame(currentFrame)
  End Function
End Class
