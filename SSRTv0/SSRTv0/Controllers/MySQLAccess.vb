Imports MySql.Data.MySqlClient
Public Class MySQLAccess
    ' This class is to put MySQL transactions in it so I do not write them again everywhere
    ' This class is an upgrade from MySQLTran
    ' Designed and developed by Ahmed Al-Zubidy - aalzubidy@crimson.ua.edu
    ' 1/23/2017
    ' V1.0.0

    Private conn As MySqlConnection = New MySqlConnection

    Public Sub New()
        ' Empty constructor, and call the set url right away from the object.
    End Sub

    Public Function connect() As Boolean
        Dim databaseName, serverName, userName, password As String
        getSettings(serverName, databaseName, userName, password)

        'Dim DatabaseName As String = "aalzubid_ssrt"
        'Dim server As String = "aalzubidy.com"
        ''Dim server As String = "localhost"
        'Dim userName As String = "aalzubid_ssrtu"
        'Dim password As String = "123ussrt"
        ''Dim userName As String = "root"
        ''Dim password As String = ""

        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", serverName, userName, password, databaseName)
        Try
            conn.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " - Let me know about it and I will fix it!", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Sub disconnect()
        conn.Close()
    End Sub

    Public Function insertMySQL(ByVal q As String, ByVal qval() As String) As Boolean
        Dim cmd As MySqlCommand = New MySqlCommand
        connect()
        Try
            Dim ParName(), ParValue() As String

            Dim temp = q.Substring(q.IndexOf("values") + 6).Replace("(", "").Replace(")", "").Trim()
            ParName = temp.Split(",")
            ParValue = qval

            With cmd
                .Connection = conn
                .CommandText = q.Trim()
                If ParValue.Length > 0 Then
                    For i = 0 To ParValue.Length - 1
                        .Parameters.AddWithValue(ParName(i), ParValue(i))
                    Next
                End If
                .ExecuteNonQuery()
            End With
            disconnect()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Public Function selectMySQL(ByVal q As String, ByVal qval() As String) As MySqlDataReader
        Dim cmd As MySqlCommand = New MySqlCommand
        connect()
        Dim data As MySqlDataReader
        Try
            Dim parName(), parValue() As String
            parValue = qval

            Dim temp As String = q
            Dim names As String = ""
            If parValue.Length > 0 Then
                While temp.Contains("=@")
                    temp = temp.Substring(temp.IndexOf("=@") + 1).Trim()
                    If temp.Contains(" ") Then
                        names = names & temp.Substring(0, temp.IndexOf(" ")) & "#"
                    ElseIf temp.Contains(" ") = False And temp.Contains(")")
                        names = names & temp.Substring(0, temp.IndexOf(")")) & "#"
                    ElseIf temp.Contains(" ") = False And temp.Contains(")") = False
                        names = names & temp.Substring(0) & "#"
                    End If
                End While
                names = names.Substring(0, names.Length - 1)
            End If
            parName = names.Split("#")

            With cmd
                .Connection = conn
                .CommandText = q.Trim()
                If parValue.Length > 0 Then
                    For i = 0 To parValue.Length - 1
                        .Parameters.AddWithValue(parName(i), parValue(i))
                    Next
                End If
            End With
            data = cmd.ExecuteReader()
        Catch e As Exception
            MsgBox(e.Message.ToString)
        End Try
        Return data
    End Function

    Public Function deleteMySQL(ByVal q As String, ByVal qval() As String) As Boolean
        Dim cmd As MySqlCommand = New MySqlCommand
        connect()
        Try
            Dim parName(), parValue() As String

            parValue = qval

            Dim temp As String = q
            Dim names As String = ""
            If parValue.Length > 0 Then
                While temp.Contains("=@")
                    temp = temp.Substring(temp.IndexOf("=@") + 1).Trim()
                    If temp.Contains(" ") Then
                        names = names & temp.Substring(0, temp.IndexOf(" ")) & "#"
                    ElseIf temp.Contains(" ") = False And temp.Contains(")")
                        names = names & temp.Substring(0, temp.IndexOf(")")) & "#"
                    ElseIf temp.Contains(" ") = False And temp.Contains(")") = False
                        names = names & temp.Substring(0) & "#"
                    End If
                End While
                names = names.Substring(0, names.Length - 1)
            End If
            parName = names.Split("#")
            With cmd
                .Connection = conn
                .CommandText = q.Trim()
                If parValue.Length > 0 Then
                    For i = 0 To parValue.Length - 1
                        .Parameters.AddWithValue(parName(i), parValue(i))
                    Next
                End If
            End With
            cmd.ExecuteNonQuery()
            disconnect()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        End Try
    End Function

    Private Sub getSettings(ByRef serverName As String, ByRef databaseName As String, ByRef userName As String, ByRef password As String)
        Dim cleanString() = System.IO.File.ReadAllLines("ConnectionSettings.txt")
        Dim i As Integer = 1

        For Each line In cleanString
            If i > 4 Then
                Exit For
            Else
                If line.StartsWith("@") Then
                    line = line.Substring(line.IndexOf("=") + 1).Trim()
                    If i = 1 Then
                        If line.Equals("ssrt") Then
                            serverName = "aalzubidy.com"
                        Else
                            serverName = line
                        End If
                        i = i + 1
                    ElseIf i = 2 Then
                        If line.Equals("ssrt") Then
                            databaseName = "aalzubid_ssrt"
                        Else
                            databaseName = line
                        End If
                        i = i + 1
                    ElseIf i = 3 Then
                        If line.Equals("ssrt") Then
                            userName = "aalzubid_ssrtu"
                        Else
                            userName = line
                        End If
                        i = i + 1
                    ElseIf i = 4 Then
                        If line.Equals("ssrt") Then
                            password = "123ussrt"
                        Else
                            password = line
                        End If
                        i = i + 1
                    End If
                End If
            End If
        Next
    End Sub
End Class