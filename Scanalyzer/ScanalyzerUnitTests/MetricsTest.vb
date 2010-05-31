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
End Class
