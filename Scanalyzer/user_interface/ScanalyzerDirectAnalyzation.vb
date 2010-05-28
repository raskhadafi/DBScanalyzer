Public Class ScanalyzerDirectAnalyzation

    Private parentClass As ScanalyzerForm

    Public Sub New(ByRef parentClass As ScanalyzerForm)

        InitializeComponent()
        Me.parentClass = parentClass

    End Sub

    Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click

        Me.parentClass.setStateToDirectAnalyzation()
        Dim computer As Objects.Computer = New Objects.Computer(Me.txtIP.Text)
        computer.addDatabaseInstance(Me.txtPort.Text, Objects.DatabaseInstance.DatabaseEnum.mysql)
        computer.getDatabaseInstance(Me.txtPort.Text).addCredentials(Me.txtUsr.Text, Me.txtPwd.Text)
        Me.parentClass.setDirectAnalyzation(computer)
        Me.parentClass.Focus()
        Me.Close()

    End Sub

End Class