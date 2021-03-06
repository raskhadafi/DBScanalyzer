﻿Namespace DBanalyzers

    Class SchemaAnalyzer

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

                    If access.openConnection(computer, db) Then

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

            Dim referencebasisdata As List(Of String)

            referencebasisdata = Me.getReferencebasisdata()

            For Each computer In Me.computers

                For Each databaseInstance In computer.getDatabaseInstances

                    For Each database In databaseInstance.getDatabases

                        If Metrics.checkIfContains(database.getName, referencebasisdata) Then

                            database.setContainsReferencedata(True)

                        End If

                        For Each table In database.getTables


                            If Metrics.checkIfContains(table.getName, referencebasisdata) Then

                                table.setContainsReferencedata(True)

                            End If


                            For Each column In table.getColumns


                                If Metrics.checkIfContains(column.getName, referencebasisdata) Then

                                    column.setContainsReferencedata(True)

                                End If


                            Next

                        Next

                    Next

                Next

            Next

        End Sub

        Private Function getReferencebasisdata() As List(Of String)

            Dim data As List(Of String) = New List(Of String)

            For Each ref In Me.settings.getSelectedReferences

                Helpers.SQLiteHelper.getReferenceData(ref, data)

            Next

            Return data

        End Function

    End Class

End Namespace
