Imports System.Data.SqlClient
Imports Scanalyzer.Objects

Namespace DBanalyzers

    Namespace DBAccessStrategies

        Class MSSQLAccessStrategy
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

            Public Overrides Function getColumnLimited(ByVal databaseName As String, ByVal tableName As String, ByVal columName As String, ByVal fromLimit As Integer, ByVal toLimit As Integer) As ArrayList

                Dim reader As SqlDataReader
                Dim returnList As New ArrayList

                Try

                    Dim transaction As SqlTransaction = Me.connection.BeginTransaction
                    Dim amount As Integer = toLimit - fromLimit
                    Dim conn As String = "USE " + databaseName + ";SELECT TOP " + amount.ToString + " [" + columName + "] FROM (SELECT *, ROW_NUMBER() OVER ( ORDER BY (SELECT kcu.COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc ON kcu.CONSTRAINT_CATALOG = tc.CONSTRAINT_CATALOG AND kcu.CONSTRAINT_SCHEMA = tc.CONSTRAINT_SCHEMA AND kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME WHERE tc.CONSTRAINT_TYPE = 'PRIMARY KEY' AND tc.TABLE_NAME = '" + tableName + "' ) ) as row_number FROM " + tableName + " ) foo WHERE row_number > " + fromLimit.ToString + ";"

                    command = New SqlCommand(conn, connection, transaction)
                    command.UpdatedRowSource = UpdateRowSource.Both
                    reader = command.ExecuteReader

                    While reader.Read()

                        returnList.Add(reader.GetValue(reader.GetOrdinal(columName)).ToString)

                    End While

                    reader.Close()

                Catch ex As Exception

                End Try

                Return returnList

            End Function

            Public Overrides Function getColumn(ByVal databaseName As String, ByVal tableName As String, ByVal columName As String) As System.Collections.ArrayList

                Dim reader As SqlDataReader
                Dim returnList As New ArrayList

                Try

                    Dim transaction As SqlTransaction = Me.connection.BeginTransaction

                    command = New SqlCommand("USE " + databaseName + ";SELECT " + columName + " FROM " + tableName, connection, transaction)
                    command.UpdatedRowSource = UpdateRowSource.Both
                    reader = command.ExecuteReader

                    While reader.Read()

                        returnList.Add(reader.GetValue(reader.GetOrdinal(columName)))

                    End While

                    reader.Close()

                Catch ex As Exception

                End Try

                Return returnList

            End Function

            Public Overrides Function getTableCount(ByVal databaseName As String, ByVal tableName As String) As Integer

                Return 1

            End Function

            Public Overrides Function getColumnNames(ByVal databaseName As String, ByVal tableName As String) As System.Collections.ArrayList

                Dim reader As SqlDataReader
                Dim returnList As New ArrayList

                Try

                    command = New SqlCommand
                    command.CommandText = "USE " + databaseName + ";EXEC sp_columns " + tableName + ";"
                    command.Connection = connection
                    command.Prepare()
                    reader = command.ExecuteReader()

                    While reader.Read

                        returnList.Add(reader.GetValue(reader.GetOrdinal("COLUMN_NAME")))

                    End While

                    reader.Close()

                Catch ex As Exception

                    Return returnList

                End Try

                Return returnList

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

                Dim reader As SqlDataReader
                Dim returnList As New ArrayList

                Try

                    command = New SqlCommand
                    command.CommandText = "USE " + databaseName + ";EXEC sp_tables;"
                    command.Connection = connection
                    command.Prepare()
                    reader = command.ExecuteReader()

                    While reader.Read

                        Dim owner As String = reader.GetValue(reader.GetOrdinal("TABLE_OWNER"))

                        If Not (owner = "sys" Or owner = "INFORMATION_SCHEMA") Then

                            returnList.Add(reader.GetValue(reader.GetOrdinal("TABLE_NAME")))

                        End If

                    End While

                    reader.Close()

                Catch ex As Exception

                    Return returnList

                End Try

                Return returnList

            End Function

            Public Overrides Function openConnection(ByRef computer As Computer, ByVal databaseInstance As DatabaseInstance) As Boolean

                Me.connectionString = "Data Source=" + computer.getIp + "," + databaseInstance.getPort.ToString + ";User Id=" + databaseInstance.getUser + ";Password=" + databaseInstance.getPassword + ";"
                connection = New SqlConnection(Me.connectionString)

                Try
                    connection.Open()

                    Return True

                Catch ex As SqlException

                End Try

                Return False

            End Function

        End Class

    End Namespace

End Namespace
