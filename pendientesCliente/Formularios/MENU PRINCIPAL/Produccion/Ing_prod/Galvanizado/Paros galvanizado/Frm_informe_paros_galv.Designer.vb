<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_informe_paros_galv
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
        Me.dtg_paros = New System.Windows.Forms.DataGridView()
        Me.cbo_bobina = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cboAño = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.btn_cargar = New System.Windows.Forms.Button()
        Me.btnexcel = New System.Windows.Forms.Button()
        CType(Me.dtg_paros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_paros
        '
        Me.dtg_paros.AllowUserToAddRows = False
        Me.dtg_paros.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtg_paros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_paros.Location = New System.Drawing.Point(12, 59)
        Me.dtg_paros.Name = "dtg_paros"
        Me.dtg_paros.RowHeadersVisible = False
        Me.dtg_paros.Size = New System.Drawing.Size(776, 379)
        Me.dtg_paros.TabIndex = 0
        '
        'cbo_bobina
        '
        Me.cbo_bobina.AutoCompleteCustomSource.AddRange(New String() {"Seleccione", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        Me.cbo_bobina.FormattingEnabled = True
        Me.cbo_bobina.Items.AddRange(New Object() {"Seleccione", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        Me.cbo_bobina.Location = New System.Drawing.Point(597, 22)
        Me.cbo_bobina.Name = "cbo_bobina"
        Me.cbo_bobina.Size = New System.Drawing.Size(121, 21)
        Me.cbo_bobina.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(530, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Bobina:"
        '
        'Label37
        '
        Me.Label37.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(107, 23)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(39, 16)
        Me.Label37.TabIndex = 56
        Me.Label37.Text = "Año:"
        '
        'cboAño
        '
        Me.cboAño.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Location = New System.Drawing.Point(147, 21)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(72, 21)
        Me.cboAño.TabIndex = 54
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(238, 23)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(41, 16)
        Me.Label30.TabIndex = 55
        Me.Label30.Text = "Mes:"
        '
        'cboMes
        '
        Me.cboMes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.FormattingEnabled = True
        Me.cboMes.Items.AddRange(New Object() {"Seleccione", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMes.Location = New System.Drawing.Point(280, 21)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(65, 20)
        Me.cboMes.TabIndex = 53
        '
        'btn_cargar
        '
        Me.btn_cargar.Location = New System.Drawing.Point(364, 11)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(75, 42)
        Me.btn_cargar.TabIndex = 57
        Me.btn_cargar.Text = "Cargar"
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'btnexcel
        '
        Me.btnexcel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnexcel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btnexcel.Location = New System.Drawing.Point(445, 12)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(67, 41)
        Me.btnexcel.TabIndex = 1170
        Me.btnexcel.UseVisualStyleBackColor = True
        '
        'Frm_informe_paros_galv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnexcel)
        Me.Controls.Add(Me.btn_cargar)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.cboAño)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cboMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo_bobina)
        Me.Controls.Add(Me.dtg_paros)
        Me.MaximizeBox = False
        Me.Name = "Frm_informe_paros_galv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de paros galvanizado"
        CType(Me.dtg_paros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtg_paros As DataGridView
    Friend WithEvents cbo_bobina As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents cboAño As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents cboMes As ComboBox
    Friend WithEvents btn_cargar As Button
    Friend WithEvents btnexcel As Button
End Class
