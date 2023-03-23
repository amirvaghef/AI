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
         For Each Pt As PointF In _Points
            .AddEllipse(Pt.X - R, Pt.Y - R, _2R, _2R)
         Next
      End With
   End Sub

   Private Function PointXComparison(ByVal P1 As PointF, ByVal P2 As PointF) As Integer
      Return P1.X.CompareTo(P2.X)
   End Function

   Public Function GetPointOnCurve(ByVal X As Single) As Nullable(Of PointF)
      ' carefully read manuals about BinarySearch() - note: I Xor it immediately
      Dim Indx As Integer = Array.BinarySearch( _
         _Points, New PointF(X, 0), ToComparer(Of PointF)(AddressOf PointXComparison)) Xor -1
      Select Case Indx
         Case Is < 0 'exact match (nearly never occurs)
            Return _Points(Indx Xor -1) 'return match uninterpolated (re-Xor Indx)

         Case 0, _Points.Length 'X is out of range
            Return Nothing

         Case Else
            If _Points.Length = 2 Then ' its a line, not a spline!
               'make shure not to call InterpolVB8ateSegment()-overrides
               Return MyClass.InterpolateSegment(X, Indx)
            End If
            Return InterpolateSegment(X, Indx) 'execute overridden interpolating, if available

      End Select
   End Function

   Protected Overridable Function InterpolateSegment(ByVal X As Single, ByVal Indx As Integer) As PointF
      'linear interpolation
      'note: Indx references the point *after* X
      Dim Pt As PointF = _Points(Indx - 1)
      With _Points(Indx) - New SizeF(Pt)
         Return New PointF(X, Pt.Y + (X - Pt.X) * .Y / .X)
      End With
   End Function

End Class
