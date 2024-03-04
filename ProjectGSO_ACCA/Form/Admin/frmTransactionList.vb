Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTransactionList

    Dim newPanel As New Panel

    Dim itemPic As New PictureBox


    Dim tno As New Label
    Dim bn As New Label
    Dim bnum As New Label

    Dim db As New Label
    Dim ic As New Label
    Dim iname As New Label

    Dim return_btn As New Button

    Sub FillTransaction()
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.Controls.Clear()

        Dim nos As Integer = 0

        con.Open()
        Dim itemQuery As String = "SELECT b_img, transid, transaction_no, b_number, CONCAT(fname, ' ', mname, ' ', lname) as FullName, date_borrowed, date_returned, quantity, item_name, item_code FROM rms_transaction rt JOIN rms_borrowers_profile rbp USING(bpid) WHERE rt.status='Borrowed' AND (b_number LIKE '" & TXTSEARCH.Text & "%' OR fname LIKE'" & TXTSEARCH.Text & "%' OR lname LIKE '" & TXTSEARCH.Text & "%' OR mname LIKE '" & TXTSEARCH.Text & "%' OR b_number LIKE '" & TXTSEARCH.Text & "%')"
        cm = New MySqlCommand(itemQuery, con)

        dr = cm.ExecuteReader

        While dr.Read
            nos += 1

            newPanel = New Panel
            newPanel.Size = New Size(664, 133)
            newPanel.BorderStyle = BorderStyle.FixedSingle
            newPanel.Font = New Font("Bahnschrift Light", 9.75)
            Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte

            dr.GetBytes(0, 0, array, 0, CInt(len))

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)

            itemPic = New PictureBox
            itemPic.BackgroundImage = bitmap
            itemPic.Size = New Size(112, 100)
            itemPic.Location = New Point(23, 16)
            itemPic.BackgroundImageLayout = ImageLayout.Stretch

            Dim no_label = New Label
            no_label.Location = New Point(634, 6)
            no_label.Text = "#" & nos

            Dim t_label = New Label
            t_label.Location = New Point(164, 21)
            t_label.Text = "Transaction No.:"
            tno = New Label
            tno.Location = New Point(266, 21)
            tno.Text = dr.Item("transaction_no").ToString

            Dim bn_label = New Label
            bn_label.Location = New Point(158, 46)
            bn_label.Text = "Borrower Name:"
            bn_label.AutoSize = False
            bn_label.Width = 105

            bn = New Label
            bn.Location = New Point(266, 46)
            bn.AutoSize = False
            bn.Width = 120
            bn.Text = dr.Item("FullName").ToString

            Dim bnumber_label = New Label
            bnumber_label.Location = New Point(145, 71)
            bnumber_label.Text = "Borrower Number:"
            bnumber_label.AutoSize = False
            bnumber_label.Width = 120

            bnum = New Label
            bnum.Location = New Point(266, 71)
            bnum.AutoSize = False
            bnum.Width = 120
            bnum.Text = dr.Item("b_number").ToString

            Dim db_label = New Label
            db_label.Location = New Point(404, 21)
            db_label.Text = "Date Borrowed:"
            db_label.AutoSize = False
            db_label.Width = 105

            db = New Label
            db.Location = New Point(508, 21)
            db.AutoSize = False
            db.Width = 105
            db.Text = Format(CDate(dr.Item("date_borrowed")), "yyyy-MM-dd")


            Dim ic_label = New Label
            ic_label.Location = New Point(431, 46)
            ic_label.Text = "Item Code:"
            ic_label.AutoSize = False
            ic_label.Width = 80

            ic = New Label
            ic.Location = New Point(508, 46)
            ic.AutoSize = False
            ic.Width = 105
            ic.Text = dr.Item("item_code").ToString

            Dim in_label = New Label
            in_label.Location = New Point(426, 71)
            in_label.Text = "Item Name:"
            in_label.AutoSize = False
            in_label.Width = 80

            iname = New Label
            iname.Location = New Point(508, 71)
            iname.AutoSize = False
            iname.Width = 105
            iname.Text = dr.Item("item_name").ToString


            return_btn = New Button
            return_btn.Size = New Size(141, 24)
            return_btn.Location = New Point(511, 98)
            return_btn.FlatStyle = FlatStyle.Flat
            return_btn.Text = "Return Item"
            return_btn.BackColor = Color.FromArgb(95, 39, 205)
            return_btn.ForeColor = Color.White

            return_btn.Tag = dr.Item("transid").ToString

            Dim sb_label = New Label
            sb_label.Text = "Stock Borrowed: "
            sb_label.Location = New Point(153, 94)
            sb_label.AutoSize = False
            sb_label.Width = 105

            Dim sb = New Label
            sb.Text = dr.Item("quantity").ToString
            sb.Location = New Point(266, 94)
            sb.AutoSize = False
            sb.Width = 120

            newPanel.Controls.Add(itemPic)
            newPanel.Controls.Add(no_label)

            newPanel.Controls.Add(t_label)
            newPanel.Controls.Add(tno)

            newPanel.Controls.Add(bn_label)
            newPanel.Controls.Add(bn)

            newPanel.Controls.Add(bnumber_label)
            newPanel.Controls.Add(bnum)

            newPanel.Controls.Add(sb_label)
            newPanel.Controls.Add(sb)

            newPanel.Controls.Add(db_label)
            newPanel.Controls.Add(db)

            newPanel.Controls.Add(ic_label)
            newPanel.Controls.Add(ic)

            newPanel.Controls.Add(in_label)
            newPanel.Controls.Add(iname)

            newPanel.Controls.Add(return_btn)


            AddHandler return_btn.Click, AddressOf ReturnItem
            AddHandler sb.Click, AddressOf ReturnItem

            FlowLayoutPanel1.Controls.Add(newPanel)

        End While

        dr.Read()

        con.Close()

    End Sub

    Private Sub ReturnItem(sender As Object, e As EventArgs)
        Dim id = sender.tag.ToString


        If (MsgBox("Are you sure that this borrower JUST returned an item?", vbOK + vbInformation, "Returning an Item") = vbOK) Then

            'MsgBox("Update rms_transaction SET status='Returned', date_returned= '" & DateTime.Now & "' WHERE transid='" & id & "'")
            con.Open()

            cm = New MySqlCommand("UPDATE rms_transaction SET status='Returned', date_returned= '" & DateTime.Now.ToString("yyyy-MM-dd") & "' WHERE transid='" & id & "'", con)
            cm.ExecuteNonQuery()

            con.Close()

            con.Open()

            cm = New MySqlCommand("UPDATE rms_item SET available_stock = available_stock + (SELECT quantity FROM rms_transaction WHERE transid='" & id & "'
) WHERE itemcode=(SELECT item_code FROM rms_transaction WHERE transid='" & id & "')", con)
            cm.ExecuteNonQuery()

            con.Close()

            FillTransaction()

        End If
        UserLog(frmMainForm.LBLLOGINANME.Text, "Just Returned the items")

    End Sub

    Private Sub frmTransactionList_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillTransaction()
    End Sub

    Private Sub TXTSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSEARCH.TextChanged
        FillTransaction()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmTransactionBorrow
            .Show()

        End With
        UserLog(frmMainForm.LBLLOGINANME.Text, "Making Transaction")

    End Sub
End Class