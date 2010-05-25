Namespace DBanalyzers

    Friend Class DataAnalyzer

        Private computers As List(Of Objects.Computer)
        Private settings As Helpers.Setting

        Public Sub New(ByRef computers As List(Of Objects.Computer), ByVal settings As Helpers.Setting)

            Me.computers = computers
            Me.settings = settings

        End Sub

        Public Sub analyzeColumnData()

            For Each computer In Me.computers

                For Each databaseInstance In computer.getDatabaseInstances

                    For Each database In databaseInstance.getDatabases

                        

                        For Each table In database.getTables

                            Dim access As DBAccessStrategies.DBAccessStrategy
                            Dim tableCount As Integer = 0

                            access = Helpers.Helper.getDBAccessStrategy(databaseInstance.getDatabaseType)
                            access.openConnection(computer, databaseInstance)
                            tableCount = access.getTableCount(database.getName, table.getName)
                            access.closeConnection()

                            If tableCount > 0 Then

                                For Each column In table.getColumns

                                    analyze(computer, databaseInstance, database, table, column, tableCount)

                                Next

                            End If

                        Next

                    Next

                Next

            Next

        End Sub

        Private Sub analyze(ByVal computer As Objects.Computer, ByVal databaseInstance As Objects.DatabaseInstance, ByRef database As Objects.Database, ByRef table As Objects.Table, ByRef column As Objects.Column, ByVal tableCount As Integer)

            Dim access As DBAccessStrategies.DBAccessStrategy
            Dim entries As List(Of String) = New List(Of String)
            Dim entriesFromDB As ArrayList
            Dim value As Boolean = Nothing
            Dim total As Integer = 0
            Dim totalFound As Integer = 0
            Dim checkIfDateTotal As Integer = 0
            Dim checkIfEmailTotal As Integer = 0
            Dim checkIfGenderTotal As Integer = 0
            Dim checkIfStreetTotal As Integer = 0

            access = Helpers.Helper.getDBAccessStrategy(databaseInstance.getDatabaseType)
            access.openConnection(computer, databaseInstance)

            For i As Integer = 0 To tableCount Step 100
                entriesFromDB = access.getColumnLimited(database.getName, table.getName, column.getName, i, (i + 99))
                For Each entry In entriesFromDB

                    For Each metric In Me.settings.getSelectedMetrics

                        Select Case metric

                            Case Helpers.Settings.Metric.checkIfDate

                                If Metrics.checkIfDate(entry) Then

                                    checkIfDateTotal += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfEmail

                                If Metrics.checkIfEmail(entry) Then

                                    checkIfEmailTotal += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfGender

                                If Metrics.checkIfGender(entry) Then

                                    checkIfGenderTotal += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfStreet

                                If Metrics.checkIfStreet(entry) Then

                                    checkIfStreetTotal += 1

                                End If

                        End Select

                    Next

                Next

                access.closeConnection()

                If checkIfDateTotal > checkIfEmailTotal & checkIfDateTotal > checkIfGenderTotal & checkIfDateTotal > checkIfEmailTotal Then

                    totalFound = checkIfDateTotal

                ElseIf checkIfEmailTotal > checkIfDateTotal & checkIfEmailTotal > checkIfGenderTotal & checkIfEmailTotal > checkIfStreetTotal Then

                    totalFound = checkIfEmailTotal

                ElseIf checkIfGenderTotal > checkIfDateTotal & checkIfGenderTotal > checkIfEmailTotal & checkIfGenderTotal > checkIfStreetTotal Then

                    totalFound = checkIfGenderTotal

                ElseIf checkIfStreetTotal > checkIfDateTotal & checkIfStreetTotal > checkIfEmailTotal & checkIfStreetTotal > checkIfGenderTotal Then

                    totalFound = checkIfStreetTotal

                Else

                    totalFound = 0

                End If

                If checkIfEmailTotal > 0 Then

                    totalFound = checkIfEmailTotal

                End If

                If total > 0 & totalFound > 0 Then

                    totalFound = totalFound / total

                End If

                column.setFound(totalFound)

            Next

        End Sub

    End Class

End Namespace
