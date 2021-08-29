<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Galvanizado
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Galvanizado))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.dtgItems = New System.Windows.Forms.DataGridView()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_ped = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_proceso = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_bodega = New System.Windows.Forms.TextBox()
        Me.btn_comenzar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.imgCed = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_codigo = New System.Windows.Forms.TextBox()
        Me.tab_transaccion = New System.Windows.Forms.TabPage()
        Me.btn_terminar = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_ppal.SuspendLayout()
        Me.tab_ped.SuspendLayout()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_transaccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoLector)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 45)
        Me.GroupBox2.TabIndex = 1074
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lector Hand-Held"
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLector.Location = New System.Drawing.Point(5, 14)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(292, 24)
        Me.txtCodigoLector.TabIndex = 1074
        '
        'dtgItems
        '
        Me.dtgItems.AllowUserToAddRows = False
        Me.dtgItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgItems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgItems.Location = New System.Drawing.Point(-1, 54)
        Me.dtgItems.Name = "dtgItems"
        Me.dtgItems.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgItems.RowHeadersVisible = False
        Me.dtgItems.Size = New System.Drawing.Size(308, 152)
        Me.dtgItems.TabIndex = 1080
        '
        'tab_ppal
        '
        Me.tab_ppal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_ppal.Controls.Add(Me.tab_ped)
        Me.tab_ppal.Controls.Add(Me.tab_transaccion)
        Me.tab_ppal.Location = New System.Drawing.Point(1, 0)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(316, 264)
        Me.tab_ppal.TabIndex = 1085
        '
        'tab_ped
        '
        Me.tab_ped.Controls.Add(Me.Label3)
        Me.tab_ped.Controls.Add(Me.cbo_proceso)
        Me.tab_ped.Controls.Add(Me.Label2)
        Me.tab_ped.Controls.Add(Me.txt_bodega)
        Me.tab_ped.Controls.Add(Me.btn_comenzar)
        Me.tab_ped.Controls.Add(Me.Label1)
        Me.tab_ped.Controls.Add(Me.imgCed)
        Me.tab_ped.Controls.Add(Me.Label5)
        Me.tab_ped.Controls.Add(Me.txt_codigo)
        Me.tab_ped.Location = New System.Drawing.Point(4, 22)
        Me.tab_ped.Name = "tab_ped"
        Me.tab_ped.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_ped.Size = New System.Drawing.Size(308, 238)
        Me.tab_ped.TabIndex = 1
        Me.tab_ped.Text = "PEDIDO"
        Me.tab_ped.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 20)
        Me.Label3.TabIndex = 1096
        Me.Label3.Text = "Proceso:"
        '
        'cbo_proceso
        '
        Me.cbo_proceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_proceso.FormattingEnabled = True
        Me.cbo_proceso.Location = New System.Drawing.Point(91, 23)
        Me.cbo_proceso.Name = "cbo_proceso"
        Me.cbo_proceso.Size = New System.Drawing.Size(183, 21)
        Me.cbo_proceso.TabIndex = 1095
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 1092
        Me.Label2.Text = "Bodega:"
        '
        'txt_bodega
        '
        Me.txt_bodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_bodega.ForeColor = System.Drawing.Color.Black
        Me.txt_bodega.Location = New System.Drawing.Point(91, 123)
        Me.txt_bodega.Name = "txt_bodega"
        Me.txt_bodega.Size = New System.Drawing.Size(183, 22)
        Me.txt_bodega.TabIndex = 1091
        '
        'btn_comenzar
        '
        Me.btn_comenzar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_comenzar.Image = Global.Spic.My.Resources.Resources.mas
        Me.btn_comenzar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_comenzar.Location = New System.Drawing.Point(68, 195)
        Me.btn_comenzar.Name = "btn_comenzar"
        Me.btn_comenzar.Size = New System.Drawing.Size(183, 38)
        Me.btn_comenzar.TabIndex = 1090
        Me.btn_comenzar.Text = "Comenzar inventario"
        Me.btn_comenzar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_comenzar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 13)
        Me.Label1.TabIndex = 1089
        Me.Label1.Text = "Ejemplo: 3CC,33B,33R,33P,22X,11" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'imgCed
        '
        Me.imgCed.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCed.Location = New System.Drawing.Point(277, 83)
        Me.imgCed.Name = "imgCed"
        Me.imgCed.Size = New System.Drawing.Size(23, 22)
        Me.imgCed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCed.TabIndex = 1086
        Me.imgCed.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 1088
        Me.Label5.Text = "Código's:"
        '
        'txt_codigo
        '
        Me.txt_codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codigo.ForeColor = System.Drawing.Color.Black
        Me.txt_codigo.Location = New System.Drawing.Point(91, 82)
        Me.txt_codigo.Name = "txt_codigo"
        Me.txt_codigo.Size = New System.Drawing.Size(183, 22)
        Me.txt_codigo.TabIndex = 1087
        '
        'tab_transaccion
        '
        Me.tab_transaccion.Controls.Add(Me.btn_terminar)
        Me.tab_transaccion.Controls.Add(Me.dtgItems)
        Me.tab_transaccion.Controls.Add(Me.GroupBox2)
        Me.tab_transaccion.Location = New System.Drawing.Point(4, 22)
        Me.tab_transaccion.Name = "tab_transaccion"
        Me.tab_transaccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_transaccion.Size = New System.Drawing.Size(308, 238)
        Me.tab_transaccion.TabIndex = 0
        Me.tab_transaccion.Text = "TRANSACCIÓN"
        Me.tab_transaccion.UseVisualStyleBackColor = True
        '
        'btn_terminar
        '
        Me.btn_terminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_terminar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_terminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_terminar.Location = New System.Drawing.Point(1, 209)
        Me.btn_terminar.Name = "btn_terminar"
        Me.btn_terminar.Size = New System.Drawing.Size(300, 27)
        Me.btn_terminar.TabIndex = 1085
        Me.btn_terminar.Text = "Terminar"
        Me.btn_terminar.UseVisualStyleBackColor = True
        '
        'Galvanizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 262)
        Me.Controls.Add(Me.tab_ppal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Galvanizado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cargue terminado"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_ped.ResumeLayout(False)
        Me.tab_ped.PerformLayout()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_transaccion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
    Friend WithEvents dtgItems As System.Windows.Forms.DataGridView
    Friend WithEvents tab_ppal As System.Windows.Forms.TabControl
    Friend WithEvents tab_ped As System.Windows.Forms.TabPage
    Friend WithEvents tab_transaccion As System.Windows.Forms.TabPage
    Friend WithEvents imgCed As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_codigo As System.Windows.Forms.TextBox
    Friend WithEvents btn_terminar As System.Windows.Forms.Button
    Friend WithEvents btn_comenzar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_bodega As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_proceso As System.Windows.Forms.ComboBox
End Class
