Imports MySql.Data.MySqlClient
Public Class frmBorrowersControl
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try

            If TXTBORROWER.Text = String.Empty Then
                MsgBox("WARNING: Borrower field is required.", vbOKOnly + vbInformation)

            Else
                con.Open()

                Dim insertQuery As String = "UPDATE rms_borrowers_type SET b_type=@b_type WHERE bid='" & LBLCID.Text & "'"
                cm = New MySqlCommand(insertQuery, con)
                With cm.Parameters
                    .AddWithValue("@b_type", TXTBORROWER.Text)
                End With

                cm.ExecuteNonQuery()

                con.Close()

                MsgBox("Record has been updated.", vbOKOnly + vbInformation, "Update Borrower")
                With frmBorrowers
                    .FillBorrower()
                End With
                Me.Dispose()
            End If


        Catch ex As Exception
            con.Close()

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If TXTBORROWER.Text = String.Empty Then
                MsgBox("WARNING: Borrower field is required.", vbOKOnly + vbInformation)

            Else
                con.Open()

                Dim insertQuery As String = "INSERT INTO rms_borrowers_type(b_type) VALUES (@b_type)"
                cm = New MySqlCommand(insertQuery, con)
                With cm.Parameters
                    .AddWithValue("@b_type", TXTBORROWER.Text)
                End With

                cm.ExecuteNonQuery()

                con.Close()

                MsgBox("Record has been saved.", vbOKOnly + vbInformation, "Saved Borrower Type")

                Me.Dispose()
            End If

            With frmBorrowers
                .FillBorrower()
            End With
        Catch ex As Exception
            con.Close()

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class