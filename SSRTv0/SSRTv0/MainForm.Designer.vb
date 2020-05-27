<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryConverterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoredCitationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportCitationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportCitationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToBibTexFormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToPlainTextFormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportBugsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lSearchQuery = New System.Windows.Forms.Label()
        Me.tbQuery = New System.Windows.Forms.TextBox()
        Me.bSearch = New System.Windows.Forms.Button()
        Me.cbDB = New System.Windows.Forms.ComboBox()
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.sblSearch = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgSearch = New System.Windows.Forms.DataGridView()
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstAuthor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Venue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bNext = New System.Windows.Forms.Button()
        Me.bPrevious = New System.Windows.Forms.Button()
        Me.bDownloadAll = New System.Windows.Forms.Button()
        Me.bPause = New System.Windows.Forms.Button()
        Me.bResume = New System.Windows.Forms.Button()
        Me.OFDImport = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbCustomDownloadOptions = New System.Windows.Forms.ComboBox()
        Me.bCustomDownload = New System.Windows.Forms.Button()
        Me.tbCustomURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SFDExport = New System.Windows.Forms.SaveFileDialog()
        Me.mainMenu.SuspendLayout()
        Me.statusBar.SuspendLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu
        '
        Me.mainMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(1229, 28)
        Me.mainMenu.TabIndex = 0
        Me.mainMenu.Text = "MainMenu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOutToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.NewSearchToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'NewSearchToolStripMenuItem
        '
        Me.NewSearchToolStripMenuItem.Name = "NewSearchToolStripMenuItem"
        Me.NewSearchToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.NewSearchToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueryConverterToolStripMenuItem, Me.StoredCitationsToolStripMenuItem, Me.QueryArchiveToolStripMenuItem, Me.ImportCitationsToolStripMenuItem, Me.ExportCitationsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(56, 24)
        Me.EditToolStripMenuItem.Text = "Tools"
        '
        'QueryConverterToolStripMenuItem
        '
        Me.QueryConverterToolStripMenuItem.Name = "QueryConverterToolStripMenuItem"
        Me.QueryConverterToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.QueryConverterToolStripMenuItem.Text = "Query Converter"
        '
        'StoredCitationsToolStripMenuItem
        '
        Me.StoredCitationsToolStripMenuItem.Name = "StoredCitationsToolStripMenuItem"
        Me.StoredCitationsToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.StoredCitationsToolStripMenuItem.Text = "View && Manage Citations"
        '
        'QueryArchiveToolStripMenuItem
        '
        Me.QueryArchiveToolStripMenuItem.Name = "QueryArchiveToolStripMenuItem"
        Me.QueryArchiveToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.QueryArchiveToolStripMenuItem.Text = "Query Archive"
        '
        'ImportCitationsToolStripMenuItem
        '
        Me.ImportCitationsToolStripMenuItem.Name = "ImportCitationsToolStripMenuItem"
        Me.ImportCitationsToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.ImportCitationsToolStripMenuItem.Text = "Import Citations"
        '
        'ExportCitationsToolStripMenuItem
        '
        Me.ExportCitationsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToBibTexFormatToolStripMenuItem, Me.ExportToPlainTextFormatToolStripMenuItem})
        Me.ExportCitationsToolStripMenuItem.Name = "ExportCitationsToolStripMenuItem"
        Me.ExportCitationsToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.ExportCitationsToolStripMenuItem.Text = "Export Citations"
        '
        'ExportToBibTexFormatToolStripMenuItem
        '
        Me.ExportToBibTexFormatToolStripMenuItem.Name = "ExportToBibTexFormatToolStripMenuItem"
        Me.ExportToBibTexFormatToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.ExportToBibTexFormatToolStripMenuItem.Text = "Export to BibTex Format"
        '
        'ExportToPlainTextFormatToolStripMenuItem
        '
        Me.ExportToPlainTextFormatToolStripMenuItem.Name = "ExportToPlainTextFormatToolStripMenuItem"
        Me.ExportToPlainTextFormatToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.ExportToPlainTextFormatToolStripMenuItem.Text = "Export to Plain Text Format"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.ReportBugsToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(53, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(197, 26)
        Me.HelpToolStripMenuItem1.Text = "How to Use SSRT"
        '
        'ReportBugsToolStripMenuItem
        '
        Me.ReportBugsToolStripMenuItem.Name = "ReportBugsToolStripMenuItem"
        Me.ReportBugsToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.ReportBugsToolStripMenuItem.Text = "Report Bugs"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.AboutUsToolStripMenuItem.Text = "About Us"
        '
        'lSearchQuery
        '
        Me.lSearchQuery.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lSearchQuery.AutoSize = True
        Me.lSearchQuery.Location = New System.Drawing.Point(88, 59)
        Me.lSearchQuery.Name = "lSearchQuery"
        Me.lSearchQuery.Size = New System.Drawing.Size(100, 17)
        Me.lSearchQuery.TabIndex = 1
        Me.lSearchQuery.Text = "Search Query:"
        '
        'tbQuery
        '
        Me.tbQuery.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbQuery.Location = New System.Drawing.Point(192, 56)
        Me.tbQuery.Name = "tbQuery"
        Me.tbQuery.Size = New System.Drawing.Size(744, 22)
        Me.tbQuery.TabIndex = 2
        Me.tbQuery.Text = "Enter query to search..."
        '
        'bSearch
        '
        Me.bSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bSearch.Location = New System.Drawing.Point(1065, 53)
        Me.bSearch.Name = "bSearch"
        Me.bSearch.Size = New System.Drawing.Size(75, 29)
        Me.bSearch.TabIndex = 4
        Me.bSearch.Text = "Search"
        Me.bSearch.UseVisualStyleBackColor = True
        '
        'cbDB
        '
        Me.cbDB.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbDB.FormattingEnabled = True
        Me.cbDB.Items.AddRange(New Object() {"ACM", "Springer Link", "IEEE", "All"})
        Me.cbDB.Location = New System.Drawing.Point(940, 55)
        Me.cbDB.Name = "cbDB"
        Me.cbDB.Size = New System.Drawing.Size(121, 24)
        Me.cbDB.TabIndex = 3
        Me.cbDB.Text = "Select DB"
        '
        'statusBar
        '
        Me.statusBar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sblSearch})
        Me.statusBar.Location = New System.Drawing.Point(0, 649)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(1229, 25)
        Me.statusBar.TabIndex = 5
        Me.statusBar.Text = "StatusBar"
        '
        'sblSearch
        '
        Me.sblSearch.Name = "sblSearch"
        Me.sblSearch.Size = New System.Drawing.Size(123, 20)
        Me.sblSearch.Text = "Ready to search..."
        '
        'dgSearch
        '
        Me.dgSearch.AllowUserToAddRows = False
        Me.dgSearch.AllowUserToDeleteRows = False
        Me.dgSearch.AllowUserToOrderColumns = True
        Me.dgSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgSearch.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Title, Me.FirstAuthor, Me.Year, Me.Venue})
        Me.dgSearch.Location = New System.Drawing.Point(0, 295)
        Me.dgSearch.Name = "dgSearch"
        Me.dgSearch.ReadOnly = True
        Me.dgSearch.RowTemplate.Height = 24
        Me.dgSearch.Size = New System.Drawing.Size(1229, 354)
        Me.dgSearch.TabIndex = 6
        '
        'Title
        '
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        '
        'FirstAuthor
        '
        Me.FirstAuthor.HeaderText = "First Author"
        Me.FirstAuthor.Name = "FirstAuthor"
        Me.FirstAuthor.ReadOnly = True
        '
        'Year
        '
        Me.Year.HeaderText = "Year"
        Me.Year.Name = "Year"
        Me.Year.ReadOnly = True
        '
        'Venue
        '
        Me.Venue.HeaderText = "Venue"
        Me.Venue.Name = "Venue"
        Me.Venue.ReadOnly = True
        '
        'bNext
        '
        Me.bNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNext.Enabled = False
        Me.bNext.Location = New System.Drawing.Point(1142, 261)
        Me.bNext.Name = "bNext"
        Me.bNext.Size = New System.Drawing.Size(75, 28)
        Me.bNext.TabIndex = 7
        Me.bNext.Text = "Next"
        Me.bNext.UseVisualStyleBackColor = True
        '
        'bPrevious
        '
        Me.bPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bPrevious.Enabled = False
        Me.bPrevious.Location = New System.Drawing.Point(1065, 261)
        Me.bPrevious.Name = "bPrevious"
        Me.bPrevious.Size = New System.Drawing.Size(75, 28)
        Me.bPrevious.TabIndex = 8
        Me.bPrevious.Text = "Previous"
        Me.bPrevious.UseVisualStyleBackColor = True
        '
        'bDownloadAll
        '
        Me.bDownloadAll.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bDownloadAll.Enabled = False
        Me.bDownloadAll.Location = New System.Drawing.Point(689, 88)
        Me.bDownloadAll.Name = "bDownloadAll"
        Me.bDownloadAll.Size = New System.Drawing.Size(137, 33)
        Me.bDownloadAll.TabIndex = 9
        Me.bDownloadAll.Text = "Download All"
        Me.bDownloadAll.UseVisualStyleBackColor = True
        '
        'bPause
        '
        Me.bPause.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bPause.Enabled = False
        Me.bPause.Location = New System.Drawing.Point(546, 88)
        Me.bPause.Name = "bPause"
        Me.bPause.Size = New System.Drawing.Size(137, 33)
        Me.bPause.TabIndex = 10
        Me.bPause.Text = "Pause Download"
        Me.bPause.UseVisualStyleBackColor = True
        '
        'bResume
        '
        Me.bResume.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bResume.Enabled = False
        Me.bResume.Location = New System.Drawing.Point(403, 88)
        Me.bResume.Name = "bResume"
        Me.bResume.Size = New System.Drawing.Size(137, 33)
        Me.bResume.TabIndex = 11
        Me.bResume.Text = "Resume Download"
        Me.bResume.UseVisualStyleBackColor = True
        '
        'OFDImport
        '
        Me.OFDImport.FileName = "OFDImport"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.cbCustomDownloadOptions)
        Me.GroupBox1.Controls.Add(Me.bCustomDownload)
        Me.GroupBox1.Controls.Add(Me.tbCustomURL)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(75, 135)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1078, 103)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Custom URL Downlaoder"
        '
        'cbCustomDownloadOptions
        '
        Me.cbCustomDownloadOptions.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbCustomDownloadOptions.FormattingEnabled = True
        Me.cbCustomDownloadOptions.Items.AddRange(New Object() {"Download Only URL Page", "Download All Pages"})
        Me.cbCustomDownloadOptions.Location = New System.Drawing.Point(614, 19)
        Me.cbCustomDownloadOptions.Name = "cbCustomDownloadOptions"
        Me.cbCustomDownloadOptions.Size = New System.Drawing.Size(137, 24)
        Me.cbCustomDownloadOptions.TabIndex = 6
        Me.cbCustomDownloadOptions.Text = "Download Options"
        Me.cbCustomDownloadOptions.Visible = False
        '
        'bCustomDownload
        '
        Me.bCustomDownload.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bCustomDownload.Location = New System.Drawing.Point(901, 46)
        Me.bCustomDownload.Name = "bCustomDownload"
        Me.bCustomDownload.Size = New System.Drawing.Size(93, 29)
        Me.bCustomDownload.TabIndex = 5
        Me.bCustomDownload.Text = "Download"
        Me.bCustomDownload.UseVisualStyleBackColor = True
        '
        'tbCustomURL
        '
        Me.tbCustomURL.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbCustomURL.Location = New System.Drawing.Point(131, 49)
        Me.tbCustomURL.Name = "tbCustomURL"
        Me.tbCustomURL.Size = New System.Drawing.Size(764, 22)
        Me.tbCustomURL.TabIndex = 1
        Me.tbCustomURL.Text = "Enter URL to Download..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "URL:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 674)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bResume)
        Me.Controls.Add(Me.bPause)
        Me.Controls.Add(Me.bDownloadAll)
        Me.Controls.Add(Me.bPrevious)
        Me.Controls.Add(Me.bNext)
        Me.Controls.Add(Me.dgSearch)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.cbDB)
        Me.Controls.Add(Me.bSearch)
        Me.Controls.Add(Me.tbQuery)
        Me.Controls.Add(Me.lSearchQuery)
        Me.Controls.Add(Me.mainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mainMenu
        Me.Name = "MainForm"
        Me.Text = "SSRT"
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        CType(Me.dgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mainMenu As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lSearchQuery As Label
    Friend WithEvents tbQuery As TextBox
    Friend WithEvents bSearch As Button
    Friend WithEvents cbDB As ComboBox
    Friend WithEvents statusBar As StatusStrip
    Friend WithEvents sblSearch As ToolStripStatusLabel
    Friend WithEvents dgSearch As DataGridView
    Friend WithEvents Title As DataGridViewTextBoxColumn
    Friend WithEvents FirstAuthor As DataGridViewTextBoxColumn
    Friend WithEvents Year As DataGridViewTextBoxColumn
    Friend WithEvents Venue As DataGridViewTextBoxColumn
    Friend WithEvents bNext As Button
    Friend WithEvents bPrevious As Button
    Friend WithEvents bDownloadAll As Button
    Friend WithEvents bPause As Button
    Friend WithEvents bResume As Button
    Friend WithEvents NewSearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueryConverterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StoredCitationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportCitationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportCitationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueryArchiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReportBugsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToBibTexFormatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToPlainTextFormatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OFDImport As OpenFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents bCustomDownload As Button
    Friend WithEvents tbCustomURL As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCustomDownloadOptions As ComboBox
    Friend WithEvents SFDExport As SaveFileDialog
End Class
