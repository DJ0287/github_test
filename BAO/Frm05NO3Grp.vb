Public Class Frm05NO3Grp

    Inherits Frm05Base

    Private Sub Frm05_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "No.3ETL溶解グラフ画面"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"
    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
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
