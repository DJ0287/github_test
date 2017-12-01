Public Class Frm08O2Grp

    Inherits FrmButton

    Private Sub Frm08_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "溶解実績トレンド画面"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"
        'Chart2D1.LoadChartFromFile("Form8Chart2D1.chart2dxml")
        'Chart2D2.LoadChartFromFile("Form8Chart2D2.chart2dxml")
        'Chart2D3.LoadChartFromFile("Form8Chart2D2.chart2dxml")

        'Chart2D1.Load("Form8Chart2D1.oc2")
        'Chart2D2.Load("Form8Chart2D2.oc2")
        'Chart2D3.Load("Form8Chart2D3.oc2")
        Dim seriesCollection
        seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
        For Each series In seriesCollection
            series.PointData.Length = 0
        Next
        seriesCollection = Chart2D2.ChartGroups.Group0.ChartData.SeriesList
        For Each series In seriesCollection
            series.PointData.Length = 0
        Next
        seriesCollection = Chart2D3.ChartGroups.Group0.ChartData.SeriesList
        For Each series In seriesCollection
            series.PointData.Length = 0
        Next

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        Dim seriesCollection
        If TRENDGRAPHDATA.錫溶解実績.Count > 1 Then
            seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection
                series.PointData.Length = TRENDGRAPHDATA.錫溶解実績.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.錫溶解実績.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.錫溶解実績(I).X
                    series.Y(I) = TRENDGRAPHDATA.錫溶解実績(I).Y
                Next
            Next
        End If
        If TRENDGRAPHDATA.O2実績.Count > 1 Then
            seriesCollection = Chart2D2.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection
                series.PointData.Length = TRENDGRAPHDATA.O2実績.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.O2実績.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.O2実績(I).X
                    series.Y(I) = TRENDGRAPHDATA.O2実績(I).Y
                Next
            Next
        End If
        If TRENDGRAPHDATA.SL実績.Count > 1 Then
            seriesCollection = Chart2D3.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection
                series.PointData.Length = TRENDGRAPHDATA.SL実績.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.SL実績.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.SL実績(I).X
                    series.Y(I) = TRENDGRAPHDATA.SL実績(I).Y
                Next
            Next
        End If
    End Sub
End Class
