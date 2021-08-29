<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_imp_tiq_dev
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_ref = New System.Windows.Forms.ComboBox()
        Me.cbo_ref_pf = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_peso = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_fac_cons = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_colada = New System.Windows.Forms.TextBox()
        Me.txt_diametro = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_clase = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_doc_client = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_nom_cliente = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_razon = New System.Windows.Forms.TextBox()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.rdb_bodega2 = New System.Windows.Forms.RadioButton()
        Me.rdb_bodega4 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(420, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GENERAR TIQUETE DE DEVOLUCION"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Referencia:"
        '
        'cbo_ref
        '
        Me.cbo_ref.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbo_ref.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ref.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_ref.FormattingEnabled = True
        Me.cbo_ref.Location = New System.Drawing.Point(112, 50)
        Me.cbo_ref.Name = "cbo_ref"
        Me.cbo_ref.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbo_ref.Size = New System.Drawing.Size(329, 23)
        Me.cbo_ref.TabIndex = 2
        '
        'cbo_ref_pf
        '
        Me.cbo_ref_pf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ref_pf.Enabled = False
        Me.cbo_ref_pf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbo_ref_pf.FormattingEnabled = True
        Me.cbo_ref_pf.Location = New System.Drawing.Point(112, 91)
        Me.cbo_ref_pf.Name = "cbo_ref_pf"
        Me.cbo_ref_pf.Size = New System.Drawing.Size(329, 23)
        Me.cbo_ref_pf.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Referencia:"
        '
        'txt_peso
        '
        Me.txt_peso.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_peso.Location = New System.Drawing.Point(112, 134)
        Me.txt_peso.Name = "txt_peso"
        Me.txt_peso.Size = New System.Drawing.Size(329, 38)
        Me.txt_peso.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-2, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 33)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "PESO:"
        '
        'txt_fac_cons
        '
        Me.txt_fac_cons.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fac_cons.Location = New System.Drawing.Point(7, 453)
        Me.txt_fac_cons.Name = "txt_fac_cons"
        Me.txt_fac_cons.Size = New System.Drawing.Size(437, 31)
        Me.txt_fac_cons.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 432)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(248, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Factura o Consecutivo Anterior:"
        '
        'txt_colada
        '
        Me.txt_colada.Location = New System.Drawing.Point(12, 202)
        Me.txt_colada.Name = "txt_colada"
        Me.txt_colada.Size = New System.Drawing.Size(132, 20)
        Me.txt_colada.TabIndex = 9
        '
        'txt_diametro
        '
        Me.txt_diametro.Location = New System.Drawing.Point(161, 202)
        Me.txt_diametro.Name = "txt_diametro"
        Me.txt_diametro.Size = New System.Drawing.Size(132, 20)
        Me.txt_diametro.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 18)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Colada:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(158, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 18)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Diametro:"
        '
        'cbo_clase
        '
        Me.cbo_clase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_clase.FormattingEnabled = True
        Me.cbo_clase.Location = New System.Drawing.Point(309, 202)
        Me.cbo_clase.Name = "cbo_clase"
        Me.cbo_clase.Size = New System.Drawing.Size(132, 21)
        Me.cbo_clase.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(306, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 18)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Clase:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 236)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 18)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Cliente:"
        '
        'lbl_doc_client
        '
        Me.lbl_doc_client.AutoSize = True
        Me.lbl_doc_client.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_doc_client.Location = New System.Drawing.Point(4, 4)
        Me.lbl_doc_client.Name = "lbl_doc_client"
        Me.lbl_doc_client.Size = New System.Drawing.Size(26, 18)
        Me.lbl_doc_client.TabIndex = 16
        Me.lbl_doc_client.Text = "nit"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbl_nom_cliente)
        Me.Panel1.Controls.Add(Me.lbl_doc_client)
        Me.Panel1.Location = New System.Drawing.Point(12, 257)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(429, 29)
        Me.Panel1.TabIndex = 17
        '
        'lbl_nom_cliente
        '
        Me.lbl_nom_cliente.AutoSize = True
        Me.lbl_nom_cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nom_cliente.Location = New System.Drawing.Point(133, 4)
        Me.lbl_nom_cliente.Name = "lbl_nom_cliente"
        Me.lbl_nom_cliente.Size = New System.Drawing.Size(57, 18)
        Me.lbl_nom_cliente.TabIndex = 17
        Me.lbl_nom_cliente.Text = "cliente"
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.Location = New System.Drawing.Point(71, 228)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(64, 26)
        Me.btn_buscar.TabIndex = 18
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 301)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(192, 18)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Razon de la Devolucion:"
        '
        'txt_razon
        '
        Me.txt_razon.Location = New System.Drawing.Point(12, 322)
        Me.txt_razon.Multiline = True
        Me.txt_razon.Name = "txt_razon"
        Me.txt_razon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_razon.Size = New System.Drawing.Size(429, 107)
        Me.txt_razon.TabIndex = 20
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = Global.Spic.My.Resources.Resources.imp3
        Me.btn_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.Location = New System.Drawing.Point(338, 490)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(103, 49)
        Me.btn_imprimir.TabIndex = 21
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'rdb_bodega2
        '
        Me.rdb_bodega2.AutoSize = True
        Me.rdb_bodega2.Checked = True
        Me.rdb_bodega2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_bodega2.Location = New System.Drawing.Point(7, 507)
        Me.rdb_bodega2.Name = "rdb_bodega2"
        Me.rdb_bodega2.Size = New System.Drawing.Size(104, 24)
        Me.rdb_bodega2.TabIndex = 22
        Me.rdb_bodega2.TabStop = True
        Me.rdb_bodega2.Text = "Bodega 2"
        Me.rdb_bodega2.UseVisualStyleBackColor = True
        '
        'rdb_bodega4
        '
        Me.rdb_bodega4.AutoSize = True
        Me.rdb_bodega4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_bodega4.Location = New System.Drawing.Point(136, 507)
        Me.rdb_bodega4.Name = "rdb_bodega4"
        Me.rdb_bodega4.Size = New System.Drawing.Size(104, 24)
        Me.rdb_bodega4.TabIndex = 23
        Me.rdb_bodega4.Text = "Bodega 4"
        Me.rdb_bodega4.UseVisualStyleBackColor = True
        '
        'frm_imp_tiq_dev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(453, 542)
        Me.Controls.Add(Me.rdb_bodega4)
        Me.Controls.Add(Me.rdb_bodega2)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.txt_razon)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbo_clase)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_diametro)
        Me.Controls.Add(Me.txt_colada)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_fac_cons)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_peso)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbo_ref_pf)
        Me.Controls.Add(Me.cbo_ref)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_imp_tiq_dev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Tiquete Alambre de Devolucion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_ref As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_ref_pf As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_peso As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_fac_cons As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_colada As System.Windows.Forms.TextBox
    Friend WithEvents txt_diametro As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_clase As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_doc_client As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_nom_cliente As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_razon As System.Windows.Forms.TextBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents rdb_bodega2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_bodega4 As System.Windows.Forms.RadioButton
End Class
