''' <summary>
''' Polygon does the most primitive form of interpolation: draw a straight line
''' Its derivates BezierSpline and CubicSpline perform higher level of drawing and 
''' interpolating (if more than 2 support-points available)
''' </summary>
Public Class Polygon : Inherits DrawObjectBase

   Protected _Points(-1) As PointF

   Public Sub UpdatePath(ByVal Points() As PointF)
      _Points = Points
      DrawPath.Reset()
      If _Visible Then
         Select Case Points.Length
            Case Is < 2
            Case 2 '2 points only? - its a line, not a spline!
               'make shure not to call PreparePath-overrides
               MyClass.PreparePath()
            Case Else
               Me.PreparePath()
         End Select
      End If
      MyBase.Invalidate(True)
   End Sub

   Protected Overrides Sub PreparePath()
      With DrawPath
         .AddLines(_Points)
         'add some decoration
         Const R As Single = 2, _2R As Single = 2 * R
         For Each Pt In _Points
            .AddEllipse(Pt.X - R, Pt.Y - R, _2R, _2R)
         Next
      End With
   End Sub

   Public Function GetPointOnCurve(ByVal X As Single) As PointF?
      ' carefully read manuals about BinarySearch() - note: I Xor it immediately
      Dim Indx = _Points.BinarySearch(New PointF(X, 0), Function(P1, P2) P1.X.CompareTo(P2.X)) Xor -1
      Select Case Indx
         Case Is < 0 'exact match (nearly never occurs)
            Return _Points(Indx Xor -1) 'return match uninterpolated (re-Xor Indx)

         Case 0, _Points.Count 'X is out of range
            Return Nothing

         Case Else
            If _Points.Length = 2 Then ' its a line, not a spline!
               'make shure not to call InterpolateSegment()-overrides
               Return MyClass.InterpolateSegment(X, Indx)
            End If
            Return InterpolateSegment(X, Indx) 'execute overridden interpolating, if available

      End Select
   End Function

   Protected Overridable Function InterpolateSegment(ByVal X As Single, ByVal Indx As Integer) As PointF
      'linear interpolation
      'note: Indx references the point *after* X
      Dim Pt = _Points(Indx - 1)
      With _Points(Indx).Subtract(Pt)
         Return New PointF(X, Pt.Y + (X - Pt.X) * .Y / .X)
      End With
   End Function

End Class
