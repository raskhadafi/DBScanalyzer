Namespace View

    Public Class ReportVisualizer

        Private computers As List(Of Objects.Computer)
        Private logger As ScanalyzerLogger

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

            Return "test output"

        End Function

    End Class

End Namespace
