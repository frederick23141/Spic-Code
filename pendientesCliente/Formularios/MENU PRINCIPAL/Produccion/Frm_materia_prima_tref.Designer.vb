<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_materia_prima_tref
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
        Me.dtg_alambron = New System.Windows.Forms.DataGridView()
        Me.dtg_reproceso = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_actualizar = New System.Windows.Forms.Button()
        Me.txt_detalle = New System.Windows.Forms.TextBox()
        Me.lbl_detalle = New System.Windows.Forms.Label()
        Me.txt_nro_orden = New System.Windows.Forms.TextBox()
        Me.lbl_nro_orden = New System.Windows.Forms.Label()
        CType(Me.dtg_alambron, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_reproceso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_alambron
        '
        Me.dtg_alambron.AllowUserToAddRows = False
        Me.dtg_alambron.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_alambron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_alambron.EnableHeadersVisualStyles = False
        Me.dtg_alambron.Location = New System.Drawing.Point(12, 70)
        Me.dtg_alambron.Name = "dtg_alambron"
        Me.dtg_alambron.RowHeadersVisible = False
        Me.dtg_alambron.Size = New System.Drawing.Size(707, 160)
        Me.dtg_alambron.TabIndex = 0
        '
        'dtg_reproceso
        '
        Me.dtg_reproceso.AllowUserToAddRows = False
        Me.dtg_reproceso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_reproceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_reproceso.Location = New System.Drawing.Point(12, 252)
        Me.dtg_reproceso.Name = "dtg_reproceso"
        Me.dtg_reproceso.RowHeadersVisible = False
        Me.dtg_reproceso.Size = New System.Drawing.Size(707, 191)
        Me.dtg_reproceso.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Alambron"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 233)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Reproceso"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btn_actualizar)
        Me.GroupBox1.Controls.Add(Me.txt_detalle)
        Me.GroupBox1.Controls.Add(Me.lbl_detalle)
        Me.GroupBox1.Controls.Add(Me.txt_nro_orden)
        Me.GroupBox1.Controls.Add(Me.lbl_nro_orden)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(698, 45)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro"
        '
        'btn_actualizar
        '
        Me.btn_actualizar.BackColor = System.Drawing.Color.Lime
        Me.btn_actualizar.Location = New System.Drawing.Point(63, 16)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(75, 23)
        Me.btn_actualizar.TabIndex = 4
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.UseVisualStyleBackColor = False
        '
        'txt_detalle
        '
        Me.txt_detalle.Location = New System.Drawing.Point(520, 16)
        Me.txt_detalle.Name = "txt_detalle"
        Me.txt_detalle.Size = New System.Drawing.Size(100, 20)
        Me.txt_detalle.TabIndex = 3
        '
        'lbl_detalle
        '
        Me.lbl_detalle.AutoSize = True
        Me.lbl_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_detalle.Location = New System.Drawing.Point(411, 19)
        Me.lbl_detalle.Name = "lbl_detalle"
        Me.lbl_detalle.Size = New System.Drawing.Size(106, 16)
        Me.lbl_detalle.TabIndex = 2
        Me.lbl_detalle.Text = "Detalle orden:"
        '
        'txt_nro_orden
        '
        Me.txt_nro_orden.Location = New System.Drawing.Point(286, 16)
        Me.txt_nro_orden.Name = "txt_nro_orden"
        Me.txt_nro_orden.Size = New System.Drawing.Size(100, 20)
        Me.txt_nro_orden.TabIndex = 1
        '
        'lbl_nro_orden
        '
        Me.lbl_nro_orden.AutoSize = True
        Me.lbl_nro_orden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nro_orden.Location = New System.Drawing.Point(148, 19)
        Me.lbl_nro_orden.Name = "lbl_nro_orden"
        Me.lbl_nro_orden.Size = New System.Drawing.Size(132, 16)
        Me.lbl_nro_orden.TabIndex = 0
        Me.lbl_nro_orden.Text = "Numero de orden:"
        '
        'Frm_materia_prima_tref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 471)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtg_reproceso)
        Me.Controls.Add(Me.dtg_alambron)
        Me.Name = "Frm_materia_prima_tref"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Materia prima ordenes producción trefilación"
        CType(Me.dtg_alambron, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_reproceso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_alambron As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_reproceso As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents txt_detalle As System.Windows.Forms.TextBox
    Friend WithEvents lbl_detalle As System.Windows.Forms.Label
    Friend WithEvents txt_nro_orden As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nro_orden As System.Windows.Forms.Label
End Class
