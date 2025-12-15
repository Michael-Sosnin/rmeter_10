Public Class KG
    Public Event CheckedChanged(ByVal sender As System.Object)

    Public Property Caption() As String
        Get
            Return lbl.Text
        End Get
        Set(ByVal value As String)
            lbl.Text = value
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return txt.Text
        End Get
        Set(ByVal value As String)
            txt.Text = value
        End Set
    End Property
    Public Property Checked() As Boolean
        Get
            Return chk.Checked
        End Get
        Set(ByVal value As Boolean)
            chk.Checked = value
        End Set
    End Property

    Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk.CheckedChanged
        RaiseEvent CheckedChanged(Me)
    End Sub
End Class
