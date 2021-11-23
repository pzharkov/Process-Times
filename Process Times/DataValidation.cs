using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Times
{
    class DataValidation
    {
        private double _processTime;
        private double _minTimeA;
        private double _maxTimeA;
        private double _minTimeB;
        private double _maxTimeB;

        private int _numberOfEntries;

        #region Manual Entry Validation
        public bool ValidProcessTimeEntered(string processTime)
        {
            // try to parse as double and see if positive number
            if (double.TryParse(processTime, out _processTime) && double.Parse(processTime) > 0f)
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
        #endregion

        #region Generate Data Set Validation

        public bool ValidNumberOfEntries(string numberOfEntries)
        {
            // try to parse as int and see if positive
            if (Int32.TryParse(numberOfEntries, out _numberOfEntries) && Int32.Parse(numberOfEntries) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}
