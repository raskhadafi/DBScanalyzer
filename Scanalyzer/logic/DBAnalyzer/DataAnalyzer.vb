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

        Public Sub calculateReport()

            For Each computer In Me.computers

                For Each databaseInstance In computer.getDatabaseInstances

                    For Each database In databaseInstance.getDatabases

                        For Each table In database.getTables

                            For Each column In table.getColumns



                            Next

                        Next

                    Next

                Next

            Next

        End Sub

        Private Sub analyze(ByVal computer As Objects.Computer, ByVal databaseInstance As Objects.DatabaseInstance, ByRef database As Objects.Database, ByRef table As Objects.Table, ByRef column As Objects.Column, ByVal tableCount As Integer)

            Dim access As DBAccessStrategies.DBAccessStrategy
            Dim entries As List(Of String) = New List(Of String)
            Dim entriesFromDB As ArrayList
            Dim totalToAnalyze As Integer
            Dim value As Boolean = Nothing
            Dim total As Integer = 0
            Dim totalFound As Integer = 0
            Dim checkIfDateTotal As Integer = 0
            Dim checkIfEmailTotal As Integer = 0
            Dim checkIfGenderTotal As Integer = 0
            Dim checkIfStreetTotal As Integer = 0


            If Me.settings.analyzeEverthing Then

                totalToAnalyze = tableCount

            Else

                totalToAnalyze = Me.settings.getDataAnalyzationLimit

            End If


            access = Helpers.Helper.getDBAccessStrategy(databaseInstance.getDatabaseType)
            access.openConnection(computer, databaseInstance)

            For i As Integer = 0 To totalToAnalyze Step 100
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
                column.setFound(getTotalOfFoundMetrics(checkIfDateTotal, checkIfEmailTotal, checkIfGenderTotal, checkIfStreetTotal))

            Next

        End Sub

        Private Function getTotalOfFoundMetrics(ByVal checkIfDateTotal As Integer, ByVal checkIfEmailTotal As Integer, ByVal checkIfGenderTotal As Integer, ByVal checkIfStreetTotal As Integer) As Integer

            If checkIfEmailTotal > 0 Then

                Return checkIfEmailTotal

            ElseIf checkIfDateTotal > 0 Then

                Return checkIfDateTotal

            ElseIf checkIfGenderTotal > 0 Then

                Return checkIfGenderTotal

            ElseIf checkIfStreetTotal > 0 Then

                Return checkIfStreetTotal

            End If

            Return 0

        End Function

    End Class

End Namespace
