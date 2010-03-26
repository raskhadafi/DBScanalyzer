Public MustInherit Class DBPingStrategy

    Public MustOverride Function tryDefaultPort(ByRef ip As String) As ArrayList
    Public MustOverride Function tryAllPorts(ByRef ip As String) As ArrayList

End Class
