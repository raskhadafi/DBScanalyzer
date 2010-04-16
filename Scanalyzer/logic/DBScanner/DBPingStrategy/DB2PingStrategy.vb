Imports System.Data.Odbc

Namespace DBScanner

    Namespace DBPingStrategy

        Public Class DB2PingStrategy
            Inherits DBPingStrategy


            Public Overrides Function checkPorts(ByVal ip As String, ByVal ports As System.Collections.ArrayList) As System.Collections.ArrayList

                Dim builder As New OdbcConnectionStringBuilder()
                builder.ConnectionString = "Provider=DB2OLEDB;Network Transport Library=TCPIP;Network Address=192.168.56.4;User ID=hr;Password=test;"
                Using connection As New OdbcConnection(builder.ConnectionString)
                    connection.Open()
                End Using

                Return Nothing

            End Function

        End Class

    End Namespace

End Namespace