Imports MySql.Data.MySqlClient
Public Class frmSystemPassword
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmSystemSettings
            .Show()
        End With
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If TXTNEW.Text <> TXTCP.Text Then
            MsgBox("ERR! Password did not match.", vbOKOnly + vbInformation)
            TXTCP.Text = String.Empty
            TXTNEW.Text = String.Empty
            TXTCUR.Text = String.Empty
            TXTCUR.Focus()

            Exit Sub
        End If

        If TXTNEW.Text = TXTCUR.Text Then
            MsgBox("ERR! You just entered the same password, try to change your password!", vbOKOnly + vbInformation)
            TXTCP.Text = String.Empty
            TXTNEW.Text = String.Empty
            TXTCUR.Text = String.Empty
            TXTCUR.Focus()
            Exit Sub
        End If

        If TXTNEW.Text = String.Empty Or TXTCP.Text = String.Empty Or TXTCUR.Text = String.Empty Then
            MsgBox("WARNING: All fields are required.", vbOKOnly + vbInformation)


        Else

            con.Open()

            cm = New MySqlCommand("UPDATE rms_user SET password=@password WHERE login_name='" & frmMainForm.LBLLOGINANME.Text & "'", con)
            cm.Parameters.AddWithValue("@password", TXTNEW.Text)

            cm.ExecuteNonQuery()

            con.Close()

            MsgBox("New Passowrd has been confirmed!", vbOKOnly + vbInformation, "Change User Security")

            Me.Dispose()

        End If

    End Sub
End Class