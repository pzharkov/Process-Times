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
    public partial class ViewDataWindow : WindowBase
    {
        public ViewDataWindow()
        {
            InitializeComponent();
        }
        private void SummaryClick(object sender, RoutedEventArgs e)
        {
            appManager.Summary(this);
        }
        private void AllDataClick(object sender, RoutedEventArgs e)
        {
            appManager.AllData(this);
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            CloseWindow(false);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            appManager.ShowMainWindow();
        }
    }
}
