using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.MonsterFolder
{
    internal class Monster : IEntity
    {
        public string Name { get; protected set; }
        public double Strength { get; set; }
        public double Speed { get; set; }
        public double MaxHealth { get; protected set; }
        public double CurrentHealth { get; set; }
        public Door Door { get; private set; }
        public string MonsterArt { get; private set; }

        private Random rnd = new Random();
        public List<Item> Drops { get; private set; } = new();

        public Monster(string name, double strength, double maxHealth,double speed ,Door door, string monsterArt)
        {
            Name = name;
            Strength = strength;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Speed = speed;
            Door = door;
            MonsterArt = monsterArt;
        }

        public void TakeDamage(double DamageTaken)
        {
            CurrentHealth -= DamageTaken;
        }
        public void PrintMonsterArt()
        {
            Console.WriteLine();
            Console.WriteLine(MonsterArt);
            Console.WriteLine();
        }
        public void AddToDrops(Item item)
        {
            Drops.Add(item);
        }
        public Item DetermineDrop()
        {
            //the default drop is a health potion which heals 10 health
            if (Drops.Count <= 0)
            {
                HealthPotion potion = new HealthPotion("10 Health Potion",10);
                return potion;
            }
            //randomizing drop
            int dropIndex = rnd.Next(0, Drops.Count);
            return Drops[dropIndex];
        }
    }
}
