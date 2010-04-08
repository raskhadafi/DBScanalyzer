﻿Imports MySql.Data.MySqlClient

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

    Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As ArrayList) As System.Collections.ArrayList
        Dim connectionString As String
        Dim mysqlPorts As ArrayList = New ArrayList
        Dim timer As Timer = New Timer
        timer.Interval = 5000
        timer.

        For Each i In ports
            Dim portNumber As Integer = i
            Dim answer As Boolean = False
            connectionString = "server=" + ip + ";port=" + i.ToString + ";"
            connection.ConnectionString = connectionString
            Try
                connection.Open()
            Catch ex As MySqlException
                If ex.Number = 1045 Then
                    mysqlPorts.Add(i)
                End If
            End Try
        Next
        Return mysqlPorts
    End Function

    Public Overrides Function tryDefaultPort(ByVal ip As String) As System.Collections.ArrayList
        Return Nothing
    End Function

End Class
