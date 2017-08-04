using System;
using System.Collections;
using System.Collections.Generic;
using ObjStateValidator.Annotations;

namespace ObjStateValidator
{
    public class Validator : IValidator
    {
        private object validatableObject;
        private bool objectValidated;
        private IDictionary<string, IList<string>> errors;

        public Validator(object validatableObject)
        {
            if (validatableObject == null)
            {
                throw new ArgumentNullException("Invalid object!");
            }
            this.validatableObject = validatableObject;
            this.errors = new Dictionary<string, IList<string>>();
        }

        public void Validate()
        {
            this.objectValidated = true;
            this.Validate(this.validatableObject, String.Empty);
        }

        public bool isValid
        {
            get
            {
                if (this.objectValidated == null)
                {
                    throw new InvalidOperationException("You must invoke Validate method first");
                }
                return this.errors.Count == 0;
            }
        }

        public IDictionary<string, IList<string>> Errors
        {
            get { return this.errors; }
        }

        private void Validate(object obj, string name)
        {
            if (obj == null)
            {
                return;
            }

            var type = obj.GetType();
            foreach (var property in type.GetProperties())
            {
                var propertyName = property.Name;
                //
                var valueToValidate = property.GetValue(obj);

                var validationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
                foreach (var valAttr in validationAttributes)
                {
                    var attrAsValidationAttr = ((ValidationAttribute)valAttr);
                    var validationResult = attrAsValidationAttr.Validate(valueToValidate);

                    if (!validationResult)
                    {
                        var errorMessage = attrAsValidationAttr.ErrorMessage;
                        this.AddError(name + propertyName, String.Format(errorMessage, name + propertyName));
                    }
                }
                //to see in Stack Overflow
                if (valueToValidate != null && !(valueToValidate is ICollection) && !property.PropertyType.IsPrimitive && !(valueToValidate is string))
                {
                    this.Validate(valueToValidate, name + property + ".");
                }
            }
        }

        private void AddError(string name, string error)
        {
            if (!this.errors.ContainsKey(name))
            {
                this.errors.Add(name, new List<string>());
            }

            this.errors[name].Add(error);
        }
    }
}