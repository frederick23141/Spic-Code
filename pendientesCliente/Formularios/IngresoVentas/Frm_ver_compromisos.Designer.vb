<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ver_compromisos
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
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.lblNit = New System.Windows.Forms.Label()
        Me.dtg_compromisos = New System.Windows.Forms.DataGridView()
        CType(Me.dtg_compromisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNit
        '
        Me.txtNit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNit.Location = New System.Drawing.Point(21, 38)
        Me.txtNit.MaxLength = 13
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(135, 20)
        Me.txtNit.TabIndex = 14
        '
        'lblNit
        '
        Me.lblNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNit.Location = New System.Drawing.Point(18, 18)
        Me.lblNit.Name = "lblNit"
        Me.lblNit.Size = New System.Drawing.Size(27, 20)
        Me.lblNit.TabIndex = 13
        Me.lblNit.Text = "Nit:"
        '
        'dtg_compromisos
        '
        Me.dtg_compromisos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dtg_compromisos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_compromisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_compromisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtg_compromisos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtg_compromisos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_compromisos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_compromisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_compromisos.Location = New System.Drawing.Point(23, 66)
        Me.dtg_compromisos.Name = "dtg_compromisos"
        Me.dtg_compromisos.RowHeadersVisible = False
        Me.dtg_compromisos.Size = New System.Drawing.Size(561, 318)
        Me.dtg_compromisos.TabIndex = 12
        '
        'Frm_ver_compromisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(606, 406)
        Me.Controls.Add(Me.txtNit)
        Me.Controls.Add(Me.lblNit)
        Me.Controls.Add(Me.dtg_compromisos)
        Me.Name = "Frm_ver_compromisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ver compromisos"
        CType(Me.dtg_compromisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents lblNit As System.Windows.Forms.Label
    Friend WithEvents dtg_compromisos As System.Windows.Forms.DataGridView
End Class
