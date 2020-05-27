Imports MySql.Data.MySqlClient
Public Class MySQLTran

    ' This class is to put MySQL transactions in it so I do not write them again everywhere
    ' Designed and developed by Ahmed Al-Zubidy - aalzubidy@crimson.ua.edu
    ' 12/06/2016
    ' V0.0.0

    Private conn As MySqlConnection = New MySqlConnection
    Private cmd As MySqlCommand = New MySqlCommand

    Public Sub New()
        ' Empty constructor, and call the set url right away from the object.
    End Sub

    Public Function connect() As Boolean
        Dim DatabaseName As String = "aalzubid_ssrt"
        'Dim server As String = "108.167.189.36"
        Dim server As String = "localhost"
        'Dim userName As String = "aalzubid_ssrt"
        'Dim password As String = "ssrt2016"
        Dim userName As String = "root"
        Dim password As String = ""
        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
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

    Public Function insertMySQL(ByVal q As String) As Boolean
        connect()
        Try
            With cmd
                .CommandText = q.Trim()
                .CommandType = CommandType.Text
                .Connection = conn
                .ExecuteNonQuery()
            End With
            Return True
        Catch e As Exception
            MsgBox(e.Message.ToString)
            Return False
        End Try
    End Function

    Public Function selectMySQL(ByVal q As String) As MySqlDataReader
        Dim data As MySqlDataReader
        Try
            With cmd
                .CommandText = q.Trim()
                .CommandType = CommandType.Text
                .Connection = conn
            End With
            data = cmd.ExecuteReader()
        Catch e As Exception
            MsgBox(e.Message.ToString)
        End Try
        Return data
    End Function
End Class
