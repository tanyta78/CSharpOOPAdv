using ObjStateValidator.Annotations;
using System.Collections.Generic;

namespace ObjectStateValidator
{
    public class Student
    {
        [Mandatory]
        public string FirstNAme { get; set; }

        public string LastName { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        [Elements(4)]
        public ICollection<int> Marks { get; set; }

        public Student Mentor { get; set; }
    }
}