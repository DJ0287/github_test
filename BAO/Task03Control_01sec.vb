Imports System.IO
Imports System.Text

Public Class Task03Control_01sec
    Inherits Task00Base
    Implements Task00Interface
    'SRS演算Controlの中で使われる変数の定義
    Public Shared lineconditionchange(1) As Boolean
    Public Shared interlockchange As Boolean

    Public Shared linecondition(1) As Boolean
    Public Shared prevlinecondition(1) As Boolean
    Public Shared schstat(1) As スケジュール変更ステータス
    Public Shared previnterlock As Boolean
    Public Shared interlock As Boolean
    Public Shared scantime As TimeSpan  'データのスキャン間隔（実測)
    Public Shared スケジュール更新フラグ(1) As Boolean

    Dim lasttime As DateTime = DateTime.MinValue  '最後の更新時刻
    Dim nowtime As DateTime ' 現在時刻

    Dim S_Pre(1) As Double
    Dim SnPre(1) As Double
    Dim S_Pre1(1) As Double
    Dim S_Init(1) As Double

    Dim TA(1) As TimeSpan '実績時間(ta)
    Dim TAC(1) As TimeSpan
    Dim TASH(1) As TimeSpan '実績時間(ta)
    Dim TR(1) As TimeSpan 'ライン停止時間(TR)
    Dim TZ0(1) As TimeSpan
    Dim TZ0P(1) As TimeSpan
    Dim TE0(1) As TimeSpan

    Dim endten(1) As Integer    '現在のTen1の位置
    Dim prev_endten(1) As Integer '前回のTen1の位置
    Dim endno(1) As String     '現在のTen1位置のCoilNo値
    Dim prev_endno(1) As String '前回のTen1位置のCoilNo値
    Dim compS(1) As Double
    Dim compE(1) As Double
    Dim compInit(1) As Boolean
    Dim lastスケジュール更新フラグ(1) As Boolean
    Dim lastschstat(1) As スケジュール変更ステータス
    Dim lastschnum(1) As Integer
    Dim FIC_2 As 時定数演算
    Dim FIC_4 As 時定数演算
    Dim FIC_7 As 時定数演算
    Dim FIC_8 As 時定数演算
    Dim FIC_10 As 時定数演算
    Dim twsums(1) As Double
    Dim prev_StA濃度測定完了 As Boolean
    Dim prev_No3濃度測定完了 As Boolean
    Dim prev_No4濃度測定完了 As Boolean

    'パラメータ更新通知
    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        evlog.Logging(Me, sender, e)
    End Sub
    'SRS演算Controlの中で使われるサブルーチンの定義
    '演算実行（1sec間隔)
    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim e As New TaskEventArgs
        Dim etlnum = 0 'RECVDATA.WORD_PLC_SRS_SCHS.Count() - 1
        If firstrun = True Then
            '初回実行時に初期化
            lasttime = DateTime.Now
            'SYSTEMCONDITION.システム稼働時間 = TimeSpan.Zero
            'SYSTEMCONDITION.ETL操業時間 = TimeSpan.Zero
            CONDITION.LINESPEED.Initialize(0, 0.5)
            previnterlock = False
            prevlinecondition(0) = False
            prevlinecondition(1) = False
            If DEBUG.Logging Then
                'デバッグ出力(0, True)
                'デバッグ出力(1, True)
            End If

            For I = 0 To etlnum
                endten(I) = -1
                prev_endten(I) = 20
                endno(I) = 0
                prev_endno(I) = ""

                compS(I) = 0
                compE(I) = 0
                compInit(I) = True
                lastschstat(I) = スケジュール変更ステータス.SCH_変更なし
                ETLPRODSCHS(I).制御実績時間 = 0
                TA(I) = TimeSpan.Zero
                TAC(I) = TimeSpan.Zero
                TASH(I) = TimeSpan.Zero
                TR(I) = TimeSpan.Zero
                TZ0(I) = TimeSpan.Zero
                TZ0P(I) = TimeSpan.Zero
                TE0(I) = TimeSpan.Zero
            Next
            DISCOMBSCH.Dissolution.Clear()
            DISCOMBSCH.O2SET = 0
            DISCOMBSCH.S1s = 0
            DISCOMBSCH.S1SET = 0
            DISCOMBSCH.SL = 0
            DISCOMBSCH.SdS1 = 0
            DISCOMBSCH.dS1x = 0
            prev_StA濃度測定完了 = False
            prev_No3濃度測定完了 = False
            prev_No4濃度測定完了 = False

        End If
        e.etype = TaskEventArgs.EventType.SRS_演算エラー
        If L1INFO.Connection <> 0 Then
            ALAM.Trigger(ALAM.ALAMNO.COM_L2_ERROR, True)
            'アラームチェック
            ALAM.CheckAlams()
            e.ex = New Exception("PLCと接続されていません。")
            Run = e
            Notify(e)
            Exit Function
        End If
        Try
            '通信が確立している
            If ALAM.ALAMITEMS(ALAM.ALAMNO.COM_L2_ERROR).Trigger Then
                ALAM.Trigger(ALAM.ALAMNO.COM_L2_ERROR, False)

            End If
            'データの更新間隔を求める
            nowtime = DateTime.Now
            scantime = (nowtime - lasttime)
            If Math.Abs(scantime.TotalSeconds()) > 10 Then
                scantime = TimeSpan.FromSeconds(1)
            End If
            If My.Computer.Name = "PDPC02017" Or My.Computer.Name = "PDPC02044" Then
                scantime = TimeSpan.FromSeconds(scantime.TotalSeconds() * DEBUG.BAISOKU)
            End If
            lasttime = nowtime
            RECVDATA.BIT_PLC_SRS_IND.StA_濃度測定中 = Not RECVDATA.BIT_PLC_SRS_IND.StA_濃度測定完了
            RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定中 = Not RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定完了
            RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定中 = Not RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定完了

            'Dim ライン速度() As Double = {RECVDATA.WORD_PLC_SRS_IND.No3_LS.ToDouble(), RECVDATA.WORD_PLC_SRS_IND.No4_LS.ToDouble()}
            Dim ライン速度() As Double = {RECVDATA.WORD_PLC_SRS_D6000.LINESPEED.ToDouble(), RECVDATA.WORD_PLC_SRS_D6000.LINESPEED.ToDouble()}

            For I = 0 To etlnum '（I=0:No3,I=1:No4)
                lastschnum(I) = ETLPRODSCHS(I).Products.Count

                linecondition(I) = CONDITION.LINESPEED.Check(I, ライン速度)
            Next
            '旧八幡No4を常に休止として扱う
            linecondition(1) = False

            If linecondition(0) Then
                SYSTEMCONDITION.ETL操業時間 = SYSTEMCONDITION.ETL操業時間 + scantime
            End If
            ETLTANK.FCV2_PV = RECVDATA.WORD_PLC_SRS_CTR.FCV2_PV.ToDouble
            ETLTANK.FCV4_PV = RECVDATA.WORD_PLC_SRS_CTR.FCV4_PV.ToDouble
            ETLTANK.FCV7_PV = RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToDouble
            ETLTANK.FCV8_PV = RECVDATA.WORD_PLC_SRS_CTR.FCV8_PV.ToDouble
            ETLTANK.FCV10_PV = RECVDATA.WORD_PLC_SRS_CTR.FCV10_PV.ToDouble
            ETLTANK.FCV2_SV = RECVDATA.WORD_PLC_SRS_IND.FCV2_SV.ToDouble
            ETLTANK.FCV4_SV = RECVDATA.WORD_PLC_SRS_IND.FCV4_SV.ToDouble
            ETLTANK.FCV7_SV = RECVDATA.WORD_PLC_SRS_IND.FCV7_SV.ToDouble
            ETLTANK.FCV8_SV = RECVDATA.WORD_PLC_SRS_IND.FCV8_SV.ToDouble
            ETLTANK.FCV10_SV = RECVDATA.WORD_PLC_SRS_IND.FCV10_SV.ToDouble
            ETLTANK.StA_TL = RECVDATA.WORD_PLC_SRS_CTR.StA_TL_PV.ToDouble
            ETLTANK.StA_TL_SETVAL = RECVDATA.WORD_PLC_SRS_CTR.StA_TL_SETVAL.ToDouble
            ETLTANK.StA_CONC = RECVDATA.WORD_PLC_SRS_CTR.StA_COND_PV.ToDouble
            ETLTANK.StA_AVE = RECVDATA.WORD_PLC_SRS_CTR.StA_AVE.ToDouble
            ETLTANK.StB_TL = RECVDATA.WORD_PLC_SRS_IND.StB_TL_PV.ToDouble
            ETLTANK.No3_TL = RECVDATA.WORD_PLC_SRS_CTR.No3_循環_TL_PV.ToDouble
            ETLTANK.No4_TL = RECVDATA.WORD_PLC_SRS_CTR.No4_循環_TL_PV.ToDouble
            ETLTANK.No3_CONC = RECVDATA.WORD_PLC_SRS_CTR.No3_循環_CONC_PV.ToDouble
            ETLTANK.No4_CONC = RECVDATA.WORD_PLC_SRS_CTR.No4_循環_CONC_PV.ToDouble
            ETLTANK.No3_AVE = RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.ToDouble
            ETLTANK.No4_AVE = RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.ToDouble

            'NO3ETL循環タンクDATA.F3set = 0
            'NO4ETL循環タンクDATA.F4set = 0
            '溶解槽DATA.Faset = 0
            '溶解槽DATA.Fbset = 0
            DISCOMBSCH.O2SET = 0
            'DISCOMBSCH.S1s = 0
            'DISCOMBSCH.S1SET = 0
            'DISCOMBSCH.SL = 0
            'DISCOMBSCH.SdS1 = 0
            'DISCOMBSCH.dS1x = 0

            'SRS運転中か確認する
            ' SRS_運転指令:ON
            ' PLC_操作:SRS自動ON
            ' FCV2_PID制御モード:CASモード
            ' FCV4_PID制御モード:CASモード
            ' FCV7_PID制御モード:CASモード
            ' FCV8_PID制御モード:CASモード
            ' FCV10_PID制御モード:CASモード
            Dim coil_weight As Double = 0
            Try
                coil_weight = PARAMETER.Search("COIL_WEIGHT").設定値
            Catch ex As Exception
                PARAMETER.SetNewValue("PARASetting.csv", "COIL_WEIGHT", coil_weight.ToString())

            End Try
            If prev_endno(0) <> "" And RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count = 0 Then
                '                OrElse (RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 AndAlso ETLPRODSCHS(0).Products.Count > 0 AndAlso
                '                RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0).No.ToString <> ETLPRODSCHS(0).Products(0).No.ToString AndAlso
                '                ETLPRODSCHS(0).Products(0).Weight_bk > coil_weight) Then

                'If prev_endno(0) <> -1 AndAlso RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count = 0 _
                'OrElse (RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 AndAlso ETLPRODSCHS(0).Products.Count > 0 _
                'AndAlso RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0).No.ToString <> ETLPRODSCHS(0).Products(0).No.ToString _
                'AndAlso ETLPRODSCHS(0).Products(0).Weight_bk > coil_weight) Then
                '            If (prev_endno(0) <> -1) AndAlso RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count = 0 Then _
                '                OrElse (RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 AndAlso
                '                    RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0).No.ToString <> ETLPRODSCHS(0).Products(0).No.ToString AndAlso
                '                    ETLPRODSCHS(0).Products(0).Weight_bk > coil_weight) Then
                '次の演算に向けた初期化（No3,No4)
                For I = 0 To etlnum
                    ETLPRODSCHS(I).Products.Clear()
                    'コントロールエンドの位置とロットNoを初期化するフラグをセットする
                    endten(I) = -1
                    prev_endten(I) = 20
                    endno(I) = 0
                    prev_endno(I) = ""
                    'Sfを初期化する
                    ETLPRODSCHS(I).Sf = 0
                    ETLPRODSCHS(I).S1p = 0
                    ETLPRODSCHS(I).S1f = 0
                    ETLPRODSCHS(I).dS1x = 0
                    compS(I) = 0
                    compE(I) = 0
                    compInit(I) = True
                    '前回のスケジュールフラグを初期化する
                    lastschstat(I) = スケジュール変更ステータス.SCH_変更なし
                    '制御区間内部変数(TA, TAC, TASH, TR, TZ0, TZ0P, TE0)を初期化する
                    ETLPRODSCHS(I).制御実績時間 = 0
                    TA(I) = TimeSpan.Zero
                    TAC(I) = TimeSpan.Zero
                    TASH(I) = TimeSpan.Zero
                    TR(I) = TimeSpan.Zero
                    TZ0(I) = TimeSpan.Zero
                    TZ0P(I) = TimeSpan.Zero
                    TE0(I) = TimeSpan.Zero
                Next
                '合算スケジュールと補正を初期化する
                DISCOMBSCH.Dissolution.Clear()
                DISCOMBSCH.O2SET = 0
                DISCOMBSCH.S1s = 0
                DISCOMBSCH.S1SET = 0
                DISCOMBSCH.SL = 0
                DISCOMBSCH.SdS1 = 0
                DISCOMBSCH.dS1x = 0
            End If
            '            If prev_StA濃度測定完了 = False And RECVDATA.BIT_PLC_SRS_IND.StA_濃度測定完了 = True Then
            If prev_StA濃度測定完了 = False And RECVDATA.BIT_PLC_SRS_M8000.CIR_TANK Then

                DISCOMBSCH.dS1a = 0.0
                DISCOMBSCH.dS1a_comp_time = PARAMETER.Search("TC1").設定値 * 60
                DISCOMBSCH.dS1b = 0.0
                DISCOMBSCH.dS1b_comp_time = PARAMETER.Search("TC2").設定値 * 60
                DISCOMBSCH.dS1c = 0.0
                DISCOMBSCH.dS1c_comp_time = PARAMETER.Search("TC3").設定値 * 60
                DISCOMBSCH.dS1d = 0.0
                DISCOMBSCH.dS1d_comp_time = PARAMETER.Search("TC4").設定値 * 60
            End If
            'If prev_No3濃度測定完了 = False And RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定完了 = True Then

            '    DISCOMBSCH.dS1e = 0.0
            '    DISCOMBSCH.dS1e_comp_time = PARAMETER.Search("TC5").設定値 * 60
            '    DISCOMBSCH.dS1f = 0.0
            '    DISCOMBSCH.dS1f_comp_time = PARAMETER.Search("TC6").設定値 * 60
            'End If
            'If prev_No4濃度測定完了 = False And RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定完了 = True Then
            '    DISCOMBSCH.dS1g = 0.0
            '    DISCOMBSCH.dS1g_comp_time = PARAMETER.Search("TC7").設定値 * 60
            '    DISCOMBSCH.dS1h = 0.0
            '    DISCOMBSCH.dS1h_comp_time = PARAMETER.Search("TC8").設定値 * 60
            'End If

            interlock = インターロック判定()
            'ETL毎生産スケジュール有　判定（I=0:No3,I=1:No4)
            For I = 0 To etlnum
                If RECVDATA.WORD_PLC_SRS_SCHS(I).Products.Count > 0 Then
                    Dim topcoilchange As Boolean = False
                    'ロット数が前回と異なっていたらスケジュール更新と判定
                    schstat(I) = スケジュール変更ステータス.SCH_変更なし
                    スケジュール更新フラグ(I) = RECVDATA.WORD_PLC_SRS_SCHS(I).Products.Count <> ETLPRODSCHS(I).Products.Count
                    If スケジュール更新フラグ(I) = False Then
                        スケジュール更新フラグ(I) = スケジュール更新フラグ(I) Or RECVDATA.WORD_PLC_SRS_SCHS(I).TopCoilChange
                        For J = 0 To ETLPRODSCHS(I).Products.Count - 1
                            '全てのロットNo,重量,幅,TPH,目付量が前回と異なっていたらスケジュール更新と判定
                            スケジュール更新フラグ(I) = スケジュール更新フラグ(I) Or RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J).No.ToString <> ETLPRODSCHS(I).Products(J).No.ToString
                            If J = 0 Then
                                スケジュール更新フラグ(I) = スケジュール更新フラグ(I) Or RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J).Weight.ToDouble() <> ETLPRODSCHS(I).Products(J).Weight_bk
                            Else
                                スケジュール更新フラグ(I) = スケジュール更新フラグ(I) Or RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J).Weight.ToDouble() <> ETLPRODSCHS(I).Products(J).Weight.ToDouble
                            End If

                            Dim coilchange = RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J).Width.ToDouble() <> ETLPRODSCHS(I).Products(J).Width.ToDouble() _
                             Or RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J).Thickness.ToDouble() <> ETLPRODSCHS(I).Products(J).Thickness.ToDouble() _
                             Or RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J).TPH.ToDouble() <> ETLPRODSCHS(I).Products(J).TPH.ToDouble() _
                             Or RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J).Coating.ToDouble() <> ETLPRODSCHS(I).Products(J).Coating.ToDouble()
                            スケジュール更新フラグ(I) = スケジュール更新フラグ(I) Or coilchange
                            If スケジュール更新フラグ(I) Then
                                If J = 0 Then
                                    topcoilchange = False
                                End If
                                Exit For
                            End If
                        Next

                    End If
                    If スケジュール更新フラグ(I) Then
                        'スケジュール変更内容チェック
                        schstat(I) = スケジュール変更ステータス.SCH_その他
                        If ETLPRODSCHS(I).Products.Count > 0 Then
                            If RECVDATA.WORD_PLC_SRS_SCHS(I).Products(0).No.ToString <> ETLPRODSCHS(I).Products(0).No.ToString Then
                                '先頭ロット更新
                                schstat(I) = スケジュール変更ステータス.SCH_先頭ロット更新
                                'ElseIf RECVDATA.WORD_PLC_SRS_SCHS(I).Products(0).Weight.ToDouble <> ETLPRODSCHS(I).Products(0).Weight.ToDouble Then
                                'ElseIf RECVDATA.WORD_PLC_SRS_SCHS(I).TopCoilChange Or RECVDATA.WORD_PLC_SRS_SCHS(I).Products(0).Weight.ToDouble <> ETLPRODSCHS(I).Products(0).Weight.ToDouble Then
                            ElseIf RECVDATA.WORD_PLC_SRS_SCHS(I).TopCoilChange Then
                                '先頭コイルスケジュール変更
                                schstat(I) = スケジュール変更ステータス.SCH_先頭コイル更新
                            ElseIf topcoilchange Then
                                schstat(I) = スケジュール変更ステータス.SCH_先頭ロット更新
                            Else

                                schstat(I) = スケジュール変更ステータス.SCH_変更なし
                            End If
                        Else
                            schstat(I) = スケジュール変更ステータス.SCH_先頭ロット更新
                        End If
                        lastschstat(I) = schstat(I)
                        lastスケジュール更新フラグ(I) = スケジュール更新フラグ(I)
                    End If
                    Call 生産スケジュールセット(I, スケジュール更新フラグ, schstat)
                Else
                    If ETLPRODSCHS(I).Products.Count > 0 Then
                        If DEBUG.Capture Then
                            Dim timestr As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                            Dim updatesubtitle = ""
                            updatesubtitle = updatesubtitle & "_ScheduleEndTrigger"
                            'Call 画面キャプチャ(Frm02NO3SCH, timestr, updatesubtitle & "1")
                            Call 画面キャプチャ(Frm02SCH_BAO, timestr, updatesubtitle & "1")
                        End If
                        ETLPRODSCHS(I).Products.Clear()
                        Call コントロールエンド処理(I)
                    End If
                    'endno(I) = 0
                    'prev_endno(I) = 0
                    endten(I) = ""
                    prev_endten(I) = 20
                    endten(I) = 0
                    endno(I) = "0"
                    prev_endno(I) = "0"
                End If
            Next

            If interlock Then
                If linecondition(0) Or linecondition(1) Then
                    SYSTEMCONDITION.システム稼働時間 = SYSTEMCONDITION.システム稼働時間 + scantime
                End If
                DISCOMBSCH.dS1x = 0
                For I = 0 To etlnum
                    ETLPRODSCHS(I).制御実績時間 = ETLPRODSCHS(I).制御実績時間 + scantime.TotalMinutes()

                    'If RECVDATA.WORD_PLC_SRS_SCHS(I).Products.Count > 0 Then
                    If linecondition(I) And RECVDATA.WORD_PLC_SRS_SCHS(I).Products.Count > 0 Then
                        TA(I) = TA(I) + scantime
                    Else
                        TR(I) = TR(I) + scantime
                    End If

                    '生産スケジュールのTw,Tz,Sn,Te,S,S1を計算する
                    If previnterlock <> interlock Then
                        schstat(I) = lastschstat(I)
                        スケジュール更新フラグ(I) = lastスケジュール更新フラグ(I)
                        lastschstat(I) = スケジュール変更ステータス.SCH_変更なし
                        lastスケジュール更新フラグ(I) = False
                    End If
                    If lastschnum(I) = 0 And RECVDATA.WORD_PLC_SRS_SCHS(I).Products.Count > 0 Then
                        TZ0P(I) = -TA(I)
                    End If
                    TAC(I) = TAC(I) + scantime
                    If RECVDATA.WORD_PLC_SRS_SCHS(I).Products.Count > 0 Then

                        If スケジュール更新フラグ(I) Then
                            'If schstat(I) <> スケジュール変更ステータス.SCH_先頭コイル更新 Then
                            If schstat(I) <> スケジュール変更ステータス.SCH_変更なし Then
                                TASH(I) = TA(I)
                                'TZ0P(I) = TZ0P(I) + TR(I)
                                'TR(I) = TimeSpan.Zero
                            End If

                        End If



                        Call 生産スケジュール演算(I, schstat)
                        Call 溶解スケジュール演算(I, schstat, scantime)
                        'If スケジュール更新フラグ(I) Or previnterlock <> interlock Then
                        Call 生産スケジュールトレンド(I)
                        'End If

                        Call 錫溶解補正量ΔS1x演算(I, linecondition)
                        DISCOMBSCH.dS1x = DISCOMBSCH.dS1x + ETLPRODSCHS(I).dS1x
                    End If
                    TZ0(I) = TZ0P(I) + TR(I)
                Next

                'Call 溶解槽流量演算()
                Call 溶解スケジュール集計(linecondition)
                Call 溶解スケジュールトレンド()
                '錫溶解補正量計算
                '各々計算タイミングが異なる

                If RECVDATA.BIT_PLC_SRS_M8000.CIR_TANK = True Then
                    If DISCOMBSCH.dS1a_comp_time > 0.0 Then
                        '補正中
                        If linecondition(0) Or linecondition(1) Then
                            '補正中
                            DISCOMBSCH.dS1a = 錫溶解補正量ΔS1a演算()
                            DISCOMBSCH.dS1a_comp_time = DISCOMBSCH.dS1a_comp_time - scantime.TotalSeconds * (Math.Abs(DISCOMBSCH.dS1a) > 0.01) * (-1)
                            If DISCOMBSCH.dS1a_comp_time <0.0 Then DISCOMBSCH.dS1a_comp_time= 0.0
                        Else
                            'No3,4ライン停止中は補正保留
                DISCOMBSCH.dS1a = 0
            End If
            Else
                        '補正完了(Tc1[min]経過後)
                        DISCOMBSCH.dS1a = 0.0
                    End If
                    If DISCOMBSCH.dS1b_comp_time > 0.0 Then
                        '補正中
                        If linecondition(0) Or linecondition(1) Then
                            DISCOMBSCH.dS1b = 錫溶解補正量ΔS1b演算()
                            DISCOMBSCH.dS1b_comp_time = DISCOMBSCH.dS1b_comp_time - scantime.TotalSeconds * (Math.Abs(DISCOMBSCH.dS1b) > 0.01) * (-1)
                            If DISCOMBSCH.dS1b_comp_time < 0.0 Then DISCOMBSCH.dS1b_comp_time = 0.0
                        Else
                            'No3,4ライン停止中は補正保留
                            DISCOMBSCH.dS1b = 0
                        End If
                    Else
                        '補正完了(Tc2[min]経過後)
                        DISCOMBSCH.dS1b = 0.0
                    End If
                    If DISCOMBSCH.dS1c_comp_time > 0.0 Then
                        '補正中
                        If linecondition(0) Or linecondition(1) Then
                            DISCOMBSCH.dS1c = 錫溶解補正量ΔS1c演算()
                            DISCOMBSCH.dS1c_comp_time = DISCOMBSCH.dS1c_comp_time - scantime.TotalSeconds * (Math.Abs(DISCOMBSCH.dS1c) > 0.01) * (-1)
                            If DISCOMBSCH.dS1c_comp_time < 0.0 Then DISCOMBSCH.dS1c_comp_time = 0.0
                        Else
                            'No3,4ライン停止中は補正保留
                            DISCOMBSCH.dS1c = 0
                        End If
                    Else
                        '補正完了(Tc3[min]経過後)
                        DISCOMBSCH.dS1c = 0.0
                    End If
                    If DISCOMBSCH.dS1d_comp_time > 0.0 Then
                        '補正中
                        If linecondition(0) Or linecondition(1) Then
                            DISCOMBSCH.dS1d = 錫溶解補正量ΔS1d演算()
                            DISCOMBSCH.dS1d_comp_time = DISCOMBSCH.dS1d_comp_time - scantime.TotalSeconds * (Math.Abs(DISCOMBSCH.dS1d) > 0.01) * (-1)
                            If DISCOMBSCH.dS1d_comp_time < 0.0 Then DISCOMBSCH.dS1d_comp_time = 0.0
                        Else
                            'No3,4ライン停止中は補正保留
                            DISCOMBSCH.dS1d = 0
                        End If
                    Else
                        '補正完了(Tc4[min]経過後)
                        DISCOMBSCH.dS1d = 0.0
                    End If

                Else
                    '測定中（補正機能は全てOFF）
                    DISCOMBSCH.dS1a = 0.0
                    DISCOMBSCH.dS1a_comp_time = PARAMETER.Search("TC1_").設定値 * 60
                    DISCOMBSCH.dS1b = 0.0
                    DISCOMBSCH.dS1b_comp_time = PARAMETER.Search("TC2").設定値 * 60
                    DISCOMBSCH.dS1c = 0.0
                    DISCOMBSCH.dS1c_comp_time = PARAMETER.Search("TC3").設定値 * 60
                    DISCOMBSCH.dS1d = 0.0
                    DISCOMBSCH.dS1d_comp_time = PARAMETER.Search("TC4").設定値 * 60
                End If
                'If RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定完了 = True Then
                'If DISCOMBSCH.dS1e_comp_time > 0.0 Then
                '    '補正中
                '    If linecondition(0) Then
                '        DISCOMBSCH.dS1e = 錫溶解補正量ΔS1e演算()
                '        DISCOMBSCH.dS1e_comp_time = DISCOMBSCH.dS1e_comp_time - scantime.TotalSeconds * (Math.Abs(DISCOMBSCH.dS1e) > 0.01) * (-1)
                '        If DISCOMBSCH.dS1e_comp_time < 0.0 Then DISCOMBSCH.dS1e_comp_time = 0.0
                '    Else
                '        'No3ライン停止中は補正保留
                '        DISCOMBSCH.dS1e = 0
                '    End If
                'Else
                '    '補正完了(Tc5[min]経過後)
                '    DISCOMBSCH.dS1e = 0.0
                'End If
                'If DISCOMBSCH.dS1f_comp_time > 0.0 Then
                '    '補正中
                '    If linecondition(0) Then
                '        DISCOMBSCH.dS1f = 錫溶解補正量ΔS1f演算()
                '        DISCOMBSCH.dS1f_comp_time = DISCOMBSCH.dS1f_comp_time - scantime.TotalSeconds * (Math.Abs(DISCOMBSCH.dS1f) > 0.01) * (-1)
                '        If DISCOMBSCH.dS1f_comp_time < 0.0 Then DISCOMBSCH.dS1f_comp_time = 0.0
                '    Else
                '        'No3ライン停止中は補正保留
                '        DISCOMBSCH.dS1f = 0
                '    End If

                'Else
                '    '補正完了(Tc6[min]経過後)
                '    DISCOMBSCH.dS1f = 0.0
                'End If
                ''Else
                ''測定中（補正機能は全てOFF）
                ''DISCOMBSCH.dS1e = 0.0
                ''DISCOMBSCH.dS1e_comp_time = PARAMETER.Search("TC5").設定値 * 60
                ''DISCOMBSCH.dS1f = 0.0
                ''DISCOMBSCH.dS1f_comp_time = PARAMETER.Search("TC6").設定値 * 60

                ''End If
                ''If RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定完了 = True Then
                'If DISCOMBSCH.dS1g_comp_time > 0.0 Then
                '    '補正中
                '    If linecondition(1) Then
                '        DISCOMBSCH.dS1g = 錫溶解補正量ΔS1g演算()
                '        DISCOMBSCH.dS1g_comp_time = DISCOMBSCH.dS1g_comp_time - scantime.TotalSeconds * (DISCOMBSCH.dS1g <> 0) * (-1)
                '        If DISCOMBSCH.dS1g_comp_time < 0.0 Then DISCOMBSCH.dS1g_comp_time = 0.0
                '    Else
                '        'No4ライン停止中は補正保留
                '        DISCOMBSCH.dS1g = 0
                '    End If
                'Else
                '    '補正完了(Tc7[min]経過後)
                '    DISCOMBSCH.dS1g = 0.0
                'End If

                'If DISCOMBSCH.dS1h_comp_time > 0.0 Then
                '    '補正中
                '    If linecondition(1) Then
                '        DISCOMBSCH.dS1h = 錫溶解補正量ΔS1h演算()
                '        DISCOMBSCH.dS1h_comp_time = DISCOMBSCH.dS1h_comp_time - scantime.TotalSeconds * (DISCOMBSCH.dS1h <> 0) * (-1)
                '        If DISCOMBSCH.dS1h_comp_time < 0.0 Then DISCOMBSCH.dS1h_comp_time = 0.0
                '    Else
                '        'No4ライン停止中は補正保留
                '        DISCOMBSCH.dS1h = 0
                '    End If
                'Else
                '    '補正完了(Tc8[min]経過後)
                '    DISCOMBSCH.dS1h = 0.0
                'End If
                'Else
                '測定中（補正機能は全てOFF）
                'DISCOMBSCH.dS1g = 0.0
                'DISCOMBSCH.dS1g_comp_time = PARAMETER.Search("TC7").設定値 * 60
                'DISCOMBSCH.dS1h = 0.0
                'DISCOMBSCH.dS1h_comp_time = PARAMETER.Search("TC8").設定値 * 60
                'End If
                '全ての補正結果の合計
                'DISCOMBSCH.SdS1 = DISCOMBSCH.dS1a + DISCOMBSCH.dS1b + DISCOMBSCH.dS1c + DISCOMBSCH.dS1d + DISCOMBSCH.dS1e + DISCOMBSCH.dS1f + DISCOMBSCH.dS1g + DISCOMBSCH.dS1h + DISCOMBSCH.dS1x
                DISCOMBSCH.SdS1 = DISCOMBSCH.dS1a + DISCOMBSCH.dS1b + DISCOMBSCH.dS1c + DISCOMBSCH.dS1d + DISCOMBSCH.dS1x
                    '補正結果のリミット
                    DISCOMBSCH.SdS1 = Math.Max(Math.Min(DISCOMBSCH.SdS1, DISCOMBSCH.SdS1Limit), -DISCOMBSCH.SdS1Limit)

                    DISCOMBSCH.S1SET = DISCOMBSCH.S1s + DISCOMBSCH.SdS1
                    DISCOMBSCH.S1SET = Math.Max(DISCOMBSCH.S1SET, 0)

                '酸素吹込量とスラッジ発生率演算
                '但し溶解槽_錫投入中の時は溶解スケジュール決定時と同じ計算を行う
                DISCOMBSCH.O2 = 酸素吹込量とスラッジ発生率演算(DISCOMBSCH.S1SET, RECVDATA.WORD_PLC_SRS_D5000.FIC311_O2_PV.ToDouble() / 1000.0, DISCOMBSCH.SL, False, False) 'RECVDATA.BIT_PLC_SRS_CTR.溶解槽_錫投入中)
                'F3計算
                'Call No3循環タンクメッキ液供給補正演算()
                'F4計算
                'Call No4循環タンクメッキ液供給補正演算()
                'St.B～溶解槽流量Ｆaを計算 と　溶解槽自己循環流量Ｆbを計算
                'Call 溶解槽流量演算()
                'F3,F4 SV計算
                'Call 各タンク供給量指令値演算()
                'End If
                e.etype = TaskEventArgs.EventType.SRS_演算完了
                Else
                    e.etype = TaskEventArgs.EventType.SRS_演算完了
            End If
            '演算エラーリセット
            'ALAM.Trigger(ALAM.ALAMNO.CALC_ERROR, ゼロ割エラー判定())
            If ゼロ割エラー判定() Then
                e.etype = TaskEventArgs.EventType.SRS_演算エラー
            End If
        Catch ex As Exception
            e.etype = TaskEventArgs.EventType.SRS_演算エラー
            e.ex = ex
            '演算エラーセット
            'ALAM.Trigger(ALAM.ALAMNO.CALC_ERROR, True)

        End Try
        'アラームチェック
        ALAM.CheckAlams()

        '送信用データセット
        'SENDDATA.BIT_SRS_PLC_ANS.SRS_運転中 = interlock
        'SENDDATA.BIT_SRS_PLC_ANS.溶解槽_酸素吹き込み中 = DISCOMBSCH.O2SET > 0
        'SENDDATA.BIT_SRS_PLC_TREND.StA_濃度測定完了 = RECVDATA.BIT_PLC_SRS_IND.StA_濃度測定中
        'SENDDATA.BIT_SRS_PLC_TREND.No3_循環濃度測定完了 = RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定中
        'SENDDATA.BIT_SRS_PLC_TREND.No3_調整材 = RECVDATA.BIT_PLC_SRS_IND.No3_調整材
        'SENDDATA.BIT_SRS_PLC_TREND.No4_循環濃度測定完了 = RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定中
        'SENDDATA.BIT_SRS_PLC_TREND.No4_調整材 = RECVDATA.BIT_PLC_SRS_IND.No4_調整材
        'SENDDATA.BIT_SRS_PLC_TREND.P1 = RECVDATA.BIT_PLC_SRS_IND.P1
        'SENDDATA.BIT_SRS_PLC_TREND.P2 = RECVDATA.BIT_PLC_SRS_IND.P2
        'SENDDATA.BIT_SRS_PLC_TREND.P7 = RECVDATA.BIT_PLC_SRS_IND.P7
        'SENDDATA.BIT_SRS_PLC_TREND.P8 = RECVDATA.BIT_PLC_SRS_IND.P8
        'SENDDATA.BIT_SRS_PLC_TREND.P12 = RECVDATA.BIT_PLC_SRS_IND.P12
        'SENDDATA.BIT_SRS_PLC_TREND.SRS_自動運転中 = RECVDATA.BIT_PLC_SRS_CTR.SRS_運転指令
        'SENDDATA.BIT_SRS_PLC_TREND.V6 = RECVDATA.BIT_PLC_SRS_IND.V6
        'SENDDATA.BIT_SRS_PLC_TREND.V12 = RECVDATA.BIT_PLC_SRS_IND.V12
        'SENDDATA.BIT_SRS_PLC_TREND.V13 = RECVDATA.BIT_PLC_SRS_IND.V13
        'SENDDATA.BIT_SRS_PLC_TREND.V16 = RECVDATA.BIT_PLC_SRS_IND.V16
        'SENDDATA.BIT_SRS_PLC_TREND.V19 = RECVDATA.BIT_PLC_SRS_IND.V19
        'SENDDATA.WORD_SRS_PLC_TREND.FIC2 = RECVDATA.WORD_PLC_SRS_CTR.FCV2_PV
        'SENDDATA.WORD_SRS_PLC_TREND.FIC4 = RECVDATA.WORD_PLC_SRS_CTR.FCV4_PV
        'SENDDATA.WORD_SRS_PLC_TREND.FIC7 = RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV
        'SENDDATA.WORD_SRS_PLC_TREND.FIC8 = RECVDATA.WORD_PLC_SRS_CTR.FCV8_PV
        'SENDDATA.WORD_SRS_PLC_TREND.No3_LS = RECVDATA.WORD_PLC_SRS_IND.No3_LS
        'SENDDATA.WORD_SRS_PLC_TREND.No4_LS = RECVDATA.WORD_PLC_SRS_IND.No4_LS
        'SENDDATA.WORD_SRS_PLC_TREND.StA_COND_PV = RECVDATA.WORD_PLC_SRS_CTR.StA_AVE
        'SENDDATA.WORD_SRS_PLC_TREND.StA_TL_PV = RECVDATA.WORD_PLC_SRS_CTR.StA_TL_PV
        'SENDDATA.WORD_SRS_PLC_TREND.StB_TL_PV = RECVDATA.WORD_PLC_SRS_IND.StB_TL_PV
        'SENDDATA.WORD_SRS_PLC_CTR.SRS_CALCERROR.From((e.etype = TaskEventArgs.EventType.SRS_演算エラー) * (-1), 1.0)
        Try
            If interlock Then
                SENDDATA.WORD_SRS_PLC_D5100.FIC311_O2_SV.FromDouble(DISCOMBSCH.O2 * 1000)
            Else
                SENDDATA.WORD_SRS_PLC_D5100.FIC311_O2_SV.FromDouble(RECVDATA.WORD_PLC_SRS_D5000.FIC311_O2_PV.ToDouble())
            End If
        Catch

        End Try
        'Try
        '    If interlock Then
        '        '2015/03/13 改修
        '        'Dim StAからNo3流量 = Math.Max(0.15, FIC_2.From1次遅れDouble(NO3ETL循環タンクDATA.F3set, 1))
        '        'Dim StAからNo4流量 = Math.Max(0.15, FIC_4.From1次遅れDouble(NO4ETL循環タンクDATA.F4set, 1))
        '        'Dim StBから溶解槽流量 = Math.Max(0.1, FIC_7.From1次遅れDouble(溶解槽DATA.Faset, 1))

        '        'SENDDATA.WORD_SRS_PLC_CTR.FIC2_SV.FromDouble(StAからNo3流量)
        '        'SENDDATA.WORD_SRS_PLC_CTR.FIC4_SV.FromDouble(StAからNo4流量)
        '        'SENDDATA.WORD_SRS_PLC_CTR.FIC7_SV.FromDouble(StBから溶解槽流量)

        '        'SENDDATA.WORD_SRS_PLC_CTR.FIC2_SV.FromDouble(FIC_2.From1次遅れDouble(NO3ETL循環タンクDATA.F3set, 1))
        '        'SENDDATA.WORD_SRS_PLC_CTR.FIC4_SV.FromDouble(FIC_4.From1次遅れDouble(NO4ETL循環タンクDATA.F4set, 1))
        '        'SENDDATA.WORD_SRS_PLC_CTR.FIC7_SV.FromDouble(FIC_7.From1次遅れDouble(溶解槽DATA.Faset, 1))
        '        'SENDDATA.WORD_SRS_PLC_CTR.FIC8_SV.FromDouble(FIC_8.From1次遅れDouble(溶解槽DATA.Fbset, 1))

        '        ''2015/02/28 改修
        '        ''SENDDATA.WORD_SRS_PLC_CTR.FIC10_SV.FromDouble(FIC_10.From1次遅れDouble(DISCOMBSCH.O2SET, 1))
        '        ''If RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToDouble() > 0.6 Then
        '        ''    SENDDATA.WORD_SRS_PLC_CTR.FIC10_SV.FromDouble(FIC_10.From1次遅れDouble(DISCOMBSCH.O2SET, 1))
        '        ''Else
        '        ''    SENDDATA.WORD_SRS_PLC_CTR.FIC10_SV.FromDouble(0.0)
        '        ''End If
        '        ''2015/03/03 Rev2
        '        'If RECVDATA.WORD_PLC_SRS_CTR.溶解槽_槽内圧力.ToDouble > PARAMETER.Search("PL").設定値 Then
        '        '    SENDDATA.WORD_SRS_PLC_CTR.FIC10_SV.FromDouble(FIC_10.From1次遅れDouble(DISCOMBSCH.O2SET, 1))
        '        'Else
        '        '    SENDDATA.WORD_SRS_PLC_CTR.FIC10_SV.FromDouble(0.0)
        '        'End If


        '    Else
        '        '    FIC_2.From1次遅れDouble(RECVDATA.WORD_PLC_SRS_IND.FCV2_SV.ToDouble, 1)
        '        '    FIC_4.From1次遅れDouble(RECVDATA.WORD_PLC_SRS_IND.FCV4_SV.ToDouble, 1)
        '        '    FIC_7.From1次遅れDouble(RECVDATA.WORD_PLC_SRS_IND.FCV7_SV.ToDouble, 1)
        '        '    FIC_8.From1次遅れDouble(RECVDATA.WORD_PLC_SRS_IND.FCV8_SV.ToDouble, 1)
        '        '    FIC_10.From1次遅れDouble(RECVDATA.WORD_PLC_SRS_IND.FCV10_SV.ToDouble, 1)

        '        '    SENDDATA.WORD_SRS_PLC_CTR.FIC2_SV.Word = RECVDATA.WORD_PLC_SRS_IND.FCV2_SV.Word
        '        '    SENDDATA.WORD_SRS_PLC_CTR.FIC4_SV.Word = RECVDATA.WORD_PLC_SRS_IND.FCV4_SV.Word
        '        '    SENDDATA.WORD_SRS_PLC_CTR.FIC7_SV.Word = RECVDATA.WORD_PLC_SRS_IND.FCV7_SV.Word
        '        '    SENDDATA.WORD_SRS_PLC_CTR.FIC8_SV.Word = RECVDATA.WORD_PLC_SRS_IND.FCV8_SV.Word
        '        '    SENDDATA.WORD_SRS_PLC_CTR.FIC10_SV.Word = RECVDATA.WORD_PLC_SRS_IND.FCV10_SV.Word
        '    End If
        '    'SENDDATA.WORD_SRS_PLC_CTR.SRS_ALAM.From(ALAM.GetAlam(), 1.0)
        '    'SENDDATA.WORD_SRS_PLC_TREND.No3_錫消費量.FromDouble(ETLTANK.No3_Sn)
        '    'SENDDATA.WORD_SRS_PLC_TREND.No4_錫消費量.FromDouble(ETLTANK.No4_Sn)
        '    'If DISCOMBSCH.Dissolution.Count > 0 Then
        '    '    SENDDATA.WORD_SRS_PLC_TREND.No3_錫溶解量.FromDouble(DISCOMBSCH.Dissolution(0).S1_NO3)
        '    '    SENDDATA.WORD_SRS_PLC_TREND.No4_錫溶解量.FromDouble(DISCOMBSCH.Dissolution(0).S1_NO4)
        '    '    SENDDATA.WORD_SRS_PLC_TREND.合算_錫溶解量.FromDouble(DISCOMBSCH.Dissolution(0).S1)
        '    'Else
        '    '    SENDDATA.WORD_SRS_PLC_TREND.No3_錫溶解量.FromDouble(0.0)
        '    '    SENDDATA.WORD_SRS_PLC_TREND.No4_錫溶解量.FromDouble(0.0)
        '    '    SENDDATA.WORD_SRS_PLC_TREND.合算_錫溶解量.FromDouble(0.0)

        '    'End If

        '    'SENDDATA.WORD_SRS_PLC_TREND.No3_循環_COND_PV.FromDouble(RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.ToDouble)
        '    'SENDDATA.WORD_SRS_PLC_TREND.No4_循環_COND_PV.FromDouble(RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.ToDouble)
        '    'SENDDATA.WORD_SRS_PLC_TREND.No3_循環_TL_PV.FromDouble(RECVDATA.WORD_PLC_SRS_CTR.No3_循環_TL_PV.ToDouble)
        '    'SENDDATA.WORD_SRS_PLC_TREND.No4_循環_TL_PV.FromDouble(RECVDATA.WORD_PLC_SRS_CTR.No4_循環_TL_PV.ToDouble)
        '    'SENDDATA.WORD_SRS_PLC_TREND.溶解槽_酸素吹き込み量_PV.FromDouble(RECVDATA.WORD_PLC_SRS_CTR.FCV10_PV.ToDouble)
        '    'SENDDATA.WORD_SRS_PLC_TREND.溶解槽_槽内差圧_PV.FromDouble(RECVDATA.WORD_PLC_SRS_CTR.溶解槽_錫槽内差圧_PV.ToDouble)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_酸素吹き込み量_SV.FromDouble(DISCOMBSCH.O2SET)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_操業時間.FromDouble(Fix(SYSTEMCONDITION.ETL操業時間.TotalHours))
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_時刻_時.FromDouble(nowtime.Hour)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_時刻_分.FromDouble(nowtime.Minute)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_稼働時間.FromDouble(Fix(SYSTEMCONDITION.システム稼働時間.TotalHours))
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_ｽﾗｯｼﾞ発生率.FromDouble(DISCOMBSCH.SL)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_稼働率.FromDouble(SYSTEMCONDITION.稼働率)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_S1set.FromDouble(DISCOMBSCH.S1SET)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_合算溶解補正量.FromDouble(DISCOMBSCH.SdS1)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No3_FLOW_H.FromDouble(NO3ETL循環タンクDATA.dF3H)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No4_FLOW_H.FromDouble(NO4ETL循環タンクDATA.dF4H)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No3_FLOW_L.FromDouble(NO3ETL循環タンクDATA.dF3L)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No4_FLOW_L.FromDouble(NO4ETL循環タンクDATA.dF4L)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_StA_H.FromDouble(DISCOMBSCH.dS1a)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_StA_HH.FromDouble(DISCOMBSCH.dS1b)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_StA_L.FromDouble(DISCOMBSCH.dS1c)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_StA_LL.FromDouble(DISCOMBSCH.dS1d)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No3_H.FromDouble(DISCOMBSCH.dS1e)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No3_L.FromDouble(DISCOMBSCH.dS1f)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No4_H.FromDouble(DISCOMBSCH.dS1g)
        '    'SENDDATA.WORD_SRS_PLC_TREND.SRS_No4_L.FromDouble(DISCOMBSCH.dS1h)

        'Catch ex As Exception
        '    e.etype = TaskEventArgs.EventType.SRS_演算エラー
        '    e.ex = ex
        '    'ALAM.Trigger(ALAM.ALAMNO.CALC_ERROR, True)
        'End Try

        For I = 0 To etlnum '（I=0:No3,I=1:No4)
            ETLPRODSCHS(I).TA = TA(I).TotalMinutes()
            ETLPRODSCHS(I).TZ0 = TZ0(I).TotalMinutes()
            ETLPRODSCHS(I).TE0 = TE0(I).TotalMinutes()
            ETLPRODSCHS(I).TAC = TAC(I).TotalMinutes()
            ETLPRODSCHS(I).TR = TR(I).TotalMinutes()
            ETLPRODSCHS(I).TZ0 = TZ0(I).TotalMinutes()
            ETLPRODSCHS(I).ライン停止時間 = TR(I).TotalMinutes
            'ETLPRODSCHS(I).制御実績時間 = TAC(I).TotalMinutes
            ETLPRODSCHS(I).Updated()
        Next

        'SYSTEMCONDITION.OverflowCheck()
        'CHECKVARIABLE.Store()
        'If CHECKVARIABLE.Transition Or linecondition(0) <> prevlinecondition(0) Or linecondition(1) <> prevlinecondition(1) Then
        '    'PV値,SV値確認用ログ
        '    PVSVLog.Logging()
        'End If
        If DEBUG.Flag Then
            If DEBUG.AutoCoilChange Then
                If ETLPRODSCHS(0).Products.Count > 0 AndAlso ETLPRODSCHS(0).Products(0).Tw <= 0 Then
                    If CSINFO.Connect() = 0 Then
                        If COIL_REJECT_FLAG = False Then
                            If CSINFO.SendRejectMessage() = CoilSchdule.CS_REJECTED Then
                                DEBUG.SnapShotTrigger = True
                                COIL_REJECT_FLAG = True
                                COIL_REJECT_TIME = DateTime.Now
                            End If
                        Else
                            COIL_REJECT_FLAG = (DateTime.Now - COIL_REJECT_TIME).TotalSeconds() < 60
                        End If
                    End If
                End If
            End If
        End If

        'If DEBUG.Flag Then
        '    If DEBUG.AutoCoilChange And interlock Then
        '        For I = 0 To 1
        '            If ETLPRODSCHS(I).Products.Count > 0 AndAlso ETLPRODSCHS(I).Products(0).Tw <= 0 Then
        '                ETLPRODSCHS(I).Products.RemoveAt(0)
        '                DEBUG.SnapShotTrigger = True
        '                'Dim J As Integer
        '                'Dim sch = RECVDATA.WORD_PLC_SRS_SCHS(I).Products(0)
        '                'For J = 1 To RECVDATA.WORD_PLC_SRS_SCHS(I).Products.Count - 1
        '                'RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J - 1) = RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J)
        '                'Next
        '                'RECVDATA.WORD_PLC_SRS_SCHS(I).Products(J - 1) = sch
        '            End If
        '        Next
        '    End If
        'End If
        If DEBUG.Logging Then
            デバッグ出力(0)
            '            デバッグ出力(1)
        End If

        prev_StA濃度測定完了 = RECVDATA.BIT_PLC_SRS_M8000.CIR_TANK
        'prev_No3濃度測定完了 = RECVDATA.BIT_PLC_SRS_IND.No3_循環濃度測定完了
        'prev_No4濃度測定完了 = RECVDATA.BIT_PLC_SRS_IND.No4_循環濃度測定完了

        lineconditionchange(0) = prevlinecondition(0) <> linecondition(0)
        'lineconditionchange(1) = prevlinecondition(1) <> linecondition(1)
        interlockchange = previnterlock <> interlock

        previnterlock = interlock
        prevlinecondition(0) = linecondition(0)
        'prevlinecondition(1) = linecondition(1)

        RECVDATA.WORD_PLC_SRS_SCHS(0).TopCoilChange = False
        'RECVDATA.WORD_PLC_SRS_SCHS(1).TopCoilChange = False
        If e.etype = TaskEventArgs.EventType.SRS_演算完了 Then
            ALAM.Trigger(ALAM.ALAMNO.CALC_ERROR, False)
        Else
            ALAM.Trigger(ALAM.ALAMNO.CALC_ERROR, True)
        End If
        Run = e
        Notify(e)
    End Function

    Private Sub 生産スケジュールセット(eno, スケジュール更新フラグ, スケジュール更新内容)
        '生産スケジュールのTw,Tz,Sn,Te,S,S1を計算する
        'If スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭ロット更新 Or スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_その他 Then
        Dim top_sch As ProductData

        If スケジュール更新フラグ(eno) Then
            If ETLPRODSCHS(eno).Products.Count > 0 Then
                top_sch = ETLPRODSCHS(eno).Products(0)
                ETLPRODSCHS(eno).Products.Clear()
            Else
                top_sch.No = ""
            End If

            Dim Idx As Integer = 0
            For Each in_sch In RECVDATA.WORD_PLC_SRS_SCHS(eno).Products
                Dim out_sch As ProductData
                '先頭コイル変更の判定
                If Idx > 0 Or (Idx = 0 And (スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭ロット更新 Or StrComp(top_sch.No, in_sch.No) <> 0)) Then
                    'ロットデータのコピー
                    out_sch.Idx = Idx
                    out_sch.No = in_sch.No
                    out_sch.TPH = in_sch.TPH
                    out_sch.Width = in_sch.Width
                    out_sch.Weight = in_sch.Weight
                    out_sch.Weight_bk = in_sch.Weight.ToDouble()
                    out_sch.Thickness = in_sch.Thickness
                    out_sch.Coating = in_sch.Coating
                    'If Idx = 0 Then
                    '先頭コイルの重量が変わった時の処理のための準備
                    'If スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭ロット更新 Or スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_その他 Then
                    '    'out_sch.Weight_bk = out_sch.Weight.ToFloat
                    '    topcoilweight(eno) = out_sch.Weight.ToDouble
                    '    'End If
                    'End If
                    'End If
                Else
                    out_sch = top_sch
                    out_sch.Weight_bk = in_sch.Weight.ToDouble()
                End If
                ETLPRODSCHS(eno).Products.Add(out_sch)
                Idx = Idx + 1
            Next
        End If
    End Sub


    Private Sub 生産スケジュール演算(eno, スケジュール更新内容)
        Dim lotcount As Integer = 0
        Dim qry_tens As New List(Of Integer)
        Dim qty_tens

        For lotcount = 0 To ETLPRODSCHS(eno).Products.Count - 1
            Dim out_sch As ProductData = ETLPRODSCHS(eno).Products(lotcount)
            Dim L As Double 'ロット長さ
            Dim LS As Double 'ラインスピードmpm
            'If lotcount = 0 Then
            '    out_sch.Thickness.FromDouble(RECVDATA.WORD_PLC_SRS_D5000.STRIP_THICKNESS.ToDouble() / 1000)
            '    out_sch.Width.FromDouble(RECVDATA.WORD_PLC_SRS_D5000.STRIP_WIDTH.ToDouble())
            '    out_sch.Coating.FromDouble(1000 * (RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_FRONT.ToDouble() + RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_BACK.ToDouble()))

            'End If
            ''生産スケジュールのデータの生成(データ受信時か最初のロットの時）
            '1)生産時間tw演算:out_sch.Tw = 重量 / TPH * 60 + (TA-TASH)*(lotcount=0)
            'If スケジュール更新フラグ(eno) = True Or lotcount = 0 Then
            'If スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭コイル更新 Then
            'If lotcount = 0 Then
            '    out_sch.Tw = topcoilweight(eno) / (out_sch.TPH.ToDouble() / 60) + (TA(eno) - TASH(eno)).TotalMinutes() * (lotcount = 0)
            'Else
            out_sch.Tw = out_sch.Weight.ToDouble() / (out_sch.TPH.ToDouble() / 60) + (TA(eno) - TASH(eno)).TotalMinutes() * (lotcount = 0)

            'End If

            If out_sch.Tw < 0 Then out_sch.Tw = 0
            'コイル長LとTPHからのライン速度を逆算してからSnを求める
            ' L=Wt/(7.85(t/m3)*W(mm)*TH(mm)/1000^2)
            ' LS=L/(Wt/(TPH/60)) 
            L = out_sch.Weight.ToDouble() / (7.85 * out_sch.Width.ToDouble() * out_sch.Thickness.ToDouble() / 1000 ^ 2)
            'LS = L / (out_sch.Weight.ToFloat() / (out_sch.TPH.ToFloat() / 60))
            LS = out_sch.TPH.ToDouble() * 1000 ^ 2 / 60 / 7.85 / out_sch.Thickness.ToDouble() / out_sch.Width.ToDouble()
            '2)錫消費量Sn演算:out_sch.SN = A(mg/m2)*W(mm)/1000*L(m) 
            out_sch.LS = LS
            out_sch.Sn = (out_sch.Coating.ToDouble() / 1000.0 ^ 2) * out_sch.Width.ToDouble() / 1000.0 * LS * 60
            If lotcount > 0 Then
                '3-2)管理時間tz演算2段目～:out_sch.Tz = tz(min)=tz-1(min)+tw-1(min)
                out_sch.Tz = ETLPRODSCHS(eno).Products(lotcount - 1).Tz + ETLPRODSCHS(eno).Products(lotcount - 1).Tw
            Else
                '3-1)管理時間tz演算1段目:out_sch.Tz = ta(min)+tz0(min)
                out_sch.Tz = (TA(eno) + TZ0(eno)).TotalMinutes
            End If
            'End If
            '5)錫必要量(S)演算（スラッジ自動中常に演算）:out_sch.S(kg)=Sn(kg/h)*tw(min)/60
            '1段目のtwが自動中に常に変化するため自動中は常に計算する。
            If lotcount = 0 Then
                Dim tw = (out_sch.Weight.ToDouble() / (out_sch.TPH.ToDouble() / 60)) / 60
                If スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭ロット更新 Then
                    S_Pre(eno) = out_sch.Sn * out_sch.Tw / 60
                    SnPre(eno) = out_sch.Sn
                    S_Pre1(eno) = S_Pre(eno)
                    S_Init(eno) = out_sch.Sn * tw
                ElseIf スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭コイル更新 Then
                    S_Pre(eno) = S_Pre(eno) + (out_sch.Sn * (out_sch.Tw) / 60 - S_Pre1(eno))
                End If
                out_sch.S = S_Pre(eno)
                If linecondition(eno) Then
                    S_Pre(eno) = S_Pre(eno) - out_sch.Sn * scantime.TotalHours
                End If
                If S_Pre(eno) < 0 Then S_Pre(eno) = 0
            Else
                out_sch.S = out_sch.Sn * out_sch.Tw / 60
            End If
            '            out_sch.S1 = 0
            ETLPRODSCHS(eno).Products(lotcount) = out_sch
        Next

        'te1～tenを仮決定する
        Dim ten As Integer = 0
        For lotcount = 1 To ETLPRODSCHS(eno).Products.Count - 1
            Dim out_sch As ProductData = ETLPRODSCHS(eno).Products(lotcount)
            'Single型での精度誤差を避けるため比較は表示精度(0.01単位）で行う
            '            If Fix(out_sch.Sn * 100 - ETLPRODSCHS(eno).Products(lotcount - 1).Sn * 100) < 0 Or lotcount = ETLPRODSCHS(eno).Products.Count - 1 Then
            If Fix(out_sch.Sn * 100 - ETLPRODSCHS(eno).Products(lotcount - 1).Sn * 100) < 0 Then
                ten = ten + 1
                out_sch.Te = ten
            Else
                out_sch.Te = 0
            End If
            ETLPRODSCHS(eno).Products(lotcount) = out_sch
        Next
        Dim findten As Boolean
        Do
            findten = False
            'ten+1以降でtenより高い山があればそこをtenに置き換える
            qty_tens = From sch In ETLPRODSCHS(eno).Products
                           Where sch.Te > 0
                           Select sch.Idx
            qry_tens.Clear()
            For Each ten In qty_tens
                If ten = 1 OrElse (Fix(ETLPRODSCHS(eno).Products(ten - 1).Sn * 100 - ETLPRODSCHS(eno).Products(ten).Sn * 100) > 0) Then
                    qry_tens.Add(ten)
                End If
            Next

            For lotcount = 1 To qry_tens.Count - 1
                Dim ta = qry_tens(lotcount) - 1
                Dim tb = qry_tens(lotcount - 1) - 1
                If (ta >= 0 And tb >= 0) Then
                    If Fix(ETLPRODSCHS(eno).Products(ta).Sn * 100 - ETLPRODSCHS(eno).Products(tb).Sn * 100) > 0 Then
                        '新しい山に古い山を統合する
                        Dim sch
                        'For lc2 = lotcount To qry_tens.Count - 1
                        '    sch = ETLPRODSCHS(eno).Products(qry_tens(lc2))
                        '    sch.Te = sch.Te - 1
                        '    ETLPRODSCHS(eno).Products(qry_tens(lc2)) = sch
                        'Next
                        sch = ETLPRODSCHS(eno).Products(qry_tens(lotcount - 1))
                        sch.Te = -sch.Te
                        ETLPRODSCHS(eno).Products(qry_tens(lotcount - 1)) = sch
                        findten = True
                    End If
                End If
            Next
        Loop While findten

        qty_tens = From sch In ETLPRODSCHS(eno).Products
                           Where sch.Te > 0
                           Select sch.Idx
        qry_tens.Clear()
        For Each ten In qty_tens
            qry_tens.Add(ten)
        Next
        prev_endten(eno) = endten(eno)
        prev_endno(eno) = endno(eno)
        If qry_tens.Count > 0 Then
            'コントロールエンド位置
            endten(eno) = qry_tens(0)
            endno(eno) = ETLPRODSCHS(eno).Products(endten(eno)).No
        Else
            endten(eno) = ETLPRODSCHS(eno).Products.Count
            endno(eno) = "0"
        End If
        If (スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭ロット更新 And prev_endno(eno) > 0 And (prev_endno(eno) <> endno(eno) Or prev_endten(eno) = 1 And (prev_endno(eno) = eno * 100000 Or endten(eno) > prev_endten(eno)))) Then
            Call コントロールエンド処理(eno)
        End If
    End Sub
    Sub コントロールエンド処理(I As Integer)
        TA(I) = TimeSpan.Zero
        TAC(I) = TimeSpan.Zero
        TASH(I) = TimeSpan.Zero
        TR(I) = TimeSpan.Zero
        TZ0(I) = TimeSpan.Zero
        TZ0P(I) = TimeSpan.Zero
        TE0(I) = TimeSpan.Zero
        '相手方の処理
        TAC(1 - I) = TAC(1 - I) - TR(1 - I)
        TE0(1 - I) = TE0(1 - I) - TA(1 - I)
        TA(1 - I) = TA(1 - I) - TASH(1 - I)
        TZ0(1 - I) = -TA(1 - I)
        'TE0(1 - I) = TE0(1 - I) - TASH(1 - I)
        'TE0(1 - I) = TASH(1 - I) - TAC(1 - I) + TR(I - 1)
        'TE0(1 - I) = -TASH(1 - I) + TR(I - 1)
        'TE0(1 - I) = -TAC(1 - I) + TA(1 - I) + TR(I - 1)
        TASH(1 - I) = TimeSpan.Zero
        TZ0P(1 - I) = TZ0(1 - I)
        'TE0(1 - I) = -TAC(1 - I) + (-TZ0(1 - I))
        TR(1 - I) = TimeSpan.Zero
        For K = 0 To 0
            ETLPRODSCHS(K).制御実績時間 = 0
            Dim zz = 0
            For lotcount = 0 To ETLPRODSCHS(K).Products.Count - 1
                Dim out_sch As ProductData = ETLPRODSCHS(K).Products(lotcount)
                If lotcount = 0 Then
                    'zz = out_sch.Tz
                    out_sch.Tz = (TA(K) + TZ0(K)).TotalMinutes
                Else
                    out_sch.Tz = ETLPRODSCHS(K).Products(lotcount - 1).Tz + ETLPRODSCHS(K).Products(lotcount - 1).Tw
                End If
                ETLPRODSCHS(K).Products(lotcount) = out_sch
            Next
        Next

        ETLPRODSCHS(I).Sf = 0
        ETLPRODSCHS(I).S1p = 0
        ETLPRODSCHS(I).S1f = 0
        ETLPRODSCHS(I).dS1x = 0
        compS(I) = 0
        compE(I) = 0
        compInit(I) = True
        If endten(I) = -1 Then
            endten(I) = 0
        End If

    End Sub
    Sub デバッグ出力(eno As Integer, Optional init As Boolean = False)
        Try
            Dim logdatestr As String = DateTime.Now.ToString("yyyyMMdd")
            Dim dbfile = "C:\DATASTRAGE\" & logdatestr & "_No" & (eno + 3) & "Debug.csv"

            If My.Computer.FileSystem.FileExists(dbfile) = False Then
                Using sw As New StreamWriter(dbfile, False, Encoding.Default)
                    sw.WriteLine("時刻,SRS_ON,ライン運転中,スケジュール更新フラグ(No3),スケジュール更新フラグ(No4),TAC,TA,TASH,TZ0,TR,TW(1),TZ(1),TE0,twsum,Sf,S(1),S1(1),S1f,S1p,ΔS1x")
                End Using
            Else
                If (ETLPRODSCHS(eno).Products.Count > 0) Then
                    Using sw As New StreamWriter(dbfile, True, Encoding.Default)
                        sw.Write(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                        sw.Write("," & interlock * (-1))
                        sw.Write("," & linecondition(eno) * (-1))
                        sw.Write("," & スケジュール更新フラグ(0) * (-1))
                        sw.Write("," & スケジュール更新フラグ(1) * (-1))
                        sw.Write("," & TAC(eno).TotalMinutes)
                        sw.Write("," & TA(eno).TotalMinutes)
                        sw.Write("," & TASH(eno).TotalMinutes)
                        sw.Write("," & TZ0(eno).TotalMinutes)
                        sw.Write("," & TR(eno).TotalMinutes)
                        sw.Write("," & ETLPRODSCHS(eno).Products(0).Tw)
                        sw.Write("," & ETLPRODSCHS(eno).Products(0).Tz)
                        sw.Write("," & TE0(eno).TotalMinutes)
                        sw.Write("," & twsums(eno))
                        sw.Write("," & ETLPRODSCHS(eno).Sf)
                        sw.Write("," & ETLPRODSCHS(eno).Products(0).S)
                        sw.Write("," & ETLPRODSCHS(eno).Products(0).S1)
                        sw.Write("," & ETLPRODSCHS(eno).S1f)
                        sw.Write("," & ETLPRODSCHS(eno).S1p)
                        sw.Write("," & ETLPRODSCHS(eno).dS1x)
                        sw.WriteLine()
                    End Using
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Sub 生産スケジュールトレンド(eno)
        Dim 錫消費SCH As New List(Of System.Drawing.PointF)
        Dim 錫溶解SCH As New List(Of System.Drawing.PointF)
        Dim Tz As Double = 0.0
        Dim KeepY As Double = 0.0
        For lotcount = 0 To ETLPRODSCHS(eno).Products.Count - 1
            Dim grppt1 As System.Drawing.PointF
            Dim grppt2 As System.Drawing.PointF
            Dim out_sch As ProductData = ETLPRODSCHS(eno).Products(lotcount)
            If (lotcount = 0) Then
                Tz = out_sch.Tz
            End If
            grppt1.X = out_sch.Tz - Tz
            grppt1.Y = out_sch.Sn
            錫消費SCH.Add(grppt1)
            grppt2.X = grppt1.X + out_sch.Tw
            grppt2.Y = out_sch.Sn
            錫消費SCH.Add(grppt2)
        Next

        For lotcount = 0 To ETLPRODSCHS(eno).Products.Count - 1
            Dim grppt1 As System.Drawing.PointF
            Dim grppt2 As System.Drawing.PointF
            Dim out_sch As ProductData = ETLPRODSCHS(eno).Products(lotcount)
            If (lotcount = 0) Then
                KeepY = out_sch.S1
                Tz = out_sch.Tz
            End If
            grppt1.X = out_sch.Tz - Tz
            If out_sch.Te > 0 Then
                grppt1.Y = out_sch.S1
            Else
                grppt1.Y = KeepY
            End If
            錫溶解SCH.Add(grppt1)
            grppt2.X = grppt1.X + out_sch.Tw
            If out_sch.Te > 0 Then
                grppt2.Y = out_sch.S1
            Else
                grppt2.Y = KeepY
            End If
            錫溶解SCH.Add(grppt2)
            KeepY = grppt2.Y
        Next

        '        grppt.Y = out_sch.S1
        '        錫溶解SCH.Add(grppt)

        If eno = 0 Then
            TRENDGRAPHDATA.NO3錫消費SCH = 錫消費SCH
            TRENDGRAPHDATA.NO3錫溶解SCH = 錫溶解SCH
        Else
            TRENDGRAPHDATA.NO4錫消費SCH = 錫消費SCH
            TRENDGRAPHDATA.NO4錫溶解SCH = 錫溶解SCH
        End If

    End Sub

    Sub 溶解スケジュール演算(eno, スケジュール更新内容, scantime)

        Dim ten_pos As Integer = 0
        Dim ten As Integer = 0
        Dim ten1_pos As Integer = 0
        Dim SigmaS As Double = 0
        Dim sch As ProductData
        'If スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭ロット更新 Or スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_その他 Or compInit(eno) Then
        If スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭ロット更新 Or compInit(eno) Then
            compInit(eno) = False
            compE(eno) = compE(eno) + compS(eno)
            compS(eno) = ETLPRODSCHS(eno).Products(0).Sn * ETLPRODSCHS(eno).Products(0).Tw / 60
            'S_Pre(eno) = ETLPRODSCHS(eno).Products(0).Sn
        End If
        'If スケジュール更新内容(eno) = スケジュール変更ステータス.SCH_先頭コイル更新 Then
        'S_Pre(eno) = S_Pre(eno) + (ETLPRODSCHS(eno).Products(0).Sn - S_Pre(eno))
        'End If
        ETLPRODSCHS(eno).Sf = compS(eno) - ETLPRODSCHS(eno).Products(0).S + compE(eno)
        'ETLPRODSCHS(eno).Sf = compS(eno) + compE(eno)
        'If linecondition(eno) And ETLPRODSCHS(eno).Products(0).Tw > 0 Then
        '    compS(eno) = compS(eno) + ETLPRODSCHS(eno).Products(0).Sn * scantime.TotalHours()
        'End If

        'If linecondition(eno) Then
        Dim s1 As Double
        Dim twsum = ETLPRODSCHS(eno).Products(0).Tz + ETLPRODSCHS(eno).Products(0).Tw - TE0(eno).TotalMinutes - TR(eno).TotalMinutes
        SigmaS = ETLPRODSCHS(eno).Sf + ETLPRODSCHS(eno).Products(0).S
        ten_pos = 0
        For lotcount = 1 To ETLPRODSCHS(eno).Products.Count - 1
            If ETLPRODSCHS(eno).Products(lotcount).Te > 0 Then
                sch = ETLPRODSCHS(eno).Products(ten_pos)
                If linecondition(eno) = False And ten_pos = 0 Then
                    sch.S1 = 0
                Else
                    sch.S1 = SigmaS * 60 / twsum
                End If
                ETLPRODSCHS(eno).Products(ten_pos) = sch
                If ten_pos = 0 Then
                    s1 = SigmaS * 60 / twsum
                End If
                ten_pos = lotcount
                SigmaS = 0
                twsum = 0
            End If
            SigmaS = SigmaS + ETLPRODSCHS(eno).Products(lotcount).S
            twsum = twsum + ETLPRODSCHS(eno).Products(lotcount).Tw
        Next
        twsums(eno) = twsum
        Dim DS1F As Double
        sch = ETLPRODSCHS(eno).Products(ten_pos)
        If ten_pos = 0 Then
            s1 = SigmaS * 60 / twsum
        End If
        If linecondition(eno) = False And ten_pos = 0 Then
            sch.S1 = 0
        Else
            sch.S1 = SigmaS * 60 / twsum
        End If
        ETLPRODSCHS(eno).Products(ten_pos) = sch

        'If RECVDATA.BIT_PLC_SRS_CTR.溶解槽_錫投入中 Then
        'DS1F = 0
        'Else
        DS1F = (ETLPRODSCHS(eno).Products(0).S1 + ETLPRODSCHS(eno).dS1x) * scantime.TotalHours()
        'End If
        ETLPRODSCHS(eno).S1p = s1 * (TAC(eno) - TR(eno)).TotalHours
        ETLPRODSCHS(eno).S1f = ETLPRODSCHS(eno).S1f + DS1F

    End Sub
    Sub 溶解スケジュール集計(linecondition)
        Dim qry_tens As New List(Of Integer)
        Dim DisSortList As New List(Of DisSortItem)
        Dim O2 As Double
        Dim O2D As Double
        Dim SL As Double
        DisSortList.Clear()
        For I = 0 To 1
            If ETLPRODSCHS(I).Products.Count > 0 Then
                Dim qty_tens = From sch In ETLPRODSCHS(I).Products
                                   Where sch.Te > 0
                                   Select sch.Idx
                qry_tens.Clear()
                qry_tens.Add(0)
                For Each ten In qty_tens
                    qry_tens.Add(ten)
                Next
                For J = 1 To qry_tens.Count - 1
                    Dim ditem As New DisSortItem With {.eno = I, .Tz = ETLPRODSCHS(I).Products(qry_tens(J)).Tz, .S1 = ETLPRODSCHS(I).Products(qry_tens(J)).S1}
                    DisSortList.Add(ditem)
                Next
            End If
        Next
        'Tz順にソート
        DisSortList.Sort(AddressOf DisSortItem.Comparison)
        '先頭の溶解データ作成
        Dim top As DisCombData
        If ETLPRODSCHS(0).Products.Count > 0 Then
            top.S1_NO3 = ETLPRODSCHS(0).Products(0).S1
            top.Tz = ETLPRODSCHS(0).Products(0).Tz
        Else
            top.S1_NO3 = 0
        End If
        If ETLPRODSCHS(1).Products.Count > 0 Then
            top.S1_NO4 = ETLPRODSCHS(1).Products(0).S1
            top.Tz = ETLPRODSCHS(1).Products(0).Tz
        Else
            top.S1_NO4 = 0
        End If
        top.S1 = top.S1_NO3 + top.S1_NO4
        O2D = 酸素吹込量とスラッジ発生率演算(top.S1, O2, SL, True, False)
        top.O2 = O2D
        top.SL = SL
        DISCOMBSCH.Dissolution.Clear()
        DISCOMBSCH.Dissolution.Add(top)
        '2番目以降の溶解データ作成
        For Each ditem In DisSortList
            top.Tz = ditem.Tz
            If ditem.eno = 0 Then
                top.S1_NO3 = ditem.S1
            Else
                top.S1_NO4 = ditem.S1
            End If
            top.S1 = top.S1_NO3 + top.S1_NO4
            O2D = 酸素吹込量とスラッジ発生率演算(top.S1, O2, SL, True, False)
            top.O2 = O2D
            top.SL = SL
            DISCOMBSCH.Dissolution.Add(top)
        Next
        If DISCOMBSCH.Dissolution.Count > 0 Then
            DISCOMBSCH.S1s = DISCOMBSCH.Dissolution(0).S1
        End If
    End Sub
    Sub 溶解スケジュールトレンド()
        Dim 錫溶解SCH As New List(Of System.Drawing.PointF)
        Dim O2SCH As New List(Of System.Drawing.PointF)
        Dim SLSCH As New List(Of System.Drawing.PointF)
        Dim Tz = 0
        Dim TW As New List(Of Single)
        If DISCOMBSCH.Dissolution.Count > 0 Then
            For lotcount = 0 To DISCOMBSCH.Dissolution.Count - 1
                Dim out_sch As DisCombData = DISCOMBSCH.Dissolution(lotcount)
                If lotcount = 0 Then
                    TW.Add(0)
                End If
                If lotcount > 0 Then
                    TW.Add(out_sch.Tz)
                End If
                If lotcount = DISCOMBSCH.Dissolution.Count - 1 Then
                    '2015/4/9追加
                    '溶解スケジュールが複数の場合の最後の制御区間終了時刻を求める処理
                    Dim eten As Integer, Tz3 As Double, Tz4 As Double
                    If ETLPRODSCHS(0).Products.Count > 0 Then
                        eten = ETLPRODSCHS(0).Products.Count - 1
                        Tz3 = ETLPRODSCHS(0).Products(eten).Tz + ETLPRODSCHS(0).Products(eten).Tw
                    End If
                    If ETLPRODSCHS(1).Products.Count > 0 Then
                        eten = ETLPRODSCHS(1).Products.Count - 1
                        Tz4 = ETLPRODSCHS(1).Products(eten).Tz + ETLPRODSCHS(1).Products(eten).Tw
                    End If
                    Tz = Math.Max(Tz3, Tz4)
                    TW.Add(Tz)
                End If

            Next
        ElseIf DISCOMBSCH.Dissolution.Count = 1 Then
            'Dim eten As Integer, Tz3 As Double, Tz4 As Double
            'If ETLPRODSCHS(0).Products.Count > 0 Then
            '    eten = ETLPRODSCHS(0).Products.Count - 1
            '    Tz3 = ETLPRODSCHS(0).Products(eten).Tz + ETLPRODSCHS(0).Products(eten).Tw
            'End If
            'If ETLPRODSCHS(1).Products.Count > 0 Then
            '    eten = ETLPRODSCHS(1).Products.Count - 1
            '    Tz4 = ETLPRODSCHS(1).Products(eten).Tz + ETLPRODSCHS(1).Products(eten).Tw
            'End If
            'Dim out_sch As DisCombData = DISCOMBSCH.Dissolution(0)
            'Tz = Math.Max(Tz3, Tz4)
            'TW.Add(0)
            'TW.Add(Tz)
        End If

        For lotcount = 0 To TW.Count - 2
            Dim out_sch As DisCombData = DISCOMBSCH.Dissolution(lotcount)
            Dim grppt As System.Drawing.PointF
            grppt.X = TW(lotcount)
            grppt.Y = out_sch.S1
            錫溶解SCH.Add(grppt)
            grppt.Y = out_sch.O2
            O2SCH.Add(grppt)
            grppt.Y = out_sch.SL
            SLSCH.Add(grppt)
            grppt.X = TW(lotcount + 1)
            grppt.Y = out_sch.S1
            錫溶解SCH.Add(grppt)
            grppt.Y = out_sch.O2
            O2SCH.Add(grppt)
            grppt.Y = out_sch.SL
            SLSCH.Add(grppt)
        Next
        TRENDGRAPHDATA.錫溶解SCH = 錫溶解SCH
        TRENDGRAPHDATA.O2SCH = O2SCH
        TRENDGRAPHDATA.SLSCH = SLSCH

    End Sub



    Sub 錫溶解補正量ΔS1x演算(eno, linecondition)

        If linecondition(eno) AndAlso ETLPRODSCHS(eno).Products.Count > 0 Then
            Dim eten = endten(eno)
            Dim disstime As Double
            If eten < ETLPRODSCHS(eno).Products.Count Then
                disstime = ETLPRODSCHS(eno).Products(eten).Tz - ETLPRODSCHS(eno).制御実績時間
            Else
                eten = ETLPRODSCHS(eno).Products.Count - 1
                disstime = ETLPRODSCHS(eno).Products(eten).Tz + ETLPRODSCHS(eno).Products(eten).Tw - ETLPRODSCHS(eno).制御実績時間
            End If
            If disstime < 10 Then disstime = 10
            ETLPRODSCHS(eno).dS1x = (ETLPRODSCHS(eno).S1p - ETLPRODSCHS(eno).S1f) * 60 / disstime
        Else
            ETLPRODSCHS(eno).dS1x = 0.0
        End If
    End Sub

    Function 錫溶解補正量ΔS1a演算()
        '下記ΔＳ1aをＳ1から減じる。
        'ΔＳA = ＣAH・ＶA
        'ΔＳ1a = α1・ΔＳA / (tc1 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1a:   不足時溶解量補正値(kg / hr)
        'ＣA:     St.A濃度(g / L)
        'ＣAH:    濃度上限(g / L)
        'ＶA:     St.Aの容量(m3)
        'ｔc1:    濃度補正のための溶解補正時間(min)
        'α1:     補正係数()
        'Dim STA_COND = RECVDATA.WORD_PLC_SRS_CTR.StA_COND_PV.ToFloat()
        Dim STA_COND = ETLTANK_BAO.CIR_TANK.TI_CONC
        Dim CAH = PARAMETER.Search("CAdH").設定値
        Dim VA = ETLTANK_BAO.CIR_TANK.LEVEL
        Dim α1 = PARAMETER.Search("alpha1").設定値
        Dim TC1 = PARAMETER.Search("TC1").設定値
        錫溶解補正量ΔS1a演算 = 0.0

        If STA_COND > CAH Then
            Dim DSA = CAH * VA
            Dim DS1A = α1 * DSA / (TC1 / 60)
            錫溶解補正量ΔS1a演算 = -DS1A
        End If
        'If CHECKVARIABLE.OldData.StA_AVE.ToString <> Math.Round(STA_COND, 2).ToString Then
        '    PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, CAH, CAREF, STA_COND, VA, α1, TC1, 錫溶解補正量ΔS1a演算)
        'End If

        If Double.IsNaN(錫溶解補正量ΔS1a演算) Then
            Throw New DivideByZeroException
        End If

    End Function
    Function 錫溶解補正量ΔS1b演算() As Double
        '下記ΔＳ1bをＳ1から減じる。	
        'ΔＳA = ＣAHH・ＶA
        'ΔＳ1b = α2・ΔＳA / (tc2 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1b:   不足時溶解量補正値(kg / hr)
        'ＣA:     St.A濃度(g / L)
        'ＣAHH:   濃度上上限(g / L)
        'ＶA:     St.Aの容量(m3)
        'ｔc2:    濃度補正のための溶解補正時間(min)
        'α2:     補正係数()

        'Dim STA_COND = RECVDATA.WORD_PLC_SRS_CTR.StA_COND_PV.ToFloat()
        Dim STA_COND = ETLTANK_BAO.CIR_TANK.TI_CONC
        Dim CAHH = PARAMETER.Search("CAH").設定値
        Dim CAREF = 0 'PARAMETER.Search("CAREF").設定値
        Dim VA = ETLTANK_BAO.CIR_TANK.LEVEL
        Dim α2 = PARAMETER.Search("alpha2").設定値
        Dim TC2 = PARAMETER.Search("TC2").設定値

        錫溶解補正量ΔS1b演算 = 0.0
        If STA_COND > CAHH Then
            Dim DSA = CAHH * VA
            Dim DS1B = α2 * DSA / (TC2 / 60)
            錫溶解補正量ΔS1b演算 = -DS1B
        End If
        'If CHECKVARIABLE.OldData.StA_AVE.ToString <> Math.Round(STA_COND, 2).ToString Then
        '    PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, CAHH, CAREF, STA_COND, VA, α2, TC2, 錫溶解補正量ΔS1b演算)
        'End If

        If Double.IsNaN(錫溶解補正量ΔS1b演算) Then
            Throw New DivideByZeroException
        End If
    End Function
    Function 錫溶解補正量ΔS1c演算() As Double
        '下記ΔＳ1cをＳ1に加える。	
        'ΔＳA = ＣAL・ＶA
        'ΔＳ1c = α3・ΔＳA / (tc3 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1c:   不足時溶解量補正値(kg / hr)
        'ＣA:     St.A濃度(g / L)
        'ＣAL:    濃度下限(g / L)
        'ＶA:     St.Aの容量(m3)
        'ｔc3:    濃度補正のための溶解補正時間(min)
        'α3:     補正係数()

        'Dim STA_COND = RECVDATA.WORD_PLC_SRS_CTR.StA_COND_PV.ToFloat()
        Dim STA_COND = ETLTANK_BAO.CIR_TANK.TI_CONC
        Dim CAL = PARAMETER.Search("CAdL").設定値
        Dim VA = ETLTANK_BAO.CIR_TANK.LEVEL
        Dim α3 = PARAMETER.Search("alpha3").設定値
        Dim TC3 = PARAMETER.Search("TC3").設定値

        錫溶解補正量ΔS1c演算 = 0.0
        If STA_COND < CAL Then
            Dim DSA = CAL * VA
            Dim DS1C = α3 * DSA / (TC3 / 60)
            錫溶解補正量ΔS1c演算 = DS1C

        End If
        'If CHECKVARIABLE.OldData.StA_AVE.ToString <> Math.Round(STA_COND, 2).ToString Then
        '    PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, CAL, CAREF, STA_COND, VA, α3, TC3, 錫溶解補正量ΔS1c演算)
        'End If

        If Double.IsNaN(錫溶解補正量ΔS1c演算) Then
            Throw New DivideByZeroException
        End If
    End Function
    Function 錫溶解補正量ΔS1d演算() As Double
        '下記ΔＳ1dをＳ1に加える。	
        'ΔＳA = ＣALＬ・ＶA
        'ΔＳ1d = α4・ΔＳA / (tc4 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1d:   不足時溶解量補正値(kg / hr)
        'ＣA:     St.A濃度(g / L)
        'ＣAＬL:   濃度下下限(g / L)
        'ＶA:     St.Aの容量(m3)
        'ｔc4:    濃度補正のための溶解補正時間(min)
        'α4:     補正係数()
        'Dim STA_COND = RECVDATA.WORD_PLC_SRS_CTR.StA_COND_PV.ToFloat()
        Dim STA_COND = ETLTANK_BAO.CIR_TANK.TI_CONC
        Dim CAL_L = PARAMETER.Search("CAL").設定値
        Dim VA = ETLTANK_BAO.CIR_TANK.LEVEL
        Dim α4 = PARAMETER.Search("alpha4").設定値
        Dim TC4 = PARAMETER.Search("TC4").設定値

        錫溶解補正量ΔS1d演算 = 0.0
        If STA_COND < CAL_L Then
            Dim DSA = CAL_L * VA
            Dim DS1D = α4 * DSA / (TC4 / 60)
            錫溶解補正量ΔS1d演算 = DS1D

        End If
        'If CHECKVARIABLE.OldData.StA_AVE.ToString <> Math.Round(STA_COND, 2).ToString Then
        '    PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, CAL_L, CAREF, STA_COND, VA, α4, TC4, 錫溶解補正量ΔS1d演算)
        'End If

        If Double.IsNaN(錫溶解補正量ΔS1d演算) Then
            Throw New DivideByZeroException
        End If

    End Function
    Function 錫溶解補正量ΔS1e演算() As Double
        '下記ΔＳ1eをＳ1に加える。	
        'ΔＳA = Ｃ３ＯＨ・Ｖ３
        'ΔＳ1ｅ = α5・ΔＳA / (tc5 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1ｅ:   不足時溶解量補正量(kg / hr)
        'Ｃ３：NO.３ETL循環タンクの濃度(g/L)
        'Ｃ３ＯＨ:   濃度上限(g / L)
        'Ｖ３：NO.３ETL循環タンクの容量(m3)
        'ｔc5:    濃度補正のための溶解補正時間(min)
        'α5:     補正係数()
        'Dim NO3_COND = RECVDATA.WORD_PLC_SRS_CTR.No3_循環_CONC_PV.ToFloat()
        Dim NO3_COND = RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.ToDouble()
        Dim C3OH = PARAMETER.Search("C3OH").設定値
        Dim Cob3 = PARAMETER.Search("COB3").設定値
        Dim V3 = RECVDATA.WORD_PLC_SRS_CTR.No3_循環_TL_PV.ToDouble()
        Dim α5 = PARAMETER.Search("α5").設定値
        Dim TC5 = PARAMETER.Search("TC5").設定値

        錫溶解補正量ΔS1e演算 = 0.0
        If NO3_COND > Cob3 + C3OH Then
            Dim DSA = C3OH * V3
            Dim DS1E = α5 * DSA / (TC5 / 60)
            錫溶解補正量ΔS1e演算 = -DS1E

        End If
        If CHECKVARIABLE.OldData.No3_AVE.ToString <> Math.Round(NO3_COND, 2).ToString Then
            PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, C3OH, Cob3, NO3_COND, V3, α5, TC5, 錫溶解補正量ΔS1e演算)
        End If

        If Double.IsNaN(錫溶解補正量ΔS1e演算) Then
            Throw New DivideByZeroException
        End If
    End Function
    Function 錫溶解補正量ΔS1f演算() As Double
        '下記ΔＳ1ｆをＳ1に加える。	
        'ΔＳA = Ｃ３ＯＬ・Ｖ３
        'ΔＳ1ｆ = α6・ΔＳA / (tc6 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1ｆ:   不足時溶解量補正量(kg / hr)
        'Ｃ３：NO.３ETL循環タンクの濃度(g/L)
        'Ｃ３ＯＬ:   濃度下限(g / L)
        'Ｖ３：NO.３ETL循環タンクの容量(m3)
        'ｔc6:    濃度補正のための溶解補正時間(min)
        'α6:     補正係数()

        'Dim NO3_COND = RECVDATA.WORD_PLC_SRS_CTR.No3_循環_CONC_PV.ToFloat()
        Dim NO3_COND = RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.ToDouble()
        Dim C3OL = PARAMETER.Search("C3OL").設定値
        Dim Cob3 = PARAMETER.Search("COB3").設定値
        Dim V3 = RECVDATA.WORD_PLC_SRS_CTR.No3_循環_TL_PV.ToDouble()
        Dim α6 = PARAMETER.Search("α6").設定値
        Dim TC6 = PARAMETER.Search("TC6").設定値

        錫溶解補正量ΔS1f演算 = 0.0
        If NO3_COND < Cob3 - C3OL Then
            Dim DSA = C3OL * V3
            Dim DS1F = α6 * DSA / (TC6 / 60)
            錫溶解補正量ΔS1f演算 = DS1F

        End If
        If CHECKVARIABLE.OldData.No3_AVE.ToString <> Math.Round(NO3_COND, 2).ToString Then
            PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, C3OL, Cob3, NO3_COND, V3, α6, TC6, 錫溶解補正量ΔS1f演算)
        End If

        If Double.IsNaN(錫溶解補正量ΔS1f演算) Then
            Throw New DivideByZeroException
        End If
    End Function
    Function 錫溶解補正量ΔS1g演算() As Double
        '下記ΔＳ1ｇをＳ1に加える。	
        'ΔＳA = Ｃ4ＯＨ・Ｖ4
        'ΔＳ1ｇ = α7・ΔＳA / (tc7 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1ｇ:   不足時溶解量補正量(kg / hr)
        'Ｃ４：NO.４ETL循環タンクの濃度(g/L)
        'Ｃ４ＯH:   濃度上限(g / L)
        'Ｖ４：NO.４ETL循環タンクの容量(m3)
        'ｔc7:    濃度補正のための溶解補正時間(min)
        'α7:     補正係数()

        'Dim NO4_COND = RECVDATA.WORD_PLC_SRS_CTR.No4_循環_CONC_PV.ToFloat()
        Dim NO4_COND = RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.ToDouble()
        Dim C4OH = PARAMETER.Search("C4OH").設定値
        Dim Cob4 = PARAMETER.Search("COB4").設定値
        Dim V4 = RECVDATA.WORD_PLC_SRS_CTR.No4_循環_TL_PV.ToDouble()
        Dim α7 = PARAMETER.Search("α7").設定値
        Dim TC7 = PARAMETER.Search("TC7").設定値

        錫溶解補正量ΔS1g演算 = 0.0
        If NO4_COND > Cob4 + C4OH Then
            Dim DSA = C4OH * V4
            Dim DS1G = α7 * DSA / (TC7 / 60)
            錫溶解補正量ΔS1g演算 = -DS1G

        End If
        If CHECKVARIABLE.OldData.No4_AVE.ToString <> Math.Round(NO4_COND, 2).ToString Then
            PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, C4OH, Cob4, NO4_COND, V4, α7, TC7, 錫溶解補正量ΔS1g演算)
        End If

        If Double.IsNaN(錫溶解補正量ΔS1g演算) Then
            Throw New DivideByZeroException
        End If
    End Function
    Function 錫溶解補正量ΔS1h演算() As Double
        '下記ΔＳ1ｈをＳ1に加える。	
        'ΔＳA = Ｃ4ＯＬ・Ｖ4
        'ΔＳ1ｈ = α8・ΔＳA / (tc8 / 60)
        'ΔＳA:    Ｓn補正値(kg)
        'ΔＳ1ｈ:   不足時溶解量補正量(kg / hr)
        'Ｃ４：NO．４ETL循環タンクの濃度(g/L)
        'Ｃ４ＯＬ:   濃度下限(g / L)
        'Ｖ４：NO．４ETL循環タンクの容量(m3)
        'ｔc8:    濃度補正のための溶解補正時間(min)
        'α8:     補正係数()

        Dim NO4_COND = RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.ToDouble()
        Dim C4OL = PARAMETER.Search("C4OL").設定値
        Dim Cob4 = PARAMETER.Search("COB4").設定値
        Dim V4 = RECVDATA.WORD_PLC_SRS_CTR.No4_循環_TL_PV.ToDouble()
        Dim α8 = PARAMETER.Search("α8").設定値
        Dim TC8 = PARAMETER.Search("TC8").設定値

        錫溶解補正量ΔS1h演算 = 0.0
        If NO4_COND < Cob4 - C4OL Then
            Dim DSA = C4OL * V4
            Dim DS1H = α8 * DSA / (TC8 / 60)
            錫溶解補正量ΔS1h演算 = DS1H

        End If
        If CHECKVARIABLE.OldData.No4_AVE.ToString <> Math.Round(NO4_COND, 2).ToString Then
            PVSVLog.Logging錫溶解補正量(System.Reflection.MethodBase.GetCurrentMethod.Name, C4OL, Cob4, NO4_COND, V4, α8, TC8, 錫溶解補正量ΔS1h演算)
        End If

        If Double.IsNaN(錫溶解補正量ΔS1h演算) Then
            Throw New DivideByZeroException
        End If
    End Function
    Sub 溶解槽流量演算()
        Dim Fas As Double
        Dim Fa As Double
        Dim VA As Double
        Dim VASet As Double
        Dim VAHH As Double
        Dim dVAHH As Double
        Dim Fcset As Double

        'Ｆaset = Ｆ3set + Ｆ4set
        'Ｆbset：StＢ～溶解槽への返送量(m3/min)				
        'Ｆ3set：No.3循環タンク供給量(m3/min)				　　　流量計のPV
        'Ｆ4set：No.4循環タンク供給量(m3/min)				　　　流量計のPV
        'Ｆas = Ｆaset * (VaHH - Va) / (VaHH - VAset)
        '（但し、 VaHH - VAset < 0.5　の時、 VaHH - Vaset = 0.5とする。）					
        '　Ｆas：St.B～溶解槽流量(m3）					
        '　ＶaHH：St.Aタンクレベル上上限HH(m3)					　　　37.8(m3)　固定値（可変）
        'Va:     St.Aタンクの容量のPV値()
        'VAset : St. Aタンクレベル設定値(m3)					PLC設定値
        溶解槽DATA.Faset = ETLTANK.FCV2_PV + ETLTANK.FCV4_PV 'RECVDATA.WORD_PLC_SRS_CTR.FCV2_PV.ToDouble + RECVDATA.WORD_PLC_SRS_CTR.FCV4_PV.ToDouble
        VA = ETLTANK.StA_TL 'RECVDATA.WORD_PLC_SRS_CTR.StA_TL_PV.ToDouble
        VASet = ETLTANK.StA_TL_SETVAL 'RECVDATA.WORD_PLC_SRS_CTR.StA_TL_SETVAL.ToDouble
        VAHH = PARAMETER.Search("VAHH").設定値
        dVAHH = Math.Max(VAHH - VASet, 0.5F)
        Fas = 溶解槽DATA.Faset * (VAHH - VA) / dVAHH
        'OLD: 0.02≦Ｆas(m3/min)≦1.00　（左記にてリミットを掛ける）					
        '0.02≦Ｆas(m3/min)≦2.00　（左記にてリミットを掛ける）					
        '溶解槽DATA.Faset = Math.Max(Math.Min(Fas, 1.0F), 0.02F)
        溶解槽DATA.Faset = Math.Max(Math.Min(Fas, 2.0F), 0.1F)
        Fa = ETLTANK.FCV7_PV 'RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToDouble
        Fcset = PARAMETER.Search("FCSET").設定値
        溶解槽DATA.Fbset = Fcset - Fa
        If Double.IsNaN(溶解槽DATA.Fbset) Or Double.IsNaN(溶解槽DATA.Faset) Then
            Throw New DivideByZeroException
        End If
    End Sub
    Function 酸素吹込量とスラッジ発生率演算(ByRef S1 As Double, ByRef O2 As Double, ByRef SL As Double, SCHMODE As Boolean, 錫投入中 As Boolean) As Double
        'Option SCHMODE=Trueの時
        '   Ｆbset:  溶解槽自己循環流量SV(m3 / min)
        '   Ｆaset：StＢ～溶解槽への返送量(m3/min)
        '   Ｆb = Ｆbset
        '   Ｆa = Ｆaset
        '   Ｗ＝6(ton)　固定値
        'Else　それ以外の時
        '   Ｆb:     液循環量(m3 / min)
        '   Ｆa:     系外流出量(m3 / min)
        '   Ｗ:      槽内充填量(ton)
        'End
        'Ｏ2:     酸素吹込量(Nm3 / min)
        'Ｆb：液循環量(m3/min)　　					流量計のPV
        'Ｆa：系外流出量(m3/min)					流量計のPV
        'Ｗ：槽内充填量(ton)					7.5/0.0102*ΔＰ 7.5*ΔＰ
        'ΔＰ：槽内差圧(kPa) (kg/cm2)					槽内差圧(レベル)のPV
        'Ｆc：溶解槽内液量(m3/min)					Ｆb＋Ｆa
        'Ｕ0：溶解槽内空塔速度(m3/min)					Ｆc／(0.46*0.46*3.14)
        'ｋｆ：溶存酸素消費速度定数					0.000487｛(Ｕ0／60)^0.578｝*60
        'Ｃsi：系外流出液溶解槽流入時酸素濃度(ppm)					7(ppm)　固定値（可変）
        'Ｃs：系外流出液溶解槽流入時酸素濃度(m3/m3)					Ｃsi・｛(22.4*0.001)／32｝
        'Ｋ：換算係数(kg/min)					10.60(kg/min)　固定値（非可変）
        'Ａ：錫粒子比表面積(m2/m3)					2782(m2/m3)　固定値（非可変）
        'Ｒ：錫の密度(t/m3)					7.3(t/m3)　固定値（非可変）
        Dim Fa As Double
        Dim Fb As Double
        Dim W As Double
        Dim dP As Double
        Dim Fc As Double
        Dim U0 As Double
        Dim kf As Double
        Dim Csi As Double
        Dim Cs As Double
        Dim K As Double
        Dim A As Double
        Dim R As Double
        'Dim C1 As Double
        'Dim C0 As Double
        'Dim S1 As Double
        Dim Z As Double
        Dim ZZ As Double
        Dim KSL As Double
        Dim O2D As Double
        Dim μ As Double
        Dim X(11) As Double
        Dim Y(11) As Double
        酸素吹込量とスラッジ発生率演算 = 0

        If SCHMODE = True Then
            Fb = PARAMETER.Search("FBSET").設定値  '溶解槽DATA.Fbset '前段で計算済みのSV値
            Fa = PARAMETER.Search("FASET").設定値 '溶解槽DATA.Faset '前段で計算済みのSV値
            W = 5.5
        Else
            'If 錫投入中 = True Or RECVDATA.WORD_PLC_SRS_CTR.溶解槽_槽内圧力.ToDouble <= PARAMETER.Search("PL").設定値 Then
            '    O2 = 0
            '    SL = 0
            '    Exit Function
            'End If
            O2 = (RECVDATA.WORD_PLC_SRS_D6000.FIC1311_1_PV.ToDouble + RECVDATA.WORD_PLC_SRS_D6000.FIC1311_2_PV.ToDouble) / 1000 'RECVDATA.WORD_PLC_SRS_CTR.FCV10_PV.ToDouble
            dP = RECVDATA.WORD_PLC_SRS_D6000.PIA1313_PV.ToDouble 'RECVDATA.WORD_PLC_SRS_CTR.溶解槽_錫槽内差圧_PV.ToDouble()
            Fb = PARAMETER.Search("FBSET").設定値 'RECVDATA.WORD_PLC_SRS_CTR.FCV8_PV.ToDouble()
            Fa = RECVDATA.WORD_PLC_SRS_D6000.FIA1315_PV.ToDouble() / 60 'm3/h->m3/min 'RECVDATA.WORD_PLC_SRS_CTR.FCV7_PV.ToDouble()
            'W = 7.5 * 0.0102 * dP
            W = 5.5
            If W = 0.0 Then
                Throw New DivideByZeroException
            End If
        End If
        Fc = Fa + Fb
        If Fc = 0.0 Then
            'If 錫投入中 = False Then
            Throw New DivideByZeroException
            'Else
            'Exit Function
            'End If
        End If

        U0 = Fc / (0.46 * 0.46 * 3.14)
        kf = 0.000487 * ((U0 / 60) ^ 0.578) * 60
        Csi = PARAMETER.Search("CSI").設定値
        Cs = Csi * ((22.4 * 0.001) / 32)
        K = 10.6 '(kg/min)　固定値（非可変）
        A = 2782 '(m2/m3)　固定値（非可変）
        R = 7.3 '(t/m3)　固定値（非可変）

        'Ｃ1 = (Ｆa・Ｃｓ + Ｏ2) / {Ｆa + ｋｆ・Ａ・(Ｗ / Ｒ)}
        'Ｃ0 = (Ｆa・Ｃs + Ｆb・Ｃ1 + Ｏ2) / Ｆc
        'ＳＬ＝0.174(32・Ｃ1／0.0224)＝248.5714・Ｃ1
        'Ｓ1＝60・(1－0.01・ＳＬ)・Ｋ・Ｆc・(Ｃ0－Ｃ1）
        'Ｚ = Ｆa + ｋｆ・Ａ・(Ｗ / Ｒ)
        'ＺＺ = Ｚ + (Ｆb - Ｆc)
        'ＫSL = 248.5714
        'ＳＬ＝［60・Ｋ・ＺＺ－｛(60・Ｋ・ＺＺ)^2－2.4・Ｋ・ＺＺ・ＫSL・Ｓ1｝^0.5］／(1.2・Ｋ・ＺＺ)・・・①
        'Ｏ2D＝［Ｓ1・Ｚ／｛60・Ｋ・ＺＺ・(1－0.01ＳＬ)｝］－Ｆa・Ｃs・・・②
        'μ：溶存酸素効率
        'O2＝1/μ・O2D…③
        'C1 = (Fa * Cs + O2) / (Fa + kf * A * (W / R))
        'C0 = (Fa * Cs + Fb * C1 + O2) / Fc
        'SL = 0.174 * (32 * C1 / 0.0224)
        'S1 = 60 * (1 - 0.01 * SL) * K * Fc * (C0 - C1)
        Z = Fa + kf * A * (W / R)
        ZZ = Z + (Fb - Fc)
        KSL = 248.5714
        SL = (60 * K * ZZ - ((60 * K * ZZ) ^ 2 - 2.4 * K * ZZ * KSL * S1) ^ 0.5) / (1.2 * K * ZZ)
        O2D = (S1 * Z / (60 * K * ZZ * (1 - 0.01 * SL))) - Fa * Cs
        If Double.IsNaN(O2D) Or Double.IsNaN(SL) Then
            O2D = 0
            SL = 0
            'Throw New DivideByZeroException
        End If
        'O2μテーブルサーチ
        Dim muIdxFrom = Fix(O2D / 0.2)
        Dim muIdxTo = muIdxFrom + 1
        If muIdxTo > 10 Then
            muIdxTo = 10
            μ = PARAMETER.Search("mu" & (muIdxTo + 1)).設定値
        ElseIf muIdxFrom < 0 Then
            muIdxFrom = 0
            μ = PARAMETER.Search("mu" & (muIdxFrom + 1)).設定値
        Else
            Dim mu1 = PARAMETER.Search("mu" & (muIdxFrom + 1)).設定値
            Dim mu2 = PARAMETER.Search("mu" & (muIdxTo + 1)).設定値
            μ = mu1 + (mu2 - mu1) * (O2D - muIdxFrom * 0.2) / ((muIdxTo - muIdxFrom) * 0.2)
        End If
        'O2値は0以上μ11を超えない
        酸素吹込量とスラッジ発生率演算 = O2D

        O2 = Math.Max(Math.Min(1 / μ * O2D, 2.0), 0)
        'SL値は0以上
        SL = Math.Max(SL, 0)
    End Function

    Sub No3循環タンクメッキ液供給補正演算()
        Dim F03 As Double
        Dim F3 As Double
        Dim CA As Double
        Dim Sn3 As Double
        Dim Cob3 As Double
        Dim dC3 As Double
        Dim dS3 As Double
        Dim dF3 As Double
        Dim C3FH As Double
        Dim C3FL As Double
        Dim C3 As Double
        Dim V3 As Double
        Dim TC9 As Double
        Dim α9 As Double
        Dim TC10 As Double
        Dim α10 As Double
        Dim sn As Double
        Dim targetTime As Double
        NO3ETL循環タンクDATA.dF3H = 0
        NO3ETL循環タンクDATA.dF3L = 0

        If ETLPRODSCHS(0).Products.Count > 0 AndAlso linecondition(0) Then

            '基本流量
            'Ｆ03＝Ｓｎ3／（ＣＡ－Ｃｏｂ3）　(m3/min)
            'ＣＡ:     ストレージＡタンクの錫イオン濃度(g / L)
            'Ｃｏｂ3：	No.3循環タンク濃度目標値(g/L)
            'Sn3：メッキによる消費量（Kg/min)
            '   Ｃ3：	No.3循環タンク濃度(g/L)
            '   Ｖ3：	No.3循環タンクの容量(m3)

            'CA = RECVDATA.WORD_PLC_SRS_CTR.StA_COND_PV.ToFloat
            CA = RECVDATA.WORD_PLC_SRS_CTR.StA_AVE.ToDouble
            Cob3 = PARAMETER.Search("COB3").設定値
            targetTime = PARAMETER.Search("TD3").設定値

            Dim qrysn = From sngrp In TRENDGRAPHDATA.NO3錫消費SCH
                        Where sngrp.X < targetTime
                        Select sngrp.Y
            If qrysn.Count > 0 Then
                sn = qrysn(qrysn.Count - 1)
            Else
                sn = ETLPRODSCHS(0).Products(0).Sn
            End If
            ETLTANK.No3_Sn = sn
            'Sn3 = Math.Max(0.05, sn / 60.0) 'NO3ETLの現在の生産スケジュールのSn(Kg/h)をKg/min変換
            Sn3 = sn / 60.0 'NO3ETLの現在の生産スケジュールのSn(Kg/h)をKg/min変換
            Dim dCACOB3 = (CA - Cob3)
            If (dCACOB3 = 0) Then
                dCACOB3 = dCACOB3 + 0.0000001
            End If
            F03 = Sn3 / dCACOB3
            C3 = RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.ToDouble
            V3 = RECVDATA.WORD_PLC_SRS_CTR.No3_循環_TL_PV.ToDouble
            F3 = F03
            '実濃度（不足）による流量補正項　（Ｃ3 ＜ Cob3 - Ｃ3FL にて補正を行う）
            '   Ｃ3FL:   濃度下限(g / L)
            '   ｔｃ9:    濃度補正のための流量供給時間(min)
            '   ＣA:     ストレージＡタンク濃度(g / L)
            '   α9:     補正係数()
            '   ΔＣ3:    濃度補正値(g / L)
            '   ΔＳ3:    Ｓn補正値(kg)
            '   ΔＦ3:    流量補正量(m3 / min)
            '   ΔＣ3 = Ｃｏｂ3 - Ｃ３
            '   ΔＳ3 = ΔＣ3・Ｖ3
            '   ΔＦ3 = α9・ΔＳ3 / (ＣA・ｔｃ9)
            'Ｆ3 = Ｆ03 + ΔＦ3
            C3FL = PARAMETER.Search("C3FL").設定値
            If C3 < Cob3 - C3FL Then
                TC9 = PARAMETER.Search("TC9").設定値
                α9 = PARAMETER.Search("α9").設定値
                dC3 = Cob3 - C3
                dS3 = dC3 * V3
                dF3 = α9 * dS3 / (CA * TC9)
                NO3ETL循環タンクDATA.dF3L = dF3
                F3 = F03 + dF3
            End If

            '実濃度（過剰）による流量流量補正項　（Ｃ3 ＞ Cob3 + Ｃ3FH にて補正を行う）
            '   Ｃ3FH:   濃度上限(g / L)
            '   ｔｃ１0:   濃度補正のための流量供給時間(min)
            '   ＣA:     ストレージＡタンク濃度(g / L)
            '   α10:    補正係数()
            '   ΔＣ3＝Ｃｏｂ3-Ｃ3	
            '   ΔＳ3 = ΔＣ3・Ｖ3
            '   ΔＦ３ = α10・ΔＳ3 / (ＣA・ｔｃ10)
            'Ｆ3 = Ｆ03 + ΔＦ3
            C3FH = PARAMETER.Search("C3FH").設定値
            If C3 > Cob3 + C3FH Then
                TC10 = PARAMETER.Search("TC10").設定値
                α10 = PARAMETER.Search("α10").設定値
                dC3 = Cob3 - C3
                dS3 = dC3 * V3
                dF3 = α10 * dS3 / (CA * TC10)
                NO3ETL循環タンクDATA.dF3H = dF3
                F3 = F03 + dF3
            End If
            'F3:
            '　0.05≦Ｆ3(m3/min)≦1.0　（左記にてリミットを掛ける）
            NO3ETL循環タンクDATA.F3 = Math.Max(Math.Min(F3, 1.0F), 0.15F)

        Else
            '　但し、３ＥＴＬライン運転中でない時はＦ3＝0とする。
            NO3ETL循環タンクDATA.F3 = 0
        End If
        If Double.IsNaN(NO3ETL循環タンクDATA.F3) Then
            Throw New DivideByZeroException
        End If

    End Sub
    Sub No4循環タンクメッキ液供給補正演算()
        Dim F04 As Double
        Dim F4 As Double
        Dim CA As Double
        Dim Sn4 As Double
        Dim Cob4 As Double
        Dim dC4 As Double
        Dim dS4 As Double
        Dim dF4 As Double
        Dim C4FH As Double
        Dim C4FL As Double
        Dim C4 As Double
        Dim V4 As Double
        Dim TC11 As Double
        Dim α11 As Double
        Dim TC12 As Double
        Dim α12 As Double
        Dim sn As Double
        Dim targetTime As Double
        NO4ETL循環タンクDATA.dF4H = 0
        NO4ETL循環タンクDATA.dF4L = 0

        '　但し、4ＥＴＬライン運転中でない時はＦ4＝0とする。
        'If RECVDATA.BIT_PLC_SRS_CTR.No4ETL運転中 AndAlso ETLPRODSCHS(1).Products.Count > 0 Then
        If ETLPRODSCHS(1).Products.Count > 0 AndAlso linecondition(1) Then

            'Ｆ04 = Ｓｎ4 / (ＣＡ - Ｃｏｂ4)(m3 / min)
            'ＣＡ:     ストレージＡタンクの錫イオン濃度(g / L)
            'Ｃｏｂ4：	No.4循環タンク濃度目標値(g/L)
            'Sn4：メッキによる消費量（Kg/min)
            '   Ｃ4：	No.4循環タンク濃度(g/L)
            '   Ｖ4：	No.4循環タンクの容量(m3)

            'CA = RECVDATA.WORD_PLC_SRS_CTR.StA_COND_PV.ToFloat
            CA = RECVDATA.WORD_PLC_SRS_CTR.StA_AVE.ToDouble
            Cob4 = PARAMETER.Search("COB4").設定値
            targetTime = PARAMETER.Search("TD4").設定値

            Dim qrysn = From sngrp In TRENDGRAPHDATA.NO4錫消費SCH
                        Where sngrp.X < targetTime
                        Select sngrp.Y
            If qrysn.Count > 0 Then
                sn = qrysn(qrysn.Count - 1)
            Else
                sn = ETLPRODSCHS(1).Products(0).Sn
            End If
            ETLTANK.No4_Sn = sn
            'Sn4 = Math.Max(0.05, sn / 60.0) 'NO4ETLの現在の生産スケジュールのSn(Kg/h)をKg/min変換
            Sn4 = sn / 60.0 'NO4ETLの現在の生産スケジュールのSn(Kg/h)をKg/min変換
            Dim dCACOB4 = (CA - Cob4)
            If (dCACOB4 = 0) Then
                dCACOB4 = dCACOB4 + 0.0000001
            End If
            F04 = Sn4 / dCACOB4
            C4 = RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.ToDouble
            V4 = RECVDATA.WORD_PLC_SRS_CTR.No4_循環_TL_PV.ToDouble
            F4 = F04

            '実濃度（不足）による流量補正項　（Ｃ4 ＜ Cob4 - Ｃ4FL にて補正を行う）
            '   Ｃ4FL:   濃度下限(g / L)
            '   ｔｃ11:    濃度補正のための流量供給時間(min)
            '   α11:     補正係数()
            '   ΔＣ4:    濃度補正値(g / L)
            '   ΔＳ4:    Ｓn補正値(kg)
            '   ΔＦ4:    流量補正量(m3 / min)
            '   ΔＣ4 = Ｃｏｂ4  - Ｃ4
            '   ΔＳ4 = ΔＣ4・Ｖ4
            '   ΔＦ4 = α11・ΔＳ4 / (ＣA・ｔｃ11)
            'Ｆ4 = Ｆ04 + ΔＦ4
            C4FL = PARAMETER.Search("C4FL").設定値
            If C4 < Cob4 - C4FL Then
                TC11 = PARAMETER.Search("TC11").設定値
                α11 = PARAMETER.Search("α11").設定値
                dC4 = Cob4 - C4
                dS4 = dC4 * V4
                dF4 = α11 * dS4 / (CA * TC11)
                NO4ETL循環タンクDATA.dF4L = dF4
                F4 = F04 + dF4
            End If


            '実濃度（過剰）による流量流量補正項　（Ｃ4 ＞ Cob4 + Ｃ4FH にて補正を行う）
            '   Ｃ4FH:   濃度上限(g / L)
            '   ｔｃ１2:   濃度補正のための流量供給時間(min)
            '   α12:    補正係数()
            '   ΔＣ4:    濃度補正値(g / L)
            '   ΔＳ4:    Ｓn補正値(kg)
            '   ΔＦ4:    流量補正量(m3 / min)
            '   ΔＣ4＝Ｃｏｂ4-Ｃ4	
            '   ΔＳ4 = ΔＣ4・Ｖ4
            '   ΔＦ4 = α11・ΔＳ4 / (ＣA・ｔｃ11)
            'Ｆ4 = Ｆ04 + ΔＦ4
            C4FH = PARAMETER.Search("C4FH").設定値
            If C4 > Cob4 + C4FH Then
                TC12 = PARAMETER.Search("TC12").設定値
                α12 = PARAMETER.Search("α12").設定値
                dC4 = Cob4 - C4
                dS4 = dC4 * V4
                dF4 = α12 * dS4 / (CA * TC12)
                NO4ETL循環タンクDATA.dF4H = dF4
                F4 = F04 + dF4
            End If
            'F4:
            '　0.05≦Ｆ4(m3/min)≦1.0　（左記にてリミットを掛ける）
            NO4ETL循環タンクDATA.F4 = Math.Max(Math.Min(F4, 1.0F), 0.15F)
        Else
            NO4ETL循環タンクDATA.F4 = 0
        End If
        If Double.IsNaN(NO4ETL循環タンクDATA.F4) Then
            Throw New DivideByZeroException
        End If
    End Sub
    Sub 各タンク供給量指令値演算()
        Dim Fsup As Double
        If RECVDATA.BIT_PLC_SRS_CTR.溶解槽_錫投入中 Then
            Fsup = PARAMETER.Search("FSUP2").設定値
        Else
            Fsup = PARAMETER.Search("FSUP1").設定値
        End If
        Dim F3F4 = (NO3ETL循環タンクDATA.F3 + NO4ETL循環タンクDATA.F4)
        If ETLPRODSCHS(0).Products.Count > 0 AndAlso ETLPRODSCHS(1).Products.Count > 0 AndAlso linecondition(0) AndAlso linecondition(1) Then
            '(1)	No.3、No.4両ライン運転中	
            '	F3set＝F3／（F3＋F4）・Fsup	
            '	F4set＝F4／（F3＋F4）・Fsup	
            '	F3set：	No.3循環タンク供給流量制御設定値（m3/min)
            '	F4set：	No.4循環タンク供給流量制御設定値（m3/min)
            NO3ETL循環タンクDATA.F3set = NO3ETL循環タンクDATA.F3 / F3F4 * Fsup
            NO4ETL循環タンクDATA.F4set = NO4ETL循環タンクDATA.F4 / F3F4 * Fsup
        ElseIf ETLPRODSCHS(0).Products.Count > 0 AndAlso linecondition(0) Then
            '(2)	No.3片ライン運転中	
            '   F3set = F3(m3 / min)
            '   F4set = 0(m3 / min)
            '	　但し、F3set上限はFsup	
            'NO3ETL循環タンクDATA.F3set = Math.Min(Math.Max(NO3ETL循環タンクDATA.F3, 0.6), Fsup)
            NO3ETL循環タンクDATA.F3set = Math.Min(NO3ETL循環タンクDATA.F3, Fsup)
            NO4ETL循環タンクDATA.F4set = 0

        ElseIf ETLPRODSCHS(1).Products.Count > 0 AndAlso linecondition(1) Then
            '(3)	No.4片ライン運転中	
            '   F3set = 0(m3 / min)
            '   F4set = F4(m3 / min)
            '	　但し、F4set上限はFsup	
            NO3ETL循環タンクDATA.F3set = 0
            'NO4ETL循環タンクDATA.F4set = Math.Min(Math.Max(NO4ETL循環タンクDATA.F4, 0.6), Fsup)
            NO4ETL循環タンクDATA.F4set = Math.Min(NO4ETL循環タンクDATA.F4, Fsup)
        End If
        If Double.IsNaN(NO3ETL循環タンクDATA.F3set) Or Double.IsNaN(NO4ETL循環タンクDATA.F4set) Then
            Throw New DivideByZeroException
        End If
    End Sub
End Class
