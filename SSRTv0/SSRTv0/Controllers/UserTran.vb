Public Class UserTran
    ' This class is designed to handle the user information across the program
    ' By: Ahmed Al-Zubidy - aalzubidy@crimson.ua.edu
    ' 12/15/2016
    ' v0.0.0

    Private userEmail As String = ""

    Public Sub New()
        ' Empty constructor
    End Sub

    Public Sub setUser(ByVal u As String)
        userEmail = u
    End Sub

    Public Function getUser() As String
        Return userEmail
    End Function

    Public Sub logOut()
        userEmail = ""
    End Sub
End Class
