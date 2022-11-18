using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.PlayerFolder
{
    internal class Player
    {
        public string Name;
        public double BaseStrength { get; private set; }

        public double BaseDefense { get; private set; }

        public double Speed { get; private set; }
        public double MaxHealth { get; private set; }

        public double CurrentHealth { get; set; }

        public Sword CurrentWeapon { get; set; }

        public Shield CurrentShield { get; set; }

        public Player(double baseStrength, double baseDefense, double maxHealth)
        {
            BaseStrength = baseStrength;
            BaseDefense = baseDefense;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
        public void SetName(Game game)
        {
            Name = game.Name;
        }

    }
}
