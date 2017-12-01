Public Class PopupSoft10Key
    Public Enum SOFT10KEYMODE
        Normal = 1
        PassWord = 2

    End Enum
    Dim mode As SOFT10KEYMODE = SOFT10KEYMODE.Normal

    Public Sub NormalMode()
        Button11.Enabled = True
        Button12.Enabled = True

        LB_LowLimit.Enabled = True
        TB_InputLowLimit.Enabled = True
        LB_TO.Enabled = True
        TB_InputUpperLimit.Enabled = True
        LB_UpperLimit.Enabled = True
        TB_Input.PasswordChar = ""
        mode = SOFT10KEYMODE.Normal
    End Sub
    Public Sub PasswdMode()
        Button11.Enabled = False
        Button12.Enabled = False

        LB_LowLimit.Enabled = False
        TB_InputLowLimit.Enabled = False
        LB_TO.Enabled = False
        TB_InputUpperLimit.Enabled = False
        LB_UpperLimit.Enabled = False

        TB_Input.PasswordChar = "*"
        mode = SOFT10KEYMODE.PassWord
    End Sub

    Private Sub Num_Click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button10.Click, Button1.Click
        Dim numbtn As Button = sender
        If TB_Input.Text.Length = 1 Then
            If TB_Input.Text(0) = "0" Then
                TB_Input.Text = ""
            End If
        End If
        If TB_Input.Text.Length < TB_Input.MaxLength Then
            TB_Input.Text = TB_Input.Text & numbtn.Text
        End If
        If TB_Input.Text.Length > 1 And TB_Input.Text(0) = "0" And TB_Input.Text.IndexOf(".") < 0 Then
            TB_Input.Text = TB_Input.Text.Substring(1)
        End If
    End Sub

    Private Sub PlusMinus_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim plusminusbtn As Button = sender
        If TB_Input.Text.Length > 0 Then
            If TB_Input.Text(0) = "-" Then
                TB_Input.Text = TB_Input.Text.Substring(1)
            ElseIf TB_Input.Text(0) <> "0" Or (TB_Input.Text(0) = "0" And TB_Input.Text.Length > 1) Then

                TB_Input.Text = "-" & TB_Input.Text
            End If
        End If
    End Sub

    Private Sub Enter_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If TB_Input.Text.Length > 0 Then
            If TB_Input.Text(TB_Input.Text.Length - 1) = "." Then
                TB_Input.Text = TB_Input.Text.Substring(0, TB_Input.Text.Length - 1)
            End If
            If mode = SOFT10KEYMODE.Normal Then
                Dim ll = Single.Parse(TB_InputLowLimit.Text)
                Dim ul = Single.Parse(TB_InputUpperLimit.Text)
                Dim value = Single.Parse(TB_Input.Text)
                If value < ll Then
                    TB_Input.Text = TB_InputLowLimit.Text
                End If
                If value > ul Then
                    TB_Input.Text = TB_InputUpperLimit.Text
                End If
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            NormalMode()
            Me.Close()

        End If
    End Sub

    Private Sub BS_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If TB_Input.Text.Length > 1 Then
            TB_Input.Text = TB_Input.Text.Substring(0, TB_Input.Text.Length - 1)
            If TB_Input.Text.Length = 1 And TB_Input.Text(0) = "-" Then
                TB_Input.Text = "0"
            End If
        Else
            TB_Input.Text = "0"
        End If
    End Sub

    Private Sub CLR_Click(sender As Object, e As EventArgs) Handles Button15.Click
        TB_Input.Text = "0"
    End Sub

    Private Sub Comma_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If TB_Input.Text.Length > 0 And TB_Input.Text.IndexOf(".") < 0 Then
            TB_Input.Text = TB_Input.Text & "."
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        NormalMode()
        Me.Close()
    End Sub

    Private Sub Soft10Key_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        NormalMode()
    End Sub

    Private Sub PopupSoft10Key_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

End Class