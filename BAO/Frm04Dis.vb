Imports Microsoft.VisualBasic.Compatibility

Public Class Frm04Dis
    Inherits FrmButton


    Private Sub Frm04_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "合算溶解スケジュール画面"
        Label22.Text = "ΣΔS1上限設定" & vbCrLf & "(kg/h)"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"

        Dim i As Short
        Dim j As Short
        Dim twidth As Short
        '        Dim scaler As Double = 1.25
        Dim scaler As Double = 1 / 10.0

        'メインセル(MSFlexGrid1)の設定
        For j = 0 To 21 '行数=22　Row：行
            C1FlexGrid1.Row = j
            For i = 0 To 5 '列数=6　Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter 'セル内のデータは中央の中央配置とする
                'If i = 0 Then
                '    C1FlexGrid1.Text = "9999.9"
                'Else
                '    C1FlexGrid1.Text = "999.99"
                'End If

            Next i
        Next j

        '        twidth = VB6.PixelsToTwipsX(MSFlexGrid1.Width) / 6.0
        twidth = C1FlexGrid1.Width / 6.0
        'MSFlexGrid1.MergeCells = 0      'セルのグループ化不可能に設定

        'メインセル(MSFlexGrid1)１行目の処理
        C1FlexGrid1.set_RowHeight(0, 700 * scaler) '１行目のセル高さを設定
        C1FlexGrid1.Row = 0 '１行目をアクティブ化

        C1FlexGrid1.Col = 0
        C1FlexGrid1.set_ColWidth(0, twidth)
        C1FlexGrid1.Text = "合算時間"

        C1FlexGrid1.Col = 1
        C1FlexGrid1.set_ColWidth(1, twidth)
        C1FlexGrid1.Text = "#3錫" & vbCrLf & "溶解量"

        C1FlexGrid1.Col = 2
        C1FlexGrid1.set_ColWidth(2, twidth)
        C1FlexGrid1.Text = "#4錫" & vbCrLf & "溶解量"

        C1FlexGrid1.Col = 3
        C1FlexGrid1.set_ColWidth(3, twidth)
        C1FlexGrid1.Text = "合算" & vbCrLf & "溶解量"

        C1FlexGrid1.Col = 4
        C1FlexGrid1.set_ColWidth(4, twidth)
        C1FlexGrid1.Text = "酸素" & vbCrLf & "吹込量"

        C1FlexGrid1.Col = 5
        C1FlexGrid1.set_ColWidth(5, twidth)
        C1FlexGrid1.Text = "ｽﾗｯｼﾞ" & vbCrLf & "発生率"

        'メインセル(MSFlexGrid1)２行目の処理
        C1FlexGrid1.set_RowHeight(1, 300 * scaler) '２行目のセル高さを設定
        C1FlexGrid1.Row = 1 '２行目をアクティブ化

        C1FlexGrid1.Col = 0
        C1FlexGrid1.Text = "tz(min)"

        C1FlexGrid1.Col = 1
        C1FlexGrid1.Text = "S1(kg/h)"

        C1FlexGrid1.Col = 2
        C1FlexGrid1.Text = "S1(kg/h)"

        C1FlexGrid1.Col = 3
        C1FlexGrid1.Text = "S1(kg/h)"

        C1FlexGrid1.Col = 4
        C1FlexGrid1.Text = "O2(Nm3/min)"

        C1FlexGrid1.Col = 5
        C1FlexGrid1.Text = "SL(%)"

        Dim celrow = Fix((C1FlexGrid1.Height - C1FlexGrid1.get_RowHeight(0) * scaler - C1FlexGrid1.get_RowHeight(1) * scaler) / 22)
        For j = 2 To 21 '行数=22　Row：行
            C1FlexGrid1.set_RowHeight(j, celrow) '3行目以降のセル高さを設定
        Next
        C1FlexGrid1.Row = -1
    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        For J = 2 To 21
            If DISCOMBSCH.Dissolution.Count > J - 2 Then
                If J > 2 Then
                    C1FlexGrid1.set_TextMatrix(J, 0, Format(DISCOMBSCH.Dissolution(J - 2).Tz, "###0.0"))
                Else
                    C1FlexGrid1.set_TextMatrix(J, 0, Format(0, "###0.0"))
                End If
                C1FlexGrid1.set_TextMatrix(J, 1, Format(DISCOMBSCH.Dissolution(J - 2).S1_NO3, "##0.0"))
                C1FlexGrid1.set_TextMatrix(J, 2, Format(DISCOMBSCH.Dissolution(J - 2).S1_NO4, "##0.0"))
                C1FlexGrid1.set_TextMatrix(J, 3, Format(DISCOMBSCH.Dissolution(J - 2).S1, "##0.0"))
                C1FlexGrid1.set_TextMatrix(J, 4, Format(DISCOMBSCH.Dissolution(J - 2).O2, "##0.0"))
                C1FlexGrid1.set_TextMatrix(J, 5, Format(DISCOMBSCH.Dissolution(J - 2).SL, "##0.0"))
            Else
                For K = 0 To 5
                    C1FlexGrid1.set_TextMatrix(J, K, "")
                Next
            End If
        Next
        LB_CONTATTIME.Text = Format(ETLPRODSCHS(0).制御実績時間, LB_CONTATTIME.Tag)
        'If DISCOMBSCH.Dissolution.Count > 0 Then
        'LB_CONTATTIME.Text = Format(DISCOMBSCH.Dissolution(0).Tz, LB_CONTATTIME.Tag)
        'Else
        'LB_CONTATTIME.Text = Format(0, LB_CONTATTIME.Tag)
        'End If

        LB_S1S.Text = Format(DISCOMBSCH.S1s, LB_S1S.Tag)
        LB_DS1A.Text = Format(DISCOMBSCH.dS1a, LB_DS1A.Tag)
        LB_DS1B.Text = Format(DISCOMBSCH.dS1b, LB_DS1B.Tag)
        LB_DS1C.Text = Format(DISCOMBSCH.dS1c, LB_DS1C.Tag)
        LB_DS1D.Text = Format(DISCOMBSCH.dS1d, LB_DS1D.Tag)
        LB_DS1E.Text = Format(DISCOMBSCH.dS1e, LB_DS1E.Tag)
        LB_DS1F.Text = Format(DISCOMBSCH.dS1f, LB_DS1F.Tag)
        LB_DS1G.Text = Format(DISCOMBSCH.dS1g, LB_DS1G.Tag)
        LB_DS1H.Text = Format(DISCOMBSCH.dS1h, LB_DS1H.Tag)
        LB_DS1X.Text = Format(DISCOMBSCH.dS1x, LB_DS1X.Tag)
        LB_SDS1.Text = Format(DISCOMBSCH.SdS1, LB_SDS1.Tag)

        If Math.Abs(DISCOMBSCH.dS1a) > 0.01 Then LB_COMP_A.BackColor = Color.Red : LB_COMP_A.ForeColor = Color.Black Else LB_COMP_A.BackColor = Color.White : LB_COMP_A.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1b) > 0.01 Then LB_COMP_B.BackColor = Color.Red : LB_COMP_B.ForeColor = Color.Black Else LB_COMP_B.BackColor = Color.White : LB_COMP_B.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1c) > 0.01 Then LB_COMP_C.BackColor = Color.Red : LB_COMP_C.ForeColor = Color.Black Else LB_COMP_C.BackColor = Color.White : LB_COMP_C.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1d) > 0.01 Then LB_COMP_D.BackColor = Color.Red : LB_COMP_D.ForeColor = Color.Black Else LB_COMP_D.BackColor = Color.White : LB_COMP_D.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1e) > 0.01 Then LB_COMP_E.BackColor = Color.Red : LB_COMP_E.ForeColor = Color.Black Else LB_COMP_E.BackColor = Color.White : LB_COMP_E.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1f) > 0.01 Then LB_COMP_F.BackColor = Color.Red : LB_COMP_F.ForeColor = Color.Black Else LB_COMP_F.BackColor = Color.White : LB_COMP_F.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1g) > 0.01 Then LB_COMP_G.BackColor = Color.Red : LB_COMP_G.ForeColor = Color.Black Else LB_COMP_G.BackColor = Color.White : LB_COMP_G.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1h) > 0.01 Then LB_COMP_H.BackColor = Color.Red : LB_COMP_H.ForeColor = Color.Black Else LB_COMP_H.BackColor = Color.White : LB_COMP_H.ForeColor = Color.White
        If Math.Abs(DISCOMBSCH.dS1x) > 0.01 Then LB_COMP_X.BackColor = Color.Red : LB_COMP_X.ForeColor = Color.Black Else LB_COMP_X.BackColor = Color.White : LB_COMP_X.ForeColor = Color.White


        LB_DS1A_TIME.Text = Format(DISCOMBSCH.dS1a_comp_time, LB_DS1A_TIME.Tag)
        LB_DS1B_TIME.Text = Format(DISCOMBSCH.dS1b_comp_time, LB_DS1B_TIME.Tag)
        LB_DS1C_TIME.Text = Format(DISCOMBSCH.dS1c_comp_time, LB_DS1C_TIME.Tag)
        LB_DS1D_TIME.Text = Format(DISCOMBSCH.dS1d_comp_time, LB_DS1D_TIME.Tag)
        LB_DS1E_TIME.Text = Format(DISCOMBSCH.dS1e_comp_time, LB_DS1E_TIME.Tag)
        LB_DS1F_TIME.Text = Format(DISCOMBSCH.dS1f_comp_time, LB_DS1F_TIME.Tag)
        LB_DS1G_TIME.Text = Format(DISCOMBSCH.dS1g_comp_time, LB_DS1G_TIME.Tag)
        LB_DS1H_TIME.Text = Format(DISCOMBSCH.dS1h_comp_time, LB_DS1H_TIME.Tag)

        LB_S1_UB.Text = Format(DISCOMBSCH.SdS1Limit, LB_S1_UB.Tag)
        LB_S1SET.Text = Format(DISCOMBSCH.S1SET, LB_S1SET.Tag)
        LB_O2SET.Text = Format(DISCOMBSCH.O2, LB_O2SET.Tag)
        LB_SL.Text = Format(DISCOMBSCH.SL, LB_SL.Tag)

    End Sub

    Private Sub C1FlexGrid1_Click(sender As Object, e As EventArgs) Handles C1FlexGrid1.Click
        sender.Row = -1
    End Sub
End Class
