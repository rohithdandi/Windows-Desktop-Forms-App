Public Class Form1
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub
    Private Sub btnView_Submissions_Click(sender As Object, e As EventArgs) Handles btnView_Submissions.Click
        viewSubmissions()
    End Sub
    Private Async Sub viewSubmissions_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            viewSubmissions()
            e.Handled = True
        End If
    End Sub
    Private Sub viewSubmissions()
        Dim viewSubmissions As New viewSubmissions()
        viewSubmissions.Show()
    End Sub
    Private Sub btnCreate_New_Submission_Click(sender As Object, e As EventArgs) Handles btnCreate_New_Submission.Click
        CreateNewSubmission()
    End Sub
    Private Async Sub createSubmission_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.N Then
            CreateNewSubmission()
            e.Handled = True
        End If
    End Sub
    Private Sub CreateNewSubmission()
        Dim createSubmission As New createSubmission()
        createSubmission.Show()
    End Sub
End Class
