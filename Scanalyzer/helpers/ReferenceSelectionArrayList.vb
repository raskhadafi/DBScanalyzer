Namespace Helpers

    Namespace Settings

        Public Structure ReferenceSelection

            Public reference As String
            Public languages As ArrayList
            Public selectedLanguages As ArrayList

            Public Sub New(ByVal name As String)

                Me.reference = name
                Me.languages = New ArrayList
                Me.selectedLanguages = New ArrayList

            End Sub

            Public Function isSelected() As Boolean

                If Me.selectedLanguages.Count = 0 Then

                    Return False

                Else

                    Return True

                End If

            End Function

            Public Function isSelectedLanguage(ByVal language As String) As Boolean

                If Me.selectedLanguages.Contains(language) Then

                    Return True

                End If

                Return False

            End Function

            Public Function hasLanguages() As Boolean


                If languages.Count > 0 Then

                    Return True

                End If

                Return False

            End Function

        End Structure

        Public Class ReferenceSelectionArrayList
            Inherits List(Of ReferenceSelection)

            Public Sub addReferenceSelection()



            End Sub

            Public Sub setReferenceAsSelected(ByVal name As String, ByVal language As String)

                Dim reference As ReferenceSelection = Me.getReferenceSelection(name)

                reference.selectedLanguages.Add(language)

            End Sub


            Public Function getReferenceSelection(ByVal term As String) As ReferenceSelection

                Dim reference As ReferenceSelection

                For Each entry In Me

                    If entry.reference.Contains(term) Then

                        reference = entry

                        Return reference

                    End If

                Next

                Return Nothing

            End Function

            Public Function checkIfContainsSelection(ByVal term As String) As Boolean

                For Each entry In Me

                    If entry.reference.Contains(term) Then

                        Return True

                    End If

                Next

                Return False

            End Function

        End Class

    End Namespace

End Namespace
