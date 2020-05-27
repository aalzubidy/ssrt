<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btLogin = New System.Windows.Forms.Button()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabLogin = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.loginStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tabNewUser = New System.Windows.Forms.TabPage()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.NewUserStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btNewUser = New System.Windows.Forms.Button()
        Me.tbNameNew = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbEmailNew = New System.Windows.Forms.TextBox()
        Me.tbPasswordNew = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabLogin.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tabNewUser.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password:"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(102, 63)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(262, 22)
        Me.tbPassword.TabIndex = 2
        Me.tbPassword.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Email:"
        '
        'btLogin
        '
        Me.btLogin.Location = New System.Drawing.Point(258, 91)
        Me.btLogin.Name = "btLogin"
        Me.btLogin.Size = New System.Drawing.Size(106, 32)
        Me.btLogin.TabIndex = 3
        Me.btLogin.Text = "Login"
        Me.btLogin.UseVisualStyleBackColor = True
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(102, 32)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(262, 22)
        Me.tbEmail.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabLogin)
        Me.TabControl1.Controls.Add(Me.tabNewUser)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(399, 227)
        Me.TabControl1.TabIndex = 4
        '
        'tabLogin
        '
        Me.tabLogin.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabLogin.Controls.Add(Me.StatusStrip1)
        Me.tabLogin.Controls.Add(Me.tbEmail)
        Me.tabLogin.Controls.Add(Me.tbPassword)
        Me.tabLogin.Controls.Add(Me.btLogin)
        Me.tabLogin.Controls.Add(Me.Label2)
        Me.tabLogin.Controls.Add(Me.Label1)
        Me.tabLogin.Location = New System.Drawing.Point(4, 25)
        Me.tabLogin.Name = "tabLogin"
        Me.tabLogin.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLogin.Size = New System.Drawing.Size(391, 198)
        Me.tabLogin.TabIndex = 0
        Me.tabLogin.Text = "Login"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loginStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 170)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(385, 25)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'loginStatusLabel
        '
        Me.loginStatusLabel.Name = "loginStatusLabel"
        Me.loginStatusLabel.Size = New System.Drawing.Size(133, 20)
        Me.loginStatusLabel.Text = "Ready to connect..."
        '
        'tabNewUser
        '
        Me.tabNewUser.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabNewUser.Controls.Add(Me.StatusStrip2)
        Me.tabNewUser.Controls.Add(Me.btNewUser)
        Me.tabNewUser.Controls.Add(Me.tbNameNew)
        Me.tabNewUser.Controls.Add(Me.Label5)
        Me.tabNewUser.Controls.Add(Me.tbEmailNew)
        Me.tabNewUser.Controls.Add(Me.tbPasswordNew)
        Me.tabNewUser.Controls.Add(Me.Label3)
        Me.tabNewUser.Controls.Add(Me.Label4)
        Me.tabNewUser.Location = New System.Drawing.Point(4, 25)
        Me.tabNewUser.Name = "tabNewUser"
        Me.tabNewUser.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNewUser.Size = New System.Drawing.Size(391, 198)
        Me.tabNewUser.TabIndex = 1
        Me.tabNewUser.Text = "New User"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewUserStatusLabel})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 170)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(385, 25)
        Me.StatusStrip2.TabIndex = 10
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'NewUserStatusLabel
        '
        Me.NewUserStatusLabel.Name = "NewUserStatusLabel"
        Me.NewUserStatusLabel.Size = New System.Drawing.Size(133, 20)
        Me.NewUserStatusLabel.Text = "Ready to connect..."
        '
        'btNewUser
        '
        Me.btNewUser.Location = New System.Drawing.Point(258, 123)
        Me.btNewUser.Name = "btNewUser"
        Me.btNewUser.Size = New System.Drawing.Size(106, 32)
        Me.btNewUser.TabIndex = 9
        Me.btNewUser.Text = "Register"
        Me.btNewUser.UseVisualStyleBackColor = True
        '
        'tbNameNew
        '
        Me.tbNameNew.Location = New System.Drawing.Point(102, 95)
        Me.tbNameNew.Name = "tbNameNew"
        Me.tbNameNew.Size = New System.Drawing.Size(262, 22)
        Me.tbNameNew.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Full Name:"
        '
        'tbEmailNew
        '
        Me.tbEmailNew.Location = New System.Drawing.Point(102, 32)
        Me.tbEmailNew.Name = "tbEmailNew"
        Me.tbEmailNew.Size = New System.Drawing.Size(262, 22)
        Me.tbEmailNew.TabIndex = 4
        '
        'tbPasswordNew
        '
        Me.tbPasswordNew.Location = New System.Drawing.Point(102, 63)
        Me.tbPasswordNew.Name = "tbPasswordNew"
        Me.tbPasswordNew.Size = New System.Drawing.Size(262, 22)
        Me.tbPasswordNew.TabIndex = 5
        Me.tbPasswordNew.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Email:"
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 227)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "LoginForm"
        Me.Text = "SSRT Login"
        Me.TabControl1.ResumeLayout(False)
        Me.tabLogin.ResumeLayout(False)
        Me.tabLogin.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tabNewUser.ResumeLayout(False)
        Me.tabNewUser.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btLogin As Button
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabLogin As TabPage
    Friend WithEvents tabNewUser As TabPage
    Friend WithEvents btNewUser As Button
    Friend WithEvents tbNameNew As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbEmailNew As TextBox
    Friend WithEvents tbPasswordNew As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents loginStatusLabel As ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents NewUserStatusLabel As ToolStripStatusLabel
End Class
