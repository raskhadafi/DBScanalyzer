Namespace Objects

    Public Class Table

        Private name As String
        Private columns As List(Of Column)
        Private equalsToData As Integer
        Private containsReferencedata As Boolean

        Public Sub New(ByVal name As String)

            Me.name = name
            Me.equalsToData = 0
            Me.columns = New List(Of Column)
            Me.containsReferencedata = False

        End Sub

        Public Function getName() As String

            Return Me.name

        End Function

        Public Sub setContainsReferencedata(ByVal value As Boolean)

            Me.containsReferencedata = value

        End Sub

        Public Sub addColumns(ByRef columns As ArrayList)

            For Each column In columns

                Me.columns.Add(New Column(column.ToString))

            Next

        End Sub

        Public Function getColumns() As List(Of Column)

            Return Me.columns

        End Function

        Public Sub increaseEqualsToDataBy(ByVal up As Integer)

            Me.equalsToData += up

        End Sub

        Public Function getEquals() As Integer

            Return Me.equalsToData

        End Function

    End Class

End Namespace
