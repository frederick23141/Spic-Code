﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ejecutar_sugerencia
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_area = New System.Windows.Forms.ComboBox()
        Me.btn_ejec = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(40, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(392, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione el area que ejecutara la Sugerencia."
        '
        'cbo_area
        '
        Me.cbo_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_area.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbo_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_area.FormattingEnabled = True
        Me.cbo_area.Location = New System.Drawing.Point(12, 32)
        Me.cbo_area.Name = "cbo_area"
        Me.cbo_area.Size = New System.Drawing.Size(454, 24)
        Me.cbo_area.TabIndex = 1
        '
        'btn_ejec
        '
        Me.btn_ejec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ejec.Image = Global.Spic.My.Resources.Resources.enlaces_de_ejecutivo
        Me.btn_ejec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ejec.Location = New System.Drawing.Point(138, 73)
        Me.btn_ejec.Name = "btn_ejec"
        Me.btn_ejec.Size = New System.Drawing.Size(201, 47)
        Me.btn_ejec.TabIndex = 2
        Me.btn_ejec.Text = "Poner en Ejecucion"
        Me.btn_ejec.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_ejec.UseVisualStyleBackColor = True
        '
        'frm_ejecutar_sugerencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(478, 132)
        Me.Controls.Add(Me.btn_ejec)
        Me.Controls.Add(Me.cbo_area)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ejecutar_sugerencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_ejecutar_sugerencia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_area As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ejec As System.Windows.Forms.Button
End Class
