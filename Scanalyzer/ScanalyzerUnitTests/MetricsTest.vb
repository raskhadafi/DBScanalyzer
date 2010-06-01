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
    '''A test for checkIfDate
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfDateTest()
        Dim inputMySQLDate As String = "2006-02-28 16:10:58"
        Dim inputMySQLDataFalse As String = "20063-02-28 16:10:58"
        Dim retInputMySQLDate As Boolean
        Dim retInputMySQLDateFalse As Boolean
        retInputMySQLDate = Metrics.checkIfDate(inputMySQLDate)
        retInputMySQLDateFalse = Metrics.checkIfDate(inputMySQLDataFalse)
        Assert.IsTrue(retInputMySQLDate)
        Assert.IsFalse(retInputMySQLDateFalse)
    End Sub

    '''<summary>
    '''A test for checkIfDate
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfDateTest1()
        Dim input As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfDate(input)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfEmail
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfEmailTest()
        Dim email As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfEmail(email)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfGender
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfGenderTest()
        Dim data As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfGender(data)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfISOcode
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfISOcodeTest()
        Dim isoCode As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim isoCodeExpected As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfISOcode(isoCode)
        Assert.AreEqual(isoCodeExpected, isoCode)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfPhone
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfPhoneTest()
        Dim phoneNumber As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfPhone(phoneNumber)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfPlace
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfPlaceTest()
        Dim place As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfPlace(place)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfStreet
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfStreetTest()
        Dim streetName As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfStreet(streetName)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for checkIfURI
    '''</summary>
    <TestMethod()> _
    Public Sub checkIfURITest()
        Dim uri As String = String.Empty ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = Metrics.checkIfURI(uri)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub
End Class
