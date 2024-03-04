Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class frmItemCreate
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using odf As New OpenFileDialog With {.Filter = "(Image.Files)|*.jpg;*.png;*.jpeg; *.jpeg|*.jpg|*.png",
                                .Multiselect = False, .Title = "Select Image"}
            If odf.ShowDialog = 1 Then
                PictureBox1.BackgroundImage = Image.FromFile(odf.FileName)
            End If
        End Using
    End Sub

    Sub FillCategory()
        Dim da As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim subQuery As String = "SELECT * FROM rms_item_category"


        con.Open()
        cm = New MySqlCommand(subQuery, con)
        da.SelectCommand = cm
        CBOIC.Items.Clear()


        da.Fill(dt)

        CBOIC.DataSource = dt
        CBOIC.ValueMember = "catid"
        CBOIC.DisplayMember = "catname"
        con.Close()
    End Sub

    Function GenerateItemCode() As String
        Dim validchars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"

        Dim sb As New StringBuilder()
        Dim rand As New Random()
        For i As Integer = 1 To 6
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i

        Dim randomString = sb.ToString()

        Return "ITEM-" & randomString
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim arrImage() As Byte




        Try
            If IsNumeric(TXTIN.Text) = False Then
                MsgBox("WARNING: You entered non-numeric character!", vbInformation)
                Exit Sub
            End If

            If TXTCODE.Text = String.Empty Or TXTIN.Text = String.Empty Or TXTNAME.Text = String.Empty Then
                MsgBox("WARNING: All fields are required!", vbInformation)
                Exit Sub
            End If

            If PictureBox1.BackgroundImage Is Nothing Then
                MsgBox("WARNING: You're required to put an image!", vbInformation)
            Else

                Dim mainstream As New MemoryStream

                PictureBox1.BackgroundImage.Save(mainstream, System.Drawing.Imaging.ImageFormat.Jpeg)

                arrImage = mainstream.GetBuffer

                con.Open()
                Dim insertQuery As String = "INSERT INTO rms_item(itemcode, item_img, item_name, item_cat_id, available_stock) VALUES (@itemcode, @item_img, @item_name, @item_cat_id, @available_stock)"
                cm = New MySqlCommand(insertQuery, con)

                With cm
                    .Parameters.AddWithValue("@itemcode", TXTCODE.Text)
                    .Parameters.AddWithValue("@item_img", arrImage)
                    .Parameters.AddWithValue("@item_name", TXTNAME.Text)

                    .Parameters.AddWithValue("@item_cat_id", CBOIC.SelectedValue)
                    .Parameters.AddWithValue("@available_stock", TXTIN.Text)


                    .ExecuteNonQuery()

                End With

                MsgBox("Record has been successfully saved.", vbInformation)
                con.Close()



                TXTCODE.Clear()
                PictureBox1.BackgroundImage = Nothing
                CBOIC.Text = "Select a category"
                TXTIN.Clear()

                With frmItem
                    .FillItem()
                End With
            End If



        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim arrImage() As Byte




        Try
            If IsNumeric(TXTIN.Text) = False Then
                MsgBox("WARNING: You entered non-numeric character!", vbInformation)

            Else

                Dim mainstream As New MemoryStream

                PictureBox1.BackgroundImage.Save(mainstream, System.Drawing.Imaging.ImageFormat.Jpeg)

                arrImage = mainstream.GetBuffer

                con.Open()
                Dim insertQuery As String = "UPDATE rms_item SET itemcode=@itemcode, item_img=@item_img, item_name=@item_name, item_cat_id=@item_cat_id, available_stock=@available_stock WHERE itemid= '" & LBLCID.Text & "'"
                cm = New MySqlCommand(insertQuery, con)

                With cm
                    .Parameters.AddWithValue("@itemcode", TXTCODE.Text)
                    .Parameters.AddWithValue("@item_img", arrImage)
                    .Parameters.AddWithValue("@item_name", TXTNAME.Text)

                    .Parameters.AddWithValue("@item_cat_id", CBOIC.SelectedValue)
                    .Parameters.AddWithValue("@available_stock", TXTIN.Text)


                    .ExecuteNonQuery()

                End With

                MsgBox("Record has been successfully saved.", vbInformation)
                con.Close()



                Me.Dispose()

                With frmItem
                    .FillItem()
                End With
            End If



        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub frmItemCreate_Load(sender As Object, e As EventArgs) Handles Me.Load

        TXTCODE.Text = GenerateItemCode()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub TXTIN_TextChanged(sender As Object, e As EventArgs) Handles TXTIN.TextChanged
    End Sub
End Class