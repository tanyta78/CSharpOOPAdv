public class Assassin:AbstractHero
    {
        private const long DefaultStrength = 25;
        private const long DefaultAgility = 100;
        private const long DefaultIntelligence = 15;
        private const long DefaultHitPoints = 150;
        private const long DefaultDamage = 300;

        public Assassin(string name) : base(name)
        {
            this.Name = name;
            this.Strength = DefaultStrength;
            this.Agility = DefaultAgility;
            this.Intelligence = DefaultIntelligence;
            this.HitPoints = DefaultHitPoints;
            this.Damage = DefaultDamage;

        }
}