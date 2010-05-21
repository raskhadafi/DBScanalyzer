<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScanalyzerReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScanalyzerReportForm))
        Me.txtReport = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtReport
        '
        Me.txtReport.AutoSize = True
        Me.txtReport.Location = New System.Drawing.Point(12, 9)
        Me.txtReport.Name = "txtReport"
        Me.txtReport.Size = New System.Drawing.Size(39, 13)
        Me.txtReport.TabIndex = 0
        Me.txtReport.Text = "Label1"
        '
        'ScanalyzerReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 422)
        Me.Controls.Add(Me.txtReport)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ScanalyzerReportForm"
        Me.Text = "ScanalyzerReportForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtReport As System.Windows.Forms.Label
End Class
