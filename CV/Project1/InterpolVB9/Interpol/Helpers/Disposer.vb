
Public Interface IDisposer
   Function Add(Of T As IDisposable)(ByVal Item As T) As T
   Sub Exchange(Of T As IDisposable)(ByRef Old As T, ByVal [New] As T)
   Sub DisposeAll()
   ReadOnly Property IsDisposed() As Boolean
End Interface

''' <summary>wraps a List(Of IDisposable). So they all can be disposed by one call.</summary>
Public Class Disposer : Implements IDisposer, IDisposable

   Protected _DisposeList As New List(Of IDisposable)
   Private _IsDisposed As Boolean

   Protected Sub New()
   End Sub
   Public Shared Function Create() As IDisposer
      Return New Disposer
   End Function

   Public Shared Sub DisposeAll(ByVal ParamArray Args() As IDisposable)
      DisposeAll(DirectCast(Args, IEnumerable(Of IDisposable)))
   End Sub

   Public Shared Sub DisposeAll(Of T As IDisposable)(ByVal Subj As IEnumerable(Of T))
      For Each O As T In Subj
         O.Dispose()
      Next
   End Sub

   Public ReadOnly Property IsDisposed() As Boolean Implements IDisposer.IsDisposed
      Get
         Return _IsDisposed
      End Get
   End Property

   Protected Function AddDisposable(Of T As IDisposable)(ByVal Item As T) As T Implements IDisposer.Add
      If Item Is Nothing Then Throw XException.Sender(Me)( _
         "Keine gute Idee, der Disposable-Liste einen nicht festgelegten Verweis (Nothing) zuzufügen!")
      If _DisposeList.Contains(Item) Then Throw XException.Sender(Me)( _
         "Das Item """, Item, """ ist schon vorhanden")
      _DisposeList.Add(Item)
      Return Item
   End Function

   Protected Sub DisposeInnerList() Implements IDisposer.DisposeAll
      Disposer.DisposeAll(_DisposeList)
      _DisposeList.Clear()
   End Sub

   Protected Sub ExchangeDisposable(Of T As IDisposable)(ByRef Old As T, ByVal [New] As T) _
         Implements IDisposer.Exchange
      If _DisposeList.Remove(Old) Then Old.Dispose()
      Old = AddDisposable([New])
   End Sub

   Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso Not _IsDisposed Then Me.DisposeInnerList()
      _IsDisposed = True
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
   End Sub

   Protected Overrides Sub Finalize()
      Dispose(False)
      MyBase.Finalize()
   End Sub

End Class 'Disposer