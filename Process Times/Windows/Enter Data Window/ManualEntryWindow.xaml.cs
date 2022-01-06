using System.Windows;
using System.Windows.Controls;

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
                _product = (ProductListBox.SelectedItem as ListBoxItem).Content.ToString();
            }


            EntryInput processTime = new EntryInput(ProcessTimeTxtBox.Text, ProcessTimeLabel);
            EntryInput productSelected = new EntryInput(_product, ProductLabel);

            appManager.SubmitManualEntry(this, processTime, productSelected);
        }
    }
}
