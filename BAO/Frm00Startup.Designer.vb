<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm00Startup
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm00Startup))
        Me.Task1Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Task2Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Task3Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Task4Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Task5Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Task6Timer = New System.Windows.Forms.Timer(Me.components)
        Me.LB_TASK1 = New System.Windows.Forms.Label()
        Me.LB_TASK2 = New System.Windows.Forms.Label()
        Me.LB_TASK3 = New System.Windows.Forms.Label()
        Me.LB_TASK4 = New System.Windows.Forms.Label()
        Me.LB_TASK5 = New System.Windows.Forms.Label()
        Me.LB_TASK6 = New System.Windows.Forms.Label()
        Me.CB_DEBUG_NO3ONOFF = New System.Windows.Forms.CheckBox()
        Me.CB_DEBUG_NO4ONOFF = New System.Windows.Forms.CheckBox()
        Me.CB_DEBUG_AUTOCOIL = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NUM_BAISOKU = New System.Windows.Forms.NumericUpDown()
        Me.BT_LOTSHIFT4 = New System.Windows.Forms.Button()
        Me.BT_LOTSHIFT3 = New System.Windows.Forms.Button()
        Me.BT_CLEAR4 = New System.Windows.Forms.Button()
        Me.BT_COILCHANGE4 = New System.Windows.Forms.Button()
        Me.BT_SETLOT4 = New System.Windows.Forms.Button()
        Me.BT_CLEAR3 = New System.Windows.Forms.Button()
        Me.BT_COILCHANGE3 = New System.Windows.Forms.Button()
        Me.BT_SETLOT3 = New System.Windows.Forms.Button()
        Me.CB_DEBUG_FLAG = New System.Windows.Forms.CheckBox()
        Me.BlinkTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LB_TASK6_STATUS = New System.Windows.Forms.Label()
        Me.LB_TASK5_STATUS = New System.Windows.Forms.Label()
        Me.LB_TASK4_STATUS = New System.Windows.Forms.Label()
        Me.LB_TASK3_STATUS = New System.Windows.Forms.Label()
        Me.LB_TASK2_STATUS = New System.Windows.Forms.Label()
        Me.LB_TASK1_STATUS = New System.Windows.Forms.Label()
        Me.CB_CAPTURE_FLAG = New System.Windows.Forms.CheckBox()
        Me.CB_LOG_FLAG = New System.Windows.Forms.CheckBox()
        Me.BTN_HIDE = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout
        CType(Me.NUM_BAISOKU,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox2.SuspendLayout
        Me.SuspendLayout
        '
        'Task1Timer
        '
        Me.Task1Timer.Interval = 1000
        '
        'Task2Timer
        '
        Me.Task2Timer.Interval = 1000
        '
        'Task3Timer
        '
        Me.Task3Timer.Interval = 1000
        '
        'Task4Timer
        '
        Me.Task4Timer.Interval = 1000
        '
        'Task5Timer
        '
        Me.Task5Timer.Interval = 1000
        '
        'Task6Timer
        '
        Me.Task6Timer.Interval = 60000
        '
        'LB_TASK1
        '
        Me.LB_TASK1.BackColor = System.Drawing.Color.White
        Me.LB_TASK1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK1.Location = New System.Drawing.Point(12, 9)
        Me.LB_TASK1.Name = "LB_TASK1"
        Me.LB_TASK1.Size = New System.Drawing.Size(362, 22)
        Me.LB_TASK1.TabIndex = 0
        Me.LB_TASK1.Text = "SRS2PLC_20sec"
        '
        'LB_TASK2
        '
        Me.LB_TASK2.BackColor = System.Drawing.Color.White
        Me.LB_TASK2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK2.Location = New System.Drawing.Point(12, 31)
        Me.LB_TASK2.Name = "LB_TASK2"
        Me.LB_TASK2.Size = New System.Drawing.Size(362, 22)
        Me.LB_TASK2.TabIndex = 1
        Me.LB_TASK2.Text = "SLS_60sec"
        '
        'LB_TASK3
        '
        Me.LB_TASK3.BackColor = System.Drawing.Color.White
        Me.LB_TASK3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK3.Location = New System.Drawing.Point(12, 53)
        Me.LB_TASK3.Name = "LB_TASK3"
        Me.LB_TASK3.Size = New System.Drawing.Size(362, 22)
        Me.LB_TASK3.TabIndex = 2
        Me.LB_TASK3.Text = "Control_1sec"
        '
        'LB_TASK4
        '
        Me.LB_TASK4.BackColor = System.Drawing.Color.White
        Me.LB_TASK4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK4.Location = New System.Drawing.Point(12, 75)
        Me.LB_TASK4.Name = "LB_TASK4"
        Me.LB_TASK4.Size = New System.Drawing.Size(362, 22)
        Me.LB_TASK4.TabIndex = 3
        Me.LB_TASK4.Text = "PLC2SRS_20sec"
        '
        'LB_TASK5
        '
        Me.LB_TASK5.BackColor = System.Drawing.Color.White
        Me.LB_TASK5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK5.Location = New System.Drawing.Point(12, 97)
        Me.LB_TASK5.Name = "LB_TASK5"
        Me.LB_TASK5.Size = New System.Drawing.Size(362, 22)
        Me.LB_TASK5.TabIndex = 4
        Me.LB_TASK5.Text = "SRS2CS_01sec"
        '
        'LB_TASK6
        '
        Me.LB_TASK6.BackColor = System.Drawing.Color.White
        Me.LB_TASK6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK6.Location = New System.Drawing.Point(12, 119)
        Me.LB_TASK6.Name = "LB_TASK6"
        Me.LB_TASK6.Size = New System.Drawing.Size(362, 22)
        Me.LB_TASK6.TabIndex = 5
        Me.LB_TASK6.Text = "DataStrage_60sec"
        '
        'CB_DEBUG_NO3ONOFF
        '
        Me.CB_DEBUG_NO3ONOFF.AutoSize = True
        Me.CB_DEBUG_NO3ONOFF.Checked = True
        Me.CB_DEBUG_NO3ONOFF.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.CB_DEBUG_NO3ONOFF.Location = New System.Drawing.Point(16, 21)
        Me.CB_DEBUG_NO3ONOFF.Name = "CB_DEBUG_NO3ONOFF"
        Me.CB_DEBUG_NO3ONOFF.Size = New System.Drawing.Size(124, 16)
        Me.CB_DEBUG_NO3ONOFF.TabIndex = 6
        Me.CB_DEBUG_NO3ONOFF.Text = "No3ライン運転/停止"
        Me.CB_DEBUG_NO3ONOFF.UseVisualStyleBackColor = True
        '
        'CB_DEBUG_NO4ONOFF
        '
        Me.CB_DEBUG_NO4ONOFF.AutoSize = True
        Me.CB_DEBUG_NO4ONOFF.Checked = True
        Me.CB_DEBUG_NO4ONOFF.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.CB_DEBUG_NO4ONOFF.Location = New System.Drawing.Point(16, 43)
        Me.CB_DEBUG_NO4ONOFF.Name = "CB_DEBUG_NO4ONOFF"
        Me.CB_DEBUG_NO4ONOFF.Size = New System.Drawing.Size(124, 16)
        Me.CB_DEBUG_NO4ONOFF.TabIndex = 7
        Me.CB_DEBUG_NO4ONOFF.Text = "No4ライン運転/停止"
        Me.CB_DEBUG_NO4ONOFF.UseVisualStyleBackColor = True
        '
        'CB_DEBUG_AUTOCOIL
        '
        Me.CB_DEBUG_AUTOCOIL.AutoSize = True
        Me.CB_DEBUG_AUTOCOIL.Checked = True
        Me.CB_DEBUG_AUTOCOIL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_DEBUG_AUTOCOIL.Location = New System.Drawing.Point(16, 65)
        Me.CB_DEBUG_AUTOCOIL.Name = "CB_DEBUG_AUTOCOIL"
        Me.CB_DEBUG_AUTOCOIL.Size = New System.Drawing.Size(110, 16)
        Me.CB_DEBUG_AUTOCOIL.TabIndex = 8
        Me.CB_DEBUG_AUTOCOIL.Text = "自動コイルチェンジ"
        Me.CB_DEBUG_AUTOCOIL.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NUM_BAISOKU)
        Me.GroupBox1.Controls.Add(Me.BT_LOTSHIFT4)
        Me.GroupBox1.Controls.Add(Me.BT_LOTSHIFT3)
        Me.GroupBox1.Controls.Add(Me.BT_CLEAR4)
        Me.GroupBox1.Controls.Add(Me.BT_COILCHANGE4)
        Me.GroupBox1.Controls.Add(Me.BT_SETLOT4)
        Me.GroupBox1.Controls.Add(Me.BT_CLEAR3)
        Me.GroupBox1.Controls.Add(Me.BT_COILCHANGE3)
        Me.GroupBox1.Controls.Add(Me.BT_SETLOT3)
        Me.GroupBox1.Controls.Add(Me.CB_DEBUG_NO4ONOFF)
        Me.GroupBox1.Controls.Add(Me.CB_DEBUG_AUTOCOIL)
        Me.GroupBox1.Controls.Add(Me.CB_DEBUG_NO3ONOFF)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 178)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 90)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "デバッグ機能"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "倍速"
        '
        'NUM_BAISOKU
        '
        Me.NUM_BAISOKU.Location = New System.Drawing.Point(152, 62)
        Me.NUM_BAISOKU.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUM_BAISOKU.Name = "NUM_BAISOKU"
        Me.NUM_BAISOKU.Size = New System.Drawing.Size(61, 19)
        Me.NUM_BAISOKU.TabIndex = 15
        Me.NUM_BAISOKU.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BT_LOTSHIFT4
        '
        Me.BT_LOTSHIFT4.Location = New System.Drawing.Point(197, 41)
        Me.BT_LOTSHIFT4.Name = "BT_LOTSHIFT4"
        Me.BT_LOTSHIFT4.Size = New System.Drawing.Size(39, 18)
        Me.BT_LOTSHIFT4.TabIndex = 16
        Me.BT_LOTSHIFT4.Text = "Shift"
        Me.BT_LOTSHIFT4.UseVisualStyleBackColor = True
        '
        'BT_LOTSHIFT3
        '
        Me.BT_LOTSHIFT3.Location = New System.Drawing.Point(197, 18)
        Me.BT_LOTSHIFT3.Name = "BT_LOTSHIFT3"
        Me.BT_LOTSHIFT3.Size = New System.Drawing.Size(39, 18)
        Me.BT_LOTSHIFT3.TabIndex = 15
        Me.BT_LOTSHIFT3.Text = "Shift"
        Me.BT_LOTSHIFT3.UseVisualStyleBackColor = True
        '
        'BT_CLEAR4
        '
        Me.BT_CLEAR4.Location = New System.Drawing.Point(289, 41)
        Me.BT_CLEAR4.Name = "BT_CLEAR4"
        Me.BT_CLEAR4.Size = New System.Drawing.Size(53, 18)
        Me.BT_CLEAR4.TabIndex = 14
        Me.BT_CLEAR4.Text = "CLR"
        Me.BT_CLEAR4.UseVisualStyleBackColor = True
        '
        'BT_COILCHANGE4
        '
        Me.BT_COILCHANGE4.Location = New System.Drawing.Point(242, 41)
        Me.BT_COILCHANGE4.Name = "BT_COILCHANGE4"
        Me.BT_COILCHANGE4.Size = New System.Drawing.Size(39, 18)
        Me.BT_COILCHANGE4.TabIndex = 13
        Me.BT_COILCHANGE4.Text = "CoilChange"
        Me.BT_COILCHANGE4.UseVisualStyleBackColor = True
        '
        'BT_SETLOT4
        '
        Me.BT_SETLOT4.Location = New System.Drawing.Point(152, 41)
        Me.BT_SETLOT4.Name = "BT_SETLOT4"
        Me.BT_SETLOT4.Size = New System.Drawing.Size(39, 18)
        Me.BT_SETLOT4.TabIndex = 12
        Me.BT_SETLOT4.Text = "SetLot"
        Me.BT_SETLOT4.UseVisualStyleBackColor = True
        '
        'BT_CLEAR3
        '
        Me.BT_CLEAR3.Location = New System.Drawing.Point(289, 18)
        Me.BT_CLEAR3.Name = "BT_CLEAR3"
        Me.BT_CLEAR3.Size = New System.Drawing.Size(53, 18)
        Me.BT_CLEAR3.TabIndex = 11
        Me.BT_CLEAR3.Text = "CLR"
        Me.BT_CLEAR3.UseVisualStyleBackColor = True
        '
        'BT_COILCHANGE3
        '
        Me.BT_COILCHANGE3.Location = New System.Drawing.Point(242, 18)
        Me.BT_COILCHANGE3.Name = "BT_COILCHANGE3"
        Me.BT_COILCHANGE3.Size = New System.Drawing.Size(39, 18)
        Me.BT_COILCHANGE3.TabIndex = 10
        Me.BT_COILCHANGE3.Text = "CoilChange"
        Me.BT_COILCHANGE3.UseVisualStyleBackColor = True
        '
        'BT_SETLOT3
        '
        Me.BT_SETLOT3.Location = New System.Drawing.Point(152, 18)
        Me.BT_SETLOT3.Name = "BT_SETLOT3"
        Me.BT_SETLOT3.Size = New System.Drawing.Size(39, 18)
        Me.BT_SETLOT3.TabIndex = 9
        Me.BT_SETLOT3.Text = "SetLot"
        Me.BT_SETLOT3.UseVisualStyleBackColor = True
        '
        'CB_DEBUG_FLAG
        '
        Me.CB_DEBUG_FLAG.AutoSize = True
        Me.CB_DEBUG_FLAG.Location = New System.Drawing.Point(16, 151)
        Me.CB_DEBUG_FLAG.Name = "CB_DEBUG_FLAG"
        Me.CB_DEBUG_FLAG.Size = New System.Drawing.Size(60, 16)
        Me.CB_DEBUG_FLAG.TabIndex = 10
        Me.CB_DEBUG_FLAG.Text = "デバッグ"
        Me.CB_DEBUG_FLAG.UseVisualStyleBackColor = True
        '
        'BlinkTimer
        '
        Me.BlinkTimer.Interval = 2000
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LB_TASK6_STATUS)
        Me.GroupBox2.Controls.Add(Me.LB_TASK5_STATUS)
        Me.GroupBox2.Controls.Add(Me.LB_TASK4_STATUS)
        Me.GroupBox2.Controls.Add(Me.LB_TASK3_STATUS)
        Me.GroupBox2.Controls.Add(Me.LB_TASK2_STATUS)
        Me.GroupBox2.Controls.Add(Me.LB_TASK1_STATUS)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 279)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(357, 157)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "STATUS"
        '
        'LB_TASK6_STATUS
        '
        Me.LB_TASK6_STATUS.BackColor = System.Drawing.Color.White
        Me.LB_TASK6_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK6_STATUS.Location = New System.Drawing.Point(4, 126)
        Me.LB_TASK6_STATUS.Name = "LB_TASK6_STATUS"
        Me.LB_TASK6_STATUS.Size = New System.Drawing.Size(350, 22)
        Me.LB_TASK6_STATUS.TabIndex = 11
        Me.LB_TASK6_STATUS.Text = "DataStrage_60sec"
        '
        'LB_TASK5_STATUS
        '
        Me.LB_TASK5_STATUS.BackColor = System.Drawing.Color.White
        Me.LB_TASK5_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK5_STATUS.Location = New System.Drawing.Point(4, 104)
        Me.LB_TASK5_STATUS.Name = "LB_TASK5_STATUS"
        Me.LB_TASK5_STATUS.Size = New System.Drawing.Size(350, 22)
        Me.LB_TASK5_STATUS.TabIndex = 10
        Me.LB_TASK5_STATUS.Text = "SRS2CS_01sec"
        '
        'LB_TASK4_STATUS
        '
        Me.LB_TASK4_STATUS.BackColor = System.Drawing.Color.White
        Me.LB_TASK4_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK4_STATUS.Location = New System.Drawing.Point(4, 82)
        Me.LB_TASK4_STATUS.Name = "LB_TASK4_STATUS"
        Me.LB_TASK4_STATUS.Size = New System.Drawing.Size(350, 22)
        Me.LB_TASK4_STATUS.TabIndex = 9
        Me.LB_TASK4_STATUS.Text = "PLC2SRS_20sec"
        '
        'LB_TASK3_STATUS
        '
        Me.LB_TASK3_STATUS.BackColor = System.Drawing.Color.White
        Me.LB_TASK3_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK3_STATUS.Location = New System.Drawing.Point(4, 60)
        Me.LB_TASK3_STATUS.Name = "LB_TASK3_STATUS"
        Me.LB_TASK3_STATUS.Size = New System.Drawing.Size(350, 22)
        Me.LB_TASK3_STATUS.TabIndex = 8
        Me.LB_TASK3_STATUS.Text = "Control_1sec"
        '
        'LB_TASK2_STATUS
        '
        Me.LB_TASK2_STATUS.BackColor = System.Drawing.Color.White
        Me.LB_TASK2_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK2_STATUS.Location = New System.Drawing.Point(4, 38)
        Me.LB_TASK2_STATUS.Name = "LB_TASK2_STATUS"
        Me.LB_TASK2_STATUS.Size = New System.Drawing.Size(350, 22)
        Me.LB_TASK2_STATUS.TabIndex = 7
        Me.LB_TASK2_STATUS.Text = "SLS_60sec"
        '
        'LB_TASK1_STATUS
        '
        Me.LB_TASK1_STATUS.BackColor = System.Drawing.Color.White
        Me.LB_TASK1_STATUS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_TASK1_STATUS.Location = New System.Drawing.Point(4, 16)
        Me.LB_TASK1_STATUS.Name = "LB_TASK1_STATUS"
        Me.LB_TASK1_STATUS.Size = New System.Drawing.Size(350, 22)
        Me.LB_TASK1_STATUS.TabIndex = 6
        Me.LB_TASK1_STATUS.Text = "SRS2PLC_20sec"
        '
        'CB_CAPTURE_FLAG
        '
        Me.CB_CAPTURE_FLAG.AutoSize = true
        Me.CB_CAPTURE_FLAG.Location = New System.Drawing.Point(82, 151)
        Me.CB_CAPTURE_FLAG.Name = "CB_CAPTURE_FLAG"
        Me.CB_CAPTURE_FLAG.Size = New System.Drawing.Size(68, 16)
        Me.CB_CAPTURE_FLAG.TabIndex = 12
        Me.CB_CAPTURE_FLAG.Text = "キャプチャ"
        Me.CB_CAPTURE_FLAG.UseVisualStyleBackColor = true
        '
        'CB_LOG_FLAG
        '
        Me.CB_LOG_FLAG.AutoSize = true
        Me.CB_LOG_FLAG.Location = New System.Drawing.Point(156, 151)
        Me.CB_LOG_FLAG.Name = "CB_LOG_FLAG"
        Me.CB_LOG_FLAG.Size = New System.Drawing.Size(42, 16)
        Me.CB_LOG_FLAG.TabIndex = 13
        Me.CB_LOG_FLAG.Text = "ログ"
        Me.CB_LOG_FLAG.UseVisualStyleBackColor = true
        '
        'BTN_HIDE
        '
        Me.BTN_HIDE.Location = New System.Drawing.Point(317, 148)
        Me.BTN_HIDE.Name = "BTN_HIDE"
        Me.BTN_HIDE.Size = New System.Drawing.Size(53, 24)
        Me.BTN_HIDE.TabIndex = 14
        Me.BTN_HIDE.Text = "Hide"
        Me.BTN_HIDE.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(244, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 24)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "キャプチャ"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Frm00Startup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 445)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTN_HIDE)
        Me.Controls.Add(Me.CB_LOG_FLAG)
        Me.Controls.Add(Me.CB_CAPTURE_FLAG)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CB_DEBUG_FLAG)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LB_TASK6)
        Me.Controls.Add(Me.LB_TASK5)
        Me.Controls.Add(Me.LB_TASK4)
        Me.Controls.Add(Me.LB_TASK3)
        Me.Controls.Add(Me.LB_TASK2)
        Me.Controls.Add(Me.LB_TASK1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Frm00Startup"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "ETL_SRS_CONNECTION_STATUS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.NUM_BAISOKU,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox2.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Task1Timer As System.Windows.Forms.Timer
    Friend WithEvents Task2Timer As System.Windows.Forms.Timer
    Friend WithEvents Task3Timer As System.Windows.Forms.Timer
    Friend WithEvents Task4Timer As System.Windows.Forms.Timer
    Friend WithEvents Task5Timer As System.Windows.Forms.Timer
    Friend WithEvents Task6Timer As System.Windows.Forms.Timer
    Friend WithEvents LB_TASK1 As System.Windows.Forms.Label
    Friend WithEvents LB_TASK2 As System.Windows.Forms.Label
    Friend WithEvents LB_TASK3 As System.Windows.Forms.Label
    Friend WithEvents LB_TASK4 As System.Windows.Forms.Label
    Friend WithEvents LB_TASK5 As System.Windows.Forms.Label
    Friend WithEvents LB_TASK6 As System.Windows.Forms.Label
    Friend WithEvents CB_DEBUG_NO3ONOFF As System.Windows.Forms.CheckBox
    Friend WithEvents CB_DEBUG_NO4ONOFF As System.Windows.Forms.CheckBox
    Friend WithEvents CB_DEBUG_AUTOCOIL As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CB_DEBUG_FLAG As System.Windows.Forms.CheckBox
    Friend WithEvents BlinkTimer As System.Windows.Forms.Timer
    Friend WithEvents BT_CLEAR4 As System.Windows.Forms.Button
    Friend WithEvents BT_COILCHANGE4 As System.Windows.Forms.Button
    Friend WithEvents BT_SETLOT4 As System.Windows.Forms.Button
    Friend WithEvents BT_CLEAR3 As System.Windows.Forms.Button
    Friend WithEvents BT_COILCHANGE3 As System.Windows.Forms.Button
    Friend WithEvents BT_SETLOT3 As System.Windows.Forms.Button
    Friend WithEvents BT_LOTSHIFT4 As System.Windows.Forms.Button
    Friend WithEvents BT_LOTSHIFT3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LB_TASK6_STATUS As System.Windows.Forms.Label
    Friend WithEvents LB_TASK5_STATUS As System.Windows.Forms.Label
    Friend WithEvents LB_TASK4_STATUS As System.Windows.Forms.Label
    Friend WithEvents LB_TASK3_STATUS As System.Windows.Forms.Label
    Friend WithEvents LB_TASK2_STATUS As System.Windows.Forms.Label
    Friend WithEvents LB_TASK1_STATUS As System.Windows.Forms.Label
    Friend WithEvents CB_CAPTURE_FLAG As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NUM_BAISOKU As System.Windows.Forms.NumericUpDown
    Friend WithEvents CB_LOG_FLAG As System.Windows.Forms.CheckBox
    Friend WithEvents BTN_HIDE As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
