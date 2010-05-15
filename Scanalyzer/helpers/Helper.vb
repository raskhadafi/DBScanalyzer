Namespace Helpers

    Public Module Helper

        Public Function getDBAccessStrategy(ByVal type As Objects.DatabaseInstance.DatabaseEnum) As DBanalyzer.DBAccessStrategies.DBAccessStrategy

            Dim access As DBanalyzer.DBAccessStrategies.DBAccessStrategy

            access = Nothing

            Select Case type

                Case Objects.DatabaseInstance.DatabaseEnum.mysql

                    access = New DBanalyzer.DBAccessStrategies.MySQLAccessStrategy

            End Select

            Return access

        End Function

    End Module

End Namespace
