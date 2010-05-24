Namespace Objects

    Public Class Column

        Private name As String
        Private containsReferencedata As Boolean
        Private totalFound As Integer

        Public Sub New(ByVal name As String)

            Me.name = name
            Me.containsReferencedata = False
            Me.totalFound = 0

        End Sub

        Public Function getName() As String

            Return Me.name

        End Function

        Public Sub setContainsReferencedata(ByVal value As Boolean)

            Me.containsReferencedata = value

        End Sub

        Public Sub setFound(ByVal totalFound As Integer)

            Me.totalFound = totalFound

        End Sub

    End Class

End Namespace