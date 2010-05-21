Namespace DBanalyzers

    Public Class DBAnalyzer

        Private schemaAnalyzer As SchemaAnalyzer
        Private dataAnalyzer As DataAnalyzer
        Private logger As ScanalyzerLogger
        Private computers As List(Of Objects.Computer)
        Private settings As Helpers.Setting

        Public Sub New(ByRef computers As List(Of Objects.Computer), ByVal settings As Helpers.Setting, ByRef logger As ScanalyzerLogger)

            Me.computers = computers
            Me.settings = settings
            Me.logger = logger

        End Sub

        Public Sub analyzeSchema()

            Dim schemaAnalyzer As SchemaAnalyzer

            schemaAnalyzer = New SchemaAnalyzer(Me.computers, Me.settings)
            schemaAnalyzer.getSchemasOfComputers()
            schemaAnalyzer.analyzeSchema()

        End Sub

        Public Sub analyzeData()

            Dim dataAnalyzer As DataAnalyzer

            dataAnalyzer = New DataAnalyzer(Me.computers, Me.settings)
            dataAnalyzer.analyzeColumnData()

        End Sub

    End Class

End Namespace