Public Class frmMainForm

    Dim drop As Boolean = True
    Private Sub frmMainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'With frmDashboard
        '    .TopLevel = False
        '    panelChildForm.Controls.Add(frmDashboard)

        '    .BringToFront()
        '    .Show()
        'End With
    End Sub

    Private Sub btnDp_Click(sender As Object, e As EventArgs)



    End Sub


    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    If drop Then
    '        dp1.Height += 50
    '        If dp1.Size = dp1.MaximumSize Then
    '            Timer1.Stop()
    '            drop = False
    '        End If
    '    Else
    '        dp1.Height -= 50

    '        If dp1.Size = dp1.MinimumSize Then
    '            Timer1.Stop()
    '            drop = True
    '        End If
    '    End If
    'End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmUserAccount
            .TopLevel = False
            panelChildForm.Controls.Add(frmUserAccount)
            .FillUsers()
            .BringToFront()
            .Show()

        End With

        UserLog(LBLLOGINANME.Text, "Navigate to User Account Management")

    End Sub

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With frmItem
            .TopLevel = False
            panelChildForm.Controls.Add(frmItem)
            .BringToFront()
            .Show()
        End With

        UserLog(LBLLOGINANME.Text, "Navigate to Inventory")

    End Sub

    Private Sub btnDp_Click_1(sender As Object, e As EventArgs) Handles btnDp.Click
        With frmSystemSettings
            .TopLevel = False
            panelChildForm.Controls.Add(frmSystemSettings)
            .BringToFront()
            .Show()
        End With

        UserLog(LBLLOGINANME.Text, "Navigate to System Settings")

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
        With frmAuditReports
            .TopLevel = False
            panelChildForm.Controls.Add(frmAuditReports)
            .BringToFront()
            .Show()
        End With

        UserLog(LBLLOGINANME.Text, "Navigate to Audit Reports")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmDashboard
            .TopLevel = False
            panelChildForm.Controls.Add(frmDashboard)
            .BringToFront()
            .Show()
        End With

        UserLog(LBLLOGINANME.Text, "Navigate to Dashboard")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If MsgBox("Are you sure you want to log out your account?", vbOKCancel + vbInformation, "Sign Out") = vbOK Then
            With frmSplashScreen
                .Show()
            End With
            Me.Close()


        End If


    End Sub
End Class
