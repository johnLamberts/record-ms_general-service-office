Imports MySql.Data.MySqlClient
Public Class frmBorrowerOfItem
    Dim borrowerBtn As New Button


    Sub FillUserBorrowers()
        FlowLayoutPanel1.AutoScroll = True


        FlowLayoutPanel1.Controls.Clear()

        con.Open()
        cm = New MySqlCommand("SELECT * FROM item_borrowed", con)
        dr = cm.ExecuteReader

        While dr.Read
            borrowerBtn = New Button
            borrowerBtn.Width = 140
            borrowerBtn.Height = 50
            If CInt(dr.Item("ItemBorrowed")) > 1 Then
                borrowerBtn.Text = dr.Item("FullName") & " - " & dr.Item("ItemBorrowed").ToString
                borrowerBtn.BackColor = Color.FromArgb(108, 92, 231)
            Else
                borrowerBtn.Text = dr.Item("FullName")
                borrowerBtn.BackColor = Color.FromArgb(9, 132, 227)
            End If
            borrowerBtn.Tag = dr.Item("bpid")
            borrowerBtn.FlatStyle = FlatStyle.Flat
            borrowerBtn.ForeColor = Color.White
            borrowerBtn.Cursor = Cursors.Hand
            borrowerBtn.TextAlign = ContentAlignment.MiddleLeft


            FlowLayoutPanel1.Controls.Add(borrowerBtn)

            AddHandler borrowerBtn.Click, AddressOf BorrowerItem

        End While

        dr.Close()
        con.Close()
    End Sub

    Private Sub BorrowerItem(sender As Object, e As EventArgs)
        Dim fullName As String = sender.text.ToString
        Dim userid As String = sender.tag.ToString
        With frmTransactionBorrow
            .LBLBN.Text = fullName
            .LBLBID.Text = userid
            .BorrowersCart()
        End With
        Me.Dispose()
    End Sub

End Class