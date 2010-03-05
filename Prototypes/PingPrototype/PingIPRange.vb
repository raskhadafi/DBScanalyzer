Imports System.Net
Imports System.Net.NetworkInformation

Public Class PingIPRange
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ping As New NetworkInformation.Ping
        Dim pingResponse As NetworkInformation.PingReply
        'Dim ipRangeStart As String
        'Dim ipRangeEnd As String
        Dim ips() As String

        ips = createIPs(txtIPRangeStart.Text, txtIPRangeEnd.Text)
        'ipRangeEnd = txtIPRangeEnd.Text
        For Each ip In ips
            txtOutput.Text += "--------------" + Environment.NewLine
            txtOutput.Text += "ping: " + ip.ToString + Environment.NewLine
            pingResponse = ping.Send(ip, 50)
            If pingResponse Is Nothing Then
                txtOutput.Text += "No reply" + Environment.NewLine
            ElseIf pingResponse.Status = IPStatus.Success Then
                txtOutput.Text += "Reply from " + pingResponse.Address.ToString() + Environment.NewLine
            Else
                txtOutput.Text += "Ping was unsuccessful: " + pingResponse.Status.ToString() + Environment.NewLine
            End If
            txtOutput.Text += "--------------" + Environment.NewLine
        Next ip
    End Sub
    ' creates array with ips from ip range
    Private Function createIPs(ByVal startIP As String, ByVal endIP As String)
        Dim datas(0) As String
        Dim startIpArray(4) As String
        Dim endIpArray(4) As String
        Dim i As Integer

        If startIP = endIP Then
            datas(0) = startIP
            Return datas
        End If

        i = 0
        startIpArray = Split(startIP, ".")
        endIpArray = Split(endIP, ".")

        For first As Integer = startIpArray(0) To endIpArray(0)
            For second As Integer = startIpArray(1) To endIpArray(1)
                For third As Integer = startIpArray(2) To endIpArray(2)
                    For fourth As Integer = startIpArray(3) To endIpArray(3)
                        i += 1
                    Next
                Next
            Next
        Next
        i = i - 1
        ReDim datas(0 To i)
        i = 0
        For first As Integer = startIpArray(0) To endIpArray(0)
            For second As Integer = startIpArray(1) To endIpArray(1)
                For third As Integer = startIpArray(2) To endIpArray(2)
                    For fourth As Integer = startIpArray(3) To endIpArray(3)
                        datas(i) = first.ToString + "." + second.ToString + "." + third.ToString + "." + fourth.ToString
                        i += 1
                    Next
                Next
            Next
        Next

        Return datas
    End Function
End Class