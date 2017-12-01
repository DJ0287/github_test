Public Class Frm08IL_BAO

    Inherits FrmButton_BAO

    Private Sub Frm10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ScrHdrLabel.Text = "インターロック表示画面"
        ScrHdrLabel.Text = "Interlock"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"

    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()

        SetInterlock(LB_SCH_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.SCHEDULE_NOTHING).Trigger)
        SetInterlock(LB_FT315_TIN_OK, RECVDATA.WORD_PLC_SRS_D5000.FI315_PV.ToDouble > 0)
        SetInterlock(LB_PT313_TIN_OK, RECVDATA.WORD_PLC_SRS_D5000.PI313_DP_PV.ToDouble > 0)
        SetInterlock(LB_CIR_CONC_OK, ETLTANK_BAO.CIR_TANK.TI_CONC > 0)
        SetInterlock(LB_FIC311_CAS_OK, RECVDATA.BIT_PLC_SRS_M8000.FIC311_CAS)
        SetInterlock(LB_XV311_OPEN_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.XV311_IS_CLOSED).Trigger)
        SetInterlock(LB_NET_OK, (PLCIO.tcp.Connected And CSIO.tcp.Connected))
        SetInterlock(LB_PLAT_OK, RECVDATA.WORD_PLC_SRS_D5000.CURRENT_TOTAL_BACK.ToDouble() + RECVDATA.WORD_PLC_SRS_D5000.CURRENT_TOTAL_FRONT.ToDouble() > 0)
        SetInterlock(LB_CALC_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.CALC_ERROR).Trigger)
        SetInterlock(LB_TIA_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.TIA_CIR_TANK_ERROR).Trigger)
        SetInterlock(LB_DATA_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.FIELD_ERROR).Trigger)

        SetInterlock(LB_PC3AB_RUN_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.PC3AB_STOP).Trigger)
        SetInterlock(LB_PC2AB_RUN_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.PC2AB_STOP).Trigger)
        SetInterlock(LB_XV311_RUN_OK, Not ALAM.ALAMITEMS(ALAM.ALAMNO.XV311_IS_CLOSED).Trigger)

        '★データはダミー。正しいデータに変更すること！
        'SetInterlock(LB_SCH_OK, RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 Or RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Count > 0)
        'SetInterlock(LB_FT315_TIN_OK, RECVDATA.BIT_PLC_SRS_IND.SRS_計測器異常)
        'SetInterlock(LB_PT313_TIN_OK, RECVDATA.WORD_PLC_SRS_IND.FCV2_CAS.Word = CasModeType.CAS)
        'SetInterlock(LB_CIR_CONC_OK, RECVDATA.WORD_PLC_SRS_IND.FCV4_CAS.Word = CasModeType.CAS)
        'SetInterlock(LB_FIC311_CAS_OK, RECVDATA.WORD_PLC_SRS_IND.FCV7_CAS.Word = CasModeType.CAS)
        'SetInterlock(LB_XV311_OPEN_OK, RECVDATA.WORD_PLC_SRS_IND.FCV8_CAS.Word = CasModeType.CAS)
        'SetInterlock(LB_NET_OK, RECVDATA.WORD_PLC_SRS_IND.FCV10_CAS.Word = CasModeType.CAS)
        'SetInterlock(LB_PLAT_OK, PLCIO.tcp.Connected)
        'SetInterlock(LB_CALC_OK, ALAM.ALAMITEMS(ALAM.ALAMNO.CALC_ERROR).Trigger = False)

        'SetInterlock(LB_TIA_OK, RECVDATA.BIT_PLC_SRS_IND.SRS_計測器異常)
        'SetInterlock(LB_DATA_OK, RECVDATA.BIT_PLC_SRS_IND.SRS_計測器異常)

        'SetInterlock(LB_PC3AB_RUN_OK, RECVDATA.WORD_PLC_SRS_IND.FCV2_CAS.Word = CasModeType.CAS)
        'SetInterlock(LB_PC2AB_RUN_OK, RECVDATA.WORD_PLC_SRS_IND.FCV4_CAS.Word = CasModeType.CAS)
        'SetInterlock(LB_XV311_RUN_OK, RECVDATA.WORD_PLC_SRS_IND.FCV7_CAS.Word = CasModeType.CAS)
    End Sub
End Class
