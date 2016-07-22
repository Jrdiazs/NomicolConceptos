Imports AccesoDatosAlk
Imports System.Data.SqlClient
Imports System.ComponentModel
''' <summary>
''' Clase de acceso a datos para las tablas de concetp
''' </summary>
''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
Public Class AccesoDatosConcepto
    Shared StrConnections As String = Configuration.ConfigurationManager.AppSettings("Conexion").ToString

#Region "[Metodos Comunes]"
    ''' <summary>
    ''' Crear un SqlParameter tipo Input
    ''' </summary>
    ''' <param name="Nombre">Nombre del parametro</param>
    ''' <param name="Valor">Valor del parametro</param>
    ''' <returns>SqlParameter</returns>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-07</remarks>
    Public Shared Function ParametroInput(ByVal Nombre As String, ByVal Valor As Object) As SqlParameter
        Dim Param As New SqlParameter()

        If Valor Is Nothing Then
            Param.Value = DBNull.Value
        Else
            Param.Value = Valor
        End If

        Param.ParameterName = Nombre
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

        If Valor Is Nothing Then
            Param.Value = DBNull.Value
        Else
            Param.Value = Valor
        End If
        Return Param
    End Function
#End Region
#Region "[Conceptos]"
    ''' <summary>
    ''' Elimina el concepto por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConcepto(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
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
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo), _
                                                             ParametroInput("@Descripcion", Descripcion)})

            Conceptos = ComunesConcepto.ToListMap(Of Conceptos)(Reader)
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

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_INSERTAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_APORTES_PARAFISCALES_CAJA]"
    ''' <summary>
    ''' Elimina el concepto parafiscal caja por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoParafiscalCaja(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_CAJA_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Consulta todo el listado de la tabla CONCEPTOS_APORTES_PARAFISCALES_CAJA
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-12</remarks>
    Public Shared Function ConsultarConceptosAportesParafiscalesCaja(ByVal Codigo As Integer?) As List(Of ConceptosAportesParaFiscalesCaja)
        Dim Conceptos As New List(Of ConceptosAportesParaFiscalesCaja)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_CAJA_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosAportesParaFiscalesCaja)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto aporte parafiscal caja por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosAportesParafiscalesCaja</returns>
    ''' <remarks>Juan R Diaz 2016-07-12</remarks>
    Public Shared Function ConsultarConceptosAportesParafiscalesCajaPorId(ByVal Codigo As Integer) As ConceptosAportesParaFiscalesCaja
        Dim Concepto As ConceptosAportesParaFiscalesCaja = Nothing
        Try
            Return ConsultarConceptosAportesParafiscalesCaja(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function

    ''' <summary>
    ''' Guarda o modifica el concepto parafiscal caja
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-12</remarks>
    Public Shared Function GuardarConceptoParafiscalCaja(ByVal Concepto As ConceptosAportesParaFiscalesCaja) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                        ParametroInput("@Codigo", Concepto.Codigo), _
                                                        ParametroInput("@Integral", Concepto.Integral), _
                                                        ParametroInput("@Negativo", Concepto.Negativo)})

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_CAJA_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_APORTES_PARAFISCALES_ICBF]"
    ''' <summary>
    ''' Elimina el concepto parafiscal ICBF por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoParafiscalICBF(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_ICBF_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Consulta todo el listado de la tabla CONCEPTOS_APORTES_PARAFISCALES_ICBF
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-12</remarks>
    Public Shared Function ConsultarConceptosAportesParafiscalesICBF(ByVal Codigo As Integer?) As List(Of ConceptosAportesParafiscalesICBF)
        Dim Conceptos As New List(Of ConceptosAportesParafiscalesICBF)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_ICBF_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosAportesParafiscalesICBF)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto aporte parafiscal ICBF por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosAportesParafiscalesICBF</returns>
    ''' <remarks>Juan R Diaz 2016-07-12</remarks>
    Public Shared Function ConsultarConceptosAportesParafiscalesICBFPorId(ByVal Codigo As Integer) As ConceptosAportesParafiscalesICBF
        Dim Concepto As ConceptosAportesParafiscalesICBF = Nothing
        Try
            Return ConsultarConceptosAportesParafiscalesICBF(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function

    ''' <summary>
    ''' Guarda o modifica el concepto parafiscal ICBF
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-12</remarks>
    Public Shared Function GuardarConceptoParafiscalICBF(ByVal Concepto As ConceptosAportesParafiscalesICBF) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                        ParametroInput("@Codigo", Concepto.Codigo), _
                                                        ParametroInput("@Integral", Concepto.Integral), _
                                                        ParametroInput("@Negativo", Concepto.Negativo)})

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_ICBF_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_APORTES_PARAFISCALES_SENA]"
    ''' <summary>
    ''' Elimina el concepto parafiscal SENA por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoParafiscalSENA(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_SENA_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto parafiscal Sena
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-12</remarks>
    Public Shared Function GuardarConceptoParafiscalSena(ByVal Concepto As ConceptosAportesParafiscalesSena) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                        ParametroInput("@Codigo", Concepto.Codigo), _
                                                        ParametroInput("@Integral", Concepto.Integral), _
                                                        ParametroInput("@Negativo", Concepto.Negativo)})

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_SENA_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosAportesParafiscalesSena
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosAportesParafiscalesSENA(ByVal Codigo As Integer?) As List(Of ConceptosAportesParafiscalesSena)
        Dim Conceptos As New List(Of ConceptosAportesParafiscalesSena)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_APORTES_PARAFISCALES_SENA_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosAportesParafiscalesSena)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto aporte parafiscal Sena por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosAportesParafiscalesSena</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosAportesParafiscalesSenaPorId(ByVal Codigo As Integer) As ConceptosAportesParafiscalesSena
        Dim Concepto As ConceptosAportesParafiscalesSena = Nothing
        Try
            Return ConsultarConceptosAportesParafiscalesSENA(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CAPACIDAD_PAGO]"
    ''' <summary>
    ''' Elimina el concepto capacidad pago por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoCapacidadPago(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CAPACIDAD_PAGO_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto capacidad de pago
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptoCapacidadPago(ByVal Concepto As ConceptosCapacidadPago) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                        ParametroInput("@CodigoConcepto", Concepto.CodigoConcepto), _
                                                        ParametroInput("@IngresoDeduccion", Concepto.IngresoDeduccion)})

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CAPACIDAD_PAGO_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosCapacidadPago
    ''' </summary>    
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCapacidadPago(ByVal Codigo As Integer?) As List(Of ConceptosCapacidadPago)
        Dim Conceptos As New List(Of ConceptosCapacidadPago)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CAPACIDAD_PAGO_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosCapacidadPago)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto capacidad de pago por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosCapacidadPago</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCapacidadPagoPorId(ByVal Codigo As Integer) As ConceptosCapacidadPago
        Dim Concepto As ConceptosCapacidadPago = Nothing
        Try
            Return ConsultarConceptosCapacidadPago(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CESANTIAS]"
    ''' <summary>
    ''' Elimina el concepto cesantias por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoCesantias(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto cesantias
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptoCesantias(ByVal Concepto As ConceptosCesantias) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@Codigo", Concepto.Codigo), _
                                                         ParametroInput("@Id_Fijo_Promedio", Concepto.Id_Fijo_Promedio), _
                                                         ParametroInput("@Id_Variable", Concepto.Id_Variable), _
                                                         ParametroInput("@Id_Fijo", Concepto.Id_Fijo)})

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosCesantias
    ''' </summary>    
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCesantias(ByVal Codigo As Integer?) As List(Of ConceptosCesantias)
        Dim Conceptos As New List(Of ConceptosCesantias)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosCesantias)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto cesantias por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosCesantias</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCesantiasPorId(ByVal Codigo As Integer) As ConceptosCesantias
        Dim Concepto As ConceptosCesantias = Nothing
        Try
            Return ConsultarConceptosCesantias(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CESANTIAS_FIJO]"
    ''' <summary>
    ''' Elimina el concepto cesantias fijo por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoCesantiasFijo(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_FIJO_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto cesantias fijo
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptoCesantiasFijo(ByVal Concepto As ConceptosCesantiasFijo) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@Codigo", Concepto.Codigo), _
                                                         ParametroInput("@id_sala", Concepto.id_sala), _
                                                         ParametroInput("@id_prom", Concepto.id_prom), _
                                                         ParametroInput("@id_aux", Concepto.id_aux)})

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_FIJO_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosCesantiasFijo
    ''' </summary>    
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCesantiasFijo(ByVal Codigo As Integer?) As List(Of ConceptosCesantiasFijo)
        Dim Conceptos As New List(Of ConceptosCesantiasFijo)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_FIJO_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosCesantiasFijo)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto cesantias fijo por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosCesantiasFijo</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCesantiasFijoPorId(ByVal Codigo As Integer) As ConceptosCesantiasFijo
        Dim Concepto As ConceptosCesantiasFijo = Nothing
        Try
            Return ConsultarConceptosCesantiasFijo(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CESANTIAS_VARIABLE]"
    ''' <summary>
    ''' Elimina el concepto cesantias variable por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoCesantiasVariable(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_VARIABLE_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto cesantias Variable
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptoCesantiasVariable(ByVal Concepto As ConceptosCesantiasVariables) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@Codigo", Concepto.Codigo), _
                                                         ParametroInput("@id_sala", Concepto.id_sala), _
                                                         ParametroInput("@id_prom", Concepto.id_prom), _
                                                         ParametroInput("@id_aux", Concepto.id_aux)})

            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_VARIABLE_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosCesantiasVariables
    ''' </summary>    
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCesantiasVariable(ByVal Codigo As Integer?) As List(Of ConceptosCesantiasVariables)
        Dim Conceptos As New List(Of ConceptosCesantiasVariables)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_VARIABLE_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosCesantiasVariables)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto cesantias variable fijo por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosCesantiasVariables</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosCesantiasVariablePorId(ByVal Codigo As Integer) As ConceptosCesantiasVariables
        Dim Concepto As ConceptosCesantiasVariables = Nothing
        Try
            Return ConsultarConceptosCesantiasVariable(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_MEDIOS_MAGNETICOS]"
    ''' <summary>
    ''' Elimina el concepto medios magneticos por id Consecutivo
    ''' </summary>
    ''' <param name="Consecutivo">Id Consec</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoMediosMagneticos(ByVal Consecutivo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_MEDIOSMAGNETICOS_ELIMINAR", Consecutivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto medios magneticos
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptoMediosMagneticos(ByVal Concepto As ConceptosMediosMagneticos) As ConceptosMediosMagneticos
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@CodMedio", Concepto.CodMedio), _
                                                         ParametroInput("@Codigo", Concepto.Codigo)})

            Dim NuevoConcepto = Concepto.Consec = 0

            If NuevoConcepto Then
                Parameters.Add(ParametroOutputInput("@Consec", Nothing, Integer.MaxValue))
            Else
                Parameters.Add(ParametroOutputInput("@Consec", Concepto.Consec, Integer.MaxValue))
            End If

            Dim RowsAfected = SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_MEDIOSMAGNETICOS_GUARDAR", Parameters.ToArray())

            Dim ParamConsecutivo = Parameters.Where(Function(x) x.ParameterName = "@Consec").FirstOrDefault()

            If Not IsDBNull(ParamConsecutivo.Value) And ParamConsecutivo.Value IsNot Nothing Then
                If ComunesConcepto.IsNumeric(ParamConsecutivo.Value.ToString()) Then
                    Concepto.Consec = Integer.Parse(ParamConsecutivo.Value)
                End If
            End If

            Return Concepto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosMediosMagneticos
    ''' </summary>    
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptoMediosMagneticos(ByVal Consecutivo As Integer?, ByVal Codigo As Integer?) As List(Of ConceptosMediosMagneticos)
        Dim Conceptos As New List(Of ConceptosMediosMagneticos)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_CESANTIAS_MEDIOSMAGNETICOS_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Consec", Consecutivo), _
                                                            ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosMediosMagneticos)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto medios magneticos por id consecutivo
    ''' </summary>
    ''' <param name="Consecutivo">Id Consecutvio</param>
    ''' <returns>ConceptosMediosMagneticos</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptoMediosMagneticosPorIdConsecutivo(ByVal Consecutivo As Integer) As ConceptosMediosMagneticos
        Dim Concepto As ConceptosMediosMagneticos = Nothing
        Try
            Return ConsultarConceptoMediosMagneticos(Consecutivo, Nothing).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function

    ''' <summary>
    ''' Consulta el concepto medios magneticos por id codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>ConceptosMediosMagneticos</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptoMediosMagneticosPorIdCodigo(ByVal Codigo As Integer) As ConceptosMediosMagneticos
        Dim Concepto As ConceptosMediosMagneticos = Nothing
        Try
            Return ConsultarConceptoMediosMagneticos(Nothing, Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PENSIONES_VOLUNTARIAS]"
    ''' <summary>
    ''' Elimina el concepto pensiones voluntarias por id Codigo
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptoPensionesVoluntarias(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PENSIONES_VOLUNTARIAS_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto pensiones voluntarias
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptoPensionesVoluntarias(ByVal Concepto As ConceptosPensionesVoluntarias) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@Codigo", Concepto.Codigo), _
                                                         ParametroInput("@Devengados", Concepto.Devengados), _
                                                         ParametroInput("@Pension_Obligatoria", Concepto.Pension_Obligatoria), _
                                                         ParametroInput("@Tipo_Pension_Obligatoria", Concepto.Tipo_Pension_Obligatoria), _
                                                         ParametroInput("@Solidaridad_Pensional", Concepto.Solidaridad_Pensional), _
                                                         ParametroInput("@Tipo_Solidaridad_Pensional", Concepto.Tipo_Solidaridad_Pensional), _
                                                         ParametroInput("@Pension_Voluntaria", Concepto.Pension_Voluntaria), _
                                                         ParametroInput("@Tipo_Pension_Voluntaria", Concepto.Tipo_Pension_Voluntaria)})



            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PENSIONES_VOLUNTARIAS_GUARDAR", Parameters.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosPensionesVoluntarias
    ''' </summary>    
    ''' <returns></returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptoPensionesVoluntarias(ByVal Codigo As Integer?) As List(Of ConceptosPensionesVoluntarias)
        Dim Conceptos As New List(Of ConceptosPensionesVoluntarias)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PENSIONES_VOLUNTARIAS_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosPensionesVoluntarias)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto pensiones voluntarias por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosPensionesVoluntarias</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptoPensionesVoluntariasPorId(ByVal Codigo As Integer) As ConceptosPensionesVoluntarias
        Dim Concepto As ConceptosPensionesVoluntarias = Nothing
        Try
            Return ConsultarConceptoPensionesVoluntarias(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PRIMA]"
    ''' <summary>
    ''' Elimina el conceptos prima por codigo id
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptosPrima(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el conceptos prima fijo liquidacion
    ''' </summary>
    ''' <param name="Concepto">ConceptosPrima</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptosPrima(ByVal Concepto As ConceptosPrima) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@Codigo", Concepto.Codigo), _
                                                         ParametroInput("@Id_Fijo", Concepto.Id_Fijo), _
                                                         ParametroInput("@Id_Fijo_Promedio", Concepto.Id_Fijo_Promedio), _
                                                         ParametroInput("@Id_Variable", Concepto.Id_Variable)})




            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_GUARDAR", Parameters.ToArray())

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosPrima
    ''' </summary>    
    ''' <returns>As List(Of ConceptosPrima)</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPrima(ByVal Codigo As Integer?) As List(Of ConceptosPrima)
        Dim Conceptos As New List(Of ConceptosPrima)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosPrima)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto prima por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosPrima</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPrimaPorId(ByVal Codigo As Integer) As ConceptosPrima
        Dim Concepto As ConceptosPrima = Nothing
        Try
            Return ConsultarConceptosPrima(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PRIMA_FIJO_LIQUIDACION]"
    ''' <summary>
    ''' Elimina el conceptos prima liquidacion por codigo id
    ''' </summary>
    ''' <param name="Codigo">Id Codigo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptosPrimaFijoLiquidacion(ByVal Codigo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_FIJO_LIQUIDACION_ELIMINAR", Codigo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el conceptos prima fijo liquidacion
    ''' </summary>
    ''' <param name="Concepto">ConceptosPrima</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptosPrimaFijoLiquidacion(ByVal Concepto As ConceptosPrimaFijoLiquidacion) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@id_prom", Concepto.id_prom), _
                                                         ParametroInput("@id_sala", Concepto.id_sala), _
                                                         ParametroInput("@id_aux", Concepto.id_aux), _
                                                         ParametroInput("@Codigo", Concepto.Codigo)})



            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_FIJO_LIQUIDACION_GUARDAR", Parameters.ToArray())

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosPrimaFijoLiquidacion
    ''' </summary>    
    ''' <returns>As List(Of ConceptosPrimaFijoLiquidacion)</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPrimaFijoLiquidacion(ByVal Codigo As Integer?) As List(Of ConceptosPrimaFijoLiquidacion)
        Dim Conceptos As New List(Of ConceptosPrimaFijoLiquidacion)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_FIJO_LIQUIDACION_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosPrimaFijoLiquidacion)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto prima fijo liquidacion por id
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosPrimaFijoLiquidacion</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPrimaFijoLiquidacionPorId(ByVal Codigo As Integer) As ConceptosPrimaFijoLiquidacion
        Dim Concepto As ConceptosPrimaFijoLiquidacion = Nothing
        Try
            Return ConsultarConceptosPrimaFijoLiquidacion(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PRIMA_VARIABLE_LIQUIDACION]"
    ''' <summary>
    ''' Elimina el concepto prima liquidacion por Consecutivo
    ''' </summary>
    ''' <param name="Consecutivo">Id Consecutivo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptosPrimaVariableLiquidacion(ByVal Consecutivo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_VARIABLE_LIQUIDACION_ELIMINAR", Consecutivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto prima Variable liquidacion
    ''' </summary>
    ''' <param name="Concepto">ConceptosPrimaVariableLiquidacion</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptosPrimaVariableLiquidacion(ByVal Concepto As ConceptosPrimaVariableLiquidacion) As ConceptosPrimaVariableLiquidacion
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@id_prom", Concepto.id_prom), _
                                                         ParametroInput("@id_sala", Concepto.id_sala), _
                                                         ParametroInput("@id_aux", Concepto.id_aux), _
                                                         ParametroInput("@Codigo", Concepto.Codigo)})

            Dim Nuevo As Boolean = Concepto.Consec = 0

            If (Nuevo) Then
                Parameters.Add(ParametroOutputInput("@Consec", Nothing, Integer.MaxValue))
            Else
                Parameters.Add(ParametroOutputInput("@Consec", Concepto.Consec, Integer.MaxValue))
            End If

            Dim RowsAfected = SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_VARIABLE_LIQUIDACION_GUARDAR", Parameters.ToArray())

            Dim ParametroConsecutivo = Parameters.Where(Function(x) x.ParameterName = "@Consec").FirstOrDefault()

            If Not IsDBNull(ParametroConsecutivo.Value) And ParametroConsecutivo.Value IsNot Nothing Then
                If ComunesConcepto.IsNumeric(ParametroConsecutivo.Value.ToString()) Then
                    Concepto.Consec = Integer.Parse(ParametroConsecutivo.Value)
                End If
            End If


            Return Concepto

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosPrimaVariableLiquidacion
    ''' </summary>    
    ''' <returns>As List(Of ConceptosPrimaVariableLiquidacion)</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPrimaVariableLiquidacion(ByVal Consecutivo As Integer?, ByVal Codigo As Integer?) As List(Of ConceptosPrimaVariableLiquidacion)
        Dim Conceptos As New List(Of ConceptosPrimaVariableLiquidacion)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PRIMA_VARIABLE_LIQUIDACION_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Consec", Consecutivo), _
                                                             ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosPrimaVariableLiquidacion)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto prima variable liquidacion por id
    ''' </summary>
    ''' <param name="Consecutivo">Codigo del concepto</param>
    ''' <returns>ConceptosPrimaVariableLiquidacion</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPrimaVariableLiquidacionPorIdConsecutivo(ByVal Consecutivo As Integer) As ConceptosPrimaVariableLiquidacion
        Dim Concepto As ConceptosPrimaVariableLiquidacion = Nothing
        Try
            Return ConsultarConceptosPrimaVariableLiquidacion(Consecutivo, Nothing).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PROMEDIO_VACACIONES]"
    ''' <summary>
    ''' Elimina el concepto promedio vacaciones por id codigo concepto
    ''' </summary>
    ''' <param name="CodigoConcepto">Codigo Concepto</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptosPromedioVacaciones(ByVal CodigoConcepto As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PROMEDIO_VACACIONES_ELIMINAR", CodigoConcepto)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto promedio vacaciones 
    ''' </summary>
    ''' <param name="Concepto">ConceptosPromedioVacaciones</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptosPromedioVacaciones(ByVal Concepto As ConceptosPromedioVacaciones) As Integer
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@Concepto", Concepto.Concepto), _
                                                         ParametroInput("@TipoSalario", Concepto.TipoSalario)})



            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PROMEDIO_VACACIONES_GUARDAR", Parameters.ToArray())

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosPromedioVacaciones
    ''' </summary>    
    ''' <returns>As List(Of ConceptosPromedioVacaciones)</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPromedioVacaciones(ByVal Codigo As Integer?) As List(Of ConceptosPromedioVacaciones)
        Dim Conceptos As New List(Of ConceptosPromedioVacaciones)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PROMEDIO_VACACIONES_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Codigo", Codigo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosPromedioVacaciones)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto Promedio Vaciones por id codigo concepto
    ''' </summary>
    ''' <param name="Codigo">Codigo del concepto</param>
    ''' <returns>ConceptosPrimaVariableLiquidacion</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPromedioVacacionesPorId(ByVal Codigo As Integer) As ConceptosPromedioVacaciones
        Dim Concepto As ConceptosPromedioVacaciones = Nothing
        Try
            Return ConsultarConceptosPromedioVacaciones(Codigo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PROMEDIO_VACACIONES_LIQUIDACION]"
    ''' <summary>
    ''' Elimina el concepto promedio vacaciones Liquidacion por id codigo Consecutivo
    ''' </summary>
    ''' <param name="Consecutivo">Codigo Consecutivo</param>
    ''' <returns>Integer return rows affecteed</returns>
    ''' <remarks>Juan R Diaz 2016-07-07</remarks>
    Public Shared Function EliminarConceptosPromedioVacacionesLiquidacion(ByVal Consecutivo As Integer) As Integer
        Try
            Return SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PROMEDIO_VACACIONES_LIQUIDACION_ELIMINAR", Consecutivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto promedio vacaciones liquidación
    ''' </summary>
    ''' <param name="Concepto">ConceptosPromedioVacionesLiquidacion</param>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Shared Function GuardarConceptosPromedioVacacionesLiquidacion(ByVal Concepto As ConceptosPromedioVacionesLiquidacion) As ConceptosPromedioVacionesLiquidacion
        Try
            Dim Parameters As New List(Of SqlParameter)(New SqlParameter() _
                                                        { _
                                                         ParametroInput("@TipoSalario", Concepto.TipoSalario), _
                                                         ParametroInput("@Integral", Concepto.Integral), _
                                                         ParametroInput("@Concepto", Concepto.Concepto), _
                                                         ParametroInput("@id_sala", Concepto.id_sala), _
                                                         ParametroInput("@id_prom", Concepto.id_prom)})


            Dim Nuevo As Boolean = Concepto.Consecutivo = 0

            If Nuevo Then
                Parameters.Add(ParametroOutputInput("@Consecutivo", Nothing, Integer.MaxValue))
            Else
                Parameters.Add(ParametroOutputInput("@Consecutivo", Concepto.Consecutivo, Integer.MaxValue))
            End If

            Dim Rows = SQL.ExecuteNonQuery(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PROMEDIO_VACACIONES_LIQUIDACION_GUARDAR", Parameters.ToArray())


            Dim ParamConsecutivo = Parameters.Where(Function(x) x.ParameterName = "@Consecutivo").FirstOrDefault()

            If Not IsDBNull(ParamConsecutivo.Value) And ParamConsecutivo.Value IsNot Nothing Then
                If ComunesConcepto.IsNumeric(ParamConsecutivo.Value.ToString()) Then
                    Concepto.Consecutivo = Integer.Parse(ParamConsecutivo.Value)
                End If
            End If

            Return Concepto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta todo el listado de la tabla ConceptosPromedioVacionesLiquidacion
    ''' </summary>    
    ''' <returns>As List(Of ConceptosPromedioVacionesLiquidacion)</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPromedioVacacionesLiquidacion(ByVal Consecutivo As Integer?) As List(Of ConceptosPromedioVacionesLiquidacion)
        Dim Conceptos As New List(Of ConceptosPromedioVacionesLiquidacion)
        Try
            Dim Reader As SqlDataReader = SQL.ExecuteReader(StrConnections, CommandType.StoredProcedure, "PROC_NOM_CONCEPTOS_PROMEDIO_VACACIONES_LIQUIDACION_CONSULTAR", New SqlParameter() _
                                                            {ParametroInput("@Consecutivo", Consecutivo)})

            Conceptos = ComunesConcepto.ToListMap(Of ConceptosPromedioVacionesLiquidacion)(Reader)
        Catch ex As Exception
            Throw ex
        End Try
        Return Conceptos
    End Function
    ''' <summary>
    ''' Consulta el concepto Promedio Vaciones Liquidacion por id consecutivo
    ''' </summary>
    ''' <param name="Consecutivo">Consecutivo del concepto</param>
    ''' <returns>ConceptosPrimaVariableLiquidacion</returns>
    ''' <remarks>Juan R Diaz 2016-07-18</remarks>
    Public Shared Function ConsultarConceptosPromedioVacacionesLiquidacionPorId(ByVal Consecutivo As Integer) As ConceptosPromedioVacionesLiquidacion
        Dim Concepto As ConceptosPromedioVacionesLiquidacion = Nothing
        Try
            Return ConsultarConceptosPromedioVacacionesLiquidacion(Consecutivo).FirstOrDefault()
        Catch ex As Exception
            Throw ex
        End Try
        Return Concepto
    End Function
#End Region
End Class
