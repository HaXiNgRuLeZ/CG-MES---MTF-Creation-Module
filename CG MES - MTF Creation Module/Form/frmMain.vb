﻿Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Imports System.Net

Public Class frmMain
    Public SQL As New SQLControl

    Private ModelLoadFlag As Boolean
    Private SelectedModelID As Integer
    Public Sub New()
        ' This call is required by the designer.'
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.'
        'Form'
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
    End Sub

    Private Function SendRequest(ByVal uri As Uri, ByVal jsonDataBytes As Byte(), ByVal contentType As String, ByVal method As String) As String
        Dim str As String = ""
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim webRequest As WebRequest = webRequest.Create(uri)
            webRequest.ContentLength = CLng(jsonDataBytes.Length)
            webRequest.ContentType = contentType
            webRequest.Method = method

            Using requestStream As Stream = webRequest.GetRequestStream()
                requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                requestStream.Close()

                Using responseStream As Stream = webRequest.GetResponse().GetResponseStream()

                    Using streamReader As StreamReader = New StreamReader(responseStream)
                        str = streamReader.ReadToEnd()
                    End Using
                End Using
            End Using

            Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            Cursor.Current = Cursors.Arrow
            Dim num As Integer = CInt(MessageBox.Show("Error: " & exception.ToString()))
            ProjectData.ClearProjectError()
        End Try

        Return str
    End Function

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvMTF.DoubleBuffered(True)
        frmMainPN.dgvMPN.DoubleBuffered(True)
        SetupDGV()
        SetupDGVMPN()
        SetupDGVAPN()
        LoadDatatoDGV()
        LoadModel()

        txtJOB.Focus()
        AssignValidation(txtQTY, ValidationType.Only_Numbers)
        Me.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub SetupDGV()
        Dim dgv As DataGridView = dgvMTF

        dgv.RowHeadersVisible = False
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnCount = 5

        dgv.Columns(0).Name = "Job Order Number"
        dgv.Columns(1).Name = "MTF Number"
        dgv.Columns(2).Name = "Product Model"
        dgv.Columns(3).Name = "Date of Creation"
        dgv.Columns(4).Name = "Lot Quantity"

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoResizeColumns()

        dgv.Columns("Product Model").Width = 450
        dgv.Columns("Lot Quantity").Width = 150

        dgv.RowTemplate.Height = 30
        dgv.AllowUserToResizeRows = False

        dgv.RowsDefaultCellStyle.BackColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(218, 238, 255)

        With dgv.ColumnHeadersDefaultCellStyle
            '.BackColor = Color.Navy
            '.ForeColor = Color.White
            '.Font = New Font(dgv.Font, FontStyle.Bold)
        End With
    End Sub

    Private Sub SetupDGVMPN()
        Dim dgv As DataGridView = frmMainPN.dgvMPN

        Dim viewCheckBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        viewCheckBoxColumn.HeaderText = ""
        viewCheckBoxColumn.Name = "CheckBox"

        dgv.RowHeadersVisible = False
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnCount = 8

        dgv.Columns.Insert(0, CType(viewCheckBoxColumn, DataGridViewColumn))
        dgv.Columns(1).Name = "No."
        dgv.Columns(2).Name = "Part Number"
        dgv.Columns(3).Name = "Description"
        dgv.Columns(4).Name = "Buffer"
        dgv.Columns(5).Name = "Loose Quantity"
        dgv.Columns(6).Name = "Quantity Per"
        dgv.Columns(7).Name = "Total Quantity"
        dgv.Columns(8).Name = "Total Balance at Store"

        dgv.Columns("No.").ReadOnly = True
        dgv.Columns("Part Number").ReadOnly = True
        dgv.Columns("Description").ReadOnly = True
        dgv.Columns("Loose Quantity").ReadOnly = True
        dgv.Columns("Quantity Per").ReadOnly = True
        dgv.Columns("Total Quantity").ReadOnly = True
        dgv.Columns("Total Balance at Store").ReadOnly = True

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoResizeColumns()

        dgv.Columns("CheckBox").Width = 30
        dgv.Columns("No.").Width = 30
        dgv.Columns("Part Number").Width = 150
        dgv.Columns("Description").Width = 315
        dgv.Columns("Buffer").Width = 50
        dgv.Columns("Loose Quantity").Width = 70
        dgv.Columns("Quantity Per").Width = 60
        dgv.Columns("Total Quantity").Width = 70
        dgv.Columns("Total Balance at Store").Width = 80

        dgv.RowTemplate.Height = 30
        dgv.AllowUserToResizeRows = False

        dgv.RowsDefaultCellStyle.BackColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(218, 238, 255)

        With dgv.ColumnHeadersDefaultCellStyle
            '.BackColor = Color.Navy
            '.ForeColor = Color.White
            .Font = New Font(dgv.Font, FontStyle.Bold)
        End With
    End Sub

    Private Sub SetupDGVAPN()
        Dim dgv As DataGridView = frmAlternatePN.dgvAPN

        Dim viewCheckBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        viewCheckBoxColumn.HeaderText = ""
        viewCheckBoxColumn.Name = "CheckBox"

        dgv.RowHeadersVisible = False
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnCount = 9

        dgv.Columns.Insert(0, CType(viewCheckBoxColumn, DataGridViewColumn))
        dgv.Columns(1).Name = "No."
        dgv.Columns(2).Name = "Alternate Part Number"
        dgv.Columns(3).Name = "Main Part Number"
        dgv.Columns(4).Name = "Description"
        dgv.Columns(5).Name = "Buffer"
        dgv.Columns(6).Name = "Loose Quantity"
        dgv.Columns(7).Name = "Quantity Per"
        dgv.Columns(8).Name = "Total Quantity"
        dgv.Columns(9).Name = "Total Balance at Store"

        dgv.Columns("No.").ReadOnly = True
        dgv.Columns("Alternate Part Number").ReadOnly = True
        dgv.Columns("Main Part Number").ReadOnly = True
        dgv.Columns("Description").ReadOnly = True
        dgv.Columns("Loose Quantity").ReadOnly = True
        dgv.Columns("Quantity Per").ReadOnly = True
        dgv.Columns("Total Quantity").ReadOnly = True
        dgv.Columns("Total Balance at Store").ReadOnly = True

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoResizeColumns()

        dgv.Columns("CheckBox").Width = 30
        dgv.Columns("No.").Width = 30
        dgv.Columns("Alternate Part Number").Width = 150
        dgv.Columns("Main Part Number").Width = 150
        dgv.Columns("Description").Width = 315
        dgv.Columns("Buffer").Width = 50
        dgv.Columns("Loose Quantity").Width = 70
        dgv.Columns("Quantity Per").Width = 70
        dgv.Columns("Total Quantity").Width = 70
        dgv.Columns("Total Balance at Store").Width = 80

        dgv.RowTemplate.Height = 30
        dgv.AllowUserToResizeRows = False

        dgv.RowsDefaultCellStyle.BackColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(218, 238, 255)

        With dgv.ColumnHeadersDefaultCellStyle
            '.BackColor = Color.Navy
            '.ForeColor = Color.White
            .Font = New Font(dgv.Font, FontStyle.Bold)
        End With
    End Sub

    Private Sub LoadDatatoDGV()
        dgvMTF.Rows.Clear()

        SQL.ExecQuery("SELECT WO, Issue_id, PD_model, Crt_dt, Plan_qty " &
                      "FROM erp_wo WHERE Stts < 2 ORDER by Crt_dt, WO;")

        If SQL.HasException(True) Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        For i As Integer = 1 To SQL.DBDT.Rows.Count
            dgvMTF.Rows.Add(New Object() {SQL.DBDT.Rows(i - 1)("WO"), SQL.DBDT.Rows(i - 1)("Issue_id"),
                                          SQL.DBDT.Rows(i - 1)("PD_model"), SQL.DBDT.Rows(i - 1)("Crt_dt"),
                                          SQL.DBDT.Rows(i - 1)("Plan_qty")})
        Next
    End Sub

    Private Sub LoadModel()
        'REFRESH COMBOBOX
        cbxModel.Items.Clear()

        cbxModel.Items.Add("[SELECT MODEL]")
        cbxModel.SelectedIndex = 0

        'Query
        SQL.ExecQuery("SELECT id, module FROM bom ORDER by module;")

        If SQL.HasException(True) Then Exit Sub

        'LOOP ROW &  ADD TO COMBOBOX
        For Each r As DataRow In SQL.DBDT.Rows
            cbxModel.Items.Add(r("module").ToString)
        Next
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDatatoDGV()
    End Sub
    'Load ID via cbxModel
    Private Sub LoadModelID()
        SQL.AddParam("@modelid", cbxModel.Text.Trim)
        SQL.ExecQuery("SELECT id FROM bom WHERE module = @modelid;")

        If SQL.HasException(True) Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows
            SelectedModelID = r("id")
        Next

        LoadDatatofrmMPN()
        LoadDatatofrmAPN()
    End Sub

    'Load dgv via ID
    Private Sub LoadDatatofrmMPN()
        If cbxModel.Text = "[SELECT MODEL]" Then
            btnMPN.Text = "---"
            btnMPN.Enabled = False
        Else
            frmMainPN.dgvMPN.Rows.Clear()
            SQL.AddParam("@id", "%" & SelectedModelID & "M%")
            SQL.ExecQuery("SELECT part_numbers.pn, part_numbers.pn_dsc, vw_wms_stock.balance_qty " &
                          "FROM part_numbers " &
                          "LEFT OUTER JOIN vw_wms_stock " &
                          "ON part_numbers.pn = vw_wms_stock.pn " &
                          "WHERE part_numbers.MesCode LIKE @id " &
                          "ORDER BY part_numbers.pn;")

            If SQL.HasException(True) Then Exit Sub

            If SQL.RecordCount > 0 Then
                Dim counter As Integer

                For i As Integer = 1 To SQL.RecordCount
                    Dim qty As Integer
                    Dim result As Boolean

                    If SQL.DBDT.Rows(i - 1)("balance_qty") Is DBNull.Value Then
                        qty = 0
                        result = False
                        counter += 1
                    Else
                        qty = SQL.DBDT.Rows(i - 1)("balance_qty")
                        result = True
                    End If

                    frmMainPN.dgvMPN.Rows.Add(New Object() {result, i.ToString + ".", SQL.DBDT.Rows(i - 1)("pn"),
                                                            SQL.DBDT.Rows(i - 1)("pn_dsc"), 0, 0, 1, 0, qty})
                Next
                btnMPN.Text = SQL.RecordCount - counter & " / " & SQL.RecordCount & " Parts Selected"
                btnMPN.Enabled = True
            Else
                btnMPN.Text = "---"
                btnMPN.Enabled = False
            End If
            ModelLoadFlag = True
        End If
    End Sub

    Private Sub LoadDatatofrmAPN()
        If cbxModel.Text = "[SELECT MODEL]" Then
            btnMPN.Text = "---"
            btnMPN.Enabled = False
        Else
            frmAlternatePN.dgvAPN.Rows.Clear()
            SQL.AddParam("@id", "%" & SelectedModelID & "A%")
            SQL.ExecQuery("SELECT part_numbers.pn, part_numbers.pn_dsc, part_numbers.dsc, " &
                          "vw_wms_stock.balance_qty FROM part_numbers " &
                          "LEFT OUTER JOIN vw_wms_stock " &
                          "ON part_numbers.pn = vw_wms_stock.pn " &
                          "WHERE part_numbers.MesCode LIKE @id " &
                          "ORDER BY part_numbers.pn;")

            If SQL.HasException(True) Then Exit Sub

            If SQL.RecordCount > 0 Then
                For i As Integer = 1 To SQL.RecordCount

                    frmAlternatePN.dgvAPN.Rows.Add(New Object() {0, i.ToString + "."})
                Next
                btnAPN.Text = "0" & " / " & SQL.RecordCount & " Parts Selected"
                btnAPN.Enabled = True
            Else
                btnAPN.Text = "---"
                btnAPN.Enabled = False
            End If
            ModelLoadFlag = True
        End If
    End Sub

    Private Sub cbxModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxModel.SelectedIndexChanged
        LoadModelID()
    End Sub

    Private Sub btnMPN_Click(sender As Object, e As EventArgs) Handles btnMPN.Click
        If txtQTY.Text <> 0 Then
            If ModelLoadFlag Then
                'domathhere later

            End If
            frmMainPN.Text = "Product Model: " & cbxModel.Text
            frmMainPN.dgvMPN.Refresh()
            'Me.Hide()
            frmMainPN.ShowDialog()
        Else
            MessageBox.Show("The Lot Quantity is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
        End If
    End Sub

    Private Sub btnAPN_Click(sender As Object, e As EventArgs) Handles btnAPN.Click
        If txtQTY.Text <> 0 Then
            If ModelLoadFlag Then
                'domathhere later

            End If
            frmAlternatePN.Text = "Product Model (Alternate): " & cbxModel.Text
            frmAlternatePN.dgvAPN.Refresh()
            'Me.Hide()
            frmAlternatePN.ShowDialog()
        Else
            MessageBox.Show("The Lot Quantity is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
        End If
    End Sub
End Class
