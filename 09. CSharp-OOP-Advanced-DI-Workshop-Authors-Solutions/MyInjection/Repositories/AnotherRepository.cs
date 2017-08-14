using MyInjection.Repositories.Interfaces;
using System;

namespace MyInjection.Repositories
{
    public class AnotherRepository : IAnotherRepository
    {
        public void AndMe()
        {
            Console.WriteLine("I was added later, and the app should work too!");
        }
    }
}