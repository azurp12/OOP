
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Program {
    public class Program {
        static void Main(string[] args) {
            OutfitCharacters begin = new OutfitCharacters();
            begin.CreateCharacters(4);
            Combat fight = new Combat(begin.GetFirstFighter(), begin.GetSecondFighter());
            fight.Fight();

        }
    }

    public interface IItem {
        void SetName(string name);
        void SetArmorMod(int armorMod);
        void SetArmorType(string type);
        string GetName();
        string GetArmorType();
        int GetArmorMod();
    }


    public class Character {
        private string name { get; set; }
        private int health { get; set; }

        private int CurrentHealth { get; set; }
        private int healthMod { get; set; }

        private IItem helm = null;
        private IItem chest = null;
        private IItem shoes = null;

        public Character(string name, int health) {
            this.name = name;
            this.health = health;
            this.CurrentHealth = 1;
        }

        public int GetHealth() => this.health;

        public int GetCurrentHealth() => this.CurrentHealth;

        public string GetName() => this.name;

        public void SetHealth(int health) => this.health = health;

        public void SetCurrentHealth(int currentHealth) => this.CurrentHealth = currentHealth;

        public void SetName(string name) => this.name = name;


        public void AddCurrentHealth(int health) => this.CurrentHealth += health;

        public void SubCurrentHealth(int health) => this.CurrentHealth -= health;

        public void EquipItem(IItem item) {
            switch (item.GetArmorType()) {
                case "helm":
                    this.helm = item;
                    break;
                case "chest":
                    this.chest = item; 
                    break;
                case "shoes":
                    this.shoes = item;
                    break;
            }
        }
        public int GetTotalHealth() {
            return this.health+this.healthMod;
        }
        public void ResetCurrentHealth() { this.CurrentHealth = GetTotalHealth();}
        public IItem[] GetEquipment() => new IItem[] { helm, chest, shoes };

        public void UpdateArmorModTotal() => this.healthMod = helm.GetArmorMod() + chest.GetArmorMod() + shoes.GetArmorMod();

        public void DisplayCharacter() => Console.WriteLine("Name: " + this.name + "\nHealth: " + this.CurrentHealth);

        public void DispalyEquipment() {
            Console.WriteLine(helm.GetName()+" "+helm.GetArmorType()+" health modifier:"+helm.GetArmorMod());
            Console.WriteLine(chest.GetName()+" "+chest.GetArmorType()+" health modifier:"+chest.GetArmorMod());
            Console.WriteLine(shoes.GetName()+" "+shoes.GetArmorType()+" health modifier:"+shoes.GetArmorMod());
        }
    }

    public class Item : IItem
    {
        private string name {get; set;}
        private string type {get; set;}
        private int armorMod {get; set;}  
        public Item(string name, string type, int armorMod)
        {
            this.name = name;
            this.type = type; 
            this.armorMod = armorMod;
        }

        public int GetArmorMod()
        {
            return this.armorMod;
        }

        public string GetArmorType()
        {
            return this.type;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetArmorMod(int armorMod)
        {
            this.armorMod = armorMod;
        }

        public void SetArmorType(string type)
        {
            this.type = type;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }

    public class OutfitCharacters {
        private Character[] Chars {get; set;}
        private IItem[] helms {get; set;}
        private IItem[] chests {get; set;}
        private IItem[] shoes {get; set;}
        private Character FirstFighter {get; set;} 
        private Character SecondFighter {get; set;} 

        public void CreateCharacters(int number) {
            Random random = new Random();
            Chars = new Character[number];
            for (int i = 0; i < number; i++) {
                Chars[i] = new Character(CreateChracterName(),random.Next(51)+5);
            }
            CreateItems();
            EquipItems();
            GetFightersReady();
            
        }

        private void GetFightersReady() {
            SelectFighters();
            
            FirstFighter.UpdateArmorModTotal();
            FirstFighter.ResetCurrentHealth();
            SecondFighter.UpdateArmorModTotal();
            SecondFighter.ResetCurrentHealth();
        }

        public Character GetFirstFighter() => this.FirstFighter;
        public Character GetSecondFighter() => this.SecondFighter;

        private void CreateItems() {
            Random random = new Random();
            helms = new Item[50];
            for (int i = 0;i<helms.Length;i++) {
                helms[i] = new Item(HelmName(), "helm", random.Next(40)+10);
            }
            chests = new Item[50];
            for (int i = 0;i<chests.Length;i++) {
                chests[i] = new Item(ChestName(), "chest", random.Next(80)+20);
            }
            shoes = new Item[50];
            for (int i = 0;i<shoes.Length;i++) {
                shoes[i] = new Item(ShoeName(), "shoes", random.Next(20)+5);
            }
        }

        private static string HelmName() {
            Random random = new Random();
            string[] names = {
                "Casque of Ending Fortunes",
                "Headguard of Doomed Dreams",
                "Ebon Casque of Hellish Dreams",
                "Golden Helm of Broken Punishment",
                "Sorrow's Adamantite Helm",
                "Malignant Bronze Greathelm",
                "Infused Headguard of the Berserker",
                "Enchanted Faceguard of Blood",
                "Demise of the Nightstalker",
                "Helmet of Discipline"};
            return names[random.Next(names.Length)];
        }
        private static string CreateChracterName() {
            Random random = new Random();
            string [] names = {
                "Horace Osborne",
                "Wilbur Blackwell",
                "Warren Knight",
                "Edward Lamb",
                "Jack Emerson",
                "Brad Bailey",
                "Jacob Hunter",
                "Patrick Manning",
                "Jason Bowers",
                "Douglas Graham"};

            return names[random.Next(names.Length)];
        }
        private static string ChestName() {
            Random random = new Random();
            string[] names = {
                "Chestplate of Infinite Damnation",
                "Chestpiece of Infernal Hell",
                "Bronzed Armor of Silent Hells",
                "Scaled Chestpiece of Sacred Ancestors",
                "Vindicator Ivory Breastplate",
                "Vindication Scaled Chestpiece",
                "Oathkeeper's Armor of Heroes",
                "Challenger Chestpiece of the Depths",
                "Gift of Thunders",
                "Pact of Ancient Power"};
            
            return names[random.Next(names.Length)];
        }
        
        private static string ShoeName() {
            Random random = new Random();
            string[] names = {
                "Greatboots of Unholy Souls",
                "Footguards of Binding Glory",
                "Bone Sabatons of Conquered Powers",
                "Ebon Greaves of Ominous Fire",
                "Pride's Golden Greatboots",
                "Storm Bone Stompers",
                "Stormguard Titanium Treads",
                "Vanquisher Footguards of Thieves",
                "Honed Greaves of the Moon",
                "Brutality Greatboots of Visions"};
            return names[random.Next(names.Length)];
        }

        public void EquipItems() {
            Random random = new Random();
            for(int i = 0; i < Chars.Length;i++){
                Chars[i].EquipItem(helms[random.Next(helms.Length)]);
                Chars[i].EquipItem(chests[random.Next(chests.Length)]);
                Chars[i].EquipItem(shoes[random.Next(shoes.Length)]);
            }
        }
        public void SelectFighters() {
            Random random = new Random();
            FirstFighter = Chars[random.Next(Chars.Length)];
            SecondFighter = Chars[random.Next(Chars.Length)];
            while (SecondFighter == FirstFighter)
                SecondFighter = Chars[random.Next(Chars.Length)];
        }
    }

    public class Combat {
        private Character combatant1 {get; set;}
        private Character combatant2 {get; set;}
        public Combat(Character combatant1, Character combatant2) {
            this.combatant1 = combatant1;
            this.combatant2 = combatant2;
        }

        public void Fight() {
            Random random = new Random();
            int hit = 0;
            DisplayFightersFull();
            Console.WriteLine("\nThe program will resume in 10 seconds:");
            Thread.Sleep(10000);
            while (combatant1.GetCurrentHealth() > 0 && combatant2.GetCurrentHealth() > 0) {
                hit = random.Next(26);
                // fighter 1 goes
                CombatantHit(hit);
                DispalyHitCombatant(hit);
                
                // fighter 2 goes 
                hit=random.Next(26);
                CombatantHit(hit, false);
                DispalyHitCombatant(hit,false);

                // Display update
                DisplayFighters();
            }
            DisplayWinner();
        }

        private void DispalyHitCombatant(int hit, Boolean first = true) {
            if (first)
                Console.WriteLine(combatant1.GetName() +" hits "+ combatant2.GetName()+ " for " + hit+" points of damage.");
            
            else 
                Console.WriteLine(combatant2.GetName() +" hits "+ combatant1.GetName()+ " for " + hit+" points of damage.");

            Console.WriteLine("\n");
        }

        private void CombatantHit(int hit, Boolean first = true) {
            if (first)
                combatant2.SubCurrentHealth(hit);
            else
                combatant1.SubCurrentHealth(hit);
        }
        
        private void DisplayFightersFull() {
            Console.WriteLine("First Combatant:");
            combatant1.DisplayCharacter();
            combatant1.DispalyEquipment();
            Console.WriteLine("\nSecond Combatant:");
            combatant2.DisplayCharacter(); 
            combatant2.DispalyEquipment();
        }
        private void DisplayFighters() {
            Console.WriteLine("First Combatant:");
            combatant1.DisplayCharacter();

            Console.WriteLine("\nSecond Combatant:");
            combatant2.DisplayCharacter();
            Console.WriteLine("\n");
        }

        private void DisplayWinner() {
            if (combatant1.GetCurrentHealth() > 0 && combatant2.GetCurrentHealth() <= 0) 
                Console.WriteLine(combatant1.GetName()+" is the winner!");
            else if (combatant2.GetCurrentHealth() > 0 && combatant1.GetCurrentHealth() <= 0)
                Console.WriteLine(combatant2.GetName()+" is the winner!");
            else
                Console.WriteLine("They both died??");
        }

    }
}

