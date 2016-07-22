Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_APORTES_PARAFISCALES_ICBF generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_APORTES_PARAFISCALES_ICBF' de la base 'NomicolSeguridad'
' Fecha: 11/jul/2016 08:52:33
'
' ©Juan Ricardo Diaz
'------------------------------------------------------------------------------

Public Class ConceptosAportesParafiscalesICBF


    Private _Codigo As Integer
    Private _Integral As Boolean
    Private _Negativo As Integer?
   
    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
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


    Public Property Negativo() As Integer?
        Get
            Return _Negativo
        End Get
        Set(ByVal value As Integer?)
            _Negativo = value
        End Set
    End Property

    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosParafiscalesICBFValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosParafiscalesICBFValidator(), Me)
    End Function

End Class
''' <summary>
''' Clase para validar la clase entidad ConceptosAportesParafiscalesICBF
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosParafiscalesICBFValidator
    Inherits AbstractValidator(Of ConceptosAportesParafiscalesICBF)

    Sub New()
        RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class
