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

namespace Process_Times
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
            appManager = new AppManager();
        }

        private void EnterData(object sender, RoutedEventArgs e)
        {                        
            appManager.EnterData(this);
        }
        private void ViewData(object sender, RoutedEventArgs e)
        {
            appManager.ViewData(this);
        }

        private void About(object sender, RoutedEventArgs e)
        {
            appManager.About(this);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (appManager != null)
            {
                appManager.ConfirmWindowClose(Title, e, true);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Missing _appManager reference when closing Main window.");
                e.Cancel = true;

                System.Diagnostics.Debug.WriteLine("Cancel Close Window.");
            }
        }
    }
}
