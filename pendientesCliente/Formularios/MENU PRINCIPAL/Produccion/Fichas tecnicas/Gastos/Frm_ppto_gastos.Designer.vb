﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ppto_gastos
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbo_ano = New System.Windows.Forms.ComboBox()
        Me.lbl_mes = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbo_mes = New System.Windows.Forms.ComboBox()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_salir = New System.Windows.Forms.ToolStripButton()
        Me.btn_ppal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_guardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_actualizar = New System.Windows.Forms.ToolStripButton()
        Me.dtg_presupuesto = New System.Windows.Forms.DataGridView()
        Me.menStripDtg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.itemDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.groupDetalle = New System.Windows.Forms.GroupBox()
        Me.btn_guardar_detalle = New System.Windows.Forms.Button()
        Me.btn_cerrar_det = New System.Windows.Forms.Button()
        Me.dtgDetalle = New System.Windows.Forms.DataGridView()
        Me.GroupBox2.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        CType(Me.dtg_presupuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menStripDtg.SuspendLayout()
        Me.groupDetalle.SuspendLayout()
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_ano)
        Me.GroupBox2.Controls.Add(Me.lbl_mes)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.cbo_mes)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 44)
        Me.GroupBox2.TabIndex = 1080
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha de presupuesto"
        '
        'cbo_ano
        '
        Me.cbo_ano.FormattingEnabled = True
        Me.cbo_ano.Location = New System.Drawing.Point(182, 14)
        Me.cbo_ano.Name = "cbo_ano"
        Me.cbo_ano.Size = New System.Drawing.Size(78, 21)
        Me.cbo_ano.TabIndex = 1075
        Me.cbo_ano.Text = "Seleccione"
        '
        'lbl_mes
        '
        Me.lbl_mes.AutoSize = True
        Me.lbl_mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mes.Location = New System.Drawing.Point(5, 18)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(34, 13)
        Me.lbl_mes.TabIndex = 1078
        Me.lbl_mes.Text = "Mes:"
        '
        'Label37
        '
        Me.Label37.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(148, 18)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(33, 13)
        Me.Label37.TabIndex = 1076
        Me.Label37.Text = "Año:"
        '
        'cbo_mes
        '
        Me.cbo_mes.FormattingEnabled = True
        Me.cbo_mes.Items.AddRange(New Object() {"Enero ", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbo_mes.Location = New System.Drawing.Point(39, 14)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(106, 21)
        Me.cbo_mes.TabIndex = 1077
        Me.cbo_mes.Text = "Seleccione"
        '
        'Toolbar1
        '
        Me.Toolbar1.AutoSize = False
        Me.Toolbar1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Toolbar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btn_salir, Me.btn_ppal, Me.ToolStripSeparator4, Me.btnNuevo, Me.btn_guardar, Me.ToolStripSeparator3, Me.btnExcel, Me.ToolStripSeparator1, Me.btn_actualizar})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(804, 28)
        Me.Toolbar1.TabIndex = 1081
        Me.Toolbar1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'btn_salir
        '
        Me.btn_salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_salir.Image = Global.Spic.My.Resources.Resources._1349388328_door_in
        Me.btn_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(27, 25)
        Me.btn_salir.Text = "ToolStripButton1"
        Me.btn_salir.ToolTipText = "Salir"
        '
        'btn_ppal
        '
        Me.btn_ppal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_ppal.Image = Global.Spic.My.Resources.Resources.ppal3
        Me.btn_ppal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ppal.Name = "btn_ppal"
        Me.btn_ppal.Size = New System.Drawing.Size(27, 25)
        Me.btn_ppal.Text = "ToolStripButton2"
        Me.btn_ppal.ToolTipText = "Menú principal"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 28)
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = Global.Spic.My.Resources.Resources.nuevo
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(27, 25)
        Me.btnNuevo.Text = "Nuevo"
        '
        'btn_guardar
        '
        Me.btn_guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_guardar.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btn_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(27, 25)
        Me.btn_guardar.Text = "Guardar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
        '
        'btnExcel
        '
        Me.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExcel.Image = Global.Spic.My.Resources.Resources.excel
        Me.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(27, 25)
        Me.btnExcel.Text = "Exportar a excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        '
        'btn_actualizar
        '
        Me.btn_actualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_actualizar.Image = Global.Spic.My.Resources.Resources.actualizar
        Me.btn_actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(27, 25)
        Me.btn_actualizar.Text = "Actualizar  datos"
        '
        'dtg_presupuesto
        '
        Me.dtg_presupuesto.AllowUserToAddRows = False
        Me.dtg_presupuesto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_presupuesto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_presupuesto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_presupuesto.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_presupuesto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_presupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_presupuesto.ContextMenuStrip = Me.menStripDtg
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_presupuesto.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_presupuesto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtg_presupuesto.Location = New System.Drawing.Point(3, 81)
        Me.dtg_presupuesto.Name = "dtg_presupuesto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_presupuesto.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_presupuesto.RowHeadersVisible = False
        Me.dtg_presupuesto.Size = New System.Drawing.Size(797, 427)
        Me.dtg_presupuesto.TabIndex = 1082
        '
        'menStripDtg
        '
        Me.menStripDtg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menStripDtg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.itemDetalle})
        Me.menStripDtg.Name = "ContextMenuStrip1"
        Me.menStripDtg.Size = New System.Drawing.Size(270, 26)
        '
        'itemDetalle
        '
        Me.itemDetalle.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.itemDetalle.Name = "itemDetalle"
        Me.itemDetalle.Size = New System.Drawing.Size(269, 22)
        Me.itemDetalle.Text = "Presupuestar por centros de costo"
        '
        'groupDetalle
        '
        Me.groupDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupDetalle.Controls.Add(Me.btn_guardar_detalle)
        Me.groupDetalle.Controls.Add(Me.btn_cerrar_det)
        Me.groupDetalle.Controls.Add(Me.dtgDetalle)
        Me.groupDetalle.Location = New System.Drawing.Point(154, 129)
        Me.groupDetalle.Name = "groupDetalle"
        Me.groupDetalle.Size = New System.Drawing.Size(496, 370)
        Me.groupDetalle.TabIndex = 1087
        Me.groupDetalle.TabStop = False
        Me.groupDetalle.Text = "Presupuesto por centros de costo"
        Me.groupDetalle.Visible = False
        '
        'btn_guardar_detalle
        '
        Me.btn_guardar_detalle.Image = Global.Spic.My.Resources.Resources.save_16
        Me.btn_guardar_detalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar_detalle.Location = New System.Drawing.Point(6, 14)
        Me.btn_guardar_detalle.Name = "btn_guardar_detalle"
        Me.btn_guardar_detalle.Size = New System.Drawing.Size(83, 23)
        Me.btn_guardar_detalle.TabIndex = 1089
        Me.btn_guardar_detalle.Text = "Guardar"
        Me.btn_guardar_detalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guardar_detalle.UseVisualStyleBackColor = True
        '
        'btn_cerrar_det
        '
        Me.btn_cerrar_det.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cerrar_det.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar_det.ForeColor = System.Drawing.Color.Red
        Me.btn_cerrar_det.Location = New System.Drawing.Point(472, 1)
        Me.btn_cerrar_det.Name = "btn_cerrar_det"
        Me.btn_cerrar_det.Size = New System.Drawing.Size(20, 23)
        Me.btn_cerrar_det.TabIndex = 1088
        Me.btn_cerrar_det.Text = "X"
        Me.btn_cerrar_det.UseVisualStyleBackColor = True
        '
        'dtgDetalle
        '
        Me.dtgDetalle.AllowUserToAddRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDetalle.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgDetalle.Location = New System.Drawing.Point(6, 40)
        Me.dtgDetalle.Name = "dtgDetalle"
        Me.dtgDetalle.RowHeadersVisible = False
        Me.dtgDetalle.Size = New System.Drawing.Size(484, 324)
        Me.dtgDetalle.TabIndex = 1087
        '
        'Frm_ppto_gastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 511)
        Me.Controls.Add(Me.groupDetalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.dtg_presupuesto)
        Me.Name = "Frm_ppto_gastos"
        Me.Text = "Presupuesto de gastos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.dtg_presupuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menStripDtg.ResumeLayout(False)
        Me.groupDetalle.ResumeLayout(False)
        CType(Me.dtgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_ano As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_mes As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbo_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_ppal As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_actualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtg_presupuesto As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents groupDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cerrar_det As System.Windows.Forms.Button
    Friend WithEvents dtgDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents menStripDtg As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents itemDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_guardar_detalle As System.Windows.Forms.Button
End Class
