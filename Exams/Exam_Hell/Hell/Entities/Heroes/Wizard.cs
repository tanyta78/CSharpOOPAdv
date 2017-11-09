public class Wizard:AbstractHero
    {
        private const long DefaultStrength = 25;
        private const long DefaultAgility = 25;
        private const long DefaultIntelligence = 100;
        private const long DefaultHitPoints = 100;
        private const long DefaultDamage = 250;

        public Wizard(string name) : base(name)
        {
            this.Name = name;
            this.Strength = DefaultStrength;
            this.Agility = DefaultAgility;
            this.Intelligence = DefaultIntelligence;
            this.HitPoints = DefaultHitPoints;
            this.Damage = DefaultDamage;

        }
}

