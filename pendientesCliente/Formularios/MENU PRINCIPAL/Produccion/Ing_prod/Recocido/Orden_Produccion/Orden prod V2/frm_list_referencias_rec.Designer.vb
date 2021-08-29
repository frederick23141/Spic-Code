<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_list_referencias_rec
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
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.col_ocultar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.menu_cantidad = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarCantidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.btn_consultar = New System.Windows.Forms.Button()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu_cantidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_consulta
        '
        Me.dtg_consulta.AllowUserToAddRows = False
        Me.dtg_consulta.AllowUserToDeleteRows = False
        Me.dtg_consulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_consulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_consulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_consulta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ocultar})
        Me.dtg_consulta.ContextMenuStrip = Me.menu_cantidad
        Me.dtg_consulta.Location = New System.Drawing.Point(12, 51)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(815, 259)
        Me.dtg_consulta.TabIndex = 0
        '
        'col_ocultar
        '
        Me.col_ocultar.HeaderText = "Ocultar"
        Me.col_ocultar.Image = Global.Spic.My.Resources.Resources.x
        Me.col_ocultar.Name = "col_ocultar"
        Me.col_ocultar.ReadOnly = True
        Me.col_ocultar.Width = 47
        '
        'menu_cantidad
        '
        Me.menu_cantidad.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarCantidadToolStripMenuItem})
        Me.menu_cantidad.Name = "menu_cantidad"
        Me.menu_cantidad.Size = New System.Drawing.Size(154, 26)
        '
        'EditarCantidadToolStripMenuItem
        '
        Me.EditarCantidadToolStripMenuItem.Image = Global.Spic.My.Resources.Resources._Save
        Me.EditarCantidadToolStripMenuItem.Name = "EditarCantidadToolStripMenuItem"
        Me.EditarCantidadToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.EditarCantidadToolStripMenuItem.Text = "Editar cantidad"
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.Location = New System.Drawing.Point(12, 15)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(55, 16)
        Me.lbl_titulo.TabIndex = 1
        Me.lbl_titulo.Text = "Label1"
        '
        'btn_consultar
        '
        Me.btn_consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar.Image = Global.Spic.My.Resources.Resources._1385696421_search
        Me.btn_consultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consultar.Location = New System.Drawing.Point(718, 2)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(109, 43)
        Me.btn_consultar.TabIndex = 2
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'frm_list_referencias_rec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 322)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.lbl_titulo)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "frm_list_referencias_rec"
        Me.Text = "Lista de referencias"
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu_cantidad.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_titulo As System.Windows.Forms.Label
    Friend WithEvents col_ocultar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents menu_cantidad As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarCantidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
