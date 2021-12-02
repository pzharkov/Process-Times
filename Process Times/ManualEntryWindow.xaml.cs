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
    public partial class ManualEntryWindow : WindowBase
    {
        private string _product = null;
        

        public ManualEntryWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            _product = null;

            if (ProductListBox.SelectedItem != null)
            {
                _product = ProductListBox.SelectedItem.ToString();
            }

            ValidEntry processTime = new ValidEntry(ProcessTimeTxtBox.Text, ProcessTimeLabel);
            ValidEntry productSelected = new ValidEntry(_product, ProductLabel);

            appManager.SubmitManualEntry(this, processTime, productSelected);
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (ProductListBox.SelectedItem == null && ProcessTimeTxtBox.Text == "")
            {
                Close();
            }
            else
            {
                appManager.ConfirmCancel(this);
            }
            
        }
        
    }
}
