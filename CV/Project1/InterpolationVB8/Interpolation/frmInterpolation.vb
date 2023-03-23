Public Class frmInterpolation

   Private _SupportPoints As New List(Of DrawPoint)
   Private _HighlightIndex As Integer                               'Index of the highlighted SupportPoint
   Private _DragGrabOffset As Point                                                       'Dragging-Helper

#Region "3 kinds of Curve"

   Private _Polygon As New Polygon
   Private _CubicSpline As New CubicSpline
   Private _BezierSpline As New BezierSpline

#End Region '3 kinds of Curve

   Private _BezierPathPoints As New Polygon         'additional Curve to display _BezierSplines Pathpoints

   Private _ToInterpolate As Polygon
   Private WithEvents _Pointer As New DrawPoint                 'displays the current interpolation-result

   Private _CurveDic As New Dictionary(Of ToolStripButton, Polygon)    'associates buttons with curves

   Private _UserManual As New ControlCaption

   Public Sub New()
      InitializeComponent()
      'DrawObjects mustn't be initialized, before InitializeComponent() has set up picCanvas.
      'It reduced flickering very effectively, when I changed the Canvas from Panel to Picturebox,
      '! because Pictureboxes Painting is doublebuffered
      _BezierPathPoints.Control(picCanvas).Pen(Pens.Orange)
      _BezierSpline.Control(picCanvas).Pen(Pens.Brown)
      _Polygon.Control(picCanvas).Pen(Pens.Green)
      _CubicSpline.Control(picCanvas).Pen(Pens.Blue)

      With _CurveDic
         .Add(btBezier, _BezierSpline)
         .Add(btPolygon, _Polygon)
         .Add(btBezierPathPoints, _BezierPathPoints)
         .Add(btSpline, _CubicSpline)
      End With

      _Pointer.Control(picCanvas).CreatePen(Color.Red, 2)

      _UserManual.Control(picCanvas).CreateBrush(Color.FromArgb(80, 0, 0, 255)).Visible = True
      With _UserManual.StringFormat
         .Alignment = StringAlignment.Near
         .LineAlignment = StringAlignment.Far
         .SetTabStops(25, New Single() {25})
      End With
      _UserManual.Text(String.Concat( _
         "Mousclicks:", CrLf, _
         "left:", Tab, "select or create new support-point", CrLf, _
         "right:", Tab, "delete highlighted support-point"))
   End Sub

   Private Sub frmInterpolVB8_Disposed(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Disposed
      Disposer.DisposeAll( _
         _BezierPathPoints, _BezierSpline, _Polygon, _CubicSpline, _Pointer, _UserManual)
      Disposer.DisposeAll(_SupportPoints)
   End Sub

   Private Function DrawPointXComparison(ByVal DP1 As DrawPoint, ByVal DP2 As DrawPoint) As Integer
      Return DP1.Location.X.CompareTo(DP2.Location.X)
   End Function

   Private Sub frmInterpolVB8_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
         Handles picCanvas.MouseDown
      Select Case e.Button
         Case MouseButtons.Left                                             'select or create SupportPoint
            Dim Selected As DrawPoint
            If _HighlightIndex < 0 Then
               Selected = New DrawPoint
               Selected.Control(picCanvas).CreatePen(Color.Blue, 2)
               Selected.Radius(5).HighLight(True).Location(e.Location).Visible = True
               _HighlightIndex = _SupportPoints.BinarySearch( _
                  Selected, _
                  ToComparer(Of DrawPoint)(AddressOf DrawPointXComparison))
               If _HighlightIndex < 0 Then _HighlightIndex = _HighlightIndex Xor -1
               _SupportPoints.Insert(_HighlightIndex, Selected)
            Else
               Selected = _SupportPoints(_HighlightIndex)
            End If
            _DragGrabOffset = e.Location - New Size(Point.Round(Selected.Location))
            UpdateAll(Selected.Location.X)

         Case MouseButtons.Right                                                      'delete SupportPoint
            If _HighlightIndex >= 0 Then
               _SupportPoints(_HighlightIndex).Dispose()
               _SupportPoints.RemoveAt(_HighlightIndex)
               _HighlightIndex = -1
               UpdateAll(_Pointer.Location.X)
            End If
      End Select
   End Sub

   Private Sub pnlCanvas_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) _
         Handles picCanvas.MouseMove
      Select Case e.Button
         Case MouseButtons.None
            TryHighlightAt(e.Location)
            UpdatePointer(e.X)

         Case MouseButtons.Left                                                         'drag SupportPoint
            Dim Selected As DrawPoint = _SupportPoints(_HighlightIndex)
            Dim Pt As Point = e.Location - New Size(_DragGrabOffset)
            Selected.Location(DrawingX.ClipIn(Pt, picCanvas.ClientRectangle))
            Dim XPos As Single = Selected.Location.X
            'keep the Points in sorted Order (sort by Point.X)
            If _
                  _HighlightIndex < _SupportPoints.Count - 1 AndAlso _
                  XPos > _SupportPoints(_HighlightIndex + 1).Location.X Then
               CollectionX.Swap(_SupportPoints, _HighlightIndex, _HighlightIndex + 1)
               _HighlightIndex += 1
            ElseIf _
                  _HighlightIndex > 0 AndAlso _
                  XPos < _SupportPoints(_HighlightIndex - 1).Location.X Then
               CollectionX.Swap(_SupportPoints, _HighlightIndex, _HighlightIndex - 1)
               _HighlightIndex -= 1
            End If
            UpdateAll(Selected.Location.X)

         Case MouseButtons.Right

      End Select
   End Sub

   Private Sub UpdatePointer(ByVal X As Single)
      If _ToInterpolate Is Nothing Then _Pointer.Visible = False : Return
      With _ToInterpolate.GetPointOnCurve(X)
         _Pointer.Visible = .HasValue
         If .HasValue Then
            _Pointer.Location(.Value)
         End If
      End With
   End Sub


   Private Sub UpdateAll(ByVal X As Single)
      Dim Pts(_SupportPoints.Count - 1) As PointF
      For I As Integer = 0 To _SupportPoints.Count - 1
         Pts(I) = _SupportPoints(I).Location
      Next
      For Each Curve As Polygon In _CurveDic.Values
         If Curve IsNot _BezierPathPoints Then
            Curve.UpdatePath(Pts)
         End If
      Next
      With _BezierSpline.DrawPath
         If .PointCount > 0 Then
            Pts = .PathPoints
         Else
            Pts = New PointF() {}
         End If
      End With
      _BezierPathPoints.UpdatePath(Pts)
      UpdatePointer(X)
   End Sub

   Private Sub TryHighlightAt(ByVal Pt As Point)
      For Me._HighlightIndex = 0 To _SupportPoints.Count - 1
         If _SupportPoints(_HighlightIndex).TryHighLight(Pt) Then Exit For
      Next
      For I As Integer = _HighlightIndex + 1 To _SupportPoints.Count - 1
         _SupportPoints(I).HighLight(False)
      Next
      If _HighlightIndex >= _SupportPoints.Count Then _HighlightIndex = -1
   End Sub

   Private Sub CurveButtons_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
         Handles btBezierPathPoints.CheckedChanged, btBezier.CheckedChanged, _
         btPolygon.CheckedChanged, btSpline.CheckedChanged
      btBezierPathPoints.Enabled = btBezier.Checked
      If Not btBezierPathPoints.Enabled Then btBezierPathPoints.Checked = False
      Dim Bt As ToolStripButton = DirectCast(sender, ToolStripButton)
      Dim Curve As Polygon = _CurveDic(Bt)
      Curve.Visible = Bt.Checked
      If Curve IsNot _BezierPathPoints Then
         If Curve.Visible Then
            _ToInterpolate = Curve
         Else
            For Each Curve In _CurveDic.Values
               If Curve IsNot _BezierPathPoints AndAlso Curve.Visible Then
                  _ToInterpolate = Curve
                  Exit For
               End If
            Next
         End If
      End If
      UpdateAll(_Pointer.Location.X)
   End Sub

   Private Sub _Pointer_LocationChanged(ByVal Sender As DrawPoint) Handles _Pointer.LocationChanged
      lbPointer.Text = Sender.Location.ToString
   End Sub

   Private Sub _Pointer_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
         Handles _Pointer.VisibleChanged
      With DirectCast(sender, DrawPoint)
         lbPointer.Text = IIf(.Visible, .Location, "n. def.").ToString
      End With
   End Sub

End Class