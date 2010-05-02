Imports System.Data.SQLite

Namespace Helpers

    Public Module SQLiteHelper

        Public Sub getReferenceData(ByVal tableName As String, ByRef entries As ArrayList)

            Try

                Dim connection As New SQLiteConnection()
                Dim sqlreader As SQLiteDataReader
                Dim cmd As SQLiteCommand

                connection.ConnectionString = "Data Source=|DataDirectory|\db\reference_data.sqlite;"
                connection.Open()
                cmd = connection.CreateCommand
                cmd.CommandText = "select value from " + tableName
                sqlreader = cmd.ExecuteReader()

                While sqlreader.Read

                    entries.Add(sqlreader(0))

                End While

                connection.Close()

            Catch ex As Exception

            End Try

        End Sub

    End Module

End Namespace