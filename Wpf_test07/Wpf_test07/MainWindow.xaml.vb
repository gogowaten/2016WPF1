Class MainWindow
    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim BindingSource = New Person() With {.Height = 1.7, .Weight = 60}

        Dim BindingHeight As New Binding("Height")
        BindingHeight.Mode = BindingMode.OneWay
        BindingHeight.Source = BindingSource
        TextBlock1.SetBinding(TextBlock.TextProperty, BindingHeight)

        Dim BindingWeight As New Binding("Weight")
        BindingWeight.Mode = BindingMode.OneWay
        BindingWeight.Source = BindingSource
        TextBlock2.SetBinding(TextBlock.TextProperty, BindingWeight)


    End Sub
End Class

Public Class Person
    Public Property Height() As Double
    Public Property Weight() As Double

End Class