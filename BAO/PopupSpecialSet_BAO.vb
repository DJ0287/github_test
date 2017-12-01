Imports Microsoft.VisualBasic.Compatibility
Imports System.Reflection
Imports System.Linq
Imports System.Collections.Generic
Public Class PopupSpecialSet_BAO

    Private Sub PopupParamerter_BAO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Actual data欄にデータをセット
        LB_Sp.Text = Format(DISCOMBSCH.S1s, LB_Sp.Tag)
        LB_SpD.Text = Format(DISCOMBSCH.dS1a, LB_SpD.Tag)
        LB_Sc.Text = Format(DISCOMBSCH.dS1b, LB_Sc.Tag)
        LB_ScD.Text = Format(DISCOMBSCH.dS1c, LB_ScD.Tag)
        LB_SpD_r.Text = Format(DISCOMBSCH.dS1d, LB_SpD_r.Tag)
        LB_ScD_r.Text = Format(DISCOMBSCH.dS1e, LB_ScD_r.Tag)
        LB_SnD_r.Text = Format(DISCOMBSCH.dS1f, LB_SnD_r.Tag)
        LB_SpT.Text = Format(DISCOMBSCH.dS1g, LB_SpT.Tag)
        LB_ScT.Text = Format(DISCOMBSCH.dS1h, LB_ScT.Tag)
        LB_SnT.Text = Format(DISCOMBSCH.dS1x, LB_SnT.Tag)

        'パラメータ欄更新
        UpdateParam()

    End Sub

    Private Sub UpdateParam()
        Dim t = GetType(PopupSpecialSet_BAO)
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

    Private Sub EditClk(sender As Object, e As EventArgs) Handles TB_SLS_V.Click, TB_SLS_taue.Click, TB_SLS_Tp.Click, TB_SLS_Tc.Click
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

End Class