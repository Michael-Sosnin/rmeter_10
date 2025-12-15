Public Class frmPreview
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Icon = My.Resources.Radiation 'Изменяем иконку

        ' Add any initialization after the InitializeComponent() call.
        Me.Opacity = 100
        Me.TransparencyKey = System.Drawing.Color.White
    End Sub
End Class