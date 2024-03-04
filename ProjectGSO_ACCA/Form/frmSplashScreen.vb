Public Class frmSplashScreen
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LBLKAAWANALOADING.Width += 10

        If LBLKAAWANALOADING.Width > 10 Then
            LBLNAINDICATOR.Text = "Loading yung database..."
        End If

        If LBLKAAWANALOADING.Width > 200 Then
            LBLNAINDICATOR.Text = "Binabasa yung mga data...."
        End If

        If LBLKAAWANALOADING.Width > 400 Then
            LBLNAINDICATOR.Text = "Nahihirapan ako iload...."
        End If

        If LBLKAAWANALOADING.Width > 600 Then
            LBLNAINDICATOR.Text = "I-launch ko na daw siya..."
        End If

        If LBLKAAWANALOADING.Width > 700 Then
            LBLNAINDICATOR.Text = "Andiyan na siya, pagod na si dev..."
        End If

        If LBLKAAWANALOADING.Width >= 762 Then
            Timer1.Stop()
            With frmLogin
                .Show()
            End With
            Me.Close()
        End If
    End Sub
End Class