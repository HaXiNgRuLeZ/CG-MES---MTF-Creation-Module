Public Class frmAlternatePN
    Private Sub frmAlternatePN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Cursor.Current = Cursors.WaitCursor
        txtInput.Focus()
        dgvAPN.ClearSelection()
        cbxOption.SelectedIndex = 0
        dgvAPN.FirstDisplayedScrollingRowIndex = 0

        'MBY ADD BUFFER OPTION
    End Sub

    Private Sub frmAlternatePN_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim count As Integer
        For Each row As DataGridViewRow In dgvAPN.Rows
            If row.Cells("CheckBox").Value = CheckState.Unchecked = False Then
                count += 1
            End If
        Next

        frmMain.btnAPN.Text = count.ToString + " / " + dgvAPN.Rows.Count.ToString + " Parts Selected"
        frmMain.Show()
        Me.Close()
    End Sub

    Private Sub btnALL_Click(sender As Object, e As EventArgs) Handles btnALL.Click
        For i As Integer = 1 To dgvAPN.Rows.Count
            dgvAPN.Rows(i - 1).Cells("CheckBox").Value = CheckState.Checked
        Next
    End Sub

    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click
        For i As Integer = 1 To dgvAPN.Rows.Count
            dgvAPN.Rows(i - 1).Cells("CheckBox").Value = CheckState.Unchecked
        Next
    End Sub

    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged
        Dim columnName As String = ""
        Select Case cbxOption.Text
            Case "Alternate Part Number"
                columnName = "Alternate Part Number"
            Case "Main Part Number"
                columnName = "Main Part Number"
            Case "Description"
                columnName = "Description"
            Case Else
                ' Handle unknown value of cbxOption.Text
        End Select

        For Each row As DataGridViewRow In dgvAPN.Rows
            If txtInput.TextLength < 1 Then
                dgvAPN.ClearSelection()
                Exit For
            End If
            If row.Cells(columnName).Value.ToString().ToLower().Contains(txtInput.Text.ToLower()) Then
                dgvAPN.ClearSelection()
                row.Selected = True
                dgvAPN.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            Else
                dgvAPN.ClearSelection()
            End If
        Next
    End Sub

    Private Sub dgvAPN_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvAPN.CellValidating
        If e.ColumnIndex = 5 Then
            If dgvAPN.IsCurrentCellDirty Then
                If Not IsNumeric(e.FormattedValue) Then
                    e.Cancel = True
                    MessageBox.Show("Insert Numeric Only...", "Error!")

                    'for select the text in cell
                    dgvAPN.CurrentCell = dgvAPN(e.ColumnIndex, e.RowIndex)
                    dgvAPN.BeginEdit(True)
                    Dim textBox As TextBox = DirectCast(dgvAPN.EditingControl, TextBox)
                    textBox.SelectionStart = 0
                    textBox.SelectionLength = textBox.Text.Length
                End If
            End If
        End If
    End Sub

    Private Sub dgvAPN_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAPN.CellEndEdit
        For Each row As DataGridViewRow In dgvAPN.Rows
            row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * frmMain.txtQTY.Text.Trim - row.Cells("Buffer").Value

            If row.Cells("Total Quantity").Value < 1 Then
                MessageBox.Show("The Total Qty cannot be zero or negative value for P/N '" + row.Cells("Part Number").Value + "'.", "Invalid Total Qty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                row.Cells("Buffer").Value = "0"
                row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * frmMain.txtQTY.Text.Trim - row.Cells("Buffer").Value
            End If
        Next
    End Sub

    Private Sub dgvAPN_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAPN.KeyDown
        If e.KeyCode = Keys.Space Then
            ' Get the current row
            Dim currentRow As DataGridViewRow = dgvAPN.CurrentRow

            ' Get the value of the checkbox cell in the first column
            Dim checkboxCell As DataGridViewCheckBoxCell = currentRow.Cells(0)
            Dim isChecked As Boolean = CBool(checkboxCell.Value)

            ' Toggle the value of the checkbox cell
            checkboxCell.Value = Not isChecked

            ' Prevent the space key from being entered in the cell
            e.Handled = True
        End If
    End Sub
End Class