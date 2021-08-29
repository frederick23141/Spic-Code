<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Gestion_ped
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenùToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendBuenosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PendBloqueadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocVencidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CupoCredToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemAutorizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemMasInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtg_ped = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        Me.menStripDtg.SuspendLayout()
        CType(Me.dtg_ped, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenùToolStripMenuItem, Me.OpcionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(500, 24)
        Me.MenuStrip1.TabIndex = 32
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenùToolStripMenuItem
        '
        Me.MenùToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrincipalToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenùToolStripMenuItem.Name = "MenùToolStripMenuItem"
        Me.MenùToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenùToolStripMenuItem.Text = "Menù"
        '
        'PrincipalToolStripMenuItem
        '
        Me.PrincipalToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.PrincipalToolStripMenuItem.Name = "PrincipalToolStripMenuItem"
        Me.PrincipalToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.PrincipalToolStripMenuItem.Text = "Principal"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.salir
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PendBuenosToolStripMenuItem, Me.PendBloqueadosToolStripMenuItem, Me.DocVencidosToolStripMenuItem, Me.CupoCredToolStripMenuItem})
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a excel"
        '
        'PendBuenosToolStripMenuItem
        '
        Me.PendBuenosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.PendBuenosToolStripMenuItem.Name = "PendBuenosToolStripMenuItem"
        Me.PendBuenosToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.PendBuenosToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.PendBuenosToolStripMenuItem.Text = "Pend buenos"
        '
        'PendBloqueadosToolStripMenuItem
        '
        Me.PendBloqueadosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.PendBloqueadosToolStripMenuItem.Name = "PendBloqueadosToolStripMenuItem"
        Me.PendBloqueadosToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.PendBloqueadosToolStripMenuItem.Text = "Pend bloqueados"
        '
        'DocVencidosToolStripMenuItem
        '
        Me.DocVencidosToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.DocVencidosToolStripMenuItem.Name = "DocVencidosToolStripMenuItem"
        Me.DocVencidosToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.DocVencidosToolStripMenuItem.Text = "Doc vencidos"
        '
        'CupoCredToolStripMenuItem
        '
        Me.CupoCredToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.excel
        Me.CupoCredToolStripMenuItem.Name = "CupoCredToolStripMenuItem"
        Me.CupoCredToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CupoCredToolStripMenuItem.Text = "Cupo cred"
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemAutorizar, Me.itemMail, Me.itemMasInfo, Me.BorrarToolStripMenuItem})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(215, 92)
        '
        'itemAutorizar
        '
        Me.itemAutorizar.Name = "itemAutorizar"
        Me.itemAutorizar.Size = New System.Drawing.Size(214, 22)
        Me.itemAutorizar.Text = "Autorizar"
        '
        'itemMail
        '
        Me.itemMail.Name = "itemMail"
        Me.itemMail.Size = New System.Drawing.Size(214, 22)
        Me.itemMail.Text = "Enviar para autorizaciòn "
        '
        'itemMasInfo
        '
        Me.itemMasInfo.Name = "itemMasInfo"
        Me.itemMasInfo.Size = New System.Drawing.Size(214, 22)
        Me.itemMasInfo.Text = "Ver mas info"
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.BorrarToolStripMenuItem.Text = "Borrar"
        '
        'dtg_ped
        '
        Me.dtg_ped.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_ped.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_ped.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_ped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_ped.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_ped.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_ped.Location = New System.Drawing.Point(12, 39)
        Me.dtg_ped.Name = "dtg_ped"
        Me.dtg_ped.RowHeadersVisible = False
        Me.dtg_ped.Size = New System.Drawing.Size(476, 301)
        Me.dtg_ped.TabIndex = 33
        '
        'Frm_Gestion_ped
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(500, 352)
        Me.Controls.Add(Me.dtg_ped)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Frm_Gestion_ped"
        Me.Text = "Gestión pedido"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.menStripDtg.ResumeLayout(False)
        CType(Me.dtg_ped, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenùToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrincipalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PendBuenosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PendBloqueadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocVencidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CupoCredToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemAutorizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemMasInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtg_ped As System.Windows.Forms.DataGridView
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
