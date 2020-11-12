Class MainWindow
    Private repeatCount As Integer
    Private Sub repeatButton1_Click(sender As Object, e As RoutedEventArgs) 'Handles repeatButton1.Click
        repeatCount += 1
        textBlock3.Text = repeatCount.ToString
    End Sub

    Private Sub radio_Checked(sender As Object, e As RoutedEventArgs) ' Handles radio1.Checked
        Dim btn As RadioButton = DirectCast(sender, RadioButton)
        textBlock2.Text = btn.Content.ToString
    End Sub
End Class
