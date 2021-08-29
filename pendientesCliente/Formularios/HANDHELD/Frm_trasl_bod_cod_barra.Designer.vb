<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_trasl_bod_cod_barra
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_trasl_bod_cod_barra))
        Me.btnRealiTran = New System.Windows.Forms.Button()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.colBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colNumeroRollo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProblemasStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBodega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVrUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCostoUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRollos = New System.Windows.Forms.Label()
        Me.txtDescKilos = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.imgTipo = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.imgCed = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRealiTran
        '
        Me.btnRealiTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRealiTran.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btnRealiTran.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRealiTran.Location = New System.Drawing.Point(165, 36)
        Me.btnRealiTran.Name = "btnRealiTran"
        Me.btnRealiTran.Size = New System.Drawing.Size(149, 23)
        Me.btnRealiTran.TabIndex = 0
        Me.btnRealiTran.Text = "Realizar transacción"
        Me.btnRealiTran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRealiTran.UseVisualStyleBackColor = True
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
        Me.dtgConsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBorrar, Me.colNumeroRollo, Me.colPeso, Me.colStock, Me.colCodigo, Me.colDesc, Me.colProblemasStock, Me.colBodega, Me.colVrUnitario, Me.colCostoUnitario})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgConsulta.Location = New System.Drawing.Point(0, 143)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(323, 138)
        Me.dtgConsulta.TabIndex = 3
        '
        'colBorrar
        '
        Me.colBorrar.Frozen = True
        Me.colBorrar.HeaderText = ""
        Me.colBorrar.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.colBorrar.Name = "colBorrar"
        Me.colBorrar.ReadOnly = True
        Me.colBorrar.Width = 5
        '
        'colNumeroRollo
        '
        Me.colNumeroRollo.Frozen = True
        Me.colNumeroRollo.HeaderText = "#"
        Me.colNumeroRollo.Name = "colNumeroRollo"
        Me.colNumeroRollo.ReadOnly = True
        Me.colNumeroRollo.Width = 39
        '
        'colPeso
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colPeso.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPeso.Frozen = True
        Me.colPeso.HeaderText = "Peso"
        Me.colPeso.Name = "colPeso"
        Me.colPeso.ReadOnly = True
        Me.colPeso.Width = 56
        '
        'colStock
        '
        Me.colStock.Frozen = True
        Me.colStock.HeaderText = "Stock"
        Me.colStock.Name = "colStock"
        Me.colStock.ReadOnly = True
        Me.colStock.Width = 60
        '
        'colCodigo
        '
        Me.colCodigo.Frozen = True
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colDesc
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colDesc.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDesc.Frozen = True
        Me.colDesc.HeaderText = "Descripción"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 88
        '
        'colProblemasStock
        '
        Me.colProblemasStock.Frozen = True
        Me.colProblemasStock.HeaderText = "problemasStock"
        Me.colProblemasStock.Name = "colProblemasStock"
        Me.colProblemasStock.ReadOnly = True
        Me.colProblemasStock.Visible = False
        Me.colProblemasStock.Width = 108
        '
        'colBodega
        '
        Me.colBodega.Frozen = True
        Me.colBodega.HeaderText = "Bodega"
        Me.colBodega.Name = "colBodega"
        Me.colBodega.ReadOnly = True
        Me.colBodega.Visible = False
        Me.colBodega.Width = 69
        '
        'colVrUnitario
        '
        Me.colVrUnitario.Frozen = True
        Me.colVrUnitario.HeaderText = "Vr_unitario"
        Me.colVrUnitario.Name = "colVrUnitario"
        Me.colVrUnitario.ReadOnly = True
        Me.colVrUnitario.Visible = False
        Me.colVrUnitario.Width = 82
        '
        'colCostoUnitario
        '
        Me.colCostoUnitario.Frozen = True
        Me.colCostoUnitario.HeaderText = "costo_unitario"
        Me.colCostoUnitario.Name = "colCostoUnitario"
        Me.colCostoUnitario.ReadOnly = True
        Me.colCostoUnitario.Visible = False
        Me.colCostoUnitario.Width = 98
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 1069
        Me.Label5.Text = "Cedula:"
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(77, 2)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(109, 20)
        Me.txtCedula.TabIndex = 1068
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRollos)
        Me.GroupBox1.Controls.Add(Me.txtDescKilos)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnRealiTran)
        Me.GroupBox1.Controls.Add(Me.imgTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTipo)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 66)
        Me.GroupBox1.TabIndex = 1072
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la transacción"
        '
        'txtRollos
        '
        Me.txtRollos.AutoSize = True
        Me.txtRollos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRollos.ForeColor = System.Drawing.Color.Black
        Me.txtRollos.Location = New System.Drawing.Point(261, 17)
        Me.txtRollos.Name = "txtRollos"
        Me.txtRollos.Size = New System.Drawing.Size(44, 15)
        Me.txtRollos.TabIndex = 1077
        Me.txtRollos.Text = "desc_r"
        '
        'txtDescKilos
        '
        Me.txtDescKilos.AutoSize = True
        Me.txtDescKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescKilos.ForeColor = System.Drawing.Color.Black
        Me.txtDescKilos.Location = New System.Drawing.Point(172, 17)
        Me.txtDescKilos.Name = "txtDescKilos"
        Me.txtDescKilos.Size = New System.Drawing.Size(46, 15)
        Me.txtDescKilos.TabIndex = 1072
        Me.txtDescKilos.Text = "desc_k"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(220, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 1075
        Me.Label8.Text = "Rollos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(138, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 1074
        Me.Label6.Text = "Kilos:"
        '
        'imgTipo
        '
        Me.imgTipo.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgTipo.Location = New System.Drawing.Point(118, 17)
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
        Me.Label4.Location = New System.Drawing.Point(1, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 1061
        Me.Label4.Text = "Tipo:"
        '
        'cboTipo
        '
        Me.cboTipo.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "7"})
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {""})
        Me.cboTipo.Location = New System.Drawing.Point(37, 15)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(78, 21)
        Me.cboTipo.TabIndex = 1062
        Me.cboTipo.Text = "Seleccione"
        '
        'imgCed
        '
        Me.imgCed.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCed.Location = New System.Drawing.Point(192, 3)
        Me.imgCed.Name = "imgCed"
        Me.imgCed.Size = New System.Drawing.Size(15, 17)
        Me.imgCed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCed.TabIndex = 1068
        Me.imgCed.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoLector)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 50)
        Me.GroupBox2.TabIndex = 1073
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lector Hand-Held"
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Location = New System.Drawing.Point(6, 19)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(308, 20)
        Me.txtCodigoLector.TabIndex = 1074
        '
        'Frm_trasl_bod_cod_barra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 281)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.imgCed)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCedula)
        Me.Controls.Add(Me.dtgConsulta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_trasl_bod_cod_barra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Traslados de bodega"
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRealiTran As System.Windows.Forms.Button
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents imgCed As System.Windows.Forms.PictureBox
    Friend WithEvents imgTipo As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtDescKilos As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
    Friend WithEvents txtRollos As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents colBorrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colNumeroRollo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPeso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProblemasStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVrUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
