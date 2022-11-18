using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.MonsterFolder
{
    internal class Monster
    {
        public string Name { get; protected set; }

        public double Strength { get; set; }
        public double Defense { get; set; }
        
        public double Speed { get; set; }
        public double MaxHealth { get; protected set; }
        public double CurrentHealth { get; set; }

        public Door Door { get; private set; }

        public string MonsterArt { get; private set; }

        public Monster(string name, double strength, double defense, double maxHealth, Door door, string monsterArt)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Door = door;
            MonsterArt = monsterArt;
        }

        public bool TakeDamage(double DamadgeTaken)
        {
            CurrentHealth = CurrentHealth - DamadgeTaken;

            if(CurrentHealth <= 0)
            {
                Console.WriteLine($"{Name} was killed");
                return true;
            }
            return false;
        }
        public void PrintMonsterArt()
        {
            Console.WriteLine();
            Console.WriteLine(MonsterArt);
            Console.WriteLine();

        }
    }
}
