<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consulta_dias_per
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
        Me.dtg_dias_asigna = New System.Windows.Forms.DataGridView()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_mes = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cbo_ano = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lbl_mes = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_ano = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btn_consultar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.dtg_dias_asigna, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_ano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_dias_asigna
        '
        Me.dtg_dias_asigna.AllowUserToAddRows = False
        Me.dtg_dias_asigna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_dias_asigna.Location = New System.Drawing.Point(12, 79)
        Me.dtg_dias_asigna.Name = "dtg_dias_asigna"
        Me.dtg_dias_asigna.RowHeadersVisible = False
        Me.dtg_dias_asigna.Size = New System.Drawing.Size(776, 359)
        Me.dtg_dias_asigna.TabIndex = 0
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(359, 3)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(106, 19)
        Me.KryptonLabel1.StateNormal.LongText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.StateNormal.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonLabel1.TabIndex = 1
        Me.KryptonLabel1.Values.Text = "Dias asignados"
        '
        'cbo_mes
        '
        Me.cbo_mes.AutoCompleteCustomSource.AddRange(New String() {"1,", "2,", "3,", "4,", "5,", "6,", "7,", "8,", "9,", "10,", "11,", "12"})
        Me.cbo_mes.DropDownWidth = 121
        Me.cbo_mes.Location = New System.Drawing.Point(241, 28)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(121, 21)
        Me.cbo_mes.TabIndex = 2
        '
        'cbo_ano
        '
        Me.cbo_ano.DropDownWidth = 121
        Me.cbo_ano.Location = New System.Drawing.Point(510, 27)
        Me.cbo_ano.Name = "cbo_ano"
        Me.cbo_ano.Size = New System.Drawing.Size(121, 21)
        Me.cbo_ano.TabIndex = 3
        '
        'lbl_mes
        '
        Me.lbl_mes.Location = New System.Drawing.Point(182, 28)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(36, 20)
        Me.lbl_mes.TabIndex = 4
        Me.lbl_mes.Values.Text = "Mes:"
        '
        'lbl_ano
        '
        Me.lbl_ano.Location = New System.Drawing.Point(461, 28)
        Me.lbl_ano.Name = "lbl_ano"
        Me.lbl_ano.Size = New System.Drawing.Size(35, 20)
        Me.lbl_ano.TabIndex = 5
        Me.lbl_ano.Values.Text = "Año:"
        '
        'btn_consultar
        '
        Me.btn_consultar.Location = New System.Drawing.Point(369, 49)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(90, 25)
        Me.btn_consultar.TabIndex = 6
        Me.btn_consultar.Values.Text = "Consultar"
        '
        'Consulta_dias_per
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.lbl_ano)
        Me.Controls.Add(Me.lbl_mes)
        Me.Controls.Add(Me.cbo_ano)
        Me.Controls.Add(Me.cbo_mes)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.dtg_dias_asigna)
        Me.Name = "Consulta_dias_per"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta dias asignados"
        CType(Me.dtg_dias_asigna, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_ano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtg_dias_asigna As DataGridView
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_mes As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cbo_ano As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lbl_mes As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_ano As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btn_consultar As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
