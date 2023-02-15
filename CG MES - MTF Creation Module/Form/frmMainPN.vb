Public Class frmMainPN
    Public SQL As New SQLControl
    Private Sort As String
    Private Sub frmMainPN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        Me.Show()
        txtInput.Focus()
        dgvMPN.ClearSelection()
        cbxOption.SelectedIndex = 0
        dgvMPN.FirstDisplayedScrollingRowIndex = 0

        'MBY ADD BUFFER OPTION
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

    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged
        Dim columnName As String
        columnName = If(cbxOption.Text = "Part Number", "Part Number", "Description")

        For Each row As DataGridViewRow In dgvMPN.Rows
            If txtInput.TextLength < 1 Then
                dgvMPN.ClearSelection()
                Exit For
            End If
            If row.Cells(columnName).Value.ToString().ToLower().Contains(txtInput.Text.ToLower()) Then
                dgvMPN.ClearSelection()
                row.Selected = True
                dgvMPN.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            Else
                dgvMPN.ClearSelection()
            End If
        Next
    End Sub

    Private Sub dgvMPN_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvMPN.CellValidating
        If e.ColumnIndex = 4 Then
            If dgvMPN.IsCurrentCellDirty Then
                If Not IsNumeric(e.FormattedValue) Then
                    e.Cancel = True
                    MessageBox.Show("Insert Numeric Only...", "Error!")

                    'for select the text in cell
                    dgvMPN.CurrentCell = dgvMPN(e.ColumnIndex, e.RowIndex)
                    dgvMPN.BeginEdit(True)
                    Dim textBox As TextBox = DirectCast(dgvMPN.EditingControl, TextBox)
                    textBox.SelectionStart = 0
                    textBox.SelectionLength = textBox.Text.Length
                End If
            End If
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim count As Integer
        For Each row As DataGridViewRow In dgvMPN.Rows
            If row.Cells("CheckBox").Value = CheckState.Unchecked = False Then
                count += 1
            End If
        Next

        If count > 0 Then
            frmMain.btnMPN.Text = count.ToString + " / " + dgvMPN.Rows.Count.ToString + " Parts Selected"
            frmMain.Show()
            Me.Close()
        Else
            MessageBox.Show("At least one Part Number is required to be selected.", "Part Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgvMPN.Focus()
        End If
    End Sub

    Private Sub dgvMPN_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMPN.CellEndEdit
        For Each row As DataGridViewRow In dgvMPN.Rows
            row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * frmMain.txtQTY.Text.Trim - row.Cells("Buffer").Value

            If row.Cells("Total Quantity").Value < 1 Then
                MessageBox.Show("The Total Qty cannot be zero or negative value for P/N '" + row.Cells("Part Number").Value + "'.", "Invalid Total Qty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                row.Cells("Buffer").Value = "0"
                row.Cells("Total Quantity").Value = row.Cells("Quantity Per").Value * frmMain.txtQTY.Text.Trim - row.Cells("Buffer").Value
            End If
        Next
    End Sub

    Private Sub dgvMPN_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvMPN.KeyDown
        If e.KeyCode = Keys.Space Then
            ' Get the current row
            Dim currentRow As DataGridViewRow = dgvMPN.CurrentRow

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