Imports IBM.Data.DB2

Namespace DBScanner

    Namespace DBPingStrategies

        Public Class DB2PingStrategy
            Inherits DBPingStrategy

            Private connection As DB2Connection

            Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As System.Collections.ArrayList) As System.Collections.ArrayList

                'Dim myConnectionString As String
                Dim db2Ports As ArrayList = New ArrayList

                Me.connection = New DB2Connection()

                For Each port In ports

                    Dim myConnectionString = "Server=" + ip + ":" + port.ToString + ";Database=testDatabaseThatShouldntBeInstalledOnTheServer;UID=myUsername;PWD=myPassword;Connection Timeout=1;"
                    Me.connection.ConnectionString = myConnectionString

                    Try

                        Me.connection.Open()
                        Me.connection.Close()

                    Catch ex As DB2Exception

                        If Not ex.Message.Contains("communication error") Then

                            db2Ports.Add(port)

                        End If

                    Catch ex As Exception



                    End Try

                Next

                Return db2Ports

            End Function

        End Class

    End Namespace

End Namespace