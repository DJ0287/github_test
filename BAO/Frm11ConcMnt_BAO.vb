Public Class Frm11ConcMnt_BAO

    Inherits FrmButton_BAO

    Dim PasswdLocked As Boolean = True

    Private Sub Frm07_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        ScrHdrLabel.Text = "合算溶解グラフ画面"
        ScrHdrLabel.Text = "Concentration Monitor"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"

        'チャートデータ初期化
        'Chart2D1.LoadChartFromFile("Form7Chart2D1.chart2dxml")
        'Chart2D2.LoadChartFromFile("Form7Chart2D2.chart2dxml")
        'Chart2D3.LoadChartFromFile("Form7Chart2D3.chart2dxml")
        'Chart2D1.Load("Form7Chart2D1.oc2")
        'Chart2D2.Load("Form7Chart2D2.oc2")
        'Chart2D3.Load("Form7Chart2D3.oc2")
        Dim seriesCollection
        seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
        For Each series In seriesCollection
            series.PointData.Length = 0
        Next
        'seriesCollection = Chart2D2.ChartGroups.Group0.ChartData.SeriesList
        'For Each series In seriesCollection
        '    series.PointData.Length = 0
        'Next
        'seriesCollection = Chart2D3.ChartGroups.Group0.ChartData.SeriesList
        'For Each series In seriesCollection
        '    series.PointData.Length = 0
        'Next

        '入力欄初期化
        Dim i As Short
        Dim twidth As Short
        Dim theight As Short
        Dim tim As Date = DateAndTime.Now

        twidth = (C1FlexGrid2.Width)
        theight = (C1FlexGrid2.Height) / 2.5
        C1FlexGrid2.Height = theight * 2
        C1FlexGrid2.set_ColWidth(0, 0.5)
        C1FlexGrid2.set_ColWidth(1, twidth * 0.25)
        C1FlexGrid2.set_ColWidth(2, twidth * 0.25)
        C1FlexGrid2.set_ColWidth(3, twidth * 0.25)
        C1FlexGrid2.set_ColWidth(4, twidth * 0.248)
        C1FlexGrid2.Row = 0
        C1FlexGrid2.Col = 1
        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid2.Text = "Time"
        C1FlexGrid2.Col = 2
        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid2.Text = "Tin Ion"
        C1FlexGrid2.Col = 3
        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid2.Text = "MSA Free acid"
        C1FlexGrid2.Col = 4
        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
        C1FlexGrid2.Text = "EN"
        '        MSFlexGrid1.CellAlignment = MSFlexGridLib.AlignmentSettings.flexAlignLeftCenter
        C1FlexGrid2.ForeColor = Color.Black

        For i = 0 To C1FlexGrid2.Rows - 1
            C1FlexGrid2.set_RowHeight(i, theight) '１行目のセル高さを設定
            '    If i > 0 And i <= ComboBox1.Items.Count Then

            '        C1FlexGrid2.Row = i
            '        C1FlexGrid2.Col = 1
            '        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '        C1FlexGrid2.Text = tim.ToString("yyyy/MM/dd")
            '        C1FlexGrid2.Col = 2
            '        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '        C1FlexGrid2.Text = tim.ToString("HH:mm:ss")
            '        C1FlexGrid2.Col = 3
            '        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignLeftCenter
            '        C1FlexGrid2.Text = ComboBox1.Items(i - 1)
            '        C1FlexGrid2.Col = 4
            '        C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter
            '        C1FlexGrid2.Text = tim.ToString("yyyy/MM/dd HH:mm")
            '    End If
        Next

        C1FlexGrid2.set_TextMatrix(1, 1, DateAndTime.Now)
        C1FlexGrid2.set_TextMatrix(1, 2, Format(10.0, "#0.0"))
        C1FlexGrid2.set_TextMatrix(1, 3, Format(10.0, "#0.0"))
        C1FlexGrid2.set_TextMatrix(1, 4, Format(10.0, "#0.0"))
        C1FlexGrid2.Row = -1

        '履歴欄初期化
        twidth = (C1FlexGrid1.Width)
        theight = (C1FlexGrid1.Height) / 7.5
        C1FlexGrid1.Height = theight * 7.07
        C1FlexGrid1.set_ColWidth(0, 1)
        C1FlexGrid1.set_ColWidth(1, twidth * 0.25)
        C1FlexGrid1.set_ColWidth(2, twidth * 0.25)
        C1FlexGrid1.set_ColWidth(3, twidth * 0.25)
        C1FlexGrid1.set_ColWidth(4, twidth * 0.248)
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
        Dim max = Math.Min(sortedanallist.Count, 6)
        Dim r = 1
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

        '最終分析結果入力からの経過時間チェック
        'デフォルト＝３０秒
        Timer1.Start()

