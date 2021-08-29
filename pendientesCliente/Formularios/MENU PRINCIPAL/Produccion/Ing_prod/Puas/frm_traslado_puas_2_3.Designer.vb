<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_traslado_puas_2_3
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_transaccion = New System.Windows.Forms.TabPage()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.imgTipo = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblDescipcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_ppal.SuspendLayout()
        Me.tab_transaccion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.Format = "N1"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colCant})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtgConsulta.Enabled = False
        Me.dtgConsulta.Location = New System.Drawing.Point(-1, 115)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(314, 151)
        Me.dtgConsulta.TabIndex = 1085
        '
        'colCodigo
        '
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colCant
        '
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colCant.DefaultCellStyle = DataGridViewCellStyle6
        Me.colCant.HeaderText = "Cantidad"
        Me.colCant.Name = "colCant"
        Me.colCant.ReadOnly = True
        Me.colCant.Width = 74
        '
        'tab_ppal
        '
        Me.tab_ppal.Controls.Add(Me.tab_transaccion)
        Me.tab_ppal.Location = New System.Drawing.Point(1, 1)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(314, 297)
        Me.tab_ppal.TabIndex = 1100
        '
        'tab_transaccion
        '
        Me.tab_transaccion.Controls.Add(Me.btn_salir)
        Me.tab_transaccion.Controls.Add(Me.txtKilos)
        Me.tab_transaccion.Controls.Add(Me.Label1)
        Me.tab_transaccion.Controls.Add(Me.dtgConsulta)
        Me.tab_transaccion.Controls.Add(Me.GroupBox1)
        Me.tab_transaccion.Controls.Add(Me.lblDescipcion)
        Me.tab_transaccion.Controls.Add(Me.lblCodigo)
        Me.tab_transaccion.Controls.Add(Me.GroupBox2)
        Me.tab_transaccion.Location = New System.Drawing.Point(4, 22)
        Me.tab_transaccion.Name = "tab_transaccion"
        Me.tab_transaccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_transaccion.Size = New System.Drawing.Size(306, 271)
        Me.tab_transaccion.TabIndex = 0
        Me.tab_transaccion.Text = "TRANSACCIÓN"
        Me.tab_transaccion.UseVisualStyleBackColor = True
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(182, 26)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(58, 20)
        Me.txtKilos.TabIndex = 1087
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1086
        Me.Label1.Text = "Cantidad Rollos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.imgTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTipo)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 46)
        Me.GroupBox1.TabIndex = 1072
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la transacción"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(184, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Transacción"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.UseVisualStyleBackColor = True
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
        Me.Label4.Location = New System.Drawing.Point(-1, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 1061
        Me.Label4.Text = "Tipo:"
        '
        'cboTipo
        '
        Me.cboTipo.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "7"})
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {""})
        Me.cboTipo.Location = New System.Drawing.Point(35, 13)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(112, 28)
        Me.cboTipo.TabIndex = 1062
        Me.cboTipo.Text = "Seleccione"
        '
        'lblDescipcion
        '
        Me.lblDescipcion.AutoSize = True
        Me.lblDescipcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescipcion.Location = New System.Drawing.Point(125, 51)
        Me.lblDescipcion.Name = "lblDescipcion"
        Me.lblDescipcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescipcion.TabIndex = 1079
        Me.lblDescipcion.Text = "lblDescipcion"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(0, 49)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(75, 16)
        Me.lblCodigo.TabIndex = 1078
        Me.lblCodigo.Text = "lblCodigo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoLector)
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 45)
        Me.GroupBox2.TabIndex = 1074
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lector Hand-Held"
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLector.Location = New System.Drawing.Point(5, 14)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(169, 24)
        Me.txtCodigoLector.TabIndex = 1074
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388831_door_in
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.Location = New System.Drawing.Point(248, 21)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(53, 27)
        Me.btn_salir.TabIndex = 1088
        Me.btn_salir.Text = "Salir "
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'frm_traslado_puas_2_3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 298)
        Me.Controls.Add(Me.tab_ppal)
        Me.Name = "frm_traslado_puas_2_3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Traslado de puas 2 a 3"
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_transaccion.ResumeLayout(False)
        Me.tab_transaccion.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgConsulta As DataGridView
    Friend WithEvents tab_ppal As TabControl
    Friend WithEvents tab_transaccion As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents imgTipo As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTipo As ComboBox
    Friend WithEvents lblDescipcion As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtCodigoLector As TextBox
    Friend WithEvents txtKilos As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents colCodigo As DataGridViewTextBoxColumn
    Friend WithEvents colCant As DataGridViewTextBoxColumn
    Friend WithEvents btn_salir As Button
End Class
