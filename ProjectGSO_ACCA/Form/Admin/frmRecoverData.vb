Imports MySql.Data.MySqlClient

Public Class frmRecoverData


    Sub RecoveryData()
        Dim nos As Integer = 0
        DataGridView1.Rows.Clear()

        con.Open()
        cm = New MySqlCommand("SELECT * FROM rms_data_recovery WHERE status='Inactive'", con)
        dr = cm.ExecuteReader
        While dr.Read
            nos += 1
            DataGridView1.Rows.Add(dr.Item("drid").ToString, nos, dr.Item("recovery_code").ToString, dr.Item("name").ToString, "Recover")
        End While

        dr.Close()

        con.Close()



    End Sub

    Sub BorrowerRecovery()
        Dim nos As Integer = 0
        DataGridView2.Rows.Clear()

        con.Open()
        cm = New MySqlCommand("SELECT * FROM rms_data_recovery_borrower WHERE status='Inactive'", con)
        dr = cm.ExecuteReader
        While dr.Read
            nos += 1
            DataGridView2.Rows.Add(dr.Item("drid").ToString, nos, dr.Item("recovory_code").ToString, dr.Item("name").ToString, "Recover")
        End While

        dr.Close()

        con.Close()



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim colname = DataGridView1.Columns(e.ColumnIndex).Name
        If colname = "Recover" Then
            If MsgBox("Are you sure to recover this data?", vbOKCancel + vbExclamation) = vbOK Then
                con.Open()

                cm = New MySqlCommand("UPDATE rms_item SET status='Active' WHERE itemcode='" & DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "'", con)
                cm.ExecuteNonQuery()

                con.Close()

                con.Open()

                cm = New MySqlCommand("UPDATE rms_data_recovery SET status='Active' WHERE recovery_code='" & DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString & "'", con)
                cm.ExecuteNonQuery()

                con.Close()
                RecoveryData()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmSystemSettings
            .Show()
        End With
        Me.Close()
    End Sub

    Private Sub frmRecoverData_Load(sender As Object, e As EventArgs) Handles Me.Load
        BorrowerRecovery()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim colname = DataGridView1.Columns(e.ColumnIndex).Name
        If colname = "Recover" Then
            If MsgBox("Are you sure to recover this data?", vbOKCancel + vbExclamation) = vbOK Then
                con.Open()

                cm = New MySqlCommand("UPDATE rms_borrowers_profile SET status='Active' WHERE b_number='" & DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString & "'", con)
                cm.ExecuteNonQuery()

                con.Close()

                con.Open()

                cm = New MySqlCommand("UPDATE rms_data_recovery_borrower SET status='Active' WHERE recovory_code='" & DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString & "'", con)
                cm.ExecuteNonQuery()

                con.Close()
                BorrowerRecovery()
            End If
        End If
    End Sub
End Class