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

        Return Nothing

    End Function

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
