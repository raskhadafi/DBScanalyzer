Imports System.Text.RegularExpressions

Namespace Helpers

    Public Class Setting

        Private ipInput As String = Nothing
        Private ips As List(Of String)
        Private references As Settings.ReferenceSelectionArrayList
        Private metrics As Settings.MetricsSelectionArrayList


        Public Sub New()

            ips = New List(Of String)

        End Sub

        Public Function getIps() As Array

            Return Me.ips.ToArray

        End Function

        Public Sub addMetrics(ByVal metrics As Settings.MetricsSelectionArrayList)

            Me.metrics = metrics

        End Sub

        Public Function getMetricsAsText() As String

            Dim metrics As String = ""

            For Each metric In Me.metrics

                metrics += metric.ToString + vbNewLine

            Next

            Return metrics

        End Function

        Public Function getSelectedMetrics() As Settings.MetricsSelectionArrayList

            Return Me.metrics

        End Function

        Public Function getMetrics() As Settings.MetricsSelectionArrayList

            Return Me.metrics

        End Function

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

        Public Function getSelectedReferences() As List(Of String)

            Return Me.references.getSelectedReferences

        End Function

        Public Sub addIP(ByVal ip As String)

            Me.ipInput = ip
            Me.ips = New List(Of String)

            If Not Me.ips.Contains(ip) Then

                Me.ips.Add(ip)

            End If

        End Sub

        Public Sub addIPRange(ByVal ipRange As String)

            Me.ipInput = ipRange
            Me.ips = New List(Of String)
            Dim ipRangePoints As Array = ipRange.Split("-")
            Dim ipRangsTupels As Array = ipRangePoints(0).Split(".")
            Dim startString As String = ipRangsTupels(0) + "." + ipRangsTupels(1) + "." + ipRangsTupels(2) + "."
            Dim startIp As Integer = ipRangsTupels(3)
            Dim lastIp As Integer = ipRangePoints(1)

            For i = startIp To lastIp

                Me.ips.Add(startString + i.ToString)

            Next


        End Sub

        Public Function getIpRangeAsInserted() As String

            Return ipInput

        End Function

        Public Function getReferencesForStreet() As ArrayList

            Dim references As ArrayList = New ArrayList

            For Each ref In Me.references

                If ref.isSelected Then

                    If ref.reference = "street" Then

                        For Each lang In ref.selectedLanguages

                            references.Add(ref.reference + "_" + lang)

                        Next

                    End If

                End If

            Next

            Return references

        End Function

    End Class

End Namespace
