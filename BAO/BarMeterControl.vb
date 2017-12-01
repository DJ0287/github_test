Public Class BarMeterControl
    Private _CtlForeColor As Color = Color.Aqua
    Private _CtlBackColor As Color = Color.White
    Private _CtlAlamColor As Color = Color.Red
    Private _Min As Double = 0
    Private _Max As Double = 100
    Private _Value As Double = 50

    Private _AlamH As Double = 90
    Private _AlamL As Double = 10
    Property CtlAlamColor As Color
        Get
            Return _CtlAlamColor
        End Get
        Set(value As Color)
            _CtlAlamColor = value
            Invalidate()
        End Set
    End Property
    Property CtlForeColor As Color
        Get
            Return _CtlForeColor
        End Get
        Set(value As Color)
            _CtlForeColor = value
            Invalidate()
        End Set
    End Property
    Property CtlBackColor As Color
        Get
            Return _CtlBackColor
        End Get
        Set(value As Color)
            _CtlBackColor = value
            Invalidate()
        End Set
    End Property
    Property AlamH As Double
        Get
            Return _AlamH
        End Get
        Set(value As Double)
            _AlamH = Math.Max(Math.Min(value, Max), Min)
            Invalidate()
        End Set
    End Property
    Property AlamL As Double
        Get
            Return _AlamL
        End Get
        Set(value As Double)
            _AlamL = Math.Min(Math.Max(value, Min), Max)
            Invalidate()
        End Set
    End Property
    Property Min As Double
        Get
            Return _Min
        End Get
        Set(value As Double)
            _Min = value
            Invalidate()
        End Set
    End Property
    Property Max As Double
        Get
            Return _Max
        End Get
        Set(value As Double)
            _Max = value
            Invalidate()
        End Set
    End Property
    Property Value As Double
        Get
            Return _Value
        End Get
        Set(value As Double)
            _Value = Math.Max(Math.Min(value, Max), Min)
            Invalidate()
        End Set
    End Property

    Private Sub BarMeterControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BarMeterControl_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim defsize = 24
        If (Size.Width < defsize) Then
            Size = New Size(defsize, Size.Height)
        End If
        Dim fact As Double = Math.Max(Math.Min((Value - Min) / (Max - Min), 1), 0)
        Dim AlmH_Height As Double = (1 - Math.Max(Math.Min((AlamH - Min) / (Max - Min), 1), 0)) * Size.Height
        Dim AlmL_Height As Double = (1 - Math.Max(Math.Min((AlamL - Min) / (Max - Min), 1), 0)) * Size.Height

        Dim offset = Size.Width - defsize
        Dim top As Integer = Size.Height * (1 - fact)
        Dim height As Double = Size.Height * fact
        Dim rca As New Rectangle(New Point(offset, 0), New Size(Size.Width, Size.Height))
        Dim rc0 As New Rectangle(New Point(offset, 0), New Size(Size.Width, top))
        Dim rc As New Rectangle(New Point(offset, top), New Size(Size.Width, height))
        Dim sf As New StringFormat
        Dim CtlColor As Color
        If Value > AlamH Or Value < AlamL Then
            CtlColor = CtlAlamColor
        Else
            CtlColor = CtlForeColor
        End If
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.Graphics.FillRectangle(New SolidBrush(CtlBackColor), rca)
        e.Graphics.FillRectangle(New SolidBrush(CtlColor), rc)
        e.Graphics.DrawRectangle(Pens.Gray, rca)
        e.Graphics.Clip = New Region(rc0)
        e.Graphics.DrawString(Value.ToString("0.0") & "%", New Font(SystemFonts.DefaultFont.FontFamily, 8.5), New SolidBrush(CtlColor), e.ClipRectangle, sf)
        e.Graphics.Clip = New Region(rc)
        e.Graphics.DrawString(Value.ToString("0.0") & "%", New Font(SystemFonts.DefaultFont.FontFamily, 8.5), New SolidBrush(CtlBackColor), e.ClipRectangle, sf)
        'sf.Alignment = StringAlignment.Far
        'sf.FormatFlags = StringFormatFlags.NoClip
        'e.Graphics.Clip = New Region(e.ClipRectangle)
        'sf.LineAlignment = StringAlignment.Far
        ''e.Graphics.DrawString("LL-", New Font(SystemFonts.DefaultFont.FontFamily, 8.5), New SolidBrush(CtlColor), New Rectangle(0, Size.Height - 10, offset, 20), sf)
        'e.Graphics.DrawString("L-", New Font(SystemFonts.DefaultFont.FontFamily, 8.5), New SolidBrush(CtlColor), New Rectangle(0, AlmL_Height - 10, offset, 20), sf)
        'sf.LineAlignment = StringAlignment.Near
        'e.Graphics.DrawString("H-", New Font(SystemFonts.DefaultFont.FontFamily, 8.5), New SolidBrush(CtlColor), New Rectangle(0, AlmH_Height, offset, 20), sf)
        ''e.Graphics.DrawString("HH-", New Font(SystemFonts.DefaultFont.FontFamily, 8.5), New SolidBrush(CtlColor), New Rectangle(0, 0, offset, 20), sf)
    End Sub
End Class
