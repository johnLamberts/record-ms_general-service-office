
Imports MySql.Data.MySqlClient
Public Class frmCategoryCreate
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try

            If TXTCATEGORY.Text = String.Empty Then
                MsgBox("WARNING: Category field is required.", vbOKOnly + vbInformation)

            Else
                con.Open()

                Dim insertQuery As String = "UPDATE rms_item_category SET catname=@catname WHERE catid='" & LBLCID.Text & "'"
                cm = New MySqlCommand(insertQuery, con)
                With cm.Parameters
                    .AddWithValue("@catname", TXTCATEGORY.Text)
                End With

                cm.ExecuteNonQuery()

                con.Close()

                MsgBox("Record has been updated.", vbOKOnly + vbInformation, "Update Category")
                With frmCategory
                    .FillCategory()
                End With
                Me.Dispose()
            End If


        Catch ex As Exception
            con.Close()

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnSave_Click_2(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If TXTCATEGORY.Text = String.Empty Then
                MsgBox("WARNING: Category field is required.", vbOKOnly + vbInformation)

            Else
                con.Open()

                Dim insertQuery As String = "INSERT INTO rms_item_category(catname) VALUES (@catname)"
                cm = New MySqlCommand(insertQuery, con)
                With cm.Parameters
                    .AddWithValue("@catname", TXTCATEGORY.Text)
                End With

                cm.ExecuteNonQuery()

                con.Close()

                MsgBox("Record has been saved.", vbOKOnly + vbInformation, "Saved User")

                Me.Dispose()
            End If

            With frmCategory
                .FillCategory()
            End With
        Catch ex As Exception
            con.Close()

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub
End Class