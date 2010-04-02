Imports MySql.Data.MySqlClient

Public Class MySQLAccessStrategy
    Inherits DBAccessStrategy

    Private connection As New MySqlConnection
    Private command As MySqlCommand
    Private connectionString As String

    Public Overrides Function closeConnection() As Boolean

        If connection.State = ConnectionState.Open Then
            connection.Close()
            Return True
        Else
            Return False
        End If

    End Function

    Public Overrides Function getColumn() As System.Collections.ArrayList
        Dim reader As MySqlDataReader
        Dim returnList As New ArrayList
        Try
            command = New MySqlCommand
            command.CommandText = "show databases"
            command.Connection = connection
            command.Prepare()
            reader = command.ExecuteReader()
            While reader.HasRows
                returnList.Add("test")
            End While
        Catch ex As Exception

        End Try
        Return New ArrayList

    End Function

    Public Overrides Function getColumnNames() As System.Collections.ArrayList

        Return New ArrayList

    End Function

    Public Overrides Function getDatabaseNames() As System.Collections.ArrayList

        Return New ArrayList

    End Function

    Public Overrides Function getInformationSchema() As System.Collections.ArrayList

        Return New ArrayList

    End Function

    Public Overrides Function openConnection(ByRef computerIn As Computer, ByVal databaseInstancePosition As Integer) As Boolean
        Dim databaseInstance As DatabaseInstance
        Dim computer As Computer = computerIn
        databaseInstance = computer.getInstance(databaseInstancePosition)

        Me.connectionString = "server=" + computer.getIp() + ";uid=" + databaseInstance.getUser() + ";pwd=" + databaseInstance.getPassword() + ";port=" + databaseInstance.getPort() + ";"

        connection.ConnectionString = Me.connectionString

        Try
            connection.Open()
            Return True
        Catch ex As MySqlException
            Select Case ex.Number
                Case 0
                    MessageBox.Show("Cannot connect to server. Contact administrator")
                Case 1045
                    MessageBox.Show("Invalid username/password, please try again")
            End Select

            Return False
        End Try

    End Function
End Class
