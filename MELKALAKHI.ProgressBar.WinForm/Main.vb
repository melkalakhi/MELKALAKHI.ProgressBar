Imports MELKALAKHI.ProgressBar.View
Imports MELKALAKHI.ProgressBar.Presenter

Public Class Main
    Implements IProgressView

    Public Sub HideProgressBar() Implements IProgressView.HideProgressBar
        Try
            ToolStripProgressBar1.Visible = False
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Public Sub SetStatusLabel(label As String) Implements IProgressView.SetStatusLabel
        Try
            ToolStripStatusLabel1.Text = label
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Public Sub ShowProgressBar(maximum As Integer) Implements IProgressView.ShowProgressBar
        Try
            ToolStripProgressBar1.Maximum = maximum
            ToolStripProgressBar1.Visible = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Public Event Start(sender As Object, e As EventArgs) Implements IProgressView.Start

    Public Sub EnableStartButon(enabled As Boolean) Implements IProgressView.EnableStartButon
        Try
            Button1.Enabled = enabled
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            RaiseEvent Start(Me, EventArgs.Empty)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Public Sub SetProgressBarValue(value As Integer) Implements IProgressView.SetProgressBarValue
        Try
            ToolStripProgressBar1.Value = value
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim presenter = New ProgressPresenter(Me)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            RaiseEvent Cancel(Me, EventArgs.Empty)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Public Event Cancel(sender As Object, e As EventArgs) Implements IProgressView.Cancel

    Public Sub ShowCancelButon(show As Boolean) Implements IProgressView.ShowCancelButon
        Try
            Button2.Visible = show
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

End Class
