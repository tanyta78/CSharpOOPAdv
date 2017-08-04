using System;

namespace ObjStateValidator.Annotations
{
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        public abstract bool Validate(object obj);
    }
}