<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeguimientoGrupos
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
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.dtgseguimientogrupos = New System.Windows.Forms.DataGridView()
        Me.Ppto_kilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porcen_Cumplido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vr_kilo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.imgProcesar = New System.Windows.Forms.PictureBox()
        Me.cbo_vendedor = New System.Windows.Forms.ComboBox()
        Me.lblVendedor = New System.Windows.Forms.Label()
        CType(Me.dtgseguimientogrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label37
        '
        Me.Label37.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Location = New System.Drawing.Point(187, 21)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(29, 13)
        Me.Label37.TabIndex = 48
        Me.Label37.Text = "Año:"
        '
        'cboAño
        '
        Me.cboAño.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(222, 18)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(72, 21)
        Me.cboAño.TabIndex = 46
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Location = New System.Drawing.Point(53, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 47
        Me.Label30.Text = "Mes:"
        '
        'cboMes
        '
        Me.cboMes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMes.Location = New System.Drawing.Point(89, 18)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(80, 20)
        Me.cboMes.TabIndex = 45
        '
        'btn_consultar
        '
        Me.btn_consultar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources.Consultar
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.Location = New System.Drawing.Point(328, 3)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(115, 44)
        Me.btn_consultar.TabIndex = 49
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'dtgseguimientogrupos
        '
        Me.dtgseguimientogrupos.AllowUserToAddRows = False
        Me.dtgseguimientogrupos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgseguimientogrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgseguimientogrupos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgseguimientogrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgseguimientogrupos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ppto_kilos, Me.porcen_Cumplido, Me.vr_kilo})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgseguimientogrupos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtgseguimientogrupos.Location = New System.Drawing.Point(2, 52)
        Me.dtgseguimientogrupos.Name = "dtgseguimientogrupos"
        Me.dtgseguimientogrupos.ReadOnly = True
        Me.dtgseguimientogrupos.RowHeadersVisible = False
        Me.dtgseguimientogrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgseguimientogrupos.Size = New System.Drawing.Size(803, 511)
        Me.dtgseguimientogrupos.TabIndex = 1037
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
        'imgProcesar
        '
        Me.imgProcesar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProcesar.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProcesar.Location = New System.Drawing.Point(29, 77)
        Me.imgProcesar.Name = "imgProcesar"
        Me.imgProcesar.Size = New System.Drawing.Size(720, 458)
        Me.imgProcesar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgProcesar.TabIndex = 143
        Me.imgProcesar.TabStop = False
        Me.imgProcesar.Visible = False
        '
        'cbo_vendedor
        '
        Me.cbo_vendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_vendedor.FormattingEnabled = True
        Me.cbo_vendedor.Location = New System.Drawing.Point(554, 16)
        Me.cbo_vendedor.Name = "cbo_vendedor"
        Me.cbo_vendedor.Size = New System.Drawing.Size(174, 21)
        Me.cbo_vendedor.TabIndex = 144
        '
        'lblVendedor
        '
        Me.lblVendedor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Location = New System.Drawing.Point(497, 20)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(56, 13)
        Me.lblVendedor.TabIndex = 145
        Me.lblVendedor.Text = "Vendedor:"
        '
        'FrmSeguimientoGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(779, 541)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.cbo_vendedor)
        Me.Controls.Add(Me.imgProcesar)
        Me.Controls.Add(Me.dtgseguimientogrupos)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cboMes)
        Me.Name = "FrmSeguimientoGrupos"
        Me.Text = "Formularios Seguimiento Lineas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgseguimientogrupos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgProcesar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents dtgseguimientogrupos As System.Windows.Forms.DataGridView
    Friend WithEvents imgProcesar As System.Windows.Forms.PictureBox
    Friend WithEvents cbo_vendedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents Ppto_kilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents porcen_Cumplido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vr_kilo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
