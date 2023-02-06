<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAPN = New System.Windows.Forms.Button()
        Me.btnMPN = New System.Windows.Forms.Button()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.txtMTF = New System.Windows.Forms.TextBox()
        Me.txtJOB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvMTF = New System.Windows.Forms.DataGridView()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelBarTop = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMinimize = New System.Windows.Forms.PictureBox()
        Me.cbxModel = New CG_MES___MTF_Creation_Module.CenteredComboBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMTF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBarTop.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1284, 200)
        Me.Panel2.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbxModel)
        Me.GroupBox1.Controls.Add(Me.btnAPN)
        Me.GroupBox1.Controls.Add(Me.btnMPN)
        Me.GroupBox1.Controls.Add(Me.txtQTY)
        Me.GroupBox1.Controls.Add(Me.txtMTF)
        Me.GroupBox1.Controls.Add(Me.btnSubmit)
        Me.GroupBox1.Controls.Add(Me.txtJOB)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1260, 185)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MTF - Create New Material Requisition"
        '
        'btnAPN
        '
        Me.btnAPN.Enabled = False
        Me.btnAPN.Location = New System.Drawing.Point(661, 101)
        Me.btnAPN.Name = "btnAPN"
        Me.btnAPN.Size = New System.Drawing.Size(316, 31)
        Me.btnAPN.TabIndex = 6
        Me.btnAPN.Text = "x / x Parts Selected"
        Me.btnAPN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAPN.UseVisualStyleBackColor = True
        '
        'btnMPN
        '
        Me.btnMPN.Enabled = False
        Me.btnMPN.Location = New System.Drawing.Point(661, 63)
        Me.btnMPN.Name = "btnMPN"
        Me.btnMPN.Size = New System.Drawing.Size(316, 31)
        Me.btnMPN.TabIndex = 5
        Me.btnMPN.Text = "x / x Parts Selected"
        Me.btnMPN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMPN.UseVisualStyleBackColor = True
        '
        'txtQTY
        '
        Me.txtQTY.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQTY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQTY.Location = New System.Drawing.Point(185, 103)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(129, 26)
        Me.txtQTY.TabIndex = 3
        Me.txtQTY.Text = "1"
        '
        'txtMTF
        '
        Me.txtMTF.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMTF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMTF.Location = New System.Drawing.Point(185, 65)
        Me.txtMTF.MaxLength = 12
        Me.txtMTF.Name = "txtMTF"
        Me.txtMTF.Size = New System.Drawing.Size(284, 26)
        Me.txtMTF.TabIndex = 2
        '
        'txtJOB
        '
        Me.txtJOB.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtJOB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJOB.Location = New System.Drawing.Point(185, 28)
        Me.txtJOB.MaxLength = 11
        Me.txtJOB.Name = "txtJOB"
        Me.txtJOB.Size = New System.Drawing.Size(284, 26)
        Me.txtJOB.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(479, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Alternate Part Number:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(510, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Main Part Number:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(532, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Product Model:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Lot Quantity:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "MTF Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Job Order Number:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Maroon
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 197)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1284, 3)
        Me.Panel3.TabIndex = 0
        '
        'dgvMTF
        '
        Me.dgvMTF.AllowUserToAddRows = False
        Me.dgvMTF.AllowUserToDeleteRows = False
        Me.dgvMTF.BackgroundColor = System.Drawing.Color.White
        Me.dgvMTF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMTF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMTF.Location = New System.Drawing.Point(0, 245)
        Me.dgvMTF.Name = "dgvMTF"
        Me.dgvMTF.ReadOnly = True
        Me.dgvMTF.Size = New System.Drawing.Size(1284, 731)
        Me.dgvMTF.TabIndex = 9
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.Image = Global.CG_MES___MTF_Creation_Module.My.Resources.Resources.apply
        Me.btnSubmit.Location = New System.Drawing.Point(997, 37)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(238, 85)
        Me.btnSubmit.TabIndex = 7
        Me.btnSubmit.Text = "Create New MTF"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Image = Global.CG_MES___MTF_Creation_Module.My.Resources.Resources.refresh
        Me.btnRefresh.Location = New System.Drawing.Point(6, 148)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(1248, 31)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 976)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1284, 29)
        Me.Panel1.TabIndex = 7
        '
        'PanelBarTop
        '
        Me.PanelBarTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.PanelBarTop.BackgroundImage = CType(resources.GetObject("PanelBarTop.BackgroundImage"), System.Drawing.Image)
        Me.PanelBarTop.Controls.Add(Me.btnExit)
        Me.PanelBarTop.Controls.Add(Me.Label1)
        Me.PanelBarTop.Controls.Add(Me.btnMinimize)
        Me.PanelBarTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBarTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelBarTop.Name = "PanelBarTop"
        Me.PanelBarTop.Size = New System.Drawing.Size(1284, 45)
        Me.PanelBarTop.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(1253, 8)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(27, 27)
        Me.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnExit.TabIndex = 7
        Me.btnExit.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(328, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CG MES - MTF Creation Module"
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimize.Image = CType(resources.GetObject("btnMinimize.Image"), System.Drawing.Image)
        Me.btnMinimize.Location = New System.Drawing.Point(1220, 8)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(27, 27)
        Me.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnMinimize.TabIndex = 9
        Me.btnMinimize.TabStop = False
        '
        'cbxModel
        '
        Me.cbxModel.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbxModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxModel.FormattingEnabled = True
        Me.cbxModel.Location = New System.Drawing.Point(661, 27)
        Me.cbxModel.Name = "cbxModel"
        Me.cbxModel.Size = New System.Drawing.Size(316, 27)
        Me.cbxModel.TabIndex = 17
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 1005)
        Me.Controls.Add(Me.dgvMTF)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelBarTop)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CG MES - MTF Creation Module"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMTF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBarTop.ResumeLayout(False)
        Me.PanelBarTop.PerformLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelBarTop As Panel
    Friend WithEvents btnExit As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnMinimize As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvMTF As DataGridView
    Friend WithEvents btnRefresh As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtJOB As TextBox
    Friend WithEvents txtQTY As TextBox
    Friend WithEvents txtMTF As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnAPN As Button
    Friend WithEvents btnMPN As Button
    Friend WithEvents cbxModel As CenteredComboBox
End Class
