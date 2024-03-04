

Imports MySql.Data.MySqlClient

Public Class frmDashboard
    Sub AllBorrowers()
        con.Open()

        cm = New MySqlCommand("SELECT COUNT(*) as BI FROM rms_borrowers_profile", con)

        dr = cm.ExecuteReader


        While dr.Read

            LBLBORROWER.Text = dr.Item("BI")

        End While

        dr.Close()

        con.Close()

    End Sub


    Sub AllUsers()
        con.Open()

        cm = New MySqlCommand("SELECT COUNT(*) as BI FROM rms_user", con)

        dr = cm.ExecuteReader


        While dr.Read

            LBLUSERS.Text = dr.Item("BI")

        End While
        dr.Close()

        con.Close()

    End Sub

    Sub AllItems()
        con.Open()

        cm = New MySqlCommand("SELECT COUNT(*) as BI FROM rms_item", con)

        dr = cm.ExecuteReader


        While dr.Read

            LBLITEMS.Text = dr.Item("BI")

        End While
        dr.Close()

        con.Close()

    End Sub

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


    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        AllBorrowers()
        AllUsers()
        AllItems()
        AllBorrowed()
        AllReturned()
        Alltransaction()

    End Sub

    Private Sub LBLUSERS_Click(sender As Object, e As EventArgs) Handles LBLUSERS.Click, LBLITEMS.Click

    End Sub
End Class