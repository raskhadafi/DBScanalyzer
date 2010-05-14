Public Class ScanalyzerLoginForm

    Private databaseInstance As Objects.DatabaseInstance

    Public Sub New(ByVal databaseInstance As Objects.DatabaseInstance)

        InitializeComponent()
        Me.databaseInstance = databaseInstance

    End Sub

    Private Sub btnSetCredentials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCredentials.Click

        If Not Me.txtUser.Text = "" And Not Me.txtPassword.Text = "" Then

            Me.databaseInstance.setUser(Me.txtUser.Text)
            Me.databaseInstance.setPassword(Me.txtPassword.Text)
            Me.Close()

        End If

    End Sub

End Class