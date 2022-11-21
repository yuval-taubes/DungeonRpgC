using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRpg.Classes.PlayerFolder
{
    internal class Player : IEntity
    {
        public string Name;

        public double Strength { get; private set; }

        public double BaseDefense { get; private set; }

        public double Speed { get; private set; }

        public double MaxHealth { get; private set; }

        public double CurrentHealth { get; private set; }

        public Sword CurrentWeapon { get; set; }

        public Shield CurrentShield { get; set; }

        public List<Item> Items { get; private set; } = new();

        public int AttemptedDungeons { get; private set; } = 0;

        public int ClearedDungeons { get; private set; } = 0;

        public Player(double baseStrength, double baseDefense, double maxHealth, double speed)
        {
            Strength = baseStrength;
            BaseDefense = baseDefense;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Speed = speed;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void TakeDamage(double DamageTaken)
        {
            CurrentHealth -= DamageTaken;
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void EquipWeapon(Sword sword)
        {
            CurrentWeapon = sword;
        }
        public void EquipShield(Shield shield)
        {
            CurrentShield = shield;
        }
        public void Heal(HealthPotion potion)
        {
            CurrentHealth += potion.HealValue;

            if (CurrentHealth > MaxHealth)
            {
                Console.WriteLine("the potion healed you to max");
                CurrentHealth = MaxHealth;
                return;
            }
            Console.WriteLine($"The Potion healed you to {(int)CurrentHealth}");
        }
        public void IncreaseAttemptedGames()
        {
            AttemptedDungeons++;
        }
        public void IncreaseWonGames()
        {
            ClearedDungeons++;
        }
        public void PrintStats()
        {
            Console.WriteLine();
            Console.WriteLine($"{Name} has {Strength} strength");
            Console.WriteLine($"{Name} has {BaseDefense} defense");
            Console.WriteLine($"{Name} has {Speed} speed");
            Console.WriteLine($"{Name} has {MaxHealth} maxHealth");
            Console.WriteLine($"{Name} has {CurrentHealth} Current Health");
        }
        public void AccessBag()
        {
            List<string> options = new List<string>();
            options.Add("Exit");
            foreach (Item item in Items)
            {
                options.Add(item.Name);
            }
            Menu bagMenu = new Menu("Bag", options);

            int optionChosen = bagMenu.RunMenu();

            //if the chosen option was exit, exit the function
            if (optionChosen == 0)
            {
                return;
            }

            //we have to subtract 1 becasue we add exit
            Item itemChosen = Items[optionChosen - 1];

            //I thought this was a cool way to do a universal bag
            if (itemChosen is Sword)
            {
                SwordOptionsBag(itemChosen);
            }
            else if (itemChosen is Shield)
            {
                ShieldOptionsBag(itemChosen);
            }
            else
            {
                PotionsOptionsBag(itemChosen);
            }
        }
        private void SwordOptionsBag(Item item)
        {
            //not ideal to use a cast, but since i make sure its a shield its ok to use
            Sword chosenSword = (Sword)item;

            List<string> options = new List<string>()
            {
                "Description",
                "Equip",
                "Exit",
            };

            Menu SwordMenu = new Menu($"What to do with {chosenSword.Name}", options);

            switch (SwordMenu.RunMenu())
            {
                case 0:
                    Console.WriteLine(chosenSword.Description);
                    Console.ReadKey();
                    SwordOptionsBag(item);
                    break;
                case 1:
                    Console.WriteLine($"{chosenSword.Name} equipped in sword slot");
                    this.EquipWeapon(chosenSword);
                    break;
                case 2:
                    return;
                    break;
            }
        }
        private void ShieldOptionsBag(Item item)
        {
            //not ideal to use a cast, but since i make sure its a shield its ok to use
            Shield chosenShield = (Shield)item;

            List<string> options = new List<string>()
            {
                "Description",
                "Equip",
                "Exit",
            };

            Menu ShieldMenu = new Menu($"What to do with {chosenShield.Name}", options);

            switch (ShieldMenu.RunMenu())
            {
                case 0:
                    Console.WriteLine(chosenShield.Description);
                    Console.ReadKey();
                    ShieldOptionsBag(item);
                    break;
                case 1:
                    Console.WriteLine($"{chosenShield.Name} equipped in shield slot");
                    this.EquipShield(chosenShield);
                    break;
                case 2:
                    return;
                    break;
            }
        }
        private void PotionsOptionsBag(Item item)
        {

            //not ideal to use a cast, but since i make sure its a shield its ok to use
            HealthPotion potion = (HealthPotion)item;

            List<string> options = new List<string>()
            {
                "Description",
                "Use",
                "Exit",
            };

            Menu ShieldMenu = new Menu($"What to do with {potion.Name}", options);

            switch (ShieldMenu.RunMenu())
            {
                case 0:
                    Console.WriteLine(potion.Description);
                    Console.ReadKey();
                    PotionsOptionsBag(item);
                    break;
                case 1:
                    Console.WriteLine($"Using {potion.Name}");
                    this.Heal(potion);
                    Items.Remove(potion);
                    break;
                case 2:
                    return;
                    break;
            }
        }
    }
}
