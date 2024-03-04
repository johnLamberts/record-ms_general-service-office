Imports MySql.Data.MySqlClient
Public Class frmWarningStock
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()

    End Sub

    Sub WarningStock()
        DataGridView1.Rows.Clear()

        con.Open()
        cm = New MySqlCommand("SELECT * FROM `rms_item` WHERE available_stock <= 10", con)
        dr = cm.ExecuteReader

        While dr.Read
            DataGridView1.Rows.Add(dr.Item("itemid"), dr.Item("item_name").ToString, dr.Item("itemcode").ToString, dr.Item("available_stock").ToString, dr.Item("status").ToString)
        End While

        dr.Close()


        con.Close()


    End Sub
End Class