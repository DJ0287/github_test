Public Class PopupProgressBar
    Delegate Function Progress() As Boolean
    Dim CallCount As Integer = 0
    Public ProgressDlg As Progress
    Public DisplayText As String
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressDlg() Then
            Me.Hide()
        End If
        CallCount = CallCount + 1
        If CallCount > 10 Then
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Label.Text = DisplayText & vbCrLf & "Please check connection."
        Else
            ProgressBar1.Value = CallCount
        End If
    End Sub

    Private Sub PopupProgressBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label.Text = DisplayText
        CallCount = 0
        Timer1.Start()
    End Sub
End Class