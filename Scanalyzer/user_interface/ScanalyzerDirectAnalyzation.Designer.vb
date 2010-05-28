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
        Me.Label4 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnAnalyze = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(113, 12)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(100, 20)
        Me.txtIP.TabIndex = 0
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
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(113, 113)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Size = New System.Drawing.Size(100, 20)
        Me.txtPwd.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "DatabaseType:"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(113, 175)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(51, 17)
        Me.RadioButton1.TabIndex = 7
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "mysql"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(113, 39)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 1
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
        Me.btnAnalyze.Location = New System.Drawing.Point(138, 246)
        Me.btnAnalyze.Name = "btnAnalyze"
        Me.btnAnalyze.Size = New System.Drawing.Size(75, 23)
        Me.btnAnalyze.TabIndex = 10
        Me.btnAnalyze.Text = "analyze"
        Me.btnAnalyze.UseVisualStyleBackColor = True
        '
        'ScanalyzerDirectAnalyzation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 290)
        Me.Controls.Add(Me.btnAnalyze)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUsr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScanalyzerDirectAnalyzation"
        Me.Text = "ScanalyzerDirectAnalyzation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUsr As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAnalyze As System.Windows.Forms.Button
End Class
