Public Class Computer

    Public ip As String
    Public databasesInstances As ArrayList

    Public Sub New(ByVal ip As String)
        Me.ip = ip
        databasesInstances = New ArrayList
    End Sub

    Public Function getInstance(ByRef position As Integer) As DatabaseInstance
        Return Me.databasesInstances(position)
    End Function

    Public Sub addDatabaseInstance(ByVal port As Integer, ByVal type As DatabaseInstance.DatabaseEnum)
        Dim databaseInstance As New DatabaseInstance(port, type)
    End Sub


End Class
