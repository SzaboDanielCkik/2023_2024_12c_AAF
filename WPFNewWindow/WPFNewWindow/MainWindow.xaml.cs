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

namespace WPFNewWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DetailsWindow dw = new DetailsWindow();
            dw.Owner = this; //Ha bezárom a szülő alkalmazást akkor bezárja az utód alkalmazást is.
            dw.ShowDialog(); // Nem tudsz kikattintani a háttérben lévő fő ablakra! Addig míg a mellék ablakot be nem zárjuk, addig a fő ablak elérhetetlen.
            //dw.Show();
        }
    }
}
