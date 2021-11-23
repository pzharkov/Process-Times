using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Process_Times
{
    public class ValidEntry
    {
        // construct to reference single entries during validation

        public string entry;
        public Label label;

        public ValidEntry(string _entry, Label _label)
        {
            entry = _entry;
            label = _label;
        }

    }
}
