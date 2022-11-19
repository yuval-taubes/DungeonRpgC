using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.DungeonFolder
{
    internal class Dungeon
    {
        public string Name { get; private set; }
        public List<Room> Rooms { get; private set; } = new();

        public Player Player { get; private set; }
        
        public Dungeon(string name, Player player)
        {
            Name = name;
            Player = player;
        }
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }
        public void EnteringDungeon()
        {
            Console.Clear();
            Console.WriteLine("The first door of the dungeon");
            Console.WriteLine($"{Rooms[0].Monster.Door.DoorArt}");
            Console.WriteLine("Press any key to enter the door");
            Console.ReadKey();
            Console.WriteLine("You enter the door");
            Console.Clear();
            Encounter firstFight = new Encounter(Player, Rooms[0].Monster);
            Rooms.Remove(Rooms[0]);
            firstFight.DetermineFirstAction();

            TwoDoors();
        }
        public void DoorMenu() {
            
        }
        public void TwoDoors()
        {

            if (Rooms.Count < 2)
            {
                Console.WriteLine("Error not enough Rooms");
                return;
            }

            Console.Clear();
            Console.WriteLine("You come accross two more doors");
            Console.WriteLine($"{Rooms[0].Monster.Door.DoorArt}         {Rooms[0].Monster.Door.DoorArt}");
            Console.WriteLine();
            Console.ReadKey();

            List<string> options = new List<string>()
            {
                "Door 1",
                "Door 2",
            };

            Menu menu = new Menu("Choose a Door", options);
        }
    }
}
