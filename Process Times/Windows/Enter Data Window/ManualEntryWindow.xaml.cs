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
    public partial class ManualEntryWindow : WindowBase
    {        
        public ManualEntryWindow()
        {
            InitializeComponent();
        }        
        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            string _product = null;

            if (ProductListBox.SelectedItem != null)
            {
                _product = ProductListBox.SelectedItem.ToString();
            }


            EntryInput processTime = new EntryInput(ProcessTimeTxtBox.Text, ProcessTimeLabel);
            EntryInput productSelected = new EntryInput(_product, ProductLabel);

            appManager.SubmitManualEntry(this, processTime, productSelected);
        }
    }
}
