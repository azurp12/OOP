
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopHomework {
    public class Program {
        static void Main(string[] args) {
            DateTime YourEndDate = new DateTime(2021,9,8);
            DateTime YourStartDate = new DateTime(2021,1,1);
            int TotalDays = (YourEndDate - YourStartDate).Days;
            decimal percentofyear = TotalDays / 365m;
            decimal y = 225647m * 0.6849315068493150684931506849M;
            decimal x = 225647m + y;
            Work work = new Work();
            work.DoWorkV1();
            //Console.WriteLine("Do Version 2");
            //Console.ReadKey();
            work.DoWorkV2();
        }
    }

    public interface ICharacter {
        void Construct(string name, int health, int armor, int armorMod);
        void SetName();
        void SetHealth();
        void SetArmor();
        void SetArmorMod();
        string GetName();
        int GetHealth();
        int GetArmor();
        int GetArmorMod();
    }

    public interface IItem {
        void Construct(string name, string type, int armorMod);
        string GetName();
        string GetArmorType();
        int GetArmorMod();
    }
fefefe
    public class Character : ICharacter {
        private string name { get; set; }
        private int health { get; set; }
        private int armor { get; set; }
        private int armorMod { get; set; }

        public void Construct(string name, int health, int armor, int armorMod) {
            this.name = name;
            this.health = health;
            this.armor = armor;
            this.armorMod = armorMod;
        }

        public string GetProfile() {
            return CuttingProfile;
        }

        public decimal GetShaftDiameter() {
            return ShaftDiameter; 
        }
        public string GetShaftMaterial() {
            return ShaftMaterial;
        }
        public decimal GetShaftLength() {
            return ShaftLength;
        }
    }
fefefefe

    public class Router : IRouter {
        private decimal ShaftDiameter { get; set; }
        private decimal ShaftLength { get; set; }
        private string ShaftMaterial { get; set; }

        private IRouterBit RouterBit { get; set; }

        public void Construct(decimal shaftDiameter, decimal shaftLength, string shaftMaterial) {
            ShaftDiameter = shaftDiameter;
            ShaftLength = shaftLength;
            ShaftMaterial = shaftMaterial;
        }

        public void TurnOn() {
            Console.WriteLine("I'm running :) ");
        }
        public void TurnOff() {
            Console.WriteLine("I'm not running :( ");
        }
        public void AddBit(IRouterBit routerBit) {
            if (routerBit.GetShaftDiameter() == ShaftDiameter && routerBit.GetShaftLength() == ShaftLength && routerBit.GetShaftMaterial() == ShaftMaterial) {
                RouterBit = routerBit;
                Console.WriteLine("Adding Bit");
            } else {
                Console.WriteLine("Bit does not fit this Router!!!!!!!");
            }
        }
        public void RemoveBit() {
            RouterBit = null;
            Console.WriteLine("Removing Bit");
        }
        public void Shape() {
            Console.WriteLine("Making the wood fly with profile " + RouterBit.GetProfile());
        }
    }

    public class Work {
        private IRouterBit RouterBitA { get; set; }
        private IRouterBit RouterBitB { get; set; }
        private IRouterBit RouterBitC { get; set; }

        private IRouterBit BigRouterBitA { get; set; }
        private IRouterBit BigRouterBitB { get; set; }
        private IRouterBit BigRouterBitC { get; set; }

        private IRouter BigRouter { get; set; }
        private IRouter SmallRouter { get; set; }

        public void DoWorkV1() {
            MakeBits();
            MakeRouter();
            Shape();
            Console.ReadKey();
        }

        public void DoWorkV2() {
            MakeBits();
            MakeRouterV2();
            ShapeV2();
            Console.ReadKey();
        }


            private void MakeBits() {
            RouterBitA = new RouterBit();
            RouterBitA.Construct(.25m, 2.0m, "steel", "profileA");

            RouterBitB = new RouterBit();
            RouterBitB.Construct(.25m, 2.0m, "steel", "profileB");

            RouterBitC = new RouterBit();
            RouterBitC.Construct(.25m, 2.0m, "steel", "profileC");

            BigRouterBitA = new RouterBit();
            BigRouterBitA.Construct(.5m, 2.0m, "steel", "profileA");

            BigRouterBitB = new RouterBit();
            BigRouterBitB.Construct(.5m, 2.0m, "steel", "profileB");

            BigRouterBitC = new RouterBit();
            BigRouterBitC.Construct(.5m, 2.0m, "steel", "profileC");
        }

        private void MakeRouter() {
            SmallRouter = new Router();
            SmallRouter.Construct(.25m, 2.0m, "steel");

            BigRouter = new Router();
            BigRouter.Construct(.5m, 2.0m, "steel");
        }

        private void MakeRouterV2() {
            SmallRouter = new RouterV2();
            SmallRouter.Construct(.25m, 2.0m, "steel");

            BigRouter = new RouterV2();
            BigRouter.Construct(.5m, 2.0m, "steel");
        }

        public void Shape() {
            Console.WriteLine("Add Bit");
            Console.ReadKey();
            SmallRouter.AddBit(RouterBitA);
            Console.WriteLine("Turn On");
            Console.ReadKey();
            SmallRouter.AddBit(RouterBitA);
            SmallRouter.TurnOn();
            Console.WriteLine("Shape");
            SmallRouter.Shape();
            Console.WriteLine("Turn Off");
            Console.ReadKey();
            SmallRouter.TurnOff();
            Console.WriteLine("Remove Bit");
            Console.ReadKey();
            SmallRouter.RemoveBit();
            Console.WriteLine("Add Bit");
            Console.ReadKey();
            SmallRouter.AddBit(RouterBitB);
            Console.WriteLine("Turn On");
            Console.ReadKey();
            SmallRouter.TurnOn();
            Console.WriteLine("Shape");
            SmallRouter.Shape();
            Console.WriteLine("Change Bits");
            Console.ReadKey();
            SmallRouter.RemoveBit();
            Console.WriteLine("Houston!! We have bits of fingers flying");
            Console.ReadKey();
        }

        public void ShapeV2() {
            SmallRouter.AddBit(RouterBitA);
            SmallRouter.TurnOn();
            SmallRouter.Shape();
            Console.WriteLine("Change Bits");
            Console.ReadKey();
            SmallRouter.TurnOff();
            SmallRouter.RemoveBit();
            SmallRouter.AddBit(RouterBitB);
            SmallRouter.TurnOn();
            SmallRouter.Shape();
            Console.WriteLine("Change Bits");
            Console.ReadKey();
            SmallRouter.RemoveBit();
            Console.WriteLine("Houston!! We Save the Users Fingers");
            Console.ReadKey();
        }
    }

    public class RouterV2 : IRouter {
        private decimal ShaftDiameter { get; set; }
        private decimal ShaftLength { get; set; }
        private string ShaftMaterial { get; set; }
        public bool OnState { get; private set; }
        public bool HasBitState { get; private set; }

        IRouterBit RouterBit { get; set; }

        public RouterV2() {
            OnState = false;
            HasBitState = false;
        }

        public void Construct(decimal shaftDiameter, decimal shaftLength, string shaftMaterial) {
            ShaftDiameter = shaftDiameter;
            ShaftLength = shaftLength;
            ShaftMaterial = shaftMaterial;
        }

        public void TurnOn() {
            if(OnState == true) {
                Console.WriteLine("I'm already running, DUH!!! ");
            } else {
                OnState = true;
            }
            Console.WriteLine("I'm running :) ");
        }
        public void TurnOff() {
            if (OnState == false) {
                Console.WriteLine("I'm already off, DUH!!! ");
            } else {
                OnState = false;
            }
            Console.WriteLine("I'm not running :( ");
        }
        public void AddBit(IRouterBit routerBit) {

            if(OnState == true) {
                Console.WriteLine("I'm running!!!!!");
                return;
            }

            if(HasBitState == true) {
                Console.WriteLine("Can't add a bit. I have one installed");
                return;
            }

            if (routerBit.GetShaftDiameter() == ShaftDiameter && routerBit.GetShaftLength() == ShaftLength && routerBit.GetShaftMaterial() == ShaftMaterial) {
                RouterBit = routerBit;
                HasBitState = true;
                Console.WriteLine("Adding Bit");
            } else {
                Console.WriteLine("Bit does not fit this Router!!!!!!!");
            }
        }
        public void RemoveBit() {

            if (OnState == true) {
                Console.WriteLine("I'm running!!!!!");
                return;
            }

            if (HasBitState == true) {
                RouterBit = null;
                HasBitState = false;
                Console.WriteLine("Removing Bit");
            } else {
                Console.WriteLine("I don't have a bit installled");
            }         
            
        }
        public void Shape() {
            if (OnState == true && HasBitState == true){
                Console.WriteLine("Making the wood fly with profile " + RouterBit.GetProfile());
            }
        }
    }
}

