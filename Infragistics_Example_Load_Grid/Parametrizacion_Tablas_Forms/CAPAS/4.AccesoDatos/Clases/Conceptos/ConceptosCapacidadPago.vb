Imports FluentValidation

Public Class ConceptosCapacidadPago

    Private _CodigoConcepto As Integer
    Private _Descripcion As String
    Private _IngresoDeduccion As Integer

    Public Property CodigoConcepto() As Integer
        Get
            Return _CodigoConcepto
        End Get
        Set(ByVal value As Integer)
            _CodigoConcepto = value
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

    Public Property IngresoDeduccion() As Integer
        Get
            Return _IngresoDeduccion
        End Get
        Set(ByVal value As Integer)
            _IngresoDeduccion = value
        End Set
    End Property

    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosCapacidadPago
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosCapacidadPagoValidator(), Me)
    End Function

End Class

''' <summary>
''' Clase para validar la clase entidad ConceptosCapacidadPago
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosCapacidadPagoValidator
    Inherits AbstractValidator(Of ConceptosCapacidadPago)

    Sub New()
        RuleFor(Function(x) x.CodigoConcepto).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
        RuleFor(Function(x) x.IngresoDeduccion).NotNull().WithMessage("El Ingreso no puede ser 0").WithName("Ingreso Deducción")
    End Sub

End Class
