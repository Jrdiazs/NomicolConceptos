Imports Infragistics.Win.UltraWinGrid

Public Class FrmConceptos
    Dim Negocio As New ConceptosNegocio

    Private Sub FrmConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CargarGridConceptos()
    End Sub
    Public Sub CargarGridConceptos()
        Dim Resultado = Negocio.ConsultarConceptos

        If Resultado.Error Then
            MostrarMensaje(Resultado)
            Exit Sub
        End If

        Me.GVConceptos.DataSource = Resultado.Valor

    End Sub

    Private Sub GVConceptos_AfterRowInsert(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GVConceptos.AfterRowInsert
        Dim Concepto As New Conceptos

        Dim ResultConcepto = Negocio.GuardarConcepto(Concepto)

        If ResultConcepto.Error Then
            MostrarMensaje(ResultConcepto)
            Exit Sub
        End If

        Me.CargarGridConceptos()

    End Sub

    Public Sub MostrarMensaje(Of T)(ByVal Resultado As ValorEntidad(Of T))
        Dim Caption As String = String.Empty

        Dim Icon = MessageBoxIcon.Information

        Select Case Resultado.TipoError
            Case EnumTipoError.Fatal
                Icon = MessageBoxIcon.Error
                Caption = "Error"
            Case EnumTipoError.Warging
                Icon = MessageBoxIcon.Warning
                Caption = "Info"
        End Select

        MessageBox.Show(Resultado.ErrorMessage, Caption, MessageBoxButtons.OK, Icon)

    End Sub

End Class