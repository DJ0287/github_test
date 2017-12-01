Public MustInherit Class DataAccessBase
    Implements DataAccessInterface
    Public MustOverride Sub Session(ParamArray openParam()) Implements DataAccessInterface.Session
    Public Overridable Sub Read(ParamArray readParam()) Implements DataAccessInterface.Read

    End Sub
    Public Overridable Sub Write(ParamArray writeParam()) Implements DataAccessInterface.Write

    End Sub
End Class

