Namespace Objects

    Public Class Computer

        Private ip As String
        Private databasesInstances As ArrayList
        Private openPorts As ArrayList

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

        Public Sub addCredentials(ByRef user As String, ByRef password As String, ByRef databaseInstancePosition As Integer, ByRef databaseName As String)

            Dim databaseInstance As DatabaseInstance = Me.databasesInstances(databaseInstancePosition)
            databaseInstance.addCredentials(user, password, databaseName)

        End Sub

        Public Function getIp() As String

            Return Me.ip

        End Function

        Public Sub addOpenPort(ByRef portNumber As Integer)

            Me.openPorts.Add(portNumber)

        End Sub

    End Class

End Namespace
