Imports MySql.Data.MySqlClient
Public Class frmStaffDashboard
    Sub AllBorrowed()
        con.Open()

        cm = New MySqlCommand("SELECT COUNT(*) as BI FROM rms_transaction WHERE status='Borrowed'", con)

        dr = cm.ExecuteReader


        While dr.Read

            LBLBORROWED.Text = dr.Item("BI")

        End While
        dr.Close()

        con.Close()

    End Sub

    Sub AllReturned()
        con.Open()

        cm = New MySqlCommand("SELECT COUNT(*) as BI FROM rms_transaction WHERE status='Returned'", con)

        dr = cm.ExecuteReader


        While dr.Read

            LBLRETURN.Text = dr.Item("BI")

        End While
        dr.Close()

        con.Close()

    End Sub

    Sub Alltransaction()
        con.Open()

        cm = New MySqlCommand("SELECT COUNT(*) as BI FROM rms_transaction ", con)

        dr = cm.ExecuteReader


        While dr.Read

            LBLTRAN.Text = dr.Item("BI")

        End While
        dr.Close()

        con.Close()

    End Sub

    Private Sub frmStaffDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Alltransaction()
        AllReturned()
        AllBorrowed()

    End Sub
End Class