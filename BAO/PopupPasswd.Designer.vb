<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopupPasswd
    Inherits ETL_SRS_STP.PopupGeneric

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
        Me.TB_PASSWORD = New System.Windows.Forms.TextBox()
        Me.BTN_PWCNG = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TB_PASSWORD
        '
        Me.TB_PASSWORD.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_PASSWORD.Location = New System.Drawing.Point(13, 115)
        Me.TB_PASSWORD.Name = "TB_PASSWORD"
        Me.TB_PASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TB_PASSWORD.Size = New System.Drawing.Size(221, 36)
        Me.TB_PASSWORD.TabIndex = 3
        '
        'BTN_PWCNG
        '
        Me.BTN_PWCNG.Location = New System.Drawing.Point(232, 115)
        Me.BTN_PWCNG.Name = "BTN_PWCNG"
        Me.BTN_PWCNG.Size = New System.Drawing.Size(44, 36)
        Me.BTN_PWCNG.TabIndex = 4
        Me.BTN_PWCNG.Text = "変更"
        Me.BTN_PWCNG.UseVisualStyleBackColor = True
        '
        'PopupPasswd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 243)
        Me.Controls.Add(Me.BTN_PWCNG)
        Me.Controls.Add(Me.TB_PASSWORD)
        Me.Name = "PopupPasswd"
        Me.Controls.SetChildIndex(Me.TB_PASSWORD, 0)
        Me.Controls.SetChildIndex(Me.BTN_PWCNG, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_PASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents BTN_PWCNG As System.Windows.Forms.Button
End Class
