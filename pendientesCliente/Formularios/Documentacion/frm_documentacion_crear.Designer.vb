<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_documentacion_crear
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.group_info = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_doc_rep = New System.Windows.Forms.TextBox()
        Me.txt_raz_c = New System.Windows.Forms.TextBox()
        Me.txt_nom_rep_leg = New System.Windows.Forms.TextBox()
        Me.txt_nit = New System.Windows.Forms.TextBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.btn_guardar = New System.Windows.Forms.ToolStripButton()
        Me.col_guardar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dtg_doc = New System.Windows.Forms.DataGridView()
        Me.gp_fecha = New System.Windows.Forms.GroupBox()
        Me.mt_fec = New System.Windows.Forms.MonthCalendar()
        Me.group_info.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_doc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gp_fecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'group_info
        '
        Me.group_info.Controls.Add(Me.Label4)
        Me.group_info.Controls.Add(Me.Label3)
        Me.group_info.Controls.Add(Me.Label2)
        Me.group_info.Controls.Add(Me.Label1)
        Me.group_info.Controls.Add(Me.txt_doc_rep)
        Me.group_info.Controls.Add(Me.txt_raz_c)
        Me.group_info.Controls.Add(Me.txt_nom_rep_leg)
        Me.group_info.Controls.Add(Me.txt_nit)
        Me.group_info.Location = New System.Drawing.Point(11, 37)
        Me.group_info.Name = "group_info"
        Me.group_info.Size = New System.Drawing.Size(588, 104)
        Me.group_info.TabIndex = 1
        Me.group_info.TabStop = False
        Me.group_info.Text = "Informacion Basica"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(286, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nombre Representante Legal:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Documento Represantante Legal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Razon Comercial:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "NIT:"
        '
        'txt_doc_rep
        '
        Me.txt_doc_rep.Location = New System.Drawing.Point(289, 32)
        Me.txt_doc_rep.Name = "txt_doc_rep"
        Me.txt_doc_rep.Size = New System.Drawing.Size(164, 20)
        Me.txt_doc_rep.TabIndex = 4
        '
        'txt_raz_c
        '
        Me.txt_raz_c.Location = New System.Drawing.Point(9, 71)
        Me.txt_raz_c.Name = "txt_raz_c"
        Me.txt_raz_c.Size = New System.Drawing.Size(261, 20)
        Me.txt_raz_c.TabIndex = 3
        '
        'txt_nom_rep_leg
        '
        Me.txt_nom_rep_leg.Location = New System.Drawing.Point(289, 71)
        Me.txt_nom_rep_leg.Name = "txt_nom_rep_leg"
        Me.txt_nom_rep_leg.Size = New System.Drawing.Size(274, 20)
        Me.txt_nom_rep_leg.TabIndex = 2
        '
        'txt_nit
        '
        Me.txt_nit.Location = New System.Drawing.Point(9, 32)
        Me.txt_nit.Name = "txt_nit"
        Me.txt_nit.Size = New System.Drawing.Size(133, 20)
        Me.txt_nit.TabIndex = 0
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.Control
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_guardar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Toolbar1.Size = New System.Drawing.Size(610, 34)
        Me.Toolbar1.TabIndex = 1147
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'btn_guardar
        '
        Me.btn_guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_guardar.Image = Global.Spic.My.Resources.Resources._Save
        Me.btn_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(27, 31)
        Me.btn_guardar.Text = "ToolStripButton1"
        '
        'col_guardar
        '
        Me.col_guardar.HeaderText = ""
        Me.col_guardar.Image = Global.Spic.My.Resources.Resources._Save
        Me.col_guardar.Name = "col_guardar"
        Me.col_guardar.ReadOnly = True
        Me.col_guardar.Width = 5
        '
        'dtg_doc
        '
        Me.dtg_doc.AllowUserToAddRows = False
        Me.dtg_doc.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dtg_doc.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dtg_doc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_doc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_doc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_doc.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_doc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_doc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_doc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtg_doc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_doc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_guardar})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_doc.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_doc.Location = New System.Drawing.Point(12, 147)
        Me.dtg_doc.Name = "dtg_doc"
        Me.dtg_doc.ReadOnly = True
        Me.dtg_doc.RowHeadersVisible = False
        Me.dtg_doc.Size = New System.Drawing.Size(587, 240)
        Me.dtg_doc.TabIndex = 0
        '
        'gp_fecha
        '
        Me.gp_fecha.BackColor = System.Drawing.SystemColors.ControlDark
        Me.gp_fecha.Controls.Add(Me.mt_fec)
        Me.gp_fecha.Location = New System.Drawing.Point(184, 122)
        Me.gp_fecha.Name = "gp_fecha"
        Me.gp_fecha.Size = New System.Drawing.Size(275, 196)
        Me.gp_fecha.TabIndex = 9
        Me.gp_fecha.TabStop = False
        Me.gp_fecha.Text = "Fecha"
        Me.gp_fecha.Visible = False
        '
        'mt_fec
        '
        Me.mt_fec.Location = New System.Drawing.Point(12, 15)
        Me.mt_fec.Name = "mt_fec"
        Me.mt_fec.TabIndex = 0
        '
        'frm_documentacion_crear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 399)
        Me.Controls.Add(Me.gp_fecha)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.group_info)
        Me.Controls.Add(Me.dtg_doc)
        Me.MaximizeBox = False
        Me.Name = "frm_documentacion_crear"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_documentacion_crear"
        Me.group_info.ResumeLayout(False)
        Me.group_info.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_doc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gp_fecha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents group_info As System.Windows.Forms.GroupBox
    Friend WithEvents txt_nit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_doc_rep As System.Windows.Forms.TextBox
    Friend WithEvents txt_raz_c As System.Windows.Forms.TextBox
    Friend WithEvents txt_nom_rep_leg As System.Windows.Forms.TextBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents col_guardar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents dtg_doc As System.Windows.Forms.DataGridView
    Friend WithEvents gp_fecha As System.Windows.Forms.GroupBox
    Friend WithEvents mt_fec As System.Windows.Forms.MonthCalendar
End Class
