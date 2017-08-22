namespace Attributies
{
    using System;
    using System.Linq;

    public class Program
    {
       public static void Main(string[] args)
        {
            var cmd = Console.ReadLine();

            var attribute = typeof(ClassWithAttribute).GetCustomAttributes(typeof(CustomAttribute), true)
                .FirstOrDefault() as CustomAttribute;

            while (cmd != "END")
            {
                switch (cmd)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attribute.Author}");
                        break;

                    case "Revision":
                        Console.WriteLine($"Revision: {attribute.Revision}");
                        break;

                    case "Description":
                        Console.WriteLine($"Class description: {attribute.Description}");
                        break;

                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                        break;
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
