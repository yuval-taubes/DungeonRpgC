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
        
        public int DungeonLength { get; private set;}

        private int CurrentRoom { get; private set;}

        public List<Monster> Monsters { get; private set;}

        private Random rnd = new Random();

        public Dungeon(string name, Player player, int dungeonLength)
        {
            Name = name;
            Player = player;
            DungeonLength = dungeonLength;
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
        public Menu DoorMenu() {
            List<string> options = new List<string>()
            {
                "Door 1",
                "Door 2",
            };
            Menu menu = new Menu("Choose a door", options);
            return menu;
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

        public void FirstRoom()
        {
            Monster monster = DetermineMonster();
            Console.Clear();
            Console.WriteLine("The first door of the dungeon");
            Console.WriteLine($"{monster.Door.DoorArt}");
            Console.WriteLine("Press any key to enter the door");
            Console.ReadKey();
            Console.WriteLine("You enter the door");
            Console.Clear();
            
            FightMonster(monster);

            CurrentRoom++;
        }
        public void DetermineNextDoor()
        {
            Monster monster1 = DetermineMonster();
            Monster monster2 = DetermineMonster();

            Console.WriteLine("You come across 2 more doors");
            Console.WriteLine($"{monster1.Door.DoorArt}                 {monster2.Door.DoorArt}");

            Menu menu = DoorMenu();

            menu.RunMenu();

            switch (menu.RunMenu())
            {
                case 0:
                Console.WriteLine("You choose door 1");
                Console.WriteLine("Press any key to enter door");
                Console.ReadKey();
                FightMonster(monster1);
                break;
                case 1:
                Console.WriteLine("You chose door 2");
                Console.WriteLine("Press any key to enter door");
                Console.ReadKey();
                FightMonster(monster2);

                break;
            }



            
        }
        public void FightMonster(Monster monster)
        {
            Encounter fight = new Encounter(Player, monster);
            fight.DetermineFirstAction();
        }
        public Monster DetermineMonster()
        {
            int monsterIndex = rnd.Next(0, Monsters.Count);
            return Monsters[monsterIndex];
        }
        
    }
}
