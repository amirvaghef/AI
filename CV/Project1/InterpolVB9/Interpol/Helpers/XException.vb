''' <summary>
''' vereinfacht bedienbare Exception-Klasse
''' Throw XException.Sender(Me)("Die Datei\n'", FileName, "'\nkonnte nicht gefunden wern.")
''' </summary>
''' <remarks></remarks>
Public Class XException
   Inherits Exception
   Public Shared _WithStop As Boolean = False

   Public Class ExceptionBuilder

      Private _Sender As Object
      Private _InnerEx As Exception

      Public Function InnerEx(ByVal Value As Exception) As ExceptionBuilder
         _InnerEx = Value
         Return Me
      End Function

      Public Function Sender(ByVal Value As Object) As ExceptionBuilder
         _Sender = Value
         Return Me
      End Function

      Public Function Create(ByVal ParamArray MessageSegments() As Object) As XException
         Return XException.Create(_InnerEx, MessageSegments)
      End Function

      Default Public ReadOnly Property Message( _
            ByVal MessageSegment0 As Object, _
            ByVal ParamArray MessageSegments() As Object) As XException
         Get
            Dim Msg = MessageSegment0.ToString.ConcatWith(MessageSegments)
            If _Sender IsNot Nothing Then
               Msg = _Sender.GetType.Name.ConcatWith("-Exception: ", Msg)
            End If
            Return XException.Create(_InnerEx, Msg)
         End Get
      End Property

   End Class 'ExceptionBuilder

   Public Shared Function WithStop(ByVal Value As Boolean) As ExceptionBuilder
      XException._WithStop = Value
      Return New ExceptionBuilder
   End Function

   Public Shared Function InnerEx(ByVal Value As Exception) As ExceptionBuilder
      Return (New ExceptionBuilder).InnerEx(Value)
   End Function

   Public Shared Function Sender(ByVal Value As Object) As ExceptionBuilder
      Return (New ExceptionBuilder).Sender(Value)
   End Function

   Public Shared Shadows Function Message(ByVal ParamArray MessageSegments() As Object) As XException
      Return Create(Nothing, MessageSegments)
   End Function
   Private Shared Function Create( _
         ByVal InnerEx As Exception, _
         ByVal ParamArray MessageSegments() As Object) As XException
      Dim X As New XException(InnerEx, StringX.Concat(MessageSegments))
#If DEBUG Then
      'Die IDE hat die nervtötende Angewohnheit, im Application-Designer rauszufliegen, wenn bei
      '! Erstellung des MainForms ein Fehler auftritt. Da stoppe ich doch besser hier, und kann in der
      '! Aufrufeliste die genaue Fehlerquelle aufsuchen
      If _WithStop Then Stop
#End If
      Return X
   End Function
   Private Sub New(ByVal InnerEx As Exception, ByVal ParamArray MessageSegments() As Object)
      MyBase.new(String.Concat(MessageSegments), InnerEx)
   End Sub

End Class 'XException