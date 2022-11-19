using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.Tools
{
    internal class Shield
    {
        public double BlockChance { get; private set; }

        public double EvadeChance { get; private set; }

        public double Defense { get; private set; }

        public bool CanDodge { get; private set; } = false;
        public Shield(double blockChance, double evadeChance, double defense)
        {
            BlockChance = blockChance;
            EvadeChance = evadeChance;
            Defense = defense;
        }
        public Shield(double blockChance, double evadeChance, double defense, bool canDodge)
        {
            BlockChance = blockChance;
            EvadeChance = evadeChance;
            Defense = defense;
            CanDodge = canDodge;
        }
    }
}
