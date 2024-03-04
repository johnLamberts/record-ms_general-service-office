Imports MySql.Data.MySqlClient
Public Class frmCategory
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmCategoryCreate
            .btnUpdate.Hide()

            .ShowDialog()
        End With

        UserLog(frmMainForm.LBLLOGINANME.Text, "Adding new category")

    End Sub

    Sub FillCategory()

        DGVCAT.Rows.Clear()

        Dim nos As Integer

        con.Open()
        Dim selectQry As String = "SELECT * FROM rms_item_category"
        cm = New MySqlCommand(selectQry, con)
        dr = cm.ExecuteReader

        While dr.Read
            nos += 1
            DGVCAT.Rows.Add(dr.Item("catid").ToString, nos, dr.Item("catname"), "Modify", "Delete")
        End While

        con.Close()

    End Sub


    Private Sub DGVCAT_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVCAT.CellContentClick
        Dim colName As String = DGVCAT.Columns(e.ColumnIndex).Name

        If colName = "Modify" Then
            With frmCategoryCreate
                .TXTCATEGORY.Text = DGVCAT.Rows(e.RowIndex).Cells(2).Value.ToString
                .LBLCID.Text = DGVCAT.Rows(e.RowIndex).Cells(0).Value.ToString
                .btnSave.Hide()
                .btnUpdate.Show()
                .ShowDialog()
                UserLog(frmMainForm.LBLLOGINANME.Text, "Modifying the category")

            End With

        ElseIf colName = "Delete" Then


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmSystemSettings
            .Show()
        End With
        Me.Close()

    End Sub
End Class