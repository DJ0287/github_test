Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
'ETL_SRS共通モジュール
Public Module CONDITION
    '    Public Function BGColor(cond As Boolean) As Color
    '        If cond Then
    '            BGColor = Color.Red
    '        Else
    '            BGColor = Color.Green
    '        End If
    '    End Function
    Public Sub SetGenericLamp(ctl As Control, cond As Boolean, OnStr As String, OnForeColor As Color, OnBackColor As Color, OffStr As String, OffForeColor As Color, OffBackColor As Color)
        If cond Then
            ctl.Text = OnStr
            ctl.ForeColor = OnForeColor
            ctl.BackColor = OnBackColor
        Else
            ctl.Text = OffStr
            ctl.ForeColor = OffForeColor
            ctl.BackColor = OffBackColor
        End If
    End Sub
    Public Sub SetInterlock(ctl As Control, cond As Boolean)
        If cond Then
            ctl.BackColor = Color.Green
        Else
            ctl.BackColor = Color.Black
        End If
    End Sub
    Public Sub SetPipeGroupCondition(ls As List(Of Object), group As String, cond As Boolean)

        Dim l = From item In ls
                Where item.Name.IndexOf("_" & group & "_") >= 0
                Select item
        For Each item In l
            Dim t = item.GetType()
            If t = GetType(Microsoft.VisualBasic.PowerPacks.LineShape) Then
                If cond Then
                    item.BorderColor = Color.Red
                Else
                    item.BorderColor = Color.FromArgb(0, 255, 0)
                End If
            ElseIf t = GetType(PictureBox) Then
                Dim hantei = Right(item.Name, 2)
                If cond Then
                    If String.Compare(hantei, "_U") = 0 Then
                        item.Image = My.Resources.arrow_up_red
                    ElseIf String.Compare(hantei, "_R") = 0 Then
                        item.Image = My.Resources.arrow_right_red
                    ElseIf String.Compare(hantei, "_D") = 0 Then
                        item.Image = My.Resources.arrow_down_red
                    ElseIf String.Compare(hantei, "_L") = 0 Then
                        item.Image = My.Resources.arrow_left_red
                    End If

                Else
                    If String.Compare(hantei, "_U") = 0 Then
                        item.Image = My.Resources.arrow_up_green
                    ElseIf String.Compare(hantei, "_R") = 0 Then
                        item.Image = My.Resources.arrow_right_green
                    ElseIf String.Compare(hantei, "_D") = 0 Then
                        item.Image = My.Resources.arrow_down_green
                    ElseIf String.Compare(hantei, "_L") = 0 Then
                        item.Image = My.Resources.arrow_left_green
                    End If

                End If
            End If
        Next

    End Sub

    Public Sub SetLineText(ctl As Control, cond As LineConditionType, Optional text As String = Nothing)
        If Not (text Is Nothing) Then
            ctl.Text = text
        Else
            ctl.Text = ""
        End If
        Select Case cond
            'Case LineConditionType.ETL運転中
            '    ctl.BackColor = Color.Red
            '    ctl.Text = ctl.Text & "運転中"
            'Case LineConditionType.ETL停止中
            '    ctl.BackColor = Color.FromArgb(0, 255, 0)
            '    ctl.Text = ctl.Text & "停止中"
            'Case LineConditionType.調整材
            '    ctl.BackColor = Color.Yellow
            '    ctl.Text = ctl.Text & "調整材"

            Case LineConditionType.ETL運転中
                ctl.BackColor = Color.Green
                ctl.Text = ctl.Text & "Running"
            Case LineConditionType.ETL停止中
                ctl.BackColor = Color.Red
                ctl.Text = ctl.Text & "Stop"
            Case LineConditionType.調整材
                ctl.BackColor = Color.Orange
                ctl.Text = ctl.Text & "Dummy"
        End Select
    End Sub

    Public Sub SetCASModeText(ctl As Control, cond As CasModeType, Optional text As String = Nothing)
        If Not (text Is Nothing) Then
            ctl.Text = text
        Else
            ctl.Text = ""
        End If
        Select Case cond
            Case CasModeType.CAS
                ctl.BackColor = Color.Red
            Case Else
                ctl.BackColor = Color.FromArgb(0, 255, 0)
        End Select
        ctl.Text = ctl.Text & [Enum].GetName(cond.GetType(), cond)
    End Sub
    Public Sub SetCASModeColor(ctl_cas As Control, ctl_notcas As Control, cond As Boolean)
        If cond Then
            ctl_cas.BackColor = Color.Lime
            ctl_notcas.BackColor = Color.Gray
        Else
            ctl_cas.BackColor = Color.Gray
            ctl_notcas.BackColor = Color.Lime
        End If
    End Sub
    Public Sub SetRunText(ctl As Control, cond As Boolean, Optional text As String = Nothing)
        If Not (text Is Nothing) Then
            ctl.Text = text
        End If
        If cond Then
            ctl.Text = "ON"
            ctl.BackColor = Color.Red
        Else
            ctl.Text = "OFF"
            ctl.BackColor = Color.FromArgb(0, 255, 0)
        End If
    End Sub

    Public Function PumpImage(cond As Boolean) As Image
        If cond Then
            PumpImage = My.Resources.pump_green
        Else
            PumpImage = My.Resources.pump_red
        End If
        '        My.Resources.ResourceManager()
    End Function
    Public Function SVImage(cond As Boolean) As Image
        If cond Then
            SVImage = My.Resources.sv_green
        Else
            SVImage = My.Resources.sv_red
        End If
        '        My.Resources.ResourceManager()
    End Function
    Public Function CVImage(cond As Boolean) As Image
        If cond Then
            CVImage = My.Resources.cv_green
        Else
            CVImage = My.Resources.cv_red
        End If
        '        My.Resources.ResourceManager()
    End Function
    Public Function CVRotImage(cond As Boolean) As Image
        If cond Then
            CVRotImage = My.Resources.cv_red_Rot
        Else
            CVRotImage = My.Resources.cv_green_Rot
        End If
        '        My.Resources.ResourceManager()
    End Function

    Public Class LINESPEED
        Private Shared treshold As TimeSpan
        Private Shared state_init(1) As Boolean
        Private Shared state_condition(1) As Boolean
        Private Shared state_time(1) As DateTime
        Private Shared countdowntimer(1) As TimeSpan

        Public Shared Function Display(check As Boolean, scantime As TimeSpan) As Boolean
            'Dim check As Boolean
            '        If eno = 0 Then
            '             check = RECVDATA.BIT_PLC_SRS_CTR.No3ETL運転中
            '          Else
            '               check = RECVDATA.BIT_PLC_SRS_CTR.No4ETL運転中
            '
            '            End If
            Dim eno = 0
            If check Then
                state_condition(eno) = True
                countdowntimer(eno) = TimeSpan.FromSeconds(30)
            Else
                countdowntimer(eno) = countdowntimer(eno) - scantime
                If countdowntimer(eno).TotalSeconds() < 0 Then
                    state_condition(eno) = False
                    countdowntimer(eno) = TimeSpan.Zero
                End If
            End If
            Display = state_condition(eno)
        End Function

        Public Shared Function Check(eno, ライン速度) As Boolean
            'If DEBUG.Flag Then
            '    If eno = 0 Then

            '        Check = (DEBUG.No3ETL And DEBUG.No3ETLCS <> CheckState.Indeterminate) Or (RECVDATA.BIT_PLC_SRS_CTR.No3ETL運転中 And DEBUG.No3ETLCS = CheckState.Indeterminate)
            '    Else
            '        Check = (DEBUG.No4ETL And DEBUG.No4ETLCS <> CheckState.Indeterminate) Or (RECVDATA.BIT_PLC_SRS_CTR.No4ETL運転中 And DEBUG.No4ETLCS = CheckState.Indeterminate)
            '    End If
            'Else
            '    If eno = 0 Then
            '        Check = RECVDATA.BIT_PLC_SRS_CTR.No3ETL運転中
            '    Else
            '        Check = RECVDATA.BIT_PLC_SRS_CTR.No4ETL運転中
            '    End If
            'End If
            Check = RECVDATA.WORD_PLC_SRS_D6000.LINESPEED.ToDouble() >= 50

            Exit Function
            'Dim nowstate As Boolean = ライン速度(eno) >= 50

            ''If nowstate <> state_condition(eno) Then
            'If (DateTime.Now - state_time(eno)) >= treshold Then
            '    Check = nowstate
            '    state_time(eno) = DateTime.Now
            '    state_init(eno) = nowstate
            '    state_condition(eno) = nowstate
            '    Exit Function
            'Else
            '    If nowstate <> state_condition(eno) Then
            '        Check = state_condition(eno)
            '        state_time(eno) = DateTime.Now
            '        state_condition(eno) = nowstate
            '        Exit Function
            '    End If
            'End If
            'Check = state_init(eno)
        End Function
        Public Shared Sub Initialize(ライン速度, 閾値)
            state_time(0) = DateTime.Now
            state_init(0) = ライン速度 >= 50
            state_time(1) = state_time(0)
            state_init(1) = state_init(0)
            treshold = TimeSpan.FromMinutes(閾値)
        End Sub
    End Class
    Public Function CASモード判定() As Boolean
        '        CASモード判定 =
        '            (RECVDATA.WORD_PLC_SRS_IND.FCV2_CAS.Word = CasModeType.CAS Or RECVDATA.BIT_PLC_SRS_CTR.No3ETL運転中 = False Or RECVDATA.BIT_PLC_SRS_IND.No3_調整材) And
        '            (RECVDATA.WORD_PLC_SRS_IND.FCV4_CAS.Word = CasModeType.CAS Or RECVDATA.BIT_PLC_SRS_CTR.No4ETL運転中 = False Or RECVDATA.BIT_PLC_SRS_IND.No4_調整材) And
        '        RECVDATA.WORD_PLC_SRS_IND.FCV7_CAS.Word = CasModeType.CAS And
        '        RECVDATA.WORD_PLC_SRS_IND.FCV8_CAS.Word = CasModeType.CAS And
        '        RECVDATA.WORD_PLC_SRS_IND.FCV10_CAS.Word = CasModeType.CAS
        CASモード判定 = RECVDATA.BIT_PLC_SRS_M9000.FIC311_CAS
    End Function

    Public Function インターロック判定() As Boolean
        '        インターロック判定 = PLCIO.tcp.Connected And
        '            (RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 Or RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Count > 0) And
        '        RECVDATA.BIT_PLC_SRS_IND.SRS_計測器異常 And
        '        RECVDATA.BIT_PLC_SRS_CTR.SRS_運転指令 And CASモード判定() And Not ゼロ割エラー判定()
        インターロック判定 = L1INFO.Connection = 0 And
                            RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 And
                             CASモード判定() And Not ゼロ割エラー判定()

    End Function

    Public Sub SetPasswordLock(ctl As Control, cond As Boolean)
        If cond Then
            'ctl.Text = "禁止中"
            ctl.Text = "Lock"
            ctl.BackColor = Color.Red
        Else
            'ctl.Text = "許可中"
            ctl.Text = "Unlock"
            ctl.BackColor = Color.FromArgb(0, 255, 0)
        End If
    End Sub
    Public Function ゼロ割エラー判定() As Boolean
        ゼロ割エラー判定 = True
        For I = 0 To 1
            For Each prod In RECVDATA.WORD_PLC_SRS_SCHS(I).Products
                ゼロ割エラー判定 = ゼロ割エラー判定 And prod.TPH.Word > 0 And prod.Weight.Word > 0 And
                            prod.Width.Word > 0 And prod.Thickness.Word > 0 And prod.Coating.Word > 0
                If ゼロ割エラー判定 = False Then
                    'Stop
                End If
            Next
        Next
        ゼロ割エラー判定 = Not ゼロ割エラー判定
    End Function
    Public Sub CheckAlams()
        '        No.Item    CONDITION	Object	Heavy	Light
        '1   Level1 Ethernet communication error	Level1 Ethernet communication error Is happened	L1	○	
        '2   Flow rate from Tin replenishing to Cir. Tank error(FT315)	The data is not in allowance (between upper limit and lower limit)	L1	○	
        '3   O2 flow rate for Tin replenishing error(FT311)	The data is not in allowance(between upper limit and lower limit)	L1	○	
        '4   DP for Tin replenishing error(PT313)	The data is not in allowance(between upper limit and lower limit)	L1	○	
        '5   Level for settling tank error(LT321)	The data is not in allowance(between upper limit and lower limit)	L1		○
        '6   Level for Cir. tank error(LT302)	The data is not in allowance(between upper limit and lower limit)	L1	○	
        '7   Concentration of Cir. tank error(Tin Ion Analyzer)	The data is not in allowance(between upper limit and lower limit)	L1	○	
        '8   Concentration of Cir. tank L(Tin Ion Analyzer)	Cons. Less than 20g/L	L1		○
        '9   Sn dissolution compensation ΔS1x excess	Correction Is more than 100kg/hr	PC		○
        '10  Feed pump for Tin replenishing stop(PC-3-A&B)	Pump stop	L1		○
        '11  Cir. pump for Tin replenishing stop(PC-2-A&B)	Pump stop	L1		○
        '12  Calculation error	When the divisor becomes 0 in division	PC	○	
        '13  On-Off Valve for O2 Close(XV311)	When O2 valve (XV311) Is closed	L1	○	
        '14  Production schedule Nothing	Production schedule nothing	L1	○	
        '15  Current for Plating error	The data is not in allowance(between upper limit and lower limit)	L1	○	
        '16  Production schedule Data error	The data is not in allowance(between upper limit and lower limit)	PC	○	
        '17  Field Data error	The data is not in allowance(between upper limit and lower limit)	L1	○	
        'COM_L2_ERROR = 1
        'FT315_FLR_CIR_ERROR = 2
        'FT311_FLR_REP_ERROR = 3
        'PT313_DP_REP_ERROR = 4
        'LT321_SET_TANK_ERROR = 5
        'LT302_CIR_TANK_ERROR = 6
        'TIA_CIR_TANK_ERROR = 7
        'TIA_CIR_TANKL_ERROR = 8
        'DS1X_TOO_LARGE = 9
        'PC3AB_STOP = 10
        'PC2AB_STOP = 11
        'CALC_ERROR = 12
        'XV311_IS_CLOSED = 13
        'SCHEDULE_NOTHING = 14
        'CURRENT_ERROR = 15
        'SCHEDULE_ERROR = 16
        'FIELD_ERROR = 17
        Dim CAH As Double = Double.Parse(PARAMETER.Search("CAH").Value)
        Dim CAL As Double = Double.Parse(PARAMETER.Search("CAL").Value)

        ALAM.Trigger(ALAM.ALAMNO.FT315_FLR_CIR_ERROR, Not RECVDATA.WORD_PLC_SRS_D5000.FI315_PV.CheckRange)
        ALAM.Trigger(ALAM.ALAMNO.FT311_FLR_REP_ERROR, Not RECVDATA.WORD_PLC_SRS_D5000.FIC311_O2_PV.CheckRange)
        ALAM.Trigger(ALAM.ALAMNO.PT313_DP_REP_ERROR, Not RECVDATA.WORD_PLC_SRS_D5000.PI313_DP_PV.CheckRange)
        ALAM.Trigger(ALAM.ALAMNO.LT321_SET_TANK_ERROR, Not RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.CheckRange)
        ALAM.Trigger(ALAM.ALAMNO.LT302_CIR_TANK_ERROR, Not RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.CheckRange)
        ALAM.Trigger(ALAM.ALAMNO.TIA_CIR_TANK_ERROR, ETLTANK_BAO.CIR_TANK.TI_CONC < CAL Or ETLTANK_BAO.CIR_TANK.TI_CONC > CAH)
        ALAM.Trigger(ALAM.ALAMNO.TIA_CIR_TANKL_ERROR, ETLTANK_BAO.CIR_TANK.TI_CONC < 20)
        ALAM.Trigger(ALAM.ALAMNO.DS1X_TOO_LARGE, DISCOMBSCH.dS1x > 100)
        ALAM.Trigger(ALAM.ALAMNO.PC3AB_STOP, Not RECVDATA.BIT_PLC_SRS_M8000.P3)
        ALAM.Trigger(ALAM.ALAMNO.PC2AB_STOP, Not RECVDATA.BIT_PLC_SRS_M8000.P2)
        ALAM.Trigger(ALAM.ALAMNO.XV311_IS_CLOSED, Not RECVDATA.BIT_PLC_SRS_M8000.XV311)
        ALAM.Trigger(ALAM.ALAMNO.SCHEDULE_NOTHING, RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count = 0)
        ALAM.Trigger(ALAM.ALAMNO.CURRENT_ERROR, Not (RECVDATA.WORD_PLC_SRS_D5000.CURRENT_TOTAL_BACK.CheckRange And RECVDATA.WORD_PLC_SRS_D5000.CURRENT_TOTAL_FRONT.CheckRange))
        Dim prerr As Boolean = True
        For I = 0 To 1
            For Each prod In RECVDATA.WORD_PLC_SRS_SCHS(I).Products
                prerr = prerr And prod.TPH.CheckRange() And prod.Weight.CheckRange() And
                            prod.Width.CheckRange() And prod.Thickness.CheckRange() And prod.Coating.CheckRange()
                If prerr = False Then
                    'Stop
                End If
            Next
        Next
        ALAM.Trigger(ALAM.ALAMNO.SCHEDULE_ERROR, Not prerr)
        Try
            Dim flderr As Boolean = False
            Dim o As Type = GetType(RECVDATA.WORD_PLC_SRS_D5000)

            'メンバを取得する
            Dim members As MemberInfo() = o.GetMembers(
            BindingFlags.Public Or BindingFlags.Static Or
            BindingFlags.DeclaredOnly)

            Dim m As MemberInfo
            For Each m In members
                'メンバの型と、名前を表示する
                '           Console.WriteLine("{0} - {1}", m.MemberType, m.Name)
                If m.MemberType = MemberTypes.Field Then

                    Dim field = o.InvokeMember(m.Name, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, o, Nothing)
                    If field.GetType().Name = "UnitWord" Then
                        Dim uw As UnitWord = field
                        If Not uw.CheckRange() Then
                            Dim istop = 1
                        End If
                        flderr = flderr Or (Not uw.CheckRange())
                    End If
                End If
            Next
            ALAM.Trigger(ALAM.ALAMNO.FIELD_ERROR, flderr)
        Catch ex As Exception

        End Try

    End Sub
