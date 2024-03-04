Imports MySql.Data.MySqlClient
Public Class frmUserAccount

    Dim name As New Label

    Dim user_type As New Label

    Dim status As New Label

    Dim date_created As New Label

    Dim change_pw As New Button

    Dim modify_user As New Button

    Dim delete_user As New Button

    Dim newPanel As New Panel
    Sub FillUsers()

        flowUserPanel.Controls.Clear()

        flowUserPanel.AutoScroll = True


        Try
            con.Open()

            cm = New MySqlCommand("SELECT * FROM rms_user WHERE status='Active'", con)

            dr = cm.ExecuteReader

            While dr.Read

                newPanel = New Panel
                newPanel.Size = New Size(364, 175)
                newPanel.BorderStyle = BorderStyle.FixedSingle

                name = New Label
                name.Text = "UserName:" & Space(2) & dr.Item("username").ToString
                name.AutoSize = False
                name.Width = 150
                name.ForeColor = Color.Black
                name.Location = New Point(21, 34)
                name.Font = New Font("Bahnschrift Light", 9.75)


                user_type = New Label
                user_type.Text = "User Type: " & Space(2) & dr.Item("user_type").ToString
                user_type.AutoSize = False
                user_type.Width = 150
                user_type.ForeColor = Color.Black
                user_type.Location = New Point(194, 34)
                user_type.Font = New Font("Bahnschrift Light", 9.75)

                status = New Label
                status.Text = "Status: " & Space(2) & dr.Item("status").ToString
                status.ForeColor = Color.Black
                status.AutoSize = False
                status.Width = 150
                status.Location = New Point(41, 71)
                status.Font = New Font("Bahnschrift Light", 9.75)


                date_created = New Label
                date_created.AutoSize = False
                date_created.Width = 150
                date_created.Text = "Date Created: " & Format(CDate(dr.Item("date_created")), "yyyy/MM/dd")
                date_created.ForeColor = Color.Black
                date_created.Location = New Point(194, 71)
                date_created.Font = New Font("Bahnschrift Light", 9.75)


                change_pw = New Button
                change_pw.Text = "Change Password"
                change_pw.Size = New Size(105, 23)
                change_pw.Location = New Point(50, 131)
                change_pw.BackColor = Color.FromArgb(108, 92, 231)
                change_pw.ForeColor = Color.White
                change_pw.FlatStyle = FlatStyle.Flat
                change_pw.Tag = dr.Item("userid").ToString

                modify_user = New Button
                modify_user.Text = "Modify Account"
                modify_user.Size = New Size(105, 23)
                modify_user.Location = New Point(181, 131)
                modify_user.BackColor = Color.FromArgb(108, 92, 231)
                modify_user.ForeColor = Color.White
                modify_user.FlatStyle = FlatStyle.Flat
                modify_user.Tag = dr.Item("userid").ToString

                delete_user = New Button
                delete_user.Image = My.Resources.close
                delete_user.Size = New Size(42, 23)
                delete_user.Location = New Point(307, 3)
                delete_user.FlatStyle = FlatStyle.Flat
                delete_user.FlatAppearance.BorderSize = 0
                delete_user.Tag = dr.Item("userid").ToString

                newPanel.Controls.Add(name)
                newPanel.Controls.Add(user_type)
                newPanel.Controls.Add(status)
                newPanel.Controls.Add(date_created)

                newPanel.Controls.Add(change_pw)
                newPanel.Controls.Add(modify_user)
                newPanel.Controls.Add(delete_user)


                AddHandler change_pw.Click, AddressOf ChangePassword
                AddHandler modify_user.Click, AddressOf ModifyAccount
                AddHandler delete_user.Click, AddressOf ArchivedUser


                flowUserPanel.Controls.Add(newPanel)
            End While

            dr.Close()


            con.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChangePassword(sender As Object, e As EventArgs)
        Dim userid = sender.Tag.ToString


        With frmChangePassword
            .LBLID.Text = userid
            .ShowDialog()

        End With
    End Sub

    Private Sub ModifyAccount(sender As Object, e As EventArgs)
        Dim userid = sender.Tag.ToString


        With frmUserCreate
            con.Open()

            cm = New MySqlCommand("SELECT * FROM rms_user WHERE userid='" & userid & "'", con)

            dr = cm.ExecuteReader

            While dr.Read
                .LBLID.Text = userid
                .TXTNAME.Text = dr.Item("login_name").ToString

                .TXTUN.Text = dr.Item("username").ToString
                .CBOUT.Text = dr.Item("user_type").ToString

            End While

            dr.Close()

            con.Close()


            .btnSave.Hide()
            .btnUpdate.Show()


            .ShowDialog()
        End With
    End Sub

    Private Sub ArchivedUser(sender As Object, e As EventArgs)
        Dim userid = sender.Tag.ToString



        If (MsgBox("Are you sure to remove this user?", vbOKCancel + vbInformation) = vbOK) Then
            con.Open()

            cm = New MySqlCommand("UPDATE rms_user SET status='Inactive' WHERE userid='" & userid & "'", con)

            cm.ExecuteNonQuery()


            con.Close()

            FillUsers()

        End If


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmUserCreate
            .ShowDialog()
        End With

    End Sub

    Private Sub frmUserAccount_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillUsers()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub
End Class