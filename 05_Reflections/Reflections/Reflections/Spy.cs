using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        Type myType = Type.GetType(className);

        StringBuilder sb = new StringBuilder();

        string nameOfTheClass = myType.Name;

        sb.AppendLine($"Class under investigation: {nameOfTheClass}");

        Object inst = Activator.CreateInstance(myType, new object[] { });

        FieldInfo[] allFields = myType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (FieldInfo field in allFields.Where(f => fieldsNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(inst)}");
        }

        return sb.ToString().Trim();
    }
}