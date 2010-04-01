Public Class DatabaseInstance

    Public port As Integer
    Public user As String
    Public pwd As String
    Public type As DatabaseEnum

    Public Sub New(ByVal port As Integer, ByVal type As DatabaseEnum)
        Me.port = port
        Me.type = type
    End Sub

    Enum DatabaseEnum
        undefinied = -1
        mysql = 0
        mssql = 1
        oracle = 2
        db2 = 3
    End Enum

End Class
