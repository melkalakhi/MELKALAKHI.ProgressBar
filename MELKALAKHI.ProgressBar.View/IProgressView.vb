Public Interface IProgressView

    Event Start As EventHandler

    Event Cancel As EventHandler

    Sub EnableStartButon(enabled As Boolean)

    Sub ShowProgressBar(maximum As Integer)

    Sub SetProgressBarValue(value As Integer)

    Sub HideProgressBar()

    Sub SetStatusLabel(label As String)

    Sub ShowCancelButon(show As Boolean)

End Interface
