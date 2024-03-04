Imports MySql.Data.MySqlClient
Public Class frmBorrowers
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmBorrowersControl
            .btnSave.Show()
            .btnUpdate.Hide()
            .ShowDialog()
            UserLog(frmMainForm.LBLLOGINANME.Text, "Creating new borrowers")

        End With
    End Sub

    Sub FillBorrower()
        DGVB.Rows.Clear()

        Dim nos As Integer

        con.Open()
        Dim selectQry As String = "SELECT * FROM rms_borrowers_type"
        cm = New MySqlCommand(selectQry, con)
        dr = cm.ExecuteReader

        While dr.Read
            nos += 1
            DGVB.Rows.Add(dr.Item("bid").ToString, nos, dr.Item("b_type"), "Modify", "Delete")
        End While

        con.Close()
    End Sub

    Private Sub DGVB_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVB.CellClick
        Dim colName As String = DGVB.Columns(e.ColumnIndex).Name

        If colName = "Modify" Then
            With frmBorrowersControl
                .TXTBORROWER.Text = DGVB.Rows(e.RowIndex).Cells(2).Value.ToString
                .LBLCID.Text = DGVB.Rows(e.RowIndex).Cells(0).Value.ToString
                .btnSave.Hide()
                .btnUpdate.Show()
                .ShowDialog()
                UserLog(frmMainForm.LBLLOGINANME.Text, "Modifying borrowers")

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