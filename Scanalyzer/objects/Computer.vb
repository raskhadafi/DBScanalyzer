Namespace Objects

    Public Class Computer

        Private ip As String
        Private databasesInstances As List(Of DatabaseInstance)
        Private openPorts As ArrayList

        Public Sub New(ByVal ip As String)

            Me.ip = ip
            Me.databasesInstances = New List(Of DatabaseInstance)
            Me.openPorts = New ArrayList

        End Sub

        Public Function getDatabaseInstances() As List(Of DatabaseInstance)

            Return Me.databasesInstances

        End Function

        Public Sub addDatabaseInstance(ByVal port As Integer, ByVal type As DatabaseInstance.DatabaseEnum)

            Dim databaseInstance As New DatabaseInstance(port, type)
            Me.databasesInstances.Add(databaseInstance)

        End Sub

        Public Function getIp() As String

            Return Me.ip

        End Function

        Public Sub addOpenPorts(ByRef ports As ArrayList)

            For Each port In ports

                Me.addOpenPort(port)

            Next

        End Sub

        Public Sub addOpenPort(ByRef portNumber As Integer)

            Me.openPorts.Add(portNumber)

        End Sub

        Public Function getOpenPorts() As ArrayList

            Return Me.openPorts

        End Function

        Public Function getDatabaseInstance(ByRef port As Integer) As DatabaseInstance

            For Each database In Me.databasesInstances

                If database.getPort = port Then

                    Return database

                End If

            Next

            Return Nothing

        End Function

    End Class

End Namespace
