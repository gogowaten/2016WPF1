' 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

''' <summary>
''' それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    '1:イベントをそのまま使う
    'Private _clock1 As Clock = New Clock
    'Private Sub Clock_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
    '    textClock1.Text = _clock1.NowTime
    'End Sub

    'Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

    '    AddHandler _clock1.PropertyChanged, AddressOf Clock_PropertyChanged
    'End Sub


    '2:コードだけでバインドする
    Private _clock1 As Clock = New Clock
    'Private _clock4 As Clock2 = New Clock2
    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        Dim tbBind = New Binding
        With tbBind
            .Source = _clock1
            .Path = New PropertyPath("NowTime")
        End With
        textClock2.SetBinding(TextBlock.TextProperty, tbBind)

        ''テスト
        'Dim testBind = New Binding
        'With testBind
        '    .Source = _clock4
        '    .Path = New PropertyPath("NowTime")
        'End With
        'textClock4.SetBinding(TextBlock.TextProperty, testBind)
    End Sub

    ''3:XAMLでバインドの場合
    'Private _clock1 As Clock = New Clock
    'Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
    '    textClock3.DataContext = _clock1
    'End Sub



End Class




'WinRT/ Metro TIPS：文字列をコントロールにバインドするには？［Win 8/WP 8］ - ＠IT
'http://www.atmarkit.co.jp/ait/articles/1304/04/news055.html

'時刻表示
Public Class Clock
    Implements INotifyPropertyChanged

    '現在時刻を表す文字列のプロパティ"HH:mm:ss"
    Public Property NowTime As String


    '自動挿入された
    'Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    '自動挿入されたのを改変、NowTimeプロパティが変化した時に発生させるイベントの定義
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged


    Public Sub New()
        Run() '時刻監視スタート
    End Sub

    '時刻監視
    Private Async Sub Run()
        Dim kako As DateTimeOffset
        While (True)
            Await Task.Delay(10) '10ミリ秒ごとに時間チェック
            Dim ima = DateTimeOffset.Now
            If kako.Second <> ima.Second Then
                '秒が変わったらプロパティに時刻をセットしてイベントを発生させる
                NowTime = ima.ToString("HH:mm:ss")
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NowTime"))
                kako = ima
            End If
        End While
    End Sub

End Class

'Public Class Clock2
'    Public Property NowTime As String

'    Private Async Sub Run()
'        Dim kako As DateTimeOffset
'        While True
'            Await Task.Delay(10)
'            Dim ima As DateTimeOffset = DateTimeOffset.Now
'            If kako.Second <> ima.Second Then
'                NowTime = ima.ToString("HH:mm:ss")
'                kako = ima
'            End If
'        End While
'    End Sub
'End Class