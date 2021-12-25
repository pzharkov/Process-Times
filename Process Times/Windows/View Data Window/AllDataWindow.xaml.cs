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
        }
    }
}
