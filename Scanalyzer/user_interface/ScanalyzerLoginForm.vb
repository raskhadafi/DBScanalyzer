Public Class ScanalyzerLoginForm

    Private databaseInstance As Objects.DatabaseInstance

    Public Sub New(ByVal databaseInstance As Objects.DatabaseInstance)

        InitializeComponent()
        Me.databaseInstance = databaseInstance

        If Not Me.databaseInstance.getUser = Nothing And Not Me.databaseInstance.getPassword = Nothing Then

            Me.txtUser.Text = Me.databaseInstance.getUser
            Me.txtPassword.Text = Me.databaseInstance.getPassword

        End If

    End Sub

    Private Sub btnSetCredentials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCredentials.Click

        If Not Me.txtUser.Text = "" And Not Me.txtPassword.Text = "" Then

            Me.databaseInstance.setUser(Me.txtUser.Text)
            Me.databaseInstance.setPassword(Me.txtPassword.Text)
            Me.databaseInstance.setSelection(True)
            Me.Close()

        End If

    End Sub

End Class