<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportesEvaluaciones
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
        Me.CriteriosEvaluacionEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Clas_provEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FichaAlambEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DetalleRollosEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrdenProdEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpt = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.CriteriosEvaluacionEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Clas_provEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FichaAlambEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetalleRollosEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdenProdEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CriteriosEvaluacionEnBindingSource
        '
        Me.CriteriosEvaluacionEnBindingSource.DataSource = GetType(entidadNegocios.CriteriosEvaluacionEn)
        '
        'Clas_provEnBindingSource
        '
        Me.Clas_provEnBindingSource.DataSource = GetType(entidadNegocios.Clas_provEn)
        '
        'FichaAlambEnBindingSource
        '
        Me.FichaAlambEnBindingSource.DataSource = GetType(entidadNegocios.FichaAlambEn)
        '
        'DetalleRollosEnBindingSource
        '
        Me.DetalleRollosEnBindingSource.DataSource = GetType(entidadNegocios.DetalleRollosEn)
        '
        'OrdenProdEnBindingSource
        '
        Me.OrdenProdEnBindingSource.DataSource = GetType(entidadNegocios.OrdenProdEn)
        '
        'rpt
        '
        Me.rpt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "DTceriteriosEvaluacion"
        ReportDataSource1.Value = Me.CriteriosEvaluacionEnBindingSource
        ReportDataSource2.Name = "DTclasProv"
        ReportDataSource2.Value = Me.Clas_provEnBindingSource
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rpt.LocalReport.ReportEmbeddedResource = "Spic.RptEvaluacionesProv.rdlc"
        Me.rpt.Location = New System.Drawing.Point(-1, -1)
        Me.rpt.Name = "rpt"
        Me.rpt.Size = New System.Drawing.Size(604, 752)
        Me.rpt.TabIndex = 0
        '
        'FrmReportesEvaluaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 749)
        Me.Controls.Add(Me.rpt)
        Me.Name = "FrmReportesEvaluaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReportesFichas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CriteriosEvaluacionEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Clas_provEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FichaAlambEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetalleRollosEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdenProdEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FichaAlambEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DetalleRollosEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdenProdEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CriteriosEvaluacionEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Clas_provEnBindingSource As System.Windows.Forms.BindingSource
End Class
