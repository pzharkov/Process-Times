using System.Windows;

namespace Process_Times
{
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
