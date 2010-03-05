Imports System.Net
Imports System.Net.NetworkInformation

Public Class PingIPRange
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ping As New NetworkInformation.Ping
        Dim pingResponse As NetworkInformation.PingReply
        Dim ipAdresse As String
        ipAdresse = txtIPAdresse.Text
        pingResponse = ping.Send(ipAdresse, 50)
        If pingResponse Is Nothing Then
            txtOutput.Text += "No reply" + Environment.NewLine
        ElseIf pingResponse.Status = IPStatus.Success Then
            txtOutput.Text += "Reply from " + pingResponse.Address.ToString() + Environment.NewLine
        Else
            txtOutput.Text += "Ping was unsuccessful: " + pingResponse.Status.ToString() + Environment.NewLine
        End If
    End Sub
End Class