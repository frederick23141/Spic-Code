<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnalisisPedido
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAnalisisPedido))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.totKilos = New System.Windows.Forms.Label()
        Me.txtTotKilosBueno = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBueVal = New System.Windows.Forms.TextBox()
        Me.txtValBloq = New System.Windows.Forms.TextBox()
        Me.txtKilBloq = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotKilo = New System.Windows.Forms.TextBox()
        Me.txtTotVal = New System.Windows.Forms.TextBox()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemAutorizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemMasInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarNotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModPed = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.txtValtotbusq = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCriterio = New System.Windows.Forms.TextBox()
        Me.btnBuscarPedido = New System.Windows.Forms.Button()
        Me.tblCupCredit = New System.Windows.Forms.TabPage()
        Me.imgProc4 = New System.Windows.Forms.PictureBox()
        Me.dtgCupCred = New System.Windows.Forms.DataGridView()
        Me.tblDocVenc = New System.Windows.Forms.TabPage()
        Me.imgProc3 = New System.Windows.Forms.PictureBox()
        Me.dtgDocVen = New System.Windows.Forms.DataGridView()
        Me.tblBloq = New System.Windows.Forms.TabPage()
        Me.imgProc2 = New System.Windows.Forms.PictureBox()
        Me.dtgBloq = New System.Windows.Forms.DataGridView()
        Me.tblPenBuenos = New System.Windows.Forms.TabPage()
        Me.imgProc = New System.Windows.Forms.PictureBox()
        Me.dtgPenBuenos = New System.Windows.Forms.DataGridView()
        Me.tbl_datos = New System.Windows.Forms.TabControl()
        Me.tbla_no_reflej = New System.Windows.Forms.TabPage()
        Me.imgProc5 = New System.Windows.Forms.PictureBox()
        Me.dtg_no_reflejados = New System.Windows.Forms.DataGridView()
        Me.menStripNoRelej = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.enviarMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.autoMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.masInfoMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtg_val_menor = New System.Windows.Forms.DataGridView()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_exportar = New System.Windows.Forms.ToolStripSplitButton()
        Me.tool_exp_buen = New System.Windows.Forms.ToolStripMenuItem()
        Me.tool_exp_bloq = New System.Windows.Forms.ToolStripMenuItem()
        Me.tool_exp_venc = New System.Windows.Forms.ToolStripMenuItem()
        Me.tool_exp_cupo = New System.Windows.Forms.ToolStripMenuItem()
        Me.tool_exp_noRef = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAyuda = New System.Windows.Forms.ToolStripButton()
        Me.btnContCambios = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtKilCupo = New System.Windows.Forms.TextBox()
        Me.txtValCupo = New System.Windows.Forms.TextBox()
        Me.txtKilDoc = New System.Windows.Forms.TextBox()
        Me.txtValDoc = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_kil_no_reflej = New System.Windows.Forms.TextBox()
        Me.txt_val_no_reflej = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.menStripDtg.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tblCupCredit.SuspendLayout()
        CType(Me.imgProc4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgCupCred, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblDocVenc.SuspendLayout()
        CType(Me.imgProc3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgDocVen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblBloq.SuspendLayout()
        CType(Me.imgProc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgBloq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblPenBuenos.SuspendLayout()
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgPenBuenos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbl_datos.SuspendLayout()
        Me.tbla_no_reflej.SuspendLayout()
        CType(Me.imgProc5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_no_reflejados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripNoRelej.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtg_val_menor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(71, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "-"
        '
        'txtMax
        '
        Me.txtMax.Location = New System.Drawing.Point(88, 40)
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(65, 21)
        Me.txtMax.TabIndex = 2
        '
        'txtMin
        '
        Me.txtMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtMin.Location = New System.Drawing.Point(5, 39)
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(65, 21)
        Me.txtMin.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMax)
        Me.GroupBox1.Controls.Add(Me.txtMin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 108)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Número vendedor"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.Location = New System.Drawing.Point(29, 68)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(98, 24)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "Consultar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.UseMnemonic = False
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(113, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "1099"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "1001"
        '
        'totKilos
        '
        Me.totKilos.AutoSize = True
        Me.totKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totKilos.Location = New System.Drawing.Point(290, 26)
        Me.totKilos.Name = "totKilos"
        Me.totKilos.Size = New System.Drawing.Size(43, 15)
        Me.totKilos.TabIndex = 6
        Me.totKilos.Text = "Kilos:"
        '
        'txtTotKilosBueno
        '
        Me.txtTotKilosBueno.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTotKilosBueno.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotKilosBueno.Location = New System.Drawing.Point(274, 46)
        Me.txtTotKilosBueno.Name = "txtTotKilosBueno"
        Me.txtTotKilosBueno.Size = New System.Drawing.Size(100, 13)
        Me.txtTotKilosBueno.TabIndex = 7
        Me.txtTotKilosBueno.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(385, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Valor total:"
        '
        'txtBueVal
        '
        Me.txtBueVal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtBueVal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBueVal.Location = New System.Drawing.Point(388, 45)
        Me.txtBueVal.Name = "txtBueVal"
        Me.txtBueVal.Size = New System.Drawing.Size(100, 13)
        Me.txtBueVal.TabIndex = 9
        Me.txtBueVal.Text = "0"
        '
        'txtValBloq
        '
        Me.txtValBloq.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtValBloq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValBloq.Location = New System.Drawing.Point(388, 63)
        Me.txtValBloq.Name = "txtValBloq"
        Me.txtValBloq.Size = New System.Drawing.Size(100, 13)
        Me.txtValBloq.TabIndex = 21
        Me.txtValBloq.Text = "0"
        '
        'txtKilBloq
        '
        Me.txtKilBloq.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtKilBloq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKilBloq.Location = New System.Drawing.Point(274, 63)
        Me.txtKilBloq.Name = "txtKilBloq"
        Me.txtKilBloq.Size = New System.Drawing.Size(100, 13)
        Me.txtKilBloq.TabIndex = 20
        Me.txtKilBloq.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(178, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 15)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Bloqueados:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(178, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 15)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Buenos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(217, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Total:"
        '
        'txtTotKilo
        '
        Me.txtTotKilo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTotKilo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotKilo.Location = New System.Drawing.Point(273, 99)
        Me.txtTotKilo.Name = "txtTotKilo"
        Me.txtTotKilo.Size = New System.Drawing.Size(100, 20)
        Me.txtTotKilo.TabIndex = 27
        Me.txtTotKilo.Text = "0"
        '
        'txtTotVal
        '
        Me.txtTotVal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTotVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotVal.Location = New System.Drawing.Point(387, 99)
        Me.txtTotVal.Name = "txtTotVal"
        Me.txtTotVal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotVal.TabIndex = 28
        Me.txtTotVal.Text = "0"
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemMail, Me.itemAutorizar, Me.itemMasInfo, Me.VerStockToolStripMenuItem, Me.CambiarNotaToolStripMenuItem, Me.btnModPed, Me.AnularPedidoToolStripMenuItem})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(215, 158)
        '
        'itemMail
        '
        Me.itemMail.Image = Global.Spic.My.Resources.Resources.enviar
        Me.itemMail.Name = "itemMail"
        Me.itemMail.Size = New System.Drawing.Size(214, 22)
        Me.itemMail.Text = "Enviar para autorizaciòn "
        '
        'itemAutorizar
        '
        Me.itemAutorizar.Image = Global.Spic.My.Resources.Resources.ok3
        Me.itemAutorizar.Name = "itemAutorizar"
        Me.itemAutorizar.Size = New System.Drawing.Size(214, 22)
        Me.itemAutorizar.Text = "Autorizar"
        '
        'itemMasInfo
        '
        Me.itemMasInfo.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.itemMasInfo.Name = "itemMasInfo"
        Me.itemMasInfo.Size = New System.Drawing.Size(214, 22)
        Me.itemMasInfo.Text = "Ver mas info"
        '
        'VerStockToolStripMenuItem
        '
        Me.VerStockToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.VerStockToolStripMenuItem.Name = "VerStockToolStripMenuItem"
        Me.VerStockToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.VerStockToolStripMenuItem.Text = "Ver stock"
        '
        'CambiarNotaToolStripMenuItem
        '
        Me.CambiarNotaToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.CambiarNotaToolStripMenuItem.Name = "CambiarNotaToolStripMenuItem"
        Me.CambiarNotaToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.CambiarNotaToolStripMenuItem.Text = "Modificar Nota"
        '
        'btnModPed
        '
        Me.btnModPed.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btnModPed.Name = "btnModPed"
        Me.btnModPed.Size = New System.Drawing.Size(214, 22)
        Me.btnModPed.Text = "Modificar Pedido"
        '
        'AnularPedidoToolStripMenuItem
        '
        Me.AnularPedidoToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.x
        Me.AnularPedidoToolStripMenuItem.Name = "AnularPedidoToolStripMenuItem"
        Me.AnularPedidoToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.AnularPedidoToolStripMenuItem.Text = "Anular pedido"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.lblIva)
        Me.GroupBox3.Controls.Add(Me.txtValtotbusq)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtCriterio)
        Me.GroupBox3.Controls.Add(Me.btnBuscarPedido)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(494, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 108)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar pedido"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(2, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "no reflej"
        '
        'lblIva
        '
        Me.lblIva.AutoSize = True
        Me.lblIva.BackColor = System.Drawing.Color.Transparent
        Me.lblIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva.Location = New System.Drawing.Point(26, 92)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(45, 13)
        Me.lblIva.TabIndex = 35
        Me.lblIva.Text = "con iva "
        '
        'txtValtotbusq
        '
        Me.txtValtotbusq.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtValtotbusq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValtotbusq.Location = New System.Drawing.Point(115, 71)
        Me.txtValtotbusq.Name = "txtValtotbusq"
        Me.txtValtotbusq.Size = New System.Drawing.Size(100, 13)
        Me.txtValtotbusq.TabIndex = 33
        Me.txtValtotbusq.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(26, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Val tot pend:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Nùmero"
        '
        'txtCriterio
        '
        Me.txtCriterio.Location = New System.Drawing.Point(59, 30)
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.Size = New System.Drawing.Size(91, 20)
        Me.txtCriterio.TabIndex = 2
        '
        'btnBuscarPedido
        '
        Me.btnBuscarPedido.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPedido.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btnBuscarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarPedido.Location = New System.Drawing.Point(156, 28)
        Me.btnBuscarPedido.Name = "btnBuscarPedido"
        Me.btnBuscarPedido.Size = New System.Drawing.Size(76, 23)
        Me.btnBuscarPedido.TabIndex = 0
        Me.btnBuscarPedido.Text = "Buscar"
        Me.btnBuscarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarPedido.UseVisualStyleBackColor = True
        '
        'tblCupCredit
        '
        Me.tblCupCredit.Controls.Add(Me.imgProc4)
        Me.tblCupCredit.Controls.Add(Me.dtgCupCred)
        Me.tblCupCredit.Location = New System.Drawing.Point(4, 25)
        Me.tblCupCredit.Name = "tblCupCredit"
        Me.tblCupCredit.Size = New System.Drawing.Size(900, 380)
        Me.tblCupCredit.TabIndex = 3
        Me.tblCupCredit.Text = "Pend sin cupo"
        Me.tblCupCredit.UseVisualStyleBackColor = True
        '
        'imgProc4
        '
        Me.imgProc4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc4.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc4.Location = New System.Drawing.Point(188, 28)
        Me.imgProc4.Name = "imgProc4"
        Me.imgProc4.Size = New System.Drawing.Size(610, 264)
        Me.imgProc4.TabIndex = 118
        Me.imgProc4.TabStop = False
        '
        'dtgCupCred
        '
        Me.dtgCupCred.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dtgCupCred.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgCupCred.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgCupCred.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgCupCred.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgCupCred.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCupCred.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgCupCred.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgCupCred.Location = New System.Drawing.Point(3, 11)
        Me.dtgCupCred.Name = "dtgCupCred"
        Me.dtgCupCred.ReadOnly = True
        Me.dtgCupCred.RowHeadersVisible = False
        Me.dtgCupCred.Size = New System.Drawing.Size(890, 366)
        Me.dtgCupCred.TabIndex = 1
        '
        'tblDocVenc
        '
        Me.tblDocVenc.Controls.Add(Me.imgProc3)
        Me.tblDocVenc.Controls.Add(Me.dtgDocVen)
        Me.tblDocVenc.Location = New System.Drawing.Point(4, 25)
        Me.tblDocVenc.Name = "tblDocVenc"
        Me.tblDocVenc.Size = New System.Drawing.Size(900, 380)
        Me.tblDocVenc.TabIndex = 2
        Me.tblDocVenc.Text = "Pend documentos vencidos"
        Me.tblDocVenc.UseVisualStyleBackColor = True
        '
        'imgProc3
        '
        Me.imgProc3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc3.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc3.Location = New System.Drawing.Point(188, 21)
        Me.imgProc3.Name = "imgProc3"
        Me.imgProc3.Size = New System.Drawing.Size(610, 265)
        Me.imgProc3.TabIndex = 118
        Me.imgProc3.TabStop = False
        '
        'dtgDocVen
        '
        Me.dtgDocVen.AllowUserToAddRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray
        Me.dtgDocVen.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgDocVen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDocVen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDocVen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgDocVen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDocVen.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDocVen.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgDocVen.Location = New System.Drawing.Point(3, 11)
        Me.dtgDocVen.Name = "dtgDocVen"
        Me.dtgDocVen.ReadOnly = True
        Me.dtgDocVen.RowHeadersVisible = False
        Me.dtgDocVen.Size = New System.Drawing.Size(889, 365)
        Me.dtgDocVen.TabIndex = 1
        '
        'tblBloq
        '
        Me.tblBloq.Controls.Add(Me.imgProc2)
        Me.tblBloq.Controls.Add(Me.dtgBloq)
        Me.tblBloq.Location = New System.Drawing.Point(4, 25)
        Me.tblBloq.Name = "tblBloq"
        Me.tblBloq.Padding = New System.Windows.Forms.Padding(3)
        Me.tblBloq.Size = New System.Drawing.Size(900, 380)
        Me.tblBloq.TabIndex = 1
        Me.tblBloq.Text = "Pend bloqueados"
        Me.tblBloq.UseVisualStyleBackColor = True
        '
        'imgProc2
        '
        Me.imgProc2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc2.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc2.Location = New System.Drawing.Point(188, 23)
        Me.imgProc2.Name = "imgProc2"
        Me.imgProc2.Size = New System.Drawing.Size(610, 250)
        Me.imgProc2.TabIndex = 118
        Me.imgProc2.TabStop = False
        '
        'dtgBloq
        '
        Me.dtgBloq.AllowUserToAddRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        Me.dtgBloq.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgBloq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgBloq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgBloq.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgBloq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgBloq.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgBloq.DefaultCellStyle = DataGridViewCellStyle9
        Me.dtgBloq.Location = New System.Drawing.Point(6, 11)
        Me.dtgBloq.Name = "dtgBloq"
        Me.dtgBloq.ReadOnly = True
        Me.dtgBloq.RowHeadersVisible = False
        Me.dtgBloq.Size = New System.Drawing.Size(888, 363)
        Me.dtgBloq.TabIndex = 1
        '
        'tblPenBuenos
        '
        Me.tblPenBuenos.Controls.Add(Me.imgProc)
        Me.tblPenBuenos.Controls.Add(Me.dtgPenBuenos)
        Me.tblPenBuenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tblPenBuenos.Location = New System.Drawing.Point(4, 25)
        Me.tblPenBuenos.Name = "tblPenBuenos"
        Me.tblPenBuenos.Padding = New System.Windows.Forms.Padding(3)
        Me.tblPenBuenos.Size = New System.Drawing.Size(900, 380)
        Me.tblPenBuenos.TabIndex = 0
        Me.tblPenBuenos.Text = "Pend buenos"
        Me.tblPenBuenos.UseVisualStyleBackColor = True
        '
        'imgProc
        '
        Me.imgProc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgProc.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc.Location = New System.Drawing.Point(185, 8)
        Me.imgProc.Name = "imgProc"
        Me.imgProc.Size = New System.Drawing.Size(610, 277)
        Me.imgProc.TabIndex = 117
        Me.imgProc.TabStop = False
        '
        'dtgPenBuenos
        '
        Me.dtgPenBuenos.AllowUserToAddRows = False
        Me.dtgPenBuenos.AllowUserToOrderColumns = True
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray
        Me.dtgPenBuenos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dtgPenBuenos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgPenBuenos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgPenBuenos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dtgPenBuenos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgPenBuenos.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = Nothing
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgPenBuenos.DefaultCellStyle = DataGridViewCellStyle12
        Me.dtgPenBuenos.Location = New System.Drawing.Point(6, 6)
        Me.dtgPenBuenos.Name = "dtgPenBuenos"
        Me.dtgPenBuenos.ReadOnly = True
        Me.dtgPenBuenos.RowHeadersVisible = False
        Me.dtgPenBuenos.Size = New System.Drawing.Size(888, 370)
        Me.dtgPenBuenos.TabIndex = 0
        '
        'tbl_datos
        '
        Me.tbl_datos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbl_datos.Controls.Add(Me.tblPenBuenos)
        Me.tbl_datos.Controls.Add(Me.tblBloq)
        Me.tbl_datos.Controls.Add(Me.tblDocVenc)
        Me.tbl_datos.Controls.Add(Me.tblCupCredit)
        Me.tbl_datos.Controls.Add(Me.tbla_no_reflej)
        Me.tbl_datos.Controls.Add(Me.TabPage1)
        Me.tbl_datos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbl_datos.Location = New System.Drawing.Point(10, 151)
        Me.tbl_datos.Name = "tbl_datos"
        Me.tbl_datos.SelectedIndex = 0
        Me.tbl_datos.Size = New System.Drawing.Size(908, 409)
        Me.tbl_datos.TabIndex = 5
        '
        'tbla_no_reflej
        '
        Me.tbla_no_reflej.Controls.Add(Me.imgProc5)
        Me.tbla_no_reflej.Controls.Add(Me.dtg_no_reflejados)
        Me.tbla_no_reflej.Location = New System.Drawing.Point(4, 25)
        Me.tbla_no_reflej.Name = "tbla_no_reflej"
        Me.tbla_no_reflej.Size = New System.Drawing.Size(900, 380)
        Me.tbla_no_reflej.TabIndex = 4
        Me.tbla_no_reflej.Text = "Pend no reflejados"
        Me.tbla_no_reflej.UseVisualStyleBackColor = True
        '
        'imgProc5
        '
        Me.imgProc5.Image = Global.Spic.My.Resources.Resources.procesando
        Me.imgProc5.Location = New System.Drawing.Point(188, 29)
        Me.imgProc5.Name = "imgProc5"
        Me.imgProc5.Size = New System.Drawing.Size(610, 266)
        Me.imgProc5.TabIndex = 119
        Me.imgProc5.TabStop = False
        '
        'dtg_no_reflejados
        '
        Me.dtg_no_reflejados.AllowUserToAddRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_no_reflejados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dtg_no_reflejados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_no_reflejados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_no_reflejados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dtg_no_reflejados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_no_reflejados.ContextMenuStrip = Me.menStripNoRelej
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.Format = "N0"
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_no_reflejados.DefaultCellStyle = DataGridViewCellStyle15
        Me.dtg_no_reflejados.Location = New System.Drawing.Point(6, 7)
        Me.dtg_no_reflejados.Name = "dtg_no_reflejados"
        Me.dtg_no_reflejados.ReadOnly = True
        Me.dtg_no_reflejados.RowHeadersVisible = False
        Me.dtg_no_reflejados.Size = New System.Drawing.Size(889, 366)
        Me.dtg_no_reflejados.TabIndex = 2
        '
        'menStripNoRelej
        '
        Me.menStripNoRelej.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripNoRelej.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.enviarMenuItem1, Me.autoMenuItem2, Me.masInfoMenuItem3, Me.BorrarToolStripMenuItem})
        Me.menStripNoRelej.Name = "ContextMenuStrip1"
        Me.menStripNoRelej.Size = New System.Drawing.Size(215, 92)
        '
        'enviarMenuItem1
        '
        Me.enviarMenuItem1.Image = Global.Spic.My.Resources.Resources.enviar
        Me.enviarMenuItem1.Name = "enviarMenuItem1"
        Me.enviarMenuItem1.Size = New System.Drawing.Size(214, 22)
        Me.enviarMenuItem1.Text = "Enviar para autorizaciòn "
        '
        'autoMenuItem2
        '
        Me.autoMenuItem2.Image = Global.Spic.My.Resources.Resources.ok3
        Me.autoMenuItem2.Name = "autoMenuItem2"
        Me.autoMenuItem2.Size = New System.Drawing.Size(214, 22)
        Me.autoMenuItem2.Text = "Autorizar"
        '
        'masInfoMenuItem3
        '
        Me.masInfoMenuItem3.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.masInfoMenuItem3.Name = "masInfoMenuItem3"
        Me.masInfoMenuItem3.Size = New System.Drawing.Size(214, 22)
        Me.masInfoMenuItem3.Text = "Ver mas info"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.x
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtg_val_menor)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(900, 380)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "Pend valor menor a 40.000"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtg_val_menor
        '
        Me.dtg_val_menor.AllowUserToAddRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_val_menor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dtg_val_menor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_val_menor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_val_menor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dtg_val_menor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_val_menor.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_val_menor.DefaultCellStyle = DataGridViewCellStyle18
        Me.dtg_val_menor.Location = New System.Drawing.Point(6, 7)
        Me.dtg_val_menor.Name = "dtg_val_menor"
        Me.dtg_val_menor.ReadOnly = True
        Me.dtg_val_menor.RowHeadersVisible = False
        Me.dtg_val_menor.Size = New System.Drawing.Size(889, 366)
        Me.dtg_val_menor.TabIndex = 3
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.btn_exportar, Me.btnAyuda, Me.btnContCambios})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(930, 29)
        Me.Toolbar1.TabIndex = 1027
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(27, 26)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Salir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(27, 26)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'btn_exportar
        '
        Me.btn_exportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_exportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_exp_buen, Me.tool_exp_bloq, Me.tool_exp_venc, Me.tool_exp_cupo, Me.tool_exp_noRef})
        Me.btn_exportar.Image = Global.Spic.My.Resources.Resources.excel
        Me.btn_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_exportar.Name = "btn_exportar"
        Me.btn_exportar.Size = New System.Drawing.Size(39, 26)
        Me.btn_exportar.Text = "Graficar"
        Me.btn_exportar.ToolTipText = "Exportar a excel"
        '
        'tool_exp_buen
        '
        Me.tool_exp_buen.AutoSize = False
        Me.tool_exp_buen.Image = Global.Spic.My.Resources.Resources.excel
        Me.tool_exp_buen.Name = "tool_exp_buen"
        Me.tool_exp_buen.Size = New System.Drawing.Size(159, 30)
        Me.tool_exp_buen.Text = "Buenos"
        Me.tool_exp_buen.ToolTipText = "Pendientes Buenos"
        '
        'tool_exp_bloq
        '
        Me.tool_exp_bloq.Image = Global.Spic.My.Resources.Resources.excel
        Me.tool_exp_bloq.Name = "tool_exp_bloq"
        Me.tool_exp_bloq.Size = New System.Drawing.Size(170, 22)
        Me.tool_exp_bloq.Text = "Bloqueados"
        Me.tool_exp_bloq.ToolTipText = "Pendientes bloqueados"
        '
        'tool_exp_venc
        '
        Me.tool_exp_venc.Image = Global.Spic.My.Resources.Resources.excel
        Me.tool_exp_venc.Name = "tool_exp_venc"
        Me.tool_exp_venc.Size = New System.Drawing.Size(170, 22)
        Me.tool_exp_venc.Text = "Documentos venc"
        Me.tool_exp_venc.ToolTipText = "Pendientes doc vencido"
        '
        'tool_exp_cupo
        '
        Me.tool_exp_cupo.Image = Global.Spic.My.Resources.Resources.excel
        Me.tool_exp_cupo.Name = "tool_exp_cupo"
        Me.tool_exp_cupo.Size = New System.Drawing.Size(170, 22)
        Me.tool_exp_cupo.Text = "Cupo credito"
        Me.tool_exp_cupo.ToolTipText = "Pendientes cupo credito"
        '
        'tool_exp_noRef
        '
        Me.tool_exp_noRef.Image = Global.Spic.My.Resources.Resources.excel
        Me.tool_exp_noRef.Name = "tool_exp_noRef"
        Me.tool_exp_noRef.Size = New System.Drawing.Size(170, 22)
        Me.tool_exp_noRef.Text = "No reflejados"
        Me.tool_exp_noRef.ToolTipText = "Pendientes no reflej"
        '
        'btnAyuda
        '
        Me.btnAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAyuda.Image = Global.Spic.My.Resources.Resources.Help2
        Me.btnAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(27, 26)
        Me.btnAyuda.Text = "Ayuda"
        '
        'btnContCambios
        '
        Me.btnContCambios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnContCambios.Image = Global.Spic.My.Resources.Resources.info1
        Me.btnContCambios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContCambios.Name = "btnContCambios"
        Me.btnContCambios.Size = New System.Drawing.Size(27, 26)
        Me.btnContCambios.Text = "Control de cambios"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(740, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 120)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipos de problemas"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(29, 105)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Sin lista de precio"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "L:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(25, 90)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(150, 13)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Sin movimiento hace 180 días"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(23, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 13)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "Precio muy bajo"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(23, 37)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 13)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Bloqueado"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(23, 54)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(127, 13)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "Cupo credito insufuciente"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(25, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 13)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "Facturación vencida"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "X:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(20, 15)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "P:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 35)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 15)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "B:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(20, 15)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "C:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "V:"
        '
        'txtKilCupo
        '
        Me.txtKilCupo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtKilCupo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKilCupo.Location = New System.Drawing.Point(274, 98)
        Me.txtKilCupo.Name = "txtKilCupo"
        Me.txtKilCupo.Size = New System.Drawing.Size(100, 13)
        Me.txtKilCupo.TabIndex = 16
        Me.txtKilCupo.Text = "0"
        Me.txtKilCupo.Visible = False
        '
        'txtValCupo
        '
        Me.txtValCupo.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtValCupo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValCupo.Location = New System.Drawing.Point(388, 98)
        Me.txtValCupo.Name = "txtValCupo"
        Me.txtValCupo.Size = New System.Drawing.Size(100, 13)
        Me.txtValCupo.TabIndex = 17
        Me.txtValCupo.Text = "0"
        Me.txtValCupo.Visible = False
        '
        'txtKilDoc
        '
        Me.txtKilDoc.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtKilDoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtKilDoc.Location = New System.Drawing.Point(274, 80)
        Me.txtKilDoc.Name = "txtKilDoc"
        Me.txtKilDoc.Size = New System.Drawing.Size(100, 13)
        Me.txtKilDoc.TabIndex = 18
        Me.txtKilDoc.Text = "0"
        Me.txtKilDoc.Visible = False
        '
        'txtValDoc
        '
        Me.txtValDoc.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtValDoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValDoc.Location = New System.Drawing.Point(388, 80)
        Me.txtValDoc.Name = "txtValDoc"
        Me.txtValDoc.Size = New System.Drawing.Size(100, 13)
        Me.txtValDoc.TabIndex = 19
        Me.txtValDoc.Text = "0"
        Me.txtValDoc.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(178, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 15)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Doc vencidos:"
        Me.Label12.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(178, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 15)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Cupo credito:"
        Me.Label15.Visible = False
        '
        'txt_kil_no_reflej
        '
        Me.txt_kil_no_reflej.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_kil_no_reflej.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_kil_no_reflej.Location = New System.Drawing.Point(274, 82)
        Me.txt_kil_no_reflej.Name = "txt_kil_no_reflej"
        Me.txt_kil_no_reflej.Size = New System.Drawing.Size(100, 13)
        Me.txt_kil_no_reflej.TabIndex = 36
        Me.txt_kil_no_reflej.Text = "0"
        '
        'txt_val_no_reflej
        '
        Me.txt_val_no_reflej.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_val_no_reflej.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_val_no_reflej.Location = New System.Drawing.Point(388, 82)
        Me.txt_val_no_reflej.Name = "txt_val_no_reflej"
        Me.txt_val_no_reflej.Size = New System.Drawing.Size(100, 13)
        Me.txt_val_no_reflej.TabIndex = 37
        Me.txt_val_no_reflej.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(178, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 15)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "No reflejados:"
        '
        'FrmAnalisisPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(930, 564)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_val_no_reflej)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txt_kil_no_reflej)
        Me.Controls.Add(Me.txtTotVal)
        Me.Controls.Add(Me.tbl_datos)
        Me.Controls.Add(Me.txtTotKilo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtValBloq)
        Me.Controls.Add(Me.txtKilBloq)
        Me.Controls.Add(Me.txtValDoc)
        Me.Controls.Add(Me.txtKilDoc)
        Me.Controls.Add(Me.txtValCupo)
        Me.Controls.Add(Me.txtKilCupo)
        Me.Controls.Add(Me.txtBueVal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotKilosBueno)
        Me.Controls.Add(Me.totKilos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAnalisisPedido"
        Me.Text = "Analisis pedido"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.menStripDtg.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tblCupCredit.ResumeLayout(False)
        CType(Me.imgProc4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgCupCred, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblDocVenc.ResumeLayout(False)
        CType(Me.imgProc3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgDocVen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblBloq.ResumeLayout(False)
        CType(Me.imgProc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgBloq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblPenBuenos.ResumeLayout(False)
        CType(Me.imgProc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgPenBuenos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbl_datos.ResumeLayout(False)
        Me.tbla_no_reflej.ResumeLayout(False)
        CType(Me.imgProc5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_no_reflejados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripNoRelej.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtg_val_menor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMax As System.Windows.Forms.TextBox
    Friend WithEvents txtMin As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents totKilos As System.Windows.Forms.Label
    Friend WithEvents txtTotKilosBueno As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBueVal As System.Windows.Forms.TextBox
    Friend WithEvents txtValBloq As System.Windows.Forms.TextBox
    Friend WithEvents txtKilBloq As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotKilo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotVal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCriterio As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarPedido As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtValtotbusq As System.Windows.Forms.TextBox
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemAutorizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemMasInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tblCupCredit As System.Windows.Forms.TabPage
    Friend WithEvents dtgCupCred As System.Windows.Forms.DataGridView
    Friend WithEvents tblDocVenc As System.Windows.Forms.TabPage
    Friend WithEvents dtgDocVen As System.Windows.Forms.DataGridView
    Friend WithEvents tblBloq As System.Windows.Forms.TabPage
    Friend WithEvents dtgBloq As System.Windows.Forms.DataGridView
    Friend WithEvents tblPenBuenos As System.Windows.Forms.TabPage
    Friend WithEvents imgProc As System.Windows.Forms.PictureBox
    Friend WithEvents dtgPenBuenos As System.Windows.Forms.DataGridView
    Friend WithEvents tbl_datos As System.Windows.Forms.TabControl
    Friend WithEvents imgProc4 As System.Windows.Forms.PictureBox
    Friend WithEvents imgProc3 As System.Windows.Forms.PictureBox
    Friend WithEvents imgProc2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents tbla_no_reflej As System.Windows.Forms.TabPage
    Friend WithEvents dtg_no_reflejados As System.Windows.Forms.DataGridView
    Friend WithEvents imgProc5 As System.Windows.Forms.PictureBox
    Friend WithEvents menStripNoRelej As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents enviarMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents autoMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents masInfoMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_exportar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tool_exp_buen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tool_exp_bloq As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tool_exp_venc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tool_exp_cupo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tool_exp_noRef As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CambiarNotaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnModPed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnContCambios As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dtg_val_menor As System.Windows.Forms.DataGridView
    Friend WithEvents AnularPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtKilCupo As System.Windows.Forms.TextBox
    Friend WithEvents txtValCupo As System.Windows.Forms.TextBox
    Friend WithEvents txtKilDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtValDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_kil_no_reflej As System.Windows.Forms.TextBox
    Friend WithEvents txt_val_no_reflej As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
