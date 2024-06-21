<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnView_Submissions = New System.Windows.Forms.Button()
        Me.btnCreate_New_Submission = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnView_Submissions
        '
        Me.btnView_Submissions.BackColor = System.Drawing.Color.Khaki
        Me.btnView_Submissions.Location = New System.Drawing.Point(22, 99)
        Me.btnView_Submissions.Name = "btnView_Submissions"
        Me.btnView_Submissions.Size = New System.Drawing.Size(504, 82)
        Me.btnView_Submissions.TabIndex = 0
        Me.btnView_Submissions.Text = "View Submissions (CTRL+V)"
        Me.btnView_Submissions.UseVisualStyleBackColor = False
        '
        'btnCreate_New_Submission
        '
        Me.btnCreate_New_Submission.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnCreate_New_Submission.Location = New System.Drawing.Point(22, 210)
        Me.btnCreate_New_Submission.Name = "btnCreate_New_Submission"
        Me.btnCreate_New_Submission.Size = New System.Drawing.Size(504, 79)
        Me.btnCreate_New_Submission.TabIndex = 1
        Me.btnCreate_New_Submission.Text = "Create New Submission(CTRL+N)"
        Me.btnCreate_New_Submission.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(122, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Rohith Dandi, Slidely Task 2- Slidely Form App"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 395)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCreate_New_Submission)
        Me.Controls.Add(Me.btnView_Submissions)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnView_Submissions As Button
    Friend WithEvents btnCreate_New_Submission As Button
    Friend WithEvents Label1 As Label
End Class
