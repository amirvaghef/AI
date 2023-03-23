Imports System.Runtime.CompilerServices
Imports System.Drawing
Imports System.Drawing.Drawing2D

''' <summary>Sammelsurium</summary>
Public Module DrawingX

   Public Function Mult(ByVal Pt As PointF, ByVal Value As Single) As PointF
      With Pt
         Return New PointF(.X * Value, .Y * Value)
      End With
   End Function

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

End Module
