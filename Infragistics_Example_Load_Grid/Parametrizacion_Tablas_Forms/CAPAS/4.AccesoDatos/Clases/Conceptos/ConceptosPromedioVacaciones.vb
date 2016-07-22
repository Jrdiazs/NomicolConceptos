Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_PROMEDIO_VACACIONES generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_PROMEDIO_VACACIONES' de la base 'NomicolSeguridad'
' Fecha: 21/jul/2016 16:48:43
'
' ©Juan Ricardo Diaz Suancha
'------------------------------------------------------------------------------

'
Public Class ConceptosPromedioVacaciones

    Private _Concepto As Integer
    Private _TipoSalario As Int16


    Public Property Concepto() As Integer
        Get
            Return _Concepto
        End Get
        Set(ByVal value As Integer)
            _Concepto = value
        End Set
    End Property
    Public Property TipoSalario() As Int16
        Get
            Return _TipoSalario
        End Get
        Set(ByVal value As Int16)
            _TipoSalario = value
        End Set
    End Property

    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosPromedioVacacionesValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosPromedioVacacionesValidator(), Me)
    End Function

End Class

''' <summary>
''' Clase para validar la clase entidad ConceptosPromedioVacaciones
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosPromedioVacacionesValidator
    Inherits AbstractValidator(Of ConceptosPromedioVacaciones)

    Sub New()
        RuleFor(Function(x) x.Concepto).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
        RuleFor(Function(x) x.TipoSalario).NotNull().WithMessage("El Tipo de salario no puede ser 0").WithName("Tipo Salario")
    End Sub

End Class

