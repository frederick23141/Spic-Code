<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consumos_alambron
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
        Me.dtg_matprima = New System.Windows.Forms.DataGridView()
        Me.btn_cargar = New System.Windows.Forms.Button()
        Me.chk_mat_ptrima = New System.Windows.Forms.CheckBox()
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
        Me.tab_brilla = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtg_matprima_repro = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dtg_alambron = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dtg_recocido = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dtg_brillante_consu = New System.Windows.Forms.DataGridView()
        Me.lbl_producido = New System.Windows.Forms.Label()
        Me.lbl_consumido = New System.Windows.Forms.Label()
        CType(Me.dtg_matprima, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tab_brilla.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtg_matprima_repro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtg_alambron, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dtg_recocido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dtg_brillante_consu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_matprima
        '
        Me.dtg_matprima.AllowUserToAddRows = False
        Me.dtg_matprima.AllowUserToDeleteRows = False
        Me.dtg_matprima.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_matprima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_matprima.Location = New System.Drawing.Point(3, 22)
        Me.dtg_matprima.Name = "dtg_matprima"
        Me.dtg_matprima.ReadOnly = True
        Me.dtg_matprima.RowHeadersVisible = False
        Me.dtg_matprima.Size = New System.Drawing.Size(828, 126)
        Me.dtg_matprima.TabIndex = 0
        '
        'btn_cargar
        '
        Me.btn_cargar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_cargar.Location = New System.Drawing.Point(445, 24)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cargar.TabIndex = 5
        Me.btn_cargar.Text = "Cargar"
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'chk_mat_ptrima
        '
        Me.chk_mat_ptrima.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chk_mat_ptrima.AutoSize = True
        Me.chk_mat_ptrima.Location = New System.Drawing.Point(537, 6)
        Me.chk_mat_ptrima.Name = "chk_mat_ptrima"
        Me.chk_mat_ptrima.Size = New System.Drawing.Size(158, 17)
        Me.chk_mat_ptrima.TabIndex = 6
        Me.chk_mat_ptrima.Text = "Consolidar por materia prima"
        Me.chk_mat_ptrima.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(330, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 1218
        Me.Label7.Text = "Minuto:"
        '
        'cbo_min_salida
        '
        Me.cbo_min_salida.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_min_salida.FormattingEnabled = True
        Me.cbo_min_salida.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_salida.Location = New System.Drawing.Point(379, 40)
        Me.cbo_min_salida.Name = "cbo_min_salida"
        Me.cbo_min_salida.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_salida.TabIndex = 1217
        Me.cbo_min_salida.Text = "00"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(198, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 1216
        Me.Label8.Text = "Hora final:"
        '
        'cbo_hora_salida
        '
        Me.cbo_hora_salida.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_hora_salida.FormattingEnabled = True
        Me.cbo_hora_salida.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_salida.Location = New System.Drawing.Point(289, 40)
        Me.cbo_hora_salida.Name = "cbo_hora_salida"
        Me.cbo_hora_salida.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_salida.TabIndex = 1215
        Me.cbo_hora_salida.Text = "6"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(331, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 1214
        Me.Label15.Text = "Minuto:"
        '
        'cbo_min_entrada
        '
        Me.cbo_min_entrada.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_min_entrada.FormattingEnabled = True
        Me.cbo_min_entrada.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "52", "53", "54", "55", "56", "57", "58", "59", "", ""})
        Me.cbo_min_entrada.Location = New System.Drawing.Point(380, 16)
        Me.cbo_min_entrada.Name = "cbo_min_entrada"
        Me.cbo_min_entrada.Size = New System.Drawing.Size(41, 21)
        Me.cbo_min_entrada.TabIndex = 1213
        Me.cbo_min_entrada.Text = "00"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(198, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 13)
        Me.Label16.TabIndex = 1212
        Me.Label16.Text = "Hora inicial:"
        '
        'cbo_hora_entrada
        '
        Me.cbo_hora_entrada.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_hora_entrada.FormattingEnabled = True
        Me.cbo_hora_entrada.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.cbo_hora_entrada.Location = New System.Drawing.Point(290, 16)
        Me.cbo_hora_entrada.Name = "cbo_hora_entrada"
        Me.cbo_hora_entrada.Size = New System.Drawing.Size(38, 21)
        Me.cbo_hora_entrada.TabIndex = 1211
        Me.cbo_hora_entrada.Text = "6"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.cboFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboFechaFin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(48, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 60)
        Me.GroupBox1.TabIndex = 1210
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
        'tab_brilla
        '
        Me.tab_brilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_brilla.Controls.Add(Me.TabPage1)
        Me.tab_brilla.Controls.Add(Me.TabPage2)
        Me.tab_brilla.Controls.Add(Me.TabPage3)
        Me.tab_brilla.Controls.Add(Me.TabPage4)
        Me.tab_brilla.Location = New System.Drawing.Point(12, 72)
        Me.tab_brilla.Name = "tab_brilla"
        Me.tab_brilla.SelectedIndex = 0
        Me.tab_brilla.Size = New System.Drawing.Size(842, 333)
        Me.tab_brilla.TabIndex = 1219
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtg_matprima_repro)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dtg_matprima)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(834, 307)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Produccion de trefilación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Reproceso"
        '
        'dtg_matprima_repro
        '
        Me.dtg_matprima_repro.AllowUserToAddRows = False
        Me.dtg_matprima_repro.AllowUserToDeleteRows = False
        Me.dtg_matprima_repro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_matprima_repro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_matprima_repro.Location = New System.Drawing.Point(3, 170)
        Me.dtg_matprima_repro.Name = "dtg_matprima_repro"
        Me.dtg_matprima_repro.RowHeadersVisible = False
        Me.dtg_matprima_repro.Size = New System.Drawing.Size(828, 131)
        Me.dtg_matprima_repro.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Alambron"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtg_alambron)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(834, 307)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Alambron consumido"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtg_alambron
        '
        Me.dtg_alambron.AllowUserToAddRows = False
        Me.dtg_alambron.AllowUserToDeleteRows = False
        Me.dtg_alambron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_alambron.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_alambron.Location = New System.Drawing.Point(3, 3)
        Me.dtg_alambron.Name = "dtg_alambron"
        Me.dtg_alambron.ReadOnly = True
        Me.dtg_alambron.RowHeadersVisible = False
        Me.dtg_alambron.Size = New System.Drawing.Size(828, 301)
        Me.dtg_alambron.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dtg_recocido)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(834, 307)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Recocido consumido"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dtg_recocido
        '
        Me.dtg_recocido.AllowUserToAddRows = False
        Me.dtg_recocido.AllowUserToDeleteRows = False
        Me.dtg_recocido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_recocido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_recocido.Location = New System.Drawing.Point(3, 3)
        Me.dtg_recocido.Name = "dtg_recocido"
        Me.dtg_recocido.ReadOnly = True
        Me.dtg_recocido.RowHeadersVisible = False
        Me.dtg_recocido.Size = New System.Drawing.Size(828, 301)
        Me.dtg_recocido.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dtg_brillante_consu)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(834, 307)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Brillante consumido"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dtg_brillante_consu
        '
        Me.dtg_brillante_consu.AllowUserToAddRows = False
        Me.dtg_brillante_consu.AllowUserToDeleteRows = False
        Me.dtg_brillante_consu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_brillante_consu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_brillante_consu.Location = New System.Drawing.Point(3, 3)
        Me.dtg_brillante_consu.Name = "dtg_brillante_consu"
        Me.dtg_brillante_consu.ReadOnly = True
        Me.dtg_brillante_consu.RowHeadersVisible = False
        Me.dtg_brillante_consu.Size = New System.Drawing.Size(828, 301)
        Me.dtg_brillante_consu.TabIndex = 1
        '
        'lbl_producido
        '
        Me.lbl_producido.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_producido.AutoSize = True
        Me.lbl_producido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_producido.Location = New System.Drawing.Point(553, 29)
        Me.lbl_producido.Name = "lbl_producido"
        Me.lbl_producido.Size = New System.Drawing.Size(131, 18)
        Me.lbl_producido.TabIndex = 1220
        Me.lbl_producido.Text = "Total producido:"
        '
        'lbl_consumido
        '
        Me.lbl_consumido.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_consumido.AutoSize = True
        Me.lbl_consumido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_consumido.Location = New System.Drawing.Point(553, 52)
        Me.lbl_consumido.Name = "lbl_consumido"
        Me.lbl_consumido.Size = New System.Drawing.Size(139, 18)
        Me.lbl_consumido.TabIndex = 1221
        Me.lbl_consumido.Text = "Total consumido:"
        '
        'frm_consumos_alambron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 417)
        Me.Controls.Add(Me.lbl_consumido)
        Me.Controls.Add(Me.lbl_producido)
        Me.Controls.Add(Me.tab_brilla)
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
        Me.Name = "frm_consumos_alambron"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control consumos trefilación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_matprima, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tab_brilla.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dtg_matprima_repro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dtg_alambron, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dtg_recocido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dtg_brillante_consu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_matprima As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cargar As System.Windows.Forms.Button
    Friend WithEvents chk_mat_ptrima As System.Windows.Forms.CheckBox
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
    Friend WithEvents tab_brilla As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dtg_alambron As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dtg_recocido As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtg_matprima_repro As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dtg_brillante_consu As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_producido As System.Windows.Forms.Label
    Friend WithEvents lbl_consumido As System.Windows.Forms.Label
End Class
