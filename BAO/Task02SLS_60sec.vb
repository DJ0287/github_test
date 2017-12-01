Imports System.IO
Imports System.Collections.Generic
Public Class Task02SLS_60sec
    Inherits Task00Base
    Implements Task00Interface
    Dim S0 As Double
    Dim V As Double
    Dim T_Delay As Integer
    Dim D_Counter As Integer
    Dim Vr As Double
    Dim Te As Double
    Dim samplingtimeSLS As Double
    Dim sim_time As DateTime
    Dim lastupdatetime As DateTime


    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim ecode As Long

        Dim e As New TaskEventArgs
        sim_time = DateTime.Now

        If firstrun Then
            '    firstrun = False
            lastupdatetime = sim_time
            '    initsensorless(SLS.TinIonValue)
        End If
        samplingtimeSLS = (sim_time - lastupdatetime).TotalSeconds()
        If samplingtimeSLS <= 0 Or samplingtimeSLS >= 100 Then
            samplingtimeSLS = 60
        End If
        If samplingtimeSLS >= 60 Or SLS.InputUpdate Then
            SLS.Tin_supply = TIN_SUPPLY_Calculation(RECVDATA.WORD_PLC_SRS_D6000.FIC1311_1_PV.ToDouble() + RECVDATA.WORD_PLC_SRS_D6000.FIC1311_2_PV.ToDouble())
            SLS.Tin_consume = Tin_consume_Calculation(RECVDATA.WORD_PLC_SRS_D6000.TOP_Efficiency.ToDouble, RECVDATA.WORD_PLC_SRS_D6000.TOP_Plating_Current.ToDouble,
                    RECVDATA.WORD_PLC_SRS_D6000.BOT_Efficiency.ToDouble, RECVDATA.WORD_PLC_SRS_D6000.BOTPlating_Current.ToDouble(),
                    RECVDATA.WORD_PLC_SRS_D6000.BASE_CURRENT.ToDouble)

            'Call TIN_SUPPLY_Calculation(MEASUREMENTSDATA.FIC_1311_PV)
            'Call TIN_SUPPLY_Calculation(100)

            'Call Tin_consume_Calculation(MEASUREMENTSDATA.TOP_EFFICIENCY, MEASUREMENTSDATA.TOP_PLATE_CURRENT, MEASUREMENTSDATA.BOT_EFFICIENCY, MEASUREMENTSDATA.BOT_PLATE_CURRENT, MEASUREMENTSDATA.BASE_CURRENT)
            Call calcsensorless(sim_time, SLS.TinIonInputTime, SLS.TinIonValue, SLS.Tin_supply, SLS.Tin_consume)
            lastupdatetime = sim_time
            SLS.InputUpdate = False
        End If

        Run = e

        Notify(e)
    End Function
    Function Tin_consume_Calculation(TOP_E As Double, TOP_CUR As Double, BOT_E As Double, BOT_CUR As Double, BASE_cur As Double) As Double
        Tin_consume_Calculation = (TOP_E * TOP_CUR + BOT_E * BOT_CUR + BASE_cur / 1000) * 36.9 / 1000 * 60
    End Function

    Function TIN_SUPPLY_Calculation(O2 As Double) As Double
        Dim e As Double = 0.0049
        Dim Fa As Double = 0.75
        Dim W As Double = 9500
        Dim a As Double = 2401
        Dim K As Double = 10.59
        Dim u As Double
        Dim Tin_supply_pre As Double

        If O2 > 1 Then
            Tin_supply_pre = (O2 / 1000 + e * Fa) / (Fa + 4.1 * W / 1000) * (a * K - 60 * K * Fa)
        Else
            Tin_supply_pre = 0
        End If
        '        u = ((PARA.A2 - PARA.A1) * O2 / 1000.0!) + PARA.A1
        'O2μテーブルサーチ
        Dim muIdxFrom = Fix(O2 / 0.2)
        Dim muIdxTo = muIdxFrom + 1
        Dim mu As Double = 1
        If muIdxTo > 10 Then
            muIdxTo = 10
            mu = PARAMETER.Search("mu" & (muIdxTo + 1)).設定値
        ElseIf muIdxFrom < 0 Then
            muIdxFrom = 0
            mu = PARAMETER.Search("mu" & (muIdxFrom + 1)).設定値
        Else
            Dim mu1 = PARAMETER.Search("mu" & (muIdxFrom + 1)).設定値
            Dim mu2 = PARAMETER.Search("mu" & (muIdxTo + 1)).設定値
            mu = mu1 + (mu2 - mu1) * (O2 / 1000 - muIdxFrom * 0.2) / ((muIdxTo - muIdxFrom) * 0.2)
        End If

        TIN_SUPPLY_Calculation = mu * Tin_supply_pre
