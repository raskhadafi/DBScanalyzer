Imports System.Collections

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Scanalyzer
Imports Scanalyzer.DBScanner.DBPingStrategy



'''<summary>
'''This is a test class for DB2PingStrategyTest and is intended
'''to contain all DB2PingStrategyTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DB2PingStrategyTest


    Private testContextInstance As TestContext

    Private ipDB2Server As String

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
    <TestInitialize()> _
    Public Sub MyTestInitialize()

        Me.ipDB2Server = "192.168.56.4"

    End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for checkPorts
    '''</summary>
    <TestMethod()> _
    Public Sub checkPortsTest()

        Dim computerPing As DBScanner.ComputerPing = New DBScanner.ComputerPing()
        Dim target As DB2PingStrategy = New DB2PingStrategy()
        Dim openPorts As ArrayList
        Dim actual As ArrayList

        openPorts = computerPing.getOpenPorts(Me.ipDB2Server)
        actual = target.checkPorts(Me.ipDB2Server, openPorts)

        Assert.IsNotNull(openPorts)
        Assert.IsNotNull(actual)

    End Sub
End Class
