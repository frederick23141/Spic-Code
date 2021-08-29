<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_planilla_inspeccion
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
        Me.lbl_conformado = New System.Windows.Forms.Label()
        Me.chk_conformado = New System.Windows.Forms.CheckBox()
        Me.lbl_longitud = New System.Windows.Forms.Label()
        Me.chk_longitud = New System.Windows.Forms.CheckBox()
        Me.lbl_torsion = New System.Windows.Forms.Label()
        Me.txt_torsion = New System.Windows.Forms.NumericUpDown()
        Me.lbl_simetria = New System.Windows.Forms.Label()
        Me.btn_planilla = New System.Windows.Forms.Button()
        Me.chk_simetria = New System.Windows.Forms.CheckBox()
        Me.lbl_emp = New System.Windows.Forms.Label()
        Me.txt_empate = New System.Windows.Forms.TextBox()
        Me.pb_puas = New System.Windows.Forms.PictureBox()
        CType(Me.txt_torsion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_puas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_conformado
        '
        Me.lbl_conformado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_conformado.AutoSize = True
        Me.lbl_conformado.Location = New System.Drawing.Point(36, 27)
        Me.lbl_conformado.Name = "lbl_conformado"
        Me.lbl_conformado.Size = New System.Drawing.Size(67, 13)
        Me.lbl_conformado.TabIndex = 0
        Me.lbl_conformado.Text = "Conformado:"
        '
        'chk_conformado
        '
        Me.chk_conformado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_conformado.AutoSize = True
        Me.chk_conformado.Location = New System.Drawing.Point(123, 30)
        Me.chk_conformado.Name = "chk_conformado"
        Me.chk_conformado.Size = New System.Drawing.Size(15, 14)
        Me.chk_conformado.TabIndex = 1
        Me.chk_conformado.UseVisualStyleBackColor = True
        '
        'lbl_longitud
        '
        Me.lbl_longitud.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_longitud.AutoSize = True
        Me.lbl_longitud.Location = New System.Drawing.Point(159, 28)
        Me.lbl_longitud.Name = "lbl_longitud"
        Me.lbl_longitud.Size = New System.Drawing.Size(72, 13)
        Me.lbl_longitud.TabIndex = 2
        Me.lbl_longitud.Text = "Longitud pua:"
        '
        'chk_longitud
        '
        Me.chk_longitud.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_longitud.AutoSize = True
        Me.chk_longitud.Location = New System.Drawing.Point(246, 28)
        Me.chk_longitud.Name = "chk_longitud"
        Me.chk_longitud.Size = New System.Drawing.Size(15, 14)
        Me.chk_longitud.TabIndex = 3
        Me.chk_longitud.UseVisualStyleBackColor = True
        '
        'lbl_torsion
        '
        Me.lbl_torsion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_torsion.AutoSize = True
        Me.lbl_torsion.Location = New System.Drawing.Point(159, 59)
        Me.lbl_torsion.Name = "lbl_torsion"
        Me.lbl_torsion.Size = New System.Drawing.Size(45, 13)
        Me.lbl_torsion.TabIndex = 4
        Me.lbl_torsion.Text = "Torsión:"
        '
        'txt_torsion
        '
        Me.txt_torsion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_torsion.Location = New System.Drawing.Point(211, 57)
        Me.txt_torsion.Name = "txt_torsion"
        Me.txt_torsion.Size = New System.Drawing.Size(64, 20)
        Me.txt_torsion.TabIndex = 5
        '
        'lbl_simetria
        '
        Me.lbl_simetria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_simetria.AutoSize = True
        Me.lbl_simetria.Location = New System.Drawing.Point(56, 61)
        Me.lbl_simetria.Name = "lbl_simetria"
        Me.lbl_simetria.Size = New System.Drawing.Size(47, 13)
        Me.lbl_simetria.TabIndex = 9
        Me.lbl_simetria.Text = "Simetria:"
        '
        'btn_planilla
        '
        Me.btn_planilla.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_planilla.Location = New System.Drawing.Point(123, 137)
        Me.btn_planilla.Name = "btn_planilla"
        Me.btn_planilla.Size = New System.Drawing.Size(75, 23)
        Me.btn_planilla.TabIndex = 11
        Me.btn_planilla.Text = "ingresar"
        Me.btn_planilla.UseVisualStyleBackColor = True
        '
        'chk_simetria
        '
        Me.chk_simetria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chk_simetria.AutoSize = True
        Me.chk_simetria.Location = New System.Drawing.Point(123, 61)
        Me.chk_simetria.Name = "chk_simetria"
        Me.chk_simetria.Size = New System.Drawing.Size(15, 14)
        Me.chk_simetria.TabIndex = 12
        Me.chk_simetria.UseVisualStyleBackColor = True
        '
        'lbl_emp
        '
        Me.lbl_emp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_emp.AutoSize = True
        Me.lbl_emp.Location = New System.Drawing.Point(88, 105)
        Me.lbl_emp.Name = "lbl_emp"
        Me.lbl_emp.Size = New System.Drawing.Size(73, 13)
        Me.lbl_emp.TabIndex = 13
        Me.lbl_emp.Text = "Empates rollo:"
        '
        'txt_empate
        '
        Me.txt_empate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_empate.Location = New System.Drawing.Point(167, 102)
        Me.txt_empate.Name = "txt_empate"
        Me.txt_empate.Size = New System.Drawing.Size(51, 20)
        Me.txt_empate.TabIndex = 14
        '
        'pb_puas
        '
        Me.pb_puas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pb_puas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_puas.Image = Global.Spic.My.Resources.Resources.puas_conforme
        Me.pb_puas.Location = New System.Drawing.Point(39, 181)
        Me.pb_puas.Name = "pb_puas"
        Me.pb_puas.Size = New System.Drawing.Size(222, 121)
        Me.pb_puas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pb_puas.TabIndex = 15
        Me.pb_puas.TabStop = False
        '
        'frm_planilla_inspeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 330)
        Me.Controls.Add(Me.pb_puas)
        Me.Controls.Add(Me.txt_empate)
        Me.Controls.Add(Me.lbl_emp)
        Me.Controls.Add(Me.chk_simetria)
        Me.Controls.Add(Me.btn_planilla)
        Me.Controls.Add(Me.lbl_simetria)
        Me.Controls.Add(Me.txt_torsion)
        Me.Controls.Add(Me.lbl_torsion)
        Me.Controls.Add(Me.chk_longitud)
        Me.Controls.Add(Me.lbl_longitud)
        Me.Controls.Add(Me.chk_conformado)
        Me.Controls.Add(Me.lbl_conformado)
        Me.Name = "frm_planilla_inspeccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla de inspección"
        CType(Me.txt_torsion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_puas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_conformado As System.Windows.Forms.Label
    Friend WithEvents chk_conformado As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_longitud As System.Windows.Forms.Label
    Friend WithEvents chk_longitud As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_torsion As System.Windows.Forms.Label
    Friend WithEvents txt_torsion As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl_simetria As System.Windows.Forms.Label
    Friend WithEvents btn_planilla As System.Windows.Forms.Button
    Friend WithEvents chk_simetria As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_emp As System.Windows.Forms.Label
    Friend WithEvents txt_empate As System.Windows.Forms.TextBox
    Friend WithEvents pb_puas As System.Windows.Forms.PictureBox
End Class
