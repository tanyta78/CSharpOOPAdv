namespace RecyclingStation.BusinestLayer.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using RecyclingStation.BusinestLayer.Contracts.Core;
    using RecyclingStation.BusinestLayer.Contracts.IO;

    public class Engine : IEngine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private readonly MethodInfo[] RecyclingManagerMethods;

        private IReader reader;
        private IWriter writer;

        private IRecyclingManager recyclingManager;

        public Engine(IReader reader, IWriter writer, IRecyclingManager recyclingManager)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.RecyclingManager = recyclingManager;
            this.RecyclingManagerMethods = this.RecyclingManager.GetType().GetMethods();
        }

        private IReader Reader
        {
            get { return this.reader; }
            set { this.reader = value; }
        }

        private IWriter Writer
        {
            get { return this.writer; }
            set { this.writer = value; }
        }

        public IRecyclingManager RecyclingManager
        {
            get { return this.recyclingManager; }
            set { this.recyclingManager = value; }
        }


        public void Run()
        {
            string inputLine;

            while ((inputLine = this.Reader.ReadLine()) != TerminatingCommand)
            {
                string[] cmdArgs = this.SplitStringByChar(inputLine, ' ');

                string methodName = cmdArgs[0];
                string[] methodNonParsedParams = this.SplitStringByChar(cmdArgs[1], '|');

                MethodInfo methodToInvoke = this.RecyclingManagerMethods.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParams = methodToInvoke.GetParameters();

                object[] parsedParams = new object[methodParams.Length];

                for (int currentConversion = 0; currentConversion < methodParams.Length; currentConversion++)
                {
                    Type currentParamType = methodParams[currentConversion].GetType();

                    string toConvert = methodNonParsedParams[currentConversion];

                    parsedParams[currentConversion] = Convert.ChangeType(toConvert, currentParamType);

                }

                methodToInvoke.Invoke(this.RecyclingManager, parsedParams);




            }




        }

        private string[] SplitStringByChar(string toSplit, params char[] toSplitBy)
        {
            return toSplit.Split(toSplitBy, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
