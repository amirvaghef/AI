Public Class BezierSpline : Inherits Polygon
   'Graphics.DrawCurve() and GraphicsPath.AddCurve() use Bezier-Splines to calculate and display a curve
   '! from given support points.
   'the curve between 2 points is constructed as bezier-curve, containing the 2 points and additional 2
   '! bezier- support points, which model the curvesegment curly.
   'so if you add a curve of 3 points to a GraphicPath by GraphicPath.AddCurve(), afterwards you will
   '! find 7 PathPoints in it: the 1. point, 2 additional points, the 2. point, 2 aditional, the 3. point
   'expressed differently: you will find the added points on Index 0, 3, 6 in the 
   '  GraphicsPath.PathPoints() - Property
   'I recommend to click the "BezierPathPoints" - button when program runs in "BezierSpline" - mode, to
   '! get a visualisation of that issue.

   Protected Overrides Sub PreparePath()
      'this one is simple. GraphicsPath does all the maths for us.
      DrawPath.AddCurve(_Points)
   End Sub

   Protected Overrides Function InterpolateSegment( _
         ByVal X As Single, ByVal Indx As Integer) As PointF
      'AFAIK for Beziers there's no Y = f(X) function available.
      'So I aproximate X by binary try and error
      'note: Indx references the support-point *after* X
      Indx = Indx * 3 'now Indx references the last *construction-point* of the 
      '               BezierSegment in MyBase.DrawPath, which is to interpolate
      Dim Pts = Me.DrawPath.PathPoints
      Dim BezierSegment = New PointF() { _
         Pts(Indx - 3), Pts(Indx - 2), Pts(Indx - 1), Pts(Indx)}
      'binary aproximation
      Dim Range = New Single() {0, 0, 1}  'elsewhere known as: Bottom, Mid, Top
      Dim Dlt = -2.0F
      Dim Pt As PointF
      Do
         Range(If(Dlt < 0, 0, 2)) = Range(1)          'set Bottom or Top to Mid
         Range(1) = (Range(0) + Range(2)) / 2                  'recalculate Mid
         Pt = PointOfFraction(Range(1), BezierSegment)                     'try
         Dlt = Pt.X - X        'for drawing an "error" smaller 0.5 is tolerable
      Loop Until Math.Abs(Dlt) < 0.5
      Return Pt
   End Function

   Private Shared Function PointOfFraction( _
         ByVal Fraction As Single, ByVal ptBeziers() As PointF) As PointF
      'Calculating a point on a BezierCurve bases on a given *Fraction* of the curve (half, 
      'third, else). For each two construction-points the proportionate between-point is 
      'computed, and is taken as new construction-point.
      'So in each loop there will be found 1 point less, until there's only one left
      'Strongly recommended: search "Casteljau" on Wikipedia. surve to "Bezier-curve" and to 
      '"Casteljau- algorithm" (which is implemented here)
      Dim Pts(ptBeziers.Length - 2) As PointF
      For I = 0 To ptBeziers.Length - 2 'first walk-through fills a temporary array
         Pts(I) = PointBetween(ptBeziers(I), ptBeziers(I + 1), Fraction)
      Next
      For UBord = Pts.Length - 2 To 0 Step -1 'following loops overwrite the array
         For I = 0 To UBord
            Pts(I) = PointBetween(Pts(I), Pts(I + 1), Fraction)
         Next
      Next
      Return Pts(0)
   End Function

   Private Shared Function PointBetween( _
         ByVal Pt1 As PointF, ByVal Pt2 As PointF, ByVal Fraction As Single) As PointF
      'compute the to Fraction proportionate between-point between Pt1 and Pt2 
      Return Pt1.Add(Pt2.Subtract(Pt1).Mult(Fraction))
   End Function

End Class