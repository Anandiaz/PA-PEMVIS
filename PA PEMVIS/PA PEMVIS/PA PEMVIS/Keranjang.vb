Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class Keranjang
    Public baris As Integer = 0


    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Arial", 12)
        Dim name As New Font("Arial", 13, FontStyle.Bold)
        Dim invoice As New Font("Arial", 25, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim pen As New Pen(Color.Black)

        Dim jumlah As Integer = 0
        Dim total As Double = 0
        Dim logo As Image = My.Resources.p4v_removebg_preview


        e.Graphics.DrawImage(logo, leftMargin - 50, topMargin - 125, 400, 200)
        e.Graphics.DrawString("SALES INVOICE", invoice, brush, leftMargin + 900, topMargin - 25)

        e.Graphics.DrawLine(pen, leftMargin, topMargin + 60, leftMargin + 1200, topMargin + 60)

        e.Graphics.DrawString("INFO PRODUK", font, brush, leftMargin, topMargin + 80)
        e.Graphics.DrawString("JUMLAH", font, brush, leftMargin + 500, topMargin + 80)
        e.Graphics.DrawString("HARGA SATUAN", font, brush, leftMargin + 700, topMargin + 80)
        e.Graphics.DrawString("TOTAL HARGA", font, brush, leftMargin + 1000, topMargin + 80)
        For Each row As DataGridViewRow In DataGridView1.Rows
            e.Graphics.DrawString(row.Cells("nama").Value, name, brush, leftMargin, topMargin + 120 + baris)
            e.Graphics.DrawString(row.Cells("jumlah").Value.ToString, font, brush, leftMargin + 500, topMargin + 120 + baris)
            e.Graphics.DrawString(row.Cells("harga").Value.ToString, font, brush, leftMargin + 700, topMargin + 120 + baris)
            e.Graphics.DrawString(row.Cells("totalHarga").Value.ToString, font, brush, leftMargin + 1000, topMargin + 120 + baris)

            CMD = New MySqlCommand("update barang set stok = stok - " & row.Cells("jumlah").Value & " where id_barang= '" & row.Cells("idBarang").Value.ToString() & "'", CONN)
            CMD.ExecuteNonQuery()
            baris += 30
            jumlah += CInt(row.Cells("jumlah").Value)
            total += row.Cells("totalHarga").Value
        Next

        e.Graphics.DrawLine(pen, leftMargin, topMargin + 180 + baris, leftMargin + 1200, topMargin + 180 + baris)

        e.Graphics.DrawString("TOTAL HARGA (" & jumlah.ToString & " BARANG): ", name, brush, leftMargin + 700, topMargin + 210 + baris)
        e.Graphics.DrawString("Rp " + total.ToString(), name, brush, leftMargin + 1000, topMargin + 210 + baris)

        e.Graphics.DrawLine(pen, leftMargin, topMargin + 310 + baris, leftMargin + 1200, topMargin + 310 + baris)
        e.Graphics.DrawString(" Jl. Sambaliung, Sempaja Sel., Kec. Samarinda Utara,", font, brush, leftMargin, topMargin + 340 + baris)
        e.Graphics.DrawString("Kota Samarinda, Kalimantan Timur 75242", font, brush, leftMargin, topMargin + 370 + baris)
        e.Graphics.DrawString("Contact Person : Fajrin(+62 895-2079-4141)", font, brush, leftMargin, topMargin + 400 + baris)

    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        Dim paperheigth As Integer = 570 + (DataGridView1.RowCount * 30)
        MsgBox(paperheigth)
        Dim paperSize As New PaperSize("CustomPaperSize", 1400, paperheigth)

        If DataGridView1.RowCount > 0 Then
            PrintDocument1.DefaultPageSettings.PaperSize = paperSize
            Me.PrintPreviewDialog1.ShowDialog()
            PrintDocument1.Print()
            Me.Close()
            MsgBox("terima kasih sudah berbelanja")
        Else
            MsgBox("barang anda masih kosong")
            Me.Close()
        End If


    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Dim menuUserForm As New MenuUser()
        menuUserForm.Show()
        Me.Close()
    End Sub
End Class
