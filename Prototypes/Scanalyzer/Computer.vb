Public Class Computer
    Private ip As String

    Public Sub New(ByVal ipInput As String)
        ip = ipInput
    End Sub

    Public Function getIpAddress()
        Return ip
    End Function
End Class
