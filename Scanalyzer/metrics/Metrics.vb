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

        Public Function checkIfPlace(ByVal place As String) As Boolean

            Return False

        End Function

        Public Function checkIfGender(ByVal entries As ArrayList) As Boolean

            'Dim entries As ArrayList = data
            Dim propability As Integer = 0
            Dim foundEntries As Integer = 0
            Dim genderTables As List(Of String) = New List(Of String)
            Dim genderEntries As List(Of String) = New List(Of String)

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfGender", genderTables)

            For Each tbl In genderTables

                Helpers.SQLiteHelper.getReferenceData(tbl, genderEntries)

            Next

            distinctArray(entries)

            ' When entries have a cardinality of 2 it's 20% propability of being a gender column
            If entries.Count = 2 Then

                For Each entry In entries

                    If genderEntries.Contains(entry) Then

                        Return True

                    End If

                Next

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

            Dim regexs As List(Of String) = New List(Of String)
            Dim dateTables As List(Of String) = New List(Of String)

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfDate", dateTables)

            For Each tbl In dateTables

                Helpers.SQLiteHelper.getReferenceData(tbl, regexs)

            Next

            For Each exp In regexs

                Dim matcher As Regex = New Regex(exp)

                If matcher.IsMatch(input) Then

                    Return True

                End If

            Next

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

        Public Function checkIfURI(ByVal uri As String) As Boolean

            Dim urlChecker As Regex = New Regex("((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)")

            If urlChecker.IsMatch(uri) Then

                Return True

            End If

            Return False

        End Function

        Public Function checkIfPhone(ByVal phoneNumber As String) As Boolean

            Dim phoneTables As List(Of String) = New List(Of String)
            Dim areaCodes As List(Of String) = New List(Of String)

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfPhone", phoneTables)

            For Each tbl In phoneTables

                Helpers.SQLiteHelper.getReferenceData(tbl, areaCodes)

            Next

            Return False

        End Function

        Public Function checkIfISOcode(ByRef isoCode As String) As Boolean

            Dim isoTables As List(Of String) = New List(Of String)
            Dim isoCodes As List(Of String) = New List(Of String)

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfISOcode", isoTables)

            For Each tbl In isoTables

                Helpers.SQLiteHelper.getReferenceData(tbl, isoCodes)

            Next

            For Each code In isoCodes

                If code.ToLower = isoCode.ToLower Then

                    Return True

                End If

            Next

            Return False

        End Function

        Public Function checkIfCity(ByVal city As String) As Boolean

            Dim cityTables As List(Of String) = New List(Of String)
            Dim cities As List(Of String) = New List(Of String)

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfCity", cityTables)

            For Each tbl In cityTables

                Helpers.SQLiteHelper.getReferenceData(tbl, cities)

            Next

            For Each entry In cities

                If city.ToLower = entry.ToLower Then

                    Return True

                End If

            Next

            Return False

        End Function

        Public Function checkIfName(ByVal name As String) As Boolean

            Dim nameTables As List(Of String) = New List(Of String)
            Dim names As List(Of String) = New List(Of String)

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfName", nameTables)

            For Each tbl In nameTables

                Helpers.SQLiteHelper.getReferenceData(tbl, names)

            Next

            For Each entry In names

                If name.ToLower = entry.ToLower Then

                    Return True

                End If

            Next

            Return False

        End Function

        Public Function checkIfPostcode(ByVal postcode As String) As Boolean


            Dim zipTables As List(Of String) = New List(Of String)
            Dim zips As List(Of String) = New List(Of String)

            Helpers.SQLiteHelper.getReferencedataForMetrics("checkIfPostcode", zipTables)

            For Each tbl In zips

                Helpers.SQLiteHelper.getReferenceData(tbl, zips)

            Next

            For Each entry In zips

                If postcode.ToLower = entry.ToLower Then

                    Return True

                End If

            Next

            Return False

        End Function

    End Module

End Namespace