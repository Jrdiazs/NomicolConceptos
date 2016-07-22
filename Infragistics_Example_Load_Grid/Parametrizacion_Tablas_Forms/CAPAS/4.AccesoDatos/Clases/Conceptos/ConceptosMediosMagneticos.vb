Imports FluentValidation

'------------------------------------------------------------------------------
' Clase CONCEPTOS_MEDIOS_MAGNETICOS generada automáticamente con CrearClaseSQL
' de la tabla 'CONCEPTOS_MEDIOS_MAGNETICOS' de la base 'NomicolSeguridad'
' Fecha: 19/jul/2016 11:24:22
'
' ©Juan Ricardo Diaz
'------------------------------------------------------------------------------
'
Public Class ConceptosMediosMagneticos
    
    Private _CodMedio As Integer?
    Private _Codigo As Integer?
    Private _Consec As Integer
    Private _Descripcion As String
   
    Public Property CodMedio() As Integer?
        Get
            Return _CodMedio
        End Get
        Set(ByVal value As Integer?)
            _CodMedio = value
        End Set
    End Property
    Public Property Codigo() As Integer?
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer?)
            _Codigo = value
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
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property


    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosMediosMagneticosValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosMediosMagneticosValidator(), Me)
    End Function

End Class
''' <summary>
''' Clase para validar la clase entidad ConceptosMediosMagneticos
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-18</remarks>
Public Class ConceptosMediosMagneticosValidator
    Inherits AbstractValidator(Of ConceptosMediosMagneticos)

    Sub New()
        'RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
    End Sub

End Class
