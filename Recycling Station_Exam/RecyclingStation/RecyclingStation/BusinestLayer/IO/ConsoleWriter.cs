namespace RecyclingStation.BusinestLayer.IO
{
    using System;
    using System.Text;
    using RecyclingStation.BusinestLayer.Contracts.IO;

   public class ConsoleWriter:IWriter
   {
       private StringBuilder outputBuilder;

       public ConsoleWriter()
            :this(new StringBuilder())
       {
           
       }

       public ConsoleWriter(StringBuilder outputBuilder)
       {
           this.OutputBuilder = outputBuilder;
       }

       public StringBuilder OutputBuilder
       {
           get { return this.outputBuilder; }
           private set { this.outputBuilder = value; }
       }

        public void GatherOutput(string outputToGather)
        {
            this.outputBuilder.AppendLine(outputToGather);
        }

        public void WriteOutput()
        {
            Console.Write(this.OutputBuilder);
        }
    }
}
