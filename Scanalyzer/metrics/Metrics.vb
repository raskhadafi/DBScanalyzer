Imports System.Text.RegularExpressions

Namespace Metrics

    Public Class Metrics

        Public Function checkIfEmail(ByVal email As String) As Integer

            Dim emailRecognition As Regex = New Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum)\b")

            If emailRecognition.IsMatch(email) Then

                Return 100

            Else

                Return 0

            End If

        End Function

        Public Function checkIfGender(ByVal data As ArrayList, ByVal references As ArrayList) As Integer

            Dim entries As ArrayList = data
            Dim propability As Integer = 0
            Dim foundEntries As Integer = 0

            distinctArray(entries)

            ' When entries have a cardinality of 2 it's 20% propability of being a gender column
            If entries.Count = 2 Then

                propability = 20

            End If

            ' searches if references are in the entries
            For Each ref In references

                If entries.Contains(ref) Then

                    foundEntries += 1

                End If

            Next

            ' when entries which matches the references and the cardinality is 2
            ' so it should be by 95% a gender column
            If propability > 0 & foundEntries > 2 Then

                propability = 95
            Else

                propability += foundEntries * 10

            End If

            Return propability

        End Function

        ' removes the duplicates in an array
        Private Sub distinctArray(ByRef data As ArrayList)

            Dim distinctArray As ArrayList = New ArrayList

            For Each entry In data


                If Not distinctArray.Contains(entry) Then

                    distinctArray.Add(entry)

                End If


            Next

            data = distinctArray

        End Sub

    End Class

End Namespace