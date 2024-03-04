
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frmBackupAndRestore
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dbFile As String
        Dim BKP_SaveFileDialog As New SaveFileDialog
        Try
            BKP_SaveFileDialog.Filter = "SQL Dump File (*.sql)|*.sql|All files  (*.*)|*.*"
            BKP_SaveFileDialog.FileName = "General Service Office (BACKUP) " + Date.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".sql"

            If BKP_SaveFileDialog.ShowDialog = DialogResult.OK Then
                con.Open()

                dbFile = BKP_SaveFileDialog.FileName
                Dim bkpProcess As New Process
                bkpProcess.StartInfo.FileName = "cmd.exe"
                bkpProcess.StartInfo.UseShellExecute = False
                bkpProcess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                bkpProcess.StartInfo.RedirectStandardInput = True
                bkpProcess.StartInfo.RedirectStandardOutput = True
                bkpProcess.Start()

                Dim bkpStream As StreamWriter = bkpProcess.StandardInput
                Dim myStreamReader As StreamReader = bkpProcess.StandardOutput

                Dim usr As String = "root"
                Dim pass As String = ""
                Dim lochost As String = "localhost"
                Dim dbName As String = "rms_gso"

                bkpStream.WriteLine("mysqldump --user=" & usr & " --password=" & pass & " -h " & lochost & " " & dbName & " > """ + dbFile + """")
                bkpStream.Close()
                bkpProcess.WaitForExit()
                bkpProcess.Close()
                con.Close()
                MessageBox.Show("Database Successfully Back up!", "Back up Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Database Back up Failed!", "Back up Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dbFile As String
        Dim RESTORE_OpenFileDialog As New SaveFileDialog

        Try
            RESTORE_OpenFileDialog.Filter = "SQL Dump File (*.sql)|*.sql|All files  (*.*)|*.*"

            If RESTORE_OpenFileDialog.ShowDialog = DialogResult.OK Then
                con.Open()
                dbFile = RESTORE_OpenFileDialog.FileName
                Dim bkpProcess As New Process
                bkpProcess.StartInfo.FileName = "cmd.exe"
                bkpProcess.StartInfo.UseShellExecute = False
                bkpProcess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                bkpProcess.StartInfo.RedirectStandardInput = True
                bkpProcess.StartInfo.RedirectStandardOutput = True
                bkpProcess.Start()

                Dim bkpStream As StreamWriter = bkpProcess.StandardInput
                Dim myStreamReader As StreamReader = bkpProcess.StandardOutput

                Dim usr As String = "root"
                Dim pass As String = ""
                Dim lochost As String = "localhost"
                Dim dbName As String = "rms_gso"
                bkpStream.WriteLine("mysql --user=" & usr & " --password=" & pass & " -h " & lochost & " " & dbName & " < """ + dbFile + """")
                bkpStream.Close()
                bkpProcess.WaitForExit()
                bkpProcess.Close()
                con.Close()
                MessageBox.Show("Database Successfully Restored!", "Restored Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'eyesdb.sql
            End If
        Catch ex As Exception
            MessageBox.Show("Restoring Database Failed!", "Restore Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With frmSystemSettings
            .Show()
        End With
        Me.Close()
    End Sub
End Class