Namespace DBanalyzer

    Public Class DataAnalyzer

        Private computers As List(Of Objects.Computer)
        Private settings As Helpers.Setting

        Public Sub New(ByRef computers As List(Of Objects.Computer), ByVal settings As Helpers.Setting)

            Me.computers = computers
            Me.settings = settings

        End Sub

        Public Sub analyzeContent()

            Dim access As DBAccessStrategies.DBAccessStrategy

            For Each computer In Me.computers

                For Each databaseInstance In computer.getDatabaseInstances

                    access = Helpers.Helper.getDBAccessStrategy(databaseInstance.getDatabaseType)

                    For Each database In databaseInstance.getDatabases

                        For Each table In database.getTables

                            For Each column In table.getColumns

                                analyze(access.getColumn(database.getName, table.getName, column), table)

                            Next

                        Next

                    Next

                Next

            Next

        End Sub

        Private Sub analyze(ByVal entries As ArrayList, ByRef table As Scanalyzer.Objects.Table)

            For Each entry In entries



            Next

        End Sub

    End Class

End Namespace
