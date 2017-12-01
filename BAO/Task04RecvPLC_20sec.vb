Imports System.IO
Imports System.Text

Public Class Task04RecvPLC_20sec
    Inherits Task00Base
    Implements Task00Interface
    Public Sub New(_ds As Dictionary(Of String, InterfaceMap))
        MyBase.New(_ds)
    End Sub
    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim e As New TaskEventArgs
        Dim ds As InterfaceMap
        Dim ecode As Long
        Dim wordarray() As Int16


        'RECVDATA.BIT_PLC_SRS_CTR.Updated()
        'RECVDATA.BIT_PLC_SRS_IND.Updated()
        'RECVDATA.WORD_PLC_SRS_IND.Updated()
        'If firstrun = True Then
        '    RECVDATA.BIT_PLC_SRS_IND.P1 = True
        '    RECVDATA.BIT_PLC_SRS_IND.P2 = True
        '    RECVDATA.BIT_PLC_SRS_IND.P7 = True
        '    RECVDATA.BIT_PLC_SRS_IND.P8 = True
        '    RECVDATA.BIT_PLC_SRS_IND.P12 = True
        '    RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 = True
        '    RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新 = True
        '    RECVDATA.BIT_PLC_SRS_CTR.SRS_運転指令 = True
        '    RECVDATA.WORD_PLC_SRS_IND.FCV2_CAS = New UnitWord(2)
        '    RECVDATA.WORD_PLC_SRS_IND.FCV4_CAS = New UnitWord(2)
        '    RECVDATA.WORD_PLC_SRS_IND.FCV7_CAS = New UnitWord(2)
        '    RECVDATA.WORD_PLC_SRS_IND.FCV8_CAS = New UnitWord(2)
        '    RECVDATA.WORD_PLC_SRS_IND.FCV10_CAS = New UnitWord(2)
        '    RECVDATA.WORD_PLC_SRS_IND.No3_LS = New UnitWord(100)
        '    RECVDATA.WORD_PLC_SRS_IND.No4_LS = New UnitWord(100)
        '    RECVDATA.WORD_PLC_SRS_IND.Updated()
        '    '初回実行時に初期化(テスト用）
        '    'datasource.Session("LotData")
        '    'For I = 0 To 1
        '    '   datasource.Read(3 + I)
        '    'Next


        '    e.etype = TaskEventArgs.EventType.TSK_初期化中
        '    Notify(e)
        '    Exit Sub
        'End If
        e.etype = TaskEventArgs.EventType.PLC_オープンリトライ中
        If PLCINFO.Connect() = 0 Then
            Try

                Dim dsBit = datasource("IF_PLC_TO_SRS_BIT_M8000")
                Dim dsWord = datasource("IF_PLC_TO_SRS_WORD_D5000")
                ecode = PLCINFO.ReadBlockData(dsWord, dsBit)
                If ecode <> 0 Then
                    Throw New Exception
                End If
                RECVDATA.BIT_PLC_SRS_M8000.Updated()
                RECVDATA.WORD_PLC_SRS_D5000.Updated()
                If RECVDATA.BIT_PLC_SRS_M8000.COILEND Then
                    If CSINFO.Connect() = 0 Then
                        If COIL_REJECT_FLAG = False Then
                            If CSINFO.SendRejectMessage() = CoilSchdule.CS_REJECTED Then
                                COIL_REJECT_FLAG = True
                                COIL_REJECT_TIME = DateTime.Now
                            End If
                        Else
                            COIL_REJECT_FLAG = (DateTime.Now - COIL_REJECT_TIME).TotalSeconds() < 60
                        End If
                    End If
                End If

                    'If RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 Then
                    '    ds = datasource("IF_PLC_TO_SRS_WORD_SCH3")
                    '    wordarray = PLCINFO.ReadWorddata(ds.address, ds.devcode, 2 + (ds.range + 1) * 20, ecode)
                    '    If ecode <> 0 Then
                    '        Throw New Exception
                    '    End If

                    '    Dim numSch = wordarray(0)
                    '    Dim ioffset = 1
                    '    RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
                    '    For I = 1 To numSch
                    '        Dim pd As New ProductData
                    '        For J = 0 To ds.interfacelist.Count - 1
                    '            Dim iface = ds.interfacelist(J)
                    '            Select Case iface.fldname
                    '                Case "No"
                    '                    pd.No = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Weight"
                    '                    pd.Weight = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "TPH"
                    '                    pd.TPH = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Thickness"
                    '                    pd.Thickness = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Width"
                    '                    pd.Width = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Coating"
                    '                    pd.Coating = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '            End Select
                    '            ioffset = ioffset + 1
                    '        Next
                    '        RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Add(pd)
                    '    Next
                    '    '2015/4/9修正
                    '    'RECVDATA.WORD_PLC_SRS_SCHS(0).TopCoilChange = (wordarray.Last = 1)
                    '    'RECVDATA.WORD_PLC_SRS_SCHS(0).TopCoilChange = (wordarray.Last = 2) '先頭コイル修正はwordarray.Last = 2の時
                    '    RECVDATA.WORD_PLC_SRS_SCHS(0).TopCoilChange = False '先頭コイル修正はなし
                    '    RECVDATA.WORD_PLC_SRS_SCHS(0).Updated()
                    'End If
                    'If RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新 Then
                    '    ds = datasource("IF_PLC_TO_SRS_WORD_SCH4")
                    '    wordarray = PLCINFO.ReadWorddata(ds.address, ds.devcode, 2 + (ds.range + 1) * 20, ecode)
                    '    If ecode <> 0 Then
                    '        Throw New Exception
                    '    End If
                    '    Dim numSch = wordarray(0)
                    '    Dim ioffset = 1
                    '    RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Clear()
                    '    For I = 1 To numSch
                    '        Dim pd As New ProductData
                    '        For J = 0 To ds.interfacelist.Count - 1
                    '            Dim iface = ds.interfacelist(J)
                    '            Select Case iface.fldname
                    '                Case "No"
                    '                    pd.No = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Weight"
                    '                    pd.Weight = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "TPH"
                    '                    pd.TPH = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Thickness"
                    '                    pd.Thickness = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Width"
                    '                    pd.Width = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '                Case "Coating"
                    '                    pd.Coating = New UnitWord(wordarray(ioffset), iface.unit, iface.lowlimit, iface.upperlimit)
                    '            End Select
                    '            ioffset = ioffset + 1
                    '        Next
                    '        RECVDATA.WORD_PLC_SRS_SCHS(1).Products.Add(pd)
                    '    Next
                    '    '2015/4/9修正
                    '    'RECVDATA.WORD_PLC_SRS_SCHS(1).TopCoilChange = (wordarray.Last = 1)
                    '    'RECVDATA.WORD_PLC_SRS_SCHS(1).TopCoilChange = (wordarray.Last = 2) '先頭コイル修正はwordarray.Last = 2の時
                    '    RECVDATA.WORD_PLC_SRS_SCHS(1).TopCoilChange = False '先頭コイル修正はwordarray.Last = 2の時
                    '    RECVDATA.WORD_PLC_SRS_SCHS(1).Updated()
                    'End If


                    'e.etype = TaskEventArgs.EventType.PLC_01sec_受信完了
                    'If RECVDATA.BIT_PLC_SRS_CTR.トレンドデータ送信完了 Then
                    '    SENDDATA.BIT_SRS_PLC_ANS.トレンドデータ送信完了 = False
                    'End If
                    'SENDDATA.BIT_SRS_PLC_ANS.No3_スケジュール更新完了 = RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新
                    'SENDDATA.BIT_SRS_PLC_ANS.No4_スケジュール更新完了 = RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新

                    'If RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 Or RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新 Then
                    '    If DEBUG.Logging Or True Then
                    '        Dim logdatestr As String = DateTime.Now.ToString("yyyyMMdd")

                    '        For II = 0 To 1
                    '            If (II = 0 And RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新) Or (II = 1 And RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新) Then
                    '                Dim dbfile = "C:\DATASTRAGE\" & logdatestr & "_No" & (II + 3) & "Schedule.csv"
                    '                Using sw As New StreamWriter(dbfile, True, Encoding.Default)
                    '                    sw.Write(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & ",")
                    '                    sw.Write(RECVDATA.WORD_PLC_SRS_SCHS(II).Products.Count)
                    '                    For Each item In RECVDATA.WORD_PLC_SRS_SCHS(II).Products
                    '                        sw.Write("," & item.No.Word)
                    '                        sw.Write("," & item.Weight.Word)
                    '                        sw.Write("," & item.TPH.Word)
                    '                        sw.Write("," & item.Thickness.Word)
                    '                        sw.Write("," & item.Width.Word)
                    '                        sw.Write("," & item.Coating.Word)
                    '                    Next
                    '                    sw.WriteLine("," & RECVDATA.WORD_PLC_SRS_SCHS(II).TopCoilChange * (-1))
                    '                End Using
                    '            End If

                    '        Next
                    '    End If

                    '    Dim presended = SENDDATA.WORD_SRS_PLC_TREND.SRS_スケジュール受信.Word
                    '    Select Case presended
                    '        Case 3
                    '            If SENDDATA.BIT_SRS_PLC_ANS.No4_スケジュール更新完了 Then
                    '                e.etype = 5
                    '            End If
                    '        Case 4
                    '            If SENDDATA.BIT_SRS_PLC_ANS.No3_スケジュール更新完了 Then
                    '                e.etype = 5
                    '            End If
                    '        Case Else
                    '            e.etype = (RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 And Not RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新) * (-3) +
                    '                      (Not RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 And RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新) * (-4) +
                    '                      (RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 And RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新) * (-5)
                    '    End Select
                    '    SENDDATA.WORD_SRS_PLC_TREND.SRS_スケジュール受信.From(e.etype, 1)
                    'End If
                    e.etype = TaskEventArgs.EventType.PLC_20sec_受信完了
            Catch ex As Exception
                e.etype = TaskEventArgs.EventType.PLC_受信エラー
            End Try
            'PLCINFO.Disconnect()
        End If
        Run = e
        Notify(e)
    End Function

    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        'If RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 And (RECVDATA.BIT_PLC_SRS_CTR.更新時刻 - RECVDATA.WORD_PLC_SRS_SCHS(0).更新時刻).TotalSeconds() >= 1 Then
        '    RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 = False
        'End If
        'If RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新 And (RECVDATA.BIT_PLC_SRS_CTR.更新時刻 - RECVDATA.WORD_PLC_SRS_SCHS(0).更新時刻).TotalSeconds() >= 1 Then
        '    RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新 = False
        'End If
        evlog.Logging(Me, sender, e)
    End Sub
End Class
