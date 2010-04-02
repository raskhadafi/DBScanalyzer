Public Class MySQLPingStrategy
    Inherits DBPingStrategy


    Public Overrides Function tryAllPorts(ByRef ip As String) As System.Collections.ArrayList
        Return Nothing
    End Function

    Public Overrides Function tryDefaultPort(ByRef ip As String) As System.Collections.ArrayList
        Return Nothing
    End Function

End Class
