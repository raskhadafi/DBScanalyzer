Namespace DBanalyzers

    Class DataAnalyzer

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

                        Dim dbTotal As Decimal = 0
                        Dim dbTotalCount As Decimal = 0

                        For Each table In database.getTables

                            Dim columnContainsReferencedata As Boolean
                            Dim tableTotal As Decimal = 0
                            Dim tableTotalCount As Decimal = 0

                            For Each column In table.getColumns

                                columnContainsReferencedata = column.getContainsRefernecedata

                                If column.getFound > 0 Then

                                    Dim equal As Decimal = calculateEquals(column.getFound, column.getRowCount, database.getContainsRefernecedata, table.getContainsRefernecedata, columnContainsReferencedata)

                                    If equal > 0 Then

                                        column.setEquals(equal)
                                        tableTotal += equal


                                    End If

                                End If

                                tableTotalCount += 1

                            Next

                            If tableTotalCount = 0 Then

                                table.setEquals(0)

                            Else

                                table.setEquals(tableTotal / tableTotalCount)

                            End If

                            tableTotal = 0
                            tableTotalCount = 0
                            dbTotal = table.getEquals
                            dbTotalCount += 1

                        Next

                        database.setEquals(dbTotal / dbTotalCount)

                    Next

                Next

            Next

        End Sub

        Private Function calculateEquals(ByVal foundTotalColumn As Decimal, ByVal rowCount As Integer, ByVal factorDatabase As Boolean, ByVal factorTable As Boolean, ByVal factorColumn As Boolean) As Decimal

            Dim fDatbase As Decimal = 0
            Dim fTable As Decimal = 0
            Dim fColumn As Decimal = 0
            Dim percent As Decimal = (foundTotalColumn / rowCount) * 100

            If factorDatabase Then

                fDatbase = Me.settings.getFDatabase

            End If


            If factorTable Then

                fTable = Me.settings.getFTable

            End If

            If factorColumn Then

                fColumn = Me.settings.getFColumn

            End If


            Return percent + (100 - percent) * (fDatbase + fTable + fColumn)

        End Function

        Private Sub analyze(ByVal computer As Objects.Computer, ByVal databaseInstance As Objects.DatabaseInstance, ByRef database As Objects.Database, ByRef table As Objects.Table, ByRef column As Objects.Column, ByVal tableCount As Integer)

            Dim access As DBAccessStrategies.DBAccessStrategy
            Dim entries As List(Of String) = New List(Of String)
            Dim entriesFromDB As ArrayList
            Dim totalToAnalyze As Integer
            Dim value As Boolean = Nothing
            Dim total As Decimal = 0
            Dim count As Integer = 0
            Dim checkIfDateTotal As Integer = 0
            Dim checkIfEmailTotal As Integer = 0
            Dim checkIfGenderTotal As Integer = 0
            Dim checkIfStreetTotal As Integer = 0
            Dim checkIfISOcode As Integer = 0
            Dim checkIfPhone As Integer = 0
            Dim checkIfURI As Integer = 0
            Dim checkIfCity As Integer = 0
            Dim checkIfPostcode As Integer = 0
            Dim metric As Helpers.Settings.Metric
            Dim genderMetricDone As Boolean = True


            If Me.settings.analyzeEverthing Then

                totalToAnalyze = tableCount

            Else

                If tableCount < Me.settings.getDataAnalyzationLimit Then

                    totalToAnalyze = tableCount

                Else

                    totalToAnalyze = Me.settings.getDataAnalyzationLimit

                End If

            End If

            column.setRowCount(totalToAnalyze)
            access = Helpers.Helper.getDBAccessStrategy(databaseInstance.getDatabaseType)
            access.openConnection(computer, databaseInstance)

            For i As Integer = 0 To totalToAnalyze Step 100

                Dim thisStep As Integer = i + 99

                If thisStep > totalToAnalyze Then

                    thisStep = totalToAnalyze

                End If

                entriesFromDB = access.getColumnLimited(database.getName, table.getName, column.getName, i, thisStep)

                For Each entry In entriesFromDB

                    count += 1

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

                                If genderMetricDone Then

                                    If Metrics.checkIfGender(entriesFromDB) Then

                                        checkIfGenderTotal = totalToAnalyze

                                    End If

                                    genderMetricDone = False
                                End If


                            Case Helpers.Settings.Metric.checkIfStreet

                                If Metrics.checkIfStreet(entry) Then

                                    checkIfStreetTotal += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfISOcode

                                If Metrics.checkIfISOcode(entry) Then

                                    checkIfISOcode += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfPhone

                                If Metrics.checkIfPhone(entry) Then

                                    checkIfPhone += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfURI

                                If Metrics.checkIfURI(entry) Then

                                    checkIfURI += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfCity

                                If Metrics.checkIfCity(entry) Then

                                    checkIfCity += 1

                                End If

                            Case Helpers.Settings.Metric.checkIfPostcode

                                If Metrics.checkIfPostcode(entry) Then

                                    checkIfPostcode += 1

                                End If

                        End Select

                    Next

                Next

                access.closeConnection()
                getTotalOfFoundMetrics(count, checkIfDateTotal, checkIfEmailTotal, checkIfGenderTotal, checkIfStreetTotal, checkIfISOcode, checkIfPhone, checkIfURI, checkIfCity, checkIfPostcode, total, metric)

                If total > 0 Then

                    column.setFound(total)
                    column.setMetricFound(metric)

                End If

            Next

        End Sub

        Private Sub getTotalOfFoundMetrics(ByVal count As Integer, ByVal checkIfDateTotal As Integer, ByVal checkIfEmailTotal As Integer, ByVal checkIfGenderTotal As Integer, ByVal checkIfStreetTotal As Integer, ByVal checkIfISOcode As Integer, ByVal checkIfPhone As Integer, ByVal checkIfURI As Integer, ByVal checkIfCity As Integer, ByVal checkIfPostcode As Integer, ByRef total As Integer, ByRef metric As Helpers.Settings.Metric)

            Dim finder As MetricDictionary = New MetricDictionary
            Dim highest As Integer = 0
            Dim overtwenty As List(Of Integer) = New List(Of Integer)

            finder.Add(Helpers.Settings.Metric.checkIfDate, checkIfDateTotal)
            finder.Add(Helpers.Settings.Metric.checkIfEmail, checkIfEmailTotal)
            finder.Add(Helpers.Settings.Metric.checkIfGender, checkIfGenderTotal)
            finder.Add(Helpers.Settings.Metric.checkIfStreet, checkIfStreetTotal)
            finder.Add(Helpers.Settings.Metric.checkIfISOcode, checkIfISOcode)
            finder.Add(Helpers.Settings.Metric.checkIfPhone, checkIfPhone)
            finder.Add(Helpers.Settings.Metric.checkIfURI, checkIfURI)
            finder.Add(Helpers.Settings.Metric.checkIfCity, checkIfCity)
            finder.Add(Helpers.Settings.Metric.checkIfPostcode, checkIfPostcode)

            For Each value In finder.Values

                If value > highest Then

                    highest = value

                End If


                If value > 19 Then

                    overtwenty.Add(value)

                End If

            Next


            total = highest

        End Sub

        Private Class MetricDictionary
            Inherits Dictionary(Of Helpers.Settings.Metric, Integer)

        End Class

    End Class

End Namespace
