<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmButton_BAO
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
        Me.BTN_CONC = New System.Windows.Forms.Button()
        Me.BTN_ALMHST = New System.Windows.Forms.Button()
        Me.BTN_ALM = New System.Windows.Forms.Button()
        Me.BTN_IL = New System.Windows.Forms.Button()
        Me.BTN_PRM = New System.Windows.Forms.Button()
        Me.BTN_O2TREND = New System.Windows.Forms.Button()
        Me.BTN_O2GRP = New System.Windows.Forms.Button()
        Me.BTN_DISGRP = New System.Windows.Forms.Button()
        Me.BTN_DISSCH = New System.Windows.Forms.Button()
        Me.BTN_PRODSCH = New System.Windows.Forms.Button()
        Me.BTN_OV = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TB_TIC_MODE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_LS3 = New System.Windows.Forms.TextBox()
        Me.TB_SRS_MODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_ALAM_MSG = New System.Windows.Forms.TextBox()
        Me.ScrHdrLabel = New System.Windows.Forms.Label()
        Me.LB_SYSTIME = New System.Windows.Forms.Label()
        Me.PB_NSENGI_LOGO = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PB_NSENGI_LOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BTN_CONC)
        Me.Panel1.Controls.Add(Me.BTN_ALMHST)
        Me.Panel1.Controls.Add(Me.BTN_ALM)
        Me.Panel1.Controls.Add(Me.BTN_IL)
        Me.Panel1.Controls.Add(Me.BTN_PRM)
        Me.Panel1.Controls.Add(Me.BTN_O2TREND)
        Me.Panel1.Controls.Add(Me.BTN_O2GRP)
        Me.Panel1.Controls.Add(Me.BTN_DISGRP)
        Me.Panel1.Controls.Add(Me.BTN_DISSCH)
        Me.Panel1.Controls.Add(Me.BTN_PRODSCH)
        Me.Panel1.Controls.Add(Me.BTN_OV)
        Me.Panel1.Location = New System.Drawing.Point(0, 877)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 69)
        Me.Panel1.TabIndex = 0
        '
        'BTN_CONC
        '
        Me.BTN_CONC.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_CONC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CONC.Location = New System.Drawing.Point(1140, 0)
        Me.BTN_CONC.Name = "BTN_CONC"
        Me.BTN_CONC.Size = New System.Drawing.Size(114, 69)
        Me.BTN_CONC.TabIndex = 13
        Me.BTN_CONC.Text = "Conc."
        Me.BTN_CONC.UseCompatibleTextRendering = True
        Me.BTN_CONC.UseVisualStyleBackColor = True
        '
        'BTN_ALMHST
        '
        Me.BTN_ALMHST.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_ALMHST.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ALMHST.Location = New System.Drawing.Point(1026, 0)
        Me.BTN_ALMHST.Name = "BTN_ALMHST"
        Me.BTN_ALMHST.Size = New System.Drawing.Size(114, 69)
        Me.BTN_ALMHST.TabIndex = 12
        Me.BTN_ALMHST.Text = "Alam " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Record"
        Me.BTN_ALMHST.UseCompatibleTextRendering = True
        Me.BTN_ALMHST.UseVisualStyleBackColor = True
        '
        'BTN_ALM
        '
        Me.BTN_ALM.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_ALM.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ALM.Location = New System.Drawing.Point(912, 0)
        Me.BTN_ALM.Name = "BTN_ALM"
        Me.BTN_ALM.Size = New System.Drawing.Size(114, 69)
        Me.BTN_ALM.TabIndex = 10
        Me.BTN_ALM.Text = "Alam"
        Me.BTN_ALM.UseCompatibleTextRendering = True
        Me.BTN_ALM.UseVisualStyleBackColor = True
        '
        'BTN_IL
        '
        Me.BTN_IL.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_IL.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_IL.Location = New System.Drawing.Point(798, 0)
        Me.BTN_IL.Name = "BTN_IL"
        Me.BTN_IL.Size = New System.Drawing.Size(114, 69)
        Me.BTN_IL.TabIndex = 9
        Me.BTN_IL.Text = "Interlock"
        Me.BTN_IL.UseCompatibleTextRendering = True
        Me.BTN_IL.UseVisualStyleBackColor = True
        '
        'BTN_PRM
        '
        Me.BTN_PRM.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_PRM.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_PRM.Location = New System.Drawing.Point(684, 0)
        Me.BTN_PRM.Name = "BTN_PRM"
        Me.BTN_PRM.Size = New System.Drawing.Size(114, 69)
        Me.BTN_PRM.TabIndex = 8
        Me.BTN_PRM.Text = "Parameter"
        Me.BTN_PRM.UseCompatibleTextRendering = True
        Me.BTN_PRM.UseVisualStyleBackColor = True
        '
        'BTN_O2TREND
        '
        Me.BTN_O2TREND.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_O2TREND.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_O2TREND.Location = New System.Drawing.Point(570, 0)
        Me.BTN_O2TREND.Name = "BTN_O2TREND"
        Me.BTN_O2TREND.Size = New System.Drawing.Size(114, 69)
        Me.BTN_O2TREND.TabIndex = 7
        Me.BTN_O2TREND.Text = "O2 Flow Trend"
        Me.BTN_O2TREND.UseCompatibleTextRendering = True
        Me.BTN_O2TREND.UseVisualStyleBackColor = True
        '
        'BTN_O2GRP
        '
        Me.BTN_O2GRP.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_O2GRP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_O2GRP.Location = New System.Drawing.Point(456, 0)
        Me.BTN_O2GRP.Name = "BTN_O2GRP"
        Me.BTN_O2GRP.Size = New System.Drawing.Size(114, 69)
        Me.BTN_O2GRP.TabIndex = 6
        Me.BTN_O2GRP.Text = "O2 Flow Graph"
        Me.BTN_O2GRP.UseCompatibleTextRendering = True
        Me.BTN_O2GRP.UseVisualStyleBackColor = True
        '
        'BTN_DISGRP
        '
        Me.BTN_DISGRP.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_DISGRP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DISGRP.Location = New System.Drawing.Point(342, 0)
        Me.BTN_DISGRP.Name = "BTN_DISGRP"
        Me.BTN_DISGRP.Size = New System.Drawing.Size(114, 69)
        Me.BTN_DISGRP.TabIndex = 4
        Me.BTN_DISGRP.Text = "Dissolution Graph"
        Me.BTN_DISGRP.UseCompatibleTextRendering = True
        Me.BTN_DISGRP.UseVisualStyleBackColor = True
        '
        'BTN_DISSCH
        '
        Me.BTN_DISSCH.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_DISSCH.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DISSCH.Location = New System.Drawing.Point(228, 0)
        Me.BTN_DISSCH.Name = "BTN_DISSCH"
        Me.BTN_DISSCH.Size = New System.Drawing.Size(114, 69)
        Me.BTN_DISSCH.TabIndex = 3
        Me.BTN_DISSCH.Text = "Dissolution Schdule"
        Me.BTN_DISSCH.UseCompatibleTextRendering = True
        Me.BTN_DISSCH.UseVisualStyleBackColor = True
        '
        'BTN_PRODSCH
        '
        Me.BTN_PRODSCH.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_PRODSCH.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_PRODSCH.Location = New System.Drawing.Point(114, 0)
        Me.BTN_PRODSCH.Name = "BTN_PRODSCH"
        Me.BTN_PRODSCH.Size = New System.Drawing.Size(114, 69)
        Me.BTN_PRODSCH.TabIndex = 1
        Me.BTN_PRODSCH.Text = "Product Schdule"
        Me.BTN_PRODSCH.UseCompatibleTextRendering = True
        Me.BTN_PRODSCH.UseVisualStyleBackColor = True
        '
        'BTN_OV
        '
        Me.BTN_OV.Dock = System.Windows.Forms.DockStyle.Left
        Me.BTN_OV.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_OV.Location = New System.Drawing.Point(0, 0)
        Me.BTN_OV.Name = "BTN_OV"
        Me.BTN_OV.Size = New System.Drawing.Size(114, 69)
        Me.BTN_OV.TabIndex = 0
        Me.BTN_OV.Tag = "1"
        Me.BTN_OV.Text = "Overview"
        Me.BTN_OV.UseCompatibleTextRendering = True
        Me.BTN_OV.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TB_TIC_MODE)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TB_LS3)
        Me.Panel2.Controls.Add(Me.TB_SRS_MODE)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.TB_ALAM_MSG)
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1266, 65)
        Me.Panel2.TabIndex = 2
        '
        'TB_TIC_MODE
        '
        Me.TB_TIC_MODE.BackColor = System.Drawing.Color.Red
        Me.TB_TIC_MODE.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_TIC_MODE.ForeColor = System.Drawing.SystemColors.InfoText
        Me.TB_TIC_MODE.Location = New System.Drawing.Point(996, 33)
        Me.TB_TIC_MODE.Name = "TB_TIC_MODE"
        Me.TB_TIC_MODE.Size = New System.Drawing.Size(48, 25)
        Me.TB_TIC_MODE.TabIndex = 124
        Me.TB_TIC_MODE.Text = "ON"
        Me.TB_TIC_MODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(789, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 18)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Tin Ion Control"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1198, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "mpm"
        '
        'TB_LS3
        '
        Me.TB_LS3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_LS3.Location = New System.Drawing.Point(1151, 4)
        Me.TB_LS3.Name = "TB_LS3"
        Me.TB_LS3.Size = New System.Drawing.Size(49, 25)
        Me.TB_LS3.TabIndex = 3
        Me.TB_LS3.Tag = "##0"
        Me.TB_LS3.Text = "300"
        Me.TB_LS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TB_SRS_MODE
        '
        Me.TB_SRS_MODE.BackColor = System.Drawing.Color.Red
        Me.TB_SRS_MODE.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_SRS_MODE.ForeColor = System.Drawing.SystemColors.InfoText
        Me.TB_SRS_MODE.Location = New System.Drawing.Point(996, 4)
        Me.TB_SRS_MODE.Name = "TB_SRS_MODE"
        Me.TB_SRS_MODE.Size = New System.Drawing.Size(48, 25)
        Me.TB_SRS_MODE.TabIndex = 5
        Me.TB_SRS_MODE.Text = "ON"
        Me.TB_SRS_MODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1050, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Line Speed"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(789, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sludge Reduction Control"
        '
        'TB_ALAM_MSG
        '
        Me.TB_ALAM_MSG.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ALAM_MSG.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB_ALAM_MSG.Location = New System.Drawing.Point(3, 16)
        Me.TB_ALAM_MSG.Name = "TB_ALAM_MSG"
        Me.TB_ALAM_MSG.ReadOnly = True
        Me.TB_ALAM_MSG.Size = New System.Drawing.Size(780, 25)
        Me.TB_ALAM_MSG.TabIndex = 2
        Me.TB_ALAM_MSG.Text = "2017/09/12 12:00:00:ALAM MESSAGE BOX "
        '
        'ScrHdrLabel
        '
        Me.ScrHdrLabel.AutoSize = True
        Me.ScrHdrLabel.BackColor = System.Drawing.SystemColors.Control
        Me.ScrHdrLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ScrHdrLabel.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrHdrLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ScrHdrLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ScrHdrLabel.Location = New System.Drawing.Point(3, 69)
        Me.ScrHdrLabel.Name = "ScrHdrLabel"
        Me.ScrHdrLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ScrHdrLabel.Size = New System.Drawing.Size(28, 41)
        Me.ScrHdrLabel.TabIndex = 121
        Me.ScrHdrLabel.Text = " "
        '
        'LB_SYSTIME
        '
        Me.LB_SYSTIME.AutoSize = True
        Me.LB_SYSTIME.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_SYSTIME.Location = New System.Drawing.Point(1125, 955)
        Me.LB_SYSTIME.Name = "LB_SYSTIME"
        Me.LB_SYSTIME.Size = New System.Drawing.Size(135, 19)
        Me.LB_SYSTIME.TabIndex = 122
        Me.LB_SYSTIME.Tag = "yyyy/MM/dd HH:mm"
        Me.LB_SYSTIME.Text = "2017/09/13 13:26"
        '
        'PB_NSENGI_LOGO
        '
        Me.PB_NSENGI_LOGO.Image = Global.ETL_SRS_BAO.My.Resources.Resources.NSENGI_LOGO
        Me.PB_NSENGI_LOGO.Location = New System.Drawing.Point(437, 952)
        Me.PB_NSENGI_LOGO.Name = "PB_NSENGI_LOGO"
        Me.PB_NSENGI_LOGO.Size = New System.Drawing.Size(390, 22)
        Me.PB_NSENGI_LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_NSENGI_LOGO.TabIndex = 123
        Me.PB_NSENGI_LOGO.TabStop = False
        '
        'FrmButton_BAO
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.PB_NSENGI_LOGO)
        Me.Controls.Add(Me.LB_SYSTIME)
        Me.Controls.Add(Me.ScrHdrLabel)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmButton_BAO"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "(ETL Tin Ion Control System)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PB_NSENGI_LOGO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BTN_DISGRP As System.Windows.Forms.Button
    Friend WithEvents BTN_DISSCH As System.Windows.Forms.Button
    Friend WithEvents BTN_PRODSCH As System.Windows.Forms.Button
    Friend WithEvents BTN_OV As System.Windows.Forms.Button
    Friend WithEvents BTN_ALM As System.Windows.Forms.Button
    Friend WithEvents BTN_IL As System.Windows.Forms.Button
    Friend WithEvents BTN_PRM As System.Windows.Forms.Button
    Friend WithEvents BTN_O2TREND As System.Windows.Forms.Button
    Friend WithEvents BTN_O2GRP As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_LS3 As System.Windows.Forms.TextBox
    Friend WithEvents TB_SRS_MODE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_ALAM_MSG As System.Windows.Forms.TextBox
    Public WithEvents ScrHdrLabel As System.Windows.Forms.Label
    Friend WithEvents LB_SYSTIME As System.Windows.Forms.Label
    Friend WithEvents TB_TIC_MODE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BTN_ALMHST As Button
    Friend WithEvents PB_NSENGI_LOGO As PictureBox
    Friend WithEvents BTN_CONC As Button
End Class
