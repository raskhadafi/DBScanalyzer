Public Class Scanalyzer
    Private startIpRange, endIpRange As String
    Private amountOfIps As Integer
    Private ips() As String
    Private startIp(3), endIp(3) As Integer
    Private ipScanner As DBAnalyzer
    Private computers As New ArrayList()

    Public Sub New(ByVal startIp As String, ByVal endIp As String)
        startIpRange = startIp
        endIpRange = endIp
        amountOfIps = getAmountOfIps()
        createIps()
    End Sub

    Private Sub createIps()
        ReDim ips(amountOfIps)
        For i As Integer = 0 To amountOfIps
            ips(i) = startIp(0).ToString + "." + startIp(1).ToString + "." + startIp(2).ToString + "." + (startIp(3) + i).ToString
        Next
    End Sub

    Public Function scanIps()
        'ipScanner = New DBAnalyzer(ips)
        'computers = ipScanner.getComputers()
        Return printIpScanResult()
    End Function

    Public Function scanPorts()
        Return printPortScanResult()
    End Function

    Private Function printPortScanResult()
        Return "portscan done" + Environment.NewLine
    End Function

    Private Function printIpScanResult()
        Dim text As String
        text = "scan finished" + Environment.NewLine
        For Each computer In computers
            text += "IP: " + computer.getIpAddress + Environment.NewLine
        Next
        Return text
    End Function

    Private Function getAmountOfIps()
        Dim count As Integer
        Dim startIpInput(3), endIpInput(3) As String
        startIpInput = Split(startIpRange, ".")
        endIpInput = Split(endIpRange, ".")
        count = 0
        For i As Integer = 0 To 3
            startIp(i) = Convert.ToInt32(startIpInput(i))
            endIp(i) = Convert.ToInt32(endIpInput(i))
        Next
        count = (endIp(0) - startIp(0)) * 255 * 255 * 255 + (endIp(1) - startIp(1)) * 255 * 255 + (endIp(2) - startIp(2)) * 255 + (endIp(3) - startIp(3))
        Return count
    End Function

End Class
