Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_PRIMA_VARIABLE_LIQUIDACION generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_PRIMA_VARIABLE_LIQUIDACION' de la base 'NomicolSeguridad'
' Fecha: 21/jul/2016 13:37:21
'
' ©Juan Ricardo Diaz
'------------------------------------------------------------------------------
Public Class ConceptosPrimaVariableLiquidacion

    Private _Codigo As Integer?
    Private _id_sala As Boolean
    Private _id_prom As Boolean
    Private _id_aux As Boolean
    Private _Consec As Integer

    Public Property Codigo() As Integer?
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer?)
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
    Public Property Consec() As Integer
        Get
            Return _Consec
        End Get
        Set(ByVal value As Integer)
            _Consec = value
        End Set
    End Property
    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosPrimaVariableLiquidacionValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosPrimaVariableLiquidacionValidator(), Me)
    End Function
End Class
''' <summary>
''' Clase para validar la clase entidad ConceptosPrimaVariableLiquidacion
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosPrimaVariableLiquidacionValidator
    Inherits AbstractValidator(Of ConceptosPrimaVariableLiquidacion)

    Sub New()
        'RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class