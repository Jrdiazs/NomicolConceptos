Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel
Imports Infragistics.Win

Public Class FrmConceptosParaFiscalesICBF
#Region "[Propiedades]"
    ''' <summary>
    ''' Clase de negocio de Conceptos
    ''' </summary>
    ''' <remarks>Juan Ricardo Diaz 2016-07-22</remarks>
    Dim Negocio As New ConceptosNegocio
    Private _ConceptosParafiscalesICBF As BindingList(Of ConceptosAportesParafiscalesICBF)
    ''' <summary>
    ''' Lista de Conceptos Parafiscales ICBF
    ''' </summary>
    ''' <value>As BindingList(Of ConceptosAportesParafiscalesICBF)</value>
    ''' <returns>As BindingList(Of ConceptosAportesParafiscalesICBF)</returns>
    ''' <remarks>Juan Ricardo Diaz 2016-07-22</remarks>
    Public Property ConceptosParafiscalesICBF() As BindingList(Of ConceptosAportesParafiscalesICBF)
        Get
            Return _ConceptosParafiscalesICBF
        End Get
        Set(ByVal value As BindingList(Of ConceptosAportesParafiscalesICBF))
            _ConceptosParafiscalesICBF = value
        End Set
    End Property
#End Region
#Region "[Constructor]"
    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region
#Region "[Eventos]"
    ''' <summary>
    ''' Load FormularioParafiscalesCaja
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Juan Ricardo Diaz 2016-07-22</remarks>
    Private Sub FrmConceptosParafiscalesCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CargarGrid()
    End Sub
    ''' <summary>
    ''' Metodo para inicializar el combo box de Conceptos en el campo Codigo de la grilla
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Juan Ricardo Diaz 2016-07-22</remarks>
    Private Sub GVConceptosParafiscalesCaja_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GVConceptosParafiscalesICBF.InitializeLayout

        Try
            '========================================================================
            'Carga el campo Codigo con el combo box de Lista de Conceptos
            Dim vl As ValueList
            If (Not e.Layout.ValueLists.Exists("DataComboConceptos")) Then
                vl = e.Layout.ValueLists.Add("DataComboConceptos")
                Dim Value = Negocio.ConsultarConceptos

                If Value.Error Then
                    ComunesConcepto.MostrarMensaje(Value)
                    Exit Sub
                End If

                Dim Items = Value.Valor.Select(Function(x) New ValueListItem() With {.DataValue = x.Codigo, .DisplayText = x.Descripcion})
                vl.ValueListItems.AddRange(Items.ToArray())
            End If

            e.Layout.Bands(0).Columns("Codigo").ValueList = e.Layout.ValueLists("DataComboConceptos")
            '========================================================================
            'Carga el campo negativo
            If (Not e.Layout.ValueLists.Exists("DataComboNegativo")) Then
                vl = e.Layout.ValueLists.Add("DataComboNegativo")
                vl.ValueListItems.Add(1, "1")
                vl.ValueListItems.Add(-1, "-1")
            End If
            e.Layout.Bands(0).Columns("Negativo").ValueList = e.Layout.ValueLists("DataComboNegativo")
            '========================================================================
        Catch ex As Exception
            ComunesConcepto.MostrarMensaje("Error al Cargar Drop Down List Conceptos", ex)
        End Try
    End Sub
#End Region
#Region "[Metodos]"
    ''' <summary>
    ''' Carga la grilla de conceptos parafiscales ICBF
    ''' </summary>
    ''' <remarks>Juan Ricardo Diaz 2016-07-22</remarks>
    Private Sub CargarGrid()
        Try
            Dim Value = Negocio.ConsultarConceptosParafiscalesICBF

            If Value.Error Then
                ComunesConcepto.MostrarMensaje(Value)
                Exit Sub
            End If

            Dim Bs As New BindingSource
            Me.ConceptosParafiscalesICBF = Value.Valor
            Bs.DataSource = Me.ConceptosParafiscalesICBF
            Me.GVConceptosParafiscalesICBF.DataSource = Bs

        Catch ex As Exception
            ComunesConcepto.MostrarMensaje("Error al Cargar Grid Conceptos parafiscales ICBF", ex)
        End Try
    End Sub
#End Region

End Class