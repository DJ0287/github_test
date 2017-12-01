Imports Microsoft.VisualBasic.FileIO

Public Class DataAccessWriteCSV
    Inherits DataAccessBase
    Implements DataAccessWriteInterface
    Dim fname As String
    Dim sname As String
    Public Overrides Sub Session(ParamArray openParam() As Object) Implements DataAccessWriteInterface.Session
        fname = openParam(0)
    End Sub

    Public Overrides Sub Write(ParamArray readParam() As Object) Implements DataAccessWriteInterface.Write


    End Sub

End Class
