<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_aud_mp_tref_rec
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
        Me.dtg_consulta = New System.Windows.Forms.DataGridView()
        Me.btn_consulta = New System.Windows.Forms.Button()
        Me.btn_excel = New System.Windows.Forms.Button()
        Me.rdb_bodega = New System.Windows.Forms.RadioButton()
        Me.rdb_consumido = New System.Windows.Forms.RadioButton()
        Me.chk_consolidar = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dtg_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_consulta.Location = New System.Drawing.Point(1, 86)
        Me.dtg_consulta.Name = "dtg_consulta"
        Me.dtg_consulta.ReadOnly = True
        Me.dtg_consulta.RowHeadersVisible = False
        Me.dtg_consulta.Size = New System.Drawing.Size(803, 305)
        Me.dtg_consulta.TabIndex = 0
        '
        'btn_consulta
        '
        Me.btn_consulta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_consulta.Location = New System.Drawing.Point(92, 10)
        Me.btn_consulta.Name = "btn_consulta"
        Me.btn_consulta.Size = New System.Drawing.Size(131, 23)
        Me.btn_consulta.TabIndex = 1
        Me.btn_consulta.Text = "Cargar"
        Me.btn_consulta.UseVisualStyleBackColor = True
        '
        'btn_excel
        '
        Me.btn_excel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excel.Location = New System.Drawing.Point(92, 41)
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(131, 23)
        Me.btn_excel.TabIndex = 2
        Me.btn_excel.Text = "Exportar"
        Me.btn_excel.UseVisualStyleBackColor = True
        '
        'rdb_bodega
        '
        Me.rdb_bodega.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdb_bodega.AutoSize = True
        Me.rdb_bodega.Checked = True
        Me.rdb_bodega.Location = New System.Drawing.Point(267, 16)
        Me.rdb_bodega.Name = "rdb_bodega"
        Me.rdb_bodega.Size = New System.Drawing.Size(157, 17)
        Me.rdb_bodega.TabIndex = 3
        Me.rdb_bodega.TabStop = True
        Me.rdb_bodega.Text = "INVENTARIO EN BODEGA"
        Me.rdb_bodega.UseVisualStyleBackColor = True
        '
        'rdb_consumido
        '
        Me.rdb_consumido.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdb_consumido.AutoSize = True
        Me.rdb_consumido.Location = New System.Drawing.Point(267, 39)
        Me.rdb_consumido.Name = "rdb_consumido"
        Me.rdb_consumido.Size = New System.Drawing.Size(160, 17)
        Me.rdb_consumido.TabIndex = 4
        Me.rdb_consumido.Text = "INVENTARIO CONSUMIDO"
        Me.rdb_consumido.UseVisualStyleBackColor = True
        '
        'chk_consolidar
        '
        Me.chk_consolidar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_consolidar.AutoSize = True
        Me.chk_consolidar.Location = New System.Drawing.Point(454, 29)
        Me.chk_consolidar.Name = "chk_consolidar"
        Me.chk_consolidar.Size = New System.Drawing.Size(96, 17)
        Me.chk_consolidar.TabIndex = 9
        Me.chk_consolidar.Text = "CONSOLIDAR"
        Me.chk_consolidar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(574, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Codigo:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCodigo.Location = New System.Drawing.Point(620, 27)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 11
        '
        'frm_aud_mp_tref_rec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 391)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chk_consolidar)
        Me.Controls.Add(Me.rdb_consumido)
        Me.Controls.Add(Me.rdb_bodega)
        Me.Controls.Add(Me.btn_excel)
        Me.Controls.Add(Me.btn_consulta)
        Me.Controls.Add(Me.dtg_consulta)
        Me.Name = "frm_aud_mp_tref_rec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulario auditoria mp tref-rec"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_consulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_consulta As System.Windows.Forms.DataGridView
    Friend WithEvents btn_consulta As System.Windows.Forms.Button
    Friend WithEvents btn_excel As System.Windows.Forms.Button
    Friend WithEvents rdb_bodega As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_consumido As System.Windows.Forms.RadioButton
    Friend WithEvents chk_consolidar As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
End Class
