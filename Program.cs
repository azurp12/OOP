
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program {
    public class Program {
        static void Main(string[] args) {
            DateTime YourEndDate = new DateTime(2021,9,8);
            DateTime YourStartDate = new DateTime(2021,1,1);
            int TotalDays = (YourEndDate - YourStartDate).Days;
            decimal percentofyear = TotalDays / 365m;
            decimal y = 225647m * 0.6849315068493150684931506849M;
            decimal x = 225647m + y;
            //Work work = new Work();
            //work.DoWorkV1();
            //Console.WriteLine("Do Version 2");
            //Console.ReadKey();
            //work.DoWorkV2();
        }
    }

    public interface ICharacter {
        void Construct(string name, int health, int armor);
        void SetName(string name);
        void SetHealth(int health);
        void SetArmor(int armor);
        void SetArmorMod(int armorMod);
        void EquipItem(IItem helm);
        IItem[] GetEquipment();
        string GetName();
        int GetHealth();
        int GetArmor();
        int GetArmorMod();
        void AddArmorMod(int armorMod);
        void SubArmorMod(int armorMod);
        void AddHealth(int health);
        void SubHealth(int health);
        void UpdateArmorModTotal();
    }

    public interface IItem {
        void SetName(string name);
        void SetArmorMod(int armorMod);
        void SetArmorType(string type);
        string GetName();
        string GetArmorType();
        int GetArmorMod();
    }


    public class Character : ICharacter {
        private string name { get; set; }
        private int health { get; set; }
        private int armor { get; set; }
        private int TotalArmorMod { get; set; }

        private IItem helm = null;
        private IItem chest = null;
        private IItem shoes = null;

        public void Construct(string name, int health, int armor) {
            this.name = name;
            this.health = health;
            this.armor = armor;
            this.TotalArmorMod = 0;
        }

        public void AddArmorMod(int armorMod) {
            this.TotalArmorMod += armorMod;
        }

        public int GetArmor() {
            return this.armor;
        }

        public int GetArmorMod() {
            return this.TotalArmorMod;
        }

        public int GetHealth() {
            return this.health;
        }

        public string GetName() {
            return this.name;
        }

        public void SetArmor(int armor) {
            this.armor = armor;
        }

        public void SetArmorMod(int armorMod) {
            this.TotalArmorMod = armorMod;
        }

        public void SetHealth(int health) {
            this.health = health;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public void SubArmorMod(int armorMod) {
            this.TotalArmorMod -= armorMod;
        }

        public void AddHealth(int health) {
            this.health += health;
        }

        public void SubHealth(int health) {
            this.health -= health;
        }
        
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
        public IItem[] GetEquipment() {
            return new IItem[] {helm, chest,shoes};
        }

        public void UpdateArmorModTotal() {
            this.TotalArmorMod = helm.GetArmorMod() + chest.GetArmorMod() + shoes.GetArmorMod();
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
        private Character Char1 {get; set;}
        private Character Char2 {get; set;}
        private Character Char3 {get; set;}
        private IItem[] helms {get; set;}
        private IItem[] chests {get; set;}
        private IItem[] shoes {get; set;}

        private void CreateCharacters() {
            Char1 = new Character();
            Char2 = new Character();
            Char3 = new Character();

            Char1.Construct("Josh", 100, 5);
            Char2.Construct("Jacob", 80,10);
            Char3.Construct("Shayne", 125,0);
        }

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

    }
}

