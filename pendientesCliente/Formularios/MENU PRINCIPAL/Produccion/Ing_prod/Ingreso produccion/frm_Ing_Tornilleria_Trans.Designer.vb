<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Ing_Tornilleria_Trans
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
        Me.lbl_Codigo_E = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_Codigo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.btn_Realizar_Transaccion_En = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btn_Realizar_Transaccion_Sal = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.cbo_Codigo_Ent = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cbo_Codigo_Sal = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.dtg_Trans_Entrada = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.lbl_kilos = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_Kilos2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.txt_Kilos = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.txt_Kilos1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.lbl_Saldo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonSeparator1 = New ComponentFactory.Krypton.Toolkit.KryptonSeparator()
        Me.KryptonHeader1 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        Me.KryptonHeader2 = New ComponentFactory.Krypton.Toolkit.KryptonHeader()
        CType(Me.cbo_Codigo_Ent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Codigo_Sal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_Trans_Entrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Codigo_E
        '
        Me.lbl_Codigo_E.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Codigo_E.Location = New System.Drawing.Point(145, 352)
        Me.lbl_Codigo_E.Name = "lbl_Codigo_E"
        Me.lbl_Codigo_E.Size = New System.Drawing.Size(53, 20)
        Me.lbl_Codigo_E.TabIndex = 0
        Me.lbl_Codigo_E.Values.Text = "Codigo:"
        '
        'lbl_Codigo
        '
        Me.lbl_Codigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Codigo.Location = New System.Drawing.Point(500, 353)
        Me.lbl_Codigo.Name = "lbl_Codigo"
        Me.lbl_Codigo.Size = New System.Drawing.Size(53, 20)
        Me.lbl_Codigo.TabIndex = 0
        Me.lbl_Codigo.Values.Text = "Codigo:"
        '
        'btn_Realizar_Transaccion_En
        '
        Me.btn_Realizar_Transaccion_En.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Realizar_Transaccion_En.Location = New System.Drawing.Point(177, 410)
        Me.btn_Realizar_Transaccion_En.Name = "btn_Realizar_Transaccion_En"
        Me.btn_Realizar_Transaccion_En.Size = New System.Drawing.Size(132, 25)
        Me.btn_Realizar_Transaccion_En.TabIndex = 1
        Me.btn_Realizar_Transaccion_En.Values.Text = "Realizar transacción"
        '
        'btn_Realizar_Transaccion_Sal
        '
        Me.btn_Realizar_Transaccion_Sal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_Realizar_Transaccion_Sal.Location = New System.Drawing.Point(537, 410)
        Me.btn_Realizar_Transaccion_Sal.Name = "btn_Realizar_Transaccion_Sal"
        Me.btn_Realizar_Transaccion_Sal.Size = New System.Drawing.Size(124, 25)
        Me.btn_Realizar_Transaccion_Sal.TabIndex = 1
        Me.btn_Realizar_Transaccion_Sal.Values.Text = "Realizar transacción"
        '
        'cbo_Codigo_Ent
        '
        Me.cbo_Codigo_Ent.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_Codigo_Ent.DropDownWidth = 121
        Me.cbo_Codigo_Ent.Location = New System.Drawing.Point(214, 352)
        Me.cbo_Codigo_Ent.Name = "cbo_Codigo_Ent"
        Me.cbo_Codigo_Ent.Size = New System.Drawing.Size(121, 21)
        Me.cbo_Codigo_Ent.TabIndex = 2
        '
        'cbo_Codigo_Sal
        '
        Me.cbo_Codigo_Sal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbo_Codigo_Sal.DropDownWidth = 121
        Me.cbo_Codigo_Sal.Location = New System.Drawing.Point(559, 352)
        Me.cbo_Codigo_Sal.Name = "cbo_Codigo_Sal"
        Me.cbo_Codigo_Sal.Size = New System.Drawing.Size(121, 21)
        Me.cbo_Codigo_Sal.TabIndex = 2
        '
        'dtg_Trans_Entrada
        '
        Me.dtg_Trans_Entrada.AllowUserToAddRows = False
        Me.dtg_Trans_Entrada.AllowUserToDeleteRows = False
        Me.dtg_Trans_Entrada.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtg_Trans_Entrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_Trans_Entrada.Location = New System.Drawing.Point(72, 38)
        Me.dtg_Trans_Entrada.Name = "dtg_Trans_Entrada"
        Me.dtg_Trans_Entrada.ReadOnly = True
        Me.dtg_Trans_Entrada.Size = New System.Drawing.Size(669, 248)
        Me.dtg_Trans_Entrada.TabIndex = 3
        '
        'lbl_kilos
        '
        Me.lbl_kilos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_kilos.Location = New System.Drawing.Point(513, 384)
        Me.lbl_kilos.Name = "lbl_kilos"
        Me.lbl_kilos.Size = New System.Drawing.Size(39, 20)
        Me.lbl_kilos.TabIndex = 4
        Me.lbl_kilos.Values.Text = "Kilos:"
        '
        'lbl_Kilos2
        '
        Me.lbl_Kilos2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Kilos2.Location = New System.Drawing.Point(159, 384)
        Me.lbl_Kilos2.Name = "lbl_Kilos2"
        Me.lbl_Kilos2.Size = New System.Drawing.Size(39, 20)
        Me.lbl_Kilos2.TabIndex = 5
        Me.lbl_Kilos2.Values.Text = "Kilos:"
        '
        'txt_Kilos
        '
        Me.txt_Kilos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Kilos.Location = New System.Drawing.Point(214, 381)
        Me.txt_Kilos.Name = "txt_Kilos"
        Me.txt_Kilos.Size = New System.Drawing.Size(121, 23)
        Me.txt_Kilos.TabIndex = 6
        '
        'txt_Kilos1
        '
        Me.txt_Kilos1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Kilos1.Location = New System.Drawing.Point(559, 381)
        Me.txt_Kilos1.Name = "txt_Kilos1"
        Me.txt_Kilos1.Size = New System.Drawing.Size(121, 23)
        Me.txt_Kilos1.TabIndex = 7
        '
        'lbl_Saldo
        '
        Me.lbl_Saldo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_Saldo.Location = New System.Drawing.Point(364, 12)
        Me.lbl_Saldo.Name = "lbl_Saldo"
        Me.lbl_Saldo.Size = New System.Drawing.Size(102, 20)
        Me.lbl_Saldo.TabIndex = 7
        Me.lbl_Saldo.Values.Text = "Saldo Disponible"
        '
        'KryptonSeparator1
        '
        Me.KryptonSeparator1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.KryptonSeparator1.Location = New System.Drawing.Point(403, 292)
        Me.KryptonSeparator1.Name = "KryptonSeparator1"
        Me.KryptonSeparator1.Size = New System.Drawing.Size(17, 162)
        Me.KryptonSeparator1.TabIndex = 8
        '
        'KryptonHeader1
        '
        Me.KryptonHeader1.Location = New System.Drawing.Point(145, 315)
        Me.KryptonHeader1.Name = "KryptonHeader1"
        Me.KryptonHeader1.Size = New System.Drawing.Size(214, 31)
        Me.KryptonHeader1.TabIndex = 9
        Me.KryptonHeader1.Values.Description = ""
        Me.KryptonHeader1.Values.Heading = "Entrada de tornilleria"
        '
        'KryptonHeader2
        '
        Me.KryptonHeader2.Location = New System.Drawing.Point(500, 315)
        Me.KryptonHeader2.Name = "KryptonHeader2"
        Me.KryptonHeader2.Size = New System.Drawing.Size(199, 31)
        Me.KryptonHeader2.TabIndex = 10
        Me.KryptonHeader2.Values.Description = ""
        Me.KryptonHeader2.Values.Heading = "Salida de tornilleria"
        '
        'frm_Ing_Tornilleria_Trans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 458)
        Me.Controls.Add(Me.KryptonHeader2)
        Me.Controls.Add(Me.KryptonHeader1)
        Me.Controls.Add(Me.KryptonSeparator1)
        Me.Controls.Add(Me.txt_Kilos1)
        Me.Controls.Add(Me.txt_Kilos)
        Me.Controls.Add(Me.lbl_kilos)
        Me.Controls.Add(Me.lbl_Kilos2)
        Me.Controls.Add(Me.cbo_Codigo_Sal)
        Me.Controls.Add(Me.dtg_Trans_Entrada)
        Me.Controls.Add(Me.btn_Realizar_Transaccion_Sal)
        Me.Controls.Add(Me.lbl_Codigo)
        Me.Controls.Add(Me.lbl_Saldo)
        Me.Controls.Add(Me.cbo_Codigo_Ent)
        Me.Controls.Add(Me.lbl_Codigo_E)
        Me.Controls.Add(Me.btn_Realizar_Transaccion_En)
        Me.MaximizeBox = False
        Me.Name = "frm_Ing_Tornilleria_Trans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transacciones de tornilleria"
        CType(Me.cbo_Codigo_Ent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Codigo_Sal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_Trans_Entrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo_Codigo_Ent As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btn_Realizar_Transaccion_En As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lbl_Codigo_E As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_Codigo_Sal As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btn_Realizar_Transaccion_Sal As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lbl_Codigo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents txt_Kilos As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lbl_Kilos2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents dtg_Trans_Entrada As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents txt_Kilos1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents lbl_kilos As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lbl_Saldo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonSeparator1 As ComponentFactory.Krypton.Toolkit.KryptonSeparator
    Friend WithEvents KryptonHeader1 As ComponentFactory.Krypton.Toolkit.KryptonHeader
    Friend WithEvents KryptonHeader2 As ComponentFactory.Krypton.Toolkit.KryptonHeader
End Class
