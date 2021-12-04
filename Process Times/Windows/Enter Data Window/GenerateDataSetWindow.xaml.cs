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
    /// <summary>
    /// Interaction logic for GenerateDataSetWindow.xaml
    /// </summary>
    public partial class GenerateDataSetWindow : WindowBase
    {
        public GenerateDataSetWindow()
        {
            InitializeComponent();
        }        
        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            // construct parameters
            ValidEntry numberOfEntries = new ValidEntry(NumberOfEntriesTextBox.Text, NumberOfEntriesLabel);
            ValidRange rangeA = new ValidRange(MinATextBox.Text, MaxATextBox.Text, MinALabel, MaxALabel);
            ValidRange rangeB = new ValidRange(MinBTextBox.Text, MaxBTextBox.Text, MinBLabel, MaxBLabel);

            appManager.SubmitGenerateDataSet(this, numberOfEntries, rangeA, rangeB);
        }
    }
}
