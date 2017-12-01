<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm07Prm_BAO
    Inherits ETL_SRS_BAO.FrmButton_BAO

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm07Prm_BAO))
        Me.PasswdBtn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_CSI = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TB_CAdH = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TB_TC1 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TB_CAH = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TB_TC2 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TB_CAL = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TB_TC4 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TB_CAdL = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TB_TC3 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.LB_LOCK = New System.Windows.Forms.Label()
        Me.PasswordLockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BTN_PARA_RELOAD = New System.Windows.Forms.Button()
        Me.TB_mu = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_FBSET = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.TB_a1 = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TB_a2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.TB_FASET = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PasswdBtn
        '
        Me.PasswdBtn.BackColor = System.Drawing.Color.Yellow
        Me.PasswdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswdBtn.Location = New System.Drawing.Point(360, 60)
        Me.PasswdBtn.Name = "PasswdBtn"
        Me.PasswdBtn.Size = New System.Drawing.Size(136, 39)
        Me.PasswdBtn.TabIndex = 122
        Me.PasswdBtn.Text = "Password"
        Me.PasswdBtn.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(58, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(286, 24)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "O2 flow calculation parameter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(75, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(400, 27)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "Tin replenishing inlet O2 concentration:Csi(ppm)"
        '
        'TB_CSI
        '
        Me.TB_CSI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_CSI.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_CSI.Location = New System.Drawing.Point(476, 228)
        Me.TB_CSI.Name = "TB_CSI"
        Me.TB_CSI.Size = New System.Drawing.Size(68, 27)
        Me.TB_CSI.TabIndex = 125
        Me.TB_CSI.Tag = "0.0"
        Me.TB_CSI.Text = "9.9"
        Me.TB_CSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(685, 162)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(452, 48)
        Me.Label25.TabIndex = 155
        Me.Label25.Text = "Sn concentration excess correction calculation " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "                  parameter for " &
    "cir. Tank"
        '
        'TB_CAdH
        '
        Me.TB_CAdH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_CAdH.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_CAdH.Location = New System.Drawing.Point(1104, 253)
        Me.TB_CAdH.Name = "TB_CAdH"
        Me.TB_CAdH.Size = New System.Drawing.Size(68, 27)
        Me.TB_CAdH.TabIndex = 159
        Me.TB_CAdH.Tag = "0.00"
        Me.TB_CAdH.Text = "9.99"
        Me.TB_CAdH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.Location = New System.Drawing.Point(703, 253)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(400, 27)
        Me.Label26.TabIndex = 158
        Me.Label26.Text = "Concentration deviation value(H):CAdH(g/L)"
        '
        'TB_TC1
        '
        Me.TB_TC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_TC1.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_TC1.Location = New System.Drawing.Point(1104, 229)
        Me.TB_TC1.Name = "TB_TC1"
        Me.TB_TC1.Size = New System.Drawing.Size(68, 27)
        Me.TB_TC1.TabIndex = 157
        Me.TB_TC1.Tag = "0.00"
        Me.TB_TC1.Text = "9.99"
        Me.TB_TC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(703, 229)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(400, 27)
        Me.Label27.TabIndex = 156
        Me.Label27.Text = "Correction time:tc1(min)"
        '
        'TB_CAH
        '
        Me.TB_CAH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_CAH.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_CAH.Location = New System.Drawing.Point(1104, 301)
        Me.TB_CAH.Name = "TB_CAH"
        Me.TB_CAH.Size = New System.Drawing.Size(68, 27)
        Me.TB_CAH.TabIndex = 163
        Me.TB_CAH.Tag = "0.00"
        Me.TB_CAH.Text = "9.99"
        Me.TB_CAH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(703, 301)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(400, 27)
        Me.Label28.TabIndex = 162
        Me.Label28.Text = "Concentration deviation value(HH):CAH(g/L)"
        '
        'TB_TC2
        '
        Me.TB_TC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_TC2.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_TC2.Location = New System.Drawing.Point(1104, 277)
        Me.TB_TC2.Name = "TB_TC2"
        Me.TB_TC2.Size = New System.Drawing.Size(68, 27)
        Me.TB_TC2.TabIndex = 161
        Me.TB_TC2.Tag = "0.00"
        Me.TB_TC2.Text = "9.99"
        Me.TB_TC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(703, 277)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(400, 27)
        Me.Label29.TabIndex = 160
        Me.Label29.Text = "Correction time:tc2(min)"
        '
        'TB_CAL
        '
        Me.TB_CAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_CAL.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_CAL.Location = New System.Drawing.Point(1104, 495)
        Me.TB_CAL.Name = "TB_CAL"
        Me.TB_CAL.Size = New System.Drawing.Size(68, 27)
        Me.TB_CAL.TabIndex = 172
        Me.TB_CAL.Tag = "0.00"
        Me.TB_CAL.Text = "9.99"
        Me.TB_CAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(703, 495)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(400, 27)
        Me.Label31.TabIndex = 171
        Me.Label31.Text = "Concentration deviation value(LL):CAL(g/L)"
        '
        'TB_TC4
        '
        Me.TB_TC4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_TC4.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_TC4.Location = New System.Drawing.Point(1104, 471)
        Me.TB_TC4.Name = "TB_TC4"
        Me.TB_TC4.Size = New System.Drawing.Size(68, 27)
        Me.TB_TC4.TabIndex = 170
        Me.TB_TC4.Tag = "0.00"
        Me.TB_TC4.Text = "9.99"
        Me.TB_TC4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(703, 471)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(400, 27)
        Me.Label32.TabIndex = 169
        Me.Label32.Text = "Correction time:tc4(min)"
        '
        'TB_CAdL
        '
        Me.TB_CAdL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_CAdL.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_CAdL.Location = New System.Drawing.Point(1104, 447)
        Me.TB_CAdL.Name = "TB_CAdL"
        Me.TB_CAdL.Size = New System.Drawing.Size(68, 27)
        Me.TB_CAdL.TabIndex = 168
        Me.TB_CAdL.Tag = "0.00"
        Me.TB_CAdL.Text = "9.99"
        Me.TB_CAdL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(703, 447)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(400, 27)
        Me.Label33.TabIndex = 167
        Me.Label33.Text = "Concentration deviation value(L):CAdL(g/L)"
        '
        'TB_TC3
        '
        Me.TB_TC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_TC3.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_TC3.Location = New System.Drawing.Point(1104, 423)
        Me.TB_TC3.Name = "TB_TC3"
        Me.TB_TC3.Size = New System.Drawing.Size(68, 27)
        Me.TB_TC3.TabIndex = 166
        Me.TB_TC3.Tag = "0.00"
        Me.TB_TC3.Text = "9.99"
        Me.TB_TC3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label34
        '
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(703, 423)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(400, 27)
        Me.Label34.TabIndex = 165
        Me.Label34.Text = "Correction time:tc3(min)"
        '
        'LB_LOCK
        '
        Me.LB_LOCK.BackColor = System.Drawing.Color.Red
        Me.LB_LOCK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LB_LOCK.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_LOCK.Location = New System.Drawing.Point(502, 65)
        Me.LB_LOCK.Name = "LB_LOCK"
        Me.LB_LOCK.Size = New System.Drawing.Size(90, 30)
        Me.LB_LOCK.TabIndex = 201
        Me.LB_LOCK.Text = "Lock"
        '
        'PasswordLockTimer
        '
        Me.PasswordLockTimer.Interval = 5000
        '
        'BTN_PARA_RELOAD
        '
        Me.BTN_PARA_RELOAD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_PARA_RELOAD.Location = New System.Drawing.Point(598, 60)
        Me.BTN_PARA_RELOAD.Name = "BTN_PARA_RELOAD"
        Me.BTN_PARA_RELOAD.Size = New System.Drawing.Size(98, 39)
        Me.BTN_PARA_RELOAD.TabIndex = 202
        Me.BTN_PARA_RELOAD.Text = "Reload"
        Me.BTN_PARA_RELOAD.UseVisualStyleBackColor = True
        '
        'TB_mu
        '
        Me.TB_mu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_mu.Enabled = False
        Me.TB_mu.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_mu.Location = New System.Drawing.Point(476, 254)
        Me.TB_mu.Name = "TB_mu"
        Me.TB_mu.Size = New System.Drawing.Size(68, 27)
        Me.TB_mu.TabIndex = 209
        Me.TB_mu.Tag = "0.00"
        Me.TB_mu.Text = "9.99"
        Me.TB_mu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TB_mu.Visible = False
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(75, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(400, 27)
        Me.Label5.TabIndex = 208
        Me.Label5.Text = "Dissolved oxygen efficiency:μ(Nm3/min)"
        Me.Label5.Visible = False
        '
        'TB_FBSET
        '
        Me.TB_FBSET.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_FBSET.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_FBSET.Location = New System.Drawing.Point(476, 373)
        Me.TB_FBSET.Name = "TB_FBSET"
        Me.TB_FBSET.Size = New System.Drawing.Size(68, 27)
        Me.TB_FBSET.TabIndex = 211
        Me.TB_FBSET.Tag = "0.0"
        Me.TB_FBSET.Text = "9.9"
        Me.TB_FBSET.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label52
        '
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(75, 373)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(400, 27)
        Me.Label52.TabIndex = 210
        Me.Label52.Text = "Tin replenishing self cir. flow rate:Fbset(m3/min)"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(58, 309)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(336, 24)
        Me.Label53.TabIndex = 123
        Me.Label53.Text = "Tin replenishing self cir. Parameter"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(58, 409)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(370, 24)
        Me.Label54.TabIndex = 123
        Me.Label54.Text = "Dissolved oxygen efficiency Parameter"
        '
        'Label55
        '
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(703, 571)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(400, 27)
        Me.Label55.TabIndex = 210
        Me.Label55.Text = "W=a1*ΔP+a2:a1"
        '
        'TB_a1
        '
        Me.TB_a1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_a1.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_a1.Location = New System.Drawing.Point(1104, 571)
        Me.TB_a1.Name = "TB_a1"
        Me.TB_a1.Size = New System.Drawing.Size(68, 27)
        Me.TB_a1.TabIndex = 211
        Me.TB_a1.Tag = "0.00"
        Me.TB_a1.Text = "9.99"
        Me.TB_a1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label56
        '
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(703, 597)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(400, 27)
        Me.Label56.TabIndex = 210
        Me.Label56.Text = "W=a1*ΔP+a2:a2"
        '
        'TB_a2
        '
        Me.TB_a2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_a2.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_a2.Location = New System.Drawing.Point(1104, 597)
        Me.TB_a2.Name = "TB_a2"
        Me.TB_a2.Size = New System.Drawing.Size(68, 27)
        Me.TB_a2.TabIndex = 211
        Me.TB_a2.Tag = "0.00"
        Me.TB_a2.Text = "9.99"
        Me.TB_a2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(685, 356)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(423, 48)
        Me.Label8.TabIndex = 155
        Me.Label8.Text = "Sn concentration lack correction calculation " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "                  parameter for ci" &
    "r. Tank"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(42, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(262, 25)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "Sludge Reduction mode"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1264, 986)
        Me.ShapeContainer1.TabIndex = 212
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Location = New System.Drawing.Point(24, 131)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(1180, 710)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(440, 511)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 21)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "Notice:a1≧a2"
        Me.Label10.Visible = False
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGrid1.Cols = 2
        Me.C1FlexGrid1.ColumnInfo = "2,1,0,0,0,145,Columns:"
        Me.C1FlexGrid1.ExplorerBar = C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExNone
        Me.C1FlexGrid1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold)
        Me.C1FlexGrid1.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.C1FlexGrid1.Location = New System.Drawing.Point(75, 447)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.NodeClosedPicture = Nothing
        Me.C1FlexGrid1.NodeOpenPicture = Nothing
        Me.C1FlexGrid1.OutlineCol = -1
        Me.C1FlexGrid1.Rows = 12
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid1.Size = New System.Drawing.Size(469, 312)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 213
        Me.C1FlexGrid1.TreeColor = System.Drawing.Color.DarkGray
        '
        'TB_FASET
        '
        Me.TB_FASET.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_FASET.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_FASET.Location = New System.Drawing.Point(476, 346)
        Me.TB_FASET.Name = "TB_FASET"
        Me.TB_FASET.Size = New System.Drawing.Size(68, 27)
        Me.TB_FASET.TabIndex = 215
        Me.TB_FASET.Tag = "0.0"
        Me.TB_FASET.Text = "9.9"
        Me.TB_FASET.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(75, 346)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(400, 27)
        Me.Label11.TabIndex = 214
        Me.Label11.Text = "Flow rate of outside(schedule only) :Faset(m3/min)"
        '
        'Frm07Prm_BAO
        '
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.TB_FASET)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TB_a2)
        Me.Controls.Add(Me.TB_a1)
        Me.Controls.Add(Me.TB_FBSET)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.TB_mu)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BTN_PARA_RELOAD)
        Me.Controls.Add(Me.LB_LOCK)
        Me.Controls.Add(Me.TB_CAL)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TB_TC4)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TB_CAdL)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.TB_TC3)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.TB_CAH)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.TB_TC2)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.TB_CAdH)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TB_TC1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TB_CSI)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PasswdBtn)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm07Prm_BAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "LETLスラッジ低減システム"
        Me.Controls.SetChildIndex(Me.ShapeContainer1, 0)
        Me.Controls.SetChildIndex(Me.PasswdBtn, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label53, 0)
        Me.Controls.SetChildIndex(Me.Label54, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TB_CSI, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.TB_TC1, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.TB_CAdH, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.TB_TC2, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.TB_CAH, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.TB_TC3, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.TB_CAdL, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.TB_TC4, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.TB_CAL, 0)
        Me.Controls.SetChildIndex(Me.LB_LOCK, 0)
        Me.Controls.SetChildIndex(Me.BTN_PARA_RELOAD, 0)
        Me.Controls.SetChildIndex(Me.ScrHdrLabel, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TB_mu, 0)
        Me.Controls.SetChildIndex(Me.Label52, 0)
        Me.Controls.SetChildIndex(Me.Label55, 0)
        Me.Controls.SetChildIndex(Me.Label56, 0)
        Me.Controls.SetChildIndex(Me.TB_FBSET, 0)
        Me.Controls.SetChildIndex(Me.TB_a1, 0)
        Me.Controls.SetChildIndex(Me.TB_a2, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid1, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.TB_FASET, 0)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PasswdBtn As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB_CSI As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TB_CAdH As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TB_TC1 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TB_CAH As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TB_TC2 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TB_CAL As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TB_TC4 As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TB_CAdL As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TB_TC3 As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents LB_LOCK As System.Windows.Forms.Label
    Friend WithEvents PasswordLockTimer As System.Windows.Forms.Timer
    Friend WithEvents BTN_PARA_RELOAD As System.Windows.Forms.Button
    Friend WithEvents TB_mu As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_FBSET As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents TB_a1 As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents TB_a2 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ShapeContainer1 As ShapeContainer
    Friend WithEvents RectangleShape1 As RectangleShape
    Friend WithEvents Label10 As Label
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
    Friend WithEvents TB_FASET As TextBox
    Friend WithEvents Label11 As Label
End Class
