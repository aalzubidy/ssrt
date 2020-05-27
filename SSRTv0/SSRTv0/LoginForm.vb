Imports MySql.Data.MySqlClient
Public Class LoginForm
    Public user As New UserTran()

    Private Sub btNewUser_Click(sender As Object, e As EventArgs) Handles btNewUser.Click
        Try
            ' Check if the email and password are in the correct format
            Dim emailInput As String
            emailInput = tbEmailNew.Text.Trim()
            Dim passInput = tbPasswordNew.Text.Trim()
            If emailInput.Contains("@") = False Or emailInput.Equals("") Or String.IsNullOrWhiteSpace(emailInput) Or String.IsNullOrEmpty(emailInput) Or emailInput.Equals(" ") Or emailInput.Substring(emailInput.IndexOf("@")).Contains(".") = False Then
                MessageBox.Show("Email is incorrect", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            ElseIf passInput.Equals("") Or passInput.Equals(" ") Or String.IsNullOrWhiteSpace(passInput) Or String.IsNullOrEmpty(passInput) Then
                MessageBox.Show("Password cannot be empty", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            NewUserStatusLabel.Text = "Please wait, connecting to database..."

            ' Create an object of the MySQLAccess
            Dim mysqlaccess As New MySQLAccess()

            ' Check if it is duplicate
            Dim read As MySqlDataReader
            read = mysqlaccess.selectMySQL("select * from user where userEmail=@userEmail", {emailInput})
            If read.HasRows = True Then
                MessageBox.Show("This email address is already registerd", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                NewUserStatusLabel.Text = "Ready to connect..."
                Return
            End If
            mysqlaccess.disconnect()

            ' Create password hash
            Dim passHash As String
            passHash = SHA256(tbPasswordNew.Text.Trim())

            ' Insert query
            Dim checkInsert As Boolean = mysqlaccess.insertMySQL("insert into user values(@username,@useremail,@userpassword)", {tbNameNew.Text.Trim(), emailInput, passHash})

            If checkInsert = True Then
                MessageBox.Show(tbEmailNew.Text.Trim() & " has been registered successfully!", ":D")
                NewUserStatusLabel.Text = "Ready to connect..."
            Else
                MessageBox.Show("Something went wrong, let me know and I will fix it", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                NewUserStatusLabel.Text = "Ready to connect..."
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Function SHA256(ByVal key) As String
        Try
            'This function is to create SHA256 hash for passwords
            Dim sAlgorithm As New Security.Cryptography.SHA256CryptoServiceProvider
            Dim byteString() As Byte = System.Text.Encoding.ASCII.GetBytes(key)
            byteString = sAlgorithm.ComputeHash(byteString)

            Dim finalString As String
            For Each bt As Byte In byteString
                finalString = finalString & bt.ToString("x2")
            Next
            Return finalString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btLogin_Click(sender As Object, e As EventArgs) Handles btLogin.Click
        Try
            ' Check if the email is in the correct format
            Dim emailInput As String
            emailInput = tbEmail.Text.Trim()
            If emailInput.Contains("@") = False Then
                MessageBox.Show("Email is incorrect", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            ElseIf emailInput.Equals("") Or String.IsNullOrWhiteSpace(emailInput) Or String.IsNullOrEmpty(emailInput) Or emailInput.Equals(" ") Or emailInput.Substring(emailInput.IndexOf("@")).Contains(".") = False Then
                MessageBox.Show("Email is incorrect", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            loginStatusLabel.Text = "Please wait, connecting to database..."

            ' Create an object of MySQLAccees
            Dim mysqlaccess As New MySQLAccess()

            ' Retreive the password
            Dim read As MySqlDataReader
            Dim qval() As String = {emailInput}
            read = mysqlaccess.selectMySQL("select userPassword from user where userEmail=@userEmail", qval)

            ' Create hash for the entered password
            Dim passScreen, passDB As String
            passScreen = SHA256(tbPassword.Text.Trim())


            ' Check if the user is not in the database
            If read.HasRows = False Then
                MessageBox.Show("Sorry, email not found", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                loginStatusLabel.Text = "Ready to connect..."
            Else
                ' Retrieve password from the database
                While read.Read()
                    passDB = read(0).ToString.Trim()
                End While
                read.Close()
                mysqlaccess.disconnect()
                ' Check if the hashes for the passwords match
                If passScreen.Equals(passDB) Then
                    user.setUser(emailInput)
                    MainForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Sorry, password is incorrect", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    loginStatusLabel.Text = "Ready to connect..."
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Sorry something went wrong, you will see the error in the next message box, contact me and I will fix it.", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AcceptButton = btLogin
    End Sub
End Class