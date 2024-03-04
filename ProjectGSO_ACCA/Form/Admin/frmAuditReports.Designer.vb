<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.userAccountPnl = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.itemPanel = New System.Windows.Forms.Panel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.itemStockPanel = New System.Windows.Forms.Panel()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.logPanel = New System.Windows.Forms.Panel()
        Me.borrowerPanel = New System.Windows.Forms.Panel()
        Me.transactionReportPanel = New System.Windows.Forms.Panel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(750, 532)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.userAccountPnl)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(742, 503)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User Account"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'userAccountPnl
        '
        Me.userAccountPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.userAccountPnl.Location = New System.Drawing.Point(3, 3)
        Me.userAccountPnl.Name = "userAccountPnl"
        Me.userAccountPnl.Size = New System.Drawing.Size(736, 497)
        Me.userAccountPnl.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.logPanel)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(742, 503)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Activity Log"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.itemPanel)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(742, 503)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Item"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'itemPanel
        '
        Me.itemPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.itemPanel.Location = New System.Drawing.Point(0, 0)
        Me.itemPanel.Name = "itemPanel"
        Me.itemPanel.Size = New System.Drawing.Size(742, 503)
        Me.itemPanel.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.itemStockPanel)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(742, 503)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Item Stock"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'itemStockPanel
        '
        Me.itemStockPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.itemStockPanel.Location = New System.Drawing.Point(0, 0)
        Me.itemStockPanel.Name = "itemStockPanel"
        Me.itemStockPanel.Size = New System.Drawing.Size(742, 503)
        Me.itemStockPanel.TabIndex = 2
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.borrowerPanel)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(742, 503)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Borrower's Profile"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.transactionReportPanel)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(742, 503)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Transaction"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'logPanel
        '
        Me.logPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.logPanel.Location = New System.Drawing.Point(3, 3)
        Me.logPanel.Name = "logPanel"
        Me.logPanel.Size = New System.Drawing.Size(736, 497)
        Me.logPanel.TabIndex = 1
        '
        'borrowerPanel
        '
        Me.borrowerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.borrowerPanel.Location = New System.Drawing.Point(0, 0)
        Me.borrowerPanel.Name = "borrowerPanel"
        Me.borrowerPanel.Size = New System.Drawing.Size(742, 503)
        Me.borrowerPanel.TabIndex = 0
        '
        'transactionReportPanel
        '
        Me.transactionReportPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.transactionReportPanel.Location = New System.Drawing.Point(0, 0)
        Me.transactionReportPanel.Name = "transactionReportPanel"
        Me.transactionReportPanel.Size = New System.Drawing.Size(742, 503)
        Me.transactionReportPanel.TabIndex = 0
        '
        'frmAuditReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(750, 532)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Bahnschrift Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmAuditReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAuditReports"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents userAccountPnl As Panel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents itemPanel As Panel
    Friend WithEvents itemStockPanel As Panel
    Friend WithEvents logPanel As Panel
    Friend WithEvents borrowerPanel As Panel
    Friend WithEvents transactionReportPanel As Panel
End Class
