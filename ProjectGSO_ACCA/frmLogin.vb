
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Net.Mail

Public Class frmLogin

    Dim attempts As Integer
    Dim verificationCode As String = Guid.NewGuid().ToString

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim user_type As String

            If TXTUSERNAME.Text = String.Empty And TXTPW.Text = String.Empty Then
                MsgBox("Please enter your username and password", vbOKOnly + vbInformation)
            Else
                con.Open()

                cm = New MySqlCommand("SELECT username, password, user_type, login_name FROM rms_user WHERE username= '" & TXTUSERNAME.Text & "' AND password='" & TXTPW.Text & "'", con)
                cm.ExecuteNonQuery()

                dr = cm.ExecuteReader

                dr.Read()




                If dr.HasRows Then
                    user_type = dr.Item("user_type")
                    If MsgBox("Successfully Login!", vbOKOnly + vbInformation) = vbOK Then
                        If user_type = "GSO Head" Then
                            With frmMainForm
                                .LBLLOGINANME.Text = dr.Item("login_name").ToString
                                .LBLROLE.Text = user_type

                                .Show()
                            End With
                            Me.Close()
                        ElseIf user_type = "Staff" Then
                            With frmStaffMainForm
                                .LBLLOGINANME.Text = dr.Item("login_name").ToString
                                .LBLROLE.Text = user_type
                                .Show()
                            End With
                            Me.Close()

                        End If
                    End If
                Else

                    attempts = attempts + 1
                    TXTPW.Clear()
                    TXTUSERNAME.Clear()
                    TXTUSERNAME.Focus()

                    MsgBox("WARNING: You entered incorrect password!", vbOK + vbInformation)

                    If attempts > 3 Then
                        If MsgBox("System will be going to terminate, you entered an incorrect password consecutively!", vbOK + vbCritical) Then
                            End
                        End If
                    End If
                    dr.Close()


                    con.Close()

                    Exit Sub


                End If

                dr.Close()


                con.Close()

            End If



        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        attempts = 0

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub
End Class