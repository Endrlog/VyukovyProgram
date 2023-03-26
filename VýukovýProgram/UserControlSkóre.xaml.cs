using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;

namespace VýukovýProgram
{
    /// <summary>
    /// Interakční logika pro UserControlSkóre.xaml
    /// </summary>
    public partial class UserControlSkóre : UserControl
    {
        public UserControlSkóre()
        {
            InitializeComponent();

            DataContext = MainWindow.data;

            if ( MainWindow.data.Životy < 3 ) 
            { 
                rctŽivot3.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.data.Životy < 2)
            {
                rctŽivot2.Visibility = Visibility.Collapsed;
            }
            if (MainWindow.data.Životy < 1)
            {
                rctŽivot1.Visibility = Visibility.Collapsed;
            }

            switch (MainWindow.data.Látka)
            {
                case string a when a.Contains("Vyjmenovaná slova"):
                    Okno.Background = Brushes.Cyan;
                    RecSkóre1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00B8B8");
                    RecSkóre2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00B8B8");
                    RecŽivoty1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00B8B8");
                    RecŽivoty2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00B8B8");
                    break;
                default:
                    break;
            }
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.cc.Content = new UserControlMain();
        }

        private void btnUložit_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Image";
            dlg.DefaultExt = ".png";
            dlg.Filter = "Image Files|*.png";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == true)
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)MainWindow.cc.ActualWidth, (int)MainWindow.cc.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                rtb.Render(MainWindow.cc);

                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));

                using (FileStream fs = (FileStream)dlg.OpenFile())
                {
                    encoder.Save(fs);
                }
            }
        }
    }
}
