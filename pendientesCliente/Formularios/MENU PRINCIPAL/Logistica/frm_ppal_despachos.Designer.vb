<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ppal_despachos
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslado de Bodega 2-3 (G y T)")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslado de Bodega 2-3 (P)")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion de despachos", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Me.tw_despachos = New System.Windows.Forms.TreeView()
        Me.imgCed = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tw_despachos
        '
        Me.tw_despachos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tw_despachos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tw_despachos.Location = New System.Drawing.Point(13, 44)
        Me.tw_despachos.Name = "tw_despachos"
        TreeNode1.Name = "nod_traslado_2_3"
        TreeNode1.Text = "Traslado de Bodega 2-3 (G y T)"
        TreeNode2.Name = "nod_traslado_2_3_P"
        TreeNode2.Text = "Traslado de Bodega 2-3 (P)"
        TreeNode3.Name = "raiz_gestion_despachos"
        TreeNode3.Text = "Gestion de despachos"
        Me.tw_despachos.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3})
        Me.tw_despachos.Size = New System.Drawing.Size(277, 230)
        Me.tw_despachos.TabIndex = 1100
        '
        'imgCed
        '
        Me.imgCed.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCed.Location = New System.Drawing.Point(257, 3)
        Me.imgCed.Name = "imgCed"
        Me.imgCed.Size = New System.Drawing.Size(27, 26)
        Me.imgCed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCed.TabIndex = 1097
        Me.imgCed.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 1099
        Me.Label5.Text = "Cedula:"
        '
        'txtCedula
        '
        Me.txtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCedula.ForeColor = System.Drawing.Color.Black
        Me.txtCedula.Location = New System.Drawing.Point(81, 3)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(170, 26)
        Me.txtCedula.TabIndex = 1098
        '
        'frm_ppal_despachos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 276)
        Me.Controls.Add(Me.tw_despachos)
        Me.Controls.Add(Me.imgCed)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCedula)
        Me.Name = "frm_ppal_despachos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Traslado para despachos"
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tw_despachos As System.Windows.Forms.TreeView
    Friend WithEvents imgCed As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
End Class
