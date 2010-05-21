Namespace DBanalyzers

    Friend Class SchemaAnalyzer

        Private computers As List(Of Objects.Computer)
        Private settings As Helpers.Setting

        Public Sub New(ByRef computers As List(Of Objects.Computer), ByVal settings As Helpers.Setting)

            Me.computers = computers
            Me.settings = settings

        End Sub

        Public Sub getSchemasOfComputers()

            For Each computer In Me.computers

                Dim position As Integer = 0

                For Each db In computer.getDatabaseInstances

                    Dim access As DBAccessStrategies.DBAccessStrategy

                    access = Helpers.Helper.getDBAccessStrategy(db.getDatabaseType)

                    If access.openConnection(computer, position) Then

                        db.addDatabases(access.getDatabaseNames())

                        For Each database In db.getDatabases

                            database.addTables(access.getTableNames(database.getName))

                            For Each table In database.getTables

                                table.addColumns(access.getColumnNames(database.getName, table.getName))

                            Next

                        Next

                    End If

                    access.closeConnection()
                    position += 1

                Next

            Next

        End Sub

        Public Sub analyzeSchema()

            For Each computer In Me.computers

                For Each databaseInstance In computer.getDatabaseInstances

                    For Each database In databaseInstance.getDatabases

                        For Each table In database.getTables

                            database.increaseEqualsToDataBy(analyseTable(table))

                            For Each column In table.getColumns

                                table.increaseEqualsToDataBy(1)

                            Next

                        Next

                    Next

                Next

            Next

        End Sub

        Private Function analyseTable(ByVal table As Objects.Table) As Integer

            Dim value As Integer = 0

            For Each metric In Me.settings.getMetrics

                Select Case metric

                    Case Helpers.Settings.Metric.checkIfDate

                        value += Metrics.checkIfDate(table.getName)

                    Case Helpers.Settings.Metric.checkIfEmail

                        value += Metrics.Metrics.checkIfEmail(table.getName)

                    Case Helpers.Settings.Metric.checkIfGender



                    Case Helpers.Settings.Metric.checkIfStreet

                        Dim tableNames As ArrayList = New ArrayList

                        For Each ref In Me.settings.getReferencesForStreet

                            Helpers.SQLiteHelper.getReferenceData(ref, tableNames)

                        Next

                        value += Metrics.Metrics.checkIfStreet(table.getName, tableNames)

                End Select

            Next

            Return value

        End Function

    End Class

End Namespace
