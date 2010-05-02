Imports System.Collections

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Scanalyzer.Metrics



'''<summary>
'''This is a test class for MetricsTest and is intended
'''to contain all MetricsTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MetricsTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for distinctArray
    '''</summary>
    <TestMethod(), _
     DeploymentItem("Scanalyzer.exe")> _
    Public Sub distinctArrayTest()
        Dim target As Metrics_Accessor = New Metrics_Accessor ' TODO: Initialize to an appropriate value
        Dim data As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        Dim dataExpected As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        target.distinctArray(data)
        Assert.AreEqual(dataExpected, data)
        Assert.Inconclusive("A method that does not return a value cannot be verified.")
    End Sub

    '''<summary>
    '''A test for checkIfDate
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfDateTest()
        Dim target As Metrics = New Metrics ' TODO: Initialize to an appropriate value
        Dim input As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = target.checkIfDate(input)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfEmail
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfEmailTest()
        Dim target As Metrics = New Metrics ' TODO: Initialize to an appropriate value
        Dim email As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = target.checkIfEmail(email)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfGender
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfGenderTest()
        Dim target As Metrics = New Metrics ' TODO: Initialize to an appropriate value
        Dim data As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        Dim references As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        Dim expected As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim actual As Integer
        actual = target.checkIfGender(data, references)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfStreet
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfStreetTest()

        Dim target As Metrics = New Metrics()
        Dim streetNameReal As String = "Sonnengrundstrasse"
        Dim streetNameFalse As String = "Horw"
        Dim expectedReal As Integer = 100
        Dim expectedFalse As Integer = 0
        Dim actualReal As Integer
        Dim actualFalse As Integer
        Dim tableNames As ArrayList = New ArrayList

        tableNames.Add("street_de")

        actualReal = target.checkIfStreet(streetNameReal, tableNames)
        actualFalse = target.checkIfStreet(streetNameFalse, tableNames)

        Assert.AreEqual(expectedReal, actualReal)
        Assert.AreEqual(expectedFalse, actualFalse)

    End Sub
End Class
