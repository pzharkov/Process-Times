using System.Windows;

namespace Process_Times
{
    public partial class EnterDataWindow : WindowBase
    {
        public EnterDataWindow()
        {
            InitializeComponent();
        }
        private void ManualEntryClick(object sender, RoutedEventArgs e)
        {
            appManager.ManualEntry(this);
        }
        private void GenerateDataSetClick(object sender, RoutedEventArgs e)
        {
            appManager.GenerateDataSet(this);
        }
    }
}