#If YATAHA Then
    Public Sub CheckAlams_YAHATA()
        'Ethernet通信異常以外のアラームを検出してアラームNoを返す
        '重複の場合、アラームNoが大きなものが優先

        '        No.	項目	条件	相手	重故障	軽故障	備考
        '1	Ethernet通信異常	Open異常検出、受信ﾃﾞｰﾀ長異常	PLC		○	
        '2	計測器異常	Local測定器測定不具合を検出（断線）	PLC	○		詳細はｲﾝﾀｰﾌｪｰｽﾘｽﾄ参照。
        '3	ﾙｰﾌﾟ制御/　CASﾓｰﾄﾞ選択でない	Local　ループ制御がCASﾓｰﾄﾞでないことを検出	PLC		○	
        '4	3ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度PV値異常	濃度10～60（g/L)範囲外の値を検出	PLC	○		
        '5	4ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度PV値異常	濃度10～60（g/L)範囲外の値を検出	PLC	○		
        '6	ｽﾄﾚｰｼﾞAﾀﾝｸ錫ｲｵﾝ濃度PV値異常	濃度10～60（g/L)範囲外の値を検出	PLC	○		
        '7	3ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度低下	濃度C3b（g/L)以下	PLC		○	
        '8	4ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度低下	濃度C4b（g/L)以下	PLC		○	
        '9	ｽﾄﾚｰｼﾞAﾀﾝｸ錫ｲｵﾝ濃度低下	濃度CAL（g/L)以下	PLC		○	
        '10	3ETL　錫溶解補正量ΔS1x過大	溶解量100kg/hrを超える補正量となる	PLC		○	
        '11	4ETL　錫溶解補正量ΔS1x過大	溶解量100kg/hrを超える補正量となる	PLC		○	
        '12	St.B～溶解槽供給ﾎﾟﾝﾌﾟ停止	P-1ﾎﾟﾝﾌﾟ停止	PLC		○	
        '13	溶解槽自己循環ﾎﾟﾝﾌﾟ停止	P-2ﾎﾟﾝﾌﾟ停止	PLC		○	
        '14	ﾒｯｷ液供給ﾎﾟﾝﾌﾟ停止	P-7ﾎﾟﾝﾌﾟ停止	PLC		○	
        '15	3ETLﾒｯｷ液返送ﾎﾟﾝﾌﾟ停止	P-12ﾎﾟﾝﾌﾟ停止	PLC		○	
        '16	4ETLﾒｯｷ液返送ﾎﾟﾝﾌﾟ停止	P-8ﾎﾟﾝﾌﾟ停止	PLC		○	
        '17	演算異常	除算において除数が「０」となった場合	PLC	○		
        '18	生産ｽｹｼﾞｭｰﾙﾃﾞｰﾀ異常	生産ｽｹｼﾞｭｰﾙﾃﾞｰﾀが指定範囲外の場合	PLC		○	
        '19	スラッジ低減運転指令 なし	計装PLCからの運転指令がOFFになった場合	PLC		○	
        ALAM.Trigger(ALAM.ALAMNO.MESURING_ERROR, RECVDATA.BIT_PLC_SRS_IND.SRS_計測器異常 = False) 'Alam No2 Check
        ALAM.Trigger(ALAM.ALAMNO.CASMODE_ERROR, Not CASモード判定()) 'Alam No3 Check
        ALAM.Trigger(ALAM.ALAMNO.NO3ETL_TINION_COND_ERROR, Not RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.CheckRange())
        ALAM.Trigger(ALAM.ALAMNO.NO4ETL_TINION_COND_ERROR, Not RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.CheckRange())
        ALAM.Trigger(ALAM.ALAMNO.STA_TINION_COND_ERROR, Not RECVDATA.WORD_PLC_SRS_CTR.StA_AVE.CheckRange())
        'ALAM.Trigger(ALAM.ALAMNO.NO3ETL_TINION_COND_LEVEL, RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.ToDouble < PARAMETER.Search("COB3").設定値 - PARAMETER.Search("C3OL").設定値)
        'ALAM.Trigger(ALAM.ALAMNO.NO4ETL_TINION_COND_LEVEL, RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.ToDouble < PARAMETER.Search("COB4").設定値 - PARAMETER.Search("C4OL").設定値)
        'ALAM.Trigger(ALAM.ALAMNO.STA_TINION_COND_LEVEL, RECVDATA.WORD_PLC_SRS_CTR.StA_AVE.ToDouble < PARAMETER.Search("CAREF").設定値 - PARAMETER.Search("CAL_").設定値)
        ALAM.Trigger(ALAM.ALAMNO.NO3ETL_DS1X_TOO_LARGE, ETLPRODSCHS(0).dS1x > 100)
        ALAM.Trigger(ALAM.ALAMNO.NO4ETL_DS1X_TOO_LARGE, ETLPRODSCHS(1).dS1x > 100)
        ALAM.Trigger(ALAM.ALAMNO.P1_PUMP_STOP, Not RECVDATA.BIT_PLC_SRS_IND.P1)
        ALAM.Trigger(ALAM.ALAMNO.P2_PUMP_STOP, Not RECVDATA.BIT_PLC_SRS_IND.P2)
        ALAM.Trigger(ALAM.ALAMNO.P7_PUMP_STOP, Not RECVDATA.BIT_PLC_SRS_IND.P7)
        ALAM.Trigger(ALAM.ALAMNO.P12_PUMP_STOP, Not RECVDATA.BIT_PLC_SRS_IND.P12)
        ALAM.Trigger(ALAM.ALAMNO.P8_PUMP_STOP, Not RECVDATA.BIT_PLC_SRS_IND.P8)
        Dim prerr As Boolean = True
        For I = 0 To 1
            For Each prod In RECVDATA.WORD_PLC_SRS_SCHS(I).Products
                prerr = prerr And prod.No.CheckRange() And prod.TPH.CheckRange() And prod.Weight.CheckRange() And
                            prod.Width.CheckRange() And prod.Thickness.CheckRange() And prod.Coating.CheckRange()
                If prerr = False Then
                    'Stop
                End If
            Next
        Next
        ALAM.Trigger(ALAM.ALAMNO.SCHEDULE_ERROR, Not prerr)
        ALAM.Trigger(ALAM.ALAMNO.SRS_OFF, Not RECVDATA.BIT_PLC_SRS_CTR.SRS_運転指令)

    End Sub
#End If
End Module
