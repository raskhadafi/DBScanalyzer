<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PingIPRange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PingIPRange))
        Me.txtIPRangeStart = New System.Windows.Forms.TextBox
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtIPRangeEnd = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtIPRangeStart
        '
        Me.txtIPRangeStart.Location = New System.Drawing.Point(93, 18)
        Me.txtIPRangeStart.Name = "txtIPRangeStart"
        Me.txtIPRangeStart.Size = New System.Drawing.Size(187, 20)
        Me.txtIPRangeStart.TabIndex = 5
        Me.txtIPRangeStart.Tag = ""
        Me.txtIPRangeStart.Text = "10.0.2.15"
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(12, 87)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtOutput.Size = New System.Drawing.Size(268, 259)
        Me.txtOutput.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "ping"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Start"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "End"
        '
        'txtIPRangeEnd
        '
        Me.txtIPRangeEnd.Location = New System.Drawing.Point(93, 61)
        Me.txtIPRangeEnd.Name = "txtIPRangeEnd"
        Me.txtIPRangeEnd.Size = New System.Drawing.Size(187, 20)
        Me.txtIPRangeEnd.TabIndex = 7
        Me.txtIPRangeEnd.Tag = ""
        Me.txtIPRangeEnd.Text = "10.0.2.15"
        '
        'PingIPRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 358)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIPRangeEnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIPRangeStart)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PingIPRange"
        Me.Text = "PingIPRange"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIPRangeStart As System.Windows.Forms.TextBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIPRangeEnd As System.Windows.Forms.TextBox
End Class
