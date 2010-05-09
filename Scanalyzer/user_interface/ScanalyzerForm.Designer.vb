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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScanalyzerForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.InitializeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReferenzdatenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblIpRange = New System.Windows.Forms.Label
        Me.txtIpRange = New System.Windows.Forms.Label
        Me.lblReferences = New System.Windows.Forms.Label
        Me.txtReferences = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InitializeToolStripMenuItem, Me.ReferenzdatenToolStripMenuItem, Me.FileToolStripMenuItem, Me.ToolStripMenuItem1, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(507, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InitializeToolStripMenuItem
        '
        Me.InitializeToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.InitializeToolStripMenuItem.Name = "InitializeToolStripMenuItem"
        Me.InitializeToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.InitializeToolStripMenuItem.Text = "Initialize"
        '
        'ReferenzdatenToolStripMenuItem
        '
        Me.ReferenzdatenToolStripMenuItem.Name = "ReferenzdatenToolStripMenuItem"
        Me.ReferenzdatenToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.ReferenzdatenToolStripMenuItem.Text = "References"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(48, 20)
        Me.ToolStripMenuItem1.Text = "About"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'lblIpRange
        '
        Me.lblIpRange.AutoSize = True
        Me.lblIpRange.Location = New System.Drawing.Point(12, 35)
        Me.lblIpRange.Name = "lblIpRange"
        Me.lblIpRange.Size = New System.Drawing.Size(55, 13)
        Me.lblIpRange.TabIndex = 1
        Me.lblIpRange.Text = "IP-Range:"
        '
        'txtIpRange
        '
        Me.txtIpRange.AutoSize = True
        Me.txtIpRange.Location = New System.Drawing.Point(73, 35)
        Me.txtIpRange.MinimumSize = New System.Drawing.Size(100, 0)
        Me.txtIpRange.Name = "txtIpRange"
        Me.txtIpRange.Size = New System.Drawing.Size(100, 13)
        Me.txtIpRange.TabIndex = 2
        Me.txtIpRange.Text = "placeholder"
        '
        'lblReferences
        '
        Me.lblReferences.AutoSize = True
        Me.lblReferences.Location = New System.Drawing.Point(12, 68)
        Me.lblReferences.Name = "lblReferences"
        Me.lblReferences.Size = New System.Drawing.Size(110, 13)
        Me.lblReferences.TabIndex = 3
        Me.lblReferences.Text = "Selected References:"
        '
        'txtReferences
        '
        Me.txtReferences.AutoSize = True
        Me.txtReferences.Location = New System.Drawing.Point(128, 68)
        Me.txtReferences.Name = "txtReferences"
        Me.txtReferences.Size = New System.Drawing.Size(39, 13)
        Me.txtReferences.TabIndex = 4
        Me.txtReferences.Text = "Label1"
        '
        'ScanalyzerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 353)
        Me.Controls.Add(Me.txtReferences)
        Me.Controls.Add(Me.lblReferences)
        Me.Controls.Add(Me.txtIpRange)
        Me.Controls.Add(Me.lblIpRange)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ScanalyzerForm"
        Me.Text = "Scanalyzer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReferenzdatenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InitializeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblIpRange As System.Windows.Forms.Label
    Friend WithEvents txtIpRange As System.Windows.Forms.Label
    Friend WithEvents lblReferences As System.Windows.Forms.Label
    Friend WithEvents txtReferences As System.Windows.Forms.Label

End Class
