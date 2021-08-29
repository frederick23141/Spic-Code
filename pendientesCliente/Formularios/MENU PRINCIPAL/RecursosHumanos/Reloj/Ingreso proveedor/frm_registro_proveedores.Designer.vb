<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_registro_proveedores
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
        Me.lbl_nomb_prov = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_nit_prov = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txt_nomb_prov = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txt_nit_prov = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btn_guardar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txt_empresa = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.blinding_temporales = New System.Windows.Forms.BindingSource(Me.components)
        Me.txt_buscar = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lbl_Buscar = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.dtg_contratista = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AsignarDiasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarDiasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.blinding_temporales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_contratista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_nomb_prov
        '
        Me.lbl_nomb_prov.Location = New System.Drawing.Point(292, 55)
        Me.lbl_nomb_prov.Name = "lbl_nomb_prov"
        Me.lbl_nomb_prov.Size = New System.Drawing.Size(119, 20)
        Me.lbl_nomb_prov.TabIndex = 1
        Me.lbl_nomb_prov.Values.Text = "Nombre contratista:"
        '
        'lbl_nit_prov
        '
        Me.lbl_nit_prov.Location = New System.Drawing.Point(312, 12)
        Me.lbl_nit_prov.Name = "lbl_nit_prov"
        Me.lbl_nit_prov.Size = New System.Drawing.Size(91, 20)
        Me.lbl_nit_prov.TabIndex = 2
        Me.lbl_nit_prov.Values.Text = "Nit contratista:"
        '
        'txt_nomb_prov
        '
        Me.txt_nomb_prov.Location = New System.Drawing.Point(429, 52)
        Me.txt_nomb_prov.Name = "txt_nomb_prov"
        Me.txt_nomb_prov.Size = New System.Drawing.Size(100, 23)
        Me.txt_nomb_prov.TabIndex = 3
        '
        'txt_nit_prov
        '
        Me.txt_nit_prov.Location = New System.Drawing.Point(428, 9)
        Me.txt_nit_prov.Name = "txt_nit_prov"
        Me.txt_nit_prov.Size = New System.Drawing.Size(100, 23)
        Me.txt_nit_prov.TabIndex = 4
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(357, 144)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(120, 25)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Values.Text = "Guardar "
        '
        'txt_empresa
        '
        Me.txt_empresa.Location = New System.Drawing.Point(427, 97)
        Me.txt_empresa.Name = "txt_empresa"
        Me.txt_empresa.Size = New System.Drawing.Size(100, 23)
        Me.txt_empresa.TabIndex = 7
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(304, 100)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(108, 20)
        Me.KryptonLabel1.TabIndex = 6
        Me.KryptonLabel1.Values.Text = "Nombre empresa:"
        '
        'blinding_temporales
        '
        Me.blinding_temporales.Filter = "nit"
        '
        'txt_buscar
        '
        Me.txt_buscar.Location = New System.Drawing.Point(425, 188)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(100, 23)
        Me.txt_buscar.TabIndex = 9
        '
        'lbl_Buscar
        '
        Me.lbl_Buscar.Location = New System.Drawing.Point(350, 191)
        Me.lbl_Buscar.Name = "lbl_Buscar"
        Me.lbl_Buscar.Size = New System.Drawing.Size(49, 20)
        Me.lbl_Buscar.TabIndex = 10
        Me.lbl_Buscar.Values.Text = "Buscar:"
        '
        'dtg_contratista
        '
        Me.dtg_contratista.AllowUserToAddRows = False
        Me.dtg_contratista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_contratista.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dtg_contratista.Location = New System.Drawing.Point(12, 224)
        Me.dtg_contratista.Name = "dtg_contratista"
        Me.dtg_contratista.RowHeadersVisible = False
        Me.dtg_contratista.Size = New System.Drawing.Size(776, 255)
        Me.dtg_contratista.TabIndex = 11
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsignarDiasToolStripMenuItem, Me.ConsultarDiasToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 48)
        '
        'AsignarDiasToolStripMenuItem
        '
        Me.AsignarDiasToolStripMenuItem.Image = Global.Spic.My.Resources.Resources._1379531393_radio_button_on
        Me.AsignarDiasToolStripMenuItem.Name = "AsignarDiasToolStripMenuItem"
        Me.AsignarDiasToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AsignarDiasToolStripMenuItem.Text = "Asignar dias"
        '
        'ConsultarDiasToolStripMenuItem
        '
        Me.ConsultarDiasToolStripMenuItem.Image = Global.Spic.My.Resources.Resources.busc
        Me.ConsultarDiasToolStripMenuItem.Name = "ConsultarDiasToolStripMenuItem"
        Me.ConsultarDiasToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ConsultarDiasToolStripMenuItem.Text = "Consultar dias"
        '
        'frm_registro_proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 491)
        Me.Controls.Add(Me.dtg_contratista)
        Me.Controls.Add(Me.lbl_Buscar)
        Me.Controls.Add(Me.txt_buscar)
        Me.Controls.Add(Me.txt_empresa)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.txt_nit_prov)
        Me.Controls.Add(Me.txt_nomb_prov)
        Me.Controls.Add(Me.lbl_nit_prov)
        Me.Controls.Add(Me.lbl_nomb_prov)
        Me.MaximizeBox = False
        Me.Name = "frm_registro_proveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de contratistas"
        CType(Me.blinding_temporales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_contratista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_nomb_prov As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_nit_prov As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txt_nomb_prov As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents txt_nit_prov As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btn_guardar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txt_empresa As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents blinding_temporales As BindingSource
    Friend WithEvents txt_buscar As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lbl_Buscar As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtg_contratista As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AsignarDiasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultarDiasToolStripMenuItem As ToolStripMenuItem
End Class
