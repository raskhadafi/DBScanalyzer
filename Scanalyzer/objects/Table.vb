Namespace Objects

    Public Class Table

        Private name As String
        Private columns As List(Of String)
        Private equalsToData As Integer

        Public Sub New(ByVal name As String)

            Me.name = name
            Me.equalsToData = 0
            Me.columns = New List(Of String)

        End Sub

        Public Function getName() As String

            Return Me.name

        End Function

        Public Sub addColumns(ByRef columns As ArrayList)

            For Each column In columns

                Me.columns.Add(column.ToString)

            Next

        End Sub

    End Class

End Namespace
