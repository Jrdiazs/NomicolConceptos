Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_PENSIONES_VOLUNTARIAS generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_PENSIONES_VOLUNTARIAS' de la base 'NomicolSeguridad'
' Fecha: 19/jul/2016 13:19:25
'
' ©Juan Ricardo Diaz s
'------------------------------------------------------------------------------
'
Public Class ConceptosPensionesVoluntarias
   
    Private _Codigo As Integer
    Private _Devengados As Boolean
    Private _Tipo_Devengado As Int16
    Private _Pension_Obligatoria As Boolean
    Private _Tipo_Pension_Obligatoria As Integer?
    Private _Solidaridad_Pensional As Boolean
    Private _Tipo_Solidaridad_Pensional As Integer?
    Private _Pension_Voluntaria As Boolean
    Private _Tipo_Pension_Voluntaria As Integer?

    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Public Property Devengados() As Boolean
        Get
            Return _Devengados
        End Get
        Set(ByVal value As Boolean)
            _Devengados = value
        End Set
    End Property
    Public Property Tipo_Devengado() As Int16
        Get
            Return _Tipo_Devengado
        End Get
        Set(ByVal value As Int16)
            _Tipo_Devengado = value
        End Set
    End Property
    Public Property Pension_Obligatoria() As Boolean
        Get
            Return _Pension_Obligatoria
        End Get
        Set(ByVal value As Boolean)
            _Pension_Obligatoria = value
        End Set
    End Property
    Public Property Tipo_Pension_Obligatoria() As Integer?
        Get
            Return _Tipo_Pension_Obligatoria
        End Get
        Set(ByVal value As Integer?)
            _Tipo_Pension_Obligatoria = value
        End Set
    End Property
    Public Property Solidaridad_Pensional() As Boolean
        Get
            Return _Solidaridad_Pensional
        End Get
        Set(ByVal value As Boolean)
            _Solidaridad_Pensional = value
        End Set
    End Property
    Public Property Tipo_Solidaridad_Pensional() As Integer?
        Get
            Return _Tipo_Solidaridad_Pensional
        End Get
        Set(ByVal value As Integer?)
            _Tipo_Solidaridad_Pensional = value
        End Set
    End Property
    Public Property Pension_Voluntaria() As Boolean
        Get
            Return _Pension_Voluntaria
        End Get
        Set(ByVal value As Boolean)
            _Pension_Voluntaria = value
        End Set
    End Property
    Public Property Tipo_Pension_Voluntaria() As Integer?
        Get
            Return _Tipo_Pension_Voluntaria
        End Get
        Set(ByVal value As Integer?)
            _Tipo_Pension_Voluntaria = value
        End Set
    End Property

    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosPensionesVoluntariasValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosPensionesVoluntariasValidator(), Me)
    End Function

End Class

''' <summary>
''' Clase para validar la clase entidad ConceptosPensionesVoluntariasValidator
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosPensionesVoluntariasValidator
    Inherits AbstractValidator(Of ConceptosPensionesVoluntarias)

    Sub New()
        RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class
