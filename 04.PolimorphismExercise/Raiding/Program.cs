using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBaseHero> heros = new List<IBaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heros.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Druid")
                {
                    IBaseHero druid = new Druid(heroName);
                    heros.Add(druid);
                }

                else if (heroType == "Paladin")
                {
                    IBaseHero paladin = new Paladin(heroName);
                    heros.Add(paladin);
                }
                else if (heroType == "Rogue")
                {
                    IBaseHero rogue = new Rogue(heroName);
                    heros.Add(rogue);
                }
                else if (heroType == "Warrior")
                {
                    IBaseHero warrior = new Warrior(heroName);
                    heros.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }

            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroSum = 0;

            foreach (var hero in heros)
            {
                heroSum = heros.Sum(x => x.Power);
                Console.WriteLine(hero.CastAbility());
            }

            if (heroSum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
