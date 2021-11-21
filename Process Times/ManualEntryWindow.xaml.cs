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
    /// Interaction logic for ManualEntryWindow.xaml
    /// </summary>
    public partial class ManualEntryWindow : Window
    {
        private AppManager _appManager = null;
        public ManualEntryWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void PassReferences(AppManager appManager)
        {
            _appManager = appManager;        
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            _appManager.SubmitManualEntry(this,"Test", "Test");
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            _appManager.ConfirmCancel(Title, this, null);
        }
    }
}
