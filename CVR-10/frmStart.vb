Public Class frmStart

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Icon = My.Resources.Radiation
    End Sub

    ''' <summary>
    ''' Открывает форму проведения измерений
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdMeasurement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMeasurement.Click
        Try
            frmMeasurement.Show()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Открывает форму обработки результатов эксперимента
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculation.Click
        Try
            frmCalculation.Show()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
