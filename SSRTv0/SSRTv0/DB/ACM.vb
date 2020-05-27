Imports System.Net
Imports System.IO
Imports System.Text
Public Class ACM
    Inherits DBManual
    ' This class is to search, parse, and download citations from ACM Digital Library.
    ' Designed and developed by Ahmed Al-Zubidy - aalzubidy@crimson.ua.edu
    ' 10/11/2016
    ' V0.0.0

    Private urlSearch, urlDownload, queryDownloadDate, userName As String
    Private startFromDisplay, endToDisplay As Integer
    Private resultsFrom, resultsTo, resultsTotal As String
    Private startFromDownload, endToDownload As Integer
    Private firstDownloadPass As Boolean = True
    Private searchContentLines(), downloadContentLines() As String
    Private downloadComplete As Boolean

    Public Sub New()
        ' Empty constructor, and call the set url right away from the object.
    End Sub

    Public Overrides Sub setUrlQuery(u As String, l As Boolean)
        ' Constructor, set query and set if it is custom or not
        urlSearch = u.Trim()
        If l = False Then
            cleanQuery()
        Else
            ' Parse the start from so you know where do you start from.
            ' Remove the &start and set it to 
            If u.Contains("&start") Then
                Dim url1, url2 As String
                url1 = u.Substring(0, u.IndexOf("&start="))
                url2 = u.Substring(u.IndexOf("&start=") + 1)
                url2 = url2.Substring(url2.IndexOf("&"))
                url1 = url1 & url2 & "&start=0"
                urlSearch = url1
            Else
                urlSearch = u & "&start=0"
            End If
        End If
        startFromDisplay = 0
        startFromDownload = 0
        firstDownloadPass = True
        downloadComplete = False
        queryDownloadDate = ""
        userName = ""

        urlDownload = urlSearch
    End Sub

    Public Overrides Sub cleanQuery()
        ' Set the query rules, change spaces, and characters.
        urlSearch = urlSearch.Replace("""", "%22").Trim
        urlSearch = urlSearch.Replace("+", "%252B").Trim
        urlSearch = urlSearch.Replace(" ", "+").Trim
        urlSearch = urlSearch.Replace("(", "%28").Trim
        urlSearch = urlSearch.Replace(")", "%29").Trim
    End Sub

    Public Overrides Sub displayResults()
        ' This method will navigate to the link that is provided by the search query
        ' It also display the results in the data grid

        ' Navigate to the url
        Dim wcSearch As WebClient = New WebClient()
            Dim searchContent As String = wcSearch.DownloadString(urlSearch)
            searchContentLines = Split(searchContent, vbLf) 'may need vbCrLf

            ' Clean the data grid from the old data
            MainForm.dgSearch.Rows.Clear()
            MainForm.dgSearch.Refresh()

            ' Catch the title, author, venue, year
            Dim title, author, venue, year As String
            Dim vFull As Integer = 0

        For Each line In searchContentLines
            If line.Contains("<a href=""citation.cfm?id=") And vFull = 0 Then
                title = line.Substring(line.IndexOf(">") + 1).Replace("</a>", "").Trim
                vFull = vFull + 1
            End If
            If line.Contains("<a href=""author_page.cfm?id=") And vFull = 1 Then
                author = line.Substring(line.IndexOf(">") + 1).Replace("</a>", "").Trim
                vFull = vFull + 1
            End If
            If line.Contains("<span class=""publicationDate"">") And vFull = 2 Then
                year = line.Substring(line.IndexOf(">") + 1).Replace("</span>", "").Trim
                vFull = vFull + 1
            End If
            If line.Contains("<span style=""padding-left") And vFull = 3 Then
                venue = line.Substring(line.IndexOf(">") + 1).Replace("</span>", "").Trim
                vFull = vFull + 1
            End If

            ' If we find name, author, year, and venue then print it  on the data grid
            If vFull = 4 Then
                MainForm.dgSearch.Rows.Add(title, author, year, venue)
                vFull = 0
            End If
        Next
    End Sub

    Public Overrides Sub downloadResults()
        ' This method is used to download all the results, until the end of the results.
        ' This method works with the link and with query
        Dim masterFileName As String = "acm-" & DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") & ".bib"
        While checkEnd(False) = False
            ' Navigate to the urlDownload webpage
            Dim wcSearch As WebClient = New WebClient()
            Dim searchContent As String = wcSearch.DownloadString(urlDownload)
            downloadContentLines = Split(searchContent, vbLf) 'may need vbCrLf

            ' Parse the downloaded page to find all the citations that needs to be downloaded
            Dim cidArray As New ArrayList
            Dim line, lineToInsert As String

            For Each line In downloadContentLines
                If line.Contains("<a href=""citation.cfm?id=") Then
                    lineToInsert = line.Substring(line.IndexOf("id=") + 3)
                    lineToInsert = lineToInsert.Substring(0, lineToInsert.IndexOf("&"))
                    cidArray.Add(lineToInsert.Trim())
                End If
            Next

            ' Download the citations from the array
            Dim wbDownload As New WebClient()
            wbDownload.Headers.Add("api_key", "3F977C1C98500F15889714859572762DE1B78D28D4059C8AFCAD9B26229E48A6")

            Dim i As String
            For Each i In cidArray
                Dim urlItem As String
                urlItem = "http://api.acm.org/dl/v1/dlnodes/" & i.ToString & "/citations?recType=bibtex"
                wbDownload.DownloadFile(urlItem, "SSRT-temp\" & i.ToString & ".bib")
                File.AppendAllText("SSRT-temp\" & masterFileName, File.ReadAllText("SSRT-temp\" & i.ToString & ".bib"), Encoding.Default) 'The text file will be created if it does not already exist
                File.AppendAllText("SSRT-temp\" & masterFileName, vbCrLf, Encoding.Default) 'The text file will be created if it does not already exist
                File.Delete("SSRT-temp\" & i.ToString & ".bib")
            Next

            nextPage(False)

        End While
        Dim cleanString() = System.IO.File.ReadAllLines("SSRT-temp\" & masterFileName)
        Dim cleanString2 As String
        For Each line In cleanString
            line = line.Trim()
            line = line & vbCrLf
            If line.Contains("},{") Then
                line = line.Replace("},{", "}," & vbCrLf & "{")
            End If
            cleanString2 = cleanString2 & line
        Next
        System.IO.File.WriteAllText("SSRT-temp\" & masterFileName, cleanString2)
        downloadComplete = True
        Dim bibtran As New BibTran()
        bibtran.inHouseACMImport("SSRT-temp\" & masterFileName, userName, queryDownloadDate)
        'bibtran.inHouseACMImport("SSRT-temp\" & "acm-2017-01-23-16-41-16.bib", userName, queryDownloadDate)
        MessageBox.Show("ACM Download Complete.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Overrides Function nextPage(s As Boolean) As Boolean
        ' This method will be used in the search and in the download
        ' The first thing to check if it reached the last results or not
        ' Then check if the option set to s=true which means work on the searchUrl or s=false which means work on the downloadURL

        If checkEnd(s) = False Then
            If s = True Then
                startFromDisplay = startFromDisplay + 20
                urlSearch = urlSearch.Substring(0, urlSearch.IndexOf("&start"))
                urlSearch = urlSearch & "&start=" & startFromDisplay
                Return True
            Else
                waitForRandom()
                startFromDownload = startFromDownload + 20
                urlDownload = urlDownload.Substring(0, urlDownload.IndexOf("&start"))
                urlDownload = urlDownload & "&start=" & startFromDownload
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Public Overrides Function previousPage() As Boolean
        ' This method will be used in the search
        ' Just check if it reached the first results or not

        If startFromDisplay > 0 Then
            startFromDisplay = startFromDisplay - 20
            urlSearch = urlSearch.Substring(0, urlSearch.IndexOf("&start"))
            urlSearch = urlSearch & "&start=" & startFromDisplay
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function getTotalResults() As String
        ' Return the total number of results found
        Dim searchDisplayedResults, searchTotalResults, tempLine As String
        For Each line In searchContentLines
            If line.Contains("Result ") And line.Contains("of") Then
                tempLine = line.Substring(0, line.IndexOf("of"))
                searchDisplayedResults = tempLine.Substring(tempLine.IndexOf(";") + 1).Trim.ToLower
                searchTotalResults = line.Substring(line.IndexOf("of ") + 3).Trim.ToLower
            End If
        Next
        Return searchTotalResults
    End Function

    Public Overrides Function checkEnd(s As Boolean) As Boolean
        Dim searchDisplayedResults, searchTotalResults, tempLine As String
        Dim endACM As Boolean = False
        ' If s=true, then this is done for searching and displaying results.
        If s Then
            For Each line In searchContentLines
                If line.Contains("Result ") And line.Contains("of") Then
                    tempLine = line.Substring(0, line.IndexOf("of"))
                    searchDisplayedResults = tempLine.Substring(tempLine.IndexOf(";") + 1).Trim.ToLower
                    searchTotalResults = line.Substring(line.IndexOf("of ") + 3).Trim.ToLower
                    If searchDisplayedResults.Equals(searchTotalResults) Then
                        endACM = True
                    End If
                End If
            Next
        Else
            If firstDownloadPass = True Then
                endACM = False
                firstDownloadPass = False
            Else
                ' If s=false, then this is done for downloading the results.
                For Each line In downloadContentLines
                    If line.Contains("Result ") And line.Contains("of") Then
                        tempLine = line.Substring(0, line.IndexOf("of"))
                        searchDisplayedResults = tempLine.Substring(tempLine.IndexOf(";") + 1).Trim.ToLower
                        searchTotalResults = line.Substring(line.IndexOf("of ") + 3).Trim.ToLower
                        If searchDisplayedResults.Equals(searchTotalResults) Then
                            endACM = True
                        End If
                    End If
                Next
            End If
        End If
        Return endACM
    End Function

    Public Overrides Function getUrlDownload() As String
        ' This method return the UrlDownload, this will be used for pausing the download process.
        Return urlDownload
    End Function

    Public Overrides Function DownloadCompleteStatus() As Boolean
        Return downloadComplete
    End Function

    Public Overrides Sub setQueryDBInfo(ByVal queryDate As String, ByVal queryUsername As String)
        queryDownloadDate = queryDate
        userName = queryUsername
    End Sub
End Class
