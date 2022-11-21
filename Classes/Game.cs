using DungeonRpg.Classes.DungeonFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes
{
    internal class Game
    {
        public string Name { get; private set; }

        public Player Player { get; private set; }

        public List<Dungeon> Dungeons { get; private set; } = new();
        public Game(string name, Player player)
        {
            Name = name;
            Player = player;
        }
        public void AddDungeon(Dungeon dungeon)
        {
            Dungeons.Add(dungeon);
        }
        public void StartGame()
        {
            Console.WriteLine(@"
            ________                                              __________        .__    .___            
            \______ \  __ __  ____    ____   ____  ____   ____    \______   \_____  |__| __| _/___________ 
             |    |  \|  |  \/    \  / ___\_/ __ \/  _ \ /    \    |       _/\__  \ |  |/ __ |/ __ \_  __ \
             |    `   \  |  /   |  \/ /_/  >  ___(  <_> )   |  \   |    |   \ / __ \|  / /_/ \  ___/|  | \/
            /_______  /____/|___|  /\___  / \___  >____/|___|  /   |____|_  /(____  /__\____ |\___  >__|   
                    \/           \//_____/      \/           \/           \/      \/        \/    \/       
            ");

            string? userInput;
            bool isValid;

            do
            {
                userInput = GetUserInput("Please enter a UserName");
                isValid = ValidateUserInput(userInput);
            } while (isValid == false);

            Player.SetName(userInput);

            Player.PrintStats();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            StartMenu();
        }

        public void StartMenu()
        {
            List<string> options = new List<string>()
            {
                "View Statistics",
                "Show Inventory",
                "Enter Dungeon",
            };
            Menu menu = new Menu(" ", options);

            switch (menu.RunMenu())
            {
                case 0:
                    PrintStatistics();
                    
                    break;
                case 1:
                    Console.WriteLine("Bag was selected");
                    Player.AccessBag();
                    break;
                case 2:
                    DungeonMenu();
                    break;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            StartMenu();
        }
        public void DungeonMenu()
        {
            List<string> dungeonNames = new List<string>();
            foreach (Dungeon dungeon in Dungeons)
            {
                dungeonNames.Add(dungeon.Name);
            }
            Menu dungeonMenu = new Menu("Select a Dungeon", dungeonNames);

            int OptionChosen = dungeonMenu.RunMenu();
            Dungeon dungeonChosen = Dungeons[OptionChosen];

            dungeonChosen.EnterDungeon();
        }
        private void PrintStatistics()
        {
            Console.WriteLine($"{Player.Name} has played {Player.AttemptedDungeons} dungeons and cleared {Player.ClearedDungeons} dungeons");
        }
        public string? GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            return input;
        }
        public bool ValidateUserInput(string? input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }
        public string GetUserName()
        {
            return Player.Name;
        }
        public void EnterDungeon(Dungeon dungeon, Player player)
        {
            Console.WriteLine("You enter a cave in the ground an come accross a Dungeon");
            Console.WriteLine($"Entering the {dungeon.Name} with player {player.Name}");
            dungeon.EnterDungeon();
        }

        //FISHER YATES SHUFFLE
    }
}
