<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_report_pendientes_zona
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
        Me.CORSANDataSet4 = New Spic.CORSANDataSet4()
        Me.V_pendientes_por_vendedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_pendientes_por_vendedorTableAdapter = New Spic.CORSANDataSet4TableAdapters.V_pendientes_por_vendedorTableAdapter()
        Me.TableAdapterManager = New Spic.CORSANDataSet4TableAdapters.TableAdapterManager()
        CType(Me.CORSANDataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V_pendientes_por_vendedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CORSANDataSet4
        '
        Me.CORSANDataSet4.DataSetName = "CORSANDataSet4"
        Me.CORSANDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'V_pendientes_por_vendedorBindingSource
        '
        Me.V_pendientes_por_vendedorBindingSource.DataMember = "V_pendientes_por_vendedor"
        Me.V_pendientes_por_vendedorBindingSource.DataSource = Me.CORSANDataSet4
        '
        'V_pendientes_por_vendedorTableAdapter
        '
        Me.V_pendientes_por_vendedorTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = Spic.CORSANDataSet4TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Frm_report_pendientes_zona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 372)
        Me.Name = "Frm_report_pendientes_zona"
        Me.Text = "Frm_report_pendientes_zona"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CORSANDataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V_pendientes_por_vendedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CORSANDataSet4 As Spic.CORSANDataSet4
    Friend WithEvents V_pendientes_por_vendedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_pendientes_por_vendedorTableAdapter As Spic.CORSANDataSet4TableAdapters.V_pendientes_por_vendedorTableAdapter
    Friend WithEvents TableAdapterManager As Spic.CORSANDataSet4TableAdapters.TableAdapterManager
End Class
