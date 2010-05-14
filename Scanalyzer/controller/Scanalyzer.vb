Imports Scanalyzer.DBScanner

Namespace Controller

    Public Class Scanalyzer

        Private settings As Helpers.Setting
        Private owner As ScanalyzerForm
        Private computers As List(Of Objects.Computer)

        Public Sub New(ByRef settings As Helpers.Setting, ByVal ownerForm As ScanalyzerForm)

            Me.settings = settings
            Me.owner = ownerForm
            Me.computers = New List(Of Objects.Computer)

        End Sub

        Public Sub startScanning()

            Dim ips As Array = Me.settings.getIps()
            Dim computerPing As ComputerPing = New ComputerPing

            For Each ip In ips

                If computerPing.pingHost(ip) Then

                    Dim computer As Objects.Computer = New Objects.Computer(ip)

                    Me.computers.Add(computer)

                End If

            Next

            For Each computer In Me.computers

                computer.addOpenPorts(computerPing.getOpenPorts(computer.getIp))

            Next

            For Each computer In Me.computers

                Dim ping As DBPingStrategies.DBPingStrategy

                ping = New DBPingStrategies.MySQLPingStrategy

                For Each port In ping.checkPorts(computer.getIp, computer.getOpenPorts)

                    computer.addDatabaseInstance(port, Objects.DatabaseInstance.DatabaseEnum.mysql)

                Next

            Next

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



        End Sub

    End Class

End Namespace
