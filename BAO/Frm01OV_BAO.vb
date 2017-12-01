'Imports Microsoft.VisualBasic.Compatibility.VB6
Imports Microsoft.VisualBasic.Compatibility.VB6

Public Class Frm01OV_BAO
    Dim blinkflag As Boolean = False

    Private Sub Frm01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ScrHdrLabel.Text = "総合監視画面"
        ScrHdrLabel.Text = "Overview"
        Me.Text = ScrHdrLabel.Text & " (" & MyBase.Text & ")"
    End Sub
    Protected Overrides Sub OnUpdate()
        MyBase.OnUpdate()

        'テストデータ
#If 0 And DEBUG Then
        RECVDATA.BIT_PLC_SRS_M8000.P1 = False
        RECVDATA.BIT_PLC_SRS_M8000.P3 = False
        RECVDATA.BIT_PLC_SRS_M8000.P4 = False

        RECVDATA.BIT_PLC_SRS_M8000.XV311 = False

        RECVDATA.WORD_PLC_SRS_D5000.FIC311_O2_PV = New UnitWord(10, 1, 0, 100)

        RECVDATA.BIT_PLC_SRS_M8000.SRS_OP = True

        RECVDATA.WORD_PLC_SRS_D5000.FI315_PV = New UnitWord(20, 1, 0, 100)
        RECVDATA.WORD_PLC_SRS_D5000.PI313_DP_PV = New UnitWord(30, 1, 0, 100)
        RECVDATA.WORD_PLC_SRS_D5000.FIC31342_TANK_PV = New UnitWord(40, 1, 0, 100)

        SENDDATA.WORD_SRS_PLC_D5100.FIC2_SV = New UnitWord(50, 1, 0, 100)
        RECVDATA.WORD_PLC_SRS_D5000.FIC31342_TANK_SV = New UnitWord(60, 1, 0, 100)
