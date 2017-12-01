Public Class Task05RecvL1CoilSchdule_01sec
    Inherits Task00Base
    Implements Task00Interface
    Public Sub New(_ds As Dictionary(Of String, InterfaceMap))
        MyBase.New(_ds)
    End Sub
    Dim firstupdate = True

    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim e As New TaskEventArgs
        Dim ecode As Long
        e.etype = TaskEventArgs.EventType.CS_オープンリトライ中
        Dim ifmap As L1InterfaceMap

        If L1INFO.Connection = 0 Then
            e.etype = L1INFO.RecvEventType
            If L1INFO.RecieveNewCoilLow Then
                L1INFO.RecieveNewCoilLow = False
                RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
                ifmap = L1INFO.L1MessageMap(1)
                Dim totcoil = ifmap.GetField(7)
                If totcoil > 255 Then
                    'BigEndian
                    totcoil = totcoil / 256
                End If
                Dim item As L1Item
                For Idx As Integer = 1 To Math.Min(totcoil, 10)
                    Dim pd As New ProductData
                    Dim offset As Integer = (Idx - 1) * 6 + 8
                    For J As Integer = 0 To 5
                        item = ifmap.l1itemlist(offset + J - 1)
                        Select Case J
                            Case 0
                                Dim coilno As String = ifmap.GetField(offset + J)
                                pd.No = coilno.Substring(0, 20)
                            Case 1
                                pd.Weight = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                            Case 2
                                pd.Thickness = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                            Case 3
                                pd.Width = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                            Case 4
                                pd.Coating = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                            Case 5
                                pd.LS = ifmap.GetField(offset + J) / item.FieldUnit

                        End Select
                    Next
                    pd.TPH = New UnitWord(7.85 * pd.LS * 60 * pd.Thickness.ToDouble() * pd.Width.ToDouble() * 0.000001 / 0.1, 0.1, 1, 32767) 'New UnitWord((L / (Sch.LS / 60) / 0.1), 0.1, 1, 32767)
                    RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Add(pd)
                Next
                If totcoil > 10 And L1INFO.RecieveNewCoilHigh Then
                    ifmap = L1INFO.L1MessageMap(2)
                    L1INFO.RecieveNewCoilHigh = False
                    For Idx As Integer = 11 To totcoil
                        Dim pd As New ProductData
                        Dim offset As Integer = (Idx - 11) * 6 + 8
                        For J As Integer = 0 To 5
                            item = ifmap.l1itemlist(offset + J - 1)
                            Select Case J
                                Case 0
                                    Dim coilno As String = ifmap.GetField(offset + J)
                                    pd.No = coilno.Substring(0, 20)
                                Case 1
                                    pd.Weight = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                                Case 2
                                    pd.Thickness = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                                Case 3
                                    pd.Width = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                                Case 4
                                    pd.Coating = New UnitWord(ifmap.GetField(offset + J) / item.FieldUnit, item.FieldUnit, item.FieldLower, item.FieldUpper)
                                Case 5
                                    pd.LS = ifmap.GetField(offset + J) / item.FieldUnit

                            End Select
                        Next
                        pd.TPH = New UnitWord(7.85 * pd.LS * 60 * pd.Thickness.ToDouble() * pd.Width.ToDouble() * 0.000001 / 0.1, 0.1, 1, 32767) 'New UnitWord((L / (Sch.LS / 60) / 0.1), 0.1, 1, 32767)

                        RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Add(pd)
                    Next

                End If
            End If

        End If

        'If CSINFO.Connect() = 0 Then
        '    Try
        '        CSIO.tcp.ReceiveTimeout = 1000
        '        Select Case CSIO.CheckAndUpdateSchedule(firstupdate)
        '            Case CoilSchdule.CS_NOPRODUCT
        '                RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
        '                e.etype = TaskEventArgs.EventType.SCH_スケジュールなし
        '            Case CoilSchdule.CS_UPDATE
        '                e.etype = TaskEventArgs.EventType.SCH_スケジュール受信完了
        '                RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
        '                If Schl.SchList(0).No <> 99999 Then
        '                    For Each Sch As CS_SchduleData In Schl.SchList
        '                        If Sch.No <> 99999 Then
        '                            Dim pd As New ProductData
        '                            pd.No = Sch.No.ToString() 'New UnitDWord(Sch.No, 1, 0, 99998)
        '                            pd.Weight = New UnitWord(Sch.Weight / 0.1, 0.1, 0, 32767)
        '                            pd.Width = New UnitWord(Sch.Width / 1, 1, 0, 32767)
        '                            pd.Thickness = New UnitWord(Sch.Thickness / 0.001, 0.001, 0, 1999)
        '                            pd.Coating = New UnitWord(0, 0.1, 0, 20000)
        '                            pd.LS = Sch.LS
        '                            pd.Coating.FromDouble((Sch.Coating_Bot + Sch.Coating_Top) * 1000)
        '                            pd.TPH = New UnitWord(7.85 * Sch.LS * 60 * Sch.Thickness * Sch.Width * 0.000001 / 0.1, 0.1, 1, 32767) 'New UnitWord((L / (Sch.LS / 60) / 0.1), 0.1, 1, 32767)
        '                            RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Add(pd)
        '                        End If
        '                    Next
        '                End If
        '            Case Else
        '                e.etype = TaskEventArgs.EventType.SCH_スケジュール更新なし
        '        End Select
        '        firstupdate = RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count = 0
        '        RECVDATA.WORD_PLC_SRS_SCHS(0).TopCoilChange = False
        '        RECVDATA.WORD_PLC_SRS_SCHS(0).Updated()
        '    Catch ex As Exception
        '        e.etype = TaskEventArgs.EventType.CS_オープンリトライ中

        '    End Try
        'End If
        'If PLCINFO.Connect() = 0 Then
        'If RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count > 0 Then
        '    Dim topSch = RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0)
        '    Dim Width = RECVDATA.WORD_PLC_SRS_D5000.STRIP_WIDTH.ToDouble
        '    Dim Thickness = (RECVDATA.WORD_PLC_SRS_D5000.STRIP_THICKNESS.ToDouble() / 1000)
        '    Dim LS = RECVDATA.WORD_PLC_SRS_D5000.LINESPEED.ToDouble
        '    Dim Coating = ((RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_BACK.ToDouble + RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_FRONT.ToDouble) * 1000)
        '    If Width > 0 Then
        '        topSch.Width.FromDouble(Width)
        '    End If
        '    If Thickness > 0 Then
        '        topSch.Thickness.FromDouble(Thickness)
        '    End If
        '    If LS > 0 Then
        '        topSch.LS = LS
        '    End If
        '    If Coating > 0 Then
        '        topSch.Coating.FromDouble(Coating)
        '    End If
        '    topSch.TPH = New UnitWord(7.85 * topSch.LS * 60 * topSch.Thickness.ToDouble() * topSch.Width.ToDouble() * 0.000001 / 0.1, 0.1, 1, 32767) 'New UnitWord((L / (Sch.LS / 60) / 0.1), 0.1, 1, 32767)
        '    RECVDATA.WORD_PLC_SRS_SCHS(0).Products(0) = topSch
        'End If
        'End If
        'If PLCINFO.Connect() = 0 Then
        '    Try
        '        Dim dsBit = datasource("IF_PLC_TO_SRS_BIT_IND")
        '        Dim dsWord = datasource("IF_PLC_TO_SRS_WORD_IND")
        '        ecode = PLCINFO.ReadBlockData(dsWord, dsBit)
        '        If ecode <> 0 Then
        '            Throw New Exception
        '        End If
        '        RECVDATA.BIT_PLC_SRS_IND.Updated()
        '        RECVDATA.WORD_PLC_SRS_IND.Updated()

        '        'ds = datasource("IF_PLC_TO_SRS_BIT_CTR")
        '        'bitarray = PLCINFO.RecvBitdata(ds.address, ds.range, ecode)
        '        'If ecode <> 0 Then
        '        '    Throw New Exception
        '        'End If
        '        'ds.UpdateFromArray(bitarray)
        '        'ds = datasource("IF_PLC_TO_SRS_WORD_CTR")
        '        'wordarray = PLCINFO.RecvWorddata(ds.address, ds.range, ecode)
        '        'If ecode <> 0 Then
        '        '    Throw New Exception
        '        'End If
        '        'ds.UpdateFromArray(wordarray)
        '        e.etype = TaskEventArgs.EventType.PLC_20sec_受信完了
        '    Catch ex As Exception
        '        e.etype = TaskEventArgs.EventType.PLC_受信エラー
        '    End Try
        '    'PLCINFO.Disconnect()

        'End If
        Notify(e)
        Run = e


    End Function

    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        evlog.Logging(Me, sender, e)
    End Sub
End Class
