using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.Tools
{
    internal class Shield
    {
        public double BlockChance { get; set; }

        public double EvadeChance { get; set; }

        public double Defense { get; set; }


        public Shield(double blockChance, double evadeChance, double defense)
        {
            BlockChance = blockChance;
            EvadeChance = evadeChance;
            Defense = defense;
        }
    }
}
