
Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmAuditItem

    Sub FillCategory()
        Dim da As New MySqlDataAdapter
        Dim dt As New DataTable
        Dim subQuery As String = "SELECT * FROM rms_item_category"


        con.Open()
        cm = New MySqlCommand(subQuery, con)
        da.SelectCommand = cm
        CBOIC.Items.Clear()


        da.Fill(dt)

        CBOIC.DataSource = dt
        CBOIC.ValueMember = "catid"
        CBOIC.DisplayMember = "catname"
        con.Close()
    End Sub
    Public Sub ItemReport(ByVal query As String)


        Dim reportDs As New ReportDataSource

        Try
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Reports\ItemReport.rdlc"
                .DataSources.Clear()
            End With

            Dim ds As New DataSet1

            Dim da As New MySqlDataAdapter

            con.Open()
            da.SelectCommand = New MySqlCommand(query, con)
            da.Fill(ds.Tables("rms_item"))
            con.Close()

            'Dim salesDate As New ReportParameter("sdate", "Date (FROM - TO): " & sales_date1 & " - " & sales_date2)

            'ReportViewer1.LocalReport.SetParameters(salesDate)

            reportDs = New ReportDataSource("DataSet1", ds.Tables("rms_item"))

            ReportViewer1.LocalReport.DataSources.Add(reportDs)

            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 30

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frmAuditItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillCategory()

        Me.ReportViewer1.RefreshReport()
        ItemReport("SELECT * FROM rms_item ri INNER JOIN rms_item_category ric ON ric.catid=ri.item_cat_id")

    End Sub

    Private Sub CBOiC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOiC.SelectedIndexChanged
    End Sub

    Private Sub CBOSTATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOSTATUS.SelectedIndexChanged
        Me.ReportViewer1.RefreshReport()
        ItemReport("SELECT * FROM rms_item ri INNER JOIN rms_item_category ric ON ric.catid=ri.item_cat_id WHERE status='" & CBOSTATUS.Text & "' AND item_cat_id='" & CBOiC.SelectedValue & "'")
    End Sub
End Class