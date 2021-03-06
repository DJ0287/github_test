﻿Public Class PopupPasswd_BAO
    Inherits ETL_SRS_BAO.PopupGeneric_BAO

    Private Sub PopupPasswd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Text = "パスワードの確認"
        'Label1.Text = "許可/禁止パスワードを入力してください。"
        Me.Text = "Confirm password"
        Label1.Text = "Please enter unlock / lock password."
    End Sub



    Private Sub PopupPasswd_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Dim form As PopupPasswd_BAO = sender
        If form.Visible Then
            form.TB_PASSWORD.Text = ""
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TB_PASSWORD.Click
        Dim editctl As TextBox = sender
        PopupSoft10Key_BAO.PasswdMode()
        PopupSoft10Key_BAO.TB_Input.Text = ""
        If DialogResult.OK = PopupSoft10Key_BAO.ShowDialog() Then
            editctl.Text = PopupSoft10Key_BAO.TB_Input.Text
        End If
    End Sub

    Private Sub BTN_PWCNG_Click(sender As Object, e As EventArgs) Handles BTN_PWCNG.Click
        'Dim editctl As TextBox = sender
        'PopupSoft10Key.PasswdMode()
        'PopupSoft10Key.TB_Input.Text = ""
        'If DialogResult.OK = PopupSoft10Key.ShowDialog() Then
        '    editctl.Text = PopupSoft10Key.TB_Input.Text
        'End If
        Dim pwenable = PARAMETER.Search("PWEnable").Value
        Dim pwdisable = PARAMETER.Search("PWDisable").Value
        If TB_PASSWORD.Text.Contains(pwenable) Then
            'PopupChangePasswd_BAO.Label1.Text = "新しい許可パスワードを入力してください"
            PopupChangePasswd_BAO.Label1.Text = "Please enter a new unlock password"
            If DialogResult.OK = PopupChangePasswd_BAO.ShowDialog() Then
                If PopupChangePasswd_BAO.TB_PASSWORD_NEW.Text.Contains(PopupChangePasswd_BAO.TB_PASSWORD_NEW_RE.Text) Then
                    'PopupGeneric.Label1.Text = "許可パスワードが変更されました"
                    PopupGeneric_BAO.Label1.Text = "Unlock password changed"
                    PopupGeneric_BAO.ShowDialog()
                    PARAMETER.SetNewValue("pwsetting.csv", "PWEnable", PopupChangePasswd_BAO.TB_PASSWORD_NEW.Text)
                    SetAttr(My.Application.Info.DirectoryPath & "\pwsetting.csv", FileAttribute.Normal)
                    PARAMETER.Export(My.Application.Info.DirectoryPath & "\pwsetting.csv")
                    SetAttr(My.Application.Info.DirectoryPath & "\pwsetting.csv", FileAttribute.Hidden)
                End If
            End If
        End If
        If TB_PASSWORD.Text.Contains(pwdisable) Then
            'PopupChangePasswd_BAO.Label1.Text = "新しい禁止パスワードを入力してください"
            PopupChangePasswd_BAO.Label1.Text = "Please enter a new lock password"
            If DialogResult.OK = PopupChangePasswd_BAO.ShowDialog() Then
                If PopupChangePasswd_BAO.TB_PASSWORD_NEW.Text.Contains(PopupChangePasswd_BAO.TB_PASSWORD_NEW_RE.Text) Then
                    'PopupGeneric.Label1.Text = "禁止パスワードが変更されました"
                    PopupGeneric_BAO.Label1.Text = "Lock password changed"
                    PopupGeneric_BAO.ShowDialog()
                    PARAMETER.SetNewValue("pwsetting.csv", "PWDisable", PopupChangePasswd_BAO.TB_PASSWORD_NEW.Text)
                    SetAttr(My.Application.Info.DirectoryPath & "\pwsetting.csv", FileAttribute.Normal)
                    PARAMETER.Export(My.Application.Info.DirectoryPath & "\pwsetting.csv")
                    SetAttr(My.Application.Info.DirectoryPath & "\pwsetting.csv", FileAttribute.Hidden)
                End If
            End If
        End If
        Me.TB_PASSWORD.Text = ""
    End Sub
End Class