Imports System.IO
Imports Microsoft.Office.Interop
Public Class frmMainPN
    Private Sub frmMainPN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        SetupDGV()


        txtInput.Focus()
        'make it load excel file or usage
        Dim filePath As String = Application.StartupPath + "\Model Quantity Per\" + frmMain.cbxModel.Text.Trim + "\Main PN\" + frmMain.cbxModel.Text.Trim + ".xls"
        If File.Exists(filePath) Then
            LoadExcelFile(filePath)
        Else
            filePath = filePath.Replace(".xls", ".xlsx")
            If File.Exists(filePath) Then
                LoadExcelFile(filePath)
            Else
                'MessageBox.Show("Excel file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnImport.Enabled = True
            End If
        End If

    End Sub

    Private Sub SetupDGV()
        Dim dgv As DataGridView = DataGridView1

        dgv.RowHeadersVisible = False
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnCount = 3

        dgv.Columns(0).Name = "No."
        dgv.Columns(1).Name = "Part Number"
        dgv.Columns(2).Name = "Per"

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoResizeColumns()

        dgv.AllowUserToResizeRows = False

    End Sub

    Private Sub LoadExcelFile(filePath As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim xlRange As Excel.Range

        'dgvImport.Rows.Clear()
        'dgvImport.Refresh()

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(filePath)
        xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
        xlRange = xlWorkSheet.UsedRange

        If xlRange.Cells(1, 1).Text <> "no" Or xlRange.Cells(1, 2).Text <> "pn" Or xlRange.Cells(1, 3).Text <> "per" Then
            'MsgBox("Wrong Template!", MsgBoxStyle.Critical)
            btnImport.Enabled = True
            Exit Sub
        End If

        If xlRange.Rows.Count < 2 Then
            'MessageBox.Show("This file contains no data.", "Import Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnImport.Enabled = True
            Exit Sub
        End If

        Dim newRow As DataGridViewRow
        For Each xlRow In xlRange.Rows
            newRow = New DataGridViewRow
            For Each xlCell In xlRow.Cells
                newRow.Cells.Add(New DataGridViewTextBoxCell With {.Value = xlCell.Value})
            Next
            DataGridView1.Rows.Add(newRow)
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub btnALL_Click(sender As Object, e As EventArgs) Handles btnALL.Click
        For i As Integer = 1 To dgvMPN.Rows.Count
            dgvMPN.Rows(i - 1).Cells("CheckBox").Value = CheckState.Checked
        Next
    End Sub

    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click
        For i As Integer = 1 To dgvMPN.Rows.Count
            dgvMPN.Rows(i - 1).Cells("CheckBox").Value = CheckState.Unchecked
        Next
    End Sub

    Private Sub frmMainPN_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMain.Show()
    End Sub
End Class