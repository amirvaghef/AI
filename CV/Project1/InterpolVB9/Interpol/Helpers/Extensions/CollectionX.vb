Imports System.Runtime.CompilerServices
Public Module CollectionX

#Region "IList"

   <Extension()> _
   Public Sub Swap(ByVal Subj As IList, ByVal I1 As Integer, ByVal I2 As Integer)
      Dim Tmp = Subj(I1)
      Subj(I1) = Subj(I2)
      Subj(I2) = Tmp
   End Sub

   <Extension()> _
   Public Function AddTo(Of T)(ByVal Subj As T, ByVal Collection As IList) As T
      'statt: Collection.Add(Obj)
      'implementiere ich: Subj.AddTo(Collection)
      'ermöglicht verkettete Aufrufe: Subj.AddTo(Col1).AddTo(Col2)
      Collection.Add(Subj)
      Return Subj
   End Function

   <Extension()> _
   Public Function RemoveFrom(Of T)(ByVal Subj As T, ByVal Collection As IList) As T
      Collection.Remove(Subj)
      Return Subj
   End Function

#End Region 'IList

#Region "Array"

   <Extension()> _
   Public Function IndexOf(Of T)(ByVal Arr() As T, ByVal Element As T) As Integer
      Return Array.IndexOf(Arr, Element)
      Arr.Contains(Element)
   End Function

#End Region 'Array

#Region "Enumerable"

   <Extension()> _
   Public Function DisposeAll(Of T As IDisposable)(ByVal Subj As IList(Of T)) As IList(Of T)
      For Each O As T In Subj
         O.Dispose()
      Next
      Return Subj
   End Function

   <Extension()> _
   Public Sub DisposeAll(Of T As IDisposable)(ByVal Subj As IEnumerable(Of T))
      For Each O As T In Subj
         O.Dispose()
      Next
   End Sub

#End Region 'Enumerable

End Module
