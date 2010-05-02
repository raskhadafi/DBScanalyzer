Imports System.Data.SQLite

Namespace Helpers

    Public Module SQLiteHelper

        Private connection As SQLiteConnection
        Private sqlreader As SQLiteDataReader
        Private cmd As SQLiteCommand

        Public Sub getReferences(ByRef references As Array)



        End Sub

        Private Sub initializeSQLiteConnection()

            connection = New SQLiteConnection()

            connection.ConnectionString = "Data Source=C:\Dokumente und Einstellungen\Roman\Eigene Dateien\bda\DBScanalyzer\Scanalyzer\db\reference_data.sqlite;Version=3;New=False;Compress=True;"
            ' TODO: sqlite should be generated
            ' connection.ConnectionString = "Data Source=reference_data.sqlite;Version=3;New=False;Compress=True;"
            connection.Open()

        End Sub

        Private Sub executeSQLCommand(ByVal sqlStatement As String)

            cmd = connection.CreateCommand
            cmd.CommandText = sqlStatement
            sqlreader = cmd.ExecuteReader()

        End Sub

        Private Sub closeSQLiteConnection()

            connection.Close()

        End Sub

        Public Sub getReferenceData(ByVal tableName As String, ByRef entries As ArrayList)

            Try

                initializeSQLiteConnection()
                executeSQLCommand("select value from " + tableName)

                While sqlreader.Read

                    entries.Add(sqlreader(0))

                End While

                closeSQLiteConnection()

            Catch ex As Exception

            End Try

        End Sub

    End Module

End Namespace