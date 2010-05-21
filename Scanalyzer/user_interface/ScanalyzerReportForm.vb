Public Class ScanalyzerReportForm

    Public Sub New(ByVal result As String)

        InitializeComponent()
        Me.txtReport.Text = result
        Me.Show()
        Me.Focus()

    End Sub

End Class