Imports System.Net.Http
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Diagnostics


Public Class createSubmission
    Private stopwatch As New Stopwatch()
    Private WithEvents timer As New Timer()
    Public Sub New()
        InitializeComponent()
        timer.Interval = 10
    End Sub
    Private Sub createSubmission_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub createSubmission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Await SubmitData()
    End Sub

    Private Async Sub createSubmission_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            ' Ctrl+S pressed, call the submit method
            Await SubmitData()
            ' Mark the event as handled
            e.Handled = True
        End If
    End Sub

    Private Async Function SubmitData() As Task
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
            btnStopwatch.Text = "Resume"
        End If

        Dim elapsed As TimeSpan = stopwatch.Elapsed
        Dim stTime = String.Format("{0:00}:{1:00}.{2:00}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds \ 10)

        Dim stName As String = txtName.Text
        Dim stEmail As String = txtEmail.Text
        Dim stPhone As String = txtPhone.Text
        Dim stLink As String = txtLink.Text

        Dim data As New With {
            .name = stName,
            .email = stEmail,
            .phone = stPhone,
            .link = stLink,
            .time = stTime
        }

        If String.IsNullOrWhiteSpace(stName) OrElse String.IsNullOrWhiteSpace(stEmail) OrElse
           String.IsNullOrWhiteSpace(stPhone) OrElse String.IsNullOrWhiteSpace(stLink) OrElse String.IsNullOrWhiteSpace(stTime) Then
            MsgBox("All fields are required.")
            Return
        End If

        ' Serialize the object to JSON using JavaScriptSerializer
        Dim jsonData As String = (New JavaScriptSerializer()).Serialize(data)
        Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

        Try
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/api/submission/submit", content)
                response.EnsureSuccessStatusCode()
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                MsgBox(responseBody)
                Me.Close()
            End Using
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Function
    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        functionStopwatch()
    End Sub
    Private Async Sub functionStopwatch_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            functionStopwatch()
            e.Handled = True
        End If
    End Sub

    Private Sub functionStopwatch()
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
            btnStopwatch.Text = "Resume"
        Else
            stopwatch.Start()
            timer.Start()
            btnStopwatch.Text = "Pause"
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        Dim elapsed As TimeSpan = stopwatch.Elapsed
        Dim formattedTime As String = String.Format("{0:00}:{1:00}.{2:00}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds \ 10)
        txtTime.Text = formattedTime
    End Sub
End Class