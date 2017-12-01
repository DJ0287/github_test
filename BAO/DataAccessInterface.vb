Public Interface DataAccessInterface
    Sub Session(ParamArray openParam() As Object)
    Sub Read(ParamArray readParam() As Object)
    Sub Write(ParamArray writeParam() As Object)
End Interface

Public Interface DataAccessReadInterface
    Sub Session(ParamArray openParam() As Object)
    Sub Read(ParamArray readParam() As Object)
End Interface

Public Interface DataAccessWriteInterface
    Sub Session(ParamArray openParam() As Object)
    Sub Write(ParamArray writeParam() As Object)
End Interface
