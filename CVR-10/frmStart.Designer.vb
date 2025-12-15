<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.cmdSettings = New System.Windows.Forms.Button()
        Me.cmdMeasurement = New System.Windows.Forms.Button()
        Me.cmdCalculation = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdSettings
        '
        Me.cmdSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdSettings.Location = New System.Drawing.Point(238, 105)
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(197, 29)
        Me.cmdSettings.TabIndex = 0
        Me.cmdSettings.Text = "Настройки (Settings)"
        Me.cmdSettings.UseVisualStyleBackColor = True
        '
        'cmdMeasurement
        '
        Me.cmdMeasurement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdMeasurement.Location = New System.Drawing.Point(238, 140)
        Me.cmdMeasurement.Name = "cmdMeasurement"
        Me.cmdMeasurement.Size = New System.Drawing.Size(197, 29)
        Me.cmdMeasurement.TabIndex = 1
        Me.cmdMeasurement.Text = "Измерения (Meas.)"
        Me.cmdMeasurement.UseVisualStyleBackColor = True
        '
        'cmdCalculation
        '
        Me.cmdCalculation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cmdCalculation.Location = New System.Drawing.Point(238, 175)
        Me.cmdCalculation.Name = "cmdCalculation"
        Me.cmdCalculation.Size = New System.Drawing.Size(197, 29)
        Me.cmdCalculation.TabIndex = 2
        Me.cmdCalculation.Text = "Обработка (Calc.)"
        Me.cmdCalculation.UseVisualStyleBackColor = True
        '
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CVR_10.My.Resources.Resources.CVR10_StartForm
        Me.ClientSize = New System.Drawing.Size(465, 239)
        Me.Controls.Add(Me.cmdCalculation)
        Me.Controls.Add(Me.cmdMeasurement)
        Me.Controls.Add(Me.cmdSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Цифровой измеритель реактивности ЦВР-10 (CVR-10)"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSettings As System.Windows.Forms.Button
    Friend WithEvents cmdMeasurement As System.Windows.Forms.Button
    Friend WithEvents cmdCalculation As System.Windows.Forms.Button

End Class
