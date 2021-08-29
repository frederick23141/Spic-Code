<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_informe_temporales
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
        Me.dtg_temporales = New System.Windows.Forms.DataGridView()
        Me.txt_nombres = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.blinding_temporales = New System.Windows.Forms.BindingSource(Me.components)
        Me.btn_exportar = New System.Windows.Forms.Button()
        CType(Me.dtg_temporales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.blinding_temporales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_temporales
        '
        Me.dtg_temporales.AllowUserToAddRows = False
        Me.dtg_temporales.AllowUserToDeleteRows = False
        Me.dtg_temporales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_temporales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_temporales.Location = New System.Drawing.Point(12, 44)
        Me.dtg_temporales.Name = "dtg_temporales"
        Me.dtg_temporales.ReadOnly = True
        Me.dtg_temporales.RowHeadersVisible = False
        Me.dtg_temporales.Size = New System.Drawing.Size(683, 341)
        Me.dtg_temporales.TabIndex = 0
        '
        'txt_nombres
        '
        Me.txt_nombres.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txt_nombres.Location = New System.Drawing.Point(411, 15)
        Me.txt_nombres.Name = "txt_nombres"
        Me.txt_nombres.Size = New System.Drawing.Size(141, 20)
        Me.txt_nombres.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(345, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombres:"
        '
        'blinding_temporales
        '
        Me.blinding_temporales.Filter = "nit"
        '
        'btn_exportar
        '
        Me.btn_exportar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btn_exportar.Location = New System.Drawing.Point(163, 6)
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(97, 36)
        Me.btn_exportar.TabIndex = 5
        Me.btn_exportar.Text = "Exportar"
        Me.btn_exportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_exportar.UseVisualStyleBackColor = True
        '
        'Frm_informe_temporales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 397)
        Me.Controls.Add(Me.btn_exportar)
        Me.Controls.Add(Me.txt_nombres)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtg_temporales)
        Me.Name = "Frm_informe_temporales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empleados temporales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_temporales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.blinding_temporales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_temporales As System.Windows.Forms.DataGridView
    Friend WithEvents txt_nombres As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents blinding_temporales As System.Windows.Forms.BindingSource
    Friend WithEvents btn_exportar As System.Windows.Forms.Button
End Class
