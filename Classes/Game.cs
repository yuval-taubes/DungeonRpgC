using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes
{
    internal class Game
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public List<Menu> Menus { get; private set; } = new();
        public Game(string name)
        {
            Name = name;
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

            UserName = userInput;

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
            return UserName;
        }
        public void AddMenu(Menu menu)
        {
            Menus.Add(menu);
        }
        public void EnterDungeon(Dungeon dungeon, Player player)
        {
            Console.WriteLine("You enter a cave in the ground an come accross a Dungeon");
            Console.WriteLine($"Entering the {dungeon.Name} with player {player.Name}");
        }


    }
}
