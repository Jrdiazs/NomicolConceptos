Imports FluentValidation
Imports System.Data.SqlClient
Imports AutoMapper
Imports System.Text.RegularExpressions
Imports System.ComponentModel

Public Class ComunesConcepto
    ''' <summary>
    ''' Muestra un mensaje de alerta o error segun el resultao de ValorEntidad si existe o no error
    ''' </summary>
    ''' <typeparam name="T">ValorEntidad Valor</typeparam>
    ''' <param name="Resultado">ValorEntidad</param>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Shared Sub MostrarMensaje(Of T)(ByVal Resultado As ValorEntidad(Of T))
        Dim Caption As String = String.Empty

        Dim Icon = MessageBoxIcon.Information

        Select Case Resultado.TipoError
            Case EnumTipoError.Fatal
                Icon = MessageBoxIcon.Error
                Caption = "Error"
            Case EnumTipoError.Warging
                Icon = MessageBoxIcon.Warning
                Caption = "Info"
            Case EnumTipoError.Info
                Icon = MessageBoxIcon.Information
                Caption = "Info"
            Case Else
                Icon = MessageBoxIcon.Information
                Caption = "Info"
        End Select

        MessageBox.Show(Resultado.ErrorMessage, Caption, MessageBoxButtons.OK, Icon)

    End Sub
    ''' <summary>
    ''' Muestra un mensaje de error personalizado junto con el message exception
    ''' </summary>
    ''' <param name="Message">Mensaje personalizado</param>
    ''' <param name="ex">Exception</param>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Shared Sub MostrarMensaje(ByVal Message As String, ByVal ex As Exception)
        MessageBox.Show(String.Format("Error : {0} : {1}", Message, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    ''' <summary>
    ''' Valida Una Entidad Generica segun el AbstractValidator definido para cada clase
    ''' </summary>
    ''' <typeparam name="T">Type of Entity </typeparam>
    ''' <param name="Errores">string que obtiene la descripcion del error</param>
    ''' <param name="AbstractValidator">Validador para cada clase entidad</param>
    ''' <param name="Entity">Objeto a validar</param>
    ''' <returns>true si la entidad no tiene errores, false si tiene por lo menos un error en alguna de sus propiedades</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Shared Function Validar(Of T)(ByRef Errores As String, ByVal AbstractValidator As AbstractValidator(Of T), ByVal Entity As T) As Boolean
        Dim Resultado = AbstractValidator.Validate(Entity)
        If (Resultado.Errors.Count > 0) Then
            For Each ErrorMessage In Resultado.Errors.Select(Function(x) x.ErrorMessage)
                Errores += ErrorMessage + vbLf
            Next
        End If
        Return Resultado.IsValid
    End Function
    ''' <summary>
    ''' Mapea los datos del SqlDataReader en una Lista generica
    ''' </summary>
    ''' <typeparam name="T">T Value</typeparam>
    ''' <param name="Reader">SqlDataReader</param>
    ''' <returns>List(Of T)</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Shared Function ToListMap(Of T)(ByVal Reader As SqlDataReader) As List(Of T)
        Dim Data = New List(Of T)

        Mapper.Reset()

        Using Reader
            If Reader.HasRows Then
                Mapper.CreateMap(Of IDataReader, T)()
                Data = Mapper.Map(Of IDataReader, IList(Of T))(Reader)
            End If
        End Using

        Return Data
    End Function
    ''' <summary>
    ''' Convierte una lista generica a BindingToList
    ''' </summary>
    ''' <typeparam name="T">T Value entidad</typeparam>
    ''' <param name="List">List(Of T) Lista generica</param>
    ''' <param name="AllowEdit">AllowEdit</param>
    ''' <param name="AllowNew">AllowNew</param>
    ''' <param name="AllowRemove">AllowRemove</param>
    ''' <returns>As BindingList(Of T)</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Shared Function BindingToList(Of T)(ByVal List As List(Of T), Optional ByVal AllowEdit As Boolean = True, Optional ByVal AllowNew As Boolean = True, Optional ByVal AllowRemove As Boolean = True) As BindingList(Of T)
        Dim Binding As New BindingList(Of T)(List)
        Binding.AllowEdit = AllowEdit
        Binding.AllowNew = AllowNew
        Binding.AllowRemove = AllowRemove
        Return Binding
    End Function
    ''' <summary>
    ''' Verifica si un string es un valor Numerico
    ''' </summary>
    ''' <param name="Value">string value</param>
    ''' <returns>true si es numerico</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Shared Function IsNumeric(ByVal Value As String) As Boolean
        If String.IsNullOrEmpty(Value) Then
            Return False
        End If
        Dim reg As New Regex("^[0-9]+$")
        Return reg.IsMatch(Value)
    End Function
End Class
