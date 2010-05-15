Namespace DBanalyzer

    Public Class SchemaAnalyzer

        Private computers As List(Of Objects.Computer)

        Public Sub New(ByRef computers As List(Of Objects.Computer))

            Me.computers = computers

        End Sub

        Public Sub getSchemasOfComputers()

            For Each computer In Me.computers

                Dim position As Integer = 0

                For Each db In computer.getDatabaseInstances

                    Dim access As DBAccessStrategies.DBAccessStrategy

                    access = getDBAccessStrategy(db.getDatabaseType)

                    If access.openConnection(computer, position) Then

                        db.setDatabaseNames(access.getDatabaseNames())

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

        Private Function getDBAccessStrategy(ByVal type As Objects.DatabaseInstance.DatabaseEnum) As DBAccessStrategies.DBAccessStrategy

            Dim access As DBAccessStrategies.DBAccessStrategy

            access = Nothing

            Select Case type

                Case Objects.DatabaseInstance.DatabaseEnum.mysql

                    access = New DBAccessStrategies.MySQLAccessStrategy

            End Select

            Return access

        End Function

    End Class

End Namespace
