Imports Scanalyzer.DBScanners
Imports Scanalyzer.DBanalyzers


Namespace Controller

    Public Class Scanalyzer

        Private settings As Helpers.Setting
        Private owner As ScanalyzerForm
        Private computers As List(Of Objects.Computer)
        Private loggerOutput As ScanalyzerLogger

        Public Sub New(ByRef settings As Helpers.Setting, ByVal ownerForm As ScanalyzerForm)

            Me.settings = settings
            Me.owner = ownerForm
            Me.computers = New List(Of Objects.Computer)
            Me.loggerOutput = New ScanalyzerLogger
            Me.loggerOutput.updateLogger("Scanalyzer initialized")
            Me.loggerOutput.Show()

        End Sub

        Public Sub New(ByRef settings As Helpers.Setting, ByVal ownerForm As ScanalyzerForm, ByVal computer As Objects.Computer)

            Me.New(settings, ownerForm)
            Me.computers.Add(computer)

        End Sub

        Public Sub startScanning()

            Dim dbScanner As DBScanners.DBScanner

            Me.loggerOutput.Focus()
            dbScanner = New DBScanners.DBScanner(Me.computers, Me.settings, Me.loggerOutput)
            Me.loggerOutput.updateLogger("start scan after computers")
            dbScanner.scanAfterComputers()
            Me.loggerOutput.updateLogger("check found computers for mysql dbs")
            dbScanner.scanAfterMySQL()
            Me.loggerOutput.updateLogger("check found computers for mssql dbs")
            dbScanner.scanAfterMSSQL()
            Me.owner.Focus()

        End Sub

        Public Function getComputers() As List(Of Objects.Computer)

            Return Me.computers

        End Function

        Public Function getComputer(ByVal ip As String) As Objects.Computer

            For Each computer In Me.computers

                If computer.getIp = ip Then

                    Return computer

                End If

            Next

            Return Nothing

        End Function

        Public Function checkIfLeastOneDatabaseinstanceCheckedAndFilled() As Boolean

            For Each computer In Me.computers

                For Each db In computer.getDatabaseInstances

                    If db.getSelection Then

                        Return True

                    End If

                Next

            Next

            Return False

        End Function

        Public Sub startReadAnalyzeAndShowData()

            Dim analyzer As DBAnalyzer
            Dim reportVisualizer As View.ReportVisualizer

            analyzer = New DBAnalyzer(Me.computers, Me.settings, Me.loggerOutput)
            Me.loggerOutput.updateLogger("start analyze schema")
            analyzer.analyzeSchema()
            Me.loggerOutput.updateLogger("start analyze data")
            analyzer.analyzeData()
            Me.loggerOutput.updateLogger("generate report")
            reportVisualizer = New View.ReportVisualizer(Me.computers, Me.loggerOutput)
            reportVisualizer.showReport()

        End Sub

    End Class

End Namespace
