Namespace Objects

    Public Class Database

        Private name As String
        Private tables As List(Of Table)
        Private equalsToData As Decimal
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

        Public Function getContainsRefernecedata() As Boolean

            Return Me.containsReferencedata

        End Function

        Public Function getEquals() As Decimal

            Return Me.equalsToData

        End Function

        Public Sub setEquals(ByVal value As Integer)

            Me.equalsToData = value

        End Sub

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

    End Class

End Namespace
