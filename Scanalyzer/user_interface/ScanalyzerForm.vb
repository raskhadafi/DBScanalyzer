﻿Public Class ScanalyzerForm

    Private settings As New Helpers.Settings
    Private initializationSetup As InitializationForm

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.showAllSettings(False)

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
        Me.showAllSettings(True)

    End Sub

    Private Sub showAllSettings(ByVal show As Boolean)

        Me.showIpRangeOutput(show)
        Me.lblReferences.Visible = show
        Me.txtReferences.Visible = show

    End Sub

End Class
