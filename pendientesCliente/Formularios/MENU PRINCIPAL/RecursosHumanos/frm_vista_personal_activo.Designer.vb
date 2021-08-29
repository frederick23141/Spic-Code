<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_vista_personal_activo
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_an_in = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_an_f = New System.Windows.Forms.ComboBox()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.btn_ex = New System.Windows.Forms.Button()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_consulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.Location = New System.Drawing.Point(1, 51)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_consulta.Size = New System.Drawing.Size(556, 505)
        Me.dtg_consulta.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Año Inicial"
        '
        'cbo_an_in
        '
        Me.cbo_an_in.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_an_in.FormattingEnabled = True
        Me.cbo_an_in.Location = New System.Drawing.Point(162, 24)
        Me.cbo_an_in.Name = "cbo_an_in"
        Me.cbo_an_in.Size = New System.Drawing.Size(82, 21)
        Me.cbo_an_in.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Año Final"
        '
        'cbo_an_f
        '
        Me.cbo_an_f.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_an_f.FormattingEnabled = True
        Me.cbo_an_f.Location = New System.Drawing.Point(317, 24)
        Me.cbo_an_f.Name = "cbo_an_f"
        Me.cbo_an_f.Size = New System.Drawing.Size(82, 21)
        Me.cbo_an_f.TabIndex = 6
        '
        'btn_consultar
        '
        Me.btn_consultar.Location = New System.Drawing.Point(436, 22)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(75, 23)
        Me.btn_consultar.TabIndex = 7
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'btn_ex
        '
        Me.btn_ex.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_ex.Location = New System.Drawing.Point(1, -1)
        Me.btn_ex.Name = "btn_ex"
        Me.btn_ex.Size = New System.Drawing.Size(43, 41)
        Me.btn_ex.TabIndex = 8
        Me.btn_ex.UseVisualStyleBackColor = True
        '
        'frm_vista_personal_activo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 559)
        Me.Controls.Add(Me.btn_ex)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.cbo_an_f)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbo_an_in)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "frm_vista_personal_activo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe Personal Activo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_an_in As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_an_f As System.Windows.Forms.ComboBox
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents btn_ex As System.Windows.Forms.Button
End Class
