Namespace Objects

    Public Class Column

        Private name As String
        Private containsReferencedata As Boolean
        Private totalFound As Decimal
        Private equalsToData As Decimal

        Public Sub New(ByVal name As String)

            Me.name = name
            Me.containsReferencedata = False
            Me.totalFound = 0
            Me.equalsToData = 0

        End Sub

        Public Function getName() As String

            Return Me.name

        End Function

        Public Sub setContainsReferencedata(ByVal value As Boolean)

            Me.containsReferencedata = value

        End Sub

        Public Function getContainsRefernecedata() As Boolean

            Return Me.containsReferencedata

        End Function

        Public Sub setFound(ByVal totalFound As Decimal)

            Me.totalFound = totalFound

        End Sub

        Public Function getFound() As Decimal

            Return Me.totalFound

        End Function

        Public Sub setEquals(ByVal value As Decimal)

            Me.equalsToData = value

        End Sub

        Public Function getEquals() As Decimal

            Return Me.equalsToData

        End Function

    End Class

End Namespace