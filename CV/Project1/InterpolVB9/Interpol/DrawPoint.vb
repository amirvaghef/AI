Public Delegate Sub EventHandlerEx(Of T0)(ByVal Sender As T0)

Public Class DrawPoint : Inherits DrawObjectBase
   'this one draws a circle around its location. Location can be moved, the drawing can be executed
   '! as highlighted

   Private _NormPath As GraphicsPath = AddDisposable(New GraphicsPath)
   Private _NormPen As Pen
   Private _HighlightPen As Pen
   Private _Radius As Single = 3
   Private _Location As PointF
   Private _Mtr As Matrix = AddDisposable(New Matrix)

   Public Event LocationChanged As EventHandlerEx(Of DrawPoint)

   Public Sub New()
      Radius(3)
   End Sub

   Public Function Radius(ByVal Value As Single) As DrawPoint
      _Radius = Value
      _NormPath.ResetX.AddEllipse(-_Radius, -_Radius, _Radius * 2, _Radius * 2)
      Return Me
   End Function

   Public Overrides Function Pen(ByVal Value As System.Drawing.Pen) As DrawObjectBase
      MyBase.Pen(Value)
      _NormPen = Value
      ExchangeDisposable(_HighlightPen, New Pen(Color.FromArgb(&HFF00FFFF), _PenWidth))
      Return Me
   End Function

   Public Function Location() As PointF
      Return _Location
   End Function

   Public Function Location(ByVal X As Single, ByVal Y As Single) As DrawPoint
      Return Location(New PointF(X, Y))
   End Function

   Public Function Location(ByVal Value As PointF) As DrawPoint
      _Location = Value
      RaiseEvent LocationChanged(Me)
      PreparePath()
      MyBase.Invalidate(True)
      Return Me
   End Function

   Protected Overrides Sub PreparePath()
      _Mtr.ResetX.TranslateX(_Location.X, _Location.Y)
      DrawPath.ReplacedBy(_NormPath).Transform(_Mtr)
   End Sub

   Public Function HighLight(ByVal LightOn As Boolean) As DrawPoint
      If (_Pen Is _HighlightPen) <> LightOn Then
         _Pen = If(LightOn, _HighlightPen, _NormPen)
         MyBase.Invalidate(False)
      End If
      Return Me
   End Function

   Public Function TryHighLight(ByVal Pt As PointF) As Boolean
      TryHighLight = DrawPath.IsVisible(Pt)
      HighLight(TryHighLight)
   End Function

End Class
