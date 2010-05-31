Imports Scanalyzer.Objects

Namespace DBanalyzers

    Namespace DBAccessStrategies

        Public MustInherit Class DBAccessStrategy

            Public MustOverride Function openConnection(ByRef computer As Computer, ByVal databaseInstance As DatabaseInstance) As Boolean

            Public MustOverride Function closeConnection() As Boolean

            Public MustOverride Function getInformationSchema() As ArrayList

            Public MustOverride Function getDatabaseNames() As ArrayList

            Public MustOverride Function getTableNames(ByVal databaseName As String) As ArrayList

            Public MustOverride Function getColumnNames(ByVal databaseName As String, ByVal tableName As String) As ArrayList

            Public MustOverride Function getColumn(ByVal databaseName As String, ByVal tableName As String, ByVal columName As String) As ArrayList

            Public MustOverride Function getColumnLimited(ByVal databaseName As String, ByVal tableName As String, ByVal columName As String, ByVal fromLimit As Integer, ByVal toLimit As Integer) As ArrayList

            Public MustOverride Function getTableCount(ByVal databaseName As String, ByVal tableName As String) As Integer

        End Class

    End Namespace

End Namespace
