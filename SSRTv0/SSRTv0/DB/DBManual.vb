Public MustInherit Class DBManual
    Public MustOverride Sub setUrlQuery(u As String, l As Boolean)
    Public MustOverride Sub cleanQuery()
    Public MustOverride Function getTotalResults() As String
    Public MustOverride Function checkEnd(s As Boolean) As Boolean
    Public MustOverride Function nextPage(s As Boolean) As Boolean
    Public MustOverride Function previousPage() As Boolean
    Public MustOverride Sub displayResults()
    Public MustOverride Sub downloadResults()
    Public MustOverride Function getUrlDownload() As String
    Public MustOverride Function DownloadCompleteStatus() As Boolean
    Public MustOverride Sub setQueryDBInfo(ByVal queryDate As String, ByVal queryUsername As String)
    Public Async Sub waitForRandom()
        Dim rdm As New Random()
        Dim arrTime() As Integer = {1000, 2000, 3000, 4000, 5000}
        Await Task.Delay(arrTime(rdm.Next(0, 4)))
    End Sub
End Class