Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Public Class frmBorrowersProfile

    Dim lblFirstName As New Label
    Dim lblMiddleName As New Label
    Dim lblLastName As New Label
    Dim lblBNumber As New Label
    Dim lblBType As New Label
    Dim lblCnumber As New Label

    Dim profilePic As New PictureBox

    Dim newPanel As New Panel

    Dim modify_btn As New Button
    Dim delete_btn As New Button
    Dim history_btn As New Button


    Sub FillBorrowersProfile()
        flowBProfile.AutoScroll = True
        flowBProfile.Controls.Clear()

        con.Open()

        Dim itemQuery As String = "SELECT b_img, bpid, CONCAT( fname, ' ', mname, ' ', lname) as FullName, b_number, c_number, bt.b_type FROM rms_borrowers_profile bp JOIN rms_borrowers_type bt ON bt.bid=bp.b_type WHERE status='Active' AND (fname LIKE'" & TXTSEARCH.Text & "%' OR lname LIKE '" & TXTSEARCH.Text & "%' OR mname LIKE '" & TXTSEARCH.Text & "%' OR b_number LIKE '" & TXTSEARCH.Text & "%')"
        cm = New MySqlCommand(itemQuery, con)

        dr = cm.ExecuteReader

        While dr.Read
            newPanel = New Panel
            newPanel.Size = New Size(350, 277)
            newPanel.BackColor = Color.White
            newPanel.BorderStyle = BorderStyle.FixedSingle


            Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte

            dr.GetBytes(0, 0, array, 0, CInt(len))

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)

            profilePic = New PictureBox
            profilePic.BackgroundImage = bitmap
            profilePic.Size = New Size(188, 103)
            profilePic.BackgroundImageLayout = ImageLayout.Stretch
            profilePic.Tag = dr.Item("bpid").ToString
            profilePic.Location = New Point(66, 13)

            lblFirstName = New Label
            lblFirstName.AutoSize = False
            lblFirstName.Width = 150
            lblFirstName.ForeColor = Color.FromArgb(0, 0, 0)
            lblFirstName.Location = New Point(15, 157)
            lblFirstName.Text = "Full Name:" & Space(2) & dr.Item("FullName").ToString
            lblFirstName.Tag = dr.Item("bpid").ToString



            lblBType = New Label
            lblBType.AutoSize = False
            lblBType.Width = 200
            lblBType.ForeColor = Color.FromArgb(0, 0, 0)
            lblBType.Text = "Borrower's Type:" & Space(2) & dr.Item("b_type").ToString
            lblBType.Location = New Point(204, 191)
            lblBType.Tag = dr.Item("bpid").ToString

            lblBNumber = New Label
            lblBNumber.AutoSize = False
            lblBNumber.Width = 200
            lblBNumber.ForeColor = Color.FromArgb(0, 0, 0)
            lblBNumber.Text = "Borrower's Number: " & Space(2) & dr.Item("b_number").ToString
            lblBNumber.Location = New Point(15, 191)
            lblBNumber.Tag = dr.Item("bpid").ToString

            lblCnumber = New Label
            lblCnumber.AutoSize = False
            lblCnumber.Width = 200
            lblCnumber.ForeColor = Color.FromArgb(0, 0, 0)
            lblCnumber.Text = "Contact Number: " & Space(2) & dr.Item("c_number").ToString
            lblCnumber.Location = New Point(203, 157)
            lblCnumber.Tag = dr.Item("bpid").ToString

            delete_btn = New Button
            delete_btn.Size = New Size(42, 23)
            delete_btn.Image = My.Resources.close
            delete_btn.FlatStyle = FlatStyle.Flat
            delete_btn.FlatAppearance.BorderSize = 0
            delete_btn.Location = New Point(297, 13)
            delete_btn.Tag = dr.Item("bpid").ToString


            modify_btn = New Button
            modify_btn.BackColor = Color.FromArgb(95, 39, 205)
            modify_btn.Size = New Size(97, 30)
            modify_btn.FlatStyle = FlatStyle.Flat
            modify_btn.FlatAppearance.BorderSize = 0
            modify_btn.Location = New Point(56, 228)
            modify_btn.Tag = dr.Item("bpid").ToString
            modify_btn.Text = "Modify"
            modify_btn.ForeColor = Color.White



            history_btn = New Button
            history_btn.BackColor = Color.FromArgb(95, 39, 205)
            history_btn.Size = New Size(97, 30)
            history_btn.FlatStyle = FlatStyle.Flat
            history_btn.FlatAppearance.BorderSize = 0
            history_btn.Location = New Point(176, 228)
            history_btn.Tag = dr.Item("bpid").ToString
            history_btn.Text = "Borrow Records"
            history_btn.ForeColor = Color.White

            newPanel.Controls.Add(delete_btn)
            newPanel.Controls.Add(modify_btn)
            newPanel.Controls.Add(history_btn)

            newPanel.Controls.Add(profilePic)
            newPanel.Controls.Add(lblFirstName)
            newPanel.Controls.Add(lblBType)
            newPanel.Controls.Add(lblBNumber)
            newPanel.Controls.Add(lblCnumber)




            flowBProfile.Controls.Add(newPanel)


            AddHandler delete_btn.Click, AddressOf Archived
            AddHandler modify_btn.Click, AddressOf Modify
            AddHandler history_btn.Click, AddressOf History

            'AddHandler edit_quantity.Click, AddressOf StockIn

        End While

        dr.Close()

        con.Close()


    End Sub

    Private Sub Archived(sender As Object, e As EventArgs)
        Dim id = sender.Tag.ToString

        If (MsgBox("Are you sure to remove this item?", vbOKCancel + vbInformation) = vbOK) Then
            con.Open()

            cm = New MySqlCommand("UPDATE rms_borrowers_profile SET status='Inactive' WHERE bpid='" & id & "'", con)

            cm.ExecuteNonQuery()

            con.Close()

            con.Open()

            cm = New MySqlCommand("INSERT INTO rms_data_recovery_borrower(recovory_code, name, status) SELECT b_number, CONCAT(fname, ' ', mname, ' ', lname) as FullName, status FROM rms_borrowers_profile	WHERE bpid= '" & id & "'", con)

            cm.ExecuteNonQuery()

            con.Close()

            FillBorrowersProfile()
        End If
    End Sub


    Private Sub History(sender As Object, e As EventArgs)
        Dim id = sender.Tag.ToString

        If (MsgBox("Are you sure to view the records?", vbOKCancel + vbInformation) = vbOK) Then
            With frmBorrowerRecords
                .FillRecords()


                .LBLTID.Text = id
                .ShowDialog()

            End With
            UserLog(frmMainForm.LBLLOGINANME.Text, "View Borrowers Records")

        End If
    End Sub

    Private Sub Modify(sender As Object, e As EventArgs)
        Dim id = sender.Tag.ToString


        With frmBorrowersCreate

            .FillBorrowers()

            con.Open()

            cm = New MySqlCommand("SELECT b_img, bpid, fname, lname, mname, b_number, c_number, bt.b_type FROM rms_borrowers_profile bp JOIN rms_borrowers_type bt ON bt.bid=bp.b_type WHERE bpid='" & id & "' AND status='Active' ", con)

            dr = cm.ExecuteReader

            While dr.Read

                Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
                Dim array(CInt(len)) As Byte

                dr.GetBytes(0, 0, array, 0, CInt(len))

                Dim ms As New MemoryStream(array)
                Dim bitmap As New System.Drawing.Bitmap(ms)

                .PictureBox1.BackgroundImage = bitmap
                '.LBLCID.Text = id
                '.TXTCODE.Text = dr.Item("itemcode").ToString
                '.TXTNAME.Text = dr.Item("item_name").ToString
                '.TXTIN.Text = dr.Item("available_stock").ToString
                '.CBOIC.Text = dr.Item("catname").ToString

                .LBLCID.Text = id
                .TXTBN.Text = dr.Item("b_number").ToString
                .TXTFN.Text = dr.Item("fname").ToString
                .TXTMN.Text = dr.Item("mname").ToString
                .TXTLN.Text = dr.Item("lname").ToString
                .CBOBC.Text = dr.Item("b_type").ToString
                .TXTCN.Text = dr.Item("c_number").ToString

            End While

            dr.Close()

            con.Close()


            .btnSave.Hide()
            .btnUpdate.Show()
            UserLog(frmMainForm.LBLLOGINANME.Text, "MOdify Borrowers Profile")

            .ShowDialog()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmBorrowersCreate
            .btnSave.Show()
            .btnUpdate.Hide()
            .FillBorrowers()
            .ShowDialog()
        End With
        UserLog(frmMainForm.LBLLOGINANME.Text, "Creating new borrowers")

    End Sub

    Private Sub TXTSEARCH_TextChanged(sender As Object, e As EventArgs) Handles TXTSEARCH.TextChanged
        FillBorrowersProfile()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub
End Class