Public Class ScanalyzerLogger

    Public Sub updateLogger(ByVal text As String)

        Me.txtOutput.Text += text + vbNewLine
        Me.Refresh()

    End Sub

End Class