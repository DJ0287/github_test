Public Class PopupChangePasswd
    Inherits PopupGeneric

    Private Sub TB_PASSWORD_Click(sender As Object, e As EventArgs) Handles TB_PASSWORD_NEW.Click, TB_PASSWORD_NEW_RE.Click
        Dim editctl As TextBox = sender
        PopupSoft10Key.PasswdMode()
        PopupSoft10Key.TB_Input.Text = ""
        If DialogResult.OK = PopupSoft10Key.ShowDialog() Then
            editctl.Text = PopupSoft10Key.TB_Input.Text
        End If
    End Sub

    Private Sub TB_PASSWORD_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Dim tform As PopupChangePasswd = sender
        If tform.Visible Then
            tform.TB_PASSWORD_NEW_RE.Text = ""
            tform.TB_PASSWORD_NEW.Text = ""

        End If
    End Sub
End Class