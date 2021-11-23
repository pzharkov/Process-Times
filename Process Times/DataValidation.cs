using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Times
{
    class DataValidation
    {
        private double result;
        public bool ValidProcessTimeEntered(string processTime)
        {
            // try to parse as double and see if positive number
            if (double.TryParse(processTime, out result) && double.Parse(processTime) > 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidProductSelected(string product)
        {
            if (product != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
