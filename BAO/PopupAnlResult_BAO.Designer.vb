<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PopupAnlResult_BAO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PopupAnlResult_BAO))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(954, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Analysis result"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.BackColorBkg = System.Drawing.SystemColors.Control
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGrid1.Cols = 5
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.FixedCols = 0
        Me.C1FlexGrid1.FixedRows = 2
        Me.C1FlexGrid1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold)
        Me.C1FlexGrid1.GridColor = System.Drawing.Color.Black
        Me.C1FlexGrid1.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.C1FlexGrid1.GridLinesFixed = C1.Win.C1FlexGrid.Classic.GridStyleSettings.flexGridFlat
        Me.C1FlexGrid1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.C1FlexGrid1.Location = New System.Drawing.Point(23, 47)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.NodeClosedPicture = Nothing
        Me.C1FlexGrid1.NodeOpenPicture = Nothing
        Me.C1FlexGrid1.OutlineCol = -1
        Me.C1FlexGrid1.Rows = 102
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid1.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
        Me.C1FlexGrid1.Size = New System.Drawing.Size(940, 550)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 215
        Me.C1FlexGrid1.TreeColor = System.Drawing.Color.DarkGray
        '
        'PopupAnlResult_BAO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 619)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(991, 657)
        Me.MinimumSize = New System.Drawing.Size(991, 657)
        Me.Name = "PopupAnlResult_BAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Analysis result"
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
End Class
