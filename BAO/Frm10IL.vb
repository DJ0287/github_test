Public Class Frm10IL

    Inherits FrmButton

    Private Sub Frm10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "インターロック表示画面"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        SetInterlock(LB_SCH_OK, RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 Or RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Count > 0)
        SetInterlock(LB_MEASURING_OK, RECVDATA.BIT_PLC_SRS_IND.SRS_計測器異常)
        SetInterlock(LB_FCV2_CAS_OK, RECVDATA.WORD_PLC_SRS_IND.FCV2_CAS.Word = CasModeType.CAS)
        SetInterlock(LB_FCV4_CAS_OK, RECVDATA.WORD_PLC_SRS_IND.FCV4_CAS.Word = CasModeType.CAS)
        SetInterlock(LB_FCV7_CAS_OK, RECVDATA.WORD_PLC_SRS_IND.FCV7_CAS.Word = CasModeType.CAS)
        SetInterlock(LB_FCV8_CAS_OK, RECVDATA.WORD_PLC_SRS_IND.FCV8_CAS.Word = CasModeType.CAS)
        SetInterlock(LB_FCV10_CAS_OK, RECVDATA.WORD_PLC_SRS_IND.FCV10_CAS.Word = CasModeType.CAS)
        SetInterlock(LB_L2_OK, PLCIO.tcp.Connected)
        SetInterlock(LB_CALC_OK, ALAM.ALAMITEMS(ALAM.ALAMNO.CALC_ERROR).Trigger = False)
    End Sub
End Class
