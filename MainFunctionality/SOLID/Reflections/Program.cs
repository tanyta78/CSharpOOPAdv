namespace Reflections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Program
    {
        public static void Main()
        {

            //първото нещо което пражим е да вземем типа на обека който ще създаваме
            Type myType = typeof(ClassForReflection);

            // или по този начин
            Type mySecondTryType = Type.GetType("Reflections.ClassForReflection");


            //на типа можем да извикваме различни неща
            var assembly = myType.Assembly;

            var typeAttributes = myType.Attributes;

            var baseType = myType.BaseType;

            // var declaringMethod = myType.DeclaringMethod;
            //reflecObjects.Add(declaringMethod);
            // var declaringType = myType.DeclaringType;
            // reflecObjects.Add(declaringType);
            var name = myType.Name;

            var namespase = myType.Namespace;

            var fullname = myType.FullName;

            var fieldInfos = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                                              BindingFlags.Static);
          
            //default consructor

            var constructorDefaulth = myType.GetConstructor(Type.EmptyTypes);
            var ctor = myType.GetConstructor(new Type[]{});
            //private constructor= добре е първо да се провери дали има такъв и тогава да се извиква. тук не ми харесва че избираме 1. трчбва да има начин да проверяваме пропертитата на конструктора; ако ми трябва да видя в command pattern
           // var constructor = myType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[1]; null защото няма такъв конструктор

            //създавааме инстанция
            var instance = (ClassForReflection) ctor.Invoke(new object[] { });
            // или по добре така
            var instanceT = (ClassForReflection)Activator.CreateInstance(myType, new object[] { });

            //ако искаме конкретен метод или всички методи
            var method = myType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.Name == "DownloadAllBankAccountsInTheWorld");// търсеното име или endswith startwith etc.
            var allNonPublicMethods = myType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var allPublicMethods = myType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            //за да извикаме метода   ако не е null и да подадем масив от параметри
            //как да вземем параметрите на командата метода
            //method.Invoke(instance, new object[] {"params"});

            //как да вземем параметрите на командата метода
            var paramsOfMethod = method.GetParameters();

            //ако искаме да вземем стойност на поле; връща object и трябва да се кастне към типа
            var fieldType = fieldInfos[0].GetValue(instance).GetType();
            var fieldValue = fieldInfos[0].GetValue(instance);
        
            //ако искаме да подадем стойност на поле
            var wantedValue = "totitorumtu";
           fieldInfos[0].SetValue(instance, wantedValue);

        }



        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            var sb = new StringBuilder();
            var classType = Type.GetType(classToInvestigate);
            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            var instanceOfClass = Activator.CreateInstance(classType, new object[] { });

            var allFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var fieldInfo in allFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                var filedName = fieldInfo.Name;
                var fieldValue = fieldInfo.GetValue(instanceOfClass);
                sb.AppendLine($"{filedName} = {fieldValue}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();
            var classType = Type.GetType(className);
            var instanceOfClass = Activator.CreateInstance(classType, new object[] { });

            var allFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in allFields)
            {
                var accessModifier = field.IsPublic;
                if (accessModifier)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            var allNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            var allPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            foreach (var method in allNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in allPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();
            var classType = Type.GetType(className);

            var allNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in allNonPublicMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();
            var classType = Type.GetType(className);

            var allMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in allMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in allMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }

        public void Create()
        {/*
            string fullTypeName = type + GarbageSuffix;
            Type garbageTypeToActivate = Assembly.GetExecutingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            object[] typeArgs = new object[] { name, weight, volumePerKg };

            // IWaste waste = (IWaste)Activator.CreateInstance(garbageTypeToActivate, name,weight,volumePerKg);

            IWaste waste = (IWaste)Activator.CreateInstance(garbageTypeToActivate, typeArgs);*/
        }

    }
}