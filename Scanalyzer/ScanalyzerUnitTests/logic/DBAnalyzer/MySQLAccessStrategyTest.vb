Imports System.Collections

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Scanalyzer



'''<summary>
'''This is a test class for MySQLAccessStrategyTest and is intended
'''to contain all MySQLAccessStrategyTest Unit Tests
'''</summary>
<TestClass()> _
Public Class MySQLAccessStrategyTest


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
    '''A test for openConnection And closeConnection
    '''</summary>
    <TestMethod()> _
    Public Sub openAndCloseConnectionTest()
        Dim target As MySQLAccessStrategy = New MySQLAccessStrategy ' TODO: Initialize to an appropriate value
        Dim computer As Computer = Nothing ' TODO: Initialize to an appropriate value
        Dim computerExpected As Computer = Nothing ' TODO: Initialize to an appropriate value
        Dim databaseInstance As Integer = 0 ' TODO: Initialize to an appropriate value
        Dim expected As Boolean = False ' TODO: Initialize to an appropriate value
        Dim actual As Boolean
        actual = target.openConnection(computer, databaseInstance)
        Assert.AreEqual(computerExpected, computer)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for getInformationSchema
    '''</summary>
    <TestMethod()> _
    Public Sub getInformationSchemaTest()
        Dim target As MySQLAccessStrategy = New MySQLAccessStrategy ' TODO: Initialize to an appropriate value
        Dim expected As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ArrayList
        actual = target.getInformationSchema
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for getDatabaseNames
    '''</summary>
    <TestMethod()> _
    Public Sub getDatabaseNamesTest()
        Dim target As MySQLAccessStrategy = New MySQLAccessStrategy ' TODO: Initialize to an appropriate value
        Dim expected As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ArrayList
        actual = target.getDatabaseNames
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for getColumnNames
    '''</summary>
    <TestMethod()> _
    Public Sub getColumnNamesTest()
        Dim target As MySQLAccessStrategy = New MySQLAccessStrategy ' TODO: Initialize to an appropriate value
        Dim expected As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ArrayList
        actual = target.getColumnNames
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for getColumn
    '''</summary>
    <TestMethod()> _
    Public Sub getColumnTest()
        Dim target As MySQLAccessStrategy = New MySQLAccessStrategy ' TODO: Initialize to an appropriate value
        Dim expected As ArrayList = Nothing ' TODO: Initialize to an appropriate value
        Dim actual As ArrayList
        actual = target.getColumn
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")
    End Sub

    '''<summary>
    '''A test for MySQLAccessStrategy Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub MySQLAccessStrategyConstructorTest()
        Dim target As MySQLAccessStrategy = New MySQLAccessStrategy
        Assert.Inconclusive("TODO: Implement code to verify target")
    End Sub
End Class
