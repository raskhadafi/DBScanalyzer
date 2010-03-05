Public Class MainForm
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim simplePingForm As New SimplePing()
        simplePingForm.Show()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ipRangePingForm As New PingIPRange()
        ipRangePingForm.Show()
    End Sub
End Class
