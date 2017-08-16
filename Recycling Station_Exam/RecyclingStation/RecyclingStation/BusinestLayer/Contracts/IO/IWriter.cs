namespace RecyclingStation.BusinestLayer.Contracts.IO
{
   public interface IWriter
   {

       void GatherOutput(string outputToGather);

       void WriteOutput();
   }
}
