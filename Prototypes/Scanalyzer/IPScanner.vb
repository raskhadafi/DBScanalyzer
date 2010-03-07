Imports System.Net.NetworkInformation

Public Class IPScanner
    Private ips() As String
    Private computers As New ArrayList()

    Public Sub New(ByRef ipsOfRange() As String)
        ips = ipsOfRange
    End Sub

    Public Function getComputers()
        For i As Integer = 0 To ips.Length - 1
            Dim ping As New Ping
            Dim pingResponse As PingReply
            pingResponse = ping.Send(ips(i), 50)
            If pingResponse.Status = IPStatus.Success Then
                computers.Add(New Computer(ips(i)))
            End If
        Next
        Return computers
    End Function
End Class
