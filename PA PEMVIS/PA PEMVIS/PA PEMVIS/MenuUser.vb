Imports MySql.Data.MySqlClient
Imports System.IO

Public Class MenuUser

    Private WithEvents pic As New PictureBox
    Private WithEvents lblD, lblP As New Label

    Private Sub MenuUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilGambar()
    End Sub

    Sub tampilGambar()
        CMD = New MySqlCommand("select gambar, nama, harga, id_barang from barang where stok > 0", CONN)
        RD = CMD.ExecuteReader
        While RD.Read
            Dim len As Long = RD.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte
            RD.GetBytes(0, 0, array, 0, CInt(len))

            pic = New PictureBox
            pic.Width = 150
            pic.Height = 150
            pic.BackgroundImageLayout = ImageLayout.Stretch
            pic.Tag = RD.Item("id_barang").ToString

            lblD = New Label
            lblD.ForeColor = Color.White
            lblD.BackColor = Color.FromArgb(0, 184, 148)
            lblD.Dock = DockStyle.Top

            lblP = New Label
            lblP.BackColor = Color.LemonChiffon
            lblP.Dock = DockStyle.Bottom

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)
            pic.BackgroundImage = bitmap
            lblD.Text = RD.Item("nama").ToString
            lblP.Text = RD.Item("harga").ToString
            pic.Controls.Add(lblD)
            pic.Controls.Add(lblP)

            FlowLayoutPanel1.Controls.Add(pic)

            AddHandler pic.Click, AddressOf lblD_Click

        End While
        RD.Close()
    End Sub

    Public Sub lbld_Click(sender As Object, e As EventArgs)
        DetailBarang.Show()
        DetailBarang.idBarang = sender.tag
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Keranjang.Show()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FlowLayoutPanel1.Controls.Clear()
        CMD = New MySqlCommand("select gambar, nama, harga, id_barang from barang where nama like '%" & txtSearch.Text & "%' and stok > 0", CONN)
        RD = CMD.ExecuteReader
        While RD.Read
            Dim len As Long = RD.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte
            RD.GetBytes(0, 0, array, 0, CInt(len))

            pic = New PictureBox
            pic.Width = 150
            pic.Height = 150
            pic.BackgroundImageLayout = ImageLayout.Stretch
            pic.Tag = RD.Item("id_barang").ToString

            lblD = New Label
            lblD.ForeColor = Color.White
            lblD.BackColor = Color.FromArgb(0, 184, 148)
            lblD.Dock = DockStyle.Top

            lblP = New Label
            lblP.BackColor = Color.LemonChiffon
            lblP.Dock = DockStyle.Bottom

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)
            pic.BackgroundImage = bitmap
            lblD.Text = RD.Item("nama").ToString
            lblP.Text = RD.Item("harga").ToString
            pic.Controls.Add(lblD)
            pic.Controls.Add(lblP)

            FlowLayoutPanel1.Controls.Add(pic)

            AddHandler pic.Click, AddressOf lbld_Click

        End While
        RD.Close()
    End Sub

    Private Sub cbProduk_TextChanged(sender As Object, e As EventArgs) Handles cbProduk.TextChanged
        FlowLayoutPanel1.Controls.Clear()
        CMD = New MySqlCommand("select gambar, nama, harga, id_barang from barang where jenis like '%" & cbProduk.Text & "%' and stok > 0", CONN)
        RD = CMD.ExecuteReader
        While RD.Read
            Dim len As Long = RD.GetBytes(0, 0, Nothing, 0, 0)
            Dim array(CInt(len)) As Byte
            RD.GetBytes(0, 0, array, 0, CInt(len))

            pic = New PictureBox
            pic.Width = 150
            pic.Height = 150
            pic.BackgroundImageLayout = ImageLayout.Stretch
            pic.Tag = RD.Item("id_barang").ToString

            lblD = New Label
            lblD.ForeColor = Color.White
            lblD.BackColor = Color.FromArgb(0, 184, 148)
            lblD.Dock = DockStyle.Top

            lblP = New Label
            lblP.BackColor = Color.LemonChiffon
            lblP.Dock = DockStyle.Bottom

            Dim ms As New MemoryStream(array)
            Dim bitmap As New System.Drawing.Bitmap(ms)
            pic.BackgroundImage = bitmap
            lblD.Text = RD.Item("nama").ToString
            lblP.Text = RD.Item("harga").ToString
            pic.Controls.Add(lblD)
            pic.Controls.Add(lblP)

            FlowLayoutPanel1.Controls.Add(pic)

            AddHandler pic.Click, AddressOf lbld_Click

        End While
        RD.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Login.ResetText()
        Login.Show()
    End Sub
End Class