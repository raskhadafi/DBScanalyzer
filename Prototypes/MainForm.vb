Public Class MainForm
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim simplePingForm As New SimplePing()
        simplePingForm.Show()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ipRangePingForm As New PingIPRange()
        ipRangePingForm.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim scanalyzerForm As New ScanalyzerForm()
        scanalyzerForm.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cmdPingForm As New cmdPing()
        cmdPingForm.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim connectForm As New Samples.ConnectForm()
        connectForm.Show()
    End Sub
End Class
