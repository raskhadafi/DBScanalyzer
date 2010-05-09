﻿Imports Scanalyzer.Helpers
Imports System.Text.RegularExpressions

Public Class InitializationForm

    Private state As STATEMACHINE
    Private metricsSelection, ipRangeSelection As TabPage
    Private references As Settings.ReferenceSelectionArrayList
    Private languageCheckboxes As List(Of CheckBox)
    Private settings As Helpers.Setting

    Private marginBottom As Integer = 5
    Private marginRight As Integer = 10
    Private marginRightExtra As Integer = marginRight + 10

    Public Sub New(ByRef settings As Helpers.Setting, ByRef parent As ScanalyzerForm)

        Me.settings = settings
        Me.Owner = parent
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' remove unused tabs, so that the state machine makes them visible
        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        ' initialize the state machine

        If Me.settings.initialized Then

            Me.state = STATEMACHINE.loadSettings

        Else

            Me.state = STATEMACHINE.initializeReferenceSelection

        End If
        ' loads the avaible references and displays the for selection
        UpdateState()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub loadAndShowReferences()

        Dim y As Integer = 0

        If Not Me.settings.initialized Then

            Helpers.SQLiteHelper.getReferences(Me.references)

        Else

            Me.references = Me.settings.getReferences()

        End If

        Me.languageCheckboxes = New List(Of CheckBox)

        For Each entry In references

            Dim label As New Label()

            label.Text = entry.reference
            label.Location = New System.Drawing.Point(0, y)
            y += label.Height + marginBottom
            Me.InputTabbs.GetControl(0).Controls.Add(label)

            If entry.hasLanguages Then

                Dim x As Integer = 0

                For Each language In entry.languages

                    Dim languageLabel As New Label()
                    Dim languageCheckbox As New CheckBox()

                    languageLabel.Text = language
                    languageLabel.Location = New System.Drawing.Point(x, y)
                    x += languageLabel.Width + marginRight
                    languageCheckbox.Name = entry.reference + "_" + language
                    languageCheckbox.Location = New System.Drawing.Point(x, y - 5)

                    If entry.isSelectedLanguage(language) Then

                        languageCheckbox.Checked = True

                    End If

                    x += languageCheckbox.Width + marginRightExtra
                    Me.InputTabbs.GetControl(0).Controls.Add(languageLabel)
                    Me.InputTabbs.GetControl(0).Controls.Add(languageCheckbox)
                    Me.languageCheckboxes.Add(languageCheckbox)

                Next

                y += label.Height + marginBottom

            End If

        Next



    End Sub

    Private Function referenceSelected() As Boolean

        For Each box In Me.languageCheckboxes

            If box.Checked Then

                Return True

            End If

        Next

        Return False

    End Function

    Private Sub updateReferenceSelection()

        For Each box In Me.languageCheckboxes

            If box.Checked Then

                Dim strings As Array = box.Name.Split("_")

                Me.references.getSetReferenceSelectionSelected(strings(0), strings(1))

            End If

        Next

        Me.settings.addReferences(Me.references)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.UpdateState()

    End Sub

    Private Sub UpdateState()

        Select Case Me.state

            Case STATEMACHINE.referenceSelection

                If Me.referenceSelected() Then

                    Me.updateReferenceSelection()
                    Me.state = STATEMACHINE.initializeMetricsSelection
                    Me.UpdateState()

                Else

                    MessageBox.Show("Please select at least one reference", "No selection", MessageBoxButtons.OK)

                End If

            Case STATEMACHINE.initializeReferenceSelection

                Me.loadAndShowReferences()
                Me.loadAndShowIPRange()
                Me.state = STATEMACHINE.referenceSelection

            Case STATEMACHINE.initializeMetricsSelection

                If Me.metricsSelection Is Nothing Then

                    initializeMetricsSelection()

                Else

                    Me.state = STATEMACHINE.initializeIPRangeInput
                    Me.UpdateState()

                End If

            Case STATEMACHINE.initializeIPRangeInput

                If Me.ipRangeSelection Is Nothing Then

                    Me.ipRangeSelection = Me.IPRangeTab
                    Me.InputTabbs.Controls.Add(Me.ipRangeSelection)
                    Me.InputTabbs.SelectedTab = Me.ipRangeSelection
                    Me.ipRangeSelection.Focus()
                    Me.state = STATEMACHINE.ipRangeInput

                End If

            Case STATEMACHINE.ipRangeInput

                Dim form As ScanalyzerForm = Me.Owner

                checkIpRangeInput()
                form.showUpdatedSettings()
                Me.Close()

            Case STATEMACHINE.loadSettings

                Me.loadAndShowReferences()
                Me.loadAndShowIPRange()
                Me.state = STATEMACHINE.referenceSelection

        End Select

    End Sub

    Private Sub initializeMetricsSelection()

        Dim x As Integer
        Dim label As New Label

        Me.metricsSelection = Me.MetricsSelectionTab
        label.Text = "Metrics:"
        label.Location = New System.Drawing.Point(5, 5)
        x = 0 + 5 + label.Height
        Me.metricsSelection.Controls.Add(label)

        For Each metric In Me.settings.getAvaibleMetrics

            Dim metricCheckBox As New CheckBox

            metricCheckBox.Location = New System.Drawing.Point(5, x)
            metricCheckBox.Text = metric.ToString
            Me.metricsSelection.Controls.Add(metricCheckBox)
            x += metricCheckBox.Height + 5

        Next

        Me.InputTabbs.Controls.Add(Me.metricsSelection)
        Me.InputTabbs.SelectedTab = Me.metricsSelection
        Me.metricsSelection.Focus()

    End Sub

    Private Sub loadAndShowIPRange()


        If Me.settings.initialized Then

            Me.txtIPRange.Text = Me.settings.getIpRangeAsInserted

        Else

            Me.txtIPRange.Text = "0.0.0.0"

        End If

    End Sub

    Private Sub checkIpRangeInput()

        If Not Me.txtIPRange.Text.Length = 0 Then

            Dim checkIPRegex As New Regex("^\b(?:\d{1,3}\.){3}\d{1,3}\b$")
            Dim checkIPRangeRegex As New Regex("^\b(?:\d{1,3}\.){3}\d{1,3}\b-\b(?:\d{1,3}\.){0}\d{1,3}\b$")

            If checkIPRegex.IsMatch(txtIPRange.Text) Then

                Me.settings.addIP(txtIPRange.Text)

            ElseIf checkIPRangeRegex.IsMatch(Me.txtIPRange.Text) Then

                Me.settings.addIPRange(txtIPRange.Text)

            Else

                showIPInputInformations()

            End If


        Else

            showIPInputInformations()

        End If

    End Sub

    Private Sub showIPInputInformations()

        MessageBox.Show("Please insert an IP or an IP range." + vbNewLine + vbNewLine + "Examples:" + vbNewLine + "192.168.0.0 or 121.124.45.23-254", "No IP", MessageBoxButtons.OK)

    End Sub

    Enum STATEMACHINE

        initializeReferenceSelection
        referenceSelection

        loadSettings

        initializeMetricsSelection
        metricsSelection

        initializeIPRangeInput
        ipRangeInput

    End Enum

End Class