#If False Then
        For j = 1 To 6
            C1FlexGrid1.Row = j
            For i = 1 To 4 'Col：列
                C1FlexGrid1.Col = i
                Select Case i
                    Case 1
                        C1FlexGrid1.Text = tim
                    Case 2
                        C1FlexGrid1.Text = Convert.ToString(14.5 + j)
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
#End If

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        Dim nowTime = DateTime.Now

        Dim seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
        Dim series = seriesCollection(0)
        If SLS.SLSHIST.Count > 0 Then
            series.PointData.Length = SLS.SLSHIST.Count
            For I = 0 To SLS.SLSHIST.Count - 1
                Dim sh = SLS.SLSHIST(I)
                series.X(I) = (sh.InputTime - nowTime).TotalMinutes()
                series.Y(I) = sh.TinIon
            Next

        End If
        series = seriesCollection(1)
        Dim seq = SLS.DateTime_r.Where(Function(x, I)
                                           Return (x - nowTime).TotalMinutes > -1440
                                       End Function
                             ).Select(Function(x, I)
                                          Return I + 1
                                      End Function)
        If seq.Count > 0 Then
            series.PointData.Length = seq.Count - 1
            For I = 0 To seq.Count - 1
                series.X(I) = (SLS.DateTime_r(seq(I)) - nowTime).TotalMinutes()
                series.Y(I) = SLS.SnD_r(seq(I))
            Next

        End If
        LB_EST.Text = Compatibility.VB6.Format(SLS.SnD, LB_EST.Tag)
        'Dim seriesCollection
        'If TRENDGRAPHDATA.錫溶解SCH.Count > 1 Then
        '    seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
        '    For Each series In seriesCollection
        '        series.PointData.Length = TRENDGRAPHDATA.錫溶解SCH.Count
        '        Dim idx = 0
        '        Dim tcount = TRENDGRAPHDATA.錫溶解SCH.Count - 1
        '        For I = 0 To tcount
        '            series.X(I) = TRENDGRAPHDATA.錫溶解SCH(I).X
        '            series.Y(I) = TRENDGRAPHDATA.錫溶解SCH(I).Y
        '        Next
        '    Next
        'End If

    End Sub

    Private Sub BTN_CONCMNT_ENTER_Click(sender As Object, e As EventArgs) Handles BTN_CONCMNT_ENTER.Click
        PopupGeneric_BAO.Label1.Text = "Do you road the analysis result ?"
        Dim dres As DialogResult = PopupGeneric_BAO.ShowDialog()
        Dim r As Integer
        Dim c As Integer

        If dres = Windows.Forms.DialogResult.OK Then
            '画面更新
            '①推定値の補正処理 (Tin Ion を使う)

            '②Resultデータを一段下に移動
            Dim sortedanallist = SLS.SLSHIST
            Dim max = Math.Min(sortedanallist.Count, 5)
            For j = max To 1 Step -1
                C1FlexGrid1.Row = j
                C1FlexGrid1.set_TextMatrix(j + 1, 1, C1FlexGrid1.get_TextMatrix(j, 1))
                C1FlexGrid1.set_TextMatrix(j + 1, 2, C1FlexGrid1.get_TextMatrix(j, 2))
                C1FlexGrid1.set_TextMatrix(j + 1, 3, C1FlexGrid1.get_TextMatrix(j, 3))
                C1FlexGrid1.set_TextMatrix(j + 1, 4, C1FlexGrid1.get_TextMatrix(j, 4))
            Next
            For i = 1 To 4 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.Text = ""
            Next

            '③Resultデータの最上段に入力データコピー
            C1FlexGrid1.set_TextMatrix(1, 1, C1FlexGrid2.get_TextMatrix(1, 1))
            C1FlexGrid1.set_TextMatrix(1, 2, C1FlexGrid2.get_TextMatrix(1, 2))
            C1FlexGrid1.set_TextMatrix(1, 3, C1FlexGrid2.get_TextMatrix(1, 3))
            C1FlexGrid1.set_TextMatrix(1, 4, C1FlexGrid2.get_TextMatrix(1, 4))

            'アナリシスデータ更新（データ追加＆保存）
            Dim analitem As New SLSItem
            analitem.InputTime = DateTime.Parse(C1FlexGrid2.get_TextMatrix(1, 1))
            analitem.TinIon = CDbl(C1FlexGrid2.get_TextMatrix(1, 2))
            analitem.MSA = CDbl(C1FlexGrid2.get_TextMatrix(1, 3))
            analitem.EN = CDbl(C1FlexGrid2.get_TextMatrix(1, 4))
            SLS.SLSHIST.Insert(0, analitem)
            SLS.Export(My.Application.Info.DirectoryPath & "\SLSRecoard.csv")

            '④入力データを削除(Empty)
            C1FlexGrid2.set_TextMatrix(1, 1, DateAndTime.Now)
            C1FlexGrid2.set_TextMatrix(1, 2, Format(10.0, "#0.0"))
            C1FlexGrid2.set_TextMatrix(1, 3, Format(10.0, "#0.0"))
            C1FlexGrid2.set_TextMatrix(1, 4, Format(10.0, "#0.0"))

            'Dim keys = ALAM.ALAMITEMS.Keys.ToArray
            'For Each key In keys
            '    Dim alm = ALAM.ALAMITEMS(key)
            '    If alm.Trigger = False And alm.TriggerTime > DateTime.MinValue Then
            '        alm.TriggerTime = DateTime.MinValue
            '        alm.RecoverTime = DateTime.MinValue
            '        ALAM.ALAMITEMS(key) = alm
            '    End If
            'Next
            'C1FlexGrid1.Rows = 1
            '再計算指示
            SLS.InputUpdate = True

        End If

    End Sub

    Private Sub BTN_CONCMNT_HISTRY_Click(sender As Object, e As EventArgs) Handles BTN_CONCMNT_HISTRY.Click
        PopupAnlResult_BAO.ShowDialog()

    End Sub

    Private Sub BTN_CONCMNT_PARASET_Click(sender As Object, e As EventArgs) Handles BTN_CONCMNT_PARASET.Click
        Dim dres As DialogResult = PopupPasswd_BAO.ShowDialog()
        If dres = Windows.Forms.DialogResult.OK Then
            Dim pwenable = PARAMETER.Search("PWEnable").Value
            Dim pwdisable = PARAMETER.Search("PWDisable").Value
            If PopupPasswd_BAO.TB_PASSWORD.Text.Contains(pwenable) Then
                'PopupGeneric.Label1.Text = "ロックが解除されました。入力完了後、禁止パスワードを入力してください。"
                PopupGeneric_BAO.Label1.Text = "Password OK."
                PopupGeneric_BAO.ShowDialog()
                PasswdLocked = False

                PopupParamerter_BAO.ShowDialog()
                'SetPasswordLock(LB_LOCK, PasswdLocked)
                'PasswordLockTimer.Interval = 60 * 15 * 1000
                'PasswordLockTimer.Start()
            End If
            'If PasswdLocked = False And PopupPasswd_BAO.TB_PASSWORD.Text.Contains(pwdisable) Then
            '    'PopupGeneric.Label1.Text = "入力がロックされました。再度設定を変更する場合は許可パスワードを入力してください。"
            '    PopupGeneric_BAO.Label1.Text = "Input is locked. To change the setting again please enter the unlock password."
            '    PopupGeneric_BAO.ShowDialog()
            '    PasswdLocked = True
            '    'SetPasswordLock(LB_LOCK, PasswdLocked)
            '    'PasswordLockTimer.Stop()

            'End If
        End If

    End Sub

    Private Sub C1FlexGrid2_ValidateEdit(sender As Object, e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles C1FlexGrid2.ValidateEdit
        If e.Col >= 2 And e.Col <= 4 Then
            Dim dec As Double = Double.Parse(C1FlexGrid2.Editor.Text)
            If dec > 25.0 Or dec < 10.0 Then
                MessageBox.Show("Only values from 10.0 to 25.0 are allowed.", "Caution")
                e.Cancel = True
                C1FlexGrid2.FinishEditing(True)
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '「4時間00分00秒」を表すTimeSpanオブジェクトを作成
        Dim ts1 As New TimeSpan(0, 4, 0, 0)
        'Dim ts1 As New TimeSpan(0, 0, 0, 10)
        '最終入力日時
        Dim dt1 As DateTime
        '最終入力日時＋４時間後
        Dim dt2 As DateTime

        '最終入力日時が空でなければ
        If C1FlexGrid1.get_TextMatrix(1, 1) <> "" Then
            dt1 = DateTime.Parse(C1FlexGrid1.get_TextMatrix(1, 1))
            '最終入力日時＋４時間後を取得
            dt2 = dt1 + ts1

            If dt2 < DateAndTime.Now Then
                '入力欄のセル色／最終入力から４時間経過で赤色表示
                For j = 1 To 1 'Row：行
                    C1FlexGrid2.Row = j
                    For i = 1 To 4 'Col：列
                        C1FlexGrid2.Col = i
                        C1FlexGrid2.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 0, 0))
                    Next i
                Next j
            Else
                '入力欄のセル色／最終入力から４時間経過で赤色表示
                For j = 1 To 1 'Row：行
                    C1FlexGrid2.Row = j
                    For i = 1 To 4 'Col：列
                        C1FlexGrid2.Col = i
                        C1FlexGrid2.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
                    Next i
                Next j
            End If
        End If

    End Sub
End Class
