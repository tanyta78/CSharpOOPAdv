public abstract class Ammunition:IAmmunition
    {
        private string name;
        private double wearLevel;
        private double weight;


        public Ammunition(string name)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = weight*100;
    }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public double WearLevel
        {
            get { return this.wearLevel; }

            set { this.wearLevel = value; }
        }

        public void DecreaseWearLevel(double wearAmount)
        {
            throw new System.NotImplementedException();
        }
    }

