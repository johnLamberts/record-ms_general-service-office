Public Class frmStaffMainForm
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With frmBorrowersProfile
            .TopLevel = False
            panelChildForm.Controls.Add(frmBorrowersProfile)
            .FillBorrowersProfile()
            .BringToFront()
            .Show()
        End With
        UserLog(LBLLOGINANME.Text, "Navigate to Borrowers Profile")

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With frmTransactionList
            .TopLevel = False
            panelChildForm.Controls.Add(frmTransactionList)
            .BringToFront()
            .Show()

        End With

        UserLog(LBLLOGINANME.Text, "Navigate to Transaction")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With frmStaffAuditReport
            .TopLevel = False
            panelChildForm.Controls.Add(frmStaffAuditReport)
            .BringToFront()
            .Show()

        End With

        UserLog(LBLLOGINANME.Text, "Navigate to Transaction")
    End Sub

    Private Sub btnDp_Click(sender As Object, e As EventArgs) Handles btnDp.Click
        With frmStaffSystemSettings
            .TopLevel = False
            panelChildForm.Controls.Add(frmStaffSystemSettings)
            .BringToFront()
            .Show()
        End With

        UserLog(LBLLOGINANME.Text, "Navigate to System Settings")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Are you sure you want to log out your account?", vbOKCancel + vbInformation, "Sign Out") = vbOK Then
            With frmSplashScreen
                .Show()
            End With
            Me.Close()

            'UserLog(dr.Item("login_name").ToString, "Successfully Logout")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmStaffDashboard
            .TopLevel = False
            panelChildForm.Controls.Add(frmStaffDashboard)
            .BringToFront()
            .Show()
        End With

        UserLog(LBLLOGINANME.Text, "Navigate to System Settings")
    End Sub
End Class