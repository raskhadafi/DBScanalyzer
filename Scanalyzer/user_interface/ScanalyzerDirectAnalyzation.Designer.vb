<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScanalyzerDirectAnalyzation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScanalyzerDirectAnalyzation))
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUsr = New System.Windows.Forms.TextBox
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.btnMysql = New System.Windows.Forms.RadioButton
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnAnalyze = New System.Windows.Forms.Button
        Me.dbGroup = New System.Windows.Forms.GroupBox
        Me.btnMssql = New System.Windows.Forms.RadioButton
        Me.dbGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(113, 12)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(100, 20)
        Me.txtIP.TabIndex = 0
        Me.txtIP.Text = "192.168.56.3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "usr:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "pwd:"
        '
        'txtUsr
        '
        Me.txtUsr.Location = New System.Drawing.Point(113, 67)
        Me.txtUsr.Name = "txtUsr"
        Me.txtUsr.Size = New System.Drawing.Size(100, 20)
        Me.txtUsr.TabIndex = 2
        Me.txtUsr.Text = "dbtest"
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(113, 113)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Size = New System.Drawing.Size(100, 20)
        Me.txtPwd.TabIndex = 3
        Me.txtPwd.Text = "dbtest"
        '
        'btnMysql
        '
        Me.btnMysql.AutoSize = True
        Me.btnMysql.Location = New System.Drawing.Point(15, 29)
        Me.btnMysql.Name = "btnMysql"
        Me.btnMysql.Size = New System.Drawing.Size(51, 17)
        Me.btnMysql.TabIndex = 7
        Me.btnMysql.Text = "mysql"
        Me.btnMysql.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(113, 39)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "3307"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Port:"
        '
        'btnAnalyze
        '
        Me.btnAnalyze.Location = New System.Drawing.Point(138, 245)
        Me.btnAnalyze.Name = "btnAnalyze"
        Me.btnAnalyze.Size = New System.Drawing.Size(75, 23)
        Me.btnAnalyze.TabIndex = 10
        Me.btnAnalyze.Text = "analyze"
        Me.btnAnalyze.UseVisualStyleBackColor = True
        '
        'dbGroup
        '
        Me.dbGroup.Controls.Add(Me.btnMssql)
        Me.dbGroup.Controls.Add(Me.btnMysql)
        Me.dbGroup.Location = New System.Drawing.Point(113, 139)
        Me.dbGroup.Name = "dbGroup"
        Me.dbGroup.Size = New System.Drawing.Size(100, 100)
        Me.dbGroup.TabIndex = 11
        Me.dbGroup.TabStop = False
        Me.dbGroup.Text = "DatabaseType:"
        '
        'btnMssql
        '
        Me.btnMssql.AutoSize = True
        Me.btnMssql.Location = New System.Drawing.Point(15, 52)
        Me.btnMssql.Name = "btnMssql"
        Me.btnMssql.Size = New System.Drawing.Size(51, 17)
        Me.btnMssql.TabIndex = 8
        Me.btnMssql.Text = "mssql"
        Me.btnMssql.UseVisualStyleBackColor = True
        '
        'ScanalyzerDirectAnalyzation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(229, 282)
        Me.Controls.Add(Me.dbGroup)
        Me.Controls.Add(Me.btnAnalyze)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUsr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScanalyzerDirectAnalyzation"
        Me.Text = "ScanalyzerDirectAnalyzation"
        Me.dbGroup.ResumeLayout(False)
        Me.dbGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsr As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents btnMysql As System.Windows.Forms.RadioButton
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAnalyze As System.Windows.Forms.Button
    Friend WithEvents dbGroup As System.Windows.Forms.GroupBox
    Friend WithEvents btnMssql As System.Windows.Forms.RadioButton
End Class
