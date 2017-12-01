<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm12ALMHst
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm12ALMHst))
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.PasswdBtn = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.BackColorBkg = System.Drawing.SystemColors.Control
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGrid1.Cols = 5
        Me.C1FlexGrid1.ColumnInfo = "5,0,0,0,0,145,Columns:"
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
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.C1FlexGrid1.Size = New System.Drawing.Size(1140, 700)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 122
        Me.C1FlexGrid1.TreeColor = System.Drawing.Color.DarkGray
        '
        'PasswdBtn
        '
        Me.PasswdBtn.BackColor = System.Drawing.Color.Red
        Me.PasswdBtn.Font = New System.Drawing.Font("メイリオ", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PasswdBtn.Location = New System.Drawing.Point(360, 60)
        Me.PasswdBtn.Name = "PasswdBtn"
        Me.PasswdBtn.Size = New System.Drawing.Size(136, 39)
        Me.PasswdBtn.TabIndex = 125
        Me.PasswdBtn.Text = "履歴消去"
        Me.PasswdBtn.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Ethernet通信異常", "計測器異常", "ﾙｰﾌﾟ制御/　CASﾓｰﾄﾞ選択でない", "3ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度PV値異常", "4ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度PV値異常", "ｽﾄﾚｰｼﾞAﾀﾝｸ錫ｲｵﾝ濃度PV値異常", "3ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度低下", "4ETL　循環ﾀﾝｸ錫ｲｵﾝ濃度低下", "ｽﾄﾚｰｼﾞAﾀﾝｸ錫ｲｵﾝ濃度低下", "3ETL　錫溶解補正量ΔS1x過大", "4ETL　錫溶解補正量ΔS1x過大", "St.B～溶解槽供給ﾎﾟﾝﾌﾟ停止", "溶解槽自己循環ﾎﾟﾝﾌﾟ停止", "ﾒｯｷ液供給ﾎﾟﾝﾌﾟ停止", "3ETLﾒｯｷ液返送ﾎﾟﾝﾌﾟ停止", "4ETLﾒｯｷ液返送ﾎﾟﾝﾌﾟ停止", "演算異常", "生産ｽｹｼﾞｭｰﾙﾃﾞｰﾀ異常"})
        Me.ComboBox1.Location = New System.Drawing.Point(973, 854)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(219, 20)
        Me.ComboBox1.TabIndex = 126
        Me.ComboBox1.Visible = False
        '
        'Frm12ALMHst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.PasswdBtn)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm12ALMHst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Controls.SetChildIndex(Me.ScrHdrLabel, 0)
        Me.Controls.SetChildIndex(Me.C1FlexGrid1, 0)
        Me.Controls.SetChildIndex(Me.PasswdBtn, 0)
        Me.Controls.SetChildIndex(Me.ComboBox1, 0)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
    Friend WithEvents PasswdBtn As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

End Class
