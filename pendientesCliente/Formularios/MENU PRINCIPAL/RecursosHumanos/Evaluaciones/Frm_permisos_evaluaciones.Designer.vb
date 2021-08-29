<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_permisos_evaluaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_permisos_evaluaciones))
        Me.listaUsuarios = New System.Windows.Forms.ListBox()
        Me.listPermisosUsuario = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddmodulo = New System.Windows.Forms.Button()
        Me.btnQuitarMod = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lista_evaluaciones = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'listaUsuarios
        '
        Me.listaUsuarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listaUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listaUsuarios.FormattingEnabled = True
        Me.listaUsuarios.ItemHeight = 12
        Me.listaUsuarios.Location = New System.Drawing.Point(5, 28)
        Me.listaUsuarios.Name = "listaUsuarios"
        Me.listaUsuarios.Size = New System.Drawing.Size(177, 436)
        Me.listaUsuarios.TabIndex = 1
        '
        'listPermisosUsuario
        '
        Me.listPermisosUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listPermisosUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listPermisosUsuario.FormattingEnabled = True
        Me.listPermisosUsuario.ItemHeight = 12
        Me.listPermisosUsuario.Items.AddRange(New Object() {""})
        Me.listPermisosUsuario.Location = New System.Drawing.Point(188, 31)
        Me.listPermisosUsuario.Name = "listPermisosUsuario"
        Me.listPermisosUsuario.Size = New System.Drawing.Size(264, 424)
        Me.listPermisosUsuario.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usuarios"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(185, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Permisos del usuario"
        '
        'btnAddmodulo
        '
        Me.btnAddmodulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddmodulo.Location = New System.Drawing.Point(457, 167)
        Me.btnAddmodulo.Name = "btnAddmodulo"
        Me.btnAddmodulo.Size = New System.Drawing.Size(37, 26)
        Me.btnAddmodulo.TabIndex = 39
        Me.btnAddmodulo.Text = "<<"
        Me.btnAddmodulo.UseVisualStyleBackColor = True
        '
        'btnQuitarMod
        '
        Me.btnQuitarMod.Image = Global.Spic.My.Resources.Resources._1371750041_14125
        Me.btnQuitarMod.Location = New System.Drawing.Point(456, 199)
        Me.btnQuitarMod.Name = "btnQuitarMod"
        Me.btnQuitarMod.Size = New System.Drawing.Size(37, 26)
        Me.btnQuitarMod.TabIndex = 40
        Me.btnQuitarMod.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icoProg.png")
        Me.ImageList1.Images.SetKeyName(1, "1349366316_users.ico")
        Me.ImageList1.Images.SetKeyName(2, "dinero.jpg")
        Me.ImageList1.Images.SetKeyName(3, "est.jpg")
        Me.ImageList1.Images.SetKeyName(4, "usuario1.gif")
        Me.ImageList1.Images.SetKeyName(5, "buscar7.gif")
        Me.ImageList1.Images.SetKeyName(6, "mas1.png")
        Me.ImageList1.Images.SetKeyName(7, "casco.jpg")
        Me.ImageList1.Images.SetKeyName(8, "casco1.jpg")
        Me.ImageList1.Images.SetKeyName(9, "despacho.png")
        Me.ImageList1.Images.SetKeyName(10, "planilla.gif")
        Me.ImageList1.Images.SetKeyName(11, "informe.png")
        Me.ImageList1.Images.SetKeyName(12, "actualizar.png")
        Me.ImageList1.Images.SetKeyName(13, "tool.png")
        Me.ImageList1.Images.SetKeyName(14, "Black_Tools.png")
        Me.ImageList1.Images.SetKeyName(15, "tool2.png")
        Me.ImageList1.Images.SetKeyName(16, "ficha.png")
        Me.ImageList1.Images.SetKeyName(17, "mobil.ico")
        Me.ImageList1.Images.SetKeyName(18, "ok.png")
        Me.ImageList1.Images.SetKeyName(19, "compras.png")
        Me.ImageList1.Images.SetKeyName(20, "compras1.png")
        Me.ImageList1.Images.SetKeyName(21, "compras2.png")
        Me.ImageList1.Images.SetKeyName(22, "compras4.png")
        Me.ImageList1.Images.SetKeyName(23, "compras5.png")
        Me.ImageList1.Images.SetKeyName(24, "Time_management.png")
        Me.ImageList1.Images.SetKeyName(25, "grafico10.png")
        Me.ImageList1.Images.SetKeyName(26, "ok3.gif")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(494, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Evaluaciones"
        '
        'lista_evaluaciones
        '
        Me.lista_evaluaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lista_evaluaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lista_evaluaciones.FormattingEnabled = True
        Me.lista_evaluaciones.ItemHeight = 12
        Me.lista_evaluaciones.Items.AddRange(New Object() {""})
        Me.lista_evaluaciones.Location = New System.Drawing.Point(497, 31)
        Me.lista_evaluaciones.Name = "lista_evaluaciones"
        Me.lista_evaluaciones.Size = New System.Drawing.Size(326, 424)
        Me.lista_evaluaciones.TabIndex = 43
        '
        'Frm_permisos_evaluaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 467)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lista_evaluaciones)
        Me.Controls.Add(Me.btnQuitarMod)
        Me.Controls.Add(Me.btnAddmodulo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listPermisosUsuario)
        Me.Controls.Add(Me.listaUsuarios)
        Me.Name = "Frm_permisos_evaluaciones"
        Me.Text = "Gestionar permisos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listaUsuarios As System.Windows.Forms.ListBox
    Friend WithEvents listPermisosUsuario As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddmodulo As System.Windows.Forms.Button
    Friend WithEvents btnQuitarMod As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lista_evaluaciones As System.Windows.Forms.ListBox
End Class
