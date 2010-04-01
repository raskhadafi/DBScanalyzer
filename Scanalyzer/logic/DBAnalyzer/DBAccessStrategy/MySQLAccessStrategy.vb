Imports MySql.Data.MySqlClient

Public Class MySQLAccessStrategy
    Inherits DBAccessStrategy

    Private connection As MySqlConnection
    Private connectionString As String
    Private databaseInstance As DatabaseInstance

    Public Overrides Function closeConnection() As Boolean

        If connection.State = ConnectionState.Open Then
            connection.Close()
            Return True
        Else
            Return False
        End If

    End Function

    Public Overrides Function getColumn() As System.Collections.ArrayList
        Return Nothing
    End Function

    Public Overrides Function getColumnNames() As System.Collections.ArrayList
        Return Nothing
    End Function

    Public Overrides Function getDatabaseNames() As System.Collections.ArrayList
        Return Nothing
    End Function

    Public Overrides Function getInformationSchema() As System.Collections.ArrayList
        Return Nothing
    End Function

    Public Overrides Function openConnection(ByRef computer As Computer, ByVal databaseInstance As Integer) As Boolean

        Me.databaseInstance = computer.getInstance(databaseInstance)

        connectionString = "server=" + computer.ip + ";" _
                         & "uid=" + Me.databaseInstance.user + ";" _
                         & "pwd=" + Me.databaseInstance.pwd + ";" _
                         & "port=" + Me.databaseInstance.port + ";"

        connection.ConnectionString = connectionString

        Try
            connection.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
