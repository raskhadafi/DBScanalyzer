﻿Imports Scanalyzer.DBScanners

Public Class ScanalyzerForm

    Private settings As New Helpers.Setting
    Private initializationSetup As InitializationForm
    Private scanalyzer As Controller.Scanalyzer
    Private state As ScanalyzerState = ScanalyzerState.waitForInitialization
    Private directAnalyzationComputer As Objects.Computer

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

    Private Sub ReferenzdatenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirectAnalyzationToolStripMenuItem.Click

        Dim directAnalyzerForm As ScanalyzerDirectAnalyzation

        directAnalyzerForm = New ScanalyzerDirectAnalyzation(Me)
        directAnalyzerForm.Show()
        directAnalyzerForm.Focus()

    End Sub

    Private Sub InitializeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InitializeToolStripMenuItem.Click

        Me.initializationSetup = New InitializationForm(Me.settings, Me)
        Me.initializationSetup.Show()
        Me.state = ScanalyzerState.waitForScanning

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

    Public Sub setDirectAnalyzation(ByRef computer As Objects.Computer)

        Me.directAnalyzationComputer = computer

    End Sub

    Private Sub btnStartScanalyzer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartScanalyzer.Click

        Select Case Me.state

            Case ScanalyzerState.waitForScanning

                Me.showBtnStartScanalyzer(False)
                Me.scanalyzer = New Controller.Scanalyzer(Me.settings, Me)
                Me.scanalyzer.startScanning()
                Me.showFoundComputersAndDatabaseinstaces()
                Me.state = ScanalyzerState.waitForAnalyzing

            Case ScanalyzerState.waitForDirectAnalyzing

                Me.scanalyzer = New Controller.Scanalyzer(Me.settings, Me, Me.directAnalyzationComputer)
                Me.showBtnStartScanalyzer(False)
                Me.scanalyzer.startReadAnalyzeAndShowData()

            Case ScanalyzerState.waitForAnalyzing

                If Me.scanalyzer.checkIfLeastOneDatabaseinstanceCheckedAndFilled() Then

                    Me.showBtnStartScanalyzer(False)
                    Me.scanalyzer.startReadAnalyzeAndShowData()

                End If

        End Select

    End Sub

    Public Sub setStateToDirectAnalyzation()

        Me.state = ScanalyzerState.waitForDirectAnalyzing

    End Sub

    Private Sub showFoundComputersAndDatabaseinstaces()

        For Each computer In Me.scanalyzer.getComputers

            For Each instance In computer.getDatabaseInstances

                Me.chklstBox.Items.Add(computer.getIp + ":" + instance.getPort.ToString + ":" + instance.getDatabaseType.ToString, instance.getSelection)

            Next

        Next

        Me.showAllSettings(False)
        Me.showDatabaseinstances(True)
        Me.showBtnStartScanalyzer(True)

    End Sub

    Private Sub chklstBox_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstBox.ItemCheck

        Dim datas As Array = Me.chklstBox.Items.Item(e.Index).ToString.Split(":")
        Dim computer As Objects.Computer = Me.scanalyzer.getComputer(datas(0))

        Select Case e.NewValue

            Case CheckState.Checked

                Dim loginData As DBCredentials

                loginData = New DBCredentials(computer.getDatabaseInstance(datas(1)))

            Case CheckState.Unchecked

                Dim db As Objects.DatabaseInstance = computer.getDatabaseInstance(datas(1))

                db.setSelection(False)

        End Select

    End Sub

    Public Enum ScanalyzerState

        waitForInitialization
        waitForScanning
        waitForAnalyzing
        waitForDirectAnalyzing

    End Enum

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click

        System.Diagnostics.Process.Start(My.Settings.ProjectRoot + "\Scanalyzer\user_interface\DBScanalyzerHelp.htm")

    End Sub
End Class
