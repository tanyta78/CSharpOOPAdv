using System;

namespace MyInjection.Repositories
{
    public class DefaultSoftUniRepository : ISoftUniRepository
    {
        private readonly IPaymentRepository paymentRepo;

        public DefaultSoftUniRepository(IPaymentRepository paymentRepo)
        {
            this.paymentRepo = paymentRepo;
        }

        public void Oop()
        {
            Console.WriteLine("softuni repo called");
            Console.WriteLine("calling payment repo");
            this.paymentRepo.Pay();
        }
    }
}