Imports System.Net
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Text.RegularExpressions

Namespace DBScanners

    Public Class ComputerPing

        Public Function pingHost(ByRef ip As String) As Boolean

            Dim ping As New NetworkInformation.Ping
            Dim pingResponse As NetworkInformation.PingReply

            pingResponse = ping.Send(ip)

            If pingResponse.Status = IPStatus.Success Then
                Return True
            Else
                Return False
            End If

        End Function

        Public Function getOpenPorts(ByVal ip As String) As ArrayList

            Dim start_info As New ProcessStartInfo("nmap.exe")
            Dim proc As New Process()
            Dim std_out As StreamReader
            Dim std_err As StreamReader
            Dim nmapOutput As String

            start_info.UseShellExecute = False
            start_info.CreateNoWindow = True
            start_info.RedirectStandardOutput = True
            start_info.RedirectStandardError = True
            start_info.Arguments = "-n -sS -p1-65535 " + ip
            proc.StartInfo = start_info
            proc.Start()
            std_out = proc.StandardOutput
            std_err = proc.StandardError
            nmapOutput = std_out.ReadToEnd()
            std_out.Close()
            std_err.Close()
            proc.Close()

            Return parseNMAPOutput(nmapOutput)

        End Function

        Private Function parseNMAPOutput(ByVal input As String) As ArrayList

            Dim output As Array
            Dim newComputer As Boolean
            Dim computerPointer As Integer
            Dim ipFinder As Regex = New Regex("(\b(?:\d{1,3}\.){3}\d{1,3}\b)")
            Dim beginOfPortsFinder As Regex = New Regex("PORT\W*STATE")
            Dim serviceFinder As Regex = New Regex("^([0-9]*)\/([a-z]*)\W*(open|filtered)\W*([\w\D]*)")
            Dim openPorts As ArrayList = New ArrayList

            newComputer = False
            output = Split(input, Environment.NewLine)

            For Each tmpTxt In output

                If newComputer Then

                    If (tmpTxt.ToString).StartsWith("MAC") Then
                        newComputer = False
                    Else

                        If Not tmpTxt.Equals("") Then

                            Dim line As Array

                            line = serviceFinder.Split(tmpTxt)

                            If line(3).Equals("open") Then

                                openPorts.Add(Integer.Parse(line(1)))

                            End If

                        Else

                            newComputer = False

                        End If

                    End If

                ElseIf ipFinder.IsMatch(tmpTxt) Then

                    Dim ip As Array

                    ip = ipFinder.Split(tmpTxt)
                    computerPointer += 1

                ElseIf beginOfPortsFinder.IsMatch(tmpTxt) Then

                    newComputer = True

                End If

            Next

            If openPorts.Count = 0 Then

                Return Nothing

            End If

            Return openPorts

        End Function

    End Class

End Namespace