Public Class frmMainPN
    Private Sub frmMainPN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        txtInput.Focus()
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
End Class