Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Imports OfficeOpenXml
Imports System.Net
Imports System.Text


Public Class frmMain
    'Might be useful somehow
    'txtLQ.SelectionStart = 0
    'txtLQ.SelectionLength = Len(txtLQ.Text)

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

    'Private Function SendRequest(ByVal uri As Uri, ByVal jsonDataBytes As Byte(), ByVal contentType As String, ByVal method As String) As String
    Public Function SendRequest(ByVal uri As Uri, ByVal jsonData As String, ByVal contentType As String, ByVal method As String) As String
        Dim str As String = ""
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim webClient As New WebClient()
            webClient.Headers.Add(HttpRequestHeader.ContentType, contentType)
            Dim response As String = webClient.UploadString(uri, method, jsonData)
            str = response
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.ToString())
        Finally
            Cursor.Current = Cursors.Default
        End Try

        Return str
    End Function

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor

        dgvMTF.DoubleBuffered(True)
        frmMainPN.dgvMPN.DoubleBuffered(True)
        frmAlternatePN.dgvAPN.DoubleBuffered(True)
        SetupDGV()
        SetupDGVMPN()
        SetupDGVAPN()
        LoadDatatoDGV()
        LoadModel()

        AssignValidation(txtQTY, ValidationType.Only_Numbers)

        Me.Show()
        txtJOB.Focus()
        dgvMTF.ClearSelection()
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
        dgv.Columns(6).Name = "Total Balance at Store"
        dgv.Columns(7).Name = "Quantity Per"
        dgv.Columns(8).Name = "Total Quantity"


        dgv.Columns("No.").ReadOnly = True
        dgv.Columns("Part Number").ReadOnly = True
        dgv.Columns("Description").ReadOnly = True
        dgv.Columns("Loose Quantity").ReadOnly = True
        dgv.Columns("Total Balance at Store").ReadOnly = True
        dgv.Columns("Quantity Per").ReadOnly = True
        dgv.Columns("Total Quantity").ReadOnly = True

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoResizeColumns()

        dgv.Columns("CheckBox").Width = 30
        dgv.Columns("No.").Width = 30
        dgv.Columns("Part Number").Width = 150
        dgv.Columns("Description").Width = 315
        dgv.Columns("Buffer").Width = 50
        dgv.Columns("Loose Quantity").Width = 70
        dgv.Columns("Total Balance at Store").Width = 80
        dgv.Columns("Quantity Per").Width = 60
        dgv.Columns("Total Quantity").Width = 70

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
        dgv.Columns(7).Name = "Total Balance at Store"
        dgv.Columns(8).Name = "Quantity Per"
        dgv.Columns(9).Name = "Total Quantity"

        dgv.Columns("No.").ReadOnly = True
        dgv.Columns("Alternate Part Number").ReadOnly = True
        dgv.Columns("Main Part Number").ReadOnly = True
        dgv.Columns("Description").ReadOnly = True
        dgv.Columns("Loose Quantity").ReadOnly = True
        dgv.Columns("Total Balance at Store").ReadOnly = True
        dgv.Columns("Quantity Per").ReadOnly = True
        dgv.Columns("Total Quantity").ReadOnly = True

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoResizeColumns()

        dgv.Columns("CheckBox").Width = 30
        dgv.Columns("No.").Width = 30
        dgv.Columns("Alternate Part Number").Width = 150
        dgv.Columns("Main Part Number").Width = 150
        dgv.Columns("Description").Width = 315
        dgv.Columns("Buffer").Width = 50
        dgv.Columns("Loose Quantity").Width = 70
        dgv.Columns("Total Balance at Store").Width = 80
        dgv.Columns("Quantity Per").Width = 70
        dgv.Columns("Total Quantity").Width = 70

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

    Private Sub LoadExcelFile(filePath1 As String, filePath2 As String)
        Dim excelFile1 As FileInfo = New FileInfo(filePath1)
        Dim excelFile2 As FileInfo = New FileInfo(filePath2)

        Using package As ExcelPackage = New ExcelPackage(excelFile1)
            ExcelPackage.LicenseContext = LicenseContext.Commercial
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets("Sheet1")
            Dim xlRange As ExcelRange = worksheet.Cells

            If xlRange(1, 1).Text <> "no" Or xlRange(1, 2).Text <> "pn" Or xlRange(1, 3).Text <> "per" Then
                'MessageBox.Show("Wrong template!", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmMainPN.btnImport.Enabled = True
                Exit Sub
            End If
            If worksheet.Dimension.End.Row < 2 Then
                'MessageBox.Show("This file contains no data.", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmMainPN.btnImport.Enabled = True
                Exit Sub
            End If

            For Each row In frmMainPN.dgvMPN.Rows
                Dim PN As String = row.Cells("Part Number").Value
                For i As Integer = 2 To worksheet.Dimension.End.Row
                    Dim xlPN As String = xlRange(i, 2).Value
                    If PN = xlPN Then
                        row.Cells("Quantity Per").Value = xlRange(i, 3).Value
                        Exit For
                    End If
                Next
            Next
        End Using

        Using package As ExcelPackage = New ExcelPackage(excelFile2)
            ExcelPackage.LicenseContext = LicenseContext.Commercial
            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets("Sheet1")
            Dim xlRange As ExcelRange = worksheet.Cells
            If xlRange(1, 1).Text <> "no" Or xlRange(1, 2).Text <> "pn" Or xlRange(1, 3).Text <> "per" Then
                'MessageBox.Show("Wrong template!", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmAlternatePN.btnImport.Enabled = True
                Exit Sub
            End If
            If worksheet.Dimension.End.Row < 2 Then
                'MessageBox.Show("This file contains no data.", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                frmAlternatePN.btnImport.Enabled = True
                Exit Sub
            End If
            For Each row In frmAlternatePN.dgvAPN.Rows
                Dim PN As String = row.Cells("Alternate Part Number").Value
                For i As Integer = 2 To worksheet.Dimension.End.Row
                    Dim xlPN As String = xlRange(i, 2).Value
                    If PN = xlPN Then
                        row.Cells("Quantity Per").Value = xlRange(i, 3).Value
                        Exit For
                    End If
                Next
            Next
        End Using
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
        LoadModel()

        dgvMTF.ClearSelection()
    End Sub
    'Load ID via cbxModel and Load Data to datagridview
    Private Sub LoadModelID()
        SQL.AddParam("@modelid", cbxModel.Text.Trim)
        SQL.ExecQuery("SELECT id FROM bom WHERE module = @modelid;")

        If SQL.HasException(True) Then Exit Sub

        For Each r As DataRow In SQL.DBDT.Rows
            SelectedModelID = r("id")
        Next

        LoadDatatofrmMPN()
        LoadDatatofrmAPN()

        LoadQuantityPer()
    End Sub

    'Load dgv via ID
    Private Sub LoadDatatofrmMPN()
        If cbxModel.Text = "[SELECT MODEL]" Then
            btnMPN.Text = "---"
            btnMPN.Enabled = False
        Else
            frmMainPN.dgvMPN.Rows.Clear()
            'INSERT MAIN
            SQL.AddParam("@id", "%" & SelectedModelID & "M%")
            SQL.ExecQuery("SELECT part_numbers.pn, part_numbers.pn_dsc, vw_wms_stock.balance_qty " &
                          "FROM part_numbers " &
                          "LEFT OUTER JOIN vw_wms_stock " &
                          "ON part_numbers.pn = vw_wms_stock.pn " &
                          "WHERE CONCAT(',', part_numbers.MesCode, ',') LIKE @id " &
                          "ORDER BY part_numbers.pn;")

            'SQL.AddParam("@id", "%" & SelectedModelID & "M%")
            'SQL.ExecQuery("SELECT part_numbers.pn, part_numbers.pn_dsc, vw_wms_stock.balance_qty " &
            '              "FROM part_numbers " &
            '              "LEFT OUTER JOIN vw_wms_stock " &
            '              "ON part_numbers.pn = vw_wms_stock.pn " &
            '              "WHERE part_numbers.MesCode LIKE @id " &
            '              "ORDER BY part_numbers.pn;")

            If SQL.HasException(True) Then Exit Sub

            If SQL.RecordCount > 0 Then
                'Dim counter1 As Integer
                Dim counter2 As Integer = SQL.RecordCount

                For i As Integer = 1 To SQL.RecordCount
                    Dim qty As Integer
                    Dim tQty As Integer
                    'Dim result As Boolean

                    If SQL.DBDT.Rows(i - 1)("balance_qty") Is DBNull.Value Then
                        qty = 0
                        'result = False
                        'counter1 += 1
                    Else
                        qty = SQL.DBDT.Rows(i - 1)("balance_qty")
                        'result = True
                    End If

                    frmMainPN.dgvMPN.Rows.Add(New Object() {1, i.ToString + ".", SQL.DBDT.Rows(i - 1)("pn"),
                                                            SQL.DBDT.Rows(i - 1)("pn_dsc"), 0, 0, qty, 1, 0})

                    If qty = 0 Then
                        For j As Integer = 1 To frmMainPN.dgvMPN.Columns.Count
                            frmMainPN.dgvMPN.Rows(frmMainPN.dgvMPN.Rows.Count - 1).Cells(j - 1).Style.BackColor = Color.FromArgb(255, 192, 192)
                        Next
                    End If

                    For Each row As DataGridViewRow In frmMainPN.dgvMPN.Rows
                        row.Cells(2).Style.Font = New Font(frmMainPN.dgvMPN.Font, FontStyle.Bold)
                        row.Cells(7).Style.Font = New Font(frmMainPN.dgvMPN.Font, FontStyle.Bold)
                        row.Cells(8).Style.Font = New Font(frmMainPN.dgvMPN.Font, FontStyle.Bold)
                    Next
                Next
                'INSERT LOOSE
                SQL.AddParam("@id", "%," & SelectedModelID & "M,%")
                SQL.ExecQuery("SELECT part_numbers.pn, SUM(materials.qty) as LQ " &
                              "FROM materials " &
                              "INNER JOIN part_numbers " &
                              "ON materials.pn = part_numbers.pn " &
                              "WHERE CONCAT(',', part_numbers.MesCode, ',') LIKE @id AND materials.Cell_id LIKE '%A%' " &
                              "AND materials.qty < part_numbers.MPQ " &
                              "GROUP BY part_numbers.pn")
                'SQL.AddParam("@id", "%" & SelectedModelID & "M%")
                'SQL.ExecQuery("SELECT part_numbers.pn, SUM(materials.qty) as LQ " &
                '              "FROM materials " &
                '              "INNER JOIN part_numbers " &
                '              "ON materials.pn = part_numbers.pn " &
                '              "WHERE part_numbers.MesCode LIKE @id AND materials.Cell_id LIKE '%A%' " &
                '              "AND materials.qty < part_numbers.MPQ " &
                '              "GROUP BY part_numbers.pn")

                If SQL.HasException(True) Then Exit Sub

                For Each row In frmMainPN.dgvMPN.Rows
                    Dim PN As String = row.Cells("Part Number").Value
                    For Each rowA In SQL.DBDT.Rows
                        Dim PNA As String = rowA("pn")
                        If PNA = PN Then
                            row.Cells("Loose Quantity").Value = rowA("LQ")
                            Exit For
                        End If
                    Next
                Next

                btnMPN.Text = counter2 & " / " & counter2 & " Parts Selected"
                btnMPN.Enabled = True
            Else
                btnMPN.Text = "0 / 0 Parts Selected"
                btnMPN.Enabled = False
            End If
            ModelLoadFlag = True
        End If
    End Sub

    Private Sub LoadDatatofrmAPN()
        If cbxModel.Text = "[SELECT MODEL]" Then
            btnAPN.Text = "---"
            btnAPN.Enabled = False
        Else
            frmAlternatePN.dgvAPN.Rows.Clear()
            'INSERT MAIN
            SQL.AddParam("@id", "%," & SelectedModelID & "A,%")
            SQL.ExecQuery("SELECT part_numbers.pn, part_numbers.pn_dsc, part_numbers.dsc, " &
                          "vw_wms_stock.balance_qty FROM part_numbers " &
                          "LEFT OUTER JOIN vw_wms_stock " &
                          "ON part_numbers.pn = vw_wms_stock.pn " &
                          "WHERE CONCAT(',', part_numbers.MesCode, ',') LIKE @id " &
                          "ORDER BY part_numbers.pn;")

            'SQL.AddParam("@id", "%" & SelectedModelID & "A%")
            'SQL.ExecQuery("SELECT part_numbers.pn, part_numbers.pn_dsc, part_numbers.dsc, " &
            '              "vw_wms_stock.balance_qty FROM part_numbers " &
            '              "LEFT OUTER JOIN vw_wms_stock " &
            '              "ON part_numbers.pn = vw_wms_stock.pn " &
            '              "WHERE part_numbers.MesCode LIKE @id " &
            '              "ORDER BY part_numbers.pn;")

            If SQL.HasException(True) Then Exit Sub

            If SQL.RecordCount > 0 Then
                Dim counter As Integer = SQL.RecordCount

                For i As Integer = 1 To SQL.RecordCount
                    Dim qty As Integer

                    If SQL.DBDT.Rows(i - 1)("balance_qty") Is DBNull.Value Then
                        qty = 0
                    Else
                        qty = SQL.DBDT.Rows(i - 1)("balance_qty")
                    End If

                    frmAlternatePN.dgvAPN.Rows.Add(New Object() {0, i.ToString + ".", SQL.DBDT.Rows(i - 1)("pn"),
                                                                SQL.DBDT.Rows(i - 1)("dsc"), SQL.DBDT.Rows(i - 1)("pn_dsc"),
                                                                0, 0, qty, 1, 0})

                    If qty = 0 Then
                        For j As Integer = 1 To frmAlternatePN.dgvAPN.Columns.Count
                            frmAlternatePN.dgvAPN.Rows(frmAlternatePN.dgvAPN.Rows.Count - 1).Cells(j - 1).Style.BackColor = Color.FromArgb(255, 192, 192)
                        Next
                    End If

                    For Each row As DataGridViewRow In frmAlternatePN.dgvAPN.Rows
                        row.Cells(2).Style.Font = New Font(frmAlternatePN.dgvAPN.Font, FontStyle.Bold)
                        row.Cells(8).Style.Font = New Font(frmAlternatePN.dgvAPN.Font, FontStyle.Bold)
                        row.Cells(9).Style.Font = New Font(frmAlternatePN.dgvAPN.Font, FontStyle.Bold)
                    Next
                Next
                'INSERT LOOSE
                SQL.AddParam("@id", "%," & SelectedModelID & "A,%")
                SQL.ExecQuery("SELECT part_numbers.pn, SUM(materials.qty) as LQ " &
                              "FROM materials " &
                              "INNER JOIN part_numbers " &
                              "ON materials.pn = part_numbers.pn " &
                              "WHERE CONCAT(',', part_numbers.MesCode, ',') LIKE @id AND materials.Cell_id LIKE '%A%' " &
                              "AND materials.qty < part_numbers.MPQ " &
                              "GROUP BY part_numbers.pn")

                'SQL.AddParam("@id", "%" & SelectedModelID & "A%")
                'SQL.ExecQuery("SELECT part_numbers.pn, SUM(materials.qty) as LQ " &
                '              "FROM materials " &
                '              "INNER JOIN part_numbers " &
                '              "ON materials.pn = part_numbers.pn " &
                '              "WHERE part_numbers.MesCode LIKE @id AND materials.Cell_id LIKE '%A%' " &
                '              "AND materials.qty < part_numbers.MPQ " &
                '              "GROUP BY part_numbers.pn")

                If SQL.HasException(True) Then Exit Sub

                For Each row In frmAlternatePN.dgvAPN.Rows
                    Dim PN As String = row.Cells("Alternate Part Number").Value
                    For Each rowA In SQL.DBDT.Rows
                        Dim PNA As String = rowA("pn")
                        If PNA = PN Then
                            row.Cells("Loose Quantity").Value = rowA("LQ")
                            Exit For
                        End If
                    Next
                Next

                btnAPN.Text = "0" & " / " & counter & " Parts Selected"
                btnAPN.Enabled = True
            Else
                btnAPN.Text = "0 / 0 Parts Selected"
                btnAPN.Enabled = False
            End If
            ModelLoadFlag = True
        End If
    End Sub

    Private Sub LoadQuantityPer()
        Cursor.Current = Cursors.WaitCursor
        Dim flagMPN As Boolean
        Dim flagAPN As Boolean
        'make it load excel file or usage
        Dim filePath1 As String = Application.StartupPath + "\Model Quantity Per\" + cbxModel.Text.Trim + "\Main PN\" + cbxModel.Text.Trim + ".xls"
        Dim filePath2 As String = Application.StartupPath + "\Model Quantity Per\" + cbxModel.Text.Trim + "\Alternate PN\" + cbxModel.Text.Trim + ".xls"
        'For Main PN
        If File.Exists(filePath1) Then
            flagMPN = True
        Else
            filePath1 = filePath1.Replace(".xls", ".xlsx")
            If File.Exists(filePath1) Then
                flagMPN = True
                frmMainPN.btnImport.Enabled = False
            Else
                'MessageBox.Show("Excel file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                flagMPN = False
                frmMainPN.btnImport.Enabled = True
            End If
        End If
        'For Alternate PN
        If File.Exists(filePath2) Then
            flagAPN = True
        Else
            filePath2 = filePath2.Replace(".xls", ".xlsx")
            If File.Exists(filePath2) Then
                flagAPN = True
                frmAlternatePN.btnImport.Enabled = False
            Else
                'MessageBox.Show("Excel file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                flagAPN = False
                frmAlternatePN.btnImport.Enabled = True
            End If
        End If

        If flagMPN And flagAPN Then
            LoadExcelFile(filePath1, filePath2)
        ElseIf flagMPN Then
            'MsgBox("MPN")
        ElseIf flagAPN Then
            'MsgBox("APN")
        ElseIf flagMPN = False And flagAPN = False Then
            frmMainPN.btnImport.Enabled = True
            frmAlternatePN.btnImport.Enabled = True
        End If
    End Sub

    Private Sub cbxModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxModel.SelectedIndexChanged
        LoadModelID()
    End Sub

    Private Sub btnMPN_Click(sender As Object, e As EventArgs) Handles btnMPN.Click
        If txtQTY.Text.Length < 1 Then
            MessageBox.Show("The Lot Quantity is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
            Exit Sub
        End If
        If txtQTY.Text <> 0 Then
            If ModelLoadFlag Then
                'Do Math
                For Each row As DataGridViewRow In frmMainPN.dgvMPN.Rows
                    row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * txtQTY.Text.Trim - row.Cells("Buffer").Value

                    If row.Cells("Total Balance at Store").Value < row.Cells("Total Quantity").Value Then
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192)
                    End If
                Next
            End If
            frmMainPN.Text = "Product Model: " & cbxModel.Text
            frmMainPN.dgvMPN.Refresh()
            Me.Hide()
            frmMainPN.ShowDialog()
        Else
            MessageBox.Show("The Lot Quantity is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
        End If
    End Sub

    Private Sub btnAPN_Click(sender As Object, e As EventArgs) Handles btnAPN.Click
        If txtQTY.Text.Length < 1 Then
            MessageBox.Show("The Lot Quantity is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
            Exit Sub
        End If
        If txtQTY.Text <> 0 Then
            If ModelLoadFlag Then
                'Do Math
                For Each row As DataGridViewRow In frmAlternatePN.dgvAPN.Rows
                    row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * txtQTY.Text.Trim - row.Cells("Buffer").Value

                    If row.Cells("Total Balance at Store").Value < row.Cells("Total Quantity").Value Then
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192)
                    End If
                Next
            End If
            frmAlternatePN.Text = "Product Model (Alternate): " & cbxModel.Text
            frmAlternatePN.dgvAPN.Refresh()
            Me.Hide()
            frmAlternatePN.ShowDialog()
        Else
            MessageBox.Show("The Lot Quantity is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
        End If
    End Sub

    Private Sub HighlightNewMTF()
        For Each row As DataGridViewRow In dgvMTF.Rows
            If row.Cells("Job Order Number").Value = txtJOB.Text.Trim Then
                dgvMTF.ClearSelection()
                row.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub ClearInput()
        txtJOB.Text = ""
        txtMTF.Text = ""
        txtQTY.Text = "0"
        cbxModel.SelectedIndex = 0
        btnMPN.Enabled = False
        btnAPN.Enabled = False
        btnMPN.Text = "---"
        btnAPN.Text = "---"
        txtJOB.Focus()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrWhiteSpace(txtJOB.Text.Trim) Then
            MessageBox.Show("The Job Order Number information is required.", "Job Order Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtJOB.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtMTF.Text.Trim) Then
            MessageBox.Show("The MTF information is required.", "MTF Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMTF.Focus()
        ElseIf txtQTY.Text.Trim = 0 Then
            MessageBox.Show("The Lot Quantity information is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
        ElseIf cbxModel.SelectedIndex = 0 Then
            MessageBox.Show("The Product Model selection is required.", "Product Model", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbxModel.DroppedDown = True
        ElseIf btnMPN.Enabled = False Then
            MessageBox.Show("No parts selection are required to create to job order.", "Parts Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbxModel.DroppedDown = True
        Else
            If ModelLoadFlag Then
                'Do Math
                For Each row As DataGridViewRow In frmMainPN.dgvMPN.Rows
                    row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * txtQTY.Text.Trim - row.Cells("Buffer").Value
                Next
                For Each row As DataGridViewRow In frmAlternatePN.dgvAPN.Rows
                    row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * txtQTY.Text.Trim - row.Cells("Buffer").Value
                Next
                ModelLoadFlag = False
            End If

            If MessageBox.Show("Confirm to create a new J/O with the below information ?" & vbCrLf & vbCrLf & "J/O # : " & txtJOB.Text.Trim() & vbCrLf & "Model : " + cbxModel.Text & vbCrLf & "Main Parts : " + btnMPN.Text & vbCrLf & "Alternate Parts : " + btnAPN.Text & vbCrLf & "MTF # : " + txtMTF.Text.Trim() & vbCrLf & "Lot Qty : " + txtQTY.Text, "Confirm MTF Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    Cursor.Current = Cursors.WaitCursor
                    txtResult.Text = "POSTing..."
                    Dim guid As Guid = Guid.NewGuid()

                    Dim str1 As String = txtJsonHeader.Text.Trim()
                    str1 = str1.Replace("[SESSION-ID]", guid.ToString("N"))
                    str1 = str1.Replace("[WO-NUM]", txtJOB.Text.Trim())
                    str1 = str1.Replace("[MTF-NUM]", txtMTF.Text.Trim())
                    str1 = str1.Replace("[MODEL]", cbxModel.Text.Trim())
                    str1 = str1.Replace("[PLAN-DATE]", DateTime.Today.ToString("yyyy-MM-dd"))
                    str1 = str1.Replace("[TIME-STAMP]", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.676Z"))
                    str1 = str1.Replace("[PLAN-QTY]", txtQTY.Text.Trim())

                    Dim str2 As String = ""

                    'check for alternate part
                    Dim str As String = btnAPN.Text.Trim
                    Dim strArr() As String = str.Split(" ")
                    'ERROR HERE BCAUSE ROMEO 0CD DONT HAVE ALTERNATE : it's --- NOT 0/0
                    'FIX FOR NOW
                    For Each row As DataGridViewRow In frmMainPN.dgvMPN.Rows
                        If row.Cells("CheckBox").Value = CheckState.Unchecked = False Then
                            Dim str3 As String = txtJsonPN.Text.Trim()
                            str3 = str3.Replace("[PART-NUM]", row.Cells("Part Number").Value.ToString())
                            str3 = str3.Replace("[PART-QTY]", row.Cells("Total Quantity").Value.ToString())
                            str3 = str3.Replace("[ITEM-NUM]", row.Index + 1)

                            str2 += str3
                            If row.Index <> frmMainPN.dgvMPN.Rows.Count - 1 Then
                                str2 += ","
                            End If

                            If row.Index = frmMainPN.dgvMPN.Rows.Count - 1 And strArr(0) > 0 Then
                                str2 += ","
                            End If
                        End If
                    Next
                    For Each row As DataGridViewRow In frmAlternatePN.dgvAPN.Rows
                        If row.Cells("CheckBox").Value = CheckState.Unchecked = False Then
                            Dim str5 As String = txtJsonPN.Text.Trim()
                            str5 = str5.Replace("[PART-NUM]", row.Cells("Alternate Part Number").Value.ToString())
                            str5 = str5.Replace("[PART-QTY]", row.Cells("Total Quantity").Value.ToString())
                            str5 = str5.Replace("[ITEM-NUM]", row.Index + 1)

                            str2 += str5
                            If row.Index <> frmAlternatePN.dgvAPN.Rows.Count - 1 Then
                                str2 += ","
                            End If
                        End If
                    Next

                    TextBox1.Text = str2

                    Dim str4 As String = str2 & "]}"
                    txtResult.Text = Me.SendRequest(New Uri("http://192.168.1.99:5080/api/ErpDataSync"), str1 + str4, "application/json", "POST")
                    If txtResult.Text.Contains("""message"":""OK""") Then
                        LoadDatatoDGV()
                        HighlightNewMTF()
                        MessageBox.Show("A new MTF has been successfully created!", "MTF Created", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearInput()
                    End If
                Catch ex As Exception
                    Cursor.Current = Cursors.Arrow
                    MessageBox.Show("Error: " & ex.ToString(), "MTF Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Finally
                    Cursor.Current = Cursors.Arrow
                End Try
            End If

            ModelLoadFlag = False
        End If
    End Sub

    Private Sub cbxAllowMore_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllowMoreMTF.CheckedChanged
        If cbxAllowMoreMTF.Checked Then
            txtMTF.MaxLength = 16
        Else
            txtMTF.MaxLength = 12
        End If
    End Sub

    Private Sub cbxAllowMoreJO_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllowMoreJO.CheckedChanged
        If cbxAllowMoreJO.Checked Then
            txtJOB.MaxLength = 15
        Else
            txtJOB.MaxLength = 11
        End If
    End Sub
End Class
