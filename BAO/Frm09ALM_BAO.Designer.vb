<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm09ALM_BAO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm09ALM_BAO))
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.PasswdBtn = New System.Windows.Forms.Button()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.BackColorBkg = System.Drawing.SystemColors.Control
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGrid1.Cols = 4
        Me.C1FlexGrid1.ColumnInfo = "4,0,0,0,0,145,Columns:"
        Me.C1FlexGrid1.ExplorerBar = C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExNone
        Me.C1FlexGrid1.FixedCols = 0
        Me.C1FlexGrid1.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Bold)
        Me.C1FlexGrid1.GridColor = System.Drawing.Color.Black
        Me.C1FlexGrid1.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.C1FlexGrid1.GridLinesFixed = C1.Win.C1FlexGrid.Classic.GridStyleSettings.flexGridFlat
        Me.C1FlexGrid1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.C1FlexGrid1.Location = New System.Drawing.Point(60, 140)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.NodeClosedPicture = Nothing
        Me.C1FlexGrid1.NodeOpenPicture = Nothing
        Me.C1FlexGrid1.OutlineCol = -1
        Me.C1FlexGrid1.Rows = 17
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid1.Size = New System.Drawing.Size(1140, 700)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 122
        Me.C1FlexGrid1.TreeColor = System.Drawing.Color.DarkGray
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Ethernet通信異常", "計測器異常", "ﾙｰﾌﾟ制御/　CASﾓｰﾄﾞ選択でない", "3ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度PV値異常", "4ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度PV値異常", "ｽﾄﾚｰｼﾞAﾀﾝｸ錫ｲｵﾝ濃度PV値異常", "3ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度低下", "4ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度低下", "ｽﾄﾚｰｼﾞAﾀﾝｸ錫ｲｵﾝ濃度低下", "3ETL　錫溶解補正量ΔS1x過大", "4ETL　錫溶解補正量ΔS1x過大", "St.B～溶解槽供給ﾎﾟﾝﾌﾟ停止", "溶解槽自己循環ﾎﾟﾝﾌﾟ停止", "ﾒｯｷ液供給ﾎﾟﾝﾌﾟ停止", "3ETLﾒｯｷ液返送ﾎﾟﾝﾌﾟ停止", "4ETLﾒｯｷ液返送ﾎﾟﾝﾌﾟ停止", "演算異常", "生産ｽｹｼﾞｭｰﾙﾃﾞｰﾀ異常"})
        Me.ComboBox1.Location = New System.Drawing.Point(973, 854)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(219, 21)
        Me.ComboBox1.TabIndex = 123
        Me.ComboBox1.Visible = False
        '
        'PasswdBtn
        '
        Me.PasswdBtn.BackColor = System.Drawing.Color.Yellow
        Me.PasswdBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswdBtn.Location = New System.Drawing.Point(360, 68)
        Me.PasswdBtn.Name = "PasswdBtn"
        Me.PasswdBtn.Size = New System.Drawing.Size(136, 39)
        Me.PasswdBtn.TabIndex = 124
        Me.PasswdBtn.Text = "Confirmation"
        Me.PasswdBtn.UseVisualStyleBackColor = False
        '
        'Frm09ALM_BAO
        '
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.PasswdBtn)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm09ALM_BAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Controls.SetChildIndex(Me.ScrHdrLabel, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid1, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        Me.Controls.SetChildIndex(Me.PasswdBtn, 0)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents PasswdBtn As System.Windows.Forms.Button

End Class
