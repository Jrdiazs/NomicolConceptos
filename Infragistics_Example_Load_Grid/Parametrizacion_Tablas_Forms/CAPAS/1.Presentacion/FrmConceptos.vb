Imports Infragistics.Win.UltraWinGrid

Public Class FrmConceptos
    Dim Negocio As New ConceptosNegocio
    ''' <summary>
    ''' Load Frame
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Private Sub FrmConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CargarGridConceptos()
    End Sub
    ''' <summary>
    ''' Carga el grid con el resultado de los conceptos
    ''' </summary>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Public Sub CargarGridConceptos()

        Try
            Dim Resultado = Negocio.ConsultarConceptos

            If Resultado.Error Then 'Si hay error muestra el mensaje
                MostrarMensaje(Resultado)
                Exit Sub
            End If

            Me.GVConceptos.DataSource = Resultado.Valor
        Catch ex As Exception
            MessageBox.Show("Error al consultar los conceptos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
       

    End Sub
    ''' <summary>
    ''' Metodo para insertar un nuevo concepto con el evento del grid view
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
    Private Sub GVConceptos_AfterRowInsert(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles GVConceptos.AfterRowInsert

        Try
            Dim c = e.Row.ListObject



            Dim Concepto As New Conceptos

            Dim ResultConcepto = Negocio.GuardarConcepto(Concepto)

            If ResultConcepto.Error Then ' Si hay error muestra un mensaje
                MostrarMensaje(ResultConcepto)
                Exit Sub
            End If

            'Carga nuevamente el listado de conceptos en el grid
            Me.CargarGridConceptos()
        Catch ex As Exception
            MessageBox.Show("Error al guardar conceptos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
       

    End Sub
    ''' <summary>
    ''' Metodo para mostrar un mensaje de error o advertencia segun el resultado de la entidad
    ''' </summary>
    ''' <typeparam name="T">Type ValorEntidad</typeparam>
    ''' <param name="Resultado">ValorEntidad</param>
    ''' <remarks>Juan Ricardo Diaz - 2016-07-08</remarks>
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

    Private Sub GVConceptos_BeforeRowInsert(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowInsertEventArgs) Handles GVConceptos.BeforeRowInsert

    End Sub
End Class