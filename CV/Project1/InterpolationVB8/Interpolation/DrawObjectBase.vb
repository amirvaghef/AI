Public MustInherit Class DrawObjectBase : Inherits Disposer
   'This one can show or hide, can draw itself (filled or outlined) and can be disposed - but it can't
   '! initiate its DrawPath with any content to draw!

   Protected MustOverride Sub PreparePath()

   Public ReadOnly DrawPath As GraphicsPath = AddDisposable(New GraphicsPath)
   Protected _Visible As Boolean = False
   Protected _Brush As Brush                                                           'for filled drawing
   Protected _Pen As Pen                                                             'for outlined drawing
   Protected _PenWidth As Single
   Protected _HalfPenWidth As Single
   Protected _Control As Control

   Public Event VisibleChanged As EventHandler

   Public Property Visible() As Boolean
      Get
         Return _Visible
      End Get
      Set(ByVal value As Boolean)
         If _Visible <> value Then
            _Visible = value
            If _Control IsNot Nothing AndAlso Not _Control.IsDisposed Then
               If _Visible Then
                  AddHandler _Control.SizeChanged, AddressOf Control_SizeChanged
                  AddHandler _Control.Paint, AddressOf Control_Paint
               Else
                  RemoveHandler _Control.SizeChanged, AddressOf Control_SizeChanged
                  RemoveHandler _Control.Paint, AddressOf Control_Paint
               End If
               _Control.Invalidate(GetBounds)
               RaiseEvent VisibleChanged(Me, EventArgs.Empty)
            End If
         End If
      End Set
   End Property

   Public Function Control(ByVal Value As Control) As DrawObjectBase
      _Control = Value
      Return Me
   End Function

   Public Overridable Function CreatePen(ByVal Color As Color, ByVal Width As Single) As DrawObjectBase
      Return Me.Pen(AddDisposable(New Pen(Color, Width)))
   End Function

   Public Overridable Function Pen(ByVal Value As Pen) As DrawObjectBase
      _DisposeList.Remove(_Pen)
      _Pen = Value
      _PenWidth = _Pen.Width
      _HalfPenWidth = _PenWidth / 2
      Return Me
   End Function

   Public Overridable Function CreateBrush(ByVal Color As Color) As DrawObjectBase
      Return Me.Brush(AddDisposable(New SolidBrush(Color)))
   End Function

   Public Overridable Function Brush(ByVal Value As Brush) As DrawObjectBase
      _DisposeList.Remove(_Brush)
      _Brush = Value
      Return Me
   End Function

   Protected Sub Invalidate(ByVal IncludeOldBounds As Boolean)
      Static OldBounds As Rectangle
      If _Visible Then
         If IncludeOldBounds Then _Control.Invalidate(OldBounds)
         OldBounds = GetBounds()
         _Control.Invalidate(OldBounds)
      Else
         OldBounds = Rectangle.Empty
      End If
   End Sub

   Protected Overridable Function GetBounds() As Rectangle
      With DrawPath.GetBounds
         If _Brush Is Nothing Then
            GetBounds = Rectangle.Ceiling(New RectangleF( _
                  .X - _HalfPenWidth, _
                  .Y - _HalfPenWidth, _
                  .Width + 1 + _PenWidth, _
                  .Height + 1 + _PenWidth))
         Else
            GetBounds = Rectangle.Ceiling(DrawPath.GetBounds)
         End If
      End With
      GetBounds.Inflate(1, 1)                                                   'consider Antialiasing
   End Function

   Protected Overridable Sub Control_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
      If Not _Visible Then Return
      If _Brush IsNot Nothing Then
         e.Graphics.FillPath(_Brush, DrawPath)
      Else
         e.Graphics.DrawPath(_Pen, DrawPath)
      End If
   End Sub

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If MyBase.IsDisposed Then Return
      If disposing Then
         Visible = False
      End If
      MyBase.Dispose(disposing)
   End Sub

   Protected Overridable Sub Control_SizeChanged(ByVal sender As Object, ByVal e As EventArgs)
      Invalidate(False)
   End Sub

End Class
