using System.Windows;
using System.Windows.Controls;

namespace Process_Times
{
    public partial class AllDataWindow : WindowBase
    {
        public readonly DataGrid dataGrid;
        public AllDataWindow()
        {
            InitializeComponent();

            dataGrid = AllDataGrid;
        }
        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            ReturnToMainWindow();
        }
        public void UpdateHeaders()
        {
            AllDataGrid.Columns[0].Header = "ID";
            AllDataGrid.Columns[1].Header = "Product";
            AllDataGrid.Columns[2].Header = "Process Time";
            AllDataGrid.Columns[0].Width = 40;
            AllDataGrid.Columns[1].Width = 60;
            AllDataGrid.Columns[2].Width = 120;
        }
    }
}
