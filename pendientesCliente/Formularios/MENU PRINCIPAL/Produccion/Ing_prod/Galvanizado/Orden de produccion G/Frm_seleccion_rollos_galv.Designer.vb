<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_seleccion_rollos_galv
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtg_Consulta = New System.Windows.Forms.DataGridView()
        Me.btnSeleccion = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtcodigo_rollo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dtg_Consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_Consulta
        '
        Me.dtg_Consulta.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_Consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_Consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_Consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_Consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_Consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_Consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnSeleccion})
        Me.dtg_Consulta.Location = New System.Drawing.Point(39, 64)
        Me.dtg_Consulta.Name = "dtg_Consulta"
        Me.dtg_Consulta.ReadOnly = True
        Me.dtg_Consulta.RowHeadersVisible = False
        Me.dtg_Consulta.Size = New System.Drawing.Size(585, 313)
        Me.dtg_Consulta.TabIndex = 1108
        '
        'btnSeleccion
        '
        Me.btnSeleccion.Frozen = True
        Me.btnSeleccion.HeaderText = "Seleccionar"
        Me.btnSeleccion.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btnSeleccion.Name = "btnSeleccion"
        Me.btnSeleccion.ReadOnly = True
        Me.btnSeleccion.Width = 69
        '
        'txtcodigo_rollo
        '
        Me.txtcodigo_rollo.Location = New System.Drawing.Point(116, 27)
        Me.txtcodigo_rollo.Name = "txtcodigo_rollo"
        Me.txtcodigo_rollo.Size = New System.Drawing.Size(100, 20)
        Me.txtcodigo_rollo.TabIndex = 1107
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 1106
        Me.Label1.Text = "Codigo rollo"
        '
        'frm_seleccion_rollos_galv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 404)
        Me.Controls.Add(Me.dtg_Consulta)
        Me.Controls.Add(Me.txtcodigo_rollo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_seleccion_rollos_galv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de codigos"
        CType(Me.dtg_Consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_Consulta As System.Windows.Forms.DataGridView
    Friend WithEvents btnSeleccion As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtcodigo_rollo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
