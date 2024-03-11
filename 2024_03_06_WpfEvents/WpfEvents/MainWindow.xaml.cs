using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyViewModel();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dell gombra kattintottál");
            e.Handled = true;
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            ButtonBase gomb = e.Source as ButtonBase;
            if(gomb != null) MessageBox.Show(gomb.Content.ToString());
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog oDialog = new OpenFileDialog();
            if (oDialog.ShowDialog() == true)
            {
                txt.Text = oDialog.FileName;
            }
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();
            if (sDialog.ShowDialog() == true)
                txt.Text = sDialog.FileName;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(txt != null)
                e.CanExecute = !string.IsNullOrEmpty(txt.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HP");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D)
            {
                MessageBox.Show("CTR+D hot key");
            }
        }
    }
}
