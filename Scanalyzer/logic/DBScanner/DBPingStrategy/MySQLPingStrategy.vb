Imports MySql.Data.MySqlClient

Public Class MySQLPingStrategy
    Inherits DBPingStrategy

    Private connection As New MySqlConnection


    Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As ArrayList) As System.Collections.ArrayList
        Dim connectionString As String
        Dim mysqlPorts As ArrayList = New ArrayList

        For Each i In ports
            Dim portNumber As Integer = i
            Dim answer As Boolean = False
            connectionString = "server=" + ip + ";port=" + i.ToString + ";"
            connection.ConnectionString = connectionString
            Try
                connection.Open()
            Catch ex As TimeoutException

            Catch ex As MySqlException
                If ex.Number = 1045 Then
                    mysqlPorts.Add(i)
                End If
            End Try
        Next
        Return mysqlPorts
    End Function

End Class
