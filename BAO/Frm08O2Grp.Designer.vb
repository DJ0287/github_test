<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm08O2Grp
    Inherits ETL_SRS_STP.FrmButton

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm08O2Grp))
        Me.Chart2D1 = New C1.Win.C1Chart.C1Chart()
        Me.Chart2D2 = New C1.Win.C1Chart.C1Chart()
        Me.Chart2D3 = New C1.Win.C1Chart.C1Chart()
        CType(Me.Chart2D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2D2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2D3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart2D1
        '
        Me.Chart2D1.BackColor = System.Drawing.Color.White
        Me.Chart2D1.ForeColor = System.Drawing.Color.Black
        Me.Chart2D1.Location = New System.Drawing.Point(120, 110)
        Me.Chart2D1.Name = "Chart2D1"
        Me.Chart2D1.PropBag = resources.GetString("Chart2D1.PropBag")
        Me.Chart2D1.Size = New System.Drawing.Size(1060, 200)
        Me.Chart2D1.TabIndex = 122
        '
        'Chart2D2
        '
        Me.Chart2D2.BackColor = System.Drawing.Color.White
        Me.Chart2D2.ForeColor = System.Drawing.Color.Black
        Me.Chart2D2.Location = New System.Drawing.Point(120, 370)
        Me.Chart2D2.Name = "Chart2D2"
        Me.Chart2D2.PropBag = resources.GetString("Chart2D2.PropBag")
        Me.Chart2D2.Size = New System.Drawing.Size(1060, 200)
        Me.Chart2D2.TabIndex = 123
        '
        'Chart2D3
        '
        Me.Chart2D3.BackColor = System.Drawing.Color.White
        Me.Chart2D3.ForeColor = System.Drawing.Color.Black
        Me.Chart2D3.Location = New System.Drawing.Point(120, 630)
        Me.Chart2D3.Name = "Chart2D3"
        Me.Chart2D3.PropBag = resources.GetString("Chart2D3.PropBag")
        Me.Chart2D3.Size = New System.Drawing.Size(1060, 200)
        Me.Chart2D3.TabIndex = 124
        '
        'Frm08O2Grp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.Chart2D3)
        Me.Controls.Add(Me.Chart2D2)
        Me.Controls.Add(Me.Chart2D1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm08O2Grp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Controls.SetChildIndex(Me.ScrHdrLabel, 0)
        Me.Controls.SetChildIndex(Me.Chart2D1, 0)
        Me.Controls.SetChildIndex(Me.Chart2D2, 0)
        Me.Controls.SetChildIndex(Me.Chart2D3, 0)
        CType(Me.Chart2D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2D2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2D3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart2D1 As C1.Win.C1Chart.C1Chart
    Friend WithEvents Chart2D2 As C1.Win.C1Chart.C1Chart
    Friend WithEvents Chart2D3 As C1.Win.C1Chart.C1Chart

End Class
