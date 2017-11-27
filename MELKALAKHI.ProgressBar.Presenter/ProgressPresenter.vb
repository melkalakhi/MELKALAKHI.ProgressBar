Imports MELKALAKHI.ProgressBar.View
Imports MELKALAKHI.ProgressBar.Service
Imports System.Threading

Public Class ProgressPresenter

    Private _View As IProgressView
    Private _Service As ProgressService
    Private _CancellationTokenSource As CancellationTokenSource

    Public Sub New(view As IProgressView)

        _View = view
        _Service = New ProgressService()

        AddHandlers()
        Initialize()

    End Sub

    Private Sub AddHandlers()
        AddHandler _View.Start, AddressOf OnStart
        AddHandler _View.Cancel, AddressOf OnCancel
    End Sub

    Private Sub Initialize()
        _View.EnableStartButon(True)
        _View.HideProgressBar()
        _View.SetStatusLabel("")
        _View.ShowCancelButon(False)
    End Sub

    Private Sub OnStart(sender As Object, e As EventArgs)
        Dim progress = New Progress(Of ProgressInfo)(AddressOf OnProgressReport)
        _CancellationTokenSource = New CancellationTokenSource()
        _Service.DoSomeWorkAsync(progress, _CancellationTokenSource.Token)
    End Sub

    Private Sub OnProgressReport(progressInfo As ProgressInfo)

        _View.SetProgressBarValue(progressInfo.Value)

        Select Case progressInfo.Status
            Case ProgressStatus.START
                _View.ShowProgressBar(progressInfo.Maximum)
                _View.EnableStartButon(False)
                _View.ShowCancelButon(True)
            Case ProgressStatus.FINISH
                _View.HideProgressBar()
                _View.EnableStartButon(True)
                _View.ShowCancelButon(False)
        End Select

        _View.SetStatusLabel(progressInfo.Description)

    End Sub

    Private Sub OnCancel(sender As Object, e As EventArgs)
        _CancellationTokenSource.Cancel()
        _View.SetStatusLabel("Waiting to cancel ..")
    End Sub

End Class
