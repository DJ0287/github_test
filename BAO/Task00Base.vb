Public Class Task00Base
    Protected firstrun As Boolean = True

    Public datasource As Dictionary(Of String, InterfaceMap)
    Protected evlog As New Log("eventlog")
    Public Event Completed(sender As Object, e As TaskEventArgs)
    Public Sub New(Optional _ds As Dictionary(Of String, InterfaceMap) = Nothing)
        datasource = _ds
        AddCompleteHandlers(Me)
    End Sub

    Public Sub AddCompleteHandlers(ParamArray handlers())
        Dim handle As Task00Interface

        For Each handle In handlers
            AddHandler Completed, AddressOf handle.OnCompleted
        Next

    End Sub
    Public Sub Notify(e As TaskEventArgs)
        If firstrun Then firstrun = False
        RaiseEvent Completed(Me, e)
    End Sub
End Class
