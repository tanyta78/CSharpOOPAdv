namespace RecyclingStation.BusinestLayer.Entities.Garbages
{
    using RecyclingStation.WasteDisposal.Interfaces;

   public abstract class Garbage:IWaste
    {
        private string name;
        private  double volumePerKg;
        private  double weight;

        public Garbage(string name,  double weight, double volumePerKg)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name
        {
            get { return this.name; }
           private set { this.name=value; }
        }

        public double VolumePerKg
        {
            get { return this.volumePerKg; }
            private set { this.volumePerKg = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }
    }
}
