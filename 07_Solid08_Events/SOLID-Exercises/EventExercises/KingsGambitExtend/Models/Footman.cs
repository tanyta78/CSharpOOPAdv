using System;

namespace KingsGambit.Models
{
    public class Footman : Soldier
    {
        public Footman(string name) : base(name)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs ea)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}