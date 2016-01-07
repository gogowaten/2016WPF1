'画像の上で右クリック押しながらホイールで画像の拡大縮小

'Ctrl+Wheelで拡大縮小するWPFImageコントロール | tocsworld
'https://tocsworld.wordpress.com/2014/04/23/ctrlwheel%e3%81%a7%e6%8b%a1%e5%a4%a7%e7%b8%ae%e5%b0%8f%e3%81%99%e3%82%8bwpfimage%e3%82%b3%e3%83%b3%e3%83%88%e3%83%ad%e3%83%bc%e3%83%ab/

Class MainWindow

End Class

Public Class ZoomableImage
    Inherits Image

    Private _transformGroup As New TransformGroup
    Protected Overrides Sub OnMouseWheel(e As MouseWheelEventArgs)
        'If Keyboard.Modifiers And ModifierKeys.Control <> ModifierKeys.None Then
        '    ChangeScale(e.GetPosition(Me), e.Delta)
        'End If

        '上のCtrlキー押しながらだとOnMouseWheelが発生しないので
        '右クリック押しながらホイールにしてみた
        If e.RightButton And MouseButtonState.Pressed = MouseButtonState.Pressed Then
            'If e.RightButton = MouseButtonState.Pressed Then
            ChangeScale(e.GetPosition(Me), e.Delta)
        End If
        MyBase.OnMouseWheel(e)
    End Sub

    Private Sub ChangeScale(center As Point, delta As Integer)
        Dim scale As Double
        If 0 < delta Then
            scale = 1.1
        Else
            scale = 1.0 / 1.1
        End If
        _transformGroup.Children.Add(New ScaleTransform(scale, scale, center.X, center.Y))
        'RenderTransform = _transformGroup'こっちだと画像の中心が基準になる拡大縮小
        LayoutTransform = _transformGroup '再レイアウトされるので他のコントロールも移動する

    End Sub

    Private Sub ZoomableImage_MouseWheel(sender As Object, e As MouseWheelEventArgs) Handles Me.MouseWheel

    End Sub

End Class