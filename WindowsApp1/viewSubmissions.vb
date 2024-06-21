Imports System.Net.Http
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Web.Script.Serialization
Imports System.Reflection

Public Class viewSubmissions
    Private currentIndex As Integer = 0
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub viewSubmissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        LoadSubmissions(currentIndex)
    End Sub

    Private Async Sub LoadSubmissions(index As Integer)
        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync($"http://localhost:3000/api/submission/read/{index}")
                If response.IsSuccessStatusCode Then
                    Dim json As String = Await response.Content.ReadAsStringAsync()
                    Dim serializer As New JavaScriptSerializer()
                    Dim result As Dictionary(Of String, Object) = serializer.Deserialize(Of Dictionary(Of String, Object))(json)

                    If result.ContainsKey("index") Then
                        Dim submissionJson As String = serializer.Serialize(result("index"))
                        Dim submission As Submission = serializer.Deserialize(Of Submission)(submissionJson)
                        DisplaySubmission(submission)

                        ' Enable/disable navigation buttons based on hasNext and hasPrev flags
                        btnPrev.Enabled = If(result.ContainsKey("index-1") AndAlso CBool(result("index-1")), True, False)
                        btnNext.Enabled = If(result.ContainsKey("index+1") AndAlso CBool(result("index+1")), True, False)
                    Else
                        MessageBox.Show("Submission data not found.")
                    End If
                Else
                    MessageBox.Show($"Failed to fetch submission data/No submissions to fetch")
                End If
            Catch ex As Exception
                MessageBox.Show($"Error fetching submission data: {ex.Message}")
            End Try
        End Using
    End Sub

    Private Sub DisplaySubmission(submission As Submission)
        txtName.Text = submission.name
        txtEmail.Text = submission.email
        txtPhone.Text = submission.phone
        txtLink.Text = submission.link
        txtTime.Text = submission.time
    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        function_Prev()
    End Sub
    Private Async Sub Prev_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            function_Prev()
            e.Handled = True
        End If
    End Sub
    Private Sub function_Prev()
        currentIndex -= 1
        LoadSubmissions(currentIndex)
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        function_Next()
    End Sub
    Private Async Sub Next_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.N Then
            function_Next()
            e.Handled = True
        End If
    End Sub
    Private Sub function_Next()
        currentIndex += 1
        LoadSubmissions(currentIndex)
    End Sub
    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.DeleteAsync($"http://localhost:3000/api/submission/delete/{currentIndex}")
                response.EnsureSuccessStatusCode()
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                MsgBox(responseBody)
                LoadSubmissions(currentIndex)
            Catch ex As Exception
                MessageBox.Show($"Error deleting submission data: {ex.Message}")
            End Try
        End Using
    End Sub
End Class

Public Class Submission
    Public Property name As String
    Public Property email As String
    Public Property phone As String
    Public Property link As String
    Public Property time As String
End Class