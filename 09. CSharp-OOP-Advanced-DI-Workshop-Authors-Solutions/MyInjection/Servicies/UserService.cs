using MyInjection.Repositories;
using System;

namespace MyInjection.Servicies
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        private readonly ISoftUniRepository softUniRepo;

        public UserService(IUserRepository userRepo, ISoftUniRepository softUniRepo)
        {
            this.userRepo = userRepo;
            this.softUniRepo = softUniRepo;
        }

        public void Rename()
        {
            Console.WriteLine("User service called");
            Console.WriteLine("service calls user repo");
            this.userRepo.Print();
            Console.WriteLine("service also calls softuni repo");
        }
    }
}