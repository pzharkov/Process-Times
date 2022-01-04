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
        private float _validFloat;
  
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
        
        public bool IsValidInt(string validInt)
        {
            // try to parse as int32 and see if positive
            if (Int32.TryParse(validInt, out _validInt) && Int32.Parse(validInt) > 0 && Int32.Parse(validInt) < 10000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidFloat(string validFloat)
        {
            // try to parse as double and see if positive number
            if (float.TryParse(validFloat, out _validFloat) && float.Parse(validFloat) > 0f && float.Parse(validFloat) < 10000f)
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