subend1:


    End Function

    Public Sub initsensorless(ByVal s0in As Double, Optional ByVal SSD0 As Double = 0)
        'Dim n As Integer
        Dim I As Integer

        S0 = s0in
        '        INPTALPHA = 1.0
        '        alpha = INPTALPHA

        'V = 100
        'Tc = 30
        'Tp = 160
        'Te = 1
        For I = 1 To SLS.NUMSAMPLES
            SLS.SampDateTime(I) = DateTime.MinValue
            SLS.SnT(I) = 27.0
            SLS.SpT(I) = 5
            SLS.ScT(I) = 5
            SLS.VT(I) = 10.0
        Next
        For I = 1 To SLS.LOGMINUTES
            SLS.DateTime_r(I) = DateTime.MinValue
            SLS.SnD_r(I) = 0.0
            SLS.SpD_r(I) = 0
            SLS.ScD_r(I) = 0
            SLS.Sn_r(I) = 0.0
        Next
        SLS.DateTime_r(1) = DateTime.Now

        'SnD = S0

        SLS.Sn_new_data = S0

        T_Delay = 1
        D_Counter = SLS.SLSrefleshimer_preset - 9
        Vr = 0.001
        'For n = 1 To 60
        '   Sn_r(n) = S0
        'Next

        SLS.SSD = SSD0
        SLS.lSpcD = 0
        SLS.V_den = 0
        SLS.V_num = 0
        SLS.count = 0

        SLS.Sn_modi = 0
        SLS.V_psa = 0
        SLS.V_demi = 0
        SLS.V_add = 0
        SLS.V_before = 0

        SLS.V_const = SLS.V

        SLS.SpDp = 0
        SLS.ScDp = 0
        SLS.Sp = 0
        SLS.Sc = 0
        'modified 20140207//////////////////////////////////////////////////////////////
        'samplingtimeSLS = 0

        'modified 20140207//////////////////////////////////////////////////////////////
        'システム起動時に最後の計算結果で初期化する
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\sls_InitialData3.csv") = True Then
            Dim parser As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(My.Application.Info.DirectoryPath & "\sls_InitialData3.csv")
            'parser.ReadLine()
            parser.SetDelimiters(",")
            Dim fields As String()
            fields = parser.ReadFields()
            If (Date.Now - CDate(fields(0))) > TimeSpan.FromHours(1) Then
                GoTo SKIPDATA1
            End If
            'Modified 2014/2/7////////////////////////////////////////////////////////
            'For I = 1 To NUMSAMPLES
            'fields = parser.ReadFields()
            ' SampDateTime(I) = CDate(fields(0))
            ' SnT(I) = CDbl(fields(1))
            ' SpT(I) = CDbl(fields(2))
            '  ScT(I) = CDbl(fields(3))
            ' VT(I) = CDbl(fields(4))
            ' Next
            'Modified 2014/2/7////////////////////////////////////////////////////////
            For I = 1 To SLS.LOGMINUTES
                fields = parser.ReadFields()
                SLS.DateTime_r(I) = CDate(fields(0))
                SLS.SnD_r(I) = CDbl(fields(1))
                SLS.SpD_r(I) = CDbl(fields(2))
                SLS.ScD_r(I) = CDbl(fields(3))
                SLS.Sn_r(I) = CDbl(fields(4))
            Next

