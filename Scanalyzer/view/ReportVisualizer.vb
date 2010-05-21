Namespace View

    Public Class ReportVisualizer

        Private computers As List(Of Objects.Computer)
        Private logger As ScanalyzerLogger

        Private Const TABSPACER As String = "   "
        Private Const SEPARATOR As String = "__________________________________________________" + vbNewLine

        Public Sub New(ByVal computers As List(Of Objects.Computer), ByRef logger As ScanalyzerLogger)

            Me.computers = computers
            Me.logger = logger

        End Sub

        Public Sub showReport()

            Dim reportForm As ScanalyzerReportForm

            reportForm = New ScanalyzerReportForm(report())
            Me.logger.updateLogger("print out report")

        End Sub

        Private Function report() As String

            Dim text As String = ""

            For Each computer In Me.computers

                text += "IP: " + computer.getIp + vbNewLine

                For Each databaseInstance In computer.getDatabaseInstances

                    text += TABSPACER + "Database-Typ: " + databaseInstance.getDatabaseType.ToString + vbNewLine

                    For Each database In databaseInstance.getDatabases

                        text += TABSPACER + TABSPACER + "Database-Name: " + database.getName + TABSPACER + "equals: " + database.getEquals.ToString + vbNewLine

                        For Each table In database.getTables

                            text += TABSPACER + TABSPACER + TABSPACER + table.getName + ": " + table.getEquals.ToString + vbNewLine

                        Next

                        text += vbNewLine

                    Next

                Next

                text += SEPARATOR

            Next

            Return text

        End Function

    End Class

End Namespace
