Namespace DBanalyzers

    Public Class SchemaAnalyzer

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

                            database.increaseEqualsToDataBy(10)

                            For Each column In table.getColumns

                                table.increaseEqualsToDataBy(19)

                            Next

                        Next

                    Next

                Next

            Next

        End Sub

    End Class

End Namespace
