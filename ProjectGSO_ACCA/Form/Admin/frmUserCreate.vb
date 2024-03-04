Imports MySql.Data.MySqlClient
Public Class frmUserCreate
    Private Sub frmUserCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint, Panel3.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim checkDuplicate As Boolean = False
        If TXTCP.Text <> TXTPASS.Text Then
            MsgBox("ERR! Password did not match.", vbOKOnly + vbInformation)
            TXTCP.Text = String.Empty
            TXTPASS.Text = String.Empty
            TXTPASS.Focus()

            Exit Sub
        End If

        If TXTCP.Text = String.Empty Or TXTNAME.Text = String.Empty Or TXTPASS.Text = String.Empty Or TXTUN.Text = String.Empty Then
            MsgBox("WARNING: All fields are required.", vbOKOnly + vbInformation)

        Else
            con.Open()

            cm = New MySqlCommand("SELECT username FROM rms_user WHERE username='" & TXTUN.Text & "'", con)
            cm.ExecuteNonQuery()

            dr = cm.ExecuteReader

            dr.Read()

            If dr.HasRows Then
                checkDuplicate = True
            End If

            con.Close()

            If checkDuplicate = False Then

                con.Open()

                Dim insertQuery As String = "INSERT INTO rms_user(username, password, login_name, user_type, date_created) VALUES (@username, @password, @login_name, @user_type, @date_taken)"

                cm = New MySqlCommand(insertQuery, con)
                With cm.Parameters
                    .AddWithValue("@username", TXTUN.Text)
                    .AddWithValue("@password", TXTPASS.Text)
                    .AddWithValue("@login_name", TXTNAME.Text)
                    .AddWithValue("@user_type", CBOUT.Text)
                    .AddWithValue("@date_taken", Now.ToString)

                End With

                cm.ExecuteNonQuery()

                con.Close()
                MsgBox("Record has been saved.", vbOKOnly + vbInformation, "Saved User")

            Else
                MsgBox("ERR! Username is already exist.", vbOKOnly + vbInformation)
            End If

        End If



        TXTCP.Text = String.Empty
        TXTNAME.Text = String.Empty
        TXTPASS.Text = String.Empty
        TXTUN.Text = String.Empty
        CBOUT.Text = String.Empty
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim checkPassword As Boolean = False

        If TXTCP.Text <> TXTPASS.Text Then
            MsgBox("ERR! Password did not match.", vbOKOnly + vbInformation)
            TXTCP.Text = String.Empty
            TXTPASS.Text = String.Empty
            TXTPASS.Focus()

            Exit Sub
        End If

        If TXTCP.Text = String.Empty Or TXTNAME.Text = String.Empty Or TXTPASS.Text = String.Empty Or TXTUN.Text = String.Empty Then
            MsgBox("WARNING: All fields are required.", vbOKOnly + vbInformation)

        Else
            con.Open()

            cm = New MySqlCommand("SELECT password FROM rms_user WHERE password='" & TXTPASS.Text & "'", con)
            cm.ExecuteNonQuery()

            dr = cm.ExecuteReader

            dr.Read()

            If dr.HasRows Then
                checkPassword = True
            End If

            con.Close()

            If checkPassword = True Then

                con.Open()

                Dim updateQuery As String = "UPDATE rms_user SET username=@username, login_name=@login_name, user_type=@user_type WHERE userid='" & LBLID.Text & "'"

                cm = New MySqlCommand(updateQuery, con)
                With cm.Parameters
                    .AddWithValue("@username", TXTUN.Text)
                    .AddWithValue("@login_name", TXTNAME.Text)
                    .AddWithValue("@user_type", CBOUT.Text)

                End With

                cm.ExecuteNonQuery()

                con.Close()
                MsgBox("Record has been saved.", vbOKOnly + vbInformation, "Saved User")
                With frmUserAccount
                    .FillUsers()
                End With

                Me.Dispose()

            Else
                MsgBox("ERR! You entered Incorrect Password", vbOKOnly + vbInformation)
                TXTCP.Text = String.Empty
                TXTPASS.Text = String.Empty
                TXTPASS.Focus()
            End If


        End If

    End Sub
End Class