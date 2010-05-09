Namespace Helpers

    Public Class Settings

        Private ips As List(Of String)

        Public Sub New()

            ips = New List(Of String)

        End Sub

        Public Sub addIP(ByVal ip As String)

            If Not Me.ips.Contains(ip) Then

                Me.ips.Add(ip)

            End If

        End Sub

        Public Sub addIPRange(ByVal ipRange As String)



        End Sub

    End Class

End Namespace
