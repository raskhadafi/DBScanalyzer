Imports System.Data.SQLite
Imports Scanalyzer.Helpers.Settings

Namespace Helpers

    Public Module SQLiteHelper

        Private connection As SQLiteConnection
        Private sqlreader As SQLiteDataReader
        Private cmd As SQLiteCommand

        Public Sub getReferences(ByRef references As Settings.ReferenceSelectionArrayList)

            Dim dbReferences As List(Of String) = New List(Of String)
            Dim returnArray As New ReferenceSelectionArrayList

            initializeSQLiteConnection()
            executeSQLCommand("select table_name from referencebasisdata")
            getDataFromQuery(dbReferences, 0)

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

        Private Sub getDataFromQuery(ByRef entries As List(Of String), ByVal columnPosition As Integer)

            While sqlreader.Read

                entries.Add(sqlreader(columnPosition))

            End While

        End Sub

        Private Sub closeSQLiteConnection()

            connection.Close()

        End Sub

        Public Sub getReferenceData(ByVal tableName As String, ByRef entries As List(Of String))

            Try

                initializeSQLiteConnection()
                executeSQLCommand("select value from " + tableName)
                getDataFromQuery(entries, 0)
                closeSQLiteConnection()

            Catch ex As Exception

            End Try

        End Sub

        Public Sub getReferencedataForMetrics(ByVal metricName As String, ByRef entries As List(Of String))

            Try

                initializeSQLiteConnection()
                executeSQLCommand("SELECT table_name FROM metric_data where name = " + metricName)
                getDataFromQuery(entries, 0)
                closeSQLiteConnection()

            Catch ex As Exception

            End Try

        End Sub

    End Module

End Namespace