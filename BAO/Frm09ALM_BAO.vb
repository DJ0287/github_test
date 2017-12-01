Imports Microsoft.VisualBasic.Compatibility
Public Class Frm09ALM_BAO

    Inherits FrmButton_BAO

    Private Sub Frm09ALM_BAO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Short
        Dim twidth As Short
        Dim theight As Short
        Dim tim As Date = DateAndTime.Now
        ScrHdrLabel.Text = "Alarm"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"


        twidth = (C1FlexGrid1.Width)
        theight = (C1FlexGrid1.Height) / 20
        C1FlexGrid1.Height = theight * 20
        C1FlexGrid1.set_ColWidth(0, 1)
        C1FlexGrid1.set_ColWidth(1, twidth * 0.2)
        C1FlexGrid1.set_ColWidth(2, twidth * 0.1)
        C1FlexGrid1.set_ColWidth(3, twidth * 0.7 - 2)
        C1FlexGrid1.Row = 0
        C1FlexGrid1.Col = 1
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "Year/Month/day"
        C1FlexGrid1.Col = 2
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "Time"
        C1FlexGrid1.Col = 3
        C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid1.Text = "Content"
        '        MSFlexGrid1.CellAlignment = MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter
        C1FlexGrid1.ForeColor = Color.Red

        For i = 0 To C1FlexGrid1.Rows - 1
            C1FlexGrid1.set_RowHeight(i, theight) '１行目のセル高さを設定
            'If i > 0 And i <= ComboBox1.Items.Count Then
            '    C1FlexGrid1.Row = i
            '    C1FlexGrid1.Col = 1
            '    C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '    C1FlexGrid1.Text = tim.ToString("yyyy/MM/dd")
            '    C1FlexGrid1.Col = 2
            '    C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '    C1FlexGrid1.Text = tim.ToString("HH:mm:ss")
            '    C1FlexGrid1.Col = 3
            '    C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignLeftCenter
            '    C1FlexGrid1.Text = ComboBox1.Items(i - 1)
            'End If
        Next
        C1FlexGrid1.Row = -1

    End Sub

    Private Sub PasswdBtn_Click(sender As Object, e As EventArgs) Handles PasswdBtn.Click
        PopupGeneric_BAO.Label1.Text = "The display in which the fault condition is restored is deleted. Is it OK?"
        Dim dres As DialogResult = PopupGeneric_BAO.ShowDialog()
        If dres = Windows.Forms.DialogResult.OK Then
            Dim keys = ALAM.ALAMITEMS.Keys.ToArray
            For Each key In keys
                Dim alm = ALAM.ALAMITEMS(key)
                If alm.Trigger = False And alm.TriggerTime > DateTime.MinValue Then
                    alm.TriggerTime = DateTime.MinValue
                    alm.RecoverTime = DateTime.MinValue
                    ALAM.ALAMITEMS(key) = alm
                End If
            Next
            C1FlexGrid1.Rows = 1
        End If

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        Dim theight = (C1FlexGrid1.Height) / 20
        Dim sortedalamlist = ALAM.ALAMITEMS.Values.ToList()
        sortedalamlist.Sort(AddressOf AlamItem.Comparison)
        C1FlexGrid1.Rows = Math.Max(sortedalamlist.Count + 1, 20)
        Dim r = 1
        For i = 1 To sortedalamlist.Count

            Dim alm = sortedalamlist(i - 1)
            If (alm.TriggerTime > DateTime.MinValue) Then
                C1FlexGrid1.set_RowHeight(r, theight) '１行目のセル高さを設定
                If alm.Trigger Then
                    C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 1, Color.Red)
                    C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 2, Color.Red)
                    C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 3, Color.Red)
                Else
                    C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 1, Color.Black)
                    C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 2, Color.Black)
                    C1FlexGrid1.set_Cell(C1.Win.C1FlexGrid.Classic.CellPropertySettings.flexcpForeColor, r, 3, Color.Black)
                End If

                C1FlexGrid1.set_TextMatrix(r, 1, alm.TriggerTime.ToString("yyyy/MM/dd"))
                C1FlexGrid1.set_TextMatrix(r, 2, alm.TriggerTime.ToString("HH:mm:ss"))
                C1FlexGrid1.set_TextMatrix(r, 3, ALAM.ALAMMESSAGES(alm.No))
                r = r + 1
            End If
        Next
        For i = r To C1FlexGrid1.Rows - 1
            C1FlexGrid1.set_RowHeight(i, theight) '１行目のセル高さを設定
        Next

    End Sub

    Private Sub C1FlexGrid1_Click(sender As Object, e As EventArgs) Handles C1FlexGrid1.Click
        sender.Row = -1
    End Sub
End Class

