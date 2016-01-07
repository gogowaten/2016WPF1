'WPF 超入門　～番外編「とある WPF の相互運用」 - (憂国のプログラマ Hatena版 改め) 周回遅れのブルース
'http://d.hatena.ne.jp/hilapon/20100603/1275583609


Public Class UserControl1
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
