Public Class DatabaseInstance

    Public port As Integer
    Public user As String
    Public password As String
    Public type As DatabaseEnum

    Public Sub New(ByVal port As Integer, ByVal type As DatabaseEnum)
        Me.port = port
        Me.type = type
    End Sub

    Public Sub addCredentials(ByVal user As String, ByVal password As String)
        Me.user = user
        Me.password = password
    End Sub

    Public Function getUser() As String
        Return Me.user
    End Function

    Public Function getPassword() As String
        Return Me.password
    End Function

    Public Function getPort() As String
        Return Me.port
    End Function

    Enum DatabaseEnum
        undefinied = -1
        mysql = 0
        mssql = 1
        oracle = 2
        db2 = 3
    End Enum

End Class
