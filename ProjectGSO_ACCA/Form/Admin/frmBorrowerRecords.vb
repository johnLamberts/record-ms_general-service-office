Imports MySql.Data.MySqlClient

Public Class frmBorrowerRecords
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Sub FillRecords()

        DataGridView1.Rows.Clear()

        con.Open()

        cm = New MySqlCommand("SELECT * FROM rms_transaction WHERE bpid='" & LBLTID.Text & "' ", con)

        dr = cm.ExecuteReader

        While dr.Read
            DataGridView1.Rows.Add(dr.Item("transid").ToString, dr.Item("transaction_no").ToString, dr.Item("item_name").ToString, dr.Item("item_code").ToString, dr.Item("quantity").ToString, Format(CDate(dr.Item("date_borrowed")), "yyyy-MM-dd"), Format(CDate(dr.Item("date_returned")), "yyyy-MM-dd"), dr.Item("status").ToString)
        End While

        dr.Close()

        con.Close()



    End Sub

    Private Sub frmBorrowerRecords_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillRecords()
    End Sub
End Class