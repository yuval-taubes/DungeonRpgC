using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.Tools
{
    internal class Sword : Item
    {
        public double WeaponStrength { get; set; }
        public int SpecialAbility { get; set; }

        public Sword(double weaponStrength, string name)
        {
            WeaponStrength = weaponStrength;
            Name = name;
            Description = $"A weapon used for Clearing Dungeons, {WeaponStrength} damage";
        }
    }
}
