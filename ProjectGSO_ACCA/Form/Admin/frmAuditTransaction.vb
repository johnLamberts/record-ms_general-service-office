Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmAuditTransaction
    Public Sub TransactionReport(ByVal query As String)


        Dim reportDs As New ReportDataSource

        Try
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\TransactionReport.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1

            Dim da As New MySqlDataAdapter

            con.Open()
            da.SelectCommand = New MySqlCommand(query, con)
            da.Fill(ds.Tables("rms_transaction"))
            con.Close()

            'Dim salesDate As New ReportParameter("sdate", "Date (FROM - TO): " & sales_date1 & " - " & sales_date2)

            'ReportViewer1.LocalReport.SetParameters(salesDate)

            reportDs = New ReportDataSource("DataSet1", ds.Tables("rms_transaction"))

            ReportViewer1.LocalReport.DataSources.Add(reportDs)

            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 30

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub frmAuditTransaction_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ReportViewer1.RefreshReport()
        TransactionReport("SELECT CONCAT(fname, ' ', lname) as FullName, transaction_no, item_name, item_code, quantity, date_borrowed, date_returned, rt.status FROM rms_transaction rt JOIN rms_borrowers_profile USING(bpid)")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.ReportViewer1.RefreshReport()

        TransactionReport("SELECT CONCAT(fname, ' ', lname) as FullName, transaction_no, item_name, item_code, quantity, date_borrowed, date_returned, rt.status FROM rms_transaction rt JOIN rms_borrowers_profile USING(bpid) WHERE date_borrowed BETWEEN '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' AND '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' AND rt.status='Borrowed'")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.ReportViewer1.RefreshReport()

        TransactionReport("SELECT CONCAT(fname, ' ', lname) as FullName, transaction_no, item_name, item_code, quantity, date_borrowed, date_returned, rt.status FROM rms_transaction rt JOIN rms_borrowers_profile USING(bpid)")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.ReportViewer1.RefreshReport()

        TransactionReport("SELECT CONCAT(fname, ' ', lname) as FullName, transaction_no, item_name, item_code, quantity, date_borrowed, date_returned, rt.status FROM rms_transaction rt JOIN rms_borrowers_profile USING(bpid) WHERE date_returned BETWEEN '" & rdp1.Value.ToString("yyyy-MM-dd") & "' AND '" & rdp2.Value.ToString("yyyy-MM-dd") & "' AND rt.status='Returned'")
    End Sub
End Class