<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteInspeccionCalidad
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporteInspeccionCalidad))
        Me.F_V_CalidadBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.F_V_CalidadBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRGPRODUCCIONDataSetCalidad = New Spic.PRGPRODUCCIONDataSetCalidad()
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
        Me.F_V_CalidadBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.FVCalidadBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRGPRODUCCIONDataSet1 = New Spic.PRGPRODUCCIONDataSet1()
        Me.F_V_CalidadTableAdapter = New Spic.PRGPRODUCCIONDataSetCalidadTableAdapters.F_V_CalidadTableAdapter()
        Me.TableAdapterManager = New Spic.PRGPRODUCCIONDataSetCalidadTableAdapters.TableAdapterManager()
        Me.F_V_CalidadTableAdapter1 = New Spic.PRGPRODUCCIONDataSet1TableAdapters.F_V_CalidadTableAdapter()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FechaprodDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CoddetalleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroOrdenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombresDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaquinaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProdfinalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OperarioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantprogDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalidadDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MateriaprimaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiametroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CircularidadDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AparienciaDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ResistenciaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CashDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.HeliceDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FVCalidadBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DATASETCALIDAD = New Spic.DATASETCALIDAD()
        Me.Consultar_Maquina_8ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButtonEnero = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonFebrero = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMarzo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAbril = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMayo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonJunio = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonJulio = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonAgosto = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSeptiembre = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonOctubre = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonNoviembre = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDiciembre = New System.Windows.Forms.ToolStripButton()
        Me.F_V_CalidadTableAdapter2 = New Spic.DATASETCALIDADTableAdapters.F_V_CalidadTableAdapter()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.F_V_CalidadBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.F_V_CalidadBindingNavigator.SuspendLayout()
        CType(Me.F_V_CalidadBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRGPRODUCCIONDataSetCalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FVCalidadBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRGPRODUCCIONDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FVCalidadBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DATASETCALIDAD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Consultar_Maquina_8ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'F_V_CalidadBindingNavigator
        '
        Me.F_V_CalidadBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.F_V_CalidadBindingNavigator.BindingSource = Me.F_V_CalidadBindingSource
        Me.F_V_CalidadBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.F_V_CalidadBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.F_V_CalidadBindingNavigator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.F_V_CalidadBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.F_V_CalidadBindingNavigatorSaveItem, Me.ToolStripButton1})
        Me.F_V_CalidadBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.F_V_CalidadBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.F_V_CalidadBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.F_V_CalidadBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.F_V_CalidadBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.F_V_CalidadBindingNavigator.Name = "F_V_CalidadBindingNavigator"
        Me.F_V_CalidadBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.F_V_CalidadBindingNavigator.Size = New System.Drawing.Size(920, 25)
        Me.F_V_CalidadBindingNavigator.TabIndex = 0
        Me.F_V_CalidadBindingNavigator.Text = "BindingNavigator1"
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
        'F_V_CalidadBindingSource
        '
        Me.F_V_CalidadBindingSource.DataMember = "F_V_Calidad"
        Me.F_V_CalidadBindingSource.DataSource = Me.PRGPRODUCCIONDataSetCalidad
        '
        'PRGPRODUCCIONDataSetCalidad
        '
        Me.PRGPRODUCCIONDataSetCalidad.DataSetName = "PRGPRODUCCIONDataSetCalidad"
        Me.PRGPRODUCCIONDataSetCalidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'F_V_CalidadBindingNavigatorSaveItem
        '
        Me.F_V_CalidadBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.F_V_CalidadBindingNavigatorSaveItem.Enabled = False
        Me.F_V_CalidadBindingNavigatorSaveItem.Image = CType(resources.GetObject("F_V_CalidadBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.F_V_CalidadBindingNavigatorSaveItem.Name = "F_V_CalidadBindingNavigatorSaveItem"
        Me.F_V_CalidadBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.F_V_CalidadBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'FVCalidadBindingSource
        '
        Me.FVCalidadBindingSource.DataMember = "F_V_Calidad"
        Me.FVCalidadBindingSource.DataSource = Me.PRGPRODUCCIONDataSet1
        '
        'PRGPRODUCCIONDataSet1
        '
        Me.PRGPRODUCCIONDataSet1.DataSetName = "PRGPRODUCCIONDataSet1"
        Me.PRGPRODUCCIONDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'F_V_CalidadTableAdapter
        '
        Me.F_V_CalidadTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = Spic.PRGPRODUCCIONDataSetCalidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'F_V_CalidadTableAdapter1
        '
        Me.F_V_CalidadTableAdapter1.ClearBeforeFill = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechaprodDataGridViewTextBoxColumn, Me.HoraDataGridViewTextBoxColumn, Me.CoddetalleDataGridViewTextBoxColumn, Me.NumeroOrdenDataGridViewTextBoxColumn, Me.NombresDataGridViewTextBoxColumn, Me.MaquinaDataGridViewTextBoxColumn, Me.ProdfinalDataGridViewTextBoxColumn, Me.OperarioDataGridViewTextBoxColumn, Me.CantprogDataGridViewTextBoxColumn, Me.CalidadDataGridViewTextBoxColumn, Me.MateriaprimaDataGridViewTextBoxColumn, Me.DiametroDataGridViewTextBoxColumn, Me.CircularidadDataGridViewTextBoxColumn, Me.PesoDataGridViewTextBoxColumn, Me.AparienciaDataGridViewCheckBoxColumn, Me.ResistenciaDataGridViewTextBoxColumn, Me.CashDataGridViewCheckBoxColumn, Me.HeliceDataGridViewCheckBoxColumn})
        Me.DataGridView1.DataSource = Me.FVCalidadBindingSource1
        Me.DataGridView1.Location = New System.Drawing.Point(0, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(920, 505)
        Me.DataGridView1.TabIndex = 4
        '
        'FechaprodDataGridViewTextBoxColumn
        '
        Me.FechaprodDataGridViewTextBoxColumn.DataPropertyName = "fecha_prod"
        Me.FechaprodDataGridViewTextBoxColumn.HeaderText = "fecha_prod"
        Me.FechaprodDataGridViewTextBoxColumn.Name = "FechaprodDataGridViewTextBoxColumn"
        Me.FechaprodDataGridViewTextBoxColumn.ReadOnly = True
        '
        'HoraDataGridViewTextBoxColumn
        '
        Me.HoraDataGridViewTextBoxColumn.DataPropertyName = "hora"
        Me.HoraDataGridViewTextBoxColumn.HeaderText = "hora"
        Me.HoraDataGridViewTextBoxColumn.Name = "HoraDataGridViewTextBoxColumn"
        Me.HoraDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CoddetalleDataGridViewTextBoxColumn
        '
        Me.CoddetalleDataGridViewTextBoxColumn.DataPropertyName = "cod_detalle"
        Me.CoddetalleDataGridViewTextBoxColumn.HeaderText = "cod_detalle"
        Me.CoddetalleDataGridViewTextBoxColumn.Name = "CoddetalleDataGridViewTextBoxColumn"
        Me.CoddetalleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NumeroOrdenDataGridViewTextBoxColumn
        '
        Me.NumeroOrdenDataGridViewTextBoxColumn.DataPropertyName = "Numero_Orden"
        Me.NumeroOrdenDataGridViewTextBoxColumn.HeaderText = "Numero_Orden"
        Me.NumeroOrdenDataGridViewTextBoxColumn.Name = "NumeroOrdenDataGridViewTextBoxColumn"
        Me.NumeroOrdenDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NombresDataGridViewTextBoxColumn
        '
        Me.NombresDataGridViewTextBoxColumn.DataPropertyName = "nombres"
        Me.NombresDataGridViewTextBoxColumn.HeaderText = "nombres"
        Me.NombresDataGridViewTextBoxColumn.Name = "NombresDataGridViewTextBoxColumn"
        Me.NombresDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MaquinaDataGridViewTextBoxColumn
        '
        Me.MaquinaDataGridViewTextBoxColumn.DataPropertyName = "Maquina"
        Me.MaquinaDataGridViewTextBoxColumn.HeaderText = "Maquina"
        Me.MaquinaDataGridViewTextBoxColumn.Name = "MaquinaDataGridViewTextBoxColumn"
        Me.MaquinaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProdfinalDataGridViewTextBoxColumn
        '
        Me.ProdfinalDataGridViewTextBoxColumn.DataPropertyName = "prod_final"
        Me.ProdfinalDataGridViewTextBoxColumn.HeaderText = "prod_final"
        Me.ProdfinalDataGridViewTextBoxColumn.Name = "ProdfinalDataGridViewTextBoxColumn"
        Me.ProdfinalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'OperarioDataGridViewTextBoxColumn
        '
        Me.OperarioDataGridViewTextBoxColumn.DataPropertyName = "Operario"
        Me.OperarioDataGridViewTextBoxColumn.HeaderText = "Operario"
        Me.OperarioDataGridViewTextBoxColumn.Name = "OperarioDataGridViewTextBoxColumn"
        Me.OperarioDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CantprogDataGridViewTextBoxColumn
        '
        Me.CantprogDataGridViewTextBoxColumn.DataPropertyName = "cant_prog"
        Me.CantprogDataGridViewTextBoxColumn.HeaderText = "cant_prog"
        Me.CantprogDataGridViewTextBoxColumn.Name = "CantprogDataGridViewTextBoxColumn"
        Me.CantprogDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CalidadDataGridViewTextBoxColumn
        '
        Me.CalidadDataGridViewTextBoxColumn.DataPropertyName = "calidad"
        Me.CalidadDataGridViewTextBoxColumn.HeaderText = "calidad"
        Me.CalidadDataGridViewTextBoxColumn.Name = "CalidadDataGridViewTextBoxColumn"
        Me.CalidadDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MateriaprimaDataGridViewTextBoxColumn
        '
        Me.MateriaprimaDataGridViewTextBoxColumn.DataPropertyName = "materia_prima"
        Me.MateriaprimaDataGridViewTextBoxColumn.HeaderText = "materia_prima"
        Me.MateriaprimaDataGridViewTextBoxColumn.Name = "MateriaprimaDataGridViewTextBoxColumn"
        Me.MateriaprimaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DiametroDataGridViewTextBoxColumn
        '
        Me.DiametroDataGridViewTextBoxColumn.DataPropertyName = "diametro"
        Me.DiametroDataGridViewTextBoxColumn.HeaderText = "diametro"
        Me.DiametroDataGridViewTextBoxColumn.Name = "DiametroDataGridViewTextBoxColumn"
        Me.DiametroDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CircularidadDataGridViewTextBoxColumn
        '
        Me.CircularidadDataGridViewTextBoxColumn.DataPropertyName = "circularidad"
        Me.CircularidadDataGridViewTextBoxColumn.HeaderText = "circularidad"
        Me.CircularidadDataGridViewTextBoxColumn.Name = "CircularidadDataGridViewTextBoxColumn"
        Me.CircularidadDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PesoDataGridViewTextBoxColumn
        '
        Me.PesoDataGridViewTextBoxColumn.DataPropertyName = "peso"
        Me.PesoDataGridViewTextBoxColumn.HeaderText = "peso"
        Me.PesoDataGridViewTextBoxColumn.Name = "PesoDataGridViewTextBoxColumn"
        Me.PesoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AparienciaDataGridViewCheckBoxColumn
        '
        Me.AparienciaDataGridViewCheckBoxColumn.DataPropertyName = "apariencia"
        Me.AparienciaDataGridViewCheckBoxColumn.HeaderText = "apariencia"
        Me.AparienciaDataGridViewCheckBoxColumn.Name = "AparienciaDataGridViewCheckBoxColumn"
        Me.AparienciaDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'ResistenciaDataGridViewTextBoxColumn
        '
        Me.ResistenciaDataGridViewTextBoxColumn.DataPropertyName = "resistencia"
        Me.ResistenciaDataGridViewTextBoxColumn.HeaderText = "resistencia"
        Me.ResistenciaDataGridViewTextBoxColumn.Name = "ResistenciaDataGridViewTextBoxColumn"
        Me.ResistenciaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CashDataGridViewCheckBoxColumn
        '
        Me.CashDataGridViewCheckBoxColumn.DataPropertyName = "cash"
        Me.CashDataGridViewCheckBoxColumn.HeaderText = "cash"
        Me.CashDataGridViewCheckBoxColumn.Name = "CashDataGridViewCheckBoxColumn"
        Me.CashDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'HeliceDataGridViewCheckBoxColumn
        '
        Me.HeliceDataGridViewCheckBoxColumn.DataPropertyName = "helice"
        Me.HeliceDataGridViewCheckBoxColumn.HeaderText = "helice"
        Me.HeliceDataGridViewCheckBoxColumn.Name = "HeliceDataGridViewCheckBoxColumn"
        Me.HeliceDataGridViewCheckBoxColumn.ReadOnly = True
        '
        'FVCalidadBindingSource1
        '
        Me.FVCalidadBindingSource1.DataMember = "F_V_Calidad"
        Me.FVCalidadBindingSource1.DataSource = Me.DATASETCALIDAD
        '
        'DATASETCALIDAD
        '
        Me.DATASETCALIDAD.DataSetName = "DATASETCALIDAD"
        Me.DATASETCALIDAD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Consultar_Maquina_8ToolStrip
        '
        Me.Consultar_Maquina_8ToolStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Consultar_Maquina_8ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButtonEnero, Me.ToolStripButtonFebrero, Me.ToolStripButtonMarzo, Me.ToolStripButtonAbril, Me.ToolStripButtonMayo, Me.ToolStripButtonJunio, Me.ToolStripButtonJulio, Me.ToolStripButtonAgosto, Me.ToolStripButtonSeptiembre, Me.ToolStripButtonOctubre, Me.ToolStripButtonNoviembre, Me.ToolStripButtonDiciembre})
        Me.Consultar_Maquina_8ToolStrip.Location = New System.Drawing.Point(0, 25)
        Me.Consultar_Maquina_8ToolStrip.Name = "Consultar_Maquina_8ToolStrip"
        Me.Consultar_Maquina_8ToolStrip.Size = New System.Drawing.Size(920, 25)
        Me.Consultar_Maquina_8ToolStrip.TabIndex = 7
        Me.Consultar_Maquina_8ToolStrip.Text = "Consultar_Maquina_8ToolStrip"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(121, 22)
        Me.ToolStripLabel1.Text = "INPECCIÓN CALIDAD"
        '
        'ToolStripButtonEnero
        '
        Me.ToolStripButtonEnero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonEnero.Name = "ToolStripButtonEnero"
        Me.ToolStripButtonEnero.Size = New System.Drawing.Size(41, 22)
        Me.ToolStripButtonEnero.Text = "Enero"
        '
        'ToolStripButtonFebrero
        '
        Me.ToolStripButtonFebrero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonFebrero.Name = "ToolStripButtonFebrero"
        Me.ToolStripButtonFebrero.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripButtonFebrero.Text = "Febrero"
        '
        'ToolStripButtonMarzo
        '
        Me.ToolStripButtonMarzo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonMarzo.Name = "ToolStripButtonMarzo"
        Me.ToolStripButtonMarzo.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripButtonMarzo.Text = "Marzo"
        '
        'ToolStripButtonAbril
        '
        Me.ToolStripButtonAbril.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonAbril.Name = "ToolStripButtonAbril"
        Me.ToolStripButtonAbril.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripButtonAbril.Text = "Abril"
        '
        'ToolStripButtonMayo
        '
        Me.ToolStripButtonMayo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonMayo.Name = "ToolStripButtonMayo"
        Me.ToolStripButtonMayo.Size = New System.Drawing.Size(41, 22)
        Me.ToolStripButtonMayo.Text = "Mayo"
        '
        'ToolStripButtonJunio
        '
        Me.ToolStripButtonJunio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonJunio.Name = "ToolStripButtonJunio"
        Me.ToolStripButtonJunio.Size = New System.Drawing.Size(39, 22)
        Me.ToolStripButtonJunio.Text = "Junio"
        '
        'ToolStripButtonJulio
        '
        Me.ToolStripButtonJulio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonJulio.Name = "ToolStripButtonJulio"
        Me.ToolStripButtonJulio.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripButtonJulio.Text = "Julio"
        '
        'ToolStripButtonAgosto
        '
        Me.ToolStripButtonAgosto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonAgosto.Name = "ToolStripButtonAgosto"
        Me.ToolStripButtonAgosto.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButtonAgosto.Text = "Agosto"
        '
        'ToolStripButtonSeptiembre
        '
        Me.ToolStripButtonSeptiembre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonSeptiembre.Name = "ToolStripButtonSeptiembre"
        Me.ToolStripButtonSeptiembre.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripButtonSeptiembre.Text = "Septiembre"
        '
        'ToolStripButtonOctubre
        '
        Me.ToolStripButtonOctubre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonOctubre.Name = "ToolStripButtonOctubre"
        Me.ToolStripButtonOctubre.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripButtonOctubre.Text = "Octubre"
        '
        'ToolStripButtonNoviembre
        '
        Me.ToolStripButtonNoviembre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonNoviembre.Name = "ToolStripButtonNoviembre"
        Me.ToolStripButtonNoviembre.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripButtonNoviembre.Text = "Noviembre"
        '
        'ToolStripButtonDiciembre
        '
        Me.ToolStripButtonDiciembre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonDiciembre.Name = "ToolStripButtonDiciembre"
        Me.ToolStripButtonDiciembre.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripButtonDiciembre.Text = "Diciembre"
        '
        'F_V_CalidadTableAdapter2
        '
        Me.F_V_CalidadTableAdapter2.ClearBeforeFill = True
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Spic.My.Resources.Resources.excel
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'FrmReporteInspeccionCalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 560)
        Me.Controls.Add(Me.Consultar_Maquina_8ToolStrip)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.F_V_CalidadBindingNavigator)
        Me.Name = "FrmReporteInspeccionCalidad"
        Me.Text = "FrmReporteInspeccionCalidad"
        CType(Me.F_V_CalidadBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.F_V_CalidadBindingNavigator.ResumeLayout(False)
        Me.F_V_CalidadBindingNavigator.PerformLayout()
        CType(Me.F_V_CalidadBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRGPRODUCCIONDataSetCalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FVCalidadBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRGPRODUCCIONDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FVCalidadBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DATASETCALIDAD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Consultar_Maquina_8ToolStrip.ResumeLayout(False)
        Me.Consultar_Maquina_8ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PRGPRODUCCIONDataSetCalidad As PRGPRODUCCIONDataSetCalidad
    Friend WithEvents F_V_CalidadBindingSource As BindingSource
    Friend WithEvents F_V_CalidadTableAdapter As PRGPRODUCCIONDataSetCalidadTableAdapters.F_V_CalidadTableAdapter
    Friend WithEvents TableAdapterManager As PRGPRODUCCIONDataSetCalidadTableAdapters.TableAdapterManager
    Friend WithEvents F_V_CalidadBindingNavigator As BindingNavigator
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
    Friend WithEvents F_V_CalidadBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents PRGPRODUCCIONDataSet1 As PRGPRODUCCIONDataSet1
    Friend WithEvents FVCalidadBindingSource As BindingSource
    Friend WithEvents F_V_CalidadTableAdapter1 As PRGPRODUCCIONDataSet1TableAdapters.F_V_CalidadTableAdapter
    Friend WithEvents DATASETCALIDAD As DATASETCALIDAD
    Friend WithEvents FVCalidadBindingSource1 As BindingSource
    Friend WithEvents F_V_CalidadTableAdapter2 As DATASETCALIDADTableAdapters.F_V_CalidadTableAdapter
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FechaprodDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HoraDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CoddetalleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumeroOrdenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombresDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MaquinaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProdfinalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OperarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CantprogDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CalidadDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MateriaprimaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DiametroDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CircularidadDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PesoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AparienciaDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents ResistenciaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CashDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents HeliceDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents Consultar_Maquina_8ToolStrip As ToolStrip
    Friend WithEvents ToolStripButtonDiciembre As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripButtonEnero As ToolStripButton
    Friend WithEvents ToolStripButtonFebrero As ToolStripButton
    Friend WithEvents ToolStripButtonMarzo As ToolStripButton
    Friend WithEvents ToolStripButtonAbril As ToolStripButton
    Friend WithEvents ToolStripButtonMayo As ToolStripButton
    Friend WithEvents ToolStripButtonJunio As ToolStripButton
    Friend WithEvents ToolStripButtonJulio As ToolStripButton
    Friend WithEvents ToolStripButtonAgosto As ToolStripButton
    Friend WithEvents ToolStripButtonSeptiembre As ToolStripButton
    Friend WithEvents ToolStripButtonOctubre As ToolStripButton
    Friend WithEvents ToolStripButtonNoviembre As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class
