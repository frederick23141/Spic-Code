<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_auditoria_tiquetes
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.menStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemCopia = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerPlanillaDeCargueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_consult_prov = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_consult_importacion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chk_tran_entrada = New System.Windows.Forms.CheckBox()
        Me.chk_sin_entrada = New System.Windows.Forms.CheckBox()
        Me.chk_tiq_unico = New System.Windows.Forms.CheckBox()
        Me.chk_ent_salida = New System.Windows.Forms.CheckBox()
        Me.chk_todo = New System.Windows.Forms.CheckBox()
        Me.chk_consum_trefila = New System.Windows.Forms.CheckBox()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStrip.SuspendLayout()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator3, Me.btnConsultar, Me.ToolStripSplitButton1})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(751, 34)
        Me.Toolbar1.TabIndex = 1068
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 31)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 31)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
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
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = Global.Spic.My.Resources.Resources.excel
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(27, 31)
        Me.ToolStripSplitButton1.Text = "Exportar a excel"
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.ContextMenuStrip = Me.menStrip
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.Location = New System.Drawing.Point(7, 63)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(739, 364)
        Me.dtg_consulta.TabIndex = 1088
        '
        'menStrip
        '
        Me.menStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemCopia, Me.EliminarRegistroToolStripMenuItem, Me.VerPlanillaDeCargueToolStripMenuItem})
        Me.menStrip.Name = "ContextMenuStrip1"
        Me.menStrip.Size = New System.Drawing.Size(196, 70)
        '
        'itemCopia
        '
        Me.itemCopia.Image = Global.Spic.My.Resources.Resources.ficha
        Me.itemCopia.Name = "itemCopia"
        Me.itemCopia.Size = New System.Drawing.Size(195, 22)
        Me.itemCopia.Text = "Copia de tiquete"
        '
        'EliminarRegistroToolStripMenuItem
        '
        Me.EliminarRegistroToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.borrar
        Me.EliminarRegistroToolStripMenuItem.Name = "EliminarRegistroToolStripMenuItem"
        Me.EliminarRegistroToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.EliminarRegistroToolStripMenuItem.Text = "Eliminar registro"
        '
        'VerPlanillaDeCargueToolStripMenuItem
        '
        Me.VerPlanillaDeCargueToolStripMenuItem.Image = Global.Spic.My.Resources.Resources._1385696415_file_search
        Me.VerPlanillaDeCargueToolStripMenuItem.Name = "VerPlanillaDeCargueToolStripMenuItem"
        Me.VerPlanillaDeCargueToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.VerPlanillaDeCargueToolStripMenuItem.Text = "Ver planilla de cargue"
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(70, 140)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(610, 188)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 1114
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(52, 37)
        Me.txtCodigo.MaxLength = 30
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(157, 20)
        Me.txtCodigo.TabIndex = 1136
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1135
        Me.Label1.Text = "Código:"
        '
        'cbo_consult_prov
        '
        Me.cbo_consult_prov.FormattingEnabled = True
        Me.cbo_consult_prov.Location = New System.Drawing.Point(289, 36)
        Me.cbo_consult_prov.Name = "cbo_consult_prov"
        Me.cbo_consult_prov.Size = New System.Drawing.Size(283, 21)
        Me.cbo_consult_prov.TabIndex = 1140
        Me.cbo_consult_prov.Text = "Seleccione"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(215, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 1141
        Me.Label9.Text = "Proveedor:"
        '
        'cbo_consult_importacion
        '
        Me.cbo_consult_importacion.FormattingEnabled = True
        Me.cbo_consult_importacion.Location = New System.Drawing.Point(629, 36)
        Me.cbo_consult_importacion.Name = "cbo_consult_importacion"
        Me.cbo_consult_importacion.Size = New System.Drawing.Size(80, 21)
        Me.cbo_consult_importacion.TabIndex = 1142
        Me.cbo_consult_importacion.Text = "Seleccione"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(576, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 1143
        Me.Label4.Text = "Número:"
        '
        'chk_tran_entrada
        '
        Me.chk_tran_entrada.AutoSize = True
        Me.chk_tran_entrada.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.chk_tran_entrada.Location = New System.Drawing.Point(261, 8)
        Me.chk_tran_entrada.Name = "chk_tran_entrada"
        Me.chk_tran_entrada.Size = New System.Drawing.Size(80, 17)
        Me.chk_tran_entrada.TabIndex = 1144
        Me.chk_tran_entrada.Text = "BODEGA 1"
        Me.chk_tran_entrada.UseVisualStyleBackColor = False
        '
        'chk_sin_entrada
        '
        Me.chk_sin_entrada.AutoSize = True
        Me.chk_sin_entrada.BackColor = System.Drawing.Color.FromArgb(CType(CType(143, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.chk_sin_entrada.ForeColor = System.Drawing.Color.White
        Me.chk_sin_entrada.Location = New System.Drawing.Point(149, 8)
        Me.chk_sin_entrada.Name = "chk_sin_entrada"
        Me.chk_sin_entrada.Size = New System.Drawing.Size(107, 17)
        Me.chk_sin_entrada.TabIndex = 1145
        Me.chk_sin_entrada.Text = "SIN ENTRADAR"
        Me.chk_sin_entrada.UseVisualStyleBackColor = False
        '
        'chk_tiq_unico
        '
        Me.chk_tiq_unico.AutoSize = True
        Me.chk_tiq_unico.BackColor = System.Drawing.Color.Yellow
        Me.chk_tiq_unico.Location = New System.Drawing.Point(542, 8)
        Me.chk_tiq_unico.Name = "chk_tiq_unico"
        Me.chk_tiq_unico.Size = New System.Drawing.Size(91, 17)
        Me.chk_tiq_unico.TabIndex = 1146
        Me.chk_tiq_unico.Text = "Tiquete único"
        Me.chk_tiq_unico.UseVisualStyleBackColor = False
        '
        'chk_ent_salida
        '
        Me.chk_ent_salida.AutoSize = True
        Me.chk_ent_salida.BackColor = System.Drawing.Color.Purple
        Me.chk_ent_salida.ForeColor = System.Drawing.Color.White
        Me.chk_ent_salida.Location = New System.Drawing.Point(348, 8)
        Me.chk_ent_salida.Name = "chk_ent_salida"
        Me.chk_ent_salida.Size = New System.Drawing.Size(80, 17)
        Me.chk_ent_salida.TabIndex = 1147
        Me.chk_ent_salida.Text = "BODEGA 2"
        Me.chk_ent_salida.UseVisualStyleBackColor = False
        '
        'chk_todo
        '
        Me.chk_todo.AutoSize = True
        Me.chk_todo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.chk_todo.Checked = True
        Me.chk_todo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_todo.Location = New System.Drawing.Point(692, 8)
        Me.chk_todo.Name = "chk_todo"
        Me.chk_todo.Size = New System.Drawing.Size(57, 17)
        Me.chk_todo.TabIndex = 1148
        Me.chk_todo.Text = "TODO"
        Me.chk_todo.UseVisualStyleBackColor = False
        '
        'chk_consum_trefila
        '
        Me.chk_consum_trefila.AutoSize = True
        Me.chk_consum_trefila.BackColor = System.Drawing.Color.Silver
        Me.chk_consum_trefila.ForeColor = System.Drawing.Color.Black
        Me.chk_consum_trefila.Location = New System.Drawing.Point(434, 8)
        Me.chk_consum_trefila.Name = "chk_consum_trefila"
        Me.chk_consum_trefila.Size = New System.Drawing.Size(99, 17)
        Me.chk_consum_trefila.TabIndex = 1149
        Me.chk_consum_trefila.Text = "CONSUMIDOS"
        Me.chk_consum_trefila.UseVisualStyleBackColor = False
        '
        'Frm_auditoria_tiquetes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 429)
        Me.Controls.Add(Me.chk_consum_trefila)
        Me.Controls.Add(Me.chk_todo)
        Me.Controls.Add(Me.chk_ent_salida)
        Me.Controls.Add(Me.chk_tiq_unico)
        Me.Controls.Add(Me.chk_sin_entrada)
        Me.Controls.Add(Me.chk_tran_entrada)
        Me.Controls.Add(Me.cbo_consult_importacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbo_consult_prov)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "Frm_auditoria_tiquetes"
        Me.Text = "Auditoria tiquetes de alambrón"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStrip.ResumeLayout(False)
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_consult_prov As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_consult_importacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chk_tran_entrada As System.Windows.Forms.CheckBox
    Friend WithEvents chk_sin_entrada As System.Windows.Forms.CheckBox
    Friend WithEvents chk_tiq_unico As System.Windows.Forms.CheckBox
    Friend WithEvents chk_ent_salida As System.Windows.Forms.CheckBox
    Friend WithEvents chk_todo As System.Windows.Forms.CheckBox
    Friend WithEvents chk_consum_trefila As System.Windows.Forms.CheckBox
    Friend WithEvents menStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemCopia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerPlanillaDeCargueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
