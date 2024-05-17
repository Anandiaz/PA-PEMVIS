<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailBarang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJumlah = New System.Windows.Forms.TextBox()
        Me.btnKonfirmasi = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DeepPink
        Me.Label1.Location = New System.Drawing.Point(72, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(405, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Berapa jumlah yang ingin kamu beli?"
        '
        'txtJumlah
        '
        Me.txtJumlah.BackColor = System.Drawing.Color.White
        Me.txtJumlah.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtJumlah.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJumlah.ForeColor = System.Drawing.Color.Black
        Me.txtJumlah.Location = New System.Drawing.Point(196, 159)
        Me.txtJumlah.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Size = New System.Drawing.Size(149, 28)
        Me.txtJumlah.TabIndex = 1
        '
        'btnKonfirmasi
        '
        Me.btnKonfirmasi.BackColor = System.Drawing.Color.SpringGreen
        Me.btnKonfirmasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKonfirmasi.ForeColor = System.Drawing.Color.Black
        Me.btnKonfirmasi.Location = New System.Drawing.Point(196, 242)
        Me.btnKonfirmasi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnKonfirmasi.Name = "btnKonfirmasi"
        Me.btnKonfirmasi.Size = New System.Drawing.Size(149, 39)
        Me.btnKonfirmasi.TabIndex = 2
        Me.btnKonfirmasi.Text = "KONFIRMASI"
        Me.btnKonfirmasi.UseVisualStyleBackColor = False
        '
        'DetailBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.solid_color_image
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(559, 385)
        Me.Controls.Add(Me.btnKonfirmasi)
        Me.Controls.Add(Me.txtJumlah)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "DetailBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DetailBarang"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtJumlah As System.Windows.Forms.TextBox
    Friend WithEvents btnKonfirmasi As System.Windows.Forms.Button
End Class
