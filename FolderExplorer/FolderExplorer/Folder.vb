'WPF のチュートリアル
'https://msdn.microsoft.com/ja-jp/library/ee649089
'チュートリアル: WPF デザイナーでの簡単な WPF アプリケーションの作成
'https://msdn.microsoft.com/ja-jp/library/bb546972(v=vs.100)


Imports System
Imports System.IO
Imports System.Linq
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Text

Public Class Folder
    Private _folder As DirectoryInfo
    Private _subFolder As ObservableCollection(Of Folder)
    Private _files As ObservableCollection(Of FileInfo)

    Public Sub New()
        Me.FullPath = "c:\"

    End Sub

    Public ReadOnly Property Name As String
        Get
            Return Me._folder.Name
        End Get
    End Property

    Public Property FullPath As String
        Get
            Return Me._folder.FullName
        End Get
        Set(value As String)
            If Directory.Exists(value) Then
                Me._folder = New DirectoryInfo(value)
            Else
                Throw New ArgumentException("must exit", "fullPath")
            End If
        End Set
    End Property

    ReadOnly Property Files As ObservableCollection(Of FileInfo)
        Get
            If Me._files Is Nothing Then
                Me._files = New ObservableCollection(Of FileInfo)

                Dim fi As FileInfo() = Me._folder.GetFiles

                Dim i As Integer
                For i = 0 To fi.Length - 1
                    Me._files.Add(fi(i))
                Next
            End If

            Return Me._files
        End Get
    End Property

    ReadOnly Property SubFolders() As ObservableCollection(Of Folder)
        Get
            If Me._subFolder Is Nothing Then
                Try
                    Me._subFolder = New ObservableCollection(Of Folder)

                    Dim di As DirectoryInfo() = Me._folder.GetDirectories

                    Dim i As Integer
                    For i = 0 To di.Length - 1
                        Dim newFolder As New Folder
                        newFolder.FullPath = di(i).FullName
                        Me._subFolder.Add(newFolder)
                    Next
                Catch ex As Exception

                    System.Diagnostics.Trace.WriteLine(ex.Message)

                End Try
            End If

            Return Me._subFolder
        End Get
    End Property
End Class
