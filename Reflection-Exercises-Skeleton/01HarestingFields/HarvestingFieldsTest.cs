using System.Collections.Generic;
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

            Type myType = Type.GetType("_01HarestingFields.HarvestingFields");
            var allFields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public |
            BindingFlags.NonPublic);

            Dictionary<string, Func<FieldInfo[]>> accModFilters = new Dictionary<string, Func<FieldInfo[]>>()
            {
                { "public",()=>allFields.Where(f => f.IsPublic).ToArray()},
                {"protected", ()=>allFields.Where(f => f.IsFamily).ToArray()},
                {"private" ,()=>allFields.Where(f => f.IsPrivate).ToArray()},
                { "all",()=>allFields}

            };

            FieldInfo[] gatheredFields;
            var command = "";
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                //switch (command)
                //{
                //    case "public":
                //       // GetPublicFields(myType);
                //        gatheredFields = allFields.Where(f => f.IsPublic).ToArray();
                //        break;

                //    case "protected":
                //        // GetProtectedFields(myType);
                //        gatheredFields = allFields.Where(f => f.IsFamily).ToArray();
                //        break;

                //    case "private":
                //        // GetPrivateFields(myType);
                //        gatheredFields = allFields.Where(f => f.IsPrivate).ToArray();
                //        break;

                //    case "all":
                //        //  GetAllFields(myType);
                //        gatheredFields = allFields;
                //        break;
                //    default:
                //        gatheredFields = null;
                //        break;
                //}

                gatheredFields = accModFilters[command]();

                string[] result = gatheredFields.Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));

                //accModFilters[command]().Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToList()
                //.ForEach(r=>Console.Writeline(r.Replace("family", "protected"));

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