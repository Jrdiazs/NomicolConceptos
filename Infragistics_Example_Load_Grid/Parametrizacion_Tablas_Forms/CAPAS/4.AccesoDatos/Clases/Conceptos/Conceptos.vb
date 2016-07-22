Imports FluentValidation
''' <summary>
''' Clase entidad equivalente a CONCEPTOS
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
Public Class Conceptos

#Region "Properties"
    Private _codigo As Integer
    Public Property Codigo() As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property
    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Private _tipo As Short
    Public Property Tipo() As Short
        Get
            Return _tipo
        End Get
        Set(ByVal value As Short)
            _tipo = value
        End Set
    End Property
    Private _porcentaje As Double
    Public Property Porcentaje() As Double
        Get
            Return _porcentaje
        End Get
        Set(ByVal value As Double)
            _porcentaje = value
        End Set
    End Property
    Private _prima As Boolean
    Public Property Prima() As Boolean
        Get
            Return _prima
        End Get
        Set(ByVal value As Boolean)
            _prima = value
        End Set
    End Property
    Private _cesantias As Boolean
    Public Property Cesantias() As Boolean
        Get
            Return _cesantias
        End Get
        Set(ByVal value As Boolean)
            _cesantias = value
        End Set
    End Property
    Private _dominicales As Boolean
    Public Property Dominicales() As Boolean
        Get
            Return _dominicales
        End Get
        Set(ByVal value As Boolean)
            _dominicales = value
        End Set
    End Property
    Private _periodo As Short
    Public Property Periodo() As Short
        Get
            Return _periodo
        End Get
        Set(ByVal value As Short)
            _periodo = value
        End Set
    End Property
    Private _iss As Boolean
    Public Property Iss() As Boolean
        Get
            Return _iss
        End Get
        Set(ByVal value As Boolean)
            _iss = value
        End Set
    End Property
    Private _retencion As Boolean
    Public Property Retencion() As Boolean
        Get
            Return _retencion
        End Get
        Set(ByVal value As Boolean)
            _retencion = value
        End Set
    End Property
    Private _vacaciones As Boolean
    Public Property Vacaciones() As Boolean
        Get
            Return _vacaciones
        End Get
        Set(ByVal value As Boolean)
            _vacaciones = value
        End Set
    End Property
    Private _auxtrans As Boolean
    Public Property Auxtrans() As Boolean
        Get
            Return _auxtrans
        End Get
        Set(ByVal value As Boolean)
            _auxtrans = value
        End Set
    End Property
    Private _clase As Short?
    Public Property Clase() As Short?
        Get
            Return _clase
        End Get
        Set(ByVal value As Short?)
            _clase = value
        End Set
    End Property
    Private _manejoConfianza As Boolean
    Public Property ManejoConfianza() As Boolean
        Get
            Return _manejoConfianza
        End Get
        Set(ByVal value As Boolean)
            _manejoConfianza = value
        End Set
    End Property
    Private _tipoAusencia As Double
    Public Property TipoAusencia() As Double
        Get
            Return _tipoAusencia
        End Get
        Set(ByVal value As Double)
            _tipoAusencia = value
        End Set
    End Property
    Private _cuentaAdministración As String
    Public Property CuentaAdministración() As String
        Get
            Return _cuentaAdministración
        End Get
        Set(ByVal value As String)
            _cuentaAdministración = value
        End Set
    End Property
    Private _cuentaVentas As String
    Public Property CuentaVentas() As String
        Get
            Return _cuentaVentas
        End Get
        Set(ByVal value As String)
            _cuentaVentas = value
        End Set
    End Property
    Private _cotizacion As Boolean
    Public Property Cotizacion() As Boolean
        Get
            Return _cotizacion
        End Get
        Set(ByVal value As Boolean)
            _cotizacion = value
        End Set
    End Property
    Private _autoliquidacion As Boolean
    Public Property Autoliquidacion() As Boolean
        Get
            Return _autoliquidacion
        End Get
        Set(ByVal value As Boolean)
            _autoliquidacion = value
        End Set
    End Property
    Private _cuentaPeoplesoft As String
    Public Property CuentaPeoplesoft() As String
        Get
            Return _cuentaPeoplesoft
        End Get
        Set(ByVal value As String)
            _cuentaPeoplesoft = value
        End Set
    End Property
    Private _cuentaAlternativa As String
    Public Property CuentaAlternativa() As String
        Get
            Return _cuentaAlternativa
        End Get
        Set(ByVal value As String)
            _cuentaAlternativa = value
        End Set
    End Property
    Private _cuentaI As Boolean?
    Public Property CuentaI() As Boolean?
        Get
            Return _cuentaI
        End Get
        Set(ByVal value As Boolean?)
            _cuentaI = value
        End Set
    End Property
    Private _cuentaIgualAltn As Boolean?
    Public Property CuentaIgualAltn() As Boolean?
        Get
            Return _cuentaIgualAltn
        End Get
        Set(ByVal value As Boolean?)
            _cuentaIgualAltn = value
        End Set
    End Property
    Private _tipoAusenciaNuevo As Integer?
    Public Property TipoAusenciaNuevo() As Integer?
        Get
            Return _tipoAusenciaNuevo
        End Get
        Set(ByVal value As Integer?)
            _tipoAusenciaNuevo = value
        End Set
    End Property
    Private _conceptoContrapartida As Integer?
    Public Property ConceptoContrapartida() As Integer?
        Get
            Return _conceptoContrapartida
        End Get
        Set(ByVal value As Integer?)
            _conceptoContrapartida = value
        End Set
    End Property
    Private _contrapartida As String
    Public Property Contrapartida() As String
        Get
            Return _contrapartida
        End Get
        Set(ByVal value As String)
            _contrapartida = value
        End Set
    End Property
    Private _saldos As Boolean?
    Public Property Saldos() As Boolean?
        Get
            Return _saldos
        End Get
        Set(ByVal value As Boolean?)
            _saldos = value
        End Set
    End Property
    Private _nomina As Boolean?
    Public Property Nomina() As Boolean?
        Get
            Return _nomina
        End Get
        Set(ByVal value As Boolean?)
            _nomina = value
        End Set
    End Property
    Private _dptoExp As Integer?
    Public Property DptoExp() As Integer?
        Get
            Return _dptoExp
        End Get
        Set(ByVal value As Integer?)
            _dptoExp = value
        End Set
    End Property
    Private _tercero As Boolean?
    Public Property Tercero() As Boolean?
        Get
            Return _tercero
        End Get
        Set(ByVal value As Boolean?)
            _tercero = value
        End Set
    End Property
    Private _noConstitutivoSS As Boolean
    Public Property NoConstitutivoSS() As Boolean
        Get
            Return _noConstitutivoSS
        End Get
        Set(ByVal value As Boolean)
            _noConstitutivoSS = value
        End Set
    End Property
    Private _novPendientes As Boolean
    Public Property NovPendientes() As Boolean
        Get
            Return _novPendientes
        End Get
        Set(ByVal value As Boolean)
            _novPendientes = value
        End Set
    End Property
    Private _compl_Exonerado_P As Boolean
    Public Property Compl_Exonerado_P() As Boolean
        Get
            Return _compl_Exonerado_P
        End Get
        Set(ByVal value As Boolean)
            _compl_Exonerado_P = value
        End Set
    End Property
