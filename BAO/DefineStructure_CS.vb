Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Net

Public Module DefineStructure_CS
    'ロットデータ構造体
    <DataContract([Namespace]:="CSCOILDATA")>
    Public Class CS_SchduleData
        <DataMember>
        Public No As Int32
        <DataMember>
        Public Width As Double
        <DataMember>
        Public Weight As Double
        <DataMember>
        Public Thickness As Double
        <DataMember>
        Public LS As Double
        <DataMember>
        Public Coating_Top As Double
        <DataMember>
        Public Coating_Bot As Double
        <DataMember>
        Public Qty As Int32
        Public Sub New()
            No = 99999
            Qty = 1
        End Sub
    End Class
    <DataContract([Namespace]:="CSCOILDATA")>
    Public Class CS_SchduleDataList
        <DataMember>
        Public SchList As New List(Of CS_SchduleData)
    End Class

    Public Schl As New CS_SchduleDataList
    Public COIL_UPDATE_FLAG As Boolean
    Public COIL_REJECT_FLAG As Boolean
    Public COIL_REJECT_TIME As DateTime

    Public Enum CoilRequest
        CR_UPDATE = 0
        CR_STARTUP = 1
        CR_ENDCOIL = 2
        CR_SHUTDOWN = -1
    End Enum
    Public Enum CoilSchdule
        CS_NOUPDATE = 0
        CS_UPDATE = 1
        CS_NOPRODUCT = 2
        CS_REJECTED = 3
        CS_SHUTDOWN = -1
    End Enum

End Module
