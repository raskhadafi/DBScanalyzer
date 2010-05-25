Imports MySql.Data.MySqlClient
Imports Scanalyzer.Objects

Namespace DBanalyzers

    Namespace DBAccessStrategies

        Class MySQLAccessStrategy
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

            Public Overrides Function getColumnLimited(ByVal databaseName As String, ByVal tableName As String, ByVal columName As String, ByVal fromLimit As Integer, ByVal toLimit As Integer) As ArrayList

                Dim reader As MySqlDataReader
                Dim returnList As New ArrayList

                Try
                    Dim transaction As MySqlTransaction = Me.connection.BeginTransaction

                    command = New MySqlCommand("select " + columName + " from " + databaseName + "." + tableName + " limit " + fromLimit.ToString + "," + toLimit.ToString, connection, transaction)
                    command.UpdatedRowSource = UpdateRowSource.Both
                    reader = command.ExecuteReader

                    While reader.Read()

                        returnList.Add(reader.GetString(columName))

                    End While

                    reader.Close()

                Catch ex As Exception

                End Try

                Return returnList

            End Function

            Public Overrides Function getColumn(ByVal databaseName As String, ByVal tableName As String, ByVal columName As String) As System.Collections.ArrayList

                Dim reader As MySqlDataReader
                Dim returnList As New ArrayList

                Try
                    Dim transaction As MySqlTransaction = Me.connection.BeginTransaction

                    command = New MySqlCommand("select " + columName + " from " + databaseName + "." + tableName, connection, transaction)
                    command.UpdatedRowSource = UpdateRowSource.Both
                    reader = command.ExecuteReader

                    While reader.Read()

                        returnList.Add(reader.GetString(columName))

                    End While

                    reader.Close()

                Catch ex As Exception

                End Try

                Return returnList

            End Function

            Public Overrides Function getTableCount(ByVal databaseName As String, ByVal tableName As String) As Integer

                Dim reader As MySqlDataReader
                Dim returnList As New ArrayList
                Dim count As Integer = 0

                Try

                    command = New MySqlCommand
                    command.CommandText = "select count(*) from " + databaseName + "." + tableName
                    command.Connection = connection
                    command.Prepare()
                    reader = command.ExecuteReader()

                    While reader.Read

                        count = reader.GetValue(0)

                    End While

                    reader.Close()

                Catch ex As Exception

                End Try

                Return count

            End Function

            Public Overrides Function getColumnNames(ByVal databaseName As String, ByVal tableName As String) As System.Collections.ArrayList

                Dim reader As MySqlDataReader
                Dim returnList As New ArrayList

                Try
                    command = New MySqlCommand
                    command.CommandText = "show columns from " + tableName + " from " + databaseName
                    command.Connection = connection
                    command.Prepare()
                    reader = command.ExecuteReader()

                    While reader.Read
                        returnList.Add(reader.GetValue(reader.GetOrdinal("Field")))
                    End While

                    reader.Close()
                Catch ex As Exception
                    Return returnList
                End Try

                Return returnList

            End Function

            Public Overrides Function getDatabaseNames() As System.Collections.ArrayList

                Dim reader As MySqlDataReader
                Dim returnList As New ArrayList

                Try
                    command = New MySqlCommand
                    command.CommandText = "show databases"
                    command.Connection = connection
                    command.Prepare()
                    reader = command.ExecuteReader()

                    While reader.Read
                        returnList.Add(reader.GetValue(reader.GetOrdinal("Database")))
                    End While

                    reader.Close()
                Catch ex As Exception
                    Return returnList
                End Try

                removeMysqlDatabases(returnList)

                Return returnList

            End Function

            Public Overrides Function getInformationSchema() As System.Collections.ArrayList

                Return New ArrayList

            End Function

            Public Overrides Function openConnection(ByRef computerIn As Computer, ByVal databaseInstance As DatabaseInstance) As Boolean

                Dim computer As Computer = computerIn

                Me.connectionString = "server=" + computer.getIp() + ";uid=" + databaseInstance.getUser() + ";pwd=" + databaseInstance.getPassword() + ";port=" + databaseInstance.getPort().ToString + ";"
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

            Public Overrides Function getTableNames(ByVal databaseName As String) As System.Collections.ArrayList

                Dim reader As MySqlDataReader
                Dim returnList As New ArrayList

                Try
                    command = New MySqlCommand
                    command.CommandText = "show tables from " + databaseName
                    command.Connection = connection
                    command.Prepare()
                    reader = command.ExecuteReader()

                    While reader.Read
                        returnList.Add(reader.GetValue(reader.GetOrdinal("Tables_in_" + databaseName)))
                    End While

                    reader.Close()
                Catch ex As Exception
                    Return returnList
                End Try

                Return returnList

            End Function

            Private Sub removeMysqlDatabases(ByRef databases As ArrayList)

                databases.Remove("mysql")
                databases.Remove("information_schema")

            End Sub

        End Class

    End Namespace

End Namespace
