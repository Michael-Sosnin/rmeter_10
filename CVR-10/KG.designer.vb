<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KG
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl = New System.Windows.Forms.Label
        Me.chk = New System.Windows.Forms.CheckBox
        Me.txt = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl.Location = New System.Drawing.Point(4, 8)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(24, 13)
        Me.lbl.TabIndex = 0
        Me.lbl.Text = "CG"
        '
        'chk
        '
        Me.chk.AutoSize = True
        Me.chk.Location = New System.Drawing.Point(117, 8)
        Me.chk.Name = "chk"
        Me.chk.Size = New System.Drawing.Size(15, 14)
        Me.chk.TabIndex = 1
        Me.chk.UseVisualStyleBackColor = True
        '
        'txt
        '
        Me.txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt.Location = New System.Drawing.Point(49, 3)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(62, 22)
        Me.txt.TabIndex = 2
        Me.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.chk)
        Me.Controls.Add(Me.lbl)
        Me.Name = "CG"
        Me.Size = New System.Drawing.Size(135, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents chk As System.Windows.Forms.CheckBox
    Friend WithEvents txt As System.Windows.Forms.TextBox

End Class
