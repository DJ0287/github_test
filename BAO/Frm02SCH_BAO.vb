Imports Microsoft.VisualBasic.Compatibility

Public Class Frm02SCH_BAO
    Inherits Frm02Base_BAO

    Private Sub Frm02_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "Product Schdule"
        LB_ETL_RUN.Text = "Stop"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        FormRedraw(0)   '引数(0)はenoのこと(0:No3、1:No4)


    End Sub
End Class
