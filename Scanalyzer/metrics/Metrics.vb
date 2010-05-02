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

        'check whether String is a Date
        'return true or false

        Public Function checkIfDate(ByVal input As String) As Integer
            'TODO: write datechecklogic

            ' to check:
            ' which kinds of formats are possible for dates
            ' 15.01.2010; 15.1.2010; 15.1.10; 15.01.2010; 
            ' also dd.mm.yyyy oder dd(one or two digits).mm(one or two digits).yy((one or) two or four digits)
            ' in the american format, the month comes first and then the day
            ' the sign which separates dd from yy from yyyy can be a "." or a "/" or a "\"? or ....?
            '    > check whether there are further possible characters to separate
            ' 
            ' research showed, that there is already a date method existing
            ' gibt es irgendetwas wie todate...?


            Return False

        End Function

        'check wether String is a Street
        Public Function checkIfStreet(ByVal streetName As String, ByVal tableNames As ArrayList) As Integer
            ' TODO: write streetchecklogic

            ' idea: separate string and and analyze last x characters whether they are street/strasse/flur/gasse/hof/matte/matt/grund/ and so on...
            ' first fill possible refrence strings into arrays, start with one letter, then two letter-arrays and so on
            ' hof would be in the three letter arry, flur in a four-letterarray, street in a six-letter-array and so on
            Dim tableName As String = "street_identifier"
            Dim streetVariants As ArrayList = New ArrayList
            Dim probability As Integer = 0

            For Each tableName In tableNames

                Helpers.SQLiteHelper.getReferenceData(tableName, streetVariants)

            Next

            streetName = streetName.ToLower

            For Each name In streetVariants

                If streetName.Contains(name) Then

                    probability = 100

                End If

            Next

            Return probability

        End Function

    End Class

End Namespace