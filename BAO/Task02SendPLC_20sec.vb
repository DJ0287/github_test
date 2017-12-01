Public Class Task02SendPLC_20sec
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
                Dim dsBit = datasource("IF_SRS_TO_PLC_BIT_ANS")
                Dim dsWord = datasource("IF_SRS_TO_PLC_WORD_CTR")
                ecode = PLCINFO.WriteBlockData(dsWord, dsBit)
                If ecode <> 0 Then
                    Throw New Exception
                End If
                SENDDATA.BIT_SRS_PLC_ANS.Updated()
                SENDDATA.WORD_SRS_PLC_CTR.Updated()
                e.etype = TaskEventArgs.EventType.SRS_01sec_送信完了
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
        If RECVDATA.BIT_PLC_SRS_CTR.No3_スケジュール更新 AndAlso (RECVDATA.BIT_PLC_SRS_CTR.更新時刻 - RECVDATA.WORD_PLC_SRS_SCHS(0).更新時刻).TotalSeconds() < 1 Then
            SENDDATA.BIT_SRS_PLC_ANS.No3_スケジュール更新完了 = True
        Else
            SENDDATA.BIT_SRS_PLC_ANS.No3_スケジュール更新完了 = False
        End If
        If RECVDATA.BIT_PLC_SRS_CTR.No4_スケジュール更新 And (RECVDATA.BIT_PLC_SRS_CTR.更新時刻 - RECVDATA.WORD_PLC_SRS_SCHS(1).更新時刻).TotalSeconds() < 1 Then
            SENDDATA.BIT_SRS_PLC_ANS.No4_スケジュール更新完了 = True
        Else
            SENDDATA.BIT_SRS_PLC_ANS.No4_スケジュール更新完了 = False
        End If
        If RECVDATA.BIT_PLC_SRS_CTR.トレンドデータ送信完了 Then
            SENDDATA.BIT_SRS_PLC_ANS.トレンドデータ送信完了 = False
        End If
        evlog.Logging(Me, sender, e)
    End Sub
End Class
