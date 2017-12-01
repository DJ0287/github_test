Imports Microsoft.VisualBasic.Compatibility

Public Class Frm02Base
    Inherits FrmButton

    Private Sub Form2Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Handles MyBase.Load
        'Vb.Net Add >>
        Dim i As Short
        Dim j As Short
        Dim twidth As Short
        Dim theight As Short

        'Vb.Net Add <<
        '        Dim scaler As Double = 1.25
        Dim scaler As Double = 1 / 12
        Dim rscaler As Double = 1 / 10

        'メインセル(MSFlexGrid1)の設定
        For j = 0 To 23 '行数=24　Row：行
            C1FlexGrid1.Row = j
            For i = 0 To 12 '列数=12　Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter  'セル内のデータは中央の中央配置とする
            Next i
        Next j
        'MSFlexGrid1.MergeCells = 1      '自由にセルのグループ化可能に設定
        'MSFlexGrid1.set_ColWidth(0, MSFlexGrid1.get_ColWidth(0) - 20)
        'メインセル(MSFlexGrid1)１行目の処理
        C1FlexGrid1.set_RowHeight(0, 700 * rscaler) '１行目のセル高さを設定
        C1FlexGrid1.Row = 0 '１行目をアクティブ化
        'MSFlexGrid1.MergeRow(0) = False '１行目のクループ化は行わない

        C1FlexGrid1.Col = 0
        'MSFlexGrid1.set_ColWidth(0, 1500)
        C1FlexGrid1.set_ColWidth(0, 800 * scaler)
        C1FlexGrid1.Text = "ﾛｯﾄNo."

        C1FlexGrid1.Col = 1
        'MSFlexGrid1.set_ColWidth(1, 1200)
        C1FlexGrid1.set_ColWidth(1, 1000 * scaler)
        C1FlexGrid1.Text = "重量"

        C1FlexGrid1.Col = 2
        C1FlexGrid1.set_ColWidth(2, 1000 * scaler)
        C1FlexGrid1.Text = "T/H"

        C1FlexGrid1.Col = 3
        C1FlexGrid1.set_ColWidth(3, 1000 * scaler)
        C1FlexGrid1.Text = "板厚"

        C1FlexGrid1.Col = 4
        C1FlexGrid1.set_ColWidth(4, 1000 * scaler)
        C1FlexGrid1.Text = "板幅"

        C1FlexGrid1.Col = 5
        C1FlexGrid1.set_ColWidth(5, 1000 * scaler)
        C1FlexGrid1.Text = "目付量"

        C1FlexGrid1.Col = 6
        C1FlexGrid1.set_ColWidth(6, 1000 * scaler)
        C1FlexGrid1.Text = "生産時間"

        C1FlexGrid1.Col = 7
        C1FlexGrid1.set_ColWidth(7, 1000 * scaler)
        C1FlexGrid1.Text = "管理時間"

        C1FlexGrid1.Col = 8
        C1FlexGrid1.set_ColWidth(8, 1200 * scaler)
        C1FlexGrid1.Text = "生産速度"

        C1FlexGrid1.Col = 9
        C1FlexGrid1.set_ColWidth(9, 1200 * scaler)
        C1FlexGrid1.Text = "錫消費量"

        C1FlexGrid1.Col = 10
        C1FlexGrid1.set_ColWidth(10, 1000 * scaler)
        C1FlexGrid1.Text = "制御終了点"


        C1FlexGrid1.Col = 11
        C1FlexGrid1.set_ColWidth(11, 1200 * scaler)
        C1FlexGrid1.Text = "錫必要量"

        twidth = 0
        For i = 0 To 11
            twidth = twidth + C1FlexGrid1.get_ColWidth(i) + 0
        Next i
        'MSFlexGrid1.set_ColWidth(11, VB6.PixelsToTwipsX(MSFlexGrid1.Width) - twidth)
        C1FlexGrid1.set_ColWidth(12, C1FlexGrid1.Width - twidth)
        '&MSFlexGrid1.set_ColWidth(11, 1200)
        C1FlexGrid1.Col = 12
        C1FlexGrid1.Text = "錫溶解量"

        'メインセル(MSFlexGrid1)２行目の処理
        C1FlexGrid1.set_RowHeight(1, 300 * rscaler) '２行目のセル高さを設定
        C1FlexGrid1.Row = 1 '２行目をアクティブ化
        'MSFlexGrid1.MergeRow(1) = False '２行目のクループ化は行わない

        C1FlexGrid1.Col = 0
        C1FlexGrid1.Text = "ﾛｯﾄ#"

        C1FlexGrid1.Col = 1
        C1FlexGrid1.Text = "Wt(ton)"

        C1FlexGrid1.Col = 2
        C1FlexGrid1.Text = "Wth(t/h)"

        C1FlexGrid1.Col = 3
        C1FlexGrid1.Text = "T(mm)"

        C1FlexGrid1.Col = 4
        C1FlexGrid1.Text = "W(mm)"

        C1FlexGrid1.Col = 5
        C1FlexGrid1.Text = "a(mg/m2)"

        C1FlexGrid1.Col = 6
        C1FlexGrid1.Text = "tw(min)"

        C1FlexGrid1.Col = 7
        C1FlexGrid1.Text = "tz(min)"

        C1FlexGrid1.Col = 8
        C1FlexGrid1.Text = "Ls(mpm)"

        C1FlexGrid1.Col = 9
        C1FlexGrid1.Text = "Sn(kg/h)"

        C1FlexGrid1.Col = 10
        C1FlexGrid1.Text = "Te"

        C1FlexGrid1.Col = 11
        C1FlexGrid1.Text = "S(kg)"

        C1FlexGrid1.Col = 12
        C1FlexGrid1.Text = "S1(kg/h)"

        'メインセル(MSFlexGrid1)３行目の処理
        C1FlexGrid1.set_RowHeight(2, 300 * rscaler) '３行目のセル高さを設定
        C1FlexGrid1.Row = 2 '３行目をアクティブ化
        'MSFlexGrid1.MergeRow(2) = True  '３行目はグループ化を行う（但し同一データのもののみ）

        For i = 0 To 5
            C1FlexGrid1.Col = i
            C1FlexGrid1.Text = " "
        Next i

        C1FlexGrid1.Col = 6
        C1FlexGrid1.Text = "ta"

        C1FlexGrid1.Col = 7
        C1FlexGrid1.Text = "tz0"

        C1FlexGrid1.Col = 8
        C1FlexGrid1.Text = " "

        C1FlexGrid1.Col = 9
        C1FlexGrid1.Text = " "

        C1FlexGrid1.Col = 10
        C1FlexGrid1.Text = "Te0"

        C1FlexGrid1.Col = 11
        C1FlexGrid1.Text = "Sf"

        C1FlexGrid1.Col = 12
        C1FlexGrid1.Text = ""

        'メインセル(MSFlexGrid1)４行目の処理
        C1FlexGrid1.set_RowHeight(3, 300 * rscaler) '４行目のセル高さを設定
        C1FlexGrid1.Row = 3 '４行目をアクティブ化
        'MSFlexGrid1.MergeRow(3) = True  '４行目はグループ化を行う（但し同一データのもののみ）
        'For i = 0 To 5
        '    MSFlexGrid1.Col = i
        '    MSFlexGrid1.Text = " "
        'Next i
        theight = (C1FlexGrid1.Height - (C1FlexGrid1.get_RowHeight(0) + C1FlexGrid1.get_RowHeight(1) + C1FlexGrid1.get_RowHeight(2) + C1FlexGrid1.get_RowHeight(3))) / 20

        'メインセル(MSFlexGrid1)５行目～２４行目の処理
        For i = 4 To 23
            C1FlexGrid1.set_RowHeight(i, theight) 'ｎ行目のセル高さを設定
        Next i
        theight = 0
        For j = 0 To 23 '行数=12　Row：行
            theight = theight + C1FlexGrid1.get_RowHeight(j)
        Next
        C1FlexGrid1.Height = theight + 5


        '右サイドセル(MSFlexGrid2)の設定
        For j = 0 To 11 '行数=12　Row：行
            C1FlexGrid2.Row = j
            C1FlexGrid2.CellAlignment = C1.Win.C1FlexGrid.Classic.AlignmentSettings.flexAlignCenterCenter 'セル内のデータは中央の中央配置とする
        Next j

        'MSFlexGrid2.MergeCells = 0      'セルのグループ化は行わない
        C1FlexGrid2.Col = 0 '１列目をアクティブ化（１列しかない）
        'MSFlexGrid2.set_ColWidth(0, VB6.PixelsToTwipsX(MSFlexGrid2.Width)) '列幅を設定
        C1FlexGrid2.set_ColWidth(0, C1FlexGrid2.Width) '列幅を設定

        C1FlexGrid2.Row = 0
        C1FlexGrid2.set_RowHeight(0, 700 * scaler)
        C1FlexGrid2.Text = "錫溶解" & vbCrLf & "予定量"

        C1FlexGrid2.Row = 1
        C1FlexGrid2.set_RowHeight(1, 300 * scaler)
        C1FlexGrid2.Text = "S1p(kg)"

        C1FlexGrid2.Row = 2
        C1FlexGrid2.set_RowHeight(2, 300 * scaler)
        C1FlexGrid2.Text = ""

        C1FlexGrid2.Row = 3
        C1FlexGrid2.set_RowHeight(3, 700 * scaler)
        C1FlexGrid2.Text = "錫溶解" & vbCrLf & "完了量"

        C1FlexGrid2.Row = 4
        C1FlexGrid2.set_RowHeight(4, 300 * scaler)
        C1FlexGrid2.Text = "S1f(kg)"

        C1FlexGrid2.Row = 5
        C1FlexGrid2.set_RowHeight(5, 300 * scaler)
        C1FlexGrid2.Text = ""

        C1FlexGrid2.Row = 6
        C1FlexGrid2.set_RowHeight(6, 700 * scaler)
        C1FlexGrid2.Text = "錫溶解予定" & vbCrLf & "過不足分"

        C1FlexGrid2.Row = 7
        C1FlexGrid2.set_RowHeight(7, 300 * scaler)
        C1FlexGrid2.Text = "S1p-S1f(kg)"

        C1FlexGrid2.Row = 8
        C1FlexGrid2.set_RowHeight(8, 300 * scaler)
        C1FlexGrid2.Text = ""

        C1FlexGrid2.Row = 9
        C1FlexGrid2.set_RowHeight(9, 700 * scaler)
        C1FlexGrid2.Text = "錫溶解" & vbCrLf & "補正量"

        C1FlexGrid2.Row = 10
        C1FlexGrid2.set_RowHeight(10, 300 * scaler)
        C1FlexGrid2.Text = "ΔS1x(kg/h)"

        C1FlexGrid2.Row = 11
        C1FlexGrid2.set_RowHeight(11, 300 * scaler)
        C1FlexGrid2.Text = ""
        theight = 0
        For j = 0 To 11 '行数=12　Row：行
            theight = theight + C1FlexGrid2.get_RowHeight(j)
        Next
        C1FlexGrid2.Height = theight

        'メインセル(MSFlexGrid1) セルの色塗りを実行
        For j = 0 To 1 'Row：行
            C1FlexGrid1.Row = j
            For i = 0 To 5 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(192, 192, 255))
            Next i
        Next j

        For j = 4 To 23 'Row：行
            C1FlexGrid1.Row = j
            For i = 0 To 5 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(192, 192, 255))
            Next i
        Next j


        For j = 0 To 1 'Row：行
            C1FlexGrid1.Row = j
            For i = 6 To 12 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(192, 255, 192))
            Next i
        Next j

        For j = 4 To 23 'Row：行
            C1FlexGrid1.Row = j
            For i = 6 To 12 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(192, 255, 192))
            Next i
        Next j

        For j = 2 To 3 'Row：行
            C1FlexGrid1.Row = j
            For i = 6 To 6 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 128))
            Next i
        Next j

        For j = 2 To 3 'Row：行
            C1FlexGrid1.Row = j
            For i = 7 To 7 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 128, 128))
            Next i
        Next j

        For j = 2 To 3 'Row：行
            C1FlexGrid1.Row = j
            For i = 10 To 10 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 128))
            Next i
        Next j

        For j = 2 To 3 'Row：行
            C1FlexGrid1.Row = j
            For i = 11 To 11 'Col：列
                C1FlexGrid1.Col = i
                C1FlexGrid1.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 128, 128))
            Next i
        Next j

        '右サイドセル(MSFlexGrid2) セルの色塗りを実行
        C1FlexGrid2.Col = 0 '１列目をアクティブ化（１列しかない）

        For j = 0 To 2 'Row：行
            C1FlexGrid2.Row = j
            C1FlexGrid2.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 192, 128))
        Next j

        For j = 3 To 5 'Row：行
            C1FlexGrid2.Row = j
            C1FlexGrid2.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(128, 128, 255))
        Next j

        For j = 6 To 8 'Row：行
            C1FlexGrid2.Row = j
            C1FlexGrid2.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 128))
        Next j

        For j = 9 To 11 'Row：行
            C1FlexGrid2.Row = j
            C1FlexGrid2.CellBackColor = System.Drawing.ColorTranslator.FromOle(RGB(192, 192, 255))
        Next j

        ''ライン速度補正係数の表示
        '        SPDfactText.Text = VB6.Format(SPD_FACTOR, "0.00")

        '画面リフレッシュ処理呼出し
        'Call formredraw()
