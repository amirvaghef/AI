Imports System.Runtime.CompilerServices

Public Module IComparableX

   ''' <summary>converts a Comparison to an IComparer</summary>
   Public Function ToComparer(Of T)(ByVal Subj As Comparison(Of T)) As ComparisonComparer(Of T)
      Return New ComparisonComparer(Of T)(Subj)
   End Function

   ''' <summary>
   ''' IComparer-implementierender Wrapper um eine Comparison 
   ''' </summary>
   Public Class ComparisonComparer(Of T) : Inherits Comparer(Of T)
      Private _Comparison As Comparison(Of T)
      Public Sub New(ByVal Comparison As Comparison(Of T))
         _Comparison = Comparison
      End Sub
      Public Overrides Function Compare(ByVal x As T, ByVal y As T) As Integer
         Return _Comparison(x, y)
      End Function
   End Class

End Module
