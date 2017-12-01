Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.IO
Imports System.Text

Public Class Log
    Dim fnameprefix As String
    Public Sub New(_fnameprefix As String)
        If DirectoryExists("C:\DATASTRAGE") = False Then
            CreateDirectory("C:\DATASTRAGE")
        End If
        fnameprefix = _fnameprefix
    End Sub
    Public Sub Logging(catcher As System.Object, sender As System.Object, e As TaskEventArgs)
        '        If DEBUG.Logging Then
        If Not (e.ex Is Nothing) Then
            Dim logdate As DateTime = Date.Now
            Dim fname As String = "C:\DATASTRAGE\" & logdate.ToString("yyyyMMdd") & "_" & fnameprefix & ".log"
            Dim msg = "Reciever [" & catcher.GetType().Name & "] ← Sender[" & sender.GetType().Name & "],Result < " & [Enum].GetName(e.etype.GetType(), e.etype) & " >"
            If Not (e.ex Is Nothing) Then
                msg = msg & ",ExtMsg. < " & e.ex.ToString() & " > "
            End If
            WriteAllText(fname, logdate.ToString("yyyy/MM/dd HH:mm:ss.fff ") & " : " & msg & vbCrLf, True, Encoding.UTF8)
        End If

    End Sub
End Class
Module PVSVLog
    Public Sub Logging錫溶解補正量(name, threshold, target, pv_cond, va, alpha, tc, ds)
        If DEBUG.Logging Then
            Dim fname As String
            Dim logdate As DateTime = Date.Now
            fname = "C:\DATASTRAGE\" & logdate.ToString("yyyyMMdd") & "_" & name & "補正演算処理確認用.csv"
            Using sw As New StreamWriter(fname, True, Encoding.UTF8)
                sw.Write(logdate.ToString("yyyy/MM/dd HH:mm:ss"))
                sw.Write("," & threshold)
                sw.Write("," & target)
                sw.Write("," & tc)
                sw.Write("," & va)
                sw.Write("," & alpha)
                sw.Write("," & pv_cond)
                sw.Write(",," & ds)
                sw.Write("," & tc * 60)
                sw.WriteLine()
            End Using

        End If

    End Sub

    Public Sub Logging()
        If DEBUG.Logging Then
            Dim fname As String
            Dim logdate As DateTime = Date.Now
            'Dim STA_COND = RECVDATA.WORD_PLC_SRS_CTR.StA_AVE.ToDouble()
            'Dim NO3_COND = RECVDATA.WORD_PLC_SRS_CTR.No3_AVE.ToDouble()
            'Dim NO4_COND = RECVDATA.WORD_PLC_SRS_CTR.No4_AVE.ToDouble()
            'Dim CAH = PARAMETER.Find("CAH").設定値
            'Dim CAHH = PARAMETER.Find("CAHH").設定値
            'Dim CAL = PARAMETER.Find("CAL").設定値
            'Dim CAL_L = PARAMETER.Find("CALL").設定値
            'Dim CAREF = PARAMETER.Find("CAREF").設定値
            'Dim C3OH = PARAMETER.Find("C3OH").設定値
            'Dim C3OL = PARAMETER.Find("C3OL").設定値
            'Dim C4OH = PARAMETER.Find("C4OH").設定値
            'Dim C4OL = PARAMETER.Find("C4OL").設定値
            'Dim Cob3 = PARAMETER.Find("COB3").設定値
            'Dim Cob4 = PARAMETER.Find("COB4").設定値


            'Dim logdate As DateTime = Date.Now
            'Dim fname As String = logdate.ToString("yyyyMMdd") & "_ΔS1a,b,c,d,e,f,g,h.csv"
            'Using sw As New StreamWriter(fname, True, Encoding.Default)
            '    sw.Write(logdate.ToString("yyyy/MM/dd HH:mm:ss"))
            '    sw.Write("," & PARAMETER.Find("α1").設定値)
            '    sw.Write("," & PARAMETER.Find("α2").設定値)
            '    sw.Write("," & PARAMETER.Find("α3").設定値)
            '    sw.Write("," & PARAMETER.Find("α4").設定値)
            '    sw.Write("," & PARAMETER.Find("α5").設定値)
            '    sw.Write("," & PARAMETER.Find("α6").設定値)
            '    sw.Write("," & PARAMETER.Find("α7").設定値)
            '    sw.Write("," & PARAMETER.Find("α8").設定値)
            '    sw.Write("," & DISCOMBSCH.dS1a)
            '    sw.Write("," & DISCOMBSCH.dS1b)
            '    sw.Write("," & DISCOMBSCH.dS1c)
            '    sw.Write("," & DISCOMBSCH.dS1d)
            '    sw.Write("," & DISCOMBSCH.dS1e)
            '    sw.Write("," & DISCOMBSCH.dS1f)
            '    sw.Write("," & DISCOMBSCH.dS1g)
            '    sw.Write("," & DISCOMBSCH.dS1h)
            '    sw.WriteLine()

            'End Using

            fname = "C:\DATASTRAGE\" & logdate.ToString("yyyyMMdd") & "_供給流量演算処理確認用.csv"
            Using sw As New StreamWriter(fname, True, Encoding.UTF8)
                sw.Write(logdate.ToString("yyyy/MM/dd HH:mm:ss"))
                sw.Write("," & CHECKVARIABLE.NewData.No3_Sn)
                sw.Write("," & CHECKVARIABLE.NewData.No4_Sn)
                sw.Write("," & CHECKVARIABLE.NewData.StA_AVE)
                sw.Write("," & CHECKVARIABLE.NewData.No3_AVE)
                sw.Write("," & CHECKVARIABLE.NewData.No4_AVE)
                sw.Write("," & CHECKVARIABLE.NewData.No3_TL)
                sw.Write("," & CHECKVARIABLE.NewData.No4_TL)
                sw.Write("," & PARAMETER.Search("FSUP1").設定値)
                sw.Write("," & PARAMETER.Search("FSUP2").設定値)
                sw.Write("," & PARAMETER.Search("COB3").設定値)
                sw.Write("," & PARAMETER.Search("C3FH").設定値)
                sw.Write("," & PARAMETER.Search("TC10").設定値)
                sw.Write("," & PARAMETER.Search("α10").設定値)
                sw.Write("," & PARAMETER.Search("C3FL").設定値)
                sw.Write("," & PARAMETER.Search("TC9").設定値)
                sw.Write("," & PARAMETER.Search("α9").設定値)
                sw.Write("," & PARAMETER.Search("COB4").設定値)
                sw.Write("," & PARAMETER.Search("C4FH").設定値)
                sw.Write("," & PARAMETER.Search("TC12").設定値)
                sw.Write("," & PARAMETER.Search("α12").設定値)
                sw.Write("," & PARAMETER.Search("C4FL").設定値)
                sw.Write("," & PARAMETER.Search("TC11").設定値)
                sw.Write("," & PARAMETER.Search("α11").設定値)
                sw.Write("," & Task03Control_01sec.linecondition(0) * (-1))
                sw.Write("," & Task03Control_01sec.linecondition(1) * (-1))
                sw.Write("," & RECVDATA.BIT_PLC_SRS_CTR.溶解槽_錫投入中 * (-1))
                sw.Write(",," & CHECKVARIABLE.NewData.F3set)
                sw.Write("," & CHECKVARIABLE.NewData.F4set)
                sw.Write("," & CHECKVARIABLE.NewData.Faset)
                sw.WriteLine()

            End Using
            fname = "C:\DATASTRAGE\" & logdate.ToString("yyyyMMdd") & "_FIC7&8確認用.csv"
            Using sw As New StreamWriter(fname, True, Encoding.UTF8)
                sw.Write(logdate.ToString("yyyy/MM/dd HH:mm:ss"))
                sw.Write("," & CHECKVARIABLE.NewData.FCV2_PV)
                sw.Write("," & CHECKVARIABLE.NewData.FCV4_PV)
                sw.Write("," & CHECKVARIABLE.NewData.StA_TL)
                sw.Write("," & CHECKVARIABLE.NewData.StA_TL_SETVAL)
                sw.Write("," & CHECKVARIABLE.NewData.FCV7_PV)
                sw.Write("," & PARAMETER.Search("VAHH").設定値)
                sw.Write("," & PARAMETER.Search("FCSET").設定値)
                sw.Write(",," & CHECKVARIABLE.NewData.Faset)
                sw.Write("," & CHECKVARIABLE.NewData.Fbset)
                sw.WriteLine()

            End Using







        End If
    End Sub
