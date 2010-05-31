Namespace Objects

    Public Class DatabaseInstance

        Private port As Integer
        Private user As String
        Private password As String
        Private name As String
        Private type As DatabaseEnum
        Private selected As Boolean
        Private databases As List(Of Database)

        Public Sub New(ByVal port As Integer, ByVal type As DatabaseEnum)

            Me.port = port
            Me.type = type
            Me.selected = False
            Me.databases = New List(Of Database)

        End Sub

        Public Function getDatabases() As List(Of Database)

            Return Me.databases

        End Function

        Public Sub addDatabases(ByVal names As ArrayList)

            For Each entry In names

                Me.databases.Add(New Database(entry))

            Next

        End Sub

        Public Sub setPassword(ByVal password As String)

            Me.password = password

        End Sub

        Public Sub setUser(ByVal user As String)

            Me.user = user

        End Sub

        Public Function getDatabaseType() As DatabaseEnum

            Return Me.type

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
            Me.name = databaseName

        End Sub

        Public Function getUser() As String

            Return Me.user

        End Function

        Public Function getPassword() As String

            Return Me.password

        End Function

        Public Function getPort() As Integer

            Return Me.port

        End Function

        Public Function getName() As String

            Return Me.name

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
