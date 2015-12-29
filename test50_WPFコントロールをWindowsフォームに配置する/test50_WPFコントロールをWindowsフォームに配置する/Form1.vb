Public Class Form1
    'WPFコントロールをWindowsフォームに配置する: .NET Tips:  C#, VB.NET
    'http://dobon.net/vb/dotnet/control/elementhost.html

    Private elementHost1 As System.Windows.Forms.Integration.ElementHost
    Private syokiP As Point



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WPFのButtonコントロールを作成する
        Dim wpfButton As New System.Windows.Controls.Button()
        wpfButton.Content = "Push!"
        AddHandler wpfButton.Click, AddressOf wpfButton_Click

        'ElementHostコントロールを作成する
        elementHost1 = New System.Windows.Forms.Integration.ElementHost()
        'コントロールの位置と大きさを設定する
        elementHost1.SetBounds(20, 10, 100, 30)

        'ElementHostのChildプロパティにWPFコントロールを設定する
        elementHost1.Child = wpfButton

        'ElementHostをフォームに配置する
        Me.Controls.Add(elementHost1)

        elementHost1 = New Integration.ElementHost
        Dim wpfPic As New System.Windows.Controls.Image
        With elementHost1
            .BackgroundImage = Image.FromFile("D:\ブログ用\collection_1.png")
            .SetBounds(50, 50, .BackgroundImage.Width, .BackgroundImage.Height)
            .Child = wpfPic
            Controls.Add(elementHost1)
        End With

        elementHost1 = New Integration.ElementHost
        wpfPic = New System.Windows.Controls.Image
        With elementHost1
            .BackgroundImage = Image.FromFile("D:\ブログ用\collection_2.png")
            .SetBounds(70, 70, .BackgroundImage.Width, .BackgroundImage.Height)
            .Child = wpfPic
            Controls.Add(elementHost1)
        End With


    End Sub

    'WPFのButtonコントロールのClickイベントハンドラ
    Private Sub wpfButton_Click(sender As Object, e As System.Windows.RoutedEventArgs)


        System.Windows.Forms.MessageBox.Show("ボタンが押されました")
    End Sub
End Class
