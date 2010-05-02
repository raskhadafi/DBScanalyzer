Imports System.Data.SQLite

Namespace Helpers

    Public Module SQLiteHelper

        Private connection As SQLiteConnection
        Private sqlreader As SQLiteDataReader
        Private cmd As SQLiteCommand

        Public Sub getReferences(ByRef references As Array)

            Dim returnReferences As ArrayList = New ArrayList

            initializeSQLiteConnection()
            executeSQLCommand("SELECT tbl_name FROM sqlite_master WHERE type='table' ORDER BY tbl_name ASC")
            getDataFromQuery(returnReferences, 0)
            returnReferences.Remove("sqlite_sequence")
            references = returnReferences.ToArray

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

        Private Sub getDataFromQuery(ByRef entries As ArrayList, ByVal columnPosition As Integer)

            While sqlreader.Read

                entries.Add(sqlreader(columnPosition))

            End While

        End Sub

        Private Sub closeSQLiteConnection()

            connection.Close()

        End Sub

        Public Sub getReferenceData(ByVal tableName As String, ByRef entries As ArrayList)

            Try

                initializeSQLiteConnection()
                executeSQLCommand("select value from " + tableName)
                getDataFromQuery(entries, 0)
                closeSQLiteConnection()

            Catch ex As Exception

            End Try

        End Sub

    End Module

End Namespace