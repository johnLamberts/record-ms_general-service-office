Public Class frmStaffAuditReport
    Private Sub frmStaffAuditReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        With frmAuditBorrower
            .TopLevel = False
            borrowerPanel.Controls.Add(frmAuditBorrower)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedIndex = 0 Then
            With frmAuditBorrower
                .TopLevel = False
                borrowerPanel.Controls.Add(frmAuditBorrower)
                .BringToFront()
                .Show()
            End With
        ElseIf TabControl1.SelectedIndex = 1 Then
            With frmAuditTransaction
                .TopLevel = False
                transactionReportPanel.Controls.Add(frmAuditTransaction)
                .BringToFront()
                .Show()
            End With
        End If
    End Sub
End Class