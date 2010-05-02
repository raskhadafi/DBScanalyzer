Imports Scanalyzer.Helpers

Public Class InitializationForm

    Private state As STATEMACHINE
    Private metricsSelection As TabPage
    Private references As ReferenceSelectionArrayList
    Private languageCheckboxes As List(Of CheckBox)

    Private marginBottom As Integer = 5
    Private marginRight As Integer = 10
    Private marginRightExtra As Integer = marginRight + 10

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' remove unused tabs, so that the state machine makes them visible
        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        ' initialize the state machine
        state = STATEMACHINE.referenceselect
        ' loads the avaible references and displays the for selection
        loadAndPaintReferences()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub loadAndPaintReferences()

        Dim y As Integer = 0

        Helpers.SQLiteHelper.getReferences(references)
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

        For Each box In languageCheckboxes

            If box.Checked Then

                Return True

            End If

        Next

        Return False

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Select Case Me.state

            Case STATEMACHINE.referenceselect

                If Me.referenceSelected() Then

                    Me.metricsSelection = New TabPage("ReferncesDefinitionTab")
                    Me.InputTabbs.Controls.Add(Me.metricsSelection)
                    Me.InputTabbs.SelectedTab = Me.metricsSelection
                    Me.metricsSelection.Focus()
                    Me.state = STATEMACHINE.metricsselect

                Else

                    MessageBox.Show("Please select at least one reference", "No selection", MessageBoxButtons.OK)

                End If

            Case STATEMACHINE.metricsselect

                Me.Hide()

        End Select



    End Sub

    Enum STATEMACHINE

        referenceselect
        referencedef
        metricsselect

    End Enum

End Class