Public Class Frm05DisGrp_BAO

    Inherits FrmButton_BAO

    Private Sub Frm07_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        ScrHdrLabel.Text = "合算溶解グラフ画面"
        ScrHdrLabel.Text = "O2 Flow Graph"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"
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
        If TRENDGRAPHDATA.錫溶解SCH.Count > 1 Then
            seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection
                series.PointData.Length = TRENDGRAPHDATA.錫溶解SCH.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.錫溶解SCH.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.錫溶解SCH(I).X
                    series.Y(I) = TRENDGRAPHDATA.錫溶解SCH(I).Y
                Next
            Next
        End If
        If TRENDGRAPHDATA.O2SCH.Count > 1 Then
            seriesCollection = Chart2D2.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection
                series.PointData.Length = TRENDGRAPHDATA.O2SCH.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.O2SCH.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.O2SCH(I).X
                    series.Y(I) = TRENDGRAPHDATA.O2SCH(I).Y
                Next
            Next
        End If
        If TRENDGRAPHDATA.SLSCH.Count > 1 Then
            seriesCollection = Chart2D3.ChartGroups.Group0.ChartData.SeriesList
            For Each series In seriesCollection
                series.PointData.Length = TRENDGRAPHDATA.SLSCH.Count
                Dim idx = 0
                Dim tcount = TRENDGRAPHDATA.SLSCH.Count - 1
                For I = 0 To tcount
                    series.X(I) = TRENDGRAPHDATA.SLSCH(I).X
                    series.Y(I) = TRENDGRAPHDATA.SLSCH(I).Y
                Next
            Next
        End If

    End Sub
End Class
