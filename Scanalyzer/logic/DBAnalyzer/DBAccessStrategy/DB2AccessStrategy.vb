Imports IBM.Data.DB2
Imports Scanalyzer.Objects

Namespace DBanalyzers

    Namespace DBAccessStrategies

        Class DB2AccessStrategy
            Inherits DBAccessStrategy

            Private connection As New DB2Connection
            Private command As DB2Command
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

                MessageBox.Show("Due security reasons of DB2 this function is not implemented.")

                Return Nothing

            End Function

            Public Overrides Function getInformationSchema() As System.Collections.ArrayList

                Return Nothing

            End Function

            Public Overrides Function getTableNames(ByVal databaseName As String) As System.Collections.ArrayList

                Dim command As DB2Command = New DB2Command("SHOW TABLES FROM " + databaseName + ";", Me.connection)
                Dim returnList As New ArrayList

                Try

                    Dim reader As DB2DataReader = command.ExecuteReader()

                    While reader.Read
                        returnList.Add(reader.GetString(0))
                    End While

                Catch ex As Exception

                End Try

                Return returnList

            End Function

            Public Overrides Function openConnection(ByRef computerIn As Objects.Computer, ByVal databaseInstancePosition As Integer) As Boolean

                Dim databaseInstance As DatabaseInstance
                Dim computer As Computer = computerIn

                databaseInstance = computer.getInstance(databaseInstancePosition)
                Me.connectionString = "Server=" + computer.getIp() + ":" + databaseInstance.getPort().ToString + ";Database=" + databaseInstance.getName() + ";UID=" + databaseInstance.getUser() + ";PWD=" + databaseInstance.getPassword() + ";"
                Me.connection = New DB2Connection(Me.connectionString)

                Try
                    connection.Open()
                    Return True
                Catch ex As DB2Exception

                    Return False

                End Try

            End Function

        End Class

    End Namespace

End Namespace
