using System;

namespace ObjStateValidator.Annotations
{
    public class RangeAttribute : ValidationAttribute
    {
        private int min;
        private int max;

        public RangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
            this.ErrorMessage = "{} should be between" + min + "and" + max;
        }

        public override bool Validate(object obj)
        {
            if (obj is int)
            {
                var objAsInt = (int)obj;
                if (objAsInt >= min && objAsInt <= max)
                {
                    return true;
                }
            }
            return false;
        }
    }
}