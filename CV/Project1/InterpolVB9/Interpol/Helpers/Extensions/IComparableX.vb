Imports System.Runtime.CompilerServices

Public Module IComparableX

   <Extension()> _
   Public Function IsBetween(Of T As IComparable)( _
         ByVal ToTest As T, _
         ByVal Bord0 As T, _
         ByVal Bord1 As T) As Boolean
      Return Bord0.CompareTo(ToTest) <= 0 AndAlso ToTest.CompareTo(Bord1) <= 0
   End Function

   <Extension()> _
   Public Function IsBetween(Of T As IComparable)( _
         ByVal ToTest As T, _
         ByVal Bord0 As T, _
         ByVal Bord1 As T, _
         ByVal AutoSort As Boolean, _
         ByVal LBoundInclude As Boolean, _
         ByVal UBoundInclude As Boolean) As Boolean
      If AutoSort AndAlso Bord0.CompareTo(Bord1) > 0 Then
         Dim Temp = Bord0
         Bord0 = Bord1
         Bord1 = Temp
      End If
      Dim C0 As Integer = Bord0.CompareTo(ToTest)
      Dim C1 As Integer = ToTest.CompareTo(Bord1)
      If LBoundInclude AndAlso C0 = 0 Then Return True
      If UBoundInclude AndAlso C1 = 0 Then Return True
      Return C0 < 0 AndAlso C1 < 0
   End Function

   <Extension()> _
   Public Function ClipIn(Of T As IComparable)( _
         ByVal Subj As T, ByVal LBound As T, ByVal UBound As T) As T
      If Subj.CompareTo(LBound) < 0 Then Return LBound
      If Subj.CompareTo(UBound) > 0 Then Return UBound
      Return Subj
   End Function

   <Extension()> _
   Public Function BinarySearch(Of T)( _
           ByVal Subj As List(Of T), _
           ByVal Pattern As T, _
           ByVal Comparison As Comparison(Of T)) As Integer
      'ermöglicht, List(Of T).BinarySearch mit Comparisons aufzurufen, statt umständlich eine IComparer-Klasse implementieren zu müssen
      Return Subj.BinarySearch(Pattern, Comparison.ToComparer)
   End Function
   <Extension()> _
   Public Function BinarySearch(Of T)( _
           ByVal Subj As T(), _
           ByVal Pattern As T, _
           ByVal Comparison As Comparison(Of T)) As Integer
      'Umbau von Shared Array.BinarySearch in eine Objektfunktion, die außerdem Comparisons akzeptiert
      Return Array.BinarySearch(Subj, Pattern, Comparison.ToComparer)
   End Function

   ''' <summary>
   ''' konvertiert eine Comparison in ein IComparer-implementierendes Objekt
   ''' </summary>
   ''' <remarks>selbst einen Delegaten kann man also erweitern</remarks>
   <Extension()> _
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
