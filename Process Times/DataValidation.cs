using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Times
{
    class DataValidation
    {
        private int _validInt;
        private double _validDouble;

        #region Manual Entry Validation       
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
        
        public bool IsValidInt(string validInt)
        {
            // try to parse as int32 and see if positive
            if (Int32.TryParse(validInt, out _validInt) && Int32.Parse(validInt) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidDouble(string validDouble)
        {
            // try to parse as double and see if positive number
            if (double.TryParse(validDouble, out _validDouble) && double.Parse(validDouble) > 0f)
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
