Public Class ScanalyzerForm

    Private settings As New Helpers.Setting
    Private initializationSetup As InitializationForm
    Private scanalyzer As Controller.Scanalyzer

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.showAllSettings(False)
        Me.showDatabaseinstances(False)

    End Sub

    Private Sub showDatabaseinstances(ByRef show As Boolean)

        Me.chklstBox.Visible = show

    End Sub

    Private Sub showIpRangeOutput(ByVal show As Boolean)

        Me.lblIpRange.Visible = show
        Me.txtIpRange.Visible = show

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        Dim about As New AboutScanalyzer

        about.Show()

    End Sub

    Private Sub ReferenzdatenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReferenzdatenToolStripMenuItem.Click



    End Sub

    Private Sub InitializeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InitializeToolStripMenuItem.Click

        Me.initializationSetup = New InitializationForm(Me.settings, Me)
        Me.initializationSetup.Show()

    End Sub

    Public Sub showUpdatedSettings()

        Me.txtIpRange.Text = Me.settings.getIpRangeAsInserted()
        Me.txtReferences.Text = Me.settings.getReferencesAsText()
        Me.txtMetrics.Text = Me.settings.getMetricsAsText()
        Me.showAllSettings(True)

    End Sub

    Private Sub showAllSettings(ByVal show As Boolean)

        Me.showIpRangeOutput(show)
        Me.lblReferences.Visible = show
        Me.txtReferences.Visible = show
        Me.txtMetrics.Visible = show
        Me.lblMetrics.Visible = show
        Me.showBtnStartScanalyzer(show)

    End Sub

    Private Sub showBtnStartScanalyzer(ByRef show As Boolean)

        Me.btnStartScanalyzer.Visible = show

    End Sub

    Private Sub btnStartScanalyzer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartScanalyzer.Click

        Me.showBtnStartScanalyzer(False)
        Me.scanalyzer = New Controller.Scanalyzer(Me.settings, Me)
        Me.scanalyzer.startScanning()
        Me.showFoundComputersAndDatabaseinstaces()

    End Sub

    Private Sub showFoundComputersAndDatabaseinstaces()

        For Each computer In Me.scanalyzer.getComputers

            For Each instance In computer.getDatabaseInstances

                Me.chklstBox.Items.Add(computer.getIp + ": " + instance.getDatabaseType, instance.getSelection)

            Next

        Next

        Me.showAllSettings(False)
        Me.showDatabaseinstances(True)

    End Sub

    Private Sub chklstBox_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstBox.ItemCheck



    End Sub

End Class
