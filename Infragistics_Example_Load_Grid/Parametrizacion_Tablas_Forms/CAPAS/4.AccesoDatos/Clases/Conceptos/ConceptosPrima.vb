Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_PRIMA generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_PRIMA' de la base 'NomicolSeguridad'
' Fecha: 21/jul/2016 08:34:54
'
' ©Juan Ricardo Diaz S
'------------------------------------------------------------------------------
Public Class ConceptosPrima
    
    Private _Codigo As Integer
    Private _Id_Fijo As Boolean
    Private _Id_Fijo_Promedio As Boolean
    Private _Id_Variable As Boolean

    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Public Property Id_Fijo() As Boolean
        Get
            Return _Id_Fijo
        End Get
        Set(ByVal value As Boolean)
            _Id_Fijo = value
        End Set
    End Property
    Public Property Id_Fijo_Promedio() As Boolean
        Get
            Return _Id_Fijo_Promedio
        End Get
        Set(ByVal value As Boolean)
            _Id_Fijo_Promedio = value
        End Set
    End Property
    Public Property Id_Variable() As Boolean
        Get
            Return _Id_Variable
        End Get
        Set(ByVal value As Boolean)
            _Id_Variable = value
        End Set
    End Property

    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosPrimaValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosPrimaValidator(), Me)
    End Function

End Class
''' <summary>
''' Clase para validar la clase entidad ConceptosPrima
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosPrimaValidator
    Inherits AbstractValidator(Of ConceptosPrima)

    Sub New()
        RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class
