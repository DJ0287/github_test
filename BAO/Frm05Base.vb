Public Class Frm05Base
    Inherits FrmButton

    Private Sub Form5Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Chart2D1.Load("Form5BaseChart2D1.oc2")
        'Chart2D2.Load("Form5BaseChart2D2.oc2")
        'Chart2D1.LoadChartFromFile(cdir & "Form5BaseChart2D1.chart2dxml")
        'Chart2D2.LoadChartFromFile(cdir & "Form5BaseChart2D2.chart2dxml")
        Dim seriesCollection
        seriesCollection = Chart2D1.ChartGroups.Group0.ChartData.SeriesList
        For Each series In seriesCollection
            series.PointData.Length = 0
        Next
        seriesCollection = Chart2D2.ChartGroups.Group0.ChartData.SeriesList
        For Each series In seriesCollection
            series.PointData.Length = 0
        Next


    End Sub
End Class
