<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cmdPing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cmdPing))
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtIPRange = New System.Windows.Forms.TextBox
        Me.txtStdout = New System.Windows.Forms.TextBox
        Me.txtStderr = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.nmapOutputText = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "nmap.exe"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtIPRange
        '
        Me.txtIPRange.Location = New System.Drawing.Point(140, 14)
        Me.txtIPRange.Name = "txtIPRange"
        Me.txtIPRange.Size = New System.Drawing.Size(414, 20)
        Me.txtIPRange.TabIndex = 1
        Me.txtIPRange.Text = "10.3.115.80"
        '
        'txtStdout
        '
        Me.txtStdout.Location = New System.Drawing.Point(12, 213)
        Me.txtStdout.Multiline = True
        Me.txtStdout.Name = "txtStdout"
        Me.txtStdout.Size = New System.Drawing.Size(268, 120)
        Me.txtStdout.TabIndex = 2
        '
        'txtStderr
        '
        Me.txtStderr.Location = New System.Drawing.Point(286, 213)
        Me.txtStderr.Multiline = True
        Me.txtStderr.Name = "txtStderr"
        Me.txtStderr.Size = New System.Drawing.Size(268, 120)
        Me.txtStderr.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "args:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Output:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(283, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Error-Output:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 51)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "nmap.exe stub"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'nmapOutputText
        '
        Me.nmapOutputText.Location = New System.Drawing.Point(155, 53)
        Me.nmapOutputText.Multiline = True
        Me.nmapOutputText.Name = "nmapOutputText"
        Me.nmapOutputText.Size = New System.Drawing.Size(383, 141)
        Me.nmapOutputText.TabIndex = 8
        Me.nmapOutputText.Text = resources.GetString("nmapOutputText.Text")
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(609, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "DBAnalyzer"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmdPing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 345)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.nmapOutputText)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtStderr)
        Me.Controls.Add(Me.txtStdout)
        Me.Controls.Add(Me.txtIPRange)
        Me.Controls.Add(Me.Button1)
        Me.Name = "cmdPing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "cmdPing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtIPRange As System.Windows.Forms.TextBox
    Friend WithEvents txtStdout As System.Windows.Forms.TextBox
    Friend WithEvents txtStderr As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents nmapOutputText As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
