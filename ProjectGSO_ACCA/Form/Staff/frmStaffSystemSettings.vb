Public Class frmStaffSystemSettings
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        With frmCategory
            .TopLevel = False
            Panel2.Controls.Add(frmCategory)
            .FillCategory()
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        With frmBorrowers
            .TopLevel = False
            Panel2.Controls.Add(frmBorrowers)
            .FillBorrower()

            .BringToFront()
            .Show()

        End With
    End Sub
End Class