Imports System.Data.OracleClient

Namespace DBScanner

    Namespace DBPingStrategy

        Public Class OraclePingStrategy
            Inherits DBPingStrategy

            Private connection As OracleConnection

            Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As System.Collections.ArrayList) As System.Collections.ArrayList

                Dim connectionString As String
                Dim oraclePorts As ArrayList = New ArrayList

                For Each portNumber In ports

                    Dim answer As Boolean = False
                    Dim dbConn = New ADODB.Connection

                    connectionString = "Data Source=" + ip + ":" + portNumber.ToString
                    'connectionString = "data source=(DESCRIPTION=(ADDRESS= (PROTOCOL=tcp)(HOST=" + ip + ")(PORT=" + portNumber.ToString + "))(CONNECT_DATA=(COMMAND=ping)));"
                    connection = New OracleConnection(connectionString)

                    Try
                        connection.Open()
                    Catch ex As TimeoutException

                    Catch ex As OverflowException

                    Catch ex As OracleException

                        If ex.Code = 18456 Then
                            oraclePorts.Add(portNumber)
                        End If

                    End Try

                Next

                Return oraclePorts

            End Function

        End Class

    End Namespace

End Namespace

