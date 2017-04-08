using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet_Template
{

    class VirtualPet
    {

        private string name;
        private double hunger;
        private double thirst;
        private double waste;
        private double boredom;
        private double sick;

        // defaut constructor
        public VirtualPet()
        {
            this.name = "George";
            this.hunger = 5;
            this.thirst = 5;
            this.waste = 5;
            this.boredom = 5;
            this.sick = 5;
        }

        public VirtualPet(string name, double hunger, double thirst, double waste, double boredom, double sick)
        {
            this.name = name;
            this.hunger = hunger;
            this.thirst = thirst;
            this.waste = waste;
            this.boredom = boredom;
            this.sick = sick;
        }
      
        //this method can be called to change the hunger
        public void HungerChange(double change)
        {
            this.hunger = hunger + change;
        }

        //this method can be called to change the thirst
        public void ThirstChange(double change)
        {
            this.thirst = thirst + change;
        }

        //this method can be called to change the waste
        public void WasteChange(double change)
        {
            this.waste = waste + change;
        }

        //this method can be called to change the boredom
        public void BoredomChange(double change)
        {
            this.boredom = boredom + change;
        }

        //this method can be called to change the sickness
        public void SickChange(double change)
        {
            this.sick = sick + change;
        }

        //method for stats of virtual pet
        public void MyPetStatus()
        {
            Console.WriteLine("\r\n\t\t\t{0}'s status: )",name);
            Console.WriteLine("\t\t\tHunger:   " + hunger.ToString("#.0"));
            Console.WriteLine("\t\t\tThirst:   " + thirst.ToString("#.0"));
            Console.WriteLine("\t\t\tWaste :   " + waste.ToString("#.0"));
            Console.WriteLine("\t\t\tBoredom:  " + boredom.ToString("#.0"));
            Console.WriteLine("\t\t\tSickness: " + sick.ToString("#.0"));
        }

        //methods to make object states/attributes accessible from Program.cs
        public string GetName()
        {
            return name;
        }
        public double GetHunger()
        {
            return hunger;
        }
        public double GetThirst()
        {
            return thirst;
        }
        public double GetWaste()
        {
            return waste;
        }
        public double GetBoredom()
        {
            return boredom;
        }
        public double GetSick()
        {
            return sick;
        }

    }
}
