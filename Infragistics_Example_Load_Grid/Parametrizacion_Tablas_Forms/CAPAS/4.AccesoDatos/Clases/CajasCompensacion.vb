Public Class CajasCompensacion

    Sub New(ByVal Codigo As Integer, ByVal Nombre As String, ByVal Cuenta As String, ByVal Nit As String, ByVal NitExp As String, ByVal Depto As Integer, ByVal Municipio As String, ByVal CodigoSuratep As String)
        Me.Codigo = Codigo
        Me.Nombre = Nombre
        Me.Cuenta = Cuenta
        Me.Nit = Nit
        Me.NitExp = NitExp
        Me.Depto = Depto
        Me.Municipio = Municipio
        Me.CodigoSuratep = CodigoSuratep
    End Sub


    Private _Codigo As Integer
    Public Property Codigo() As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property


    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property


    Private _Cuenta As String
    Public Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal value As String)
            _Cuenta = value
        End Set
    End Property


    Private _Nit As String
    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property


    Private _NitExp As String
    Public Property NitExp() As String
        Get
            Return _NitExp
        End Get
        Set(ByVal value As String)
            _NitExp = value
        End Set
    End Property


    Private _Depto As Integer
    Public Property Depto() As Integer
        Get
            Return _Depto
        End Get
        Set(ByVal value As Integer)
            _Depto = value
        End Set
    End Property


    Private _Municipio As String
    Public Property Municipio() As String
        Get
            Return _Municipio
        End Get
        Set(ByVal value As String)
            _Municipio = value
        End Set
    End Property


    Private _CodigoSuratep As String
    Public Property CodigoSuratep() As String
        Get
            Return _CodigoSuratep
        End Get
        Set(ByVal value As String)
            _CodigoSuratep = value
        End Set
    End Property


End Class
