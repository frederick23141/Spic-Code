<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuejaRec
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQuejaRec))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgQuejaRec = New System.Windows.Forms.DataGridView()
        Me.btnBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BtnGuardar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_doc = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtDiasResp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtFecIng = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_id_tratamiento_pqr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_tratamiento_pqr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_dias_tratamiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ciudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPqr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtResp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtInsatis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescProblema = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCausasDetect = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_flete = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNotaCredito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtFecCierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMcierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtAcciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtidResp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNitCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtIdInsaticfac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtIdPqr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNitResp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnCorreoResp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCorreoCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCorreoFacili = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarCampoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuditoriaDeEstadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjuntarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.btn_excel = New System.Windows.Forms.ToolStripSplitButton()
        Me.PQRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DíasTransitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_factura = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.cboCal = New System.Windows.Forms.MonthCalendar()
        Me.chkCerrado = New System.Windows.Forms.CheckBox()
        Me.chkAbierto = New System.Windows.Forms.CheckBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbo_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.cbo_fecha_ini = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_codigo_filtrar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.imagenEnviar = New System.Windows.Forms.PictureBox()
        Me.progBar = New System.Windows.Forms.ProgressBar()
        Me.group_estado = New System.Windows.Forms.GroupBox()
        Me.btn_ok_estado = New System.Windows.Forms.Button()
        Me.txt_observacion_estado = New System.Windows.Forms.RichTextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.dtgEstado = New System.Windows.Forms.DataGridView()
        Me.col_ok = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_cerrar_graf = New System.Windows.Forms.Button()
        Me.group_audit_estados = New System.Windows.Forms.GroupBox()
        Me.dtg_audit_estados = New System.Windows.Forms.DataGridView()
        Me.btn_anular = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_cerrar_audit_estados = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tab_ppal = New System.Windows.Forms.TabControl()
        Me.tab_quejas = New System.Windows.Forms.TabPage()
        Me.tab_transito = New System.Windows.Forms.TabPage()
        Me.chk_consol_estados = New System.Windows.Forms.CheckBox()
        Me.dtg_transito = New System.Windows.Forms.DataGridView()
        CType(Me.dtgQuejaRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imagenEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_estado.SuspendLayout()
        CType(Me.dtgEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_audit_estados.SuspendLayout()
        CType(Me.dtg_audit_estados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_ppal.SuspendLayout()
        Me.tab_quejas.SuspendLayout()
        Me.tab_transito.SuspendLayout()
        CType(Me.dtg_transito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgQuejaRec
        '
        Me.dtgQuejaRec.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtgQuejaRec.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgQuejaRec.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgQuejaRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgQuejaRec.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgQuejaRec.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgQuejaRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgQuejaRec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnBorrar, Me.BtnGuardar, Me.txtId, Me.col_doc, Me.txtDiasResp, Me.txtFecIng, Me.col_id_tratamiento_pqr, Me.col_tratamiento_pqr, Me.col_dias_tratamiento, Me.txtCliente, Me.colVend, Me.col_ciudad, Me.txtPqr, Me.txtCodigo, Me.txtDescCodigo, Me.txtResp, Me.txtInsatis, Me.txtDescProblema, Me.txtCausasDetect, Me.txtMonto, Me.col_flete, Me.txtNotaCredito, Me.txtFecCierre, Me.txtMcierre, Me.txtObservacion, Me.txtAcciones, Me.txtidResp, Me.txtNitCliente, Me.txtIdInsaticfac, Me.txtIdPqr, Me.txtNitResp})
        Me.dtgQuejaRec.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgQuejaRec.DefaultCellStyle = DataGridViewCellStyle7
        Me.dtgQuejaRec.Location = New System.Drawing.Point(3, 3)
        Me.dtgQuejaRec.Name = "dtgQuejaRec"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgQuejaRec.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgQuejaRec.RowHeadersVisible = False
        Me.dtgQuejaRec.Size = New System.Drawing.Size(602, 302)
        Me.dtgQuejaRec.TabIndex = 0
        '
        'btnBorrar
        '
        Me.btnBorrar.Frozen = True
        Me.btnBorrar.HeaderText = ""
        Me.btnBorrar.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.ReadOnly = True
        Me.btnBorrar.ToolTipText = "Eliminar"
        Me.btnBorrar.Width = 5
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Frozen = True
        Me.BtnGuardar.HeaderText = ""
        Me.BtnGuardar.Image = Global.Spic.My.Resources.Resources.save2
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.ReadOnly = True
        Me.BtnGuardar.ToolTipText = "Guardar"
        Me.BtnGuardar.Width = 5
        '
        'txtId
        '
        Me.txtId.Frozen = True
        Me.txtId.HeaderText = "Id"
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Width = 41
        '
        'col_doc
        '
        Me.col_doc.HeaderText = ""
        Me.col_doc.Image = Global.Spic.My.Resources.Resources.pdf2
        Me.col_doc.Name = "col_doc"
        Me.col_doc.Width = 5
        '
        'txtDiasResp
        '
        Me.txtDiasResp.HeaderText = "D_resp"
        Me.txtDiasResp.Name = "txtDiasResp"
        Me.txtDiasResp.ReadOnly = True
        Me.txtDiasResp.Width = 66
        '
        'txtFecIng
        '
        Me.txtFecIng.HeaderText = "Fec_ing"
        Me.txtFecIng.Name = "txtFecIng"
        Me.txtFecIng.ReadOnly = True
        Me.txtFecIng.Width = 70
        '
        'col_id_tratamiento_pqr
        '
        Me.col_id_tratamiento_pqr.HeaderText = "id_tratamiento"
        Me.col_id_tratamiento_pqr.Name = "col_id_tratamiento_pqr"
        Me.col_id_tratamiento_pqr.Visible = False
        Me.col_id_tratamiento_pqr.Width = 98
        '
        'col_tratamiento_pqr
        '
        Me.col_tratamiento_pqr.HeaderText = "Tratamiento pqr"
        Me.col_tratamiento_pqr.Name = "col_tratamiento_pqr"
        Me.col_tratamiento_pqr.ReadOnly = True
        Me.col_tratamiento_pqr.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_tratamiento_pqr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_tratamiento_pqr.Width = 78
        '
        'col_dias_tratamiento
        '
        Me.col_dias_tratamiento.HeaderText = "Días tratamiento"
        Me.col_dias_tratamiento.Name = "col_dias_tratamiento"
        Me.col_dias_tratamiento.ReadOnly = True
        Me.col_dias_tratamiento.Width = 101
        '
        'txtCliente
        '
        Me.txtCliente.HeaderText = "Cliente"
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.txtCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.txtCliente.Width = 45
        '
        'colVend
        '
        Me.colVend.HeaderText = "Vend"
        Me.colVend.Name = "colVend"
        Me.colVend.Width = 57
        '
        'col_ciudad
        '
        Me.col_ciudad.HeaderText = "Ciudad"
        Me.col_ciudad.Name = "col_ciudad"
        Me.col_ciudad.Width = 65
        '
        'txtPqr
        '
        Me.txtPqr.HeaderText = "Pqr"
        Me.txtPqr.Name = "txtPqr"
        Me.txtPqr.ReadOnly = True
        Me.txtPqr.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.txtPqr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.txtPqr.Width = 29
        '
        'txtCodigo
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.txtCodigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.txtCodigo.HeaderText = "Código"
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.txtCodigo.Width = 65
        '
        'txtDescCodigo
        '
        Me.txtDescCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.txtDescCodigo.DefaultCellStyle = DataGridViewCellStyle4
        Me.txtDescCodigo.HeaderText = "Desc_código"
        Me.txtDescCodigo.Name = "txtDescCodigo"
        Me.txtDescCodigo.ReadOnly = True
        Me.txtDescCodigo.Width = 320
        '
        'txtResp
        '
        Me.txtResp.HeaderText = "Responsable"
        Me.txtResp.Name = "txtResp"
        Me.txtResp.ReadOnly = True
        Me.txtResp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.txtResp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.txtResp.Width = 75
        '
        'txtInsatis
        '
        Me.txtInsatis.HeaderText = "Insatisfacción"
        Me.txtInsatis.Name = "txtInsatis"
        Me.txtInsatis.ReadOnly = True
        Me.txtInsatis.Width = 97
        '
        'txtDescProblema
        '
        Me.txtDescProblema.HeaderText = "Descripción_problema"
        Me.txtDescProblema.Name = "txtDescProblema"
        Me.txtDescProblema.Width = 137
        '
        'txtCausasDetect
        '
        Me.txtCausasDetect.HeaderText = "Causas_detectadas"
        Me.txtCausasDetect.Name = "txtCausasDetect"
        Me.txtCausasDetect.Width = 126
        '
        'txtMonto
        '
        DataGridViewCellStyle5.Format = "C0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.txtMonto.DefaultCellStyle = DataGridViewCellStyle5
        Me.txtMonto.HeaderText = "Monto"
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Width = 62
        '
        'col_flete
        '
        DataGridViewCellStyle6.Format = "C0"
        Me.col_flete.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_flete.HeaderText = "Flete"
        Me.col_flete.Name = "col_flete"
        Me.col_flete.Width = 55
        '
        'txtNotaCredito
        '
        Me.txtNotaCredito.HeaderText = "N_credito"
        Me.txtNotaCredito.Name = "txtNotaCredito"
        Me.txtNotaCredito.ReadOnly = True
        Me.txtNotaCredito.Width = 78
        '
        'txtFecCierre
        '
        Me.txtFecCierre.HeaderText = "F_cierre"
        Me.txtFecCierre.Name = "txtFecCierre"
        Me.txtFecCierre.ReadOnly = True
        Me.txtFecCierre.Width = 70
        '
        'txtMcierre
        '
        Me.txtMcierre.HeaderText = "Mot_cierre"
        Me.txtMcierre.Name = "txtMcierre"
        Me.txtMcierre.Width = 82
        '
        'txtObservacion
        '
        Me.txtObservacion.HeaderText = "Obervación"
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Width = 87
        '
        'txtAcciones
        '
        Me.txtAcciones.HeaderText = "Acciones_a_seguir"
        Me.txtAcciones.Name = "txtAcciones"
        Me.txtAcciones.Width = 122
        '
        'txtidResp
        '
        Me.txtidResp.HeaderText = "idResp"
        Me.txtidResp.Name = "txtidResp"
        Me.txtidResp.Visible = False
        Me.txtidResp.Width = 65
        '
        'txtNitCliente
        '
        Me.txtNitCliente.HeaderText = "nitCliente"
        Me.txtNitCliente.Name = "txtNitCliente"
        Me.txtNitCliente.Visible = False
        Me.txtNitCliente.Width = 75
        '
        'txtIdInsaticfac
        '
        Me.txtIdInsaticfac.HeaderText = "idInsatisfac"
        Me.txtIdInsaticfac.Name = "txtIdInsaticfac"
        Me.txtIdInsaticfac.Visible = False
        Me.txtIdInsaticfac.Width = 85
        '
        'txtIdPqr
        '
        Me.txtIdPqr.HeaderText = "idPqr"
        Me.txtIdPqr.Name = "txtIdPqr"
        Me.txtIdPqr.Visible = False
        Me.txtIdPqr.Width = 56
        '
        'txtNitResp
        '
        Me.txtNitResp.HeaderText = "nitResp"
        Me.txtNitResp.Name = "txtNitResp"
        Me.txtNitResp.Visible = False
        Me.txtNitResp.Width = 68
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCorreoResp, Me.btnCorreoCliente, Me.btnCorreoFacili, Me.btnCerrar, Me.EditarCampoToolStripMenuItem, Me.AuditoriaDeEstadosToolStripMenuItem, Me.AdjuntarToolStripMenuItem})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(325, 158)
        '
        'btnCorreoResp
        '
        Me.btnCorreoResp.Image = Global.Spic.My.Resources.Resources.enviar
        Me.btnCorreoResp.Name = "btnCorreoResp"
        Me.btnCorreoResp.Size = New System.Drawing.Size(324, 22)
        Me.btnCorreoResp.Text = "Enviar correo responsable "
        '
        'btnCorreoCliente
        '
        Me.btnCorreoCliente.Image = Global.Spic.My.Resources.Resources.enviar
        Me.btnCorreoCliente.Name = "btnCorreoCliente"
        Me.btnCorreoCliente.Size = New System.Drawing.Size(324, 22)
        Me.btnCorreoCliente.Text = "Enviar correo cliente"
        '
        'btnCorreoFacili
        '
        Me.btnCorreoFacili.Image = Global.Spic.My.Resources.Resources.enviar
        Me.btnCorreoFacili.Name = "btnCorreoFacili"
        Me.btnCorreoFacili.Size = New System.Drawing.Size(324, 22)
        Me.btnCorreoFacili.Text = "Enviar correo facilitador"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(324, 22)
        Me.btnCerrar.Text = "Cerrar caso"
        '
        'EditarCampoToolStripMenuItem
        '
        Me.EditarCampoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.EditarCampoToolStripMenuItem.Name = "EditarCampoToolStripMenuItem"
        Me.EditarCampoToolStripMenuItem.Size = New System.Drawing.Size(324, 22)
        Me.EditarCampoToolStripMenuItem.Text = "Editar campo"
        Me.EditarCampoToolStripMenuItem.Visible = False
        '
        'AuditoriaDeEstadosToolStripMenuItem
        '
        Me.AuditoriaDeEstadosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.est
        Me.AuditoriaDeEstadosToolStripMenuItem.Name = "AuditoriaDeEstadosToolStripMenuItem"
        Me.AuditoriaDeEstadosToolStripMenuItem.Size = New System.Drawing.Size(324, 22)
        Me.AuditoriaDeEstadosToolStripMenuItem.Text = "Auditoria de estados"
        '
        'AdjuntarToolStripMenuItem
        '
        Me.AdjuntarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.adjunto
        Me.AdjuntarToolStripMenuItem.Name = "AdjuntarToolStripMenuItem"
        Me.AdjuntarToolStripMenuItem.Size = New System.Drawing.Size(324, 22)
        Me.AdjuntarToolStripMenuItem.Text = "Adjuntar acciones preventivas y correctivas"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btnNuevo, Me.btnBuscar, Me.btnActualizar, Me.btn_excel, Me.btn_factura, Me.btnContCambios})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(615, 33)
        Me.Toolbar1.TabIndex = 1026
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Salir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(27, 30)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnNuevo.Size = New System.Drawing.Size(35, 30)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btnBuscar
        '
        Me.btnBuscar.AutoSize = False
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(35, 39)
        Me.btnBuscar.ToolTipText = "Consultar"
        '
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(27, 30)
        Me.btnActualizar.Text = "ToolStripButton3"
        Me.btnActualizar.ToolTipText = "Actualizar"
        '
        'btn_excel
        '
        Me.btn_excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_excel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PQRToolStripMenuItem, Me.DíasTransitoToolStripMenuItem})
        Me.btn_excel.Image = Global.Spic.My.Resources.Resources.icon_excel
        Me.btn_excel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(39, 30)
        Me.btn_excel.Text = "ToolStripButton4"
        Me.btn_excel.ToolTipText = "Enviar a excel"
        '
        'PQRToolStripMenuItem
        '
        Me.PQRToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.PQRToolStripMenuItem.Name = "PQRToolStripMenuItem"
        Me.PQRToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.PQRToolStripMenuItem.Text = "PQR"
        '
        'DíasTransitoToolStripMenuItem
        '
        Me.DíasTransitoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.DíasTransitoToolStripMenuItem.Name = "DíasTransitoToolStripMenuItem"
        Me.DíasTransitoToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.DíasTransitoToolStripMenuItem.Text = "Días transito"
        '
        'btn_factura
        '
        Me.btn_factura.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_factura.Image = Global.Spic.My.Resources.Resources.ficha
        Me.btn_factura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_factura.Name = "btn_factura"
        Me.btn_factura.Size = New System.Drawing.Size(27, 30)
        Me.btn_factura.Text = "Factura"
        '
        'btnContCambios
        '
        Me.btnContCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContCambios.Image = Global.Spic.My.Resources.Resources.info1
        Me.btnContCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContCambios.Name = "btnContCambios"
        Me.btnContCambios.Size = New System.Drawing.Size(27, 30)
        Me.btnContCambios.Text = "Control de cambios"
        '
        'cboCal
        '
        Me.cboCal.Location = New System.Drawing.Point(354, 77)
        Me.cboCal.MaxDate = New Date(2100, 8, 1, 0, 0, 0, 0)
        Me.cboCal.Name = "cboCal"
        Me.cboCal.TabIndex = 1056
        Me.cboCal.Visible = False
        '
        'chkCerrado
        '
        Me.chkCerrado.AutoSize = True
        Me.chkCerrado.Location = New System.Drawing.Point(6, 46)
        Me.chkCerrado.Name = "chkCerrado"
        Me.chkCerrado.Size = New System.Drawing.Size(68, 17)
        Me.chkCerrado.TabIndex = 1057
        Me.chkCerrado.Text = "Cerrados"
        Me.chkCerrado.UseVisualStyleBackColor = True
        '
        'chkAbierto
        '
        Me.chkAbierto.AutoSize = True
        Me.chkAbierto.Location = New System.Drawing.Point(6, 75)
        Me.chkAbierto.Name = "chkAbierto"
        Me.chkAbierto.Size = New System.Drawing.Size(64, 17)
        Me.chkAbierto.TabIndex = 1058
        Me.chkAbierto.Text = "Abiertos"
        Me.chkAbierto.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(81, 12)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(146, 20)
        Me.txtBuscar.TabIndex = 1060
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(69, 13)
        Me.label1.TabIndex = 1061
        Me.label1.Text = "Consecutivo:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_fin)
        Me.GroupBox3.Controls.Add(Me.cbo_fecha_ini)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(461, 36)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(151, 65)
        Me.GroupBox3.TabIndex = 1062
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rango de fecha"
        '
        'cbo_fecha_fin
        '
        Me.cbo_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_fin.Location = New System.Drawing.Point(55, 40)
        Me.cbo_fecha_fin.Name = "cbo_fecha_fin"
        Me.cbo_fecha_fin.Size = New System.Drawing.Size(86, 20)
        Me.cbo_fecha_fin.TabIndex = 1068
        '
        'cbo_fecha_ini
        '
        Me.cbo_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_fecha_ini.Location = New System.Drawing.Point(55, 16)
        Me.cbo_fecha_ini.Name = "cbo_fecha_ini"
        Me.cbo_fecha_ini.Size = New System.Drawing.Size(86, 20)
        Me.cbo_fecha_ini.TabIndex = 1067
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1050
        Me.Label2.Text = "Fec fin:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 1048
        Me.Label3.Text = "Fec ini:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_codigo_filtrar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNit)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNombres)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBuscar)
        Me.GroupBox1.Controls.Add(Me.label1)
        Me.GroupBox1.Location = New System.Drawing.Point(68, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 65)
        Me.GroupBox1.TabIndex = 1063
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consultar"
        '
        'txt_codigo_filtrar
        '
        Me.txt_codigo_filtrar.Location = New System.Drawing.Point(276, 39)
        Me.txt_codigo_filtrar.Name = "txt_codigo_filtrar"
        Me.txt_codigo_filtrar.Size = New System.Drawing.Size(110, 20)
        Me.txt_codigo_filtrar.TabIndex = 1067
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(233, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 1068
        Me.Label5.Text = "Código"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(276, 12)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(110, 20)
        Me.txtNit.TabIndex = 1065
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(233, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 1066
        Me.Label6.Text = "Nit:"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(81, 39)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(146, 20)
        Me.txtNombres.TabIndex = 1062
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 1063
        Me.Label4.Text = "Nombres:"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.ToolTipText = "Eliminar"
        Me.DataGridViewImageColumn1.Width = 21
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.Frozen = True
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = Global.Spic.My.Resources.Resources._Save
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.ToolTipText = "Guardar"
        Me.DataGridViewImageColumn2.Width = 21
        '
        'imagenEnviar
        '
        Me.imagenEnviar.Image = Global.Spic.My.Resources.Resources.enviando1
        Me.imagenEnviar.Location = New System.Drawing.Point(173, 77)
        Me.imagenEnviar.Name = "imagenEnviar"
        Me.imagenEnviar.Size = New System.Drawing.Size(279, 220)
        Me.imagenEnviar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imagenEnviar.TabIndex = 1059
        Me.imagenEnviar.TabStop = False
        Me.imagenEnviar.Visible = False
        '
        'progBar
        '
        Me.progBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progBar.Location = New System.Drawing.Point(3, 306)
        Me.progBar.Name = "progBar"
        Me.progBar.Size = New System.Drawing.Size(602, 15)
        Me.progBar.TabIndex = 1064
        '
        'group_estado
        '
        Me.group_estado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.group_estado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_estado.Controls.Add(Me.btn_ok_estado)
        Me.group_estado.Controls.Add(Me.txt_observacion_estado)
        Me.group_estado.Controls.Add(Me.Label29)
        Me.group_estado.Controls.Add(Me.dtgEstado)
        Me.group_estado.Controls.Add(Me.btn_cerrar_graf)
        Me.group_estado.Location = New System.Drawing.Point(113, 31)
        Me.group_estado.Name = "group_estado"
        Me.group_estado.Size = New System.Drawing.Size(263, 284)
        Me.group_estado.TabIndex = 1106
        Me.group_estado.TabStop = False
        Me.group_estado.Text = "Seleccione estado de PQR"
        Me.group_estado.Visible = False
        '
        'btn_ok_estado
        '
        Me.btn_ok_estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ok_estado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ok_estado.Location = New System.Drawing.Point(89, 259)
        Me.btn_ok_estado.Name = "btn_ok_estado"
        Me.btn_ok_estado.Size = New System.Drawing.Size(75, 23)
        Me.btn_ok_estado.TabIndex = 1122
        Me.btn_ok_estado.Text = "Terminar"
        Me.btn_ok_estado.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btn_ok_estado.UseVisualStyleBackColor = True
        '
        'txt_observacion_estado
        '
        Me.txt_observacion_estado.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_observacion_estado.Location = New System.Drawing.Point(9, 140)
        Me.txt_observacion_estado.Name = "txt_observacion_estado"
        Me.txt_observacion_estado.Size = New System.Drawing.Size(248, 118)
        Me.txt_observacion_estado.TabIndex = 1121
        Me.txt_observacion_estado.Text = ""
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 124)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(78, 13)
        Me.Label29.TabIndex = 1120
        Me.Label29.Text = "Observaciones"
        '
        'dtgEstado
        '
        Me.dtgEstado.AllowUserToAddRows = False
        Me.dtgEstado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgEstado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgEstado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgEstado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_ok})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "0"
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgEstado.DefaultCellStyle = DataGridViewCellStyle9
        Me.dtgEstado.Location = New System.Drawing.Point(6, 28)
        Me.dtgEstado.Name = "dtgEstado"
        Me.dtgEstado.ReadOnly = True
        Me.dtgEstado.RowHeadersVisible = False
        Me.dtgEstado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgEstado.Size = New System.Drawing.Size(251, 93)
        Me.dtgEstado.TabIndex = 1087
        '
        'col_ok
        '
        Me.col_ok.Frozen = True
        Me.col_ok.HeaderText = ""
        Me.col_ok.Name = "col_ok"
        Me.col_ok.ReadOnly = True
        Me.col_ok.Visible = False
        Me.col_ok.Width = 5
        '
        'btn_cerrar_graf
        '
        Me.btn_cerrar_graf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_graf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_graf.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_graf.Location = New System.Drawing.Point(239, 1)
        Me.btn_cerrar_graf.Name = "btn_cerrar_graf"
        Me.btn_cerrar_graf.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_graf.TabIndex = 1088
        Me.btn_cerrar_graf.Text = "X"
        Me.btn_cerrar_graf.UseVisualStyleBackColor = True
        '
        'group_audit_estados
        '
        Me.group_audit_estados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.group_audit_estados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.group_audit_estados.Controls.Add(Me.dtg_audit_estados)
        Me.group_audit_estados.Controls.Add(Me.btn_cerrar_audit_estados)
        Me.group_audit_estados.Location = New System.Drawing.Point(28, 96)
        Me.group_audit_estados.Name = "group_audit_estados"
        Me.group_audit_estados.Size = New System.Drawing.Size(441, 219)
        Me.group_audit_estados.TabIndex = 1123
        Me.group_audit_estados.TabStop = False
        Me.group_audit_estados.Text = "Auditoria de estados"
        Me.group_audit_estados.Visible = False
        '
        'dtg_audit_estados
        '
        Me.dtg_audit_estados.AllowUserToAddRows = False
        Me.dtg_audit_estados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_audit_estados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_audit_estados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_audit_estados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_audit_estados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btn_anular})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = "0"
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_audit_estados.DefaultCellStyle = DataGridViewCellStyle10
        Me.dtg_audit_estados.Location = New System.Drawing.Point(6, 28)
        Me.dtg_audit_estados.Name = "dtg_audit_estados"
        Me.dtg_audit_estados.ReadOnly = True
        Me.dtg_audit_estados.RowHeadersVisible = False
        Me.dtg_audit_estados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_audit_estados.Size = New System.Drawing.Size(429, 185)
        Me.dtg_audit_estados.TabIndex = 1087
        '
        'btn_anular
        '
        Me.btn_anular.HeaderText = ""
        Me.btn_anular.Image = Global.Spic.My.Resources.Resources.x
        Me.btn_anular.Name = "btn_anular"
        Me.btn_anular.ReadOnly = True
        Me.btn_anular.Width = 5
        '
        'btn_cerrar_audit_estados
        '
        Me.btn_cerrar_audit_estados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_audit_estados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_audit_estados.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_audit_estados.Location = New System.Drawing.Point(417, 1)
        Me.btn_cerrar_audit_estados.Name = "btn_cerrar_audit_estados"
        Me.btn_cerrar_audit_estados.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_audit_estados.TabIndex = 1088
        Me.btn_cerrar_audit_estados.Text = "X"
        Me.btn_cerrar_audit_estados.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'tab_ppal
        '
        Me.tab_ppal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tab_ppal.Controls.Add(Me.tab_quejas)
        Me.tab_ppal.Controls.Add(Me.tab_transito)
        Me.tab_ppal.Location = New System.Drawing.Point(0, 107)
        Me.tab_ppal.Name = "tab_ppal"
        Me.tab_ppal.SelectedIndex = 0
        Me.tab_ppal.Size = New System.Drawing.Size(615, 347)
        Me.tab_ppal.TabIndex = 1124
        '
        'tab_quejas
        '
        Me.tab_quejas.Controls.Add(Me.group_estado)
        Me.tab_quejas.Controls.Add(Me.group_audit_estados)
        Me.tab_quejas.Controls.Add(Me.imagenEnviar)
        Me.tab_quejas.Controls.Add(Me.cboCal)
        Me.tab_quejas.Controls.Add(Me.progBar)
        Me.tab_quejas.Controls.Add(Me.dtgQuejaRec)
        Me.tab_quejas.Location = New System.Drawing.Point(4, 22)
        Me.tab_quejas.Name = "tab_quejas"
        Me.tab_quejas.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_quejas.Size = New System.Drawing.Size(607, 321)
        Me.tab_quejas.TabIndex = 0
        Me.tab_quejas.Text = "Gestionar quejas y reclamos"
        Me.tab_quejas.UseVisualStyleBackColor = True
        '
        'tab_transito
        '
        Me.tab_transito.Controls.Add(Me.chk_consol_estados)
        Me.tab_transito.Controls.Add(Me.dtg_transito)
        Me.tab_transito.Location = New System.Drawing.Point(4, 22)
        Me.tab_transito.Name = "tab_transito"
        Me.tab_transito.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_transito.Size = New System.Drawing.Size(607, 321)
        Me.tab_transito.TabIndex = 1
        Me.tab_transito.Text = "tiempos de transito PQR "
        Me.tab_transito.UseVisualStyleBackColor = True
        '
        'chk_consol_estados
        '
        Me.chk_consol_estados.AutoSize = True
        Me.chk_consol_estados.Location = New System.Drawing.Point(3, 3)
        Me.chk_consol_estados.Name = "chk_consol_estados"
        Me.chk_consol_estados.Size = New System.Drawing.Size(115, 17)
        Me.chk_consol_estados.TabIndex = 1125
        Me.chk_consol_estados.Text = "Consolidar estados"
        Me.chk_consol_estados.UseVisualStyleBackColor = True
        '
        'dtg_transito
        '
        Me.dtg_transito.AllowUserToAddRows = False
        Me.dtg_transito.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_transito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_transito.Location = New System.Drawing.Point(0, 24)
        Me.dtg_transito.Name = "dtg_transito"
        Me.dtg_transito.ReadOnly = True
        Me.dtg_transito.Size = New System.Drawing.Size(607, 297)
        Me.dtg_transito.TabIndex = 0
        '
        'FrmQuejaRec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 466)
        Me.Controls.Add(Me.tab_ppal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkCerrado)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkAbierto)
        Me.Name = "FrmQuejaRec"
        Me.Text = "Quejas y reclamos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtgQuejaRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imagenEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_estado.ResumeLayout(False)
        Me.group_estado.PerformLayout()
        CType(Me.dtgEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_audit_estados.ResumeLayout(False)
        CType(Me.dtg_audit_estados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_ppal.ResumeLayout(False)
        Me.tab_quejas.ResumeLayout(False)
        Me.tab_transito.ResumeLayout(False)
        Me.tab_transito.PerformLayout()
        CType(Me.dtg_transito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgQuejaRec As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnCorreoResp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCorreoCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkCerrado As System.Windows.Forms.CheckBox
    Friend WithEvents chkAbierto As System.Windows.Forms.CheckBox
    Friend WithEvents imagenEnviar As System.Windows.Forms.PictureBox
    Friend WithEvents btnCorreoFacili As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents EditarCampoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_fecha_ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents progBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents group_estado As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ok_estado As System.Windows.Forms.Button
    Friend WithEvents txt_observacion_estado As System.Windows.Forms.RichTextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents dtgEstado As System.Windows.Forms.DataGridView
    Friend WithEvents col_ok As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents btn_cerrar_graf As System.Windows.Forms.Button
    Friend WithEvents AuditoriaDeEstadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents group_audit_estados As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_audit_estados As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cerrar_audit_estados As System.Windows.Forms.Button
    Friend WithEvents AdjuntarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBorrar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents BtnGuardar As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_doc As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtDiasResp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtFecIng As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_id_tratamiento_pqr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tratamiento_pqr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_dias_tratamiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_ciudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPqr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDescCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtResp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtInsatis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDescProblema As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCausasDetect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_flete As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNotaCredito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtFecCierre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMcierre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtAcciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtidResp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNitCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtIdInsaticfac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtIdPqr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNitResp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_anular As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents tab_ppal As System.Windows.Forms.TabControl
    Friend WithEvents tab_quejas As System.Windows.Forms.TabPage
    Friend WithEvents tab_transito As System.Windows.Forms.TabPage
    Friend WithEvents dtg_transito As System.Windows.Forms.DataGridView
    Friend WithEvents chk_consol_estados As System.Windows.Forms.CheckBox
    Friend WithEvents btn_excel As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PQRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DíasTransitoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_factura As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_codigo_filtrar As TextBox
    Friend WithEvents Label5 As Label
End Class
