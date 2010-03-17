Imports System.IO
Imports System.Text.RegularExpressions

Public Class DBScanner

    Public Sub scanIPRange(ByRef scanargument As String, ByRef computers As ArrayList)
        ' Set start information.
        Dim start_info As New ProcessStartInfo("nmap.exe")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = True
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True
        start_info.Arguments = "-sV --open " + scanargument

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As StreamReader = proc.StandardOutput()
        Dim std_err As StreamReader = proc.StandardError()

        ' Clean up.
        std_out.Close()
        std_err.Close()
        proc.Close()
        parseNMAPOutput(std_out.ReadToEnd(), computers)
    End Sub

    Public Sub scanIPRangeStubTest(ByVal stub As String, ByRef computers As ArrayList)
        parseNMAPOutput(stub, computers)
    End Sub

    Private Sub parseNMAPOutput(ByVal input As String, ByRef computers As ArrayList)
        Dim output As Array
        Dim newComputer As Boolean
        Dim computerPointer As Integer
        Dim ipFinder As Regex = New Regex("(\b(?:\d{1,3}\.){3}\d{1,3}\b)")
        Dim beginOfPortsFinder As Regex = New Regex("PORT\W*STATE\W*SERVICE\W*VERSION")
        Dim serviceFinder As Regex = New Regex("^([0-9]*)\/([a-z]*)\W*(open)\W*([\w\D]*)")
        newComputer = False
        output = Split(input, Environment.NewLine)
        For Each tmpTxt In output
            If newComputer Then
                If tmpTxt.Equals("") Then
                    newComputer = False
                Else
                    Dim line As Array
                    line = serviceFinder.Split(tmpTxt)
                    If line(3).Equals("open") Then
                        Dim computer As Computer
                        Dim port As Integer
                        computer = computers(computerPointer - 1)
                        port = line(1)
                        computer.addNewDatabase(port, line(4))
                    End If
                    newComputer = False
                End If
            ElseIf ipFinder.IsMatch(tmpTxt) Then
                Dim ip As Array
                ip = ipFinder.Split(tmpTxt)
                computers.Add(New Computer(ip(1)))
                computerPointer += 1
            ElseIf beginOfPortsFinder.IsMatch(tmpTxt) Then
                newComputer = True
            End If

        Next
    End Sub
End Class
