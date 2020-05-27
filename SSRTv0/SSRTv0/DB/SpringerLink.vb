Imports System.Net
Imports System.IO
Imports System.Text
Public Class SpringerLink
    Inherits DBManual
    ' This class is to search, parse, and download citations from SpringerLink Digital Library.
    ' Designed and developed by Ahmed Al-Zubidy - aalzubidy@crimson.ua.edu
    ' 10/24/2016
    ' V0.0.0

    Dim urlSearch, urlDownload, queryDownloadDate, userName As String
    Dim startFromDisplay, endToDisplay As Integer
    Dim resultsFrom, resultsTo, resultsTotal As String
    Dim startFromDownload, endToDownload As Integer
    Dim firstDownloadPass As Boolean = True
    Dim searchContentLines(), downloadContentLines() As String
    Private downloadComplete As Boolean

    Public Sub New()
        ' Empty constructor, and call the set url right away from the object.
    End Sub

    Public Overrides Sub cleanQuery()
        ' Set the query rules, change spaces, and characters.
        urlSearch = urlSearch.Replace("'", "%27").Trim
        urlSearch = urlSearch.Replace("+", "%2B").Trim
        urlSearch = urlSearch.Replace(" ", "+").Trim
        urlSearch = urlSearch.Replace("(", "%28").Trim
        urlSearch = urlSearch.Replace(")", "%29").Trim
    End Sub

    Public Overrides Sub setUrlQuery(u As String, l As Boolean)
        ' Constructor, set query and set if it is custom or not
        urlSearch = u.Trim()
        If l = False Then
            cleanQuery()
        Else
            ' Parse the start from so you know where do you start from.
            ' Remove the &start and set it to 
            If u.Contains("/page/") Then
                Dim url1, url2 As String
                url1 = u.Substring(0, u.IndexOf("/page/"))
                url2 = u.Substring(u.IndexOf("/page/") + 6)
                url2 = url2.Substring(url2.IndexOf("?"))
                url1 = url1 & url2 & "&page=1"
                urlSearch = url1
            Else
                urlSearch = u & "&page=1"
            End If
        End If
        startFromDisplay = 1
        startFromDownload = 1
        firstDownloadPass = True
        downloadComplete = False
        queryDownloadDate = ""
        userName = ""
        urlDownload = urlSearch
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
        Dim title As String = ""
        Dim author As String = ""
        Dim venue As String = ""
        Dim year As String = ""

        Dim vFull As Integer = 0

        For Each line In searchContentLines
            If line.Contains("<a class=""title""") And vFull = 0 Then
                title = line.Substring(line.IndexOf(">") + 1).Replace("</a>", "").Trim
                vFull = vFull + 1
            End If

            If line.Contains("<a href=""/search?facet-creator=") And vFull = 1 Then
                author = line.Substring(line.IndexOf(">") + 1).Replace("</a>", "").Replace("</span>", "").Trim
                vFull = vFull + 1
            End If

            If line.Contains("<a class=""publication-title""") And vFull = 1 Then
                venue = line.Substring(line.IndexOf(">") + 1).Replace("</a>", "").Trim
                vFull = vFull + 2
            End If

            If line.Contains("<a class=""publication-title""") And vFull = 2 Then
                venue = line.Substring(line.IndexOf(">") + 1).Replace("</a>", "").Trim
                vFull = vFull + 1
            End If
            If line.Contains("<span class=""year""") And vFull = 3 Then
                year = line.Substring(line.IndexOf(">") + 1).Replace("</span>", "").Trim
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
        ' This method download the results from Springer Link
        ' First, check the number of results if it is larger than 1000 or less.
        ' If it is less than 1000, download the file, loop through it and get the DOI, then download each DOI
        ' If the results are more than 1000, then do the step above, and loop through each page above 50, and parse them manually.
        ' This method works with the link and with query
        ' The API have a limit of 5000 request per day, so do not use the API

        Dim noOfPages As Integer
        Dim resultsObtained As Boolean = False
        Dim csvObtained As Boolean = False
        Dim csvParsed As Boolean = False
        Dim startFromSet As Boolean = False
        Dim masterFileName As String = "springerLink-" & DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") & ".bib"

        While checkEnd(False) = False
            ' Navigate to the download URL and check the number of results. Only one time.
            If resultsObtained = False Then
                noOfPages = getTotalPages()
                resultsObtained = True
            End If

            ' Download the CSV file to get DOI
            If csvObtained = False Then
                Dim wbDownload As New WebClient()
                Dim urlItem As String
                urlItem = urlDownload.Replace("/search?", "/search/csv?")
                wbDownload.DownloadFile(urlItem, "SSRT-temp\SpringerLinkCSV.csv")
                csvObtained = True
            End If

            ' Parse and download the DOI from the CSV file
            ' For each link call up the Bibtex for it and store
            If csvParsed = False Then
                Dim wbDownload As New WebClient()
                Dim urlItem As String
                Dim line As String
                Using reader As StreamReader = New StreamReader("SSRT-temp\SpringerLinkCSV.csv")
                    line = reader.ReadLine
                    Do While (Not line Is Nothing)
                        If line.Contains("http") Then
                            line = line.Substring(line.IndexOf(".com/") + 5)
                            line = line.Substring(line.IndexOf("/") + 1)
                            line = line.Substring(0, line.IndexOf("""")).Trim()
                            urlItem = "http://citation-needed.services.springer.com/v2/references/" & line & "?format=bibtex&flavour=citation"
                            wbDownload.DownloadFile(urlItem, "SSRT-temp\" & line.Replace("/", "-") & ".bib")
                            File.AppendAllText("SSRT-temp\" & masterFileName, File.ReadAllText("SSRT-temp\" & line.ToString.Replace("/", "-") & ".bib"), Encoding.Default) 'The text file will be created if it does not already exist
                            File.AppendAllText("SSRT-temp\" & masterFileName, vbCrLf, Encoding.Default) 'The text file will be created if it does not already exist
                            File.Delete("SSRT-temp\" & line.ToString.Replace("/", "-") & ".bib")
                        End If
                        line = reader.ReadLine()
                    Loop
                End Using
                csvParsed = True
            End If

            ' If there are more than 1000, parse the pages above 51 manually and download the DOIs
            If noOfPages > 50 And startFromSet = True Then
                ' Navigate to the urlDownload webpage
                Dim wcSearch As WebClient = New WebClient()
                Dim searchContent As String = wcSearch.DownloadString(urlDownload)
                downloadContentLines = Split(searchContent, vbLf) 'may need vbCrLf

                ' Parse the downloaded page to find all the citations that needs to be downloaded
                Dim cidArray As New ArrayList
                Dim line, lineToInsert As String

                For Each line In downloadContentLines
                    If line.Contains("<a class=""title""") Then
                        lineToInsert = line.Substring(line.IndexOf("href=""/") + 7)
                        line = line.Substring(line.IndexOf("/") + 1)
                        line = line.Substring(0, line.IndexOf("""")).Trim()
                        cidArray.Add(lineToInsert)
                    End If
                Next

                ' Download the citations from the array
                Dim wbDownload As New WebClient()

                Dim i As String
                For Each i In cidArray
                    Dim urlItem As String
                    urlItem = "http://citation-needed.services.springer.com/v2/references/" & i.ToString & "?format=bibtex&flavour=citation"
                    wbDownload.DownloadFile(urlItem, "SSRT-temp\" & i.ToString.Replace("/", "-") & ".bib")
                    File.AppendAllText("SSRT-temp\" & masterFileName, File.ReadAllText("SSRT-temp\" & i.ToString.Replace("/", "-") & ".bib"), Encoding.Default) 'The text file will be created if it does not already exist
                    File.AppendAllText("SSRT-temp\" & masterFileName, vbCrLf, Encoding.Default) 'The text file will be created if it does not already exist
                    File.Delete("SSRT-temp\" & i.ToString.Replace("/", "-") & ".bib")
                Next
                nextPage(False)
            End If

            ' If there are more than 1000 pages, then set the URL download to go to page 51
            If noOfPages > 50 And startFromSet = False Then
                urlDownload = urlDownload.Substring(0, urlDownload.IndexOf("&page"))
                urlDownload = urlDownload & "&page=51"
                'Dim wcSearch As WebClient = New WebClient()
                'Dim searchContent As String = wcSearch.DownloadString(urlDownload)
                'downloadContentLines = Split(searchContent, vbLf) 'may need vbCrLf
                startFromDownload = 51
                startFromSet = True
            ElseIf noOfPages <= 50 And startFromSet = False Then
                urlDownload = urlDownload.Substring(0, urlDownload.IndexOf("&page"))
                urlDownload = urlDownload & "&page=" & (noOfPages + 1).ToString
                'Dim wcSearch As WebClient = New WebClient()
                'Dim searchContent As String = wcSearch.DownloadString(urlDownload)
                'downloadContentLines = Split(searchContent, vbLf) 'may need vbCrLf
                startFromDownload = noOfPages + 1
                startFromSet = True
            End If

        End While
        downloadComplete = True
        File.Delete("SSRT-temp\SpringerLinkCSV.csv")
        Dim bibtran As New BibTran()
        bibtran.inHouseBibImport("SSRT-temp\" & masterFileName, userName, queryDownloadDate, False, "SpringerLink")
        MessageBox.Show("SpringerLink Download Complete.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Overrides Function nextPage(s As Boolean) As Boolean
        ' This method will be used in the search and in the download
        ' The first thing to check if it reached the last results or not
        ' Then check if the option set to s=true which means work on the searchUrl or s=false which means work on the downloadURL

        If checkEnd(s) = False Then
            If s = True Then
                startFromDisplay = startFromDisplay + 1
                urlSearch = urlSearch.Substring(0, urlSearch.IndexOf("&page"))
                urlSearch = urlSearch & "&page=" & startFromDisplay
                Return True
            Else
                startFromDownload = startFromDownload + 1
                urlDownload = urlDownload.Substring(0, urlDownload.IndexOf("&page"))
                urlDownload = urlDownload & "&page=" & startFromDownload
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
            startFromDisplay = startFromDisplay - 1
            urlSearch = urlSearch.Substring(0, urlSearch.IndexOf("&page"))
            urlSearch = urlSearch & "&page=" & startFromDisplay
            Return True
        Else
            'MsgBox("Reached the beginning of results")
            Return False
        End If
    End Function

    Public Function getTotalPages() As Integer
        ' Navigate to the download URL and check the number of results.
        Dim noOfPages As Integer = 0
        Dim noOfPagesString As String
        Dim wcSearch As WebClient = New WebClient()
        Dim searchContent As String = wcSearch.DownloadString(urlDownload)
        downloadContentLines = Split(searchContent, vbLf) 'may need vbCrLf
        For Each line In downloadContentLines
            If line.Contains("class=""number-of-pages""") Then
                noOfPagesString = line.Substring(line.IndexOf(">") + 1).Replace("</span>", "").Replace(",", "").Trim()
                noOfPages = Integer.Parse(noOfPagesString)
                Exit For
            End If
        Next
        Return noOfPages
    End Function

    Public Overrides Function checkEnd(s As Boolean) As Boolean
        ' This method to check if it reached end of results
        ' For springerlink check the pages with the url and you know when it reach it
        ' If the resutls do not have pages that means it is the end of the results

        Dim totalPages As String = ""
        Dim currentPage As String = ""
        Dim checkEndV As Boolean = False

        If s = True Then
            For Each line In searchContentLines
                If line.Contains("class=""number-of-pages""") Then
                    totalPages = line.Substring(line.IndexOf(">") + 1).Replace("</span>", "").Replace(",", "").Trim()
                End If
            Next

            currentPage = urlSearch.Substring(urlSearch.IndexOf("&page=") + 6).Trim

            If totalPages.Equals(currentPage) Then
                checkEndV = True
            End If

            If totalPages.Equals("") Then
                checkEndV = True
            End If
        Else
            If firstDownloadPass = True Then
                checkEndV = False
                firstDownloadPass = False
            Else
                For Each line In downloadContentLines
                    If line.Contains("class=""number-of-pages""") Then
                        totalPages = line.Substring(line.IndexOf(">") + 1).Replace("</span>", "").Trim()
                    End If
                Next

                currentPage = urlDownload.Substring(urlDownload.IndexOf("&page=") + 6).Trim
                If totalPages.Equals("") Or totalPages.Equals(" ") Then
                    checkEnd = True
                Else
                    If totalPages.Equals(currentPage) Or (Integer.Parse(totalPages) < Integer.Parse(currentPage)) Then
                    checkEndV = True
                End If
            End If
            If totalPages.Equals("") Then
                    checkEndV = True
                End If
            End If
        End If

        Return checkEndV
    End Function

    Public Overrides Function getTotalResults() As String
        ' Return the total number of results found
        Dim searchTotalResults As String = ""
        Dim resultLine As Boolean = False
        For Each line In searchContentLines
            If resultLine = True Then
                searchTotalResults = line.Replace("<strong>", "").Replace("</strong>", "").Trim.ToLower
                resultLine = False
            End If
            If line.Contains("number-of-search-results") Then
                resultLine = True
            End If
        Next
        Return searchTotalResults
    End Function

    Public Overrides Function getUrlDownload() As String
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
