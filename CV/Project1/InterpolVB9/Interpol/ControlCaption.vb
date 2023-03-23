Public Class ControlCaption : Inherits DrawObjectBase

   Public ReadOnly StringFormat As StringFormat = AddDisposable(New StringFormat)

   Protected _Text As String
   Public Shadows Function Text(ByVal NewValue As String) As ControlCaption
      If Object.Equals(NewValue, _Text) Then Return Me
      _Text = NewValue
      PreparePath()
      MyBase.Invalidate(True)
      Return Me
   End Function

   Protected Overrides Sub Control_SizeChanged(ByVal sender As Object, ByVal e As EventArgs)
      PreparePath()
      MyBase.Invalidate(True)
   End Sub

   Protected Overrides Sub PreparePath()
      With _Control.Font
         DrawPath.ResetX.AddString( _
            _Text, .FontFamily, .Style, .Size * 1.4F, _Control.ClientRectangle, StringFormat)
      End With
   End Sub

   Protected Overrides Sub Control_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
      e.Graphics.SmoothingMode = SmoothingMode.HighQuality
      MyBase.Control_Paint(sender, e)
   End Sub

End Class
