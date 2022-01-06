using System.Windows.Controls;

namespace Process_Times
{
    public class EntryInput
    {
        // construct to reference single entries during validation

        public string entry;
        public Label label;

        public EntryInput(string _entry, Label _label)
        {
            entry = _entry;
            label = _label;
        }
    }
}
