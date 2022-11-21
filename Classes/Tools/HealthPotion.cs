using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.Tools
{
    internal class HealthPotion : Item
    {
        public double HealValue { get; set; }

        public HealthPotion(string name, double healValue)
        {
            Name = name;
            Description = $"Use to recover {HealValue} health";
            HealValue = healValue;
        }
    }
}
