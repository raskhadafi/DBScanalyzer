Public MustInherit Class DBPingStrategy

    Public MustOverride Function tryDefaultPort(ByVal ip As String) As ArrayList
    Public MustOverride Function tryAllPorts(ByVal ip As String) As ArrayList

End Class
