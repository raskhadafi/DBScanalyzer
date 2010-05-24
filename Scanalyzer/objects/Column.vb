Namespace Objects

    Public Class Column

        Private name As String
        Private containsReferencedata As Boolean

        Public Sub New(ByVal name As String)

            Me.name = name
            Me.containsReferencedata = False

        End Sub

        Public Function getName() As String

            Return Me.name

        End Function

    End Class

End Namespace