using System.Collections;

namespace ObjStateValidator.Annotations
{
    public class ElementsAttribute : ValidationAttribute
    {
        private int maxCount;

        public ElementsAttribute(int maxCount)
        {
            this.maxCount = maxCount;
            this.ErrorMessage = "{0} should have maximum of " + maxCount + " elements";
        }

        public int MinCount { get; set; }

        public override bool Validate(object obj)
        {
            if (obj is string)
            {
                string objAsString = (string)obj;
                if (MinCount <= objAsString.Length && objAsString.Length <= maxCount)
                {
                    return true;
                }
            }

            if (obj is ICollection)
            {
                var collection = (ICollection)obj;
                if (MinCount <= collection.Count && collection.Count <= maxCount)
                {
                    return true;
                }
            }

            //to do array, Ienumerable

            return false;
        }
    }
}