Imports System.ComponentModel
Imports System.Text.RegularExpressions
Public Class QueryConverterForm
    Private Sub query_Click(sender As Object, e As EventArgs) Handles query.Click
        If query.Text = "Enter search query..." Then
            query.Text = ""
        End If
    End Sub

    Private Sub query_DoubleClick(sender As Object, e As EventArgs) Handles query.DoubleClick
        If query.Text = "Enter search query..." Then
            query.Text = ""
        End If
    End Sub

    Private Sub optimize_Click(sender As Object, e As EventArgs) Handles optimize.Click
        If queryCheck() = False Then
            MessageBox.Show("Please fix the issues in the search string and try again", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            IEEESpringerOptimzer()
            SSDEVOptimizer()
            ACMOptimzer()
        End If

    End Sub

    Private Sub ACMOptimzer()
        Dim queryM As String = query.Text.Trim
        queryM = queryM.Replace(" AND ", " + ")
        queryM = queryM.Replace(" OR ", " | ")
        queryM = queryM.Replace(" NOT ", " - ")

        Dim queryMArray As Char() = queryM.ToCharArray

        Dim queryItemsArray As New List(Of String)

        Dim entry, optemp As String
        Dim op As String = ""
        Dim brFlag As Boolean = False

        For i = 0 To queryMArray.Length - 1

            If i = 0 And brFlag = False Then
                op = "AND "
            Else
                If queryMArray(i) = "+" And brFlag = False Then
                    op = " AND "
                ElseIf queryMArray(i) = "|" And brFlag = False Then
                    op = " OR "
                ElseIf queryMArray(i) = "-" And brFlag = False Then
                    op = " NOT "
                End If
            End If

            If queryMArray(i) = "(" Then
                brFlag = True
            End If

            If brFlag = True And queryMArray(i) <> ")" Then
                entry = entry & queryMArray(i)
            End If

            If brFlag = True And queryMArray(i) = ")" Then
                entry = entry & queryMArray(i)
                queryItemsArray.Add(op + entry)
                brFlag = False
                entry = ""
            End If

            If brFlag = False And queryMArray(i) <> "+" And queryMArray(i) <> "|" And queryMArray(i) <> "-" And queryMArray(i) <> ")" Then
                entry = entry & queryMArray(i)
                optemp = op
            End If

            If brFlag = False And (queryMArray(i) = "+" Or queryMArray(i) = "|" Or queryMArray(i) = "-") And entry <> "" And entry <> " " Then
                entry = entry
                queryItemsArray.Add(optemp + entry)
                entry = ""
            End If

        Next

        If queryMArray.Last <> ")" Then
            queryItemsArray.Add(optemp + entry)
        End If

        Dim itemsArray As String() = queryItemsArray.ToArray

        queryOutput.AppendText("ACM Digital Library:" & vbNewLine)
        perm(itemsArray, 0, itemsArray.Count - 1)

    End Sub

    Private Sub perm(ByVal a As String(), ByVal k As Integer, ByVal n As Integer)
        ''This goes to Ali Smadi
        If k = n Then
            For j = 0 To n
                queryOutput.AppendText(a(j))
            Next
            queryOutput.AppendText(vbNewLine)
        Else
            For i = k To n
                Dim t = a(k)
                a(k) = a(i)
                a(i) = t
                perm(a, k + 1, n)
                t = a(k)
                a(k) = a(i)
                a(i) = t
            Next
        End If
    End Sub

    Private Sub SSDEVOptimizer()
        Dim queryClean As String
        queryClean = query.Text.Trim()
        queryClean = queryClean.Replace("NOT", "AND NOT")
        queryClean = queryClean.Replace(""" ", "} ")
        queryClean = queryClean.Replace(""")", "})")
        Dim lastChar = queryClean.LastIndexOf("""")
        If lastChar = queryClean.Length - 1 Then
            queryClean = queryClean.Substring(0, queryClean.Length - 1) & "}"
        End If
        queryClean = queryClean.Replace("""", "{")
        queryOutput.AppendText("Scopus and Science Direct:" & vbNewLine & "TITLE-ABS-KEY(" & queryClean & ")" & vbNewLine & vbNewLine)
        queryOutput.AppendText("Engineering Village:" & vbNewLine & "(" & queryClean.Replace("AND NOT", "NOT") & " WN KY)" & vbNewLine & vbNewLine)
    End Sub

    Private Sub IEEESpringerOptimzer()
        queryOutput.AppendText("IEEE Xplore and Springer Link: " & vbNewLine)
        queryOutput.AppendText(query.Text & vbNewLine & vbNewLine)
    End Sub

    Private Function queryCheck() As Boolean
        query.Text = query.Text.Trim
        Dim queryError As Boolean = True
        If query.Text.Contains("near") Or query.Text.Contains("NEAR") Or query.Text.Contains("?") Or query.Text.Contains("AND NOT") Or query.Text.Contains("{") Or query.Text.Contains("}") Or query.Text.Contains("<") Or query.Text.Contains(">") Or query.Text.Contains("\") Then
            MessageBox.Show("Sorry, the search string contain operator or charcter that is not supported, pleaes refer to the help file for more information", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            queryError = False
        End If
        If CountWords(query.Text) > 150 Then
            MessageBox.Show("Sorry, the search string contain more than 15 string term which is limited by the digital libraries engines", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            queryError = False
        End If
        If CountCharacter(query.Text, "*") > 5 Then
            MessageBox.Show("Sorry, the digital library does not support the use of more than 5 wild cards * per search string", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            queryError = False
        End If
        If query.Text.Contains("?") Then
            MessageBox.Show("Just to let you know, the wild card ""?"" will not run on ACM Digital Library", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        If CountCharacter(query.Text, "(") <> CountCharacter(query.Text, ")") Then
            MessageBox.Show("Please check the ( and ), it looks like there is one missing!", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            queryError = False
        End If
        If query.Text = "" Or query.Text = " " Or query.Text = "Enter search query..." Then
            MessageBox.Show("Please insert a query to search", ":(", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            queryError = False
        End If
        Return queryError
    End Function

    Public Function CountWords(ByVal value As String) As Integer
        Dim collection As MatchCollection = Regex.Matches(value, "\S+")
        Return collection.Count
    End Function

    Public Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer
        Dim cnt As Integer = 0
        For Each c As Char In value
            If c = ch Then cnt += 1
        Next
        Return cnt
    End Function

    Private Sub NewQueryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewQueryToolStripMenuItem.Click
        query.Text = "Enter search query..."
        queryOutput.Text = ""
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub QueryConverterForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
    End Sub

    Private Sub SSRTOnlineDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SSRTOnlineDatabaseToolStripMenuItem.Click
        Dim mysqlaccess As New MySQLAccess()
        Dim saveQuery As Boolean
        Dim qval() As String = {query.Text.Trim(), queryOutput.Text.Trim(), LoginForm.user.getUser(), DateTime.Now.ToString("yyyy/MM/dd HH: mm : ss")}
        saveQuery = mysqlaccess.insertMySQL("insert into queryconverter(qcinputquery,qcoutputquery,qcuser,qcdate) values(@qcinput,@qcoutput,@qcuser,@qcdate)", qval)

        If saveQuery = True Then
            MessageBox.Show("Query have been saved successfully to SSRT database!", ": D", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Query was not saved", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LocalDiskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalDiskToolStripMenuItem.Click
        SaveFileDialog1.Filter = "Text Files (*.txt*)|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
        Then
            Dim fileToSave As String = SaveFileDialog1.FileName
            Dim fileWriter As New System.IO.StreamWriter(fileToSave)
            fileWriter.Write("Query: " & vbCrLf & query.Text & vbCrLf & vbCrLf & "Qurey Conversion: " & vbCrLf & vbCrLf & queryOutput.Text)
            fileWriter.Close()
            MessageBox.Show("File Saved Successfully!", ":D", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class