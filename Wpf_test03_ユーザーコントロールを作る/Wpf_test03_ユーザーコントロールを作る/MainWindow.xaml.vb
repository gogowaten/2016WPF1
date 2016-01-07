Class MainWindow
    Private Sub btnPause_Click(sender As Object, e As RoutedEventArgs) Handles btnPause.Click
        MediaElement1.Pause()
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As RoutedEventArgs) Handles btnPlay.Click
        MediaElement1.Play()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As RoutedEventArgs) Handles btnStop.Click
        MediaElement1.Stop()
    End Sub
End Class
