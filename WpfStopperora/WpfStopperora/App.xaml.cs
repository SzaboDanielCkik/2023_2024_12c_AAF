using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfStopperora
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Mutex peldaMutex = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            bool ujLetrehozasa;
            peldaMutex = new Mutex(true, "stopper", out ujLetrehozasa);
            if (!ujLetrehozasa)
            {
                MessageBox.Show("Az alkalmazás már fut! Nem tudja mégegyszer elindítani!");
                Current.Shutdown();
                return;
            }
            base.OnStartup(e);
        }
    }
}
