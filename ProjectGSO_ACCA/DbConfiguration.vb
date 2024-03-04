
Imports MySql.Data.MySqlClient
Module DbConfiguration

    Public cm As New MySqlCommand
    Public dr As MySqlDataReader
    Public Function strCon() As MySqlConnection
        Return New MySqlConnection("server=localhost;username=root;password=;database=rms_gso; convert zero DateTime=true")
    End Function

    Public con As MySqlConnection = strCon()


    Public Sub UserLog(ByVal name As String, ByVal actions As String)
        con.Open()

        cm = New MySqlCommand("INSERT INTO rms_act_log (login_name, actions) VALUES (@login_name, @actions)", con)

        With cm.Parameters
            .AddWithValue("@login_name", name)
            .AddWithValue("@actions", actions)
        End With
        cm.ExecuteNonQuery()

        con.Close()

    End Sub
End Module
