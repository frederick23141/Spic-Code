<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ppal_alambron
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Descargue de Alambron")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslado de Bodega (1 -2)")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslado de Bodega (2 - 1)")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion de Alambron", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslado de Bodega (2-11)")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Traslados de Bodega (11-2)")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion Galvanizado", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Entrega de Materia Prima Puas")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Devolver materia prima")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion Puas", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Entrega Materia Prima")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Devoluciones Puntilleria")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion Puntilleria", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Registro de Produccion")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Planilla de Separe M/CIA")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion No Conforme")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventarios")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventario por Bodegas")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consumo scal")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consumo scae")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consumo sar")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consumo sav")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Otros", New System.Windows.Forms.TreeNode() {TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ppal_alambron))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.imgCed = New System.Windows.Forms.PictureBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 1069
        Me.Label5.Text = "Cedula:"
        '
        'txtCedula
        '
        Me.txtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCedula.ForeColor = System.Drawing.Color.Black
        Me.txtCedula.Location = New System.Drawing.Point(80, 2)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(170, 26)
        Me.txtCedula.TabIndex = 1068
        '
        'imgCed
        '
        Me.imgCed.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.imgCed.Location = New System.Drawing.Point(256, 2)
        Me.imgCed.Name = "imgCed"
        Me.imgCed.Size = New System.Drawing.Size(27, 26)
        Me.imgCed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgCed.TabIndex = 1068
        Me.imgCed.TabStop = False
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(12, 43)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "nod_descarga_alambron"
        TreeNode1.Text = "Descargue de Alambron"
        TreeNode2.Name = "nod_traslado_1_2"
        TreeNode2.Text = "Traslado de Bodega (1 -2)"
        TreeNode3.Name = "nod_trasalado_2_1"
        TreeNode3.Text = "Traslado de Bodega (2 - 1)"
        TreeNode4.Name = "raiz_gestion_alambron"
        TreeNode4.Text = "Gestion de Alambron"
        TreeNode5.Name = "nod_traslado_2_11"
        TreeNode5.Text = "Traslado de Bodega (2-11)"
        TreeNode6.Name = "nod_traslado_11_2"
        TreeNode6.Text = "Traslados de Bodega (11-2)"
        TreeNode7.Name = "raiz_gestion_galvanizado"
        TreeNode7.Text = "Gestion Galvanizado"
        TreeNode8.Name = "nod_mat_prima_puas"
        TreeNode8.Text = "Entrega de Materia Prima Puas"
        TreeNode9.Name = "nodo_devolver_p"
        TreeNode9.Text = "Devolver materia prima"
        TreeNode10.Name = "Raiz_gestion_puas"
        TreeNode10.Text = "Gestion Puas"
        TreeNode11.Name = "nod_mat_prima_punt"
        TreeNode11.Text = "Entrega Materia Prima"
        TreeNode12.Name = "nod_dev_punti"
        TreeNode12.Text = "Devoluciones Puntilleria"
        TreeNode13.Name = "Raiz_gestion_puntilleria"
        TreeNode13.Text = "Gestion Puntilleria"
        TreeNode14.Name = "nod_registro_prod"
        TreeNode14.Text = "Registro de Produccion"
        TreeNode15.Name = "nod_planilla"
        TreeNode15.Text = "Planilla de Separe M/CIA"
        TreeNode16.Name = "nod_noconforme"
        TreeNode16.Text = "Gestion No Conforme"
        TreeNode17.Name = "nod_inventarios"
        TreeNode17.Text = "Inventarios"
        TreeNode18.Name = "nod_inv_bod"
        TreeNode18.Text = "Inventario por Bodegas"
        TreeNode19.Name = "nod_scal_tref"
        TreeNode19.Text = "Consumo scal"
        TreeNode20.Name = "nod_scae_tref"
        TreeNode20.Text = "Consumo scae"
        TreeNode21.Name = "nod_sar_tref"
        TreeNode21.Text = "Consumo sar"
        TreeNode22.Name = "nod_savr_tref"
        TreeNode22.Text = "Consumo sav"
        TreeNode23.Name = "raiz_otros"
        TreeNode23.Text = "Otros"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode7, TreeNode10, TreeNode13, TreeNode23})
        Me.TreeView1.Size = New System.Drawing.Size(277, 230)
        Me.TreeView1.TabIndex = 1096
        '
        'Frm_ppal_alambron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 276)
        Me.ControlBox = False
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.imgCed)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCedula)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ppal_alambron"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Traslados de bodega"
        CType(Me.imgCed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents imgCed As System.Windows.Forms.PictureBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
End Class
