Imports System.Threading

Public Class Task01SendPLC_20sec
    Inherits Task00Base
    Implements Task00Interface
    Public Sub New(_ds As Dictionary(Of String, InterfaceMap))
        MyBase.New(_ds)
    End Sub
    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim ecode As Long

        Dim e As New TaskEventArgs

        e.etype = TaskEventArgs.EventType.L1_オープンリトライ中
        '        If PLCINFO.Connect() = 0 Then
        If L1INFO.Connection = 0 Then
            e.etype = L1INFO.SendEventType
            Try
                Dim dsBit = datasource("IF_SRS_TO_PLC_BIT_M9100")
                Dim dsWord = datasource("IF_SRS_TO_PLC_WORD_D6100")
                Dim ifmap = L1INFO.L1MessageMap(4) ' Setting Value
                If Not ifmap.GetBuffer() Is Nothing Then
                    For Each item In dsBit.interfacelist
                        ifmap.SetField(item.comment, item.GetBoolean())
                    Next
                    For Each item In dsWord.interfacelist
                        ifmap.SetField(item.comment, item.GetWord() * item.unit)
                    Next
                    Monitor.Enter(L1INFO.LockItem)
                    L1INFO.L1MessageMap(4) = ifmap
                    Monitor.Exit(L1INFO.LockItem)

                End If

                'ecode = PLCINFO.WriteBlockData(dsWord, dsBit)
                'If ecode <> 0 Then
                '    Throw New Exception
                'End If
                'Dim counter As Integer = SENDDATA.WORD_SRS_PLC_D5100.COUNTER_ROUND_10000.ToDouble()
                'counter = counter + 1 Mod 10000
                'SENDDATA.WORD_SRS_PLC_D5100.COUNTER_ROUND_10000.FromDouble(counter)
                SENDDATA.BIT_SRS_PLC_M9100.Updated()
                SENDDATA.WORD_SRS_PLC_D6100.Updated()

                'ds = datasource("IF_SRS_TO_PLC_BIT_TREND")
                'ecode = PLCINFO.SendData(ds.address, ds.GetBitarray())
                'If ecode <> 0 Then
                '    Throw New Exception
                'End If
                'ds = datasource("IF_SRS_TO_PLC_WORD_TREND")
                'ecode = PLCINFO.SendData(ds.address, ds.GetWordarray())
                'If ecode <> 0 Then
                '    Throw New Exception
                'End If
                'e.etype = TaskEventArgs.EventType.SRS_20sec_送信完了
            Catch ex As Exception
                e.ex = ex
            End Try
            'PLCINFO.Disconnect()
        End If
        Run = e
        Notify(e)
    End Function

    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        If e.etype = TaskEventArgs.EventType.SRS_20sec_送信完了 Then
            'SENDDATA.BIT_SRS_PLC_ANS.トレンドデータ送信完了 = True
            'SENDDATA.WORD_SRS_PLC_TREND.SRS_スケジュール受信.Word = 0
        End If

        evlog.Logging(Me, sender, e)
    End Sub
End Class
