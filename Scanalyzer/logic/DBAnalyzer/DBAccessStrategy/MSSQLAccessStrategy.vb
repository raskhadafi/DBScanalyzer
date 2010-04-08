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

    Public Overrides Function openConnection(ByRef computer As Computer, ByVal databaseInstance As Integer) As Boolean

        Return Nothing

    End Function

End Class
