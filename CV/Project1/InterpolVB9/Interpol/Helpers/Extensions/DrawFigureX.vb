Imports System.Runtime.CompilerServices
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Module DrawFigureX

#Region "Matrix"

   <Extension()> _
   Public Function TranslateX( _
         ByVal Subj As Matrix, ByVal X As Single, ByVal Y As Single, _
         Optional ByVal Order As MatrixOrder = MatrixOrder.Append) As Matrix
      Subj.Translate(X, Y, Order)
      Return Subj
   End Function

   <Extension()> _
   Public Function ScaleX( _
         ByVal Subj As Matrix, ByVal X As Single, ByVal Y As Single, _
         Optional ByVal Order As MatrixOrder = MatrixOrder.Append) As Matrix
      Subj.Scale(X, Y, Order)
      Return Subj
   End Function

   <Extension()> _
   Public Function ResetX(ByVal Subj As Matrix) As Matrix
      Subj.Reset()
      Return Subj
   End Function

#End Region 'Matrix

#Region "GraphicsPath"

   <Extension()> _
   Public Function ResetX(ByVal Subj As GraphicsPath) As GraphicsPath
      Subj.Reset()
      Return Subj
   End Function

   <Extension()> _
   Public Function ReplacedBy(ByVal Subj As GraphicsPath, ByVal Src As GraphicsPath) As GraphicsPath
      Subj.Reset()
      Subj.AddPath(Src, False)
      Return Subj
   End Function

#End Region 'GraphicsPath

End Module
