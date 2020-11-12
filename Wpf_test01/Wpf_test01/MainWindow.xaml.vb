Class MainWindow
    'PictureBoxの代わりのImageをマウスドラッグできるようにしてみたけど
    'コントロール同士が重なるとフォーカスが上にあるコントロールに移ってしまい
    'ドラッグしているコントロールが入れ替わってしまう

    'マウスドラッグに特化したThumbってコントロール？があるみたい




    Private syokiP As Point
    Private IsDrag As Boolean

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        label.Content = "button clecked!"

        Dim img As New BitmapImage
        img.BeginInit()
        img.UriSource = New Uri("D:\ブログ用\collection_3.png")
        img.EndInit()

        image1.Source = img
        image1.Width = img.PixelWidth
        With image1
            .Height = img.Height
            .Focusable = True
        End With

        img = New BitmapImage
        With img
            .BeginInit()
            .UriSource = New Uri("D:\ブログ用\collection_4.png")
            .EndInit()
        End With
        With image2
            .Source = img
            .Width = img.Width
            .Height = img.Height
            .Focusable = True
            AddHandler .MouseLeftButtonDown, AddressOf image_MouseLeftButtonDown
            AddHandler .MouseMove, AddressOf image_MouseMove
            AddHandler .MouseUp, AddressOf image1_MouseUp

        End With

    End Sub

    Private Sub image_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles image1.MouseDown
        'If e.LeftButton = MouseButtonState.Pressed Then
        '    syokiP = e.GetPosition(sender)
        '    IsDrag = True
        'End If
    End Sub

    Private Sub image_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles image1.MouseLeftButtonDown
        syokiP = e.GetPosition(sender)
        Dim img As Image = DirectCast(sender, Image)
        img.Focus()
        'IsDrag = True
    End Sub

    Private Sub image_MouseMove(sender As Object, e As MouseEventArgs) Handles image1.MouseMove
        If e.LeftButton <> MouseButtonState.Pressed Then ' And IsDrag = False Then
            Return
        End If

        Dim img As Image = DirectCast(sender, Image)
        If Not img.IsFocused Then Return

        Dim nt As New Thickness
        Dim np As Point = e.GetPosition(img)

        nt.Top = np.Y - syokiP.Y + img.Margin.Top
        nt.Left = np.X - syokiP.X + img.Margin.Left

        img.Margin = nt


    End Sub

    Private Sub image1_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles image1.MouseUp
        IsDrag = False
    End Sub

    Private Sub image1_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles image1.GotMouseCapture
        MsgBox("mouse capture")
    End Sub

    Private Sub image1_IsMouseDirectlyOverChanged(sender As Object, e As DependencyPropertyChangedEventArgs) Handles image1.IsMouseDirectlyOverChanged

    End Sub

    Private Sub image1_LostMouseCapture(sender As Object, e As MouseEventArgs) Handles image1.LostMouseCapture
        MsgBox("Lost mouse capture")
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        'image2.panel.zindex = 0

    End Sub
End Class
