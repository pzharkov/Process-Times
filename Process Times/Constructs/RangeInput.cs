using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Process_Times
{
    public class RangeInput
    {
        // construct to reference ranges during validation process

        public string min;
        public string max;
        public Label minLabel;
        public Label maxLabel;

        public RangeInput(string _min, string _max, Label _minLabel, Label _maxLabel)
        {
            min = _min;
            max = _max;
            minLabel = _minLabel;
            maxLabel = _maxLabel;
        }
    }
}
