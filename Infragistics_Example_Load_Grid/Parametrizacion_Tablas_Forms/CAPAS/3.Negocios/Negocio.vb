Imports System.ComponentModel

Public Class Negocio

    Dim AuxAccesoDatos As New AccesoDatos


#Region "ADMINISTRAR CAJAS COMPENSACION"

    Function Listar_Cajas_de_Compensacion() As BindingList(Of CajasCompensacion)
        Dim Lista As New BindingList(Of CajasCompensacion)
        Try
            Lista = AuxAccesoDatos.Listar_Cajas_de_Compensacion()
        Catch ex As Exception
            Throw (ex)
        End Try
        Return Lista
    End Function

    Function Actualizar_Cajas_de_Compensacion(ByVal Codigo As Integer, ByVal Nombre As String, ByVal Cuenta As String, ByVal Nit As String, ByVal NitExp As String, ByVal Depto As Integer, ByVal Municipio As String, ByVal CodigoSuratep As String) As Integer
        Dim respuesta As Integer = 0
        Try
            respuesta = AuxAccesoDatos.Actualizar_Cajas_de_Compensacion(Codigo, Nombre, Cuenta, Nit, NitExp, Depto, Municipio, CodigoSuratep)
        Catch ex As Exception
            Throw (ex)
        End Try
        Return respuesta
    End Function
#End Region

End Class
