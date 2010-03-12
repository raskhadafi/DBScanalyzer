Imports System.IO

Public Class cmdPing

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Set start information.
        Dim start_info As New ProcessStartInfo("nmap.exe")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = True
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True
        start_info.Arguments = txtOutput.Text

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As StreamReader = proc.StandardOutput()
        Dim std_err As StreamReader = proc.StandardError()

        ' Display the results.
        txtStdout.Text = std_out.ReadToEnd()
        txtStderr.Text = std_err.ReadToEnd()

        ' Clean up.
        std_out.Close()
        std_err.Close()
        proc.Close()

    End Sub
End Class