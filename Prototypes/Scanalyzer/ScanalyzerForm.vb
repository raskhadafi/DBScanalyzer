Public Class ScanalyzerForm
    Dim scanalyzer As Scanalyzer
    Private Sub btnScanIPRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanIPRange.Click
        scanalyzer = New Scanalyzer(txtIPRangeBegin.Text, txtIPRangeEnd.Text)
        txtPrintout.Text += scanalyzer.scanIps()
    End Sub
End Class