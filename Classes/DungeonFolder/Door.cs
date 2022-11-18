using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.DungeonFolder
{
    internal class Door
    {
        public string DoorArt { get; set; }

        public Door(string doorArt)
        {
            DoorArt = doorArt;
        }
        public void PrintDoorArt()
        {
            Console.WriteLine(DoorArt);
        }
    }
}
