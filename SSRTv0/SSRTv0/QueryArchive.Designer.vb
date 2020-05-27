<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QueryArchive
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
        Me.btQueryConverterArchive = New System.Windows.Forms.Button()
        Me.btQuerySearchandDownloadArchive = New System.Windows.Forms.Button()
        Me.dgvQueryArchive = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sbLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btDeleteQueryArchive = New System.Windows.Forms.Button()
        Me.tbDeleteQueryID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btDeleteSelected = New System.Windows.Forms.Button()
        CType(Me.dgvQueryArchive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btQueryConverterArchive
        '
        Me.btQueryConverterArchive.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btQueryConverterArchive.Location = New System.Drawing.Point(501, 22)
        Me.btQueryConverterArchive.Name = "btQueryConverterArchive"
        Me.btQueryConverterArchive.Size = New System.Drawing.Size(140, 47)
        Me.btQueryConverterArchive.TabIndex = 0
        Me.btQueryConverterArchive.Text = "Query Converter Archive"
        Me.btQueryConverterArchive.UseVisualStyleBackColor = True
        '
        'btQuerySearchandDownloadArchive
        '
        Me.btQuerySearchandDownloadArchive.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btQuerySearchandDownloadArchive.Location = New System.Drawing.Point(647, 22)
        Me.btQuerySearchandDownloadArchive.Name = "btQuerySearchandDownloadArchive"
        Me.btQuerySearchandDownloadArchive.Size = New System.Drawing.Size(140, 47)
        Me.btQuerySearchandDownloadArchive.TabIndex = 1
        Me.btQuerySearchandDownloadArchive.Text = "Query Search and Download Archive"
        Me.btQuerySearchandDownloadArchive.UseVisualStyleBackColor = True
        '
        'dgvQueryArchive
        '
        Me.dgvQueryArchive.AllowUserToAddRows = False
        Me.dgvQueryArchive.AllowUserToDeleteRows = False
        Me.dgvQueryArchive.AllowUserToOrderColumns = True
        Me.dgvQueryArchive.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQueryArchive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvQueryArchive.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvQueryArchive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvQueryArchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQueryArchive.Location = New System.Drawing.Point(0, 157)
        Me.dgvQueryArchive.Name = "dgvQueryArchive"
        Me.dgvQueryArchive.ReadOnly = True
        Me.dgvQueryArchive.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvQueryArchive.RowTemplate.Height = 24
        Me.dgvQueryArchive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQueryArchive.Size = New System.Drawing.Size(1289, 488)
        Me.dgvQueryArchive.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 645)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1289, 25)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sbLabel
        '
        Me.sbLabel.Name = "sbLabel"
        Me.sbLabel.Size = New System.Drawing.Size(133, 20)
        Me.sbLabel.Text = "Ready to connect..."
        '
        'btDeleteQueryArchive
        '
        Me.btDeleteQueryArchive.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btDeleteQueryArchive.Location = New System.Drawing.Point(734, 99)
        Me.btDeleteQueryArchive.Name = "btDeleteQueryArchive"
        Me.btDeleteQueryArchive.Size = New System.Drawing.Size(104, 29)
        Me.btDeleteQueryArchive.TabIndex = 4
        Me.btDeleteQueryArchive.Text = "Delete"
        Me.btDeleteQueryArchive.UseVisualStyleBackColor = True
        '
        'tbDeleteQueryID
        '
        Me.tbDeleteQueryID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbDeleteQueryID.Location = New System.Drawing.Point(361, 102)
        Me.tbDeleteQueryID.Name = "tbDeleteQueryID"
        Me.tbDeleteQueryID.Size = New System.Drawing.Size(367, 22)
        Me.tbDeleteQueryID.TabIndex = 5
        Me.tbDeleteQueryID.Text = "For multiple, seperate with comma i.e 1,2,3"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(287, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Query ID:"
        '
        'btDeleteSelected
        '
        Me.btDeleteSelected.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btDeleteSelected.Location = New System.Drawing.Point(844, 99)
        Me.btDeleteSelected.Name = "btDeleteSelected"
        Me.btDeleteSelected.Size = New System.Drawing.Size(158, 29)
        Me.btDeleteSelected.TabIndex = 16
        Me.btDeleteSelected.Text = "Delete Selected Rows"
        Me.btDeleteSelected.UseVisualStyleBackColor = True
        '
        'QueryArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 670)
        Me.Controls.Add(Me.btDeleteSelected)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbDeleteQueryID)
        Me.Controls.Add(Me.btDeleteQueryArchive)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvQueryArchive)
        Me.Controls.Add(Me.btQuerySearchandDownloadArchive)
        Me.Controls.Add(Me.btQueryConverterArchive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "QueryArchive"
        Me.Text = "QueryArchive"
        CType(Me.dgvQueryArchive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btQueryConverterArchive As Button
    Friend WithEvents btQuerySearchandDownloadArchive As Button
    Friend WithEvents dgvQueryArchive As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents btDeleteQueryArchive As Button
    Friend WithEvents tbDeleteQueryID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents sbLabel As ToolStripStatusLabel
    Friend WithEvents btDeleteSelected As Button
End Class
