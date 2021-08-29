<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_transaciones_terminado
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_transaciones_terminado))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_num_transaccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbo_operario = New System.Windows.Forms.ComboBox()
        Me.chk_todo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_movimientos = New System.Windows.Forms.Label()
        Me.btn_reiniciar_contador = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoLector)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(213, 46)
        Me.GroupBox2.TabIndex = 1074
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lector Hand-Held"
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLector.Location = New System.Drawing.Point(5, 16)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(202, 26)
        Me.txtCodigoLector.TabIndex = 1074
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colCant, Me.col_tipo, Me.col_num_transaccion})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgConsulta.Enabled = False
        Me.dtgConsulta.Location = New System.Drawing.Point(1, 81)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(314, 182)
        Me.dtgConsulta.TabIndex = 1080
        '
        'colCodigo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCodigo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCodigo.Frozen = True
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colCant
        '
        DataGridViewCellStyle3.Format = "N1"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colCant.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCant.Frozen = True
        Me.colCant.HeaderText = "Cant"
        Me.colCant.Name = "colCant"
        Me.colCant.ReadOnly = True
        Me.colCant.Width = 54
        '
        'col_tipo
        '
        Me.col_tipo.HeaderText = "Tipo"
        Me.col_tipo.Name = "col_tipo"
        Me.col_tipo.ReadOnly = True
        Me.col_tipo.Width = 53
        '
        'col_num_transaccion
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.NullValue = Nothing
        Me.col_num_transaccion.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_num_transaccion.HeaderText = "Número"
        Me.col_num_transaccion.Name = "col_num_transaccion"
        Me.col_num_transaccion.ReadOnly = True
        Me.col_num_transaccion.Width = 69
        '
        'cbo_operario
        '
        Me.cbo_operario.FormattingEnabled = True
        Me.cbo_operario.Location = New System.Drawing.Point(64, 6)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(250, 21)
        Me.cbo_operario.TabIndex = 1088
        '
        'chk_todo
        '
        Me.chk_todo.AutoSize = True
        Me.chk_todo.Location = New System.Drawing.Point(5, 8)
        Me.chk_todo.Name = "chk_todo"
        Me.chk_todo.Size = New System.Drawing.Size(56, 17)
        Me.chk_todo.TabIndex = 1089
        Me.chk_todo.Text = "Todos"
        Me.chk_todo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(221, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 1091
        Me.Label2.Text = "Movimientos"
        '
        'lbl_movimientos
        '
        Me.lbl_movimientos.AutoSize = True
        Me.lbl_movimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_movimientos.ForeColor = System.Drawing.Color.Red
        Me.lbl_movimientos.Location = New System.Drawing.Point(224, 41)
        Me.lbl_movimientos.Name = "lbl_movimientos"
        Me.lbl_movimientos.Size = New System.Drawing.Size(36, 37)
        Me.lbl_movimientos.TabIndex = 1090
        Me.lbl_movimientos.Text = "0"
        '
        'btn_reiniciar_contador
        '
        Me.btn_reiniciar_contador.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_reiniciar_contador.Location = New System.Drawing.Point(283, 46)
        Me.btn_reiniciar_contador.Name = "btn_reiniciar_contador"
        Me.btn_reiniciar_contador.Size = New System.Drawing.Size(31, 23)
        Me.btn_reiniciar_contador.TabIndex = 1092
        Me.btn_reiniciar_contador.UseVisualStyleBackColor = True
        '
        'Frm_transaciones_terminado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 267)
        Me.Controls.Add(Me.btn_reiniciar_contador)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_movimientos)
        Me.Controls.Add(Me.chk_todo)
        Me.Controls.Add(Me.cbo_operario)
        Me.Controls.Add(Me.dtgConsulta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_transaciones_terminado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ingreso de produccción"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_operario As System.Windows.Forms.ComboBox
    Friend WithEvents chk_todo As System.Windows.Forms.CheckBox
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_num_transaccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_movimientos As System.Windows.Forms.Label
    Friend WithEvents btn_reiniciar_contador As System.Windows.Forms.Button
End Class
