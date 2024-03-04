Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frmItem

    Dim lblItemCode As New Label
    Dim lblCatName As New Label
    Dim lblItemName As New Label
    Dim lblStock As New Label

    Dim itemPic As New PictureBox

    Dim newPanel As New Panel

    Dim modify_btn As New Button
    Dim delete_btn As New Button
    Dim edit_quantity As New Button

    Sub FillItem()

        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.Controls.Clear()

        con.Open()

        Dim itemQuery As String = "SELECT item_img, itemid, item_name, catname, itemcode, available_stock FROM  rms_item JOIN rms_item_category ic ON ic.catid=item_cat_id WHERE status='Active'  AND (itemcode LIKE '" & TXTSEARCH.Text & "%' OR item_name LIKE '" & TXTSEARCH.Text & "%' )"
        cm = New MySqlCommand(itemQuery, con)

        dr = cm.ExecuteReader

        While dr.Read
            newPanel = New Panel
            newPanel.Size = New Size(358, 296)
            newPanel.BackColor = Color.White
            newPanel.BorderStyle = BorderStyle.FixedSingle


            Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte

            dr.GetBytes(0, 0, array, 0, CInt(len))

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)

            itemPic = New PictureBox
            itemPic.BackgroundImage = bitmap
            itemPic.Size = New Size(164, 172)
            itemPic.BackgroundImageLayout = ImageLayout.Stretch
            itemPic.Tag = dr.Item("itemid").ToString
            itemPic.Location = New Point(9, 43)

            lblItemCode = New Label
            lblItemCode.AutoSize = False
            lblItemCode.Width = 200
            lblItemCode.ForeColor = Color.FromArgb(0, 0, 0)
            lblItemCode.Location = New Point(198, 110)
            lblItemCode.Text = "Item Code: " & Space(2) & dr.Item("itemcode").ToString
            lblItemCode.Tag = dr.Item("itemid").ToString

            lblItemName = New Label
            lblItemName.AutoSize = False
            lblItemName.Width = 220
            lblItemName.Location = New Point(193, 83)
            lblItemName.Text = "Item Name: " & Space(2) & dr.Item("item_name").ToString()
            lblItemName.Tag = dr.Item("itemid").ToString

            lblCatName = New Label
            lblCatName.AutoSize = False
            lblCatName.Width = 200
            lblCatName.Location = New Point(179, 136)
            lblCatName.Text = "Item Category: " & Space(2) & dr.Item("catname").ToString
            lblCatName.Tag = dr.Item("itemid").ToString

            lblStock = New Label
            lblStock.AutoSize = False
            lblStock.Width = 200
            lblStock.ForeColor = Color.FromArgb(0, 0, 0)
            lblStock.Text = "Stock: " & Space(2) & dr.Item("available_stock").ToString
            lblStock.Location = New Point(224, 166)
            lblStock.Tag = dr.Item("itemid").ToString


            delete_btn = New Button
            delete_btn.Size = New Size(42, 23)
            delete_btn.Image = My.Resources.close
            delete_btn.FlatStyle = FlatStyle.Flat
            delete_btn.FlatAppearance.BorderSize = 0
            delete_btn.Location = New Point(295, 14)
            delete_btn.Tag = dr.Item("itemid").ToString


            modify_btn = New Button
            modify_btn.BackColor = Color.FromArgb(95, 39, 205)
            modify_btn.Size = New Size(113, 35)
            modify_btn.FlatStyle = FlatStyle.Flat
            modify_btn.FlatAppearance.BorderSize = 0
            modify_btn.Location = New Point(60, 242)
            modify_btn.Tag = dr.Item("itemid").ToString
            modify_btn.Text = "Modify"
            modify_btn.ForeColor = Color.White

            edit_quantity = New Button
            edit_quantity.BackColor = Color.FromArgb(95, 39, 205)
            edit_quantity.Text = "Stock In"
            edit_quantity.Size = New Size(125, 35)
            edit_quantity.FlatStyle = FlatStyle.Flat
            edit_quantity.FlatAppearance.BorderSize = 0
            edit_quantity.Location = New Point(196, 242)
            edit_quantity.Tag = dr.Item("itemid").ToString
            edit_quantity.ForeColor = Color.White

            'prodPic.Controls.Add(lblCode)
            'prodPic.Controls.Add(lblPrice)
            newPanel.Controls.Add(delete_btn)
            newPanel.Controls.Add(modify_btn)
            newPanel.Controls.Add(edit_quantity)

            newPanel.Controls.Add(itemPic)
            newPanel.Controls.Add(lblItemCode)
            newPanel.Controls.Add(lblItemName)
            newPanel.Controls.Add(lblCatName)
            newPanel.Controls.Add(lblStock)




            FlowLayoutPanel1.Controls.Add(newPanel)


            AddHandler delete_btn.Click, AddressOf Archived
            AddHandler modify_btn.Click, AddressOf Modify
            AddHandler edit_quantity.Click, AddressOf StockIn
            'AddHandler lblCode.Click, AddressOf selectClick
            'AddHandler lblPrice.Click, AddressOf selectClick


        End While

        dr.Close()

        con.Close()



    End Sub

    Private Sub Archived(sender As Object, e As EventArgs)
        Dim id = sender.Tag.ToString

        If (MsgBox("Are you sure to remove this item?", vbOKCancel + vbInformation) = vbOK) Then
            con.Open()

            cm = New MySqlCommand("UPDATE rms_item SET status='Inactive' WHERE itemid='" & id & "'", con)

            cm.ExecuteNonQuery()

            con.Close()

            con.Open()

            cm = New MySqlCommand("INSERT INTO rms_data_recovery(recovery_code, name, status) SELECT itemcode, item_name, status FROM rms_item	WHERE itemid= '" & id & "'", con)


            cm.ExecuteNonQuery()

            con.Close()

            FillItem()
        End If
        UserLog(frmMainForm.LBLLOGINANME.Text, "Remove the item")

    End Sub

    Private Sub StockIn(sender As Object, e As EventArgs)
        Dim id = sender.Tag.ToString
        With frmStockIn

            con.Open()

            cm = New MySqlCommand("SELECT itemcode, itemid, item_name, available_stock, catname FROM rms_item INNER JOIN rms_item_category ic ON ic.catid=item_cat_id WHERE itemid='" & id & "' AND status='Active'", con)

            dr = cm.ExecuteReader

            While dr.Read


                .LBLCID.Text = id
                .TXTCODE.Text = dr.Item("itemcode").ToString
                .TXTNAME.Text = dr.Item("item_name").ToString
                .TXTIN.Text = dr.Item("available_stock").ToString
                .CBOIC.Text = dr.Item("catname").ToString


            End While

            dr.Close()

            con.Close()


            .btnSave.Show()

            .ShowDialog()
        End With
        UserLog(frmMainForm.LBLLOGINANME.Text, "Add Stocks")

    End Sub

    Private Sub Modify(sender As Object, e As EventArgs)
        Dim id = sender.Tag.ToString



        With frmItemCreate

            .FillCategory()
            con.Open()

            cm = New MySqlCommand("SELECT item_img, itemcode, itemid, item_name, available_stock, catname FROM rms_item INNER JOIN rms_item_category ic ON ic.catid=item_cat_id WHERE itemid='" & id & "' AND status='Active'", con)

            dr = cm.ExecuteReader

            While dr.Read

                Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte

                dr.GetBytes(0, 0, array, 0, CInt(len))

                Dim ms As New MemoryStream(array)
                Dim bitmap As New System.Drawing.Bitmap(ms)

                .PictureBox1.BackgroundImage = bitmap
                .LBLCID.Text = id
                .TXTCODE.Text = dr.Item("itemcode").ToString
                .TXTNAME.Text = dr.Item("item_name").ToString
                .TXTIN.Text = dr.Item("available_stock").ToString
                .CBOIC.Text = dr.Item("catname").ToString


            End While

            dr.Close()

            con.Close()


            .btnSave.Hide()
            .btnUpdate.Show()

            .ShowDialog()
            UserLog(frmMainForm.LBLLOGINANME.Text, "Moidfy the item")

        End With
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With frmItemCreate
            .FillCategory()
            .btnSave.Show()
            .btnUpdate.Hide()
            .ShowDialog()
        End With
    End Sub

    Private Sub frmItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillItem()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TXTSEARCH.TextChanged
        FillItem()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        With frmWarningStock
            .WarningStock()

            .ShowDialog()

        End With
    End Sub
End Class