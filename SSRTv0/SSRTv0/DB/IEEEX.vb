Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Public Class IEEEX
    Inherits DBManual
    ' This class is to search, parse, and download citations from IEEE Xplore Digital Library.
    ' Designed and developed by Ahmed Al-Zubidy - aalzubidy@crimson.ua.edu
    ' 11/15/2016
    ' V0.0.0

    Dim urlSearch, urlDownload, queryDownloadDate, userName As String
    Dim startFromDisplay, endToDisplay As Integer
    Dim resultsFrom, resultsTo, resultsTotal As String
    Dim startFromDownload, endToDownload As Integer
    Dim firstDownloadPass As Boolean = True
    Dim searchContentLines() As String
    Dim downloadContentLines() As String
    Dim cookie As String
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
        End If
        startFromDisplay = 1
        startFromDownload = 1
        firstDownloadPass = True
        downloadComplete = False
        queryDownloadDate = ""
        userName = ""
        urlDownload = urlSearch
        setCookie()
    End Sub

    Public Overrides Sub cleanQuery()
        ' Set the query rules, change spaces, and characters.
        urlSearch = urlSearch.Replace("""", ".QT.").Trim
        urlSearch = urlSearch.Replace("+", ".PLS.").Trim
        urlSearch = urlSearch.Replace("(", ".LB.").Trim
        urlSearch = urlSearch.Replace(")", ".RB.").Trim
        'urlSearch = """" & urlSearch & """"
    End Sub

    Public Overrides Sub displayResults()
        ' Navigate to the search URL posting the searchUrl in the request
        ' Retreive responses and put them in the searchContent
        ' Loop on the searchContentLines and find the articles
        ' Display the responses on the screen

        connect(True)

        ' Clean the data grid from the old data
        MainForm.dgSearch.Rows.Clear()
        MainForm.dgSearch.Refresh()

        ' Catch the title, author, venue, year
        Dim title, author, venue, year As String
        Dim vFull As Integer = 0

        For Each line In searchContentLines
            If line.Contains("""preferredName"": ") And vFull = 0 Then
                author = line.Substring(line.IndexOf(":") + 1).Replace("""", "").Replace(",", "").Trim
                vFull = vFull + 1
            End If
            If line.Contains("""publicationYear"": ") And vFull = 1 Then
                year = line.Substring(line.IndexOf(":") + 1).Replace("""", "").Replace(",", "").Trim
                vFull = vFull + 1
            End If
            If line.Contains("""title"": ") And vFull = 2 Then
                title = line.Substring(line.IndexOf(":") + 1).Replace("""", "").Replace(",", "").Trim
                vFull = vFull + 1
            End If
            If line.Contains("""publicationTitle"": ") And vFull = 3 Then
                venue = line.Substring(line.IndexOf(":") + 1).Replace("</span>", "").Trim
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
        ' Alright focus a little bit, and it is very easy
        ' First call the connect(false) to get all the page and put it in downloadContentLines()
        ' Parse the downloadContentLines() and store all the DOIs
        ' Request the connectDownload(list), and everything in it will be downloaded
        ' Call nextPage(false)
        ' Repeat until checkEnd() is true

        While checkEnd(False) = False

            connect(False)

            Dim toDownload As New ArrayList
            Dim toAdd As String = ""
            Dim recordsInfo As String = ""

            For Each line In downloadContentLines
                If line.Contains("documentLink") Then
                    toAdd = line.Substring(line.IndexOf("t/") + 2)
                    toAdd = toAdd.Replace("/", "").Trim()
                    toAdd = toAdd.Replace("""", "").Trim()
                    toAdd = toAdd.Replace(",", "").Trim()
                    toDownload.Add(toAdd.ToString)
                End If
            Next

            toAdd = ""
            For Each rec In toDownload
                toAdd = toAdd & rec.ToString & "%2C"
            Next

            If toAdd.Equals("") = False Then
                Dim toAdd2 As String = ""
                toAdd2 = toAdd.Substring(0, toAdd.Count - 3)

                connectDownload(toAdd2)
            End If

            nextPage(False)
        End While
        downloadComplete = True
        MessageBox.Show("IEEE Download Complete.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Overrides Function nextPage(s As Boolean) As Boolean
        ' This method will be used in the search and in the download
        ' The first thing to check if it reached the last results or not
        ' Then check if the option set to s=true which means work on the startFromDisplay or s=false which means work on the startFromDownload

        If checkEnd(s) = False Then
            If s = True Then
                startFromDisplay = startFromDisplay + 1
                Return True
            Else
                startFromDownload = startFromDownload + 1
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Public Overrides Function previousPage() As Boolean
        ' This method will be used in the search
        ' Just check if it reached the first results or not

        If startFromDisplay > 1 Then
            startFromDisplay = startFromDisplay - 1
            Return True
        Else
            'MsgBox("Reached the beginning of results")
            Return False
        End If

    End Function

    Public Overrides Function checkEnd(s As Boolean) As Boolean
        ' This method checks if the results reached the last page or not
        ' It works for both the search and the download
        ' Simply read the endRecord number and compare it to the total records number

        Dim totalPages As String = ""
        Dim currentPage As String = ""
        Dim checkEndV As Boolean = False
        Dim totalPagesInt, currentPageInt As Integer

        If s = True Then
            For Each line In searchContentLines
                If line.Contains("totalRecords") Then
                    totalPages = line.Substring(line.IndexOf(": ") + 1).Replace(",", "").Trim()
                End If
                If line.Contains("endRecord") Then
                    currentPage = line.Substring(line.IndexOf(":") + 1).Replace(",", "").Trim()
                End If
            Next

            totalPagesInt = Integer.Parse(totalPages)
            currentPageInt = Integer.Parse(currentPage)

            If totalPagesInt <= currentPageInt Then
                checkEndV = True
            End If
        Else
            If firstDownloadPass = True Then
                checkEndV = False
                firstDownloadPass = False
            Else
                For Each line In downloadContentLines
                    If line.Contains("totalRecords") Then
                        totalPages = line.Substring(line.IndexOf(":") + 1).Replace(",", "").Trim()
                    End If
                    If line.Contains("endRecord") Then
                        currentPage = line.Substring(line.IndexOf(":") + 1).Replace(",", "").Trim()
                    End If
                Next

                totalPagesInt = Integer.Parse(totalPages)
                currentPageInt = Integer.Parse(currentPage)

                If currentPageInt >= totalPagesInt Then
                    checkEndV = True
                End If
            End If
        End If

        Return checkEndV

    End Function

    Public Overrides Function getTotalResults() As String
        Dim totalPages As String = ""
        For Each line In searchContentLines
            If line.Contains("totalRecords") Then
                totalPages = line.Substring(line.IndexOf(":") + 1).Replace(",", "").Trim()
            End If
        Next
        Return totalPages
    End Function

    Public Overrides Function getUrlDownload() As String
        Return urlDownload
    End Function

    Public Sub setCookie()
        ' To search and download results a cookie needs to be submitted with the HTTP request.
        ' Webclient navigate to the homepage 
        ' Get the headers infomration
        ' Find the cookie in the header information
        ' The cookie is valid for a day maximum before it expires.

        ' Navigate to the url
        Dim wcCookie As WebClient = New WebClient()
        Dim wcCookieContent As String = wcCookie.DownloadString("http://ieeexplore.ieee.org")

        ' Get the headers information
        Dim wcCookieHC As WebHeaderCollection = wcCookie.ResponseHeaders

        ' Parse the headers information and get the cookie
        For i = 0 To wcCookieHC.Count - 1
            If wcCookieHC.GetKey(i).Equals("Set-Cookie") Then
                cookie = wcCookieHC.Get(i)
            End If
        Next

    End Sub

    Public Sub connect(sRequest As Boolean)
        ' This method all it does is initate and HTTP request and save the response in either the searchcontent or the downloadcontent
        Dim s As Boolean = sRequest

        ' Create a request using a URL that can receive a post. 
        Dim request As WebRequest = WebRequest.Create("http://ieeexplore.ieee.org/rest/search")
        ' Set the Method property of the request to POST.
        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        Dim postData As String

        If s = True Then
            postData = "{""queryText"":""" & urlSearch & """,""pageNumber"":""" & startFromDisplay & """}"
        Else
            postData = "{""queryText"":""" & urlDownload & """,""pageNumber"":""" & startFromDownload & """,""rowsPerPage"":""100""}"
        End If

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/json"
        request.Headers.Add("Cookie:" & cookie)
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()
        ' Get the response.
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.
        'searchContentLines.Add((CType(response, HttpWebResponse).StatusDescription))
        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        Dim responseFS As Object
        'searchContentLines = Split(responseFS, ":[{")
        responseFS = JsonConvert.DeserializeObject(responseFromServer)

        If s = True Then
            searchContentLines = Split(JsonConvert.SerializeObject(responseFS, Formatting.Indented), vbCrLf)
        Else
            downloadContentLines = Split(JsonConvert.SerializeObject(responseFS, Formatting.Indented), vbCrLf)
        End If

        ' Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
    End Sub

    Public Sub connectDownload(records As String)
        ' This method is to initiate an HTTP request to download the records

        Dim recordsInfo As String = records

        ' Create a request using a URL that can receive a post. 
        Dim request As WebRequest = WebRequest.Create("http://ieeexplore.ieee.org/xpl/downloadCitations")
        ' Set the Method property of the request to POST.
        request.Method = "POST"
        ' Create POST data and convert it to a byte array.
        Dim postData As String = "recordIds=" & recordsInfo & "&download-format=download-bibtex&citations-format=citation-abstract"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"
        request.Headers.Add("Cookie:" & cookie)
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()
        ' Get the response.
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.
        'RichTextBox1.AppendText(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        'RichTextBox1.AppendText(responseFromServer)
        Dim responseFile As String = responseFromServer
        responseFile = responseFile.Replace("<br>", "")
        Dim fileName As String = "SSRT-temp\ieee-" & DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") & ".bib"
        IO.File.AppendAllText(fileName, responseFile)
        ' Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
        Dim cleanString() = System.IO.File.ReadAllLines(fileName)
        Dim cleanString2 As String
        For Each line In cleanString
            line = line.Trim()
            line = line & vbCrLf
            If line.Contains("@") Then
                line = line.Replace("@", vbCrLf & "@")
            End If
            cleanString2 = cleanString2 & line
        Next
        System.IO.File.WriteAllText(fileName, cleanString2)
        Dim bibtran As New BibTran()
        bibtran.inHouseBibImport(fileName, userName, queryDownloadDate, False, "IEEEXplore")
    End Sub

    Public Overrides Function DownloadCompleteStatus() As Boolean
        Return downloadComplete
    End Function

    Public Overrides Sub setQueryDBInfo(ByVal queryDate As String, ByVal queryUsername As String)
        queryDownloadDate = queryDate
        userName = queryUsername
    End Sub
End Class