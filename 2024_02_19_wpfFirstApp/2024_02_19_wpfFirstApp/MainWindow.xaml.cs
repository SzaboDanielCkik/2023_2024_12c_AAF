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
using System.IO;
using System.IO.IsolatedStorage;

namespace _2024_02_19_wpfFirstApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnLogin.Background = new SolidColorBrush(Properties.Settings.Default.Mycolor);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //btnLogin.Background = Brushes.Green;

            Properties.Settings.Default.Mycolor = Colors.Red;
            Properties.Settings.Default.Save();
            btnLogin.Background = new SolidColorBrush(Properties.Settings.Default.Mycolor);


            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream fs = new IsolatedStorageFileStream("mentesek.txt", FileMode.Create, FileAccess.Write, isf);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(txtLogin.Text + " " + txtPass.Text);
            
            sw.Close();
            fs.Close();

            MessageBox.Show("OK");
        }
    }
}
