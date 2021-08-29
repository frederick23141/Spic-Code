<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_pesar_cargar_rollo
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
        Me.lbl_desc_producto = New System.Windows.Forms.Label()
        Me.Group_defecto = New System.Windows.Forms.GroupBox()
        Me.cbo_defecto = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_ok_defecto = New System.Windows.Forms.Button()
        Me.Lbldevanador = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_bobina = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_orden = New System.Windows.Forms.Label()
        Me.lbl_codigo_m = New System.Windows.Forms.Label()
        Me.flecha_devanador = New System.Windows.Forms.PictureBox()
        Me.flecha_rollo = New System.Windows.Forms.PictureBox()
        Me.GroupBox_devanador = New System.Windows.Forms.GroupBox()
        Me.Btn_borrar_Devanador = New System.Windows.Forms.Button()
        Me.btn_p_devanador = New System.Windows.Forms.Button()
        Me.Panel_cargar = New System.Windows.Forms.Panel()
        Me.lbl_calibre = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btncargar_panel = New System.Windows.Forms.Button()
        Me.lblnomb_panel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.abel_nom_orden = New System.Windows.Forms.Label()
        Me.GroupBox_rollo = New System.Windows.Forms.GroupBox()
        Me.btn_cargar_rollo_N = New System.Windows.Forms.Button()
        Me.btn_cargar_rollo = New System.Windows.Forms.Button()
        Me.txt_peso = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.HelpProvider2 = New System.Windows.Forms.HelpProvider()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.Group_defecto.SuspendLayout()
        CType(Me.flecha_devanador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flecha_rollo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_devanador.SuspendLayout()
        Me.Panel_cargar.SuspendLayout()
        Me.GroupBox_rollo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_desc_producto
        '
        Me.lbl_desc_producto.AutoSize = True
        Me.lbl_desc_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_desc_producto.Location = New System.Drawing.Point(100, 38)
        Me.lbl_desc_producto.Name = "lbl_desc_producto"
        Me.lbl_desc_producto.Size = New System.Drawing.Size(72, 24)
        Me.lbl_desc_producto.TabIndex = 6
        Me.lbl_desc_producto.Text = "Label9"
        '
        'Group_defecto
        '
        Me.Group_defecto.Controls.Add(Me.cbo_defecto)
        Me.Group_defecto.Controls.Add(Me.Label46)
        Me.Group_defecto.Controls.Add(Me.Button1)
        Me.Group_defecto.Controls.Add(Me.btn_ok_defecto)
        Me.Group_defecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_defecto.ForeColor = System.Drawing.Color.Red
        Me.Group_defecto.Location = New System.Drawing.Point(151, 94)
        Me.Group_defecto.Name = "Group_defecto"
        Me.Group_defecto.Size = New System.Drawing.Size(513, 139)
        Me.Group_defecto.TabIndex = 2143
        Me.Group_defecto.TabStop = False
        Me.Group_defecto.Text = "Seleccione defecto de no conforme"
        Me.Group_defecto.Visible = False
        '
        'cbo_defecto
        '
        Me.cbo_defecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_defecto.FormattingEnabled = True
        Me.cbo_defecto.Location = New System.Drawing.Point(82, 32)
        Me.cbo_defecto.Name = "cbo_defecto"
        Me.cbo_defecto.Size = New System.Drawing.Size(411, 28)
        Me.cbo_defecto.TabIndex = 1188
        Me.cbo_defecto.Text = "Seleccione"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(14, 38)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(56, 13)
        Me.Label46.TabIndex = 1187
        Me.Label46.Text = "Defecto:"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(485, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 1185
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_ok_defecto
        '
        Me.btn_ok_defecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok_defecto.ForeColor = System.Drawing.Color.Black
        Me.btn_ok_defecto.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_ok_defecto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok_defecto.Location = New System.Drawing.Point(185, 82)
        Me.btn_ok_defecto.Name = "btn_ok_defecto"
        Me.btn_ok_defecto.Size = New System.Drawing.Size(107, 38)
        Me.btn_ok_defecto.TabIndex = 1180
        Me.btn_ok_defecto.Text = "OK"
        Me.btn_ok_defecto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ok_defecto.UseVisualStyleBackColor = True
        '
        'Lbldevanador
        '
        Me.Lbldevanador.AutoSize = True
        Me.Lbldevanador.Location = New System.Drawing.Point(129, 78)
        Me.Lbldevanador.Name = "Lbldevanador"
        Me.Lbldevanador.Size = New System.Drawing.Size(0, 13)
        Me.Lbldevanador.TabIndex = 2142
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 2141
        Me.Label2.Text = "Peso devanador:"
        '
        'lbl_bobina
        '
        Me.lbl_bobina.AutoSize = True
        Me.lbl_bobina.Location = New System.Drawing.Point(249, 79)
        Me.lbl_bobina.Name = "lbl_bobina"
        Me.lbl_bobina.Size = New System.Drawing.Size(0, 13)
        Me.lbl_bobina.TabIndex = 2140
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 18)
        Me.Label1.TabIndex = 2139
        Me.Label1.Text = "Bobina:"
        '
        'lbl_orden
        '
        Me.lbl_orden.AutoSize = True
        Me.lbl_orden.Location = New System.Drawing.Point(503, 19)
        Me.lbl_orden.Name = "lbl_orden"
        Me.lbl_orden.Size = New System.Drawing.Size(0, 13)
        Me.lbl_orden.TabIndex = 2138
        '
        'lbl_codigo_m
        '
        Me.lbl_codigo_m.AutoSize = True
        Me.lbl_codigo_m.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo_m.Location = New System.Drawing.Point(100, 12)
        Me.lbl_codigo_m.Name = "lbl_codigo_m"
        Me.lbl_codigo_m.Size = New System.Drawing.Size(59, 20)
        Me.lbl_codigo_m.TabIndex = 2137
        Me.lbl_codigo_m.Text = "Codigo"
        '
        'flecha_devanador
        '
        Me.flecha_devanador.Location = New System.Drawing.Point(160, 111)
        Me.flecha_devanador.Name = "flecha_devanador"
        Me.flecha_devanador.Size = New System.Drawing.Size(49, 40)
        Me.flecha_devanador.TabIndex = 2136
        Me.flecha_devanador.TabStop = False
        '
        'flecha_rollo
        '
        Me.flecha_rollo.Location = New System.Drawing.Point(585, 111)
        Me.flecha_rollo.Name = "flecha_rollo"
        Me.flecha_rollo.Size = New System.Drawing.Size(52, 38)
        Me.flecha_rollo.TabIndex = 2135
        Me.flecha_rollo.TabStop = False
        '
        'GroupBox_devanador
        '
        Me.GroupBox_devanador.BackColor = System.Drawing.Color.Red
        Me.GroupBox_devanador.Controls.Add(Me.Btn_borrar_Devanador)
        Me.GroupBox_devanador.Controls.Add(Me.btn_p_devanador)
        Me.GroupBox_devanador.Location = New System.Drawing.Point(23, 157)
        Me.GroupBox_devanador.Name = "GroupBox_devanador"
        Me.GroupBox_devanador.Size = New System.Drawing.Size(348, 175)
        Me.GroupBox_devanador.TabIndex = 2134
        Me.GroupBox_devanador.TabStop = False
        Me.GroupBox_devanador.Text = "Pesar devanador"
        '
        'Btn_borrar_Devanador
        '
        Me.Btn_borrar_Devanador.Location = New System.Drawing.Point(73, 46)
        Me.Btn_borrar_Devanador.Name = "Btn_borrar_Devanador"
        Me.Btn_borrar_Devanador.Size = New System.Drawing.Size(175, 94)
        Me.Btn_borrar_Devanador.TabIndex = 1
        Me.Btn_borrar_Devanador.Text = "Borrar devanador"
        Me.Btn_borrar_Devanador.UseVisualStyleBackColor = True
        '
        'btn_p_devanador
        '
        Me.btn_p_devanador.Location = New System.Drawing.Point(73, 46)
        Me.btn_p_devanador.Name = "btn_p_devanador"
        Me.btn_p_devanador.Size = New System.Drawing.Size(175, 94)
        Me.btn_p_devanador.TabIndex = 0
        Me.btn_p_devanador.Text = "Pesar devanador"
        Me.btn_p_devanador.UseVisualStyleBackColor = True
        '
        'Panel_cargar
        '
        Me.Panel_cargar.Controls.Add(Me.lbl_calibre)
        Me.Panel_cargar.Controls.Add(Me.Button2)
        Me.Panel_cargar.Controls.Add(Me.btncargar_panel)
        Me.Panel_cargar.Controls.Add(Me.lblnomb_panel)
        Me.Panel_cargar.Controls.Add(Me.Label6)
        Me.Panel_cargar.Controls.Add(Me.Label5)
        Me.Panel_cargar.Location = New System.Drawing.Point(23, 95)
        Me.Panel_cargar.Name = "Panel_cargar"
        Me.Panel_cargar.Size = New System.Drawing.Size(801, 241)
        Me.Panel_cargar.TabIndex = 2128
        '
        'lbl_calibre
        '
        Me.lbl_calibre.AutoSize = True
        Me.lbl_calibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_calibre.Location = New System.Drawing.Point(321, 68)
        Me.lbl_calibre.Name = "lbl_calibre"
        Me.lbl_calibre.Size = New System.Drawing.Size(118, 37)
        Me.lbl_calibre.TabIndex = 1187
        Me.lbl_calibre.Text = "calibre"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(775, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 1186
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btncargar_panel
        '
        Me.btncargar_panel.BackColor = System.Drawing.Color.Lime
        Me.btncargar_panel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncargar_panel.Location = New System.Drawing.Point(272, 142)
        Me.btncargar_panel.Name = "btncargar_panel"
        Me.btncargar_panel.Size = New System.Drawing.Size(246, 75)
        Me.btncargar_panel.TabIndex = 7
        Me.btncargar_panel.Text = "Cargar"
        Me.btncargar_panel.UseVisualStyleBackColor = False
        '
        'lblnomb_panel
        '
        Me.lblnomb_panel.AutoSize = True
        Me.lblnomb_panel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnomb_panel.Location = New System.Drawing.Point(361, 11)
        Me.lblnomb_panel.Name = "lblnomb_panel"
        Me.lblnomb_panel.Size = New System.Drawing.Size(57, 18)
        Me.lblnomb_panel.TabIndex = 4
        Me.lblnomb_panel.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(219, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Nombre operario:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(219, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 29)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Calibre:"
        '
        'abel_nom_orden
        '
        Me.abel_nom_orden.AutoSize = True
        Me.abel_nom_orden.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abel_nom_orden.Location = New System.Drawing.Point(392, 14)
        Me.abel_nom_orden.Name = "abel_nom_orden"
        Me.abel_nom_orden.Size = New System.Drawing.Size(112, 18)
        Me.abel_nom_orden.TabIndex = 2133
        Me.abel_nom_orden.Text = "Nro de orden:"
        '
        'GroupBox_rollo
        '
        Me.GroupBox_rollo.BackColor = System.Drawing.Color.Red
        Me.GroupBox_rollo.Controls.Add(Me.btn_cargar_rollo_N)
        Me.GroupBox_rollo.Controls.Add(Me.btn_cargar_rollo)
        Me.GroupBox_rollo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox_rollo.Location = New System.Drawing.Point(387, 157)
        Me.GroupBox_rollo.Name = "GroupBox_rollo"
        Me.GroupBox_rollo.Size = New System.Drawing.Size(437, 175)
        Me.GroupBox_rollo.TabIndex = 2129
        Me.GroupBox_rollo.TabStop = False
        Me.GroupBox_rollo.Text = "Cargar rollo a la orden de producción"
        '
        'btn_cargar_rollo_N
        '
        Me.btn_cargar_rollo_N.Location = New System.Drawing.Point(26, 46)
        Me.btn_cargar_rollo_N.Name = "btn_cargar_rollo_N"
        Me.btn_cargar_rollo_N.Size = New System.Drawing.Size(182, 94)
        Me.btn_cargar_rollo_N.TabIndex = 1161
        Me.btn_cargar_rollo_N.Text = "Cargar rollo no conforme"
        Me.btn_cargar_rollo_N.UseVisualStyleBackColor = True
        '
        'btn_cargar_rollo
        '
        Me.btn_cargar_rollo.Location = New System.Drawing.Point(235, 46)
        Me.btn_cargar_rollo.Name = "btn_cargar_rollo"
        Me.btn_cargar_rollo.Size = New System.Drawing.Size(182, 94)
        Me.btn_cargar_rollo.TabIndex = 1160
        Me.btn_cargar_rollo.Text = "Cargar rollo"
        Me.btn_cargar_rollo.UseVisualStyleBackColor = True
        '
        'txt_peso
        '
        Me.txt_peso.Enabled = False
        Me.txt_peso.Location = New System.Drawing.Point(436, 71)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.Size = New System.Drawing.Size(308, 20)
        Me.txt_peso.TabIndex = 2131
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(389, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 2130
        Me.Label12.Text = "Peso*:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 60
        '
        'SerialPort1
        '
        Me.SerialPort1.WriteTimeout = 2000
        '
        'SerialPort2
        '
        Me.SerialPort2.PortName = "COM2"
        Me.SerialPort2.WriteTimeout = 2000
        '
        'Frm_pesar_cargar_rollo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 352)
        Me.Controls.Add(Me.Panel_cargar)
        Me.Controls.Add(Me.Group_defecto)
        Me.Controls.Add(Me.lbl_desc_producto)
        Me.Controls.Add(Me.Lbldevanador)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_bobina)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_orden)
        Me.Controls.Add(Me.lbl_codigo_m)
        Me.Controls.Add(Me.flecha_devanador)
        Me.Controls.Add(Me.flecha_rollo)
        Me.Controls.Add(Me.GroupBox_devanador)
        Me.Controls.Add(Me.abel_nom_orden)
        Me.Controls.Add(Me.GroupBox_rollo)
        Me.Controls.Add(Me.txt_peso)
        Me.Controls.Add(Me.Label12)
        Me.Name = "Frm_pesar_cargar_rollo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesar rollo galvanizado"
        Me.Group_defecto.ResumeLayout(False)
        Me.Group_defecto.PerformLayout()
        CType(Me.flecha_devanador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flecha_rollo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_devanador.ResumeLayout(False)
        Me.Panel_cargar.ResumeLayout(False)
        Me.Panel_cargar.PerformLayout()
        Me.GroupBox_rollo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_desc_producto As System.Windows.Forms.Label
    Friend WithEvents Group_defecto As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_defecto As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_ok_defecto As System.Windows.Forms.Button
    Friend WithEvents Lbldevanador As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_bobina As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_orden As System.Windows.Forms.Label
    Friend WithEvents lbl_codigo_m As System.Windows.Forms.Label
    Friend WithEvents flecha_devanador As System.Windows.Forms.PictureBox
    Friend WithEvents flecha_rollo As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox_devanador As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_borrar_Devanador As System.Windows.Forms.Button
    Friend WithEvents btn_p_devanador As System.Windows.Forms.Button
    Friend WithEvents abel_nom_orden As System.Windows.Forms.Label
    Friend WithEvents GroupBox_rollo As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cargar_rollo_N As System.Windows.Forms.Button
    Friend WithEvents btn_cargar_rollo As System.Windows.Forms.Button
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents HelpProvider2 As System.Windows.Forms.HelpProvider
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents SerialPort2 As System.IO.Ports.SerialPort
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblnomb_panel As System.Windows.Forms.Label
    Friend WithEvents btncargar_panel As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbl_calibre As System.Windows.Forms.Label
    Friend WithEvents Panel_cargar As System.Windows.Forms.Panel
End Class