End Module

Module PacketLog
    Public Sub Logging(packet As String, packetname As String)
        If False And DEBUG.Logging Then

            Dim logdate As DateTime = Date.Now
            Dim fname As String = "C:\DATASTRAGE\" & logdate.ToString("yyyyMMdd") & "_" & packetname & ".log"

            Using sw As New StreamWriter(fname, True, Encoding.UTF8)
                sw.WriteLine(logdate.ToString("yyyy/MM/dd HH:mm:ss") & "," & packet)
            End Using
        End If

    End Sub
    Public Sub Logging(packet As Byte(), packetname As String, Optional ByVal PacketDelim As List(Of Short) = Nothing)
        If False And DEBUG.Logging Then

            Dim logdate As DateTime = Date.Now
            Dim fname As String = "C:\DATASTRAGE\" & logdate.ToString("yyyyMMdd") & "_" & packetname & ".log"

            Using sw As New StreamWriter(fname, True, Encoding.UTF8)
                sw.Write(logdate.ToString("yyyy/MM/dd HH:mm:ss") & ",")
                For K = 0 To packet.Length - 1
                    sw.Write(packet(K).ToString("X2"))
                    If PacketDelim Is Nothing Then
                        If K Mod 2 <> 0 Then
                            sw.Write("|")
                        End If
                    Else
                        If PacketDelim.Count > 0 AndAlso PacketDelim(0) - 1 = K Then
                            sw.Write("|")
                            PacketDelim.RemoveAt(0)
                        End If

                    End If
                Next
                sw.WriteLine()
            End Using
        End If
    End Sub

