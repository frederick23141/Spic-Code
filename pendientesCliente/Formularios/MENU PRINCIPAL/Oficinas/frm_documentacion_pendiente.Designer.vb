<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_documentacion_pendiente
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
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnConsultar = New System.Windows.Forms.ToolStripButton()
        Me.dtg_clientes = New System.Windows.Forms.DataGridView()
        Me.col_ver = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_env = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.txt_nombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_fecha_in = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.group_correo = New System.Windows.Forms.GroupBox()
        Me.btn_enviar = New System.Windows.Forms.Button()
        Me.chk_estados = New System.Windows.Forms.CheckBox()
        Me.chk_pagare = New System.Windows.Forms.CheckBox()
        Me.chk_camar = New System.Windows.Forms.CheckBox()
        Me.chk_cc = New System.Windows.Forms.CheckBox()
        Me.chk_solicitud = New System.Windows.Forms.CheckBox()
        Me.chk_rut = New System.Windows.Forms.CheckBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_correo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_nuevo, Me.btnConsultar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Toolbar1.Size = New System.Drawing.Size(732, 34)
        Me.Toolbar1.TabIndex = 1146
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_nuevo.Image = Global.Spic.My.Resources.Resources._new
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(27, 31)
        Me.btn_nuevo.Text = "ToolStripButton2"
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
        'dtg_clientes
        '
        Me.dtg_clientes.AllowUserToAddRows = False
        Me.dtg_clientes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        Me.dtg_clientes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_clientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_clientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_clientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dtg_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ver, Me.col_env})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_clientes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_clientes.Location = New System.Drawing.Point(12, 113)
        Me.dtg_clientes.Name = "dtg_clientes"
        Me.dtg_clientes.ReadOnly = True
        Me.dtg_clientes.RowHeadersVisible = False
        Me.dtg_clientes.Size = New System.Drawing.Size(708, 288)
        Me.dtg_clientes.TabIndex = 1147
        '
        'col_ver
        '
        Me.col_ver.Frozen = True
        Me.col_ver.HeaderText = ""
        Me.col_ver.Image = Global.Spic.My.Resources.Resources._1385696415_file_search
        Me.col_ver.Name = "col_ver"
        Me.col_ver.ReadOnly = True
        Me.col_ver.Width = 5
        '
        'col_env
        '
        Me.col_env.HeaderText = ""
        Me.col_env.Image = Global.Spic.My.Resources.Resources._next
        Me.col_env.Name = "col_env"
        Me.col_env.ReadOnly = True
        Me.col_env.Width = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 16)
        Me.Label1.TabIndex = 1148
        Me.Label1.Text = "Nit:"
        '
        'txt_nit
        '
        Me.txt_nit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nit.Location = New System.Drawing.Point(90, 49)
        Me.txt_nit.Name = "txt_nit"
        Me.txt_nit.Size = New System.Drawing.Size(100, 22)
        Me.txt_nit.TabIndex = 1149
        '
        'txt_nombre
        '
        Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre.Location = New System.Drawing.Point(90, 85)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(206, 22)
        Me.txt_nombre.TabIndex = 1150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 1151
        Me.Label2.Text = "Nombre:"
        '
        'cbo_fecha_in
        '
        Me.cbo_fecha_in.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_fecha_in.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_in.Location = New System.Drawing.Point(377, 49)
        Me.cbo_fecha_in.Name = "cbo_fecha_in"
        Me.cbo_fecha_in.Size = New System.Drawing.Size(113, 22)
        Me.cbo_fecha_in.TabIndex = 1152
        '
        'cbo_fecha_fin
        '
        Me.cbo_fecha_fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin.Location = New System.Drawing.Point(547, 49)
        Me.cbo_fecha_fin.Name = "cbo_fecha_fin"
        Me.cbo_fecha_fin.Size = New System.Drawing.Size(113, 22)
        Me.cbo_fecha_fin.TabIndex = 1153
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(322, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 1154
        Me.Label3.Text = "Inicio:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(508, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 16)
        Me.Label4.TabIndex = 1155
        Me.Label4.Text = "Fin:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(322, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 1156
        Me.Label5.Text = "Vendedor:"
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vendedor.Location = New System.Drawing.Point(408, 85)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(100, 22)
        Me.txt_vendedor.TabIndex = 1157
        '
        'group_correo
        '
        Me.group_correo.BackColor = System.Drawing.SystemColors.ControlDark
        Me.group_correo.Controls.Add(Me.btn_cancelar)
        Me.group_correo.Controls.Add(Me.btn_enviar)
        Me.group_correo.Controls.Add(Me.chk_estados)
        Me.group_correo.Controls.Add(Me.chk_pagare)
        Me.group_correo.Controls.Add(Me.chk_camar)
        Me.group_correo.Controls.Add(Me.chk_cc)
        Me.group_correo.Controls.Add(Me.chk_solicitud)
        Me.group_correo.Controls.Add(Me.chk_rut)
        Me.group_correo.Location = New System.Drawing.Point(266, 96)
        Me.group_correo.Name = "group_correo"
        Me.group_correo.Size = New System.Drawing.Size(236, 238)
        Me.group_correo.TabIndex = 1158
        Me.group_correo.TabStop = False
        Me.group_correo.Text = "Documentos"
        Me.group_correo.Visible = False
        '
        'btn_enviar
        '
        Me.btn_enviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_enviar.Image = Global.Spic.My.Resources.Resources.ficha
        Me.btn_enviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_enviar.Location = New System.Drawing.Point(12, 178)
        Me.btn_enviar.Name = "btn_enviar"
        Me.btn_enviar.Size = New System.Drawing.Size(93, 42)
        Me.btn_enviar.TabIndex = 6
        Me.btn_enviar.Text = "Enviar"
        Me.btn_enviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_enviar.UseVisualStyleBackColor = True
        '
        'chk_estados
        '
        Me.chk_estados.AutoSize = True
        Me.chk_estados.Location = New System.Drawing.Point(24, 155)
        Me.chk_estados.Name = "chk_estados"
        Me.chk_estados.Size = New System.Drawing.Size(152, 17)
        Me.chk_estados.TabIndex = 5
        Me.chk_estados.Text = "ESTADOS FINANCIEROS"
        Me.chk_estados.UseVisualStyleBackColor = True
        '
        'chk_pagare
        '
        Me.chk_pagare.AutoSize = True
        Me.chk_pagare.Location = New System.Drawing.Point(24, 132)
        Me.chk_pagare.Name = "chk_pagare"
        Me.chk_pagare.Size = New System.Drawing.Size(70, 17)
        Me.chk_pagare.TabIndex = 4
        Me.chk_pagare.Text = "PAGARÉ"
        Me.chk_pagare.UseVisualStyleBackColor = True
        '
        'chk_camar
        '
        Me.chk_camar.AutoSize = True
        Me.chk_camar.Location = New System.Drawing.Point(24, 109)
        Me.chk_camar.Name = "chk_camar"
        Me.chk_camar.Size = New System.Drawing.Size(149, 17)
        Me.chk_camar.TabIndex = 3
        Me.chk_camar.Text = "CAMARA DE COMERCIO"
        Me.chk_camar.UseVisualStyleBackColor = True
        '
        'chk_cc
        '
        Me.chk_cc.AutoSize = True
        Me.chk_cc.Location = New System.Drawing.Point(24, 63)
        Me.chk_cc.Name = "chk_cc"
        Me.chk_cc.Size = New System.Drawing.Size(204, 17)
        Me.chk_cc.TabIndex = 2
        Me.chk_cc.Text = "CEDULA REPRESENTANTE LEGAL"
        Me.chk_cc.UseVisualStyleBackColor = True
        '
        'chk_solicitud
        '
        Me.chk_solicitud.AutoSize = True
        Me.chk_solicitud.Location = New System.Drawing.Point(24, 86)
        Me.chk_solicitud.Name = "chk_solicitud"
        Me.chk_solicitud.Size = New System.Drawing.Size(210, 17)
        Me.chk_solicitud.TabIndex = 1
        Me.chk_solicitud.Text = "SOLICITUD DE CREDITO/CONTADO"
        Me.chk_solicitud.UseVisualStyleBackColor = True
        '
        'chk_rut
        '
        Me.chk_rut.AutoSize = True
        Me.chk_rut.Location = New System.Drawing.Point(24, 40)
        Me.chk_rut.Name = "chk_rut"
        Me.chk_rut.Size = New System.Drawing.Size(49, 17)
        Me.chk_rut.TabIndex = 0
        Me.chk_rut.Text = "RUT"
        Me.chk_rut.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = Global.Spic.My.Resources.Resources._1371749741_32447
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(125, 178)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(99, 42)
        Me.btn_cancelar.TabIndex = 7
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'frm_documentacion_pendiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 413)
        Me.Controls.Add(Me.group_correo)
        Me.Controls.Add(Me.txt_vendedor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbo_fecha_fin)
        Me.Controls.Add(Me.cbo_fecha_in)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.txt_nit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtg_clientes)
        Me.Controls.Add(Me.Toolbar1)
        Me.Name = "frm_documentacion_pendiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_documentacion_pendiente"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_correo.ResumeLayout(False)
        Me.group_correo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtg_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_nit As System.Windows.Forms.TextBox
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_fecha_in As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents col_ver As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents col_env As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents group_correo As System.Windows.Forms.GroupBox
    Friend WithEvents btn_enviar As System.Windows.Forms.Button
    Friend WithEvents chk_estados As System.Windows.Forms.CheckBox
    Friend WithEvents chk_pagare As System.Windows.Forms.CheckBox
    Friend WithEvents chk_camar As System.Windows.Forms.CheckBox
    Friend WithEvents chk_cc As System.Windows.Forms.CheckBox
    Friend WithEvents chk_solicitud As System.Windows.Forms.CheckBox
    Friend WithEvents chk_rut As System.Windows.Forms.CheckBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
End Class
