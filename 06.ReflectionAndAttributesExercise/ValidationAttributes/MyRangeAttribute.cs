using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxvalue;

        public MyRangeAttribute(int minValue, int maxvalue)
        {
            this.minValue = minValue;
            this.maxvalue = maxvalue;
        }

        public override bool IsValid(object obj)
        {
            int inputInteger = (int)obj;

            if (inputInteger < minValue || inputInteger > maxvalue)
            {
                return false;
            }

            return true;
        }
    }
}
