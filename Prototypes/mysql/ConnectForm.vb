'
'  dotConnect for MySQL
'  Copyright © 2002-2006 Devart. All rights reserved.
'  ConnectForm
'  Last modified:

Imports Devart.Data.MySql
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms

Namespace Samples
    Public Class ConnectForm
        Inherits Form

        ' Fields
        Private WithEvents lbHost As System.Windows.Forms.Label
        Private WithEvents edPassword As System.Windows.Forms.TextBox
        Private WithEvents lbPassword As System.Windows.Forms.Label
        Private WithEvents edUser As System.Windows.Forms.TextBox
        Private WithEvents lbUser As System.Windows.Forms.Label
        Private WithEvents lbPort As System.Windows.Forms.Label
        Private WithEvents cbHost As System.Windows.Forms.ComboBox
        Private WithEvents cbDatabase As System.Windows.Forms.ComboBox
        Private WithEvents btConnect As System.Windows.Forms.Button
        Private WithEvents btCancel As System.Windows.Forms.Button
        Private WithEvents lbDatabase As System.Windows.Forms.Label
        Private WithEvents edPort As System.Windows.Forms.NumericUpDown
        Private WithEvents panel1 As System.Windows.Forms.Panel

        Private connection As MySqlConnection
        Private retries As Integer
        Private fillHostsThread As Thread

        ' Methods
        Public Sub New()
            Me.components = Nothing
            Me.connection = Nothing
            Me.retries = 3
            Me.InitializeComponent()
        End Sub

        Public Sub New(ByVal connection As IDbConnection)
            Me.components = Nothing
            Me.connection = Nothing
            Me.retries = 3
            Me.InitializeComponent()
            Me.connection = DirectCast(connection, MySqlConnection)
            Me.edUser.Text = Me.connection.UserId
            Me.edPassword.Text = Me.connection.Password
            Me.cbHost.Text = Me.connection.Host
            Me.edPort.Text = Me.connection.Port.ToString
            Me.cbDatabase.Text = Me.connection.Database
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.lbHost = New System.Windows.Forms.Label()
            Me.edPassword = New System.Windows.Forms.TextBox()
            Me.lbPassword = New System.Windows.Forms.Label()
            Me.edUser = New System.Windows.Forms.TextBox()
            Me.lbUser = New System.Windows.Forms.Label()
            Me.lbPort = New System.Windows.Forms.Label()
            Me.cbHost = New System.Windows.Forms.ComboBox()
            Me.cbDatabase = New System.Windows.Forms.ComboBox()
            Me.btConnect = New System.Windows.Forms.Button()
            Me.btCancel = New System.Windows.Forms.Button()
            Me.lbDatabase = New System.Windows.Forms.Label()
            Me.edPort = New System.Windows.Forms.NumericUpDown()
            Me.panel1 = New System.Windows.Forms.Panel()
            CType(Me.edPort, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lbHost
            '
            Me.lbHost.Location = New System.Drawing.Point(10, 81)
            Me.lbHost.Name = "lbHost"
            Me.lbHost.Size = New System.Drawing.Size(64, 16)
            Me.lbHost.TabIndex = 2
            Me.lbHost.Text = "Host"
            '
            'edPassword
            '
            Me.edPassword.Location = New System.Drawing.Point(88, 46)
            Me.edPassword.Name = "edPassword"
            Me.edPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.edPassword.Size = New System.Drawing.Size(113, 20)
            Me.edPassword.TabIndex = 1
            '
            'lbPassword
            '
            Me.lbPassword.Location = New System.Drawing.Point(10, 49)
            Me.lbPassword.Name = "lbPassword"
            Me.lbPassword.Size = New System.Drawing.Size(64, 16)
            Me.lbPassword.TabIndex = 1
            Me.lbPassword.Text = "Password"
            '
            'edUser
            '
            Me.edUser.Location = New System.Drawing.Point(88, 14)
            Me.edUser.Name = "edUser"
            Me.edUser.Size = New System.Drawing.Size(113, 20)
            Me.edUser.TabIndex = 0
            '
            'lbUser
            '
            Me.lbUser.Location = New System.Drawing.Point(10, 17)
            Me.lbUser.Name = "lbUser"
            Me.lbUser.Size = New System.Drawing.Size(64, 16)
            Me.lbUser.TabIndex = 0
            Me.lbUser.Text = "User"
            '
            'lbPort
            '
            Me.lbPort.Location = New System.Drawing.Point(11, 113)
            Me.lbPort.Name = "lbPort"
            Me.lbPort.Size = New System.Drawing.Size(64, 16)
            Me.lbPort.TabIndex = 3
            Me.lbPort.Text = "Port"
            '
            'cbHost
            '
            Me.cbHost.Location = New System.Drawing.Point(88, 78)
            Me.cbHost.Name = "cbHost"
            Me.cbHost.Size = New System.Drawing.Size(113, 21)
            Me.cbHost.TabIndex = 2
            '
            'cbDatabase
            '
            Me.cbDatabase.Location = New System.Drawing.Point(88, 142)
            Me.cbDatabase.Name = "cbDatabase"
            Me.cbDatabase.Size = New System.Drawing.Size(113, 21)
            Me.cbDatabase.TabIndex = 4
            '
            'btConnect
            '
            Me.btConnect.Location = New System.Drawing.Point(36, 200)
            Me.btConnect.Name = "btConnect"
            Me.btConnect.Size = New System.Drawing.Size(75, 24)
            Me.btConnect.TabIndex = 8
            Me.btConnect.Text = "Connect"
            '
            'btCancel
            '
            Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btCancel.Location = New System.Drawing.Point(124, 200)
            Me.btCancel.Name = "btCancel"
            Me.btCancel.Size = New System.Drawing.Size(75, 24)
            Me.btCancel.TabIndex = 9
            Me.btCancel.Text = "Cancel"
            '
            'lbDatabase
            '
            Me.lbDatabase.Location = New System.Drawing.Point(11, 145)
            Me.lbDatabase.Name = "lbDatabase"
            Me.lbDatabase.Size = New System.Drawing.Size(64, 16)
            Me.lbDatabase.TabIndex = 6
            Me.lbDatabase.Text = "Database"
            '
            'edPort
            '
            Me.edPort.Location = New System.Drawing.Point(88, 110)
            Me.edPort.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
            Me.edPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.edPort.Name = "edPort"
            Me.edPort.Size = New System.Drawing.Size(113, 20)
            Me.edPort.TabIndex = 3
            Me.edPort.Value = New Decimal(New Integer() {3306, 0, 0, 0})
            '
            'panel1
            '
            Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.panel1.Controls.Add(Me.cbHost)
            Me.panel1.Controls.Add(Me.cbDatabase)
            Me.panel1.Controls.Add(Me.lbDatabase)
            Me.panel1.Controls.Add(Me.edPort)
            Me.panel1.Controls.Add(Me.lbPort)
            Me.panel1.Controls.Add(Me.lbHost)
            Me.panel1.Controls.Add(Me.edPassword)
            Me.panel1.Controls.Add(Me.lbPassword)
            Me.panel1.Controls.Add(Me.edUser)
            Me.panel1.Controls.Add(Me.lbUser)
            Me.panel1.Location = New System.Drawing.Point(12, 11)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(216, 177)
            Me.panel1.TabIndex = 7
            '
            'ConnectForm
            '
            Me.AcceptButton = Me.btConnect
            'Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
            Me.CancelButton = Me.btCancel
            Me.ClientSize = New System.Drawing.Size(239, 236)
            Me.Controls.Add(Me.btConnect)
            Me.Controls.Add(Me.btCancel)
            Me.Controls.Add(Me.panel1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            'Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ConnectForm"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Connect"
            CType(Me.edPort, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panel1.ResumeLayout(False)
            Me.panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        ' Methods
        Private Sub AddHostItem(ByVal host As String)
            Me.cbHost.Items.Add(host)
        End Sub

        Private Sub btConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btConnect.Click
            Me.connection.Close()
            Me.connection.UserId = Me.edUser.Text
            Me.connection.Password = Me.edPassword.Text
            Me.connection.Host = Me.cbHost.Text
            Me.connection.Port = Convert.ToInt32(Me.edPort.Text)
            Me.connection.Database = Me.cbDatabase.Text
            Try
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Me.connection.Open()
                Windows.Forms.Cursor.Current = Cursors.Default
                MyBase.DialogResult = Windows.Forms.DialogResult.OK
            Catch exception As MySqlException
                Windows.Forms.Cursor.Current = Cursors.Default
                Me.retries -= 1
                If (Me.retries = 0) Then
                    MyBase.DialogResult = Windows.Forms.DialogResult.Cancel
                End If
                Select Case exception.Code
                    Case &H7D3, &H7D5
                        MyBase.ActiveControl = Me.cbHost
                        Exit Select
                    Case &H415
                        MyBase.ActiveControl = Me.edUser
                        Exit Select
                End Select
                Throw
            End Try
        End Sub

        Private Sub cdDatabase_DropDown(ByVal sender As Object, ByVal e As EventArgs) Handles cbDatabase.DropDown
            Me.cbDatabase.Items.Clear()
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Dim databaseConnection As New MySqlConnection()
            databaseConnection.Host = Me.cbHost.Text
            databaseConnection.UserId = Me.edUser.Text
            databaseConnection.Password = Me.edPassword.Text
            databaseConnection.Port = CInt(Me.edPort.Value)
            Try
                Try
                    databaseConnection.Open()
                    Dim command As IDbCommand = New MySqlCommand("show databases", databaseConnection)
                    Dim reader As IDataReader = command.ExecuteReader
                    Try
                        Do While reader.Read
                            Me.cbDatabase.Items.Add(reader.Item(0))
                        Loop
                    Finally
                        reader.Dispose()
                    End Try
                Catch exception As exception
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End Try
            Finally
                Windows.Forms.Cursor.Current = Cursors.Default
                databaseConnection.Close()
            End Try
        End Sub

        Private Sub ConnectForm_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
            Try
                If (Not Me.fillHostsThread Is Nothing) Then
                    Me.fillHostsThread.Abort()
                End If
            Catch
            End Try
        End Sub

        Private Sub FillHostListThreadFunc()
            MyBase.Invoke(New MethodInvoker(AddressOf Me.SetStartingCursor))
            Try
                Dim sources As DataTable = MySqlProviderFactory.Instance.CreateDataSourceEnumerator.GetDataSources
                Dim hostInfo As DataRow
                For Each hostInfo In sources.Rows
                    Try
                        If Not (((Me.cbHost Is Nothing) OrElse Me.cbHost.IsDisposed) OrElse Me.cbHost.Disposing) Then
                            Me.cbHost.Invoke(New AddHostItemDelegate(AddressOf Me.AddHostItem), New Object() {hostInfo.Item("ServerName").ToString})
                        End If
                    Catch
                        Return
                    End Try
                Next
            Finally
                Try
                    MyBase.Invoke(New MethodInvoker(AddressOf Me.SetDefaultCursor))
                Catch
                End Try
            End Try
        End Sub

        Private Sub SetDefaultCursor()
            Me.Cursor = Cursors.Default
        End Sub

        Private Sub SetStartingCursor()
            Me.Cursor = Cursors.AppStarting
        End Sub

        Private Sub ConnectForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.fillHostsThread = New Thread(New ThreadStart(AddressOf Me.FillHostListThreadFunc))
            Me.fillHostsThread.Start()
        End Sub

        ' Nested Types
        Private Delegate Sub AddHostItemDelegate(ByVal host As String)
    End Class
End Namespace