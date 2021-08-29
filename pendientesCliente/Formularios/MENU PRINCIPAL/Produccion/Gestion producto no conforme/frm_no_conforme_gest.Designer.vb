<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_no_conforme_gest
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
        Me.tb_no_conforme = New System.Windows.Forms.TabControl()
        Me.tb_tiqueto = New System.Windows.Forms.TabPage()
        Me.rdb_bodega3 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.lblcodigo = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.lbl_peso = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.rdb_bode12 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.btn_trasladar = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txt_lector = New System.Windows.Forms.TextBox()
        Me.rdb_bodega14 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdb_bodega13 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdb_bodega11 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdb_bodega2 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.lbl_area_origen = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.tb_kilos = New System.Windows.Forms.TabPage()
        Me.btn_trasladar_kilos = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lbl_kilos_Ing = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.rdb_bode12_kilos = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdb_bodega14_kilos = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdb_bodega13_kilos = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdb_bodega11_kilos = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.rdb_bodega2_kilos = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.rdb_bodega3_kilos = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.tb_no_conforme.SuspendLayout()
        Me.tb_tiqueto.SuspendLayout()
        Me.tb_kilos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_no_conforme
        '
        Me.tb_no_conforme.Controls.Add(Me.tb_tiqueto)
        Me.tb_no_conforme.Controls.Add(Me.tb_kilos)
        Me.tb_no_conforme.Location = New System.Drawing.Point(12, 12)
        Me.tb_no_conforme.Name = "tb_no_conforme"
        Me.tb_no_conforme.SelectedIndex = 0
        Me.tb_no_conforme.Size = New System.Drawing.Size(294, 283)
        Me.tb_no_conforme.TabIndex = 2
        '
        'tb_tiqueto
        '
        Me.tb_tiqueto.Controls.Add(Me.rdb_bodega3)
        Me.tb_tiqueto.Controls.Add(Me.lblcodigo)
        Me.tb_tiqueto.Controls.Add(Me.lbl_peso)
        Me.tb_tiqueto.Controls.Add(Me.rdb_bode12)
        Me.tb_tiqueto.Controls.Add(Me.btn_trasladar)
        Me.tb_tiqueto.Controls.Add(Me.txt_lector)
        Me.tb_tiqueto.Controls.Add(Me.rdb_bodega14)
        Me.tb_tiqueto.Controls.Add(Me.rdb_bodega13)
        Me.tb_tiqueto.Controls.Add(Me.rdb_bodega11)
        Me.tb_tiqueto.Controls.Add(Me.rdb_bodega2)
        Me.tb_tiqueto.Controls.Add(Me.lbl_area_origen)
        Me.tb_tiqueto.Location = New System.Drawing.Point(4, 22)
        Me.tb_tiqueto.Name = "tb_tiqueto"
        Me.tb_tiqueto.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_tiqueto.Size = New System.Drawing.Size(286, 257)
        Me.tb_tiqueto.TabIndex = 0
        Me.tb_tiqueto.Text = "Tiquete"
        Me.tb_tiqueto.UseVisualStyleBackColor = True
        '
        'rdb_bodega3
        '
        Me.rdb_bodega3.Location = New System.Drawing.Point(108, 23)
        Me.rdb_bodega3.Name = "rdb_bodega3"
        Me.rdb_bodega3.Size = New System.Drawing.Size(96, 20)
        Me.rdb_bodega3.TabIndex = 11
        Me.rdb_bodega3.Values.Text = "Bodega 3 tref"
        '
        'lblcodigo
        '
        Me.lblcodigo.Location = New System.Drawing.Point(134, 174)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(48, 20)
        Me.lblcodigo.TabIndex = 10
        Me.lblcodigo.Values.Text = "codigo"
        '
        'lbl_peso
        '
        Me.lbl_peso.Location = New System.Drawing.Point(134, 200)
        Me.lbl_peso.Name = "lbl_peso"
        Me.lbl_peso.Size = New System.Drawing.Size(37, 20)
        Me.lbl_peso.TabIndex = 9
        Me.lbl_peso.Values.Text = "peso"
        '
        'rdb_bode12
        '
        Me.rdb_bode12.Location = New System.Drawing.Point(108, 69)
        Me.rdb_bode12.Name = "rdb_bode12"
        Me.rdb_bode12.Size = New System.Drawing.Size(110, 20)
        Me.rdb_bode12.TabIndex = 8
        Me.rdb_bode12.Values.Text = "Bodega 12 punt"
        '
        'btn_trasladar
        '
        Me.btn_trasladar.Location = New System.Drawing.Point(108, 226)
        Me.btn_trasladar.Name = "btn_trasladar"
        Me.btn_trasladar.Size = New System.Drawing.Size(90, 25)
        Me.btn_trasladar.TabIndex = 7
        Me.btn_trasladar.Values.Text = "Trasladar a 4"
        '
        'txt_lector
        '
        Me.txt_lector.BackColor = System.Drawing.Color.Red
        Me.txt_lector.Location = New System.Drawing.Point(59, 146)
        Me.txt_lector.Name = "txt_lector"
        Me.txt_lector.Size = New System.Drawing.Size(190, 20)
        Me.txt_lector.TabIndex = 6
        '
        'rdb_bodega14
        '
        Me.rdb_bodega14.Location = New System.Drawing.Point(108, 121)
        Me.rdb_bodega14.Name = "rdb_bodega14"
        Me.rdb_bodega14.Size = New System.Drawing.Size(110, 20)
        Me.rdb_bodega14.TabIndex = 5
        Me.rdb_bodega14.Values.Text = "Bodega 14 puas"
        '
        'rdb_bodega13
        '
        Me.rdb_bodega13.Location = New System.Drawing.Point(108, 95)
        Me.rdb_bodega13.Name = "rdb_bodega13"
        Me.rdb_bodega13.Size = New System.Drawing.Size(131, 20)
        Me.rdb_bodega13.TabIndex = 4
        Me.rdb_bodega13.Values.Text = "Bodega 13 recocido"
        '
        'rdb_bodega11
        '
        Me.rdb_bodega11.Location = New System.Drawing.Point(108, 45)
        Me.rdb_bodega11.Name = "rdb_bodega11"
        Me.rdb_bodega11.Size = New System.Drawing.Size(113, 20)
        Me.rdb_bodega11.TabIndex = 2
        Me.rdb_bodega11.Values.Text = "Bodega 11 galva"
        '
        'rdb_bodega2
        '
        Me.rdb_bodega2.Location = New System.Drawing.Point(108, 3)
        Me.rdb_bodega2.Name = "rdb_bodega2"
        Me.rdb_bodega2.Size = New System.Drawing.Size(96, 20)
        Me.rdb_bodega2.TabIndex = 1
        Me.rdb_bodega2.Values.Text = "Bodega 2 tref"
        '
        'lbl_area_origen
        '
        Me.lbl_area_origen.Location = New System.Drawing.Point(3, 58)
        Me.lbl_area_origen.Name = "lbl_area_origen"
        Me.lbl_area_origen.Size = New System.Drawing.Size(77, 20)
        Me.lbl_area_origen.TabIndex = 0
        Me.lbl_area_origen.Values.Text = "Area origen:"
        '
        'tb_kilos
        '
        Me.tb_kilos.Controls.Add(Me.rdb_bodega3_kilos)
        Me.tb_kilos.Controls.Add(Me.btn_trasladar_kilos)
        Me.tb_kilos.Controls.Add(Me.lbl_kilos_Ing)
        Me.tb_kilos.Controls.Add(Me.KryptonLabel2)
        Me.tb_kilos.Controls.Add(Me.rdb_bode12_kilos)
        Me.tb_kilos.Controls.Add(Me.rdb_bodega14_kilos)
        Me.tb_kilos.Controls.Add(Me.rdb_bodega13_kilos)
        Me.tb_kilos.Controls.Add(Me.rdb_bodega11_kilos)
        Me.tb_kilos.Controls.Add(Me.rdb_bodega2_kilos)
        Me.tb_kilos.Controls.Add(Me.KryptonLabel1)
        Me.tb_kilos.Location = New System.Drawing.Point(4, 22)
        Me.tb_kilos.Name = "tb_kilos"
        Me.tb_kilos.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_kilos.Size = New System.Drawing.Size(286, 257)
        Me.tb_kilos.TabIndex = 1
        Me.tb_kilos.Text = "Kilos"
        Me.tb_kilos.UseVisualStyleBackColor = True
        '
        'btn_trasladar_kilos
        '
        Me.btn_trasladar_kilos.Location = New System.Drawing.Point(89, 226)
        Me.btn_trasladar_kilos.Name = "btn_trasladar_kilos"
        Me.btn_trasladar_kilos.Size = New System.Drawing.Size(90, 25)
        Me.btn_trasladar_kilos.TabIndex = 17
        Me.btn_trasladar_kilos.Values.Text = "Trasladar"
        '
        'lbl_kilos_Ing
        '
        Me.lbl_kilos_Ing.Location = New System.Drawing.Point(116, 188)
        Me.lbl_kilos_Ing.Name = "lbl_kilos_Ing"
        Me.lbl_kilos_Ing.Size = New System.Drawing.Size(100, 23)
        Me.lbl_kilos_Ing.TabIndex = 16
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(64, 188)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(36, 20)
        Me.KryptonLabel2.TabIndex = 15
        Me.KryptonLabel2.Values.Text = "Kilos"
        '
        'rdb_bode12_kilos
        '
        Me.rdb_bode12_kilos.Location = New System.Drawing.Point(116, 100)
        Me.rdb_bode12_kilos.Name = "rdb_bode12_kilos"
        Me.rdb_bode12_kilos.Size = New System.Drawing.Size(110, 20)
        Me.rdb_bode12_kilos.TabIndex = 14
        Me.rdb_bode12_kilos.Values.Text = "Bodega 12 punt"
        '
        'rdb_bodega14_kilos
        '
        Me.rdb_bodega14_kilos.Location = New System.Drawing.Point(116, 153)
        Me.rdb_bodega14_kilos.Name = "rdb_bodega14_kilos"
        Me.rdb_bodega14_kilos.Size = New System.Drawing.Size(110, 20)
        Me.rdb_bodega14_kilos.TabIndex = 13
        Me.rdb_bodega14_kilos.Values.Text = "Bodega 14 puas"
        '
        'rdb_bodega13_kilos
        '
        Me.rdb_bodega13_kilos.Location = New System.Drawing.Point(116, 127)
        Me.rdb_bodega13_kilos.Name = "rdb_bodega13_kilos"
        Me.rdb_bodega13_kilos.Size = New System.Drawing.Size(131, 20)
        Me.rdb_bodega13_kilos.TabIndex = 12
        Me.rdb_bodega13_kilos.Values.Text = "Bodega 13 recocido"
        '
        'rdb_bodega11_kilos
        '
        Me.rdb_bodega11_kilos.Location = New System.Drawing.Point(116, 75)
        Me.rdb_bodega11_kilos.Name = "rdb_bodega11_kilos"
        Me.rdb_bodega11_kilos.Size = New System.Drawing.Size(113, 20)
        Me.rdb_bodega11_kilos.TabIndex = 11
        Me.rdb_bodega11_kilos.Values.Text = "Bodega 11 galva"
        '
        'rdb_bodega2_kilos
        '
        Me.rdb_bodega2_kilos.Location = New System.Drawing.Point(116, 28)
        Me.rdb_bodega2_kilos.Name = "rdb_bodega2_kilos"
        Me.rdb_bodega2_kilos.Size = New System.Drawing.Size(96, 20)
        Me.rdb_bodega2_kilos.TabIndex = 10
        Me.rdb_bodega2_kilos.Values.Text = "Bodega 2 tref"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 82)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(83, 20)
        Me.KryptonLabel1.TabIndex = 9
        Me.KryptonLabel1.Values.Text = "Area Destino:"
        '
        'rdb_bodega3_kilos
        '
        Me.rdb_bodega3_kilos.Location = New System.Drawing.Point(116, 50)
        Me.rdb_bodega3_kilos.Name = "rdb_bodega3_kilos"
        Me.rdb_bodega3_kilos.Size = New System.Drawing.Size(96, 20)
        Me.rdb_bodega3_kilos.TabIndex = 18
        Me.rdb_bodega3_kilos.Values.Text = "Bodega 3 tref"
        '
        'frm_no_conforme_gest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 298)
        Me.Controls.Add(Me.tb_no_conforme)
        Me.Name = "frm_no_conforme_gest"
        Me.Text = "Gestion de no conformes"
        Me.tb_no_conforme.ResumeLayout(False)
        Me.tb_tiqueto.ResumeLayout(False)
        Me.tb_tiqueto.PerformLayout()
        Me.tb_kilos.ResumeLayout(False)
        Me.tb_kilos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tb_no_conforme As TabControl
    Friend WithEvents tb_tiqueto As TabPage
    Friend WithEvents btn_trasladar As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txt_lector As TextBox
    Friend WithEvents rdb_bodega14 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega13 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega11 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega2 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents lbl_area_origen As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents tb_kilos As TabPage
    Friend WithEvents rdb_bode12 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents lbl_peso As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents lblcodigo As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents rdb_bode12_kilos As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega14_kilos As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega13_kilos As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega11_kilos As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega2_kilos As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents btn_trasladar_kilos As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lbl_kilos_Ing As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents rdb_bodega3 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rdb_bodega3_kilos As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
End Class
