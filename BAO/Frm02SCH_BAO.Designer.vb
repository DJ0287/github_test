<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm02SCH_BAO
    Inherits ETL_SRS_BAO.Frm02Base_BAO

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm02SCH_BAO))
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "13,0,0,0,0,130,Columns:0{Width:67;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "3{Width:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "4{Widt" &
    "h:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "5{Width:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "6{Width:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "7{Width:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "8{Width:100;}" & Global.Microsoft.VisualBasic.ChrW(9) & "9{Width:100;}" & Global.Microsoft.VisualBasic.ChrW(9) & "10{Wid" &
    "th:83;}" & Global.Microsoft.VisualBasic.ChrW(9) & "11{Width:100;}" & Global.Microsoft.VisualBasic.ChrW(9) & "12{Width:83;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid1.Size = New System.Drawing.Size(1114, 545)
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.ColumnInfo = "1,0,0,0,0,130,Columns:0{Width:116;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid2.Size = New System.Drawing.Size(116, 432)
        '
        'Frm02SCH_BAO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1264, 986)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm02SCH_BAO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    '    Public WithEvents LineStoptime As System.Windows.Forms.Label
    '    Public WithEvents Label10 As System.Windows.Forms.Label
    '    Public WithEvents ContAtime As System.Windows.Forms.Label
    '    Public WithEvents Label8 As System.Windows.Forms.Label
    '    Public WithEvents Label76 As System.Windows.Forms.Label
    '    Public WithEvents Label56 As System.Windows.Forms.Label

End Class
