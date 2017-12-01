Imports Microsoft.VisualBasic.Compatibility
Imports System.Reflection
Imports System.Linq
Imports System.Collections.Generic
Public Class PopupParamerter_BAO

    Dim PasswdLocked As Boolean = True

    Private Sub PopupParamerter_BAO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateParam()

    End Sub

    Private Sub UpdateParam()
        Dim t = GetType(PopupParamerter_BAO)
        Dim fs = t.GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField)
        Dim ls = From l In fs
                 Where (l.FieldType().Name.IndexOf("TextBox") >= 0 And l.Name.IndexOf("TB_") >= 0)
                 Select l

        For Each fld In ls
            'PipeColorList.Add(t.InvokeMember(fld.Name, BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, Me, Nothing))
            Dim tb As TextBox = t.InvokeMember(fld.Name, BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, Me, Nothing)
            If (tb.Visible) Then

                Try
                    tb.Text = Format(PARAMETER.Search(Mid(tb.Name, 4)).設定値, tb.Tag)
                Catch
                    MessageBox.Show("Parameter '" & Mid(tb.Name, 4) & "' can not be found in [PARASetting.csv]")
                End Try

                tb.ReadOnly = True
                tb.BackColor = Color.White
            End If

        Next

    End Sub

    Private Sub EditClk(sender As Object, e As EventArgs) Handles TB_SLS_alpha.Click, TB_SLS_So.Click
        'If PasswdLocked = False Or sender Is TB_COB3 Or sender Is TB_COB4 Or sender Is TB_CAREF Then
        Dim tb As TextBox = sender
        Dim param = PARAMETER.Search(Mid(tb.Name, 4))
        PopupSoft10Key_BAO.TB_InputLowLimit.Text = Format(param.下限値, tb.Tag)
        PopupSoft10Key_BAO.TB_InputUpperLimit.Text = Format(param.上限値, tb.Tag)
        PopupSoft10Key_BAO.TB_Input.Text = tb.Text
        If DialogResult.OK = PopupSoft10Key_BAO.ShowDialog() Then
            tb.Text = Format(Double.Parse(PopupSoft10Key_BAO.TB_Input.Text), tb.Tag)
            PARAMETER.SetNewValue("PARASetting.csv", param.Name, tb.Text)
            Do While Not PARAMETER.Export(My.Application.Info.DirectoryPath & "\PARASetting.csv")
                'MessageBox.Show("ファイル[PARASetting.csv]は他のアプリケーションで開かれているため開くことができません。他のアプリケーションを閉じてOKを押してください。", "オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                MessageBox.Show("The file [PARASetting.csv] can not be opened because it is open in another application. Please close other application and press OK.", "Open error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Loop

        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSS_Click(sender As Object, e As EventArgs) Handles BtnSS.Click
        Dim dres As DialogResult = PopupPasswd_BAO.ShowDialog()
        If dres = Windows.Forms.DialogResult.OK Then
            Dim pwenable = PARAMETER.Search("PWEnable").Value
            Dim pwdisable = PARAMETER.Search("PWDisable").Value
            Dim pwspecial = PARAMETER.Search("PWSpecial").Value
            If PopupPasswd_BAO.TB_PASSWORD.Text.Contains(pwspecial) Then
                'PopupGeneric.Label1.Text = "ロックが解除されました。入力完了後、禁止パスワードを入力してください。"
                PopupGeneric_BAO.Label1.Text = "Special Password OK."
                PopupGeneric_BAO.ShowDialog()
                PasswdLocked = False

                PopupSpecialSet_BAO.ShowDialog()
                'SetPasswordLock(LB_LOCK, PasswdLocked)
                'PasswordLockTimer.Interval = 60 * 15 * 1000
                'PasswordLockTimer.Start()
            End If
        End If

    End Sub
End Class