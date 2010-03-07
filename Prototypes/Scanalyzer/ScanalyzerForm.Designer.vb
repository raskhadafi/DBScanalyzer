<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScanalyzerForm
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
        Me.txtIPRangeBegin = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtIPRangeEnd = New System.Windows.Forms.TextBox
        Me.btnScanIPRange = New System.Windows.Forms.Button
        Me.txtPrintout = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtIPRangeBegin
        '
        Me.txtIPRangeBegin.Location = New System.Drawing.Point(63, 4)
        Me.txtIPRangeBegin.Name = "txtIPRangeBegin"
        Me.txtIPRangeBegin.Size = New System.Drawing.Size(100, 20)
        Me.txtIPRangeBegin.TabIndex = 0
        Me.txtIPRangeBegin.Text = "192.168.1.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Start Ip:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "End Ip:"
        '
        'txtIPRangeEnd
        '
        Me.txtIPRangeEnd.Location = New System.Drawing.Point(63, 30)
        Me.txtIPRangeEnd.Name = "txtIPRangeEnd"
        Me.txtIPRangeEnd.Size = New System.Drawing.Size(100, 20)
        Me.txtIPRangeEnd.TabIndex = 2
        Me.txtIPRangeEnd.Text = "192.168.1.50"
        '
        'btnScanIPRange
        '
        Me.btnScanIPRange.Location = New System.Drawing.Point(169, 2)
        Me.btnScanIPRange.Name = "btnScanIPRange"
        Me.btnScanIPRange.Size = New System.Drawing.Size(111, 23)
        Me.btnScanIPRange.TabIndex = 4
        Me.btnScanIPRange.Text = "scan IP Range"
        Me.btnScanIPRange.UseVisualStyleBackColor = True
        '
        'txtPrintout
        '
        Me.txtPrintout.Location = New System.Drawing.Point(16, 80)
        Me.txtPrintout.Multiline = True
        Me.txtPrintout.Name = "txtPrintout"
        Me.txtPrintout.Size = New System.Drawing.Size(147, 181)
        Me.txtPrintout.TabIndex = 5
        '
        'ScanalyzerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.txtPrintout)
        Me.Controls.Add(Me.btnScanIPRange)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIPRangeEnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIPRangeBegin)
        Me.Name = "ScanalyzerForm"
        Me.Text = "ScanalyzerForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIPRangeBegin As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIPRangeEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnScanIPRange As System.Windows.Forms.Button
    Friend WithEvents txtPrintout As System.Windows.Forms.TextBox
End Class
