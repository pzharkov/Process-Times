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
    public partial class AllDataWindow : Window
    {
        private AppManager _appManager = null;
        private ViewDataWindow _owner = null;

        public AllDataWindow()
        {
            InitializeComponent();
        }
        public void PassReferences(AppManager appManager, ViewDataWindow owner)
        {
            _appManager = appManager;
            _owner = owner;
        }

        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            _owner.Close();
            _appManager.ShowMainWindow();

            Close();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
