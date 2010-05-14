Namespace Objects

    Public Class DatabaseInstance

        Private port As Integer
        Private user As String
        Private password As String
        Private databaseName As String
        Private type As DatabaseEnum
        Private selected As Boolean

        Public Sub New(ByVal port As Integer, ByVal type As DatabaseEnum)

            Me.port = port
            Me.type = type
            Me.selected = False

        End Sub

        Public Function getDatabaseType() As String

            Return Me.type.ToString

        End Function

        Public Sub setSelection(ByRef selected As Boolean)

            Me.selected = selected

        End Sub

        Public Function getSelection() As Boolean

            Return Me.selected

        End Function

        Public Sub addCredentials(ByVal user As String, ByVal password As String)

            Me.user = user
            Me.password = password

        End Sub

        Public Sub addCredentials(ByVal user As String, ByVal password As String, ByVal databaseName As String)

            Me.user = user
            Me.password = password
            Me.databaseName = databaseName

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

        Public Function getDatabaseName() As String

            Return Me.databaseName

        End Function

        Enum DatabaseEnum

            undefinied = -1
            mysql = 0
            mssql = 1
            oracle = 2
            db2 = 3

        End Enum

    End Class

End Namespace
