Imports Scanalyzer.Helpers

Public Class InitializationForm

    Private state As STATEMACHINE
    Private metricsSelection As TabPage
    Private references As ReferenceSelectionArrayList

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

        For Each entry In references

            Dim label As New Label()

            label.Text = entry.reference
            label.Location = New System.Drawing.Point(0, y)
            y += 30
            Me.InputTabbs.GetControl(0).Controls.Add(label)

        Next
        


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Select Case Me.state

            Case STATEMACHINE.referenceselect

                Me.metricsSelection = New TabPage("ReferncesDefinitionTab")
                Me.InputTabbs.Controls.Add(Me.metricsSelection)
                Me.InputTabbs.SelectedTab = Me.metricsSelection
                Me.metricsSelection.Focus()
                Me.state = STATEMACHINE.metricsselect

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