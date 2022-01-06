using System.Windows;

namespace Process_Times
{
    public partial class ShowAppStructureWindow : WindowBase
    {
        public ShowAppStructureWindow()
        {
            InitializeComponent();
        }
        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            ReturnToMainWindow();
        }
    }
}
