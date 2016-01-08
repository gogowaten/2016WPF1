//Ctrl+Wheelで拡大縮小するWPFImageコントロール | tocsworld
//https://tocsworld.wordpress.com/2014/04/23/ctrlwheel%e3%81%a7%e6%8b%a1%e5%a4%a7%e7%b8%ae%e5%b0%8f%e3%81%99%e3%82%8bwpfimage%e3%82%b3%e3%83%b3%e3%83%88%e3%83%ad%e3%83%bc%e3%83%ab/

//やっぱりコントロールキー押しながらだとOnMouseWheelが反応しない

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wpf_test11_画像の上で右クリック押しながらホイールで画像の拡大縮小CS編
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }


    public class ZoomImage : Image
    {
        private TransformGroup _transformGroup = new TransformGroup();
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) != ModifierKeys.None)
            {
                ChangeScale(e.GetPosition(this), e.Delta);
            }
            base.OnMouseWheel(e);
            
        }
        private void ChangeScale(Point center, int delta)
        {
            double scale = (0 < delta) ? 1.1 : (1.0 / 1.1);
            _transformGroup.Children.Add(new ScaleTransform(scale, scale, center.X, center.Y));
            RenderTransform = _transformGroup;
        }
    }

}

