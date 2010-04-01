Public Class Computer

    Public ip As String
    Public databasesInstances As ArrayList

    Public Function getInstance(ByRef position As Integer) As DatabaseInstance
        Return Me.databasesInstances(position)
    End Function


End Class
