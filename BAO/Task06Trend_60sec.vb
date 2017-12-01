Imports System.Text
Imports System.IO

Public Class Task06Trend_60sec
    Inherits Task00Base
    Implements Task00Interface
    Dim 実績 As New SortedList(Of DateTime, Tuple(Of Single, Single, Single))
    Public Sub New(_ds As Dictionary(Of String, InterfaceMap))
        MyBase.New(_ds)
    End Sub
    <System.Runtime.InteropServices.DllImport("User32.dll")>
    Private Shared Function PrintWindow(ByVal hwnd As IntPtr,
    ByVal hDC As IntPtr, ByVal nFlags As Integer) As Boolean
    End Function

    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim e As New TaskEventArgs
        e.etype = TaskEventArgs.EventType.SRS_トレンド更新
        'Call 溶解スケジュールトレンド()
        Call 溶解実績トレンド()
        Call データストレージ()
        If DEBUG.Capture Then
            Dim timestr = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            '    Call 画面キャプチャ(Frm01OV, timestr)
            Call 画面キャプチャ(Frm02SCH_BAO, timestr, "1min")
            '    Call 画面キャプチャ(Frm03NO4SCH, timestr)
            Call 画面キャプチャ(Frm03Dis_BAO, timestr, "1min")
        End If
        Run = e
        Notify(e)
    End Function
    Sub データストレージ()
        If Not FileIO.FileSystem.DirectoryExists("C:\DATASTRAGE") Then
            FileIO.FileSystem.CreateDirectory("C:\DATASTRAGE")
        End If
        Dim ttime = DateTime.Now

        Dim path As String = "C:\DATASTRAGE\" & ttime.ToString("yyyyMMdd") & "_trend.csv"

        If Not FileIO.FileSystem.FileExists(path) Then
            Using sw As New StreamWriter(path, False, Encoding.UTF8)
                'Coil Data
                sw.Write("DateTime")
                For IC = 1 To 20
                    sw.Write(",Lot#")
                    sw.Write(",Width(mm)")
                    sw.Write(",Thickness(mm)")
                    sw.Write(",Weight(ton)")
                    sw.Write(",LS(mpm)")
                    sw.Write(",Coating Top(g/m2)")
                    sw.Write(",Coating Bot(g/m2)")
                Next
                'Public Shared S1s As Double
                'Public Shared dS1a As Double
                'Public Shared dS1b As Double
                'Public Shared dS1c As Double
                'Public Shared dS1d As Double
                'Public Shared dS1x As Double
                'Public Shared SdS1 As Double
                'Public Shared S1SET As Double
                'Public Shared O2SET As Double
                'Public Shared O2 As Double
                'Public Shared SL As Double
                sw.Write(",S1s")
                sw.Write(",dS1a")
                sw.Write(",dS1b")
                sw.Write(",dS1c")
                sw.Write(",dS1d")
                sw.Write(",dS1x")
                sw.Write(",SdS1")
                sw.Write(",S1SET")
                sw.Write(",O2SET")
                sw.Write(",O2")
                sw.Write(",SL")

                DumpHeader(sw, datasource("IF_PLC_TO_SRS_BIT_M9000"))
                DumpHeader(sw, datasource("IF_SRS_TO_PLC_BIT_M9100"))
                DumpHeader(sw, datasource("IF_PLC_TO_SRS_WORD_D6000"))
                DumpHeader(sw, datasource("IF_SRS_TO_PLC_WORD_D6100"))

                sw.WriteLine()
            End Using
        End If
        Using sw As New StreamWriter(path, True, Encoding.UTF8)
            sw.Write(ttime.ToString("yyyy/MM/dd HH:mm:ss"))
            'For IC = 0 To Schl.SchList.Count - 1
            '    Dim sch = Schl.SchList(IC)
            '    sw.Write("," & sch.No.ToString("00000"))
            '    sw.Write("," & sch.Width.ToString("0"))
            '    sw.Write("," & sch.Thickness.ToString("0.000"))
            '    sw.Write("," & sch.Weight.ToString("0.000"))
            '    sw.Write("," & sch.LS.ToString("0"))
            '    sw.Write("," & sch.Coating_Top.ToString("0.000"))
            '    sw.Write("," & sch.Coating_Bot.ToString("0.000"))
            'Next
            For IC = 0 To ETLPRODSCHS(0).Products.Count - 1
                Dim sch = ETLPRODSCHS(0).Products(IC)
                sw.Write("," & sch.No)
                sw.Write("," & sch.Width.ToString("0"))
                sw.Write("," & sch.Thickness.ToString("0.000"))
                sw.Write("," & sch.Weight.ToString("0.000"))
                sw.Write("," & sch.LS.ToString("0"))
                sw.Write("," & sch.Coating.ToString("0.000"))
            Next
            For IC = ETLPRODSCHS(0).Products.Count To 20 - 1
                sw.Write(",99999")
                sw.Write(",99999")
                sw.Write(",99999")
                sw.Write(",99999")
                sw.Write(",99999")
                sw.Write(",99999")
            Next
            sw.Write("," & DISCOMBSCH.S1s)
            sw.Write("," & DISCOMBSCH.dS1a)
            sw.Write("," & DISCOMBSCH.dS1b)
            sw.Write("," & DISCOMBSCH.dS1c)
            sw.Write("," & DISCOMBSCH.dS1d)
            sw.Write("," & DISCOMBSCH.dS1x)
            sw.Write("," & DISCOMBSCH.SdS1)
            sw.Write("," & DISCOMBSCH.S1SET)
            sw.Write("," & DISCOMBSCH.O2SET)
            sw.Write("," & DISCOMBSCH.O2)
            sw.Write("," & DISCOMBSCH.SL)

            DumpData(sw, datasource("IF_PLC_TO_SRS_BIT_M9000"))
            DumpData(sw, datasource("IF_SRS_TO_PLC_BIT_M9100"))
            DumpData(sw, datasource("IF_PLC_TO_SRS_WORD_D6000"))
            DumpData(sw, datasource("IF_SRS_TO_PLC_WORD_D6100"))

            sw.WriteLine()
        End Using

        'Dim imi(5) As OUTSTR
        'For I = 0 To 5

        '    imi(I).Offset = datasource("IF_SRS_TO_PLC_WORD_TREND").interfacelist.Count + I
        '    If I < 2 Then
        '        imi(I).Name = "No" & I + 3 & "_先頭コイルライン速度"
        '        imi(I).field.Unit = 1.0
        '        imi(I).field.UpperLimit = 10000
        '        imi(I).field.LowerLimit = 0
        '        If ETLPRODSCHS(I).Products.Count > 0 Then
        '            imi(I).field.FromDouble(ETLPRODSCHS(I).Products(0).LS)
        '        Else
        '            imi(I).field.FromDouble(0)
        '        End If
        '    ElseIf I < 4 Then
        '        imi(I).Name = "No" & (I - 2) + 3 & "_先頭コイル目付量"
        '        imi(I).field.Unit = 1.0
        '        imi(I).field.UpperLimit = 32767
        '        imi(I).field.LowerLimit = 0
        '        If ETLPRODSCHS(I - 2).Products.Count > 0 Then
        '            imi(I).field.FromDouble(ETLPRODSCHS(I - 2).Products(0).Coating.ToDouble)
        '        Else
        '            imi(I).field.FromDouble(0)
        '        End If

        '    ElseIf I < 6 Then
        '        imi(I).Name = "No" & (I - 4) + 3 & "_ΔS1x"
        '        imi(I).field.Unit = 0.01
        '        imi(I).field.UpperLimit = 32767
        '        imi(I).field.LowerLimit = 0
        '        imi(I).field.FromDouble(Math.Abs(ETLPRODSCHS(I - 4).dS1x))
        '    End If

        'Next

        'DATASTRAGEIO.DataStore("C:\DATASTRAGE", datasource("IF_SRS_TO_PLC_BIT_TREND"))
        'DATASTRAGEIO.DataStore("C:\DATASTRAGE", datasource("IF_SRS_TO_PLC_WORD_TREND"), imi)
        'DATASTRAGEIO.DataStore("C:\DATASTRAGE", datasource("IF_PLC_TO_SRS_WORD_CTR"))
        'DATASTRAGEIO.DataStore("C:\DATASTRAGE", datasource("IF_PLC_TO_SRS_WORD_IND"))

    End Sub


    Sub 溶解実績トレンド()
        Dim 更新実績 As New SortedList(Of DateTime, Tuple(Of Single, Single, Single))
        Dim now = DateTime.Now
        実績.Add(now, New Tuple(Of Single, Single, Single)(DISCOMBSCH.S1SET, DISCOMBSCH.O2SET, DISCOMBSCH.SL))
        '1日以内のデータを取り出す

        Dim activedata = From item In 実績
                         Where item.Key >= now - TimeSpan.FromMinutes(1440)
                         Select item

        TRENDGRAPHDATA.錫溶解実績.Clear()
        TRENDGRAPHDATA.O2実績.Clear()
        TRENDGRAPHDATA.SL実績.Clear()

        For Each item In activedata
            更新実績.Add(item.Key, item.Value)
            Dim grppt As System.Drawing.PointF
            grppt.X = (item.Key - now).TotalMinutes
            grppt.Y = item.Value.Item1
            TRENDGRAPHDATA.錫溶解実績.Add(grppt)
            grppt.Y = item.Value.Item2
            TRENDGRAPHDATA.O2実績.Add(grppt)
            grppt.Y = item.Value.Item3
            TRENDGRAPHDATA.SL実績.Add(grppt)
        Next
        実績 = 更新実績

    End Sub

    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        evlog.Logging(Me, sender, e)
    End Sub
End Class
