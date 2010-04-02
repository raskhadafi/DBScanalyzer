Public Class Computer

    Private ip As String
    Private databasesInstances As ArrayList

    Public Sub New(ByVal ip As String)
        Me.ip = ip
        databasesInstances = New ArrayList
    End Sub

    Public Function getInstance(ByRef position As Integer) As DatabaseInstance
        Return Me.databasesInstances(position)
    End Function

    Public Sub addDatabaseInstance(ByVal port As Integer, ByVal type As DatabaseInstance.DatabaseEnum)
        Dim databaseInstance As New DatabaseInstance(port, type)
        Me.databasesInstances.Add(databaseInstance)
    End Sub

    Public Sub addCredentials(ByRef user As String, ByRef password As String, ByRef databaseInstancePosition As Integer)
        Dim databaseInstance As DatabaseInstance = Me.databasesInstances(databaseInstancePosition)
        databaseInstance.addCredentials(user, password)
    End Sub

    Public Function getIp() As String
        Return Me.ip
    End Function

End Class
