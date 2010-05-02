Public Class InitializationForm

    Private state As STATEMACHINE
    Private metricsSelection As TabPage

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        Me.InputTabbs.Controls.Remove(Me.InputTabbs.TabPages(1))
        state = STATEMACHINE.referenceselect

        ' Add any initialization after the InitializeComponent() call.

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