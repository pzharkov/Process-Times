using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Times
{
    public class SummaryStats
    {
        public int count_A;
        public int count_B;
        public int count_Total;

        public float average_A;
        public float average_B;
        public float average_Total;

        public SummaryStats(int _count_A, int _count_B, int _count_Total, float _average_A, float _average_B, float _average_Total)
        {
            count_A = _count_A;
            count_B = _count_B;
            count_Total = _count_Total;

            average_A = _average_A;
            average_B = _average_B;
            average_Total = _average_Total;
        }
    }
}
