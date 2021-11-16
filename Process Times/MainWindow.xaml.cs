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
    public partial class MainWindow : Window
    {
        private readonly AppManager _app = new AppManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void enterData(object sender, RoutedEventArgs e)
        {                        
            _app.EnterData(this);
        }
        private void viewData(object sender, RoutedEventArgs e)
        {
            _app.ViewData();
        }

        private void about(object sender, RoutedEventArgs e)
        {
            _app.About();
        }

    }
}
