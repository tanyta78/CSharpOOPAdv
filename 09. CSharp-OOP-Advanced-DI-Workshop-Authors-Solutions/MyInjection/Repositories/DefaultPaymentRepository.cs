using System;
using MyInjection.Repositories.Interfaces;

namespace MyInjection.Repositories
{
    public class DefaultPaymentRepository : IPaymentRepository
    {
        private readonly IAnotherRepository anotherRepo;

        public DefaultPaymentRepository(IAnotherRepository anotherRepo)
        {
            Console.WriteLine("Constructor of payment repo called!");
            this.anotherRepo = anotherRepo;
        }

        public void Pay()
        {
            Console.WriteLine("payment repo called");
            this.anotherRepo.AndMe();
        }
    }
}