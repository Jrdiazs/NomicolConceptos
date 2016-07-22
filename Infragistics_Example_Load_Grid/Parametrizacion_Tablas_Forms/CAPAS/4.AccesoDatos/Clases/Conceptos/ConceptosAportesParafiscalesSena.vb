Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_APORTES_PARAFISCALES_SENA generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_APORTES_PARAFISCALES_SENA' de la base 'NomicolSeguridad'
' Fecha: 12/jul/2016 16:09:41
'
' ©Juan Ricardo Diaz
'------------------------------------------------------------------------------
Public Class ConceptosAportesParafiscalesSena
   
    Private _Codigo As Integer
    Private _Integral As Boolean
    Private _Negativo As Integer?
    Private _Descripcion As String
  
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

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
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
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosAportesParafiscalesSena
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosParafiscalesSenaValidator(), Me)
    End Function

End Class

''' <summary>
''' Clase para validar la clase entidad ConceptosAportesParafiscalesSena
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosParafiscalesSenaValidator
    Inherits AbstractValidator(Of ConceptosAportesParafiscalesSena)

    Sub New()
        RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class
