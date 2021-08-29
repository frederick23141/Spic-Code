<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_infor_cant_entre
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtg_cantidad = New System.Windows.Forms.DataGridView()
        Me.btn_cargar = New System.Windows.Forms.Button()
        Me.btnexcel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.cboFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(321, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 60)
        Me.GroupBox1.TabIndex = 1047
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de fecha"
        '
        'cboFechaIni
        '
        Me.cboFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaIni.Location = New System.Drawing.Point(53, 14)
        Me.cboFechaIni.MaxDate = New Date(2054, 5, 13, 0, 0, 0, 0)
        Me.cboFechaIni.Name = "cboFechaIni"
        Me.cboFechaIni.Size = New System.Drawing.Size(91, 20)
        Me.cboFechaIni.TabIndex = 1028
        Me.cboFechaIni.Value = New Date(2020, 2, 7, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 1029
        Me.Label5.Text = "Inicial:"
        '
        'cboFechaFin
        '
        Me.cboFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cboFechaFin.Location = New System.Drawing.Point(53, 36)
        Me.cboFechaFin.MaxDate = New Date(2054, 5, 13, 0, 0, 0, 0)
        Me.cboFechaFin.Name = "cboFechaFin"
        Me.cboFechaFin.Size = New System.Drawing.Size(91, 20)
        Me.cboFechaFin.TabIndex = 1030
        Me.cboFechaFin.Value = New Date(2020, 2, 7, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1031
        Me.Label3.Text = "Final:"
        '
        'dtg_cantidad
        '
        Me.dtg_cantidad.AllowUserToAddRows = False
        Me.dtg_cantidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_cantidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_cantidad.Location = New System.Drawing.Point(7, 100)
        Me.dtg_cantidad.Name = "dtg_cantidad"
        Me.dtg_cantidad.RowHeadersVisible = False
        Me.dtg_cantidad.Size = New System.Drawing.Size(793, 338)
        Me.dtg_cantidad.TabIndex = 1048
        '
        'btn_cargar
        '
        Me.btn_cargar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_cargar.Location = New System.Drawing.Point(433, 74)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cargar.TabIndex = 1049
        Me.btn_cargar.Text = "Cargar"
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'btnexcel
        '
        Me.btnexcel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnexcel.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btnexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexcel.Location = New System.Drawing.Point(282, 74)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(120, 23)
        Me.btnexcel.TabIndex = 1171
        Me.btnexcel.Text = "Exportar"
        Me.btnexcel.UseVisualStyleBackColor = True
        '
        'Frm_infor_cant_entre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnexcel)
        Me.Controls.Add(Me.btn_cargar)
        Me.Controls.Add(Me.dtg_cantidad)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frm_infor_cant_entre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe cant autorizada vs cant entregada"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboFechaIni As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents cboFechaFin As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtg_cantidad As DataGridView
    Friend WithEvents btn_cargar As Button
    Friend WithEvents btnexcel As Button
End Class
