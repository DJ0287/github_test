Imports Microsoft.VisualBasic.Compatibility
Imports System.Reflection
Imports System.Linq
Imports System.Collections.Generic
Public Class Frm09Prm
    Inherits FrmButton

    Dim PasswdLocked As Boolean = True
    Dim PasswdUnlockTimeLime As DateTime

    Private Sub Frm09_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim twidth As Short
        Dim theight As Short
        Dim scaler As Double = 1 / 12
        Dim i As Short

        ScrHdrLabel.Text = "パラメータ設定画面"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"
        twidth = (C1FlexGrid1.Width)
        C1FlexGrid1.set_RowHeight(0, 300 * scaler) '１行目のセル高さを設定
        C1FlexGrid1.Row = 0 '１行目をアクティブ化
        C1FlexGrid1.Col = 0
        C1FlexGrid1.set_ColWidth(0, twidth * 0.7)
        C1FlexGrid1.Text = "酸素吹き込み量"
        C1FlexGrid1.Col = 1
        C1FlexGrid1.set_ColWidth(1, twidth * 0.3)
        C1FlexGrid1.Text = "効率μ"
        theight = (C1FlexGrid1.Height - C1FlexGrid1.get_RowHeight(0)) / 11
        For i = 1 To 11
            Dim ii = i
            If ii >= 9 Then ii = 9
            C1FlexGrid1.set_RowHeight(i, theight) '１行目のセル高さを設定
            C1FlexGrid1.Row = i
            C1FlexGrid1.Col = 0
            C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            C1FlexGrid1.Text = Format((i - 1) * 0.2, "0.0") & " (Nm3/min)"
            C1FlexGrid1.Col = 1
            C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            C1FlexGrid1.Text = Format(PARAMETER.Search("μ" & i).設定値, "0.00")
            'C1FlexGrid1.Text = Format(PARAMETER.Table.Find("μ" & i).設定値, "0.00")
        Next
        UpdateParam()
        C1FlexGrid1.Row = -1
        PasswdLocked = True
        SetPasswordLock(LB_LOCK, PasswdLocked)
        PasswordLockTimer.Stop()

    End Sub
    Private Sub UpdateParam()
        Dim t = GetType(Frm09Prm)
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
                    MessageBox.Show("パラメータ変数 '" & Mid(tb.Name, 4) & "'がPARASetting.csv内に見つかりません。'")
                End Try

                tb.ReadOnly = True
                tb.BackColor = Color.White
            End If

        Next
        For i = 1 To 11
            Dim ii = i
            If ii >= 9 Then ii = 9
            C1FlexGrid1.Row = i
            C1FlexGrid1.Col = 1
            Try
                C1FlexGrid1.Text = Format(PARAMETER.Search("μ" & i).設定値, "0.00")
            Catch
                MessageBox.Show("パラメータ変数 '" & "μ" & i & "'がPARASetting.csv内に見つかりません。'")
            End Try

        Next

    End Sub
    Private Sub PasswdBtn_Click(sender As Object, e As EventArgs) Handles PasswdBtn.Click
        Dim dres As DialogResult = PopupPasswd.ShowDialog()
        If dres = Windows.Forms.DialogResult.OK Then
            Dim pwenable = PARAMETER.Search("PWEnable").Value
            Dim pwdisable = PARAMETER.Search("PWDisable").Value
            If PasswdLocked = True And PopupPasswd.TB_PASSWORD.Text.Contains(pwenable) Then
                PopupGeneric.Label1.Text = "ロックが解除されました。入力完了後、禁止パスワードを入力してください。"
                PopupGeneric.ShowDialog()
                PasswdLocked = False
                SetPasswordLock(LB_LOCK, PasswdLocked)
                PasswordLockTimer.Interval = 60 * 15 * 1000
                PasswordLockTimer.Start()
            End If
            If PasswdLocked = False And PopupPasswd.TB_PASSWORD.Text.Contains(pwdisable) Then
                PopupGeneric.Label1.Text = "入力がロックされました。再度設定を変更する場合は許可パスワードを入力してください。"
                PopupGeneric.ShowDialog()
                PasswdLocked = True
                SetPasswordLock(LB_LOCK, PasswdLocked)
                PasswordLockTimer.Stop()

            End If
        End If
    End Sub

    Private Sub EditClk(sender As Object, e As EventArgs) Handles TB_COB3.Click, TB_DVAHH.Click, TB_FCSET.Click,
        TB_VAHH.Click, TB_CSI.Click, TB_TC3.Click, TB_CAL_.Click, TB_TC4.Click, TB_CALL.Click, TB_TC2.Click, TB_CAHH.Click,
        TB_TC1_.Click, TB_CAH_.Click, TB_FSUP1.Click, TB_TD4.Click, TB_COB4.Click, TB_C4FL.Click, TB_TC11.Click, TB_TC9.Click,
        TB_C3FL.Click, TB_TD3.Click, TB_TC8.Click, TB_TC7.Click, TB_TC6.Click, TB_TC5.Click, TB_TC12.Click, TB_TC10.Click,
        TB_CAREF.Click, TB_C4OL.Click, TB_C4OH.Click, TB_C4FH.Click, TB_C3OL.Click, TB_C3OH.Click, TB_C3FH.Click, TB_FSUP2.Click, TB_PL.Click
        If PasswdLocked = False Or sender Is TB_COB3 Or sender Is TB_COB4 Or sender Is TB_CAREF Then
            Dim tb As TextBox = sender
            Dim param = PARAMETER.Search(Mid(tb.Name, 4))
            PopupSoft10Key.TB_InputLowLimit.Text = Format(param.下限値, tb.Tag)
            PopupSoft10Key.TB_InputUpperLimit.Text = Format(param.上限値, tb.Tag)
            PopupSoft10Key.TB_Input.Text = tb.Text
            If DialogResult.OK = PopupSoft10Key.ShowDialog() Then
                tb.Text = Format(Double.Parse(PopupSoft10Key.TB_Input.Text), tb.Tag)
                PARAMETER.SetNewValue("PARASetting.csv", param.Name, tb.Text)
                Do While Not PARAMETER.Export(My.Application.Info.DirectoryPath & "\PARASetting.csv")
                    MessageBox.Show("ファイル[PARASetting.csv]は他のアプリケーションで開かれているため開くことができません。他のアプリケーションを閉じてOKを押してください。", "オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Loop
                SetPasswordLock(LB_LOCK, PasswdLocked)
                PasswordLockTimer.Start()

            End If
        End If
    End Sub



    Private Sub C1FlexGrid1_Click(sender As Object, e As EventArgs) Handles C1FlexGrid1.Click
        Dim cell As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic = sender
        If PasswdLocked = False Then
            Dim param = PARAMETER.Search("μ" & cell.Row)
            PopupSoft10Key.TB_InputLowLimit.Text = Format(param.下限値, "0.00")
            PopupSoft10Key.TB_InputUpperLimit.Text = Format(param.上限値, "0.00")
            PopupSoft10Key.TB_Input.Text = cell.Text
            If DialogResult.OK = PopupSoft10Key.ShowDialog() Then
                cell.Text = Format(Double.Parse(PopupSoft10Key.TB_Input.Text), "0.00")
                PARAMETER.SetNewValue("PARASetting.csv", param.Name, cell.Text)
                Do While Not PARAMETER.Export(My.Application.Info.DirectoryPath & "\PARASetting.csv")
                    MessageBox.Show("ファイル[PARASetting.csv]は他のアプリケーションで開かれているため開くことができません。他のアプリケーションを閉じてOKを押してください。", "オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Loop

                SetPasswordLock(LB_LOCK, PasswdLocked)
                PasswordLockTimer.Start()
            End If
        End If
        sender.Row = -1
    End Sub

    'Private Sub ParamChanged(sender As Object, e As EventArgs) Handles TB_VAHH.TextChanged,
    '    TB_TD4.TextChanged, TB_TD3.TextChanged, TB_TC4.TextChanged, TB_TC3.TextChanged,
    '    TB_TC2.TextChanged, TB_TC11.TextChanged, TB_TC9.TextChanged, TB_TC1.TextChanged,
    '    TB_FSUP.TextChanged, TB_FCSET.TextChanged, TB_DVAHH.TextChanged, TB_CSI.TextChanged,
    '    TB_COB4.TextChanged, TB_COB3.TextChanged, TB_CAREF.TextChanged, TB_CALL.TextChanged,
    '    TB_CAHH.TextChanged, TB_CAL.TextChanged, TB_CAH.TextChanged, TB_C4FL.TextChanged,
    '    TB_C3FL.TextChanged, TB_TC8.TextChanged, TB_TC7.TextChanged, TB_TC6.TextChanged,
    '    TB_TC5.TextChanged, TB_TC12.TextChanged, TB_TC10.TextChanged, TB_C4OL.TextChanged,
    '    TB_C4OH.TextChanged, TB_C4FH.TextChanged, TB_C3OL.TextChanged, TB_C3OH.TextChanged,
    '    TB_C3FH.TextChanged
    '    If PasswdLocked = False Then
    '        Dim tb As TextBox = sender
    '        Dim param = PARAMETER.Find(Mid(tb.Name, 4))
    '        PARAMETER.SetNewValue("datalimit1.csv", param.Name, tb.Text)
    '        SetPasswordLock(LB_LOCK, PasswdLocked)
    '        PasswordLockTimer.Start()
    '    End If
    '    'Try
    '    '    PARAMETER.VaHH = Single.Parse(TB_VAHH.Text)
    '    '    PARAMETER.Td4 = Single.Parse(TB_TD4.Text)
    '    '    PARAMETER.Td3 = Single.Parse(TB_TD3.Text)
    '    '    PARAMETER.Tc4 = Single.Parse(TB_TC4.Text)
    '    '    PARAMETER.Tc3 = Single.Parse(TB_TC3.Text)
    '    '    PARAMETER.Tc2 = Single.Parse(TB_TC2.Text)
    '    '    PARAMETER.Tc14 = Single.Parse(TB_TC11.Text)
    '    '    PARAMETER.Tc13 = Single.Parse(TB_TC9.Text)
    '    '    PARAMETER.Tc1 = Single.Parse(TB_TC1.Text)
    '    '    PARAMETER.Fsup = Single.Parse(TB_FSUP.Text)
    '    '    PARAMETER.Fcset = Single.Parse(TB_FCSET.Text)
    '    '    PARAMETER.dVaHH = Single.Parse(TB_DVAHH.Text)
    '    '    PARAMETER.Csi = Single.Parse(TB_CSI.Text)
    '    '    PARAMETER.Cob4 = Single.Parse(TB_COB4.Text)
    '    '    PARAMETER.Cob3 = Single.Parse(TB_COB3.Text)
    '    '    PARAMETER.Caref = Single.Parse(TB_CAREF.Text)
    '    '    PARAMETER.CAL = Single.Parse(TB_CAL.Text)
    '    '    PARAMETER.CAH = Single.Parse(TB_CAH.Text)
    '    '    PARAMETER.CAdL = Single.Parse(TB_CADL.Text)
    '    '    PARAMETER.CAdH = Single.Parse(TB_CADH.Text)
    '    '    PARAMETER.C4d = Single.Parse(TB_C4D.Text)
    '    '    PARAMETER.C3d = Single.Parse(TB_C3D.Text)

    '    'Catch ex As Exception

    '    'End Try

    '    Run()
    'End Sub
    'Private Sub C1FlexGrid1_CellChanged(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGrid1.CellChanged
    '    If PasswdLocked = False Then
    '        Dim cell As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic = sender
    '        Dim param = PARAMETER.Find("μ" & cell.Row)
    '        PARAMETER.SetNewValue("datalimit1.csv", param.Name, cell.Text)
    '        SetPasswordLock(LB_LOCK, PasswdLocked)
    '        PasswordLockTimer.Start()
    '    End If
    'End Sub

    Protected Overrides Sub OnUpdate()
        BTN_PARA_RELOAD.Enabled = Not PasswdLocked
        MyBase.OnUpdate()

    End Sub

    Private Sub PasswordLockTimer_Tick(sender As Object, e As EventArgs) Handles PasswordLockTimer.Tick
        PasswdLocked = True
        SetPasswordLock(LB_LOCK, PasswdLocked)
        PasswordLockTimer.Stop()
    End Sub

    Private Sub BTN_PARA_RELOAD_Click(sender As Object, e As EventArgs) Handles BTN_PARA_RELOAD.Click
        PARAMETER.Clear()
        If Not My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\PARASetting.csv") Then
            My.Computer.FileSystem.CopyFile(My.Application.Info.DirectoryPath & "\PARASettingDef.csv", My.Application.Info.DirectoryPath & "\PARASetting.csv", True)
        End If
        Do While Not PARAMETER.Import(My.Application.Info.DirectoryPath & "\PARASetting.csv")
            PARAMETER.Restore()
            MessageBox.Show("ファイル[PARASetting.csv]は他のアプリケーションで開かれているため開くことができません。他のアプリケーションを閉じてOKを押してください。", "オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Loop
        PARAMETER.Import(My.Application.Info.DirectoryPath & "\pwsetting.csv")
        UpdateParam()

    End Sub

End Class