#End Region
    ''' <summary>
    ''' Metodo para validar la entidad de conceptos por medio de la clase ConceptosValidator
    ''' </summary>
    ''' <param name="Errores">retorna el mensaje de error de las validaciones de la entidad</param>
    ''' <returns>true si la entidad es valida</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Function Validar(ByRef Errores As String) As Boolean
        Return ComunesConcepto.Validar(Errores, New ConceptosValidator(), Me)
    End Function

End Class
''' <summary>
''' Clase para validad la entidad de conceptos
''' </summary>
''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
Public Class ConceptosValidator
    Inherits AbstractValidator(Of Conceptos)

    Sub New()
        RuleFor(Function(x) x.Codigo).NotNull().WithMessage("El Código no puede ser 0").WithName("Código")
        RuleFor(Function(x) x.Descripcion).NotNull().WithMessage("La Descripción no puede ser null").WithName("Descripción")
        RuleFor(Function(x) x.CuentaAdministración).NotNull().WithMessage("La cuenta de Administración no puede ser null").Length(0, 50).WithMessage("La cuenta de Administracion no puede pasar de 50 caracteres").WithName("Cuenta Administración")
        RuleFor(Function(x) x.CuentaVentas).NotNull().WithMessage("La Cuenta de Ventas no puede ser null").Length(0, 50).WithMessage("La Cuenta de Ventas no puede pasar de 50 caracteres").WithName("Cuenta Ventas")
        RuleFor(Function(x) x.CuentaPeoplesoft).Length(0, 50).WithMessage("La Cuenta People Soft no puede pasar de 50 caracteres").WithName("Cuenta People Soft")
        RuleFor(Function(x) x.CuentaAlternativa).Length(0, 50).WithMessage("La Cuenta Alternativa no puede pasar de 50 caracteres").WithName("Cuenta Alternativa")
        RuleFor(Function(x) x.Contrapartida).Length(0, 50).WithMessage("La Contra partida no puede pasar de 50 caracteres").WithName("Contra Partida")
    End Sub

End Class
