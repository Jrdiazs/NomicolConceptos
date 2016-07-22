Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_PRIMA_FIJO_LIQUIDACION generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_PRIMA_FIJO_LIQUIDACION' de la base 'NomicolSeguridad'
' Fecha: 21/jul/2016 09:42:47
'
' ©Juan Ricardo Diaz 
'------------------------------------------------------------------------------
Public Class ConceptosPrimaFijoLiquidacion
    
    Private _Codigo As Integer
    Private _id_sala As Boolean
    Private _id_prom As Boolean
    Private _id_aux As Boolean

  
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


    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosPrimaFijoLiquidacionValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosPrimaFijoLiquidacionValidator(), Me)
    End Function

End Class
''' <summary>
''' Clase para validar la clase entidad ConceptosPrimaFijoLiquidacion
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosPrimaFijoLiquidacionValidator
    Inherits AbstractValidator(Of ConceptosPrimaFijoLiquidacion)

    Sub New()
        RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class
