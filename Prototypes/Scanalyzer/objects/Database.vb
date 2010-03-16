Public Class Database
    Private type As DatabaseType
    Private port As Integer

    Sub New(ByVal inputport As Integer, ByVal type As String)
        port = inputport
        If type.Equals("mysql") Then
            type = DatabaseType.mysql
        Else
            type = DatabaseType.undefinied
        End If
    End Sub

    Enum DatabaseType
        undefinied = -1
        mysql = 0
    End Enum
End Class
