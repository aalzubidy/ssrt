Imports System.ComponentModel
Public Class MainForm
    Private acm As New ACM()
    Private springerLink As New SpringerLink()
    Private ieee As New IEEEX()
    Private threadACM, threadSpringerLink, threadIEEE As System.Threading.Thread

    Private Sub tbQuery_Click(sender As Object, e As EventArgs) Handles tbQuery.Click
        If tbQuery.Text = "Enter query to search..." Then
            tbQuery.Text = ""
        End If
    End Sub

    Private Sub tbQuery_DoubleClick(sender As Object, e As EventArgs) Handles tbQuery.DoubleClick
        If tbQuery.Text = "Enter query to search..." Then
            tbQuery.Text = ""
        End If
    End Sub

    Private Sub bSearch_Click(sender As Object, e As EventArgs) Handles bSearch.Click
        ' This button only for search, check for which database you need to search and create the URL for that one.

        If cbDB.Text = "Select DB" Then
            MessageBox.Show("Please choose a database to search first.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            sblSearch.Text = "Searching, please wait..."
            bDownloadAll.Enabled = True
            bNext.Enabled = True
            bPrevious.Enabled = True
            bPause.Enabled = False
            bResume.Enabled = False
            ' Check what is the selected database to create the URL for that database.
            If cbDB.SelectedItem = "ACM" Then
                Dim custom As Boolean = False
                ' Create ACM url for search.
                Dim queryUrl As String
                queryUrl = "http://dl.acm.org/results.cfm?query=" + tbQuery.Text.Trim() + "&start=0"
                ' Set the url in the ACM object.
                acm.setUrlQuery(queryUrl, custom)
                ' Call the display method to show the results in the datagrid.
                acm.displayResults()
                sblSearch.Text = "Search completed. The total number of results found is: " & acm.getTotalResults()

                Dim mysqlaccess As New MySQLAccess()
                Dim qval() As String = {queryUrl, "ACM", LoginForm.user.getUser(), "0", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), acm.getTotalResults(), tbQuery.Text.Trim()}
                mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)
            ElseIf cbDB.SelectedItem = "Springer Link" Then
                Dim custom As Boolean = False
                Dim queryUrl As String
                queryUrl = "http://link.springer.com/search?query=" + tbQuery.Text.Trim() + "&page=1"
                springerLink.setUrlQuery(queryUrl, custom)
                springerLink.displayResults()
                sblSearch.Text = "Search completed. The total number of results found is: " & springerLink.getTotalResults()

                Dim mysqlaccess As New MySQLAccess()
                Dim qval() As String = {queryUrl, "SpringerLink", LoginForm.user.getUser(), "0", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), springerLink.getTotalResults(), tbQuery.Text.Trim()}
                mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)
            ElseIf cbDB.SelectedItem = "IEEE" Then
                Dim custom As Boolean = False
                Dim queryUrl As String
                queryUrl = tbQuery.Text.Trim()
                ieee.setUrlQuery(queryUrl, custom)
                ieee.displayResults()
                sblSearch.Text = "Search completed. The total number of results found is: " & ieee.getTotalResults()

                Dim mysqlaccess As New MySQLAccess()
                Dim qval() As String = {queryUrl, "IEEEXplore", LoginForm.user.getUser(), "0", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), ieee.getTotalResults(), tbQuery.Text.Trim()}
                mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)
            ElseIf cbDB.SelectedItem = "All" Then
                sblSearch.Text = "Ready to search..."

                Dim r As DialogResult
                r = MessageBox.Show("All digital libraries will be searched and downloaded in pararell, this process will run in the background and you may continue using the tool until the download is finished.", ":)", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                If r = DialogResult.OK Then
                    Dim acmAll As New ACM()
                    Dim springerLinkAll As New SpringerLink()
                    Dim ieeeAll As New IEEEX()
                    Dim threadACMAll, threadSpringerLinkAll, threadIEEEAll As System.Threading.Thread

                    acmAll.setUrlQuery("http://dl.acm.org/results.cfm?query=" + tbQuery.Text.Trim() + "&start=0", False)
                    springerLinkAll.setUrlQuery("http://link.springer.com/search?query=" + tbQuery.Text.Trim() + "&page=1", False)
                    ieeeAll.setUrlQuery(tbQuery.Text.Trim(), False)

                    threadACMAll = New System.Threading.Thread(AddressOf acmAll.downloadResults)
                    threadSpringerLinkAll = New System.Threading.Thread(AddressOf springerLinkAll.downloadResults)
                    threadIEEEAll = New System.Threading.Thread(AddressOf ieeeAll.downloadResults)

                    threadACMAll.Start()
                    threadSpringerLinkAll.Start()
                    threadIEEEAll.Start()

                    Dim queryDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

                    Dim mysqlaccess As New MySQLAccess()
                    Dim qval() As String = {"http://dl.acm.org/results.cfm?query=" + tbQuery.Text.Trim() + "&start=0", "ACM", LoginForm.user.getUser(), "1", queryDate, "null", tbQuery.Text.Trim()}
                    mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)
                    qval = {"http://link.springer.com/search?query=" + tbQuery.Text.Trim() + "&page=1", "SpringerLink", LoginForm.user.getUser(), "1", queryDate, "null", tbQuery.Text.Trim()}
                    mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)
                    qval = {tbQuery.Text.Trim(), "IEEEXplore", LoginForm.user.getUser(), "1", queryDate, "null", tbQuery.Text.Trim()}
                    mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)

                    acmAll.setQueryDBInfo(queryDate, LoginForm.user.getUser())
                    springerLinkAll.setQueryDBInfo(queryDate, LoginForm.user.getUser())
                    ieeeAll.setQueryDBInfo(queryDate, LoginForm.user.getUser())
                Else
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        AcceptButton = bSearch
        Me.KeyPreview = True
    End Sub

    Private Sub bNext_Click(sender As Object, e As EventArgs) Handles bNext.Click
        sblSearch.Text = "Searching, please wait..."
        If cbDB.SelectedItem = "ACM" Then
            If acm.nextPage(True) Then
                acm.displayResults()
            Else
                MessageBox.Show("Reached the end of the results.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            sblSearch.Text = "Search completed. The total number of results found is: " & acm.getTotalResults()
        ElseIf cbDB.SelectedItem = "Springer Link" Then
            If springerLink.nextPage(True) Then
                springerLink.displayResults()
            Else
                MessageBox.Show("Reached the end of the results.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            sblSearch.Text = "Search completed. The total number of results found is: " & springerLink.getTotalResults
        ElseIf cbDB.SelectedItem = "IEEE" Then
            If ieee.nextPage(True) Then
                ieee.displayResults()
            Else
                MessageBox.Show("Reached the end of the results.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            sblSearch.Text = "Search completed. The total number of results found is: " & ieee.getTotalResults
        End If
    End Sub

    Private Sub bPrevious_Click(sender As Object, e As EventArgs) Handles bPrevious.Click
        sblSearch.Text = "Searching, please wait..."
        If cbDB.SelectedItem = "ACM" Then
            If acm.previousPage() Then
                acm.displayResults()
            Else
                MessageBox.Show("Reached the beginning of the results.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            sblSearch.Text = "Search completed. The total number of results found is: " & acm.getTotalResults()
        ElseIf cbDB.SelectedItem = "Springer Link" Then
            If springerLink.previousPage() Then
                springerLink.displayResults()
            Else
                MessageBox.Show("Reached the beginning of the results.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            sblSearch.Text = "Search completed. The total number of results found is: " & springerLink.getTotalResults
        ElseIf cbDB.SelectedItem = "IEEE" Then
            If ieee.previousPage() Then
                ieee.displayResults()
            Else
                MessageBox.Show("Reached the beginning of the results.", ":)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            sblSearch.Text = "Search completed. The total number of results found is: " & ieee.getTotalResults
        End If
    End Sub

    Private Sub bDownloadAll_Click(sender As Object, e As EventArgs) Handles bDownloadAll.Click
        'bDownloadAll.Enabled = False
        bPause.Enabled = True
        Dim queryDate As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        If cbDB.SelectedItem = "ACM" Then
            If threadACM IsNot Nothing Then
                If threadACM.IsAlive = True Then
                    MessageBox.Show("ACM download is in progress, please wait to finish or cancel download to start a new one.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If

            If acm.DownloadCompleteStatus() = False Then
                threadACM = New System.Threading.Thread(AddressOf acm.downloadResults)

                Dim mysqlaccess As New MySQLAccess()
                Dim qval() As String = {acm.getUrlDownload(), "ACM", LoginForm.user.getUser(), "1", querydate, acm.getTotalResults(), tbQuery.Text.Trim()}
                mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)

                threadACM.Start()
                acm.setQueryDBInfo(queryDate, LoginForm.user.getUser())
            Else
                MessageBox.Show("Download completed for this search string, search and download it again if needed.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        ElseIf cbDB.SelectedItem = "Springer Link" Then
            threadSpringerLink = New System.Threading.Thread(AddressOf springerLink.downloadResults)

            Dim mysqlaccess As New MySQLAccess()
            Dim qval() As String = {springerLink.getUrlDownload(), "SpringerLink", LoginForm.user.getUser(), "1", queryDate, springerLink.getTotalResults(), tbQuery.Text.Trim()}
            mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)

            threadSpringerLink.Start()
            springerLink.setQueryDBInfo(queryDate, LoginForm.user.getUser())
        ElseIf cbDB.SelectedItem = "IEEE" Then
            If threadIEEE IsNot Nothing Then
                If threadIEEE.IsAlive = True Then
                    MessageBox.Show("IEEE download is in progress, please wait to finish or cancel download to start a new one.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If

            If ieee.DownloadCompleteStatus() = False Then
                threadIEEE = New System.Threading.Thread(AddressOf ieee.downloadResults)

                Dim mysqlaccess As New MySQLAccess()
                Dim qval() As String = {ieee.getUrlDownload(), "IEEEXplore", LoginForm.user.getUser(), "1", queryDate, ieee.getTotalResults(), tbQuery.Text.Trim()}
                mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)


                threadIEEE.Start()
                ieee.setQueryDBInfo(queryDate, LoginForm.user.getUser())
            Else
                MessageBox.Show("IEEE download is in progress, please wait to finish or cancel download to start a new one.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub bPause_Click(sender As Object, e As EventArgs) Handles bPause.Click
        bResume.Enabled = True

        If cbDB.SelectedItem = "ACM" Then
            If threadACM.IsAlive = True Then
                threadACM.Suspend()
            ElseIf threadACM.IsAlive = False & acm.DownloadCompleteStatus() = False Then
                MessageBox.Show("ACM download is paused.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf threadACM.IsAlive = False & acm.DownloadCompleteStatus() = True Then
                MessageBox.Show("Download completed for this search string, search and download it again if needed.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf cbDB.SelectedItem = "Springer Link" Then
            threadSpringerLink.Suspend()
        ElseIf cbDB.SelectedItem = "IEEE" Then
            If threadIEEE.IsAlive = True Then
                threadIEEE.Suspend()
            ElseIf threadIEEE.IsAlive = False And ieee.DownloadCompleteStatus = False Then
                MessageBox.Show("IEEE download is paused.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf threadIEEE.IsAlive = False And ieee.DownloadCompleteStatus() = True Then
                MessageBox.Show("Download completed for this search string, search and download it again if needed.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub NewSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewSearchToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Just to make sure, do you want to logout?", ":)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            LoginForm.user.logOut()
            Me.Hide()
            LoginForm.Show()
        Else
            Return
        End If
    End Sub

    Private Sub QueryConverterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueryConverterToolStripMenuItem.Click
        QueryConverterForm.Show()
    End Sub

    Private Sub ExportToBibTexFormatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToBibTexFormatToolStripMenuItem.Click
        SFDExport.Filter = "BibTex Files (*.bib*)|*.bib"
        If SFDExport.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bibtran As New BibTran()
            If bibtran.bibExport(True, LoginForm.user.getUser().ToString(), SFDExport.FileName) Then
                MessageBox.Show("Publications exported successfully.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ExportToPlainTextFormatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToPlainTextFormatToolStripMenuItem.Click
        SFDExport.Filter = "Text Files (*.txt*)|*.txt"
        If SFDExport.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bibtran As New BibTran()
            If bibtran.bibExport(True, LoginForm.user.getUser().ToString(), SFDExport.FileName) Then
                MessageBox.Show("Publications exported successfully.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ImportCitationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportCitationsToolStripMenuItem.Click
        Me.OFDImport.Filter = "Bibtex Files (*.bib*)|*.bib"
        ' Allow the user to select multiple images.
        Me.OFDImport.Multiselect = True

        Dim dr As DialogResult = Me.OFDImport.ShowDialog()
        If (dr = System.Windows.Forms.DialogResult.OK) Then
            Dim queryDate As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

            Dim mysqlaccess As New MySQLAccess()
            Dim qval() As String = {"null", "Imported", LoginForm.user.getUser(), "1", queryDate, "null", "Imported"}
            mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)

            Dim file As String
            For Each file In OFDImport.FileNames
                Try
                    Dim bibtran As New BibTran()
                    bibtran.inHouseBibImport(file, LoginForm.user.getUser().ToString, queryDate, True, "Imported")
                Catch ex As Exception
                    MessageBox.Show("Please do not be mad, but something went wrong in the import publication dialog, let me know about it and I will fix it.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next file
            MessageBox.Show("All good, everything imported successfully.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub QueryArchiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueryArchiveToolStripMenuItem.Click
        QueryArchive.Show()
    End Sub

    Private Sub bResume_Click(sender As Object, e As EventArgs) Handles bResume.Click
        If cbDB.SelectedItem = "ACM" Then
            If threadACM.IsAlive.ToString = True And threadACM.ThreadState = 64 Then
                threadACM.Resume()
            ElseIf threadACM.IsAlive.ToString = False & acm.DownloadCompleteStatus = True Then
                MessageBox.Show("Download completed for this search string, search and download it again if needed.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf cbDB.SelectedItem = "Springer Link" Then
            threadSpringerLink.Resume()
        ElseIf cbDB.SelectedItem = "IEEE" Then
            If threadIEEE.IsAlive.ToString = True And threadIEEE.ThreadState = 64 Then
                threadIEEE.Resume()
            ElseIf threadIEEE.IsAlive.ToString = False And ieee.DownloadCompleteStatus = True Then
                MessageBox.Show("Download completed for this search string, search and download it again if needed.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub StoredCitationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoredCitationsToolStripMenuItem.Click
        ViewManageCitations.Show()
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Application.Exit()
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.Alt AndAlso (e.Control AndAlso (e.KeyCode = Keys.A))) Then
            QueryArchive.Show()
        ElseIf (e.Alt AndAlso (e.Control AndAlso (e.KeyCode = Keys.C)))
            QueryConverterForm.Show()
        ElseIf (e.Alt AndAlso (e.Control AndAlso (e.KeyCode = Keys.V)))
            ViewManageCitations.Show()
        End If
    End Sub

    Private Sub bCustomDownload_Click(sender As Object, e As EventArgs) Handles bCustomDownload.Click
        If tbCustomURL.Text = "Enter URL to Download..." Or String.IsNullOrEmpty(tbCustomURL.Text) Or String.IsNullOrWhiteSpace(tbCustomURL.Text) Or tbCustomURL.Text = "" Or tbCustomURL.Text = " " Then
            MessageBox.Show("Please enter a URL", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If cbCustomDownloadOptions.Text = "Download Options." Then
            MessageBox.Show("Please select a download option", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim queryDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        Dim url As String = tbCustomURL.Text().Trim()
        If url.Contains("dl.acm.org/") Then

            'If threadACMCustom IsNot Nothing Then
            '    If threadACM.IsAlive = True Then
            '        MessageBox.Show("ACM download is in progress, please wait to finish or cancel download to start a new one.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Return
            '    End If
            'End If

            'If acm.DownloadCompleteStatus() = False Then
            '    threadACM = New System.Threading.Thread(AddressOf acm.downloadResults)
            '    Dim sqlTran As New MySQLTran()
            '    sqlTran.connect()
            '    sqlTran.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(""" & acm.getUrlDownload().Replace("""", "\""") & """,""ACM"",""" & LoginForm.user.getUser() & """,1,""" & queryDate & """,""" & acm.getTotalResults() & """,""" & tbQuery.Text.Trim().Replace("""", "\""") & """)")
            '    sqlTran.disconnect()
            '    threadACM.Start()
            '    acm.setQueryDBInfo(queryDate, LoginForm.user.getUser())
            'Else
            '    MessageBox.Show("Download completed for this search string, search and download it again if needed.", ":l", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If

            Dim acmCustom As New ACM()
            acmCustom.setUrlQuery(url, True)

            Dim mysqlaccess As New MySQLAccess()
            Dim qval() As String = {url, "ACM", LoginForm.user.getUser(), "1", queryDate, "null", url}
            mysqlaccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)

            acmCustom.setQueryDBInfo(queryDate, LoginForm.user.getUser())

            Dim threadACMCustom = New System.Threading.Thread(AddressOf acmCustom.downloadResults)
            threadACMCustom.Start()
            MessageBox.Show("All good, your download for custom URL is running in the background I will let you know when it is done.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf url.Contains("link.springer.com/") Then
            Dim springerLinkCustom As New SpringerLink()
            springerLinkCustom.setUrlQuery(url, True)

            Dim mysqlaccess As New MySQLAccess()
            Dim qval() As String = {url, "SpringerLink", LoginForm.user.getUser(), "1", queryDate, "null", url}
            MySQLAccess.insertMySQL("insert into query(queryURL,queryDB,queryUser,queryDownload,queryDate,queryTotalResults, queryQuery) values(@queryurl,@querydb,@queryuser,@querydownload,@querydate,@querytotalresults,@queryquery)", qval)

            springerLinkCustom.setQueryDBInfo(queryDate, LoginForm.user.getUser())

            Dim threadSpringerLinkCustom = New System.Threading.Thread(AddressOf springerLinkCustom.downloadResults)
            threadSpringerLinkCustom.Start()
            MessageBox.Show("All good, your download for custom URL is running in the background I will let you know when it is done.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("This database is not suupported yet", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        If System.IO.File.Exists("ConnectionSettings.txt") = True Then
            Process.Start("ConnectionSettings.txt")
        Else
            MessageBox.Show("Sorry cannot find the settings file", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        MessageBox.Show("Sorry this feature is not implemented yet", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ReportBugsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportBugsToolStripMenuItem.Click
        MessageBox.Show("Sorry this feature is not implemented yet", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub tbCustomURL_MouseClick(sender As Object, e As MouseEventArgs) Handles tbCustomURL.MouseClick
        If tbCustomURL.Text = "Enter URL to Download..." Then
            tbCustomURL.Text = ""
        End If
    End Sub

    Private Sub tbCustomURL_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tbCustomURL.MouseDoubleClick
        If tbCustomURL.Text = "Enter URL to Download..." Then
            tbCustomURL.Text = ""
        End If
    End Sub
End Class