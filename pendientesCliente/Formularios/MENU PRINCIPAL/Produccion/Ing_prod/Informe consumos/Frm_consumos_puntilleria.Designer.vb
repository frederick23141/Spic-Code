<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_consumos_puntilleria
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
        Me.dtg_mat_punt = New System.Windows.Forms.DataGridView()
        Me.dtg_scla = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbo_min_salida = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_hora_salida = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbo_min_entrada = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbo_hora_entrada = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chk_mat_ptrima = New System.Windows.Forms.CheckBox()
        Me.btn_cargar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dtg_mat_punt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_scla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtg_mat_punt
        '
        Me.dtg_mat_punt.AllowUserToAddRows = False
        Me.dtg_mat_punt.AllowUserToDeleteRows = False
        Me.dtg_mat_punt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_mat_punt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_mat_punt.Location = New System.Drawing.Point(21, 107)
        Me.dtg_mat_punt.Name = "dtg_mat_punt"
        Me.dtg_mat_punt.ReadOnly = True
        Me.dtg_mat_punt.RowHeadersVisible = False
        Me.dtg_mat_punt.Size = New System.Drawing.Size(999, 117)
        Me.dtg_mat_punt.TabIndex = 0
        '
        'dtg_scla
        '
        Me.dtg_scla.AllowUserToAddRows = False
        Me.dtg_scla.AllowUserToDeleteRows = False
        Me.dtg_scla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_scla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_scla.Location = New System.Drawing.Point(21, 255)
        Me.dtg_scla.Name = "dtg_scla"
        Me.dtg_scla.ReadOnly = True
        Me.dtg_scla.RowHeadersVisible = False
        Me.dtg_scla.Size = New System.Drawing.Size(999, 150)
        Me.dtg_scla.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(449, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 1229
        Me.Label7.Text = "Minuto:"
        '
        'cbo_min_salida
        '
        Me.cbo_min_salida.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_min_salida.FormattingEnabled = True
        Me.cbo_min_salida.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_salida.Location = New System.Drawing.Point(498, 46)
        Me.cbo_min_salida.Name = "cbo_min_salida"
        Me.cbo_min_salida.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_salida.TabIndex = 1228
        Me.cbo_min_salida.Text = "00"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(317, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 1227
        Me.Label8.Text = "Hora final:"
        '
        'cbo_hora_salida
        '
        Me.cbo_hora_salida.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_hora_salida.FormattingEnabled = True
        Me.cbo_hora_salida.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_salida.Location = New System.Drawing.Point(408, 46)
        Me.cbo_hora_salida.Name = "cbo_hora_salida"
        Me.cbo_hora_salida.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_salida.TabIndex = 1226
        Me.cbo_hora_salida.Text = "6"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(450, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 1225
        Me.Label15.Text = "Minuto:"
        '
        'cbo_min_entrada
        '
        Me.cbo_min_entrada.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_min_entrada.FormattingEnabled = True
        Me.cbo_min_entrada.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_entrada.Location = New System.Drawing.Point(499, 22)
        Me.cbo_min_entrada.Name = "cbo_min_entrada"
        Me.cbo_min_entrada.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_entrada.TabIndex = 1224
        Me.cbo_min_entrada.Text = "00"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(317, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 13)
        Me.Label16.TabIndex = 1223
        Me.Label16.Text = "Hora inicial:"
        '
        'cbo_hora_entrada
        '
        Me.cbo_hora_entrada.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_hora_entrada.FormattingEnabled = True
        Me.cbo_hora_entrada.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_entrada.Location = New System.Drawing.Point(409, 22)
        Me.cbo_hora_entrada.Name = "cbo_hora_entrada"
        Me.cbo_hora_entrada.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_entrada.TabIndex = 1222
        Me.cbo_hora_entrada.Text = "6"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.cboFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(167, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 60)
        Me.GroupBox1.TabIndex = 1221
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
        Me.cboFechaIni.Value = New Date(2016, 6, 1, 0, 0, 0, 0)
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
        Me.cboFechaFin.Value = New Date(2016, 6, 1, 15, 46, 45, 0)
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
        'chk_mat_ptrima
        '
        Me.chk_mat_ptrima.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_mat_ptrima.AutoSize = True
        Me.chk_mat_ptrima.Location = New System.Drawing.Point(685, 34)
        Me.chk_mat_ptrima.Name = "chk_mat_ptrima"
        Me.chk_mat_ptrima.Size = New System.Drawing.Size(158, 17)
        Me.chk_mat_ptrima.TabIndex = 1220
        Me.chk_mat_ptrima.Text = "Consolidar por materia prima"
        Me.chk_mat_ptrima.UseVisualStyleBackColor = True
        '
        'btn_cargar
        '
        Me.btn_cargar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_cargar.Location = New System.Drawing.Point(564, 30)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cargar.TabIndex = 1219
        Me.btn_cargar.Text = "Cargar"
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 1230
        Me.Label1.Text = "Producto trabajado"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(196, 13)
        Me.Label2.TabIndex = 1231
        Me.Label2.Text = "Materia prima consumida por scal"
        '
        'Frm_consumos_puntilleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 418)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbo_min_salida)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbo_hora_salida)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbo_min_entrada)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cbo_hora_entrada)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chk_mat_ptrima)
        Me.Controls.Add(Me.btn_cargar)
        Me.Controls.Add(Me.dtg_scla)
        Me.Controls.Add(Me.dtg_mat_punt)
        Me.Name = "Frm_consumos_puntilleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control Consumos puntilleria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_mat_punt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_scla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_mat_punt As System.Windows.Forms.DataGridView
    Friend WithEvents dtg_scla As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_min_salida As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_hora_salida As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_min_entrada As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbo_hora_entrada As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_mat_ptrima As System.Windows.Forms.CheckBox
    Friend WithEvents btn_cargar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