SKIPDATA1:
            parser.Close()


        End If

        'Modified 2014/2/7////////////////////////////////////////////////////////
        'システム起動時に最後の計算結果で初期化する
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\sls_InitialData4.csv") = True Then
            Dim parser1 As FileIO.TextFieldParser = My.Computer.FileSystem.OpenTextFieldParser(My.Application.Info.DirectoryPath & "\sls_InitialData4.csv")
            'parser.ReadLine()
            parser1.SetDelimiters(",")
            Dim fields1 As String()
            fields1 = parser1.ReadFields()
            For I = 1 To SLS.NUMSAMPLES
                fields1 = parser1.ReadFields()
                SLS.SampDateTime(I) = CDate(fields1(0))
                SLS.SnT(I) = CDbl(fields1(1))
                SLS.SpT(I) = CDbl(fields1(2))
                SLS.ScT(I) = CDbl(fields1(3))
                SLS.VT(I) = CDbl(fields1(4))
            Next
SKIPDATA2:
            parser1.Close()

        End If

        SLS.SnD = SLS.TinIonValue
        'Modified 2014/2/7///////////////////////////////////////////////////////

        'Modified 20140228///////////////////////////////////////////////////////
        SLS.SLSrefleshimer = SLS.SLSrefleshimer_preset


        'Modified 20140228///////////////////////////////////////////////////////


    End Sub
    'SENSORLESS CALCULATION
    Public Sub calcsensorless(ByVal tday As DateTime, ByVal sampletime As DateTime, ByVal new_data As Double, ByVal Spkgh As Double, ByVal Sckgh As Double)
        Dim ii As Integer
        Dim defaultListener As New DefaultTraceListener
        Dim dataInputFlag As Boolean = False
        Dim I As Integer
        Dim eventlog As Boolean
        'Dim  xx As Integer   ' 時刻sampletimeでの手分析結果を参照する配列の要素番号
        '        Dim SpD As Double
        '        Dim ScD As Double
        '        Dim Sp As Double = 0
        '        Dim Sc As Double = 0
        'Dim tmin As Double
        'Modified 20140127///////////////////////////////////////////////////////

        'Dim tday As Date = DateTime.Now
        '手分析結果の妥当性確認（A1)////////////////////////////////////
        '‘入力値が１５ｇL～３５ｇLのとき、分析値が妥当であると判断する
        'Modifed 2014/0402/////////////////////////////////////////////////
        ' If 15 < new_data And new_data < 35 Then
        'V_comp = Sn_new_data - new_data
        ' Else
        ' V_comp = 0
        ' End If
        eventlog = SLS.SpT(1) <> SLS.Sp Or SLS.ScT(1) <> SLS.Sc Or SLS.V_comp <> 0
        'Modifed 2014/0402/////////////////////////////////////////////////

        'Modifed 2014/02/14/////////////////////////////////////////////////
        For I = SLS.LOGMINUTES To 2 Step -1
            SLS.DateTime_r(I) = SLS.DateTime_r(I - 1)
            SLS.SnD_r(I) = SLS.SnD_r(I - 1)
            SLS.SpD_r(I) = SLS.SpD_r(I - 1)
            SLS.ScD_r(I) = SLS.ScD_r(I - 1)
            SLS.Sn_r(I) = SLS.Sn_r(I - 1)
        Next
        'Modifed 2014/02/14/////////////////////////////////////////////////
        'Sp_r(NUMMINUTES) = SpT
        'Sc_r(NUMMINUTES) = ScT
        '2014/1/23 Sp,Scは最新時刻の値
        'Sp = Sp_r(1) '- preSp
        'Sc = Sc_r(1) '- preSc
        'Sp = SpT
        'Sc = ScT

        '        VTIE08OP_AND_PC17AORBRUN = MEASUREMENTSDATA.VTIE_08_CLOSE_LS_ON * MEASUREMENTSDATA.PC_17_AB_RUN
        '        VTIB02OP_AND_VTIB07OP_PC2ARUN = MEASUREMENTSDATA.VTIB_02_CLOSE_LS_ON * MEASUREMENTSDATA.VTIB_07_CLOSE_LS_ON * MEASUREMENTSDATA.PC_2_A_RUN

        'preSp = SpT
        'preSc = ScT
        '        If BEING_SCHEDULE = 0 Then
        '生産スケジュールが無い場合は溶解量・消費量をクリア
        'SpD = 0
        'ScD = 0
        'End If
        'TEST


        'Modified 20140228///////////////////////////////////////////////////////
        If SLS.SLSrefleshimer < 0 And 15 < SLS.TinIonValue And SLS.TinIonValue < 35 Then
            SLS.SLSrefleshimer = SLS.SLSrefleshimer_preset
            SLS.V_comp = 2
            new_data = SLS.TinIonValue
        Else
            SLS.SLSrefleshimer = SLS.SLSrefleshimer - 1
            SLS.V_comp = 0
        End If

        'Modified 20140228///////////////////////////////////////////////////////

        If SLS.V_comp <> 0 Then
            'Sn_new_dataが更新された時の処理

            'If 15 < new_data And new_data < 35 Then
            If D_Counter < 1 Then
                SLS.Sn_new_data = new_data
                D_Counter = T_Delay
                If Spkgh > 10 Or Sckgh > 10 Then
                    dataInputFlag = True

                    '過去データの削除
                    For I = SLS.NUMSAMPLES To 2 Step -1
                        SLS.SampDateTime(I) = SLS.SampDateTime(I - 1)
                        SLS.SnT(I) = SLS.SnT(I - 1)
                        SLS.SpT(I) = SLS.SpT(I - 1)
                        SLS.ScT(I) = SLS.ScT(I - 1)
                        SLS.VT(I) = SLS.VT(I - 1)
                    Next

                    'sampletime時のインデックスxx
                    'Modifed 2014/4/03//////////////////////////////////////////
                    ' For I = 2 To LOGMINUTES
                    'If sampletime < SLS.DateTime_r(I) Then
                    'If sampletime < SLS.DateTime_r(I) Then
                    'Exit For
                    ' End If
                    ' Next
                    ' xx = I - 1
                    ' For ii = 1 To xx - 1
                    'SpD_r(ii) = SpD_r(ii) - SpD_r(xx)
                    ' ScD_r(ii) = ScD_r(ii) - ScD_r(xx)
                    '  SnD_r(ii) = SnD_r(ii) + Sn_new_data - SnD_r(xx)
                    'Next
                    SLS.SampDateTime(1) = tday
                    SLS.SnT(1) = SLS.Sn_new_data
                    SLS.SpT(1) = SLS.SpD_r(1)
                    SLS.ScT(1) = SLS.ScD_r(1)
                    SLS.VT(1) = SLS.V

                    SLS.SpD_r(2) = 0
                    SLS.ScD_r(2) = 0
                    'Modifed 2014/4/03//////////////////////////////////////////
                    'Modified 2014/02/14 /////////////////////////////////////////////////////////
                    SLS.SnD = SLS.SnT(1)
                    'Modified 2014/02/14 /////////////////////////////////////////////////////////

                    '2014/1/23 SSDは前回インプットからのSp'-Sc'積算量
                    SLS.V_den = 0
                    SLS.V_num = 0
                    '係数αの算出
                    Dim datacount As Integer = 0
                    For ii = 1 To SLS.NUMSAMPLES
                        If SLS.SnT(ii) <> 0 Then
                            datacount = datacount + 1
                        End If
                    Next
                    If datacount = SLS.NUMSAMPLES Then
                        For ii = 1 To SLS.NUMSAMPLES - 1
                            SLS.V_num = SLS.V_num + (SLS.SnT(ii) - SLS.SnT(ii + 1) + SLS.ScT(ii) / SLS.VT(ii)) * SLS.SpT(ii) / SLS.VT(ii)
                            SLS.V_den = SLS.V_den + SLS.SpT(ii) ^ 2 / SLS.VT(ii)
                        Next
                        If SLS.V_den < Vr Then
                            SLS.V_den = Vr
                        End If
                        'SLS.alpha = SLS.INPTALPHA
                        ' alpha = alpha * 0.8 + (V_num / V_den) * 0.2
                    End If
                End If
            End If
            SLS.V_comp = 0
            '        End If
        End If

        'Sn_new_dataが更新されなかった時の処理
        'またはSn_new_dataが更新された後に戻る処理
        '        V = MEASUREMENTSDATA.LIA_1302_PV + MEASUREMENTSDATA.LIA_1340_PV + V_const
        V = SLS.V + RECVDATA.WORD_PLC_SRS_D6000.LIA1302_PV.ToDouble() + RECVDATA.WORD_PLC_SRS_D6000.LIA1340_PV.ToDouble()

        'Modified 2014/2/14/////////////////////////////////////////////////////////////////
        'If MEASUREMENTSDATA.XV_1305_1_OPEN Or MEASUREMENTSDATA.XV_1305_2_OPEN Then
        'If RECVDATA Or MEASUREMENTSDATA.XV_1305_2_OPEN Then
        '    V_before = V
        '    V_psa = 0
        '    V_demi = 0
        '    V_psa = V_psa + MEASUREMENTSDATA.FQS_1305_2_PV / 60 * samplingtimeSLS / 1000
        '    V_demi = V_demi + MEASUREMENTSDATA.FQS_1305_1_PV / 60 * samplingtimeSLS / 1000
        '    V_add = V_psa + V_demi
        '    SnD = SnD * V_before / (V_before + V_add)
        'End If
        SLS.V_before = V
        SLS.V_demi = 0
        SLS.V_psa = 0

        SLS.V_demi = SLS.V_demi + (-1 * RECVDATA.BIT_PLC_SRS_M9000.XV1305_1) * RECVDATA.WORD_PLC_SRS_D6000.FI1305_1_PV.ToDouble() / 1000 ' L/min⇒m3/min
        SLS.V_psa = SLS.V_psa + (-1 * RECVDATA.BIT_PLC_SRS_M9000.XV1305_2) * RECVDATA.WORD_PLC_SRS_D6000.FI1305_2_PV.ToDouble() 'm3/min
        SLS.V_psa = SLS.V_psa + (-1 * RECVDATA.BIT_PLC_SRS_M9000.XV1309) * RECVDATA.WORD_PLC_SRS_D6000.FI1309_PV.ToDouble() / 1000 'L/min⇒m3/min
        SLS.V_psa = SLS.V_psa + (-1 * RECVDATA.BIT_PLC_SRS_M9000.XV1308) * RECVDATA.WORD_PLC_SRS_D6000.FI1308_PV.ToDouble() / 1000 'L/min⇒m3/min
        SLS.V_psa = SLS.V_psa + (-1 * RECVDATA.BIT_PLC_SRS_M9000.XV1393_2) * RECVDATA.WORD_PLC_SRS_D6000.FI1393_2_PV.ToDouble() / 1000 'L/min⇒m3/min

        SLS.V_demi = SLS.V_demi / 60 * samplingtimeSLS ' m3/min⇒m3/s * samplingtimesecond⇒m3
        SLS.V_psa = SLS.V_psa / 60 * samplingtimeSLS ' m3/min⇒m3/s * samplingtimesecond⇒m3
        SLS.V_add = SLS.V_psa + SLS.V_demi
        SLS.SnD = SLS.SnD * SLS.V_before / (SLS.V_before + SLS.V_add)


        'Modified 2014/2/14/////////////////////////////////////////////////////////////////

        'ScD,SpDの一次遅れ計算
        ' SpDp,SpDpは前回の一次遅れ計算結果
        'SpD = (Tp - Te) / Tp * SpDp + Te / Tp * Sp  '
        'ScD = (Tc - Te) / Tc * ScDp + Te / Tc * Sc  '
        'SnD = (alpha * SpD + ScD) / V + SnD



        'Modified 2014/02/07////////////////////////////////////////////////
        'サンプリング時間の統一のため修正

        SLS.Sp = Spkgh / 3600 * samplingtimeSLS
        SLS.Sc = Sckgh / 3600 * samplingtimeSLS

        Dim Tp = SLS.Tp
        Dim Te = SLS.Te
        Dim Tc = SLS.Tc
        Dim alpha = SLS.alpha


        ' SpDp,SpDpは前回の一次遅れ計算結果
        SLS.SpD = (Tp - Te) / Tp * SLS.SpDp + Te / Tp * SLS.Sp  '
        SLS.ScD = (Tc - Te) / Tc * SLS.ScDp + Te / Tc * SLS.Sc '
        SLS.SnD = (alpha * SLS.SpD - SLS.ScD) / V + SLS.SnD
        'Modified 2014/02/07////////////////////////////////////////////

        'If dataInputFlag <> 0 Then
        '    SnD = (SnD + Sn(1)) / 2.0
        'End If
        'lSpcD = SpD - ScD

        'For I = 60 To 2 Step -1
        '    ScD_r(I) = ScD_r(I - 1)
        '    lSpcD_r(I) = lSpcD_r(I - 1)
        'Next
        'ScD_r(1) = ScD
        'lSpcD_r(1) = lSpcD

        'If dataInputFlag <> 0 Then
        '    '2014/1/23 手分析結果インプットで積算量リセット
        '    SSD = lSpcD
        'Else
        '    '2014/1/23 以後積算
        '    SSD = SSD + lSpcD
        'End If

        If D_Counter > 0 Then
            D_Counter = D_Counter - 1
        End If

        SLS.DateTime_r(1) = tday
        SLS.SnD_r(1) = SLS.SnD 'ログに残す
        SLS.SpD_r(1) = SLS.SpD_r(2) + SLS.SpD
        SLS.ScD_r(1) = SLS.ScD_r(2) + SLS.ScD
        SLS.Sn_r(1) = SLS.TinIonValue

        SLS.SpDp = SLS.SpD 'sp１次遅れ計算用
        SLS.ScDp = SLS.ScD 'sc１次遅れ計算用

        'Dim db_time As Date = tday.Date + TimeSerial(tday.Hour, tday.Minute, 0)
        'Dim db_vals() As Single = New Single() {SnD, MEASUREMENTSDATA.TIA_PV}

        'inmemory_db(db_time) = db_vals

        'Dim loopflag As Boolean = True
        'Do While loopflag
        '    If db_time - inmemory_db.Keys(0) > TimeSpan.FromHours(1) Then
        '        inmemory_db.RemoveAt(0)
        '        loopflag = inmemory_db.Count > 0
        '        Continue Do
        '    End If
        '    loopflag = False
        'Loop
        '
        'イベントログ出力しない場合はFalse
        '
        'Try
        '    If True And eventlog Then
        '        'イベントログ
        '        Dim buff As String
        '        Dim EVLogFilename As String = "C:\DATASTRAGE\" & tday.ToString("yyyyMMdd") & "_eventlog_sls.csv"

        '        If FileIO.FileSystem.FileExists(EVLogFilename) = False Then

        '            FileIO.FileSystem.WriteAllText(EVLogFilename, "Time,手入力更新フラグ,Sn,Sp,Sc,V_num,V_den,α,", False, System.Text.Encoding.Default)
        '            buff = ""
        '            For I = 1 To NUMSAMPLES - 1
        '                buff = buff & String.Format("(SnT({0})-SnT({1}))V,", I, I + 1)
        '            Next
        '            For I = 1 To NUMSAMPLES
        '                buff = buff & String.Format("SpT({0}),ScT({0},VT({0})", I)
        '            Next
        '            FileIO.FileSystem.WriteAllText(EVLogFilename, buff & vbCrLf, True, System.Text.Encoding.Default)
        '        End If
        '        FileIO.FileSystem.WriteAllText(EVLogFilename, sim_time.ToString("yyyy/MM/dd HH:mm:ss") & "," & (V_comp <> 0) & "," & Sn_new_data & "," & Sp & "," & Sc & "," & V_num & "," & V_den & "," & alpha & ",", True, System.Text.Encoding.Default)
        '        buff = ""
        '        For I = 1 To NUMSAMPLES - 1
        '            buff = buff & (SnT(I) - SnT(I + 1)) * V & ","
        '        Next
        '        For I = 1 To NUMSAMPLES
        '            buff = buff & SpT(I) & "," & ScT(I) & "," & VT(I) & ","
        '        Next
        '        FileIO.FileSystem.WriteAllText(EVLogFilename, buff & vbCrLf, True, System.Text.Encoding.Default)
        '    End If
        Dim sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\sls_InitialData3.csv", False)
        sw.WriteLine(tday.ToString("yyyy/MM/dd HH:mm:ss"))
        'Modified 2014/02/07//////////////////////////////////////////////////////////////////////
        'For I = 1 To NUMSAMPLES
        'sw.WriteLine(SampDateTime(I).ToString("yyyy/MM/dd HH:mm:ss") & "," & SnT(I) & "," & SpT(I) & "," & ScT(I) & "," & VT(I))
        'Next

        'Modified 2014/02/07//////////////////////////////////////////////////////////////////////
        For I = 1 To SLS.LOGMINUTES
            sw.WriteLine(SLS.DateTime_r(I).ToString("yyyy/MM/dd HH:mm:ss") & "," & SLS.SnD_r(I) & "," & SLS.SpD_r(I) & "," & SLS.ScD_r(I) & "," & SLS.Sn_r(I))
        Next
        sw.Close()

        'Modified 2014/02/07//////////////////////////////////////////////////////////////////////
        Dim sw1 As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\sls_InitialData4.csv", False)
        sw1.WriteLine(tday.ToString("yyyy/MM/dd HH:mm:ss"))
        For I = 1 To SLS.NUMSAMPLES
            sw1.WriteLine(SLS.SampDateTime(I).ToString("yyyy/MM/dd HH:mm:ss") & "," & SLS.SnT(I) & "," & SLS.SpT(I) & "," & SLS.ScT(I) & "," & SLS.VT(I))
        Next
        sw1.Close()

        'Modified 2014/02/07//////////////////////////////////////////////////////////////////////


        '    ' 検索用インメモリDBの出力
        '    '
        '    'sw = New StreamWriter(My.Application.Info.DirectoryPath & "\sls_InMemoryDB.csv", False)

        '    'sls計算ログ出力しない場合はコメントアウト
        '    '
        '    'Exit Sub

        '    Dim SLLogFilename As String = "C:\DATASTRAGE\" & tday.ToString("yyyyMMdd") & "_sls.csv"
        '    If FileIO.FileSystem.FileExists(SLLogFilename) = False Then
        '        FileIO.FileSystem.WriteAllText(SLLogFilename, "Time,手入力更新フラグ,New Data,α,Sp,Sc,Sp',Sc', Sp'r,Sc'r, Sn',XV-1305-1 Open,XV-1305-2 Open,XV-1308 Open,XV-1309 Open,VTIE-08 Open & PC-17-AorB Runnning,VTIE-02 Open & VTIB-07 Open & PC-17-A Runnning,V_psa,V_demi,V_add" & vbCrLf, False, System.Text.Encoding.Default)
        '    End If
        '    FileIO.FileSystem.WriteAllText(SLLogFilename, sim_time.ToString("yyyy/MM/dd HH:mm:ss") & "," & (V_comp <> 0) & "," & Sn_new_data & "," & alpha & "," & Sp & "," & Sc & "," & SpD & "," & ScD & "," & SpD_r(1) & "," & ScD_r(1) & "," & SnD & "," _
        '                                   & MEASUREMENTSDATA.XV_1305_1_OPEN & "," & MEASUREMENTSDATA.XV_1305_2_OPEN & "," _
        '                                   & MEASUREMENTSDATA.XV_1308_OPEN & "," & MEASUREMENTSDATA.XV_1309_OPEN & "," _
        '                                   & VTIE08OP_AND_PC17AORBRUN & "," & VTIB02OP_AND_VTIB07OP_PC2ARUN & "," _
        '                                   & V_psa & "," & V_demi & "," & V_add _
        '                                   & vbCrLf, True, System.Text.Encoding.Default)
        'Catch ex As Exception

        'End Try

    End Sub


    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted

        evlog.Logging(Me, sender, e)
    End Sub
End Class