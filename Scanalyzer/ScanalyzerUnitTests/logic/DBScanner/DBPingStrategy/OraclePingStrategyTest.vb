Imports System.Collections

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Scanalyzer
Imports Scanalyzer.DBScanner.DBPingStrategy



'''<summary>
'''This is a test class for OraclePingStrategyTest and is intended
'''to contain all OraclePingStrategyTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OraclePingStrategyTest


    Private testContextInstance As TestContext

    Private ipOracleServer As String

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
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
    <TestInitialize()> _
    Public Sub MyTestInitialize()

        Me.ipOracleServer = "192.168.56.3"

    End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region

    '''<summary>
    '''A test for tryAllPorts
    '''</summary>
    <TestMethod()> _
    Public Sub tryAllPortsTest()

        Dim computerPing As DBScanner.ComputerPing = New DBScanner.ComputerPing()
        Dim target As OraclePingStrategy = New OraclePingStrategy()
        Dim openPorts As ArrayList
        Dim actual As ArrayList

        openPorts = computerPing.getOpenPorts(Me.ipOracleServer)
        actual = target.checkPorts(Me.ipOracleServer, openPorts)

        Assert.IsNotNull(openPorts)
        Assert.IsNotNull(actual)

    End Sub

End Class
