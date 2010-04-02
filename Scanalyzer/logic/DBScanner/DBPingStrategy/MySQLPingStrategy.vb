Imports MySql.Data.MySqlClient

Public Class MySQLPingStrategy
    Inherits DBPingStrategy

    Private connection As New MySqlConnection
    Private ports As Array


    Public Overrides Function tryAllPorts(ByVal ip As String) As System.Collections.ArrayList
        Dim connectionString As String
        Dim ports(65000)
        Dim port As Integer = 0
        Dim mysqlPorts As ArrayList = New ArrayList
        For Each i In ports
            connectionString = "server=" + ip + ";port=" + port.ToString + ";"
            port += 1
            connection.ConnectionString = connectionString
            Try
                connection.Open()
            Catch ex As MySqlException
                If ex.Number = 1045 Then
                    mysqlPorts.Add(port)
                End If
            End Try
        Next
        Return mysqlPorts
    End Function

    Public Overrides Function tryDefaultPort(ByVal ip As String) As System.Collections.ArrayList
        Return Nothing
    End Function

End Class
