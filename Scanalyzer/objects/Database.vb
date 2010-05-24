Namespace Objects

    Public Class Database

        Private name As String
        Private tables As List(Of Table)
        Private equalsToData As Integer
        Private containsReferencedata As Boolean

        Public Sub New(ByVal name As String)

            Me.name = name
            Me.tables = New List(Of Table)
            Me.equalsToData = 0
            Me.containsReferencedata = False

        End Sub

        Public Sub setContainsReferencedata(ByVal value As Boolean)

            Me.containsReferencedata = value

        End Sub

        Public Function getEquals() As Integer

            Return Me.equalsToData

        End Function

        Public Function getName() As String

            Return Me.name

        End Function

        Public Sub addTables(ByVal tableNames As ArrayList)

            For Each tableName In tableNames

                Dim table As Table = New Table(tableName)

                Me.tables.Add(table)

            Next

        End Sub

        Public Function getTables() As List(Of Table)

            Return Me.tables

        End Function

        Public Sub increaseEqualsToDataBy(ByVal up As Integer)

            Me.equalsToData += up

        End Sub

    End Class

End Namespace
