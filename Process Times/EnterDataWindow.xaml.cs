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
    public partial class EnterDataWindow : WindowBase
    {
        public EnterDataWindow()
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
                System.Diagnostics.Debug.WriteLine("Missing _appManager reference when closing Enter Data window.");
                e.Cancel = true;

                System.Diagnostics.Debug.WriteLine("Cancel Close Window.");
            }
        }

        public void PassReferences(AppManager _appManager)
        {
            appManager = _appManager;
        }

        private void ManualEntryClick(object sender, RoutedEventArgs e)
        {
            appManager.ManualEntry(this);
        }
        private void GenerateDataSetClick(object sender, RoutedEventArgs e)
        {
            appManager.GenerateDataSet(this);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            appManager.ShowMainWindow();
            Close();
        }
    }
}
