using System;
using System.Collections.Generic;
using System.Text;

namespace MyInjection.Repositories
{
    public class DefaultUserRepository : IUserRepository
    {
        private readonly IPaymentRepository paymentsRepo;

        private readonly ISoftUniRepository softUniRepo;

        public DefaultUserRepository(
            IPaymentRepository paymentsRepo,
            ISoftUniRepository softUniRepo)
        {
            this.paymentsRepo = paymentsRepo;
            this.softUniRepo = softUniRepo;
        }

        public void Print()
        {
            Console.WriteLine("User repository called!");
            Console.WriteLine("User repo calling payments repo");
            this.paymentsRepo.Pay();
            Console.WriteLine("User repo calling also softuni repo");
            this.softUniRepo.Oop();
        }
    }
}