#If False Then
        For j = 4 To 23
            C1FlexGrid1.Row = j
            For i = 0 To 11 'Col：列
                C1FlexGrid1.Col = i
                Select Case i
                    Case 0, 5
                        C1FlexGrid1.Text = "99999"
                    Case 1
                        C1FlexGrid1.Text = "999.9"
                    Case 2
                        C1FlexGrid1.Text = "999.99"
                    Case 3
                        C1FlexGrid1.Text = "9.999"
                    Case 4, 6, 7
                        C1FlexGrid1.Text = "9999.9"
                    Case 8
                        C1FlexGrid1.Text = "99.99"
                    Case 9
                        If j = 10 Then
                            C1FlexGrid1.Text = "Te1"
                        End If
                        If j = 20 Then
                            C1FlexGrid1.Text = "Te2"
                        End If
                    Case 10
                        C1FlexGrid1.Text = "999.99"
                    Case 11
                        If j = 10 Or j = 20 Then
                            C1FlexGrid1.Text = "999.99"
                        End If

                End Select
            Next
        Next
        C1FlexGrid1.Row = 3
        C1FlexGrid1.Col = 6
        C1FlexGrid1.Text = "9999.9"
        C1FlexGrid1.Col = 7
        C1FlexGrid1.Text = "9999.9"
        C1FlexGrid1.Col = 9
        C1FlexGrid1.Text = "9999.9"
        C1FlexGrid1.Col = 10
        C1FlexGrid1.Text = "9999.9"

        C1FlexGrid2.Col = 0
        C1FlexGrid2.Row = 2
        C1FlexGrid2.Text = "9999.99"
        C1FlexGrid2.Row = 5
        C1FlexGrid2.Text = "9999.99"
        C1FlexGrid2.Row = 8
        C1FlexGrid2.Text = "9999.99"
        C1FlexGrid2.Row = 11
        C1FlexGrid2.Text = "9999.99"
