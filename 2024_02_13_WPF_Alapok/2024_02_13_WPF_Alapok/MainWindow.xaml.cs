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

namespace _2024_02_13_WPF_Alapok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*Button gomb = new Button();
            gomb.Width = 200;
            gomb.Height = 32;
            gomb.Content = "Gomb";
            
            GridMain.Children.Add(gomb);*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Szöveg");
        }

        private void Btn_MouseE(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            b.Background = Brushes.Red;
        }
    }
}
