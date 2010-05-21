Imports System.Collections

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Scanalyzer
Imports Scanalyzer.DBanalyzers.DBAccessStrategies
Imports Scanalyzer.Objects


'''<summary>
'''This is a test class for MSSQLAccessStrategyTest and is intended
'''to contain all MSSQLAccessStrategyTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MSSQLAccessStrategyTest


    Private testContextInstance As TestContext

    Private mssqlServer As Computer

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

        Me.mssqlServer = New Computer("192.168.56.3")
        Me.mssqlServer.addDatabaseInstance(1433, Scanalyzer.Objects.DatabaseInstance.DatabaseEnum.mssql)
        Me.mssqlServer.addCredentials("dbtest", "dbtest", 0)

    End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''A test for openConnection And closeConnection
    '''</summary>
    <TestMethod()> _
    Public Sub openAndCloseConnectionTest()

        Dim target As MSSQLAccessStrategy = New MSSQLAccessStrategy
        Dim computer As Computer = mssqlServer
        Dim expected As Boolean = True
        Dim actualOpen As Boolean
        Dim actualClose As Boolean

        actualOpen = target.openConnection(computer, 0)
        actualClose = target.closeConnection()

        Assert.AreEqual(expected, actualOpen)
        Assert.AreEqual(expected, actualClose)

    End Sub

    '''<summary>
    '''A test for getDatabaseNames
    '''</summary>
    <TestMethod()> _
    Public Sub getDatabaseNamesTest()

        Dim target As MSSQLAccessStrategy = New MSSQLAccessStrategy
        Dim computer As Computer = mssqlServer
        Dim expected As Boolean = True
        Dim actualOpen As Boolean
        Dim actualClose As Boolean
        Dim actualDatabaseNames As ArrayList

        actualOpen = target.openConnection(computer, 0)
        actualDatabaseNames = target.getDatabaseNames()
        actualClose = target.closeConnection()

        Assert.AreEqual(expected, actualOpen)
        Assert.AreEqual(expected, actualClose)
        Assert.AreNotEqual(0, actualDatabaseNames.Count)

    End Sub

    '''<summary>
    '''A test for getTableNames
    '''</summary>
    <TestMethod()> _
    Public Sub getTableNamesTest()

        Dim target As MSSQLAccessStrategy = New MSSQLAccessStrategy
        Dim computer As Computer = mssqlServer
        Dim expected As Boolean = True
        Dim actualOpen As Boolean
        Dim actualClose As Boolean
        Dim actualDatabaseNames As ArrayList
        Dim actualTableNames As ArrayList

        actualOpen = target.openConnection(computer, 0)
        actualDatabaseNames = target.getDatabaseNames()
        actualTableNames = target.getTableNames(actualDatabaseNames(0))
        actualClose = target.closeConnection()

        Assert.AreEqual(expected, actualOpen)
        Assert.AreEqual(expected, actualClose)
        Assert.AreNotEqual(0, actualDatabaseNames.Count)
        Assert.AreNotEqual(0, actualTableNames.Count)

    End Sub

    '''<summary>
    '''A test for getColumnNames
    '''</summary>
    <TestMethod()> _
    Public Sub getColumnNamesTest()

        Dim target As MSSQLAccessStrategy = New MSSQLAccessStrategy
        Dim computer As Computer = mssqlServer
        Dim expected As Boolean = True
        Dim actualOpen As Boolean
        Dim actualClose As Boolean
        Dim actualDatabaseNames As ArrayList
        Dim actualTableNames As ArrayList
        Dim actualColumnNames As ArrayList

        actualOpen = target.openConnection(computer, 0)
        actualDatabaseNames = target.getDatabaseNames()
        actualTableNames = target.getTableNames(actualDatabaseNames(0))
        actualColumnNames = target.getColumnNames(actualDatabaseNames(0), actualTableNames(0))
        actualClose = target.closeConnection()

        Assert.AreEqual(expected, actualOpen)
        Assert.AreEqual(expected, actualClose)
        Assert.AreNotEqual(0, actualDatabaseNames.Count)
        Assert.AreNotEqual(0, actualTableNames.Count)
        Assert.AreNotEqual(0, actualColumnNames.Count)

    End Sub

    '''<summary>
    '''A test for getColumn
    '''</summary>
    <TestMethod()> _
    Public Sub getColumnTest()

        Dim target As MSSQLAccessStrategy = New MSSQLAccessStrategy
        Dim computer As Computer = mssqlServer
        Dim expected As Boolean = True
        Dim actualOpen As Boolean
        Dim actualClose As Boolean
        Dim actualDatabaseNames As ArrayList
        Dim actualTableNames As ArrayList
        Dim actualColumnNames As ArrayList
        Dim actualColumn As ArrayList

        actualOpen = target.openConnection(computer, 0)
        actualDatabaseNames = target.getDatabaseNames()
        actualTableNames = target.getTableNames(actualDatabaseNames(0))
        actualColumnNames = target.getColumnNames(actualDatabaseNames(0), actualTableNames(0))
        actualColumn = target.getColumn(actualDatabaseNames(0), actualTableNames(0), actualColumnNames(0))
        actualClose = target.closeConnection()

        Assert.AreEqual(expected, actualOpen)
        Assert.AreEqual(expected, actualClose)
        Assert.AreNotEqual(0, actualDatabaseNames.Count)
        Assert.AreNotEqual(0, actualTableNames.Count)
        Assert.AreNotEqual(0, actualColumnNames.Count)
        Assert.AreNotEqual(0, actualColumn.Count)

    End Sub

    '''<summary>
    '''A test for MySQLAccessStrategy Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub MSSQLAccessStrategyConstructorTest()

        Dim target As MSSQLAccessStrategy = New MSSQLAccessStrategy

        Assert.IsNotNull(target)

    End Sub

End Class
