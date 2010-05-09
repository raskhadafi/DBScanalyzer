Namespace Helpers

    Public Class Settings

        Private ipInput As String
        Private ips As List(Of String)
        Private references As ReferenceSelectionArrayList

        Public Sub New()

            ips = New List(Of String)

        End Sub

        Public Function getReferences() As ReferenceSelectionArrayList

            Return references

        End Function

        Public Function initialized() As Boolean

            If ipInput Is Nothing And ips.Count = 0 And references Is Nothing Then

                Return False

            Else

                Return True

            End If

        End Function

        Public Sub addReferences(ByVal reference As ReferenceSelectionArrayList)

            Me.references = reference

        End Sub

        Public Sub addIP(ByVal ip As String)

            Me.ipInput = ip

            If Not Me.ips.Contains(ip) Then

                Me.ips.Add(ip)

            End If

        End Sub

        Public Sub addIPRange(ByVal ipRange As String)

            Dim ipRangePoints As Array = ipRange.Split("-")
            Dim ipRangsTupels As Array = ipRangePoints(0).Split(".")
            Dim startString As String = ipRangsTupels(0) + "." + ipRangsTupels(1) + "." + ipRangsTupels(2) + "."
            Dim startIp As Integer = ipRangsTupels(3)
            Dim lastIp As Integer = ipRangePoints(1)

            Me.ipInput = ipRange

            For i = startIp To lastIp

                Me.addIP(startString + i.ToString)

            Next


        End Sub

        Public Function getIpRangeAsInserted() As String

            Return ipInput

        End Function

    End Class

End Namespace
