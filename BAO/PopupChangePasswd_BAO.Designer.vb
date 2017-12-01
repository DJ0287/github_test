<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PopupChangePasswd_BAO
    Inherits ETL_SRS_BAO.PopupGeneric_BAO

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
        Me.TB_PASSWORD_NEW = New System.Windows.Forms.TextBox()
        Me.TB_PASSWORD_NEW_RE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TB_PASSWORD_NEW
        '
        Me.TB_PASSWORD_NEW.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_PASSWORD_NEW.Location = New System.Drawing.Point(139, 47)
        Me.TB_PASSWORD_NEW.Name = "TB_PASSWORD_NEW"
        Me.TB_PASSWORD_NEW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TB_PASSWORD_NEW.Size = New System.Drawing.Size(169, 36)
        Me.TB_PASSWORD_NEW.TabIndex = 4
        '
        'TB_PASSWORD_NEW_RE
        '
        Me.TB_PASSWORD_NEW_RE.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TB_PASSWORD_NEW_RE.Location = New System.Drawing.Point(139, 102)
        Me.TB_PASSWORD_NEW_RE.Name = "TB_PASSWORD_NEW_RE"
        Me.TB_PASSWORD_NEW_RE.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TB_PASSWORD_NEW_RE.Size = New System.Drawing.Size(169, 36)
        Me.TB_PASSWORD_NEW_RE.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "New password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Confirm New password"
        '
        'PopupChangePasswd_BAO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 242)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_PASSWORD_NEW_RE)
        Me.Controls.Add(Me.TB_PASSWORD_NEW)
        Me.Name = "PopupChangePasswd_BAO"
        Me.Text = "PopupChangePasswd"
        Me.Controls.SetChildIndex(Me.TB_PASSWORD_NEW, 0)
        Me.Controls.SetChildIndex(Me.TB_PASSWORD_NEW_RE, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_PASSWORD_NEW As System.Windows.Forms.TextBox
    Friend WithEvents TB_PASSWORD_NEW_RE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
