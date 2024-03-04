Public Class frmSystemSettings
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmCategory
            .TopLevel = False
            Panel2.Controls.Add(frmCategory)
            .FillCategory()
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmBorrowers
            .TopLevel = False
            Panel2.Controls.Add(frmBorrowers)
            .FillBorrower()

            .BringToFront()
            .Show()

        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With frmBackupAndRestore
            .TopLevel = False
            Panel2.Controls.Add(frmBackupAndRestore)

            .BringToFront()
            .Show()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With frmRecoverData
            .TopLevel = False
            Panel2.Controls.Add(frmRecoverData)
            .RecoveryData()
            .BringToFront()
            .Show()

        End With
    End Sub
End Class