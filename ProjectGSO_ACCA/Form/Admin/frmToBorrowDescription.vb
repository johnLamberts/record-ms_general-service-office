Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmToBorrowDescription
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim arrImage() As Byte

        Dim trans_date As String = Now.ToString("yyyy-MM-dd")

        'Validate the Stock before continuing 
        If LBLSTOCK.Text = String.Empty Or LBLSTOCK.Text = "0" Then
            MsgBox("No available item at the moment", vbInformation)
            Exit Sub

        Else

        End If

        con.Open()

        cm = New MySqlCommand("SELECT available_stock FROM rms_item WHERE itemid ='" & LBLITEMID.Text & "' AND available_stock >= '" & CInt(LBLSTOCK.Text) & "'", con)
        dr = cm.ExecuteReader
        dr.Read()

        If dr.HasRows Then
            dr.Close()
            con.Close()
        Else
            MsgBox("Order cannot be processed! Remaining Stock: " & dr.Item("available_stock"), vbInformation)
            dr.Close()
            con.Close()
        End If


        con.Open()

        cm = New MySqlCommand("SELECT available_stock FROM rms_item WHERE itemid ='" & LBLITEMID.Text & "'", con)
        dr = cm.ExecuteReader
        dr.Read()

        If dr.HasRows Then
            If qty.Value > dr.Item("available_stock") Then
                MsgBox("WARNING: The number of items cannot be processed! Stock Remaining" & dr.Item("available_stock"), vbInformation)
                dr.Read()

                con.Close()

                qty.ResetText()
                qty.Focus()
                Exit Sub
            Else
                dr.Read()
                con.Close()
            End If
        End If

        Dim checkTransaction As Boolean = False

        Dim check As Boolean = False

        For i = 0 To frmTransactionBorrow.DataGridView1.Rows.Count - 1

            If frmTransactionBorrow.DataGridView1.Rows(i).Cells(1).Value = LBLICODE.Text Then
                check = True
                frmTransactionBorrow.DataGridView1.Rows(i).Cells(3).Value += qty.Value
            End If
        Next

        If check = False Then
            con.Open()



            Dim getProductQuery As String = "INSERT INTO rms_cart(transaction_no, item_code , item_name,  bpid, quantity, date_borrowed) VALUES (@transaction_no, @item_code, @item_name, @bpid, @quantity, @date_borrowed)"
            cm = New MySqlCommand(getProductQuery, con)

            With cm
                .Parameters.AddWithValue("@transaction_no", frmTransactionBorrow.LBLTRANSNO.Text)
                .Parameters.AddWithValue("@item_code", LBLICODE.Text)
                .Parameters.AddWithValue("@item_name", LBLIN.Text)

                .Parameters.AddWithValue("@bpid", frmTransactionBorrow.LBLBID.Text)
                .Parameters.AddWithValue("@quantity", qty.Value)
                .Parameters.AddWithValue("@date_borrowed", DateTime.Now)

                '.Parameters.AddWithValue("@quantity", qty.Value)

                .ExecuteNonQuery()


            End With
            con.Close()
        Else
            con.Open()

            Dim getProductQuery As String = "UPDATE rms_cart SET quantity= quantity + '" & qty.Value & "' WHERE item_code='" & LBLICODE.Text & "'"

            cm = New MySqlCommand(getProductQuery, con)

            With cm
                .ExecuteNonQuery()
            End With

            con.Close()


        End If

        frmTransactionBorrow.BorrowersCart()


        Me.Dispose()


        'For index = 0 To frmTransactionBorrow.DataGridView1.Rows.Count - 1
        '    If frmTransactionBorrow.DataGridView1.Rows(index).Cells(1).Value = LBLICODE.Text Then


        '        con.Open()

        '        Dim assert = frmTransactionBorrow.DataGridView1.Rows(index).Cells(3).Value + qty.Value

        '        Dim getProductQuery As String = "UPDATE rms_cart SET quantity= quantity + '" & qty.Value & "' WHERE item_code='" & LBLICODE.Text & "'"

        '        cm = New MySqlCommand(getProductQuery, con)

        '        With cm
        '            .ExecuteNonQuery()
        '        End With

        '        con.Close()
        '    Else

        '    End If
        'Next






        'UserLog("Order Product")

    End Sub
End Class