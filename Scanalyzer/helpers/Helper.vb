Imports System.Text.RegularExpressions

Namespace Helpers

    Public Module Helper

        Public checkIPRegex As New Regex("^\b(?:\d{1,3}\.){3}\d{1,3}\b$")
        Public checkIPRangeRegex As New Regex("^\b(?:\d{1,3}\.){3}\d{1,3}\b-\b(?:\d{1,3}\.){0}\d{1,3}\b$")

        Public Function getDBAccessStrategy(ByVal type As Objects.DatabaseInstance.DatabaseEnum) As DBanalyzers.DBAccessStrategies.DBAccessStrategy

            Dim access As DBanalyzers.DBAccessStrategies.DBAccessStrategy

            access = Nothing

            Select Case type

                Case Objects.DatabaseInstance.DatabaseEnum.mysql

                    access = New DBanalyzers.DBAccessStrategies.MySQLAccessStrategy

                Case Objects.DatabaseInstance.DatabaseEnum.mssql

                    access = New DBanalyzers.DBAccessStrategies.MSSQLAccessStrategy

            End Select

            Return access

        End Function

    End Module

End Namespace
