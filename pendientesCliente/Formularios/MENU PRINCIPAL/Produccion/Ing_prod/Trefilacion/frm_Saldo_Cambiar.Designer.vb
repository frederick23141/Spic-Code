<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Saldo_Cambiar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Saldo_Cambiar))
        Me.dtg_Saldo_Alambron = New System.Windows.Forms.DataGridView()
        Me.IdmatprimaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesorealDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesollevaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoMDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodalambronDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JtrefcontmpBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AsaldoDataSet = New Spic.AsaldoDataSet()
        Me.J_tref_cont_mpTableAdapter = New Spic.AsaldoDataSetTableAdapters.J_tref_cont_mpTableAdapter()
        Me.bd_Saldo = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorEditItem = New System.Windows.Forms.ToolStripButton()
        Me.gb_Filtro = New ComponentFactory.Krypton.Toolkit.KryptonGroupBox()
        Me.cbo_tref = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lbl_tref = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btn_cargar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cbo_mes = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cbo_Ano = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lbl_mes = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_ano = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.dtg_Saldo_Alambron, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.JtrefcontmpBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AsaldoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bd_Saldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bd_Saldo.SuspendLayout()
        CType(Me.gb_Filtro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_Filtro.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Filtro.Panel.SuspendLayout()
        Me.gb_Filtro.SuspendLayout()
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Ano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_Saldo_Alambron
        '
        Me.dtg_Saldo_Alambron.AllowUserToAddRows = False
        Me.dtg_Saldo_Alambron.AllowUserToDeleteRows = False
        Me.dtg_Saldo_Alambron.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_Saldo_Alambron.AutoGenerateColumns = False
        Me.dtg_Saldo_Alambron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_Saldo_Alambron.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdmatprimaDataGridViewTextBoxColumn, Me.PesorealDataGridViewTextBoxColumn, Me.PesollevaDataGridViewTextBoxColumn, Me.MesDataGridViewTextBoxColumn, Me.AnoDataGridViewTextBoxColumn, Me.CodigoMDataGridViewTextBoxColumn, Me.CodalambronDataGridViewTextBoxColumn})
        Me.dtg_Saldo_Alambron.DataSource = Me.JtrefcontmpBindingSource
        Me.dtg_Saldo_Alambron.Location = New System.Drawing.Point(12, 200)
        Me.dtg_Saldo_Alambron.Name = "dtg_Saldo_Alambron"
        Me.dtg_Saldo_Alambron.RowHeadersVisible = False
        Me.dtg_Saldo_Alambron.Size = New System.Drawing.Size(776, 238)
        Me.dtg_Saldo_Alambron.TabIndex = 0
        '
        'IdmatprimaDataGridViewTextBoxColumn
        '
        Me.IdmatprimaDataGridViewTextBoxColumn.DataPropertyName = "id_mat_prima"
        Me.IdmatprimaDataGridViewTextBoxColumn.HeaderText = "id_mat_prima"
        Me.IdmatprimaDataGridViewTextBoxColumn.Name = "IdmatprimaDataGridViewTextBoxColumn"
        Me.IdmatprimaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PesorealDataGridViewTextBoxColumn
        '
        Me.PesorealDataGridViewTextBoxColumn.DataPropertyName = "peso_real"
        Me.PesorealDataGridViewTextBoxColumn.HeaderText = "peso_real"
        Me.PesorealDataGridViewTextBoxColumn.Name = "PesorealDataGridViewTextBoxColumn"
        '
        'PesollevaDataGridViewTextBoxColumn
        '
        Me.PesollevaDataGridViewTextBoxColumn.DataPropertyName = "peso_lleva"
        Me.PesollevaDataGridViewTextBoxColumn.HeaderText = "peso_lleva"
        Me.PesollevaDataGridViewTextBoxColumn.Name = "PesollevaDataGridViewTextBoxColumn"
        '
        'MesDataGridViewTextBoxColumn
        '
        Me.MesDataGridViewTextBoxColumn.DataPropertyName = "mes"
        Me.MesDataGridViewTextBoxColumn.HeaderText = "mes"
        Me.MesDataGridViewTextBoxColumn.Name = "MesDataGridViewTextBoxColumn"
        '
        'AnoDataGridViewTextBoxColumn
        '
        Me.AnoDataGridViewTextBoxColumn.DataPropertyName = "ano"
        Me.AnoDataGridViewTextBoxColumn.HeaderText = "ano"
        Me.AnoDataGridViewTextBoxColumn.Name = "AnoDataGridViewTextBoxColumn"
        '
        'CodigoMDataGridViewTextBoxColumn
        '
        Me.CodigoMDataGridViewTextBoxColumn.DataPropertyName = "codigoM"
        Me.CodigoMDataGridViewTextBoxColumn.HeaderText = "codigoM"
        Me.CodigoMDataGridViewTextBoxColumn.Name = "CodigoMDataGridViewTextBoxColumn"
        '
        'CodalambronDataGridViewTextBoxColumn
        '
        Me.CodalambronDataGridViewTextBoxColumn.DataPropertyName = "cod_alambron"
        Me.CodalambronDataGridViewTextBoxColumn.HeaderText = "cod_alambron"
        Me.CodalambronDataGridViewTextBoxColumn.Name = "CodalambronDataGridViewTextBoxColumn"
        '
        'JtrefcontmpBindingSource
        '
        Me.JtrefcontmpBindingSource.DataMember = "J_tref_cont_mp"
        Me.JtrefcontmpBindingSource.DataSource = Me.AsaldoDataSet
        '
        'AsaldoDataSet
        '
        Me.AsaldoDataSet.DataSetName = "AsaldoDataSet"
        Me.AsaldoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'J_tref_cont_mpTableAdapter
        '
        Me.J_tref_cont_mpTableAdapter.ClearBeforeFill = True
        '
        'bd_Saldo
        '
        Me.bd_Saldo.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.bd_Saldo.BindingSource = Me.JtrefcontmpBindingSource
        Me.bd_Saldo.CountItem = Me.BindingNavigatorCountItem
        Me.bd_Saldo.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.bd_Saldo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bd_Saldo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorEditItem})
        Me.bd_Saldo.Location = New System.Drawing.Point(0, 0)
        Me.bd_Saldo.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bd_Saldo.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bd_Saldo.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bd_Saldo.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bd_Saldo.Name = "bd_Saldo"
        Me.bd_Saldo.PositionItem = Me.BindingNavigatorPositionItem
        Me.bd_Saldo.Size = New System.Drawing.Size(800, 25)
        Me.bd_Saldo.TabIndex = 1
        Me.bd_Saldo.Text = "bd_Saldo"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Enabled = False
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Enabled = False
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorEditItem
        '
        Me.BindingNavigatorEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorEditItem.Image = Global.Spic.My.Resources.Resources.edit
        Me.BindingNavigatorEditItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BindingNavigatorEditItem.Name = "BindingNavigatorEditItem"
        Me.BindingNavigatorEditItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorEditItem.Text = "Editar"
        '
        'gb_Filtro
        '
        Me.gb_Filtro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gb_Filtro.Location = New System.Drawing.Point(259, 28)
        Me.gb_Filtro.Name = "gb_Filtro"
        '
        'gb_Filtro.Panel
        '
        Me.gb_Filtro.Panel.Controls.Add(Me.cbo_tref)
        Me.gb_Filtro.Panel.Controls.Add(Me.lbl_tref)
        Me.gb_Filtro.Panel.Controls.Add(Me.btn_cargar)
        Me.gb_Filtro.Panel.Controls.Add(Me.cbo_mes)
        Me.gb_Filtro.Panel.Controls.Add(Me.cbo_Ano)
        Me.gb_Filtro.Panel.Controls.Add(Me.lbl_mes)
        Me.gb_Filtro.Panel.Controls.Add(Me.lbl_ano)
        Me.gb_Filtro.Size = New System.Drawing.Size(280, 166)
        Me.gb_Filtro.TabIndex = 3
        Me.gb_Filtro.Values.Heading = "Selección:"
        '
        'cbo_tref
        '
        Me.cbo_tref.DropDownWidth = 141
        Me.cbo_tref.Location = New System.Drawing.Point(105, 86)
        Me.cbo_tref.Name = "cbo_tref"
        Me.cbo_tref.Size = New System.Drawing.Size(141, 21)
        Me.cbo_tref.TabIndex = 4
        '
        'lbl_tref
        '
        Me.lbl_tref.Location = New System.Drawing.Point(17, 87)
        Me.lbl_tref.Name = "lbl_tref"
        Me.lbl_tref.Size = New System.Drawing.Size(72, 20)
        Me.lbl_tref.TabIndex = 7
        Me.lbl_tref.Values.Text = "Trefiladora:"
        '
        'btn_cargar
        '
        Me.btn_cargar.Location = New System.Drawing.Point(88, 113)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(102, 25)
        Me.btn_cargar.TabIndex = 3
        Me.btn_cargar.Values.Text = "Cargar"
        '
        'cbo_mes
        '
        Me.cbo_mes.DropDownWidth = 141
        Me.cbo_mes.Location = New System.Drawing.Point(105, 48)
        Me.cbo_mes.Name = "cbo_mes"
        Me.cbo_mes.Size = New System.Drawing.Size(141, 21)
        Me.cbo_mes.TabIndex = 6
        '
        'cbo_Ano
        '
        Me.cbo_Ano.DropDownWidth = 141
        Me.cbo_Ano.Location = New System.Drawing.Point(105, 11)
        Me.cbo_Ano.Name = "cbo_Ano"
        Me.cbo_Ano.Size = New System.Drawing.Size(141, 21)
        Me.cbo_Ano.TabIndex = 5
        '
        'lbl_mes
        '
        Me.lbl_mes.Location = New System.Drawing.Point(50, 49)
        Me.lbl_mes.Name = "lbl_mes"
        Me.lbl_mes.Size = New System.Drawing.Size(36, 20)
        Me.lbl_mes.TabIndex = 4
        Me.lbl_mes.Values.Text = "Mes:"
        '
        'lbl_ano
        '
        Me.lbl_ano.Location = New System.Drawing.Point(51, 12)
        Me.lbl_ano.Name = "lbl_ano"
        Me.lbl_ano.Size = New System.Drawing.Size(35, 20)
        Me.lbl_ano.TabIndex = 3
        Me.lbl_ano.Values.Text = "Año:"
        '
        'frm_Saldo_Cambiar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gb_Filtro)
        Me.Controls.Add(Me.bd_Saldo)
        Me.Controls.Add(Me.dtg_Saldo_Alambron)
        Me.Name = "frm_Saldo_Cambiar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar saldos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtg_Saldo_Alambron, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.JtrefcontmpBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AsaldoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bd_Saldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bd_Saldo.ResumeLayout(False)
        Me.bd_Saldo.PerformLayout()
        CType(Me.gb_Filtro.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Filtro.Panel.ResumeLayout(False)
        Me.gb_Filtro.Panel.PerformLayout()
        CType(Me.gb_Filtro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Filtro.ResumeLayout(False)
        CType(Me.cbo_tref, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Ano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtg_Saldo_Alambron As DataGridView
    Friend WithEvents AsaldoDataSet As AsaldoDataSet
    Friend WithEvents JtrefcontmpBindingSource As BindingSource
    Friend WithEvents J_tref_cont_mpTableAdapter As AsaldoDataSetTableAdapters.J_tref_cont_mpTableAdapter
    Friend WithEvents IdmatprimaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PesorealDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PesollevaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AnoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CodigoMDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CodalambronDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents bd_Saldo As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents BindingNavigatorEditItem As ToolStripButton
    Friend WithEvents gb_Filtro As ComponentFactory.Krypton.Toolkit.KryptonGroupBox
    Friend WithEvents cbo_tref As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lbl_tref As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btn_cargar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents cbo_mes As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cbo_Ano As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lbl_mes As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_ano As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
