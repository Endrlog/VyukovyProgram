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

namespace VýukovýProgram
{
    /// <summary>
    /// Interakční logika pro UserControlVyjmenovanáSlova.xaml
    /// </summary>
    public partial class UserControlVyjmenovanáSlova : UserControl
    {
        Random nc = new Random();
        int num;

        public UserControlVyjmenovanáSlova()
        {
            InitializeComponent();

            DataContext = MainWindow.data;

            MainWindow.data.Životy = 3;

            num = nc.Next(0, MainWindow.data.Otázky.Count);
            MainWindow.data.Otázka = MainWindow.data.Otázky.ElementAt(num).Key;
            MainWindow.data.Odpověď = MainWindow.data.Otázky.ElementAt(num).Value;

            switch (MainWindow.data.Odpověď)
            {
                case "i":
                    btnI.Content = "i";
                    btnY.Content = "y";
                    break;
                case "y":
                    btnI.Content = "i";
                    btnY.Content = "y";
                    break;
                case "í":
                    btnI.Content = "í";
                    btnY.Content = "ý";
                    break;
                case "ý":
                    btnI.Content = "í";
                    btnY.Content = "ý";
                    break;
                case "I":
                    btnI.Content = "I";
                    btnY.Content = "Y";
                    break;
                case "Y":
                    btnI.Content = "I";
                    btnY.Content = "Y";
                    break;
                case "Í":
                    btnI.Content = "Í";
                    btnY.Content = "Ý";
                    break;
                case "Ý":
                    btnI.Content = "Í";
                    btnY.Content = "Ý";
                    break;
                default:
                    break;
            }
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.cc.Content = new UserControlSkóre();
        }

        private void btnOdpověď_Click(object sender, RoutedEventArgs e) 
        {
            if (MainWindow.data.Odpověď == (sender as Button).Content.ToString())
            {
                MainWindow.data.Skóre++;
                MainWindow.data.Otázky.Remove(MainWindow.data.Otázka);
                if (MainWindow.data.Otázky.Count == 0)
                {
                    btnEnd_Click(new object(), new RoutedEventArgs());
                    return;
                }
            }
            else
            {
                switch (MainWindow.data.Životy)
                {
                    case 3:
                        rctŽivot3.Visibility = Visibility.Collapsed;
                        break;
                    case 2:
                        rctŽivot2.Visibility = Visibility.Collapsed;
                        break;
                    case 1:
                        MainWindow.data.Životy--;
                        btnEnd_Click(new object(), new RoutedEventArgs());
                        return;
                    default:
                        break;
                }
                MainWindow.data.Životy--;
            }

            num = nc.Next(0, MainWindow.data.Otázky.Count);
            MainWindow.data.Otázka = MainWindow.data.Otázky.ElementAt(num).Key;
            MainWindow.data.Odpověď = MainWindow.data.Otázky.ElementAt(num).Value;

            switch (MainWindow.data.Odpověď)
            {
                case "i":
                    btnI.Content = "i";
                    btnY.Content = "y";
                    break;
                case "y":
                    btnI.Content = "i";
                    btnY.Content = "y";
                    break;
                case "í":
                    btnI.Content = "í";
                    btnY.Content = "ý";
                    break;
                case "ý":
                    btnI.Content = "í";
                    btnY.Content = "ý";
                    break;
                case "I":
                    btnI.Content = "I";
                    btnY.Content = "Y";
                    break;
                case "Y":
                    btnI.Content = "I";
                    btnY.Content = "Y";
                    break;
                case "Í":
                    btnI.Content = "Í";
                    btnY.Content = "Ý";
                    break;
                case "Ý":
                    btnI.Content = "Í";
                    btnY.Content = "Ý";
                    break;
                default:
                    break;
            }
        }
    }
}
