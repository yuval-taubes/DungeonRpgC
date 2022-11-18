using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.Tools
{
    internal class Sword
    {
        public string Name { get; set; }
        public double WeaponStrength { get; set; }
        public int SpecialAbility { get; set; }

        enum SpecialAbilties{
            MultiStrike = 1,
            UndeadBonus,



            OneShotOneKill = 666
        }

        public Sword(double weaponStrength, int specialAbility, string name)
        {
            WeaponStrength = weaponStrength;
            SpecialAbility = specialAbility;
            Name = name;
        }
        public Sword(double weaponStrength, string name)
        {
            WeaponStrength = weaponStrength;
            Name = name;
        }

    }
}
