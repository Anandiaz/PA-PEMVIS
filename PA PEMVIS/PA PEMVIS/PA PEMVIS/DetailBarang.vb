Imports MySql.Data.MySqlClient

Public Class DetailBarang

    Public idBarang As String

    Private Sub btnKonfirmasi_Click(sender As Object, e As EventArgs) Handles btnKonfirmasi.Click
        CMD = New MySqlCommand("select gambar, nama, harga, stok from barang where id_barang = '" & idBarang & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        Dim count As Integer
        If CInt(txtJumlah.Text) <= CInt(RD.Item("stok")) Then
            If Keranjang.DataGridView1.Rows.Count > 0 Then
                For Each row As DataGridViewRow In Keranjang.DataGridView1.Rows
                    If row.Cells("idBarang").Value = idBarang Then
                        Dim total As Integer
                        total = CInt(row.Cells("jumlah").Value) + CInt(txtJumlah.Text)
                        If total > CInt(RD.Item("stok")) Then
                            MsgBox("stok kurang")
                            RD.Close()
                        Else
                            row.Cells("jumlah").Value = total
                            row.Cells("totalHarga").Value = CInt(row.Cells("jumlah").Value) * CInt(row.Cells("harga").Value)
                            RD.Close()
                            Me.Close()
                        End If
                        Exit For
                    End If
                    count += 1
                Next
                If count = Keranjang.DataGridView1.Rows.Count Then
                    Keranjang.DataGridView1.Rows.Add(RD.Item("gambar"), RD.Item("nama"), RD.Item("harga").ToString, txtJumlah.Text, CInt(RD.Item("harga").ToString) * CInt(txtJumlah.Text), idBarang)
                    RD.Close()
                    Me.Close()
                End If
            Else
                Keranjang.DataGridView1.Rows.Add(RD.Item("gambar"), RD.Item("nama"), RD.Item("harga").ToString, txtJumlah.Text, CInt(RD.Item("harga").ToString) * CInt(txtJumlah.Text), idBarang)
                RD.Close()
                Me.Close()
            End If
        Else
            MsgBox("stok kurang")
            RD.Close()
        End If
    End Sub

    Private Sub DetailBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub txtJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlah.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            MsgBox("Hanya bisa diisi dengan angka")
        End If
    End Sub

    Private Sub txtJumlah_TextChanged(sender As Object, e As EventArgs) Handles txtJumlah.TextChanged

    End Sub
End Class
