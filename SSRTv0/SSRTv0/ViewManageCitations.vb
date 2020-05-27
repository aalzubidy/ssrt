Public Class ViewManageCitations
    Private viewedDB As String = ""

    Private Sub tbDeleteCitationID_Click(sender As Object, e As EventArgs) Handles tbDeleteCitationID.Click
        If tbDeleteCitationID.Text = "For multiple, seperate with comma i.e 1,2,3" Then
            tbDeleteCitationID.Text = ""
        End If
    End Sub

    Private Sub tbDeleteCitationID_DoubleClick(sender As Object, e As EventArgs) Handles tbDeleteCitationID.DoubleClick
        If tbDeleteCitationID.Text = "For multiple, seperate with comma i.e 1,2,3" Then
            tbDeleteCitationID.Text = ""
        End If
    End Sub

    Private Sub btView_Click(sender As Object, e As EventArgs) Handles btView.Click
        If cbSourceSelection.Text = "Select Source to View" Then
            MessageBox.Show("It cannot be empty, please select source to view", ":l", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        sbLabel.Text = "Connecting to publications, please wait..."
        viewedDB = cbSourceSelection.SelectedItem.ToString()
        Dim mysqlaccess As New MySQLAccess()
        Dim reader
        sbLabel.Text = "Retreiving citations from publications, please wait..."
        If cbSourceSelection.SelectedItem = "All" Then
            Dim qval() As String = {LoginForm.user.getUser()}
            reader = mysqlaccess.selectMySQL("select publicationid as 'ID', type as 'Type', author as 'Author', title as 'Title', booktitle as 'Book Title', year as 'Year', doi as 'DOI', abstract as 'Abstract', queryDB as 'DB' from publication, query where publicationqueryid=queryid and queryuser=@qcuser", qval)
        ElseIf cbSourceSelection.SelectedItem = "Imported" Then
            Dim qval() As String = {LoginForm.user.getUser(), "Imported"}
            reader = mysqlaccess.selectMySQL("select publicationid as 'ID', type as 'Type', author as 'Author', title as 'Title', booktitle as 'Book Title', year as 'Year', doi as 'DOI', abstract as 'Abstract', queryDB as 'DB' from publication, query where publicationqueryid=queryid and queryuser=@queryuser and querydb=@querydb", qval)
        Else
            Dim qval() As String = {LoginForm.user.getUser(), viewedDB}
            reader = mysqlaccess.selectMySQL("select publicationid as 'ID', type as 'Type', author as 'Author', title as 'Title', booktitle as 'Book Title', year as 'Year', doi as 'DOI', abstract as 'Abstract', queryDB as 'DB' from publication, query where publicationqueryid=queryid and queryuser=@queryuser and querydb=@querydb", qval)
        End If
        Dim dataTable As New DataTable
        dataTable.Load(reader)
        dgvPublications.DataSource = dataTable
        mysqlaccess.disconnect()
        sbLabel.Text = dgvPublications.RowCount().ToString() & " Citations Retreived"
    End Sub

    Private Sub btDeleteCitation_Click(sender As Object, e As EventArgs) Handles btDeleteCitation.Click
        Dim citationsIDToDelete() As String
        Try
            ' Check if the textbox for the id is empty or not
            tbDeleteCitationID.Text = tbDeleteCitationID.Text.Trim()
            If tbDeleteCitationID.Text = "For multiple, seperate with comma i.e 1,2,3" Or String.IsNullOrEmpty(tbDeleteCitationID.Text) Or String.IsNullOrWhiteSpace(tbDeleteCitationID.Text) Then
                MessageBox.Show("It cannot be empty, please insert citation ID", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            End If

            sbLabel.Text = "Connecting to publications, please wait..."

            ' Check if there are more than one ID to delete
            If tbDeleteCitationID.Text.Contains(",") Then
                citationsIDToDelete = tbDeleteCitationID.Text.Split(",")
            Else
                citationsIDToDelete = {tbDeleteCitationID.Text.Trim()}
            End If

            ' Create an object of MySQLAccess
            Dim mysqlaccess As New MySQLAccess()

            ' Loop on the items in the array to delete them
            For i = 0 To citationsIDToDelete.Length - 1
                sbLabel.Text = "Deleteing citations from publications, please wait..."
                Dim qval() As String = {citationsIDToDelete(i).ToString, LoginForm.user.getUser()}
                mysqlaccess.deleteMySQL("delete from publication where publicationID=@publicationid and publicationQueryID in (select queryid from query where queryuser=@queruser)", qval)
            Next
            sbLabel.Text = "Citations have been deleted from publications"
            MessageBox.Show("Citation(s) have been deleted successfully", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sbLabel.Text = "Refreshing publications, please wait..."
            btView.PerformClick()
        Catch ex As Exception
            MessageBox.Show("Something On my End went wrong In the delete process, let me know about it and I will fix it", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub btDeleteSelected_Click(sender As Object, e As EventArgs) Handles btDeleteSelected.Click
        Try
            ' Check if no rows have been selected
            If dgvPublications.SelectedRows.Count = 0 Then
                MessageBox.Show("No row(s) have been selected", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            Else
                Dim citationsIDToDelete() As String

                ' Loop on the selected rows and add them to the array to delete them
                Dim idValues As String = ""
                For Each r As DataGridViewRow In dgvPublications.SelectedRows
                    idValues = idValues & r.Cells(0).Value.ToString() & ","
                Next
                idValues = idValues.Substring(0, idValues.Count - 1)
                citationsIDToDelete = idValues.Split(",")

                ' Create an object of MySQLAccess
                Dim mysqlaccess As New MySQLAccess()

                ' Loop on the ids in the array and delete them
                For Each i In citationsIDToDelete
                    sbLabel.Text = "Deleteing citations from publications, please wait..."
                    Dim qval() As String = {i.ToString, LoginForm.user.getUser()}
                    mysqlaccess.deleteMySQL("delete from publication where publicationID=@publicationid and publicationQueryID in (select queryid from query where queryuser=@queryuser)", qval)
                Next
                sbLabel.Text = "Citations have been deleted from publications"
                MessageBox.Show("Citation(s) have been deleted successfully", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sbLabel.Text = "Refreshing publications, please wait..."
                btView.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show("Something On my End went wrong In the delete process, let me know about it and I will fix it", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

    End Sub
End Class