Imports Oracle.DataAccess.Client

Public Class OraclePingStrategy
    Inherits DBPingStrategy

    Private connection As OracleConnection

    Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As System.Collections.ArrayList) As System.Collections.ArrayList

        Dim connectionString As String
        Dim oraclePorts As ArrayList = New ArrayList

        For Each i In ports
            Dim portNumber As Integer = i
            Dim answer As Boolean = False

            connectionString = "Data Source=" + ip + "," + i.ToString + ";"
            connection = New OracleConnection(connectionString)

            Try
                connection.Open()
            Catch ex As TimeoutException

            Catch ex As OverflowException

            Catch ex As OracleException

                If ex.Number = 18456 Then
                    oraclePorts.Add(i)
                End If

            End Try

        Next

        Return oraclePorts

    End Function

End Class
