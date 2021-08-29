<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cartera_por_vencer
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
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cboAño = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.dtg_cartera_por_v = New System.Windows.Forms.DataGridView()
        Me.Ppto_kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porcen_Cumplido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_kilo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.cbo_vendedor = New System.Windows.Forms.ComboBox()
        Me.btnexcel = New System.Windows.Forms.Button()
        Me.ch_unoatrien = New System.Windows.Forms.CheckBox()
        Me.chk_61 = New System.Windows.Forms.CheckBox()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_cartera_por_v, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label37
        '
        Me.Label37.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Location = New System.Drawing.Point(303, 17)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(29, 13)
        Me.Label37.TabIndex = 52
        Me.Label37.Text = "Año:"
        '
        'cboAño
        '
        Me.cboAño.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(338, 14)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(72, 21)
        Me.cboAño.TabIndex = 50
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(169, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Mes:"
        '
        'cboMes
        '
        Me.cboMes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMes.Location = New System.Drawing.Point(205, 14)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(80, 20)
        Me.cboMes.TabIndex = 49
        '
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(60, 70)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(812, 348)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 1038
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'dtg_cartera_por_v
        '
        Me.dtg_cartera_por_v.AllowUserToAddRows = False
        Me.dtg_cartera_por_v.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_cartera_por_v.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtg_cartera_por_v.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_cartera_por_v.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_cartera_por_v.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ppto_kilos, Me.porcen_Cumplido, Me.vr_kilo})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_cartera_por_v.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_cartera_por_v.Location = New System.Drawing.Point(34, 51)
        Me.dtg_cartera_por_v.Name = "dtg_cartera_por_v"
        Me.dtg_cartera_por_v.ReadOnly = True
        Me.dtg_cartera_por_v.RowHeadersVisible = False
        Me.dtg_cartera_por_v.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_cartera_por_v.Size = New System.Drawing.Size(895, 387)
        Me.dtg_cartera_por_v.TabIndex = 1039
        '
        'Ppto_kilos
        '
        Me.Ppto_kilos.HeaderText = "Ppto_kilos"
        Me.Ppto_kilos.Name = "Ppto_kilos"
        Me.Ppto_kilos.ReadOnly = True
        Me.Ppto_kilos.Visible = False
        '
        'porcen_Cumplido
        '
        Me.porcen_Cumplido.HeaderText = "Porcen_Cumplido"
        Me.porcen_Cumplido.Name = "porcen_Cumplido"
        Me.porcen_Cumplido.ReadOnly = True
        Me.porcen_Cumplido.Visible = False
        '
        'vr_kilo
        '
        Me.vr_kilo.HeaderText = "Vr_kilo"
        Me.vr_kilo.Name = "vr_kilo"
        Me.vr_kilo.ReadOnly = True
        Me.vr_kilo.Visible = False
        '
        'btn_consultar
        '
        Me.btn_consultar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources.Consultar
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.Location = New System.Drawing.Point(431, 1)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(115, 44)
        Me.btn_consultar.TabIndex = 1040
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'lblVendedor
        '
        Me.lblVendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Location = New System.Drawing.Point(564, 18)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(56, 13)
        Me.lblVendedor.TabIndex = 1044
        Me.lblVendedor.Text = "Vendedor:"
        '
        'cbo_vendedor
        '
        Me.cbo_vendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_vendedor.FormattingEnabled = True
        Me.cbo_vendedor.Location = New System.Drawing.Point(621, 14)
        Me.cbo_vendedor.Name = "cbo_vendedor"
        Me.cbo_vendedor.Size = New System.Drawing.Size(174, 21)
        Me.cbo_vendedor.TabIndex = 1043
        '
        'btnexcel
        '
        Me.btnexcel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnexcel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btnexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexcel.Location = New System.Drawing.Point(49, 14)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(114, 23)
        Me.btnexcel.TabIndex = 1170
        Me.btnexcel.Text = "Exportar"
        Me.btnexcel.UseVisualStyleBackColor = True
        '
        'ch_unoatrien
        '
        Me.ch_unoatrien.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ch_unoatrien.AutoSize = True
        Me.ch_unoatrien.Location = New System.Drawing.Point(807, 16)
        Me.ch_unoatrien.Name = "ch_unoatrien"
        Me.ch_unoatrien.Size = New System.Drawing.Size(56, 17)
        Me.ch_unoatrien.TabIndex = 1171
        Me.ch_unoatrien.Text = "1 a 30"
        Me.ch_unoatrien.UseVisualStyleBackColor = True
        '
        'chk_61
        '
        Me.chk_61.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_61.AutoSize = True
        Me.chk_61.Location = New System.Drawing.Point(869, 16)
        Me.chk_61.Name = "chk_61"
        Me.chk_61.Size = New System.Drawing.Size(79, 17)
        Me.chk_61.TabIndex = 1172
        Me.chk_61.Text = "Mayor a 30"
        Me.chk_61.UseVisualStyleBackColor = True
        '
        'frm_cartera_por_vencer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 442)
        Me.Controls.Add(Me.chk_61)
        Me.Controls.Add(Me.ch_unoatrien)
        Me.Controls.Add(Me.btnexcel)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.cbo_vendedor)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.dtg_cartera_por_v)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cboMes)
        Me.Name = "frm_cartera_por_vencer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cartera por vencer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_cartera_por_v, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents dtg_cartera_por_v As System.Windows.Forms.DataGridView
    Friend WithEvents Ppto_kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porcen_Cumplido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_kilo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents cbo_vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents btnexcel As System.Windows.Forms.Button
    Friend WithEvents ch_unoatrien As System.Windows.Forms.CheckBox
    Friend WithEvents chk_61 As System.Windows.Forms.CheckBox
End Class
