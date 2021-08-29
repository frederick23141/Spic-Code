<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportesManual
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.FichaAlambEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DetalleRollosEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrdenProdEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpt = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Calidad_alambronEnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.FichaAlambEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetalleRollosEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdenProdEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Calidad_alambronEnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        ReportDataSource1.Name = "EncFichaAlamb"
        ReportDataSource1.Value = Me.FichaAlambEnBindingSource
        ReportDataSource2.Name = "DetRollos"
        ReportDataSource2.Value = Me.DetalleRollosEnBindingSource
        ReportDataSource3.Name = "DetRollos2"
        ReportDataSource3.Value = Me.DetalleRollosEnBindingSource
        ReportDataSource4.Name = "Calidad_alambron"
        ReportDataSource4.Value = Me.Calidad_alambronEnBindingSource
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rpt.LocalReport.DataSources.Add(ReportDataSource4)
        Me.rpt.LocalReport.ReportEmbeddedResource = "Spic.RptFichaAlambManual.rdlc"
        Me.rpt.Location = New System.Drawing.Point(-1, -1)
        Me.rpt.Name = "rpt"
        Me.rpt.Size = New System.Drawing.Size(604, 736)
        Me.rpt.TabIndex = 0
        '
        'Calidad_alambronEnBindingSource
        '
        Me.Calidad_alambronEnBindingSource.DataSource = GetType(entidadNegocios.Calidad_alambronEn)
        '
        'FrmReportesManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 733)
        Me.Controls.Add(Me.rpt)
        Me.Name = "FrmReportesManual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReportesFichas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FichaAlambEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetalleRollosEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdenProdEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Calidad_alambronEnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FichaAlambEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DetalleRollosEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdenProdEnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Calidad_alambronEnBindingSource As System.Windows.Forms.BindingSource
End Class
