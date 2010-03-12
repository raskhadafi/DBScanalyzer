Public Class DBScanner
    Private pcs As ArrayList

    Public Sub New(ByRef computers As ArrayList)
        pcs = computers
    End Sub

    Public Sub scanPorts()
        For Each pc In pcs
            scanMySQL(pc.getIpAddress())
        Next
    End Sub

    Public Sub scanMySQL(ByRef ip As String)

    End Sub
End Class
