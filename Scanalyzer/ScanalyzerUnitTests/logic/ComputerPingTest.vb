Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Scanalyzer
Imports System.Collections
Imports Scanalyzer.DBScanners



'''<summary>
'''This is a test class for ComputerPingTest and is intended
'''to contain all ComputerPingTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ComputerPingTest


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
    '''A test for pingHost
    '''</summary>
    <TestMethod()> _
    Public Sub pingHostTest()

        Dim target As ComputerPing = New ComputerPing()
        Dim localIP As Object
        Dim notavaibleIP As Object

        localIP = target.pingHost("127.0.0.1")
        notavaibleIP = target.pingHost("192.168.255.50")

        Assert.AreEqual(True, localIP)
        Assert.AreEqual(False, notavaibleIP)

    End Sub

    '''<summary>
    '''A test for openPorts
    '''</summary>
    <TestMethod()> _
    Public Sub openPortsTest()

        Dim target As ComputerPing = New ComputerPing()
        Dim actual As ArrayList

        actual = target.getOpenPorts("192.168.56.3")

        Assert.AreNotEqual(0, actual.Count)

    End Sub

End Class
