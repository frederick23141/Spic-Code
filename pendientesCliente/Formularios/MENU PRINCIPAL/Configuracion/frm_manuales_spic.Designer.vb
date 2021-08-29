<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_manuales_spic
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
        Me.tbl_manuales = New System.Windows.Forms.TabControl()
        Me.pag_produccion = New System.Windows.Forms.TabPage()
        Me.dtg_produccion = New System.Windows.Forms.DataGridView()
        Me.col_pdf = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_act = New System.Windows.Forms.Button()
        Me.tbl_manuales.SuspendLayout()
        Me.pag_produccion.SuspendLayout()
        CType(Me.dtg_produccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbl_manuales
        '
        Me.tbl_manuales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbl_manuales.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tbl_manuales.Controls.Add(Me.pag_produccion)
        Me.tbl_manuales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbl_manuales.Location = New System.Drawing.Point(-1, 46)
        Me.tbl_manuales.Multiline = True
        Me.tbl_manuales.Name = "tbl_manuales"
        Me.tbl_manuales.SelectedIndex = 0
        Me.tbl_manuales.Size = New System.Drawing.Size(707, 350)
        Me.tbl_manuales.TabIndex = 0
        '
        'pag_produccion
        '
        Me.pag_produccion.Controls.Add(Me.dtg_produccion)
        Me.pag_produccion.Location = New System.Drawing.Point(4, 32)
        Me.pag_produccion.Name = "pag_produccion"
        Me.pag_produccion.Padding = New System.Windows.Forms.Padding(3)
        Me.pag_produccion.Size = New System.Drawing.Size(699, 314)
        Me.pag_produccion.TabIndex = 0
        Me.pag_produccion.Text = "Produccion"
        Me.pag_produccion.UseVisualStyleBackColor = True
        '
        'dtg_produccion
        '
        Me.dtg_produccion.AllowUserToAddRows = False
        Me.dtg_produccion.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtg_produccion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_produccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_produccion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_produccion.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dtg_produccion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_produccion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtg_produccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_produccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_pdf})
        Me.dtg_produccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_produccion.Location = New System.Drawing.Point(3, 3)
        Me.dtg_produccion.MultiSelect = False
        Me.dtg_produccion.Name = "dtg_produccion"
        Me.dtg_produccion.ReadOnly = True
        Me.dtg_produccion.RowHeadersVisible = False
        Me.dtg_produccion.Size = New System.Drawing.Size(693, 308)
        Me.dtg_produccion.TabIndex = 0
        '
        'col_pdf
        '
        Me.col_pdf.HeaderText = ""
        Me.col_pdf.Image = Global.Spic.My.Resources.Resources.pdf
        Me.col_pdf.Name = "col_pdf"
        Me.col_pdf.ReadOnly = True
        Me.col_pdf.Width = 5
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Location = New System.Drawing.Point(6, 12)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(138, 28)
        Me.btn_nuevo.TabIndex = 1
        Me.btn_nuevo.Text = "Agregar Manual"
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_act
        '
        Me.btn_act.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_act.Image = Global.Spic.My.Resources.Resources._1448305221_Refresh
        Me.btn_act.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_act.Location = New System.Drawing.Point(150, 2)
        Me.btn_act.Name = "btn_act"
        Me.btn_act.Size = New System.Drawing.Size(122, 38)
        Me.btn_act.TabIndex = 2
        Me.btn_act.Text = "Actualizar"
        Me.btn_act.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_act.UseVisualStyleBackColor = True
        '
        'frm_manuales_spic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 397)
        Me.Controls.Add(Me.btn_act)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.tbl_manuales)
        Me.Name = "frm_manuales_spic"
        Me.Text = "frm_manuales_spic"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tbl_manuales.ResumeLayout(False)
        Me.pag_produccion.ResumeLayout(False)
        CType(Me.dtg_produccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbl_manuales As System.Windows.Forms.TabControl
    Friend WithEvents pag_produccion As System.Windows.Forms.TabPage
    Friend WithEvents dtg_produccion As System.Windows.Forms.DataGridView
    Friend WithEvents col_pdf As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_act As System.Windows.Forms.Button
End Class
