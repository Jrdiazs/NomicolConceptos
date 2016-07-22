<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConceptosParaFiscalesSENA
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Integral")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Negativo")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Integral")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Negativo")
        Me.GVConceptosParafiscalesSENA = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UDS_Conceptos_Parafiscales_SENA = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        CType(Me.GVConceptosParafiscalesSENA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDS_Conceptos_Parafiscales_SENA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GVConceptosParafiscalesSENA
        '
        Me.GVConceptosParafiscalesSENA.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.GVConceptosParafiscalesSENA.DataSource = Me.UDS_Conceptos_Parafiscales_SENA
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Appearance = Appearance7
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 350
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 150
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.GVConceptosParafiscalesSENA.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.GVConceptosParafiscalesSENA.DisplayLayout.InterBandSpacing = 10
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))
        Appearance9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.TextHAlignAsString = "Left"
        Appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.HeaderAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.RowAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))
        Appearance11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.RowSelectorAppearance = Appearance11
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.RowSelectorWidth = 12
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Appearance12.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(249, Byte), Integer))
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.ForeColor = System.Drawing.Color.Black
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.SelectedRowAppearance = Appearance12
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.GVConceptosParafiscalesSENA.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.GVConceptosParafiscalesSENA.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.GVConceptosParafiscalesSENA.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.GVConceptosParafiscalesSENA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GVConceptosParafiscalesSENA.Location = New System.Drawing.Point(8, 12)
        Me.GVConceptosParafiscalesSENA.Name = "GVConceptosParafiscalesSENA"
        Me.GVConceptosParafiscalesSENA.Size = New System.Drawing.Size(955, 415)
        Me.GVConceptosParafiscalesSENA.TabIndex = 102
        Me.GVConceptosParafiscalesSENA.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        '
        'UDS_Conceptos_Parafiscales_SENA
        '
        Me.UDS_Conceptos_Parafiscales_SENA.Band.AllowAdd = Infragistics.Win.DefaultableBoolean.[True]
        UltraDataColumn4.DataType = GetType(Integer)
        UltraDataColumn4.DefaultValue = 0
        UltraDataColumn5.AllowDBNull = Infragistics.Win.DefaultableBoolean.[False]
        UltraDataColumn5.DataType = GetType(Boolean)
        UltraDataColumn5.DefaultValue = False
        UltraDataColumn6.DataType = GetType(Integer)
        UltraDataColumn6.DefaultValue = 0
        Me.UDS_Conceptos_Parafiscales_SENA.Band.Columns.AddRange(New Object() {UltraDataColumn4, UltraDataColumn5, UltraDataColumn6})
        Me.UDS_Conceptos_Parafiscales_SENA.Rows.AddRange(New Object() {New Infragistics.Win.UltraWinDataSource.UltraDataRow(New Object(-1) {})})
        '
        'FrmConceptosParaFiscalesSENA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 446)
        Me.Controls.Add(Me.GVConceptosParafiscalesSENA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmConceptosParaFiscalesSENA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Conceptos Parafiscales SENA ::."
        CType(Me.GVConceptosParafiscalesSENA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDS_Conceptos_Parafiscales_SENA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GVConceptosParafiscalesSENA As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UDS_Conceptos_Parafiscales_SENA As Infragistics.Win.UltraWinDataSource.UltraDataSource
End Class
