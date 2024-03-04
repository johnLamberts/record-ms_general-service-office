<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToBorrowDescription
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBLICODE = New System.Windows.Forms.Label()
        Me.LBLIN = New System.Windows.Forms.Label()
        Me.LBLINl3 = New System.Windows.Forms.Label()
        Me.LBLCAT = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.LBLSTOCK = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.qty = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBLITEMID = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(33, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(177, 178)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Item Code: "
        '
        'LBLICODE
        '
        Me.LBLICODE.ForeColor = System.Drawing.Color.Black
        Me.LBLICODE.Location = New System.Drawing.Point(101, 236)
        Me.LBLICODE.Name = "LBLICODE"
        Me.LBLICODE.Size = New System.Drawing.Size(116, 16)
        Me.LBLICODE.TabIndex = 2
        '
        'LBLIN
        '
        Me.LBLIN.ForeColor = System.Drawing.Color.Black
        Me.LBLIN.Location = New System.Drawing.Point(339, 84)
        Me.LBLIN.Name = "LBLIN"
        Me.LBLIN.Size = New System.Drawing.Size(172, 16)
        Me.LBLIN.TabIndex = 4
        '
        'LBLINl3
        '
        Me.LBLINl3.AutoSize = True
        Me.LBLINl3.ForeColor = System.Drawing.Color.Black
        Me.LBLINl3.Location = New System.Drawing.Point(259, 84)
        Me.LBLINl3.Name = "LBLINl3"
        Me.LBLINl3.Size = New System.Drawing.Size(74, 16)
        Me.LBLINl3.TabIndex = 3
        Me.LBLINl3.Text = "Item Name:"
        '
        'LBLCAT
        '
        Me.LBLCAT.ForeColor = System.Drawing.Color.Black
        Me.LBLCAT.Location = New System.Drawing.Point(339, 122)
        Me.LBLCAT.Name = "LBLCAT"
        Me.LBLCAT.Size = New System.Drawing.Size(172, 16)
        Me.LBLCAT.TabIndex = 6
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.ForeColor = System.Drawing.Color.Black
        Me.lbl2.Location = New System.Drawing.Point(271, 122)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(62, 16)
        Me.lbl2.TabIndex = 5
        Me.lbl2.Text = "Category:"
        '
        'LBLSTOCK
        '
        Me.LBLSTOCK.ForeColor = System.Drawing.Color.Black
        Me.LBLSTOCK.Location = New System.Drawing.Point(339, 162)
        Me.LBLSTOCK.Name = "LBLSTOCK"
        Me.LBLSTOCK.Size = New System.Drawing.Size(172, 16)
        Me.LBLSTOCK.TabIndex = 8
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(236, 162)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(97, 16)
        Me.lbl.TabIndex = 7
        Me.lbl.Text = "Available Stock"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(223, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Borrow Quantity: "
        '
        'qty
        '
        Me.qty.Location = New System.Drawing.Point(342, 236)
        Me.qty.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.qty.Name = "qty"
        Me.qty.Size = New System.Drawing.Size(169, 23)
        Me.qty.TabIndex = 10
        Me.qty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(164, 289)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 28)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(310, 289)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 28)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(465, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Item ID: "
        '
        'LBLITEMID
        '
        Me.LBLITEMID.ForeColor = System.Drawing.Color.Black
        Me.LBLITEMID.Location = New System.Drawing.Point(518, 9)
        Me.LBLITEMID.Name = "LBLITEMID"
        Me.LBLITEMID.Size = New System.Drawing.Size(72, 16)
        Me.LBLITEMID.TabIndex = 2
        '
        'frmToBorrowDescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(602, 334)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.qty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBLSTOCK)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.LBLCAT)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.LBLIN)
        Me.Controls.Add(Me.LBLINl3)
        Me.Controls.Add(Me.LBLITEMID)
        Me.Controls.Add(Me.LBLICODE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Bahnschrift Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(179, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmToBorrowDescription"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmToBorrowDescription"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LBLICODE As Label
    Friend WithEvents LBLIN As Label
    Friend WithEvents LBLINl3 As Label
    Friend WithEvents LBLCAT As Label
    Friend WithEvents lbl2 As Label
    Friend WithEvents LBLSTOCK As Label
    Friend WithEvents lbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents qty As NumericUpDown
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents LBLITEMID As Label
End Class
