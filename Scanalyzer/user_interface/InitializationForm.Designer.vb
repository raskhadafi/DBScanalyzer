<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InitializationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InitializationForm))
        Me.InputTabbs = New System.Windows.Forms.TabControl
        Me.ReferncesSelectionTab = New System.Windows.Forms.TabPage
        Me.ReferncesDefinitionTab = New System.Windows.Forms.TabPage
        Me.MetricsSelectionTab = New System.Windows.Forms.TabPage
        Me.IPRangeTab = New System.Windows.Forms.TabPage
        Me.txtIPRange = New System.Windows.Forms.TextBox
        Me.lblIPRange = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.InputTabbs.SuspendLayout()
        Me.IPRangeTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'InputTabbs
        '
        Me.InputTabbs.Controls.Add(Me.ReferncesSelectionTab)
        Me.InputTabbs.Controls.Add(Me.ReferncesDefinitionTab)
        Me.InputTabbs.Controls.Add(Me.MetricsSelectionTab)
        Me.InputTabbs.Controls.Add(Me.IPRangeTab)
        Me.InputTabbs.Location = New System.Drawing.Point(-2, 47)
        Me.InputTabbs.Name = "InputTabbs"
        Me.InputTabbs.SelectedIndex = 0
        Me.InputTabbs.Size = New System.Drawing.Size(458, 485)
        Me.InputTabbs.TabIndex = 0
        '
        'ReferncesSelectionTab
        '
        Me.ReferncesSelectionTab.AutoScroll = True
        Me.ReferncesSelectionTab.Location = New System.Drawing.Point(4, 22)
        Me.ReferncesSelectionTab.Name = "ReferncesSelectionTab"
        Me.ReferncesSelectionTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ReferncesSelectionTab.Size = New System.Drawing.Size(450, 459)
        Me.ReferncesSelectionTab.TabIndex = 0
        Me.ReferncesSelectionTab.Text = "Select References"
        Me.ReferncesSelectionTab.UseVisualStyleBackColor = True
        '
        'ReferncesDefinitionTab
        '
        Me.ReferncesDefinitionTab.Location = New System.Drawing.Point(4, 22)
        Me.ReferncesDefinitionTab.Name = "ReferncesDefinitionTab"
        Me.ReferncesDefinitionTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ReferncesDefinitionTab.Size = New System.Drawing.Size(450, 459)
        Me.ReferncesDefinitionTab.TabIndex = 1
        Me.ReferncesDefinitionTab.Text = "Add new References"
        Me.ReferncesDefinitionTab.UseVisualStyleBackColor = True
        '
        'MetricsSelectionTab
        '
        Me.MetricsSelectionTab.Location = New System.Drawing.Point(4, 22)
        Me.MetricsSelectionTab.Name = "MetricsSelectionTab"
        Me.MetricsSelectionTab.Size = New System.Drawing.Size(450, 459)
        Me.MetricsSelectionTab.TabIndex = 2
        Me.MetricsSelectionTab.Text = "Select Metrics"
        Me.MetricsSelectionTab.UseVisualStyleBackColor = True
        '
        'IPRangeTab
        '
        Me.IPRangeTab.Controls.Add(Me.txtIPRange)
        Me.IPRangeTab.Controls.Add(Me.lblIPRange)
        Me.IPRangeTab.Location = New System.Drawing.Point(4, 22)
        Me.IPRangeTab.Name = "IPRangeTab"
        Me.IPRangeTab.Size = New System.Drawing.Size(450, 459)
        Me.IPRangeTab.TabIndex = 3
        Me.IPRangeTab.Text = "Definie IP-Range"
        Me.IPRangeTab.UseVisualStyleBackColor = True
        '
        'txtIPRange
        '
        Me.txtIPRange.Location = New System.Drawing.Point(87, 23)
        Me.txtIPRange.Name = "txtIPRange"
        Me.txtIPRange.Size = New System.Drawing.Size(177, 20)
        Me.txtIPRange.TabIndex = 1
        '
        'lblIPRange
        '
        Me.lblIPRange.AutoSize = True
        Me.lblIPRange.Location = New System.Drawing.Point(29, 26)
        Me.lblIPRange.Name = "lblIPRange"
        Me.lblIPRange.Size = New System.Drawing.Size(55, 13)
        Me.lblIPRange.TabIndex = 0
        Me.lblIPRange.Text = "IP-Range:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(368, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "next step"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'InitializationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 532)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.InputTabbs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InitializationForm"
        Me.Text = "InitializationForm"
        Me.InputTabbs.ResumeLayout(False)
        Me.IPRangeTab.ResumeLayout(False)
        Me.IPRangeTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InputTabbs As System.Windows.Forms.TabControl
    Friend WithEvents ReferncesSelectionTab As System.Windows.Forms.TabPage
    Friend WithEvents ReferncesDefinitionTab As System.Windows.Forms.TabPage
    Friend WithEvents MetricsSelectionTab As System.Windows.Forms.TabPage
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents IPRangeTab As System.Windows.Forms.TabPage
    Friend WithEvents txtIPRange As System.Windows.Forms.TextBox
    Friend WithEvents lblIPRange As System.Windows.Forms.Label
End Class
