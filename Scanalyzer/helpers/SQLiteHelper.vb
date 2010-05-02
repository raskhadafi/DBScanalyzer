Imports System.Data.SQLite

Namespace Helpers

    Public Module SQLiteHelper

        Private connection As SQLiteConnection
        Private sqlreader As SQLiteDataReader
        Private cmd As SQLiteCommand

        Public Sub getReferences(ByRef references As ReferenceSelectionArrayList)

            Dim dbReferences As ArrayList = New ArrayList
            Dim returnArray As New ReferenceSelectionArrayList

            initializeSQLiteConnection()
            executeSQLCommand("SELECT tbl_name FROM sqlite_master WHERE type='table' ORDER BY tbl_name ASC")
            getDataFromQuery(dbReferences, 0)
            dbReferences.Remove("sqlite_sequence")

            For Each dbRef In dbReferences

                Dim dbEntry As Array = dbRef.ToString.Split("_")

                If Not returnArray.checkIfContainsSelection(dbEntry(0)) Then

                    Dim entry As New ReferenceSelection(dbEntry(0))

                    entry.languages.Add(dbEntry(1))
                    returnArray.Add(entry)

                Else

                    Dim entry As ReferenceSelection = returnArray.getReferenceSelection(dbEntry(0))

                    If entry.reference.Contains(dbEntry(0)) Then

                        If Not entry.languages.Contains(dbEntry(1)) Then

                            entry.languages.Add(dbEntry(1))

                        End If

                    End If


                End If

            Next

            references = returnArray

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