Public Class Task05RecvCS_01sec
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
        If CSINFO.Connect() = 0 Then
            Try
                CSIO.tcp.ReceiveTimeout = 1000
                Select Case CSIO.CheckAndUpdateSchedule(firstupdate)
                    Case CoilSchdule.CS_NOPRODUCT
                        RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
                        e.etype = TaskEventArgs.EventType.SCH_スケジュールなし
                    Case CoilSchdule.CS_UPDATE
                        e.etype = TaskEventArgs.EventType.SCH_スケジュール受信完了
                        RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Clear()
                        If Schl.SchList(0).No <> 99999 Then
                            For Each Sch As CS_SchduleData In Schl.SchList
                                If Sch.No <> 99999 Then
                                    Dim pd As New ProductData
                                    pd.No = New UnitDWord(Sch.No, 1, 0, 99998)
                                    pd.Weight = New UnitWord(Sch.Weight / 0.1, 0.1, 0, 32767)
                                    pd.Width = New UnitWord(Sch.Width / 1, 1, 0, 32767)
                                    pd.Thickness = New UnitWord(Sch.Thickness / 0.001, 0.001, 0, 1999)
                                    pd.Coating = New UnitWord(0, 0.1, 0, 20000)
                                    pd.LS = Sch.LS
                                    pd.Coating.FromDouble((Sch.Coating_Bot + Sch.Coating_Top) * 1000)
                                    pd.TPH = New UnitWord(7.85 * Sch.LS * 60 * Sch.Thickness * Sch.Width * 0.000001 / 0.1, 0.1, 1, 32767) 'New UnitWord((L / (Sch.LS / 60) / 0.1), 0.1, 1, 32767)
                                    RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Add(pd)
                                End If
                            Next
                        End If
                    Case Else
                        e.etype = TaskEventArgs.EventType.SCH_スケジュール更新なし
                End Select
                firstupdate = RECVDATA.WORD_PLC_SRS_SCHS(0).Products.Count = 0
                RECVDATA.WORD_PLC_SRS_SCHS(0).TopCoilChange = False
                RECVDATA.WORD_PLC_SRS_SCHS(0).Updated()
            Catch ex As Exception
                e.etype = TaskEventArgs.EventType.CS_オープンリトライ中

            End Try
        End If
        If PLCINFO.Connect() = 0 Then
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
        End If
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
