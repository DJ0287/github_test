Imports Microsoft.VisualBasic.Compatibility

Public Class Frm02NO3SCH
    Inherits Frm02Base

    Private Sub Frm02_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "3ETL生産スケジュール画面"
        LB_ETL_RUN.Text = "No.3ETL運転中"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        FormRedraw(0)


    End Sub
End Class
