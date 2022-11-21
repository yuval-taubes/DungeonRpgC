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
        public Player Player { get; private set; }
        public int DungeonLength { get; private set; }
        private int CurrentRoom { get; set; }
        public List<Monster> Monsters { get; private set; } = new();

        //for convenience
        private Random rnd = new Random();

        public Dungeon(string name, Player player, int dungeonLength)
        {
            Name = name;
            Player = player;
            DungeonLength = dungeonLength;
        }
        public void AddMonster(Monster monster)
        {
            Monsters.Add(monster);
        }
        public Menu DoorMenu()
        {
            List<string> options = new List<string>()
            {
                "Door 1",
                "Door 2",
            };
            Menu menu = new Menu("Choose a door", options);
            return menu;
        }

        public void EnterDungeon()
        {
            Player.IncreaseAttemptedGames();
            Monster monster = DetermineMonster();
            Console.Clear();
            Console.WriteLine("The first door of the dungeon");
            Console.WriteLine($"{monster.Door.DoorArt}");
            Console.WriteLine("Press any key to enter the door");
            Console.ReadKey();
            Console.Clear();

            FightMonster(monster);

            //this counts how many rooms you have cleared
            CurrentRoom++;

            DetermineNextDoor();
        }
        public void DetermineNextDoor()
        {
            if (Player.CurrentHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine(@"
                _____.___.                ________   .__             .___
                \__  |   |  ____   __ __  \______ \  |__|  ____    __| _/
                 /   |   | /  _ \ |  |  \  |    |  \ |  |_/ __ \  / __ | 
                 \____   |(  <_> )|  |  /  |    `   \|  |\  ___/ / /_/ | 
                 / ______| \____/ |____/  /_______  /|__| \___  >\____ | 
                 \/                               \/          \/      \/ 
                ");
                return;
            }
            while (CurrentRoom != DungeonLength)
            {
                Monster monster1 = DetermineMonster();
                Monster monster2 = DetermineMonster();

                Console.WriteLine("You come across 2 more doors");
                Console.WriteLine(monster1.Door.DoorArt);
                Console.WriteLine();
                Console.WriteLine(monster2.Door.DoorArt);

                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();

                Menu menu = DoorMenu();

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

                CurrentRoom++;
            }
            //once you clear the room count you clear the dugeon, and increases your won games tracker
            Console.WriteLine(@"
            _________  .__                                      .___    ________                                                 
            \_   ___ \ |  |    ____  _____  _______   ____    __| _/    \______ \   __ __   ____    ____    ____   ____    ____  
            /    \  \/ |  |  _/ __ \ \__  \ \_  __ \_/ __ \  / __ |      |    |  \ |  |  \ /    \  / ___\ _/ __ \ /  _ \  /    \ 
            \     \____|  |__\  ___/  / __ \_|  | \/\  ___/ / /_/ |      |    `   \|  |  /|   |  \/ /_/  >\  ___/(  <_> )|   |  \
             \______  /|____/ \___  >(____  /|__|    \___  >\____ |     /_______  /|____/ |___|  /\___  /  \___  >\____/ |___|  /
                    \/            \/      \/             \/      \/             \/             \//_____/       \/             \/ 
            ");

            Player.IncreaseWonGames();
        }
        private void FightMonster(Monster monster)
        {
            Encounter fight = new Encounter(Player, monster);
            fight.DetermineFirstAction();
        }
        private Monster DetermineMonster()
        {
            //determining which monster is going to show up next
            int monsterIndex = rnd.Next(0, Monsters.Count);
            return Monsters[monsterIndex];
        }
    }
}
