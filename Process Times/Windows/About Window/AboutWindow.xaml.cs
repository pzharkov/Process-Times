using System.Windows;

namespace Process_Times
{    
    public partial class AboutWindow : WindowBase
    {   
        public AboutWindow()
        {
            InitializeComponent();
        }
        private void ShowDiagram(object sender, RoutedEventArgs e)
        {
            appManager.ShowDiagram(this);
        }
    }

}
