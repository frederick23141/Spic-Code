<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_estupefacientes
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
        Me.dtg_infor_estupefacientes = New System.Windows.Forms.DataGridView()
        Me.Dtg_i_estupefacientes_e_s = New System.Windows.Forms.DataGridView()
        CType(Me.dtg_infor_estupefacientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtg_i_estupefacientes_e_s, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_infor_estupefacientes
        '
        Me.dtg_infor_estupefacientes.AllowUserToAddRows = False
        Me.dtg_infor_estupefacientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_infor_estupefacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_infor_estupefacientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_infor_estupefacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_infor_estupefacientes.Location = New System.Drawing.Point(10, 215)
        Me.dtg_infor_estupefacientes.Name = "dtg_infor_estupefacientes"
        Me.dtg_infor_estupefacientes.Size = New System.Drawing.Size(469, 185)
        Me.dtg_infor_estupefacientes.TabIndex = 3
        '
        'Dtg_i_estupefacientes_e_s
        '
        Me.Dtg_i_estupefacientes_e_s.AllowUserToAddRows = False
        Me.Dtg_i_estupefacientes_e_s.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dtg_i_estupefacientes_e_s.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Dtg_i_estupefacientes_e_s.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Dtg_i_estupefacientes_e_s.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dtg_i_estupefacientes_e_s.Location = New System.Drawing.Point(10, 13)
        Me.Dtg_i_estupefacientes_e_s.Name = "Dtg_i_estupefacientes_e_s"
        Me.Dtg_i_estupefacientes_e_s.Size = New System.Drawing.Size(469, 185)
        Me.Dtg_i_estupefacientes_e_s.TabIndex = 2
        '
        'frm_estupefacientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 408)
        Me.Controls.Add(Me.dtg_infor_estupefacientes)
        Me.Controls.Add(Me.Dtg_i_estupefacientes_e_s)
        Me.Name = "frm_estupefacientes"
        Me.Text = "Estupefacientes"
        CType(Me.dtg_infor_estupefacientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtg_i_estupefacientes_e_s, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtg_infor_estupefacientes As System.Windows.Forms.DataGridView
    Friend WithEvents Dtg_i_estupefacientes_e_s As System.Windows.Forms.DataGridView
End Class
