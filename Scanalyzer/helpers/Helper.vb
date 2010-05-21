Namespace Helpers

    Public Module Helper

        Public Function getDBAccessStrategy(ByVal type As Objects.DatabaseInstance.DatabaseEnum) As DBanalyzers.DBAccessStrategies.DBAccessStrategy

            Dim access As DBanalyzers.DBAccessStrategies.DBAccessStrategy

            access = Nothing

            Select Case type

                Case Objects.DatabaseInstance.DatabaseEnum.mysql

                    access = New DBanalyzers.DBAccessStrategies.MySQLAccessStrategy

            End Select

            Return access

        End Function

    End Module

End Namespace
