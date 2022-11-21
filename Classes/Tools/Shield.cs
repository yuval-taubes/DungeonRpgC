using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.Tools
{
    //Inheritance
    internal class Shield : Item
    {
        public double BlockChance { get; private set; }
        public double Defense { get; private set; }
        public bool CanDodge { get; private set; } = false;

        public Shield(string name, double blockChance, double defense)
        {
            Name = name;
            BlockChance = blockChance;
            Defense = defense;
            Description = $"A Shield, reduces incoming damage by {defense} and gives a chance to completely block all damage {blockChance}%";
        }
    }
}
