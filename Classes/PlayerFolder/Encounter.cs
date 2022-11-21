using DungeonRpg.Classes.Menus;
using DungeonRpg.Classes.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonRpg.Classes.PlayerFolder
{
    internal class Encounter
    {
        public Player Player { get; private set; }

        public Monster Monster { get; private set; }

        //just for ease of use
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

            //see explanation in Men for SetMonsterArt
            menu.SetMonsterArt(Monster.MonsterArt);

            do
            {     
                switch (menu.RunMenu())
                {
                    case 0:
                        Fight();
                        break;
                    case 1:
                        Console.WriteLine("Bag was selected");
                        Player.AccessBag();
                        break;
                    case 2:
                        //kinda like a pokemon battle against a trainer
                        Console.WriteLine("Ha you thought you could run?");
                        MonsterAttacks();
                        break;
                }

                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();

                if (Player.CurrentHealth <= 0)
                {
                    return;
                }

            } while (Player.CurrentHealth > 0 && Monster.CurrentHealth > 0);

            menu.ClearMonsterArt();
        }
        private void Fight()
        {
            //this takes the speed stat and determines who moves first
            //very similar to the idea of pokemon
            if (Player.Speed < Monster.Speed && Player.CurrentHealth > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"The {Monster.Name} outspeed you and attacked first");
                MonsterAttacks();
            }
            PlayerAttacks();
            if (Monster.Speed <= Player.Speed && Monster.CurrentHealth > 0)
            {
                Console.WriteLine($"You outspeed the {Monster.Name} and attacked first");
                MonsterAttacks();
            }
        }
        public void PlayerAttacks()
        {
            double damage = CalculatePlayerDamage();
            Monster.TakeDamage(damage);
            Console.WriteLine($"You attack the {Monster.Name} and do {(int)damage} damage");

            if (Monster.CurrentHealth > 0)
            {
                Console.WriteLine($"The {Monster.Name} has {Monster.CurrentHealth} Health");
            }
            else
            {
                Console.WriteLine($"{Monster.Name} is dead");
                Item drop = Monster.DetermineDrop();
                Console.WriteLine($"Recieved {drop.Name} from {Monster.Name}");
                //we have to add the drop to a list in the player, this list is later used for the bag function
                Player.AddItem(drop);
            }

            Console.WriteLine();
        }
        private double CalculatePlayerDamage()
        {
            double damage = Player.Strength + Player.CurrentWeapon.WeaponStrength;
            return damage;
        }
        public void MonsterAttacks()
        {
            //dodge chance is based on the shield, a random number from 0 - 100 is generated and if the players current shield is above it then you dodge the attack
            int DodgeChance = rnd.Next(0, 101);

            Console.WriteLine($"the {Monster.Name} attacks");

            if (Player.CurrentShield.BlockChance >= DodgeChance)
            {
                Console.WriteLine("Your Shield Blocked all the Damage");
                return;
            }

            double damage = CalculateMonsterDamage();
            Player.TakeDamage(damage);

            Console.WriteLine($"took {(int)damage} damage");

            if (Player.CurrentHealth <= 0)
            {
                return;
            }

            Console.WriteLine($"Remaining health {(int)Player.CurrentHealth}");
        }
        private double CalculateMonsterDamage()
        {
            //because i wanted some randomness I have a multiplier set up that determines how effective your blocking is
            double multiplier = rnd.NextDouble();
            double damage = Monster.Strength - (Player.CurrentShield.Defense * multiplier);

            //have to make sure to check otherwise we could return a negative number
            if(damage < 0)
            {
                Console.WriteLine("Your shield Blocked all Damage");
                return 0;
            }

            Console.WriteLine($"Your shield blocked {(int)damage} damage");
            return damage;
        }

    }
}
