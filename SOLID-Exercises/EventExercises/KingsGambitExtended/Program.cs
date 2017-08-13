using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<Soldier> army = new List<Soldier>();
        King king = new King(Console.ReadLine());

        string[] royalGuards = Console.ReadLine().Split().ToArray();
        foreach (var royalGuard in royalGuards)
        {
            var guard = new RoyalGuard(royalGuard);
            army.Add(guard);
            king.UnderAttack += guard.KingUnderAttack;
        }

        string[] footmans = Console.ReadLine().Split().ToArray();
        foreach (var footman in footmans)
        {
            var footm = new Footman(footman);
            army.Add(footm);
            king.UnderAttack += footm.KingUnderAttack;
        }

        string[] command = Console.ReadLine().Split();
        while (command[0] != "End")
        {
            switch (command[0])
            {
                case "Kill":
                    var soldier = army.FirstOrDefault(s => s.Name == command[1]);
                    king.UnderAttack -= soldier.KingUnderAttack;
                    army.Remove(soldier);
                    break;

                case "Attack":
                    king.OnUnderAttack();
                    break;
            }

            command = Console.ReadLine().Split();
        }
    }
}