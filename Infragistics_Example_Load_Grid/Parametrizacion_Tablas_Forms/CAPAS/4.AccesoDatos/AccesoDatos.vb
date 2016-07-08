Imports System.ComponentModel
Imports System.Data.SqlClient
Imports AccesoDatosAlk
Public Class AccesoDatos

    Dim Conexion As String = Configuration.ConfigurationManager.AppSettings("Conexion").ToString


#Region "ADMINISTRAR CAJAS COMPENSACION"

    Function Crear_Cajas_de_Compensacion(ByVal Codigo As Integer, ByVal Nombre As String, ByVal Cuenta As String, ByVal Nit As String, ByVal NitExp As String, ByVal Depto As Integer, ByVal Municipio As String, ByVal CodigoSuratep As String) As Integer
        Dim respuesta As Integer = 0
        Try
            respuesta = AccesoDatosAlk.SQL.ExecuteScalar(Conexion, "dbo.Proc_Nom_Crear_Cajas_de_Compensacion", Codigo, Nombre, Cuenta, Nit, NitExp, Depto, Municipio, CodigoSuratep)
        Catch ex As Exception
            respuesta = 0
        End Try
        Return respuesta
    End Function

    Function Listar_Cajas_de_Compensacion() As BindingList(Of CajasCompensacion)
        Dim Lista As New BindingList(Of CajasCompensacion)
        Try
            Dim Dr As SqlDataReader
            Dr = AccesoDatosAlk.SQL.ExecuteReader(Conexion, "dbo.Proc_Nom_Listar_Cajas_de_Compensacion")
            If Dr.HasRows Then
                While Dr.Read
                    Lista.Add(New CajasCompensacion(Dr.Item("Codigo"), Dr.Item("Nombre"), Dr.Item("Cuenta"), Dr.Item("Nit"), Dr.Item("NitExp"), Dr.Item("Depto"), Dr.Item("Municipio"), Dr.Item("CodigoSuratep")))
                End While
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
        Return Lista
    End Function

    Function Actualizar_Cajas_de_Compensacion(ByVal Codigo As Integer, ByVal Nombre As String, ByVal Cuenta As String, ByVal Nit As String, ByVal NitExp As String, ByVal Depto As Integer, ByVal Municipio As String, ByVal CodigoSuratep As String) As Integer
        Dim respuesta As Integer = 0
        Try
            respuesta = AccesoDatosAlk.SQL.ExecuteScalar(Conexion, "dbo.Proc_Nom_Actualizar_Cajas_de_Compensacion", Codigo, Nombre, Cuenta, Nit, NitExp, Depto, Municipio, CodigoSuratep)
        Catch ex As Exception
            Throw (ex)
        End Try
        Return respuesta
    End Function
#End Region

End Class
