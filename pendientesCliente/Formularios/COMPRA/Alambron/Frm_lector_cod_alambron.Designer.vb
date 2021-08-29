<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_lector_cod_alambron
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_lector_cod_alambron))
        Me.dtgConsulta = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtCodigoLector = New System.Windows.Forms.TextBox()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_requisicion = New System.Windows.Forms.TabPage()
        Me.txt_cant_rollos = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_traslado = New System.Windows.Forms.Button()
        Me.btn_next_requisicion = New System.Windows.Forms.Button()
        Me.txtMulaDescargada = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMulaCargada = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tab_cargue = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_movimientos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_cargar = New System.Windows.Forms.Button()
        Me.txtPeso = New System.Windows.Forms.RichTextBox()
        Me.lblDescipcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.tab_muestra = New System.Windows.Forms.TabPage()
        Me.txt_consecutivo_muestra = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_cal_final = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_terminar_muestra = New System.Windows.Forms.Button()
        Me.txt_recalado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_traccion = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txt_torsion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btn_transaccion = New System.Windows.Forms.Button()
        Me.col_borrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_muestra = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colConsecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_numero_imp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_id_det = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumRollo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_costo_kilo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_estado_muestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nit_prov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_ppal.SuspendLayout()
        Me.tab_requisicion.SuspendLayout()
        Me.tab_cargue.SuspendLayout()
        Me.tab_muestra.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgConsulta
        '
        Me.dtgConsulta.AllowUserToAddRows = False
        Me.dtgConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N1"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgConsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_borrar, Me.col_muestra, Me.colConsecutivo, Me.colCodigo, Me.colPeso, Me.col_numero_imp, Me.col_id_det, Me.colNumRollo, Me.col_costo_kilo, Me.col_estado_muestra, Me.col_nit_prov})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgConsulta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgConsulta.Location = New System.Drawing.Point(1, 86)
        Me.dtgConsulta.Name = "dtgConsulta"
        Me.dtgConsulta.ReadOnly = True
        Me.dtgConsulta.RowHeadersVisible = False
        Me.dtgConsulta.Size = New System.Drawing.Size(314, 142)
        Me.dtgConsulta.TabIndex = 3
        '
        'txtCodigoLector
        '
        Me.txtCodigoLector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodigoLector.Enabled = False
        Me.txtCodigoLector.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLector.ForeColor = System.Drawing.Color.Silver
        Me.txtCodigoLector.Location = New System.Drawing.Point(4, 15)
        Me.txtCodigoLector.Name = "txtCodigoLector"
        Me.txtCodigoLector.Size = New System.Drawing.Size(181, 35)
        Me.txtCodigoLector.TabIndex = 1074
        Me.txtCodigoLector.Text = "LEA CÓDIGO"
        '
        'tab_ppal
        '
        Me.tab_ppal.Controls.Add(Me.tab_requisicion)
        Me.tab_ppal.Controls.Add(Me.tab_cargue)
        Me.tab_ppal.Controls.Add(Me.tab_muestra)
        Me.tab_ppal.Location = New System.Drawing.Point(0, 0)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(325, 292)
        Me.tab_ppal.TabIndex = 1074
        '
        'tab_requisicion
        '
        Me.tab_requisicion.Controls.Add(Me.txt_cant_rollos)
        Me.tab_requisicion.Controls.Add(Me.Label11)
        Me.tab_requisicion.Controls.Add(Me.btn_traslado)
        Me.tab_requisicion.Controls.Add(Me.btn_next_requisicion)
        Me.tab_requisicion.Controls.Add(Me.txtMulaDescargada)
        Me.tab_requisicion.Controls.Add(Me.Label3)
        Me.tab_requisicion.Controls.Add(Me.txtMulaCargada)
        Me.tab_requisicion.Controls.Add(Me.Label2)
        Me.tab_requisicion.Controls.Add(Me.txtPlaca)
        Me.tab_requisicion.Controls.Add(Me.Label1)
        Me.tab_requisicion.Location = New System.Drawing.Point(4, 22)
        Me.tab_requisicion.Name = "tab_requisicion"
        Me.tab_requisicion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_requisicion.Size = New System.Drawing.Size(317, 265)
        Me.tab_requisicion.TabIndex = 0
        Me.tab_requisicion.Text = "Requisición"
        Me.tab_requisicion.UseVisualStyleBackColor = True
        '
        'txt_cant_rollos
        '
        Me.txt_cant_rollos.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cant_rollos.Location = New System.Drawing.Point(226, 105)
        Me.txt_cant_rollos.Name = "txt_cant_rollos"
        Me.txt_cant_rollos.Size = New System.Drawing.Size(67, 38)
        Me.txt_cant_rollos.TabIndex = 1084
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(218, 13)
        Me.Label11.TabIndex = 1085
        Me.Label11.Text = "Cantidad de rollos fisicos del camión:"
        '
        'btn_traslado
        '
        Me.btn_traslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_traslado.Image = Global.Spic.My.Resources.Resources._1349388328_door_in1
        Me.btn_traslado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_traslado.Location = New System.Drawing.Point(109, 216)
        Me.btn_traslado.Name = "btn_traslado"
        Me.btn_traslado.Size = New System.Drawing.Size(100, 43)
        Me.btn_traslado.TabIndex = 1081
        Me.btn_traslado.Text = "Salir "
        Me.btn_traslado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_traslado.UseVisualStyleBackColor = True
        '
        'btn_next_requisicion
        '
        Me.btn_next_requisicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_next_requisicion.Image = Global.Spic.My.Resources.Resources._next
        Me.btn_next_requisicion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_next_requisicion.Location = New System.Drawing.Point(48, 149)
        Me.btn_next_requisicion.Name = "btn_next_requisicion"
        Me.btn_next_requisicion.Size = New System.Drawing.Size(219, 65)
        Me.btn_next_requisicion.TabIndex = 1080
        Me.btn_next_requisicion.Text = "CONTINUAR"
        Me.btn_next_requisicion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_next_requisicion.UseVisualStyleBackColor = True
        '
        'txtMulaDescargada
        '
        Me.txtMulaDescargada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMulaDescargada.Location = New System.Drawing.Point(146, 76)
        Me.txtMulaDescargada.Name = "txtMulaDescargada"
        Me.txtMulaDescargada.Size = New System.Drawing.Size(147, 22)
        Me.txtMulaDescargada.TabIndex = 1074
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 1075
        Me.Label3.Text = "Peso mula descargada:"
        '
        'txtMulaCargada
        '
        Me.txtMulaCargada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMulaCargada.Location = New System.Drawing.Point(146, 40)
        Me.txtMulaCargada.Name = "txtMulaCargada"
        Me.txtMulaCargada.Size = New System.Drawing.Size(147, 22)
        Me.txtMulaCargada.TabIndex = 1072
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 13)
        Me.Label2.TabIndex = 1073
        Me.Label2.Text = "Peso mula cargada:"
        '
        'txtPlaca
        '
        Me.txtPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaca.Location = New System.Drawing.Point(146, 6)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(147, 22)
        Me.txtPlaca.TabIndex = 1070
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1071
        Me.Label1.Text = "Placa:"
        '
        'tab_cargue
        '
        Me.tab_cargue.Controls.Add(Me.btn_transaccion)
        Me.tab_cargue.Controls.Add(Me.Label12)
        Me.tab_cargue.Controls.Add(Me.lbl_movimientos)
        Me.tab_cargue.Controls.Add(Me.txtCodigoLector)
        Me.tab_cargue.Controls.Add(Me.Label5)
        Me.tab_cargue.Controls.Add(Me.btn_cargar)
        Me.tab_cargue.Controls.Add(Me.txtPeso)
        Me.tab_cargue.Controls.Add(Me.lblDescipcion)
        Me.tab_cargue.Controls.Add(Me.lblCodigo)
        Me.tab_cargue.Controls.Add(Me.dtgConsulta)
        Me.tab_cargue.Location = New System.Drawing.Point(4, 22)
        Me.tab_cargue.Name = "tab_cargue"
        Me.tab_cargue.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_cargue.Size = New System.Drawing.Size(317, 266)
        Me.tab_cargue.TabIndex = 1
        Me.tab_cargue.Text = "Cargue"
        Me.tab_cargue.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(189, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 16)
        Me.Label12.TabIndex = 1086
        Me.Label12.Text = "Movimientos:"
        '
        'lbl_movimientos
        '
        Me.lbl_movimientos.AutoSize = True
        Me.lbl_movimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_movimientos.ForeColor = System.Drawing.Color.Red
        Me.lbl_movimientos.Location = New System.Drawing.Point(285, 1)
        Me.lbl_movimientos.Name = "lbl_movimientos"
        Me.lbl_movimientos.Size = New System.Drawing.Size(19, 20)
        Me.lbl_movimientos.TabIndex = 1085
        Me.lbl_movimientos.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 1082
        Me.Label5.Text = "Lector código de barras"
        '
        'btn_cargar
        '
        Me.btn_cargar.Enabled = False
        Me.btn_cargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cargar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_cargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cargar.Location = New System.Drawing.Point(190, 60)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(122, 25)
        Me.btn_cargar.TabIndex = 1079
        Me.btn_cargar.Text = "CARGAR"
        Me.btn_cargar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'txtPeso
        '
        Me.txtPeso.Enabled = False
        Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeso.ForeColor = System.Drawing.Color.DarkGray
        Me.txtPeso.Location = New System.Drawing.Point(191, 21)
        Me.txtPeso.MaxLength = 4
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(120, 39)
        Me.txtPeso.TabIndex = 1078
        Me.txtPeso.Text = "PESO"
        '
        'lblDescipcion
        '
        Me.lblDescipcion.AutoSize = True
        Me.lblDescipcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescipcion.Location = New System.Drawing.Point(3, 70)
        Me.lblDescipcion.Name = "lblDescipcion"
        Me.lblDescipcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescipcion.TabIndex = 1077
        Me.lblDescipcion.Text = "lblDescipcion"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(1, 52)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(75, 16)
        Me.lblCodigo.TabIndex = 1076
        Me.lblCodigo.Text = "lblCodigo"
        '
        'tab_muestra
        '
        Me.tab_muestra.Controls.Add(Me.txt_consecutivo_muestra)
        Me.tab_muestra.Controls.Add(Me.Label10)
        Me.tab_muestra.Controls.Add(Me.txt_cal_final)
        Me.tab_muestra.Controls.Add(Me.Label9)
        Me.tab_muestra.Controls.Add(Me.btn_terminar_muestra)
        Me.tab_muestra.Controls.Add(Me.txt_recalado)
        Me.tab_muestra.Controls.Add(Me.Label6)
        Me.tab_muestra.Controls.Add(Me.txt_traccion)
        Me.tab_muestra.Controls.Add(Me.label7)
        Me.tab_muestra.Controls.Add(Me.txt_torsion)
        Me.tab_muestra.Controls.Add(Me.Label8)
        Me.tab_muestra.Location = New System.Drawing.Point(4, 22)
        Me.tab_muestra.Name = "tab_muestra"
        Me.tab_muestra.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_muestra.Size = New System.Drawing.Size(317, 265)
        Me.tab_muestra.TabIndex = 2
        Me.tab_muestra.Text = "Muestreo"
        Me.tab_muestra.UseVisualStyleBackColor = True
        '
        'txt_consecutivo_muestra
        '
        Me.txt_consecutivo_muestra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_consecutivo_muestra.Location = New System.Drawing.Point(106, 6)
        Me.txt_consecutivo_muestra.Name = "txt_consecutivo_muestra"
        Me.txt_consecutivo_muestra.ReadOnly = True
        Me.txt_consecutivo_muestra.Size = New System.Drawing.Size(200, 22)
        Me.txt_consecutivo_muestra.TabIndex = 1085
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(20, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 1086
        Me.Label10.Text = "Consecutivo:"
        '
        'txt_cal_final
        '
        Me.txt_cal_final.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cal_final.Location = New System.Drawing.Point(106, 132)
        Me.txt_cal_final.Name = "txt_cal_final"
        Me.txt_cal_final.Size = New System.Drawing.Size(200, 22)
        Me.txt_cal_final.TabIndex = 1083
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 1084
        Me.Label9.Text = "Calidad final:"
        '
        'btn_terminar_muestra
        '
        Me.btn_terminar_muestra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_terminar_muestra.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btn_terminar_muestra.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_terminar_muestra.Location = New System.Drawing.Point(61, 214)
        Me.btn_terminar_muestra.Name = "btn_terminar_muestra"
        Me.btn_terminar_muestra.Size = New System.Drawing.Size(189, 29)
        Me.btn_terminar_muestra.TabIndex = 1082
        Me.btn_terminar_muestra.Text = "Terminar muestreo"
        Me.btn_terminar_muestra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_terminar_muestra.UseVisualStyleBackColor = True
        '
        'txt_recalado
        '
        Me.txt_recalado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_recalado.Location = New System.Drawing.Point(106, 102)
        Me.txt_recalado.Name = "txt_recalado"
        Me.txt_recalado.Size = New System.Drawing.Size(200, 22)
        Me.txt_recalado.TabIndex = 1080
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 1081
        Me.Label6.Text = "Recalcado:"
        '
        'txt_traccion
        '
        Me.txt_traccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_traccion.Location = New System.Drawing.Point(106, 68)
        Me.txt_traccion.Name = "txt_traccion"
        Me.txt_traccion.Size = New System.Drawing.Size(200, 22)
        Me.txt_traccion.TabIndex = 1078
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(40, 73)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(61, 13)
        Me.label7.TabIndex = 1079
        Me.label7.Text = "Tracción:"
        '
        'txt_torsion
        '
        Me.txt_torsion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_torsion.Location = New System.Drawing.Point(106, 37)
        Me.txt_torsion.Name = "txt_torsion"
        Me.txt_torsion.Size = New System.Drawing.Size(200, 22)
        Me.txt_torsion.TabIndex = 1076
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 1077
        Me.Label8.Text = "Torsión:"
        '
        'btn_transaccion
        '
        Me.btn_transaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_transaccion.Image = Global.Spic.My.Resources.Resources._new
        Me.btn_transaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_transaccion.Location = New System.Drawing.Point(5, 230)
        Me.btn_transaccion.Name = "btn_transaccion"
        Me.btn_transaccion.Size = New System.Drawing.Size(305, 37)
        Me.btn_transaccion.TabIndex = 1087
        Me.btn_transaccion.Text = "TRANSACCIÓN"
        Me.btn_transaccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_transaccion.UseVisualStyleBackColor = True
        '
        'col_borrar
        '
        Me.col_borrar.Frozen = True
        Me.col_borrar.HeaderText = ""
        Me.col_borrar.Image = Global.Spic.My.Resources.Resources.x
        Me.col_borrar.Name = "col_borrar"
        Me.col_borrar.ReadOnly = True
        Me.col_borrar.Width = 5
        '
        'col_muestra
        '
        Me.col_muestra.Frozen = True
        Me.col_muestra.HeaderText = ""
        Me.col_muestra.Image = Global.Spic.My.Resources.Resources._1447811158_settings
        Me.col_muestra.Name = "col_muestra"
        Me.col_muestra.ReadOnly = True
        Me.col_muestra.ToolTipText = "Sacar muestra"
        Me.col_muestra.Width = 5
        '
        'colConsecutivo
        '
        Me.colConsecutivo.Frozen = True
        Me.colConsecutivo.HeaderText = "#"
        Me.colConsecutivo.Name = "colConsecutivo"
        Me.colConsecutivo.ReadOnly = True
        Me.colConsecutivo.Width = 39
        '
        'colCodigo
        '
        Me.colCodigo.Frozen = True
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 65
        '
        'colPeso
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colPeso.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPeso.Frozen = True
        Me.colPeso.HeaderText = "Peso"
        Me.colPeso.Name = "colPeso"
        Me.colPeso.ReadOnly = True
        Me.colPeso.Width = 56
        '
        'col_numero_imp
        '
        Me.col_numero_imp.Frozen = True
        Me.col_numero_imp.HeaderText = "Núm_imp"
        Me.col_numero_imp.Name = "col_numero_imp"
        Me.col_numero_imp.ReadOnly = True
        Me.col_numero_imp.Width = 76
        '
        'col_id_det
        '
        Me.col_id_det.Frozen = True
        Me.col_id_det.HeaderText = "Detalle"
        Me.col_id_det.Name = "col_id_det"
        Me.col_id_det.ReadOnly = True
        Me.col_id_det.Width = 65
        '
        'colNumRollo
        '
        Me.colNumRollo.Frozen = True
        Me.colNumRollo.HeaderText = "Num_rollo"
        Me.colNumRollo.Name = "colNumRollo"
        Me.colNumRollo.ReadOnly = True
        Me.colNumRollo.Width = 79
        '
        'col_costo_kilo
        '
        Me.col_costo_kilo.Frozen = True
        Me.col_costo_kilo.HeaderText = "costo"
        Me.col_costo_kilo.Name = "col_costo_kilo"
        Me.col_costo_kilo.ReadOnly = True
        Me.col_costo_kilo.Visible = False
        Me.col_costo_kilo.Width = 58
        '
        'col_estado_muestra
        '
        Me.col_estado_muestra.Frozen = True
        Me.col_estado_muestra.HeaderText = "estado_muestra"
        Me.col_estado_muestra.Name = "col_estado_muestra"
        Me.col_estado_muestra.ReadOnly = True
        Me.col_estado_muestra.Visible = False
        Me.col_estado_muestra.Width = 107
        '
        'col_nit_prov
        '
        Me.col_nit_prov.Frozen = True
        Me.col_nit_prov.HeaderText = "nit_proveeddor"
        Me.col_nit_prov.Name = "col_nit_prov"
        Me.col_nit_prov.ReadOnly = True
        Me.col_nit_prov.Visible = False
        Me.col_nit_prov.Width = 103
        '
        'Frm_lector_cod_alambron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 292)
        Me.ControlBox = False
        Me.Controls.Add(Me.tab_ppal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_lector_cod_alambron"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Manejo de alambrón"
        CType(Me.dtgConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_requisicion.ResumeLayout(False)
        Me.tab_requisicion.PerformLayout()
        Me.tab_cargue.ResumeLayout(False)
        Me.tab_cargue.PerformLayout()
        Me.tab_muestra.ResumeLayout(False)
        Me.tab_muestra.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgConsulta As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtCodigoLector As System.Windows.Forms.TextBox
    Friend WithEvents tab_ppal As System.Windows.Forms.TabControl
    Friend WithEvents tab_requisicion As System.Windows.Forms.TabPage
    Friend WithEvents txtMulaDescargada As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMulaCargada As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tab_cargue As System.Windows.Forms.TabPage
    Friend WithEvents txtPeso As System.Windows.Forms.RichTextBox
    Friend WithEvents lblDescipcion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents btn_cargar As System.Windows.Forms.Button
    Friend WithEvents tab_muestra As System.Windows.Forms.TabPage
    Friend WithEvents txt_recalado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_traccion As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents txt_torsion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btn_next_requisicion As System.Windows.Forms.Button
    Friend WithEvents btn_terminar_muestra As System.Windows.Forms.Button
    Friend WithEvents txt_cal_final As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_consecutivo_muestra As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_traslado As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_cant_rollos As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lbl_movimientos As Label
    Friend WithEvents btn_transaccion As Button
    Friend WithEvents col_borrar As DataGridViewImageColumn
    Friend WithEvents col_muestra As DataGridViewImageColumn
    Friend WithEvents colConsecutivo As DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As DataGridViewTextBoxColumn
    Friend WithEvents colPeso As DataGridViewTextBoxColumn
    Friend WithEvents col_numero_imp As DataGridViewTextBoxColumn
    Friend WithEvents col_id_det As DataGridViewTextBoxColumn
    Friend WithEvents colNumRollo As DataGridViewTextBoxColumn
    Friend WithEvents col_costo_kilo As DataGridViewTextBoxColumn
    Friend WithEvents col_estado_muestra As DataGridViewTextBoxColumn
    Friend WithEvents col_nit_prov As DataGridViewTextBoxColumn
End Class
