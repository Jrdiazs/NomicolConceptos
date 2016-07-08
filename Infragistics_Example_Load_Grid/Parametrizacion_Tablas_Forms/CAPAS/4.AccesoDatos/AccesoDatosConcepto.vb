Imports AccesoDatosAlk
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class AccesoDatosConcepto
    Shared Conexion As String = Configuration.ConfigurationManager.AppSettings("Conexion").ToString

#Region "[Metodos Comunes]"
    ''' <summary>
    ''' Crear un SqlParameter tipo Input
    ''' </summary>
    ''' <param name="Nombre">Nombre del parametro</param>
    ''' <param name="Valor">Valor del parametro</param>
    ''' <returns>SqlParameter</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-07</remarks>
    Public Shared Function ParametroInput(ByVal Nombre As String, ByVal Valor As Object) As SqlParameter
        Dim Param As New SqlParameter(Nombre, Valor)
        Param.Direction = ParameterDirection.Input
        Return Param
    End Function
    ''' <summary>
    ''' Crear un SqlParameter de tipo Output
    ''' </summary>
    ''' <param name="Nombre">Nombre del parametro</param>
    ''' <param name="Size">Tamaño en longitud del parametro</param>
    ''' <returns>SqlParameter</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-07</remarks>
    Public Shared Function ParametroOutput(ByVal Nombre As String, ByVal Size As Integer) As SqlParameter
        Dim Param As New SqlParameter()
        Param.Direction = ParameterDirection.Output
        Param.Size = Size
        Param.ParameterName = Nombre
        Return Param
    End Function
    ''' <summary>
    ''' Crea un SqlParameter de tipi OutputInput
    ''' </summary>
    ''' <param name="Nombre">Nombre del parametro</param>
    ''' <param name="Valor">Valor del parametro</param>
    ''' <param name="Size">Tamaño en longitud del parametro</param>
    ''' <returns>SqlParameter</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-07</remarks>
    Public Shared Function ParametroOutputInput(ByVal Nombre As String, ByVal Valor As Object, ByVal Size As Integer) As SqlParameter
        Dim Param As New SqlParameter()
        Param.Direction = ParameterDirection.InputOutput
        Param.Size = Size
        Param.ParameterName = Nombre
        Param.Value = Valor
        Return Param
    End Function
#End Region
#Region "[Conceptos]"
    ''' <summary>
    ''' Consulta todo el listado de la tabla conceptos
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <param name="Descripcion">Descripcion del concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function ConsultarConceptos(ByVal Codigo As Integer?, ByVal Descripcion As String) As List(Of Conceptos)
        Dim Conceptos As New List(Of Conceptos)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(Conexion, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("Codigo", Codigo), _
                                                             ParametroInput("Descripcion", Descripcion)})

            If Reader.HasRows Then
                Using Reader
                    AutoMapper.Mapper.CreateMap(Of IDataReader, Conceptos)()
                    Conceptos = AutoMapper.Mapper.Map(Of IDataReader, IList(Of Conceptos))(Reader)
                End Using
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto por id
    ''' </summary>
    ''' <param name="Codigo">Codigo Id</param>
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-17</remarks>
    Public Shared Function ConsultarConceptosPorId(ByVal Codigo As Integer) As Conceptos
        Dim Conceptos As Conceptos = Nothing
        Try
            Conceptos = ConsultarConceptos(Codigo, Nothing).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Shared Function GuardarConcepto(ByVal Concepto As Conceptos) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                        ParametroInput("@Codigo", Concepto.Codigo), _
                                                        ParametroInput("@Descripcion", Concepto.Descripcion), _
                                                        ParametroInput("@Tipo", Concepto.Tipo), _
                                                        ParametroInput("@Porcentaje", Concepto.Porcentaje), _
                                                        ParametroInput("@Prima", Concepto.Prima), _
                                                        ParametroInput("@Cesantias", Concepto.Cesantias), _
                                                        ParametroInput("@Dominicales", Concepto.Dominicales), _
                                                        ParametroInput("@Periodo", Concepto.Periodo), _
                                                        ParametroInput("@Iss", Concepto.Iss), _
                                                        ParametroInput("@Retencion", Concepto.Retencion), _
                                                        ParametroInput("@Vacaciones", Concepto.Vacaciones), _
                                                        ParametroInput("@Auxtrans", Concepto.Auxtrans), _
                                                        ParametroInput("@Clase", Concepto.Clase), _
                                                        ParametroInput("@ManejoConfianza", Concepto.ManejoConfianza), _
                                                        ParametroInput("@TipoAusencia", Concepto.TipoAusencia), _
                                                        ParametroInput("@CuentaAdministración", Concepto.CuentaAdministración), _
                                                        ParametroInput("@CuentaVentas", Concepto.CuentaVentas), _
                                                        ParametroInput("@Cotizacion", Concepto.Cotizacion), _
                                                        ParametroInput("@Autoliquidacion", Concepto.Autoliquidacion), _
                                                        ParametroInput("@CuentaPeoplesoft", Concepto.CuentaPeoplesoft), _
                                                        ParametroInput("@CuentaAlternativa", Concepto.CuentaAlternativa), _
                                                        ParametroInput("@CuentaI", Concepto.CuentaI), _
                                                        ParametroInput("@CuentaIgualAltn", Concepto.CuentaIgualAltn), _
                                                        ParametroInput("@TipoAusenciaNuevo", Concepto.TipoAusenciaNuevo), _
                                                        ParametroInput("@ConceptoContrapartida", Concepto.ConceptoContrapartida), _
                                                        ParametroInput("@Contrapartida", Concepto.Contrapartida), _
                                                        ParametroInput("@Saldos", Concepto.Saldos), _
                                                        ParametroInput("@Nomina", Concepto.Nomina), _
                                                        ParametroInput("@DptoExp", Concepto.DptoExp), _
                                                        ParametroInput("@Tercero", Concepto.Tercero), _
                                                        ParametroInput("@NoConstitutivoSS", Concepto.NoConstitutivoSS), _
                                                        ParametroInput("@NovPendientes", Concepto.NovPendientes), _
                                                        ParametroInput("@Compl_Exonerado_P", Concepto.Compl_Exonerado_P)})

            Return SQL.ExecuteNonQuery(Conexion, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_INSERTAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
