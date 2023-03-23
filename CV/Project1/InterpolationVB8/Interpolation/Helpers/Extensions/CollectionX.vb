Imports System.Collections

Public Module CollectionX

   Public Sub Swap(ByVal Subj As IList, ByVal I1 As Integer, ByVal I2 As Integer)
      Dim Tmp As Object = Subj(I1)
      Subj(I1) = Subj(I2)
      Subj(I2) = Tmp
   End Sub

End Module
