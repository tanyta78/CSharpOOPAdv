namespace RecyclingStation.BusinestLayer.Contracts.Core
{
   public interface IRecyclingManager
   {
       void ProcessGarbage(string name, double weight, double volumePerKg, string type);


       void Status();

   }
}