#End If

        'イメージ更新
        '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        '＜　Level2(PLC like)I/F変数確定後、正しい変数名に変更する　＞
        PB_PC1.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.PC1_A Or RECVDATA.BIT_PLC_SRS_M9000.PC1_B Or RECVDATA.BIT_PLC_SRS_M9000.PC1_C Or RECVDATA.BIT_PLC_SRS_M9000.PC1_D)
        PB_PC2.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.PC2_A)
        'PB_PC3.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.PC3a Or RECVDATA.BIT_PLC_SRS_M9000.P3b)
        PB_PC4.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.PC4_A)
        PB_PC5.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.PC5_AB)
        PB_PC6.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.PC6_AB)
        'PB_PC7.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.P7a Or RECVDATA.BIT_PLC_SRS_M9000.P7b)
        PB_PC21.Image = PumpImage(RECVDATA.BIT_PLC_SRS_M9000.PC21_A)

        PB_XV311.Image = SVImage(RECVDATA.BIT_PLC_SRS_M9000.XV1311)
        PB_XV1305_1.Image = SVImage(RECVDATA.BIT_PLC_SRS_M9000.XV1305_1)
        PB_XV1305_2.Image = SVImage(RECVDATA.BIT_PLC_SRS_M9000.XV1305_2)
        PB_XV1308.Image = SVImage(RECVDATA.BIT_PLC_SRS_M9000.XV1308)
        PB_XV1309.Image = SVImage(RECVDATA.BIT_PLC_SRS_M9000.XV1309)
        PB_XV1393_2.Image = SVImage(RECVDATA.BIT_PLC_SRS_M9000.XV1393_2)

        PB_FCV311_1.Image = CVImage(RECVDATA.WORD_PLC_SRS_D6000.FIC1311_1_PV.ToDouble() > 0.01)
        PB_FCV311_2.Image = CVImage(RECVDATA.WORD_PLC_SRS_D6000.FIC1311_2_PV.ToDouble() > 0.01)

        SetCASModeColor(LB_FIC311_CAS, LB_FIC311_NOTCAS, RECVDATA.BIT_PLC_SRS_M9000.FIC311_CAS)

        LB_FI315_PV.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FIA1315_PV.ToDouble(), LB_FI315_PV.Tag)
        LB_PI313_PV.Text = Format(ETLTANK_BAO.PT313, LB_PI313_PV.Tag)
        LB_FIC1311_1_PV.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FIC1311_1_PV.ToDouble(), LB_FIC1311_1_PV.Tag)
        'LB_FIC1311_1_SV.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FIC1311_1_SV.ToDouble(), LB_FIC1311_1_SV.Tag)
        LB_FIC1311_2_PV.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FIC1311_1_PV.ToDouble(), LB_FIC1311_2_PV.Tag)
        'LB_FIC1311_2_SV.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FIC1311_1_SV.ToDouble(), LB_FIC1311_2_SV.Tag)

        LB_BUF_AVE_CONC.Text = Format(ETLTANK_BAO.BUF_TANK.TI_CONC, LB_BUF_AVE_CONC.Tag)
        LB_CIR_AVE_CONC.Text = Format(ETLTANK_BAO.CIR_TANK.TI_CONC, LB_CIR_AVE_CONC.Tag)

        LB_BUF_PV_TL.Text = Format(ETLTANK_BAO.BUF_TANK.LEVEL, LB_BUF_PV_TL.Tag)
        LB_CIR_PV_TL.Text = Format(ETLTANK_BAO.CIR_TANK.LEVEL, LB_CIR_PV_TL.Tag)
        LB_LI1304_PV.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.LIA1304_PV.ToDouble(), LB_LI1304_PV.Tag)
        LB_LI1381_PV.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.LIA1302_PV.ToDouble, LB_LI1381_PV.Tag)

        LB_TIN_SUPPLY.Text = Format(SLS.Tin_supply, LB_TIN_SUPPLY.Tag)
        LB_TIN_CONC.Text = Format(SLS.Tin_consume, LB_TIN_SUPPLY.Tag)

        LB_FT1305_1.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FI1305_1_PV.ToDouble(), LB_FT1305_1.Tag)
        LB_FT1305_2.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FI1305_2_PV.ToDouble(), LB_FT1305_2.Tag)
        LB_FT1308.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FI1308_PV.ToDouble(), LB_FT1308.Tag)
        LB_FT1309.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FI1309_PV.ToDouble(), LB_FT1309.Tag)
        LB_FT1393_2.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.FI1393_2_PV.ToDouble(), LB_FT1393_2.Tag)
        '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
        If SLS.TinIonInputTime <> DateTime.MinValue AndAlso (DateTime.Now - SLS.TinIonInputTime).TotalHours > 4 Then
            If blinkflag Then
                LB_CIR_AVE_CONC.BackColor = Color.Red
                LB_CIR_AVE_CONC.ForeColor = Color.WhiteSmoke
            Else
                LB_CIR_AVE_CONC.BackColor = Color.WhiteSmoke
                LB_CIR_AVE_CONC.ForeColor = Color.Black

            End If
            blinkflag = Not blinkflag
        Else
            LB_CIR_AVE_CONC.BackColor = Color.WhiteSmoke
            LB_CIR_AVE_CONC.ForeColor = Color.Black
        End If
        '↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        '＜　BAOは、BMオブジェクトなし　＞
        'Dim CAH As Double = Double.Parse(PARAMETER.Search("CAH").Value)
        'Dim CAL As Double = Double.Parse(PARAMETER.Search("CAL").Value)
        'Dim CAdH As Double = Double.Parse(PARAMETER.Search("CAdH").Value)
        'Dim CAdL As Double = Double.Parse(PARAMETER.Search("CAdL").Value)

        'BM_BUF_C.AlamH = (CAdH - CAL) / (CAH - CAL) * 100
        'BM_BUF_C.AlamL = (CAdL - CAL) / (CAH - CAL) * 100
        'BM_BUF_C.Value = ETLTANK_BAO.BUF_TANK.TI_CONC_PERCENT
        'BM_BUF_LEVEL.AlamL = 0
        'BM_BUF_LEVEL.AlamH = 100
        'BM_BUF_LEVEL.Value = ETLTANK_BAO.BUF_TANK.LEVEL_PERCENT
        'BM_CIR_C.AlamH = (CAdH - CAL) / (CAH - CAL) * 100
        'BM_CIR_C.AlamL = (CAdL - CAL) / (CAH - CAL) * 100
        'BM_CIR_C.Value = ETLTANK_BAO.CIR_TANK.TI_CONC_PERCENT
        'BM_CIR_LEVEL.AlamL = 0
        'BM_CIR_LEVEL.AlamH = 100
        'BM_CIR_LEVEL.Value = ETLTANK_BAO.CIR_TANK.LEVEL_PERCENT
        '↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub PB_PC3_Click(sender As Object, e As EventArgs)

    End Sub
End Class
