'連載： WPF入門：第4回　WPFの「リソース、スタイル、テンプレート」を習得しよう (2/3) - ＠IT
'http://www.atmarkit.co.jp/ait/articles/1009/07/news096_2.html


Class MainWindow
    Dim obj = New Button With {.Content = "butttoooonnn", .FontSize = 20, .Background = New SolidColorBrush(Colors.Blue)}
    Dim syokiP As Point


    Private Sub button_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles button.MouseLeftButtonDown, button1.MouseLeftButtonDown
        syokiP = e.GetPosition(sender)
    End Sub

    Private Sub button_MouseMove(sender As Object, e As MouseEventArgs) Handles button.MouseMove
        Dim b As Button = DirectCast(sender, Button)
        If e.LeftButton = MouseButtonState.Pressed Then
            Dim l As Double = b.Margin.Left
            Dim t As Double = b.Margin.Top
            Dim p As Point = e.GetPosition(b)
            Dim x As Double = p.X
            Dim y As Double = p.Y
            x += x - syokiP.X
            y += y - syokiP.Y
            Dim m As New Thickness(l + x, t + y, 0, 0)
            b.Margin = m
        End If
    End Sub

    Private Sub MainWindow_ContentRendered(sender As Object, e As EventArgs) Handles Me.ContentRendered
        'Dim b As New Button
        'With b
        '    .Content = "動的追加"
        'End With

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

    End Sub



    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        MsgBox("ok")
    End Sub

    Private Sub button_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles button.MouseDown
        syokiP = e.GetPosition(sender)
        MsgBox("ok")
    End Sub
End Class
