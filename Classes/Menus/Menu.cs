using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.Menus
{
    internal class Menu
    {
        private List<string> Options;
        private string Prompt;
        private int SelectedOption = 0;
        //because i want to print this with every menu, it has to be static
        private static string Title = @"
            ________                                              __________        .__    .___            
            \______ \  __ __  ____    ____   ____  ____   ____    \______   \_____  |__| __| _/___________ 
             |    |  \|  |  \/    \  / ___\_/ __ \/  _ \ /    \    |       _/\__  \ |  |/ __ |/ __ \_  __ \
             |    `   \  |  /   |  \/ /_/  >  ___(  <_> )   |  \   |    |   \ / __ \|  / /_/ \  ___/|  | \/
            /_______  /____/|___|  /\___  / \___  >____/|___|  /   |____|_  /(____  /__\____ |\___  >__|   
                    \/           \//_____/      \/           \/           \/      \/        \/    \/       
            ";

        //since monster art is different for every monster, and i want the monster to appear on the menu I had to use a static string
        public static string MonsterArt { get; private set; }
        public Menu(string prompt, List<string> option)
        {
            Prompt = prompt;
            Options = option;
        }

        //this code is from the in class example
        private void DisplayOptions()
        {
            //printing title and art before every menu
            Console.WriteLine(Title);
            Console.WriteLine(MonsterArt);
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Count; i++)
            {
                string currentOption = Options[i];
                int currentIndex = i + 1;


                if (i == SelectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine($"{currentIndex}. {currentOption}");
                Console.ResetColor();
            }
        }

        private void OptionInRange()
        {
            if (SelectedOption < 0)
            {
                SelectedOption = Options.Count - 1;
            }
            else if (SelectedOption > Options.Count - 1)
            {
                SelectedOption = 0;
            }
        }

        public int RunMenu()
        {
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                DisplayOptions();
                keyPressed = Console.ReadKey(true).Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedOption--;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedOption++;
                }

                OptionInRange();

            } while (keyPressed != ConsoleKey.Enter);

            // while the key pressed is not the enter key
            // keep on keepin on
            return SelectedOption;
     
        }
        public void SetMonsterArt(string art)
        {
            MonsterArt = art;
        }
        public void ClearMonsterArt()
        {
            MonsterArt = "";
        }

    }
}
