Namespace DBScanner

    Namespace DBPingStrategies

        Public MustInherit Class DBPingStrategy

            Public MustOverride Function checkPorts(ByVal ip As String, ByVal ports As ArrayList) As ArrayList

        End Class

    End Namespace

End Namespace