<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_compromiso
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
        Me.txt_fec = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtCompromiso = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_ped = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.TipotransaccionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CORSANDataSet = New Spic.CORSANDataSet()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.Tipo_transaccionesTableAdapter = New Spic.CORSANDataSetTableAdapters.tipo_transaccionesTableAdapter()
        Me.txt_resp = New System.Windows.Forms.TextBox()
        Me.txt_fact = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_cumplio = New System.Windows.Forms.ComboBox()
        Me.txt_cons = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TipotransaccionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CORSANDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_fec
        '
        Me.txt_fec.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txt_fec.Location = New System.Drawing.Point(17, 53)
        Me.txt_fec.MinDate = New Date(2012, 11, 23, 0, 0, 0, 0)
        Me.txt_fec.Name = "txt_fec"
        Me.txt_fec.Size = New System.Drawing.Size(96, 20)
        Me.txt_fec.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtCompromiso)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(15, 126)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(653, 120)
        Me.GroupBox4.TabIndex = 105
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Compromiso"
        '
        'txtCompromiso
        '
        Me.txtCompromiso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCompromiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompromiso.Location = New System.Drawing.Point(7, 15)
        Me.txtCompromiso.MaxLength = 250
        Me.txtCompromiso.Multiline = True
        Me.txtCompromiso.Name = "txtCompromiso"
        Me.txtCompromiso.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCompromiso.Size = New System.Drawing.Size(640, 99)
        Me.txtCompromiso.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(461, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Responsable:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "# Pedido:"
        '
        'txt_ped
        '
        Me.txt_ped.Location = New System.Drawing.Point(17, 96)
        Me.txt_ped.MaxLength = 32
        Me.txt_ped.Name = "txt_ped"
        Me.txt_ped.Size = New System.Drawing.Size(126, 20)
        Me.txt_ped.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(116, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Nit:"
        '
        'txt_nit
        '
        Me.txt_nit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nit.Enabled = False
        Me.txt_nit.Location = New System.Drawing.Point(119, 53)
        Me.txt_nit.MaxLength = 32
        Me.txt_nit.Name = "txt_nit"
        Me.txt_nit.Size = New System.Drawing.Size(339, 20)
        Me.txt_nit.TabIndex = 10
        '
        'TipotransaccionesBindingSource
        '
        Me.TipotransaccionesBindingSource.DataMember = "tipo_transacciones"
        Me.TipotransaccionesBindingSource.DataSource = Me.CORSANDataSet
        '
        'CORSANDataSet

        '
        'btn_guardar
        '
        Me.btn_guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.Location = New System.Drawing.Point(113, 252)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(154, 68)
        Me.btn_guardar.TabIndex = 50
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.Location = New System.Drawing.Point(273, 252)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(157, 68)
        Me.btnConsultar.TabIndex = 51
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.btn_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_nuevo.Location = New System.Drawing.Point(444, 252)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(139, 68)
        Me.btn_nuevo.TabIndex = 53
        Me.btn_nuevo.Text = "  Nuevo"
        Me.btn_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'Tipo_transaccionesTableAdapter

        'txt_resp
        '
        Me.txt_resp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_resp.Location = New System.Drawing.Point(203, 53)
        Me.txt_resp.MaxLength = 32
        Me.txt_resp.Name = "txt_resp"
        Me.txt_resp.Size = New System.Drawing.Size(463, 20)
        Me.txt_resp.TabIndex = 121
        '
        'txt_fact
        '
        Me.txt_fact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_fact.Location = New System.Drawing.Point(149, 96)
        Me.txt_fact.MaxLength = 32
        Me.txt_fact.Name = "txt_fact"
        Me.txt_fact.Size = New System.Drawing.Size(456, 20)
        Me.txt_fact.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(146, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Factura:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(608, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "Cumplio"
        '
        'cbo_cumplio
        '
        Me.cbo_cumplio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbo_cumplio.FormattingEnabled = True
        Me.cbo_cumplio.Items.AddRange(New Object() {"SI", "NO"})
        Me.cbo_cumplio.Location = New System.Drawing.Point(611, 96)
        Me.cbo_cumplio.Name = "cbo_cumplio"
        Me.cbo_cumplio.Size = New System.Drawing.Size(55, 21)
        Me.cbo_cumplio.TabIndex = 123
        '
        'txt_cons
        '
        Me.txt_cons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_cons.Enabled = False
        Me.txt_cons.Location = New System.Drawing.Point(97, 9)
        Me.txt_cons.MaxLength = 32
        Me.txt_cons.Name = "txt_cons"
        Me.txt_cons.Size = New System.Drawing.Size(339, 20)
        Me.txt_cons.TabIndex = 125
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Consecutivo:"
        '
        'Frm_compromiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 336)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_cons)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbo_cumplio)
        Me.Controls.Add(Me.txt_resp)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_nit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_fact)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_ped)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_fec)
        Me.Name = "Frm_compromiso"
        Me.Text = "Compromiso"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TipotransaccionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CORSANDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_fec As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompromiso As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_ped As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_nit As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents CORSANDataSet As Spic.CORSANDataSet
    Friend WithEvents TipotransaccionesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tipo_transaccionesTableAdapter As Spic.CORSANDataSetTableAdapters.tipo_transaccionesTableAdapter
    Friend WithEvents txt_resp As System.Windows.Forms.TextBox
    Friend WithEvents txt_fact As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_cumplio As System.Windows.Forms.ComboBox
    Friend WithEvents txt_cons As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
