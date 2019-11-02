Imports System.IO
Imports System.Reflection
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Collections.Generic
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Threading.Tasks

Public Module DEFINESTRUCTURE
    Public Delegate Sub ALAMDELEGATE(alam As ALAM)
    Public Structure AlamItem
        Public No As Int16
        Public Trigger As Boolean
        Public TriggerTime As DateTime
        Public RecoverTime As DateTime
        Public Shared Function Comparison(ByVal x As AlamItem, ByVal y As AlamItem) As Integer
            Comparison = 0
            If x.TriggerTime < y.TriggerTime Then Comparison = 1
            If x.TriggerTime > y.TriggerTime Then Comparison = -1
        End Function
    End Structure
    Public Structure ALAM
        'アラームNo
        Public Enum ALAMNO
            COM_L2_ERROR = 1
            FT315_FLR_CIR_ERROR = 2
            FT311_FLR_REP_ERROR = 3
            PT313_DP_REP_ERROR = 4
            LT321_SET_TANK_ERROR = 5
            LT302_CIR_TANK_ERROR = 6
            TIA_CIR_TANK_ERROR = 7
            TIA_CIR_TANKL_ERROR = 8
            DS1X_TOO_LARGE = 9
            PC3AB_STOP = 10
            PC2AB_STOP = 11
            CALC_ERROR = 12
            XV311_IS_CLOSED = 13
            SCHEDULE_NOTHING = 14
            CURRENT_ERROR = 15
            SCHEDULE_ERROR = 16
            FIELD_ERROR = 17
        End Enum

        Public Enum ALAMNO_YAHATA
            COM_L2_ERROR = 1
            MESURING_ERROR = 2
            CASMODE_ERROR = 3
            NO3ETL_TINION_COND_ERROR = 4
            NO4ETL_TINION_COND_ERROR = 5
            STA_TINION_COND_ERROR = 6
            NO3ETL_TINION_COND_LEVEL = 7
            NO4ETL_TINION_COND_LEVEL = 8
            STA_TINION_COND_LEVEL = 9
            NO3ETL_DS1X_TOO_LARGE = 10
            NO4ETL_DS1X_TOO_LARGE = 11
            P1_PUMP_STOP = 12
            P2_PUMP_STOP = 13
            P7_PUMP_STOP = 14
            P12_PUMP_STOP = 15
            P8_PUMP_STOP = 16
            CALC_ERROR = 17
            SCHEDULE_ERROR = 18
            SRS_OFF = 19
        End Enum
        Public Shared ALAMMESSAGES As New Dictionary(Of Int16, String)
        Public Shared ALAMITEMS As New Dictionary(Of Int16, AlamItem)
        Public Shared ALAMHIST As New List(Of AlamItem)
        Public Shared Sub Load(fpath As String)
            ALAMIO.ALAM_Setting(fpath)
            'SetAttr(fpath, FileAttribute.Hidden)
        End Sub
        Public Shared Sub Import(fpath As String)
            ALAMIO.AlamRecord_Import(fpath)

        End Sub
        Public Shared Sub Export(fpath As String)
            'SetAttr(fpath, FileAttribute.Normal)
            ALAMIO.AlamRecord_Export(fpath)
            'SetAttr(fpath, FileAttribute.Hidden)
        End Sub
        Public Shared Sub CheckAlams()
            CONDITION.CheckAlams()
        End Sub

        Public Shared Sub Trigger(No As ALAMNO, flag As Boolean)
            If Not ALAMITEMS.ContainsKey(No) Then
                Dim newalam As New AlamItem With {.No = No, .Trigger = flag, .TriggerTime = DateTime.MinValue, .RecoverTime = DateTime.MinValue}
                ALAMITEMS.Add(No, newalam)
            End If
            'アラーム発生
            If flag = True And (ALAMITEMS(No).TriggerTime = DateTime.MinValue Or ALAMITEMS(No).Trigger = False) Then
                Dim alam = ALAMITEMS(No)
                alam.Trigger = flag
                alam.TriggerTime = DateTime.Now
                alam.RecoverTime = DateTime.MinValue
                ALAMITEMS(No) = alam
                ALAMHIST.Insert(0, alam)
            End If
            'アラーム解消
            If flag = False And ALAMITEMS(No).Trigger = True Then
                Dim alam = ALAMITEMS(No)
                Dim idx = ALAMHIST.FindIndex(Function(ah) ah.No = No And ah.Trigger = True)
                alam.Trigger = flag
                alam.RecoverTime = DateTime.Now
                ALAMITEMS(No) = alam
                If idx >= 0 Then
                    ALAMHIST(idx) = alam
                Else
                    ALAMHIST.Insert(0, alam)
                End If
            End If

        End Sub
        Public Shared Function GetAlam()
            GetAlam = 0
            Dim idx = ALAMHIST.FindIndex(Function(ah) ah.Trigger = True)
            If idx >= 0 Then
                GetAlam = ALAMHIST(idx).No
            End If
            'GetAlam = 0
            'Dim lasttime As DateTime = DateTime.MinValue
            'Dim alams = From alamitem In ALAMITEMS
            '            Where alamitem.Value.Trigger = True
            '            Select alamitem
            'For Each alam In alams
            '    If (alam.Value.TriggerTime > lasttime) Then
            '        lasttime = alam.Value.TriggerTime
            '        GetAlam = alam.Value.No
            '    ElseIf (alam.Value.TriggerTime = lasttime) Then
            '        If (alam.Value.No > GetAlam) Then
            '            GetAlam = alam.Value.No
            '        End If
            '    End If
            'Next
        End Function

    End Structure



    Public Delegate Sub SLSDELEGATE(sls As SLS)
    Public Structure SLSItem
        Public No As Int16
        Public Trigger As Boolean
        Public TriggerTime As DateTime
        Public RecoverTime As DateTime

        Public InputTime As DateTime
        Public TinIon As Double
        Public MSA As Double
        Public EN As Double
        Public Shared Function Comparison(ByVal x As SLSItem, ByVal y As SLSItem) As Integer
            Comparison = 0
            If x.TriggerTime < y.TriggerTime Then Comparison = 1
            If x.TriggerTime > y.TriggerTime Then Comparison = -1
        End Function
    End Structure
    Public Structure SLS
        ''アラームNo
        'Public Enum SLSNO
        '    COM_L2_ERROR = 1
        '    FT315_FLR_CIR_ERROR = 2
        '    FT311_FLR_REP_ERROR = 3
        '    PT313_DP_REP_ERROR = 4
        '    LT321_SET_TANK_ERROR = 5
        '    LT302_CIR_TANK_ERROR = 6
        '    TIA_CIR_TANK_ERROR = 7
        '    TIA_CIR_TANKL_ERROR = 8
        '    DS1X_TOO_LARGE = 9
        '    PC3AB_STOP = 10
        '    PC2AB_STOP = 11
        '    CALC_ERROR = 12
        '    XV311_IS_CLOSED = 13
        '    SCHEDULE_NOTHING = 14
        '    CURRENT_ERROR = 15
        '    SCHEDULE_ERROR = 16
        '    FIELD_ERROR = 17
        'End Enum

        'Public Enum SLSNO_YAHATA
        '    COM_L2_ERROR = 1
        '    MESURING_ERROR = 2
        '    CASMODE_ERROR = 3
        '    NO3ETL_TINION_COND_ERROR = 4
        '    NO4ETL_TINION_COND_ERROR = 5
        '    STA_TINION_COND_ERROR = 6
        '    NO3ETL_TINION_COND_LEVEL = 7
        '    NO4ETL_TINION_COND_LEVEL = 8
        '    STA_TINION_COND_LEVEL = 9
        '    NO3ETL_DS1X_TOO_LARGE = 10
        '    NO4ETL_DS1X_TOO_LARGE = 11
        '    P1_PUMP_STOP = 12
        '    P2_PUMP_STOP = 13
        '    P7_PUMP_STOP = 14
        '    P12_PUMP_STOP = 15
        '    P8_PUMP_STOP = 16
        '    CALC_ERROR = 17
        '    SCHEDULE_ERROR = 18
        '    SRS_OFF = 19
        'End Enum
        Public Shared SLSMESSAGES As New Dictionary(Of Int16, String)
        Public Shared SLSITEMS As New Dictionary(Of Int16, SLSItem)
        Public Shared SLSHIST As New List(Of SLSItem)
        Public Shared Sub Load(fpath As String)
            SLSIO.SLS_Setting(fpath)
            'SetAttr(fpath, FileAttribute.Hidden)
        End Sub
        Public Shared Sub Import(fpath As String)
            SLSIO.SLSRecord_Import(fpath)

        End Sub
        Public Shared Sub Export(fpath As String)
            'SetAttr(fpath, FileAttribute.Normal)
            SLSIO.SLSRecord_Export(fpath)
            'SetAttr(fpath, FileAttribute.Hidden)
        End Sub
        Public Shared Sub CheckAlams()
            'CONDITION.CheckSls()
        End Sub

        'Public Shared Sub Trigger(No As SLSNO, flag As Boolean)
        '    If Not SLSITEMS.ContainsKey(No) Then
        '        Dim newsls As New SLSItem With {.No = No, .Trigger = flag, .TriggerTime = DateTime.MinValue, .RecoverTime = DateTime.MinValue}
        '        SLSITEMS.Add(No, newsls)
        '    End If
        '    'アラーム発生
        '    If flag = True And (SLSITEMS(No).TriggerTime = DateTime.MinValue Or SLSITEMS(No).Trigger = False) Then
        '        Dim sls = SLSITEMS(No)
        '        sls.Trigger = flag
        '        sls.TriggerTime = DateTime.Now
        '        sls.RecoverTime = DateTime.MinValue
        '        SLSITEMS(No) = sls
        '        SLSHIST.Insert(0, sls)
        '    End If
        '    'アラーム解消
        '    If flag = False And SLSITEMS(No).Trigger = True Then
        '        Dim sls = SLSITEMS(No)
        '        Dim idx = SLSHIST.FindIndex(Function(ah) ah.No = No And ah.Trigger = True)
        '        sls.Trigger = flag
        '        sls.RecoverTime = DateTime.Now
        '        SLSITEMS(No) = sls
        '        If idx >= 0 Then
        '            SLSHIST(idx) = sls
        '        Else
        '            SLSHIST.Insert(0, sls)
        '        End If
        '    End If

        'End Sub
        'Public Shared Function GetSls()
        '    GetSls = 0
        '    Dim idx = SLSHIST.FindIndex(Function(ah) ah.Trigger = True)
        '    If idx >= 0 Then
        '        GetSls = SLSHIST(idx).No
        '    End If
        '    'GetAlam = 0
        '    'Dim lasttime As DateTime = DateTime.MinValue
        '    'Dim alams = From alamitem In ALAMITEMS
        '    '            Where alamitem.Value.Trigger = True
        '    '            Select alamitem
        '    'For Each alam In alams
        '    '    If (alam.Value.TriggerTime > lasttime) Then
        '    '        lasttime = alam.Value.TriggerTime
        '    '        GetAlam = alam.Value.No
        '    '    ElseIf (alam.Value.TriggerTime = lasttime) Then
        '    '        If (alam.Value.No > GetAlam) Then
        '    '            GetAlam = alam.Value.No
        '    '        End If
        '    '    End If
        '    'Next
        'End Function
        Public Const NUMMINUTES As Integer = 1441
        Public Const LOGMINUTES As Integer = 1441
        Public Const NUMSAMPLES As Integer = 11

        'Shared Vr As Double 'Parameter for escape Zero-deviation/ Progream parameter
        'Shared Te As Double

        Public Shared Function V() As Double
            V = Convert.ToDouble(PARAMETER.Search("SLS_V").Value)
        End Function
        Public Shared Function alpha() As Double
            alpha = Convert.ToDouble(PARAMETER.Search("SLS_alpha").Value)
        End Function

        Public Shared Function TinIonValue() As Double
            If SLSHIST.Count > 0 Then
                TinIonValue = SLSHIST.First().TinIon
            Else
                TinIonValue = Convert.ToDouble(PARAMETER.Search("SLS_So").Value)
            End If
        End Function
        Public Shared Function TinIonInputTime() As DateTime
            If SLSHIST.Count > 0 Then
                TinIonInputTime = SLSHIST.First().InputTime
            Else
                TinIonInputTime = DateTime.MinValue
            End If
        End Function
        Public Shared Function Te() As Double
            Te = Convert.ToDouble(PARAMETER.Search("SLS_taue").Value)
        End Function
        Public Shared Function Tp() As Double
            Tp = Convert.ToDouble(PARAMETER.Search("SLS_Tp").Value)
        End Function
        Public Shared Function Tc() As Double
            Tc = Convert.ToDouble(PARAMETER.Search("SLS_Tc").Value)
        End Function

        '    Public Sp_r(NUMMINUTES) As Double
        '    Public Sc_r(NUMMINUTES) As Double
        Public Shared Tin_consume As Double
        Public Shared Tin_supply As Double

        Public Shared DateTime_r(LOGMINUTES) As DateTime
        '    Public PV_TinIon_r(LOGMINUTES) As Double
        Public Shared SnD_r(LOGMINUTES) As Double
        Public Shared SpD_r(LOGMINUTES) As Double
        Public Shared ScD_r(LOGMINUTES) As Double
        Public Shared Sn_r(LOGMINUTES) As Double

        Public Shared SampDateTime(NUMSAMPLES) As DateTime
        Public Shared SnT(NUMSAMPLES) As Double
        Public Shared SpT(NUMSAMPLES) As Double
        Public Shared ScT(NUMSAMPLES) As Double
        Public Shared VT(NUMSAMPLES) As Double

        'Dim T(11) As System.UInt64


        'Dim preSp As Double
        'Dim preSc As Double
        Public Shared SpDp As Double
        Public Shared ScDp As Double

        Public Shared SpD As Double
        Public Shared ScD As Double


        Public Shared Sn_new_data As Double
        '    Public SpD As Double
        '    Public ScD As Double
        '    Public SnD As Double
        ' Public D_Counter As Integer
        Public Shared SSD As Double
        Public Shared lSpcD As Double
        Public Shared V_den As Double
        Public Shared V_num As Double
        Public Shared count As System.UInt64

        Public Shared Sn_modi As Integer
        Public Shared V_psa As Double
        Public Shared V_demi As Double
        Public Shared V_add As Double
        Public Shared V_before As Double
        Public Shared V_const As Double
        Public Shared V_comp As Double
        'Modified 20140127///////////////////////////////////////////////////////
        Public Shared Sp As Double
        Public Shared Sc As Double
        Public Shared SnD As Double
        'Modified 20140127///////////////////////////////////////////////////////
        'Modified 20140228///////////////////////////////////////////////////////
        Public Shared SLSrefleshimer As Integer
        Public Shared SLSrefleshimer_preset As Integer = 240  'Bigger than 10
        'Modified 20140228///////////////////////////////////////////////////////
        Public Shared InputUpdate As Boolean
        Public Shared sim_time As DateTime
        'Public inmemory_db As SortedList(Of DateTime, Single())

        Public Shared VTIE08OP_AND_PC17AORBRUN As Integer
        Public Shared VTIB02OP_AND_VTIB07OP_PC2ARUN As Integer
    End Structure

    '時定数演算
    Public Structure 時定数演算
        Public dbl As Double
        Public Function From1次遅れDouble(newData As Double, T As Double) As Double
            'Word = Math.Max(Math.Min(in_Float / Unit, UpperLimit), LowerLimit)
            T = Math.Max(T, 1)
            dbl = dbl * (T - 1) / T + newData * 1 / T
            From1次遅れDouble = dbl
        End Function

    End Structure

    'ワード/浮動小数点変換
    Public Structure UnitDWord
        Public LowerLimit As UInt32
        Public UpperLimit As UInt32
        Public Word As System.UInt32
        Public Unit As Double
        Public Sub From(in_Word As UInt32, in_Unit As Double)
            Word = in_Word
            Unit = in_Unit
        End Sub

        Public Sub FromDouble(in_Float As Double)
            'Word = Math.Max(Math.Min(in_Float / Unit, UpperLimit), LowerLimit)
            Dim var = Math.Abs(in_Float / Unit)
            If var >= UpperLimit Then var = UpperLimit
            If var <= LowerLimit Then var = LowerLimit
            Try
                Word = CShort(var)
            Catch
            End Try
        End Sub
        Public Sub New(in_Word As UInt32, in_Unit As Double, in_LowerLimit As UInt32, in_UpperLimit As UInt32)
            Word = in_Word
            Unit = in_Unit
            LowerLimit = in_LowerLimit
            UpperLimit = in_UpperLimit
        End Sub

        'Public Sub New(in_Word As Int16, in_Unit As Double)
        '    Word = in_Word
        '    Unit = in_Unit
        'End Sub
        'Public Sub New(in_Word As Int16)
        '    Word = in_Word
        '    Unit = 1.0
        'End Sub
        'Public Sub New(in_Float As Double, in_Unit As Double)
        '    Word = in_Float / in_Unit
        '    Unit = in_Unit
        'End Sub
        'Public Sub New(in_Float As Double)
        '    Word = in_Float
        '    Unit = 1.0
        'End Sub
        Public Function ToDouble() As Double
            ToDouble = Word * Unit
        End Function
        Public Overrides Function ToString() As String
            ToString = ToDouble().ToString()
        End Function
        Public Function CheckRange() As Boolean
            CheckRange = Word >= LowerLimit And Word <= UpperLimit
        End Function
    End Structure
    Public Structure UnitWord
        Public LowerLimit As UInt16
        Public UpperLimit As UInt16
        Public Word As System.UInt16
        Public Unit As Double
        Public Sub From(in_Word As UInt16, in_Unit As Double)
            Word = in_Word
            Unit = in_Unit
        End Sub

        Public Sub FromDouble(in_Float As Double)
            'Word = Math.Max(Math.Min(in_Float / Unit, UpperLimit), LowerLimit)
            Dim var = Math.Abs(in_Float / Unit)
            If var >= UpperLimit Then var = UpperLimit
            If var <= LowerLimit Then var = LowerLimit
            Try
                Word = CShort(var)
            Catch
            End Try
        End Sub
        Public Sub New(in_Word As UInt16, in_Unit As Double, in_LowerLimit As UInt16, in_UpperLimit As UInt16)
            Word = in_Word
            Unit = in_Unit
            LowerLimit = in_LowerLimit
            UpperLimit = in_UpperLimit
        End Sub

        'Public Sub New(in_Word As Int16, in_Unit As Double)
        '    Word = in_Word
        '    Unit = in_Unit
        'End Sub
        'Public Sub New(in_Word As Int16)
        '    Word = in_Word
        '    Unit = 1.0
        'End Sub
        'Public Sub New(in_Float As Double, in_Unit As Double)
        '    Word = in_Float / in_Unit
        '    Unit = in_Unit
        'End Sub
        'Public Sub New(in_Float As Double)
        '    Word = in_Float
        '    Unit = 1.0
        'End Sub
        Public Function ToDouble() As Double
            ToDouble = Word * Unit
        End Function
        Public Overrides Function ToString() As String
            ToString = ToDouble().ToString()
        End Function
        Public Function CheckRange() As Boolean
            CheckRange = Word >= LowerLimit And Word <= UpperLimit
        End Function
    End Structure
    '出力構造体（出力用)
    Public Structure OUTSTR
        Public Name As String
        Public Offset As Integer
        Public field As UnitWord
    End Structure

    'ロットデータ構造体
    Public Structure ProductData
        Public No As String
        Public Weight As UnitWord
        Public Weight_bk As Double
        Public TPH As UnitWord
        Public Thickness As UnitWord
        Public Width As UnitWord
        Public Coating As UnitWord
        Public Idx As Integer 'スケジュール先頭からの位置
        Public Tw As Double
        Public Tz As Double
        Public Tz_bk As Double
        Public LS As Double
        Public Sn As Double
        Public Sn_bk As Double 'コイル重量が変わる前のSn値のバックアップ
        Public Te As Integer
        Public S As Double
        Public S_Pre As Double
        Public S1 As Double
    End Structure
    '溶解データ構造体
    Public Structure DisCombData
        Public Tz As Double
        Public Tz_bk As Double
        Public S1_NO3 As Double
        Public S1_NO4 As Double
        Public S1 As Double
        Public O2 As Double
        Public SL As Double
    End Structure
    '溶解データソート構造体
    Public Structure DisSortItem
        Public eno As Integer
        Public Tz As Double
        Public S1 As Double
        Public Shared Function Comparison(ByVal x As DisSortItem, ByVal y As DisSortItem) As Integer
            Comparison = 0
            If x.Tz < y.Tz Then Comparison = -1
            If x.Tz > y.Tz Then Comparison = 1
        End Function
    End Structure

    'SRS PLC インターフェース
    Public Structure RECVDATA
        Public Structure BIT_PLC_SRS_M9000 '1. BIT_PLC_SRS_IND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared PW_5AB As Boolean
            Public Shared PC12_AB As Boolean
            Public Shared PC13_AB As Boolean
            Public Shared PC4_A As Boolean
            Public Shared PC21_A As Boolean
            Public Shared PC5_AB As Boolean
            Public Shared PC6_AB As Boolean
            Public Shared PC1_A As Boolean
            Public Shared PC1_B As Boolean
            Public Shared PC1_C As Boolean
            Public Shared PC1_D As Boolean
            Public Shared PC2_A As Boolean
            Public Shared PC14_AB As Boolean
            Public Shared XV1305_1 As Boolean
            Public Shared XV1305_2 As Boolean
            Public Shared XV1308 As Boolean
            Public Shared XV1309 As Boolean
            Public Shared XV1311 As Boolean
            Public Shared XV1318 As Boolean
            Public Shared XV1322_1 As Boolean
            Public Shared XV1322_2 As Boolean
            Public Shared XV1326 As Boolean
            Public Shared XV1327 As Boolean
            Public Shared XV1328 As Boolean
            Public Shared XV1329 As Boolean
            Public Shared XV1341_1 As Boolean
            Public Shared XV1341_2 As Boolean
            Public Shared XV1393_1 As Boolean
            Public Shared XV1393_2 As Boolean
            Public Shared XV1392 As Boolean
            Public Shared XV1395 As Boolean
            Public Shared XV1338 As Boolean
            Public Shared XV1332 As Boolean
            Public Shared XV1334 As Boolean
            Public Shared SV1361 As Boolean
            Public Shared SV1362 As Boolean
            Public Shared SV1363 As Boolean
            Public Shared SV1364 As Boolean
            Public Shared XV1333 As Boolean
            Public Shared FIC311_CAS As Boolean
            Public Shared FEEDER_ASL As Boolean
            Public Shared FEEDER_AFR As Boolean
            Public Shared FAILURE As Boolean
            Public Shared PREFILTERING As Boolean
            Public Shared FILTERING As Boolean
            Public Shared DISCHARGE As Boolean
            Public Shared WATERFLUSH As Boolean
            Public Shared SOLUTION_SUPPLY_PRO As Boolean
            Public Shared SOLUTION_FEEDING As Boolean

        End Structure
        Public Structure WORD_PLC_SRS_D6000 '1. BIT_PLC_SRS_IND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared LCV1340_1_MV As UnitWord
            Public Shared LCV1340_2_MV As UnitWord
            Public Shared FCV1311_1_MV As UnitWord
            Public Shared FCV1311_2_MV As UnitWord
            Public Shared FIC1311_1_PV As UnitWord
            Public Shared FIC1311_2_PV As UnitWord
            Public Shared PIC1312_PV As UnitWord
            Public Shared PIA1313_PV As UnitWord
            Public Shared PIA1314_PV As UnitWord
            Public Shared FIA1315_PV As UnitWord
            Public Shared TIA1316_PV As UnitWord
            Public Shared LIA1317_PV As UnitWord
            Public Shared LIA1321_PV As UnitWord
            Public Shared LIA1340_PV As UnitWord
            Public Shared LIA1302_PV As UnitWord
            Public Shared LIA1391_PV As UnitWord
            Public Shared LIA1330_PV As UnitWord
            Public Shared LIA1304_PV As UnitWord
            Public Shared LIA1381_PV As UnitWord
            Public Shared LTW5_PV As UnitWord
            Public Shared LTW7_PV As UnitWord
            Public Shared FI1305_1_PV As UnitWord
            Public Shared FI1305_2_PV As UnitWord
            Public Shared FI1308_PV As UnitWord
            Public Shared FI1309_PV As UnitWord
            Public Shared FI1392_PV As UnitWord
            Public Shared FI1393_1_PV As UnitWord
            Public Shared FI1393_2_PV As UnitWord
            Public Shared FI1332_PV As UnitWord
            Public Shared FT1338_PV As UnitWord
            Public Shared XI1332_PV As UnitWord
            Public Shared XI1335_PV As UnitWord
            Public Shared XI1331_PV As UnitWord
            Public Shared XI1365_PV As UnitWord
            Public Shared TI1307_1_PV As UnitWord
            Public Shared LINESPEED As UnitWord
            Public Shared TOP_Plating_Current As UnitWord
            Public Shared TOP_Efficiency As UnitWord
            Public Shared BOTPlating_Current As UnitWord
            Public Shared BOT_Efficiency As UnitWord
            Public Shared BASE_CURRENT As UnitWord

        End Structure
        Public Structure BIT_PLC_SRS_M8000 '1. BIT_PLC_SRS_IND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime

            Public Shared BUF_TANK As Boolean
            Public Shared CIR_TANK As Boolean
            Public Shared RESERVE1 As Boolean
            Public Shared RESERVE2 As Boolean
            Public Shared XV1341_1 As Boolean
            Public Shared XV1341_2 As Boolean
            Public Shared XV1341_3 As Boolean
            Public Shared XV311 As Boolean
            Public Shared XV1338 As Boolean
            Public Shared P1 As Boolean
            Public Shared P2 As Boolean
            Public Shared P3 As Boolean
            Public Shared P4 As Boolean
            Public Shared P5 As Boolean
            Public Shared RESERVE3 As Boolean
            Public Shared RESERVE4 As Boolean
            Public Shared RESERVE5 As Boolean
            Public Shared SRS_OP As Boolean
            Public Shared DIS_TR As Boolean
            Public Shared COILEND As Boolean
            Public Shared RESERVE6 As Boolean
            Public Shared RESERVE7 As Boolean
            Public Shared RESERVE8 As Boolean
            Public Shared RESERVE9 As Boolean
            Public Shared RESERVE10 As Boolean
            Public Shared FIC311_CAS As Boolean
            Public Shared FIC311_AUTO As Boolean
            Public Shared FIC1342_CAS As Boolean
            Public Shared FIC1342_AUTO As Boolean
            Public Shared RESERVE11 As Boolean
            Public Shared RESERVE12 As Boolean
            Public Shared RESERVE13 As Boolean

        End Structure
        Public Structure WORD_PLC_SRS_D5000 '3. WORD_PLC_SRS_IND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared COUNTER_ROUND_10000 As UnitWord
            Public Shared LINESPEED As UnitWord
            Public Shared CURRENT_TOTAL_FRONT As UnitWord
            Public Shared CURRENT_TOTAL_BACK As UnitWord
            Public Shared STRIP_THICKNESS As UnitWord
            Public Shared STRIP_WIDTH As UnitWord
            Public Shared BASIS_TARGET_FRONT As UnitWord
            Public Shared BASIS_TARGET_BACK As UnitWord
            Public Shared PLATING_EFFECT_FRONT As UnitWord
            Public Shared PLATING_EFFECT_BACK As UnitWord
            Public Shared RESERVE1 As UnitWord
            Public Shared FIC311_O2_SV As UnitWord
            Public Shared FIC1342_TANK_SV As UnitWord
            Public Shared RESERVE2 As UnitWord
            Public Shared RESERVE3 As UnitWord
            Public Shared RESERVE4 As UnitWord
            Public Shared LIA01_TANKLEVEL_PV As UnitWord
            Public Shared LICA1340_BUFTANKLEVEL_PV As UnitWord
            Public Shared PI313_DP_PV As UnitWord
            Public Shared BUFTANK_TIN_ION_CONC As UnitWord
            Public Shared CIRTANK_TIN_ION_CONC As UnitWord
            Public Shared FIC311_O2_PV As UnitWord
            Public Shared FIC1342_TANK_PV As UnitWord
            Public Shared FI315_PV As UnitWord
            Public Shared TI316_PV As UnitWord
            Public Shared PIC312_PV As UnitWord
            Public Shared PIC314_PV As UnitWord
            Public Shared RESERVE6 As UnitWord
            Public Shared RESERVE7 As UnitWord
            Public Shared RESERVE8 As UnitWord
            Public Shared RESERVE9 As UnitWord
            Public Shared RESERVE10 As UnitWord
        End Structure

        Public Structure BIT_PLC_SRS_IND '1. BIT_PLC_SRS_IND
                Public Shared Sub Updated()
                    更新時刻 = DateTime.Now
                End Sub
                Public Shared 更新時刻 As DateTime
                Public Shared StA_濃度測定完了 As Boolean
                Public Shared No3_循環濃度測定完了 As Boolean
                Public Shared No4_循環濃度測定完了 As Boolean
                Public Shared 予備 As Boolean
                Public Shared V6 As Boolean
                Public Shared V12 As Boolean
                Public Shared V13 As Boolean
                Public Shared V16 As Boolean
                Public Shared V19 As Boolean
                Public Shared P1 As Boolean
                Public Shared P2 As Boolean
                Public Shared P7 As Boolean
                Public Shared P8 As Boolean
                Public Shared P12 As Boolean
                Public Shared No3_調整材 As Boolean
                Public Shared No4_調整材 As Boolean
                Public Shared SRS_計測器異常 As Boolean
                Public Shared StA_濃度測定中 As Boolean
                Public Shared No3_循環濃度測定中 As Boolean
                Public Shared No4_循環濃度測定中 As Boolean
            End Structure
            Public Structure BIT_PLC_SRS_CTR '2. BIT_PLC_SRS_CTR
                Public Shared Sub Updated()
                    更新時刻 = DateTime.Now
                End Sub
                Public Shared 更新時刻 As DateTime
                Public Shared No3_スケジュール更新 As Boolean
                Public Shared No4_スケジュール更新 As Boolean
                Public Shared 溶解槽_錫投入中 As Boolean
                Public Shared SRS_運転指令 As Boolean
                Public Shared トレンドデータ送信完了 As Boolean
                Public Shared No3ETL運転中 As Boolean
                Public Shared No4ETL運転中 As Boolean

            End Structure
            Public Structure WORD_PLC_SRS_IND '3. WORD_PLC_SRS_IND
                Public Shared Sub Updated()
                    更新時刻 = DateTime.Now
                End Sub
                Public Shared 更新時刻 As DateTime
                Public Shared No3_LS As UnitWord
                Public Shared No4_LS As UnitWord
                Public Shared FCV2_CAS As UnitWord
                Public Shared FCV4_CAS As UnitWord
                Public Shared FCV7_CAS As UnitWord
                Public Shared FCV8_CAS As UnitWord
                Public Shared FCV10_CAS As UnitWord
                Public Shared FCV2_SV As UnitWord
                Public Shared FCV4_SV As UnitWord
                Public Shared FCV7_SV As UnitWord
                Public Shared FCV8_SV As UnitWord
                Public Shared FCV10_SV As UnitWord
                Public Shared StB_TL_PV As UnitWord
            End Structure
            Public Structure WORD_PLC_SRS_CTR '4.WORD_PLC_SRS_CTR
                Public Shared Sub Updated()
                    更新時刻 = DateTime.Now
                End Sub
                Public Shared 更新時刻 As DateTime
                Public Shared StA_TL_PV As UnitWord
                Public Shared No3_循環_TL_PV As UnitWord
                Public Shared No4_循環_TL_PV As UnitWord
                Public Shared 溶解槽_錫槽内差圧_PV As UnitWord
                Public Shared StA_COND_PV As UnitWord
                Public Shared No3_循環_CONC_PV As UnitWord
                Public Shared No4_循環_CONC_PV As UnitWord
                Public Shared FCV2_PV As UnitWord
                Public Shared FCV4_PV As UnitWord
                Public Shared FCV7_PV As UnitWord
                Public Shared FCV8_PV As UnitWord
                Public Shared FCV10_PV As UnitWord
                Public Shared StA_TL_SETVAL As UnitWord
                Public Shared StA_AVE As UnitWord
                Public Shared No3_AVE As UnitWord
                Public Shared No4_AVE As UnitWord
                Public Shared 溶解槽_槽内圧力 As UnitWord

            End Structure
        Public Class Word_PLC_SRS_Sch '5,6. WORD_PLC_SRS_SCH3
                Public Sub Updated()
                    更新時刻 = DateTime.Now
                End Sub
                Public 更新時刻 As DateTime
                Public Products As New List(Of ProductData)
                Public TopCoilChange As Boolean
            End Class
            Public Shared WORD_PLC_SRS_SCHS() As Word_PLC_SRS_Sch = {New Word_PLC_SRS_Sch(), New Word_PLC_SRS_Sch()}
        End Structure


    Public Structure SENDDATA
        Public Structure BIT_SRS_PLC_M9100 '7. BIT_SRS_PLC_TREND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub

            Public Shared 更新時刻 As DateTime

            Public Shared FIC311_CAS_ON As Boolean
            Public Shared FIC311_CAS_DRV As Boolean

        End Structure

        Public Structure WORD_SRS_PLC_D6100 '9. WORD_SRS_PLC_TREND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared FIC311_O2_SV As UnitWord

        End Structure

        Public Structure BIT_SRS_PLC_M8100 '7. BIT_SRS_PLC_TREND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub

            Public Shared 更新時刻 As DateTime

            Public Shared FIC311_CAS_ON As Boolean
            Public Shared FIC311_CAS_DRV As Boolean
            Public Shared RESERVE1 As Boolean
            Public Shared RESERVE2 As Boolean
            Public Shared RESERVE3 As Boolean
            Public Shared RESERVE4 As Boolean
            Public Shared RESERVE5 As Boolean
            Public Shared RESERVE6 As Boolean
            Public Shared RESERVE7 As Boolean
            Public Shared RESERVE8 As Boolean
            Public Shared RESERVE9 As Boolean
            Public Shared RESERVE10 As Boolean
            Public Shared RESERVE11 As Boolean
            Public Shared RESERVE12 As Boolean
            Public Shared RESERVE13 As Boolean
            Public Shared RESERVE14 As Boolean
            Public Shared RESERVE15 As Boolean
            Public Shared RESERVE16 As Boolean
            Public Shared RESERVE17 As Boolean
            Public Shared RESERVE18 As Boolean
            Public Shared RESERVE19 As Boolean
            Public Shared RESERVE20 As Boolean
            Public Shared RESERVE21 As Boolean
            Public Shared RESERVE22 As Boolean
            Public Shared RESERVE23 As Boolean
            Public Shared RESERVE24 As Boolean
            Public Shared RESERVE25 As Boolean
            Public Shared RESERVE26 As Boolean
            Public Shared RESERVE27 As Boolean
            Public Shared RESERVE28 As Boolean
            Public Shared RESERVE29 As Boolean
            Public Shared RESERVE30 As Boolean

        End Structure

        Public Structure WORD_SRS_PLC_D5100 '9. WORD_SRS_PLC_TREND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared COUNTER_ROUND_10000 As UnitWord
            Public Shared FIC311_O2_SV As UnitWord
            Public Shared RESERVE1 As UnitWord
            Public Shared RESERVE2 As UnitWord
            Public Shared RESERVE3 As UnitWord
            Public Shared RESERVE4 As UnitWord
            Public Shared RESERVE5 As UnitWord
            Public Shared RESERVE6 As UnitWord
            Public Shared RESERVE7 As UnitWord
            Public Shared RESERVE8 As UnitWord
            Public Shared RESERVE9 As UnitWord
            Public Shared RESERVE10 As UnitWord
            Public Shared RESERVE11 As UnitWord
            Public Shared RESERVE12 As UnitWord
            Public Shared RESERVE13 As UnitWord
            Public Shared RESERVE14 As UnitWord
            Public Shared RESERVE15 As UnitWord
            Public Shared RESERVE16 As UnitWord
            Public Shared RESERVE17 As UnitWord
            Public Shared RESERVE18 As UnitWord
            Public Shared RESERVE19 As UnitWord
            Public Shared RESERVE20 As UnitWord
            Public Shared RESERVE21 As UnitWord
            Public Shared RESERVE22 As UnitWord
            Public Shared RESERVE23 As UnitWord
            Public Shared RESERVE24 As UnitWord
            Public Shared RESERVE25 As UnitWord
            Public Shared RESERVE26 As UnitWord
            Public Shared RESERVE27 As UnitWord
            Public Shared RESERVE28 As UnitWord
            Public Shared RESERVE29 As UnitWord
            Public Shared RESERVE30 As UnitWord

        End Structure

        Public Structure BIT_SRS_PLC_TREND '7. BIT_SRS_PLC_TREND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared StA_濃度測定完了 As Boolean
            Public Shared No3_循環濃度測定完了 As Boolean
            Public Shared No4_循環濃度測定完了 As Boolean
            Public Shared 予備 As Boolean
            Public Shared P1 As Boolean
            Public Shared P2 As Boolean
            Public Shared P7 As Boolean
            Public Shared P8 As Boolean
            Public Shared P12 As Boolean
            Public Shared V6 As Boolean
            Public Shared V12 As Boolean
            Public Shared V13 As Boolean
            Public Shared V16 As Boolean
            Public Shared V19 As Boolean
            Public Shared No3_調整材 As Boolean
            Public Shared No4_調整材 As Boolean
            Public Shared SRS_自動運転中 As Boolean
            'Public Shared StA_濃度測定中 As Boolean
            'Public Shared No3_循環濃度測定中 As Boolean
            'Public Shared No4_循環濃度測定中 As Boolean

        End Structure
        Public Structure BIT_SRS_PLC_ANS '8. BIT_SRS_PLC_ANS
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared No3_スケジュール更新完了 As Boolean
            Public Shared No4_スケジュール更新完了 As Boolean
            Public Shared 溶解槽_酸素吹き込み中 As Boolean
            Public Shared SRS_運転中 As Boolean
            Public Shared トレンドデータ送信完了 As Boolean
        End Structure
        Public Structure WORD_SRS_PLC_TREND '9. WORD_SRS_PLC_TREND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared SRS_時刻_時 As UnitWord
            Public Shared SRS_時刻_分 As UnitWord
            Public Shared 溶解槽_酸素吹き込み量_PV As UnitWord
            Public Shared 溶解槽_槽内差圧_PV As UnitWord
            Public Shared FIC7 As UnitWord
            Public Shared FIC8 As UnitWord
            Public Shared FIC2 As UnitWord
            Public Shared FIC4 As UnitWord
            Public Shared StA_COND_PV As UnitWord
            Public Shared No3_循環_COND_PV As UnitWord
            Public Shared No4_循環_COND_PV As UnitWord
            Public Shared StA_TL_PV As UnitWord
            Public Shared StB_TL_PV As UnitWord
            Public Shared No3_循環_TL_PV As UnitWord
            Public Shared No4_循環_TL_PV As UnitWord
            Public Shared No3_錫消費量 As UnitWord
            Public Shared No4_錫消費量 As UnitWord
            Public Shared No3_錫溶解量 As UnitWord
            Public Shared No4_錫溶解量 As UnitWord
            Public Shared 合算_錫溶解量 As UnitWord
            Public Shared SRS_酸素吹き込み量_SV As UnitWord
            Public Shared SRS_ｽﾗｯｼﾞ発生率 As UnitWord
            Public Shared No3_LS As UnitWord
            Public Shared No4_LS As UnitWord
            Public Shared SRS_StA_H As UnitWord
            Public Shared SRS_StA_HH As UnitWord
            Public Shared SRS_StA_L As UnitWord
            Public Shared SRS_StA_LL As UnitWord
            Public Shared SRS_No3_FLOW_L As UnitWord
            Public Shared SRS_No4_FLOW_L As UnitWord
            Public Shared SRS_合算溶解補正量 As UnitWord
            Public Shared SRS_S1set As UnitWord
            Public Shared SRS_スケジュール受信 As UnitWord
            Public Shared SRS_No3_H As UnitWord
            Public Shared SRS_No3_L As UnitWord
            Public Shared SRS_No4_H As UnitWord
            Public Shared SRS_No4_L As UnitWord
            Public Shared SRS_No3_FLOW_H As UnitWord
            Public Shared SRS_No4_FLOW_H As UnitWord
            Public Shared SRS_稼働率 As UnitWord
            Public Shared SRS_稼働時間 As UnitWord
            Public Shared SRS_操業時間 As UnitWord
        End Structure
        Public Structure WORD_SRS_PLC_CTR '9. WORD_SRS_PLC_TREND
            Public Shared Sub Updated()
                更新時刻 = DateTime.Now
            End Sub
            Public Shared 更新時刻 As DateTime
            Public Shared SRS_ALAM As UnitWord
            Public Shared FIC2_SV As UnitWord
            Public Shared FIC4_SV As UnitWord
            Public Shared FIC7_SV As UnitWord
            Public Shared FIC8_SV As UnitWord
            Public Shared FIC10_SV As UnitWord
            Public Shared SRS_CALCERROR As UnitWord
        End Structure

    End Structure

    Public Structure ETLTANK_BAO

        Public Shared Sub Updated()
            更新時刻 = DateTime.Now
        End Sub
        Public Shared 更新時刻 As DateTime
        Public Shared Function PT313() As Double
            PT313 = RECVDATA.WORD_PLC_SRS_D6000.PIA1313_PV.ToDouble * PARAMETER.Search("a1").設定値 + PARAMETER.Search("a2").設定値
        End Function
        Public Structure BUF_TANK
            Private Shared TI_CONC_BAK As Double
            Public Shared Function TI_CONC() As Double
                If RECVDATA.BIT_PLC_SRS_M8000.BUF_TANK Then
                    TI_CONC_BAK = RECVDATA.WORD_PLC_SRS_D5000.BUFTANK_TIN_ION_CONC.ToDouble
                    TI_CONC = TI_CONC_BAK
                Else
                    TI_CONC = TI_CONC_BAK
                End If
            End Function
            Public Shared Function LEVEL() As Double
                LEVEL = RECVDATA.WORD_PLC_SRS_D6000.LIA1340_PV.ToDouble

            End Function

            'Public Shared Function LEVEL_PERCENT() As Double
            '    Dim ValH = RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.UpperLimit * RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Unit
            '    Dim ValL = RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.LowerLimit * RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Unit
            '    Dim Val = RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Word * RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Unit
            '    LEVEL_PERCENT = 100 * (Val - ValL) / (ValH - ValL)
            'End Function
            'Public Shared Function TI_CONC_PERCENT() As Double
            '    Dim CAH As Double = Double.Parse(PARAMETER.Search("CAH").Value)
            '    Dim CAL As Double = Double.Parse(PARAMETER.Search("CAL").Value)
            '    Dim Val As Double = TI_CONC()
            '    TI_CONC_PERCENT = 100 * (Val - CAL) / (CAH - CAL)
            'End Function
        End Structure
        Public Structure CIR_TANK
            Private Shared TI_CONC_BAK As Double
            Public Shared Function TI_CONC() As Double
                TI_CONC = SLS.TinIonValue
                'If RECVDATA.BIT_PLC_SRS_M8000.CIR_TANK Then
                '    TI_CONC_BAK = RECVDATA.WORD_PLC_SRS_D5000.CIRTANK_TIN_ION_CONC.ToDouble
                '    TI_CONC = TI_CONC_BAK
                'Else
                '    TI_CONC = TI_CONC_BAK
                'End If
            End Function
            Public Shared Function LEVEL() As Double
                LEVEL = RECVDATA.WORD_PLC_SRS_D6000.LIA1302_PV.ToDouble()
            End Function

            'Public Shared Function LEVEL_PERCENT() As Double
            '    Dim ValH = RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.UpperLimit * RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Unit
            '    Dim ValL = RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.LowerLimit * RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Unit
            '    Dim Val = RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Word * RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Unit
            '    LEVEL_PERCENT = 100 * (Val - ValL) / (ValH - ValL)
            'End Function

            'Public Shared Function TI_CONC_PERCENT() As Double
            '    Dim CAH As Double = Double.Parse(PARAMETER.Search("CAH").Value)
            '    Dim CAL As Double = Double.Parse(PARAMETER.Search("CAL").Value)
            '    Dim Val As Double = TI_CONC()
            '    TI_CONC_PERCENT = 100 * (Val - CAL) / (CAH - CAL)
            'End Function

        End Structure
    End Structure

    Public Structure ETLTANK_STP

        Public Shared Sub Updated()
            更新時刻 = DateTime.Now
        End Sub
        Public Shared 更新時刻 As DateTime
        Public Shared Function PT313() As Double
            PT313 = RECVDATA.WORD_PLC_SRS_D5000.PI313_DP_PV.ToDouble * PARAMETER.Search("a1").設定値 + PARAMETER.Search("a2").設定値
        End Function
        Public Structure BUF_TANK
            Private Shared TI_CONC_BAK As Double
            Public Shared Function TI_CONC() As Double
                If RECVDATA.BIT_PLC_SRS_M8000.BUF_TANK Then
                    TI_CONC_BAK = RECVDATA.WORD_PLC_SRS_D5000.BUFTANK_TIN_ION_CONC.ToDouble
                    TI_CONC = TI_CONC_BAK
                Else
                    TI_CONC = TI_CONC_BAK
                End If
            End Function
            Public Shared Function LEVEL() As Double
                LEVEL = RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.ToDouble
            End Function

            Public Shared Function LEVEL_PERCENT() As Double
                Dim ValH = RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.UpperLimit * RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Unit
                Dim ValL = RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.LowerLimit * RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Unit
                Dim Val = RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Word * RECVDATA.WORD_PLC_SRS_D5000.LICA1340_BUFTANKLEVEL_PV.Unit
                LEVEL_PERCENT = 100 * (Val - ValL) / (ValH - ValL)
            End Function
            Public Shared Function TI_CONC_PERCENT() As Double
                Dim CAH As Double = Double.Parse(PARAMETER.Search("CAH").Value)
                Dim CAL As Double = Double.Parse(PARAMETER.Search("CAL").Value)
                Dim Val As Double = TI_CONC()
                TI_CONC_PERCENT = 100 * (Val - CAL) / (CAH - CAL)
            End Function
        End Structure
        Public Structure CIR_TANK
            Private Shared TI_CONC_BAK As Double
            Public Shared Function TI_CONC() As Double
                If RECVDATA.BIT_PLC_SRS_M8000.CIR_TANK Then
                    TI_CONC_BAK = RECVDATA.WORD_PLC_SRS_D5000.CIRTANK_TIN_ION_CONC.ToDouble
                    TI_CONC = TI_CONC_BAK
                Else
                    TI_CONC = TI_CONC_BAK
                End If
            End Function
            Public Shared Function LEVEL() As Double
                LEVEL = RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.ToDouble
            End Function

            Public Shared Function LEVEL_PERCENT() As Double
                Dim ValH = RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.UpperLimit * RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Unit
                Dim ValL = RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.LowerLimit * RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Unit
                Dim Val = RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Word * RECVDATA.WORD_PLC_SRS_D5000.LIA01_TANKLEVEL_PV.Unit
                LEVEL_PERCENT = 100 * (Val - ValL) / (ValH - ValL)
            End Function

            Public Shared Function TI_CONC_PERCENT() As Double
                Dim CAH As Double = Double.Parse(PARAMETER.Search("CAH").Value)
                Dim CAL As Double = Double.Parse(PARAMETER.Search("CAL").Value)
                Dim Val As Double = TI_CONC()
                TI_CONC_PERCENT = 100 * (Val - CAL) / (CAH - CAL)
            End Function

        End Structure
    End Structure

    Public Structure ETLTANK
        Public Shared Sub Updated()
            更新時刻 = DateTime.Now
        End Sub
        Public Shared 更新時刻 As DateTime
        Public Shared Function 溶解槽_TL()
            溶解槽_TL = RECVDATA.WORD_PLC_SRS_CTR.溶解槽_錫槽内差圧_PV.ToDouble * 7.5 * 0.0102
        End Function
        Public Shared FCV2_PV As Double
        Public Shared FCV4_PV As Double
        Public Shared FCV7_PV As Double
        Public Shared FCV8_PV As Double
        Public Shared FCV10_PV As Double
        Public Shared FCV2_SV As Double
        Public Shared FCV4_SV As Double
        Public Shared FCV7_SV As Double
        Public Shared FCV8_SV As Double
        Public Shared FCV10_SV As Double
        Public Shared StA_TL_SETVAL As Double
        Public Shared StA_TL As Double
        Public Shared StA_CONC As Double
        Public Shared StA_AVE As Double
        Public Shared StB_TL As Double
        Public Shared No3_TL As Double
        Public Shared No3_CONC As Double
        Public Shared No3_AVE As Double
        Public Shared No3_Sn As Double
        Public Shared No4_TL As Double
        Public Shared No4_CONC As Double
        Public Shared No4_AVE As Double
        Public Shared No4_Sn As Double
    End Structure
    'HMI画面
    Public Enum LineConditionType
        ETL運転中 = 0
        ETL停止中 = 1
        調整材 = 2
    End Enum
    Public Enum CasModeType
        MAN = 0
        AUTO = 1
        CAS = 2
    End Enum


    Public Class ETLProdSch 'No3,4 ETL生産スケジュール
        Public Sub Updated()
            更新時刻 = DateTime.Now
        End Sub
        Public 更新時刻 As DateTime

        Public 運転中 As LineConditionType
        Public 制御実績時間 As Double
        Public ライン停止時間 As Double
        Public TA As Double
        Public TAC As Double
        Public TR As Double
        Public TZ0 As Double
        Public TE0 As Double
        Public Sf As Double
        Public S1p As Double
        Public S1f As Double
        Public dS1x As Double
        Public Products As New List(Of ProductData)
    End Class

    Public ETLPRODSCHS() As ETLProdSch = {New ETLProdSch, New ETLProdSch}

    Public Structure DISCOMBSCH '合算スケジュール


        Public Shared Sub Updated()
            更新時刻 = DateTime.Now
        End Sub
        Public Shared 更新時刻 As DateTime
        Public Shared 制御実績時間 As Double
        Public Shared Dissolution As New List(Of DisCombData)
        Public Shared dS1a_comp_time As Double
        Public Shared dS1b_comp_time As Double
        Public Shared dS1c_comp_time As Double
        Public Shared dS1d_comp_time As Double
        Public Shared dS1e_comp_time As Double
        Public Shared dS1f_comp_time As Double
        Public Shared dS1g_comp_time As Double
        Public Shared dS1h_comp_time As Double

        Public Shared S1s As Double
        Public Shared dS1a As Double
        Public Shared dS1b As Double
        Public Shared dS1c As Double
        Public Shared dS1d As Double
        Public Shared dS1e As Double
        Public Shared dS1f As Double
        Public Shared dS1g As Double
        Public Shared dS1h As Double
        Public Shared dS1x As Double
        Public Shared SdS1 As Double
        Public Shared SdS1Limit As Double = 400

        Public Shared S1SET As Double
        Public Shared O2SET As Double
        Public Shared O2 As Double
        Public Shared SL As Double

    End Structure
    'システム稼働時間
    Public Structure SYSTEMCONDITION
        Public Shared Sub Updated()
            更新時刻 = DateTime.Now
        End Sub
        Public Shared 更新時刻 As DateTime
        Public Shared システム稼働時間 As TimeSpan
        Public Shared ETL操業時間 As TimeSpan
        Public Shared Function 稼働率() As Double
            If ETL操業時間.TotalHours() >= 1.0 Then
                稼働率 = Math.Min(システム稼働時間.TotalHours() / ETL操業時間.TotalHours() * 100.0, 100)
            Else
                稼働率 = 0.0
            End If
        End Function
        Public Shared Lastシステム稼働時間 As TimeSpan
        Public Shared LastETL操業時間 As TimeSpan
        Public Shared Last稼働率 As Double
        Public Shared Sub Load(path As String)
            SYSTEMINFOIO.SYSTEMINFO_Load(path)
        End Sub
        Public Shared Sub Save(path As String)
            SetAttr(path, FileAttribute.Normal)
            SYSTEMINFOIO.SYSTEMINFO_Save(path)
            SetAttr(path, FileAttribute.Hidden)
        End Sub

        Public Shared Sub Import(path As String)
            SYSTEMCONDITION.ETL操業時間 = TimeSpan.FromSeconds(0)
            SYSTEMCONDITION.システム稼働時間 = TimeSpan.FromSeconds(0)
            SYSTEMINFOIO.SYSTEMINFO_Import(path)
        End Sub
        Public Shared Sub Export(path As String)
            SetAttr(path, FileAttribute.Normal)
            SYSTEMINFOIO.SYSTEMINFO_Export(path)
            SetAttr(path, FileAttribute.Hidden)
            SYSTEMCONDITION.更新時刻 = DateTime.Now
            SYSTEMCONDITION.LastETL操業時間 = SYSTEMCONDITION.ETL操業時間
            SYSTEMCONDITION.Lastシステム稼働時間 = SYSTEMCONDITION.システム稼働時間
            SYSTEMCONDITION.Last稼働率 = 稼働率()
            SYSTEMCONDITION.ETL操業時間 = TimeSpan.FromSeconds(0)
            SYSTEMCONDITION.システム稼働時間 = TimeSpan.FromSeconds(0)

        End Sub
        Public Shared Sub OverflowCheck()
            If システム稼働時間.TotalHours() >= 32767 OrElse ETL操業時間.TotalHours() >= 32767 Then
                Export(My.Application.Info.DirectoryPath & "\SystemCond.csv")
            End If
        End Sub
        'Public Shared CALCOK As Boolean
        'Public Shared ETHERNETOK(3) As Boolean


    End Structure
    Public Structure SRSCONDITION
        Public Shared Sub Updated()
            更新時刻 = DateTime.Now
        End Sub
        Public Shared 更新時刻 As DateTime

        Public Shared SRS自動ON As Boolean
        Public Shared NO3_LS As Double
        Public Shared No4_LS As Double
    End Structure

    Public Structure ParameterAttr
        Public Section As String
        Public Name As String
        Public Desc As String
        Public 下限値 As Double
        Public 上限値 As Double
        Public 設定値 As Double
        Public Value As String

    End Structure
    Public Structure NO3ETL循環タンクDATA
        Public Shared F3set As Double
        Public Shared F3 As Double
        Public Shared dF3L As Double
        Public Shared dF3H As Double

    End Structure
    Public Structure NO4ETL循環タンクDATA
        Public Shared F4set As Double
        Public Shared F4 As Double
        Public Shared dF4L As Double
        Public Shared dF4H As Double
    End Structure

    Public Structure 溶解槽DATA
        Public Shared Faset As Double
        Public Shared Fbset As Double
        Public Shared Fcset As Double
    End Structure

    Public Structure PARAMETER
        Public Shared Function Import(fpath As String) As Boolean

            Import = SRSFileIO.Parameter_Import(fpath)
        End Function
        Public Shared Function Export(fpath As String) As Boolean
            Export = SRSFileIO.Parameter_Export(fpath)
        End Function
        Public Shared Sub Clear()
            If Table.Count > 0 Then
                ReDim BackupTable(Table.Count - 1)
                Table.CopyTo(BackupTable)
            End If
            Table.Clear()
        End Sub
        Public Shared Sub Restore()
            If BackupTable.Length > 0 Then
                Table = New List(Of ParameterAttr)(BackupTable)
            End If
        End Sub

        Public Shared Function SetNewValue(section As String, name As String, value As String)
            'Dim Find = Table.Find(Function(x) x.Section.Contains(section) And x.Name.Contains(name))
            Dim Find = Table.Find(Function(x) StrComp(x.Section, section) = 0 And StrComp(x.Name, name) = 0)
            SetNewValue = Table.IndexOf(Find)
            Find.Value = value
            Double.TryParse(value, Find.設定値)
            If (SetNewValue >= 0) Then
                Table.Item(SetNewValue) = Find
            Else
                Find.Name = name
                Find.Section = section
                Table.Add(Find)
            End If
        End Function
        Public Shared Function Search(name As String) As ParameterAttr
            'Find = Table.Find(Function(x) x.Name.Contains(name))
            Dim idx = Table.FindIndex(Function(x) StrComp(x.Name, name) = 0)
            If idx < 0 Then
                Search.Name = ""
                Search.Value = ""
                Search.Desc = ""
                Throw New ArgumentException
            Else
                Search = Table.Item(idx)
            End If

        End Function

        Public Shared 更新時刻 As DateTime
        Public Shared Table As New List(Of ParameterAttr)
        Public Shared BackupTable() As ParameterAttr
    End Structure

    Public Structure TRENDGRAPHDATA
        Public Shared NO3錫消費SCH As New List(Of System.Drawing.PointF)
        Public Shared NO3錫溶解SCH As New List(Of System.Drawing.PointF)
        Public Shared NO4錫消費SCH As New List(Of System.Drawing.PointF)
        Public Shared NO4錫溶解SCH As New List(Of System.Drawing.PointF)
        Public Shared 錫溶解SCH As New List(Of System.Drawing.PointF)
        Public Shared O2SCH As New List(Of System.Drawing.PointF)
        Public Shared SLSCH As New List(Of System.Drawing.PointF)
        Public Shared 錫溶解実績 As New List(Of System.Drawing.PointF)
        Public Shared O2実績 As New List(Of System.Drawing.PointF)
        Public Shared SL実績 As New List(Of System.Drawing.PointF)
    End Structure
    Public Structure InterfaceMapItem
        Public offset As Long
        Public fldname As String
        Public comment As String
        Public unit As Double
        Public lowlimit As Int16
        Public upperlimit As Int16
        Public devcode As String

        Public o As Object
        Public Sub SetField(val As Boolean)
            Try
                o.GetType().InvokeMember(fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetField, Nothing, o, New Object() {val})
            Catch ex As Exception
                Debugger.Log(0, "ERROR", fldname & "が見つかりません")
            End Try
        End Sub
        Public Sub SetField(val As UInt16)
            Try
                Dim field As New UnitWord(val, unit, lowlimit, upperlimit)
                o.GetType().InvokeMember(fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetField, Nothing, o, New Object() {field})
            Catch ex As Exception
                Debugger.Log(0, "ERROR", fldname & "が見つかりません")
            End Try

        End Sub
        Public Function GetBoolean() As Boolean
            Try
                Dim field = o.GetType().InvokeMember(fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, o, Nothing)
                GetBoolean = field
            Catch ex As Exception
                GetBoolean = False
                Debugger.Log(0, "ERROR", fldname & "が見つかりません")
            End Try
        End Function
        Public Function GetWord() As UInt16
            Try
                Dim field = o.GetType().InvokeMember(fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, o, Nothing)
                GetWord = field.Word
            Catch ex As Exception
                GetWord = 0
                Debugger.Log(0, "ERROR", fldname & "が見つかりません")
            End Try
        End Function
        Public Function GetField() As Object
            Try
                GetField = o.GetType().InvokeMember(fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, o, Nothing)
            Catch ex As Exception
                GetField = Nothing
                Debugger.Log(0, "ERROR", fldname & "が見つかりません")
            End Try
        End Function

    End Structure
    Public Structure BlockDeviceItem
        Public address As Integer
        Public devcode As String
        Public devNum As Int16
        Public offset As Int16
    End Structure

    Public Structure InterfaceMap
        Public address As Integer
        Public strname As String
        Public devcode As String
        Public range As UInt16
        Public interfacelist As List(Of InterfaceMapItem)
        Public blockdevicelist As List(Of BlockDeviceItem)

        Public Sub New(path As String, _name As String, _address As Integer, _devcode As String, o As Object)
            Dim bdi As BlockDeviceItem
            Dim poffset As Int16 = -1
            strname = _name
            address = _address
            devcode = _devcode
            interfacelist = SRSFileIO.Interface_Import(path, _devcode, o)
            blockdevicelist = New List(Of BlockDeviceItem)
            range = 0
            bdi.address = address
            bdi.devcode = _devcode
            bdi.devNum = 0
            bdi.offset = 0
            For I = 0 To interfacelist.Count - 1
                Dim item = interfacelist(I)
                range = Math.Max(range, item.offset)
                If I > 0 Then
                    '連続したアドレスまたは同じデバイスコードかををチェック
                    If item.offset - poffset > 1 Or bdi.devcode <> item.devcode Then
                        blockdevicelist.Add(bdi)
                        bdi.address = address + item.offset
                        bdi.offset = I
                        bdi.devNum = 0
                        bdi.devcode = item.devcode
                    End If
                Else
                    bdi.address = address + item.offset
                    bdi.devcode = item.devcode
                End If
                poffset = item.offset
                bdi.devNum = bdi.devNum + 1
            Next
            blockdevicelist.Add(bdi)
        End Sub
        Public Sub UpdateFromArray(ByRef bitarray() As Boolean, Optional alam As ALAMDELEGATE = Nothing)
            For Each item In interfacelist
                item.SetField(bitarray(item.offset))
            Next
        End Sub
        Public Sub UpdateFromArray(ByRef wordarray() As UInt16, Optional alam As ALAMDELEGATE = Nothing)
            For Each item In interfacelist
                item.SetField(wordarray(item.offset))
            Next
        End Sub
        Public Function GetBitarray(Optional alam As ALAMDELEGATE = Nothing) As Boolean()
            Dim bitarray(range) As Boolean
            For Each item In interfacelist
                bitarray(item.offset) = item.GetBoolean()
            Next
            GetBitarray = bitarray
        End Function
        Public Function GetWordarray(Optional alam As ALAMDELEGATE = Nothing) As Int16()
            Dim wordarray(range) As Int16
            For Each item In interfacelist
                wordarray(item.offset) = item.GetWord()
            Next
            GetWordarray = wordarray
        End Function

    End Structure
    Public Structure CSINFO

        Public Shared IEP As IPEndPoint
        Public Shared Sub Load(path As String)
            SRSFileIO.CS_Setting(path)
        End Sub
        Public Shared Function Connect() As Integer
            Connect = CSIO.Connect(IEP)
        End Function
        Public Shared Function Disconnect() As Integer
            Disconnect = CSIO.Disconnect()
        End Function
        Public Shared Function UpdateCoilData(Optional Startup As Boolean = False) As CoilSchdule
            UpdateCoilData = CSIO.CheckAndUpdateSchedule(Startup)
        End Function
        Public Shared Function SendRejectMessage() As CoilSchdule
            SendRejectMessage = CSIO.RejectCoil()
        End Function

    End Structure
    Public Enum FIELDTYPE
        FT_INT = 1
        FT_STR = 2
        FT_BYTE = 3
        FT_INT32 = 4
    End Enum
    Public Structure L1Item
        Public Address As Long
        Public No As Integer
        Public Fieldname As String
        Public FieldSize As Integer
        Public FieldType As FIELDTYPE
        Public FieldUnit As Double
        Public FieldLower As UInt16
        Public FieldUpper As UInt16
    End Structure

    Public Structure L1InterfaceMap
        Private ByteBuffer As Byte()
        Public Sub New(path As String, _MessageNo As Integer, _Size As Integer, _timeSpan As Integer)
            MessageNo = _MessageNo
            timeSpan = _timeSpan
            l1itemlist = SRSFileIO.L1Interface_Import(path)
            If _Size > 0 Then
                ReDim ByteBuffer(_Size - 1)
            End If
        End Sub
        Public Function GetField(fieldname As String) As Object
            Dim query As IEnumerable(Of Integer) = l1itemlist.Where(
                Function(x)
                    Return x.Fieldname = fieldname
                End Function).Select(
                Function(x)
                    Return x.No
                End Function)
            If Not query Is Nothing Then
                Return GetField(query.First())
            End If
            Return Nothing
        End Function
        Public Function GetField(No As Integer) As Object
            Dim item = l1itemlist(No - 1)
            Select Case item.FieldType
                Case FIELDTYPE.FT_INT32
                    Return BitConverter.ToInt32(ByteBuffer, item.Address) * item.FieldUnit
                Case FIELDTYPE.FT_INT
                    Return BitConverter.ToUInt16(ByteBuffer, item.Address) * item.FieldUnit
                Case FIELDTYPE.FT_STR
                    Return Encoding.UTF8.GetString(ByteBuffer.ToList().GetRange(item.Address, item.FieldSize).ToArray())
            End Select
            Return Nothing
        End Function
        Public Sub SetField(fieldname As String, Value As Object)
            Dim query As IEnumerable(Of Integer) = l1itemlist.Where(
                Function(x)
                    Return x.Fieldname = fieldname
                End Function).Select(
                Function(x)
                    Return x.No
                End Function)
            If Not query Is Nothing Then
                SetField(query.First(), Value)
            End If
        End Sub
        Public Sub SetField(No As Integer, Value As Object)
            If Value.GetType().Name = "Boolean" Then
                Value = Value * -1
            End If
            Dim item = l1itemlist(No - 1)
            Try
                Select Case item.FieldType
                    Case FIELDTYPE.FT_INT32
                        Dim onedata(0) As Int32
                        onedata(0) = Convert.ToInt32(Value / item.FieldUnit)
                        Buffer.BlockCopy(onedata, 0, ByteBuffer, item.Address, item.FieldSize)

                    Case FIELDTYPE.FT_INT
                        Dim onedata(0) As UInt16
                        onedata(0) = Convert.ToUInt16(Value / item.FieldUnit)
                        Buffer.BlockCopy(onedata, 0, ByteBuffer, item.Address, item.FieldSize)
                    Case FIELDTYPE.FT_STR
                        Dim str As String = Value
                        Buffer.BlockCopy(Encoding.ASCII.GetBytes(str), 0, ByteBuffer, item.Address, item.FieldSize)
                End Select
            Catch ex As Exception
            End Try

        End Sub
        Public Sub SetBuffer(_Buffer As Byte())
            ByteBuffer = _Buffer
        End Sub
        Public Function GetBuffer() As Byte()
            Return ByteBuffer
        End Function
        Public MessageNo As Int32
        Public timeSpan As Integer
        Public l1itemlist As List(Of L1Item)

    End Structure

    Public Structure L1INFO
        Public Shared Function Connection()
            If SendTcp Is Nothing Then
                Return -1
            End If
            If RecvTcp Is Nothing Then
                Return -1
            End If
            Return Not (SendTcp.Connected And RecvTcp.Connected)
        End Function
        Public Shared SendEventType As TaskEventArgs.EventType
        Public Shared RecvEventType As TaskEventArgs.EventType
        Public Shared SendTcp As TcpClient
        Public Shared RecvTcp As TcpClient

        Public Shared ServerRunnning As Boolean
        Public Shared L1MessageMap As Dictionary(Of Integer, L1InterfaceMap)
        Public Shared IEP_SERVER As IPEndPoint
        Public Shared IEP_LISTEN As IPEndPoint


        Public Shared LockItem As New Object
        Public Shared RecieveNewMeasure As Boolean
        Public Shared RecieveNewCoilLow As Boolean
        Public Shared RecieveNewCoilHigh As Boolean
        Public Shared SenderTask As Task
        Public Shared RecieverTask As Task


        Public Shared Sub Load(path As String)
            SRSFileIO.L1_Setting(path)
        End Sub
        Public Shared Sub Build(path As String)
            L1MessageMap = InterfaceBuilder.BuildL1(path)
        End Sub

        Public Shared Sub Start()

            SenderTask = Task.Run(AddressOf L1IO.Sender)
            RecieverTask = Task.Run(AddressOf L1IO.Reciever)
        End Sub
        Public Shared Sub Finish()
            ServerRunnning = False
        End Sub

    End Structure

    Public Structure PLCINFO
        Public Shared IEP As IPEndPoint
        Public Shared NetNo As Int16
        Public Shared PCNo As Int16
        Public Shared Sub Load(path As String)
            SRSFileIO.PLC_Setting(path)
        End Sub
        Public Shared Function Connect() As Integer
            Connect = PLCIO.Connect(IEP)
        End Function
        Public Shared Function Disconnect() As Integer
            Disconnect = PLCIO.Disconnect()
        End Function
        Public Shared Function WriteBlockData(wordblock As InterfaceMap, bitblock As InterfaceMap) As Integer
            WriteBlockData = PLCIO.WriteBlockData(NetNo, PCNo, wordblock, bitblock)
        End Function
        Public Shared Function ReadBlockData(wordblock As InterfaceMap, bitblock As InterfaceMap) As Integer
            ReadBlockData = PLCIO.ReadBlockData(NetNo, PCNo, wordblock, bitblock)
        End Function
        Public Shared Function WriteData(address As Integer, devcode As String, ByRef bitarray() As Boolean) As Integer
            WriteData = PLCIO.WriteData(NetNo, PCNo, address, devcode, bitarray)
        End Function
        Public Shared Function WriteData(address As Integer, devcode As String, ByRef wordarray() As Int16) As Integer
            WriteData = PLCIO.WriteData(NetNo, PCNo, address, devcode, wordarray)
        End Function
        Public Shared Function ReadBitdata(address As Integer, devcode As String, size As UInt16, ByRef ecode As Integer) As Boolean()
            ReadBitdata = PLCIO.ReadBitdata(NetNo, PCNo, address, devcode, size, ecode)
        End Function
        Public Shared Function ReadWorddata(address As Integer, devcode As String, size As UInt16, ByRef ecode As Integer) As Int16()
            ReadWorddata = PLCIO.ReadWorddata(NetNo, PCNo, address, devcode, size, ecode)
        End Function


    End Structure
    'Public Structure PARAMETER
    '    Public Shared 更新時刻 As DateTime
    '    Public Structure 溶存酸素効率Data
    '        Public 酸素吹込量 As Double
    '        Public 効率 As Double
    '    End Structure
    '    Public Shared 溶存酸素効率(10) As 溶存酸素効率Data
    '    Public Shared Csi As Double

    '    Public Shared VaHH As Double
    '    'Public Shared dVaHH As Double

    '    Public Shared Td3 As Double
    '    Public Shared Cob3 As Double
    '    Public Shared C3FL As Double
    '    Public Shared Tc9 As Double
    '    Public Shared α9 As Double
    '    Public Shared C3FH As Double
    '    Public Shared Tc10 As Double
    '    Public Shared α10 As Double

    '    Public Shared Td4 As Double
    '    Public Shared Cob4 As Double
    '    Public Shared C4FL As Double
    '    Public Shared Tc11 As Double
    '    Public Shared α11 As Double
    '    Public Shared C4FH As Double
    '    Public Shared Tc12 As Double
    '    Public Shared α12 As Double

    '    Public Shared Fsup As Double

    '    Public Shared Fcset As Double

    '    Public Shared Tc1 As Double
    '    Public Shared CAdH As Double
    '    Public Shared Tc2 As Double
    '    Public Shared CAH As Double

    '    Public Shared Tc3 As Double
    '    Public Shared CAdL As Double
    '    Public Shared Tc4 As Double
    '    Public Shared CAL As Double

    '    Public Shared Caref As Double

    'End Structure
    Public Enum スケジュール変更ステータス
        SCH_変更なし = 0
        SCH_先頭ロット更新 = 1
        SCH_先頭コイル更新 = 2
        SCH_その他 = 3
    End Enum


    'タスク完了通知
    Public Class TaskEventArgs
        Inherits EventArgs
        Public Shared 更新時刻 As DateTime
        Public Enum EventType
            TSK_初期化中 = 0
            SRS_トレンド60sec_送信完了 = 1
            SRS_01sec_送信完了 = 2
            SRS_アンサーバック送信完了 = 3
            SRS_演算完了 = 4
            PLC_01sec_受信完了 = 5
            PLC_20sec_受信完了 = 6
            SCH_NO3スケジュール受信完了 = 7
            SCH_NO4スケジュール受信完了 = 8
            SRS_パラメータ変更 = 9
            SRS_トレンド更新 = 10
            SCH_NO34スケジュール受信完了 = 15
            SRS_更新完了 = 16
            SCH_スケジュール受信完了 = 17
            SCH_スケジュール更新なし = 18
            SCH_スケジュールなし = 19

            SRS_20sec_送信完了 = 20

            PLC_受信エラー = -1
            PLC_送信エラー = -2
            SRS_演算エラー = -3
            SRS_更新エラー = -4
            PLC_オープンリトライ中 = -5
            CS_オープンリトライ中 = -6
            CS_受信エラー = -7
            L1_オープンリトライ中 = -8

            Reply_Normal_End_00E0 = &HE0
            Reply_Abnormal_MessageNo_Error_50E0 = &H50E0
            Reply_Abnormal_Sequense_Error_51E0 = &H51E0
            Reply_Abnormal_Datalength_Error_52E0 = &H52E0
        End Enum
        Public etype As EventType
        Public ex As Exception
    End Class
    'デバッグ機能
    Public Structure DEBUG
        Public Shared Hide
        Public Shared BAISOKU As Double
        Public Shared Flag As Boolean
        Public Shared No3ETL As Boolean
        Public Shared No4ETL As Boolean
        Public Shared No3ETLCS As CheckState
        Public Shared No4ETLCS As CheckState

        Public Shared AutoCoilChange As Boolean
        Public Shared SnapShotTrigger As Boolean
        Public Shared Capture As Boolean
        Public Shared Logging As Boolean
    End Structure

    Public Structure BackupVariable
        Public FCV2_PV As Single
        Public FCV4_PV As Single
        Public FCV7_PV As Single
        Public FCV8_PV As Single
        Public FCV10_PV As Single
        Public FCV2_SV As Single
        Public FCV4_SV As Single
        Public FCV7_SV As Single
        Public FCV8_SV As Single
        Public FCV10_SV As Single
        Public FIC2_SV As Single
        Public FIC4_SV As Single
        Public FIC7_SV As Single
        Public FIC8_SV As Single
        Public FIC10_SV As Single
        Public StA_TL As Single
        Public StA_TL_SETVAL As Single
        Public StA_CONC As Single
        Public StA_AVE As Single
        Public StB_TL As Single
        Public No3_TL As Single
        Public No3_CONC As Single
        Public No3_AVE As Single
        Public No3_Sn As Single
        Public No4_TL As Single
        Public No4_CONC As Single
        Public No4_AVE As Single
        Public No4_Sn As Single
        Public F3set As Single
        Public F3 As Single
        Public dF3L As Single
        Public dF3H As Single
        Public F4set As Single
        Public F4 As Single
        Public dF4L As Single
        Public dF4H As Single
        Public Faset As Single
        Public Fbset As Single
        Public Fcset As Single
    End Structure
    Public Structure CHECKVARIABLE
        Public Shared OldData As BackupVariable
        Public Shared NewData As BackupVariable
        Public Shared Sub Store()
            OldData = NewData
            NewData.FCV2_PV = Math.Round(ETLTANK.FCV2_PV, 2)
            NewData.FCV4_PV = Math.Round(ETLTANK.FCV4_PV, 2)
            NewData.FCV7_PV = Math.Round(ETLTANK.FCV7_PV, 2)
            NewData.FCV8_PV = Math.Round(ETLTANK.FCV8_PV, 2)
            NewData.FCV10_PV = Math.Round(ETLTANK.FCV10_PV, 2)
            NewData.FCV2_SV = Math.Round(ETLTANK.FCV2_SV, 2)
            NewData.FCV4_SV = Math.Round(ETLTANK.FCV4_SV, 2)
            NewData.FCV7_SV = Math.Round(ETLTANK.FCV7_SV, 2)
            NewData.FCV8_SV = Math.Round(ETLTANK.FCV8_SV, 2)
            NewData.FCV10_SV = Math.Round(ETLTANK.FCV10_SV, 2)

            NewData.StA_TL = Math.Round(ETLTANK.StA_TL, 2)
            NewData.StA_TL_SETVAL = Math.Round(ETLTANK.StA_TL_SETVAL, 2)
            NewData.StA_CONC = Math.Round(ETLTANK.StA_CONC, 2)
            NewData.StA_AVE = Math.Round(ETLTANK.StA_AVE, 2)
            NewData.StB_TL = Math.Round(ETLTANK.StB_TL, 2)
            NewData.No3_TL = Math.Round(ETLTANK.No3_TL, 2)
            NewData.No3_CONC = Math.Round(ETLTANK.No3_CONC, 2)
            NewData.No3_AVE = Math.Round(ETLTANK.No3_AVE, 2)
            NewData.No3_Sn = Math.Round(ETLTANK.No3_Sn, 2)
            NewData.No4_TL = Math.Round(ETLTANK.No4_TL, 2)
            NewData.No4_CONC = Math.Round(ETLTANK.No4_CONC, 2)
            NewData.No4_AVE = Math.Round(ETLTANK.No4_AVE, 2)
            NewData.No4_Sn = Math.Round(ETLTANK.No4_Sn, 2)

            NewData.FIC2_SV = Math.Round(NO3ETL循環タンクDATA.F3set, 2)
            NewData.FIC4_SV = Math.Round(NO4ETL循環タンクDATA.F4set, 2)
            NewData.FIC7_SV = Math.Round(溶解槽DATA.Faset, 2)
            NewData.FIC8_SV = Math.Round(溶解槽DATA.Fbset, 2)
            NewData.FIC10_SV = Math.Round(DISCOMBSCH.O2SET, 2)

            NewData.F3set = Math.Round(NO3ETL循環タンクDATA.F3set, 2)
            NewData.F3 = Math.Round(NO3ETL循環タンクDATA.F3, 2)
            NewData.dF3L = Math.Round(NO3ETL循環タンクDATA.dF3L, 2)
            NewData.dF3H = Math.Round(NO3ETL循環タンクDATA.dF3H, 2)
            NewData.F4set = Math.Round(NO4ETL循環タンクDATA.F4set, 2)
            NewData.F4 = Math.Round(NO4ETL循環タンクDATA.F4, 2)
            NewData.dF4L = Math.Round(NO4ETL循環タンクDATA.dF4L, 2)
            NewData.dF4H = Math.Round(NO4ETL循環タンクDATA.dF4H, 2)
            NewData.Faset = Math.Round(溶解槽DATA.Faset, 2)
            NewData.Fbset = Math.Round(溶解槽DATA.Fbset, 2)
            NewData.Fcset = Math.Round(溶解槽DATA.Fcset, 2)
        End Sub
        Public Shared Function Transition() As Boolean
            Transition = Not OldData.Equals(NewData)
        End Function

    End Structure


End Module
