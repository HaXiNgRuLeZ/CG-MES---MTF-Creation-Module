Public Class frmMainPN
    Private Sub frmMainPN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        Me.Show()
        txtInput.Focus()
        dgvMPN.ClearSelection()
        cbxOption.SelectedIndex = 0
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
End Class