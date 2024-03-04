Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmAuditUserAccount

    Sub UserAccount(ByVal query As String)


        Dim reportDs As New ReportDataSource

        Try
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\UserAccount.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1

            Dim da As New MySqlDataAdapter

            con.Open()
            da.SelectCommand = New MySqlCommand(query, con)
            da.Fill(ds.Tables("rms_user"))
            con.Close()

            'Dim salesDate As New ReportParameter("sdate", "Date (FROM - TO): " & sales_date1 & " - " & sales_date2)

            'ReportViewer1.LocalReport.SetParameters(salesDate)

            reportDs = New ReportDataSource("DataSet1", ds.Tables("rms_user"))

            ReportViewer1.LocalReport.DataSources.Add(reportDs)

            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 30

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frmAuditUserAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserAccount("SELECT * FROM rms_user")

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.ReportViewer1.RefreshReport()
        UserAccount("SELECT * FROM rms_user WHERE date_created BETWEEN '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "'")
    End Sub

    Private Sub CBOSTATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOSTATUS.SelectedIndexChanged
        Me.ReportViewer1.RefreshReport()
        UserAccount("SELECT * FROM rms_user WHERE status='" & CBOSTATUS.Text & "'")
    End Sub

    Private Sub CBOROLE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOROLE.SelectedIndexChanged
        Me.ReportViewer1.RefreshReport()
        UserAccount("SELECT * FROM rms_user WHERE user_type='" & CBOROLE.Text & "'")
    End Sub
End Class