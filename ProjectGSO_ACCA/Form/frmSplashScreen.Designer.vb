<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplashScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LBLKAAWANALOADING = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LBLNAINDICATOR = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LBLKAAWANALOADING)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 367)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(762, 10)
        Me.Panel1.TabIndex = 2
        '
        'LBLKAAWANALOADING
        '
        Me.LBLKAAWANALOADING.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(151, Byte), Integer))
        Me.LBLKAAWANALOADING.Dock = System.Windows.Forms.DockStyle.Left
        Me.LBLKAAWANALOADING.Location = New System.Drawing.Point(0, 0)
        Me.LBLKAAWANALOADING.Name = "LBLKAAWANALOADING"
        Me.LBLKAAWANALOADING.Size = New System.Drawing.Size(1, 10)
        Me.LBLKAAWANALOADING.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ProjectGSO_ACCA.My.Resources.Resources.test
        Me.PictureBox2.Location = New System.Drawing.Point(29, 9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(117, 136)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProjectGSO_ACCA.My.Resources.Resources.Illustration___Comic_3
        Me.PictureBox1.Location = New System.Drawing.Point(164, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(382, 384)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift Light", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(287, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Republic of the Philippines"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Bahnschrift Light", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(267, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UNIVERSITY OF RIZAL SYSTEM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift Light", 11.0!)
        Me.Label3.Location = New System.Drawing.Point(301, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Binangonan, Campus"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'LBLNAINDICATOR
        '
        Me.LBLNAINDICATOR.Font = New System.Drawing.Font("Bahnschrift Light", 9.75!)
        Me.LBLNAINDICATOR.Location = New System.Drawing.Point(523, 350)
        Me.LBLNAINDICATOR.Name = "LBLNAINDICATOR"
        Me.LBLNAINDICATOR.Size = New System.Drawing.Size(239, 16)
        Me.LBLNAINDICATOR.TabIndex = 4
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ProjectGSO_ACCA.My.Resources.Resources._345917858_276559151387161_7563734434802728788_n
        Me.PictureBox3.Location = New System.Drawing.Point(563, 9)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(196, 138)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'frmSplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(762, 377)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.LBLNAINDICATOR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSplashScreen"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBLKAAWANALOADING As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LBLNAINDICATOR As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
