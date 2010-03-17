Imports System.IO

Imports System.Text.RegularExpressions

Public Class cmdPing
    Private computers As New ArrayList()
    Private dbScanner As New DBScanner()

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dbScanner.scanIPRange(txtIPRange.Text, computers)
        txtIPRange.Text = "db scan done"
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dbScanner.scanIPRangeStubTest(nmapOutputText.Text, computers)
        txtIPRange.Text = "db scan done with stub"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub
End Class