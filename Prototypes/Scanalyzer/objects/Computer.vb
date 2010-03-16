Public Class Computer
    Private ip As String
    Private databases As ArrayList

    Public Sub New(ByVal ipInput As String)
        ip = ipInput
        databases = New ArrayList
    End Sub

    Public Function getIpAddress()
        Return ip
    End Function

    Public Sub addNewDatabase(ByVal port As Integer, ByVal type As String)
        Dim database As New Database(port, type)
        databases.Add(database)
    End Sub
End Class
