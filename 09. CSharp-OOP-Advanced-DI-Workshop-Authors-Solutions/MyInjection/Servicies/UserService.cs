using MyInjection.Repositories;
using System;
using MyInjection.Repositories.Interfaces;

namespace MyInjection.Servicies
{
    public class UserService : IUserService
    {
        private readonly ISomeInterface userRepo;
        private readonly ISoftUniRepository softUniRepo;

        public UserService(ISomeInterface userRepo,
            ISoftUniRepository softUniRepo,
            DateTime myDateTime,
            string dbPath)
        {
            this.userRepo = userRepo;
            this.softUniRepo = softUniRepo;
            Console.WriteLine(dbPath);
            Console.WriteLine(myDateTime);
        }

        public void Rename()
        {
            Console.WriteLine("User service called");
            Console.WriteLine("service calls user repo");
            this.userRepo.Print();
            Console.WriteLine("service also calls softuni repo");
            this.softUniRepo.Oop();
        }
    }
}