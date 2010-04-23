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

    End Class

End Namespace