End Module
Module CAPTURE
    Sub 画面キャプチャ(form As FrmButton_BAO, timestr As String, postfix As String)
        If form.ScrHdrLabel.Text = "" Then
            Exit Sub
        End If
        Dim name = form.ScrHdrLabel.Text
        Dim cdir = "C:\DATASTRAGE\Capture"
        If Not My.Computer.FileSystem.DirectoryExists(cdir) Then
            My.Computer.FileSystem.CreateDirectory(cdir)
        End If
        cdir = cdir & "\" & timestr.Substring(0, 8)
        If Not My.Computer.FileSystem.DirectoryExists(cdir) Then
            My.Computer.FileSystem.CreateDirectory(cdir)
        End If
        cdir = cdir & "\" & name
        If Not My.Computer.FileSystem.DirectoryExists(cdir) Then
            My.Computer.FileSystem.CreateDirectory(cdir)
        End If

        Dim fname = cdir & "\" & timestr & "_" & name & postfix & ".png"
        'Dim img As New Bitmap(form.Width, form.Height)
        'Dim memg As Graphics = Graphics.FromImage(img)
        'Dim dc As IntPtr = memg.GetHdc()
        'PrintWindow(form.Handle, dc, 0)
        'img.Save(fname)
        'memg.ReleaseHdc(dc)
        'memg.Dispose()
        Dim bitmap As New Bitmap(CInt(form.Width), CInt(form.Height))
        form.DrawToBitmap(bitmap, New Rectangle(0, 0, form.Width, form.Height))
        bitmap.Save(fname)
        bitmap.Dispose()

    End Sub
End Module

