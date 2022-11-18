using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonRpg.Classes.PlayerFolder
{
    internal class Encounter
    {
        public Player Player { get; private set; }

        public Monster Monster { get; private set; }

        private Random rnd = new Random();

        public Encounter(Player player, Monster monster)
        {
            Player = player;
            Monster = monster;
        }
        public void DetermineFirstAction()
        {
            
            Console.WriteLine($"You have come accross a {Monster.Name}");
            Monster.PrintMonsterArt();
            Console.WriteLine("Press any Key to Continue");
            Console.ReadKey();

            List<string> options1 = new List<string>()
            {
            "Fight",
            "Bag",
            "Run",
            };
            Menu menu = new Menu($"Choose an option against the {Monster.Name}", options1);
            menu.SetMonsterArt(Monster.MonsterArt);

            do
            {

                if (Player.Speed < Monster.Speed)
                {
                    MonsterAttacks();
                }
                switch (menu.RunMenu())
                {

                    case 0:
                        PlayerAttacks();
                        break;
                    case 1:
                        Console.WriteLine("Bag was selected");
                        break;
                    case 2:
                        Console.WriteLine("Ha you thought you could run?");
                        break;
                }
                if(Monster.Speed <= Player.Speed)
                {
                    MonsterAttacks();
                }

                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();
            } while (Player.CurrentHealth > 0 && Monster.CurrentHealth > 0);

            menu.ClearMonsterArt();
        }
        public void PlayerAttacks()
        {
            double damage = CalculatePlayerDamage();
            Monster.TakeDamage(damage);
            Console.WriteLine($"You attack the {Monster.Name} and do {(int)damage} ");
            if (Monster.CurrentHealth > 0)
            {
                Console.WriteLine($"Max health is {Monster.MaxHealth} current health is {Monster.CurrentHealth}");
            }
            else
            {
                Console.WriteLine($"Monster is dead");
            }
            Console.WriteLine();
        }
        private double CalculatePlayerDamage()
        {
            double damage = Player.BaseStrength + Player.CurrentWeapon.WeaponStrength;
            return damage;
        }
        public void MonsterAttacks()
        {
            double damage = CalculateMonsterDamage();
            Player.CurrentHealth -= damage;

            Console.WriteLine($"took {damage} damage");
            Console.WriteLine($"Remaining health {Player.CurrentHealth}");
        }
        private double CalculateMonsterDamage()
        {
            double multiplier = rnd.NextDouble();
            double damage = Monster.Strength - (Player.CurrentShield.Defense * multiplier);
            Console.WriteLine($"Your shield blocked {(int)damage} damage");
            return damage;
        }
    }
}
