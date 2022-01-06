using System.Windows;

namespace Process_Times
{
    public partial class GenerateDataSetWindow : WindowBase
    {
        public GenerateDataSetWindow()
        {
            InitializeComponent();
        }        
        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            // construct parameters
            EntryInput numberOfEntries = new EntryInput(NumberOfEntriesTextBox.Text, NumberOfEntriesLabel);
            RangeInput rangeA = new RangeInput(MinATextBox.Text, MaxATextBox.Text, MinALabel, MaxALabel);
            RangeInput rangeB = new RangeInput(MinBTextBox.Text, MaxBTextBox.Text, MinBLabel, MaxBLabel);

            appManager.SubmitGenerateDataSet(this, numberOfEntries, rangeA, rangeB);
        }
    }
}
