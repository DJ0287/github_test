Public Class Frm04DisGrp_BAO

    Inherits Frm04Base_BAO

    Private Sub Frm05_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        ScrHdrLabel.Text = "No.3ETL溶解グラフ画面"
        ScrHdrLabel.Text = "Dissolution Graph"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"
    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()

        'テストデータ作成
        'テストデータ
#If False And DEBUG Then
        Dim 錫消費SCH As New List(Of System.Drawing.PointF)
        Dim 錫溶解SCH As New List(Of System.Drawing.PointF)
        If TRENDGRAPHDATA.NO3錫消費SCH.Count < 1 Then
            Dim Tz As Double = 0.0
            Dim KeepY As Double = 0.0
            For lotcount = 0 To 10 - 1
                Dim grppt1 As System.Drawing.PointF
                Dim grppt2 As System.Drawing.PointF
                grppt1.X = lotcount * 100
                grppt1.Y = 100.0 + (10 * (lotcount + 1))
                錫消費SCH.Add(grppt1)
                'grppt2.X = grppt1.X + out_sch.Tw
                'grppt2.Y = out_sch.Sn
                '錫消費SCH.Add(grppt2)
            Next

            For lotcount = 0 To 10 - 1
                Dim grppt1 As System.Drawing.PointF
                Dim grppt2 As System.Drawing.PointF
                grppt1.X = lotcount * 100
                grppt1.Y = 100.0 + 20
                錫溶解SCH.Add(grppt1)
                'grppt2.X = grppt1.X + out_sch.Tw
                'If out_sch.Te > 0 Then
                '    grppt2.Y = out_sch.S1
                'Else
                '    grppt2.Y = KeepY
                'End If
                '錫溶解SCH.Add(grppt2)
                'KeepY = grppt2.Y
            Next

            '        grppt.Y = out_sch.S1
            '        錫溶解SCH.Add(grppt)

            TRENDGRAPHDATA.NO3錫消費SCH = 錫消費SCH
            TRENDGRAPHDATA.NO3錫溶解SCH = 錫溶解SCH
        End If
        If TRENDGRAPHDATA.NO3錫溶解SCH.Count < 1 Then
        End If
#End If





        Dim seriesCollection
        If TRENDGRAPHDATA.NO3錫消費SCH.Count > 1 Then
            seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection

                series.PointData.Length = TRENDGRAPHDATA.NO3錫消費SCH.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.NO3錫消費SCH.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.NO3錫消費SCH(I).X
                    series.Y(I) = TRENDGRAPHDATA.NO3錫消費SCH(I).Y
                Next
            Next
        End If
        If TRENDGRAPHDATA.NO3錫溶解SCH.Count > 1 Then
            seriesCollection = Chart2D2.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection
                series.PointData.Length = TRENDGRAPHDATA.NO3錫溶解SCH.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.NO3錫溶解SCH.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.NO3錫溶解SCH(I).X
                    series.Y(I) = TRENDGRAPHDATA.NO3錫溶解SCH(I).Y
                Next
            Next
        End If



    End Sub
End Class
