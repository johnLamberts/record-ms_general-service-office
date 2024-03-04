Public Class frmAuditReports
    Private Sub frmAuditReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        With frmAuditUserAccount
            .TopLevel = False
            userAccountPnl.Controls.Add(frmAuditUserAccount)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedIndex = 0 Then
            With frmAuditUserAccount
                .TopLevel = False
                userAccountPnl.Controls.Add(frmAuditUserAccount)
                .BringToFront()
                .Show()
            End With
        ElseIf TabControl1.SelectedIndex = 1 Then
            With frmAuditLog
                .TopLevel = False
                logPanel.Controls.Add(frmAuditLog)
                .BringToFront()
                .Show()
            End With
        ElseIf TabControl1.SelectedIndex = 2 Then
            With frmAuditItem
                .TopLevel = False
                itemPanel.Controls.Add(frmAuditItem)
                .BringToFront()
                .Show()
            End With
        ElseIf TabControl1.SelectedIndex = 3 Then
            With frmAuditItemStock
                .TopLevel = False
                itemStockPanel.Controls.Add(frmAuditItemStock)
                .BringToFront()
                .Show()
            End With
        ElseIf TabControl1.SelectedIndex = 4 Then
            With frmAuditBorrower
                .TopLevel = False
                borrowerPanel.Controls.Add(frmAuditBorrower)
                .BringToFront()
                .Show()
            End With
        ElseIf TabControl1.SelectedIndex = 5 Then
            With frmAuditTransaction
                .TopLevel = False
                transactionReportPanel.Controls.Add(frmAuditTransaction)
                .BringToFront()
                .Show()
            End With
        End If
    End Sub
End Class