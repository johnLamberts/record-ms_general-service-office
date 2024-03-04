Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Public Class frmBorrowersCreate
    Private Sub frmBorrowersCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Function GenerateFaculty() As String
        Dim validchars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"

        Dim sb As New StringBuilder()
        Dim rand As New Random()
        For i As Integer = 1 To 6
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i

        Dim randomString = sb.ToString()

        Return "FCY-" & randomString
    End Function

    Function GenerateStudent() As String
        Dim validchars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"

        Dim sb As New StringBuilder()
        Dim rand As New Random()
        For i As Integer = 1 To 6
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i

        Dim randomString = sb.ToString()

        Return "STU-" & randomString
    End Function

    Sub FillBorrowers()
        Dim da As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim subQuery As String = "SELECT * FROM rms_borrowers_type"


        con.Open()
        cm = New MySqlCommand(subQuery, con)
        da.SelectCommand = cm


        da.Fill(dt)

        CBOBC.DataSource = dt
        CBOBC.ValueMember = "bid"
        CBOBC.DisplayMember = "b_type"
        con.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim arrImage() As Byte




        Try
            If IsNumeric(TXTCN.Text) = False Then
                MsgBox("WARNING: You entered non-numeric character!", vbInformation)

            Else

                Dim mainstream As New MemoryStream

                PictureBox1.BackgroundImage.Save(mainstream, System.Drawing.Imaging.ImageFormat.Jpeg)

                arrImage = mainstream.GetBuffer

                con.Open()
                Dim insertQuery As String = "UPDATE rms_borrowers_profile SET b_number=@b_number, b_img=@b_img, fname=@fname, mname=@mname, lname=@lname, b_type=@b_type, c_number=@c_number WHERE bpid= '" & LBLCID.Text & "'"
                cm = New MySqlCommand(insertQuery, con)

                With cm
                    .Parameters.AddWithValue("@b_number", TXTBN.Text)
                    .Parameters.AddWithValue("@b_img", arrImage)
                    .Parameters.AddWithValue("@fname", TXTFN.Text)
                    .Parameters.AddWithValue("@mname", TXTMN.Text)
                    .Parameters.AddWithValue("@lname", TXTLN.Text)
                    .Parameters.AddWithValue("@b_type", CBOBC.SelectedValue)
                    .Parameters.AddWithValue("@c_number", TXTCN.Text)

                    .ExecuteNonQuery()

                End With

                MsgBox("Record has been successfully saved.", vbInformation)
                con.Close()


                With frmBorrowersProfile
                    .FillBorrowersProfile()
                End With

                Me.Dispose()

            End If



        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim arrImage() As Byte




        Try
            If IsNumeric(TXTCN.Text) = False Then
                MsgBox("WARNING: You entered non-numeric character!", vbInformation)
                Exit Sub
            End If

            If TXTCN.Text = String.Empty Or TXTFN.Text = String.Empty Or TXTMN.Text = String.Empty Or TXTLN.Text = String.Empty Then
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
                Dim insertQuery As String = "INSERT INTO rms_borrowers_profile(b_number, b_img, fname, mname, lname, b_type, c_number) " &
                    "VALUES (@b_number, @b_img, @fname, @mname, @lname, @b_type, @c_number)"
                cm = New MySqlCommand(insertQuery, con)

                With cm
                    .Parameters.AddWithValue("@b_number", TXTBN.Text)
                    .Parameters.AddWithValue("@b_img", arrImage)
                    .Parameters.AddWithValue("@fname", TXTFN.Text)
                    .Parameters.AddWithValue("@mname", TXTMN.Text)
                    .Parameters.AddWithValue("@lname", TXTLN.Text)
                    .Parameters.AddWithValue("@b_type", CBOBC.SelectedValue)
                    .Parameters.AddWithValue("@c_number", TXTCN.Text)


                    .ExecuteNonQuery()

                End With

                MsgBox("Record has been successfully saved.", vbInformation)
                con.Close()



                TXTBN.Clear()
                PictureBox1.BackgroundImage = Nothing
                CBOBC.Text = "Select a Borrowers"
                TXTFN.Clear()
                TXTMN.Clear()
                TXTLN.Clear()
                TXTCN.Clear()

            End If

            With frmBorrowersProfile
                .FillBorrowersProfile()
            End With

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub CBOBC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOBC.SelectedIndexChanged
        If CBOBC.Text = "Faculty" Then
            TXTBN.Text = GenerateFaculty()
        Else
            TXTBN.Text = GenerateStudent()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using odf As New OpenFileDialog With {.Filter = "(Image.Files)|*.jpg;*.png;*.jpeg; *.jpeg|*.jpg|*.png",
                              .Multiselect = False, .Title = "Select Image"}
            If odf.ShowDialog = 1 Then
                PictureBox1.BackgroundImage = Image.FromFile(odf.FileName)
            End If
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class