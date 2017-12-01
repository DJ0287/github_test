Imports Microsoft.VisualBasic.FileIO

Public Class DataAccessReadCSV
    Inherits DataAccessBase
    Implements DataAccessReadInterface
    Dim fname As String
    Dim sname As String
    Public Overrides Sub Session(ParamArray openParam() As Object) Implements DataAccessReadInterface.Session
        fname = openParam(0)
    End Sub

    Public Overrides Sub Read(ParamArray readParam() As Object) Implements DataAccessReadInterface.Read
        'Dim etlno = CInt(readParam(0))
        'Dim idx = etlno - 3
        'sname = etlno.ToString()
        'Dim f As New TextFieldParser(fname & "#" & sname & ".csv")
        'Try
        '    f.Delimiters = {","}
        '    f.ReadLine()
        '    RECVDATA.WORD_PLC_SRS_SCHS(idx).Products.Clear()
        '    Do Until f.EndOfData
        '        Dim fields = f.ReadFields()
        '        Dim prd As ProductData
        '        prd.No = New UnitWord(UInt16.Parse(fields(0) + etlno * 10000))
        '        prd.Weight = New UnitWord(UInt16.Parse(fields(1)), 0.1F)
        '        prd.TPH = New UnitWord(UInt16.Parse(fields(2)), 0.01F)
        '        prd.Thickness = New UnitWord(UInt16.Parse(fields(3)), 0.001F)
        '        prd.Width = New UnitWord(UInt16.Parse(fields(4)), 0.1F)
        '        prd.Coating = New UnitWord(UInt16.Parse(fields(5)))
        '        RECVDATA.WORD_PLC_SRS_SCHS(idx).Products.Add(prd)
        '    Loop
        '    RECVDATA.WORD_PLC_SRS_SCHS(idx).Updated()
        'Catch ex As Exception
        '    Throw ex
        'End Try

    End Sub

End Class
