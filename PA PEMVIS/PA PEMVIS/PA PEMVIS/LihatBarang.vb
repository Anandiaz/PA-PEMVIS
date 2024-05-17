Imports MySql.Data.MySqlClient

Public Class LihatBarang
    Dim idBarang As String

    Sub tampilTabel()
        DA = New MySqlDataAdapter("SELECT * FROM barang", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "id_barang")
        DataGridView1.DataSource = DS.Tables("id_barang")
        DataGridView1.Refresh()
    End Sub

    Sub aturGrid()
        DataGridView1.Columns(0).HeaderText = "id barang"
        DataGridView1.Columns(1).HeaderText = "Jenis"
        DataGridView1.Columns(2).HeaderText = "Nama"
        DataGridView1.Columns(3).HeaderText = "Merk"
        DataGridView1.Columns(4).HeaderText = "Garansi"
        DataGridView1.Columns(5).HeaderText = "harga"
        DataGridView1.Columns(6).HeaderText = "kualitas"
        DataGridView1.Columns(7).HeaderText = "stok"
        DataGridView1.Columns(8).HeaderText = "gambar"
        Dim imgcol As DataGridViewImageColumn = DirectCast(DataGridView1.Columns(8), DataGridViewImageColumn)
        imgcol.ImageLayout = DataGridViewImageCellLayout.Stretch

    End Sub

    Private Sub LihatBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.RowTemplate.Height = 100
        koneksi()
        tampilTabel()
        aturGrid()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If idBarang = "" Then
            MsgBox("Silahkan pilih data terlebih dahulu")
        Else
            TambahBarang.BtnSimpan.Text = "Ubah"
            TambahBarang.ResetForm()
            TambahBarang.Show()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If idBarang = "" Then
            MsgBox("Silahkan pilih data terlebih dahulu")
        Else
            Dim pilihan = MessageBox.Show("Apakah anda yakin ingin menghapus data dengan ID " & idBarang & " ?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If pilihan = Windows.Forms.DialogResult.Yes Then
                CMD = New MySqlCommand("delete from barang where id_barang = '" & idBarang & "'", CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Hapus Data Sukses!")
                tampilTabel()
            Else
                MsgBox("Data tidak jadi dihapus")
                idBarang = ""
            End If
        End If


    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DataGridView1.SelectedRows(0)
            If row.Index < DataGridView1.RowCount - 1 And row.Index >= 0 Then
                idBarang = row.Cells(0).Value
                TambahBarang.idBarang = row.Cells(0).Value
                TambahBarang.CbKompenen.Text = row.Cells(1).Value
                TambahBarang.txtNama.Text = row.Cells(2).Value
                TambahBarang.txtMerek.Text = row.Cells(3).Value
                TambahBarang.dtGaransi.Value = row.Cells(4).Value
                TambahBarang.txtHarga.Text = row.Cells(5).Value
                TambahBarang.txtStok.Text = row.Cells(7).Value
            End If
        End If

    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        TambahBarang.BtnSimpan.Text = "Simpan"
        TambahBarang.ResetForm()
        TambahBarang.Show()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If txtCari.Text <> Nothing Then
            If txtCari.Text = "Cari ID tiket atau ID bus" Then
            Else
                CMD = New MySqlCommand("select * from barang where id_barang like '%" & txtCari.Text & "%'", CONN)
                RD = CMD.ExecuteReader()
                If RD.HasRows Then
                    DS.Clear()
                    While RD.Read()
                        Dim dsNewRow As DataRow = DS.Tables("id_barang").NewRow()
                        dsNewRow.Item(0) = RD("id_barang")
                        dsNewRow.Item(1) = RD("jenis")
                        dsNewRow.Item(2) = RD("nama")
                        dsNewRow.Item(3) = RD("merk")
                        dsNewRow.Item(4) = RD("garansi")
                        dsNewRow.Item(5) = RD("harga")
                        dsNewRow.Item(6) = RD("kualitas")
                        dsNewRow.Item(7) = RD("stok")
                        dsNewRow.Item(8) = RD("gambar")
                        DS.Tables("id_barang").Rows.Add(dsNewRow)
                    End While
                Else
                    MsgBox("Data tidak ditemukan")
                End If
                RD.Close()
            End If
        Else
            tampilTabel()
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Login.ResetText()
        Login.Show()
    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Login.Show()
    End Sub
End Class