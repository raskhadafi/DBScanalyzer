Namespace Helpers

    Public Class Settings

        Private ips As List(Of String)
        Private references As ReferenceSelectionArrayList

        Public Sub New()

            ips = New List(Of String)

        End Sub

        Public Sub addReferences(ByVal reference As ReferenceSelectionArrayList)

            Me.references = reference

        End Sub

        Public Sub addIP(ByVal ip As String)

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

            For i = startIp To lastIp

                Me.addIP(startString + i.ToString)

            Next


        End Sub

    End Class

End Namespace
