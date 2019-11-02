﻿Imports System.Windows.Input
Imports System.Threading

Public Class Frm00Startup
    Private Task04 As Task04RecvL1Measure_01sec
    Private Task05 As Task05RecvL1CoilSchdule_01sec
    Private Task03 As Task03Control_01sec
    Private Task01 As Task01SendPLC_20sec
    Private Task02 As Task02SLS_60sec
    Private Task06 As Task06Trend_60sec

    Private Sub Task01Timer_SRS2PLC_20sec(sender As Object, e As EventArgs) Handles Task1Timer.Tick
        Dim col As Color
        col = LB_TASK1.ForeColor
        LB_TASK1.ForeColor = LB_TASK1.BackColor
        LB_TASK1.BackColor = col
        Dim status As TaskEventArgs = Task01.Run()
        LB_TASK1_STATUS.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") & " : " & [Enum].GetName(status.etype.GetType(), status.etype)
        'SYSTEMCONDITION.ETHERNETOK(0) = status.etype >= 0
        If (status.etype < 0) Then
            Task1Timer.Stop()
            Task1Timer.Interval = 1000
            Task1Timer.Start()
        Else
            If Task1Timer.Interval <> 20000 Then
                Task1Timer.Stop()
                Task1Timer.Interval = 20000
                Task1Timer.Start()
            End If
        End If
    End Sub
    Private Sub Task02Timer_SLS_60sec(sender As Object, e As EventArgs) Handles Task2Timer.Tick
        Dim col As Color
        col = LB_TASK2.ForeColor
        LB_TASK2.ForeColor = LB_TASK2.BackColor
        LB_TASK2.BackColor = col
        Dim status As TaskEventArgs = Task02.Run()
        'SYSTEMCONDITION.ETHERNETOK(1) = status.etype >= 0
        LB_TASK2_STATUS.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") & " : " & [Enum].GetName(status.etype.GetType(), status.etype)
    End Sub
    Private Sub Task03Timer_Control_1sec(sender As Object, e As EventArgs) Handles Task3Timer.Tick
        If DEBUG.Hide Then
            Dim keyD = Keyboard.GetKeyStates(Key.D)
            Dim keyALT = Keyboard.GetKeyStates(Key.LeftAlt)
            Dim keySFT = Keyboard.GetKeyStates(Key.LeftShift)
            If (keyD And KeyStates.Down) AndAlso (keyALT And KeyStates.Down) AndAlso (keySFT And KeyStates.Down) Then
                WindowHide(False)
            End If
        End If

        Dim col As Color
        col = LB_TASK3.ForeColor
        LB_TASK3.ForeColor = LB_TASK3.BackColor
        LB_TASK3.BackColor = col
        Dim status As TaskEventArgs = Task03.Run()
        'SYSTEMCONDITION.CALCOK = status.etype = TaskEventArgs.EventType.SRS_演算完了

        LB_TASK3_STATUS.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") & " : " & [Enum].GetName(status.etype.GetType(), status.etype)
    End Sub
    Private Sub Task04Timer_PLC2SRS_20sec(sender As Object, e As EventArgs) Handles Task4Timer.Tick

        Dim col As Color
        col = LB_TASK4.ForeColor
        LB_TASK4.ForeColor = LB_TASK4.BackColor
        LB_TASK4.BackColor = col
        Dim status As TaskEventArgs = Task04.Run()
        'SYSTEMCONDITION.ETHERNETOK(2) = status.etype >= 0
        LB_TASK4_STATUS.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") & " : " & [Enum].GetName(status.etype.GetType(), status.etype)
        If (status.etype < 0) Then
            Task4Timer.Stop()
            Task4Timer.Interval = 1000
            Task4Timer.Start()

        Else
            If Task4Timer.Interval <> 1000 Then
                Task4Timer.Stop()
                Task4Timer.Interval = 1000
                Task4Timer.Start()
            End If
        End If
    End Sub
    Private Sub Task05Timer_SRS2CS_01sec(sender As Object, e As EventArgs) Handles Task5Timer.Tick
        Dim col As Color
        col = LB_TASK5.ForeColor
        LB_TASK5.ForeColor = LB_TASK5.BackColor
        LB_TASK5.BackColor = col
        Dim status As TaskEventArgs = Task05.Run()
        'SYSTEMCONDITION.ETHERNETOK(3) = status.etype >= 0
        LB_TASK5_STATUS.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") & " : " & [Enum].GetName(status.etype.GetType(), status.etype)
        If (status.etype < 0) Then
            Task5Timer.Stop()
            Task5Timer.Interval = 1000
            Task5Timer.Start()

        Else
            If Task5Timer.Interval <> 1000 Then
                Task5Timer.Stop()
                Task5Timer.Interval = 1000
                Task5Timer.Start()
            End If
        End If
    End Sub
    Private Sub Task06Timer_DataStrage_60sec(sender As Object, e As EventArgs) Handles Task6Timer.Tick
        Dim col As Color
        col = LB_TASK6.ForeColor()
        LB_TASK6.ForeColor = LB_TASK6.BackColor
        LB_TASK6.BackColor = col
        Dim status As TaskEventArgs = Task06.Run()
        LB_TASK6_STATUS.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") & " : " & [Enum].GetName(status.etype.GetType(), status.etype)
        If (status.etype < 0) Then
            Task6Timer.Stop()
            Task6Timer.Interval = 1000
            Task6Timer.Start()
        Else
            If Task6Timer.Interval <> 60000 Then
                Task6Timer.Stop()
                Task6Timer.Interval = 60000
                Task6Timer.Start()
            End If
        End If

    End Sub
    Private Sub FormInit(frm As Form)
        'frm.WindowState = FormWindowState.Minimized : frm.Show() : frm.WindowState = FormWindowState.Normal : frm.Hide()
        'frm.WindowState = FormWindowState.Maximized
        frm.Show() : frm.Hide()
        frm.MaximizeBox = False
    End Sub
    Private Function PLC_Connection_Check() As Boolean
        PLC_Connection_Check = PLCINFO.Connect() = 0
    End Function
    Private Function CS_Connection_Check() As Boolean
        CS_Connection_Check = CSINFO.Connect() = 0
    End Function
    Private Function L1_Connection_Check() As Boolean
        L1_Connection_Check = L1INFO.Connection = 0
    End Function
    Private Sub Task07_FormLoad(sender As Object, e As EventArgs) Handles MyBase.Load

        '初期パラメータのロード
        '・分散処理の登録
        '   通信と演算を6タスクに分散して処理する
        '
        '・タスクリスト1

        '
        'Task01:PLC送信 20sec(トレンドデータ)
        'Task03:SRS演算
        'Task04:PLC受信 20sec
        'Task06:トレンド更新 60sec

        My.Computer.FileSystem.CreateDirectory("C:\DATASTRAGE")
        My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Capture")

        PARAMETER.Clear()
        If Not My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\PARASetting.csv") Then
            My.Computer.FileSystem.CopyFile(My.Application.Info.DirectoryPath & "\PARASettingDef.csv", My.Application.Info.DirectoryPath & "\PARASetting.csv", True)
        End If
        Do While Not PARAMETER.Import(My.Application.Info.DirectoryPath & "\PARASetting.csv")
            MessageBox.Show("ファイル[PARASetting.csv]は他のアプリケーションで開かれているため開くことができません。他のアプリケーションを閉じてOKを押してください。", "オープンエラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Loop
        PARAMETER.Import(My.Application.Info.DirectoryPath & "\pwsetting.csv")
        'PLCとの接続情報
        PLCINFO.Load(My.Application.Info.DirectoryPath & "\PLCSetting.csv")
        Dim ifmap = InterfaceBuilder.Build(My.Application.Info.DirectoryPath & "\InterfaceSetting.csv")
        'コイルスケジューラとの接続情報
        'CSINFO.Load(My.Application.Info.DirectoryPath & "\CSSetting.csv")

        'L1とのインターフェイスと変数バインディング(本体）
        L1INFO.Load(My.Application.Info.DirectoryPath & "\L1Setting.csv")
        L1INFO.Build(My.Application.Info.DirectoryPath & "\L1InterfaceMapping.csv")

        'item.SetBuffer(buffer)
        'item.SetField(1, &H50E0)
        'item.SetField(2, &H40)
        'item.SetField(3, &H4)
        'item.SetField(4, "0001")
        'item.SetField(5, "000000")

        'Dim hdr = item.GetField(1)
        'Dim dl = item.GetField(2)
        'Dim msgno = item.GetField(3)
        'Dim seq = item.GetField(4)
        'Dim tim = item.GetField(5)
        'アラーム情報
        ALAM.Load(My.Application.Info.DirectoryPath & "\AlamSetting.csv")
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\AlamRecoard.csv") Then
            ALAM.Import(My.Application.Info.DirectoryPath & "\AlamRecoard.csv")
        End If

        'アナリシスデータ読込み
        SLS.Load(My.Application.Info.DirectoryPath & "\SLSSetting.csv")
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\SLSRecoard.csv") Then
            SLS.Import(My.Application.Info.DirectoryPath & "\SLSRecoard.csv")
        End If

        'システム情報
        SYSTEMCONDITION.更新時刻 = DateTime.MinValue
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\SystemCondSuspend.csv") Then
            SYSTEMCONDITION.Load(My.Application.Info.DirectoryPath & "\SystemCondSuspend.csv")
        End If

        L1INFO.Start()


        'コイルスケジューラ起動チェック
        'Dim ConnectProgressDialog As New PopupProgressBar

        'ConnectProgressDialog.ProgressDlg = AddressOf CS_Connection_Check
        'ConnectProgressDialog.DisplayText = "Connecting CS : " & CSINFO.IEP.Address.ToString() & ":" & CSINFO.IEP.Port
        'ConnectProgressDialog.ShowDialog()

        'ConnectProgressDialog.ProgressDlg = AddressOf PLC_Connection_Check
        'ConnectProgressDialog.DisplayText = "Connecting PLC: " & PLCINFO.IEP.Address.ToString() & ":" & PLCINFO.IEP.Port
        'ConnectProgressDialog.ShowDialog()

        'ConnectProgressDialog.ProgressDlg = AddressOf L1_Connection_Check
        'ConnectProgressDialog.DisplayText = "Connecting L1: " & L1INFO.IEP_SERVER.Address.ToString() & ":" & L1INFO.IEP_SERVER.Port
        'ConnectProgressDialog.ShowDialog()

        'If False Then
        '    Task03 = New Task03Control_01sec
        '    Dim sch As ProductData
        '    sch.Sn = 96.89
        '    ETLPRODSCHS(0).Products.Add(sch)
        '    ETLPRODSCHS(1).Products.Add(sch)
        '    RECVDATA.WORD_PLC_SRS_CTR.StA_AVE.FromDouble(28.0)
        '    RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.FromDouble(31.5)
        '    RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.FromDouble(24.0)
        '    RECVDATA.WORD_PLC_SRS_CTR.No3_循環_TL_PV.FromDouble(35.0)
        '    RECVDATA.WORD_PLC_SRS_CTR.No4_循環_TL_PV.FromDouble(35.0)
        '    Task03Control_01sec.linecondition(0) = True
        '    Task03Control_01sec.linecondition(1) = True

        '    Call Task03.No3循環タンクメッキ液供給補正演算()
        '    Call Task03.No4循環タンクメッキ液供給補正演算()
        '    Call Task03.各タンク供給量指令値演算()
        '    Dim f3set = NO3ETL循環タンクDATA.F3set
        '    Dim f3 = NO3ETL循環タンクDATA.F3
        '    Dim f4set = NO4ETL循環タンクDATA.F4set
        '    Dim f4 = NO4ETL循環タンクDATA.F4
        '    End
        'End If

        '初期フォームのロード
        FormInit(Frm01OV_BAO)
        FormInit(Frm02SCH_BAO)
        FormInit(Frm03Dis_BAO)
        FormInit(Frm04DisGrp_BAO)
        FormInit(Frm05DisGrp_BAO)
        FormInit(Frm06O2Grp_BAO)
        FormInit(Frm07Prm_BAO)
        FormInit(Frm08IL_BAO)
        FormInit(Frm11ConcMnt_BAO)
        'FormInit(Frm11ALM_BAO)
        'FormInit(Frm12ALMHst_BAO)
        'Call 画面キャプチャ(Frm05NO3Grp, "201502041300")

        'Do While PLCINFO.Connect() < 0
        '    Thread.Sleep(100)
        'Loop
        'Do While CSINFO.Connect() < 0
        '    Thread.Sleep(100)
        'Loop
        'CSIO.t.Wait() '接続を待つ
        ''最初のコイルスケジュールをアップデート
        'Select Case CSIO.CheckAndUpdateSchedule(True)
        '    Case CoilSchdule.CS_NOPRODUCT
        '        RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
        '    Case CoilSchdule.CS_UPDATE
        '        RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
        '        For Each Sch As CS_SchduleData In Schl.SchList
        '            Dim pd As New ProductData
        '            pd.No = New UnitDWord(Sch.No, 1, 0, 99998)
        '            pd.Weight = New UnitWord(Sch.Weight / 0.1, 0.1, 0, 32767)
        '            pd.Thickness = New UnitWord(Sch.Thickness / 0.001, 0.001, 0, 1999)
        '            pd.Width = New UnitWord(Sch.Width / 1, 1, 0, 32767)
        '            'pd.LS = New UnitWord(Sch.LS / 1, 1, 0, 32767)
        '            pd.Coating = New UnitWord((Sch.Coating_Bot + Sch.Coating_Top) / 0.1, 0.1, 0, 32767)
        '            pd.TPH = New UnitWord((Sch.Width / (7.85 * (Sch.LS * Sch.Width * 0.001 * Sch.Thickness * 0.001) * 60)) / 0.01, 0.01, 1, 32767)
        '            RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Add(pd)
        '        Next
        'End Select
        'RECVDATA.WORD_PLC_SRS_SCHS(0).TopCoilChange = False
        'RECVDATA.WORD_PLC_SRS_SCHS(0).Updated()        'SYSTEMCONDITION.更新時刻 = DateTime.Now
        'SYSTEMCONDITION.Import(My.Application.Info.DirectoryPath & "\SystemCond.csv")
        DEBUG.Hide = False
        DEBUG.Capture = CB_CAPTURE_FLAG.Checked
        DEBUG.Flag = CB_DEBUG_FLAG.Checked
        DEBUG.No3ETL = CB_DEBUG_NO3ONOFF.Checked
        DEBUG.No4ETL = CB_DEBUG_NO4ONOFF.Checked
        DEBUG.AutoCoilChange = CB_DEBUG_AUTOCOIL.Checked
        DEBUG.BAISOKU = NUM_BAISOKU.Value
        DEBUG.Logging = CB_LOG_FLAG.Checked
        DEBUG.SnapShotTrigger = False
        Task01 = New Task01SendPLC_20sec(ifmap)
        Task02 = New Task02SLS_60sec
        Task03 = New Task03Control_01sec
        Task04 = New Task04RecvL1Measure_01sec(ifmap)
        Task05 = New Task05RecvL1CoilSchdule_01sec(ifmap)
        Task06 = New Task06Trend_60sec(ifmap)

        'センサーレス初期化
        Task02.initsensorless(SLS.TinIonValue)

        'Task03演算完了をFrmButtonへ通知
        'Task03.AddCompleteHandlers(FrmButton)
        Task03.AddCompleteHandlers(FrmButton_BAO)
        'Frm09Prmパラメータ変更をTask03へ通知
        Frm07Prm_BAO.AddCompleteHandlers(Task03)

        Task1Timer.Start()
        Task2Timer.Start()
        Task3Timer.Start()
        Task4Timer.Start()
        Task5Timer.Start()
        Task6Timer.Start()
        BlinkTimer.Start()
        WindowHide(False)
        'Frm01OV_BAO.WindowState = FormWindowState.Maximized


        'Task04.Run()
        '中国向けのとき有効
        'Task.Run(AddressOf AsyncTask01_SRS_L2.L2_CommunicationTask)
        Frm01OV_BAO.Show()
        'Frm02SCH_BAO.Show()
        'Frm04DisGrp_BAO.Show()
        'Frm05DisGrp_BAO.Show()
        'Frm06O2Grp_BAO.Show()
    End Sub
    Private Sub CB_LOG_FLAG_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LOG_FLAG.CheckedChanged
        DEBUG.Logging = CB_LOG_FLAG.Checked
    End Sub
    Private Sub CB_CAPTURE_FLAG_CheckedChanged(sender As Object, e As EventArgs) Handles CB_CAPTURE_FLAG.CheckedChanged
        DEBUG.Capture = CB_CAPTURE_FLAG.Checked
    End Sub

    Private Sub CB_DEBUG_NO3ONOFF_CheckedChanged(sender As Object, e As EventArgs) Handles CB_DEBUG_NO3ONOFF.CheckedChanged
        DEBUG.No3ETL = CB_DEBUG_NO3ONOFF.Checked
        DEBUG.No3ETLCS = CB_DEBUG_NO3ONOFF.CheckState
    End Sub

    Private Sub CB_DEBUG_NO4ONOFF_CheckedChanged(sender As Object, e As EventArgs) Handles CB_DEBUG_NO4ONOFF.CheckedChanged
        DEBUG.No4ETL = CB_DEBUG_NO4ONOFF.Checked
        DEBUG.No4ETLCS = CB_DEBUG_NO3ONOFF.CheckState
    End Sub

    Private Sub CB_DEBUG_AUTOCOIL_CheckedChanged(sender As Object, e As EventArgs) Handles CB_DEBUG_AUTOCOIL.CheckedChanged
        DEBUG.AutoCoilChange = CB_DEBUG_AUTOCOIL.Checked
    End Sub

    Private Sub CB_DEBUG_FLAG_CheckedChanged(sender As Object, e As EventArgs) Handles CB_DEBUG_FLAG.CheckedChanged
        DEBUG.Flag = CB_DEBUG_FLAG.Checked

    End Sub

    Private Sub BlinkTimer_Tick(sender As Object, e As EventArgs) Handles BlinkTimer.Tick
        LB_TASK1.ForeColor = Color.Black
        LB_TASK1.BackColor = Color.White
        LB_TASK2.ForeColor = Color.Black
        LB_TASK2.BackColor = Color.White
        LB_TASK4.ForeColor = Color.Black
        LB_TASK4.BackColor = Color.White
        LB_TASK5.ForeColor = Color.Black
        LB_TASK5.BackColor = Color.White
        LB_TASK6.ForeColor = Color.Black
        LB_TASK6.BackColor = Color.White

    End Sub

    Private Sub BT_SETLOT3_Click(sender As Object, e As EventArgs) Handles BT_SETLOT3.Click
        '        Task04.datasource.Session("LotData")
        '        Task04.datasource.Read(3)

    End Sub

    Private Sub BT_COILCHANGE3_Click(sender As Object, e As EventArgs) Handles BT_COILCHANGE3.Click
        If RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 Then
            Dim sch = RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0)
            sch.Weight.FromDouble(sch.Weight.ToDouble * 0.9F)
            RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0) = sch
        End If
    End Sub

    Private Sub BT_CLEAR3_Click(sender As Object, e As EventArgs) Handles BT_CLEAR3.Click
        RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()

    End Sub
    Private Sub BT_LOTSHIFT3_Click(sender As Object, e As EventArgs) Handles BT_LOTSHIFT3.Click
        If RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 Then
            RECVDATA.WORD_PLC_SRS_SCHS(0).Products.RemoveAt(0)
        End If
        'Dim J As Integer
        'Dim sch = RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0)
        'For J = 1 To RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count - 1
        '    RECVDATA.WORD_PLC_SRS_SCHS(0).Products(J - 1) = RECVDATA.WORD_PLC_SRS_SCHS(0).Products(J)
        'Next
        'RECVDATA.WORD_PLC_SRS_SCHS(0).Products(J - 1) = sch

    End Sub

    Private Sub BT_SETLOT4_Click(sender As Object, e As EventArgs) Handles BT_SETLOT4.Click
        'Task04.datasource.Session("LotData")
        'Task04.datasource.Read(4)

    End Sub

    Private Sub BT_COILCHANGE4_Click(sender As Object, e As EventArgs) Handles BT_COILCHANGE4.Click

        If RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Count > 0 Then
            Dim sch = RECVDATA.WORD_PLC_SRS_SCHS(1).Products(0)
            sch.Weight.FromDouble(sch.Weight.ToDouble * 0.9F)

            RECVDATA.WORD_PLC_SRS_SCHS(1).Products(0) = sch
        End If

    End Sub

    Private Sub BT_CLEAR4_Click(sender As Object, e As EventArgs) Handles BT_CLEAR4.Click
        RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Clear()

    End Sub


    Private Sub BT_LOTSHIFT4_Click(sender As Object, e As EventArgs) Handles BT_LOTSHIFT4.Click
        If RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Count > 0 Then
            RECVDATA.WORD_PLC_SRS_SCHS(1).Products.RemoveAt(0)
        End If

        'Dim J As Integer
        'Dim sch = RECVDATA.WORD_PLC_SRS_SCHS(1).Products(0)
        'For J = 1 To RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Count - 1
        '    RECVDATA.WORD_PLC_SRS_SCHS(1).Products(J - 1) = RECVDATA.WORD_PLC_SRS_SCHS(1).Products(J)
        'Next
        'RECVDATA.WORD_PLC_SRS_SCHS(1).Products(J - 1) = sch

    End Sub

    Private Sub Frm00Startup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'PLCとの接続切断
        Task1Timer.Stop()
        Task2Timer.Stop()
        Task3Timer.Stop()
        Task4Timer.Stop()
        Task5Timer.Stop()
        Task6Timer.Stop()
        BlinkTimer.Stop()

        PLCINFO.Disconnect()
        ALAM.Export(My.Application.Info.DirectoryPath & "\AlamRecoard.csv")
        'アナリシスデータ保存
        SLS.Export(My.Application.Info.DirectoryPath & "\SLSRecoard.csv")
        SYSTEMCONDITION.Save(My.Application.Info.DirectoryPath & "\SystemCondSuspend.csv")
    End Sub

    Private Sub NUM_BAISOKU_ValueChanged(sender As Object, e As EventArgs) Handles NUM_BAISOKU.ValueChanged
        DEBUG.BAISOKU = NUM_BAISOKU.Value

    End Sub

    Private Sub BTN_HIDE_Click(sender As Object, e As EventArgs) Handles BTN_HIDE.Click
        WindowHide(True)
    End Sub


    Private Sub Frm00Startup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DEBUG.Hide = False Then
            e.Cancel = MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes
        Else
        End If

    End Sub
    Public Sub WindowHide(Hide As Boolean)
        DEBUG.Hide = Hide
        If DEBUG.Hide Then
            Me.Opacity = 0
        Else
            Me.Opacity = 100
        End If
        Me.ShowInTaskbar = Not DEBUG.Hide
        Me.ShowIcon = Not DEBUG.Hide

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DEBUG.SnapShotTrigger = True
    End Sub


End Class