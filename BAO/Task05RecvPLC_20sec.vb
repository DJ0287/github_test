Public Class Task05RecvPLC_20sec
    Inherits Task00Base
    Implements Task00Interface
    Public Sub New(_ds As Dictionary(Of String, InterfaceMap))
        MyBase.New(_ds)
    End Sub
    Public Function Run() As TaskEventArgs Implements Task00Interface.Run
        Dim e As New TaskEventArgs
        Dim ecode As Long
        e.etype = TaskEventArgs.EventType.PLC_オープンリトライ中
        If PLCINFO.Connect() = 0 Then
            Try
                Dim dsBit = datasource("IF_PLC_TO_SRS_BIT_IND")
                Dim dsWord = datasource("IF_PLC_TO_SRS_WORD_IND")
                ecode = PLCINFO.ReadBlockData(dsWord, dsBit)
                If ecode <> 0 Then
                    Throw New Exception
                End If
                RECVDATA.BIT_PLC_SRS_IND.Updated()
                RECVDATA.WORD_PLC_SRS_IND.Updated()

                'ds = datasource("IF_PLC_TO_SRS_BIT_CTR")
                'bitarray = PLCINFO.RecvBitdata(ds.address, ds.range, ecode)
                'If ecode <> 0 Then
                '    Throw New Exception
                'End If
                'ds.UpdateFromArray(bitarray)
                'ds = datasource("IF_PLC_TO_SRS_WORD_CTR")
                'wordarray = PLCINFO.RecvWorddata(ds.address, ds.range, ecode)
                'If ecode <> 0 Then
                '    Throw New Exception
                'End If
                'ds.UpdateFromArray(wordarray)
                e.etype = TaskEventArgs.EventType.PLC_20sec_受信完了
            Catch ex As Exception
                e.etype = TaskEventArgs.EventType.PLC_受信エラー
            End Try
            'PLCINFO.Disconnect()

        End If
        Notify(e)
        Run = e


    End Function

    Private Sub OnCompleted(sender As Object, e As TaskEventArgs) Implements Task00Interface.OnCompleted
        evlog.Logging(Me, sender, e)
    End Sub
End Class
