Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Imports OfficeOpenXml
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
        Cursor.Current = Cursors.WaitCursor

        dgvMTF.DoubleBuffered(True)
        frmMainPN.dgvMPN.DoubleBuffered(True)
        frmAlternatePN.dgvAPN.DoubleBuffered(True)
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

    Private Sub LoadExcelFile(filePath As String)
        Dim excelFile As FileInfo = New FileInfo(filePath)
        Using package As ExcelPackage = New ExcelPackage(excelFile)
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
        LoadQuantityPerMPN()

        LoadDatatofrmAPN()

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
                          "WHERE part_numbers.MesCode LIKE @id " &
                          "ORDER BY part_numbers.pn;")

            If SQL.HasException(True) Then Exit Sub

            If SQL.RecordCount > 0 Then
                'Dim counter1 As Integer
                Dim counter2 As Integer = SQL.RecordCount

                For i As Integer = 1 To SQL.RecordCount
                    Dim qty As Integer
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
                                                            SQL.DBDT.Rows(i - 1)("pn_dsc"), 0, 0, 1, 0, qty})

                    If qty = 0 Then
                        For j As Integer = 1 To frmMainPN.dgvMPN.Columns.Count
                            frmMainPN.dgvMPN.Rows(frmMainPN.dgvMPN.Rows.Count - 1).Cells(j - 1).Style.BackColor = Color.FromArgb(255, 192, 192)
                        Next
                    End If
                Next
                'INSERT LOOSE
                SQL.AddParam("@id", "%" & SelectedModelID & "M%")
                SQL.ExecQuery("SELECT part_numbers.pn, SUM(materials.qty) as LQ " &
                              "FROM materials " &
                              "INNER JOIN part_numbers " &
                              "ON materials.pn = part_numbers.pn " &
                              "WHERE part_numbers.MesCode LIKE @id AND materials.Cell_id LIKE '%A%' " &
                              "AND materials.qty < part_numbers.MPQ " &
                              "GROUP BY part_numbers.pn")

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
                btnMPN.Text = "---"
                btnMPN.Enabled = False
            End If
            ModelLoadFlag = True
        End If
    End Sub

    Private Sub LoadQuantityPerMPN()
        Cursor.Current = Cursors.WaitCursor
        'make it load excel file or usage
        Dim filePath As String = Application.StartupPath + "\Model Quantity Per\" + cbxModel.Text.Trim + "\Main PN\" + cbxModel.Text.Trim + ".xls"
        If File.Exists(filePath) Then
            LoadExcelFile(filePath)
        Else
            filePath = filePath.Replace(".xls", ".xlsx")
            If File.Exists(filePath) Then
                LoadExcelFile(filePath)
                frmMainPN.btnImport.Enabled = False
            Else
                'MessageBox.Show("Excel file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                frmMainPN.btnImport.Enabled = True
            End If
        End If
    End Sub

    Private Sub LoadDatatofrmAPN()
        If cbxModel.Text = "[SELECT MODEL]" Then
            btnAPN.Text = "---"
            btnAPN.Enabled = False
        Else
            frmAlternatePN.dgvAPN.Rows.Clear()
            'INSERT MAIN
            SQL.AddParam("@id", "%" & SelectedModelID & "A%")
            SQL.ExecQuery("SELECT part_numbers.pn, part_numbers.pn_dsc, part_numbers.dsc, " &
                          "vw_wms_stock.balance_qty FROM part_numbers " &
                          "LEFT OUTER JOIN vw_wms_stock " &
                          "ON part_numbers.pn = vw_wms_stock.pn " &
                          "WHERE part_numbers.MesCode LIKE @id " &
                          "ORDER BY part_numbers.pn;")

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
                                                                0, 0, 1, 0, qty})

                    If qty = 0 Then
                        For j As Integer = 1 To frmAlternatePN.dgvAPN.Columns.Count
                            frmAlternatePN.dgvAPN.Rows(frmAlternatePN.dgvAPN.Rows.Count - 1).Cells(j - 1).Style.BackColor = Color.FromArgb(255, 192, 192)
                        Next
                    End If
                Next
                'INSERT LOOSE
                SQL.AddParam("@id", "%" & SelectedModelID & "A%")
                SQL.ExecQuery("SELECT part_numbers.pn, SUM(materials.qty) as LQ " &
                              "FROM materials " &
                              "INNER JOIN part_numbers " &
                              "ON materials.pn = part_numbers.pn " &
                              "WHERE part_numbers.MesCode LIKE @id AND materials.Cell_id LIKE '%A%' " &
                              "AND materials.qty < part_numbers.MPQ " &
                              "GROUP BY part_numbers.pn")

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
            Me.Hide()
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
            Me.Hide()
            frmAlternatePN.ShowDialog()
        Else
            MessageBox.Show("The Lot Quantity is required.", "Lot Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQTY.Focus()
        End If
    End Sub
End Class
