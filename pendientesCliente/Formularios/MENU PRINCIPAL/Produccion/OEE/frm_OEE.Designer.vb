<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_OEE
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
        Me.dtg_OEE = New System.Windows.Forms.DataGridView()
        Me.btn_cargar = New System.Windows.Forms.Button()
        CType(Me.dtg_OEE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_OEE
        '
        Me.dtg_OEE.AllowUserToAddRows = False
        Me.dtg_OEE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_OEE.ColumnHeadersVisible = False
        Me.dtg_OEE.Location = New System.Drawing.Point(25, 91)
        Me.dtg_OEE.Name = "dtg_OEE"
        Me.dtg_OEE.Size = New System.Drawing.Size(763, 347)
        Me.dtg_OEE.TabIndex = 0
        '
        'btn_cargar
        '
        Me.btn_cargar.Location = New System.Drawing.Point(370, 62)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cargar.TabIndex = 1
        Me.btn_cargar.Text = "Cargar"
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'frm_OEE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_cargar)
        Me.Controls.Add(Me.dtg_OEE)
        Me.Name = "frm_OEE"
        Me.Text = "Formulario OEE"
        CType(Me.dtg_OEE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtg_OEE As DataGridView
    Friend WithEvents btn_cargar As Button
End Class
