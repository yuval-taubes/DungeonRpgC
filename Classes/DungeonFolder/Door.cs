using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.DungeonFolder
{
    internal class Door
    {
        //each monster has its own door, so while you are clearing a dungeon before you make your next choice you can see which monster is coming up
        //for the second dungeon this is huge because instead of fighting devils, you can fight skeletons, a much easier mob
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
