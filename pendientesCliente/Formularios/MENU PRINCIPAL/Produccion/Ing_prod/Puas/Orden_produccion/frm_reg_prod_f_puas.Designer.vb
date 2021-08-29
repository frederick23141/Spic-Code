<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reg_prod_f_puas
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
        Me.txt_indicador = New System.Windows.Forms.TextBox()
        Me.txt_peso = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_ref = New System.Windows.Forms.Label()
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.lbl_orden = New System.Windows.Forms.Label()
        Me.pn_desperdicios = New System.Windows.Forms.Panel()
        Me.btn_cerrar_chat = New System.Windows.Forms.Button()
        Me.btn_chatarra = New System.Windows.Forms.Button()
        Me.cbo_defecto = New System.Windows.Forms.ComboBox()
        Me.lbldefecto = New System.Windows.Forms.Label()
        Me.lblchatarra = New System.Windows.Forms.Label()
        Me.pn_causal = New System.Windows.Forms.Panel()
        Me.btn_cerrar2 = New System.Windows.Forms.Button()
        Me.btn_ok_causal = New System.Windows.Forms.Button()
        Me.cbo_causal = New System.Windows.Forms.ComboBox()
        Me.lbl_re_causal = New System.Windows.Forms.Label()
        Me.lbl_causal = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tool_planilla = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Peso_R = New System.Windows.Forms.TextBox()
        Me.btn_noconforme = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btn_tiq = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnchatarra = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cbo_operario = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.pn_desperdicios.SuspendLayout()
        Me.pn_causal.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cbo_operario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_indicador
        '
        Me.txt_indicador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_indicador.BackColor = System.Drawing.Color.White
        Me.txt_indicador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_indicador.Enabled = False
        Me.txt_indicador.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_indicador.Location = New System.Drawing.Point(28, 93)
        Me.txt_indicador.Name = "txt_indicador"
        Me.txt_indicador.Size = New System.Drawing.Size(427, 42)
        Me.txt_indicador.TabIndex = 1
        Me.txt_indicador.Text = "Indicador"
        '
        'txt_peso
        '
        Me.txt_peso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_peso.BackColor = System.Drawing.Color.White
        Me.txt_peso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_peso.Enabled = False
        Me.txt_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_peso.Location = New System.Drawing.Point(30, 238)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.Size = New System.Drawing.Size(173, 33)
        Me.txt_peso.TabIndex = 2
        Me.txt_peso.Text = "Peso"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Indicador:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(27, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Peso Fc:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(25, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Operario:"
        '
        'lbl_ref
        '
        Me.lbl_ref.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_ref.AutoSize = True
        Me.lbl_ref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_ref.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ref.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbl_ref.Location = New System.Drawing.Point(28, 9)
        Me.lbl_ref.Name = "lbl_ref"
        Me.lbl_ref.Size = New System.Drawing.Size(51, 33)
        Me.lbl_ref.TabIndex = 7
        Me.lbl_ref.Text = "ref"
        '
        'lbl_nombre
        '
        Me.lbl_nombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre.Location = New System.Drawing.Point(28, 51)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(84, 16)
        Me.lbl_nombre.TabIndex = 8
        Me.lbl_nombre.Text = "Referencia"
        '
        'Timer1
        '
        Me.Timer1.Interval = 60
        '
        'SerialPort1
        '
        Me.SerialPort1.WriteTimeout = 2000
        '
        'lbl_orden
        '
        Me.lbl_orden.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_orden.AutoSize = True
        Me.lbl_orden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_orden.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_orden.ForeColor = System.Drawing.Color.Green
        Me.lbl_orden.Location = New System.Drawing.Point(471, 9)
        Me.lbl_orden.Name = "lbl_orden"
        Me.lbl_orden.Size = New System.Drawing.Size(42, 27)
        Me.lbl_orden.TabIndex = 9
        Me.lbl_orden.Text = "ref"
        '
        'pn_desperdicios
        '
        Me.pn_desperdicios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pn_desperdicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pn_desperdicios.Controls.Add(Me.btn_cerrar_chat)
        Me.pn_desperdicios.Controls.Add(Me.btn_chatarra)
        Me.pn_desperdicios.Controls.Add(Me.cbo_defecto)
        Me.pn_desperdicios.Controls.Add(Me.lbldefecto)
        Me.pn_desperdicios.Controls.Add(Me.lblchatarra)
        Me.pn_desperdicios.Location = New System.Drawing.Point(31, 302)
        Me.pn_desperdicios.Name = "pn_desperdicios"
        Me.pn_desperdicios.Size = New System.Drawing.Size(472, 234)
        Me.pn_desperdicios.TabIndex = 12
        Me.pn_desperdicios.Visible = False
        '
        'btn_cerrar_chat
        '
        Me.btn_cerrar_chat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_chat.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_chat.Location = New System.Drawing.Point(444, 0)
        Me.btn_cerrar_chat.Name = "btn_cerrar_chat"
        Me.btn_cerrar_chat.Size = New System.Drawing.Size(26, 23)
        Me.btn_cerrar_chat.TabIndex = 1186
        Me.btn_cerrar_chat.Text = "X"
        Me.btn_cerrar_chat.UseVisualStyleBackColor = True
        '
        'btn_chatarra
        '
        Me.btn_chatarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_chatarra.ForeColor = System.Drawing.Color.Black
        Me.btn_chatarra.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_chatarra.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_chatarra.Location = New System.Drawing.Point(183, 148)
        Me.btn_chatarra.Name = "btn_chatarra"
        Me.btn_chatarra.Size = New System.Drawing.Size(107, 38)
        Me.btn_chatarra.TabIndex = 1190
        Me.btn_chatarra.Text = "OK"
        Me.btn_chatarra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_chatarra.UseVisualStyleBackColor = True
        '
        'cbo_defecto
        '
        Me.cbo_defecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_defecto.FormattingEnabled = True
        Me.cbo_defecto.Location = New System.Drawing.Point(100, 69)
        Me.cbo_defecto.Name = "cbo_defecto"
        Me.cbo_defecto.Size = New System.Drawing.Size(350, 28)
        Me.cbo_defecto.TabIndex = 1189
        Me.cbo_defecto.Text = "Seleccione"
        '
        'lbldefecto
        '
        Me.lbldefecto.AutoSize = True
        Me.lbldefecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldefecto.ForeColor = System.Drawing.Color.Black
        Me.lbldefecto.Location = New System.Drawing.Point(22, 73)
        Me.lbldefecto.Name = "lbldefecto"
        Me.lbldefecto.Size = New System.Drawing.Size(72, 18)
        Me.lbldefecto.TabIndex = 1
        Me.lbldefecto.Text = "Defecto:"
        '
        'lblchatarra
        '
        Me.lblchatarra.AutoSize = True
        Me.lblchatarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblchatarra.ForeColor = System.Drawing.Color.Red
        Me.lblchatarra.Location = New System.Drawing.Point(3, 11)
        Me.lblchatarra.Name = "lblchatarra"
        Me.lblchatarra.Size = New System.Drawing.Size(266, 20)
        Me.lblchatarra.TabIndex = 0
        Me.lblchatarra.Text = "Seleccionar defecto de chatarra"
        '
        'pn_causal
        '
        Me.pn_causal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pn_causal.Controls.Add(Me.btn_cerrar2)
        Me.pn_causal.Controls.Add(Me.btn_ok_causal)
        Me.pn_causal.Controls.Add(Me.cbo_causal)
        Me.pn_causal.Controls.Add(Me.lbl_re_causal)
        Me.pn_causal.Controls.Add(Me.lbl_causal)
        Me.pn_causal.Location = New System.Drawing.Point(35, 301)
        Me.pn_causal.Name = "pn_causal"
        Me.pn_causal.Size = New System.Drawing.Size(475, 235)
        Me.pn_causal.TabIndex = 1191
        Me.pn_causal.Visible = False
        '
        'btn_cerrar2
        '
        Me.btn_cerrar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar2.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar2.Location = New System.Drawing.Point(450, -1)
        Me.btn_cerrar2.Name = "btn_cerrar2"
        Me.btn_cerrar2.Size = New System.Drawing.Size(26, 23)
        Me.btn_cerrar2.TabIndex = 1187
        Me.btn_cerrar2.Text = "X"
        Me.btn_cerrar2.UseVisualStyleBackColor = True
        '
        'btn_ok_causal
        '
        Me.btn_ok_causal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_ok_causal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok_causal.Image = Global.Spic.My.Resources.Resources.acept
        Me.btn_ok_causal.Location = New System.Drawing.Point(201, 172)
        Me.btn_ok_causal.Name = "btn_ok_causal"
        Me.btn_ok_causal.Size = New System.Drawing.Size(90, 23)
        Me.btn_ok_causal.TabIndex = 4
        Me.btn_ok_causal.Text = "Ok"
        Me.btn_ok_causal.UseVisualStyleBackColor = True
        '
        'cbo_causal
        '
        Me.cbo_causal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_causal.FormattingEnabled = True
        Me.cbo_causal.Location = New System.Drawing.Point(144, 112)
        Me.cbo_causal.Name = "cbo_causal"
        Me.cbo_causal.Size = New System.Drawing.Size(233, 21)
        Me.cbo_causal.TabIndex = 3
        '
        'lbl_re_causal
        '
        Me.lbl_re_causal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_re_causal.AutoSize = True
        Me.lbl_re_causal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_re_causal.Location = New System.Drawing.Point(42, 109)
        Me.lbl_re_causal.Name = "lbl_re_causal"
        Me.lbl_re_causal.Size = New System.Drawing.Size(79, 24)
        Me.lbl_re_causal.TabIndex = 2
        Me.lbl_re_causal.Text = "Causal:"
        '
        'lbl_causal
        '
        Me.lbl_causal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_causal.AutoSize = True
        Me.lbl_causal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_causal.ForeColor = System.Drawing.Color.Red
        Me.lbl_causal.Location = New System.Drawing.Point(19, 33)
        Me.lbl_causal.Name = "lbl_causal"
        Me.lbl_causal.Size = New System.Drawing.Size(160, 20)
        Me.lbl_causal.TabIndex = 1
        Me.lbl_causal.Text = "Seleccionar causal"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_planilla})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(24, 539)
        Me.ToolStrip1.TabIndex = 1192
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tool_planilla
        '
        Me.tool_planilla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_planilla.Image = Global.Spic.My.Resources.Resources._1385694500_document_add
        Me.tool_planilla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_planilla.Name = "tool_planilla"
        Me.tool_planilla.Size = New System.Drawing.Size(21, 20)
        Me.tool_planilla.Text = "Registrar planilla"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(310, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 16)
        Me.Label4.TabIndex = 1194
        Me.Label4.Text = "Peso Real :"
        '
        'txt_Peso_R
        '
        Me.txt_Peso_R.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Peso_R.BackColor = System.Drawing.Color.White
        Me.txt_Peso_R.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_Peso_R.Enabled = False
        Me.txt_Peso_R.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Peso_R.Location = New System.Drawing.Point(313, 238)
        Me.txt_Peso_R.Name = "txt_Peso_R"
        Me.txt_Peso_R.Size = New System.Drawing.Size(173, 33)
        Me.txt_Peso_R.TabIndex = 1193
        Me.txt_Peso_R.Text = "Peso"
        '
        'btn_noconforme
        '
        Me.btn_noconforme.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_noconforme.Location = New System.Drawing.Point(86, 381)
        Me.btn_noconforme.Name = "btn_noconforme"
        Me.btn_noconforme.Size = New System.Drawing.Size(349, 73)
        Me.btn_noconforme.StateNormal.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btn_noconforme.StateNormal.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btn_noconforme.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_noconforme.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btn_noconforme.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btn_noconforme.TabIndex = 1195
        Me.btn_noconforme.Values.Image = Global.Spic.My.Resources.Resources.ticket3
        Me.btn_noconforme.Values.Text = "Reproceso"
        '
        'btn_tiq
        '
        Me.btn_tiq.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_tiq.Location = New System.Drawing.Point(86, 302)
        Me.btn_tiq.Name = "btn_tiq"
        Me.btn_tiq.Size = New System.Drawing.Size(349, 73)
        Me.btn_tiq.StateNormal.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btn_tiq.StateNormal.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btn_tiq.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tiq.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btn_tiq.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btn_tiq.TabIndex = 1196
        Me.btn_tiq.Values.Image = Global.Spic.My.Resources.Resources.ticket3
        Me.btn_tiq.Values.Text = "Registrar producto"
        '
        'btnchatarra
        '
        Me.btnchatarra.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnchatarra.Location = New System.Drawing.Point(86, 459)
        Me.btnchatarra.Name = "btnchatarra"
        Me.btnchatarra.Size = New System.Drawing.Size(349, 73)
        Me.btnchatarra.StateNormal.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.btnchatarra.StateNormal.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnchatarra.StateNormal.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnchatarra.StateNormal.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.btnchatarra.StateNormal.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near
        Me.btnchatarra.TabIndex = 1197
        Me.btnchatarra.Values.Image = Global.Spic.My.Resources.Resources.ticket3
        Me.btnchatarra.Values.Text = "Chatarra"
        '
        'cbo_operario
        '
        Me.cbo_operario.DropDownWidth = 427
        Me.cbo_operario.Location = New System.Drawing.Point(27, 170)
        Me.cbo_operario.Name = "cbo_operario"
        Me.cbo_operario.Size = New System.Drawing.Size(427, 21)
        Me.cbo_operario.StateNormal.Item.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_operario.TabIndex = 1198
        '
        'frm_reg_prod_f_puas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 539)
        Me.Controls.Add(Me.pn_causal)
        Me.Controls.Add(Me.cbo_operario)
        Me.Controls.Add(Me.pn_desperdicios)
        Me.Controls.Add(Me.btnchatarra)
        Me.Controls.Add(Me.btn_tiq)
        Me.Controls.Add(Me.btn_noconforme)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_Peso_R)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lbl_orden)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Controls.Add(Me.lbl_ref)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_peso)
        Me.Controls.Add(Me.txt_indicador)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reg_prod_f_puas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de producto"
        Me.pn_desperdicios.ResumeLayout(False)
        Me.pn_desperdicios.PerformLayout()
        Me.pn_causal.ResumeLayout(False)
        Me.pn_causal.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cbo_operario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_indicador As System.Windows.Forms.TextBox
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_ref As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents lbl_orden As System.Windows.Forms.Label
    Friend WithEvents pn_desperdicios As System.Windows.Forms.Panel
    Friend WithEvents lbldefecto As System.Windows.Forms.Label
    Friend WithEvents lblchatarra As System.Windows.Forms.Label
    Friend WithEvents cbo_defecto As System.Windows.Forms.ComboBox
    Friend WithEvents btn_chatarra As System.Windows.Forms.Button
    Friend WithEvents btn_cerrar_chat As System.Windows.Forms.Button
    Friend WithEvents pn_causal As System.Windows.Forms.Panel
    Friend WithEvents btn_ok_causal As System.Windows.Forms.Button
    Friend WithEvents cbo_causal As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_re_causal As System.Windows.Forms.Label
    Friend WithEvents lbl_causal As System.Windows.Forms.Label
    Friend WithEvents btn_cerrar2 As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tool_planilla As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_Peso_R As TextBox
    Friend WithEvents btn_noconforme As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btn_tiq As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnchatarra As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cbo_operario As ComponentFactory.Krypton.Toolkit.KryptonComboBox
End Class
