<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_rpt_fact
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.FacturaDetEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FacturaEncEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpt = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.FacturaDetEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacturaEncEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FacturaDetEnBindingSource
        '
        Me.FacturaDetEnBindingSource.DataSource = GetType(entidadNegocios.FacturaDetEn)
        '
        'FacturaEncEnBindingSource
        '
        Me.FacturaEncEnBindingSource.DataSource = GetType(entidadNegocios.FacturaEncEn)
        '
        'rpt
        '
        Me.rpt.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dts_ts_detalle"
        ReportDataSource1.Value = Me.FacturaDetEnBindingSource
        ReportDataSource2.Name = "dts_fact_enc"
        ReportDataSource2.Value = Me.FacturaEncEnBindingSource
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rpt.LocalReport.ReportEmbeddedResource = "Spic.rpt_fact.rdlc"
        Me.rpt.Location = New System.Drawing.Point(0, 0)
        Me.rpt.Name = "rpt"
        Me.rpt.Size = New System.Drawing.Size(328, 261)
        Me.rpt.TabIndex = 1
        '
        'Frm_rpt_fact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 261)
        Me.Controls.Add(Me.rpt)
        Me.Name = "Frm_rpt_fact"
        Me.Text = "Frm_rpt_fact"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FacturaDetEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacturaEncEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FacturaDetEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FacturaEncEnBindingSource As System.Windows.Forms.BindingSource
End Class
