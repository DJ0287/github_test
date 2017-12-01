Public Class Task01SendPLC_60sec
    Inherits Task00Base
    Implements Task00Interface
    Public Sub New(_ds As Dictionary(Of String, InterfaceMap))
        MyBase.New(_ds)
    End Sub
    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim ecode As Long

        Dim e As New TaskEventArgs
        e.etype = TaskEventArgs.EventType.PLC_オープンリトライ中
        If PLCINFO.Connect() = 0 Then

            Try
                Dim dsBit = datasource("IF_SRS_TO_PLC_BIT_TREND")
                Dim dsWord = datasource("IF_SRS_TO_PLC_WORD_TREND")
                ecode = PLCINFO.WriteBlockData(dsWord, dsBit)
                If ecode <> 0 Then
                    Throw New Exception
                End If
                SENDDATA.BIT_SRS_PLC_TREND.Updated()
                SENDDATA.WORD_SRS_PLC_TREND.Updated()

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
                e.etype = TaskEventArgs.EventType.SRS_トレンド60sec_送信完了
            Catch ex As Exception
                e.etype = TaskEventArgs.EventType.PLC_送信エラー
                e.ex = ex
            End Try
            'PLCINFO.Disconnect()
        End If
        Run = e
        Notify(e)
    End Function

    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        If e.etype = TaskEventArgs.EventType.SRS_トレンド60sec_送信完了 Then
            SENDDATA.BIT_SRS_PLC_ANS.トレンドデータ送信完了 = True
            SENDDATA.WORD_SRS_PLC_TREND.SRS_スケジュール受信.Word = 0
        End If

        evlog.Logging(Me, sender, e)
    End Sub
End Class
