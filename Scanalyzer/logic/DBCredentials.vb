Namespace DBScanners

    Public Class DBCredentials

        Private loginDataForm As ScanalyzerLoginForm
        Private databaseInstance As Objects.DatabaseInstance

        Public Sub New(ByRef databaseInstance As Objects.DatabaseInstance)

            Me.databaseInstance = databaseInstance
            Me.loginDataForm = New ScanalyzerLoginForm(Me.databaseInstance)
            Me.loginDataForm.Show()
            Me.loginDataForm.Focus()

        End Sub


    End Class

End Namespace
