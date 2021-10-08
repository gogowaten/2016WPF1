Imports System.Windows.Controls.Primitives

Class MainWindow
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        'AddHandler thumb1.DragDelta, AddressOf tmb_DragDelta
        AddHandler thumb2.DragDelta, AddressOf tmb_DragDelta
        Dim c As New Canvas

    End Sub

    Private Sub tmb_DragDelta(sender As Object, e As DragDeltaEventArgs) 'Handles tmb.DragDelta
        Dim t As Thumb = DirectCast(sender, Thumb)
        If t Is Nothing Then Return

        textBlock1.Text = "HorizontalChange " & e.HorizontalChange.ToString
        textBlock2.Text = "VerticalChange " & e.VerticalChange.ToString
        Call UpdateTextBlock(t)

        ''Marginを変更して動かす
        'Dim mr As Thickness = t.Margin
        'mr.Left += e.HorizontalChange
        'mr.Top += e.VerticalChange
        't.Margin = mr


        '動かしたいコントロールにあらかじめCanvas.LeftやTopの指定がないと動かない
        'Canvas.LeftやTopを変更して動かす
        Canvas.SetLeft(t, Canvas.GetLeft(t) + e.HorizontalChange)
        Canvas.SetTop(t, Canvas.GetTop(t) + e.VerticalChange)

    End Sub

    Private Sub UpdateTextBlock(t As Thumb)
        textBlock3.Text = "MarginLeft " & t.Margin.Left
        textBlock4.Text = "MarginTop " & t.Margin.Top
        textBlock5.Text = "left " & Canvas.GetLeft(t)
        textBlock6.Text = "top " & Canvas.GetTop(t)

    End Sub
End Class
