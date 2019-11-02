<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm11ConcMnt_BAO
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm11ConcMnt_BAO))
        Me.Chart2D1 = New C1.Win.C1Chart.C1Chart()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.BTN_CONCMNT_ENTER = New System.Windows.Forms.Button()
        Me.BTN_CONCMNT_HISTRY = New System.Windows.Forms.Button()
        Me.BTN_CONCMNT_PARASET = New System.Windows.Forms.Button()
        Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.LB_EST = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Chart2D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart2D1
        '
        Me.Chart2D1.BackColor = System.Drawing.Color.White
        Me.Chart2D1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Chart2D1.ForeColor = System.Drawing.Color.Black
        Me.Chart2D1.Location = New System.Drawing.Point(120, 110)
        Me.Chart2D1.Name = "Chart2D1"
        Me.Chart2D1.PropBag = resources.GetString("Chart2D1.PropBag")
        Me.Chart2D1.Size = New System.Drawing.Size(1060, 288)
        Me.Chart2D1.TabIndex = 122
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.BackColorBkg = System.Drawing.SystemColors.Control
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGrid1.Cols = 5
        Me.C1FlexGrid1.ColumnInfo = resources.GetString("C1FlexGrid1.ColumnInfo")
        Me.C1FlexGrid1.FixedCols = 0
        Me.C1FlexGrid1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold)
        Me.C1FlexGrid1.GridColor = System.Drawing.Color.Black
        Me.C1FlexGrid1.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.C1FlexGrid1.GridLinesFixed = C1.Win.C1FlexGrid.Classic.GridStyleSettings.flexGridFlat
        Me.C1FlexGrid1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.C1FlexGrid1.Location = New System.Drawing.Point(120, 589)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.NodeClosedPicture = Nothing
        Me.C1FlexGrid1.NodeOpenPicture = Nothing
        Me.C1FlexGrid1.OutlineCol = -1
        Me.C1FlexGrid1.Rows = 7
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid1.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
        Me.C1FlexGrid1.Size = New System.Drawing.Size(924, 219)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 124
        Me.C1FlexGrid1.TreeColor = System.Drawing.Color.DarkGray
        '
        'BTN_CONCMNT_ENTER
        '
        Me.BTN_CONCMNT_ENTER.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CONCMNT_ENTER.Location = New System.Drawing.Point(1082, 492)
        Me.BTN_CONCMNT_ENTER.Name = "BTN_CONCMNT_ENTER"
        Me.BTN_CONCMNT_ENTER.Size = New System.Drawing.Size(98, 39)
        Me.BTN_CONCMNT_ENTER.TabIndex = 203
        Me.BTN_CONCMNT_ENTER.Text = "ENTER"
        Me.BTN_CONCMNT_ENTER.UseVisualStyleBackColor = True
        '
        'BTN_CONCMNT_HISTRY
        '
        Me.BTN_CONCMNT_HISTRY.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CONCMNT_HISTRY.Location = New System.Drawing.Point(1082, 589)
        Me.BTN_CONCMNT_HISTRY.Name = "BTN_CONCMNT_HISTRY"
        Me.BTN_CONCMNT_HISTRY.Size = New System.Drawing.Size(98, 39)
        Me.BTN_CONCMNT_HISTRY.TabIndex = 203
        Me.BTN_CONCMNT_HISTRY.Text = "HISTRY"
        Me.BTN_CONCMNT_HISTRY.UseVisualStyleBackColor = True
        '
        'BTN_CONCMNT_PARASET
        '
        Me.BTN_CONCMNT_PARASET.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CONCMNT_PARASET.Location = New System.Drawing.Point(120, 814)
        Me.BTN_CONCMNT_PARASET.Name = "BTN_CONCMNT_PARASET"
        Me.BTN_CONCMNT_PARASET.Size = New System.Drawing.Size(161, 39)
        Me.BTN_CONCMNT_PARASET.TabIndex = 204
        Me.BTN_CONCMNT_PARASET.Text = "Parameter Setting"
        Me.BTN_CONCMNT_PARASET.UseVisualStyleBackColor = True
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.BackColorBkg = System.Drawing.SystemColors.Control
        Me.C1FlexGrid2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGrid2.Cols = 5
        Me.C1FlexGrid2.ColumnInfo = resources.GetString("C1FlexGrid2.ColumnInfo")
        Me.C1FlexGrid2.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse
        Me.C1FlexGrid2.ExplorerBar = C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSortShow
        Me.C1FlexGrid2.FixedCols = 0
        Me.C1FlexGrid2.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold)
        Me.C1FlexGrid2.GridColor = System.Drawing.Color.Black
        Me.C1FlexGrid2.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.C1FlexGrid2.GridLinesFixed = C1.Win.C1FlexGrid.Classic.GridStyleSettings.flexGridFlat
        Me.C1FlexGrid2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.C1FlexGrid2.Location = New System.Drawing.Point(120, 492)
        Me.C1FlexGrid2.Name = "C1FlexGrid2"
        Me.C1FlexGrid2.NodeClosedPicture = Nothing
        Me.C1FlexGrid2.NodeOpenPicture = Nothing
        Me.C1FlexGrid2.OutlineCol = -1
        Me.C1FlexGrid2.Rows = 2
        Me.C1FlexGrid2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid2.ShowCursor = True
        Me.C1FlexGrid2.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
        Me.C1FlexGrid2.Size = New System.Drawing.Size(924, 65)
        Me.C1FlexGrid2.StyleInfo = resources.GetString("C1FlexGrid2.StyleInfo")
        Me.C1FlexGrid2.TabIndex = 124
        Me.C1FlexGrid2.TreeColor = System.Drawing.Color.DarkGray
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(187, 401)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 24)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "Analysis result"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.SystemColors.Control
        Me.Label60.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label60.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label60.Location = New System.Drawing.Point(1189, 221)
        Me.Label60.Name = "Label60"
        Me.Label60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label60.Size = New System.Drawing.Size(34, 19)
        Me.Label60.TabIndex = 206
        Me.Label60.Text = "Est"
        '
        'LB_EST
        '
        Me.LB_EST.BackColor = System.Drawing.SystemColors.Control
        Me.LB_EST.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LB_EST.Cursor = System.Windows.Forms.Cursors.Default
        Me.LB_EST.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_EST.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LB_EST.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LB_EST.Location = New System.Drawing.Point(1186, 244)
        Me.LB_EST.Name = "LB_EST"
        Me.LB_EST.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LB_EST.Size = New System.Drawing.Size(57, 25)
        Me.LB_EST.TabIndex = 207
        Me.LB_EST.Tag = "#0.0"
        Me.LB_EST.Text = "0.0"
        Me.LB_EST.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(1215, 273)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(28, 16)
        Me.Label62.TabIndex = 208
        Me.Label62.Text = "g/L"
        '
        'Timer1
        '
        Me.Timer1.Interval = 30000
        '
        'Frm11ConcMnt_BAO
        '
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.LB_EST)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BTN_CONCMNT_PARASET)
        Me.Controls.Add(Me.BTN_CONCMNT_HISTRY)
        Me.Controls.Add(Me.BTN_CONCMNT_ENTER)
        Me.Controls.Add(Me.C1FlexGrid2)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.Chart2D1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm11ConcMnt_BAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Controls.SetChildIndex(Me.ScrHdrLabel, 0)
        Me.Controls.SetChildIndex(Me.Chart2D1, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid1, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid2, 0)
        Me.Controls.SetChildIndex(Me.BTN_CONCMNT_ENTER, 0)
        Me.Controls.SetChildIndex(Me.BTN_CONCMNT_HISTRY, 0)
        Me.Controls.SetChildIndex(Me.BTN_CONCMNT_PARASET, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label62, 0)
        Me.Controls.SetChildIndex(Me.LB_EST, 0)
        Me.Controls.SetChildIndex(Me.Label60, 0)
        CType(Me.Chart2D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart2D1 As C1.Win.C1Chart.C1Chart
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
    Friend WithEvents BTN_CONCMNT_ENTER As Button
    Friend WithEvents BTN_CONCMNT_HISTRY As Button
    Friend WithEvents BTN_CONCMNT_PARASET As Button
    Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
    Friend WithEvents Label6 As Label
    Public WithEvents Label60 As Label
    Public WithEvents LB_EST As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents Timer1 As Timer
End Class
