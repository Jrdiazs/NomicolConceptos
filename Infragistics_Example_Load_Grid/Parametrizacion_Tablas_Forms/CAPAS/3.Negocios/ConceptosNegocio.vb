Imports System.ComponentModel
''' <summary>
''' Clase de negocio para las tablas de conceptos
''' </summary>
''' <remarks>Juan Ricardo Diaz 2016-07-06</remarks>
Public Class ConceptosNegocio
#Region "[Conceptos]"
    ''' <summary>
    ''' Guarda o modifica el concepto
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <returns>ValorEntidad(Of Conceptos)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function GuardarConcepto(ByVal Concepto As Conceptos) As ValorEntidad(Of Conceptos)
        Dim Value As New ValorEntidad(Of Conceptos)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Concepto.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConcepto(Concepto)
            Value.Valor = Concepto

        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Elimina el concepto por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConcepto(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConcepto(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Lista todo los conceptos de base de datos
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of Conceptos))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function ConsultarConceptos() As ValorEntidad(Of BindingList(Of Conceptos))
        Dim Value As New ValorEntidad(Of BindingList(Of Conceptos))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptos(Nothing, Nothing)
            Value.Valor = ComunesConcepto.BindingToList(Of Conceptos)(ConceptosData)
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos Parafiscales Caja]"
    ''' <summary>
    ''' Elimina el concepto para fiscal caja por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoParafiscalCaja(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosAportesParafiscalesCajaPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoParafiscalCaja(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto para fiscal caja", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Lista todos los conceptos parafiscales Caja
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosAportesParafiscalesCaja))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosParafiscalesCaja() As ValorEntidad(Of BindingList(Of ConceptosAportesParaFiscalesCaja))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosAportesParaFiscalesCaja))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosAportesParafiscalesCaja(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosAportesParaFiscalesCaja)(ConceptosData)
            Value.Valor = BindingList

        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos parafiscales Caja", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Consulta el concepto parafiscal Caja por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>ValorEntidad(Of ConceptosAportesParafiscalesCaja)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosAportesParafiscalesCajaPorId(ByVal Codigo As Integer) As ValorEntidad(Of ConceptosAportesParaFiscalesCaja)
        Dim Value As New ValorEntidad(Of ConceptosAportesParaFiscalesCaja)
        Try
            Dim ConceptoCaja = AccesoDatosConcepto.ConsultarConceptosAportesParafiscalesCajaPorId(Codigo)

            If ConceptoCaja Is Nothing Then
                Value.GenerarError("No existe el concepto por id", EnumTipoError.Info)
                Return Value
            End If

            Value.Valor = ConceptoCaja
        Catch ex As Exception
            Value.GenerarError("Error al consultar concepto parafiscal Caja por id", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda un concepto parafiscal Caja en base de datos
    ''' </summary>
    ''' <param name="ConceptoCaja">ConceptosAportesParafiscalesCaja</param>
    ''' <returns>As ValorEntidad(Of ConceptosAportesParafiscalesCaja)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function GuardarConceptoParafiscalCaja(ByVal ConceptoCaja As ConceptosAportesParaFiscalesCaja) As ValorEntidad(Of ConceptosAportesParaFiscalesCaja)
        Dim Value As New ValorEntidad(Of ConceptosAportesParaFiscalesCaja)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = ConceptoCaja.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoParafiscalCaja(ConceptoCaja)
            Value.Valor = ConceptoCaja
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto parafiscal Caja", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos parafiscales SENA]"
    ''' <summary>
    ''' Elimina el concepto para fiscal SENA por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoParafiscalSENA(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosAportesParafiscalesSenaPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoParafiscalSENA(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto para fiscal SENA", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto parafiscal Sena
    ''' </summary>
    ''' <param name="ConceptoSena">ConceptosAportesParafiscalesSena</param>
    ''' <returns>ConceptosAportesParafiscalesSena</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptoParafiscalSena(ByVal ConceptoSena As ConceptosAportesParafiscalesSena) As ValorEntidad(Of ConceptosAportesParafiscalesSena)
        Dim Value As New ValorEntidad(Of ConceptosAportesParafiscalesSena)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = ConceptoSena.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoParafiscalSena(ConceptoSena)
            Value.Valor = ConceptoSena
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto parafiscal Sena", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos parafiscales Sena
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosAportesParafiscalesSena))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosParafiscalesSena() As ValorEntidad(Of BindingList(Of ConceptosAportesParafiscalesSena))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosAportesParafiscalesSena))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosAportesParafiscalesSENA(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosAportesParafiscalesSena)(ConceptosData)
            Value.Valor = BindingList

        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos parafiscales Sena", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos parafiscales ICBF]"
    ''' <summary>
    ''' Elimina el concepto para fiscal ICBF por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoParafiscalICBF(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosAportesParafiscalesICBF(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoParafiscalICBF(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto para fiscal ICBF", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto parafiscal ICBF
    ''' </summary>
    ''' <param name="ConceptoICBF">ConceptosAportesParafiscalesICBF</param>
    ''' <returns>ConceptosAportesParafiscalesICBF</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptoParafiscalICBF(ByVal ConceptoICBF As ConceptosAportesParafiscalesICBF) As ValorEntidad(Of ConceptosAportesParafiscalesICBF)
        Dim Value As New ValorEntidad(Of ConceptosAportesParafiscalesICBF)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = ConceptoICBF.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoParafiscalICBF(ConceptoICBF)
            Value.Valor = ConceptoICBF
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto parafiscal ICBF", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos parafiscales ICBF
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosAportesParafiscalesICBF))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosParafiscalesICBF() As ValorEntidad(Of BindingList(Of ConceptosAportesParafiscalesICBF))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosAportesParafiscalesICBF))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosAportesParafiscalesICBF(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosAportesParafiscalesICBF)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos parafiscales ICBF", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CAPACIDAD_PAGO]"

    ''' <summary>
    ''' Elimina el concepto capacidad pago
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoCapacidadPago(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosCapacidadPagoPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoCapacidadPago(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto capacidad pago", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto capacidad de pago
    ''' </summary>
    ''' <param name="ConceptoPago">ConceptosCapacidadPago</param>
    ''' <returns>ConceptosCapacidadPago</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptoCapacidadPago(ByVal ConceptoPago As ConceptosCapacidadPago) As ValorEntidad(Of ConceptosCapacidadPago)
        Dim Value As New ValorEntidad(Of ConceptosCapacidadPago)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = ConceptoPago.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoCapacidadPago(ConceptoPago)
            Value.Valor = ConceptoPago
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto capacidad de pago", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos capacidad de pago
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosCapacidadPago))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosCapacidadPago() As ValorEntidad(Of BindingList(Of ConceptosCapacidadPago))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosCapacidadPago))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosCapacidadPago(Nothing)
            Dim BindingList = New BindingList(Of ConceptosCapacidadPago)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos capacidad de pago", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CESANTIAS]"
    ''' <summary>
    ''' Elimina el concepto cesantias por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoCesantias(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosCesantiasPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoCesantias(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto cesantias", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto cesantias
    ''' </summary>
    ''' <param name="ConceptoCesantias">ConceptoCesantias</param>
    ''' <returns>ConceptosCesantias</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptoCesantias(ByVal ConceptoCesantias As ConceptosCesantias) As ValorEntidad(Of ConceptosCesantias)
        Dim Value As New ValorEntidad(Of ConceptosCesantias)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = ConceptoCesantias.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoCesantias(ConceptoCesantias)
            Value.Valor = ConceptoCesantias
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto Cesantias", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos cesantias
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosCesantias))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosCesantias() As ValorEntidad(Of BindingList(Of ConceptosCesantias))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosCesantias))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosCesantias(Nothing)
            Dim BindingList = New BindingList(Of ConceptosCesantias)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos cesantias", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CESANTIAS_FIJO]"
    ''' <summary>
    ''' Elimina el concepto cesantias fijo por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoCesantiasFijo(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosCesantiasFijoPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoCesantiasFijo(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto cesantias fijo", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto cesantias fijo
    ''' </summary>
    ''' <param name="ConceptoCesantias">ConceptosCesantiasFijo</param>
    ''' <returns>ConceptosCesantiasFijo</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptoCesantiasFijo(ByVal ConceptoCesantias As ConceptosCesantiasFijo) As ValorEntidad(Of ConceptosCesantiasFijo)
        Dim Value As New ValorEntidad(Of ConceptosCesantiasFijo)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = ConceptoCesantias.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoCesantiasFijo(ConceptoCesantias)
            Value.Valor = ConceptoCesantias
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto Cesantias fijo", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos cesantias fijo
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosCesantiasFijo))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosCesantiasFijo() As ValorEntidad(Of BindingList(Of ConceptosCesantiasFijo))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosCesantiasFijo))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosCesantiasFijo(Nothing)
            Dim BindingList = New BindingList(Of ConceptosCesantiasFijo)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos cesantias fijo", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_CESANTIAS_VARIABLE]"
    ''' <summary>
    ''' Elimina el concepto cesantias variable por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoCesantiasVariable(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosCesantiasVariablePorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoCesantiasVariable(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto cesantias variable", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el concepto cesantias variable
    ''' </summary>
    ''' <param name="ConceptoCesantias">ConceptosCesantiasVariables</param>
    ''' <returns>ConceptosCesantiasVariables</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptoCesantiasVariable(ByVal ConceptoCesantias As ConceptosCesantiasVariables) As ValorEntidad(Of ConceptosCesantiasVariables)
        Dim Value As New ValorEntidad(Of ConceptosCesantiasVariables)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = ConceptoCesantias.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoCesantiasVariable(ConceptoCesantias)
            Value.Valor = ConceptoCesantias
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto Cesantias variable", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos cesantias variable
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosCesantiasVariables))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosCesantiasVariable() As ValorEntidad(Of BindingList(Of ConceptosCesantiasVariables))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosCesantiasVariables))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosCesantiasVariable(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosCesantiasVariables)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos cesantias variable", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_MEDIOS_MAGNETICOS]"
    ''' <summary>
    ''' Elimina el concepto medios magneticos por id consecutivo
    ''' </summary>
    ''' <param name="Consecutivo">Id consecutivo concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoMediosMagneticos(ByVal Consecutivo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptoMediosMagneticosPorIdConsecutivo(Consecutivo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoMediosMagneticos(Consecutivo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto medios magneticos", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el conceptos medios magnéticos
    ''' </summary>
    ''' <param name="Conceptos">ConceptosMediosMagneticos</param>
    ''' <returns>ConceptosMediosMagneticos</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptosMediosMagneticos(ByVal Conceptos As ConceptosMediosMagneticos) As ValorEntidad(Of ConceptosMediosMagneticos)
        Dim Value As New ValorEntidad(Of ConceptosMediosMagneticos)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Conceptos.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            Conceptos = AccesoDatosConcepto.GuardarConceptoMediosMagneticos(Conceptos)
            Value.Valor = Conceptos
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto medios magnéticos", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos medios magnéticos
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosMediosMagneticos))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosMediosMagneticos() As ValorEntidad(Of BindingList(Of ConceptosMediosMagneticos))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosMediosMagneticos))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptoMediosMagneticos(Nothing, Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosMediosMagneticos)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos medios magnéticos", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PENSIONES_VOLUNTARIAS]"
    ''' <summary>
    ''' Elimina el concepto medios magneticos por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptoPensionesVoluntarias(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptoPensionesVoluntariasPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptoPensionesVoluntarias(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto pensiones voluntarias", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Lista todos los conceptos pensiones voluntarias
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosPensionesVoluntarias))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPensionesVoluntarias() As ValorEntidad(Of BindingList(Of ConceptosPensionesVoluntarias))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosPensionesVoluntarias))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptoPensionesVoluntarias(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosPensionesVoluntarias)(ConceptosData)
            Value.Valor = BindingList

        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos pensiones voluntarias", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Consulta el concepto de pensiones voluntarias
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>ValorEntidad(Of ConceptosPensionesVoluntarias)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPensionesVoluntariasPorId(ByVal Codigo As Integer) As ValorEntidad(Of ConceptosPensionesVoluntarias)
        Dim Value As New ValorEntidad(Of ConceptosPensionesVoluntarias)
        Try
            Dim Concepto = AccesoDatosConcepto.ConsultarConceptoPensionesVoluntariasPorId(Codigo)

            If Concepto Is Nothing Then
                Value.GenerarError("No existe el concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = Concepto
        Catch ex As Exception
            Value.GenerarError("Error al consultar concepto pensiones voluntarias", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda un concepto pensiones voluntarias
    ''' </summary>
    ''' <param name="Concepto">ConceptosPensionesVoluntarias</param>
    ''' <returns>As ValorEntidad(Of ConceptosPensionesVoluntarias)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function GuardarConceptoPensionesVoluntarias(ByVal Concepto As ConceptosPensionesVoluntarias) As ValorEntidad(Of ConceptosPensionesVoluntarias)
        Dim Value As New ValorEntidad(Of ConceptosPensionesVoluntarias)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Concepto.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptoPensionesVoluntarias(Concepto)
            Value.Valor = Concepto
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto pensiones voluntarias", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PRIMA]"
    ''' <summary>
    ''' Elimina el concepto prima por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptosPrima(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPrimaPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptosPrima(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto prima", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Lista todos los conceptos prima
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosPrima))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPrima() As ValorEntidad(Of BindingList(Of ConceptosPrima))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosPrima))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosPrima(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosPrima)(ConceptosData)
            Value.Valor = BindingList

        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos prima", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Consulta el concepto prima por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>ValorEntidad(Of ConceptosPrima)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPrimaPorId(ByVal Codigo As Integer) As ValorEntidad(Of ConceptosPrima)
        Dim Value As New ValorEntidad(Of ConceptosPrima)
        Try
            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPrimaPorId(Codigo)

            If Concepto Is Nothing Then
                Value.GenerarError("No existe el concepto por id", EnumTipoError.Info)
                Return Value
            End If

            Value.Valor = Concepto
        Catch ex As Exception
            Value.GenerarError("Error al consultar concepto prima por id", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica un concepto prima
    ''' </summary>
    ''' <param name="Concepto">ConceptosPrima</param>
    ''' <returns>As ValorEntidad(Of ConceptosPrima)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function GuardarConceptoPrima(ByVal Concepto As ConceptosPrima) As ValorEntidad(Of ConceptosPrima)
        Dim Value As New ValorEntidad(Of ConceptosPrima)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Concepto.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptosPrima(Concepto)
            Value.Valor = Concepto
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto prima", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PRIMA_FIJO_LIQUIDACION]"
    ''' <summary>
    ''' Elimina el concepto prima fijo liquidacion por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptosPrimaFijoLiquidacion(ByVal Codigo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPrimaFijoLiquidacionPorId(Codigo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptosPrimaFijoLiquidacion(Codigo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto prima", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Lista todos los conceptos prima fijo liquidacion
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosPrimaFijoLiquidacion))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPrimaFijoLiquidacion() As ValorEntidad(Of BindingList(Of ConceptosPrimaFijoLiquidacion))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosPrimaFijoLiquidacion))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosPrimaFijoLiquidacion(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosPrimaFijoLiquidacion)(ConceptosData)
            Value.Valor = BindingList

        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos prima fijo liquidación", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Consulta el concepto prima por id
    ''' </summary>
    ''' <param name="Codigo">Id del concepto</param>
    ''' <returns>ValorEntidad(Of ConceptosPrimaFijoLiquidacion)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPrimaFijoLiquidacionPorId(ByVal Codigo As Integer) As ValorEntidad(Of ConceptosPrimaFijoLiquidacion)
        Dim Value As New ValorEntidad(Of ConceptosPrimaFijoLiquidacion)
        Try
            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPrimaFijoLiquidacionPorId(Codigo)

            If Concepto Is Nothing Then
                Value.GenerarError("No existe el concepto por id", EnumTipoError.Info)
                Return Value
            End If

            Value.Valor = Concepto
        Catch ex As Exception
            Value.GenerarError("Error al consultar concepto prima fijo liquidación por id", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica un concepto prima fijo liquidación
    ''' </summary>
    ''' <param name="Concepto">ConceptosPrima</param>
    ''' <returns>As ValorEntidad(Of ConceptosPrimaFijoLiquidacion)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function GuardarConceptoPrimaFijoLiquidacion(ByVal Concepto As ConceptosPrimaFijoLiquidacion) As ValorEntidad(Of ConceptosPrimaFijoLiquidacion)
        Dim Value As New ValorEntidad(Of ConceptosPrimaFijoLiquidacion)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Concepto.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptosPrimaFijoLiquidacion(Concepto)
            Value.Valor = Concepto
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto prima", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PRIMA_VARIABLE_LIQUIDACION]"
    ''' <summary>
    ''' Elimina el concepto prima variable liquidacion
    ''' </summary>
    ''' <param name="Consecutivo">Id consecutivo concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptosPrimaVariableLiquidacion(ByVal Consecutivo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPrimaVariableLiquidacionPorIdConsecutivo(Consecutivo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptosPrimaVariableLiquidacion(Consecutivo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto prima variable liquidación", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el conceptos prima variable liquidación
    ''' </summary>
    ''' <param name="Conceptos">ConceptosPrimaVariableLiquidacion</param>
    ''' <returns>ConceptosPrimaVariableLiquidacion</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptosPrimaVariableLiquidacion(ByVal Conceptos As ConceptosPrimaVariableLiquidacion) As ValorEntidad(Of ConceptosPrimaVariableLiquidacion)
        Dim Value As New ValorEntidad(Of ConceptosPrimaVariableLiquidacion)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Conceptos.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            Conceptos = AccesoDatosConcepto.GuardarConceptosPrimaVariableLiquidacion(Conceptos)
            Value.Valor = Conceptos
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto prima variable liquidación", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos prima variable liquidación
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosPrimaVariableLiquidacion))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPrimaVariableLiquidacion() As ValorEntidad(Of BindingList(Of ConceptosPrimaVariableLiquidacion))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosPrimaVariableLiquidacion))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosPrimaVariableLiquidacion(Nothing, Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosPrimaVariableLiquidacion)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos prima variable liquidación", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PROMEDIO_VACACIONES]"
    ''' <summary>
    ''' Elimina el concepto promedio vacaciones
    ''' </summary>
    ''' <param name="Consecutivo">Id consecutivo concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptosPromedioVacaciones(ByVal Consecutivo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPromedioVacacionesPorId(Consecutivo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptosPromedioVacaciones(Consecutivo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto promedio vacaciones", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el conceptos promedio vacaciones
    ''' </summary>
    ''' <param name="Conceptos">ConceptosPromedioVacaciones</param>
    ''' <returns>ConceptosPromedioVacaciones</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptosPromedioVacaciones(ByVal Conceptos As ConceptosPromedioVacaciones) As ValorEntidad(Of ConceptosPromedioVacaciones)
        Dim Value As New ValorEntidad(Of ConceptosPromedioVacaciones)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Conceptos.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptosPromedioVacaciones(Conceptos)
            Value.Valor = Conceptos
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto promedio vacaciones", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos promedio vacaciones
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosPromedioVacaciones))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPromedioVacaciones() As ValorEntidad(Of BindingList(Of ConceptosPromedioVacaciones))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosPromedioVacaciones))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosPromedioVacaciones(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosPromedioVacaciones)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos promedio vacaciones", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
#Region "[Conceptos CONCEPTOS_PROMEDIO_VACACIONES_LIQUIDACION]"
    ''' <summary>
    ''' Elimina el concepto promedio vacaciones liquidacion
    ''' </summary>
    ''' <param name="Consecutivo">Id consecutivo concepto</param>
    ''' <returns>As ValorEntidad(Of Integer) Integer Rows Affected</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-07</remarks>
    Public Function EliminarConceptosPromedioVacacionesLiquidacion(ByVal Consecutivo As Integer) As ValorEntidad(Of Integer)
        Dim Value As New ValorEntidad(Of Integer)
        Try

            Dim Concepto = AccesoDatosConcepto.ConsultarConceptosPromedioVacacionesLiquidacionPorId(Consecutivo)
            If Concepto Is Nothing Then
                Value.GenerarError("No existe el Concepto por id", EnumTipoError.Warging)
                Return Value
            End If

            Value.Valor = AccesoDatosConcepto.EliminarConceptosPromedioVacacionesLiquidacion(Consecutivo)

        Catch ex As Exception
            Value.GenerarError("Error al Eliminar concepto promedio vacaciones liquidación", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
    ''' <summary>
    ''' Guarda o modifica el conceptos promedio vacaciones liquidacion
    ''' </summary>
    ''' <param name="Conceptos">ConceptosPromedioVacionesLiquidacion</param>
    ''' <returns>ConceptosPromedioVacionesLiquidacion</returns>
    ''' <remarks>Juan Ricardo Diaz S 2016-07-18</remarks>
    Public Function GuardarConceptosPromedioVacacionesLiquidacion(ByVal Conceptos As ConceptosPromedioVacionesLiquidacion) As ValorEntidad(Of ConceptosPromedioVacionesLiquidacion)
        Dim Value As New ValorEntidad(Of ConceptosPromedioVacionesLiquidacion)
        Try
            Dim Errores As String = String.Empty
            Dim ConceptoValido As Boolean = Conceptos.Validar(Errores)

            If Not ConceptoValido Then
                Value.GenerarError(Errores, EnumTipoError.Warging)
                Return Value
            End If

            AccesoDatosConcepto.GuardarConceptosPromedioVacacionesLiquidacion(Conceptos)
            Value.Valor = Conceptos
        Catch ex As Exception
            Value.GenerarError("Error al guardar concepto promedio vacaciones liquidación", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

    ''' <summary>
    ''' Lista todos los conceptos promedio vacaciones liquidación
    ''' </summary>
    ''' <returns>ValorEntidad(Of BindingList(Of ConceptosPromedioVacionesLiquidacion))</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptosPromedioVacacionesLiquidacion() As ValorEntidad(Of BindingList(Of ConceptosPromedioVacionesLiquidacion))
        Dim Value As New ValorEntidad(Of BindingList(Of ConceptosPromedioVacionesLiquidacion))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptosPromedioVacacionesLiquidacion(Nothing)
            Dim BindingList = ComunesConcepto.BindingToList(Of ConceptosPromedioVacionesLiquidacion)(ConceptosData)
            Value.Valor = BindingList
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos promedio vacaciones liquidación", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function
#End Region
End Class
