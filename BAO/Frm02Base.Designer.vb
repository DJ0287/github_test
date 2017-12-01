<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm02Base
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm02Base))
        Me.LB_LINESTOP_TIME = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LB_CTL_TIME = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.LB_ETL_RUN = New System.Windows.Forms.Label()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LB_LINESTOP_TIME
        '
        Me.LB_LINESTOP_TIME.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LB_LINESTOP_TIME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LB_LINESTOP_TIME.Cursor = System.Windows.Forms.Cursors.Default
        Me.LB_LINESTOP_TIME.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_LINESTOP_TIME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LB_LINESTOP_TIME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LB_LINESTOP_TIME.Location = New System.Drawing.Point(793, 141)
        Me.LB_LINESTOP_TIME.Name = "LB_LINESTOP_TIME"
        Me.LB_LINESTOP_TIME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LB_LINESTOP_TIME.Size = New System.Drawing.Size(81, 25)
        Me.LB_LINESTOP_TIME.TabIndex = 27
        Me.LB_LINESTOP_TIME.Text = "999.9"
        Me.LB_LINESTOP_TIME.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(608, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(186, 25)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "ライン停止時間(分)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LB_CTL_TIME
        '
        Me.LB_CTL_TIME.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LB_CTL_TIME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LB_CTL_TIME.Cursor = System.Windows.Forms.Cursors.Default
        Me.LB_CTL_TIME.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_CTL_TIME.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LB_CTL_TIME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LB_CTL_TIME.Location = New System.Drawing.Point(521, 141)
        Me.LB_CTL_TIME.Name = "LB_CTL_TIME"
        Me.LB_CTL_TIME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LB_CTL_TIME.Size = New System.Drawing.Size(81, 25)
        Me.LB_CTL_TIME.TabIndex = 25
        Me.LB_CTL_TIME.Text = "999.9"
        Me.LB_CTL_TIME.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(345, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(177, 25)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "制御実績時間(分)"
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.Cols = 13
        Me.C1FlexGrid1.ColumnInfo = "13,0,0,0,0,130,Columns:"
        Me.C1FlexGrid1.ExplorerBar = C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExNone
        Me.C1FlexGrid1.ExtendLastCol = True
        Me.C1FlexGrid1.FixedCols = 0
        Me.C1FlexGrid1.FixedRows = 2
        Me.C1FlexGrid1.Font = New System.Drawing.Font("Meiryo UI", 11.25!)
        Me.C1FlexGrid1.GridColor = System.Drawing.Color.Black
        Me.C1FlexGrid1.GridColorFixed = System.Drawing.Color.Black
        Me.C1FlexGrid1.Location = New System.Drawing.Point(12, 178)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.NodeClosedPicture = Nothing
        Me.C1FlexGrid1.NodeOpenPicture = Nothing
        Me.C1FlexGrid1.OutlineCol = -1
        Me.C1FlexGrid1.Rows = 24
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid1.Size = New System.Drawing.Size(1114, 547)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 121
        Me.C1FlexGrid1.TreeColor = System.Drawing.Color.DarkGray
        Me.C1FlexGrid1.WordWrap = True
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.Cols = 1
        Me.C1FlexGrid2.ColumnInfo = "1,0,0,0,0,130,Columns:"
        Me.C1FlexGrid2.ExtendLastCol = True
        Me.C1FlexGrid2.FixedCols = 0
        Me.C1FlexGrid2.FixedRows = 0
        Me.C1FlexGrid2.Font = New System.Drawing.Font("Meiryo UI", 11.25!)
        Me.C1FlexGrid2.GridColor = System.Drawing.Color.Black
        Me.C1FlexGrid2.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.C1FlexGrid2.GridLinesFixed = C1.Win.C1FlexGrid.Classic.GridStyleSettings.flexGridFlat
        Me.C1FlexGrid2.Location = New System.Drawing.Point(1132, 178)
        Me.C1FlexGrid2.Name = "C1FlexGrid2"
        Me.C1FlexGrid2.NodeClosedPicture = Nothing
        Me.C1FlexGrid2.NodeOpenPicture = Nothing
        Me.C1FlexGrid2.OutlineCol = -1
        Me.C1FlexGrid2.Rows = 12
        Me.C1FlexGrid2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid2.Size = New System.Drawing.Size(116, 444)
        Me.C1FlexGrid2.StyleInfo = resources.GetString("C1FlexGrid2.StyleInfo")
        Me.C1FlexGrid2.TabIndex = 122
        Me.C1FlexGrid2.TreeColor = System.Drawing.Color.DarkGray
        '
        'LB_ETL_RUN
        '
        Me.LB_ETL_RUN.BackColor = System.Drawing.Color.Red
        Me.LB_ETL_RUN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LB_ETL_RUN.Cursor = System.Windows.Forms.Cursors.Default
        Me.LB_ETL_RUN.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_ETL_RUN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LB_ETL_RUN.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LB_ETL_RUN.Location = New System.Drawing.Point(523, 101)
        Me.LB_ETL_RUN.Name = "LB_ETL_RUN"
        Me.LB_ETL_RUN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LB_ETL_RUN.Size = New System.Drawing.Size(162, 25)
        Me.LB_ETL_RUN.TabIndex = 123
        Me.LB_ETL_RUN.Text = "No.3ETL運転中"
        Me.LB_ETL_RUN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm02Base
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.LB_ETL_RUN)
        Me.Controls.Add(Me.C1FlexGrid2)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.LB_LINESTOP_TIME)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LB_CTL_TIME)
        Me.Controls.Add(Me.Label8)
        Me.Name = "Frm02Base"
        Me.Controls.SetChildIndex(Me.ScrHdrLabel, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.LB_CTL_TIME, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.LB_LINESTOP_TIME, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid1, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid2, 0)
        Me.Controls.SetChildIndex(Me.LB_ETL_RUN, 0)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LB_LINESTOP_TIME As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents LB_CTL_TIME As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents LB_ETL_RUN As System.Windows.Forms.Label
    Public WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic 'AxMSFlexGridLib.AxMSFlexGrid
    Public WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic 'AxMSFlexGridLib.AxMSFlexGrid

End Class
