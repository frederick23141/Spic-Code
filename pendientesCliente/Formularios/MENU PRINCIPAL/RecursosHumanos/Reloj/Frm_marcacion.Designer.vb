<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_marcacion
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
        Me.btn_marc_visit = New System.Windows.Forms.Button()
        Me.btn_marc_cont = New System.Windows.Forms.Button()
        Me.btn_consultar_cont = New System.Windows.Forms.Button()
        Me.btn_reg_maquilas = New System.Windows.Forms.Button()
        Me.btn_sin_ced = New System.Windows.Forms.Button()
        Me.pic_foto = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.lblConexion = New System.Windows.Forms.Label()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.lblNombres = New System.Windows.Forms.Label()
        Me.txtLector = New System.Windows.Forms.TextBox()
        Me.txt_hora = New System.Windows.Forms.TextBox()
        Me.txtAdvertencia = New System.Windows.Forms.TextBox()
        Me.timFecha = New System.Windows.Forms.Timer(Me.components)
        Me.timConexion = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pic_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_marc_visit
        '
        Me.btn_marc_visit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_marc_visit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_marc_visit.Image = Global.Spic.My.Resources.Resources._1385694385_friend_finder
        Me.btn_marc_visit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_marc_visit.Location = New System.Drawing.Point(604, 318)
        Me.btn_marc_visit.Name = "btn_marc_visit"
        Me.btn_marc_visit.Size = New System.Drawing.Size(233, 34)
        Me.btn_marc_visit.TabIndex = 1111
        Me.btn_marc_visit.Text = "Marcacion visitantes"
        Me.btn_marc_visit.UseVisualStyleBackColor = False
        '
        'btn_marc_cont
        '
        Me.btn_marc_cont.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_marc_cont.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_marc_cont.Image = Global.Spic.My.Resources.Resources._1385694385_friend_finder
        Me.btn_marc_cont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_marc_cont.Location = New System.Drawing.Point(604, 283)
        Me.btn_marc_cont.Name = "btn_marc_cont"
        Me.btn_marc_cont.Size = New System.Drawing.Size(233, 34)
        Me.btn_marc_cont.TabIndex = 1110
        Me.btn_marc_cont.Text = "Marcacion contratista"
        Me.btn_marc_cont.UseVisualStyleBackColor = False
        '
        'btn_consultar_cont
        '
        Me.btn_consultar_cont.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_consultar_cont.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar_cont.Image = Global.Spic.My.Resources.Resources._1373663824_36960
        Me.btn_consultar_cont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consultar_cont.Location = New System.Drawing.Point(604, 248)
        Me.btn_consultar_cont.Name = "btn_consultar_cont"
        Me.btn_consultar_cont.Size = New System.Drawing.Size(233, 33)
        Me.btn_consultar_cont.TabIndex = 1109
        Me.btn_consultar_cont.Text = "Consultar contratista"
        Me.btn_consultar_cont.UseVisualStyleBackColor = False
        '
        'btn_reg_maquilas
        '
        Me.btn_reg_maquilas.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reg_maquilas.Image = Global.Spic.My.Resources.Resources._1373663824_36960
        Me.btn_reg_maquilas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_reg_maquilas.Location = New System.Drawing.Point(382, 318)
        Me.btn_reg_maquilas.Name = "btn_reg_maquilas"
        Me.btn_reg_maquilas.Size = New System.Drawing.Size(216, 34)
        Me.btn_reg_maquilas.TabIndex = 1108
        Me.btn_reg_maquilas.Text = "Registrar personal maquilas"
        Me.btn_reg_maquilas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_reg_maquilas.UseVisualStyleBackColor = True
        '
        'btn_sin_ced
        '
        Me.btn_sin_ced.BackColor = System.Drawing.Color.Red
        Me.btn_sin_ced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_sin_ced.Image = Global.Spic.My.Resources.Resources._1385694385_friend_finder
        Me.btn_sin_ced.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sin_ced.Location = New System.Drawing.Point(383, 248)
        Me.btn_sin_ced.Name = "btn_sin_ced"
        Me.btn_sin_ced.Size = New System.Drawing.Size(215, 34)
        Me.btn_sin_ced.TabIndex = 1107
        Me.btn_sin_ced.Text = "Marcación sin cédula"
        Me.btn_sin_ced.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_sin_ced.UseVisualStyleBackColor = False
        '
        'pic_foto
        '
        Me.pic_foto.Location = New System.Drawing.Point(1, 58)
        Me.pic_foto.Name = "pic_foto"
        Me.pic_foto.Size = New System.Drawing.Size(372, 360)
        Me.pic_foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_foto.TabIndex = 1106
        Me.pic_foto.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 80.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(-27, 449)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(307, 120)
        Me.lblEstado.TabIndex = 1101
        Me.lblEstado.Text = "Entro"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(377, 363)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 18)
        Me.Label1.TabIndex = 1105
        Me.Label1.Text = "Sin marcación de salida"
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_consulta.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_consulta.Location = New System.Drawing.Point(383, 385)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(396, 167)
        Me.dtg_consulta.TabIndex = 1104
        '
        'lblConexion
        '
        Me.lblConexion.AutoSize = True
        Me.lblConexion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConexion.Location = New System.Drawing.Point(377, 29)
        Me.lblConexion.Name = "lblConexion"
        Me.lblConexion.Size = New System.Drawing.Size(123, 29)
        Me.lblConexion.TabIndex = 1103
        Me.lblConexion.Text = "Conexión"
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistrar.Image = Global.Spic.My.Resources.Resources._1373663824_36960
        Me.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRegistrar.Location = New System.Drawing.Point(381, 283)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(217, 34)
        Me.btnRegistrar.TabIndex = 1102
        Me.btnRegistrar.Text = "Registrar cédula"
        Me.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'lblNombres
        '
        Me.lblNombres.AutoSize = True
        Me.lblNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 33.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombres.ForeColor = System.Drawing.Color.Blue
        Me.lblNombres.Location = New System.Drawing.Point(2, 6)
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.Size = New System.Drawing.Size(206, 52)
        Me.lblNombres.TabIndex = 1100
        Me.lblNombres.Text = "Nombres"
        '
        'txtLector
        '
        Me.txtLector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLector.Location = New System.Drawing.Point(383, 165)
        Me.txtLector.Name = "txtLector"
        Me.txtLector.Size = New System.Drawing.Size(396, 80)
        Me.txtLector.TabIndex = 1099
        '
        'txt_hora
        '
        Me.txt_hora.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_hora.Location = New System.Drawing.Point(383, 81)
        Me.txt_hora.Name = "txt_hora"
        Me.txt_hora.ReadOnly = True
        Me.txt_hora.Size = New System.Drawing.Size(396, 80)
        Me.txt_hora.TabIndex = 1098
        Me.txt_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAdvertencia
        '
        Me.txtAdvertencia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdvertencia.BackColor = System.Drawing.Color.White
        Me.txtAdvertencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdvertencia.ForeColor = System.Drawing.Color.Red
        Me.txtAdvertencia.Location = New System.Drawing.Point(383, 58)
        Me.txtAdvertencia.Name = "txtAdvertencia"
        Me.txtAdvertencia.ReadOnly = True
        Me.txtAdvertencia.Size = New System.Drawing.Size(396, 20)
        Me.txtAdvertencia.TabIndex = 1097
        Me.txtAdvertencia.Text = "COLOCAR EL CÓDIGO DE LA CÉDULA  EN LA LUZ DEL LECTOR"
        Me.txtAdvertencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'timFecha
        '
        Me.timFecha.Enabled = True
        Me.timFecha.Interval = 1000
        '
        'timConexion
        '
        Me.timConexion.Enabled = True
        Me.timConexion.Interval = 120000
        '
        'Frm_marcacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 549)
        Me.Controls.Add(Me.btn_marc_visit)
        Me.Controls.Add(Me.btn_marc_cont)
        Me.Controls.Add(Me.btn_consultar_cont)
        Me.Controls.Add(Me.btn_reg_maquilas)
        Me.Controls.Add(Me.btn_sin_ced)
        Me.Controls.Add(Me.pic_foto)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Controls.Add(Me.lblConexion)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.lblNombres)
        Me.Controls.Add(Me.txtLector)
        Me.Controls.Add(Me.txt_hora)
        Me.Controls.Add(Me.txtAdvertencia)
        Me.Name = "Frm_marcacion"
        Me.Text = "Marcación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pic_foto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_marc_visit As Button
    Friend WithEvents btn_marc_cont As Button
    Friend WithEvents btn_consultar_cont As Button
    Friend WithEvents btn_reg_maquilas As Button
    Friend WithEvents btn_sin_ced As Button
    Friend WithEvents pic_foto As PictureBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtg_consulta As DataGridView
    Friend WithEvents lblConexion As Label
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents lblNombres As Label
    Friend WithEvents txtLector As TextBox
    Friend WithEvents txt_hora As TextBox
    Friend WithEvents txtAdvertencia As TextBox
    Friend WithEvents timFecha As Timer
    Friend WithEvents timConexion As Timer
End Class
