Imports MySql.Data.MySqlClient

Public Class Regis
    Dim STR As String = "server=localhost;userid=root;password=;database=pa_pemvis"

    Private Sub btnRegis_Click(sender As Object, e As EventArgs) Handles btnRegis.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Username dan Password tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(STR)
                conn.Open()
                Dim checkQuery As String = "SELECT COUNT(*) FROM akun WHERE username = @username"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@username", username)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Username telah digunakan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtUsername.Clear()
                        txtPassword.Clear()
                        Return
                    End If
                End Using

                Dim query As String = "INSERT INTO akun (username, password) VALUES (@username, @password)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Registrasi berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsername.Clear()
            txtPassword.Clear()
            Me.Hide()
            Login.Show()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Dim loginForm As New Login()
        loginForm.Show()
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
