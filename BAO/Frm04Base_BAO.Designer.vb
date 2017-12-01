<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm04Base_BAO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm04Base_BAO))
        Me.Chart2D1 = New C1.Win.C1Chart.C1Chart()
        Me.Chart2D2 = New C1.Win.C1Chart.C1Chart()
        CType(Me.Chart2D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2D2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart2D1
        '
        Me.Chart2D1.BackColor = System.Drawing.Color.White
        Me.Chart2D1.ForeColor = System.Drawing.Color.Black
        Me.Chart2D1.Location = New System.Drawing.Point(120, 140)
        Me.Chart2D1.Name = "Chart2D1"
        Me.Chart2D1.PropBag = resources.GetString("Chart2D1.PropBag")
        Me.Chart2D1.Size = New System.Drawing.Size(1060, 280)
        Me.Chart2D1.TabIndex = 122
        '
        'Chart2D2
        '
        Me.Chart2D2.BackColor = System.Drawing.Color.White
        Me.Chart2D2.ForeColor = System.Drawing.Color.Black
        Me.Chart2D2.Location = New System.Drawing.Point(120, 520)
        Me.Chart2D2.Name = "Chart2D2"
        Me.Chart2D2.PropBag = resources.GetString("Chart2D2.PropBag")
        Me.Chart2D2.Size = New System.Drawing.Size(1060, 280)
        Me.Chart2D2.TabIndex = 123
        '
        'Frm04Base_BAO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.Chart2D2)
        Me.Controls.Add(Me.Chart2D1)
        Me.Name = "Frm04Base_BAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Controls.SetChildIndex(Me.ScrHdrLabel, 0)
        Me.Controls.SetChildIndex(Me.Chart2D1, 0)
        Me.Controls.SetChildIndex(Me.Chart2D2, 0)
        CType(Me.Chart2D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2D2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart2D1 As C1.Win.C1Chart.C1Chart
    Friend WithEvents Chart2D2 As C1.Win.C1Chart.C1Chart




End Class
