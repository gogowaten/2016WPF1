'特集： UWPとは何か ： Windowsフォーム開発者のためのWindows 10 UWPアプリ開発入門（前編） (6/6) - ＠IT
'http://www.atmarkit.co.jp/ait/articles/1509/29/news020_6.html


' 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

''' <summary>
''' それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        textBlock.Text = DateTimeOffset.Now.ToString("HH:mm:ss")
    End Sub

End Class


