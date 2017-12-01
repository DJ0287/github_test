Imports Microsoft.VisualBasic.Compatibility

Public Class Frm03NO4SCH
    Inherits Frm02Base

    Private Sub Frm03_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "4ETL生産スケジュール画面"
        LB_ETL_RUN.Text = "No.4ETL運転中"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        FormRedraw(1)


    End Sub
End Class
