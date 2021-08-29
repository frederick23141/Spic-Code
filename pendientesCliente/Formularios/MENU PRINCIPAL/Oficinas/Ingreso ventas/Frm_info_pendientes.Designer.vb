<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_info_pendientes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.lblNombres = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.lblNit = New System.Windows.Forms.Label()
        Me.dtg_pend = New System.Windows.Forms.DataGridView()
        Me.txt_cant_desp = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.txt_cant_ped = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.txt_vr_unit = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.txt_vr_tot = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txt_pend = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txt_kilos_pend = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.btn_ped_prob = New System.Windows.Forms.Button()
        Me.txt_vrtot_prob = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        CType(Me.dtg_pend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombres
        '
        Me.txtNombres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombres.Location = New System.Drawing.Point(171, 43)
        Me.txtNombres.MaxLength = 40
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(438, 20)
        Me.txtNombres.TabIndex = 20
        '
        'lblNombres
        '
        Me.lblNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombres.Location = New System.Drawing.Point(171, 23)
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.Size = New System.Drawing.Size(87, 20)
        Me.lblNombres.TabIndex = 19
        Me.lblNombres.Text = "Nombres:"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(19, 43)
        Me.txtNit.MaxLength = 13
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(134, 20)
        Me.txtNit.TabIndex = 18
        '
        'lblNit
        '
        Me.lblNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNit.Location = New System.Drawing.Point(19, 23)
        Me.lblNit.Name = "lblNit"
        Me.lblNit.Size = New System.Drawing.Size(40, 20)
        Me.lblNit.TabIndex = 17
        Me.lblNit.Text = "Nit:"
        '
        'dtg_pend
        '
        Me.dtg_pend.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_pend.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_pend.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_pend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_pend.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_pend.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_pend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtg_pend.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtg_pend.Location = New System.Drawing.Point(9, 73)
        Me.dtg_pend.Name = "dtg_pend"
        Me.dtg_pend.ReadOnly = True
        Me.dtg_pend.RowHeadersVisible = False
        Me.dtg_pend.Size = New System.Drawing.Size(916, 525)
        Me.dtg_pend.TabIndex = 16
        '
        'txt_cant_desp
        '
        Me.txt_cant_desp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_cant_desp.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_cant_desp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cant_desp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cant_desp.Location = New System.Drawing.Point(582, 610)
        Me.txt_cant_desp.Name = "txt_cant_desp"
        Me.txt_cant_desp.Size = New System.Drawing.Size(61, 20)
        Me.txt_cant_desp.TabIndex = 151
        Me.txt_cant_desp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox12
        '
        Me.TextBox12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox12.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(510, 610)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(73, 20)
        Me.TextBox12.TabIndex = 150
        Me.TextBox12.Text = "Cant_desp:"
        '
        'txt_cant_ped
        '
        Me.txt_cant_ped.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_cant_ped.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_cant_ped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cant_ped.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cant_ped.Location = New System.Drawing.Point(446, 610)
        Me.txt_cant_ped.Name = "txt_cant_ped"
        Me.txt_cant_ped.Size = New System.Drawing.Size(59, 20)
        Me.txt_cant_ped.TabIndex = 149
        Me.txt_cant_ped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox8.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(383, 610)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(64, 20)
        Me.TextBox8.TabIndex = 148
        Me.TextBox8.Text = "Cant_ped:"
        '
        'txt_vr_unit
        '
        Me.txt_vr_unit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_vr_unit.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_vr_unit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vr_unit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vr_unit.Location = New System.Drawing.Point(257, 609)
        Me.txt_vr_unit.Name = "txt_vr_unit"
        Me.txt_vr_unit.Size = New System.Drawing.Size(121, 20)
        Me.txt_vr_unit.TabIndex = 147
        Me.txt_vr_unit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(197, 609)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(61, 20)
        Me.TextBox6.TabIndex = 146
        Me.TextBox6.Text = "Vr_unit:"
        '
        'txt_vr_tot
        '
        Me.txt_vr_tot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_vr_tot.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_vr_tot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vr_tot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vr_tot.Location = New System.Drawing.Point(72, 609)
        Me.txt_vr_tot.Name = "txt_vr_tot"
        Me.txt_vr_tot.Size = New System.Drawing.Size(119, 20)
        Me.txt_vr_tot.TabIndex = 145
        Me.txt_vr_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(23, 609)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(50, 20)
        Me.TextBox1.TabIndex = 144
        Me.TextBox1.Text = "Vr total:"
        '
        'txt_pend
        '
        Me.txt_pend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_pend.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_pend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pend.Location = New System.Drawing.Point(722, 610)
        Me.txt_pend.Name = "txt_pend"
        Me.txt_pend.Size = New System.Drawing.Size(61, 20)
        Me.txt_pend.TabIndex = 155
        Me.txt_pend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(650, 610)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(73, 20)
        Me.TextBox3.TabIndex = 154
        Me.TextBox3.Text = "Pendiente:"
        '
        'txt_kilos_pend
        '
        Me.txt_kilos_pend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_kilos_pend.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_kilos_pend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kilos_pend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_kilos_pend.Location = New System.Drawing.Point(852, 610)
        Me.txt_kilos_pend.Name = "txt_kilos_pend"
        Me.txt_kilos_pend.Size = New System.Drawing.Size(63, 20)
        Me.txt_kilos_pend.TabIndex = 153
        Me.txt_kilos_pend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(789, 610)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(64, 20)
        Me.TextBox5.TabIndex = 152
        Me.TextBox5.Text = "Kilos_pte:"
        '
        'btn_ped_prob
        '
        Me.btn_ped_prob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_ped_prob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ped_prob.Image = Global.Spic.My.Resources.Resources.buscar7
        Me.btn_ped_prob.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ped_prob.Location = New System.Drawing.Point(862, 41)
        Me.btn_ped_prob.Name = "btn_ped_prob"
        Me.btn_ped_prob.Size = New System.Drawing.Size(52, 23)
        Me.btn_ped_prob.TabIndex = 156
        Me.btn_ped_prob.Text = "Ver"
        Me.btn_ped_prob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ped_prob.UseVisualStyleBackColor = True
        '
        'txt_vrtot_prob
        '
        Me.txt_vrtot_prob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_vrtot_prob.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txt_vrtot_prob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_vrtot_prob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vrtot_prob.Location = New System.Drawing.Point(734, 43)
        Me.txt_vrtot_prob.Name = "txt_vrtot_prob"
        Me.txt_vrtot_prob.Size = New System.Drawing.Size(119, 20)
        Me.txt_vrtot_prob.TabIndex = 158
        Me.txt_vrtot_prob.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(625, 43)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(110, 20)
        Me.TextBox4.TabIndex = 157
        Me.TextBox4.Text = "Pedidos problema:"
        '
        'Frm_info_pendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 643)
        Me.Controls.Add(Me.txt_vrtot_prob)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.btn_ped_prob)
        Me.Controls.Add(Me.txt_pend)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.txt_kilos_pend)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.txt_cant_desp)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.txt_cant_ped)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.txt_vr_unit)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.txt_vr_tot)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.lblNombres)
        Me.Controls.Add(Me.txtNit)
        Me.Controls.Add(Me.lblNit)
        Me.Controls.Add(Me.dtg_pend)
        Me.Name = "Frm_info_pendientes"
        Me.Text = "Pendientes"
        CType(Me.dtg_pend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents lblNombres As System.Windows.Forms.Label
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents lblNit As System.Windows.Forms.Label
    Friend WithEvents dtg_pend As System.Windows.Forms.DataGridView
    Friend WithEvents txt_cant_desp As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents txt_cant_ped As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents txt_vr_unit As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_vr_tot As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_pend As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_kilos_pend As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents btn_ped_prob As System.Windows.Forms.Button
    Friend WithEvents txt_vrtot_prob As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
End Class
