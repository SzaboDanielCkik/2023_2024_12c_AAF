using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _2024_02_19_wpfFirstApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Mutex instMutex = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            bool ujLetrehozasa;
            instMutex = new Mutex(true, "egyedinev", out ujLetrehozasa);
            if (!ujLetrehozasa)
            {
                MessageBox.Show("Az alkalmazás már fut egy példányban.");
                Current.Shutdown();
                return;
            }
            base.OnStartup(e);
        }
    }
}