#End If

        C1FlexGrid1.Row = -1
        C1FlexGrid2.Row = -1

    End Sub
    Protected Sub FormRedraw(no)
        Dim Products As List(Of ProductData) = ETLPRODSCHS(no).Products
        Dim teend = 0

        LB_CTL_TIME.Text = Format(ETLPRODSCHS(no).制御実績時間, "###0.0")
        LB_LINESTOP_TIME.Text = Format(ETLPRODSCHS(no).ライン停止時間, "###0.0")

        Dim ライン速度() As Double = {RECVDATA.WORD_PLC_SRS_IND.No3_LS.ToDouble(), RECVDATA.WORD_PLC_SRS_IND.No4_LS.ToDouble()}
        Select Case no
            Case 0
                If RECVDATA.BIT_PLC_SRS_IND.No3_調整材 Then
                    SetLineText(LB_ETL_RUN, LineConditionType.調整材, "3ETL")
                Else
                    If CONDITION.LINESPEED.Display(0, Task03Control_01sec.scantime) Then
                        SetLineText(LB_ETL_RUN, LineConditionType.ETL運転中, "3ETL")
                    Else
                        SetLineText(LB_ETL_RUN, LineConditionType.ETL停止中, "3ETL")
                    End If
                End If

            Case 1
                If RECVDATA.BIT_PLC_SRS_IND.No4_調整材 Then
                    SetLineText(LB_ETL_RUN, LineConditionType.調整材, "4ETL")
                Else
                    If CONDITION.LINESPEED.Display(1, Task03Control_01sec.scantime) Then
                        SetLineText(LB_ETL_RUN, LineConditionType.ETL運転中, "4ETL")
                    Else
                        SetLineText(LB_ETL_RUN, LineConditionType.ETL停止中, "4ETL")
                    End If
                End If

        End Select

        For j = 4 To 23
            If Products.Count > j - 4 Then
                C1FlexGrid1.set_TextMatrix(j, 0, Format((no + 3) * 10000 + Products(j - 4).No.Word, "0000"))
                If j = 4 Then
                    C1FlexGrid1.set_TextMatrix(j, 1, Format(Products(j - 4).Weight_bk, "##0.0"))
                Else
                    C1FlexGrid1.set_TextMatrix(j, 1, Format(Products(j - 4).Weight.ToDouble(), "##0.0"))
                End If
                C1FlexGrid1.set_TextMatrix(j, 2, Format(Products(j - 4).TPH.ToDouble(), "##0.00"))
                C1FlexGrid1.set_TextMatrix(j, 3, Format(Products(j - 4).Thickness.ToDouble(), "0.000"))
                C1FlexGrid1.set_TextMatrix(j, 4, Format(Products(j - 4).Width.ToDouble(), "###0.0"))
                C1FlexGrid1.set_TextMatrix(j, 5, Format(Products(j - 4).Coating.ToDouble(), "####0"))
                C1FlexGrid1.set_TextMatrix(j, 6, Format(Products(j - 4).Tw, "###0.0"))
                C1FlexGrid1.set_TextMatrix(j, 7, Format(Products(j - 4).Tz, "###0.0"))
                C1FlexGrid1.set_TextMatrix(j, 8, Format(Products(j - 4).LS, "##0.00"))
                C1FlexGrid1.set_TextMatrix(j, 9, Format(Products(j - 4).Sn, "#0.00"))
                If Products(j - 4).Te <> 0 Then
                    C1FlexGrid1.set_TextMatrix(j, 10, "Te" & Math.Abs(Products(j - 4).Te))
                    teend = Products(j - 4).Te
                Else
                    C1FlexGrid1.set_TextMatrix(j, 10, "")
                End If
                C1FlexGrid1.set_TextMatrix(j, 11, Format(Products(j - 4).S, "##0.00"))
                If j = 4 Or Products(j - 4).Te > 0 Then
                    C1FlexGrid1.set_TextMatrix(j, 12, Format(Products(j - 4).S1, "##0.00"))
                Else
                    C1FlexGrid1.set_TextMatrix(j, 12, "")
                End If
            Else
                If Products.Count > 0 And Products.Count = j - 4 Then
                    Dim lastsch = Products(Products.Count - 1)
                    C1FlexGrid1.set_TextMatrix(j, 0, "")
                    C1FlexGrid1.set_TextMatrix(j, 1, Format(0.0, "##0.0"))
                    C1FlexGrid1.set_TextMatrix(j, 2, Format(0.0, "##0.00"))
                    C1FlexGrid1.set_TextMatrix(j, 3, Format(0.0, "0.000"))
                    C1FlexGrid1.set_TextMatrix(j, 4, Format(0.0, "###0.0"))
                    C1FlexGrid1.set_TextMatrix(j, 5, Format(0.0, "####0"))
                    C1FlexGrid1.set_TextMatrix(j, 6, Format(0.0, "###0.0"))
                    C1FlexGrid1.set_TextMatrix(j, 7, Format(lastsch.Tz + lastsch.Tw, "###0.0"))
                    C1FlexGrid1.set_TextMatrix(j, 8, Format(0.0, "##0.00"))
                    C1FlexGrid1.set_TextMatrix(j, 9, Format(0.0, "##0.00"))
                    C1FlexGrid1.set_TextMatrix(j, 10, "Te" & teend + 1)
                    C1FlexGrid1.set_TextMatrix(j, 11, Format(0.0, "##0.00"))
                    C1FlexGrid1.set_TextMatrix(j, 12, "")
                Else
                    For K = 0 To 12
                        C1FlexGrid1.set_TextMatrix(j, K, "")
                    Next
                End If
            End If

        Next

        C1FlexGrid1.set_TextMatrix(3, 6, Format(ETLPRODSCHS(no).TA, "###0.0"))
        C1FlexGrid1.set_TextMatrix(3, 7, Format(ETLPRODSCHS(no).TZ0, "###0.0"))
        C1FlexGrid1.set_TextMatrix(3, 10, Format(ETLPRODSCHS(no).TE0, "###0.0"))
        C1FlexGrid1.set_TextMatrix(3, 11, Format(ETLPRODSCHS(no).Sf, "###0.0"))

        C1FlexGrid2.set_TextMatrix(2, 0, Format(ETLPRODSCHS(no).S1p, "###0.0"))
        C1FlexGrid2.set_TextMatrix(5, 0, Format(ETLPRODSCHS(no).S1f, "###0.0"))
        C1FlexGrid2.set_TextMatrix(8, 0, Format(ETLPRODSCHS(no).S1p - ETLPRODSCHS(no).S1f, "###0.0"))
        C1FlexGrid2.set_TextMatrix(11, 0, Format(ETLPRODSCHS(no).dS1x, "###0.0"))

        'For j = 4 To 23
        '    If Products.Count > j - 4 Then
        '        MSFlexGrid1.Row = j
        '        For i = 0 To 11 'Col：列
        '            MSFlexGrid1.Col = i
        '            Select Case i
        '                Case 0
        '                    MSFlexGrid1.Text = Format(Products(j - 4).No.Word, "0000")
        '                Case 1
        '                    MSFlexGrid1.Text = Format(Products(j - 4).Weight.ToFloat(), "##0.0")
        '                Case 2
        '                    MSFlexGrid1.Text = Format(Products(j - 4).TPH.ToFloat(), "##0.00")
        '                Case 3
        '                    MSFlexGrid1.Text = Format(Products(j - 4).Thickness.ToFloat(), "0.000")
        '                Case 4
        '                    MSFlexGrid1.Text = Format(Products(j - 4).Width.ToFloat(), "###0.0")
        '                Case 5
        '                    MSFlexGrid1.Text = Format(Products(j - 4).Coating.ToFloat(), "###0.0")
        '                Case 6
        '                    MSFlexGrid1.Text = Format(Products(j - 4).Tw, "###0.0")
        '                Case 7
        '                    MSFlexGrid1.Text = Format(Products(j - 4).Tz, "###0.0")
        '                Case 8
        '                    MSFlexGrid1.Text = Format(Products(j - 4).Sn, "#0.00")
        '                Case 9
        '                    If Products(j - 4).Te > 0 Then MSFlexGrid1.Text = "Te" & Products(j - 4).Te
        '                Case 10
        '                    MSFlexGrid1.Text = Format(Products(j - 4).S, "##0.00")
        '                Case 11
        '                    If Products(j - 4).Te > 0 Then MSFlexGrid1.Text = "Te" & Products(j - 4).S1

        '            End Select
        '        Next
        '    End If
        'Next
    End Sub

    Private Sub C1FlexGrid1_Click(sender As Object, e As EventArgs) Handles C1FlexGrid1.Click
        sender.Row = -1
    End Sub

    Private Sub C1FlexGrid2_Click(sender As Object, e As EventArgs) Handles C1FlexGrid2.Click
        sender.Row = -1
    End Sub
End Class
