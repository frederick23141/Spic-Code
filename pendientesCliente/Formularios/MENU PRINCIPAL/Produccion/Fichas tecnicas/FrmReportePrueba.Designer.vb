<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportePrueba
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
        Me.OrdenProdLnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpt2 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.OrdenProdLnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OrdenProdLnBindingSource
        '
        Me.OrdenProdLnBindingSource.DataSource = GetType(entidadNegocios.OrdenProdEn)
        '
        'rpt2
        '
        Me.rpt2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "objOrdenProdLn"
        ReportDataSource1.Value = Me.OrdenProdLnBindingSource
        Me.rpt2.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpt2.LocalReport.ReportEmbeddedResource = "Presentacion.Report1.rdlc"
        Me.rpt2.Location = New System.Drawing.Point(0, 0)
        Me.rpt2.Name = "rpt2"
        Me.rpt2.Size = New System.Drawing.Size(763, 445)
        Me.rpt2.TabIndex = 0
        '
        'FrmReportePrueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 444)
        Me.Controls.Add(Me.rpt2)
        Me.Name = "FrmReportePrueba"
        Me.Text = "FrmReportePrueba"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.OrdenProdLnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpt2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents OrdenProdLnBindingSource As System.Windows.Forms.BindingSource
End Class
