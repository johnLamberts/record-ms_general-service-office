Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTransactionBorrow

    Dim catBtn As New Button

    Dim sidebar As Boolean = True


    Dim newPanel As New Panel

    Dim lblName As New Label
    Dim itemPic As New PictureBox
    Dim lblCode As New Label
    Dim lblQty As New Label

    Dim add_cart As New Button

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click


        If (MsgBox("These are all the items that you want to borrow, do you want to continue?.", vbOKCancel + vbInformation) = vbOK) Then

                For i = 0 To DataGridView1.Rows.Count - 1
                    con.Open()

                    cm = New MySqlCommand("INSERT INTO rms_transaction(bpid, transaction_no, item_name, item_code, quantity, date_borrowed, status) VALUES(@bpid, @transaction_no, @item_name, @item_code, @quantity, @date_borrowed, @status)", con)

                    With cm.Parameters
                        .AddWithValue("@bpid", CInt(LBLBID.Text))
                        .AddWithValue("@transaction_no", LBLTRANSNO.Text)
                        .AddWithValue("@item_name", DataGridView1.Rows(i).Cells(2).Value.ToString)
                        .AddWithValue("@item_code", DataGridView1.Rows(i).Cells(1).Value.ToString)
                        .AddWithValue("@quantity", DataGridView1.Rows(i).Cells(3).Value.ToString)
                        .AddWithValue("@date_borrowed", DateTime.Now)
                        .AddWithValue("@status", "Borrowed")
                    End With

                    cm.ExecuteNonQuery()

                    con.Close()

                    con.Open()

                    cm = New MySqlCommand("UPDATE rms_item SET available_stock= available_stock - '" & CInt(DataGridView1.Rows(i).Cells(3).Value.ToString) & "' WHERE itemcode='" & DataGridView1.Rows(i).Cells(1).Value.ToString & "'", con)
                    cm.ExecuteNonQuery()
                    con.Close()

                Next

                con.Open()


                cm = New MySqlCommand("DELETE FROM rms_cart WHERE bpid='" & LBLBID.Text & "'", con)
                cm.ExecuteNonQuery()
                con.Close()
            End If

            DataGridView1.Controls.Clear()
            FillCart()

            MsgBox("SUCCESS! The item has been recorded.", vbOK + vbInformation)



    End Sub


    Sub FillItemToBorrow()

        FlowLayoutPanel2.AutoScroll = True
        FlowLayoutPanel2.Controls.Clear()

        con.Open()

        Dim itemQuery As String = "SELECT item_img, itemid, item_name, catname, itemcode, available_stock FROM  rms_item JOIN rms_item_category ic ON ic.catid=item_cat_id WHERE (itemcode LIKE '" & TXTSEARCH.Text & "%' OR item_name LIKE '" & TXTSEARCH.Text & "%' ) AND status='Active' ORDER BY itemid"
        cm = New MySqlCommand(itemQuery, con)

        dr = cm.ExecuteReader

        While dr.Read
            newPanel = New Panel
            newPanel.Size = New Size(187, 276)
            newPanel.BackColor = Color.FromArgb(65, 105, 225)


            Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte

            dr.GetBytes(0, 0, array, 0, CInt(len))

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)

            itemPic = New PictureBox
            itemPic.BackgroundImage = bitmap
            itemPic.Size = New Size(162, 154)
            itemPic.BackgroundImageLayout = ImageLayout.Stretch
            itemPic.Tag = dr.Item("itemid").ToString
            itemPic.Location = New Point(9, 13)

            lblName = New Label
            lblName.AutoSize = False
            lblName.Width = 200
            lblName.ForeColor = Color.FromArgb(0, 0, 0)
            lblName.Location = New Point(6, 197)
            lblName.Text = "Item Name: " & Space(2) & dr.Item("item_name").ToString
            lblName.Tag = dr.Item("itemid").ToString


            add_cart = New Button
            add_cart.BackColor = Color.FromArgb(95, 39, 205)
            add_cart.Text = "Add To Borrow"
            add_cart.Size = New Size(128, 30)
            add_cart.FlatStyle = FlatStyle.Flat
            add_cart.Location = New Point(24, 227)
            add_cart.Tag = dr.Item("itemid").ToString
            add_cart.ForeColor = Color.White


            newPanel.Controls.Add(itemPic)
            newPanel.Controls.Add(lblName)
            newPanel.Controls.Add(add_cart)


            AddHandler add_cart.Click, AddressOf ConfirmQuantity


            FlowLayoutPanel2.Controls.Add(newPanel)



            'AddHandler modify_btn.Click, AddressOf Modify
            'AddHandler edit_quantity.Click, AddressOf StockIn
            'AddHandler lblCode.Click, AddressOf selectClick
            'AddHandler lblPrice.Click, AddressOf selectClick



        End While


        If DataGridView1.Rows.Count Then
            Button8.Enabled = False
        Else
            Button8.Enabled = True

        End If


        dr.Close()

        con.Close()

    End Sub

    Function TransNo() As String
        Dim newDate As String = Now.ToString("yyyyMMdd")

        Try
            con.Open()
            cm = New MySqlCommand("SELECT * FROM rms_cart WHERE transaction_no LIKE '" & newDate & "%' ORDER BY cartid DESC", con)
            dr = cm.ExecuteReader

            dr.Read()
            If dr.HasRows Then
                TransNo = CLng(dr.Item("transaction_no").ToString) + 1
                Else
                    TransNo = newDate & "0001"
            End If

            dr.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
        Return TransNo

    End Function


    Sub BorrowersCart()
        Dim hasCart As Boolean
        Dim transno As String

        cm = New MySqlCommand("SELECT * FROM rms_cart WHERE bpid LIKE'" & LBLBID.Text & "'", con)
        con.Open()
        dr = cm.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            hasCart = True
            transno = dr.Item("transaction_no").ToString
        Else
            hasCart = False
            DataGridView1.Rows.Clear()
        End If
        dr.Close()
        con.Close()

        If hasCart = True Then
            LBLTRANSNO.Text = transno
            FillCart()
        End If
    End Sub



    Sub FillCart()

        DataGridView1.Rows.Clear()
        Try

            con.Open()

            cm = New MySqlCommand("SELECT cartid, item_name, item_code, quantity FROM rms_cart WHERE transaction_no LIKE'" & LBLTRANSNO.Text & "'", con)
            dr = cm.ExecuteReader

            While dr.Read


                DataGridView1.Rows.Add(dr.Item("cartid").ToString, dr.Item("item_code").ToString, dr.Item("item_name").ToString, dr.Item("quantity").ToString, "Remove")

            End While



            dr.Close()

            con.Close()





        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub




    Private Sub ConfirmQuantity(sender As Object, e As EventArgs)
        Dim id = sender.Tag.ToString

        If LBLBN.Text = String.Empty Then
            MsgBox("WARNING! Choose borrower first before continuing.", vbOKOnly + vbInformation)
        Else
            With frmToBorrowDescription

                con.Open()

                cm = New MySqlCommand("SELECT item_img, item_name, itemcode, available_stock, catname FROM rms_item INNER JOIN rms_item_category ic ON ic.catid=item_cat_id WHERE itemid='" & id & "'", con)

                dr = cm.ExecuteReader

                While dr.Read
                    Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
                    Dim array(CInt(len)) As Byte

                    dr.GetBytes(0, 0, array, 0, CInt(len))

                    Dim ms As New MemoryStream(array)
                    Dim bitmap As New System.Drawing.Bitmap(ms)

                    .PictureBox1.BackgroundImage = bitmap
                    .LBLITEMID.Text = id
                    .LBLICODE.Text = dr.Item("itemcode").ToString
                    .LBLIN.Text = dr.Item("item_name").ToString
                    .LBLSTOCK.Text = dr.Item("available_stock").ToString
                    .LBLCAT.Text = dr.Item("catname").ToString
                End While

                dr.Close()

                con.Close()



                .ShowDialog()
            End With
        End If
    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        LBLTRANSNO.Text = TransNo()
        With frmBorrowerOfItem
            .FillUserBorrowers()
            .ShowDialog()
        End With
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs)


    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sidebar = False
        Timer1.Start()
        Timer2.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sidebar = False

        Timer2.Start()
    End Sub


    Sub FillTypeButtons()
        con.Open()
        Dim typeQuery As String = "SELECT * FROM ec_catsub_eye JOIN ec_cateye USING (catid)"
        cm = New MySqlCommand(typeQuery, con)

        dr = cm.ExecuteReader

        While dr.Read
            catBtn = New Button
            catBtn.Width = 100
            catBtn.Height = 35
            catBtn.Text = dr.Item("sub_name")
            catBtn.FlatStyle = FlatStyle.Flat
            catBtn.BackColor = Color.FromArgb(9, 132, 227)
            catBtn.ForeColor = Color.White
            catBtn.Cursor = Cursors.Hand

            'lblCat = New Label
            'lblCat.Text = dr.Item("eye_name")
            'newPanel.Controls.Add(typeBtn)


            'FlowLayoutPanel1.Controls.Add(typeBtn)
            'FlowLayoutPanel1.Controls.Add(lblCat)


            'AddHandler typeBtn.Click, AddressOf filterClick
        End While

        dr.Close()
        con.Close()

    End Sub




    Private Sub frmTransactionBorrow_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillItemToBorrow()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TXTSEARCH.TextChanged
        FillItemToBorrow()

        'con.Open()

        'Dim check As Boolean = False


        'Dim getProductQuery As String = "SELECT * FROM rms_item WHERE itemcode LIKE'" & TXTSEARCH.Text & "%'"
        ''Dim displayProduct As String = "SELECT productimg, productid, productcode, price, brandname, typename FROM ec_products JOIN ec_brand USING(brandid) JOIN ec_type USING(typeid) WHERE productid='" & productid & "'"
        'cm = New MySqlCommand(getProductQuery, con)

        'dr = cm.ExecuteReader
        'dr.Read()

        'If dr.HasRows Then
        '    check = True

        'End If

        'dr.Close()

        'con.Close()

        'If check = True Then
        '    FillItemToBorrow()

        'End If
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        If sidebar Then
            sidebar1.Width += 100
            If sidebar1.Size = sidebar1.MaximumSize Then
                Timer1.Stop()
                sidebar = False

                Button1.Visible = False
            End If
        Else
            sidebar1.Width -= 100
            If sidebar1.Size = sidebar1.MinimumSize Then
                Timer1.Stop()
                sidebar = True
                Button1.Visible = True

            End If
        End If
    End Sub

    Private Sub Timer2_Tick_1(sender As Object, e As EventArgs) Handles Timer2.Tick
        If sidebar Then
            sidebar1.Width += 100
            If sidebar1.Size = sidebar1.MaximumSize Then
                Timer2.Stop()
                sidebar = False
                Button1.Visible = False

            End If
        Else
            sidebar1.Width -= 100
            If sidebar1.Size = sidebar1.MinimumSize Then
                Timer2.Stop()
                sidebar = True
                Button1.Visible = True

            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()

    End Sub
End Class