using System.Collections.Generic;

namespace ObjStateValidator
{
    public interface IValidator
    {
        void Validate();

        bool isValid { get; }

        IDictionary<string, IList<string>> Errors { get; }
    }
}