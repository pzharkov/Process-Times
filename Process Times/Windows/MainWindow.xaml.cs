using System.Windows;

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
            appManager.Initialization();
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
    }
}
