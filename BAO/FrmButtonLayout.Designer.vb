<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmButton
    Inherits System.Windows.Forms.Form

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTN_ALM = New System.Windows.Forms.Button()
        Me.BTN_ALMHST = New System.Windows.Forms.Button()
        Me.BTN_IL = New System.Windows.Forms.Button()
        Me.BTN_PRM = New System.Windows.Forms.Button()
        Me.BTN_O2GRP = New System.Windows.Forms.Button()
        Me.BTN_DISGRP = New System.Windows.Forms.Button()
        Me.BTN_NO4GRP = New System.Windows.Forms.Button()
        Me.BTN_NO3GRP = New System.Windows.Forms.Button()
        Me.BTN_DIS = New System.Windows.Forms.Button()
        Me.BTN_NO4SCH = New System.Windows.Forms.Button()
        Me.BTN_NO3SCH = New System.Windows.Forms.Button()
        Me.BTN_OV = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_LS4 = New System.Windows.Forms.TextBox()
        Me.TB_LS3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_SRS_MODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_ALAM_MSG = New System.Windows.Forms.TextBox()
        Me.ScrHdrLabel = New System.Windows.Forms.Label()
        Me.LB_SYSTIME = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BTN_ALM)
        Me.Panel1.Controls.Add(Me.BTN_ALMHST)
        Me.Panel1.Controls.Add(Me.BTN_IL)
        Me.Panel1.Controls.Add(Me.BTN_PRM)
        Me.Panel1.Controls.Add(Me.BTN_O2GRP)
        Me.Panel1.Controls.Add(Me.BTN_DISGRP)
        Me.Panel1.Controls.Add(Me.BTN_NO4GRP)
        Me.Panel1.Controls.Add(Me.BTN_NO3GRP)
        Me.Panel1.Controls.Add(Me.BTN_DIS)
        Me.Panel1.Controls.Add(Me.BTN_NO4SCH)
        Me.Panel1.Controls.Add(Me.BTN_NO3SCH)
        Me.Panel1.Controls.Add(Me.BTN_OV)
        Me.Panel1.Location = New System.Drawing.Point(0, 880)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 64)
        Me.Panel1.TabIndex = 0
        '
        'BTN_ALM
        '
        Me.BTN_ALM.Dock = System.Windows.Forms.DockStyle.Right
        Me.BTN_ALM.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_ALM.Location = New System.Drawing.Point(1054, 0)
        Me.BTN_ALM.Name = "BTN_ALM"
        Me.BTN_ALM.Size = New System.Drawing.Size(105, 64)
        Me.BTN_ALM.TabIndex = 10
        Me.BTN_ALM.Text = "故障表示"
        Me.BTN_ALM.UseCompatibleTextRendering = True
        Me.BTN_ALM.UseVisualStyleBackColor = True
        '
        'BTN_ALMHST
        '
        Me.BTN_ALMHST.Dock = System.Windows.Forms.DockStyle.Right
        Me.BTN_ALMHST.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_ALMHST.Location = New System.Drawing.Point(1159, 0)
        Me.BTN_ALMHST.Name = "BTN_ALMHST"
        Me.BTN_ALMHST.Size = New System.Drawing.Size(105, 64)
        Me.BTN_ALMHST.TabIndex = 11
        Me.BTN_ALMHST.Text = "故障履歴"
        Me.BTN_ALMHST.UseCompatibleTextRendering = True
        Me.BTN_ALMHST.UseVisualStyleBackColor = True
        '
        'BTN_IL
        '
        Me.BTN_IL.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_IL.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_IL.Location = New System.Drawing.Point(945, 0)
        Me.BTN_IL.Name = "BTN_IL"
        Me.BTN_IL.Size = New System.Drawing.Size(105, 64)
        Me.BTN_IL.TabIndex = 9
        Me.BTN_IL.Text = "ｲﾝﾀｰﾛｯｸ"
        Me.BTN_IL.UseCompatibleTextRendering = True
        Me.BTN_IL.UseVisualStyleBackColor = True
        '
        'BTN_PRM
        '
        Me.BTN_PRM.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_PRM.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_PRM.Location = New System.Drawing.Point(840, 0)
        Me.BTN_PRM.Name = "BTN_PRM"
        Me.BTN_PRM.Size = New System.Drawing.Size(105, 64)
        Me.BTN_PRM.TabIndex = 8
        Me.BTN_PRM.Text = "ﾊﾟﾗﾒｰﾀ設定"
        Me.BTN_PRM.UseCompatibleTextRendering = True
        Me.BTN_PRM.UseVisualStyleBackColor = True
        '
        'BTN_O2GRP
        '
        Me.BTN_O2GRP.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_O2GRP.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_O2GRP.Location = New System.Drawing.Point(735, 0)
        Me.BTN_O2GRP.Name = "BTN_O2GRP"
        Me.BTN_O2GRP.Size = New System.Drawing.Size(105, 64)
        Me.BTN_O2GRP.TabIndex = 7
        Me.BTN_O2GRP.Text = "溶解実績　　　　　ﾄﾚﾝﾄﾞ"
        Me.BTN_O2GRP.UseCompatibleTextRendering = True
        Me.BTN_O2GRP.UseVisualStyleBackColor = True
        '
        'BTN_DISGRP
        '
        Me.BTN_DISGRP.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_DISGRP.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_DISGRP.Location = New System.Drawing.Point(630, 0)
        Me.BTN_DISGRP.Name = "BTN_DISGRP"
        Me.BTN_DISGRP.Size = New System.Drawing.Size(105, 64)
        Me.BTN_DISGRP.TabIndex = 6
        Me.BTN_DISGRP.Text = "合算     　  　     溶解ｸﾞﾗﾌ"
        Me.BTN_DISGRP.UseCompatibleTextRendering = True
        Me.BTN_DISGRP.UseVisualStyleBackColor = True
        '
        'BTN_NO4GRP
        '
        Me.BTN_NO4GRP.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_NO4GRP.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_NO4GRP.Location = New System.Drawing.Point(525, 0)
        Me.BTN_NO4GRP.Name = "BTN_NO4GRP"
        Me.BTN_NO4GRP.Size = New System.Drawing.Size(105, 64)
        Me.BTN_NO4GRP.TabIndex = 5
        Me.BTN_NO4GRP.Text = "No.4ETL            溶解ｸﾞﾗﾌ"
        Me.BTN_NO4GRP.UseCompatibleTextRendering = True
        Me.BTN_NO4GRP.UseVisualStyleBackColor = True
        '
        'BTN_NO3GRP
        '
        Me.BTN_NO3GRP.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_NO3GRP.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_NO3GRP.Location = New System.Drawing.Point(420, 0)
        Me.BTN_NO3GRP.Name = "BTN_NO3GRP"
        Me.BTN_NO3GRP.Size = New System.Drawing.Size(105, 64)
        Me.BTN_NO3GRP.TabIndex = 4
        Me.BTN_NO3GRP.Text = "No.3ETL            溶解ｸﾞﾗﾌ"
        Me.BTN_NO3GRP.UseCompatibleTextRendering = True
        Me.BTN_NO3GRP.UseVisualStyleBackColor = True
        '
        'BTN_DIS
        '
        Me.BTN_DIS.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_DIS.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_DIS.Location = New System.Drawing.Point(315, 0)
        Me.BTN_DIS.Name = "BTN_DIS"
        Me.BTN_DIS.Size = New System.Drawing.Size(105, 64)
        Me.BTN_DIS.TabIndex = 3
        Me.BTN_DIS.Text = "合算溶解　　　　　ｽｹｼﾞｭｰﾙ"
        Me.BTN_DIS.UseCompatibleTextRendering = True
        Me.BTN_DIS.UseVisualStyleBackColor = True
        '
        'BTN_NO4SCH
        '
        Me.BTN_NO4SCH.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_NO4SCH.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_NO4SCH.Location = New System.Drawing.Point(210, 0)
        Me.BTN_NO4SCH.Name = "BTN_NO4SCH"
        Me.BTN_NO4SCH.Size = New System.Drawing.Size(105, 64)
        Me.BTN_NO4SCH.TabIndex = 2
        Me.BTN_NO4SCH.Text = "No.4ETL            生産ｽｹｼﾞｭｰﾙ"
        Me.BTN_NO4SCH.UseCompatibleTextRendering = True
        Me.BTN_NO4SCH.UseVisualStyleBackColor = True
        '
        'BTN_NO3SCH
        '
        Me.BTN_NO3SCH.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_NO3SCH.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_NO3SCH.Location = New System.Drawing.Point(105, 0)
        Me.BTN_NO3SCH.Name = "BTN_NO3SCH"
        Me.BTN_NO3SCH.Size = New System.Drawing.Size(105, 64)
        Me.BTN_NO3SCH.TabIndex = 1
        Me.BTN_NO3SCH.Text = "No.3ETL            生産ｽｹｼﾞｭｰﾙ"
        Me.BTN_NO3SCH.UseCompatibleTextRendering = True
        Me.BTN_NO3SCH.UseVisualStyleBackColor = True
        '
        'BTN_OV
        '
        Me.BTN_OV.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_OV.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BTN_OV.Location = New System.Drawing.Point(0, 0)
        Me.BTN_OV.Name = "BTN_OV"
        Me.BTN_OV.Size = New System.Drawing.Size(105, 64)
        Me.BTN_OV.TabIndex = 0
        Me.BTN_OV.Tag = "1"
        Me.BTN_OV.Text = "総合監視"
        Me.BTN_OV.UseCompatibleTextRendering = True
        Me.BTN_OV.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TB_LS4)
        Me.Panel2.Controls.Add(Me.TB_LS3)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TB_SRS_MODE)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.TB_ALAM_MSG)
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1266, 53)
        Me.Panel2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(1198, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "mpm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(1198, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "mpm"
        '
        'TB_LS4
        '
        Me.TB_LS4.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_LS4.Location = New System.Drawing.Point(1132, 26)
        Me.TB_LS4.Name = "TB_LS4"
        Me.TB_LS4.Size = New System.Drawing.Size(60, 27)
        Me.TB_LS4.TabIndex = 4
        Me.TB_LS4.Tag = "##0"
        Me.TB_LS4.Text = "300"
        Me.TB_LS4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TB_LS3
        '
        Me.TB_LS3.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_LS3.Location = New System.Drawing.Point(1132, 0)
        Me.TB_LS3.Name = "TB_LS3"
        Me.TB_LS3.Size = New System.Drawing.Size(60, 27)
        Me.TB_LS3.TabIndex = 3
        Me.TB_LS3.Tag = "##0"
        Me.TB_LS3.Text = "300"
        Me.TB_LS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(1050, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "No.4 速度"
        '
        'TB_SRS_MODE
        '
        Me.TB_SRS_MODE.BackColor = System.Drawing.Color.Red
        Me.TB_SRS_MODE.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_SRS_MODE.ForeColor = System.Drawing.SystemColors.InfoText
        Me.TB_SRS_MODE.Location = New System.Drawing.Point(996, 11)
        Me.TB_SRS_MODE.Name = "TB_SRS_MODE"
        Me.TB_SRS_MODE.Size = New System.Drawing.Size(48, 30)
        Me.TB_SRS_MODE.TabIndex = 5
        Me.TB_SRS_MODE.Text = "ON"
        Me.TB_SRS_MODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(1050, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "No.3 速度"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(845, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "スラッジ低減モード"
        '
        'TB_ALAM_MSG
        '
        Me.TB_ALAM_MSG.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ALAM_MSG.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_ALAM_MSG.Location = New System.Drawing.Point(3, 11)
        Me.TB_ALAM_MSG.Name = "TB_ALAM_MSG"
        Me.TB_ALAM_MSG.ReadOnly = True
        Me.TB_ALAM_MSG.Size = New System.Drawing.Size(837, 30)
        Me.TB_ALAM_MSG.TabIndex = 2
        Me.TB_ALAM_MSG.Text = "2014/09/29 12:00:00:アラームメッセージボックス "
        '
        'ScrHdrLabel
        '
        Me.ScrHdrLabel.AutoSize = True
        Me.ScrHdrLabel.BackColor = System.Drawing.SystemColors.Control
        Me.ScrHdrLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrHdrLabel.Font = New System.Drawing.Font("メイリオ", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrHdrLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrHdrLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ScrHdrLabel.Location = New System.Drawing.Point(3, 57)
        Me.ScrHdrLabel.Name = "ScrHdrLabel"
        Me.ScrHdrLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrHdrLabel.Size = New System.Drawing.Size(35, 52)
        Me.ScrHdrLabel.TabIndex = 121
        Me.ScrHdrLabel.Text = " "
        '
        'LB_SYSTIME
        '
        Me.LB_SYSTIME.AutoSize = True
        Me.LB_SYSTIME.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LB_SYSTIME.Location = New System.Drawing.Point(1079, 953)
        Me.LB_SYSTIME.Name = "LB_SYSTIME"
        Me.LB_SYSTIME.Size = New System.Drawing.Size(173, 24)
        Me.LB_SYSTIME.TabIndex = 122
        Me.LB_SYSTIME.Tag = "yyyy/MM/dd HH:mm"
        Me.LB_SYSTIME.Text = "2014/10/01 13:26"
        '
        'FrmButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.LB_SYSTIME)
        Me.Controls.Add(Me.ScrHdrLabel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmButton"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ETLスラッジ低減システム"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BTN_NO4GRP As System.Windows.Forms.Button
    Friend WithEvents BTN_NO3GRP As System.Windows.Forms.Button
    Friend WithEvents BTN_DIS As System.Windows.Forms.Button
    Friend WithEvents BTN_NO4SCH As System.Windows.Forms.Button
    Friend WithEvents BTN_NO3SCH As System.Windows.Forms.Button
    Friend WithEvents BTN_OV As System.Windows.Forms.Button
    Friend WithEvents BTN_ALM As System.Windows.Forms.Button
    Friend WithEvents BTN_ALMHST As System.Windows.Forms.Button
    Friend WithEvents BTN_IL As System.Windows.Forms.Button
    Friend WithEvents BTN_PRM As System.Windows.Forms.Button
    Friend WithEvents BTN_O2GRP As System.Windows.Forms.Button
    Friend WithEvents BTN_DISGRP As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_LS4 As System.Windows.Forms.TextBox
    Friend WithEvents TB_LS3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_SRS_MODE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_ALAM_MSG As System.Windows.Forms.TextBox
    Public WithEvents ScrHdrLabel As System.Windows.Forms.Label
    Friend WithEvents LB_SYSTIME As System.Windows.Forms.Label

End Class
