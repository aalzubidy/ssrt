Public Class QueryArchive
    Private archiveTableSelected As String = ""

    Private Sub btQueryConverterArchive_Click(sender As Object, e As EventArgs) Handles btQueryConverterArchive.Click
        queryConverterArchive()
    End Sub

    Private Sub btQuerySearchandDownloadArchive_Click(sender As Object, e As EventArgs) Handles btQuerySearchandDownloadArchive.Click
        queryQueryArchive()
    End Sub

    Private Sub tbDeleteQueryID_Click(sender As Object, e As EventArgs) Handles tbDeleteQueryID.Click
        If tbDeleteQueryID.Text = "For multiple, seperate with comma i.e 1,2,3" Then
            tbDeleteQueryID.Text = ""
        End If
    End Sub

    Private Sub tbDeleteQueryIDe_DoubleClick(sender As Object, e As EventArgs) Handles tbDeleteQueryID.DoubleClick
        If tbDeleteQueryID.Text = "For multiple, seperate with comma i.e 1,2,3" Then
            tbDeleteQueryID.Text = ""
        End If
    End Sub

    Private Sub btDeleteQueryArchive_Click(sender As Object, e As EventArgs) Handles btDeleteQueryArchive.Click
        Dim queryIDToDelete() As String
        Try
            tbDeleteQueryID.Text = tbDeleteQueryID.Text.Trim()
            If tbDeleteQueryID.Text = "For multiple, seperate with comma i.e 1,2,3" Or String.IsNullOrEmpty(tbDeleteQueryID.Text) Or String.IsNullOrWhiteSpace(tbDeleteQueryID.Text) Then
                MessageBox.Show("It cannot be empty, please insert query ID", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If
            sbLabel.Text = "Connecting to archive, please wait..."
            queryIDToDelete = tbDeleteQueryID.Text.Split(",")
            Dim mysqlaccess As New MySQLAccess()
            For Each i In queryIDToDelete
                sbLabel.Text = "Deleteing queries from archive, please wait..."
                If archiveTableSelected = "QueryConverter" Then
                    Dim qval() As String = {i.ToString, LoginForm.user.getUser()}
                    mysqlaccess.deleteMySQL("delete from QueryConverter where qcId=@qcid and qcUser=@qcuser", qval)
                Else
                    Dim qval() As String = {i.ToString, LoginForm.user.getUser()}
                    mysqlaccess.deleteMySQL("delete from Query where queryId=@qcid and queryUser=@qcuser", qval)
                End If
            Next
            sbLabel.Text = "Queries have been deleted from archive"
            MessageBox.Show("Query(ies) have been deleted successfully", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sbLabel.Text = "Refreshing Archive, please wait..."
            If archiveTableSelected = "QueryConverter" Then
                queryConverterArchive()
            Else
                queryQueryArchive()
            End If
            sbLabel.Text = dgvQueryArchive.RowCount().ToString() & " Archived Queries Retrived"
        Catch ex As Exception
            MessageBox.Show("Something On my End went wrong In the delete process, let me know about it and I will fix it", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub queryConverterArchive()
        archiveTableSelected = "QueryConverter"
        sbLabel.Text = "Connecting to archive, please wait..."
        Dim mysqlaccess As New MySQLAccess()
        sbLabel.Text = "Retreiving archive, please wait..."
        Dim qval() As String = {LoginForm.user.getUser()}
        Dim reader = mysqlaccess.selectMySQL("select qcId as 'ID', qcInputQuery as 'Query', qcOutputQuery as 'Query Converted', qcDate as 'Date' from queryconverter where qcUser=@qcuser", qval)
        Dim dataTable As New DataTable
        dataTable.Load(reader)
        dgvQueryArchive.DataSource = dataTable
        mysqlaccess.disconnect()
        sbLabel.Text = dgvQueryArchive.RowCount().ToString() & " Archived Queries Retrived"
    End Sub

    Private Sub queryQueryArchive()
        archiveTableSelected = "Query"
        sbLabel.Text = "Connecting to archive, please wait..."
        Dim mysqlaccess As New MySQLAccess()
        sbLabel.Text = "Retreiving archive, please wait..."
        Dim qval() As String = {LoginForm.user.getUser()}
        Dim reader = mysqlaccess.selectMySQL("select queryid as 'ID', queryquery as 'Query', querydb as 'DB', querydownload as 'Downloaded', querydate as 'Date', querytotalresults as 'Total Results' from query where queryuser=@qcuser", qval)
        Dim dataTable As New DataTable
        dataTable.Load(reader)
        dgvQueryArchive.DataSource = dataTable
        mysqlaccess.disconnect()
        sbLabel.Text = dgvQueryArchive.RowCount().ToString() & " Archived Queries Retrived"
    End Sub

    Private Sub btDeleteSelected_Click(sender As Object, e As EventArgs) Handles btDeleteSelected.Click
        Try
            If dgvQueryArchive.SelectedRows.Count = 0 Then
                MessageBox.Show("No row(s) have been selected", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            Else
                Dim queryIDToDelete() As String

                Dim idValues As String = ""
                For Each r As DataGridViewRow In dgvQueryArchive.SelectedRows
                    idValues = idValues & r.Cells(0).Value.ToString() & ","
                Next
                idValues = idValues.Substring(0, idValues.Count - 1)
                queryIDToDelete = idValues.Split(",")
                Dim mysqlaccess As New MySQLAccess()
                For Each i In queryIDToDelete
                    sbLabel.Text = "Deleteing queries from archive, please wait..."
                    If archiveTableSelected = "QueryConverter" Then
                        Dim qval() As String = {i.ToString, LoginForm.user.getUser()}
                        mysqlaccess.deleteMySQL("delete from QueryConverter where qcId=@qcid and qcUser=@qcuser", qval)
                    Else
                        Dim qval() As String = {i.ToString, LoginForm.user.getUser()}
                        mysqlaccess.deleteMySQL("delete from Query where queryId=@qcid and queryUser=@qcuser", qval)
                    End If
                Next
                sbLabel.Text = "Queries have been deleted from archive"
                MessageBox.Show("Query(ies) have been deleted successfully", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sbLabel.Text = "Refreshing Archive, please wait..."
                If archiveTableSelected = "QueryConverter" Then
                    queryConverterArchive()
                Else
                    queryQueryArchive()
                End If
                sbLabel.Text = dgvQueryArchive.RowCount().ToString() & " Archived Queries Retrived"
            End If
        Catch ex As Exception
            MessageBox.Show("Something On my End went wrong In the delete process, let me know about it and I will fix it", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub
End Class