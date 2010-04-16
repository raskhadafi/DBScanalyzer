Imports IBM.Data.DB2

Namespace DBScanner

    Namespace DBPingStrategy

        Public Class DB2PingStrategy
            Inherits DBPingStrategy


            Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As System.Collections.ArrayList) As System.Collections.ArrayList

                Dim myConnectionString = "Server=192.168.56.4:50000;Database=testDatabaseThatShouldntBeInstalledOnTheServer;UID=myUsername;PWD=myPassword;"
                Dim myConnection As DB2Connection = New DB2Connection()
                myConnection.ConnectionString = myConnectionString

                Try

                    myConnection.Open()
                    myConnection.Close()

                Catch ex As DB2Exception

                    If Not ex.Message.Contains("communication error") Then
                        Return Nothing
                    End If


                End Try

                Return Nothing

            End Function

        End Class

    End Namespace

End Namespace