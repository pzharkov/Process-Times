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

namespace Process_Times
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : WindowBase
    {
        public SummaryWindow()
        {
            InitializeComponent();
        }
        public void UpdateSummary(SummaryStats stats)
        {
            Count_A.Content = stats.count_A;
            Count_B.Content = stats.count_B;
            Count_Total.Content = stats.count_Total;

            Average_A.Content = stats.average_A;
            Average_B.Content = stats.average_B;
            Average_Total.Content = stats.average_Total;
        }
        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            ReturnToMainWindow();
        }
    }
}
