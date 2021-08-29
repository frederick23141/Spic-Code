<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_informe_dif_tref
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.btn_excel = New System.Windows.Forms.ToolStripButton()
        Me.cbo_ano = New System.Windows.Forms.ComboBox()
        Me.cbo_mes = New System.Windows.Forms.ComboBox()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.rdb_interno = New System.Windows.Forms.RadioButton()
        Me.rdb_externo = New System.Windows.Forms.RadioButton()
        Me.chk_consolidar = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.Control
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConsultar, Me.btn_excel})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(751, 34)
        Me.Toolbar1.TabIndex = 1196
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'btnConsultar
        '
        Me.btnConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.update
        Me.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(27, 31)
        Me.btnConsultar.Text = "Consultar"
        '
        'btn_excel
        '
        Me.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(27, 31)
        Me.btn_excel.Text = "ToolStripButton3"
        '
        'cbo_ano
        '
        Me.cbo_ano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ano.FormattingEnabled = True
        Me.cbo_ano.Location = New System.Drawing.Point(75, 46)
        Me.cbo_ano.Name = "cbo_ano"
        Me.cbo_ano.Size = New System.Drawing.Size(103, 21)
        Me.cbo_ano.TabIndex = 1198
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Location = New System.Drawing.Point(75, 73)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(103, 21)
        Me.cbo_mes.TabIndex = 1199
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.dtg_consulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_consulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dtg_consulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Location = New System.Drawing.Point(12, 100)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(727, 311)
        Me.dtg_consulta.TabIndex = 1200
        '
        'rdb_interno
        '
        Me.rdb_interno.AutoSize = True
        Me.rdb_interno.Location = New System.Drawing.Point(184, 47)
        Me.rdb_interno.Name = "rdb_interno"
        Me.rdb_interno.Size = New System.Drawing.Size(58, 17)
        Me.rdb_interno.TabIndex = 1201
        Me.rdb_interno.TabStop = True
        Me.rdb_interno.Text = "Interno"
        Me.rdb_interno.UseVisualStyleBackColor = True
        '
        'rdb_externo
        '
        Me.rdb_externo.AutoSize = True
        Me.rdb_externo.Location = New System.Drawing.Point(184, 73)
        Me.rdb_externo.Name = "rdb_externo"
        Me.rdb_externo.Size = New System.Drawing.Size(61, 17)
        Me.rdb_externo.TabIndex = 1202
        Me.rdb_externo.TabStop = True
        Me.rdb_externo.Text = "Externo"
        Me.rdb_externo.UseVisualStyleBackColor = True
        '
        'chk_consolidar
        '
        Me.chk_consolidar.AutoSize = True
        Me.chk_consolidar.Location = New System.Drawing.Point(75, 12)
        Me.chk_consolidar.Name = "chk_consolidar"
        Me.chk_consolidar.Size = New System.Drawing.Size(96, 17)
        Me.chk_consolidar.TabIndex = 1203
        Me.chk_consolidar.Text = "CONSOLIDAR"
        Me.chk_consolidar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 1204
        Me.Label1.Text = "AÑO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 1205
        Me.Label2.Text = "MES:"
        '
        'frm_informe_dif_tref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 423)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chk_consolidar)
        Me.Controls.Add(Me.rdb_externo)
        Me.Controls.Add(Me.rdb_interno)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Controls.Add(Me.cbo_mes)
        Me.Controls.Add(Me.cbo_ano)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "frm_informe_dif_tref"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe Diferencia Trefilacion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbo_ano As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents rdb_interno As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_externo As System.Windows.Forms.RadioButton
    Friend WithEvents chk_consolidar As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
