Imports Oracle.DataAccess.Client
'Imports System.Data.OracleClient

Namespace DBScanners

    Namespace DBPingStrategies

        Public Class OraclePingStrategy
            Inherits DBPingStrategy

            Private connection As OracleConnection

            Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As System.Collections.ArrayList) As System.Collections.ArrayList

                Dim connectionString As String
                Dim oraclePorts As ArrayList = New ArrayList

                For Each portNumber In ports

                    connectionString = "Data Source=" + ip + ":" + portNumber.ToString + ";Pooling=False;Connection Lifetime=2;"
                    Me.connection = New OracleConnection(connectionString)

                    Try

                        Me.connection.Open()

                    Catch ex As OracleException

                        If ex.ErrorCode = 18456 Then

                            oraclePorts.Add(portNumber)

                        End If

                    End Try

                Next

                Return oraclePorts

            End Function

        End Class

    End Namespace

End Namespace

