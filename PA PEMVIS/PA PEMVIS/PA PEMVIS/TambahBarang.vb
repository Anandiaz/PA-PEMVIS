Imports MySql.Data.MySqlClient
Imports System.IO

Public Class TambahBarang
    Dim jenis, kualitas, tglformat As String
    Dim countBarang As Integer = 1
    Public idBarang As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub BtnLihatBarang_Click(sender As Object, e As EventArgs) Handles BtnLihatBarang.Click
        Me.Hide()
        LihatBarang.Show()
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        If txtNama.Text = Nothing Or txtHarga.Text = Nothing Or CbKompenen.Text = Nothing Or (RdBaru.Checked = False And RdBekas.Checked = False) Or
            txtMerek.Text = Nothing Or txtStok.Text = Nothing Or PictureBox2.Image Is Nothing Then
            MessageBox.Show("Semua kolom dan gambar harus terisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CbKompenen.Focus()
            Return
        End If
        Select Case CbKompenen.Text
            Case "Processor"
                jenis = "PRO"
            Case "Ram"
                jenis = "RAM"
            Case "Motherboard"
                jenis = "MOB"
            Case "Vga"
                jenis = "VGA"
            Case "Psu"
                jenis = "PSU"
            Case "Monitor"
                jenis = "MON"
            Case "Ssd"
                jenis = "SSD"
            Case "Hdd"
                jenis = "HDD"
            Case "Casing"
                jenis = "CAS"
            Case "Kipas / Fan"
                jenis = "FAN"
            Case "Mouse"
                jenis = "MOS"
            Case "Keyboard"
                jenis = "KYB"
        End Select

        idBarang = jenis & countBarang

        Dim ms As New MemoryStream
        PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)

        If BtnSimpan.Text = "Simpan" Then
            While True
                CMD = New MySqlCommand("Select * from barang where id_barang ='" & idBarang & "'", CONN)
                RD = CMD.ExecuteReader
                RD.Read()
                If Not RD.HasRows Then
                    tglformat = Format(CDate(dtGaransi.Text), "yyyy-MM-dd")
                    If RdBaru.Checked = True Then
                        kualitas = "Baru"
                    Else
                        kualitas = "Bekas"
                    End If
                    RD.Close()
                    CMD = New MySqlCommand("insert into barang values('" & idBarang & "', '" & CbKompenen.Text & "','" & txtNama.Text & "','" & txtMerek.Text & "','" & tglformat & "','" & txtHarga.Text & "','" & kualitas & "','" & txtStok.Text & "', @img)", CONN)
                    CMD.Parameters.Add("@img", MySqlDbType.Blob).Value = ms.ToArray()
                    CMD.ExecuteNonQuery()
                    MsgBox("Simpan Data Sukses!")

                    ' Reset all controls to their default state
                    Me.Close()
                    LihatBarang.Show()
                    LihatBarang.tampilTabel()
                    Exit While
                Else
                    RD.Close()
                    countBarang += 1
                    idBarang = jenis & countBarang
                End If
            End While
        ElseIf BtnSimpan.Text = "Ubah" Then
            tglformat = Format(CDate(dtGaransi.Text), "yyyy-MM-dd")
            If RdBaru.Checked = True Then
                kualitas = "Baru"
            Else
                kualitas = "Bekas"
            End If
            
            CMD = New MySqlCommand("UPDATE barang SET jenis='" & CbKompenen.Text & "', nama= '" & txtNama.Text & "', merk= '" & txtMerek.Text & "', garansi= '" & tglformat & "', harga= '" & txtHarga.Text & "', kualitas= '" & kualitas & "', stok='" & txtStok.Text & "', gambar =@img where id_barang='" & idBarang & "'", CONN)
            CMD.Parameters.AddWithValue("@img", ms.ToArray())
            CMD.ExecuteNonQuery()
            MsgBox("ubah Data Sukses!")

            ' Reset all controls to their default state
            Me.Close()
            LihatBarang.Show()
            LihatBarang.tampilTabel()
        End If


    End Sub

    Private Sub BtnGambar_Click(sender As Object, e As EventArgs) Handles BtnGambar.Click
        Dim opf As New OpenFileDialog

        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"

        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(opf.FileName)
        End If
    End Sub

    Private Sub txtMerek_TextChanged(sender As Object, e As EventArgs) Handles txtMerek.TextChanged
        If Not IsInputString(txtMerek.Text) Then
            MessageBox.Show("Kolom Merek hanya boleh diisi dengan huruf.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMerek.Clear()
        End If
    End Sub

    Private Sub txtHarga_TextChanged(sender As Object, e As EventArgs) Handles txtHarga.TextChanged
        If Not IsInputInteger(txtHarga.Text) Then
            MessageBox.Show("Kolom Harga hanya boleh diisi dengan angka.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHarga.Clear()
        End If
    End Sub

    Private Sub txtStok_TextChanged(sender As Object, e As EventArgs) Handles txtStok.TextChanged
        If Not IsInputInteger(txtStok.Text) Then
            MessageBox.Show("Kolom Stok hanya boleh diisi dengan angka.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStok.Clear()
        End If
    End Sub

    Private Function IsInputString(input As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(input, "^[a-zA-Z\s]*$")
    End Function

    Private Function IsInputInteger(input As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(input, "^\d+$")
    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Public Sub ResetForm()
        ' Reset all text fields
        txtNama.Clear()
        txtMerek.Clear()
        txtHarga.Clear()
        txtStok.Clear()
        ' Reset ComboBox
        CbKompenen.SelectedIndex = -1
        ' Reset RadioButton
        RdBaru.Checked = False
        RdBekas.Checked = False
        ' Reset DateTimePicker
        dtGaransi.Value = DateTime.Now
        ' Clear PictureBox
        PictureBox2.Image = Nothing
        countBarang = 1
    End Sub
End Class
