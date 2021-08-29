<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_informe_paros_puas
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
        Me.dtg_paros = New System.Windows.Forms.DataGridView()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_Ano = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Cbo_Mes = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.btn_carga = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnExcel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.cbo_maquina = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        CType(Me.dtg_paros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Ano, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_Mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_maquina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtg_paros
        '
        Me.dtg_paros.AllowUserToAddRows = False
        Me.dtg_paros.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtg_paros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_paros.Location = New System.Drawing.Point(12, 64)
        Me.dtg_paros.Name = "dtg_paros"
        Me.dtg_paros.RowHeadersVisible = False
        Me.dtg_paros.Size = New System.Drawing.Size(776, 379)
        Me.dtg_paros.TabIndex = 1
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel1.Location = New System.Drawing.Point(55, 29)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(35, 20)
        Me.KryptonLabel1.TabIndex = 2
        Me.KryptonLabel1.Values.Text = "Año:"
        '
        'cbo_Ano
        '
        Me.cbo_Ano.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_Ano.DropDownWidth = 83
        Me.cbo_Ano.Location = New System.Drawing.Point(96, 28)
        Me.cbo_Ano.Name = "cbo_Ano"
        Me.cbo_Ano.Size = New System.Drawing.Size(83, 21)
        Me.cbo_Ano.TabIndex = 3
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel2.Location = New System.Drawing.Point(207, 27)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(36, 20)
        Me.KryptonLabel2.TabIndex = 4
        Me.KryptonLabel2.Values.Text = "Mes:"
        '
        'Cbo_Mes
        '
        Me.Cbo_Mes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Cbo_Mes.DropDownWidth = 58
        Me.Cbo_Mes.Items.AddRange(New Object() {"Seleccione", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cbo_Mes.Location = New System.Drawing.Point(240, 27)
        Me.Cbo_Mes.Name = "Cbo_Mes"
        Me.Cbo_Mes.Size = New System.Drawing.Size(58, 21)
        Me.Cbo_Mes.TabIndex = 5
        '
        'btn_carga
        '
        Me.btn_carga.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_carga.Location = New System.Drawing.Point(329, 7)
        Me.btn_carga.Name = "btn_carga"
        Me.btn_carga.Size = New System.Drawing.Size(70, 46)
        Me.btn_carga.TabIndex = 6
        Me.btn_carga.Values.Text = "Cargar"
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnExcel.Location = New System.Drawing.Point(405, 7)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(64, 46)
        Me.btnExcel.TabIndex = 7
        Me.btnExcel.Values.Image = Global.Spic.My.Resources.Resources.excel10
        Me.btnExcel.Values.Text = ""
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.KryptonLabel3.Location = New System.Drawing.Point(502, 25)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(61, 20)
        Me.KryptonLabel3.TabIndex = 8
        Me.KryptonLabel3.Values.Text = "Máquina:"
        '
        'cbo_maquina
        '
        Me.cbo_maquina.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbo_maquina.DropDownWidth = 121
        Me.cbo_maquina.Location = New System.Drawing.Point(562, 24)
        Me.cbo_maquina.Name = "cbo_maquina"
        Me.cbo_maquina.Size = New System.Drawing.Size(121, 21)
        Me.cbo_maquina.TabIndex = 9
        '
        'Frm_informe_paros_puas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cbo_maquina)
        Me.Controls.Add(Me.KryptonLabel3)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btn_carga)
        Me.Controls.Add(Me.Cbo_Mes)
        Me.Controls.Add(Me.KryptonLabel2)
        Me.Controls.Add(Me.cbo_Ano)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.dtg_paros)
        Me.MaximizeBox = False
        Me.Name = "Frm_informe_paros_puas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de paros púas"
        CType(Me.dtg_paros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Ano, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_Mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_maquina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtg_paros As DataGridView
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_Ano As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Cbo_Mes As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents btn_carga As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnExcel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents cbo_maquina As ComponentFactory.Krypton.Toolkit.KryptonComboBox
End Class
