<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Consumo_Tornilleria
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
        Me.lbl_Referencia_Final = New System.Windows.Forms.Label()
        Me.cbo_Referencia_Final = New System.Windows.Forms.ComboBox()
        Me.lbl_mill = New System.Windows.Forms.Label()
        Me.txt_kilos = New System.Windows.Forms.TextBox()
        Me.btn_Realizar_Trans = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_Referencia_Final
        '
        Me.lbl_Referencia_Final.AutoSize = True
        Me.lbl_Referencia_Final.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Referencia_Final.Location = New System.Drawing.Point(23, 27)
        Me.lbl_Referencia_Final.Name = "lbl_Referencia_Final"
        Me.lbl_Referencia_Final.Size = New System.Drawing.Size(101, 13)
        Me.lbl_Referencia_Final.TabIndex = 0
        Me.lbl_Referencia_Final.Text = "Referencia final:"
        '
        'cbo_Referencia_Final
        '
        Me.cbo_Referencia_Final.FormattingEnabled = True
        Me.cbo_Referencia_Final.Location = New System.Drawing.Point(130, 23)
        Me.cbo_Referencia_Final.Name = "cbo_Referencia_Final"
        Me.cbo_Referencia_Final.Size = New System.Drawing.Size(121, 21)
        Me.cbo_Referencia_Final.TabIndex = 1
        '
        'lbl_mill
        '
        Me.lbl_mill.AutoSize = True
        Me.lbl_mill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mill.Location = New System.Drawing.Point(85, 72)
        Me.lbl_mill.Name = "lbl_mill"
        Me.lbl_mill.Size = New System.Drawing.Size(54, 13)
        Me.lbl_mill.TabIndex = 2
        Me.lbl_mill.Text = "Millares:"
        '
        'txt_kilos
        '
        Me.txt_kilos.Location = New System.Drawing.Point(130, 69)
        Me.txt_kilos.Name = "txt_kilos"
        Me.txt_kilos.Size = New System.Drawing.Size(121, 20)
        Me.txt_kilos.TabIndex = 3
        '
        'btn_Realizar_Trans
        '
        Me.btn_Realizar_Trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Realizar_Trans.Location = New System.Drawing.Point(74, 115)
        Me.btn_Realizar_Trans.Name = "btn_Realizar_Trans"
        Me.btn_Realizar_Trans.Size = New System.Drawing.Size(141, 23)
        Me.btn_Realizar_Trans.TabIndex = 4
        Me.btn_Realizar_Trans.Text = "Realizar transacción"
        Me.btn_Realizar_Trans.UseVisualStyleBackColor = True
        '
        'frm_Consumo_Tornilleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 166)
        Me.Controls.Add(Me.btn_Realizar_Trans)
        Me.Controls.Add(Me.txt_kilos)
        Me.Controls.Add(Me.lbl_mill)
        Me.Controls.Add(Me.cbo_Referencia_Final)
        Me.Controls.Add(Me.lbl_Referencia_Final)
        Me.MaximizeBox = False
        Me.Name = "frm_Consumo_Tornilleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consumo de tornilleria"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Referencia_Final As Label
    Friend WithEvents cbo_Referencia_Final As ComboBox
    Friend WithEvents lbl_mill As Label
    Friend WithEvents txt_kilos As TextBox
    Friend WithEvents btn_Realizar_Trans As Button
End Class
