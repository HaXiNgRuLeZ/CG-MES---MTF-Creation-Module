<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainPN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainPN))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnNone = New System.Windows.Forms.Button()
        Me.btnALL = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvMPN = New System.Windows.Forms.DataGridView()
        Me.cbxOption = New CG_MES___MTF_Creation_Module.CenteredComboBox()
        Me.cbxBuffer = New CG_MES___MTF_Creation_Module.CenteredComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvMPN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtInput)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cbxOption)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cbxBuffer)
        Me.Panel1.Controls.Add(Me.btnImport)
        Me.Panel1.Controls.Add(Me.btnSubmit)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnNone)
        Me.Panel1.Controls.Add(Me.btnALL)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 657)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1074, 98)
        Me.Panel1.TabIndex = 0
        '
        'txtInput
        '
        Me.txtInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInput.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.Location = New System.Drawing.Point(478, 13)
        Me.txtInput.MaxLength = 11
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(218, 31)
        Me.txtInput.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(433, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 22)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Like"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(185, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 22)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Search:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(196, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 22)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Buffer:"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.Image = Global.CG_MES___MTF_Creation_Module.My.Resources.Resources.import
        Me.btnImport.Location = New System.Drawing.Point(500, 51)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(196, 35)
        Me.btnImport.TabIndex = 13
        Me.btnImport.Text = "Import Qty Per"
        Me.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.Image = CType(resources.GetObject("btnSubmit.Image"), System.Drawing.Image)
        Me.btnSubmit.Location = New System.Drawing.Point(726, 11)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(165, 76)
        Me.btnSubmit.TabIndex = 12
        Me.btnSubmit.Text = "Confirm"
        Me.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Image = Global.CG_MES___MTF_Creation_Module.My.Resources.Resources.cancel
        Me.btnCancel.Location = New System.Drawing.Point(897, 11)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(165, 76)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnNone
        '
        Me.btnNone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNone.Image = Global.CG_MES___MTF_Creation_Module.My.Resources.Resources.remove_selection
        Me.btnNone.Location = New System.Drawing.Point(12, 52)
        Me.btnNone.Name = "btnNone"
        Me.btnNone.Size = New System.Drawing.Size(165, 35)
        Me.btnNone.TabIndex = 10
        Me.btnNone.Text = "Deselect All"
        Me.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNone.UseVisualStyleBackColor = True
        '
        'btnALL
        '
        Me.btnALL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnALL.Image = Global.CG_MES___MTF_Creation_Module.My.Resources.Resources.list
        Me.btnALL.Location = New System.Drawing.Point(12, 11)
        Me.btnALL.Name = "btnALL"
        Me.btnALL.Size = New System.Drawing.Size(165, 35)
        Me.btnALL.TabIndex = 9
        Me.btnALL.Text = "Select All"
        Me.btnALL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnALL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnALL.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Maroon
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1074, 3)
        Me.Panel2.TabIndex = 0
        '
        'dgvMPN
        '
        Me.dgvMPN.AllowUserToAddRows = False
        Me.dgvMPN.AllowUserToDeleteRows = False
        Me.dgvMPN.BackgroundColor = System.Drawing.Color.White
        Me.dgvMPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMPN.Location = New System.Drawing.Point(0, 0)
        Me.dgvMPN.Name = "dgvMPN"
        Me.dgvMPN.Size = New System.Drawing.Size(1074, 657)
        Me.dgvMPN.TabIndex = 1
        '
        'cbxOption
        '
        Me.cbxOption.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbxOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbxOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxOption.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOption.FormattingEnabled = True
        Me.cbxOption.Items.AddRange(New Object() {"Part Number", "Description"})
        Me.cbxOption.Location = New System.Drawing.Point(266, 13)
        Me.cbxOption.Name = "cbxOption"
        Me.cbxOption.Size = New System.Drawing.Size(163, 32)
        Me.cbxOption.TabIndex = 21
        '
        'cbxBuffer
        '
        Me.cbxBuffer.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbxBuffer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbxBuffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBuffer.Enabled = False
        Me.cbxBuffer.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBuffer.FormattingEnabled = True
        Me.cbxBuffer.Location = New System.Drawing.Point(266, 53)
        Me.cbxBuffer.Name = "cbxBuffer"
        Me.cbxBuffer.Size = New System.Drawing.Size(228, 32)
        Me.cbxBuffer.TabIndex = 18
        '
        'frmMainPN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 755)
        Me.Controls.Add(Me.dgvMPN)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMainPN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMainPN"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvMPN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvMPN As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnALL As Button
    Friend WithEvents btnNone As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnImport As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbxOption As CenteredComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxBuffer As CenteredComboBox
    Friend WithEvents txtInput As TextBox
End Class
