Public Class PopupAnlResult_BAO


    Private Sub PopupParamerter_BAO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '履歴欄初期化
        Dim i As Short
        Dim twidth As Short
        Dim theight As Short
        Dim tim As Date = DateAndTime.Now

        twidth = (C1FlexGrid1.Width)
        theight = (C1FlexGrid1.Height) / 19.5
        C1FlexGrid1.Height = theight * 19
        C1FlexGrid1.set_ColWidth(0, 1)
        C1FlexGrid1.set_ColWidth(1, twidth * 0.245)
        C1FlexGrid1.set_ColWidth(2, twidth * 0.245)
        C1FlexGrid1.set_ColWidth(3, twidth * 0.245)
        C1FlexGrid1.set_ColWidth(4, twidth * 0.245)
        C1FlexGrid1.Row = 0
        C1FlexGrid1.Col = 1
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "Time"
        C1FlexGrid1.Col = 2
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "Tin Ion"
        C1FlexGrid1.Col = 3
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "MSA Free acid"
        C1FlexGrid1.Col = 4
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "EN"
        '        MSFlexGrid1.CellAlignment = MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter
        C1FlexGrid1.Row = 1
        C1FlexGrid1.Col = 1
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "-"
        C1FlexGrid1.Col = 2
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "g/L"
        C1FlexGrid1.Col = 3
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "g/L"
        C1FlexGrid1.Col = 4
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "g/L"

        C1FlexGrid1.ForeColor = Color.Black

        For i = 0 To C1FlexGrid1.Rows - 1
            C1FlexGrid1.set_RowHeight(i, theight) '１行目のセル高さを設定
            '    If i > 0 And i <= ComboBox1.Items.Count Then

            '        C1FlexGrid1.Row = i
            '        C1FlexGrid1.Col = 1
            '        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '        C1FlexGrid1.Text = tim.ToString("yyyy/MM/dd")
            '        C1FlexGrid1.Col = 2
            '        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '        C1FlexGrid1.Text = tim.ToString("HH:mm:ss")
            '        C1FlexGrid1.Col = 3
            '        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignLeftCenter
            '        C1FlexGrid1.Text = ComboBox1.Items(i - 1)
            '        C1FlexGrid1.Col = 4
            '        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '        C1FlexGrid1.Text = tim.ToString("yyyy/MM/dd HH:mm")
            '    End If
        Next

        'アナリシスデータセット
        Dim sortedanallist = SLS.SLSHIST
        Dim max = Math.Min(sortedanallist.Count, 100)
        Dim r = 2
        For i = 1 To max
            Dim anl = sortedanallist(i - 1)
            'C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 1, Color.Red)
            'C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 2, Color.Red)
            'C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 3, Color.Red)
            C1FlexGrid1.set_TextMatrix(r, 1, anl.InputTime.ToString)
            C1FlexGrid1.set_TextMatrix(r, 2, anl.TinIon.ToString)
            C1FlexGrid1.set_TextMatrix(r, 3, anl.MSA.ToString)
            C1FlexGrid1.set_TextMatrix(r, 4, anl.EN.ToString)
            r = r + 1
        Next

        C1FlexGrid1.Row = -1

#If False Then
        For j = 2 To 101
            C1FlexGrid1.Row = j
            For i = 1 To 4 'Col：列
                C1FlexGrid1.Col = i
                Select Case i
                    Case 1
                        C1FlexGrid1.Text = tim
                    Case 2
                        C1FlexGrid1.Text = Convert.ToString(14.5 + j / 10)
                    Case 3
                        C1FlexGrid1.Text = "10.0"
                    Case 4
                        C1FlexGrid1.Text = "20.0"
                End Select
            Next
        Next
        'C1FlexGrid2.Row = 1
        'C1FlexGrid2.Col = 1
        'C1FlexGrid2.Text = tim
        'C1FlexGrid2.Col = 2
        'C1FlexGrid2.Text = "15.5"
        'C1FlexGrid2.Col = 3
        'C1FlexGrid2.Text = "11.0"
        'C1FlexGrid2.Col = 4
        'C1FlexGrid2.Text = "21.0"
        C1FlexGrid1.Row = 2
#End If



    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSS_Click(sender As Object, e As EventArgs)

    End Sub
End Class