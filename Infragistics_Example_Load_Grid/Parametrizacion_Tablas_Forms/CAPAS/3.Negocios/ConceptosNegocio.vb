Imports System.ComponentModel

Public Class ConceptosNegocio
    ''' <summary>
    ''' Guarda o modifica el concepto
    ''' </summary>
    ''' <param name="Concepto">Concepto</param>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
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
    ''' Lista todo los conceptos de base de datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-18</remarks>
    Public Function ConsultarConceptos() As ValorEntidad(Of BindingList(Of Conceptos))
        Dim Value As New ValorEntidad(Of BindingList(Of Conceptos))
        Try
            Dim ConceptosData = AccesoDatosConcepto.ConsultarConceptos(Nothing, Nothing)
            Value.Valor = New BindingList(Of Conceptos)(ConceptosData)
        Catch ex As Exception
            Value.GenerarError("Error al consultar el listado de conceptos", EnumTipoError.Fatal, ex)
        End Try
        Return Value
    End Function

End Class
