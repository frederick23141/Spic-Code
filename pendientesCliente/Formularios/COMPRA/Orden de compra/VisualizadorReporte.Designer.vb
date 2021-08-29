<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisualizadorReporte
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PRGPRODUCCIONDataSet = New Spic.PRGPRODUCCIONDataSet()
        Me.d_filtrar_reporte_solicitudBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.d_filtrar_reporte_solicitudTableAdapter = New Spic.PRGPRODUCCIONDataSetTableAdapters.d_filtrar_reporte_solicitudTableAdapter()
        CType(Me.PRGPRODUCCIONDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.d_filtrar_reporte_solicitudBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "Filtrar_reporte_solicitud"
        ReportDataSource1.Value = Me.d_filtrar_reporte_solicitudBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Spic.Reportesolicitud.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(897, 437)
        Me.ReportViewer1.TabIndex = 1
        '
        'PRGPRODUCCIONDataSet
        '
        Me.PRGPRODUCCIONDataSet.DataSetName = "PRGPRODUCCIONDataSet"
        Me.PRGPRODUCCIONDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'd_filtrar_reporte_solicitudBindingSource
        '
        Me.d_filtrar_reporte_solicitudBindingSource.DataMember = "d_filtrar_reporte_solicitud"
        Me.d_filtrar_reporte_solicitudBindingSource.DataSource = Me.PRGPRODUCCIONDataSet
        '
        'd_filtrar_reporte_solicitudTableAdapter
        '
        Me.d_filtrar_reporte_solicitudTableAdapter.ClearBeforeFill = True
        '
        'VisualizadorReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 437)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "VisualizadorReporte"
        Me.Text = "VisualizadorReporte"
        CType(Me.PRGPRODUCCIONDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.d_filtrar_reporte_solicitudBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents d_filtrar_reporte_solicitudBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRGPRODUCCIONDataSet As Spic.PRGPRODUCCIONDataSet
    Friend WithEvents d_filtrar_reporte_solicitudTableAdapter As Spic.PRGPRODUCCIONDataSetTableAdapters.d_filtrar_reporte_solicitudTableAdapter
End Class
