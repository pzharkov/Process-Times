using System.Windows;

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
    }
}
