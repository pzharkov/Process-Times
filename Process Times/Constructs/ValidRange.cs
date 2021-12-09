using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Times.Constructs
{
    public class ValidRange
    {
        public float min;
        public float max;

        public ValidRange(float _min, float _max)
        {
            min = _min;
            max = _max;
        }
    }
}
