﻿Imports System.Security.Permissions
Public Class FrmButton_BAO

    Implements Task00Interface
    Implements FrmUpdateInterface

    Private evlog As New Log("eventlog")
    Private Event Completed(sender As Object, e As TaskEventArgs)
    Private ButtonAry(13) As Button
    Private FormAry(13) As FrmButton_BAO

    <SecurityPermission(SecurityAction.Demand,
    Flags:=SecurityPermissionFlag.UnmanagedCode)>
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_MOVE As Long = &HF010L

        If m.Msg = WM_SYSCOMMAND AndAlso
            (m.WParam.ToInt64() And &HFFF0L) = SC_MOVE Then
            'm.Result = IntPtr.Zero
            'Return
        End If

        MyBase.WndProc(m)
    End Sub
    Private Sub ButtonForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Frm00Startup.Close()


    End Sub
    Private Sub FrmButton_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = Not DEBUG.Hide

    End Sub
    '    Private Sub SystemTimer_Tick(sender As Object, e As EventArgs)
    '        LB_SYSTIME.Text = DateAndTime.Now.ToString("yyyy/MM/dd HH:mm")
    '    End Sub

    Private Sub SelectScreen(sender As Object, e As EventArgs) Handles BTN_PRM.Click, BTN_O2TREND.Click, BTN_O2GRP.Click, BTN_DISGRP.Click, BTN_DISSCH.Click, BTN_PRODSCH.Click, BTN_ALM.Click, BTN_IL.Click, BTN_OV.Click, BTN_ALMHST.Click, BTN_CONC.Click
        Dim selbtn As Button = sender
        Dim sidx = selbtn.TabIndex
        If Not (Me Is FormAry(sidx)) Then
            'FormAry(sidx).WindowState = FormWindowState.Maximized
            If Not IsNothing(FormAry(sidx)) Then
                FormAry(sidx).Show()
                FormAry(sidx).ButtonAry(sidx).Select()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub ButtonForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FormAry(0) = Frm01OV
        'FormAry(1) = Frm02NO3SCH
        'FormAry(2) = Frm03NO4SCH
        'FormAry(3) = Frm04Dis
        'FormAry(4) = Frm05NO3Grp
        'FormAry(5) = Frm06NO4Grp
        'FormAry(6) = Frm07DisGrp
        'FormAry(7) = Frm08O2Grp
        'FormAry(8) = Frm09Prm
        'FormAry(9) = Frm10IL
        'FormAry(10) = Frm09ALM_BAO
        'FormAry(11) = Frm10ALMHst_BAO
        'ButtonAry(0) = BTN_OV
        'ButtonAry(1) = BTN_NO3SCH
        'ButtonAry(2) = BTN_NO4SCH
        'ButtonAry(3) = BTN_DIS
        'ButtonAry(4) = BTN_NO3GRP
        'ButtonAry(5) = BTN_NO4GRP
        'ButtonAry(6) = BTN_DISGRP
        'ButtonAry(7) = BTN_O2GRP
        'ButtonAry(8) = BTN_PRM
        'ButtonAry(9) = BTN_IL
        'ButtonAry(10) = BTN_ALM
        'ButtonAry(11) = BTN_ALMHST

        FormAry(0) = Frm01OV_BAO
        FormAry(1) = Frm02SCH_BAO
        FormAry(3) = Frm03Dis_BAO
        FormAry(4) = Frm04DisGrp_BAO
        FormAry(6) = Frm05DisGrp_BAO
        FormAry(7) = Frm06O2Grp_BAO
        FormAry(8) = Frm07Prm_BAO
        FormAry(9) = Frm08IL_BAO
        FormAry(10) = Frm09ALM_BAO
        FormAry(12) = Frm10ALMHst_BAO
        FormAry(13) = Frm11ConcMnt_BAO

        ButtonAry(0) = BTN_OV
        ButtonAry(1) = BTN_PRODSCH
        ButtonAry(3) = BTN_DISSCH
        ButtonAry(4) = BTN_DISGRP
        ButtonAry(6) = BTN_O2GRP
        ButtonAry(7) = BTN_O2TREND
        ButtonAry(8) = BTN_PRM
        ButtonAry(9) = BTN_IL
        ButtonAry(10) = BTN_ALM
        ButtonAry(12) = BTN_ALMHST
        ButtonAry(13) = BTN_CONC

    End Sub
    Protected Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim e As New TaskEventArgs
        e.etype = TaskEventArgs.EventType.SRS_パラメータ変更
        Run = e
        RaiseEvent Completed(Me, e)
    End Function
    Public Sub AddCompleteHandlers(ParamArray handlers())
        Dim handle As Task00Interface

        For Each handle In handlers
            AddHandler Completed, AddressOf handle.OnCompleted
        Next

    End Sub
    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        e.etype = TaskEventArgs.EventType.SRS_更新完了
        Try
            Dim task As Task00Base = sender
            If FormAry(0) Is Nothing Then
                'FormAry(0) = Frm01OV
                'FormAry(1) = Frm02NO3SCH
                'FormAry(2) = Frm03NO4SCH
                'FormAry(3) = Frm04Dis
                'FormAry(4) = Frm05NO3Grp
                'FormAry(5) = Frm06NO4Grp
                'FormAry(6) = Frm07DisGrp
                'FormAry(7) = Frm08O2Grp
                'FormAry(8) = Frm09Prm
                'FormAry(9) = Frm10IL
                'FormAry(10) = Frm09ALM_BAO
                'FormAry(11) = Frm10ALMHst_BAO

                FormAry(0) = Frm01OV_BAO
                FormAry(1) = Frm02SCH_BAO
                FormAry(3) = Frm03Dis_BAO
                FormAry(4) = Frm04DisGrp_BAO
                FormAry(6) = Frm05DisGrp_BAO
                FormAry(7) = Frm06O2Grp_BAO
                FormAry(8) = Frm07Prm_BAO
                FormAry(9) = Frm08IL_BAO
                FormAry(10) = Frm09ALM_BAO
                FormAry(12) = Frm10ALMHst_BAO
                FormAry(13) = Frm11ConcMnt_BAO

            End If

            For Each frm In FormAry
                If (DEBUG.Capture Or DEBUG.SnapShotTrigger) And (frm Is FormAry(0) Or frm Is FormAry(1) Or frm Is FormAry(3) Or frm Is FormAry(4) Or frm Is FormAry(6) _
                                                                Or frm Is FormAry(7) Or frm Is FormAry(13)) Then
                    Dim timestr As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                    Dim updatesubtitle = ""
                    If DEBUG.SnapShotTrigger Then
                        updatesubtitle = updatesubtitle & "_SnapShotTrigger"
                    End If
                    If Task03Control_01sec.lineconditionchange(0) Then
                        updatesubtitle = updatesubtitle & "_No3ライン状態変化"
                    End If
                    If Task03Control_01sec.lineconditionchange(1) Then
                        updatesubtitle = updatesubtitle & "_No4ライン状態変化"
                    End If
                    If Task03Control_01sec.interlockchange Then
                        updatesubtitle = updatesubtitle & "_インターロック変化"
                    End If
                    If Task03Control_01sec.スケジュール更新フラグ(0) Then
                        updatesubtitle = updatesubtitle & "_No3スケジュール更新"
                    End If
                    If Task03Control_01sec.スケジュール更新フラグ(1) Then
                        updatesubtitle = updatesubtitle & "_No4スケジュール更新"
                    End If
                    'If CHECKVARIABLE.Transition Then
                    '    updatesubtitle = updatesubtitle & "_PV値orSV値変化"
                    'End If
                    If (updatesubtitle <> "") Then
                        Call 画面キャプチャ(frm, timestr, updatesubtitle & "0")
                    End If
                    Try
                        frm.OnUpdate()
                    Catch
                    End Try
                    If (updatesubtitle <> "") Then
                        Call 画面キャプチャ(frm, timestr, updatesubtitle & "1")
                    End If
                Else
                    Try
                        frm.OnUpdate()
                    Catch
                    End Try
                End If

            Next
        Catch
            e.etype = TaskEventArgs.EventType.SRS_更新エラー
        End Try
        DEBUG.SnapShotTrigger = False
        evlog.Logging(Me, sender, e)

    End Sub

    Protected Overridable Sub OnUpdate() Implements FrmUpdateInterface.OnUpdate
        SetRunText(TB_SRS_MODE, インターロック判定())
        TB_LS3.Text = Format(RECVDATA.WORD_PLC_SRS_D6000.LINESPEED.ToDouble(), TB_LS3.Tag)
        '        TB_LS4.Text = Format(RECVDATA.WORD_PLC_SRS_IND.No4_LS.ToDouble(), TB_LS4.Tag)
        LB_SYSTIME.Text = DateAndTime.Now.ToString(LB_SYSTIME.Tag)
        Dim almno = ALAM.GetAlam()
        If almno > 0 Then
            Dim almtime = ALAM.ALAMITEMS(almno).TriggerTime
            Dim almmsg = ALAM.ALAMMESSAGES(almno)
            TB_ALAM_MSG.Text = almtime.ToString("yyyy/MM/dd HH:mm:ss") & " : " & almmsg
        Else
            TB_ALAM_MSG.Text = ""

        End If
    End Sub




End Class
