Imports System.Runtime.CompilerServices

Public Module ObjectX

   <Extension()> _
   Public Function Except(Of T)(ByVal Subj As IEnumerable(Of T), ByVal ParamArray Args() As T) As IEnumerable(Of T)
      Return Enumerable.Except(Subj, Args)
   End Function

   <Extension()> _
   Public Function IsSomething(Of T As Class)(ByVal Subj As T) As Boolean
      Return Subj IsNot Nothing
   End Function

   <Extension()> _
   Public Function IsNothing(Of T As Class)(ByVal Subj As T) As Boolean
      Return Subj Is Nothing
   End Function

End Module
