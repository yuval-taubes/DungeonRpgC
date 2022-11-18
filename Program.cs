﻿global using DungeonRpg.Classes.DungeonFolder;
global using DungeonRpg.Classes.PlayerFolder;
global using DungeonRpg.Classes.MonsterFolder;
global using DungeonRpg.Classes.Tools;
global using DungeonRpg.Classes.Menus;
global using DungeonRpg.Classes;

using System.Threading;

namespace DungeonRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Dungeon Slayer");
            Player player = new Player(10, 11, 50);

            Dungeon dungeon = new Dungeon("Cave of Death", player);

            Sword excalibur = new Sword(100, "Excalibur");
            Shield starterShield = new Shield(4, 2, 1);



            Door door1 = new Door(@"
            %%%%%%%%%%%%%%%%%%%%&&&%%%%%%%%#%&%%%%,.,.,%%&&%%%%%%%%&&%%%&%%%%&&&&&&&&&&&&&&&
            %%%%%%%%%%%%%%%%%%%%&&&%%%%%#%%%%%%%%%%%%%%%%%%%%%%%%%&&&&%%%%%&%&&&&&&&&&&&&&&&
            %%%%%%%%%%%%%%%%%%%%%&#%%%%%%%#(/(*/(((*###//*(((#%&%%%%%%%%%%&&%&&&&&&&&&&&&&&&
            %%%%%%%%%%%%%%%%%%#%%&%%(/(((#(#/(//#(#*(##///(((##((#((##%%%%&&%&&&&&&&&&&&&&&&
            #%%%#%%%#%%%#%%%%%%%(((////((#//////((#*#(#(//(((#(((((((/#%#%%%%%##############
            #############%%%%(((/((//,/((#//(/*/((#*###(//((((#(((((*/(#/((%%%%#%%%%%%%%%%%%
            %%%%%%%%%%%%%%&((//(/(//*//((#/((///(((/###(//((((#((((/(((((#///#%%%%%%%%%%%%%%
            #%%%%%%%%%%%%#((#/*//(///(//##%%%%%%%%%%%%%%%%%%%%%(##/(/((#((/////%%%%%%%%%%%%%
            %%%%%%%%%%%%((/((/*(/(*/(//((#%%%@@%@@@@%@@@%@@@%%%((/((/((#(((/////(%%%########
            %%%%%%%%%%&(/(((((*(/(/*////##%%%@@%@@@@%@@@%@@@%&%((((//((##((////*/#%%%#######
            %%%%%%%%%%((/((##(*(/(/((///(#%%%@@%@@@@%@@@%@@@%%%((((((((##((//*(*/(#%%%%%%%%%
            ######%%%#((((((((/(/(/((///((%%%@@%@@@@%@@@%@@@%%%(#(((/(###((/(///(/(%%%%%%%%%
            %%%%%%%##%(//((((//(((((/*//((%%%@@%@@@@%@@@%@@@%%%/(#(//(###(#(/*//((#%%%%%%%%%
            %%%%%%%%#%#/(((((((((//((/(*((%%%%%%%%%%%%%%%%%%%%%(((((/(((%(((////(/(%%%%%%%&&
            %%%%%%%%%%(((((#(((((///*/*/((%%%%%%%%%%%%%%%%%%%%#((((((((#%##(////(/(%%#%%&&&&
            %%%%%%%%%%(((((#(((((/(//**/((//(////((/((((((/(((#(#(((/(#%%##(///*&&&%%%%%%%%%
            %%%%%%&%%%%%%%%##(#/((((///(#////#(/*((/((##///(((#((((((/##%#(((/*/&@&&%%&&&&%%
            &&&&&&&&&%%%%%%%%%%%%%#%%%%%%%%%%%%%%%%%%%%%%%%%/(#(((((/((###((//(/&&%&%%%%%%%%
            &&&%@&&&%%##((((((%/((//(//((//((*((/((/(((/(///((#/((((/(#(%#(//((/&&%%%%%%%%%%
            &&&&&%%&%%#((/((((%(/(/*/(/(#//((((//#(/(((/(//(((%(((((((##%#(///((/(/%%%%%%%%%
            %&&&&%%%%%#(/(((((%(*(/////((//(((/((#(/(##/(/(/(##(((((((##&%%%/(///(/%%%######
            %&&&%%%%%%((/((##(%(/(//////(//((/(//#(/(#(/(/(((##(((((/#%%%&&&%%%/(/(%%%%%%%%%
            &%%%%%%%%%#(((((((%(((//(((/(*/((((//#(/(##((/(((##((#((#%%%%%%%%%%%#((%%%%%%%%%
            %%%%%%%%%%#(((((((%((/(/////(//#((,/(##/(##((/((((#((((#%%%&&&&&&%%%((/%%%%%%%%%
            %%%%%%%%%%(((((((/#((/(*/*(/#*/((/*/(##/(##//*(((((((####%&&&&&&%&%%(((%%%%%%%%%
            %%%%%%%%%%((/(((((#((/(***((#*/((#*//((/(##(/*((((#((((##%&&&&@&&&%%#((%%%%%%%%%
            %%%%%%%%%%(((/((((#((/(**///(*/(/(**/#(*(#((//(((##((#####%&&&%%###(((#%%%%%%%%%
            %%%%%%%%%%((//(((((((/(//*//#///(////((/((((//((((#(((((((%%&%##(((((((%%%%%%%%%
            %%%%%%%%%&#(/((((((((/#/*///#//((//*/#(/(##((/(((##(((((/((#%#((/(%(/(/%%%%%%%%%
            %%%%%%%%%&#(/(((((//(/(/*(//(/*((*(//#(/(((//*(/((#//(((/(((#(*//((*/((%&%%%%%%%
            %%%%%%%%%&##((((((//(//**/(/((/((((//#(((#(/(//((##(((((/((##(////((/(/%%%%%%%%%
            %%%%%%%%%%#(((((((*//((*///((//(/#/((#((((#/(/(/((#((((((((((((/(*/*(/#%%%%%%%%%
            %%%%%%%%%%(((/((#(*//(//////(/*/(((*/#(/(#(/(///((#(((((/(((#(((///*(/(#%%%%%%%%
            %%%%%%%%%%(#((((((/(((///((//(*((////#(((#(/(///((%(((((/((((((/*((/(((%%%%%%%%%
            %%%%%%%%%%#(((((((//((/(##///(/((/(/(#(((##((/#//(%(((/(/(((((((*/*/((#%%%%%%%%%
            %%%%%%&&%%%%%%%%%%%&&&&&&&&&&&&&&%%%%%%%%%%%#%%//(%(((/(/((((((//(*/(/(%%%%%%%%%
            &&&@@@&&&%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#/((%(((((/((((#((//*/(*#%%%%%%%%%
            &&&&&#&&&%#((((((((/(////(//(#(/(((/(((#((/(((//((%(((((/((##((/*/*//*#%%%%%%%%%
            %%&&&&&%&%#(((((((#(/(///*//##(/((//(((#((((/*/(((&(#((((/(###//***//*(%%%%%%%%%
            &&&%%%%%%%%#((((((((//(////((#(/(((/(((#(((((/(//(%(((((((((#((///////%%%%%%%%%%
            &&&#%%%%%%%(((((((((/((/*/(/(#(/(///*((#((((////((&/((((/((#((/(////((%%%%%%%%%%
            %%%%%%%%&#&%%#((#####(#((((##%##(##((%#%###((((###&(##(((#####((((((#%&%%%%%%%%%
            &&&&&&&%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");

            string mantisArt = @"
                                        ,-.                               
                   ___,---.__          /'|`\          __,---,___          
                ,-'    \`    `-.____,-'  |  `-.____,-'    //    `-.       
              ,'        |           ~'\     /`~           |        `.      
             /      ___//              `. ,'          ,  , \___      \    
            |    ,-'   `-.__   _         |        ,    __,-'   `-.    |    
            |   /          /\_  `   .    |    ,      _/\          \   |   
            \  |           \ \`-.___ \   |   / ___,-'/ /           |  /  
             \  \           | `._   `\\  |  //'   _,' |           /  /      
              `-.\         /'  _ `---'' , . ``---' _  `\         /,-'     
                 ``       /     \    ,='/ \`=.    /     \       ''          
                         |__   /|\_,--.,-.--,--._/|\   __|                  
                         /  `./  \\`\ |  |  | /,//' \,'  \                  
                        /   /     ||--+--|--+-/-|     \   \                 
                       |   |     /'\_\_\ | /_/_/`\     |   |                
                        \   \__, \_     `~'     _/ .__/   /            
                         `-._,-'   `-._______,-'   `-._,-'";

            Monster mantis = new Monster("Mantis", 5, 5, 500, door1, mantisArt);

            Room room11 = new Room(mantis);
            Room room21 = new Room(mantis);
            Room room22 = new Room(mantis);
            Room room31 = new Room(mantis);
            Room room32 = new Room(mantis);
            Room room33 = new Room(mantis);
            Room room41 = new Room(mantis);
            Room room42 = new Room(mantis);
            Room room51 = new Room(mantis);

            dungeon.AddRoom(room11);
            dungeon.AddRoom(room21);
            dungeon.AddRoom(room22);
            dungeon.AddRoom(room31);
            dungeon.AddRoom(room32);
            dungeon.AddRoom(room33);
            dungeon.AddRoom(room41);
            dungeon.AddRoom(room42);
            dungeon.AddRoom(room51);

            player.CurrentWeapon = excalibur;
            player.CurrentShield = starterShield;
            game.StartGame();
            dungeon.EnteringDungeon();


        }
    }
}