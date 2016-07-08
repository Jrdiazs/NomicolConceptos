Imports Infragistics.Win.UltraWinGrid

Public Class FrmCajasCompensacion

    Dim AuxNegocio As New Negocio
    Dim datos_Bitacora As String = String.Empty

    Private Sub FrmCajasCompensacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaInicial()
    End Sub

    Sub CargaInicial()
        Try
            GvCajasCompensacion.DataSource = AuxNegocio.Listar_Cajas_de_Compensacion()            
        Catch ex As Exception
        End Try
    End Sub

End Class