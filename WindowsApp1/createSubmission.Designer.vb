<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class createSubmission
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtLink = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnStopwatch = New System.Windows.Forms.Button()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(225, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rohith Dandi, Slidely Task 2 - Create Submissions"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Email"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Phone Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Github Link For Task 2"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(205, 139)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(540, 22)
        Me.txtName.TabIndex = 5
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(205, 183)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(540, 22)
        Me.txtEmail.TabIndex = 6
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(205, 236)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(540, 22)
        Me.txtPhone.TabIndex = 7
        '
        'txtLink
        '
        Me.txtLink.Location = New System.Drawing.Point(205, 281)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.Size = New System.Drawing.Size(540, 22)
        Me.txtLink.TabIndex = 8
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnSubmit.Location = New System.Drawing.Point(51, 377)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(694, 61)
        Me.btnSubmit.TabIndex = 9
        Me.btnSubmit.Text = "SUBMIT (CTRL+S)"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'btnStopwatch
        '
        Me.btnStopwatch.BackColor = System.Drawing.Color.Gold
        Me.btnStopwatch.Location = New System.Drawing.Point(51, 321)
        Me.btnStopwatch.Name = "btnStopwatch"
        Me.btnStopwatch.Size = New System.Drawing.Size(315, 37)
        Me.btnStopwatch.TabIndex = 10
        Me.btnStopwatch.Text = "TOGGLE STOPWATCH (CTRL+T)"
        Me.btnStopwatch.UseVisualStyleBackColor = False
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(495, 328)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(148, 22)
        Me.txtTime.TabIndex = 11
        '
        'createSubmission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.btnStopwatch)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtLink)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "createSubmission"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtLink As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnStopwatch As Button
    Friend WithEvents txtTime As TextBox
End Class
