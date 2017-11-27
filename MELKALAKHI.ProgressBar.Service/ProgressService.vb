Imports System.Threading

Public Class ProgressService

    Public Sub DoSomeWork(progress As IProgress(Of ProgressInfo), cancellationToken As CancellationToken)

        Dim progressInfo As ProgressInfo = Nothing

        Try
            progressInfo = New ProgressInfo() With {
                .Status = ProgressStatus.START,
                .Maximum = 10,
                .Description = "Starting Process.."
            }
            progress.Report(progressInfo)


            For index = 1 To 10

                cancellationToken.ThrowIfCancellationRequested()

                Thread.Sleep(1000)

                progressInfo = New ProgressInfo() With {
                    .Status = ProgressStatus.PROGRESS,
                    .Value = index,
                    .Description = ((index / 10) * 100) & " %"
                }
                progress.Report(progressInfo)

            Next

        Finally
            progressInfo = New ProgressInfo() With {
                .Status = ProgressStatus.FINISH,
                .Description = "Finish Process"
            }
            progress.Report(progressInfo)
        End Try

    End Sub

    Public Function DoSomeWorkAsync(progress As IProgress(Of ProgressInfo), cancellationToken As CancellationToken) As Task

        Return Task.Run(Sub()
                            DoSomeWork(progress, cancellationToken)
                        End Sub)

    End Function

End Class
