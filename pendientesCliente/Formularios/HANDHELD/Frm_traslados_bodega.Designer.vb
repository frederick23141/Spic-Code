<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_traslados_bodega
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_traslados_bodega))
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.colAnular = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colAnulado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colKilos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_stock_insuf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.imgCod = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDescKilos = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.Label()
        Me.txtMensKilos = New System.Windows.Forms.Label()
        Me.imgKilos = New System.Windows.Forms.PictureBox()
        Me.imgTipo = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.imgCed = New System.Windows.Forms.PictureBox()
        Me.imgCarga = New System.Windows.Forms.PictureBox()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgKilos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(233, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 23)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAnular, Me.colAnulado, Me.colSeq, Me.colNumero, Me.colTipo, Me.colKilos, Me.colBod, Me.colCodigo, Me.colDesc, Me.col_stock_insuf})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgConsulta.Location = New System.Drawing.Point(0, 111)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(319, 185)
        Me.dtgConsulta.TabIndex = 3
        '
        'colAnular
        '
        Me.colAnular.Frozen = True
        Me.colAnular.HeaderText = ""
        Me.colAnular.Image = Global.Spic.My.Resources.Resources._1371749741_32447
        Me.colAnular.Name = "colAnular"
        Me.colAnular.ReadOnly = True
        Me.colAnular.Width = 5
        '
        'colAnulado
        '
        Me.colAnulado.HeaderText = "anulado"
        Me.colAnulado.Name = "colAnulado"
        Me.colAnulado.ReadOnly = True
        Me.colAnulado.Visible = False
        Me.colAnulado.Width = 51
        '
        'colSeq
        '
        Me.colSeq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colSeq.HeaderText = "Seq"
        Me.colSeq.Name = "colSeq"
        Me.colSeq.ReadOnly = True
        Me.colSeq.Width = 40
        '
        'colNumero
        '
        Me.colNumero.HeaderText = "Número"
        Me.colNumero.Name = "colNumero"
        Me.colNumero.ReadOnly = True
        Me.colNumero.Width = 69
        '
        'colTipo
        '
        Me.colTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 40
        '
        'colKilos
        '
        Me.colKilos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colKilos.DefaultCellStyle = DataGridViewCellStyle2
        Me.colKilos.HeaderText = "Kilos"
        Me.colKilos.Name = "colKilos"
        Me.colKilos.ReadOnly = True
        Me.colKilos.Width = 45
        '
        'colBod
        '
        Me.colBod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colBod.HeaderText = "Bod"
        Me.colBod.Name = "colBod"
        Me.colBod.ReadOnly = True
        Me.colBod.Width = 35
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colDesc
        '
        Me.colDesc.HeaderText = "Descripción"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 88
        '
        'col_stock_insuf
        '
        Me.col_stock_insuf.HeaderText = "col_stock_insuf"
        Me.col_stock_insuf.Name = "col_stock_insuf"
        Me.col_stock_insuf.ReadOnly = True
        Me.col_stock_insuf.Visible = False
        Me.col_stock_insuf.Width = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(48, 42)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(99, 22)
        Me.txtCodigo.TabIndex = 4
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(166, 45)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.Size = New System.Drawing.Size(149, 18)
        Me.txtDesc.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1064
        Me.Label1.Text = "Kilos:"
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(48, 66)
        Me.txtKilos.MaxLength = 4
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(77, 20)
        Me.txtKilos.TabIndex = 1063
        '
        'imgCod
        '
        Me.imgCod.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCod.Location = New System.Drawing.Point(148, 45)
        Me.imgCod.Name = "imgCod"
        Me.imgCod.Size = New System.Drawing.Size(15, 17)
        Me.imgCod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCod.TabIndex = 1066
        Me.imgCod.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 1069
        Me.Label5.Text = "Cedula:"
        '
        'txtCedula
        '
        Me.txtCedula.ForeColor = System.Drawing.Color.Black
        Me.txtCedula.Location = New System.Drawing.Point(77, 0)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(109, 20)
        Me.txtCedula.TabIndex = 1068
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtDescKilos)
        Me.GroupBox1.Controls.Add(Me.txtStock)
        Me.GroupBox1.Controls.Add(Me.txtMensKilos)
        Me.GroupBox1.Controls.Add(Me.imgKilos)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDesc)
        Me.GroupBox1.Controls.Add(Me.imgTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.imgCod)
        Me.GroupBox1.Controls.Add(Me.cboTipo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtKilos)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 89)
        Me.GroupBox1.TabIndex = 1072
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la transacción"
        '
        'txtDescKilos
        '
        Me.txtDescKilos.AutoSize = True
        Me.txtDescKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescKilos.ForeColor = System.Drawing.Color.Black
        Me.txtDescKilos.Location = New System.Drawing.Point(125, 68)
        Me.txtDescKilos.Name = "txtDescKilos"
        Me.txtDescKilos.Size = New System.Drawing.Size(47, 15)
        Me.txtDescKilos.TabIndex = 1072
        Me.txtDescKilos.Text = "dKilos"
        '
        'txtStock
        '
        Me.txtStock.AutoSize = True
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.ForeColor = System.Drawing.Color.Black
        Me.txtStock.Location = New System.Drawing.Point(264, 68)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(37, 15)
        Me.txtStock.TabIndex = 1071
        Me.txtStock.Text = "Stock"
        Me.txtStock.Visible = False
        '
        'txtMensKilos
        '
        Me.txtMensKilos.AutoSize = True
        Me.txtMensKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensKilos.ForeColor = System.Drawing.Color.Red
        Me.txtMensKilos.Location = New System.Drawing.Point(188, 70)
        Me.txtMensKilos.Name = "txtMensKilos"
        Me.txtMensKilos.Size = New System.Drawing.Size(70, 13)
        Me.txtMensKilos.TabIndex = 1069
        Me.txtMensKilos.Text = "mensaje kilos"
        '
        'imgKilos
        '
        Me.imgKilos.Image = Global.Spic.My.Resources.Resources.estable
        Me.imgKilos.Location = New System.Drawing.Point(173, 67)
        Me.imgKilos.Name = "imgKilos"
        Me.imgKilos.Size = New System.Drawing.Size(15, 17)
        Me.imgKilos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgKilos.TabIndex = 1068
        Me.imgKilos.TabStop = False
        '
        'imgTipo
        '
        Me.imgTipo.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgTipo.Location = New System.Drawing.Point(160, 18)
        Me.imgTipo.Name = "imgTipo"
        Me.imgTipo.Size = New System.Drawing.Size(15, 17)
        Me.imgTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgTipo.TabIndex = 1067
        Me.imgTipo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 1061
        Me.Label4.Text = "Tipo:"
        '
        'cboTipo
        '
        Me.cboTipo.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "7"})
        Me.cboTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {""})
        Me.cboTipo.Location = New System.Drawing.Point(48, 13)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(111, 27)
        Me.cboTipo.TabIndex = 1062
        Me.cboTipo.Text = "Seleccione"
        '
        'imgCed
        '
        Me.imgCed.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCed.Location = New System.Drawing.Point(192, 1)
        Me.imgCed.Name = "imgCed"
        Me.imgCed.Size = New System.Drawing.Size(15, 17)
        Me.imgCed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCed.TabIndex = 1068
        Me.imgCed.TabStop = False
        '
        'imgCarga
        '
        Me.imgCarga.Image = Global.Spic.My.Resources.Resources.cargandoGif
        Me.imgCarga.Location = New System.Drawing.Point(66, 140)
        Me.imgCarga.Name = "imgCarga"
        Me.imgCarga.Size = New System.Drawing.Size(192, 129)
        Me.imgCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCarga.TabIndex = 1072
        Me.imgCarga.TabStop = False
        Me.imgCarga.Visible = False
        '
        'Frm_traslados_bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.imgCarga)
        Me.Controls.Add(Me.imgCed)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCedula)
        Me.Controls.Add(Me.dtgConsulta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_traslados_bodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Traslados de bodega"
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgKilos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents imgCod As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents imgCed As System.Windows.Forms.PictureBox
    Friend WithEvents txtMensKilos As System.Windows.Forms.Label
    Friend WithEvents imgKilos As System.Windows.Forms.PictureBox
    Friend WithEvents txtStock As System.Windows.Forms.Label
    Friend WithEvents imgTipo As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents imgCarga As System.Windows.Forms.PictureBox
    Friend WithEvents txtDescKilos As System.Windows.Forms.Label
    Friend WithEvents colAnular As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colAnulado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_stock_insuf As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
