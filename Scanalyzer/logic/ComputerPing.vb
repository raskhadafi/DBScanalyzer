Imports System.Net
Imports System.Net.NetworkInformation

Public Class ComputerPing

    Public Function pingHost(ByRef ip As String)
        Dim ping As New NetworkInformation.Ping
        Dim pingResponse As NetworkInformation.PingReply
        pingResponse = ping.Send(ip)
        If pingResponse.Status = IPStatus.Success Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
