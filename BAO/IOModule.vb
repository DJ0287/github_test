Imports System.IO
Imports System.Collections.Generic
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Xml
Imports System.Runtime.Serialization
Imports System.Reflection
Imports System.Threading.Tasks

Module InterfaceBuilder
    Function BuildL1(fpath As String) As Dictionary(Of Integer, L1InterfaceMap)
        BuildL1 = New Dictionary(Of Integer, L1InterfaceMap)
        Dim cdir = fpath.Substring(0, fpath.LastIndexOf("\"))
        Dim imap As L1InterfaceMap = Nothing
        Using sr As New StreamReader(fpath, Encoding.Default)
            Dim line = sr.ReadLine()
            Do Until sr.EndOfStream
                line = sr.ReadLine()
                Dim params() = line.Split(",")
                Dim no = Convert.ToInt16(params(0))
                Dim msgno = Convert.ToInt16(params(4))
                Dim timeSpan = Convert.ToInt16(params(5))
                Dim size = Convert.ToInt16(params(2))
                Dim ifname = params(3)
                imap = New L1InterfaceMap(cdir & "\" & ifname & ".csv", msgno, size, timeSpan)

                BuildL1.Add(no, imap)
            Loop


        End Using

    End Function

    Function Build(fpath As String) As Dictionary(Of String, InterfaceMap)
        Build = New Dictionary(Of String, InterfaceMap)
        Dim cdir = fpath.Substring(0, fpath.LastIndexOf("\"))
        Dim imap As InterfaceMap = Nothing
        Using sr As New StreamReader(fpath, Encoding.Default)
            Dim line = sr.ReadLine()
            Do Until sr.EndOfStream
                line = sr.ReadLine()
                Dim params() = line.Split(",")
                Dim address '= Convert.ToInt32(params(1).Replace("&H", "00"), 16)
                If params(1).IndexOf("&H") >= 0 Then
                    address = Convert.ToInt32(params(1).Replace("&H", "00"), 16)
                Else
                    address = Convert.ToInt32(params(1))
                End If
                Select Case params(0)
                    Case "IF_PLC_TO_SRS_BIT_M9000"
                        Dim o As RECVDATA.BIT_PLC_SRS_M9000
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_PLC_TO_SRS_WORD_D6000"
                        Dim o As RECVDATA.WORD_PLC_SRS_D6000
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_BIT_M9100"
                        Dim o As SENDDATA.BIT_SRS_PLC_M9100
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_WORD_D6100"
                        Dim o As SENDDATA.WORD_SRS_PLC_D6100
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)

                    Case "IF_PLC_TO_SRS_BIT_M8000"
                        Dim o As RECVDATA.BIT_PLC_SRS_M8000
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_PLC_TO_SRS_WORD_D5000"
                        Dim o As RECVDATA.WORD_PLC_SRS_D5000
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_BIT_M8100"
                        Dim o As SENDDATA.BIT_SRS_PLC_M8100
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_WORD_D5100"
                        Dim o As SENDDATA.WORD_SRS_PLC_D5100
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_PLC_TO_SRS_BIT_IND"
                        Dim o As RECVDATA.BIT_PLC_SRS_IND
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_PLC_TO_SRS_BIT_CTR"
                        Dim o As RECVDATA.BIT_PLC_SRS_CTR
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_PLC_TO_SRS_WORD_IND"
                        Dim o As RECVDATA.WORD_PLC_SRS_IND
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_PLC_TO_SRS_WORD_CTR"
                        Dim o As RECVDATA.WORD_PLC_SRS_CTR
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_BIT_TREND"
                        Dim o As SENDDATA.BIT_SRS_PLC_TREND
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_BIT_ANS"
                        Dim o As SENDDATA.BIT_SRS_PLC_ANS
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_WORD_TREND"
                        Dim o As SENDDATA.WORD_SRS_PLC_TREND
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_SRS_TO_PLC_WORD_CTR"
                        Dim o As SENDDATA.WORD_SRS_PLC_CTR
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                    Case "IF_PLC_TO_SRS_WORD_SCH3", "IF_PLC_TO_SRS_WORD_SCH4"
                        Dim o As New ProductData
                        imap = New InterfaceMap(cdir & "\" & params(0) & ".csv", params(0), address, params(2), o)
                End Select
                Build.Add(params(0), imap)
            Loop
        End Using
        SetAttr(fpath, FileAttribute.Hidden)
    End Function
End Module

Module SRSFileIO

    Function Parameter_Import(fpath As String) As Boolean
        Parameter_Import = True
        Try
            Dim section As String
            Dim idx = fpath.LastIndexOf("\")
            If idx >= 0 Then
                section = Mid(fpath, idx + 2)
            Else
                section = fpath
            End If
            Using sr As New StreamReader(fpath, Encoding.UTF8)
                Dim line = sr.ReadLine()
                Do Until sr.EndOfStream
                    line = sr.ReadLine()
                    Dim params() = line.Split(",")
                    Dim paramattr As New ParameterAttr
                    paramattr.Section = section
                    paramattr.Name = params(0)
                    paramattr.Desc = params(1)
                    paramattr.Value = params(2)
                    Double.TryParse(paramattr.Value, paramattr.設定値)
                    Double.TryParse(params(3), paramattr.下限値)
                    Double.TryParse(params(4), paramattr.上限値)

                    idx = PARAMETER.Table.IndexOf(paramattr)
                    If idx >= 0 Then
                        PARAMETER.Table.Item(idx) = paramattr
                    Else
                        PARAMETER.Table.Add(paramattr)
                    End If
                Loop
            End Using
        Catch ex As System.IO.IOException
            Parameter_Import = False
        End Try
    End Function
    Function Parameter_Export(fpath As String) As Boolean
        Parameter_Export = True
        Try
            Dim section As String
            Dim idx = fpath.LastIndexOf("\")
            If idx >= 0 Then
                section = Mid(fpath, idx + 2)
            Else
                section = fpath
            End If
            Dim line As String
            Using sr As New StreamReader(fpath, Encoding.UTF8)
                line = sr.ReadLine()
            End Using
            Dim prms = From item In PARAMETER.Table
                       Where item.Section.Contains(section)
                       Select item
            If prms.Count > 0 Then
                Using sw As New StreamWriter(fpath, False, Encoding.UTF8)
                    sw.WriteLine(line)
                    For Each p In prms
                        sw.WriteLine(p.Name & "," & p.Desc & "," & p.Value & "," & p.下限値 & "," & p.上限値)
                    Next
                End Using
            End If
        Catch ex As System.IO.IOException
            Parameter_Export = False
        End Try

    End Function
    '    Public Function Interface_Import(fpath As String, t As Type, o As Object) As List(Of InterfaceMapItem)
    Function L1Interface_Import(fpath As String) As List(Of L1Item)
        L1Interface_Import = New List(Of L1Item)
        Dim line As String
        Dim address As Long = 0
        Using sr As New StreamReader(fpath, Encoding.Default)
            line = sr.ReadLine()
            Do Until sr.EndOfStream
                line = sr.ReadLine()
                Dim in_param() = line.Split(",")
                Dim in_item As New L1Item
                in_item.Address = address
                in_item.No = CInt(in_param(0))
                in_item.Fieldname = in_param(1)
                Select Case in_param(2)
                    Case "Integer32"
                        in_item.FieldType = FIELDTYPE.FT_INT32
                    Case "Integer"
                        in_item.FieldType = FIELDTYPE.FT_INT
                    Case "Character"
                        in_item.FieldType = FIELDTYPE.FT_STR
                    Case Else
                        in_item.FieldType = FIELDTYPE.FT_BYTE
                End Select

                in_item.FieldSize = CInt(in_param(3))
                in_item.FieldUnit = 1
                in_item.FieldLower = 0
                in_item.FieldUpper = 1
                If in_item.FieldType = FIELDTYPE.FT_INT Or in_item.FieldType = FIELDTYPE.FT_INT32 Then
                    Try
                        in_item.FieldUnit = Convert.ToDouble(in_param(4))
                        in_item.FieldLower = Convert.ToUInt16(in_param(5))
                        in_item.FieldUpper = Convert.ToUInt16(in_param(6))
                    Catch ee As Exception
                    End Try
                End If
                If in_item.FieldUnit = 0 Then
                    in_item.FieldUnit = 1
                End If

                L1Interface_Import.Add(in_item)
                address = address + in_item.FieldSize
            Loop
        End Using
        SetAttr(fpath, FileAttribute.Hidden)

    End Function

    Public Function Interface_Import(fpath As String, _devcode As String, o As Object) As List(Of InterfaceMapItem)
        Interface_Import = New List(Of InterfaceMapItem)
        Dim line As String
        Using sr As New StreamReader(fpath, Encoding.Default)
            line = sr.ReadLine()
            Do Until sr.EndOfStream
                line = sr.ReadLine()
                Dim in_param() = line.Split(",")
                Dim in_item As New InterfaceMapItem
                in_item.offset = CLng(in_param(0))
                in_item.fldname = in_param(1).Trim()
                in_item.comment = in_param(2)
                in_item.unit = CSng(in_param(3))
                in_item.lowlimit = UInt16.Parse(in_param(4))
                in_item.upperlimit = UInt16.Parse(in_param(5))
                If (in_param.Length > 6) Then
                    in_item.devcode = in_param(6)
                Else
                    in_item.devcode = _devcode
                End If
                Dim t = o.GetType()
                Try
                    Dim field = t.InvokeMember(in_item.fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, o, Nothing)
                    Select Case field.GetType().Name
                        Case "Boolean"
                            t.InvokeMember(in_item.fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetField, Nothing, o, New Object() {False})
                        Case "UnitWord"
                            t.InvokeMember(in_item.fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetField, Nothing, o, New Object() {New UnitWord(0, in_item.unit, in_item.lowlimit, in_item.upperlimit)})
                    End Select
                Catch ex As Exception

                End Try

                in_item.o = o
                '                Try
                'in_item.field = t.InvokeMember(in_item.fldname, BindingFlags.Static Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, o, Nothing)
                Interface_Import.Add(in_item)
                'Catch ex As Exception
                'Debugger.Log(1, "INITIALIZE", fpath & ":" & in_item.fldname & "が見つかりません" & vbCrLf)
                'in_item.field = Nothing

            Loop
        End Using
        SetAttr(fpath, FileAttribute.Hidden)
    End Function
    Public Sub CS_Setting(fpath As String)
        Dim line As String
        Dim ip As New IPAddress(New Byte() {127, 0, 0, 1})
        Using sr As New StreamReader(fpath, Encoding.Default)
            line = sr.ReadLine()
            Do Until sr.EndOfStream
                line = sr.ReadLine()
                Dim in_param() = line.Split(",")
                Select Case in_param(0)
                    Case "IPAddress"
                        Dim ipline() = in_param(2).Split(".")
                        ip = New IPAddress(New Byte() {CByte(ipline(0)), CByte(ipline(1)), CByte(ipline(2)), CByte(ipline(3))})
                    Case "PortNo"
                        CSINFO.IEP = New IPEndPoint(ip, CInt(in_param(2)))
                End Select
            Loop
        End Using

    End Sub

    Public Sub PLC_Setting(fpath As String)
        Dim line As String
        Dim ip As New IPAddress(New Byte() {127, 0, 0, 1})
        Using sr As New StreamReader(fpath, Encoding.Default)
            line = sr.ReadLine()
            Do Until sr.EndOfStream
                line = sr.ReadLine()
                Dim in_param() = line.Split(",")
                Select Case in_param(0)
                    Case "IPAddress"
                        Dim ipline() = in_param(2).Split(".")
                        ip = New IPAddress(New Byte() {CByte(ipline(0)), CByte(ipline(1)), CByte(ipline(2)), CByte(ipline(3))})
                    Case "PortNo"
                        PLCINFO.IEP = New IPEndPoint(ip, CInt(in_param(2)))
                    Case "NetNo"
                        PLCINFO.NetNo = CInt(in_param(2))
                    Case "PCNo"
                        PLCINFO.PCNo = CInt(in_param(2))
                End Select
            Loop
        End Using

    End Sub
    Sub L1_Setting(fpath As String)
        Dim line As String
        Dim ip As New IPAddress(New Byte() {127, 0, 0, 1})
        Using sr As New StreamReader(fpath, Encoding.Default)
            line = sr.ReadLine()
            Do Until sr.EndOfStream
                line = sr.ReadLine()
                Dim in_param() = line.Split(",")
                Select Case in_param(0)
                    Case "SERVER_IPAddress"
                        Dim ipline() = in_param(2).Split(".")
                        ip = New IPAddress(New Byte() {CByte(ipline(0)), CByte(ipline(1)), CByte(ipline(2)), CByte(ipline(3))})
                    Case "SERVER_PortNo"
                        L1INFO.IEP_SERVER = New IPEndPoint(ip, CInt(in_param(2)))
                    Case "LISTENER_IPAddress"
                        Dim ipline() = in_param(2).Split(".")
                        ip = New IPAddress(New Byte() {CByte(ipline(0)), CByte(ipline(1)), CByte(ipline(2)), CByte(ipline(3))})
                    Case "LISTENER_PortNo"
                        L1INFO.IEP_LISTEN = New IPEndPoint(ip, CInt(in_param(2)))
                End Select
            Loop
        End Using

    End Sub

End Module
Module L1IO
    Public Sub Sender()
        Dim replyCounter As Integer = 0
        Dim replyTimes As TimeSpan() = {TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(6), TimeSpan.FromSeconds(10)}
        Dim seqNo As Integer = 1
        Dim SendTimingList As New SortedDictionary(Of DateTime, Integer)
        Dim nowTime As DateTime = DateTime.Now
        Dim connectionLostTime As DateTime = nowTime + TimeSpan.FromSeconds(5)
        Dim l1intfitem = L1INFO.L1MessageMap(4)
        SendTimingList.Add(nowTime + TimeSpan.FromSeconds(l1intfitem.timeSpan), 4) 'MsgNo. 4
        l1intfitem = L1INFO.L1MessageMap(6)
        SendTimingList.Add(nowTime + TimeSpan.FromSeconds(l1intfitem.timeSpan), 6) 'MsgNo. 6
        Dim L1Server = New TcpClient

        L1INFO.ServerRunnning = True
        L1INFO.SendEventType = &HE0
        Do While (L1INFO.ServerRunnning)
            L1INFO.SendTcp = L1Server
            '接続済み
            Try
                If L1Server.Connected = False Then
                    Dim t As Task = L1Server.ConnectAsync(L1INFO.IEP_SERVER.Address, L1INFO.IEP_SERVER.Port)
                    If (t.Wait(5000) = False) Then
                        L1Server.Close()
                        Continue Do
                    End If
                End If
                Dim nStream = L1Server.GetStream()
                nStream.ReadTimeout = 5000
                nStream.WriteTimeout = 5000
                seqNo = 1
                Do While (SendTimingList.Count > 0)
                    nowTime = DateTime.Now
                    If SendTimingList.First().Key > nowTime Then
                        Task.Delay(1000).Wait()
                        Continue Do
                    End If
                    Dim eventData As KeyValuePair(Of DateTime, Integer) = SendTimingList.First()
                    SendTimingList.Remove(eventData.Key)
                    Dim replyCode = SendSRSTOL1(nStream, nowTime, seqNo, L1INFO.L1MessageMap(eventData.Value))
                    If replyCode <> &HE0 Then
                        replyCounter = replyCounter + 1
                        If replyCounter > 0 Then
                            Exit Do
                        End If
                        SendTimingList.Add(nowTime + replyTimes(replyCounter), eventData.Value)
                    Else
                        seqNo = (seqNo + 1) Mod 10000
                        If seqNo = 0 Then
                            seqNo = seqNo + 1
                        End If
                        SendTimingList.Add(nowTime + TimeSpan.FromSeconds(L1INFO.L1MessageMap(eventData.Value).timeSpan), eventData.Value)
                    End If
                    L1INFO.SendEventType = replyCode

                Loop
            Catch ex As Exception
            End Try
            replyCounter = 0
            nowTime = DateTime.Now
            SendTimingList.Clear()
            l1intfitem = L1INFO.L1MessageMap(4)
            SendTimingList.Add(nowTime + TimeSpan.FromSeconds(l1intfitem.timeSpan), 4) 'MsgNo. 4
            l1intfitem = L1INFO.L1MessageMap(6)
            SendTimingList.Add(nowTime + TimeSpan.FromSeconds(l1intfitem.timeSpan), 6) 'MsgNo. 6
            Task.Delay(5000).Wait()
            L1Server = New TcpClient
        Loop

    End Sub
    Public Sub Reciever()
        Dim replyCounter As Integer = 0
        Dim replyTimes As TimeSpan() = {TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(6), TimeSpan.FromSeconds(10)}
        Dim L1Client = New TcpListener(L1INFO.IEP_LISTEN)
        Dim Tcp As TcpClient
        Dim ifmap = L1INFO.L1MessageMap
        Dim L1_HDR_SIZE = ifmap(0).l1itemlist.Last.Address + ifmap(0).l1itemlist.Last.FieldSize
        Dim hdrbuffer(L1_HDR_SIZE - 1) As Byte
        Do While (True)
            L1Client.Start()
            Do While (True)
                Tcp = L1Client.AcceptTcpClient()
                L1INFO.RecvTcp = Tcp
                Dim nstream = Tcp.GetStream()
                nstream.ReadTimeout = 20000
                nstream.WriteTimeout = 5000

                Do While (Tcp.Connected)
                    Dim replycode As Integer = &HE0
                    L1INFO.RecvEventType = replycode
                    Try
                        'Do While Tcp.Available < L1_HDR_SIZE And Tcp.Connected
                        '    Task.Delay(1000).Wait()
                        'Loop
                        'If Tcp.Connected = False Then
                        '    Exit Do
                        'End If
                        nstream.Read(hdrbuffer, 0, L1_HDR_SIZE)
                        Dim hdrif = ifmap(0)
                        hdrif.SetBuffer(hdrbuffer)
                        Dim msgno = hdrif.GetField(3)

                        Select Case msgno
                            Case 1
                                replycode = InterfaceSetStuff(1, hdrif.GetBuffer(), nstream)
                                L1INFO.RecieveNewCoilLow = True
                            Case 4
                                replycode = InterfaceSetStuff(2, hdrif.GetBuffer(), nstream)
                                L1INFO.RecieveNewCoilHigh = True
                            Case 2
                                replycode = InterfaceSetStuff(3, hdrif.GetBuffer(), nstream)
                                L1INFO.RecieveNewMeasure = True
                            Case -1
                                replycode = InterfaceSetStuff(5, hdrif.GetBuffer(), nstream)
                            Case Else
                                replycode = &H50E0
                        End Select
                        Dim sendif = ifmap(8)
                        sendif.SetField(1, replycode)
                        sendif.SetField(2, hdrif.GetField(4))
                        sendif.SetField(3, DateTime.Now.ToString("HHmmss"))
                        nstream.Write(sendif.GetBuffer(), 0, sendif.GetBuffer().Length)
                        Monitor.Enter(L1INFO.LockItem)
                        L1INFO.L1MessageMap(8) = sendif
                        Monitor.Exit(L1INFO.LockItem)
                        L1INFO.RecvEventType = replycode
                    Catch ex As Exception
                        replyCounter = replyCounter + 1
                        If replyCounter > 4 Then
                            replyCounter = 1
                        End If
                        Exit Do
                    End Try
                Loop
                Tcp.Close()
                nstream.Close()
                'Task.Delay(replyTimes(replyCounter).TotalMilliseconds).Wait()
            Loop
        Loop
    End Sub
    Public Function InterfaceSetStuff(No As Integer, hdrbuffer As Byte(), nstream As NetworkStream) As Integer
        Dim replycode = &HE0
        Dim databuffer() As Byte
        Dim ifmap = L1INFO.L1MessageMap(No)
        Dim L1_SIZE = ifmap.l1itemlist.Last.Address + ifmap.l1itemlist.Last.FieldSize
        Dim L1_SIZE_LEFT = L1_SIZE - hdrbuffer.Length
        ReDim databuffer(L1_SIZE_LEFT - 1)

        nstream.Read(databuffer, 0, L1_SIZE_LEFT)
        Dim tmpbuf = hdrbuffer.ToList()
        tmpbuf.AddRange(databuffer)
        hdrbuffer = tmpbuf.ToArray()
        ifmap.SetBuffer(hdrbuffer)
        Dim datalen = ifmap.GetField(2)
        If datalen <> L1_SIZE - 8 Then
            replycode = &H52E0
        End If
        Dim seqNo = ifmap.GetField(4)
        Monitor.Enter(L1INFO.LockItem)
        L1INFO.L1MessageMap(No) = ifmap
        Monitor.Exit(L1INFO.LockItem)
        Return replycode

    End Function
    Public Function SendSRSTOL1(nStream As NetworkStream, nowtime As DateTime, seqNo As Integer, ifmap As L1InterfaceMap) As Integer
        Dim replyif = L1INFO.L1MessageMap(8)
        Dim datalen As UInt16 = ifmap.l1itemlist.Last().Address + ifmap.l1itemlist.Last().FieldSize - 8
        ifmap.SetField(1, &H60)
        ifmap.SetField(2, datalen)
        ifmap.SetField(3, ifmap.MessageNo)
        ifmap.SetField(4, seqNo.ToString("0000"))
        ifmap.SetField(5, nowtime.ToString("HHmmss"))
        Dim buffer = ifmap.GetBuffer()
        nStream.Write(buffer, 0, buffer.Length)
        nStream.Read(replyif.GetBuffer(), 0, replyif.GetBuffer().Length)
        Return replyif.GetField(1)

    End Function
End Module
Module CSIO
    Const TIMEOUTSEC As Double = 5

    Dim retryTimer As DateTime = DateTime.Now
    Public tcp As TcpClient = New TcpClient()
    '   Public HeaderPacket As String
    '    Public RequeBAOacket As String
    Public RequeBAOacketBin As List(Of Byte) = New List(Of Byte)
    Public RequeBAOacketLenPos = 0
    Public PacketDelim As List(Of Short) = New List(Of Short)
    Public t As Task = Nothing

    Public Function Connect(IEP As IPEndPoint) As Integer
        Connect = 0
        If Not (t Is Nothing) Then
            If t.IsCompleted = False Then
                Connect = -1
                Exit Function
            End If
        End If
        Try
            If tcp.Connected = False Then
                '未接続の時は接続
                If retryTimer < DateTime.Now Then
                    t = tcp.ConnectAsync(IEP.Address, IEP.Port)
                Else
                    Connect = -1
                End If
            Else
                '接続中の時は有効性を確認
                Dim state = tcp.Client.Poll(10, SelectMode.SelectWrite)
                If state = False Then
                    tcp.Close()
                    retryTimer = DateTime.Now + TimeSpan.FromSeconds(5)
                    'Thread.Sleep(500)
                    'tcp.Connect(IEP)
                End If
            End If
            Connect = Not tcp.Connected
        Catch ex As Exception
            Connect = ex.HResult
            retryTimer = DateTime.Now + TimeSpan.FromSeconds(5)
            tcp = New TcpClient()
        End Try

    End Function
    Public Function Disconnect() As Integer
        Disconnect = 0
        Try
            tcp.Close()
        Catch ex As Exception
            Disconnect = ex.HResult
        End Try

    End Function
    Public Function CheckAndUpdateSchedule(Optional Startup As Boolean = False) As CoilSchdule
        If (tcp.Connected) Then
            Dim TeArray(19) As Byte
            Using bw = New BinaryWriter(tcp.GetStream(), Encoding.UTF8, True)
                If Startup Then
                    bw.Write(CoilRequest.CR_STARTUP)
                Else
                    bw.Write(CoilRequest.CR_UPDATE)
                End If
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.STRIP_THICKNESS.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.STRIP_WIDTH.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_BACK.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_FRONT.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.LINESPEED.ToDouble())
                Dim L As Integer = 0
                For Each sch As ProductData In ETLPRODSCHS(0).Products
                    TeArray(L) = (sch.Te > 0) * -1
                    L = L + 1
                Next
                bw.Write(TeArray.ToArray())

                Using br = New BinaryReader(tcp.GetStream(), Encoding.UTF8, True)
                    CheckAndUpdateSchedule = br.ReadInt32()
                    If CheckAndUpdateSchedule = CoilSchdule.CS_UPDATE Then
                        XMLCoilDataDeSerialize(br)
                    End If
                End Using
            End Using
        Else
            CheckAndUpdateSchedule = CoilSchdule.CS_NOUPDATE
        End If

    End Function
    Public Function RejectCoil() As CoilSchdule
        If (tcp.Connected) Then
            Dim TeArray(19) As Byte

            Using bw = New BinaryWriter(tcp.GetStream(), Encoding.UTF8, True)
                bw.Write(CoilRequest.CR_ENDCOIL)
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.STRIP_THICKNESS.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.STRIP_WIDTH.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_BACK.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.BASIS_TARGET_FRONT.ToDouble())
                bw.Write(RECVDATA.WORD_PLC_SRS_D5000.LINESPEED.ToDouble())
                Dim L As Integer = 0
                For Each sch As ProductData In ETLPRODSCHS(0).Products
                    TeArray(L) = (sch.Te > 0) * -1
                    L = L + 1
                Next
                bw.Write(TeArray.ToArray())
                Using br = New BinaryReader(tcp.GetStream(), Encoding.UTF8, True)
                    RejectCoil = br.ReadInt32()
                End Using
            End Using
        Else
            RejectCoil = CoilSchdule.CS_NOUPDATE
        End If
    End Function
End Module

Module PLCIO
    Const TIMEOUTSEC As Double = 1

    Dim retryTimer As DateTime = DateTime.Now
    Public tcp As TcpClient = New TcpClient()
    '   Public HeaderPacket As String
    '    Public RequeBAOacket As String
    Public RequeBAOacketBin As List(Of Byte) = New List(Of Byte)
    Public RequeBAOacketLenPos = 0
    Public PacketDelim As List(Of Short) = New List(Of Short)
    Public t As Task = Nothing

    Public Function Connect(IEP As IPEndPoint) As Integer
        Connect = 0
        If Not (t Is Nothing) Then
            If t.IsCompleted = False Then
                Connect = -1
                Exit Function
            End If
        End If
        Try
            If tcp.Connected = False Then
                '未接続の時は接続
                If retryTimer < DateTime.Now Then
                    t = tcp.ConnectAsync(IEP.Address, IEP.Port)
                Else
                    Connect = -1
                End If
            Else
                '接続中の時は有効性を確認
                Dim state = tcp.Client.Poll(10, SelectMode.SelectWrite)
                If state = False Then
                    tcp.Close()
                    retryTimer = DateTime.Now + TimeSpan.FromSeconds(5)
                    'Thread.Sleep(500)
                    'tcp.Connect(IEP)
                End If
            End If

        Catch ex As Exception
            Connect = ex.HResult
            retryTimer = DateTime.Now + TimeSpan.FromSeconds(5)
            tcp = New TcpClient()
        End Try

    End Function
    Public Function Disconnect() As Integer
        Disconnect = 0
        Try
            tcp.Close()
        Catch ex As Exception
            Disconnect = ex.HResult
        End Try

    End Function

    Public Function MakeHeader(NetNo As Integer, PCNo As Integer) As Integer
        'PLCの通信伝文ヘッダ
        '3Eフレーム(MELSEC-Q)を使用
        'HeaderPacket = "5000"
        PacketDelim.Clear()
        RequeBAOacketBin.Clear()
        RequeBAOacketBin.Add(&H50)
        RequeBAOacketBin.Add(&H0)
        PacketDelim.Add(RequeBAOacketBin.Count)
        'アクセス経路
        'HeaderPacket = HeaderPacket & Right("00" & Hex(NetNo), 2) & Right("00" & Hex(PCNo), 2)
        'HeaderPacket = HeaderPacket & "03FF" ' 要求先ユニットI/O番号(管理CPUの固定値)　
        'HeaderPacket = HeaderPacket & "00" ' 要求先ユニット局番号(管理CPUの固定値)　

        RequeBAOacketBin.Add(NetNo)
        RequeBAOacketBin.Add(PCNo)
        RequeBAOacketBin.Add(&HFF)
        RequeBAOacketBin.Add(&H3)
        RequeBAOacketBin.Add(&H0)
        PacketDelim.Add(RequeBAOacketBin.Count)

        '要求データ長(RequeBAOacket長が確定したあとで埋めるためのマーカセット)
        'HeaderPacket = HeaderPacket & "$DLN"
        RequeBAOacketLenPos = RequeBAOacketBin.Count
        RequeBAOacketBin.Add(Asc("$"))
        RequeBAOacketBin.Add(Asc("$"))
        PacketDelim.Add(RequeBAOacketBin.Count)

        'RequeBAOacket = ""

        MakeHeader = 0
    End Function
    '    Public Sub AddRequest(Message As String)
    '        RequeBAOacket = RequeBAOacket & Message
    '    End Sub
    Public Sub AddRequest(b As Byte)
        RequeBAOacketBin.Add(b)
        PacketDelim.Add(RequeBAOacketBin.Count)
    End Sub
    Public Sub AddRequest(w As Int16)
        Dim bytes = BitConverter.GetBytes(w)
        RequeBAOacketBin.Add(bytes(0))
        RequeBAOacketBin.Add(bytes(1))
        PacketDelim.Add(RequeBAOacketBin.Count)
    End Sub
    Public Sub AddRequest(w As UInt16)
        Dim bytes = BitConverter.GetBytes(w)
        RequeBAOacketBin.Add(bytes(0))
        RequeBAOacketBin.Add(bytes(1))
        PacketDelim.Add(RequeBAOacketBin.Count)
    End Sub

    Public Sub AddRequest(w As Int32)
        Dim bytes = BitConverter.GetBytes(w)
        RequeBAOacketBin.Add(bytes(0))
        RequeBAOacketBin.Add(bytes(1))
        RequeBAOacketBin.Add(bytes(2))
        RequeBAOacketBin.Add(bytes(3))
        PacketDelim.Add(RequeBAOacketBin.Count)
    End Sub

    Public Function SendPacket(ByRef errcode As Integer) As Byte()
        Dim recvdata() As Byte
        SendPacket = Nothing
        errcode = 0
        Dim plen = (RequeBAOacketBin.Count) - (RequeBAOacketLenPos + 2)
        Dim bytes = BitConverter.GetBytes(plen)
        RequeBAOacketBin(RequeBAOacketLenPos + 0) = bytes(0)
        RequeBAOacketBin(RequeBAOacketLenPos + 1) = bytes(1)
        'HeaderPacket = HeaderPacket.Replace("$DLN", Right("0000" & Hex(RequeBAOacket.Length), 4))

        'Dim encoding = New ASCIIEncoding
        'Dim senddata() = encoding.GetBytes(HeaderPacket & RequeBAOacket)
        Dim senddata = RequeBAOacketBin.ToArray()
        PacketLog.Logging(senddata, "SEND", PacketDelim)
        Try
            Dim datalen As UInt16
            Dim response() As Byte
            Dim responseoffset As Integer = 0
            Dim nstream = tcp.GetStream()
            nstream.Write(senddata, 0, senddata.Length)
            Dim timeout As DateTime = DateTime.Now + TimeSpan.FromSeconds(TIMEOUTSEC)
            Do Until tcp.Available > 0 Or DateTime.Now > timeout
                Thread.Sleep(10)
            Loop
            If tcp.Available > 0 Then
                ReDim recvdata(tcp.Available - 1)
                nstream.Read(recvdata, 0, tcp.Available)
                'response = encoding.GetString(recvdata)
                response = recvdata
                PacketLog.Logging(response, "RECV", New List(Of Short) From {2, 7, 9, 11, 13, 15, 17})
                responseoffset = 0
                '3Eフレーム(MELSEC-Q)を使用
                responseoffset = responseoffset + 2
                'アクセス経路
                responseoffset = responseoffset + 2 + 2 + 1
                '応答データ長
                'datalen = Val("&H" & response.Substring(responseoffset, 4))
                'datalen = Convert.ToInt32(response.Substring(responseoffset, 4), 16)
                datalen = BitConverter.ToInt16(response, responseoffset)
                responseoffset = responseoffset + 2
                '終了コード
                'errcode = Val("&H" & response.Substring(responseoffset, 4))
                'errcode = Convert.ToInt32(response.Substring(responseoffset, 4), 16)
                errcode = BitConverter.ToInt16(response, responseoffset)
                responseoffset = responseoffset + 2
            Else
                datalen = 0
                errcode = -1
                response = Nothing
            End If
            If datalen > 2 Then
                Dim resbin = response.ToList()
                resbin.RemoveRange(0, responseoffset)
                SendPacket = resbin.ToArray()
            End If
        Catch ex As Exception
            errcode = ex.HResult
        End Try

    End Function
    Public Function WriteBlockData(NetNo As Integer, PCNo As Integer, wordblock As InterfaceMap, bitblock As InterfaceMap) As Integer
        MakeHeader(NetNo, PCNo)
        '要求伝文(監視タイマ(1H=0.25sec))
        AddRequest(CShort(0))
        '要求伝文(ブロック一括コマンド)
        AddRequest(CShort(&H1406))
        '要求伝文(ブロック書き込みサブコマンド)
        AddRequest(CShort(0))
        '要求伝文(ワードデバイスブロック数)
        If (wordblock.blockdevicelist Is Nothing OrElse wordblock.blockdevicelist.Count = 0) Then
            AddRequest(CByte(0))
        Else
            AddRequest(CByte(wordblock.blockdevicelist.Count))
        End If
        '要求伝文(ビットデバイスブロック数)
        If (bitblock.blockdevicelist Is Nothing OrElse bitblock.blockdevicelist.Count = 0) Then
            AddRequest(CByte(0))
        Else
            AddRequest(CByte(bitblock.blockdevicelist.Count))
        End If
        '要求伝文(ワードデバイスブロックデータ)
        If (wordblock.blockdevicelist Is Nothing OrElse wordblock.blockdevicelist.Count = 0) Then
        Else
            For Each item In wordblock.blockdevicelist
                Dim adrs As Int32 = item.address
                Select Case item.devcode(0)
                    Case "M"
                        adrs = adrs + &H90000000
                    Case "L"
                        adrs = adrs + &H92000000
                    Case "D"
                        adrs = adrs + &HA8000000
                End Select
                AddRequest(adrs)
                AddRequest(item.devNum)

                'Dim str = Left(item.devcode & "**", 2)
                'Dim hexstr = Hex(Asc(str(0))) & Hex(Asc(str(1)))
                'AddRequest(hexstr)
                'AddRequest(Right("000000" & Hex(item.address), 6))
                'AddRequest(Right("0000" & Hex(item.devNum), 4))
                For K = 0 To item.devNum - 1
                    Dim word As UShort = wordblock.interfacelist(item.offset + K).GetWord()
                    'AddRequest(Right("0000" & Hex(word), 4))
                    AddRequest(word)
                Next
            Next
        End If
        '要求伝文(ビットデバイスブロックデータ)
        If (bitblock.blockdevicelist Is Nothing OrElse bitblock.blockdevicelist.Count = 0) Then
        Else
            For Each item In bitblock.blockdevicelist
                Dim num16fix As UInt16 = CType(Fix((item.devNum - 1) / 16) + 1, UInt16)
                Dim adrs As Int32 = item.address
                Select Case item.devcode(0)
                    Case "M"
                        adrs = adrs + &H90000000
                    Case "L"
                        adrs = adrs + &H92000000
                    Case "D"
                        adrs = adrs + &HA8000000
                End Select
                AddRequest(adrs)
                AddRequest(num16fix)
                For K = 0 To num16fix - 1
                    Dim word As UInt16 = 0
                    For Bit = 0 To 15
                        Dim off = K * 16 + Bit + item.offset
                        If off >= bitblock.interfacelist.Count Then
                            Exit For
                        End If
                        word = word + (bitblock.interfacelist(off).GetBoolean() = True) * (-1) * 2 ^ Bit
                    Next
                    AddRequest(word)
                Next
            Next
        End If
        Dim RecvPacket = SendPacket(WriteBlockData)


    End Function
    Public Function ReadBlockData(NetNo As Integer, PCNo As Integer, wordblock As InterfaceMap, bitblock As InterfaceMap) As Integer
        MakeHeader(NetNo, PCNo)
        '要求伝文(監視タイマ(1H=0.25sec))
        AddRequest(CShort(0))
        '要求伝文(ブロック一括コマンド)
        AddRequest(CShort(&H406))
        '要求伝文(ブロック読み込みサブコマンド)
        AddRequest(CShort(0))
        '要求伝文(ワードデバイスブロック数)
        If (wordblock.blockdevicelist Is Nothing OrElse wordblock.blockdevicelist.Count = 0) Then
            AddRequest(CByte(0))
        Else
            AddRequest(CByte(wordblock.blockdevicelist.Count))
        End If
        '要求伝文(ビットデバイスブロック数)
        If (bitblock.blockdevicelist Is Nothing OrElse bitblock.blockdevicelist.Count = 0) Then
            AddRequest(CByte(0))
        Else
            AddRequest(CByte(bitblock.blockdevicelist.Count))
        End If
        '要求伝文(ワードデバイスブロックデータ)
        If (wordblock.blockdevicelist Is Nothing OrElse wordblock.blockdevicelist.Count = 0) Then
        Else
            For Each item In wordblock.blockdevicelist
                'AddRequest(Left(item.devcode & "**", 2))
                Dim adrs As Int32 = item.address
                Select Case item.devcode(0)
                    Case "M"
                        adrs = adrs + &H90000000
                    Case "L"
                        adrs = adrs + &H92000000
                    Case "D"
                        adrs = adrs + &HA8000000
                End Select
                AddRequest(adrs)
                AddRequest(item.devNum)
            Next
        End If
        '要求伝文(ビットデバイスブロックデータ)
        If (bitblock.blockdevicelist Is Nothing OrElse bitblock.blockdevicelist.Count = 0) Then
        Else
            For Each item In bitblock.blockdevicelist
                Dim num16fix As Int16 = CType(Fix((item.devNum - 1) / 16) + 1, Short)
                Dim adrs As Int32 = item.address
                Select Case item.devcode(0)
                    Case "M"
                        adrs = adrs + &H90000000
                    Case "L"
                        adrs = adrs + &H92000000
                    Case "D"
                        adrs = adrs + &HA8000000
                End Select
                AddRequest(adrs)
                AddRequest(num16fix)
            Next
        End If

        Dim RecvPacket = SendPacket(ReadBlockData).ToArray()

        Dim pos As Int16 = 0
        '応答伝文(ワードデバイスブロックデータ)
        If (wordblock.blockdevicelist Is Nothing OrElse wordblock.blockdevicelist.Count = 0) Then
        Else
            For Each item In wordblock.blockdevicelist
                For K = 0 To item.devNum - 1
                    'Dim word As Int16 = Val("&H" & RecvPacket.Substring(pos * 4, 4))
                    Dim word As UInt16 = BitConverter.ToUInt16(RecvPacket, pos * 2)
                    wordblock.interfacelist(K + item.offset).SetField(word)
                    pos = pos + 1
                Next
            Next
        End If
        '応答伝文(ビットデバイスブロックデータ)
        If (bitblock.blockdevicelist Is Nothing OrElse bitblock.blockdevicelist.Count = 0) Then
        Else
            For Each item In bitblock.blockdevicelist
                Dim num16fix As UInt16 = CType(Fix((item.devNum - 1) / 16) + 1, UInt16)
                For K = 0 To num16fix - 1
                    'Dim word As UInt16 = Val("&H" & RecvPacket.Substring(pos * 4, 4))
                    Dim word As UInt16 = BitConverter.ToUInt16(RecvPacket, pos * 2)
                    For Bit = 0 To 15
                        Dim off = K * 16 + Bit + item.offset
                        If off >= bitblock.interfacelist.Count Then
                            Exit For
                        End If
                        bitblock.interfacelist(off).SetField((word And (2 ^ Bit)) <> 0)
                    Next
                    pos = pos + 1
                Next
            Next
        End If


    End Function

    Public Function WriteData(NetNo As Integer, PCNo As Integer, address As Integer, devcode As String, ByRef bitarray() As Boolean) As Integer
        MakeHeader(NetNo, PCNo)
        '要求伝文(監視タイマ(1H=0.25sec))
        AddRequest(CShort(0))
        '要求伝文(一括コマンド)
        AddRequest(CShort(&H1401))
        '要求伝文(ビット書き込みサブコマンド)
        AddRequest(CShort(1))
        '要求伝文(デバイスコード)
        '要求伝文(デバイス番号)
        address = address + &H92000000
        AddRequest(address)
        'デバイス点数
        AddRequest(CShort(Fix(bitarray.Length / 2 + bitarray.Length Mod 2)))
        Dim bit As Byte = 0
        For K = 0 To bitarray.Length - 1
            'ビットデータの書き込みは1文字1ビット
            If K Mod 2 = 0 Then
                bit = bitarray(K) * (-1) * 16
            Else
                bit = bit + bitarray(K) * (-1)
                AddRequest(bit)
            End If
            'If bitarray(K) Then
            '    AddRequest("1")
            'Else
            '    AddRequest("0")
            'End If
        Next
        If bitarray.Length - 1 Mod 2 = 0 Then
            AddRequest(bit)
        End If
        Dim RecvPacket = SendPacket(WriteData)
    End Function
    Public Function WriteData(NetNo As Integer, PCNo As Integer, address As Integer, devcode As String, ByRef wordarray() As Int16) As Integer
        MakeHeader(NetNo, PCNo)
        '要求伝文(監視タイマ(1H=0.25sec))
        AddRequest(CShort(0))
        '要求伝文(一括コマンド)
        AddRequest(CShort(&H1401))
        '要求伝文(ワード書き込みサブコマンド)
        AddRequest(CShort(0))
        '要求伝文(デバイスコード)
        '要求伝文(デバイス番号)
        address = address + &HA8000000
        AddRequest(address)
        AddRequest(CShort(wordarray.Length))
        For K = 0 To wordarray.Length - 1
            'ワードデータの書き込みは4文字1ワード
            AddRequest(wordarray(K))
        Next

        Dim RecvPacket = SendPacket(WriteData)

    End Function
    Public Function ReadBitdata(NetNo As Integer, PCNo As Integer, address As Integer, devcode As String, size As Short, ByRef ecode As Integer) As Boolean()
        MakeHeader(NetNo, PCNo)
        '要求伝文(監視タイマ(1H=0.25sec))
        AddRequest(CShort(0))
        '要求伝文(一括コマンド)
        AddRequest(CShort(&H401))
        '要求伝文(ビット読み込みサブコマンド)
        AddRequest(CShort(1))
        '要求伝文(デバイスコード)
        '要求伝文(デバイス番号)
        address = address + &H92000000
        AddRequest(address)
        AddRequest(CShort(size))
        Dim RecvPacket = SendPacket(ecode)

        '応答伝文からデータを取得する
        If ecode = 0 And size > 0 Then
            Dim bitarray(size - 1) As Boolean
            'RecvDataが0の時は正常終了している
            'ビットデータの応答は1文字4ビット
            Dim pos = 0
            For K = 0 To bitarray.Length - 1
                If (K < RecvPacket.Length) Then
                    If K Mod 2 = 0 Then
                        bitarray(K) = (RecvPacket(pos) And &HF0) <> 0
                    Else
                        bitarray(K) = (RecvPacket(pos) And &HF) <> 0
                        pos = pos + 1
                    End If
                End If
            Next
            ReadBitdata = bitarray
        Else
            ReadBitdata = Nothing
        End If
    End Function
    Public Function ReadWorddata(NetNo As Integer, PCNo As Integer, address As Integer, devcode As String, size As Short, ByRef ecode As Integer) As Int16()
        MakeHeader(NetNo, PCNo)
        '要求伝文(監視タイマ(1H=0.25sec))
        AddRequest(CShort(0))
        '要求伝文(一括コマンド)
        AddRequest(CShort(&H401))
        '要求伝文(ワード読み込みサブコマンド)
        AddRequest(CShort(0))
        '要求伝文(デバイスコード)
        '要求伝文(デバイス番号)
        address = address + &HA8000000
        AddRequest(address)
        AddRequest(CShort(size))
        Dim RecvPacket = SendPacket(ecode)
        Dim K
        '応答伝文からデータを取得する
        If ecode = 0 And size > 0 Then
            Dim wordarray(size - 1) As Int16
            'RecvDataが0の時は正常終了している
            'ワードデータの応答は4文字1ワード
            For K = 0 To wordarray.Length - 1
                If (K < RecvPacket.Length) Then
                    'wordarray(K) = Val("&H" & RecvPacket.Substring(K * 4, 4))
                    'wordarray(K) = Convert.ToInt16(RecvPacket.Substring(K * 4, 4), 16)
                    wordarray(K) = BitConverter.ToInt16(RecvPacket, K * 2)
                End If
            Next

            ReadWorddata = wordarray
        Else
            ReadWorddata = Nothing

        End If

    End Function
End Module
Module ALAMIO
    Public Sub ALAM_Setting(fpath As String)
        Dim line As String
        ALAM.ALAMMESSAGES.Clear()
        ALAM.ALAMITEMS.Clear()
        Try
            Using sr As New StreamReader(fpath, Encoding.Default)
                line = sr.ReadLine()
                Do Until sr.EndOfStream
                    Dim alamitem As New AlamItem
                    line = sr.ReadLine()
                    Dim in_param() = line.Split(",")
                    alamitem.No = CShort(in_param(0))
                    alamitem.Trigger = False
                    alamitem.TriggerTime = DateTime.MinValue
                    alamitem.RecoverTime = DateTime.MinValue
                    ALAM.ALAMITEMS.Add(alamitem.No, alamitem)
                    ALAM.ALAMMESSAGES.Add(alamitem.No, in_param(1))
                Loop
            End Using
        Catch ex As Exception

        End Try

    End Sub
    Public Sub AlamRecord_Import(fpath As String)
        Dim line As String
        ALAM.ALAMHIST.Clear()
        Try
            Using sr As New StreamReader(fpath, Encoding.Default)
                Do Until sr.EndOfStream
                    Dim alamitem As New AlamItem
                    line = sr.ReadLine()
                    Dim in_param() = line.Split(",")
                    alamitem.No = CShort(in_param(0))
                    alamitem.Trigger = CShort(in_param(1)) = 1
                    alamitem.TriggerTime = DateTime.Parse(in_param(2))
                    alamitem.RecoverTime = DateTime.Parse(in_param(3))
                    ALAM.ALAMHIST.Add(alamitem)
                Loop
            End Using
        Catch ex As Exception

        End Try
        '過去のアラームで未解消のものを現在のアラームにセット()
        Dim almhist = From ah In ALAM.ALAMHIST
                      Where ah.Trigger = True
        For Each alm In almhist
            ALAM.ALAMITEMS(alm.No) = alm
        Next
    End Sub
    Public Sub AlamRecord_Export(fpath As String)
        Try
            Using sw As New StreamWriter(fpath, False, Encoding.Default)
                For Each p In ALAM.ALAMHIST
                    sw.Write(p.No.ToString("D2") & ",")
                    If p.Trigger Then
                        sw.Write("1,")
                    Else
                        sw.Write("0,")
                    End If
                    sw.Write(p.TriggerTime.ToString("yyyy/MM/dd HH:mm:ss") & ",")
                    sw.Write(p.RecoverTime.ToString("yyyy/MM/dd HH:mm:ss") & ",")
                    sw.WriteLine(ALAM.ALAMMESSAGES.Item(p.No))
                Next
            End Using


        Catch ex As Exception
        End Try
    End Sub

End Module
Module SLSIO
    Public Sub SLS_Setting(fpath As String)
        Dim line As String
        SLS.SLSMESSAGES.Clear()
        SLS.SLSITEMS.Clear()
        Try
            Using sr As New StreamReader(fpath, Encoding.Default)
                line = sr.ReadLine()
                Do Until sr.EndOfStream
                    Dim analitem As New SLSItem
                    line = sr.ReadLine()
                    Dim in_param() = line.Split(",")
                    analitem.No = CShort(in_param(0))
                    analitem.Trigger = False
                    analitem.TriggerTime = DateTime.MinValue
                    analitem.RecoverTime = DateTime.MinValue
                    SLS.SLSITEMS.Add(analitem.No, analitem)
                    SLS.SLSMESSAGES.Add(analitem.No, in_param(1))
                Loop
            End Using
        Catch ex As Exception

        End Try

    End Sub
    Public Sub SLSRecord_Import(fpath As String)
        Dim line As String
        SLS.SLSHIST.Clear()
        Try
            Using sr As New StreamReader(fpath, Encoding.Default)
                Do Until sr.EndOfStream
                    Dim analitem As New SLSItem
                    line = sr.ReadLine()
                    Dim in_param() = line.Split(",")
                    'analitem.No = CShort(in_param(0))
                    'analitem.Trigger = CShort(in_param(1)) = 1
                    'analitem.TriggerTime = DateTime.Parse(in_param(2))
                    'analitem.RecoverTime = DateTime.Parse(in_param(3))
                    analitem.InputTime = DateTime.Parse(in_param(0))
                    analitem.TinIon = CDbl(in_param(1))
                    analitem.MSA = CDbl(in_param(2))
                    analitem.EN = CDbl(in_param(3))
                    SLS.SLSHIST.Add(analitem)
                Loop
            End Using
        Catch ex As Exception

        End Try
        '過去のアラームで未解消のものを現在のアラームにセット()
        Dim anlhist = From ah In SLS.SLSHIST
                      Where ah.Trigger = True
        For Each anl In anlhist
            SLS.SLSITEMS(anl.No) = anl
        Next
    End Sub
    Public Sub SLSRecord_Export(fpath As String)
        Try
            Using sw As New StreamWriter(fpath, False, Encoding.Default)
                For Each p In SLS.SLSHIST
                    sw.Write(p.InputTime.ToString("yyyy/MM/dd HH:mm:ss") & ",")
                    sw.Write(p.TinIon.ToString & ",")
                    sw.Write(p.MSA.ToString & ",")
                    sw.Write(p.EN.ToString & vbCrLf)
                Next
            End Using


        Catch ex As Exception
        End Try
    End Sub

End Module

Module SYSTEMINFOIO
    Public Sub SYSTEMINFO_Load(fpath As String)
        Dim line As String
        Try
            Using sr As New StreamReader(fpath, Encoding.Default)
                Do Until sr.EndOfStream
                    line = sr.ReadLine()
                    Dim in_param() = line.Split(",")
                    SYSTEMCONDITION.更新時刻 = DateTime.Parse(in_param(0))
                    SYSTEMCONDITION.ETL操業時間 = TimeSpan.FromHours(Double.Parse(in_param(1)))
                    SYSTEMCONDITION.システム稼働時間 = TimeSpan.FromHours(Double.Parse(in_param(2)))
                    SYSTEMCONDITION.LastETL操業時間 = TimeSpan.FromHours(Double.Parse(in_param(3)))
                    SYSTEMCONDITION.Lastシステム稼働時間 = TimeSpan.FromHours(Double.Parse(in_param(4)))
                    SYSTEMCONDITION.Last稼働率 = Single.Parse(in_param(5))
                Loop
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SYSTEMINFO_Save(fpath As String)
        Try
            Using sw As New StreamWriter(fpath, False, Encoding.Default)
                sw.Write(SYSTEMCONDITION.更新時刻.ToString("yyyy/MM/dd HH:mm:ss") & ",")
                sw.Write(SYSTEMCONDITION.ETL操業時間.TotalHours() & ",")
                sw.Write(SYSTEMCONDITION.システム稼働時間.TotalHours() & ",")
                sw.Write(SYSTEMCONDITION.LastETL操業時間.TotalHours() & ",")
                sw.Write(SYSTEMCONDITION.Lastシステム稼働時間.TotalHours() & ",")
                sw.Write(SYSTEMCONDITION.Last稼働率)
                sw.WriteLine()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SYSTEMINFO_Import(fpath As String)
        Dim line As String
        Try
            Using sr As New StreamReader(fpath, Encoding.Default)
                Do Until sr.EndOfStream
                    line = sr.ReadLine()
                    Dim in_param() = line.Split(",")
                    SYSTEMCONDITION.更新時刻 = DateTime.Parse(in_param(0))
                    SYSTEMCONDITION.LastETL操業時間 = TimeSpan.FromHours(Double.Parse(in_param(1)))
                    SYSTEMCONDITION.Lastシステム稼働時間 = TimeSpan.FromHours(Double.Parse(in_param(2)))
                    SYSTEMCONDITION.Last稼働率 = Single.Parse(in_param(3))
                Loop
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SYSTEMINFO_Export(fpath As String)
        Try
            Using sw As New StreamWriter(fpath, False, Encoding.Default)
                sw.Write(DateTime.Now & ",")
                sw.Write(SYSTEMCONDITION.ETL操業時間.TotalHours() & ",")
                sw.Write(SYSTEMCONDITION.システム稼働時間.TotalHours() & ",")
                sw.Write(SYSTEMCONDITION.稼働率)
                sw.WriteLine()
            End Using

        Catch ex As Exception

        End Try
    End Sub

End Module
Module DATASTRAGEIO
    Public Sub DumpHeader(sw As TextWriter, ifdata As InterfaceMap)
        For Each item In ifdata.interfacelist
            If item.fldname.IndexOf("RESERVE") < 0 Then
                sw.Write("," & item.fldname)
            End If
        Next

    End Sub
    Public Sub DumpData(sw As TextWriter, ifdata As InterfaceMap)
        For Each item In ifdata.interfacelist
            If item.fldname.IndexOf("RESERVE") < 0 Then
                Dim field = item.GetField()

                If field.GetType().Name = "Boolean" Then
                    sw.Write("," & item.GetBoolean())
                Else
                    sw.Write("," & field.ToDouble())
                End If
            End If
        Next

    End Sub

    Public Sub DataStore(dirpath As String, ifdata As InterfaceMap, Optional addInterface() As OUTSTR = Nothing)
        Try

            Dim nowtime = DateTime.Now
            Dim timeprx = nowtime.ToString("HH:mm:ss")
            Dim datepfx = nowtime.ToString("yyyyMMdd")

            Dim path = dirpath & "\" & datepfx & "_" & ifdata.strname & ".csv"
            If Not My.Computer.FileSystem.FileExists(path) Then
                Using sw As New StreamWriter(path, False, Encoding.Default)
                    sw.Write("オフセット")
                    For Each item In ifdata.interfacelist
                        sw.Write("," & item.offset)
                    Next
                    If addInterface Is Nothing Then
                    Else
                        For Each item In addInterface
                            sw.Write("," & item.Offset)
                        Next
                    End If
                    sw.WriteLine()
                    sw.Write("項目")
                    For Each item In ifdata.interfacelist
                        sw.Write("," & item.comment)
                    Next
                    If addInterface Is Nothing Then
                    Else
                        For Each item In addInterface
                            sw.Write("," & item.Name)
                        Next
                    End If

                    sw.WriteLine()
                End Using
            End If
            Using sw As New StreamWriter(path, True, Encoding.Default)
                sw.Write(timeprx)
                For Each item In ifdata.interfacelist
                    Dim field = item.GetField
                    If Not field Is Nothing Then
                        If TypeOf field Is Boolean Then
                            sw.Write("," & field * (-1))
                        Else
                            sw.Write("," & field.ToDouble)
                        End If
                    Else
                        sw.Write(",0")
                    End If
                Next
                If addInterface Is Nothing Then
                Else
                    For Each item In addInterface
                        sw.Write("," & item.field.ToDouble)
                    Next
                End If
                sw.WriteLine()
            End Using
        Catch ex As Exception

        End Try

    End Sub
End Module
Module XMLIO

    Public Sub XMLCoilDataSerialize(filename As String)
        Dim serializer As New DataContractSerializer(GetType(CS_SchduleDataList))
        Using sw = New StreamWriter(filename, False, Encoding.UTF8)
            'BOMが付かないUTF-8で、書き込むファイルを開く
            Dim settings As New XmlWriterSettings()
            settings.Encoding = New System.Text.UTF8Encoding(False)
            settings.OmitXmlDeclaration = True
            settings.CloseOutput = False
            settings.Indent = True
            settings.IndentChars = "    "
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates
            settings.NewLineOnAttributes = False
            settings.NewLineChars = vbCrLf
            Dim xw As XmlWriter = XmlWriter.Create(sw, settings)
            'シリアル化し、XMLファイルに保存する
            serializer.WriteObject(xw, Schl)
            'ファイルを閉じる
            xw.Close()
        End Using
    End Sub

    Public Sub XMLCoilDataDeSerialize(filename As String)
        'DataContractSerializerオブジェクトを作成
        Dim serializer As New DataContractSerializer(GetType(CS_SchduleDataList))
        Using tw = New StreamReader(filename, Encoding.UTF8)
            Dim settings As New XmlReaderSettings()
            Dim xr As XmlReader = XmlReader.Create(tw, settings)
            'XMLファイルから読み込み、逆シリアル化する
            Schl = DirectCast(serializer.ReadObject(xr), CS_SchduleDataList)
            'ファイルを閉じる
        End Using

    End Sub

    Public Sub XMLCoilDataSerialize(s As BinaryWriter)
        Dim serializer As New DataContractSerializer(GetType(CS_SchduleDataList))
        '一度メモリーに書いてから書き出す
        Using tw = New StreamWriter(New MemoryStream(), Encoding.UTF8)

            'BOMが付かないUTF-8で、書き込むファイルを開く
            Dim settings As New XmlWriterSettings()
            settings.Encoding = New System.Text.UTF8Encoding(False)
            settings.OmitXmlDeclaration = True
            settings.CloseOutput = False
            'settings.Indent = True
            'settings.IndentChars = "    "
            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates
            settings.NewLineOnAttributes = False
            'settings.NewLineChars = "\r\n"
            Dim xw As XmlWriter = XmlWriter.Create(tw, settings)
            'シリアル化し、XMLファイルに保存する
            serializer.WriteObject(xw, Schl)
            'ファイルを閉じる
            xw.Close()
            tw.BaseStream.Seek(0, SeekOrigin.Begin)
            Using sw = New StreamReader(tw.BaseStream)
                s.Write(sw.ReadToEnd())
            End Using

        End Using


    End Sub
    Public Sub XMLCoilDataDeSerialize(s As BinaryReader)
        'DataContractSerializerオブジェクトを作成
        Dim serializer As New DataContractSerializer(GetType(CS_SchduleDataList))
        Using tw = New StreamWriter(New MemoryStream(), Encoding.UTF8)
            Dim settings As New XmlReaderSettings()
            '読み込むファイルを開く
            Dim xml = s.ReadString()
            Console.WriteLine(xml)
            tw.Write(xml)
            tw.Flush()
            tw.BaseStream.Seek(0, SeekOrigin.Begin)
            Using sw = New StreamReader(tw.BaseStream)
                Dim xr As XmlReader = XmlReader.Create(sw, settings)
                'XMLファイルから読み込み、逆シリアル化する
                Schl = DirectCast(serializer.ReadObject(xr), CS_SchduleDataList)
                'ファイルを閉じる
            End Using
        End Using

    End Sub
End Module
