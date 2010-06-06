Imports Scanalyzer.Helpers
Imports System.Text.RegularExpressions

Public Class InitializationForm

    Private state As STATEMACHINE
    Private metricsSelection, ipRangeSelection As TabPage
    Private references As Settings.ReferenceSelectionArrayList
    Private metrics As Settings.MetricsSelectionArrayList
    Private languageCheckboxes As List(Of CheckBox)
    Private metricCheckboxes As List(Of CheckBox)
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

        UpdateState()

    End Sub

    Private Sub UpdateState()

        Select Case Me.state

            Case STATEMACHINE.loadSettings

                ' this is executed for a reinitizialization
                Me.loadAndShowReferences()
                Me.loadMetrics()
                Me.loadIPRange()
                Me.state = STATEMACHINE.checkReferenceSelection

            Case STATEMACHINE.initializeReferenceSelection

                ' initialized first, shows the reference selection
                Me.loadAndShowReferences()
                Me.loadIPRange()
                Me.state = STATEMACHINE.checkReferenceSelection

            Case STATEMACHINE.checkReferenceSelection

                ' checks if references selected
                If Me.referenceSelected() Then

                    Me.updateReferenceSelection()
                    Me.state = STATEMACHINE.initializeMetricsSelection
                    Me.UpdateState()

                Else

                    MessageBox.Show("Please select at least one reference", "No selection", MessageBoxButtons.OK)

                End If

            Case STATEMACHINE.checkIpRangeInput

                ' checks ip range input, updates settings and closes the form
                Dim form As ScanalyzerForm = Me.Owner

                If isIpRangeValide() Then

                    Me.updateIpInput()
                    form.showUpdatedSettings()
                    Me.Close()

                End If

            Case STATEMACHINE.checkMetricsSelection

                ' checks metric selections and initializes the ip range input
                If Me.metricSelected() Then

                    Me.updateMetricsSelection()
                    Me.state = STATEMACHINE.initializeIPRangeInput
                    Me.UpdateState()

                Else

                    MessageBox.Show("Please select at least one metric", "No selection", MessageBoxButtons.OK)

                End If

            Case STATEMACHINE.initializeMetricsSelection

                ' initializes and shows the metrics
                If Me.metricsSelection Is Nothing Then

                    Me.initializeMetricsSelection()

                Else

                    Me.InputTabbs.Controls.Add(Me.metricsSelection)
                    Me.InputTabbs.SelectedTab = Me.metricsSelection
                    Me.metricsSelection.Focus()

                End If

                Me.state = STATEMACHINE.checkMetricsSelection

            Case STATEMACHINE.initializeIPRangeInput

                ' initializes the ip range input
                If Me.ipRangeSelection Is Nothing Then

                    Me.ipRangeSelection = Me.IPRangeTab
                    Me.InputTabbs.Controls.Add(Me.ipRangeSelection)
                    Me.InputTabbs.SelectedTab = Me.ipRangeSelection
                    Me.ipRangeSelection.Focus()
                    Me.state = STATEMACHINE.checkIpRangeInput

                End If

        End Select

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

            Dim strings As Array = box.Name.Split("_")

            If box.Checked Then

                Me.references.setReferenceAsSelected(Strings(0), Strings(1))
            Else

                Me.references.removeReferenceIfSelected(strings(0), strings(1))

            End If

        Next

        Me.settings.addReferences(Me.references)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.UpdateState()

    End Sub

    Private Sub loadMetrics()

        Dim x As Integer
        Dim label As New Label

        Me.metrics = Me.settings.getMetrics
        Me.metricsSelection = Me.MetricsSelectionTab
        Me.metricCheckboxes = New List(Of CheckBox)
        label.Text = "Metrics:"
        label.Location = New System.Drawing.Point(5, 5)
        x = 0 + 5 + label.Height
        Me.metricsSelection.Controls.Add(label)

        For Each metric In Me.metrics.getAvaibleMetris()

            Dim metricCheckBox As New CheckBox

            metricCheckBox.Location = New System.Drawing.Point(5, x)
            metricCheckBox.Text = metric.ToString
            metricCheckBox.Name = metric.ToString
            Me.metricsSelection.Controls.Add(metricCheckBox)
            Me.metricCheckboxes.Add(metricCheckBox)

            If Me.metrics.isSelected(metric) Then

                metricCheckBox.Checked = True

            End If

            x += metricCheckBox.Height + 5

        Next

    End Sub

    Private Sub updateMetricsSelection()

        For Each metricBox In Me.metricCheckboxes

            If metricBox.Checked Then

                Me.metrics.setMetricAsSelected(metricBox.Name)

            Else

                Me.metrics.removeMetricIfSelected(metricBox.Name)

            End If

        Next

        Me.settings.addMetrics(Me.metrics)

    End Sub

    Private Sub initializeMetricsSelection()

        Dim x As Integer
        Dim label As New Label

        Me.metrics = New Settings.MetricsSelectionArrayList
        Me.metricsSelection = Me.MetricsSelectionTab
        Me.metricCheckboxes = New List(Of CheckBox)
        label.Text = "Metrics:"
        label.Location = New System.Drawing.Point(5, 5)
        x = 0 + 5 + label.Height
        Me.metricsSelection.Controls.Add(label)

        For Each metric In Me.metrics.getAvaibleMetris()

            Dim metricCheckBox As New CheckBox

            metricCheckBox.Location = New System.Drawing.Point(5, x)
            metricCheckBox.Text = metric.ToString
            metricCheckBox.Name = metric.ToString
            Me.metricsSelection.Controls.Add(metricCheckBox)
            Me.metricCheckboxes.Add(metricCheckBox)
            x += metricCheckBox.Height + 5

        Next

        Me.InputTabbs.Controls.Add(Me.metricsSelection)
        Me.InputTabbs.SelectedTab = Me.metricsSelection
        Me.metricsSelection.Focus()

    End Sub

    Private Function metricSelected() As Boolean

        For Each metric In Me.metricCheckboxes

            If metric.Checked Then

                Return True

            End If

        Next

        Return False

    End Function

    Private Sub loadIPRange()


        If Me.settings.initialized Then

            Me.txtIPRange.Text = Me.settings.getIpRangeAsInserted

        Else

            Me.txtIPRange.Text = "0.0.0.0"

        End If

    End Sub

    Private Function isIpRangeValide() As Boolean

        If Not Me.txtIPRange.Text.Length = 0 Then

            If Helper.checkIPRegex.IsMatch(txtIPRange.Text) Then

                Return True

            ElseIf Helper.checkIPRangeRegex.IsMatch(Me.txtIPRange.Text) Then

                Return True

            End If

        End If

        Return False

    End Function

    Private Sub updateIpInput()

        If Helper.checkIPRegex.IsMatch(txtIPRange.Text) Then

            Me.settings.addIP(txtIPRange.Text)

        ElseIf Helper.checkIPRangeRegex.IsMatch(Me.txtIPRange.Text) Then

            Me.settings.addIPRange(txtIPRange.Text)

        End If

    End Sub

    Private Sub showIPInputInformations()

        MessageBox.Show("Please insert an IP or an IP range." + vbNewLine + vbNewLine + "Examples:" + vbNewLine + "IP: 192.168.0.0" + vbNewLine + "IP-Range: 121.124.45.23-254", "No IP", MessageBoxButtons.OK)

    End Sub

    Enum STATEMACHINE

        initializeReferenceSelection
        checkReferenceSelection

        loadSettings

        initializeMetricsSelection
        checkMetricsSelection

        initializeIPRangeInput
        checkIpRangeInput

    End Enum

End Class