
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmAuditBorrower
    Public Sub BorrowerReport(ByVal query As String)


        Dim reportDs As New ReportDataSource

        Try
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\BorrowerProfileReport.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1

            Dim da As New MySqlDataAdapter

            con.Open()
            da.SelectCommand = New MySqlCommand(query, con)
            da.Fill(ds.Tables("rms_borrowers_profile"))
            con.Close()

            'Dim salesDate As New ReportParameter("sdate", "Date (FROM - TO): " & sales_date1 & " - " & sales_date2)

            'ReportViewer1.LocalReport.SetParameters(salesDate)

            reportDs = New ReportDataSource("DataSet1", ds.Tables("rms_borrowers_profile"))

            ReportViewer1.LocalReport.DataSources.Add(reportDs)

            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 30

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frmAuditBorrower_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ReportViewer1.RefreshReport()

        BorrowerReport("SELECT * FROM rms_borrowers_profile rbp INNER JOIN rms_borrowers_type rbt ON rbt.bid=rbp.b_type")

    End Sub
End Class