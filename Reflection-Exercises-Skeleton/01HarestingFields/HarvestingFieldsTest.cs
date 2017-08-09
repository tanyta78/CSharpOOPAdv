using System.Linq;
using System.Reflection;
using System.Text;

namespace _01HarestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            //TODO put your reflection code here
            Type myType = Type.GetType("_01HarestingFields.HarvestingFields");

            var command = "";
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "public":
                        GetPublicFields(myType);
                        break;

                    case "protected":
                        GetProtectedFields(myType);
                        break;

                    case "private":
                        GetPrivateFields(myType);
                        break;

                    case "all":
                        GetAllFields(myType);
                        break;
                }
            }
        }

        public static void GetAllFields(Type myType)
        {
            var sb = new StringBuilder();

            var allFields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public |
                                                    BindingFlags.NonPublic);

            foreach (var field in allFields)
            {
                var modifier = "";
                switch (field.Attributes.ToString())
                {
                    case "Public":
                        modifier = "public";
                        break;

                    case "Family":
                        modifier = "protected";
                        break;

                    case "Private":
                        modifier = "private";
                        break;
                }
                sb.AppendLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        public static void GetPrivateFields(Type myType)
        {
            var sb = new StringBuilder();

            var allNonPublicFields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in allNonPublicFields.Where(f => f.Attributes.ToString() == "Private"))
            {
                sb.AppendLine($"private {field.FieldType.Name} {field.Name}");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        public static void GetProtectedFields(Type myType)
        {
            var sb = new StringBuilder();

            var allNonPublicFields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in allNonPublicFields.Where(f => f.Attributes.ToString() == "Family"))
            {
                sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        public static void GetPublicFields(Type myType)
        {
            var sb = new StringBuilder();

            var allNonPublicFields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

            foreach (var field in allNonPublicFields.Where(f => f.Attributes.ToString() == "Public"))
            {
                sb.AppendLine($"public {field.FieldType.Name} {field.Name}");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}