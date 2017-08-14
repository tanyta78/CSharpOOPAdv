using MyInjection.Core;
using MyInjection.Repositories;
using MyInjection.Servicies;

namespace MyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var paymentRepo = new DefaultPaymentRepository();
            //var softUniRepo = new DefaultSoftUniRepository(paymentRepo);
            //var userRepo = new DefaultUserRepository(paymentRepo, softUniRepo);
            //var userService = new UserService(userRepo, softUniRepo);

            var container = new Container();
            var userService = container.Get<IUserService>();

            userService.Rename();
        }
    }
}