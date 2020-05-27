<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewManageCitations
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbDeleteCitationID = New System.Windows.Forms.TextBox()
        Me.btDeleteCitation = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sbLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvPublications = New System.Windows.Forms.DataGridView()
        Me.cbSourceSelection = New System.Windows.Forms.ComboBox()
        Me.btView = New System.Windows.Forms.Button()
        Me.btDeleteSelected = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvPublications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(272, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Publication ID:"
        '
        'tbDeleteCitationID
        '
        Me.tbDeleteCitationID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbDeleteCitationID.Location = New System.Drawing.Point(376, 103)
        Me.tbDeleteCitationID.Name = "tbDeleteCitationID"
        Me.tbDeleteCitationID.Size = New System.Drawing.Size(367, 22)
        Me.tbDeleteCitationID.TabIndex = 11
        Me.tbDeleteCitationID.Text = "For multiple, seperate with comma i.e 1,2,3"
        '
        'btDeleteCitation
        '
        Me.btDeleteCitation.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btDeleteCitation.Location = New System.Drawing.Point(749, 100)
        Me.btDeleteCitation.Name = "btDeleteCitation"
        Me.btDeleteCitation.Size = New System.Drawing.Size(104, 29)
        Me.btDeleteCitation.TabIndex = 10
        Me.btDeleteCitation.Text = "Delete"
        Me.btDeleteCitation.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 645)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1289, 25)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sbLabel
        '
        Me.sbLabel.Name = "sbLabel"
        Me.sbLabel.Size = New System.Drawing.Size(133, 20)
        Me.sbLabel.Text = "Ready to connect..."
        '
        'dgvPublications
        '
        Me.dgvPublications.AllowUserToAddRows = False
        Me.dgvPublications.AllowUserToDeleteRows = False
        Me.dgvPublications.AllowUserToOrderColumns = True
        Me.dgvPublications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPublications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPublications.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPublications.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPublications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPublications.Location = New System.Drawing.Point(0, 156)
        Me.dgvPublications.Name = "dgvPublications"
        Me.dgvPublications.ReadOnly = True
        Me.dgvPublications.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvPublications.RowTemplate.Height = 24
        Me.dgvPublications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPublications.Size = New System.Drawing.Size(1289, 486)
        Me.dgvPublications.TabIndex = 8
        '
        'cbSourceSelection
        '
        Me.cbSourceSelection.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbSourceSelection.FormattingEnabled = True
        Me.cbSourceSelection.Items.AddRange(New Object() {"ACM", "IEEEXplore", "SpringerLink", "Imported", "All"})
        Me.cbSourceSelection.Location = New System.Drawing.Point(499, 40)
        Me.cbSourceSelection.Name = "cbSourceSelection"
        Me.cbSourceSelection.Size = New System.Drawing.Size(181, 24)
        Me.cbSourceSelection.TabIndex = 13
        Me.cbSourceSelection.Text = "Select Source to View"
        '
        'btView
        '
        Me.btView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btView.Location = New System.Drawing.Point(686, 37)
        Me.btView.Name = "btView"
        Me.btView.Size = New System.Drawing.Size(104, 29)
        Me.btView.TabIndex = 14
        Me.btView.Text = "View"
        Me.btView.UseVisualStyleBackColor = True
        '
        'btDeleteSelected
        '
        Me.btDeleteSelected.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btDeleteSelected.Location = New System.Drawing.Point(859, 100)
        Me.btDeleteSelected.Name = "btDeleteSelected"
        Me.btDeleteSelected.Size = New System.Drawing.Size(158, 29)
        Me.btDeleteSelected.TabIndex = 15
        Me.btDeleteSelected.Text = "Delete Selected Rows"
        Me.btDeleteSelected.UseVisualStyleBackColor = True
        '
        'ViewManageCitations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 670)
        Me.Controls.Add(Me.btDeleteSelected)
        Me.Controls.Add(Me.btView)
        Me.Controls.Add(Me.cbSourceSelection)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbDeleteCitationID)
        Me.Controls.Add(Me.btDeleteCitation)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvPublications)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ViewManageCitations"
        Me.Text = "ViewManageCitations"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvPublications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbDeleteCitationID As TextBox
    Friend WithEvents btDeleteCitation As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbLabel As ToolStripStatusLabel
    Friend WithEvents dgvPublications As DataGridView
    Friend WithEvents cbSourceSelection As ComboBox
    Friend WithEvents btView As Button
    Friend WithEvents btDeleteSelected As Button
End Class
