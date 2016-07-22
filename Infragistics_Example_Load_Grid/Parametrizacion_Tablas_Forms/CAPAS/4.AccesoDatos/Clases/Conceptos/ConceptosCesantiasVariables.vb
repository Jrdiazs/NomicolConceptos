Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_CESANTIAS_VARIABLE generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_CESANTIAS_VARIABLE' de la base 'NomicolSeguridad'
' Fecha: 19/jul/2016 09:14:44
'
' ©Juan Ricardo Diaz
'------------------------------------------------------------------------------
Public Class ConceptosCesantiasVariables
    
    Private _Codigo As Integer
    Private _id_sala As Boolean
    Private _id_prom As Boolean
    Private _id_aux As Boolean
    Private _Descripcion As String

   
    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Public Property id_sala() As Boolean
        Get
            Return _id_sala
        End Get
        Set(ByVal value As Boolean)
            _id_sala = value
        End Set
    End Property
    Public Property id_prom() As Boolean
        Get
            Return _id_prom
        End Get
        Set(ByVal value As Boolean)
            _id_prom = value
        End Set
    End Property
    Public Property id_aux() As Boolean
        Get
            Return _id_aux
        End Get
        Set(ByVal value As Boolean)
            _id_aux = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosCesantiasVariablesValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosCesantiasVariablesValidator(), Me)
    End Function

End Class

''' <summary>
''' Clase para validar la clase entidad ConceptosCesantiasVariables
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosCesantiasVariablesValidator
    Inherits AbstractValidator(Of ConceptosCesantiasVariables)

    Sub New()
        RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class

