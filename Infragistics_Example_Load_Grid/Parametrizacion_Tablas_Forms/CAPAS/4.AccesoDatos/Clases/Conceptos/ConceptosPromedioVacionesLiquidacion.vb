Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_PROMEDIO_VACACIONES_LIQUIDACION generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_PROMEDIO_VACACIONES_LIQUIDACION' de la base 'NomicolSeguridad'
' Fecha: 21/jul/2016 16:51:22
'
' ©Juan Ricardo Diaz S
'------------------------------------------------------------------------------
Public Class ConceptosPromedioVacionesLiquidacion

    Private _TipoSalario As Int16?
    Private _Integral As Boolean
    Private _Concepto As Integer?
    Private _id_sala As Boolean
    Private _id_prom As Boolean
    Private _Consecutivo As Integer

    Public Property TipoSalario() As Int16?
        Get
            Return _TipoSalario
        End Get
        Set(ByVal value As Int16?)
            _TipoSalario = value
        End Set
    End Property
    Public Property Integral() As Boolean
        Get
            Return _Integral
        End Get
        Set(ByVal value As Boolean)
            _Integral = value
        End Set
    End Property
    Public Property Concepto() As Integer?
        Get
            Return _Concepto
        End Get
        Set(ByVal value As Integer?)
            _Concepto = value
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
    Public Property Consecutivo() As Integer
        Get
            Return _Consecutivo
        End Get
        Set(ByVal value As Integer)
            _Consecutivo = value
        End Set
    End Property


    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosPromedioVacionesLiquidacionValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosPromedioVacionesLiquidacionValidator(), Me)
    End Function

End Class

''' <summary>
''' Clase para validar la clase entidad ConceptosPromedioVacionesLiquidacionValidator
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosPromedioVacionesLiquidacionValidator
    Inherits AbstractValidator(Of ConceptosPromedioVacionesLiquidacion)

    Sub New()
        'RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class
