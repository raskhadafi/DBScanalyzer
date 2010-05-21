Namespace DBScanners

    Public Class DBScanner

        Private computers As List(Of Objects.Computer)
        Private settings As Helpers.Setting
        Private logger As ScanalyzerLogger

        Public Sub New(ByRef computers As List(Of Objects.Computer), ByVal settings As Helpers.Setting, ByRef logger As ScanalyzerLogger)

            Me.computers = computers
            Me.settings = settings
            Me.logger = logger

        End Sub

        Public Sub scanAfterComputers()

            Dim ips As Array = Me.settings.getIps()
            Dim computerPing As ComputerPing = New ComputerPing

            For Each ip In ips

                Me.logger.updateLogger("ping: " + ip.ToString)

                If computerPing.pingHost(ip) Then

                    Dim computer As Objects.Computer = New Objects.Computer(ip)

                    Me.computers.Add(computer)
                    Me.logger.updateLogger("found computer on " + ip.ToString)

                End If

            Next

            For Each computer In Me.computers

                Me.logger.updateLogger("scan for computer " + computer.getIp + " for open ports")
                computer.addOpenPorts(computerPing.getOpenPorts(computer.getIp))

            Next

        End Sub

        Public Sub scanAfterMySQL()

            For Each computer In Me.computers

                Dim ping As DBPingStrategies.DBPingStrategy = New DBPingStrategies.MySQLPingStrategy

                Me.logger.updateLogger("scan " + computer.getIp + " for mysql dbs")

                For Each port In ping.checkPorts(computer.getIp, computer.getOpenPorts)

                    computer.addDatabaseInstance(port, Objects.DatabaseInstance.DatabaseEnum.mysql)

                Next

            Next

        End Sub

        Public Sub scanAfterMSSQL()

            For Each computer In Me.computers

                Dim ping As DBPingStrategies.DBPingStrategy = New DBPingStrategies.MSSQLPingStrategy

                Me.logger.updateLogger("scan " + computer.getIp + " for mssql dbs")

                For Each port In ping.checkPorts(computer.getIp, computer.getOpenPorts)

                    computer.addDatabaseInstance(port, Objects.DatabaseInstance.DatabaseEnum.mssql)

                Next

            Next

        End Sub

    End Class

End Namespace
