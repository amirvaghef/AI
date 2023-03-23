Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections

Public Module StringBuilderX

   Private _LineFeedRegex As Regex = CreateUnescapeRegex("\\n")

   <Extension()> _
   Public Function Clear(ByVal SB As StringBuilder, ByVal ParamArray Args() As Object) As StringBuilder
      Return SB.Remove(0, SB.Length).AddEnumeration(Args.GetEnumerator)
   End Function

   <Extension()> _
   Public Function Clear(ByVal SB As StringBuilder, ByVal Enmrt As IEnumerator) As StringBuilder
      Return SB.Remove(0, SB.Length).AddEnumeration(Enmrt)
   End Function

   <Extension()> _
   Public Function Add(ByVal SB As StringBuilder, ByVal ParamArray Args() As Object) As StringBuilder
      Return SB.AddEnumeration(Args.GetEnumerator)
   End Function

   <Extension()> _
   Public Function AddEnumeration(ByVal SB As StringBuilder, ByVal Enmrt As IEnumerator) As StringBuilder
      While Enmrt.MoveNext
         SB.Add(Enmrt.Current)
      End While
      Return SB
   End Function

   <Extension()> _
   Public Function Add(ByVal SB As StringBuilder, ByVal Arg As Object) As StringBuilder
      If Arg Is Nothing Then
         Return SB.Append("#Null#")
      Else
         Static Interprete As Boolean = True
         Dim S As String
         If Interprete Then
            S = _LineFeedRegex.Replace(Arg.ToString, vbNewLine) 'Newlines einfügen
         Else
            S = Arg.ToString
            Interprete = True
         End If
         If S.EndsWith("\x") Then 'auf Interprete-Next-Off - Schalter testen
            SB.Append(S.Substring(0, S.Length - 2)) 'Schalter-Token nicht adden
            Interprete = False
         Else
            SB.Append(S)
         End If
      End If
      Return SB
   End Function

End Module
