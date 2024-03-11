using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfEvents
{
    public class MyViewModel
    {
        private ICommand someCommand;
        public ICommand SomeCommand
        {
            get {
                return someCommand ?? (someCommand = new ActionCommand(() =>
                {
                    MessageBox.Show("SomeCommand Hotkey run");
                }));
            }
        }
    }
}
