public class RPG:Ammunition
    {
        private const double RPGWeight = 17.1;

        public RPG(string name)
            : base(name)
        {
            this.Weight = RPGWeight;
            this.WearLevel = Weight * 100;
    }
    }
