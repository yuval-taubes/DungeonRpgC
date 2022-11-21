using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Interfaces
{
    internal interface IEntity
    {
        //this is used for Player, and monster to make sure the have required properties to fight
        public double Strength { get; }
        public double MaxHealth { get; }
        public double CurrentHealth { get;}
        public double Speed { get; }

        public void TakeDamage(double damage);
    }
}
