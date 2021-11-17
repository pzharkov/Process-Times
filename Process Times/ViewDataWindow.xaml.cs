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
using System.Windows.Shapes;
using System.ComponentModel;

namespace Process_Times
{
    public partial class ViewDataWindow : Window
    {

        private AppManager _appManager = null;
        public ViewDataWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_appManager != null)
            {
                TryToClose(e);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Missing _appManager reference when closing View Data window.");
                e.Cancel = true;
            }
        }

        public void PassReferences(AppManager appManager)
        {
            _appManager = appManager;
        }

        private void TryToClose(CancelEventArgs e)
        {
            if (!_appManager.ConfirmWindowClose(this.Title))
            {
                e.Cancel = true;
                System.Diagnostics.Debug.WriteLine("Cancel Close Window.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Close View Data window.");
                _appManager.ShowMainWindow();
            }
        }
    }
}
