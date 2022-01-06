namespace Process_Times
{
    class DataValidation
    {
        private int _validInt;
        private float _validFloat;
  
        public bool ValidProductSelected(string product)
        {
            return product == null ? false : true;
        }
        
        public bool IsValidInt(string validInt)
        {
            // if can't parse as int, negative or too large > 9999, return false, else true
            
            if (int.TryParse(validInt, out _validInt) && int.Parse(validInt) > 0 && int.Parse(validInt) < 10000)
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
