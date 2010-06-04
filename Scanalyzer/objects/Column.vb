Namespace Objects

    Public Class Column

        Private name As String
        Private containsReferencedata As Boolean
        Private totalFound As Decimal
        Private equalsToData As Decimal
        Private metric As Helpers.Settings.Metric
        Private rowCount As Integer

        Public Sub New(ByVal name As String)

            Me.name = name
            Me.containsReferencedata = False
            Me.totalFound = 0
            Me.equalsToData = 0
            Me.rowCount = 0
            Me.metric = Helpers.Settings.Metric.noMetric

        End Sub

        Public Sub setRowCount(ByVal count As Integer)

            Me.rowCount = count

        End Sub

        Public Function getRowCount() As Integer

            Return Me.rowCount

        End Function

        Public Sub setMetricFound(ByVal metric As Helpers.Settings.Metric)

            Me.metric = metric

        End Sub

        Public Function getName() As String

            Return Me.name

        End Function

        Public Sub setContainsReferencedata(ByVal value As Boolean)

            Me.containsReferencedata = value

        End Sub

        Public Function getContainsRefernecedata() As Boolean

            Return Me.containsReferencedata

        End Function

        Public Sub setFound(ByVal totalFound As Decimal)

            Me.totalFound = totalFound

        End Sub

        Public Function getFound() As Decimal

            Return Me.totalFound

        End Function

        Public Sub setEquals(ByVal value As Decimal)

            Me.equalsToData = value

        End Sub

        Public Function getEquals() As Decimal

            Return Me.equalsToData

        End Function

    End Class

End Namespace