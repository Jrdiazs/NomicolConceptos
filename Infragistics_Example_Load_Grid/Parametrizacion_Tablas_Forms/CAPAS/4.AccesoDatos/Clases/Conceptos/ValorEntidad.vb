''' <summary>
''' Resultado para validar las entidades de conceptos
''' </summary>
''' <typeparam name="T">Tipo de entidad</typeparam>
''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
Public Class ValorEntidad(Of T)

    Private _Eror As Boolean
    ''' <summary>
    ''' Para identificar si se ha generado un error
    ''' </summary>
    ''' <value>boolean</value>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Property [Error]() As Boolean
        Get
            Return _Eror
        End Get
        Set(ByVal value As Boolean)
            _Eror = value
        End Set
    End Property


    Private _ErrorMessage As String
    ''' <summary>
    ''' Para generar un mensaje alternativo al error de la excepcion
    ''' </summary>
    ''' <value>string</value>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property


    Private _ErrorException As String
    ''' <summary>
    ''' Para obtener el mensaje de error de la excepcion
    ''' </summary>
    ''' <value>String</value>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Property ErrorException() As String
        Get
            Return _ErrorException
        End Get
        Set(ByVal value As String)
            _ErrorException = value
        End Set
    End Property

    Private _T As T
    ''' <summary>
    ''' Para obtener el valor de la entidad si no se ha generado un error
    ''' </summary>
    ''' <value>T Entity</value>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Property Valor() As T
        Get
            Return _T
        End Get
        Set(ByVal value As T)
            _T = value
        End Set
    End Property


    Private _TipoError As EnumTipoError
    ''' <summary>
    ''' Para identificar que tipo de error es
    ''' </summary>
    ''' <value>Enum Type EnumTipoError</value>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Property TipoError() As EnumTipoError
        Get
            Return _TipoError
        End Get
        Set(ByVal value As EnumTipoError)
            _TipoError = value
        End Set
    End Property
    ''' <summary>
    ''' Metodo para generar un error 
    ''' </summary>
    ''' <param name="Message">Mensaje alternativo para mostrar al usuario</param>
    ''' <param name="Type">Enum para identificar el tipo de error</param>
    ''' <param name="Ex">exception</param>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Sub GenerarError(ByVal Message As String, ByVal Type As EnumTipoError, Optional ByVal Ex As Exception = Nothing)
        Me.[Error] = True
        Me.ErrorException = If(Ex IsNot Nothing, Me.GetInner(Ex), String.Empty)
        Me.ErrorMessage = Message
        Me.TipoError = Type
        If Type = EnumTipoError.Fatal Then
            Me.Valor = Nothing
        End If
    End Sub

    ''' <summary>
    ''' metodo para obtener el mensaje interno de la excepcion
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
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
''' <summary>
''' Enum que representa el tipo de error de una entidad
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
Public Enum EnumTipoError
    [Nothing] = 0
    Info = 1
    Warging = 2
    Fatal = 3
End Enum
