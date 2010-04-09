Imports System.Data.SqlClient

Public Class MSSQLAccessStrategy
    Inherits DBAccessStrategy

    Private connection As SqlConnection
    Private command As SqlCommand
    Private connectionString As String

    Public Overrides Function closeConnection() As Boolean

        If connection.State = ConnectionState.Open Then
            connection.Close()
            Return True
        Else
            Return False
        End If

    End Function

    Public Overrides Function getColumn(ByVal databaseName As String, ByVal tableName As String, ByVal columName As String) As System.Collections.ArrayList

        Return Nothing

    End Function

    Public Overrides Function getColumnNames(ByVal databaseName As String, ByVal tableName As String) As System.Collections.ArrayList

        Return Nothing

    End Function

    Public Overrides Function getDatabaseNames() As System.Collections.ArrayList

        Dim reader As SqlDataReader
        Dim returnList As New ArrayList

        Try
            command = New SqlCommand
            command.CommandText = "EXEC sp_databases"
            command.Connection = connection
            command.Prepare()
            reader = command.ExecuteReader()

            While reader.Read
                returnList.Add(reader.GetValue(reader.GetOrdinal("DATABASE_NAME")))
            End While

            reader.Close()
        Catch ex As Exception
            Return returnList
        End Try

        removeStandardDatabases(returnList)

        Return returnList

    End Function

    Private Sub removeStandardDatabases(ByRef list As ArrayList)
        list.Remove("master")
        list.Remove("model")
        list.Remove("msdb")
        list.Remove("tempdb")
    End Sub

    Public Overrides Function getInformationSchema() As System.Collections.ArrayList

        Return Nothing

    End Function

    Public Overrides Function getTableNames(ByVal databaseName As String) As System.Collections.ArrayList

        Return Nothing

    End Function

    Public Overrides Function openConnection(ByRef computer As Computer, ByVal databaseInstancePosition As Integer) As Boolean

        Dim databaseInstance As DatabaseInstance = computer.getInstance(databaseInstancePosition)

        Me.connectionString = "Data Source=" + computer.getIp + "," + databaseInstance.getPort + ";User Id=" + databaseInstance.getUser + ";Password=" + databaseInstance.getPassword + ";"
        connection = New SqlConnection(Me.connectionString)

        Try
            connection.Open()
            Return True
        Catch ex As SqlException

        End Try

        Return False

    End Function

End Class
