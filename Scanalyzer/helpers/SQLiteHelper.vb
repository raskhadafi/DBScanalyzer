Imports System.Data.SQLite

Namespace Helpers

    Public Module SQLiteHelper

        Public Sub getReferenceData(ByVal tableName As String, ByRef entries As ArrayList)

            Try

                Dim connection As New SQLiteConnection()
                Dim sqlreader As SQLiteDataReader
                Dim cmd As SQLiteCommand

                connection.ConnectionString = "Data Source=C:\Dokumente und Einstellungen\Roman\Eigene Dateien\bda\DBScanalyzer\Scanalyzer\db\reference_data.sqlite;Version=3;New=False;Compress=True;"
                ' TODO: sqlite should be generated
                ' connection.ConnectionString = "Data Source=reference_data.sqlite;Version=3;New=False;Compress=True;"
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