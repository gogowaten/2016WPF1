Imports System.Collections.ObjectModel
Imports System.ComponentModel
'動かん、データバインディングの設定の画面が微妙に違っていてわからん

'Windowsエクスプローラ型アプリケーション - ＠IT
'http://www.atmarkit.co.jp/fdotnet/chushin/wpfsluipattern_01/wpfsluipattern_01_02.html


Class MainWindow

End Class



Public Class File
    Public Property Name As String
    Public Property Type As String
    Public Property Size As String
    Public Property ImageSize As String
    Public Property CreateDate As String
End Class


Public Class MainViewModel
    Implements INotifyPropertyChanged

    Public Property Files As ObservableCollection(Of File)

    Private Property _selectedFile As File
    Public Property SelectedFile As File
        Get
            Return _selectedFile
        End Get
        Set(value As File)
            _selectedFile = value
            NotifyPropertyChanged("SelectedFile")
        End Set
    End Property


    Public Sub New()
        Dim files = New ObservableCollection(Of File)
        For index As Integer = 1 To 10
            files.Add(New File With {.Name = "Image.jpg", .ImageSize = "256 x 256", .Type = "JPEG イメージ", .Size = "256 KB", .CreateDate = "2011/11/11 11:11"})
        Next
        Me.Files = files

    End Sub

    Private Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class