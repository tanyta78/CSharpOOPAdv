using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineParsedMethodParameters
{
    using System.Reflection;

    class Engine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private readonly MethodInfo[] RecyclingManagerMethods;

        private IReader reader;
        private IWriter writer;

        private IRecyclingManager recyclingManager;

        public Engine(IReader reader, IWriter writer, IRecyclingManager recyclingManager)
        {
            this.reader = reader;
            this.writer = writer;
            this.recyclingManager = recyclingManager;
            this.RecyclingManagerMethods = this.recyclingManager.GetType().GetMethods();
        }


        public void Run()
        {
            string inputLine;

            while ((inputLine = this.reader.ReadLine()) != TerminatingCommand)
            {
                string[] cmdArgs = this.SplitStringByChar(inputLine, ' ');

                string methodName = cmdArgs[0];
                string[] methodNonParsedParams = default(string[]);

                if (cmdArgs.Length == 2)
                {
                    methodNonParsedParams = this.SplitStringByChar(cmdArgs[1], '|');
                }

                MethodInfo methodToInvoke = this.RecyclingManagerMethods.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParams = methodToInvoke.GetParameters();

                object[] parsedParams = new object[methodParams.Length];

                for (int currentConversion = 0; currentConversion < methodParams.Length; currentConversion++)
                {
                    Type currentParamType = methodParams[currentConversion].ParameterType;

                    string toConvert = methodNonParsedParams[currentConversion];

                    parsedParams[currentConversion] = Convert.ChangeType(toConvert, currentParamType);
                }

                object result = methodToInvoke.Invoke(this.recyclingManager, parsedParams);


                this.writer.GatherOutput(result.ToString());
            }

            this.writer.WriteOutput();
        }

        private string[] SplitStringByChar(string toSplit, params char[] toSplitBy)
        {
            return toSplit.Split(toSplitBy, StringSplitOptions.RemoveEmptyEntries);
        }
    }

    internal interface IRecyclingManager
    {
    }

    internal interface IWriter
    {
        void GatherOutput(string toString);
        void WriteOutput();
    }

    internal interface IReader
    {
        string ReadLine();
    }
}
}
