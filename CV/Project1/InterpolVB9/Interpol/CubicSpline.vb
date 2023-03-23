Public Class CubicSpline : Inherits Polygon

   Private _Results(-1) As Single

   Private Const Precision As Integer = 4       'a poor Precision shows the construction more clearly. The
   '!                                        program displays the exact interpolation by a kind of pointer

   Private Shared Sub SolveTridiag( _
         ByVal SubDiag As Single(), ByVal Diag As Single(), _
         ByVal SuperDiag As Single(), ByVal Results As Single())
      '                  solve linear system with tridiagonal N by N matrix a
      '                        using Gaussian elimination *without* pivoting
      '                        where   a(i,i-1) = SubDiag[i]   for 1<=i<=N
      '                                a(i,i)   = Diag[i]      for 0<=i<=N
      '                                a(i,i+1) = SuperDiag[i] for 0<=i<=N-1
      '                       (the values SubDiag[0], SuperDiag[N] are ignored)
      '        right hand side vector Results[0:N] is overwritten with solution 
      Dim N = Results.Length - 1
      Dim Helper1 = Diag(0)
      For I = 1 To N
         Dim Helper2 = SubDiag(I) / Helper1
         Helper1 = Diag(I) - Helper2 * SuperDiag(I - 1)
         Results(I) -= Helper2 * Results(I - 1)
      Next
      Results(N) /= Diag(N)
      For I = N - 1 To 0 Step -1
         Results(I) = (Results(I) - SuperDiag(I) * Results(I + 1)) / Diag(I)
      Next
   End Sub

   Protected Overrides Sub PreparePath()
      Dim NP = _Points.Count
      If _Points(1).X = _Points(0).X Then Return 'a vertical spline-segment is not interpolable
      'chapter #1: calculate with matrix
      'only the inner points must be associated with a calculated result; border-point-result is 0
      '4 arrays constitute the matrix 
      Dim SubDiag(NP - 3) As Single
      Dim Diag(NP - 3) As Single
      Dim SuperDiag(NP - 3) As Single
      Dim Results(NP - 3) As Single
      For I As Integer = 0 To NP - 3
         Dim PtBefore As PointF = _Points(I)
         Dim Pt As PointF = _Points(I + 1)
         Dim PtAfter As PointF = _Points(I + 2)

         Dim DeltaXBefore = Pt.X - PtBefore.X
         Dim DeltaXAfter = PtAfter.X - Pt.X
         If DeltaXAfter = 0 Then Return 'a vertical spline-segment is not interpolable

         Dim GradeBefore = (Pt.Y - PtBefore.Y) / DeltaXBefore
         Dim GradeAfter = (PtAfter.Y - Pt.Y) / DeltaXAfter

         'I dont really know, why feed the matrix this way - she likes it!
         SubDiag(I) = DeltaXBefore / 6
         Diag(I) = (DeltaXBefore + DeltaXAfter) / 3
         SuperDiag(I) = DeltaXAfter / 6
         Results(I) = GradeAfter - GradeBefore
      Next
      SolveTridiag(SubDiag, Diag, SuperDiag, Results)

      'now pre- and ap-pend the Result 0 for the borderpoints (copy Results into a bigger array)
      ReDim _Results(Results.Length + 1)
      For I = 0 To Results.Length - 1
         'while copying I divide by -6, in anticipation of upcoming calculations
         _Results(I + 1) = Results(I) / -6
      Next

      'chapter #2: prepare Pathpoints
      Dim PathPoints((NP - 1) * Precision) As PointF

      'loop all DeltaXes between the _Points  
      For I = 0 To NP - 2
         Dim PtFrom As PointF = _Points(I)
         Dim PtTo As PointF = _Points(I + 1)
         Dim DeltaX = PtTo.X - PtFrom.X

         'put Precision interpolation-results from each DeltaX to Pathpoints 
         For J As Integer = 0 To Precision - 1
            Dim x1 = DeltaX * J / Precision
            Dim x2 = DeltaX - x1
            '"... don't ask me to explain ..." (Heather Nova: Oyster - Doubled up)
            Dim Y = ((_Results(I) * x1 * (x2 + DeltaX) + PtFrom.Y) * x2 + _
                  (_Results(I + 1) * x2 * (x1 + DeltaX) + PtTo.Y) * x1) / _
                  DeltaX
            PathPoints(I * Precision + J) = New PointF(PtFrom.X + x1, Y)
         Next
      Next
      PathPoints(PathPoints.Length - 1) = _Points(NP - 1) 'dont forget the last point

      'chapter #3: Push Pathpoints to _DrawPath
      DrawPath.AddLines(PathPoints)
      'add some decoration
      Const R As Single = 2, _2R As Single = 2 * R
      For Each Pt In PathPoints
         DrawPath.AddEllipse(Pt.X - R, Pt.Y - R, _2R, _2R)
      Next
   End Sub

   Protected Overrides Function InterpolateSegment(ByVal X As Single, ByVal Indx As Integer) As PointF
      'Indx references the point on the right side of X
      Dim PtFrom As PointF = _Points(Indx - 1)
      Dim PtTo As PointF = _Points(Indx)
      Dim DeltaX = PtTo.X - PtFrom.X
      Dim x1 = X - PtFrom.X
      Dim x2 = DeltaX - x1
      'some numerical black magic again...
      Dim Y = ((_Results(Indx - 1) * x1 * (x2 + DeltaX) + PtFrom.Y) * x2 + _
                    (_Results(Indx) * x2 * (x1 + DeltaX) + PtTo.Y) * x1) / _
                    DeltaX
      Return New PointF(X, Y) 'aaaahh!
   End Function

End Class

