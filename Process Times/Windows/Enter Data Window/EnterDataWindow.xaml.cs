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
using System.ComponentModel;

namespace Process_Times
{
    public partial class EnterDataWindow : WindowBase
    {
        public EnterDataWindow()
        {
            InitializeComponent();
        }
        private void ManualEntryClick(object sender, RoutedEventArgs e)
        {
            appManager.ManualEntry(this);
        }
        private void GenerateDataSetClick(object sender, RoutedEventArgs e)
        {
            appManager.GenerateDataSet(this);
        }
    }
}
