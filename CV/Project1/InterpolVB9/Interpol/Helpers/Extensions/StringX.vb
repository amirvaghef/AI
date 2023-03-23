Option Compare Text

Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Collections
Imports System.Text.RegularExpressions

Public Module StringX

    Private _SB As New System.Text.StringBuilder

    Public Function CreateUnescapeRegex(ByVal Pattern As String) As Regex
        Return New Regex("(?<=(^|[^\\](\\\\)*))" & Pattern, RegexOptions.Compiled) 'der vorangestellte Pattern schließt escaped Matches ('\X' etc.) aus
    End Function

   <Extension()> _
   Public Function HasValue(ByVal Subj As System.String) As Boolean
      Return Not String.IsNullOrEmpty(Subj)
   End Function

    <Extension()> _
    Public Function HasNoValue(ByVal Subj As String) As Boolean
        Return String.IsNullOrEmpty(Subj)
   End Function

   ''' <summary>
   ''' gibt den String-Abschnitt links des ersten gefundenen Matches zurück
   ''' </summary>
   <Extension()> _
   Public Function LastLeftCut(ByVal Subj As String, ByVal Pattern As String) As String
      Dim Index = Subj.LastIndexOf(Pattern)
      If Index >= 0 Then
         Return Subj.Substring(0, Index)
      Else
         Return Nothing
      End If
   End Function

   ''' <summary>
   ''' gibt den String-Abschnitt links des ersten gefundenen Matches zurück
   ''' </summary>
   <Extension()> _
   Public Function LeftCut(ByVal Subj As String, ByVal Pattern As String) As String
      Dim Index = Subj.IndexOf(Pattern)
      If Index >= 0 Then
         Return Subj.Substring(0, Index)
      Else
         Return Nothing
      End If
   End Function

    ' ''Nicht löschen! smart and simple!
    '<Extension()> _
    'Public Function ConcatWith(ByVal Subj As Object, ByVal ParamArray Args() As Object) As String
    '    'Quasi-Umbau von Shared String.Concat() in eine Object-Function
    '    Return Subj.ToString & String.Concat(Args)
   'End Function

   Public Function Concat(ByVal ParamArray Args() As Object) As String
      Return Args.GetEnumerator.Concat
   End Function

   <Extension()> _
   Public Function Concat(ByVal Enmrt As IEnumerator) As String
      Return _SB.Clear(Enmrt).ToString
   End Function

   <Extension()> _
   Public Function ConcatWith(ByVal Subj As Object, ByVal ParamArray Args() As Object) As String
      With _SB
         If Not TypeOf Subj Is String AndAlso TypeOf Subj Is IEnumerable Then
            .Clear(DirectCast(Subj, IEnumerable).GetEnumerator)
         Else
            .Clear(Subj)
         End If
         Return .AddEnumeration(Args.GetEnumerator).ToString
      End With
   End Function

   <Extension()> _
   Public Function Between(ByVal Delimiter As Char, ByVal ParamArray Args() As Object) As String
      Return Args.Join(Delimiter)
   End Function

   <Extension()> _
   Public Function Between(ByVal Delimiter As Char, ByVal Args As IEnumerable) As String
      Return Args.Join(Delimiter)
   End Function

   <Extension()> _
   Public Function Between(ByVal Delimiter As String, ByVal ParamArray Args() As Object) As String
      Return Args.Join(Delimiter)
   End Function

   <Extension()> _
   Public Function Between(ByVal Delimiter As String, ByVal Args As IEnumerable) As String
      Return Args.Join(Delimiter)
   End Function

    <Extension()> _
    Private Function Join(ByVal Subj As IEnumerable, ByVal Delimiter As String) As String
        _SB.Clear()
        With Subj.GetEnumerator
            If .MoveNext Then
                _SB.Append(If(.Current, "").ToString)
                While .MoveNext
                    _SB.Append(Delimiter).Append(If(.Current, "").ToString)
                End While
            End If
        End With
        Return _SB.ToString
   End Function

   <Extension()> _
   Public Function IntParsed(ByRef Subj As String) As Integer
      Return Integer.Parse(Subj)
   End Function

   <Extension()> _
   Public Function BoolParsed(ByRef Subj As String) As Boolean
      Return Boolean.Parse(Subj)
   End Function

End Module
