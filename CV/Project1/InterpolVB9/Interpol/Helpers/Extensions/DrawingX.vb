Imports System.Runtime.CompilerServices
Imports System.Drawing
Imports System.Drawing.Drawing2D

''' <summary>Sammelsurium</summary>
Public Module DrawingX

   <Extension()> _
   Public Function Round(ByVal Rct As RectangleF) As Rectangle
      Return Rectangle.Round(Rct)
   End Function

   <Extension()> _
   Public Function Ceiling(ByVal Rct As RectangleF) As Rectangle
      Return Rectangle.Ceiling(Rct)
   End Function

   <Extension()> _
   Public Function Subtract(ByVal Pt As Point, ByVal Pt2 As Point) As Point
      Pt.Offset(-Pt2.X, -Pt2.Y)
      Return Pt
   End Function

   <Extension()> _
   Public Function Subtract(ByVal Pt As PointF, ByVal Pt2 As PointF) As PointF
      With Pt
         Return New PointF(.X - Pt2.X, .Y - Pt2.Y)
      End With
   End Function

   <Extension()> _
   Public Function Add(ByVal Pt As PointF, ByVal Pt2 As PointF) As PointF
      With Pt
         Return New PointF(.X + Pt2.X, .Y + Pt2.Y)
      End With
   End Function

   <Extension()> _
   Public Function Mult(ByVal Pt As PointF, ByVal Value As Single) As PointF
      With Pt
         Return New PointF(.X * Value, .Y * Value)
      End With
   End Function

   <Extension()> _
   Public Function Divide(ByVal Pt As PointF, ByVal Value As Single) As PointF
      With Pt
         Return New PointF(.X / Value, .Y / Value)
      End With
   End Function

   <Extension()> _
   Public Function Round(ByVal Pt As PointF) As Point
      Return Point.Round(Pt)
   End Function

   <Extension()> _
   Public Function Mid(ByVal Rct As Rectangle) As Point
      With Rct
         Return New Point(.Left + (.Right - .Left) \ 2, .Top + (.Bottom - .Top) \ 2)
      End With
   End Function
   <Extension()> _
   Public Function Mid(ByVal Sz As Size) As Point
      With Sz
         Return New Point(.Width \ 2, .Height \ 2)
      End With
   End Function
   <Extension()> _
   Public Function Mid(ByVal Pt As Point) As Point
      With Pt
         Return New Point(.X \ 2, .Y \ 2)
      End With
   End Function
   <Extension()> _
   Public Function ClipIn(ByVal Pt As Point, ByVal Clip As Rectangle) As Point
      With Clip
         If .Contains(Pt) Then Return Pt
         If Pt.X < .X Then
            Pt.X = .X
         ElseIf Pt.X >= .Right Then
            Pt.X = .Right
         End If
         If Pt.Y < .Y Then
            Pt.Y = .Y
         ElseIf Pt.Y >= .Bottom Then
            Pt.Y = .Bottom
         End If
      End With
      Return Pt
   End Function
   <Extension()> _
   Public Function ClipIn(ByVal Pt As Point, ByVal Clip As Size) As Point
      Return Pt.ClipIn(New Rectangle(Point.Empty, Clip))
   End Function
   <Extension()> _
   Public Function Mult(ByVal Rct As Rectangle, ByVal Value As Double) As Rectangle
      With Rct
         Return New Rectangle( _
            CInt(.X * Value), _
            CInt(.Y * Value), _
            CInt(.Width * Value), _
            CInt(.Height * Value))
      End With
   End Function

End Module
