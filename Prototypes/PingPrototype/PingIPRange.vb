Imports System.Net
Imports System.Net.NetworkInformation

Public Class PingIPRange
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ping As New NetworkInformation.Ping
        'Dim pingResponse As NetworkInformation.PingReply
        Dim ipRangeStart(3) As Integer
        Dim ipRangeEnd(3) As Integer
        'Dim ips()() As Integer
        Dim startIpInput(), endIpInput() As String
        startIpInput = Split(txtIPRangeStart.Text, ".")
        endIpInput = Split(txtIPRangeEnd.Text, ".")
        For index As Integer = 0 To 3
            ipRangeStart(index) = Convert.ToInt32(startIpInput(index))
            ipRangeEnd(index) = Convert.ToInt32(endIpInput(index))
        Next
        createIPs(ipRangeStart, ipRangeEnd)
    End Sub
    ' creates array with ips from ip range
    Private Sub createIPs(ByVal startIP() As Integer, ByVal endIP() As Integer)
        Dim ips()() As Integer
        Dim count As Integer
        count = (endIP(0) - startIP(0)) * 255 * 255 * 255 + (endIP(1) - startIP(1)) * 255 * 255 + (endIP(2) - startIP(2)) * 255 + (endIP(3) - startIP(3))
        ReDim ips(0)
        If startIP(3) = endIP(3) Then
            ReDim ips(0)(3)
            For index As Integer = 0 To 3
                ips(0)(index) = startIP(index)
            Next
            Exit Sub
        End If
        ReDim ips(count)
        ReDim ips(count)(3)
    End Sub
End Class