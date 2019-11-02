<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PopupParamerter_BAO
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.TB_SLS_alpha = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_SLS_So = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSS = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(395, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Paramerter"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnClose
        '
        Me.BtnClose.Font = New System.Drawing.Font("メイリオ", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Black
        Me.BtnClose.Location = New System.Drawing.Point(278, 174)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(95, 59)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TB_SLS_alpha
        '
        Me.TB_SLS_alpha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_SLS_alpha.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_SLS_alpha.Location = New System.Drawing.Point(293, 68)
        Me.TB_SLS_alpha.Name = "TB_SLS_alpha"
        Me.TB_SLS_alpha.Size = New System.Drawing.Size(68, 27)
        Me.TB_SLS_alpha.TabIndex = 213
        Me.TB_SLS_alpha.Tag = "0.00"
        Me.TB_SLS_alpha.Text = "9.99"
        Me.TB_SLS_alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label55
        '
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(31, 68)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(261, 27)
        Me.Label55.TabIndex = 212
        Me.Label55.Text = "α: Adjust parameter"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(261, 27)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "So: Initial concentration"
        '
        'TB_SLS_So
        '
        Me.TB_SLS_So.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_SLS_So.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_SLS_So.Location = New System.Drawing.Point(292, 123)
        Me.TB_SLS_So.Name = "TB_SLS_So"
        Me.TB_SLS_So.Size = New System.Drawing.Size(68, 27)
        Me.TB_SLS_So.TabIndex = 213
        Me.TB_SLS_So.Tag = "#0.0"
        Me.TB_SLS_So.Text = "99.9"
        Me.TB_SLS_So.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(366, 126)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 16)
        Me.Label20.TabIndex = 214
        Me.Label20.Text = "g/L"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(367, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 214
        Me.Label3.Text = "－"
        '
        'BtnSS
        '
        Me.BtnSS.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSS.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.BtnSS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSS.Font = New System.Drawing.Font("メイリオ", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnSS.ForeColor = System.Drawing.SystemColors.Control
        Me.BtnSS.Location = New System.Drawing.Point(0, 246)
        Me.BtnSS.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnSS.Name = "BtnSS"
        Me.BtnSS.Size = New System.Drawing.Size(13, 14)
        Me.BtnSS.TabIndex = 1
        Me.BtnSS.Text = "Special" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Setting"
        Me.BtnSS.UseVisualStyleBackColor = False
        '
        'PopupParamerter_BAO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 260)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TB_SLS_So)
        Me.Controls.Add(Me.TB_SLS_alpha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSS)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(433, 298)
        Me.MinimumSize = New System.Drawing.Size(433, 298)
        Me.Name = "PopupParamerter_BAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Paramerter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TB_SLS_alpha As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_SLS_So As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnSS As Button
End Class
