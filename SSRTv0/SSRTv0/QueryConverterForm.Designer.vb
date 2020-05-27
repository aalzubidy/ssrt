<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QueryConverterForm
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
        Me.queryOutput = New System.Windows.Forms.RichTextBox()
        Me.optimize = New System.Windows.Forms.Button()
        Me.query = New System.Windows.Forms.TextBox()
        Me.searchQueryLabel = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveQueryOutputLocallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SSRTOnlineDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocalDiskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewManageCitationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportCitationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportCitationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryConverterArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuerySearchDownloadArchiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'queryOutput
        '
        Me.queryOutput.Location = New System.Drawing.Point(17, 100)
        Me.queryOutput.Name = "queryOutput"
        Me.queryOutput.Size = New System.Drawing.Size(628, 467)
        Me.queryOutput.TabIndex = 7
        Me.queryOutput.Text = ""
        '
        'optimize
        '
        Me.optimize.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.optimize.Location = New System.Drawing.Point(578, 40)
        Me.optimize.Name = "optimize"
        Me.optimize.Size = New System.Drawing.Size(75, 29)
        Me.optimize.TabIndex = 6
        Me.optimize.Text = "Convert"
        Me.optimize.UseVisualStyleBackColor = True
        '
        'query
        '
        Me.query.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.query.Location = New System.Drawing.Point(115, 43)
        Me.query.Name = "query"
        Me.query.Size = New System.Drawing.Size(457, 22)
        Me.query.TabIndex = 5
        Me.query.Text = "Enter search query..."
        '
        'searchQueryLabel
        '
        Me.searchQueryLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchQueryLabel.AutoSize = True
        Me.searchQueryLabel.Location = New System.Drawing.Point(9, 46)
        Me.searchQueryLabel.Name = "searchQueryLabel"
        Me.searchQueryLabel.Size = New System.Drawing.Size(100, 17)
        Me.searchQueryLabel.TabIndex = 4
        Me.searchQueryLabel.Text = "Search Query:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(662, 28)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewQueryToolStripMenuItem, Me.SaveQueryOutputLocallyToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewQueryToolStripMenuItem
        '
        Me.NewQueryToolStripMenuItem.Name = "NewQueryToolStripMenuItem"
        Me.NewQueryToolStripMenuItem.Size = New System.Drawing.Size(158, 26)
        Me.NewQueryToolStripMenuItem.Text = "New Query"
        '
        'SaveQueryOutputLocallyToolStripMenuItem
        '
        Me.SaveQueryOutputLocallyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SSRTOnlineDatabaseToolStripMenuItem, Me.LocalDiskToolStripMenuItem})
        Me.SaveQueryOutputLocallyToolStripMenuItem.Name = "SaveQueryOutputLocallyToolStripMenuItem"
        Me.SaveQueryOutputLocallyToolStripMenuItem.Size = New System.Drawing.Size(158, 26)
        Me.SaveQueryOutputLocallyToolStripMenuItem.Text = "Save Query"
        '
        'SSRTOnlineDatabaseToolStripMenuItem
        '
        Me.SSRTOnlineDatabaseToolStripMenuItem.Name = "SSRTOnlineDatabaseToolStripMenuItem"
        Me.SSRTOnlineDatabaseToolStripMenuItem.Size = New System.Drawing.Size(230, 26)
        Me.SSRTOnlineDatabaseToolStripMenuItem.Text = "SSRT Online Database"
        '
        'LocalDiskToolStripMenuItem
        '
        Me.LocalDiskToolStripMenuItem.Name = "LocalDiskToolStripMenuItem"
        Me.LocalDiskToolStripMenuItem.Size = New System.Drawing.Size(230, 26)
        Me.LocalDiskToolStripMenuItem.Text = "Local Disk"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(158, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewManageCitationsToolStripMenuItem, Me.ImportCitationsToolStripMenuItem, Me.ExportCitationsToolStripMenuItem, Me.QueryArchiveToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(56, 24)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ViewManageCitationsToolStripMenuItem
        '
        Me.ViewManageCitationsToolStripMenuItem.Name = "ViewManageCitationsToolStripMenuItem"
        Me.ViewManageCitationsToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.ViewManageCitationsToolStripMenuItem.Text = "View && Manage Citations"
        '
        'ImportCitationsToolStripMenuItem
        '
        Me.ImportCitationsToolStripMenuItem.Name = "ImportCitationsToolStripMenuItem"
        Me.ImportCitationsToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.ImportCitationsToolStripMenuItem.Text = "Import Citations"
        '
        'ExportCitationsToolStripMenuItem
        '
        Me.ExportCitationsToolStripMenuItem.Name = "ExportCitationsToolStripMenuItem"
        Me.ExportCitationsToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.ExportCitationsToolStripMenuItem.Text = "Export Citations"
        '
        'QueryArchiveToolStripMenuItem
        '
        Me.QueryArchiveToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QueryConverterArchiveToolStripMenuItem, Me.QuerySearchDownloadArchiveToolStripMenuItem})
        Me.QueryArchiveToolStripMenuItem.Name = "QueryArchiveToolStripMenuItem"
        Me.QueryArchiveToolStripMenuItem.Size = New System.Drawing.Size(252, 26)
        Me.QueryArchiveToolStripMenuItem.Text = "Query Archive"
        '
        'QueryConverterArchiveToolStripMenuItem
        '
        Me.QueryConverterArchiveToolStripMenuItem.Name = "QueryConverterArchiveToolStripMenuItem"
        Me.QueryConverterArchiveToolStripMenuItem.Size = New System.Drawing.Size(313, 26)
        Me.QueryConverterArchiveToolStripMenuItem.Text = "Query Converter Archive"
        '
        'QuerySearchDownloadArchiveToolStripMenuItem
        '
        Me.QuerySearchDownloadArchiveToolStripMenuItem.Name = "QuerySearchDownloadArchiveToolStripMenuItem"
        Me.QuerySearchDownloadArchiveToolStripMenuItem.Size = New System.Drawing.Size(313, 26)
        Me.QuerySearchDownloadArchiveToolStripMenuItem.Text = "Query Search && Download Archive"
        '
        'QueryConverterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 579)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.queryOutput)
        Me.Controls.Add(Me.optimize)
        Me.Controls.Add(Me.query)
        Me.Controls.Add(Me.searchQueryLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(680, 626)
        Me.Name = "QueryConverterForm"
        Me.Text = "Query Converter"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents queryOutput As RichTextBox
    Friend WithEvents optimize As Button
    Friend WithEvents query As TextBox
    Friend WithEvents searchQueryLabel As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewQueryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveQueryOutputLocallyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewManageCitationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportCitationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportCitationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueryArchiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QueryConverterArchiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuerySearchDownloadArchiveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SSRTOnlineDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LocalDiskToolStripMenuItem As ToolStripMenuItem
End Class
