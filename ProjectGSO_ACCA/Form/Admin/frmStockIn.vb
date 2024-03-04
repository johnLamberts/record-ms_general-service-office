Imports MySql.Data.MySqlClient
Public Class frmStockIn
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If IsNumeric(TXTADDSTOCK.Text) = False Then
                MsgBox("WARNING: You entered non-numeric character!", vbInformation)
                Exit Sub

            Else




                con.Open()
                Dim insertQuery As String = "INSERT INTO rms_stock(item_name, item_category, quantity_added, date_created) VALUES (@item_name, @item_category, @quantity_added, @date_created)"
                cm = New MySqlCommand(insertQuery, con)

                With cm
                    .Parameters.AddWithValue("@item_name", TXTNAME.Text)
                    .Parameters.AddWithValue("@item_category", CBOIC.Text)
                    .Parameters.AddWithValue("@quantity_added", TXTADDSTOCK.Text)
                    .Parameters.AddWithValue("@date_created", DateTimePicker1.Value)

                    .ExecuteNonQuery()

                End With

                con.Close()


                con.Open()
                Dim updateQuery As String = "UPDATE rms_item SET available_stock= available_stock + '" & CInt(TXTADDSTOCK.Text) & "' WHERE itemid='" & LBLCID.Text & "'"
                cm = New MySqlCommand(updateQuery, con)

                With cm
                    .ExecuteNonQuery()
                End With

                MsgBox("Record has been successfully saved.", vbInformation)
                con.Close()


                With frmItem
                    .FillItem()
                End With

                Me.Dispose()
            End If



        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub
End Class