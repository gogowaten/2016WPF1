'Thumb コントロールで Photoshop のナビゲーターを再現する | grabacr.nét
'http://grabacr.net/archives/1723

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Class MainWindow

    Private Sub MainWindow_Initialized(sender As Object, e As EventArgs) Handles Me.Initialized
        Dim img As New BitmapImage(New Uri("D:\ブログ用\作業用\NEC_2097.JPG"))
        Dim rect As New Rect(0, 0, Thumbnail.ActualWidth, Thumbnail.ActualHeight)
        CombinedGeometry.Geometry1 = New RectangleGeometry(rect)
        Me.Image.Source = img
        Me.Thumbnail.Source = img

    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
    End Sub

    Private Sub UpdateThumbnailViewport(sender As Object, e As ScrollChangedEventArgs) Handles ScrollViewer.ScrollChanged

        Dim xfactor = Thumbnail.ActualWidth / e.ExtentWidth
        Dim yfactor = Thumbnail.ActualHeight / e.ExtentHeight

        Dim left = e.HorizontalOffset * xfactor
        Dim top = e.VerticalOffset * yfactor

        Dim width = e.ViewportWidth * xfactor
        If width > Thumbnail.ActualWidth Then width = Thumbnail.ActualWidth

        Dim height = e.ViewportHeight * yfactor
        If height > Thumbnail.ActualHeight Then height = Thumbnail.ActualHeight

        Canvas.SetLeft(Viewport, left)
        Canvas.SetTop(Viewport, top)

        Viewport.Width = width
        Viewport.Height = height

        CombinedGeometry.Geometry2 = New RectangleGeometry(New Rect(left, top, width, height))
    End Sub

    Private Sub OnDragDelta(sender As Object, e As DragDeltaEventArgs) Handles Viewport.DragDelta
        With ScrollViewer
            Dim x As Double = .HorizontalOffset + (e.HorizontalChange * .ExtentWidth / Thumbnail.ActualWidth)
            Dim y As Double = .VerticalOffset + (e.VerticalChange * .ExtentHeight / Thumbnail.ActualHeight)
            .ScrollToHorizontalOffset(x)
            .ScrollToVerticalOffset(y)
        End With

    End Sub

End Class
