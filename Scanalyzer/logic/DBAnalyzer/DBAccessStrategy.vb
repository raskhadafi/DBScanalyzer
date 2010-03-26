Public MustInherit Class DBAccessStrategy

    Public MustOverride Function openConnection(ByRef computer As Computer, ByVal databaseInstance As Integer) As Boolean
    Public MustOverride Function closeConnection() As Boolean
    Public MustOverride Function getInformationSchema() As ArrayList
    Public MustOverride Function getDatabaseNames() As ArrayList
    Public MustOverride Function getColumnNames() As ArrayList
    Public MustOverride Function getColumn() As ArrayList

End Class
