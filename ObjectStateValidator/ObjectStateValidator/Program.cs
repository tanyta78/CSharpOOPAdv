using ObjStateValidator;
using System;
using System.Collections.Generic;

namespace ObjectStateValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var student = new Student
            {
                FirstNAme = "Pesho",
                LastName = "Goshov",
                Age = 15,
                Marks = new List<int> { 2, 2, 2, 5 },
                Mentor = new Student
                {
                    FirstNAme = "Vankata",
                    LastName = "Peshov",
                    Age = 20,
                    Marks = new List<int> { 6, 6, 6, 6, 6 },
                }
            };

            var studentValidator = new Validator(student);

            studentValidator.Validate();

            if (!studentValidator.isValid)
            {
                foreach (var error in studentValidator.Errors)
                {
                    Console.WriteLine(error.Key);
                }
            }
        }
    }
}