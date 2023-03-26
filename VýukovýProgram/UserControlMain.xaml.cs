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
    /// Interakční logika pro UserControlMain.xaml
    /// </summary>
    public partial class UserControlMain : UserControl
    {
        

        public UserControlMain()
        {
            InitializeComponent();

            DataContext = MainWindow.data;
        }

        private void cmbLátka_DropDownClosed(object sender, EventArgs e)
        {
            switch (MainWindow.data.Látka)
            {
                case string a when a.Contains("Vyjmenovaná slova"):
                    Okno.Background = Brushes.Cyan;
                    break;
                default:
                    break;
            }
        }

        private void btnHrát_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.data.Skóre = 0;
            switch (MainWindow.data.Látka)
            {
                case string a when a.Contains("Vyjmenovaná slova"):
                    switch (MainWindow.data.Látka)
                    {
                        case "Vyjmenovaná slova po b":
                            MainWindow.data.Otázky = MainWindow.B;
                            break;
                        case "Vyjmenovaná slova po l":
                            MainWindow.data.Otázky = MainWindow.L;
                            break;
                        case "Vyjmenovaná slova po m":
                            MainWindow.data.Otázky = MainWindow.M;
                            break;
                        case "Vyjmenovaná slova po p":
                            MainWindow.data.Otázky = MainWindow.P;
                            break;
                        case "Vyjmenovaná slova po s":
                            MainWindow.data.Otázky = MainWindow.S;
                            break;
                        case "Vyjmenovaná slova po v":
                            MainWindow.data.Otázky = MainWindow.V;
                            break;
                        case "Vyjmenovaná slova po z":
                            MainWindow.data.Otázky = MainWindow.Z;
                            break;
                        case "Vyjmenovaná slova - opakování":
                            MainWindow.data.Otázky = new Dictionary<string, string>();
                            foreach (var i in MainWindow.B)
                            {
                                MainWindow.data.Otázky.Add(i.Key, i.Value);
                            }
                            foreach (var i in MainWindow.L)
                            {
                                MainWindow.data.Otázky.Add(i.Key, i.Value);
                            }
                            foreach (var i in MainWindow.M)
                            {
                                MainWindow.data.Otázky.Add(i.Key, i.Value);
                            }
                            foreach (var i in MainWindow.P)
                            {
                                MainWindow.data.Otázky.Add(i.Key, i.Value);
                            }
                            foreach (var i in MainWindow.S)
                            {
                                MainWindow.data.Otázky.Add(i.Key, i.Value);
                            }
                            foreach (var i in MainWindow.V)
                            {
                                MainWindow.data.Otázky.Add(i.Key, i.Value);
                            }
                            foreach (var i in MainWindow.Z)
                            {
                                MainWindow.data.Otázky.Add(i.Key, i.Value);
                            }
                            break;
                        default:
                            break;
                    }
                    MainWindow.cc.Content = new UserControlVyjmenovanáSlova();
                    break;
                default:
                    break;
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.data.Látka = ((sender as ListBox)?.SelectedItem as ListBoxItem)?.Content.ToString();
        }
    }
}
