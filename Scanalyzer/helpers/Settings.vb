Namespace Helpers

    Public Class Setting

        Private ipInput As String = Nothing
        Private ips As List(Of String)
        Private references As Settings.ReferenceSelectionArrayList
        Private metrics As List(Of Metric)

        Public Enum Metric

            checkIfDate
            checkIfEmail
            checkIfGender
            checkIfStreet

        End Enum

        Public Function getAvaibleMetrics() As ArrayList

            Dim metrics As ArrayList = New ArrayList

            metrics.Add(Metric.checkIfDate)
            metrics.Add(Metric.checkIfEmail)
            metrics.Add(Metric.checkIfGender)
            metrics.Add(Metric.checkIfStreet)

            Return metrics

        End Function

        Public Sub New()

            ips = New List(Of String)

        End Sub

        Public Function getReferences() As Settings.ReferenceSelectionArrayList

            Return references

        End Function

        Public Function initialized() As Boolean

            If ipInput Is Nothing And ips.Count = 0 And references Is Nothing Then

                Return False

            Else

                Return True

            End If

        End Function

        Public Sub addReferences(ByVal reference As Settings.ReferenceSelectionArrayList)

            Me.references = reference

        End Sub

        Public Function getReferencesAsText() As String

            Dim returnString As String = ""

            For Each refrence In Me.references

                If refrence.isSelected() Then

                    returnString = returnString + refrence.reference + ":" + vbNewLine

                    For Each language In refrence.selectedLanguages

                        returnString = returnString + "    " + language + vbNewLine

                    Next

                End If

            Next

            Return returnString

        End Function

        Public Sub addIP(ByVal ip As String)

            If Me.ipInput Is Nothing Then

                Me.ipInput = ip

            End If

            If Not Me.ips.Contains(ip) Then

                Me.ips.Add(ip)

            End If

        End Sub

        Public Sub addIPRange(ByVal ipRange As String)

            Me.ipInput = ipRange

            Dim ipRangePoints As Array = ipRange.Split("-")
            Dim ipRangsTupels As Array = ipRangePoints(0).Split(".")
            Dim startString As String = ipRangsTupels(0) + "." + ipRangsTupels(1) + "." + ipRangsTupels(2) + "."
            Dim startIp As Integer = ipRangsTupels(3)
            Dim lastIp As Integer = ipRangePoints(1)

            For i = startIp To lastIp

                Me.addIP(startString + i.ToString)

            Next


        End Sub

        Public Function getIpRangeAsInserted() As String

            Return ipInput

        End Function

    End Class

End Namespace
