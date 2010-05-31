Imports System.Text.RegularExpressions

Namespace Metrics

    Public Module Metrics

        Public Function checkIfEmail(ByVal email As String) As Boolean

            Dim emailRecognition As Regex = New Regex("^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
            ' old regex: New Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum)\b")

            If emailRecognition.IsMatch(email) Then

                Return True

            Else

                Return False

            End If

        End Function

        Public Function checkIfGender(ByVal data As String) As Boolean

            'Dim entries As ArrayList = data
            Dim propability As Integer = 0
            Dim foundEntries As Integer = 0

            'distinctArray(entries)

            ' When entries have a cardinality of 2 it's 20% propability of being a gender column
            'If entries.Count = 2 Then

            'propability = 20

            'End If

            ' searches if references are in the entries
            'For Each ref In references

            'If entries.Contains(ref) Then

            'foundEntries += 1

            'End If

            'Next

            ' when entries which matches the references and the cardinality is 2
            ' so it should be by 95% a gender column
            If propability > 0 & foundEntries > 2 Then

                Return True

            End If

            Return False

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

        'check whether String is a Date
        'return true or false
        Public Function checkIfDate(ByVal input As String) As Boolean

            Dim matcher As Regex = New Regex("^[0-9]{4}-[0-9]{2}-[0-9]{2}\s{1}[0-9]{2}:[0-9]{2}:[0-9]{2}$")

            If matcher.IsMatch(input) Then

                Return True

            End If

            Return False

        End Function

        'check wether String is a Street
        Public Function checkIfStreet(ByVal streetName As String) As Boolean
            ' TODO: write streetchecklogic

            ' idea: separate string and and analyze last x characters whether they are street/strasse/flur/gasse/hof/matte/matt/grund/ and so on...
            ' first fill possible refrence strings into arrays, start with one letter, then two letter-arrays and so on
            ' hof would be in the three letter arry, flur in a four-letterarray, street in a six-letter-array and so on
            Dim streetTables As List(Of String) = New List(Of String)
            Dim streetReferenceData As List(Of String) = New List(Of String)
            Dim probability As Integer = 0

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfStreet", streetTables)

            For Each table In streetTables

                Helpers.SQLiteHelper.getReferenceData(table, streetReferenceData)

            Next


            streetName = streetName.ToLower

            For Each name In streetReferenceData

                If streetName.Contains(name) Then

                    Return True

                End If

            Next

            Return False

        End Function

        Public Function checkIfContains(ByVal name As String, ByVal searched As List(Of String)) As Boolean

            For Each searching In searched

                If name.Contains(searching) Then

                    Return True

                End If

            Next

            Return False

        End Function

    End Module

End Namespace