Imports System.Data.SqlClient

Namespace DBScanner

    Namespace DBPingStrategies

        Public Class MSSQLPingStrategy
            Inherits DBPingStrategy

            Private connection As SqlConnection

            Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As System.Collections.ArrayList) As System.Collections.ArrayList

                Dim connectionString As String
                Dim mssqlPorts As ArrayList = New ArrayList

                For Each i In ports
                    Dim portNumber As Integer = i
                    Dim answer As Boolean = False

                    connectionString = "Data Source=" + ip + "," + i.ToString + ";"
                    connection = New SqlConnection(connectionString)

                    Try
                        connection.Open()
                    Catch ex As TimeoutException

                    Catch ex As OverflowException

                    Catch ex As SqlException

                        If ex.Number = 18456 Then
                            mssqlPorts.Add(i)
                        End If

                    End Try

                Next

                Return mssqlPorts

            End Function

        End Class

    End Namespace

End Namespace
