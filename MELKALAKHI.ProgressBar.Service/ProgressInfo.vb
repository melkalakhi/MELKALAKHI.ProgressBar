Public Class ProgressInfo

    Private _Status As ProgressStatus
    Public Property Status() As ProgressStatus
        Get
            Return _Status
        End Get
        Set(ByVal value As ProgressStatus)
            _Status = value
            Select Case _Status
                Case ProgressStatus.START, ProgressStatus.FINISH
                    Me.Value = 0
            End Select
        End Set
    End Property


    Property Value As Integer

    Property Maximum As Integer

    Property Description As String

End Class

Public Enum ProgressStatus

    START
    PROGRESS
    FINISH

End Enum
