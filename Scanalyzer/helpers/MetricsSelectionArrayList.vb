Namespace Helpers

    Namespace Settings

        Public Class MetricsSelectionArrayList
            Inherits List(Of Metric)

            Private selected As Boolean = False

            Public Function isSelected(ByRef name As String) As Boolean

                Dim searched As Metric

                searched = CType(System.Enum.Parse(searched.GetType, name), Metric)


                If Me.Contains(searched) Then

                    Return True

                Else

                    Return False

                End If

            End Function

            Public Function getAvaibleMetris() As Array

                Dim metrics As ArrayList = New ArrayList

                For Each metric In System.Enum.GetValues(GetType(Metric))

                    If Not metric = Helpers.Settings.Metric.noMetric Then

                        metrics.Add(metric.ToString)

                    End If

                Next

                Return metrics.ToArray

            End Function

            Public Sub setMetricAsSelected(ByRef name As String)

                Dim searched As Metric

                searched = CType(System.Enum.Parse(searched.GetType, name), Metric)

                If Not Me.Contains(searched) Then

                    Me.Add(searched)

                End If

            End Sub

            Public Sub removeMetricIfSelected(ByRef name As String)

                Dim removed As Metric

                removed = CType(System.Enum.Parse(removed.GetType, name), Metric)

                If Me.Contains(removed) Then

                    Me.Remove(removed)

                End If

            End Sub

        End Class


        Public Enum Metric

            noMetric
            checkIfDate
            checkIfEmail
            checkIfGender
            checkIfStreet
            checkIfURI
            checkIfPhone
            checkIfISOcode
            checkIfCity
            checkIfName
            checkIfPostcode

        End Enum

    End Namespace

End Namespace
