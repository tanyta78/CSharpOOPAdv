using MyInjection.Core.Attribites;
using MyInjection.Repositories.Interfaces;
using System;

namespace MyInjection.Repositories
{
    public class DefaultSomeRepo : ISomeInterface
    {
        public void Print()
        {
            Console.WriteLine("Something is here!!!");
        }
    }
}