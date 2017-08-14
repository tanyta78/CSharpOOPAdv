using System;

namespace MyInjection.Repositories
{
    public class DefaultPaymentRepository : IPaymentRepository
    {
        public void Pay()
        {
            Console.WriteLine("payment repo called");
            Console.WriteLine("No payments !!!");
        }
    }
}