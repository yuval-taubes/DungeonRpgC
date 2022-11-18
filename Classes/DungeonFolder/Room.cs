using DungeonRpg.Classes.PlayerFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonRpg.Classes.DungeonFolder
{
    internal class Room
    {
        private Player _player { get; set; }
        public Monster Monster { get; private set; }
        public Room(Monster monster)
        {
            Monster = monster;
        }

    }
}
