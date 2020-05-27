Imports MySql.Data.MySqlClient
Imports System.IO
Public Class BibTran

    ' This class is to put Bibtex transactions in it so I do not write them again everywhere
    ' Designed and developed by Ahmed Al-Zubidy - aalzubidy@crimson.ua.edu
    ' 1/05/2017
    ' V0.0.0

    ' I am not doing work as fast as I can but that is alright, I will pick it up from this class and get things done faster.
    ' Once I build this class the rest will be very easy hopefully

    Public Sub New()
        ' Empty constructor to build an object for Bib
    End Sub

    Public Sub inHouseACMImport(ByVal fileName As String, ByVal userName As String, ByVal queryDate As String)
        ' This sub will be used in the ACM class so it imports the citations from ACM to the DB
        ' The citations of the ACM are single line, and kinda messy

        ' Get the query id(queryDate, username, and the database)
        ' Get the username

        ' Steps to parse this file as follow
        '' Open the file
        '' Read line by line
        '' For each line remove anything before the @
        '' For each line read after the @ to the next bracket that would be the type
        '' Build key value pairs arrays
        '' Finally build an insert query and send it to the database

        Dim mysqlaccess As New MySQLAccess()

        ' Get the query ID
        Dim queryID As String = ""
        Dim read As MySqlDataReader
        Dim qval() As String = {userName, "ACM", queryDate}
        read = mysqlaccess.selectMySQL("select queryID from query where queryuser=@queryuser and querydb=@querydb and querydate=@querydate", qval)
        If read.HasRows Then
            While read.Read()
                queryID = read(0).ToString.Trim()
            End While
        End If
        mysqlaccess.disconnect()

        ' Get the columns names from the publications table
        ' Store the column names in a list
        ' To make sure we are only inserting the columns that exist to the database

        Dim columnNames As New List(Of String)

        qval = {"publication"}
        read = mysqlaccess.selectMySQL("select column_name from information_schema.columns where table_name=@tablename", qval)

        If read.HasRows Then
            While read.Read()
                columnNames.Add(read(0).ToString.Trim())
            End While
        End If

        ' Read the file line by line and obtain the key value pair
        For Each line As String In File.ReadLines(fileName)
            Dim KeyValuelist As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
            Dim insertTODB As Boolean = False
            If String.IsNullOrWhiteSpace(line) = False And String.IsNullOrEmpty(line) = False Then

                If line.Contains("@") Then
                    line = line.Substring(line.IndexOf("@") + 1)
                    line = line.Trim()
                    KeyValuelist.Add(New KeyValuePair(Of String, String)("type", line.Substring(0, line.IndexOf("{")).Trim()))

                    line = line.Substring(line.IndexOf("|") + 1)
                    line = line.Trim()

                    Dim lineFirstPass As Boolean = True
                    While line.Contains("|")

                        If lineFirstPass = True Then
                            lineFirstPass = False
                        Else
                            line = line.Substring(line.IndexOf("|") + 1)
                            line = line.Trim()
                        End If

                        If line.Contains("=") Then
                            Dim key, value As String
                            key = line.Substring(0, line.IndexOf("=")).Trim()
                            line = line.Substring(line.IndexOf("=") + 1).Trim()
                            value = line.Substring(0, line.IndexOf(",|")).Trim()
                            value = value.Replace("{", "")
                            value = value.Replace("}", "")

                            Dim keyColumnFound As Boolean = False
                            Dim keyListFound As Boolean = False

                            For Each i In columnNames
                                If i.ToString.Equals(key) Then
                                    keyColumnFound = True
                                End If
                            Next

                            For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                                ' Get key.
                                Dim keyList As String = pair.Key
                                If keyList.Equals(key) Then
                                    keyListFound = True
                                End If
                            Next

                            If keyColumnFound = True And keyListFound = False Then
                                KeyValuelist.Add(New KeyValuePair(Of String, String)(key, value))
                                insertTODB = True
                            End If
                        End If

                    End While

                End If
            End If

            ' Loop on the key value pairs and build the insert query
            If insertTODB = True Then

                Dim author, title, year As String

                For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                    ' Get key.
                    Dim key As String = pair.Key
                    ' Get value.
                    Dim value As String = pair.Value

                    If key.Equals("author") Then
                        author = value
                    ElseIf key.Equals("title") Then
                        title = value
                    ElseIf key.Equals("year") Then
                        year = value
                    End If
                Next

                Dim foundPublication As Boolean = False
                qval = {author, title, year, userName}
                read = mysqlaccess.selectMySQL("select publicationid from publication where author=@author and title=@title and year=@year and publicationqueryid in (select queryid from query where queryuser=@queryuser)", qval)
                If read.HasRows Then
                    foundPublication = True
                End If
                mysqlaccess.disconnect()

                'If foundPublication = False Then

                '    Dim queryKey As String = "(publicationQueryID, "
                '    Dim queryValue As String = "(" & queryID & ", "

                '    For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                '        ' Get key.
                '        Dim key As String = pair.Key
                '        ' Get value.
                '        Dim value As String = pair.Value

                '        queryKey = queryKey & key & ", "
                '        queryValue = queryValue & """" & value & """, "

                '    Next
                '    queryKey = queryKey.Trim().Substring(0, queryKey.Length - 2)
                '    queryValue = queryValue.Trim().Substring(0, queryValue.Length - 2)
                '    queryKey = queryKey & ")"
                '    queryValue = queryValue & ")"
                '    Dim insertBibQuery As String
                '    insertBibQuery = "insert into publication" & queryKey & " values" & queryValue

                '    ' Insert the insertBibQuery to the database
                '    Dim insertBibQueryOk As Boolean
                '    mysqltran.connect()
                '    insertBibQueryOk = mysqltran.insertMySQL(insertBibQuery)

                If foundPublication = False Then

                    Dim queryKey As String = "(publicationQueryID,"
                    Dim queryKeyValue As String = "(@publicationid,"
                    Dim queryValue As String = queryID & "$"

                    For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                        ' Get key.
                        Dim pairKey As String = pair.Key
                        ' Get value.
                        Dim pairValue As String = pair.Value

                        queryKey = queryKey & pairKey & ","
                        queryKeyValue = queryKeyValue & "@" & pairKey & ","
                        queryValue = queryValue & pairValue & "$"
                    Next

                    queryKey = queryKey.Trim().Substring(0, queryKey.Length - 1)
                    queryKeyValue = queryKeyValue.Trim().Substring(0, queryKeyValue.Length - 1)
                    queryValue = queryValue.Trim().Substring(0, queryValue.Length - 1)
                    queryKey = queryKey & ")"
                    queryKeyValue = queryKeyValue & ")"
                    Dim insertBibQuery As String
                    insertBibQuery = "insert into publication" & queryKey & " values" & queryKeyValue
                    qval = queryValue.Split("$")

                    ' Insert the insertBibQuery to the database
                    Dim insertBibQueryOk As Boolean
                    insertBibQueryOk = mysqlaccess.insertMySQL(insertBibQuery, qval)
                End If
            End If
        Next

        ' Remove the publications without author
        ' Because these are just names of books of conferences not publications
        qval = {}
        mysqlaccess.insertMySQL("delete from publication where author is null", qval)
    End Sub

    Public Sub inHouseBibImport(ByVal fileName As String, ByVal userName As String, ByVal queryDate As String, ByVal queryImport As Boolean, ByVal queryDB As String)
        ' This sub will be used in the Bibtex citations from any database to the DB

        ' Okay this is not tricky at all
        ' First cleaned any bibtex file you get by changing all the brackets to double quoations
        ' Same to the ACM one get the information from the database to check the columns
        ' Same to the ACM one structure but with change in the algorithm for finding the key and value
        ' Make sure to not insert duplicates
        ' Clean the table from the null authors
        ' Good luck!!!!!

        ' Get the queryID

        Dim queryID As String = ""

        Dim read As MySqlDataReader

        Dim mysqlaccess As New MySQLAccess()

        Dim qval() As String = {userName, queryDB, queryDate}
        read = mysqlaccess.selectMySQL("select queryID from query where queryuser=@queryuser and querydb=@querydb and querydate=@querydate", qval)
        If read.HasRows Then
            While read.Read()
                queryID = read(0).ToString.Trim()
            End While
        End If
        mysqlaccess.disconnect()

        ' Get the columns names from the publications table
        ' Store the column names in a list
        ' To make sure we are only inserting the columns that exist to the database

        Dim columnNames As New List(Of String)

        qval = {"publication"}
        read = mysqlaccess.selectMySQL("select column_name from information_schema.columns where table_name=@tablename", qval)

        If read.HasRows Then
            While read.Read()
                columnNames.Add(read(0).ToString.Trim())
            End While
        End If
        mysqlaccess.disconnect()

        ' Take the file loop on it and convert every {} to "
        Dim cleanString() = System.IO.File.ReadAllLines(fileName)
        Dim cleanString2 As String
        For Each line In cleanString
            line = line.Trim()
            line = line.Replace("{", """")
            line = line.Replace("}", """")
            cleanString2 = cleanString2 & line & vbCrLf
        Next
        System.IO.File.WriteAllText(fileName, cleanString2)

        ' Now the file is ready to be open and looped into to build the keyvalue pairs

        ' Read the file line by line and obtain the key value pair

        Dim KeyValuelist As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
        Dim insertToDB As Integer = 0
        Dim key, value As String
        Dim keyValueReady As Boolean = False

        For Each line As String In File.ReadLines(fileName)
            If String.IsNullOrWhiteSpace(line) = False And String.IsNullOrEmpty(line) = False Then


                If line.Contains("@") And insertToDB = 0 Then
                    line = line.Substring(line.IndexOf("@") + 1)
                    line = line.Trim()
                    KeyValuelist.Add(New KeyValuePair(Of String, String)("type", line.Substring(0, line.IndexOf("""")).Trim()))
                    insertToDB = 1
                ElseIf line.Contains("@") And insertToDB = 2 Then
                    ' Insert to DB
                    ' Resert everything

                    ' Check if publication already in the database
                    Dim author, title, year As String

                    For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                        ' Get key.
                        Dim pairKey As String = pair.Key
                        ' Get value.
                        Dim pairValue As String = pair.Value

                        If pairKey.Equals("author") Then
                            author = pairValue
                        ElseIf pairKey.Equals("title") Then
                            title = pairValue
                        ElseIf pairKey.Equals("year") Then
                            year = pairValue
                        End If
                    Next

                    Dim foundPublication As Boolean = False
                    qval = {author, title, year, userName}
                    read = mysqlaccess.selectMySQL("select publicationid from publication where author=@author and title=@title and year=@year and publicationqueryid in (select queryid from query where queryuser=@queryuser)", qval)
                    If read.HasRows Then
                        foundPublication = True
                    End If

                    mysqlaccess.disconnect()

                    ' If the publication is not a duplicate then create the insert query and send it to the database
                    If foundPublication = False Then

                        Dim queryKey As String = "(publicationQueryID,"
                        Dim queryKeyValue As String = "(@publicationid,"
                        Dim queryValue As String = queryID & "$"

                        For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                            ' Get key.
                            Dim pairKey As String = pair.Key
                            ' Get value.
                            Dim pairValue As String = pair.Value

                            queryKey = queryKey & pairKey & ","
                            queryKeyValue = queryKeyValue & "@" & pairKey & ","
                            queryValue = queryValue & pairValue & "$"
                        Next

                        queryKey = queryKey.Trim().Substring(0, queryKey.Length - 1)
                        queryKeyValue = queryKeyValue.Trim().Substring(0, queryKeyValue.Length - 1)
                        queryValue = queryValue.Trim().Substring(0, queryValue.Length - 1)
                        queryKey = queryKey & ")"
                        queryKeyValue = queryKeyValue & ")"
                        Dim insertBibQuery As String
                        insertBibQuery = "insert into publication" & queryKey & " values" & queryKeyValue
                        qval = queryValue.Split("$")

                        ' Insert the insertBibQuery to the database
                        Dim insertBibQueryOk As Boolean
                        insertBibQueryOk = mysqlaccess.insertMySQL(insertBibQuery, qval)

                        ' Reset everything
                        KeyValuelist.Clear()
                        key = ""
                        value = ""
                        keyValueReady = False

                        ' Put the new key and value in the keyvlaue list
                        line = line.Substring(line.IndexOf("@") + 1)
                        line = line.Trim()
                        KeyValuelist.Add(New KeyValuePair(Of String, String)("type", line.Substring(0, line.IndexOf("""")).Trim()))
                        insertToDB = 1
                    Else
                        ' Reset everything
                        KeyValuelist.Clear()
                        key = ""
                        value = ""
                        keyValueReady = False

                        ' Put the new key and value in the keyvlaue list
                        line = line.Substring(line.IndexOf("@") + 1)
                        line = line.Trim()
                        KeyValuelist.Add(New KeyValuePair(Of String, String)("type", line.Substring(0, line.IndexOf("""")).Trim()))
                        insertToDB = 1
                    End If
                ElseIf line.Contains("@") = False And insertToDB > 0 Then
                    ' Get the key value pair here
                    ' Check if the line ends here or if the value on multiple lines

                    line = line.Trim()

                    If line.Contains("=") Then
                        key = line.Substring(0, line.IndexOf("=")).Trim()
                        If line.Contains(""",") Then
                            line = line.Substring(line.IndexOf("=") + 1)
                            value = line.Replace(""",", "")
                            value = line.Replace("""", "")
                            keyValueReady = True
                        Else
                            line = line.Substring(line.IndexOf("=") + 1)
                            value = line.Replace("""", "")
                            keyValueReady = False
                        End If
                    ElseIf line.Contains("=") = False And keyValueReady = False And line.Contains("@") = False And line.Contains(""",") = False Then
                        value = value & " " & line.Trim()
                    ElseIf line.Contains("=") = False And keyValueReady = False And line.Contains("@") = False And line.Contains(""",") = True Then
                        value = value & " " & line.Trim()
                        value = value.Replace(""",", "")
                        keyValueReady = True
                    End If

                    If keyValueReady = True Then
                        Dim keyColumn As Boolean = False
                        Dim keyKeyValueList As Boolean = False

                        For Each i In columnNames
                            If i.ToString.Equals(key) Then
                                keyColumn = True
                            End If
                        Next

                        For Each i As KeyValuePair(Of String, String) In KeyValuelist
                            Dim iKey As String = i.Key
                            If iKey.Equals(key) Then
                                keyKeyValueList = True
                            End If
                        Next

                        If keyColumn = True And keyKeyValueList = False Then
                            KeyValuelist.Add(New KeyValuePair(Of String, String)(key, value))
                            keyValueReady = False
                            key = ""
                            value = ""
                            insertToDB = 2
                        End If
                    End If

                End If
            End If
        Next

        ' Remove the publications without author
        ' Because these are just names of books of conferences not publications

        If insertToDB = 2 Then
            ' Insert to DB
            ' Resert everything

            ' Check if publication already in the database
            Dim author, title, year As String

            For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                ' Get key.
                Dim pairKey As String = pair.Key
                ' Get value.
                Dim pairValue As String = pair.Value

                If pairKey.Equals("author") Then
                    author = pairValue
                ElseIf pairKey.Equals("title") Then
                    title = pairValue
                ElseIf pairKey.Equals("year") Then
                    year = pairValue
                End If
            Next

            Dim foundPublication As Boolean = False
            qval = {author, title, year, userName}
            read = mysqlaccess.selectMySQL("select publicationid from publication where author=@author and title=@title and year=@year and publicationqueryid in (select queryid from query where queryuser=@queryuser)", qval)

            If read.HasRows Then
                foundPublication = True
            End If
            mysqlaccess.disconnect()

            ' If the publication is not a duplicate then create the insert query and send it to the database
            If foundPublication = False Then

                Dim queryKey As String = "(publicationQueryID,"
                Dim queryKeyValue As String = "(@publicationid,"
                Dim queryValue As String = queryID & "$"

                For Each pair As KeyValuePair(Of String, String) In KeyValuelist
                    ' Get key.
                    Dim pairKey As String = pair.Key
                    ' Get value.
                    Dim pairValue As String = pair.Value

                    queryKey = queryKey & pairKey & ","
                    queryKeyValue = queryKeyValue & "@" & pairKey & ","
                    queryValue = queryValue & pairValue & "$"
                Next

                queryKey = queryKey.Trim().Substring(0, queryKey.Length - 1)
                queryKeyValue = queryKeyValue.Trim().Substring(0, queryKeyValue.Length - 1)
                queryValue = queryValue.Trim().Substring(0, queryValue.Length - 1)
                queryKey = queryKey & ")"
                queryKeyValue = queryKeyValue & ")"
                Dim insertBibQuery As String
                insertBibQuery = "insert into publication" & queryKey & " values" & queryKeyValue
                qval = queryValue.Split("$")

                ' Insert the insertBibQuery to the database
                Dim insertBibQueryOk As Boolean
                insertBibQueryOk = mysqlaccess.insertMySQL(insertBibQuery, qval)
            End If
        End If
        qval = {}
        mysqlaccess.deleteMySQL("delete from publication where author is null", qval)
    End Sub

    Public Function bibExport(ByVal bibFormat As Boolean, ByVal userName As String, ByVal fileName As String) As Boolean
        ' This sub will export the citations from the database to bibtex file
        ' Export them all in one file

        ' To export we have two options either in Bibtex format or plain raw data in text format
        ' Get all the citations for that user
        ' Get all the publications column names

        Try
            Dim mysqlaccess As New MySQLAccess()
            Dim read As MySqlDataReader

            Dim columnNames As New List(Of String)
            Dim qval() As String = {"publication"}
            read = mysqlaccess.selectMySQL("select column_name from information_schema.columns where table_name=@tablename", qval)

            If read.HasRows Then
                While read.Read()
                    columnNames.Add(read(0).ToString.Trim())
                End While
            End If
            Dim masterFileName = fileName

            If bibFormat = True Then
                ' Export as Bibtex format
                ' All the citations in one file
                ' Put the @ for every read(0)
                ' Loop on the column names and get their values from read
                ' Write to one string, then append to it to the master file

                'Dim masterFileName As String = "AllPublications-Exported-" & DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")

                qval = {userName}
                read = mysqlaccess.selectMySQL("select * from publication where publicationqueryid in(select queryId from query where queryuser=@queryuser)", qval)
                Dim textBib As String = ""
                While read.Read()
                    textBib = textBib & vbCrLf & "@" & read(2).ToString() & "{" & read(0).ToString() & "," & vbCrLf
                    For i = 3 To columnNames.Count - 1
                        textBib = textBib & columnNames.Item(i) & "={" & read(i) & "}," & vbCrLf
                    Next
                    textBib = textBib & "}"
                End While
                mysqlaccess.disconnect()
                System.IO.File.WriteAllText(masterFileName, textBib)
                Return True
            Else
                ' Export in one text file as raw data
                'Dim masterFileName As String = "AllPublications-Exported-" & DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")

                qval = {userName}
                read = mysqlaccess.selectMySQL("select * from publication where publicationqueryid in(select queryId from query where queryuser=@queryuser)", qval)
                Dim textBib As String = ""
                While read.Read()
                    textBib = textBib & "Publication ID: " & read(0).ToString() & "---Type:" & read(2).ToString()
                    For i = 3 To columnNames.Count - 1
                        textBib = textBib & "---" & columnNames.Item(i) & "=" & read(i)
                    Next
                    textBib = textBib & vbCrLf
                End While
                mysqlaccess.disconnect()
                System.IO.File.WriteAllText(masterFileName, textBib)
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class