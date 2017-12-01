Imports System.Reflection
Imports System.Linq
Imports System.Collections.Generic

Public Class Frm01OV
    Inherits FrmButton
    Dim PipeColorList As New List(Of System.Object)

    Private Sub Frm01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScrHdrLabel.Text = "総合監視画面"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"
        Dim t = GetType(Frm01OV)
        Dim fs = t.GetFields(BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField)
        Dim ls = From l In fs
                 Where (l.FieldType().Name.IndexOf("LineShape") >= 0 And l.Name.IndexOf("LINE") >= 0) Or
                       (l.FieldType().Name.IndexOf("PictureBox") >= 0 And l.Name.IndexOf("ALLOW") >= 0)
                 Select l

        For Each fld In ls
            PipeColorList.Add(t.InvokeMember(fld.Name, BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, Me, Nothing))
        Next
        '        Me.





    End Sub

    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()
        SetPipeGroupCondition(PipeColorList, "A1", RECVDATA.BIT_PLC_SRS_IND.P1)
        SetPipeGroupCondition(PipeColorList, "A2", RECVDATA.BIT_PLC_SRS_IND.V12)
        '        SetPipeGroupCondition(PipeColorList, "A3", RECVDATA.BIT_PLC_SRS_IND.P1 And Not RECVDATA.BIT_PLC_SRS_IND.V12)
        SetPipeGroupCondition(PipeColorList, "A3", RECVDATA.BIT_PLC_SRS_IND.P1)
        SetPipeGroupCondition(PipeColorList, "A4", RECVDATA.BIT_PLC_SRS_IND.P1 And Not RECVDATA.BIT_PLC_SRS_IND.V12 And RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToDouble() > 0.01)
        SetPipeGroupCondition(PipeColorList, "B1", True)
        SetPipeGroupCondition(PipeColorList, "B2", RECVDATA.BIT_PLC_SRS_IND.V16)
        SetPipeGroupCondition(PipeColorList, "C1", RECVDATA.BIT_PLC_SRS_IND.P7)
        SetPipeGroupCondition(PipeColorList, "C2", RECVDATA.BIT_PLC_SRS_IND.V13)
        SetPipeGroupCondition(PipeColorList, "C3", RECVDATA.WORD_PLC_SRS_CTR.FCV2_PV.ToDouble() > 0.01)
        SetPipeGroupCondition(PipeColorList, "C4", RECVDATA.WORD_PLC_SRS_CTR.FCV4_PV.ToDouble() > 0.01)
        'SetPipeGroupCondition(PipeColorList, "D1", RECVDATA.BIT_PLC_SRS_IND.P12)
        SetPipeGroupCondition(PipeColorList, "D1", RECVDATA.BIT_PLC_SRS_IND.P8)
        SetPipeGroupCondition(PipeColorList, "D2", RECVDATA.BIT_PLC_SRS_IND.V19)
        'SetPipeGroupCondition(PipeColorList, "D3", RECVDATA.BIT_PLC_SRS_IND.P12 And Not RECVDATA.BIT_PLC_SRS_IND.V19)
        SetPipeGroupCondition(PipeColorList, "D3", RECVDATA.BIT_PLC_SRS_IND.P8 And Not RECVDATA.BIT_PLC_SRS_IND.V19)
        'SetPipeGroupCondition(PipeColorList, "D4", RECVDATA.BIT_PLC_SRS_IND.P8)
        SetPipeGroupCondition(PipeColorList, "D4", RECVDATA.BIT_PLC_SRS_IND.P12)
        SetPipeGroupCondition(PipeColorList, "D5", RECVDATA.BIT_PLC_SRS_IND.V6)
        'SetPipeGroupCondition(PipeColorList, "D6", RECVDATA.BIT_PLC_SRS_IND.P8 And Not RECVDATA.BIT_PLC_SRS_IND.V6)
        SetPipeGroupCondition(PipeColorList, "D6", RECVDATA.BIT_PLC_SRS_IND.P12 And Not RECVDATA.BIT_PLC_SRS_IND.V6)
        'SetPipeGroupCondition(PipeColorList, "D7", (RECVDATA.BIT_PLC_SRS_IND.P8 And Not RECVDATA.BIT_PLC_SRS_IND.V19) Or (RECVDATA.BIT_PLC_SRS_IND.P12 And Not RECVDATA.BIT_PLC_SRS_IND.V6))
        SetPipeGroupCondition(PipeColorList, "D7", (RECVDATA.BIT_PLC_SRS_IND.P12 And Not RECVDATA.BIT_PLC_SRS_IND.V6) Or (RECVDATA.BIT_PLC_SRS_IND.P8 And Not RECVDATA.BIT_PLC_SRS_IND.V19))
        SetPipeGroupCondition(PipeColorList, "E1", RECVDATA.BIT_PLC_SRS_IND.P2)
        SetPipeGroupCondition(PipeColorList, "E2", RECVDATA.WORD_PLC_SRS_CTR.FCV8_PV.ToDouble() > 0.01)
        'イメージ更新
        PB_P1.Image = PumpImage(RECVDATA.BIT_PLC_SRS_IND.P1)
        PB_P2.Image = PumpImage(RECVDATA.BIT_PLC_SRS_IND.P2)
        PB_P7.Image = PumpImage(RECVDATA.BIT_PLC_SRS_IND.P7)
        PB_P8.Image = PumpImage(RECVDATA.BIT_PLC_SRS_IND.P8)
        PB_P12.Image = PumpImage(RECVDATA.BIT_PLC_SRS_IND.P12)

        PB_V6.Image = SVImage(RECVDATA.BIT_PLC_SRS_IND.V6)
        PB_V12.Image = SVImage(RECVDATA.BIT_PLC_SRS_IND.V12)
        PB_V13.Image = SVImage(RECVDATA.BIT_PLC_SRS_IND.V13)
        PB_V16.Image = SVImage(RECVDATA.BIT_PLC_SRS_IND.V16)
        PB_V19.Image = SVImage(RECVDATA.BIT_PLC_SRS_IND.V19)

        PB_FCV2.Image = CVImage(RECVDATA.WORD_PLC_SRS_CTR.FCV2_PV.ToDouble() > 0.01)
        PB_FCV4.Image = CVImage(RECVDATA.WORD_PLC_SRS_CTR.FCV4_PV.ToDouble() > 0.01)
        PB_FCV7.Image = CVImage(RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToDouble() > 0.01)
        PB_FCV8.Image = CVRotImage(RECVDATA.WORD_PLC_SRS_CTR.FCV8_PV.ToDouble() > 0.01)
        PB_FCV10.Image = CVImage(RECVDATA.WORD_PLC_SRS_CTR.FCV10_PV.ToDouble() > 0.01)

        SetCASModeText(LB_FCV2_CAS, RECVDATA.WORD_PLC_SRS_IND.FCV2_CAS.Word)
        SetCASModeText(LB_FCV4_CAS, RECVDATA.WORD_PLC_SRS_IND.FCV4_CAS.Word)
        SetCASModeText(LB_FCV7_CAS, RECVDATA.WORD_PLC_SRS_IND.FCV7_CAS.Word)
        SetCASModeText(LB_FCV8_CAS, RECVDATA.WORD_PLC_SRS_IND.FCV8_CAS.Word)
        SetCASModeText(LB_FCV10_CAS, RECVDATA.WORD_PLC_SRS_IND.FCV10_CAS.Word)

        LB_FCV2_PV.Text = Format(RECVDATA.WORD_PLC_SRS_CTR.FCV2_PV.ToDouble(), LB_FCV2_PV.Tag)
        LB_FCV4_PV.Text = Format(RECVDATA.WORD_PLC_SRS_CTR.FCV4_PV.ToDouble(), LB_FCV4_PV.Tag)
        LB_FCV7_PV.Text = Format(RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToDouble(), LB_FCV7_PV.Tag)
        LB_FCV8_PV.Text = Format(RECVDATA.WORD_PLC_SRS_CTR.FCV8_PV.ToDouble(), LB_FCV8_PV.Tag)
        LB_FCV10_PV.Text = Format(RECVDATA.WORD_PLC_SRS_CTR.FCV10_PV.ToDouble(), LB_FCV10_PV.Tag)

        'LB_FCV2_SV.Text = Format(RECVDATA.WORD_PLC_SRS_IND.FCV2_SV.ToFloat(), LB_FCV2_SV.Tag)
        'LB_FCV4_SV.Text = Format(RECVDATA.WORD_PLC_SRS_IND.FCV4_SV.ToFloat(), LB_FCV4_SV.Tag)
        'LB_FCV7_SV.Text = Format(RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToFloat(), LB_FCV8_PV.Tag)
        'LB_FCV8_SV.Text = Format(RECVDATA.WORD_PLC_SRS_IND.FCV8_SV.ToFloat(), LB_FCV8_SV.Tag)
        'LB_FCV10_SV.Text = Format(RECVDATA.WORD_PLC_SRS_IND.FCV10_SV.ToFloat(), LB_FCV10_SV.Tag)
        LB_FCV2_SV.Text = Format(SENDDATA.WORD_SRS_PLC_CTR.FIC2_SV.ToDouble, LB_FCV2_SV.Tag)
        LB_FCV4_SV.Text = Format(SENDDATA.WORD_SRS_PLC_CTR.FIC4_SV.ToDouble, LB_FCV4_SV.Tag)
        LB_FCV7_SV.Text = Format(SENDDATA.WORD_SRS_PLC_CTR.FIC7_SV.ToDouble, LB_FCV7_SV.Tag)
        LB_FCV8_SV.Text = Format(SENDDATA.WORD_SRS_PLC_CTR.FIC8_SV.ToDouble, LB_FCV8_SV.Tag)
        LB_FCV10_SV.Text = Format(SENDDATA.WORD_SRS_PLC_CTR.FIC10_SV.ToDouble, LB_FCV10_SV.Tag)

        LB_STA_PV_CONC.Text = Format(ETLTANK.StA_CONC, LB_STA_PV_CONC.Tag)
        LB_STA_AVE_CONC.Text = Format(ETLTANK.StA_AVE, LB_STA_AVE_CONC.Tag)
        LB_NO3_PV_CONC.Text = Format(ETLTANK.No3_CONC, LB_NO3_PV_CONC.Tag)
        LB_NO4_PV_CONC.Text = Format(ETLTANK.No4_CONC, LB_NO4_PV_CONC.Tag)
        LB_NO3_PV_CONC_AVE.Text = Format(ETLTANK.No3_AVE, LB_NO3_PV_CONC_AVE.Tag)
        LB_NO4_PV_CONC_AVE.Text = Format(ETLTANK.No4_AVE, LB_NO4_PV_CONC_AVE.Tag)

        LB_STA_PV_TL.Text = Format(ETLTANK.StA_TL, LB_STA_PV_TL.Tag)
        LB_STA_SV_TL.Text = Format(ETLTANK.StA_TL_SETVAL, LB_STA_SV_TL.Tag)
        LB_NO3_PV_TL.Text = Format(ETLTANK.No3_TL, LB_NO3_PV_TL.Tag)
        LB_NO4_PV_TL.Text = Format(ETLTANK.No4_TL, LB_NO4_PV_TL.Tag)

        LB_STB_PV_TL.Text = Format(ETLTANK.StB_TL, LB_STB_PV_TL.Tag)
        LB_STA_AVE_CONC.Enabled = RECVDATA.BIT_PLC_SRS_IND.StA_濃度測定完了
        LB_NO3_PV_CONC_AVE.Enabled = RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定完了
        LB_NO4_PV_CONC_AVE.Enabled = RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定完了
        LB_STA_PV_CONC.Enabled = RECVDATA.BIT_PLC_SRS_IND.StA_濃度測定中
        LB_NO3_PV_CONC.Enabled = RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定中
        LB_NO4_PV_CONC.Enabled = RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定中

        LB_溶解槽.Text = Format(ETLTANK.溶解槽_TL, LB_溶解槽.Tag)
        Dim ライン速度() As Double = {RECVDATA.WORD_PLC_SRS_IND.No3_LS.ToDouble(), RECVDATA.WORD_PLC_SRS_IND.No4_LS.ToDouble()}
        If RECVDATA.BIT_PLC_SRS_IND.No3_調整材 Then
            SetLineText(LB_NO3_RUN, LineConditionType.調整材, "3ETL")
        Else
            If CONDITION.LINESPEED.Display(0, Task03Control_01sec.scantime) Then
                SetLineText(LB_NO3_RUN, LineConditionType.ETL運転中, "3ETL")
            Else
                SetLineText(LB_NO3_RUN, LineConditionType.ETL停止中, "3ETL")
            End If
        End If
        If RECVDATA.BIT_PLC_SRS_IND.No4_調整材 Then
            SetLineText(LB_NO4_RUN, LineConditionType.調整材, "4ETL")
        Else
            If CONDITION.LINESPEED.Display(1, Task03Control_01sec.scantime) Then
                SetLineText(LB_NO4_RUN, LineConditionType.ETL運転中, "4ETL")
            Else
                SetLineText(LB_NO4_RUN, LineConditionType.ETL停止中, "4ETL")
            End If
        End If

        'SetRunText(LB_TIN_CHARGE, RECVDATA.BIT_PLC_SRS_CTR.溶解槽_錫投入中)
        SetGenericLamp(LB_TIN_CHARGE, RECVDATA.BIT_PLC_SRS_CTR.溶解槽_錫投入中, "錫投入中", Color.Black, Color.Yellow, "錫投入中", SystemColors.GrayText, SystemColors.Control)
        SetGenericLamp(LB_O2_CHARGE, RECVDATA.WORD_PLC_SRS_CTR.溶解槽_槽内圧力.ToDouble <= PARAMETER.Search("PL").設定値, "酸素吹込停止中 : 槽内圧低下", Color.Black, Color.Yellow, "酸素吹込停止中 : 槽内圧低下", SystemColors.GrayText, SystemColors.Control)
        LB_SYS_RUNTIME.Text = Format(Fix(SYSTEMCONDITION.システム稼働時間.TotalHours()), LB_SYS_RUNTIME.Tag)
        LB_ETL_RUNTIME.Text = Format(Fix(SYSTEMCONDITION.ETL操業時間.TotalHours()), LB_ETL_RUNTIME.Tag)
        LB_OP_RATE.Text = Format(SYSTEMCONDITION.稼働率(), LB_OP_RATE.Tag)
        If SYSTEMCONDITION.更新時刻 > DateTime.MinValue Then
            LB_SYS_UPDATETIME.Text = SYSTEMCONDITION.更新時刻.ToString("yyyy/MM/dd HH:mm:ss")
        Else
            LB_SYS_UPDATETIME.Text = ""
        End If
        LB_SYS_RUNTIME_Last.Text = Format(Fix(SYSTEMCONDITION.Lastシステム稼働時間.TotalHours()), LB_SYS_RUNTIME_Last.Tag)
        LB_ETL_RUNTIME_Last.Text = Format(Fix(SYSTEMCONDITION.LastETL操業時間.TotalHours()), LB_ETL_RUNTIME_Last.Tag)
        LB_OP_RATE_Last.Text = Format(SYSTEMCONDITION.Last稼働率, LB_OP_RATE_Last.Tag)

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        PopupGeneric.Label1.Text = "稼働時間を初期化します。よろしいですか？"
        Dim dres As DialogResult = PopupGeneric.ShowDialog()
        If dres = Windows.Forms.DialogResult.OK Then
            SYSTEMCONDITION.Export(My.Application.Info.DirectoryPath & "\SystemCond.csv")
        End If

    End Sub
End Class
