Public Class DatabaseInstance

    Public port As Integer
    Public user As String
    Public pwd As String
    Public type As DatabaseEnum

    Enum DatabaseEnum
        undefinied = -1
        mysql = 0
        mssql = 1
        oracle = 2
        db2 = 3
    End Enum

End Class
