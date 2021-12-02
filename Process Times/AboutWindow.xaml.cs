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
    public partial class AboutWindow : WindowBase
    {   
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (appManager != null)
            {
                appManager.ShowMainWindow();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Missing _appManager reference when closing About window.");
                e.Cancel = true;

                System.Diagnostics.Debug.WriteLine("Cancel Close Window.");
            }
        }

        public void PassReferences(AppManager appManager)
        {
            appManager = appManager;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (appManager != null)
            {
                this.Close();
                appManager.ShowMainWindow();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Missing _appManager reference when closing About window.");                
            }

        }
    }
}
