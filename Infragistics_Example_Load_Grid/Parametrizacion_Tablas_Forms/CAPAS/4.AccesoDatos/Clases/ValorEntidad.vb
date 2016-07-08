Public Class ValorEntidad(Of T)



    Private _Eror As Boolean
    Public Property [Error]() As Boolean
        Get
            Return _Eror
        End Get
        Set(ByVal value As Boolean)
            _Eror = value
        End Set
    End Property


    Private _ErrorMessage As String
    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property


    Private _ErrorException As String
    Public Property ErrorException() As String
        Get
            Return _ErrorException
        End Get
        Set(ByVal value As String)
            _ErrorException = value
        End Set
    End Property

    Private _T As T
    Public Property Valor() As T
        Get
            Return _T
        End Get
        Set(ByVal value As T)
            _T = value
        End Set
    End Property


    Private _TipoError As EnumTipoError
    Public Property TipoError() As EnumTipoError
        Get
            Return _TipoError
        End Get
        Set(ByVal value As EnumTipoError)
            _TipoError = value
        End Set
    End Property

    Public Sub GenerarError(ByVal Message As String, ByVal Type As EnumTipoError, Optional ByVal Ex As Exception = Nothing)
        Me.[Error] = True
        Me.ErrorException = If(Ex IsNot Nothing, Me.GetInner(Ex), String.Empty)
        Me.ErrorMessage = Message
        Me.TipoError = Type
        If Type = EnumTipoError.Fatal Then
            Me.Valor = Nothing
        End If
    End Sub


    Private Function GetInner(ByVal ex As Exception) As String
        Dim mensaje As String = String.Empty
        If ex IsNot Nothing Then
            mensaje += ";" + ex.Message
        End If
        If ex.InnerException IsNot Nothing Then
            mensaje += Me.GetInner(ex.InnerException)
        End If
        Return mensaje
    End Function


End Class

Public Enum EnumTipoError
    [Nothing] = 0
    Info = 1
    Warging = 2
    Fatal = 3
End Enum
