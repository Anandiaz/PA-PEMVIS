Imports MySql.Data.MySqlClient

Public Class Login
    Dim STR As String = "server=localhost;userid=root;password=;database=pa_pemvis;"

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Username dan Password tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If username = "admin" And password = "admin" Then
            Me.Hide()
            LihatBarang.Show()
        Else
            Try
                Using conn As New MySqlConnection(STR)
                    conn.Open()
                    Dim query As String = "SELECT COUNT(*) FROM akun WHERE username = @username AND password = @password"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@username", username)
                        cmd.Parameters.AddWithValue("@password", password)
                        Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                        If result > 0 Then
                            MessageBox.Show("Login berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Dim menuUserForm As New MenuUser()
                            menuUserForm.Show()
                            Me.Hide()
                        Else
                            MessageBox.Show("Username dan Password salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtUsername.Clear()
                            txtPassword.Clear()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRegis_Click(sender As Object, e As EventArgs) Handles btnRegis.Click
        Regis.Show()
        Me.Hide()
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Username tidak boleh mengandung spasi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Password tidak boleh mengandung spasi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
