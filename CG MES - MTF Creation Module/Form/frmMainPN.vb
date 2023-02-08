Public Class frmMainPN
    Public SQL As SQLControl
    Private Sort As String
    Private Sub frmMainPN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        Me.Show()
        txtInput.Focus()
        dgvMPN.ClearSelection()
        cbxOption.SelectedIndex = 0
        dgvMPN.FirstDisplayedScrollingRowIndex = 0

        'Load MTF that has buffer
        LoadcbxMTF()
    End Sub

    'This function is for BUFFER.
    Private Sub LoadcbxMTF()
        cbxBuffer.Items.Clear()

        SQL.AddParam("@modelname", frmMain.cbxModel.Text.Trim)
        SQL.ExecQuery("select sht, wo from vw_chkout_sht where dsc like '%发料全部完成，自动完结工单%' AND pd_model LIKE @modelname;")

        If SQL.HasException(True) Then Exit Sub

        If SQL.RecordCount > 0 Then
            cbxBuffer.Items.Add("[SELECT MTF]")
            For Each r As DataRow In SQL.DBDT.Rows
                cbxBuffer.Items.Add(r("sht"))
            Next
            cbxBuffer.SelectedIndex = 0

            'This features close for now bcause of the latest flowchart
            'cbxBuffer.Enabled = True
        Else
            cbxBuffer.Items.Add("---")
            cbxBuffer.SelectedIndex = 0
            cbxBuffer.Enabled = False
        End If
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

    'This function is for BUFFER.
    Private Sub LoadBuffer()
        'Dim count = dgvPN.Rows.Count
        'Dim countA = dgvMTF.Rows.Count
        'Dim num = 1
        'Dim numA = 1
        '
        'While num <= count
        '    Dim PN As String = dgvPN.Rows(num - 1).Cells("Part Number").Value
        '
        '    While numA <= countA
        '        Dim PNA As String = dgvMTF.Rows(numA - 1).Cells("pn").Value
        '        If PNA = PN Then
        '            dgvPN.Rows(num - 1).Cells("Buffer").Value = dgvMTF.Rows(numA - 1).Cells("extra_qty").Value
        '        End If
        '
        '        numA += 1
        '    End While
        '    numA = 1
        '    num += 1
        'End While
    End Sub

    Private Sub cbxBuffer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBuffer.SelectedIndexChanged
        If cbxBuffer.SelectedIndex = 0 Then
            'Return the quantity for buffer = 0
            For Each row As DataGridViewRow In dgvMPN.Rows
                row.Cells("Buffer").Value = "0"
            Next
        Else
            ' look up for MTF number for next query
            SQL.AddParam("@mtfnumber", cbxBuffer.Text.Trim)
            SQL.ExecQuery("select sht from vw_wms_chkout_sht where sht = @mtfnumber;")

            If SQL.RecordCount < 1 Then Exit Sub

            For Each r As DataRow In SQL.DBDT.Rows
                Sort = r("sht")
            Next

            'Next query or change the buffer quantity after query

            'SQL.AddParam("@mtf", "%" & Sort & "%")
            'SQL.ExecQuery("SELECT pn, chkout_sht_id, wo_plan_qty, need_qty, act_qty, extra_qty FROM vw_chkout_sum_sync where chkout_sht_id LIKE @mtf;")
            '
            'If SQL.HasException(True) Then Exit Sub
            '
            'Cursor.Current = Cursors.WaitCursor
            'dgvMTF.DataSource = SQL.DBDT
            'dgvMTF.Columns.Cast(Of DataGridViewColumn)().First(Function(c) c.DataPropertyName = "pn").HeaderText = "Part Number"
            'dgvMTF.Columns.Cast(Of DataGridViewColumn)().First(Function(c) c.DataPropertyName = "chkout_sht_id").HeaderText = "MTF Number"
            'dgvMTF.Columns.Cast(Of DataGridViewColumn)().First(Function(c) c.DataPropertyName = "wo_plan_qty").HeaderText = "LOT Quantity"
            'dgvMTF.Columns.Cast(Of DataGridViewColumn)().First(Function(c) c.DataPropertyName = "need_qty").HeaderText = "ACT Qty Request"
            'dgvMTF.Columns.Cast(Of DataGridViewColumn)().First(Function(c) c.DataPropertyName = "act_qty").HeaderText = "Issued Qty"
            'dgvMTF.Columns.Cast(Of DataGridViewColumn)().First(Function(c) c.DataPropertyName = "extra_qty").HeaderText = "Incoming Buffer"
            '
            'dgvMTF.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            'dgvMTF.AutoResizeColumns()

            LoadBuffer()
        End If
    End Sub
End Class